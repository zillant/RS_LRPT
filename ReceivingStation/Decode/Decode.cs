using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using ReceivingStation.Other;
using Color = System.Drawing.Color;

namespace ReceivingStation
{
    class Decode
    {       
        public delegate void UpdateDateTimeDelegate(DateTime date);
        public UpdateDateTimeDelegate ThreadSafeUpdateDateTime;
        public delegate void UpdateMkoDelegate(string td, string oshv, string bshv, string pdcm);
        public UpdateMkoDelegate ThreadSafeUpdateMko;
        public delegate void UpdateImagesContentDelegate(DirectBitmap[] list);
        public UpdateImagesContentDelegate ThreadSafeUpdateImagesContent;
        public delegate void UpdateGuiDelegate();
        public UpdateGuiDelegate ThreadSafeUpdateGui;
        public delegate void StopDecodingDelegate();
        public StopDecodingDelegate ThreadSafeStopDecoding;

        private MaterialForm _form;
        private ReedSolo _reedSolo;
        private Viterbi _viterbi;
        private Jpeg _jpeg;
         
        private DateTime currentLineDate;

        private DirectBitmap[] _bmps = new DirectBitmap[6]; // Полосы изображений для каждого канала.

        private string _td;
        private string _oshv;
        private string _bshv;
        private string _pdcm;

        private string _fileName; // Имя открытого файла.
        private FileStream _fs; // Содержимое открытого .dat файла.
        private StreamWriter _sw;
        private string _decodeLogFileName; // Файл для записи информации.

        private uint Kol_tk; //Считает число транспортных кадров.       
        private byte[] tk_in = new byte[1020]; //Входящий транспортный кадр баз маркера(4 байта).
        private int ind_bt_in; //Счетчик принимаемых байт.

        private int kol_pix;
        private int kol_all;

        private byte[] in_buf = new byte[Constants.DL_IN_BUF];  //Входной буфер.
        private byte[] vit_buf = new byte[Constants.DL_VIT_BUF]; //Буфер после Витерби.
        private bool[] bits_buf = new bool[Constants.DL_IN_VIT_BUF]; //Битовый массив на 2048 байт.

        private int ind_tk_in;
        private int ind_vit; //Счетчик после витерби.

        // Для поиска маркера ТК.
        private byte mask_out_tk;
        private int Ind_mar_tk_bit;
        private bool Fl_err; // Флаг потери маркера ТК.
        private int cnt_mark; // Считаем биты маркера.

        // Для интерливинга.
        private bool _isInterliving; // Состояние checkBox "Интерливинг".
        private bool[] interl_buf = new bool[Constants.DL_INTRL_BUF];

        private int ind_mark_uw; //Индекс 0-80.
        private int beg_mark_uw; //Начало uw.
        private int ind_in_intrl, ind_out_intrl; //Индекс по буф.интерливинга.

        private bool fl_fool_buf;
        private int ind_small, ind_big, ind_fr;

        // Для проверки подлинности трансп. и парц. пакетов.
        private int tk_last; // Номер ТК.
        private long tm_last; // Последнее время.
        private int last_count_pac; // Запоминаем счетчик пакетов.
        private int apid; // Запоминаем последний апид.
        private int errs; // Накапливаем ошибки здесь.

        private bool _isReedSolo; // Состояние checkBox "Рида-Соломона".
        private byte Q_Value; // Фактор качества.
        private int dl_jpeg_in; //Длина данных jpeg.
        private int Xt, Yt;    //Индекс полосы при выводе.    

        // Для НРЗ.
        private bool _isNrz; // Состояние checkBox "НРЗ".
        private bool last_bit_in;

        #region Конструктор для открытого файла.
        public Decode(FormDecode form, string fileName, bool reedSoloFlag, bool nrzFlag)
        {
            _fileName = fileName;
            _isNrz = nrzFlag;
            _isReedSolo = reedSoloFlag;

            _reedSolo = new ReedSolo();
            _viterbi = new Viterbi();
            _jpeg = new Jpeg();
            _form = form;

            _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            _decodeLogFileName = $"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_info.txt";
            _sw = new StreamWriter(_decodeLogFileName, true, Encoding.UTF8, 65536);

            for (int i = 0; i < 6; i++)
            {
                _bmps[i] = new DirectBitmap(Constants.WDT, Constants.HGT);       
            }

            Init();
        }

