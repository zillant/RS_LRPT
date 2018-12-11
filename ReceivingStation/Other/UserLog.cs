using System;
using System.IO;
using System.Text;

namespace ReceivingStation.Other
{
    static class UserLog
    {
        #region Запись в лог файл действий пользователя.
        public static void WriteToLogUserActions(string logMessage)
        {
            using (var sw = new StreamWriter("log.txt", true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }

        #endregion
    }
}
