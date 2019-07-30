using System;
using System.IO;

namespace ReceivingStation.Demodulator
{
    public unsafe partial class StreamCorrection
    {
        static BeforeViterbiSync _BeforeViterbiSync = new BeforeViterbiSync();
        BinaryWriter datfile;
        private int bytedata;
        private bool _Interliving;

        #region Конструктор
        public StreamCorrection(byte interliving, string filename)
        {
            if (interliving == 0x1) _Interliving = true;
            if (interliving == 0x2) _Interliving = false;
            datfile = new BinaryWriter(File.Create(filename));
            //_isSelfTest = false;
        }
        #endregion

        public StreamCorrection(byte interliving)
        {
            
        }
        

        public void fromAmplitudesToBits(byte[] indata, byte[] array)
        {
            sbyte[] data = new sbyte[indata.Length];
            byte[] outarray = new byte[indata.Length / 8];
            //byte[] array = new byte[indata.Length / 8];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (sbyte)indata[i];
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > 0) data[i] = 0;
                if (data[i] < 0) data[i] = 1;
            }

            var m = 0;
            int count = 0;
            bytedata = 0;
            for (int i = 0; i < data.Length; i++) // преобразуем биты в байты
            {

                bytedata = bytedata << 1;
                bytedata += data[i];
                count = count + 1;
                if (count == 8)
                {
                    outarray[m] = (byte)bytedata;
                    m++;
                    count = 0;
                    bytedata = 0;
                }

            }

            Array.Copy(outarray, array, array.Length);
           
        }

       

        public void StopCorrect()
        {
            
        }
    }
}
