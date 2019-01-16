using System;
using System.IO;
using System.Text;

namespace ReceivingStation.Other
{
    /// <summary>
    /// Класс для работы с лог файлом времени наработки борта.
    /// </summary>
    static class WorkingTimeOnboardLog
    {
        /// <summary>
        /// Запись в файл времени наработки.
        /// </summary>
        /// <param name="mainFcpWorkingTime">Время наработки основного ФЦП.</param> 
        /// <param name="reserveFcpWorkingTime">Время наработки резервного ФЦП.</param> 
        /// <param name="mainPrdWorkingTime">Время наработки основного ПРД.</param> 
        /// <param name="reservePrdWorkingTime">Время наработки резервного ПРД.</param> 
        public static void Write(TimeSpan mainFcpWorkingTime, TimeSpan reserveFcpWorkingTime, TimeSpan mainPrdWorkingTime, TimeSpan reservePrdWorkingTime)
        {
            using (StreamWriter sw = new StreamWriter(ApplicationDirectory.WorkingTimeOnBoardFile, false, Encoding.UTF8, 65536))
            {
                // Первые 4 строчки в формате удобном для Е.В.
                sw.WriteLine($"{mainFcpWorkingTime.Days}.{mainFcpWorkingTime.Hours}:{mainFcpWorkingTime.Minutes}:{mainFcpWorkingTime.Seconds}");

                sw.WriteLine($"{reserveFcpWorkingTime.Days}.{reserveFcpWorkingTime.Hours}:{reserveFcpWorkingTime.Minutes}:{reserveFcpWorkingTime.Seconds}");

                sw.WriteLine($"{mainPrdWorkingTime.Days}.{mainPrdWorkingTime.Hours}:{mainPrdWorkingTime.Minutes}:{mainPrdWorkingTime.Seconds}");

                sw.WriteLine($"{reservePrdWorkingTime.Days}.{reservePrdWorkingTime.Hours}:{reservePrdWorkingTime.Minutes}:{reservePrdWorkingTime.Seconds}");
            }
        }

        /// <summary>
        /// Чтение значений из файла времени наработки.
        /// </summary> 
        /// <param name="mainFcpWorkingTime">Время наработки основного ФЦП.</param> 
        /// <param name="reserveFcpWorkingTime">Время наработки резервного ФЦП.</param> 
        /// <param name="mainPrdWorkingTime">Время наработки основного ПРД.</param> 
        /// <param name="reservePrdWorkingTime">Время наработки резервного ПРД.</param> 
        public static void Read(out TimeSpan mainFcpWorkingTime, out TimeSpan reserveFcpWorkingTime, out TimeSpan mainPrdWorkingTime, out TimeSpan reservePrdWorkingTime)
        {
            using (StreamReader sr = new StreamReader(ApplicationDirectory.WorkingTimeOnBoardFile))
            {
                mainFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                reserveFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                mainPrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                reservePrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
            }
        }
    }
}
