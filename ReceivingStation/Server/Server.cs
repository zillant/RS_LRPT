using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ReceivingStation.Properties;

namespace ReceivingStation.Server
{
    class Server
    {
        public delegate void ChangeModeDelegate(byte modeNumber);
        public ChangeModeDelegate ThreadSafeChangeMode;
        public delegate void SetParametersDelegate(byte fcp, byte prd, byte freq, byte interliving);
        public SetParametersDelegate ThreadSafeSetReceiveParameters;
        public delegate void StartStopReceivingDelegate();
        public StartStopReceivingDelegate ThreadSafeStartStopReceiving;

        public bool StopThread;
       
        public static bool RemoteModeFlag;

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
        private bool _receivingStartedFlag; // Начат ли прием потока.
        private bool _isCommandCompleted; // Проверка, выполнена ли принятая команда.
        private NetworkStream _stream;

        private bool _isItSelfTest; // Флаг, является ли это процессом самотестирования. Нужно чтоб не привязывать делегаты к форме самотестирования.

        public Server(bool isItSelfTest)
        {
            StopThread = false;
            _isItSelfTest = isItSelfTest;
            _isCommandCompleted = false;
        }

        #region Запустить работу сервера.

        public void StartServer()
        {
            byte[] data = new byte[256];  // Буфер для получаемых команд.           

            List<string> ipList = new List<string> { Settings.Default.ipAddressIVK, Settings.Default.ipAddressLocal };

            try
            {
                var server = new TcpListener(IPAddress.Parse("0.0.0.0"), 11005);

                _setParametersFlag = false;
                _receivingStartedFlag = false;

                while (StopThread == false)
                {
                    // Перевод в местный режим управления.                 
                    if (!_isItSelfTest)
                        ThreadSafeChangeMode(1);
                    else
                    {
                        _setParametersFlag = false;
                        _receivingStartedFlag = false;
                    }

                    RemoteModeFlag = false;

                    server.Start();

                    var client = server.AcceptTcpClient();

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

        #endregion

        #region Проверка принятой команды.

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

        #endregion

        #region Получить статус переключения на удаленный или местный режим управления.
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

        #endregion

        #region Получить статус установки параметров приема потока.
        private byte SetReceiveParameters(byte[] command)
        {
            if (RemoteModeFlag && !_receivingStartedFlag)
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
            else if (_receivingStartedFlag)
            {
                return ReceivingStartedMessage;
            }

            return OkMessage;
        }

        #endregion

        #region Получить статус Начала/Остановки приема потока.
        private byte GetStartStopReceivingStatus(byte command)
        {
            if (command == 0xFC)
            {
                // Начать запись потока.
                if (RemoteModeFlag && _setParametersFlag && !_receivingStartedFlag)
                {
                    _receivingStartedFlag = true;

                    if (!_isItSelfTest)
                        ThreadSafeStartStopReceiving();
                }
                else if (!RemoteModeFlag)
                {
                    return LocalModeMessage;
                }
                else if (!_setParametersFlag)
                {
                    return ParametersNotSetMessage;
                }
                else if (_receivingStartedFlag)
                {
                    return ReceivingStartedMessage;
                }
            }

            else if (command == 0xFD)
            {
                // Остановить запись потока.
                if (RemoteModeFlag && _receivingStartedFlag)
                {
                    _receivingStartedFlag = false;
                    if (!_isItSelfTest)
                        ThreadSafeStartStopReceiving();
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

        #endregion

        #region Получить статус синхронизации.
        private byte GetSyncStatus()
        {
            if (_receivingStartedFlag)
            {
                return OkMessage;
            }

            return ReceivingNotStartedMessage;
        }

        #endregion

        #region Формирование ответной квитанции.
        private byte[] GetAnswer(byte[] command, byte commandStatus)
        {
            // Структура квитанции - Значения указанные в командном сообщении,
            // резервный байт (беру из командного сообщения), код ошибки (статус выполнения команды).

            List<byte> answer = new List<byte>();

            // Если запрос статуса синхронизации.
            if (command[1] == 0x03)
            {
                answer = GetSyncStatusFromThread();
                answer.Insert(0, 0x33);
            }
            else
            {
                answer.AddRange(command);
            }

            answer.Add(commandStatus);

            return answer.ToArray();
        }

        #endregion

        private List<byte> GetSyncStatusFromThread()
        {
            // Создать метод в Form1 который отдает значения синхронизации. 
            // Ильшату из своего потока обновлять не только лейбл но и эти значения.

            // Или забирать у Ильшата геттер этих переменных и вывести сюда.
            throw new NotImplementedException();
        }
    }
}