        #endregion

        #region Конструктор для приемника.
        public Decode(FormReceive form, string fileName)
        {
            _isNrz = false;
            _isReedSolo = true;

            _reedSolo = new ReedSolo();
            _viterbi = new Viterbi();
            _jpeg = new Jpeg();
            _form = form;

            _decodeLogFileName = $"{fileName}_info.txt";
            _sw = new StreamWriter(_decodeLogFileName, true, Encoding.UTF8, 65536);

            for (int i = 0; i < 6; i++)
            {
                _bmps[i] = new DirectBitmap(Constants.WDT, Constants.HGT);
            }

            Init();
        }

        #endregion

        #region Начать декодирование для открытого файла.
        public void StartDecode(CancellationToken token)
        {
            int bytesCount;

            do
            {
                bytesCount = _fs.Read(in_buf, 0, Constants.DL_IN_BUF);

                if (bytesCount < 2048)
                {
                    break;
                }

                beg_mark_uw = Test_uw();
                _isInterliving = beg_mark_uw != -1;

                if (_isInterliving)
                {
                    beg_mark_uw = Test_uw();
                    Deinterl(); //деинтерливинг
                }
                else
                {
                    for (int i = 0; i < bytesCount; i += 2048)
                    {
                        To_bits(i);
                        ind_vit = _viterbi.DecodeViterbi(bits_buf, vit_buf);
                        Find_tk_in();
                    }
                }

            } while (!token.IsCancellationRequested);

            FinishDecode();
        }

        #endregion

        #region Начать декодирование для приемника.
        public void StartDecode(byte[] data)
        {
            Array.Copy(data, in_buf, data.Length);

            beg_mark_uw = Test_uw();
            _isInterliving = beg_mark_uw != -1;

            if (_isInterliving)
            {
                beg_mark_uw = Test_uw();
                Deinterl(); //деинтерливинг
            }
            else
            {
                for (int i = 0; i < Constants.DL_IN_BUF; i += 2048)
                {
                    To_bits(i);
                    ind_vit = _viterbi.DecodeViterbi(bits_buf, vit_buf);
                    Find_tk_in();
                }
            }             
        }

        #endregion

        #region Завершение декодирования.
        public void FinishDecode()
        {
            UpdateDataGui();

            _sw.WriteLine("-------------------------------------------------");
            _sw.WriteLine("------------------------------------------");
            _sw.WriteLine($"Всего найдено ошибок: {errs}");
            _sw.Close();

            _form.Invoke(new Action(() => { ThreadSafeStopDecoding(); }));
        }

        #endregion

        #region Инициализация переменных.
        private void Init()
        {
            ind_bt_in = 0;
            dl_jpeg_in = -1;
            ind_tk_in = 0;
            Kol_tk = 0;

            last_bit_in = Convert.ToBoolean(0);

            //Для поиска маркера ТК
            mask_out_tk = 0x80;
            Ind_mar_tk_bit = 0;
            Fl_err = true;      //первый поиск или потеря маркера ТК
            cnt_mark = 0;
            tk_in[0] = 0;

            //Для интерливинга
            ind_mark_uw = 0;
            fl_fool_buf = false;
            ind_small = 0;
            ind_big = 0;
            ind_fr = 0;
            ind_in_intrl = 0;
            ind_out_intrl = 0;
            beg_mark_uw = -1; //начало маркера интерливинга в битах

            // Для проверки подлинности парц. пакетов.
            tk_last = -1;
            tm_last = 0;
            last_count_pac = -1;
            apid = -1;
            errs = 0;       //считаем ошибки

            Yt = 0;
            kol_all = 0;
        }

        #endregion

        #region Поиск синхромаркера.
        private int Test_uw()
        {
            int kol;
            byte bt;

            for (int i = 0; i < Constants.DL_IN_BUF - 100; i++)
            {
                for (byte k = 0; k < 8; k++)
                {
                    kol = 0;

                    for (byte j = 0; j < 5; j++)
                    {
                        bt = Convert.ToByte(((in_buf[j * 10 + i] << k) & 0xFF) | (in_buf[j * 10 + i + 1] >> (8 - k)));

                        kol = bt == 0x27 ? kol + 1 : 0;

                        if (kol == 4) // Нашли синхромаркер.
                        {
                            return (i * 8 + k) % 80; // Битовый индекс начала синхромаркера uw.
                        }
                    }
                }
            }

            return -1;
        }

