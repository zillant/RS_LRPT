using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceivingStation.Other;
using Color = System.Drawing.Color;

namespace ReceivingStation.Decode
{
    /// <summary>
    /// Класс основной логики декодирования принимаемого или записанного в файл потока.
    /// Используется в режимах "Самопроверка", "Прием" и "Декодирование".
    /// </summary>
    class Decode
    {
        public delegate void UpdateGuiDelegate(DateTime linesDate, string linesService, string linesTd, string linesOshv, string linesBshv, string linesPcdm, DirectBitmap[] imagesLines, int delegateCallCounter);
        public UpdateGuiDelegate ThreadSafeUpdateGui; // Для остальных режимов. Передаем на форму данные МКО и полосу изображения.
        public delegate void UpdateSelfTestDataDelegate(uint tkCount, int errorsTkCount); 
        public UpdateSelfTestDataDelegate ThreadSafeUpdateSelfTestData; // Для режима самопроверки. Передаем кол-во принятых кадров и кол-во ошибок.

        public bool IsSignalPhaseSync { get; set; } = false;

        public bool stopDecoding;

        private bool _isItSelfTest; // Флаг, является ли это процессом самопроверки.

        private ReedSolo _reedSolo;
        private Viterbi _viterbi;
        private Jpeg _jpeg;
         
        private DateTime _linesDate;
        private DirectBitmap[] _imagesLines = new DirectBitmap[6]; // Полосы изображений для каждого канала.

        private string _linesService;
        private string _linesTd;
        private string _linesOshv;
        private string _linesBshv;
        private string _linesPcdm;

        private int _delegateCallCounter; // Счетчик вызова делегата. Нужен для синхронизации сброса накопленного изображения с созданием нового лог файла.
        private long _logFilesNameCounter;

        private string _fileName; // Имя открытого файла.
        private FileStream _fs; // Содержимое открытого .dat файла.
        private StreamWriter _sw;
        private string _decodeLogDir;
        private string _decodeLogFile; // Файл для записи информации.

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
        private int timeShiftErrs; // Накапливаем ошибки сдвига по времени.

        private bool _isReedSolo; // Требуется ли декодирование Рида-Соломона.
        private byte Q_Value; // Фактор качества.
        private int dl_jpeg_in; //Длина данных jpeg.
        private int Xt, Yt;    //Индекс полосы при выводе.    
        private int _lastXt; //Последнее Xt

        // Для НРЗ.
        private bool _isNrz; // Есть ли NRZ.
        private bool last_bit_in;
      

        #region Режим "Самопроверка".

        /// <summary>
        /// Конструктор для самопроверки.
        /// </summary>
        /// <remarks>
        /// Логика декодирования будет взята из режима "Прием".
        /// </remarks>
        /// <param name="fileName">Имя файла.</param>
        public Decode()
        {
            _isItSelfTest = true;

            _viterbi = new Viterbi();

            Init();
        }

