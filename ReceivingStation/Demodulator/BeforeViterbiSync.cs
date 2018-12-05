using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform.IO;

namespace ReceivingStation
{

    class BeforeViterbiSync
    {
        sbyte[] psp1 = new sbyte[48] { 1, 1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, 1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1 };
        sbyte[] psp1i = new sbyte[48] { 1, 1, 1, -1, 1, -1, -1, -1, -1, 1, 1, -1, 1, 1, -1, -1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1 };
        sbyte[] psp2 = new sbyte[48] { -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, 1, 1, -1, 1, -1, -1, -1, 1, 1, 1, -1, -1, 1, -1, 1, -1, 1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, -1, 1, -1, 1, 1, -1, -1 };
        sbyte[] psp2i = new sbyte[48] { 1, -1, 1, 1, 1, 1, -1, 1, -1, -1, 1, 1, 1, -1, -1, 1, -1, 1, -1, -1, 1, 1, -1, 1, 1, -1, 1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, 1, -1, -1, -1, -1, -1, 1, 1, 1, -1, -1 };
        sbyte[] pspNRZ1 = new sbyte[48] { 1, 1, -1, -1, -1, -1, -1, 1, -1, -1, 1, -1, 1, 1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, -1, 1, 1, 1, 1, 1, 1, 1, -1, 1, -1, -1, 1, -1, 1, -1, -1, -1, 1, 1, 1, -1, 1, -1 };
        sbyte[] pspNRZ2 = new sbyte[48] { -1, 1, -1, -1, -1, -1, -1, 1, -1, -1, 1, -1, 1, 1, -1, 1, 1, 1, -1, -1, 1, -1, -1, 1, -1, 1, 1, 1, 1, 1, 1, 1, -1, 1, -1, -1, 1, -1, 1, -1, -1, -1, 1, 1, 1, -1, 1, -1 };

        sbyte[] sum = new sbyte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] dif = new int[9];
        int[] positions = new int[100];
        //sbyte[] psp1i = new sbyte[48];
        //sbyte[] psp2i = new sbyte[48];
        // -1 равносильно битовой единице, а 1 = нулю
        // все приводится к -psp1

        public Demodulator.Packet[] Packets;
        public Demodulator.Packet Packet;
        public Demodulator.LogWriter logs;

        int _FullLength = 16384;
        int PSPLength = 48;

        sbyte[] PSP = new sbyte[48];
        //sbyte[] DATA = new sbyte[16384 - 48]; // FullLength - PSPLength = 16336 
        sbyte[] DATA = new sbyte[10];
        public sbyte[] DATA1; // FullLength - PSPLength = 16336 
        int difmode;
        int mode;
        int maxdif = 0;
        bool saved = false;

        private sbyte temp;

        // Сюда попадает массив с размеров в считанный файл.
        // Далее, начиная с нулевого элемента идет поиск синхропосылки, размер которой 48 
        // Если же мы не находим синхропосылку, то смещаемся на один элемент вправо, и начинаем поиск, соответсвенно ищем по 48 битов.
        // Когда находим синхропосылку, затем корректируем поток, если это нужно, а потом выделяем пакет, идущий после синхропосылки, размером в (16384 - 48) бит, сохраняем его.




        public bool PSPSearch(byte[] inputarray, int outmode)
        {
            int bit;
            bool PSPFinded = false;
            sbyte[] arrayToCorrect = new sbyte[inputarray.Length];
            sbyte[] array = new sbyte[48];
            sbyte[] array2 = new sbyte[48];
            sbyte[] FirstPacket = new sbyte[_FullLength];
            sbyte[] SecondPacket = new sbyte[_FullLength];
            if (logs == null) logs = new Demodulator.LogWriter();
            //PSPFinded = false;

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

            for (int i = 0; i < sum.Length; i++) sum[i] = 0; // обнуляем sum

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

                #endregion

            }

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в во 2й раз
            {
                PSP[i] = array2[i];
                // Записываем в PSP 48 значений из потока, т.е. берем начало второго потока
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

                #endregion
            }

            dif[1] = (sbyte)(sum[1] - sum[2]);
            dif[2] = (sbyte)(sum[2] - sum[1]);
            dif[3] = (sbyte)(sum[3] - sum[4]);
            dif[4] = (sbyte)(sum[4] - sum[3]);
            dif[5] = (sbyte)(sum[5] - sum[6]);
            dif[6] = (sbyte)(sum[6] - sum[5]);
            dif[7] = (sbyte)(sum[7] - sum[8]);
            dif[8] = (sbyte)(sum[8] - sum[7]);

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

            if (maxdif > 65) mode = difmode;
            else mode = 0;

            if (mode != 0)
            {
                PSPFinded = true;
                outmode = mode;
            }

            if (PSPFinded)
            {
                Array.Copy(arrayToCorrect, FirstPacket, _FullLength);
                Array.Copy(arrayToCorrect, _FullLength, SecondPacket, 0, _FullLength);
                PacketCorrect(FirstPacket);
                PacketCorrect(SecondPacket);
                Array.Copy(FirstPacket, arrayToCorrect, _FullLength);
                Array.Copy(SecondPacket, 0, arrayToCorrect, 16384, _FullLength);

                for (int i = 0; i < inputarray.Length; i++)
                {
                    inputarray[i] = (byte)arrayToCorrect[i];// переводим отрывок из byte в знаковый sbyte
                }
            }