        #endregion

        #region Деинтерливинг.
        private void Deinterl()
        {
            int pos, beg;
            bool bit;
            byte tek_bt, tek_mask;

            if (80 - beg_mark_uw != ind_mark_uw) //Если потеря синхромаркера.
            {
                beg = beg_mark_uw / 8; // Байт, откуда начинаем.
                tek_mask = Convert.ToByte(0x80 >> (beg_mark_uw % 8));
                ind_mark_uw = 0;

                ind_in_intrl = 0; // Входной и выходной буферы.
                ind_out_intrl = 0;

                ind_small = 0;
                ind_big = 0;
                ind_fr = 0;
                fl_fool_buf = false;
            }
            else
            {
                beg = 0; // Байт, откуда начинаем.
                tek_mask = 0x80;
            }

            for (int i = beg; i < Constants.DL_IN_BUF; i++)
            {
                tek_bt = Convert.ToByte(in_buf[i]);

                while (Convert.ToBoolean(tek_mask))
                {
                    if (ind_mark_uw == 80)
                    {
                        ind_mark_uw = 0;
                    }

                    if (ind_mark_uw > 7) //Если находимся вне зоны маркера.
                    {
                        bit = Convert.ToBoolean(tek_bt & tek_mask);
                        interl_buf[ind_in_intrl++] = bit; // Набираем буфер.

                        if (ind_in_intrl == Constants.DL_INTRL_BUF) // Набрали буфер.
                        {
                            ind_in_intrl = 0;
                            fl_fool_buf = true;
                        }

                        if (fl_fool_buf)
                        {
                            pos = (ind_fr * 73728 + ind_small * 73728 + ind_small + ind_big * 36) %
                                  Constants.DL_INTRL_BUF;
                            bits_buf[ind_out_intrl++] = interl_buf[pos];

                            //Меняем индексы
                            ind_small++;

                            if (ind_small >= 36)
                            {
                                ind_small = 0;
                                ind_big++;

                                if (ind_big > 2047)
                                {
                                    ind_big = 0;
                                    ind_fr++;

                                    if (ind_fr >= 36)
                                    {
                                        ind_fr = 0;
                                    }
                                }
                            }

                            if (ind_out_intrl == Constants.DL_IN_VIT_BUF)
                            {
                                ind_out_intrl = 0;
                                ind_vit = _viterbi.DecodeViterbi(bits_buf, vit_buf);
                                Find_tk_in();
                            }
                        }
                    }
                    tek_mask = Convert.ToByte(tek_mask >> 1);

                    ind_mark_uw++;
                }
                tek_mask = 0x80;
            }
        }

        #endregion

        #region Преобразование в бит. поток 2048 байт.
        private void To_bits(int initialArrayIndex)
        {
            int ind, limitIndex;
            byte mask, bt;

            limitIndex = initialArrayIndex + 2048;
            ind = 0;

            for (; initialArrayIndex < limitIndex; initialArrayIndex++)
            {
                bt = Convert.ToByte(in_buf[initialArrayIndex]);
                mask = 0x80;

                while (Convert.ToBoolean(mask))
                {
                    bits_buf[ind++] = Convert.ToBoolean(bt & mask);
                    mask = Convert.ToByte(mask >> 1);
                }
            }
        }

        #endregion