        /// <summary>
        /// Начать декодирование для самопроверки.
        /// </summary>   
        public void SFStartDecode(byte[] data, bool nrz, bool _isInterliving)
        {
            if (_isInterliving) Constants.DL_IN_BUF = 32768;
            else Constants.DL_IN_BUF = 4096;

            in_buf = new byte[Constants.DL_IN_BUF];
            Array.Copy(data, in_buf, data.Length);

            _isNrz = nrz;

            beg_mark_uw = Test_uw(in_buf.Length);

            if (_isInterliving)
            {
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

        /// <summary>
        /// Обновление данных самопроверки на форме.
        /// </summary>  
        /// <remarks>
        /// Проверка принятого ТК на ошибки и отправка данных на форму самопроверки.
        /// </remarks>
        private void UpdateSelfTestData()
        {
            bool isTkError = false;

            Kol_tk++;

            isTkError = CheckData();

            if (isTkError)
            {
                errs++;
            }

            if (Kol_tk % 20 == 0)
            {
                ThreadSafeUpdateSelfTestData(Kol_tk, errs);
            }          
        }

        /// <summary>
        /// Побитовая проверка принятого ТК на ошибки.
        /// </summary>   
        /// <remarks>
        /// При нахождении более 15 ошибок прерывает цикл.
        /// </remarks>
        /// <param name="beginInd">Начальный индекс байта массива ТК.</param>
        /// <returns>Найдена ли ошибка в байте ТК.</returns>
        private bool CheckData()
        {
            int errors = 0;

            for (int i = 0, j = 0; i < tk_in.Length; i++, j++)
            {
                if (j == 255)
                {
                    j = 0;
                }

                var res = tk_in[i] ^ Constants.tkTemplateForSelfTest[j];

                if (res != 0)
                {
                    for (int bitNum = 0; bitNum < 8; bitNum++)
                    {
                        if ((res & 1) == 1)
                        {
                            errors++;
                        }

                        res = res >> 1;
                    }
                }
               
                // Слишком много ошибок в ТК.
                if (errors > 15)
                {
                    return true;
                }
            }
            
            return false;
        }

        #endregion

        #region Режим "Прием".

        /// <summary>
        /// Конструктор для приемника.
        /// </summary>
        /// <param name="fileName">Имя файла для записи.</param>
        public Decode(string fileName)
        {
            _fileName = fileName;
            _isReedSolo = true;
            _isItSelfTest = false;

            _reedSolo = new ReedSolo();
            _viterbi = new Viterbi();
            _jpeg = new Jpeg();

            _delegateCallCounter = 0;
            _logFilesNameCounter = 0;

            CreateLogDirectory();
            CreateNewLogFile(_logFilesNameCounter);

            for (int i = 0; i < 6; i++)
            {
                _imagesLines[i] = new DirectBitmap(Constants.WDT, Constants.HGT);
            }

            Init();
        }

        /// <summary>
        /// Начать декодирование для приемника.
        /// </summary> 
        /// <param name="data">Принятые данные.</param>
        /// <param name="nrz">Есть ли NRZ.</param>
        /// <param name="_isInterliving">Есть ли интерливинг.</param>
        public void StartDecode(byte[] data, bool nrz, bool _isInterliving)
        {
            if (_isInterliving) Constants.DL_IN_BUF = 32000;
            else Constants.DL_IN_BUF = 4096;

            in_buf = new byte[Constants.DL_IN_BUF];
            Array.Copy(data, in_buf, data.Length);

            _isNrz = nrz;

            beg_mark_uw = Test_uw(in_buf.Length);

            if (_isInterliving)
            {
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

        #region Режим "Декодирование".

        /// <summary>
        /// Конструктор для открытого файла.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="reedSoloFlag">Требуется ли декодирование Рида-Соломона.</param>
        /// <param name="nrzFlag">Есть ли NRZ.</param>
        public Decode(string fileName, bool reedSoloFlag, bool nrzFlag)
        {
            _fileName = fileName;
            _isNrz = nrzFlag;
            _isReedSolo = reedSoloFlag;

            _reedSolo = new ReedSolo();
            _viterbi = new Viterbi();
            _jpeg = new Jpeg();

            _delegateCallCounter = 0;
            _logFilesNameCounter = 0;

            _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);

            CreateLogDirectory();
            CreateNewLogFile(_logFilesNameCounter);

            stopDecoding = false;
            _isItSelfTest = false;

            for (int i = 0; i < 6; i++)
            {
                _imagesLines[i] = new DirectBitmap(Constants.WDT, Constants.HGT);       
            }

            Init();
        }

        /// <summary>
        /// Начать декодирование для открытого файла.
        /// </summary>   
        public void StartDecode()
        {
            int bytesCount;

            do
            {
                bytesCount = _fs.Read(in_buf, 0, Constants.DL_IN_BUF);

                if (bytesCount < 2048)
                {
                    break;
                }

                beg_mark_uw = Test_uw(bytesCount);
                _isInterliving = beg_mark_uw != -1;

                if (_isInterliving)
                {
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

            } while (!stopDecoding);

            UpdateDataGui();
            FinishDecode();
        }

        #endregion

        /// <summary>
        /// Инициализация переменных.
        /// </summary>
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
            timeShiftErrs = 0;

            _lastXt = 0;

            Yt = 0;
            kol_all = 0;
        }

        /// <summary>
        /// Поиск синхромаркера.
        /// </summary>
        /// <param name="kol">Длина массива входных данных.</param> 
        private int Test_uw(int kol)
        {
            byte bt, j;

            for (int i = 0; i < kol - 50; i++)
            {
                for (byte k = 0; k < 8; k++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        bt = Convert.ToByte(((in_buf[j * 10 + i] << k) & 0xFF) | (in_buf[j * 10 + i + 1] >> (8 - k)));
                        if (bt != 0x27) break;                      
                    }
                    if (j == 5) return (i * 8 + k) % 80;
                }
            }

            return -1;
        }

        /// <summary>
        /// Деинтерливинг.
        /// </summary>     
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
                            pos = (ind_fr * 73728 + ind_small * 73728 + ind_small + ind_big * 36) % Constants.DL_INTRL_BUF;
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

        /// <summary>
        /// Преобразование в бит. поток 2048 байт.
        /// </summary>
        /// <param name="initialArrayIndex">Начальный индекс массива данных.</param>     
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

        /// <summary>
        /// Разбирает кадр после Витерби и NRZ.
        /// </summary>
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
                                IsSignalPhaseSync = true;
                            }

                            if (cnt_mark < 26)      //потеря маркера
                            {
                                Ind_mar_tk_bit = 0;
                                cnt_mark = 0;
                                Fl_err = Convert.ToBoolean(1);
                                IsSignalPhaseSync = false;
                            }
                            else
                            {
                                ind_tk_in = 0;        //к началу набора кадра
                                mask_out_tk = 0x80;
                                tk_in[0] = 0;
                            }
                        }
                    }
                    else  //набор кадра
                    {
                        if (bit)
                        {
                            tk_in[ind_tk_in] |= mask_out_tk;
                        }

                        mask_out_tk = Convert.ToByte(mask_out_tk >> 1);

                        if (!Convert.ToBoolean(mask_out_tk)) //набрали байт
                        {
                            mask_out_tk = 0x80;
                            ind_tk_in++;

                            if (ind_tk_in == 1020)      //набрали кадр
                            {                               
                                if (_isItSelfTest)
                                {
                                    // Режим самопроверки.
                                    UpdateSelfTestData();
                                }                               
                                else
                                {
                                    // Остальные режимы.
                                    Get_dat_tk();
                                }
                                

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

        /// <summary>
        /// Расшифровка ТК.
        /// </summary>
        private void Get_dat_tk()
        {
            int i, beg, pr;
            ushort data;
            byte bt;
            
            _reedSolo.Decode_RS(tk_in, _isReedSolo);   //декодирование Рида-Соломона

            kol_all++;
            //_sw.WriteLine($"Пакет № {kol_all}");
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
                beg = ((tk_in[8] & 0x07) << 8 | tk_in[9]) + 10;    //указатель заголовка
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

                _jpeg.jpeg_buf_in[ind_bt_in] = tk_in[i];
                if (_jpeg.jpeg_buf_in[0] != 0x08)
                    continue;
                ind_bt_in++;

                if (ind_bt_in == 6)
                {
                    data = Convert.ToUInt16((_jpeg.jpeg_buf_in[4] << 8) | _jpeg.jpeg_buf_in[5]);  //длина парц.пакета
                    dl_jpeg_in = data + 7;

                    
                    if (dl_jpeg_in > Constants.DL_JPEG)
                    {
                        Razbor_parc();
                    }
                }
            }
        }

        /// <summary>
        /// Разбор парциального кадра.
        /// </summary>
        private void Razbor_parc()
        {
            int mc, i;
            int data;
            long tm;
            float dt;

            if (dl_jpeg_in < 14 || ind_bt_in <= 20)
            {
                ind_bt_in = 0;
                dl_jpeg_in = -1;

                return;
            }

            //WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, " ПП: ", 0, 20, 1);

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
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "Служебная сканера: ", 14, 64, 1);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ТД: ", 64, 72, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ОШВ: ", 72, 76, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#БШВ: ", 76, 96, 2);
                WriteServiceDataToLogFile(_jpeg.jpeg_buf_in, "#ПДЦМ: ", 96, 124, 2);
                _sw.WriteLine("\n");

                ind_bt_in = 0;
                dl_jpeg_in = -1;

                return;
            }

            //Время
            //Считаем миллисек.
            tm = (_jpeg.jpeg_buf_in[8] << 24) | (_jpeg.jpeg_buf_in[9] << 16) | (_jpeg.jpeg_buf_in[10] << 8) | _jpeg.jpeg_buf_in[11];
            mc = (_jpeg.jpeg_buf_in[12] << 8) | _jpeg.jpeg_buf_in[13];   //микросек.

            Xt = _jpeg.jpeg_buf_in[14];  //Номер MCU

            if (Xt > Constants.MAX_MSU || Convert.ToBoolean(Xt % 14))
            {
                errs++;
                _sw.WriteLine("    ----- ошибка номера МСУ");

                Xt = _lastXt + 14;

                if (Xt > Constants.MAX_MSU)
                    Xt = 0;
            }
            _lastXt = Xt;

            if (tm != tm_last && !Convert.ToBoolean(Xt)) // Новая полоса.        
            {
                _sw.WriteLine($"Номер суток: {(_jpeg.jpeg_buf_in[6] << 8) | _jpeg.jpeg_buf_in[7]}");
                _sw.WriteLine($"Миллисекунды: {tm}" + $" ({TimeSpan.FromMilliseconds(tm)})");
                _sw.WriteLine($"Микросекунды: {mc}");
                _sw.WriteLine("-----------------------------------------------------------------------");

                GetDateTime((_jpeg.jpeg_buf_in[6] << 8) | _jpeg.jpeg_buf_in[7], tm);

                if (Convert.ToBoolean(tm_last))
                {
                    if (tm < tm_last) dt = (86400000 - tm_last + tm) / 1000f; //смена суток
                    else dt = (tm - tm_last) / 1000f; //разница в секундах
                    _sw.WriteLine($"Разница: {dt}");

                    if (dt < 1.2 || dt > 1.25)
                    {
                        _sw.WriteLine("??????????????????????????????????????????????");
                        timeShiftErrs++;

                        UpdateDataGui();
                    }

                    UpdateDataGui();

                    if (_delegateCallCounter == Constants.DELEGATE_CALL_COUNTER)
                    {
                        _sw.Close();
                        CreateNewLogFile(++_logFilesNameCounter);
                        _delegateCallCounter = 0;
                    }

                    _delegateCallCounter++;

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

        /// <summary>
        /// Формирование изображения.
        /// </summary>
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
                        _imagesLines[nc].SetPixel(x + j, Yt + i, Color.FromArgb(255, Color.FromArgb(color)));
                    }
                }

                x += 8;
            }
        }

        /// <summary>
        /// Поиск нового начала заголовка.
        /// </summary>
        /// <param name="k">Индекс поиска нового начала заголовка.</param>
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

        /// <summary>
        /// Запись той служебной информации в лог файл которая формируется через StringBuilder.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="header">Заголовок.</param>
        /// <param name="startIndex">Начальный индекс из данных.</param>
        /// <param name="finishIndex">Конечный индекс из данных.</param>
        /// <param name="iterStep">Шаг итерации.</param>
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
                case "Служебная сканера: ": _linesService = _sb.ToString(); break;
                case "#ТД: ": _linesTd = _sb.ToString(); break;
                case "#ОШВ: ": _linesOshv = _sb.ToString(); break;
                case "#БШВ: ": _linesBshv = _sb.ToString(); break;
                case "#ПДЦМ: ": _linesPcdm = _sb.ToString(); break;
            }

            _sb.Insert(0, header);

            _sw.WriteLine($"{_sb}");
        }

        /// <summary>
        /// Формирование даты и времени.
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <param name="ms">Кол-во миллисекунд.</param>
        private void GetDateTime(int date, long ms)
        {
            if (_isNrz)
            {
                _linesDate = Constants.referenceDate + TimeSpan.FromDays(date - 1) + TimeSpan.FromMilliseconds(ms);
            }
            else
            {
                _linesDate = Constants.referenceDate + TimeSpan.FromMilliseconds(ms);
            }
        }

        /// <summary>
        /// Создание нового файла логов декодирования.
        /// </summary>
        /// <param name="filesCounter">Счетчик кол-ва файлов.</param> 
        private void CreateNewLogFile(long filesCounter)
        {           
            _decodeLogFile = $"{_decodeLogDir}\\{Path.GetFileNameWithoutExtension(_fileName)}_decode_log_{filesCounter}.txt";
            _sw = new StreamWriter(_decodeLogFile, true, Encoding.UTF8, 65536);
        }

        /// <summary>
        /// Создание каталога для хранения логов декодирования.
        /// </summary>
        private void CreateLogDirectory()
        {
            _decodeLogDir = $"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Decode_logs";

            if (Directory.Exists(_decodeLogDir) == false)
            {
                Directory.CreateDirectory(_decodeLogDir);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(_decodeLogDir);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        /// <summary>
        /// Создание полноценного лог файла.
        /// </summary>
        private void CreateBigLogFile()
        {
            var filePaths = Directory.GetFiles($"{_decodeLogDir}\\", "*.txt", SearchOption.TopDirectoryOnly)
                .OrderBy(f => new FileInfo(f).CreationTime);

            using (StreamWriter sw = new StreamWriter($"{_decodeLogDir}\\{Path.GetFileNameWithoutExtension(_fileName)}_big_decode_log.txt", true, Encoding.UTF8, 65536))
            {
                foreach (var file in filePaths)
                {
                    using (StreamReader sr = new StreamReader(file, Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Завершение декодирования.
        /// </summary>
        public void FinishDecode()
        {
            _sw.WriteLine("-------------------------------------------------");
            _sw.WriteLine("------------------------------------------");
            _sw.WriteLine($"Всего найдено ошибок: {errs}");
            _sw.WriteLine($"Найдено сдвигов по времени: {timeShiftErrs}");
            _sw.Close();
            CreateBigLogFile();
        }

        /// <summary>
        /// Обновление данных и информации на форме.
        /// </summary>
        public void UpdateDataGui()
        {
            if (_linesTd != null) // Костыль, проверка на то что файл начал декодироваться. Возникал эксепшн, если запускал файл с NRZ и не отмечал его, и наоборот, а потом останавливал. 
            {
                ThreadSafeUpdateGui(_linesDate, _linesService, _linesTd, _linesOshv, _linesBshv, _linesPcdm, _imagesLines, _delegateCallCounter);
                Parallel.For(0, _imagesLines.Length, j =>
                {
                    _imagesLines[j].Dispose();
                    _imagesLines[j] = new DirectBitmap(Constants.WDT, Constants.HGT);
                });
            }
        }
    }
}