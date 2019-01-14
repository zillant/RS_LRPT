using ReceivingStation.Properties;
using System;
using System.IO;

namespace ReceivingStation.Other
{
    /// <summary>
    /// Класс для работы с основным каталогом приложения,
    /// который находится в папке "Мои Документы" текущего пользователя.
    /// </summary>
    /// <remarks>
    /// Класс создает: основной каталог приложения если он не создан, каталог для каждого сеанса приема.
    /// Класс предоставляет путь к файлам: пользовательский лог файл, лог файл времени наработки борта.
    /// </remarks>
    static class ApplicationDirectory
    {
        private static string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string _mainDirectory = _myDocuments + Resources.MainDirName;
        private static string _logsDirectory  = _mainDirectory + Resources.LogsDirName;
        private static string _sessionsDirectory = _mainDirectory + Resources.SessionsDirName;
        private static string _dateDirectory = $"{_sessionsDirectory}{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";

        /// <summary>
        /// Пользовательский лог файл.
        /// </summary>
        /// <returns>
        /// Путь к пользовательскому лог файлу.
        /// </returns>
        public static string UserLogFile { get; } = _logsDirectory + Resources.UserLogFileName;

        /// <summary>
        /// Лог файл времени наработки борта.
        /// </summary>
        /// <returns>
        /// Путь к лог файлу времени наработки борта.
        /// </returns>
        public static string WorkingTimeOnBoardFile { get; } = _logsDirectory + Resources.WorkingTimeOnBoardFileName;

        /// <summary>
        /// Создание основоного каталога приложения.
        /// </summary>
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

        /// <summary>
        /// Получение пути к каталогу текущего сеанса.        
        /// </summary>
        /// <remarks>
        /// Создает каталог текущего сеанса.
        /// Создает каталог текущей даты если он не создан.        
        /// </remarks>
        /// <param name="sessionName">Имя сеанса приема.</param> 
        /// <returns>
        /// Путь к каталогу текущего сеанса.
        /// </returns>
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