        #region Разбирает кадр после Витерби и NRZ.
        private void Find_tk_in()
        {
            int i;
            byte mask_in;
            bool bit, b;

            for (i = 0; i < ind_vit; i++)
            {
                mask_in = 0x80;

                while (Convert.ToBoolean(mask_in))
                {
                    b = Convert.ToBoolean(vit_buf[i] & mask_in);

                    //-------NRZ--------------
                    if (_isNrz)
                    {
                        bit = b ^ last_bit_in;
                        last_bit_in = b;
                    }
                    else
                        bit = b;
                    //------------------------

                    if (Ind_mar_tk_bit < 32) //зона маркера тк
                    {
                        if (bit == Convert.ToBoolean(Constants.zag_tk_bit[Ind_mar_tk_bit]))
                        {
                            cnt_mark++; //считаем биты маркера
                        }
                        else
                        {
                            if (Fl_err) //если первый поиск или потеря
                            {
                                Ind_mar_tk_bit = Find_new_beg_zag(Ind_mar_tk_bit);
                                cnt_mark = 0;
                                mask_in = Convert.ToByte(mask_in >> 1);
                                continue;
                            }
                        }

                        Ind_mar_tk_bit++;

                        if (Ind_mar_tk_bit == 32)
                        {
                            if (cnt_mark == 32)
                            {
                                Fl_err = Convert.ToBoolean(0);
                            }

                            if (cnt_mark < 16)      //потеря маркера
                            {
                                Ind_mar_tk_bit = 0;
                                cnt_mark = 0;
                                Fl_err = Convert.ToBoolean(1);
                            }
                            else
                            {
                                ind_tk_in = 0;        //к началу набора кадра
                                mask_out_tk = 0x80;
                                tk_in[0] = 0;
                            }
                        }
                    }
                    else            //набор кадра
                    {
                        if (bit)
                        {
                            tk_in[ind_tk_in] |= mask_out_tk;
                        }

                        mask_out_tk = Convert.ToByte(mask_out_tk >> 1);

                        if (!Convert.ToBoolean(mask_out_tk))      //набрали байт
                        {
                            mask_out_tk = 0x80;
                            ind_tk_in++;

                            if (ind_tk_in == 1020)      //набрали кадр
                            {
                                Get_dat_tk();

                                ind_tk_in = 0;
                                Ind_mar_tk_bit = 0;
                                cnt_mark = 0;
                            }

                            tk_in[ind_tk_in] = 0;     //следующий байт
                        }

                    }
                    mask_in = Convert.ToByte(mask_in >> 1);
                }
            }
        }

        #endregion

        #region Индекс поиска нового начала заголовка.
        private int Find_new_beg_zag(int k)
        {
            int i, j, n, kol;
            bool[] buf = new bool[32];

            if (!Convert.ToBoolean(k))
            {
                return 0;
            }

            //Формируем полученную последовательность
            for (i = 0; i < k; i++)
            {
                buf[i] = Convert.ToBoolean(Constants.zag_tk_bit[i]);
            }

            buf[i] = !Convert.ToBoolean(Constants.zag_tk_bit[i]);    //след. бит

            kol = k + 1;

            for (i = k; i >= 0; i--)
            {
                n = 0;

                for (j = i; j < kol; j++)
                {
                    if (Convert.ToBoolean(Constants.zag_tk_bit[n]) != buf[j])
                    {
                        return (kol - i - 1);
                    }
                    
                    n++;
                }
            }

            return 0;
        }

        #endregion

