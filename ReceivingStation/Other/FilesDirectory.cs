using ReceivingStation.Properties;
using System;
using System.IO;

namespace ReceivingStation.Other
{
    static class FilesDirectory
    {
        public static string UserLogFile { get; } = $"{LogsDirectory}\\{Resources.UserLogFileName}";

        public static string WorkingTimeOnBoardFile { get; } = $"{LogsDirectory}\\{Resources.WorkingTimeOnBoardFileName}";

        static string MainDirectory { get; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Resources.MainDirName}";

        static string LogsDirectory { get; } = $"{MainDirectory}\\{Resources.LogsDirName}";

        static string SessionsDirectory { get; } = $"{MainDirectory}\\{Resources.SessionsDirName}";

        static string DateDirectory { get; } = $"{SessionsDirectory}\\{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";
   
        public static void CreateApplicationDirectory()
        {
            if (Directory.Exists(MainDirectory) == false)
            {
                Directory.CreateDirectory(MainDirectory);
            }

            if (Directory.Exists(LogsDirectory) == false)
            {
                Directory.CreateDirectory(LogsDirectory);
            }

            if (Directory.Exists(SessionsDirectory) == false)
            {
                Directory.CreateDirectory(SessionsDirectory);
            }
        }

        public static string GetCurrentSessionDirectory(string sessionName)
        {
            if (Directory.Exists($"{DateDirectory}") == false)
            {
                Directory.CreateDirectory($"{DateDirectory}");
            }

            string sessionDirectory = $"{DateDirectory}\\{sessionName}";

            if (Directory.Exists(sessionDirectory) == false)
            {
                Directory.CreateDirectory(sessionDirectory);
            }

            return sessionDirectory;
        }
    }
}
