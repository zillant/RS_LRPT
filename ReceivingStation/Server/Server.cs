using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ReceivingStation.Properties;

namespace ReceivingStation.Server
{
    /// <summary>
    /// Класс сокет сервера, для дистанционной работы с ИВК.
    /// Используется в режимах "Самопроверка" и "Прием"
    /// </summary>
    class Server
    {
        public delegate void ChangeModeDelegate(byte modeNumber);
        public ChangeModeDelegate ThreadSafeChangeMode;
        public delegate void SetParametersDelegate(byte fcp, byte prd, byte freq, byte interliving);
        public SetParametersDelegate ThreadSafeSetReceiveParameters;
        public delegate bool[] GetSyncsStatesDelegate();
        public GetSyncsStatesDelegate ThreadSafeGetSyncsStates;
        public delegate void StartStopReceivingDelegate();
        public StartStopReceivingDelegate ThreadSafeStartStopReceiving;

        public bool StopThread;

        public static bool RemoteModeFlag { get; set; }
        public bool ReceivingStartedFlag { get; set; } // Начат ли прием потока.

        private const byte OkMessage = 0x0; // Команда выполнена.
        private const byte InvalidCommandMessage = 0x1; // Ошибочная команда.
        private const byte ParametersNotSetMessage = 0x2; // Не установлены параметры записи потока.
        private const byte LocalModeMessage = 0x3; // КПА находится в режиме местного управления.
        private const byte RemoteModeMessage = 0x4; // КПА находится в режиме дистанционного управления.
        private const byte ReceivingStartedMessage = 0x5; // Прием потока уже начат.
        private const byte ReceivingNotStartedMessage = 0x6; // Прием потока еще не начат.
        private const byte CommandNotComletedMessage = 0x7; // Выполнение предыдущей команды не завершено.
        private const byte CommandHeader = 0x33; // Заголовок полученной команды.

        private bool _setParametersFlag; // Установлены ли параметры приема.       
        private bool _isCommandCompleted; // Проверка, выполнена ли принятая команда.
        private NetworkStream _stream;

        private bool _isItSelfTest; // Флаг, является ли это процессом самопроверки. Нужно чтоб не привязывать делегаты к форме самопроверки.

        public Server(bool isItSelfTest)
        {
            StopThread = false;
            _isItSelfTest = isItSelfTest;
            _isCommandCompleted = false;
        }

