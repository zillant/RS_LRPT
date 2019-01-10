﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform.IO;

namespace ReceivingStation.Demodulator
{

    class BeforeViterbiSync
    {
        sbyte[] psp1 = new sbyte[48] { 1, 1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1 };
        sbyte[] psp1i = new sbyte[48] { 1, 1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1, 1, 1, -1, -1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1 };
        sbyte[] psp2 = new sbyte[48] { -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, 1, 1, -1, 1, -1, -1, -1, 1, 1, 1, -1, -1, 1, -1, 1, -1, 1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, -1, 1, -1, 1, 1, -1, -1 };
        sbyte[] psp2i = new sbyte[48] { 1, -1, 1, 1, 1, 1, -1, 1, -1, -1, 1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, 1, -1, 1, 1, -1, 1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, 1, -1, -1, -1, -1, -1, 1, 1, 1, -1, -1 };
        sbyte[] pspNRZ1 = new sbyte[48] { 1, 1, 1, -1, 1, 1, 1, 1, -1, 1, -1, -1, 1, 1, 1, 1, 1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1, -1, 1, 1, -1, -1, -1, -1, 1, -1, 1, 1, -1, 1, 1, 1, 1, 1, 1, -1, -1, -1 };
        sbyte[] pspNRZ2 = new sbyte[48] { -1, 1, 1, -1, -1, -1, 1, -1, 1, -1, 1, 1, -1, 1, 1, -1, 1, -1, 1, -1, 1, 1, -1, 1, -1, 1, 1, -1, -1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, -1, 1, 1, 1, -1, 1, -1, -1, -1};

        sbyte[] pspInt1 = new sbyte[8] { 1, 1, -1, 1, 1, -1, -1, -1 }; // при интерливинге NRZ включен
        sbyte[] pspInt2 = new sbyte[8] { 1, -1, 1, 1, -1, -1, -1, 1 };
        sbyte[] pspInt3 = new sbyte[8] { -1, -1, 1, -1, -1, 1, 1, 1 };
        sbyte[] pspInt4 = new sbyte[8] { -1, 1, -1, -1, 1, 1, 1, -1 };

        sbyte[] sum = new sbyte[17];
        int[] dif = new int[17];
        int[] positions = new int[100];
        //sbyte[] psp1i = new sbyte[48];
        //sbyte[] psp2i = new sbyte[48];
        // -1 равносильно битовой единице, а 1 = нулю
        // все приводится к -psp1

        public Demodulator.Packet[] Packets;
        public Demodulator.Packet Packet;
        public Demodulator.LogWriter logs;

        int _FullLength = 16384;
        int _FullLength_int = 80;
        int PSPLength = 48;
        int PSPLength_int = 8;

        sbyte[] PSP = new sbyte[48];
        sbyte[] PSPINT = new sbyte[8];
        sbyte[] PSP2 = new sbyte[48];
        sbyte[] PSPint = new sbyte[16];
        sbyte[] PSP2int = new sbyte[16];
        //sbyte[] DATA = new sbyte[16384 - 48]; // FullLength - PSPLength = 16336 
        sbyte[] DATA = new sbyte[10];
        public sbyte[] DATA1; // FullLength - PSPLength = 16336 
        int difmode;
        public int mode;
        int NRZmode1; // мод для первого пакета
        int NRZmode2; // мод для второго пакета
        int maxdif = 0;

        bool saved = false;

        private sbyte temp;
        public bool NRZ;

        // Сюда попадает массив с размеров в считанный файл.
        // Далее, начиная с нулевого элемента идет поиск синхропосылки, размер которой 48 
        // Если же мы не находим синхропосылку, то смещаемся на один элемент вправо, и начинаем поиск, соответсвенно ищем по 48 битов.
        // Когда находим синхропосылку, затем корректируем поток, если это нужно, а потом выделяем пакет, идущий после синхропосылки, размером в (16384 - 48) бит, сохраняем его.




