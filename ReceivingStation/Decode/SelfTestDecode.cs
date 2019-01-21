using System;
using System.IO;
using System.Text;

namespace ReceivingStation.Decode
{
    class SelfTestDecode 
    {
        public delegate void UpdateGuiDelegate();
        public UpdateGuiDelegate ThreadSafeUpdateGui;

        public bool stopDecoding;

        private Viterbi _viterbi;
     
        private byte[] tk_in = new byte[1020]; //Входящий транспортный кадр баз маркера(4 байта).

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

        // Для НРЗ.
        private bool _isNrz; // Состояние checkBox "НРЗ".
        private bool last_bit_in;

        private string _fileName; // Имя открытого файла.
        private FileStream _fs; // Содержимое открытого .dat файла.
        private StreamWriter _sw;
        private string _decodeLogFileName; // Файл для записи информации.


        #region Конструктор для приемника.
        public SelfTestDecode()
        {
            _isNrz = false;
            _viterbi = new Viterbi();      

            Init();
        }

        #endregion

        #region Конструктор для открытого файла.
        public SelfTestDecode(string fileName)
        {
            _fileName = fileName;
            _isNrz = false;


            _viterbi = new Viterbi();

            _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            _decodeLogFileName = $"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_info.txt";
            _sw = new StreamWriter(_decodeLogFileName, true, Encoding.UTF8, 65536);

            stopDecoding = false;


            Init();
        }

        #endregion

        #region Начать декодирование для открытого файла.
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

            } while (!stopDecoding);
        }

        #endregion

        #region Начать декодирование для приемника.
        public void StartDecode(byte[] data, bool NRZ, bool _isInterliving)
        {

            if (_isInterliving) Constants.DL_IN_BUF = 32000;
            else Constants.DL_IN_BUF = 4096;

            in_buf = new byte[Constants.DL_IN_BUF];
            Array.Copy(data, in_buf, data.Length);
            _isNrz = NRZ;
            beg_mark_uw = Test_uw();
            //_isInterliving = beg_mark_uw != -1;

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

        #region Инициализация переменных.
        private void Init()
        {
            ind_tk_in = 0;

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
                                //ThreadSafeUpdateGui();
                                Console.Write(BitConverter.ToString(tk_in));
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();

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

        #region Обновление данных и информации на форме.
        private void UpdateDataGui()
        {
            //if (_linesTd != null) // Костыль, проверка на то что файл начал декодироваться. Возникал эксепшн, если запускал файл с NRZ и не отмечал его, и наоборот, а потом останавливал. 
            //{
            //    ThreadSafeUpdateGui(_linesDate, _linesTd, _linesOshv, _linesBshv, _linesPcdm, _imagesLines);
            //}
        }
        #endregion
    }
}
