using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Platform.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ReceivingStation.Demodulator
{
    public unsafe partial class StreamCorrection
    {
        static BeforeViterbiSync _BeforeViterbiSync = new BeforeViterbiSync();
        static sbyte[] _outputarray;
        static Packet[] DataPacket;
        static BitPacket[] BitPacket;

        private int bytedata;
        private bool _Interliving;

        #region Конструктор
        public StreamCorrection(byte interliving)
        {
            if (interliving == 0x1) _Interliving = true;
            if (interliving == 0x2) _Interliving = false;
        }
        #endregion
        public void StreamCorrect(string filenameFromRecordingThread)
        {
            FileStream fstream = null;

            fstream = File.OpenRead(filenameFromRecordingThread);
           
            byte[] array = new byte[fstream.Length];
            sbyte[] int_array = new sbyte[fstream.Length];
            sbyte[] out_stream = new sbyte[fstream.Length];

            sbyte[] test_array = new sbyte[10];


            fstream.Read(array, 0, array.Length);

            fstream.Close();
            
            //string textfromFile = System.Text.Encoding.Default.GetString(array);

            for (int i = 0; i < array.Length; i++)
            {
                int_array[i] = (sbyte)array[i];
                //Console.Write(" " + int_array[i]);
            }

            // создавай тут файл, в который ты будешь сейвить пакеты

            _BeforeViterbiSync.StreamSynchronization(int_array, int_array.Length); 

            DataPacket = _BeforeViterbiSync.Packets; // достаем массив пакетов

            BitPacket = new BitPacket[DataPacket.Length];

            byte[] dataarray = new byte[DataPacket.Length * 16384 / 8];

            for (var e = 0; e < BitPacket.Length; e++)
            {
                BitPacket[e] = new BitPacket();
            }

            for (int i = 0; i < DataPacket.Length; i++)
            {
                for (int j = 0; j < DataPacket[i].SyncMarker.Length; j++)
                {
                    if (DataPacket[i].SyncMarker[j] < 0) BitPacket[i].SyncMarker[j] = 1;
                    if (DataPacket[i].SyncMarker[j] > 0) BitPacket[i].SyncMarker[j] = 0;
                }

                for (int j = 0; j < DataPacket[i].PacketBody.Length; j++)
                {
                    if (DataPacket[i].PacketBody[j] < 0) BitPacket[i].PacketBody[j] = 1;
                    if (DataPacket[i].PacketBody[j] > 0) BitPacket[i].PacketBody[j] = 0;
                }
            }

            #region Сохранение в файд
            var filename = "AfterSync.txt";
            string[] Result = new string[DataPacket.Length]; // создаем по строчке для каждого пакета

            System.IO.StreamWriter textfile = new StreamWriter(@"C:\Users\Нестерова ЕВ\source\repos\Recieving Station Final\ReceivingStation\ReceivingStation\bin\Debug\LOGS\DebugAfterSync.txt");

            for (int i = 0; i < BitPacket.Length; i++)
            {
                textfile.Write("Пакет №{0} ", i);
                for (int j = 0; j < BitPacket[i].SyncMarker.Length; j++) textfile.Write(BitPacket[i].SyncMarker[j] + " ");
                for (int k = 0; k < BitPacket[i].PacketBody.Length; k++) textfile.Write(BitPacket[i].PacketBody[k] + " ");
                textfile.WriteLine();

            }
            textfile.Close();


            System.IO.BinaryWriter datfile = new BinaryWriter(File.Create(@"C:\Users\Нестерова ЕВ\source\repos\Recieving Station Final\ReceivingStation\ReceivingStation\bin\Debug\LOGS\AfterSync_HEX.dat"));
            var m = 0;
            for (int i = 0; i < BitPacket.Length; i++) // преобразуем биты в байты
            {
                int count = 0;
                bytedata = 0;
                for (int j = 0; j < BitPacket[i].SyncMarker.Length; j++)
                {
                    bytedata = bytedata << 1;
                    bytedata += BitPacket[i].SyncMarker[j];

                    count = count + 1;
                    if (count == 8)
                    {

                        dataarray[m] = (byte)bytedata;
                        m++;
                        var p = j;
                        count = 0;
                        bytedata = 0;

                    }
                }

                count = 0;
                bytedata = 0;

                for (int k = 0; k < BitPacket[i].PacketBody.Length; k++)
                {
                    bytedata = bytedata << 1;
                    bytedata = bytedata + BitPacket[i].PacketBody[k];

                    count = count + 1;
                    if (count == 8)
                    {
                        dataarray[m] = (byte)bytedata;
                        m++;
                        count = 0;
                        bytedata = 0;
                    }

                }
            }
            datfile.Write(dataarray, 0, dataarray.Length);
            datfile.Close();

            #endregion

        }

        public void StreamCorrect(Platform.IO.FifoStream BeforeSync, FifoStream AfterSync, CancellationToken token)
        {
            int FullLength = 16384;
            long pos;

            byte[] array = new byte[FullLength];
            sbyte[] int_array = new sbyte[FullLength];
            sbyte[] out_stream = new sbyte[FullLength];
            int r;

            if (BeforeSync == null) BeforeSync = new FifoStream(FullLength * 8);

            _BeforeViterbiSync.StreamSynchronization(BeforeSync, AfterSync);

        }

        public void StreamCorrect(byte[] data, int length, byte[] outarray)
        {
                    
            sbyte[] array = new sbyte[length];
            sbyte[] out_stream = new sbyte[length];

            sbyte[] test_array = new sbyte[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (sbyte)data[i];// переводим отрывок из byte в знаковый sbyte
            }

            // создавай тут файл, в который ты будешь сейвить пакеты

            _BeforeViterbiSync.StreamSynchronization(array, array.Length);

            DataPacket = _BeforeViterbiSync.Packets; // достаем массив пакетов

            BitPacket = new BitPacket[DataPacket.Length];

            byte[] dataarray = new byte[DataPacket.Length * 16384 / 8];

            for (var e = 0; e < BitPacket.Length; e++)
            {
                BitPacket[e] = new BitPacket();
            }

            for (int i = 0; i < DataPacket.Length; i++)
            {
                for (int j = 0; j < DataPacket[i].SyncMarker.Length; j++)
                {
                    if (DataPacket[i].SyncMarker[j] < 0) BitPacket[i].SyncMarker[j] = 1;
                    if (DataPacket[i].SyncMarker[j] > 0) BitPacket[i].SyncMarker[j] = 0;
                }

                for (int j = 0; j < DataPacket[i].PacketBody.Length; j++)
                {
                    if (DataPacket[i].PacketBody[j] < 0) BitPacket[i].PacketBody[j] = 1;
                    if (DataPacket[i].PacketBody[j] > 0) BitPacket[i].PacketBody[j] = 0;
                }
            }

            #region Сохранение в файл, и в массив
            var filename = "AfterSync.txt";
            string[] Result = new string[DataPacket.Length]; // создаем по строчке для каждого пакета

            System.IO.StreamWriter textfile = new StreamWriter(@"C:\Users\Нестерова ЕВ\source\repos\Recieving Station Final\ReceivingStation\ReceivingStation\bin\Debug\LOGS\DebugAfterSync.txt");

            for (int i = 0; i < BitPacket.Length; i++)
            {
                textfile.Write("Пакет №{0} ", i);
                for (int j = 0; j < BitPacket[i].SyncMarker.Length; j++) textfile.Write(BitPacket[i].SyncMarker[j] + " ");
                for (int k = 0; k < BitPacket[i].PacketBody.Length; k++) textfile.Write(BitPacket[i].PacketBody[k] + " ");
                textfile.WriteLine();

            }
            textfile.Close();


            System.IO.BinaryWriter datfile = new BinaryWriter(File.Create(@"C:\Users\Нестерова ЕВ\source\repos\Recieving Station Final\ReceivingStation\ReceivingStation\bin\Debug\LOGS\AfterSync_HEX.dat"));
            var m = 0;
            for (int i = 0; i < BitPacket.Length; i++) // преобразуем биты в байты
            {
                int count = 0;
                bytedata = 0;
                for (int j = 0; j < BitPacket[i].SyncMarker.Length; j++)
                {
                    bytedata = bytedata << 1;
                    bytedata += BitPacket[i].SyncMarker[j];

                    count = count + 1;
                    if (count == 8)
                    {

                        dataarray[m] = (byte)bytedata;
                        m++;
                        var p = j;
                        count = 0;
                        bytedata = 0;

                    }
                }

                count = 0;
                bytedata = 0;

                for (int k = 0; k < BitPacket[i].PacketBody.Length; k++)
                {
                    bytedata = bytedata << 1;
                    bytedata = bytedata + BitPacket[i].PacketBody[k];

                    count = count + 1;
                    if (count == 8)
                    {
                        dataarray[m] = (byte)bytedata;
                        m++;
                        count = 0;
                        bytedata = 0;
                    }

                }
            }
            outarray = dataarray;
            datfile.Write(dataarray, 0, dataarray.Length);
            datfile.Close();

            #endregion
        }
    }
}