        #region Расшифровка ТК.
        private void Get_dat_tk()
        {
            int i, beg, pr;
            ushort data;
            byte bt;
            
            _reedSolo.Decode_RS(tk_in, _isReedSolo);   //декодирование Рида-Соломона

            kol_all++;
            _sw.WriteLine($"Пакет № {kol_all}");
            WriteServiceDataToLogFile(tk_in, "ТК: ", 0, 10, 1);

            //Тестирование ТК
            if (tk_in[0] >> 6 != Constants.NOM_VER)	//проверка номера версии
            {
                _sw.WriteLine("    ----- ошибка номера версии структуры");
                errs++;
            }

            bt = Convert.ToByte(((tk_in[0] << 2) & 0xFF) | ((tk_in[1] >> 6) & 0xFF));
            if (bt != Constants.IDENT_KA) //проверка идент. КА
            {
                _sw.WriteLine("    ----- ошибка идентификатора КА");
                errs++;
            }

            bt = Convert.ToByte(tk_in[1] & 0x3f);
            if (bt != Constants.KADR_INFO && bt != Constants.KADR_LOOSE)    //проверка идент.кадра
            {
                _sw.WriteLine("    ----- ошибка идентификатора кадра");
                errs++;
            }

            for (i = 5; i < 8; i++)    //проверка поля меток
            {
                if (Convert.ToBoolean(tk_in[i]))
                {
                    break;
                }
            }

            if (i < 8)
            {
                _sw.WriteLine("    ----- ошибка в поле меток или поле управления кодированием");
                errs++;
            }

            if (tk_in[1] == Constants.KADR_LOOSE) //идентификатор кадра (5 или 63)
            {
                return;
            }

            Kol_tk++;                  

            beg = (tk_in[2] << 16) | (tk_in[3] << 8) | tk_in[4];

            pr = tk_last == 0xffffff ? 0 : tk_last + 1; //максим. знач.счетчика

            if (tk_last >= 0 && beg != pr)
            {
                _sw.WriteLine("    ----- ошибка счетчика кадров");
                errs++;
            }

            tk_last = beg;
            bt = Convert.ToByte(tk_in[8] >> 3);   //маркер наличия заголовка

            if (Convert.ToBoolean(bt) && bt != 0x1f) //проверка маркера наличия заголовка
            {
                _sw.WriteLine("    ----- ошибка маркера наличия заголовка");
                errs++;
            }

            if (!Convert.ToBoolean(bt))            //заголовок есть
            {
                beg = (tk_in[8] << 8 | tk_in[9]) + 10;    //указатель заголовка
            }
            else
            {
                beg = -1;           //заголовка нет
            }

            for (i = 10; i < 892; i++)
            {
                if (ind_bt_in == dl_jpeg_in || i == beg)        //набрали пакет, дошли до заголовка
                {
                    Razbor_parc();
                }

                _jpeg.jpeg_buf_in[ind_bt_in++] = tk_in[i];

                if (ind_bt_in == 6)
                {
                    data = Convert.ToUInt16((_jpeg.jpeg_buf_in[4] << 8) | _jpeg.jpeg_buf_in[5]);  //длина парц.пакета
                    dl_jpeg_in = data + 7;

                    if (_jpeg.jpeg_buf_in[0] != 0x08 || dl_jpeg_in > Constants.DL_JPEG)
                    {
                        dl_jpeg_in = -1;
                        ind_bt_in = 0;
                    }
                }
            }
        }

        #endregion

        #region Разбор парциального кадра.
        private void Razbor_parc()
        {
            int mc, i;
            int data;
            long tm;            
            float dt;

            if (dl_jpeg_in < 0 || ind_bt_in <= 20)
            {
                ind_bt_in = 0;
                dl_jpeg_in = -1;

                return;
            }

            WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, " ПП: ", 0, 20, 1);

            apid = ((_jpeg.jpeg_buf_in[0] & 0x07) << 8) | _jpeg.jpeg_buf_in[1];
            if (apid < Constants.APID_1 || apid > Constants.APID_c)
            {
                errs++;
                _sw.WriteLine("    ----- ошибка АПИД");

                ind_bt_in = 0;
                dl_jpeg_in = -1;

                return;
            }

            data = ((_jpeg.jpeg_buf_in[2] & 0x3f) << 8) | _jpeg.jpeg_buf_in[3]; //счетчик пакетов

            i = last_count_pac == 0x3fff ? 0 : last_count_pac + 1; //набрали максимум

            if (last_count_pac >= 0 && data != i)
            {
                errs++;
                _sw.WriteLine("    ----- ошибка счетчика пакетов");
            }

            last_count_pac = data;

            //если служебный пакет
            if (apid == Constants.APID_c)
            {
                // МКО.
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "Служебная сканера: ", 14, 25, 1);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ТД: ", 64, 72, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ОШВ: ", 72, 76, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#БШВ: ", 76, 96, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ПДЦМ: ", 96, 124, 2);

                UpdateDataGui();

                Parallel.For(0, _bmps.Length, j =>
                {
                    _bmps[j].Dispose();
                    _bmps[j] = new DirectBitmap(Constants.WDT, Constants.HGT);

                });

                PreparePicture();

                ind_bt_in = 0;
                dl_jpeg_in = -1;

                return;
            }

            //Время
            //Считаем миллисек.
            tm = (_jpeg.jpeg_buf_in[8] << 24) | (_jpeg.jpeg_buf_in[9] << 16) | (_jpeg.jpeg_buf_in[10] << 8) | _jpeg.jpeg_buf_in[11];
            mc = (_jpeg.jpeg_buf_in[12] << 8) | _jpeg.jpeg_buf_in[13];   //микросек.

            Xt = _jpeg.jpeg_buf_in[14];           //Номер MCU
            if (Xt > Constants.MAX_MSU)
            {
                Xt = Constants.MAX_MSU;
                errs++;
            }