        public bool PSPSearch(byte[] inputarray, int outmode) // тут только для NRZ
        {
            int bit;
            bool PSPFinded = false;
            sbyte[] arrayToCorrect = new sbyte[inputarray.Length];
            sbyte[] pspNRZ1i = new sbyte[48];
            sbyte[] pspNRZ2i = new sbyte[48];
            sbyte[] array = new sbyte[48];
            sbyte[] array2 = new sbyte[48];
            sbyte[] FirstPacket = new sbyte[_FullLength];
            sbyte[] SecondPacket = new sbyte[_FullLength];

            //if (logs == null) logs = new Demodulator.LogWriter();
            //PSPFinded = false;
                        
            for (int i = 0; i < PSPLength; i++)
            {
                pspNRZ1i[i] = (sbyte)-pspNRZ1[i];
                pspNRZ2i[i] = (sbyte)-pspNRZ2[i];
            }

            for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum
            for (int i = 0; i < dif.Length; i++) dif[i] = 0;

            #region SearchPSP
            for (int i = 0; i < 48; i++)
            {
                array[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < 48; i++)
            {
                array2[i] = (sbyte)inputarray[i + _FullLength];// переводим отрывок из byte в знаковый sbyte, берем заголовок второго пакета
            }

            for (int i = 0; i < inputarray.Length; i++)
            {
                arrayToCorrect[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte,
            }

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в первый раз
            {
                PSP[i] = array[i];
                // Записываем в PSP 48 значений из потока
            }
            for (int i = 0; i < PSPLength; i++)
            {
                bit = Math.Sign(PSP[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;
                // if NRZ

                if (pspNRZ1[i] == bit) sum[2]++;
                else sum[1]++;

                if (pspNRZ2[i] == bit) sum[4]++;
                else sum[3]++;

                if (pspNRZ1i[i] == bit) sum[6]++;
                else sum[5]++;
                
                if (pspNRZ2i[i] == bit) sum[8]++;
                else sum[7]++;
                #endregion
            }

            #region Dif Modes
            // NRZ
            dif[1] = (sbyte)(sum[1] - sum[2]);
            dif[2] = (sbyte)(sum[2] - sum[1]);
            dif[3] = (sbyte)(sum[3] - sum[4]);
            dif[4] = (sbyte)(sum[4] - sum[3]);
            dif[5] = (sbyte)(sum[5] - sum[6]);
            dif[6] = (sbyte)(sum[6] - sum[5]);
            dif[7] = (sbyte)(sum[7] - sum[8]);
            dif[8] = (sbyte)(sum[8] - sum[7]);

            #endregion

            for (int i = 1; i < 9; i++)
            {
                if (dif[i] > maxdif)
                {
                    maxdif = dif[i];
                    difmode = i;
                }
            }

            if (maxdif > 39)
            {
                NRZmode1 = difmode;
                PSPFinded = true;
            }
            else PSPFinded = false;

            for (int i = 0; i < dif.Length; i++) dif[i] = 0;
            for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в во 2й раз
            {
                PSP2[i] = array2[i];
                // Записываем в PSP 48 значений из потока, т.е. берем начало второго потока
            }

            for (int i = 0; i < PSPLength; i++)
            {
                bit = Math.Sign(PSP2[i]);
                #region Magic with PSP
                // if NRZ
                if (bit == 0) bit = -1;
                if (pspNRZ1[i] == bit) sum[2]++;
                else sum[1]++;

                if (pspNRZ2[i] == bit) sum[4]++;
                else sum[3]++;

                if (pspNRZ1i[i] == bit) sum[6]++;
                else sum[5]++;

                if (pspNRZ2i[i] == bit) sum[8]++;
                else sum[7]++;
               
                #endregion
            }

            #endregion

            #region Dif Modes
            // NRZ
            dif[1] = (sbyte)(sum[1] - sum[2]);
            dif[2] = (sbyte)(sum[2] - sum[1]);
            dif[3] = (sbyte)(sum[3] - sum[4]);
            dif[4] = (sbyte)(sum[4] - sum[3]);
            dif[5] = (sbyte)(sum[5] - sum[6]);
            dif[6] = (sbyte)(sum[6] - sum[5]);
            dif[7] = (sbyte)(sum[7] - sum[8]);
            dif[8] = (sbyte)(sum[8] - sum[7]);
                       
            #endregion

            difmode = 0;
            maxdif = 0;

            for (int i = 1; i < 9; i++)
            {
                if (dif[i] > maxdif)
                {
                    maxdif = dif[i];
                    difmode = i;
                }
            }

            if (maxdif > 39)
            {
                NRZmode2 = difmode;
                PSPFinded = true;
            }
            else PSPFinded = false;
           

            if ((NRZmode1 != 0) || (NRZmode2 != 0) && maxdif > 39)
            {
                PSPFinded = true;
                outmode = mode;
                //if (mode > 9) NRZ = true;
            }

            if (PSPFinded)
            {
                Array.Copy(arrayToCorrect, FirstPacket, _FullLength);
                Array.Copy(arrayToCorrect, _FullLength, SecondPacket, 0, _FullLength); // делим большой массив на два пакета
                PacketCorrect(FirstPacket, NRZmode1);
                PacketCorrect(SecondPacket, NRZmode2);
                Array.Copy(FirstPacket, arrayToCorrect, _FullLength);
                Array.Copy(SecondPacket, 0, arrayToCorrect, 16384, _FullLength);

                for (int i = 0; i < inputarray.Length; i++)
                {
                    inputarray[i] = (byte)arrayToCorrect[i];// переводим отрывок из byte в знаковый sbyte
                }
            }
            return PSPFinded;
        }
        public bool PSPSearch_old(byte[] inputarray, int outmode)
        {
            int bit;
            bool PSPFinded = false;
            sbyte[] arrayToCorrect = new sbyte[inputarray.Length];
            sbyte[] pspNRZ1i = new sbyte[48];
            sbyte[] pspNRZ2i = new sbyte[48];
            sbyte[] array = new sbyte[48];
            sbyte[] array2 = new sbyte[48];
            sbyte[] FirstPacket = new sbyte[_FullLength];
            sbyte[] SecondPacket = new sbyte[_FullLength];

            //if (logs == null) logs = new Demodulator.LogWriter();
            //PSPFinded = false;

            for (int i = 0; i < PSPLength; i++)
            {
                pspNRZ1i[i] = (sbyte)-pspNRZ1[i];
                pspNRZ2i[i] = (sbyte)-pspNRZ2[i];
            }

            for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum

            #region SearchPSP
            for (int i = 0; i < 48; i++)
            {
                array[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < 48; i++)
            {
                array2[i] = (sbyte)inputarray[i + _FullLength];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < inputarray.Length; i++)
            {
                arrayToCorrect[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в первый раз
            {
                PSP[i] = array[i];
                // Записываем в PSP 48 значений из потока
            }
            for (int i = 0; i < PSPLength; i++)
            {
                bit = Math.Sign(PSP[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;
                if (psp1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (psp2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (psp1i[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (psp2i[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                // if NRZ

                if (pspNRZ1[i] == bit)
                {
                    sum[10]++;
                }
                else
                {
                    sum[9]++;
                }
                if (pspNRZ2[i] == bit)
                {
                    sum[12]++;
                }
                else
                {
                    sum[11]++;
                }
                if (pspNRZ1i[i] == bit)
                {
                    sum[14]++;
                }
                else
                {
                    sum[13]++;
                }
                if (pspNRZ2i[i] == bit)
                {
                    sum[16]++;
                }
                else
                {
                    sum[15]++;
                }

                #endregion

            }

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в во 2й раз
            {
                PSP2[i] = array2[i];
                // Записываем в PSP 48 значений из потока, т.е. берем начало второго потока
            }

            for (int i = 0; i < PSPLength; i++)
            {
                bit = Math.Sign(PSP2[i]);
                #region Magic with PSP
                if (bit == 0) bit = -1;
                if (psp1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (psp2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (psp1i[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (psp2i[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                // if NRZ

                if (pspNRZ1[i] == bit)
                {
                    sum[10]++;
                }
                else
                {
                    sum[9]++;
                }
                if (pspNRZ2[i] == bit)
                {
                    sum[12]++;
                }
                else
                {
                    sum[11]++;
                }
                if (pspNRZ1i[i] == bit)
                {
                    sum[14]++;
                }
                else
                {
                    sum[13]++;
                }
                if (pspNRZ2i[i] == bit)
                {
                    sum[16]++;
                }
                else
                {
                    sum[15]++;
                }

                #endregion
            }

            #endregion

            #region Dif Modes
            dif[1] = (sbyte)(sum[1] - sum[2]);
            dif[2] = (sbyte)(sum[2] - sum[1]);
            dif[3] = (sbyte)(sum[3] - sum[4]);
            dif[4] = (sbyte)(sum[4] - sum[3]);
            dif[5] = (sbyte)(sum[5] - sum[6]);
            dif[6] = (sbyte)(sum[6] - sum[5]);
            dif[7] = (sbyte)(sum[7] - sum[8]);
            dif[8] = (sbyte)(sum[8] - sum[7]);

            // NRZ

            dif[9] = (sbyte)(sum[9] - sum[10]);
            dif[10] = (sbyte)(sum[10] - sum[9]);
            dif[11] = (sbyte)(sum[11] - sum[12]);
            dif[12] = (sbyte)(sum[12] - sum[11]);
            dif[13] = (sbyte)(sum[13] - sum[14]);
            dif[14] = (sbyte)(sum[14] - sum[13]);
            dif[15] = (sbyte)(sum[15] - sum[16]);
            dif[16] = (sbyte)(sum[16] - sum[15]);

            #endregion

            difmode = 0;
            maxdif = 0;

            for (int i = 1; i < 17; i++)
            {
                if (dif[i] > maxdif)
                {
                    maxdif = dif[i];
                    difmode = i;
                    if (difmode > 8) NRZ = true;
                }
            }


            if (maxdif > 60 && !NRZ)
            {
                mode = difmode;
            }
            else if (NRZ)
            {
                for (int i = 0; i < dif.Length; i++) dif[i] = 0;
                for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum
                #region FirstPacket
                for (int i = 0; i < PSPLength; i++) // ищем поссылку в первый раз
                {
                    PSP[i] = array[i];
                    // Записываем в PSP 48 значений из потока
                }
                for (int i = 0; i < PSPLength; i++)
                {
                    bit = Math.Sign(PSP[i]);

                    #region Magic with PSP
                    if (bit == 0) bit = -1;
                    if (psp1[i] == bit)
                    {
                        sum[2]++;
                    }
                    else
                    {
                        sum[1]++;
                    }
                    if (psp2[i] == bit)
                    {
                        sum[4]++;
                    }
                    else
                    {
                        sum[3]++;
                    }
                    if (psp1i[i] == bit)
                    {
                        sum[6]++;
                    }
                    else
                    {
                        sum[5]++;
                    }
                    if (psp2i[i] == bit)
                    {
                        sum[8]++;
                    }
                    else
                    {
                        sum[7]++;
                    }

                    // if NRZ

                    if (pspNRZ1[i] == bit)
                    {
                        sum[10]++;
                    }
                    else
                    {
                        sum[9]++;
                    }
                    if (pspNRZ2[i] == bit)
                    {
                        sum[12]++;
                    }
                    else
                    {
                        sum[11]++;
                    }
                    if (pspNRZ1i[i] == bit)
                    {
                        sum[14]++;
                    }
                    else
                    {
                        sum[13]++;
                    }
                    if (pspNRZ2i[i] == bit)
                    {
                        sum[16]++;
                    }
                    else
                    {
                        sum[15]++;
                    }

                    #endregion

                }
                #endregion

                #region Dif Modes
                dif[1] = (sbyte)(sum[1] - sum[2]);
                dif[2] = (sbyte)(sum[2] - sum[1]);
                dif[3] = (sbyte)(sum[3] - sum[4]);
                dif[4] = (sbyte)(sum[4] - sum[3]);
                dif[5] = (sbyte)(sum[5] - sum[6]);
                dif[6] = (sbyte)(sum[6] - sum[5]);
                dif[7] = (sbyte)(sum[7] - sum[8]);
                dif[8] = (sbyte)(sum[8] - sum[7]);

                // NRZ

                dif[9] = (sbyte)(sum[9] - sum[10]);
                dif[10] = (sbyte)(sum[10] - sum[9]);
                dif[11] = (sbyte)(sum[11] - sum[12]);
                dif[12] = (sbyte)(sum[12] - sum[11]);
                dif[13] = (sbyte)(sum[13] - sum[14]);
                dif[14] = (sbyte)(sum[14] - sum[13]);
                dif[15] = (sbyte)(sum[15] - sum[16]);
                dif[16] = (sbyte)(sum[16] - sum[15]);

                #endregion

                difmode = 0;
                maxdif = 0;

                for (int i = 1; i < 17; i++)
                {
                    if (dif[i] > maxdif)
                    {
                        maxdif = dif[i];
                        difmode = i;

                    }
                }
                if (maxdif > 38)
                {
                    NRZmode1 = difmode;
                    PSPFinded = true;
                }
                else PSPFinded = false;

                for (int i = 0; i < dif.Length; i++) dif[i] = 0;
                for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum

                #region Second Packet
                for (int i = 0; i < PSPLength; i++) // ищем поссылку в во 2й раз
                {
                    PSP2[i] = array2[i];
                    // Записываем в PSP 48 значений из потока, т.е. берем начало второго потока
                }

                for (int i = 0; i < PSPLength; i++)
                {
                    bit = Math.Sign(PSP2[i]);
                    #region Magic with PSP
                    if (bit == 0) bit = -1;
                    if (psp1[i] == bit)
                    {
                        sum[2]++;
                    }
                    else
                    {
                        sum[1]++;
                    }
                    if (psp2[i] == bit)
                    {
                        sum[4]++;
                    }
                    else
                    {
                        sum[3]++;
                    }
                    if (psp1i[i] == bit)
                    {
                        sum[6]++;
                    }
                    else
                    {
                        sum[5]++;
                    }
                    if (psp2i[i] == bit)
                    {
                        sum[8]++;
                    }
                    else
                    {
                        sum[7]++;
                    }

                    // if NRZ

                    if (pspNRZ1[i] == bit)
                    {
                        sum[10]++;
                    }
                    else
                    {
                        sum[9]++;
                    }
                    if (pspNRZ2[i] == bit)
                    {
                        sum[12]++;
                    }
                    else
                    {
                        sum[11]++;
                    }
                    if (pspNRZ1i[i] == bit)
                    {
                        sum[14]++;
                    }
                    else
                    {
                        sum[13]++;
                    }
                    if (pspNRZ2i[i] == bit)
                    {
                        sum[16]++;
                    }
                    else
                    {
                        sum[15]++;
                    }

                    #endregion
                }
                #endregion

                #region Dif Modes
                dif[1] = (sbyte)(sum[1] - sum[2]);
                dif[2] = (sbyte)(sum[2] - sum[1]);
                dif[3] = (sbyte)(sum[3] - sum[4]);
                dif[4] = (sbyte)(sum[4] - sum[3]);
                dif[5] = (sbyte)(sum[5] - sum[6]);
                dif[6] = (sbyte)(sum[6] - sum[5]);
                dif[7] = (sbyte)(sum[7] - sum[8]);
                dif[8] = (sbyte)(sum[8] - sum[7]);

                // NRZ

                dif[9] = (sbyte)(sum[9] - sum[10]);
                dif[10] = (sbyte)(sum[10] - sum[9]);
                dif[11] = (sbyte)(sum[11] - sum[12]);
                dif[12] = (sbyte)(sum[12] - sum[11]);
                dif[13] = (sbyte)(sum[13] - sum[14]);
                dif[14] = (sbyte)(sum[14] - sum[13]);
                dif[15] = (sbyte)(sum[15] - sum[16]);
                dif[16] = (sbyte)(sum[16] - sum[15]);

                #endregion

                difmode = 0;
                maxdif = 0;

                for (int i = 1; i < 17; i++)
                {
                    if (dif[i] > maxdif)
                    {
                        maxdif = dif[i];
                        difmode = i;
                    }
                }
                if (maxdif > 38)
                {
                    NRZmode2 = difmode;
                    PSPFinded = true;
                }
            }
            else mode = 0;


            if (((mode != 0) || (NRZmode1 != 0) || (NRZmode2 != 0)) && maxdif > 40)
            {
                PSPFinded = true;
                outmode = mode;
                //if (mode > 9) NRZ = true;
            }

            if (PSPFinded)
            {
                Array.Copy(arrayToCorrect, FirstPacket, _FullLength);
                Array.Copy(arrayToCorrect, _FullLength, SecondPacket, 0, _FullLength); // делим большой массив на два пакета
                if (!NRZ)
                {
                    PacketCorrect(FirstPacket, outmode);
                    PacketCorrect(SecondPacket, outmode);
                }
                else if (NRZ)
                {
                    PacketCorrect(FirstPacket, NRZmode1);
                    PacketCorrect(SecondPacket, NRZmode2);
                }
                Array.Copy(FirstPacket, arrayToCorrect, _FullLength);
                Array.Copy(SecondPacket, 0, arrayToCorrect, 16384, _FullLength);

                for (int i = 0; i < inputarray.Length; i++)
                {
                    inputarray[i] = (byte)arrayToCorrect[i];// переводим отрывок из byte в знаковый sbyte
                }
            }


            return PSPFinded;



        }

        public void PacketCorrect(sbyte[] array, int outmode)
        {

            switch (outmode)
            {
                #region NOT NRZ
                //case 4: //PSP2
                //        // i - нашли начало кадра
                //    Console.WriteLine(mode);
                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        array[i] = psp2[i];
                //    }

                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = array[i]; // пока ничего не меняем
                //    }
                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет
                //    // 

                //    for (int i = 0; i < PSPLength / 2; i++)
                //    {
                //        array[i] = (sbyte)-array[i * 2 + 1];
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                //    {
                //        array[2 * i + 1] = (sbyte)-array[2 * i + 1];
                //    }

                //    break;

                //case 8: // PSP2i
                //    Console.WriteLine(mode);
                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        array[i] = psp2i[i];
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    for (int i = 0; i < (_FullLength / 2); i++)
                //    {
                //        sbyte temp;
                //        temp = array[2 * i];
                //        array[2 * i] = array[2 * i + 1];
                //        array[2 * i + 1] = (sbyte)-temp;
                //    }

                //    break;

                //case 3: // - psp2
                //    Console.WriteLine(mode);
                //    // i - нашли начало кадра

                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        //array = inputArray[ArrayPos];
                //        array[i] = (sbyte)-psp2[i];
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = array[i];
                //    }
                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    for (int i = 0; i < PSPLength / 2; i++) // инвертируем нечентные
                //    {
                //        array[2 * i] = (sbyte)-array[2 * i];
                //    }


                //    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                //    {
                //        array[2 * i] = (sbyte)-array[2 * i];
                //    }
                //    break;

                //case 7: // -psp2i
                //        // i - нашли начало кадра
                //    Console.WriteLine(mode);
                //    //for (int i = 0; i < PSPLength; i++)
                //    //{
                //    //    //array = inputArray[ArrayPos];
                //    //    array[i] = (sbyte)-psp2i[i];
                //    //}
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву


                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    // приводим к PSP2i, и дальше работаем как с PSP2i


                //    for (int i = 0; i < (_FullLength / 2) - 1; i++)
                //    {
                //        sbyte temp;
                //        temp = (sbyte)-array[2 * i + 1];
                //        array[2 * i + 1] = array[2 * i];
                //        array[2 * i] = temp;
                //    }


                //    break;

                //case 2: //psp1
                //        // i - нашли начало кадра
                //    Console.WriteLine(mode);
                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        array[i] = psp1[i];
                //        //array = inputArray[ArrayPos];
                //        i++;
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    // Далее корректируем соответствующий пакет

                //    for (int i = 0; i < _FullLength; i++)
                //    {
                //        array[i] = (sbyte)-array[i];
                //    }



                //    break;

                //case 6: // psp1i
                //        // i - нашли начало кадра
                //    Console.WriteLine(mode);
                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        //array = inputArray[ArrayPos];
                //        array[i] = psp1i[i];
                //        i++;
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = array[i];
                //        i++;
                //    }
                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    for (int i = 0; i < PSPLength / 2; i++)
                //    {
                //        sbyte temp;
                //        temp = array[2 * i + 1];
                //        array[2 * i + 1] = array[2 * i];
                //        array[2 * i] = temp;
                //    }

                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        array[i] = (sbyte)-array[i];
                //    }


                //    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                //    {
                //        sbyte temp;
                //        temp = array[2 * i];
                //        array[2 * i] = array[2 * i + 1];
                //        array[2 * i + 1] = temp;
                //    }


                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = (sbyte)-array[i];
                //    }

                //    break;

                //case 1: // -psp1
                //    Console.WriteLine(mode);
                //    // i - нашли начало кадра

                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        //array = inputArray[ArrayPos];
                //        array[i] = (sbyte)-psp1[i];
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = array[i];
                //    }
                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    // приводим к PSP1, и дальше работаем как с PSP1


                //    break;

                //case 5:
                //    // i - нашли начало кадра
                //    Console.WriteLine(mode);
                //    for (int i = 0; i < PSPLength; i++)
                //    {
                //        // array = inputArray[ArrayPos];
                //        array[i] = (sbyte)-psp1i[i];
                //        i++;
                //    }
                //    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                //    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                //    {
                //        array[i] = array[i];
                //        i++;
                //    }
                //    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                //    // Далее корректируем соответствующий пакет

                //    // приводим к PSP1i, и дальше работаем как с PSP1i


                //    for (int i = 0; i < PSPLength / 2; i++)
                //    {
                //        sbyte temp;
                //        temp = (sbyte)array[2 * i];
                //        array[2 * i] = array[2 * i + 1];
                //        array[2 * i + 1] = temp;
                //    }


                //    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                //    {
                //        sbyte temp;
                //        temp = (sbyte)array[2 * i];
                //        array[2 * i] = array[2 * i + 1];
                //        array[2 * i + 1] = temp;
                //    }

                //    break;

                #endregion

                case 2: //исходный вариант, корректировать не нужно
                    for (int i = 0; i < array.Length; i++) array[i] = array[i];
                    break;

                case 4: // поворот на 90
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = array[2 * i + 1];
                        array[2 * i + 1] = (sbyte)-array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 6: // поворот на 180
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }
                    break;

                case 8: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 3: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 1: // -psp1

                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (sbyte)-array[i]; ;
                    }
                    break;



            }


            if (mode > 0)
            {
                // logs.SaveLogs(0, mode, 0, 0, dif);

                // positions[empty] = inputArrayPos;
            }
            // return mode;

        }


        public bool PSPSearch_wInt(byte[] inputarray, int outmode)
        {
            int bit;
            bool PSPFinded = false;
            sbyte[] arrayToCorrect = new sbyte[inputarray.Length];
            sbyte[] array = new sbyte[8];
            sbyte[] array2 = new sbyte[8];
            sbyte[] array3 = new sbyte[8];
            sbyte[] array4 = new sbyte[8];
            sbyte[] FirstPacket = new sbyte[_FullLength_int];
            sbyte[] SecondPacket = new sbyte[_FullLength_int];
            sbyte[] ThirdPacket = new sbyte[_FullLength_int];
            sbyte[] FourthPacket = new sbyte[_FullLength_int];

            //if (logs == null) logs = new Demodulator.LogWriter();
            //PSPFinded = false;

            
            for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum

            #region SearchPSP
            for (int i = 0; i < PSPLength_int; i++)
            {
                array[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < PSPLength_int; i++)
            {
                array2[i] = (sbyte)inputarray[i + _FullLength_int];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < PSPLength_int; i++)
            {
                array3[i] = (sbyte)inputarray[i + 2 * _FullLength_int];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < PSPLength_int; i++)
            {
                array4[i] = (sbyte)inputarray[i + 3 * _FullLength_int];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < inputarray.Length; i++)
            {
                arrayToCorrect[i] = (sbyte)inputarray[i];// переводим отрывок из byte в знаковый sbyte
            }

            for (int i = 0; i < PSPLength_int; i++) // ищем поссылку в первый раз
            {
                PSPint[i] = array[i];
                // Записываем в PSP 48 значений из потока
            }

            for (int i = 0; i < PSPLength_int; i++)
            {
                bit = Math.Sign(PSPint[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;
                
                // if NRZ

                if (pspInt1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (pspInt2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (pspInt3[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (pspInt4[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                #endregion

            }

            for (int i = 0; i < PSPLength_int; i++) // ищем поссылку во второй раз
            {
                PSPint[i] = array2[i];
                // Записываем в PSP 48 значений из потока
            }
            for (int i = 0; i < PSPLength_int; i++)
            {
                bit = Math.Sign(PSPint[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;

                // if NRZ

                if (pspInt1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (pspInt2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (pspInt3[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (pspInt4[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                #endregion

            }

            for (int i = 0; i < PSPLength_int; i++) // ищем поссылку во 3 раз
            {
                PSPint[i] = array3[i];
                // Записываем в PSP 48 значений из потока
            }
            for (int i = 0; i < PSPLength_int; i++)
            {
                bit = Math.Sign(PSPint[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;

                // if NRZ

                if (pspInt1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (pspInt2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (pspInt3[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (pspInt4[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                #endregion

            }

            for (int i = 0; i < PSPLength_int; i++) // ищем поссылку во 4 раз
            {
                PSPint[i] = array4[i];
                // Записываем в PSP 48 значений из потока
            }
            for (int i = 0; i < PSPLength_int; i++)
            {
                bit = Math.Sign(PSPint[i]);

                #region Magic with PSP
                if (bit == 0) bit = -1;

                // if NRZ

                if (pspInt1[i] == bit)
                {
                    sum[2]++;
                }
                else
                {
                    sum[1]++;
                }
                if (pspInt2[i] == bit)
                {
                    sum[4]++;
                }
                else
                {
                    sum[3]++;
                }
                if (pspInt3[i] == bit)
                {
                    sum[6]++;
                }
                else
                {
                    sum[5]++;
                }
                if (pspInt4[i] == bit)
                {
                    sum[8]++;
                }
                else
                {
                    sum[7]++;
                }

                #endregion

            }
            #endregion

            #region Dif Modes
            dif[1] = (sbyte)(sum[1] - sum[2]);
            dif[2] = (sbyte)(sum[2] - sum[1]);
            dif[3] = (sbyte)(sum[3] - sum[4]);
            dif[4] = (sbyte)(sum[4] - sum[3]);
            dif[5] = (sbyte)(sum[5] - sum[6]);
            dif[6] = (sbyte)(sum[6] - sum[5]);
            dif[7] = (sbyte)(sum[7] - sum[8]);
            dif[8] = (sbyte)(sum[8] - sum[7]);

           

            #endregion

            difmode = 0;
            maxdif = 0;

            for (int i = 1; i < 9; i++)
            {
                if (dif[i] > maxdif)
                {
                    maxdif = dif[i];
                    difmode = i;
                    //Console.WriteLine(maxdif);
                }
            }
            
            if (maxdif > 25)
            {
                mode = difmode;
                PSPFinded = true;
            }

            if (PSPFinded)
            {
               // Array.Copy(arrayToCorrect, FirstPacket, _FullLength_int);
                PacketCorrect_int(arrayToCorrect, mode);
               // Array.Copy(FirstPacket, arrayToCorrect, _FullLength_int);
                for (int i = 0; i < inputarray.Length; i++)
                {
                    inputarray[i] = (byte)arrayToCorrect[i];// переводим отрывок из byte в знаковый sbyte
                }
            }
            return PSPFinded;
        }

        public void PacketCorrect_int(sbyte[] array, int outmode)
        {
            Console.WriteLine(outmode);
            switch (outmode)
            {
                case 2: //исходный вариант, корректировать не нужно
                    for (int i = 0; i < array.Length; i++) array[i] = array[i];
                    break;

                case 4: // поворот на 90
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = array[2 * i + 1];
                        array[2 * i + 1] = (sbyte)-array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 6: // поворот на 180
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }
                    break;

                case 8: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 3: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 1: // -psp1
                    
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (sbyte)-array[i]; ;
                    }
                    break;


            }


            if (mode > 0)
            {
                // logs.SaveLogs(0, mode, 0, 0, dif);

                // positions[empty] = inputArrayPos;
            }
            // return mode;

        }

        public void PacketCorrect_int(byte[] array1, int outmode)
        {
            sbyte[] array;
            array = new sbyte[array1.Length];
            for (int i = 0; i < array.Length; i++) array[i] = (sbyte)array1[i];
            Console.WriteLine(outmode);
            switch (outmode)
            {
                case 2: //исходный вариант, корректировать не нужно
                    for (int i = 0; i < array.Length; i++) array[i] = array[i];
                    break;

                case 4: // поворот на 90
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = array[2 * i + 1];
                        array[2 * i + 1] = (sbyte)-array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 6: // поворот на 180
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }
                    break;

                case 8: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;

                case 3: // поворот на 270
                    for (int i = 0; i < array.Length / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }
                    break;


            }


            if (mode > 0)
            {
                // logs.SaveLogs(0, mode, 0, 0, dif);

                // positions[empty] = inputArrayPos;
            }
            // return mode;

        }

    }
}
