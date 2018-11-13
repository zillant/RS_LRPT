using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReceivingStation.Demodulator
{
    class LogWriter
    {
        string dateString = DateTime.Now.ToString("yyyy_MM_dd");
        string timeString = DateTime.Now.ToString("HH-mm-ss");
        StreamWriter textfile;

        public LogWriter()
        {
            textfile = new StreamWriter(@"C:\Users\Нестерова ЕВ\source\repos\Recieving Station Final\ReceivingStation\ReceivingStation\bin\Debug\" + timeString + "_DemodLogs.txt");
        }

        
        public void SaveLogs(int iterration, int mode, int startPos, int Length, int[] dif)
        {
            if (mode != 0)
            {
                textfile.Write("Пакет №{0} ", iterration);
                textfile.Write(mode);
                textfile.Write(" {0}", startPos);
                textfile.Write(" {0} ", Length);
                for (int i = 0; i < dif.Length; i++) textfile.Write("/{0}", dif[i]);
                textfile.WriteLine();
            }
            
        }
        
    }
}