            if (tm != tm_last && !Convert.ToBoolean(Xt)) // Новая полоса.        
            {         
                _sw.WriteLine($"Номер суток: {(_jpeg.jpeg_buf_in[6] << 8) | _jpeg.jpeg_buf_in[7]}");
                _sw.WriteLine($"Миллисекунды: {tm}");                
                _sw.WriteLine($"Микросекунды: {mc}");
                _sw.WriteLine("-----------------------------------------------------------------------");

                GetDateTime((_jpeg.jpeg_buf_in[6] << 8) | _jpeg.jpeg_buf_in[7], tm);

                if (Convert.ToBoolean(tm_last))
                {
                    dt = (tm - tm_last) / 1000f; //разница в секундах
                    _sw.WriteLine($"Разница: {dt}");

                    if (dt < 1.2 || dt > 1.25)
                    {
                        _sw.WriteLine("??????????????????????????????????????????????");
                        errs++;
                    }
                }

                _sw.WriteLine("-----------------------------------------------------------------------");
                tm_last = tm;
            }


            if (Convert.ToBoolean(_jpeg.jpeg_buf_in[15]) || Convert.ToBoolean(_jpeg.jpeg_buf_in[16]))
            {
                errs++;
                _sw.WriteLine("    ----- ошибка заголовка скана");
            }

            if (_jpeg.jpeg_buf_in[17] != 0xff || _jpeg.jpeg_buf_in[18] != 0xf0)
            {
                errs++;
                _sw.WriteLine("    ----- ошибка заголовка сегмента");
            }

            Q_Value = _jpeg.jpeg_buf_in[19];

            if (Q_Value > Constants.MAX_Q)
            {
                Q_Value = 75;
                errs++;
            }

            kol_pix = _jpeg.DeCompress(Xt, dl_jpeg_in, Q_Value);

            PreparePicture();
            ind_bt_in = 0;
            dl_jpeg_in = -1;
        }

        #endregion

        #region Формирование изображения.
        private void PreparePicture()
        {
            int k, x, num, nc, color;

            nc = apid - Constants.APID_1; // Номер канала.

            if (nc < 0 || nc > 5)
            {
                return;
            }

            k = 0;
            x = Xt * 8;

            while (k < kol_pix)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        num = _jpeg.video_mass[k++];
                        color = (num << 16) | (num << 8) | num;
                        _bmps[nc].SetPixel(x + j, Yt + i, Color.FromArgb(255, Color.FromArgb(color)));
                    }
                }

                x += 8;
            }
        }

        #endregion

        #region Запись той служебной информации в лог файл которая формируется через StringBuilder.
        private void WriteServiceDataToLogFile(byte[] data, string header, int startIndex, int finishIndex, int iterStep)
        {
            StringBuilder _sb = new StringBuilder();
           
            for (int i = startIndex; i < finishIndex; i += iterStep)
            {
                if (iterStep == 1)
                {
                    _sb.Append(data[i].ToString("X") + " ");
                }
                else
                {
                    _sb.Append(data[i].ToString("X") + _jpeg.jpeg_buf_in[i + 1].ToString("X") + " ");
                }
            }

            switch (header)
            {
                case "#ТД: ": _td = _sb.ToString(); break;
                case "#ОШВ: ": _oshv = _sb.ToString(); break;
                case "#БШВ: ": _bshv = _sb.ToString(); break;
                case "#ПДЦМ: ": _pdcm = _sb.ToString(); break;
            }

            _sb.Insert(0, header);

            _sw.WriteLine($"{_sb}");
        }

        #endregion

        #region Обновление данных и информации на форме.
        private async void UpdateDataGui()
        {
            ThreadSafeUpdateDateTime(currentLineDate);
            ThreadSafeUpdateImagesContent(_bmps);
            ThreadSafeUpdateMko(_td, _oshv, _bshv, _pdcm);
            _form.Invoke(new Action(() => { ThreadSafeUpdateGui(); }));
        }
        #endregion

        #region Формирование даты и времени.
        private void GetDateTime(int date, long ms)
        {
            if (_isNrz)
            {
                currentLineDate = Constants.referenceDate + TimeSpan.FromDays(date - 1) + TimeSpan.FromMilliseconds(ms);
            }
            else
            {
                currentLineDate = Constants.referenceDate + TimeSpan.FromMilliseconds(ms);
            }
        }

        #endregion
    }
}