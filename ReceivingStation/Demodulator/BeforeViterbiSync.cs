using System;
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
        sbyte[] sum = new sbyte[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] dif = new int[9];
        //sbyte[] psp1i = new sbyte[48];
        //sbyte[] psp2i = new sbyte[48];

        public Packet[] Packets;
        public Packet Packet;
        public LogWriter logs;

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

        public void StreamSynchronization(sbyte[] inputArrayFromFile, int length) // 
        {
            int inputArrayPos = 0;
            int ArrayPos = 0;
            int testinputArrayPos = 0;
            int empty = 0;
            int packetnum = 0;
            int mode = 0;
            int bit;
            int SizeOfPacket = _FullLength;
            logs = new LogWriter();
            //sbyte[] DATA1 = new sbyte[length]; // FullLength - PSPLength = 16336 
            Packets = new Packet[length / 16384 + 1];// создаю массив пакетов, состоящих из синхромаркеров и самих данных, +1 на случай неполного последнего пакета
            sbyte[] inputArray = new sbyte[length + 16384]; // пересоздаем массив  чуть с запасом :D (оптимизация? не, не слышали)


            for (int i = 0; i < length; i++)
            {
                inputArray[i] = inputArrayFromFile[i];
            }

            for (var e = 0; e < Packets.Length; e++)
            {
                Packets[e] = new Packet();
            }

            // DATA1 = new sbyte[length] ;
            //for (int i = 0; i < ((PSPLength / 2) - 1); i++)
            //{
            //    psp1i[2 * i + 1] = psp1[2 * i + 2];
            //    psp1i[2 * i + 2] = psp1[2 * i + 1];
            //    psp2i[2 * i + 1] = psp2[2 * i + 2];
            //    psp2i[2 * i + 2] = psp2[2 * i + 1];
            //}



            while ((ArrayPos < inputArray.Length) && (packetnum < Packets.Length)) // будем ловить по 2 поссылки с промежутком 16384
            {
                ArrayPos = inputArrayPos; // делаю для того, чтобы перемещаться по массиву на 1 с каждой иттерацией цикла. Сохраняем входную позицию на данной иттерации
                // ArrayPos  = pos; inputArrayPos = aIn.Position 

                for (int i = 0; i < sum.Length; i++) sum[i] = 0; //обнуляем sum

                for (int i = ArrayPos; (i - ArrayPos) < PSPLength; i++) // ищем поссылку в первый раз
                {
                    PSP[i - ArrayPos] = inputArray[i];
                    //Console.Write(" " + PSP[i]);
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

                ArrayPos = ArrayPos + _FullLength; // переместились к предположительному началу второго пакета

                for (int i = ArrayPos; (i - inputArrayPos) < PSPLength; i++) // ищем поссылку во второй раз
                {
                    PSP[i - ArrayPos] = inputArray[i];
                    //Console.Write(" " + PSP[i]);
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

                // inputArrayPos = inputArrayPos + PSPLength; //перешли в начало PacketBody

                for (int i = 1; i < 9; i++)
                {
                    if (dif[i] > maxdif)
                    {
                        maxdif = dif[i];
                        difmode = i;
                    }
                    //else difmode = 0;

                }

                // SyncMArker Search with XNOR ^ ~(A ^ B)
                //for (int i = 0; i < PSPLength; i++)
                //{
                //    if (~(PSP[i] ^ psp1[i]) == (sbyte)1) ;
                //}

                if (maxdif > 122 * PSPLength / 100) mode = difmode;
                else mode = 0;
                // SyncMArker Search with XNOR ^ ~(A ^ B)

                switch (mode)
                {
                    case 0:
                        empty++;
                        inputArrayPos++;
                        testinputArrayPos = inputArrayPos;
                        break;
                    #region OLD CASES  
                    //case 8: // PSP2i
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(psp2i[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            temp = Packets[packetnum].PacketBody[2 * j + 1];
                    //            Packets[packetnum].PacketBody[2 * j + 1] = Packets[packetnum].PacketBody[2 * j];
                    //            Packets[packetnum].PacketBody[2 * j] = (sbyte)-temp;
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    //case 3:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(-psp2[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            Packets[packetnum].PacketBody[2 * j + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * j + 1];
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;


                    //case 7:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(-psp2[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }


                    //        for (int j = 0; j < PSPLength / 2; j++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            temp = Packets[packetnum].SyncMarker[2 * j + 1];
                    //            Packets[packetnum].SyncMarker[2 * j + 1] = (sbyte)-Packets[packetnum].SyncMarker[2 * j];
                    //            Packets[packetnum].SyncMarker[2 * j] = temp;
                    //        }


                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            temp = Packets[packetnum].PacketBody[2 * j + 1];
                    //            Packets[packetnum].PacketBody[2 * j + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * j];
                    //            Packets[packetnum].PacketBody[2 * j] = temp;
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    //case 2:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(psp1[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    //case 6:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(psp1i[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            temp = Packets[packetnum].PacketBody[2 * j + 1];
                    //            Packets[packetnum].PacketBody[2 * j + 1] = Packets[packetnum].PacketBody[2 * j];
                    //            Packets[packetnum].PacketBody[2 * j] = temp;
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    //case 1:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(-psp1[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            Packets[packetnum].PacketBody[2 * j] = (sbyte)-Packets[packetnum].PacketBody[2 * j];
                    //            Packets[packetnum].PacketBody[2 * j + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * j + 1];
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    //case 5:
                    //    while (packetnum < Packets.Length) // пока не сформирован каждый пакет
                    //    {


                    //        for (int i = 0; i < PSPLength; i++) // сохраняем в пакет с номером packetnum синхромаркер
                    //        {
                    //            PSP[i] = (sbyte)(-psp1i[i] * 70);
                    //            Packets[packetnum].SyncMarker[i] = PSP[i];
                    //        }

                    //        // сюда нужно считать пакет после синхромаркера, это и есть DATA
                    //        //  перемещаемся к концу синхромаркера  и пока не дойдем до конца пакета     
                    //        inputArrayPos = inputArrayPos + PSPLength; //перемещаемся в начало следующего пакета
                    //        for (int i = inputArrayPos; (i - inputArrayPos) < Packets[packetnum].PacketBody.Length; i++) // выделяем данные в пакете после синхромаркера
                    //        {

                    //            //DATA1[i - (inputArrayPos + PSPLength)] = inputArray[i];
                    //            Packets[packetnum].PacketBody[i - inputArrayPos] = inputArray[inputarray_seek];
                    //            inputarray_seek++;

                    //        }

                    //        for (int j = 0; j < Packets[packetnum].PacketBody.Length / 2; j++)
                    //        {
                    //            temp = Packets[packetnum].PacketBody[2 * j + 1];
                    //            Packets[packetnum].PacketBody[2 * j + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * j];
                    //            Packets[packetnum].PacketBody[2 * j] = (sbyte)-temp;
                    //        }

                    //        inputArrayPos = inputArrayPos + 16336; // перемещаемся к началу следующего синхромаркера
                    //        packetnum++;// переходим в следующий пакет

                    //    }

                    //    break;

                    #endregion

                    case 4: //PSP2
                            // inputarrayPos - нашли начало кадра
                        Console.WriteLine(mode);
                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = psp2[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет
                        // 

                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            Packets[packetnum].SyncMarker[i * 2 + 1] = (sbyte)-Packets[packetnum].SyncMarker[i * 2 + 1];
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * i + 1];
                        }
                        packetnum++;
                        break;

                    case 8: // PSP2i
                        Console.WriteLine(mode);
                        // inputarrayPos - нашли начало кадра
                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = psp2i[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].SyncMarker[2 * i];
                            Packets[packetnum].SyncMarker[2 * i] = Packets[packetnum].SyncMarker[2 * i + 1];
                            Packets[packetnum].SyncMarker[2 * i + 1] = (sbyte)-temp;
                        }


                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].PacketBody[2 * i];
                            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)-temp;
                        }

                        packetnum++;
                        break;

                    case 3: // - psp2
                        Console.WriteLine(mode);
                        // inputarrayPos - нашли начало кадра

                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = (sbyte)-psp2[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        for (int i = 0; i < PSPLength / 2; i++) // инвертируем нечентные
                        {
                            Packets[packetnum].SyncMarker[2 * i] = (sbyte)-Packets[packetnum].SyncMarker[2 * i];
                        }


                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            Packets[packetnum].PacketBody[2 * i] = (sbyte)-Packets[packetnum].PacketBody[2 * i];
                        }

                        packetnum++;
                        break;

                    case 7: // -psp2i
                            // inputarrayPos - нашли начало кадра
                        Console.WriteLine(mode);
                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = (sbyte)-psp2i[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        // приводим к PSP2i, и дальше работаем как с PSP2i


                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].SyncMarker[2 * i];
                            Packets[packetnum].SyncMarker[2 * i] = (sbyte)-Packets[packetnum].SyncMarker[2 * i + 1];
                            Packets[packetnum].SyncMarker[2 * i + 1] = temp;
                        }


                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].PacketBody[2 * i];
                            Packets[packetnum].PacketBody[2 * i] = (sbyte)-Packets[packetnum].PacketBody[2 * i + 1];
                            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                        }

                        packetnum++;
                        break;

                    case 2: //psp1
                            // inputarrayPos - нашли начало кадра
                        Console.WriteLine(mode);
                        for (int i = 0; i < PSPLength; i++)
                        {
                            Packets[packetnum].SyncMarker[i] = psp1[i];
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        for (int i = 0; i < PSPLength; i++)
                        {
                            Packets[packetnum].SyncMarker[i] = (sbyte)-Packets[packetnum].SyncMarker[i];
                        }

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = (sbyte)-Packets[packetnum].PacketBody[i];
                        }

                        packetnum++;
                        break;

                    case 6: // psp1i
                            // inputarrayPos - нашли начало кадра
                        Console.WriteLine(mode);
                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = psp1i[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].SyncMarker[2 * i + 1];
                            Packets[packetnum].SyncMarker[2 * i + 1] = Packets[packetnum].SyncMarker[2 * i];
                            Packets[packetnum].SyncMarker[2 * i] = temp;
                        }

                        for (int i = 0; i < PSPLength; i++)
                        {
                            Packets[packetnum].SyncMarker[i] = (sbyte)-Packets[packetnum].SyncMarker[i];
                        }


                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            sbyte temp;
                            temp = Packets[packetnum].PacketBody[2 * i];
                            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                        }


                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = (sbyte)-Packets[packetnum].PacketBody[i];
                        }

                        packetnum++;
                        break;

                    case 1: // -psp1
                        Console.WriteLine(mode);
                        // inputarrayPos - нашли начало кадра

                        for (int i = 0; i < PSPLength; i++)
                        {
                            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = (sbyte)-psp1[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        // приводим к PSP1, и дальше работаем как с PSP1

                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            Packets[packetnum].SyncMarker[2 * i] = (sbyte)Packets[packetnum].SyncMarker[2 * i];
                            Packets[packetnum].SyncMarker[2 * i + 1] = (sbyte)Packets[packetnum].SyncMarker[2 * i + 1];
                        }

                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            Packets[packetnum].PacketBody[2 * i] = (sbyte)Packets[packetnum].PacketBody[2 * i];
                            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)Packets[packetnum].PacketBody[2 * i + 1];
                        }

                        packetnum++;
                        break;


                    case 5:
                        // inputarrayPos - нашли начало кадра
                        Console.WriteLine(mode);
                        for (int i = 0; i < PSPLength; i++)
                        {
                            // Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                            Packets[packetnum].SyncMarker[i] = (sbyte)-psp1i[i];
                            inputArrayPos++;
                        }
                        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                        for (int i = 0; i < _FullLength - PSPLength; i++)
                        {
                            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                            inputArrayPos++;
                        }
                        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                        // Далее корректируем соответствующий пакет

                        // приводим к PSP1i, и дальше работаем как с PSP1i


                        for (int i = 0; i < PSPLength / 2; i++)
                        {
                            sbyte temp;
                            temp = (sbyte)Packets[packetnum].SyncMarker[2 * i];
                            Packets[packetnum].SyncMarker[2 * i] = Packets[packetnum].SyncMarker[2 * i + 1];
                            Packets[packetnum].SyncMarker[2 * i + 1] = temp;
                        }


                        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                        {
                            sbyte temp;
                            temp = (sbyte)Packets[packetnum].PacketBody[2 * i];
                            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                        }

                        packetnum++;
                        break;


                }
                if (mode > 0) logs.SaveLogs(packetnum, mode, ArrayPos, ArrayPos - inputArrayPos, dif);
            }

            // вне цикла сделать дозапись в конце массива
        }

        public void StreamSynchronization(FifoStream BeforeSync, FifoStream AfterSync) // 
        {
            int inputArrayPos = 0;
            long Pos = 0;
            int testinputArrayPos = 0;
            int empty = 0;
            int packetnum = 0;
            int mode = 0;
            int bit;
            int SizeOfPacket = _FullLength;

            logs = new LogWriter();
            Packet = new Packet();// создаю массив пакетов, состоящих из синхромаркеров и самих данных, +1 на случай неполного последнего пакета

            byte[] inputArray = new byte[_FullLength];
            sbyte[] inputBuffer = new sbyte[_FullLength]; // пересоздаем массив в sbyte

            Pos = BeforeSync.Position; // аолучаем позицию в потоке
            BeforeSync.Read(inputArray, 0, _FullLength); //читаем из потока в буффер 16384 битов

            for (int i = 0; i < _FullLength; i++) // преобразовываем из byte в sbyte
            {
                inputBuffer[i] = (sbyte)inputArray[i];
            }

            for (int i = 0; i < sum.Length; i++) sum[i] = 0; //обнуляем sum 

            for (int i = 0; i < PSPLength; i++) // ищем поссылку в первый раз, т.е. берем первые 48 битов и ищем по ним различные варианты синхромаркера
            {
                PSP[i] = inputBuffer[i];    // Записываем в PSP 48 значений из потока
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

            } // ищем совпадения поточных битов с битами синхромаркера

            // перемещаемся по потоку на 16384 бита, т.е. к следующему пакету 
            //BeforeSync.Position = Pos + _FullLength;
            BeforeSync.Read(inputArray, _FullLength, _FullLength);
            for (int i = 0; i < _FullLength; i++) // преобразовываем из byte в sbyte
            {
                inputBuffer[i] = (sbyte)inputArray[i];
            }
            //BeforeSync.Position = Pos + _FullLength; // перемещаемся к началу 3 пакета
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

            } // второй раз ищем совпадения поточных битов с битами синхромаркера

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

            // inputArrayPos = inputArrayPos + PSPLength; //перешли в начало PacketBody

            for (int i = 1; i < 9; i++)
            {
                if (dif[i] > maxdif)
                {
                    maxdif = dif[i];
                    difmode = i;
                }
                //else difmode = 0;
            }

            if (maxdif > 122 * PSPLength / 100) mode = difmode;
            else mode = 0;
            switch (mode)
            {
                case 0:
                    empty++;
                    //BeforeSync.Position = Pos + 1;
                    break;


                    //    case 4: //PSP2
                    //            // inputarrayPos - нашли начало кадра
                    //        Console.WriteLine(mode);
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = psp2[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет
                    //        // 

                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            Packets[packetnum].SyncMarker[i * 2 + 1] = (sbyte)-Packets[packetnum].SyncMarker[i * 2 + 1];
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)-Packets[packetnum].PacketBody[2 * i + 1];
                    //        }
                    //        packetnum++;
                    //        break;

                    //    case 8: // PSP2i
                    //        Console.WriteLine(mode);
                    //        // inputarrayPos - нашли начало кадра
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = psp2i[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].SyncMarker[2 * i];
                    //            Packets[packetnum].SyncMarker[2 * i] = Packets[packetnum].SyncMarker[2 * i + 1];
                    //            Packets[packetnum].SyncMarker[2 * i + 1] = (sbyte)-temp;
                    //        }


                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].PacketBody[2 * i];
                    //            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                    //            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)-temp;
                    //        }

                    //        packetnum++;
                    //        break;

                    //    case 3: // - psp2
                    //        Console.WriteLine(mode);
                    //        // inputarrayPos - нашли начало кадра

                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-psp2[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        for (int i = 0; i < PSPLength / 2; i++) // инвертируем нечентные
                    //        {
                    //            Packets[packetnum].SyncMarker[2 * i] = (sbyte)-Packets[packetnum].SyncMarker[2 * i];
                    //        }


                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[2 * i] = (sbyte)-Packets[packetnum].PacketBody[2 * i];
                    //        }

                    //        packetnum++;
                    //        break;

                    //    case 7: // -psp2i
                    //            // inputarrayPos - нашли начало кадра
                    //        Console.WriteLine(mode);
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-psp2i[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        // приводим к PSP2i, и дальше работаем как с PSP2i


                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].SyncMarker[2 * i];
                    //            Packets[packetnum].SyncMarker[2 * i] = (sbyte)-Packets[packetnum].SyncMarker[2 * i + 1];
                    //            Packets[packetnum].SyncMarker[2 * i + 1] = temp;
                    //        }


                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].PacketBody[2 * i];
                    //            Packets[packetnum].PacketBody[2 * i] = (sbyte)-Packets[packetnum].PacketBody[2 * i + 1];
                    //            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                    //        }

                    //        packetnum++;
                    //        break;

                    //    case 2: //psp1
                    //            // inputarrayPos - нашли начало кадра
                    //        Console.WriteLine(mode);
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            Packets[packetnum].SyncMarker[i] = psp1[i];
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-Packets[packetnum].SyncMarker[i];
                    //        }

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = (sbyte)-Packets[packetnum].PacketBody[i];
                    //        }

                    //        packetnum++;
                    //        break;

                    //    case 6: // psp1i
                    //            // inputarrayPos - нашли начало кадра
                    //        Console.WriteLine(mode);
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = psp1i[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].SyncMarker[2 * i + 1];
                    //            Packets[packetnum].SyncMarker[2 * i + 1] = Packets[packetnum].SyncMarker[2 * i];
                    //            Packets[packetnum].SyncMarker[2 * i] = temp;
                    //        }

                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-Packets[packetnum].SyncMarker[i];
                    //        }


                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = Packets[packetnum].PacketBody[2 * i];
                    //            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                    //            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                    //        }


                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = (sbyte)-Packets[packetnum].PacketBody[i];
                    //        }

                    //        packetnum++;
                    //        break;

                    //    case 1: // -psp1
                    //        Console.WriteLine(mode);
                    //        // inputarrayPos - нашли начало кадра

                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            //Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-psp1[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        // приводим к PSP1, и дальше работаем как с PSP1

                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            Packets[packetnum].SyncMarker[2 * i] = (sbyte)Packets[packetnum].SyncMarker[2 * i];
                    //            Packets[packetnum].SyncMarker[2 * i + 1] = (sbyte)Packets[packetnum].SyncMarker[2 * i + 1];
                    //        }

                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[2 * i] = (sbyte)Packets[packetnum].PacketBody[2 * i];
                    //            Packets[packetnum].PacketBody[2 * i + 1] = (sbyte)Packets[packetnum].PacketBody[2 * i + 1];
                    //        }



                    //        packetnum++;
                    //        break;


                    //    case 5:
                    //        // inputarrayPos - нашли начало кадра
                    //        Console.WriteLine(mode);
                    //        for (int i = 0; i < PSPLength; i++)
                    //        {
                    //            // Packets[packetnum].SyncMarker[i] = inputArray[ArrayPos];
                    //            Packets[packetnum].SyncMarker[i] = (sbyte)-psp1i[i];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили синхромаркер, и переместились на PSPLength по входному массиву

                    //        for (int i = 0; i < _FullLength - PSPLength; i++)
                    //        {
                    //            Packets[packetnum].PacketBody[i] = inputArray[inputArrayPos];
                    //            inputArrayPos++;
                    //        }
                    //        // сохранили информационный кадр, и переместились  на 16336 позиций по входному массиву
                    //        // Далее корректируем соответствующий пакет

                    //        // приводим к PSP1i, и дальше работаем как с PSP1i


                    //        for (int i = 0; i < PSPLength / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = (sbyte)Packets[packetnum].SyncMarker[2 * i];
                    //            Packets[packetnum].SyncMarker[2 * i] = Packets[packetnum].SyncMarker[2 * i + 1];
                    //            Packets[packetnum].SyncMarker[2 * i + 1] = temp;
                    //        }


                    //        for (int i = 0; i < (_FullLength - PSPLength) / 2; i++)
                    //        {
                    //            sbyte temp;
                    //            temp = (sbyte)Packets[packetnum].PacketBody[2 * i];
                    //            Packets[packetnum].PacketBody[2 * i] = Packets[packetnum].PacketBody[2 * i + 1];
                    //            Packets[packetnum].PacketBody[2 * i + 1] = temp;
                    //        }

                    //        packetnum++;
                    //        break;


            }
            //if (mode > 0) logs.SaveLogs(packetnum, mode, ArrayPos, ArrayPos - inputArrayPos, dif);


            // вне цикла сделать дозапись в конце массива

        }

        
    }
}
