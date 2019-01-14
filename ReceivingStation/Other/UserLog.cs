using System;
using System.IO;
using System.Text;

namespace ReceivingStation.Other
{
    /// <summary>
    /// Класс для работы с пользовательским лог файлом.
    /// </summary>
    static class UserLog
    {
        /// <summary>
        /// Запись в лог файл действий пользователя.
        /// </summary>
        /// <param name="logMessage">Сообщение для записи в лог файл.</param> 
        public static void WriteToLogUserActions(string logMessage)
        {
            using (var sw = new StreamWriter(ApplicationDirectory.UserLogFile, true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }
    }
}