        /// <summary>
        /// Запустить работу сервера.
        /// </summary>
        /// <remarks>
        /// Ожидает подключения клиента. Сверяет IP клиента со списком разрешенных IP.
        /// Принимает сообщения от клиента и отвечает ему.
        /// </remarks>
        public void StartServer()
        {
            byte[] data = new byte[256];  // Буфер для получаемых команд.                    

            try
            {
                var server = new TcpListener(IPAddress.Parse("0.0.0.0"), 11005);

                _setParametersFlag = false;
                ReceivingStartedFlag = false;

                while (StopThread == false)
                {
                    // Перевод в местный режим управления.                 
                    if (!_isItSelfTest)
                        ThreadSafeChangeMode(1);
                    else
                    {
                        _setParametersFlag = false;
                        ReceivingStartedFlag = false;
                    }

                    RemoteModeFlag = false;

                    server.Start();

                    var client = server.AcceptTcpClient();

                    List<string> ipList = new List<string> { Settings.Default.ipAddressIVK, Resources.ipAddressLocal };

                    if (!ipList.Contains(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()))
                    {
                        client.Close();
                        continue;
                    }

                    server.Stop(); // Больше не ждем подключений.  
                    _stream = client.GetStream();

                    try
                    {
                        while (true)
                        {
                            var bytes = _stream.Read(data, 0, data.Length); // Количество полученных байт.
                            var command = new byte[bytes];
                            Array.Copy(data, 0, command, 0, bytes); // Извлечение принятой команды.

                            if (!_isCommandCompleted && bytes > 0)
                            {
                                _isCommandCompleted = true;
                                Task.Run(() => CheckReceivedCommand(command)); // Ответная квитанция на присланную команду.          
                            }
                            else
                            {
                                var commandNotComleted = GetAnswer(command, CommandNotComletedMessage);
                                _stream.Write(commandNotComleted, 0, commandNotComleted.Length);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        _stream.Close();
                        client.Close();
                    }
                }
                server.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Проверка принятой команды.
        /// </summary>
        /// <param name="command">Принятая команда.</param>
        private void CheckReceivedCommand(byte[] command)
        {
            byte commandStatus = InvalidCommandMessage;

            // Проверка заголовка команды.
            if (command[0] != CommandHeader)
            {
                commandStatus = InvalidCommandMessage;
            }
            else
            {
                // Для команд смены режима управления, начать/остановить запись потока, получить статус синхронизации.
                switch (command.Length)
                {
                    case 3:
                        // Перевод в дистанционный/местный режим управления.
                        if (command[1] == 0x1 || command[1] == 0xFF)
                        {
                            commandStatus = GetChangeModeStatus(command[1]);
                        }

                        // Запустить/Остановить запись потока.
                        if (command[1] == 0xFC || command[1] == 0xFD)
                        {
                            commandStatus = GetStartStopReceivingStatus(command[1]);
                        }

                        // Получить статус синхронизации.
                        if (command[1] == 0x03)
                        {
                            commandStatus = GetSyncStatus();
                        }

                        break;
                    case 6:
                        // Для команды установки параметров записи потока.
                        commandStatus = SetReceiveParameters(command);
                        break;
                }
            }

            _stream.Write(GetAnswer(command, commandStatus), 0, GetAnswer(command, commandStatus).Length);
            _isCommandCompleted = false;
        }

        /// <summary>
        /// Получить статус переключения на удаленный или местный режим управления.
        /// </summary>
        /// <param name="commandValue">Код команды.</param>
        /// <returns>
        /// Результат смены режима управления (Код ошибки).
        /// </returns>
        private byte GetChangeModeStatus(byte commandValue)
        {
            if (commandValue == 0x01)
            {
                // Режим местного управления.
                if (RemoteModeFlag)
                {
                    RemoteModeFlag = false;
                    if (!_isItSelfTest)
                    {
                        ThreadSafeChangeMode(1);
                    }

                }
                else
                {
                    return LocalModeMessage;
                }
            }

            else if (commandValue == 0xFF)
            {
                // Режим дистанционного управления.
                if (!RemoteModeFlag)
                {
                    RemoteModeFlag = true;
                    if (!_isItSelfTest)
                        ThreadSafeChangeMode(0);
                }
                else
                {
                    return RemoteModeMessage;
                }
            }

            return OkMessage;
        }

        /// <summary>
        /// Получить статус установки параметров приема потока.
        /// </summary>
        /// <param name="command">Принятая команда.</param>
        /// <returns>
        /// Результат установки параметров (Код ошибки).
        /// </returns>
        private byte SetReceiveParameters(byte[] command)
        {
            if (RemoteModeFlag && !ReceivingStartedFlag)
            {
                // Проверяем содержимое команды после заголовка и до резервного байта.
                for (int i = 1; i < 5; i++)
                {
                    if (command[i] == 0x1 || command[i] == 0x2)
                    {
                        continue;
                    }

                    return InvalidCommandMessage;
                }

                _setParametersFlag = true;

                if (!_isItSelfTest)
                    ThreadSafeSetReceiveParameters(command[1], command[2], command[3], command[4]);              
            }
            else if (!RemoteModeFlag)
            {
                return LocalModeMessage;
            }
            else if (ReceivingStartedFlag)
            {
                return ReceivingStartedMessage;
            }

            return OkMessage;
        }

        /// <summary>
        /// Получить статус Начала/Остановки приема потока.
        /// </summary>
        /// <param name="commandValue">Код команды.</param>
        /// <returns>
        /// Результат Начала/Остановки приема потока (Код ошибки).
        /// </returns>
        private byte GetStartStopReceivingStatus(byte commandValue)
        {
            if (commandValue == 0xFC)
            {
                // Начать запись потока.
                if (RemoteModeFlag && _setParametersFlag && !ReceivingStartedFlag)
                {
                    if (!_isItSelfTest)
                        ThreadSafeStartStopReceiving();
                    else
                        ReceivingStartedFlag = true;
                }
                else if (!RemoteModeFlag)
                {
                    return LocalModeMessage;
                }
                else if (!_setParametersFlag)
                {
                    return ParametersNotSetMessage;
                }
                else if (ReceivingStartedFlag)
                {
                    return ReceivingStartedMessage;
                }
            }

            else if (commandValue == 0xFD)
            {
                // Остановить запись потока.
                if (RemoteModeFlag && ReceivingStartedFlag)
                {
                    if (!_isItSelfTest)
                        ThreadSafeStartStopReceiving();
                    else
                        ReceivingStartedFlag = false;
                }
                else if (!RemoteModeFlag)
                {
                    return LocalModeMessage;
                }
                else
                {
                    return ReceivingNotStartedMessage;
                }
            }

            return OkMessage;
        }

        /// <summary>
        /// Получить статус синхронизации.
        /// </summary>
        /// <returns>
        /// Результат запроса статуса синхронизации (Код ошибки).
        /// </returns>
        private byte GetSyncStatus()
        {
            if (!RemoteModeFlag)
            {
                return LocalModeMessage;
            }
            else if (!ReceivingStartedFlag)
            {
                return ReceivingNotStartedMessage;
            }

            return OkMessage;
        }

        /// <summary>
        /// Формирование ответной квитанции.
        /// </summary>
        /// <remarks>
        /// Структура квитанции - Значения указанные в командном сообщении,
        /// резервный байт (беру из командного сообщения), код ошибки (статус выполнения команды).
        /// </remarks>
        /// <param name="command">Принятая команда.</param>
        /// <param name="commandStatus">Статус выполнения принятой команды.</param>
        /// <returns>
        /// Ответ на принятую команду.
        /// </returns>
        private byte[] GetAnswer(byte[] command, byte commandStatus)
        {
            List<byte> answer = new List<byte>();

            // Если запрос статуса синхронизации.
            if (command[1] == 0x03)
            {
                bool[] syncsStatesValues = ThreadSafeGetSyncsStates();

                answer.AddRange(command);
                answer.Insert(2, commandStatus == OkMessage ? syncsStatesValues[0] ? (byte)0x00 : (byte)0xFF : (byte)0xFF);
                answer.Insert(3, commandStatus == OkMessage ? syncsStatesValues[1] ? (byte)0x00 : (byte)0xFF : (byte)0xFF);
            }
            else
            {
                answer.AddRange(command);
            }

            answer.Add(commandStatus);

            return answer.ToArray();
        }
    }
}
