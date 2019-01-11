using ReceivingStation.Properties;
using System;
using System.IO;

namespace ReceivingStation.Other
{
    static class FilesDirectory
    {
        private static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string _mainDirectory = _myDocuments + Resources.MainDirName;
        private static string _logsDirectory  = _mainDirectory + Resources.LogsDirName;
        private static string _sessionsDirectory = _mainDirectory + Resources.SessionsDirName;
        private static string _dateDirectory = $"{_sessionsDirectory}{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";

        public static string UserLogFile { get; } = _logsDirectory + Resources.UserLogFileName;
        public static string WorkingTimeOnBoardFile { get; } = _logsDirectory + Resources.WorkingTimeOnBoardFileName;

        public static void CreateApplicationDirectory()
        {
            if (Directory.Exists(_mainDirectory) == false)
            {
                Directory.CreateDirectory(_mainDirectory);
            }

            if (Directory.Exists(_logsDirectory) == false)
            {
                Directory.CreateDirectory(_logsDirectory);
            }

            if (Directory.Exists(_sessionsDirectory) == false)
            {
                Directory.CreateDirectory(_sessionsDirectory);
            }
        }

        public static string GetCurrentSessionDirectory(string sessionName)
        {
            if (Directory.Exists($"{_dateDirectory}") == false)
            {
                Directory.CreateDirectory($"{_dateDirectory}");
            }

            string sessionDirectory = $"{_dateDirectory}\\{sessionName}";

            if (Directory.Exists(sessionDirectory) == false)
            {
                Directory.CreateDirectory(sessionDirectory);
            }

            return sessionDirectory;
        }
    }
}
