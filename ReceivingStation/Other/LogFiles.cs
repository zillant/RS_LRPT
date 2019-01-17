using System;
using System.IO;
using System.Text;

namespace ReceivingStation.Other
{
    /// <summary>
    /// Класс для работы с лог файлами.
    /// </summary>
    static class LogFiles
    {
        /// <summary>
        /// Запись в лог файл действий пользователя.
        /// </summary>
        /// <param name="logMessage">Сообщение для записи в лог файл.</param> 
        public static void WriteUserActions(string logMessage)
        {
            using (var sw = new StreamWriter(ApplicationDirectory.UserLogFile, true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }

        /// <summary>
        /// Запись в файл времени наработки.
        /// </summary>
        /// <param name="mainFcpWorkingTime">Время наработки основного ФЦП.</param> 
        /// <param name="reserveFcpWorkingTime">Время наработки резервного ФЦП.</param> 
        /// <param name="mainPrdWorkingTime">Время наработки основного ПРД.</param> 
        /// <param name="reservePrdWorkingTime">Время наработки резервного ПРД.</param> 
        public static void WriteWorkingTimeValues(TimeSpan mainFcpWorkingTime, TimeSpan reserveFcpWorkingTime, TimeSpan mainPrdWorkingTime, TimeSpan reservePrdWorkingTime)
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
        public static void ReadWorkingTimeValues(out TimeSpan mainFcpWorkingTime, out TimeSpan reserveFcpWorkingTime, out TimeSpan mainPrdWorkingTime, out TimeSpan reservePrdWorkingTime)
        {
            try
            {
                using (StreamReader sr = new StreamReader(ApplicationDirectory.WorkingTimeOnBoardFile))
                {
                    mainFcpWorkingTime = TimeSpan.Parse(sr.ReadLine());
                    reserveFcpWorkingTime = TimeSpan.Parse(sr.ReadLine());
                    mainPrdWorkingTime = TimeSpan.Parse(sr.ReadLine());
                    reservePrdWorkingTime = TimeSpan.Parse(sr.ReadLine());
                }
            }
            catch (Exception)
            {
                mainFcpWorkingTime = TimeSpan.Parse("0.0:0:0");
                reserveFcpWorkingTime = TimeSpan.Parse("0.0:0:0");
                mainPrdWorkingTime = TimeSpan.Parse("0.0:0:0");
                reservePrdWorkingTime = TimeSpan.Parse("0.0:0:0");
                WriteWorkingTimeValues(mainFcpWorkingTime, reserveFcpWorkingTime, mainPrdWorkingTime, reservePrdWorkingTime);
            }
        }
    }
}
