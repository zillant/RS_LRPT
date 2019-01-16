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
        /// Открытие файла времени наработки.
        /// </summary>
        /// <remarks>
        /// Попытка считать значения времени наработки каждого полукомплекта.
        /// Если файл нет, создает новый с нулевыми значениями.
        /// </remarks>
        public static void ReadValues(TimeSpan mainFcpWorkingTime, TimeSpan reserveFcpWorkingTime, TimeSpan mainPrdWorkingTime, TimeSpan reservePrdWorkingTime)
        {
            try
            {
                Read();
            }
            catch (Exception)
            {
                Write(mainFcpWorkingTime, reserveFcpWorkingTime, mainPrdWorkingTime, reservePrdWorkingTime);
                Read();
            }
        }

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
        /// <remarks>
        /// Не передаю ссылки на переменные, потому что это не работает. Ссылкам значения не присваиваются, хз почему.
        /// </remarks>
        private static void Read()
        {
            using (StreamReader sr = new StreamReader(ApplicationDirectory.WorkingTimeOnBoardFile))
            {
                FormReceive.MainFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                FormReceive.ReserveFcpWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                FormReceive.MainPrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
                FormReceive.ReservePrdWorkingTime = TimeSpan.Parse(sr.ReadLine() ?? "0.0:0:0");
            }
        }
    }
}
