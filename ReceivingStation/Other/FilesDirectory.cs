using ReceivingStation.Properties;
using System;
using System.IO;

namespace ReceivingStation.Other
{
    static class FilesDirectory
    {         
        static string MainDirectory { get; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{Resources.MainDirName}";

        static string LogsDirectory { get; } = $"{MainDirectory}\\{Resources.LogsDirName}";

        public static string UserLogFile { get; } = $"{LogsDirectory}\\{Resources.UserLogFileName}";

        public static string WorkingTimeOnBoardFile { get; } = $"{LogsDirectory}\\{Resources.WorkingTimeOnBoardFileName}";

        public static string SessionsDirectory { get; } = $"{MainDirectory}\\{Resources.SessionsDirName}";

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
            if (Directory.Exists($"{SessionsDirectory}\\{sessionName}") == false)
            {
                Directory.CreateDirectory($"{SessionsDirectory}\\{sessionName}");
            }

            return $"{SessionsDirectory}\\{sessionName}";
        }
    }
}