            return PSPFinded;



        }

        public int PacketCorrect(sbyte[] array)
        {

            switch (mode)
            {
                case 4: //PSP2
                        // i - нашли начало кадра
                    Console.WriteLine(mode);
                    for (int i = 0; i < PSPLength; i++)
                    {
                        array[i] = psp2[i];
                    }

                    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    {
                        array[i] = array[i]; // пока ничего не меняем
                    }
                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет
                    // 

                    for (int i = 0; i < PSPLength / 2; i++)
                    {
                        array[i] = (sbyte)-array[i * 2 + 1];
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                    {
                        array[2 * i + 1] = (sbyte)-array[2 * i + 1];
                    }

                    break;

                case 8: // PSP2i
                    Console.WriteLine(mode);
                    for (int i = 0; i < PSPLength; i++)
                    {
                        array[i] = psp2i[i];
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    for (int i = 0; i < (_FullLength / 2); i++)
                    {
                        sbyte temp;
                        temp = array[2 * i];
                        array[2 * i] = array[2 * i + 1];
                        array[2 * i + 1] = (sbyte)-temp;
                    }

                    break;

                case 3: // - psp2
                    Console.WriteLine(mode);
                    // i - нашли начало кадра

                    for (int i = 0; i < PSPLength; i++)
                    {
                        //array = inputArray[ArrayPos];
                        array[i] = (sbyte)-psp2[i];
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    {
                        array[i] = array[i];
                    }
                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    for (int i = 0; i < PSPLength / 2; i++) // инвертируем нечентные
                    {
                        array[2 * i] = (sbyte)-array[2 * i];
                    }


                    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                    {
                        array[2 * i] = (sbyte)-array[2 * i];
                    }
                    break;

                case 7: // -psp2i
                        // i - нашли начало кадра
                    Console.WriteLine(mode);
                    //for (int i = 0; i < PSPLength; i++)
                    //{
                    //    //array = inputArray[ArrayPos];
                    //    array[i] = (sbyte)-psp2i[i];
                    //}
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву


                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    // приводим к PSP2i, и дальше работаем как с PSP2i


                    for (int i = 0; i < (_FullLength / 2) - 1; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)-array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }


                    break;

                case 2: //psp1
                        // i - нашли начало кадра
                    Console.WriteLine(mode);
                    for (int i = 0; i < PSPLength; i++)
                    {
                        array[i] = psp1[i];
                        //array = inputArray[ArrayPos];
                        i++;
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    // Далее корректируем соответствующий пакет

                    for (int i = 0; i < _FullLength; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }



                    break;

                case 6: // psp1i
                        // i - нашли начало кадра
                    Console.WriteLine(mode);
                    for (int i = 0; i < PSPLength; i++)
                    {
                        //array = inputArray[ArrayPos];
                        array[i] = psp1i[i];
                        i++;
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    {
                        array[i] = array[i];
                        i++;
                    }
                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    for (int i = 0; i < PSPLength / 2; i++)
                    {
                        sbyte temp;
                        temp = array[2 * i + 1];
                        array[2 * i + 1] = array[2 * i];
                        array[2 * i] = temp;
                    }

                    for (int i = 0; i < PSPLength; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }


                    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                    {
                        sbyte temp;
                        temp = array[2 * i];
                        array[2 * i] = array[2 * i + 1];
                        array[2 * i + 1] = temp;
                    }


                    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    {
                        array[i] = (sbyte)-array[i];
                    }

                    break;

                case 1: // -psp1
                    Console.WriteLine(mode);
                    // i - нашли начало кадра

                    for (int i = 0; i < PSPLength; i++)
                    {
                        //array = inputArray[ArrayPos];
                        array[i] = (sbyte)-psp1[i];
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    //{
                    //    array[i] = array[i];
                    //}
                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    // приводим к PSP1, и дальше работаем как с PSP1

                    //for (int i = 0; i < PSPLength / 2; i++)
                    //{
                    //    array[2 * i] = (sbyte)array[2 * i];
                    //    array[2 * i + 1] = (sbyte)array[2 * i + 1];
                    //}

                    //for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                    //{
                    //    array[2 * i] = (sbyte)array[2 * i];
                    //    array[2 * i + 1] = (sbyte)array[2 * i + 1];
                    //}

                    break;

                case 5:
                    // i - нашли начало кадра
                    Console.WriteLine(mode);
                    for (int i = 0; i < PSPLength; i++)
                    {
                        // array = inputArray[ArrayPos];
                        array[i] = (sbyte)-psp1i[i];
                        i++;
                    }
                    // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    for (int i = PSPLength; i < _FullLength - PSPLength; i++)
                    {
                        array[i] = array[i];
                        i++;
                    }
                    // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    // Далее корректируем соответствующий пакет

                    // приводим к PSP1i, и дальше работаем как с PSP1i


                    for (int i = 0; i < PSPLength / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)array[2 * i];
                        array[2 * i] = array[2 * i + 1];
                        array[2 * i + 1] = temp;
                    }


                    for (int i = PSPLength; i < (_FullLength - PSPLength) / 2; i++)
                    {
                        sbyte temp;
                        temp = (sbyte)array[2 * i];
                        array[2 * i] = array[2 * i + 1];
                        array[2 * i + 1] = temp;
                    }

                    break;


            }
            if (mode > 0)
            {
                logs.SaveLogs(0, mode, 0, 0, dif);

                // positions[empty] = inputArrayPos;
            }
            return mode;

        }

    }
}
