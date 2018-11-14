using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ReceivingStation.Properties;

namespace ReceivingStation.Server
{
    class Server
    {
        public delegate void ChangeModeDelegate(byte modeNumber);
        public ChangeModeDelegate ThreadSafeChangeMode;
        public delegate void SetParametersDelegate(byte fcp, byte prd, byte freq, byte interliving);
        public SetParametersDelegate ThreadSafeSetReceiveParameters;
        public delegate void StartReceivingDelegate();
        public StartReceivingDelegate ThreadSafeStartReceiving;
        public delegate void StopReceivingDelegate();
        public StopReceivingDelegate ThreadSafeStopReceiving;

        private FormReceive _form;
        public bool _stopThread;

        private const byte OkMessage = 0x0; // Команда выполнена.
        private const byte InvalidCommandMessage = 0x1; // Ошибочная команда.
        private const byte ParametersNotSetMessage = 0x2; // Не установлены параметры записи потока.
        private const byte LocalModeMessage = 0x3; // КПА находится в режиме местного управления.
        private const byte RemoteModeMessage = 0x4; // КПА находится в режиме дистанционного управления.
        private const byte ReceivingStartedMessage = 0x5; // Прием потока уже начата.
        private const byte ReceivingNotStartedMessage = 0x6; // Прием потока еще не начата.
       
        private bool _remoteControlFlag; // Включен ли удаленный режим управления.
        private bool _setParametersFlag; // Установлены ли параметры приема.
        private bool _receivingStartedFlag; // Начат ли прием потока.
       
        public Server(FormReceive form)
        {
            _form = form;
            _stopThread = false;
        }

        #region Запустить работу сервера.

        public void StartServer()
        {
            TcpListener server;
            TcpClient client;
            NetworkStream stream;

            int bytes; // Количество полученных байт.
            byte[] data = new byte[256];  // Буфер для получаемых команд.           
            byte[] result = new byte[256]; // Ответная квитанция на присланную команду.

            try
            {
                server = new TcpListener(IPAddress.Parse("0.0.0.0"), 11005);
                _setParametersFlag = false;
                _receivingStartedFlag = false;

                while (_stopThread == false)
                {
                    // Перевод в местный режим управления.
                    _form.Invoke(new Action(() => { ThreadSafeChangeMode(1); }));
                    _remoteControlFlag = false;

                    server.Start();

                    client = server.AcceptTcpClient();
                    if (((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() != Settings.Default.ipAddressIVK)
                    {
                        client.Close();
                        continue;
                    }
                    server.Stop(); // Больше не ждем подключений.  
                    stream = client.GetStream();

                    try
                    {
                        while (true)
                        {
                            bytes = stream.Read(data, 0 , data.Length);
                            result = CheckReceivedData(data, bytes);
                            stream.Write(result, 0, result.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        stream.Close();
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

        private byte[] CheckReceivedData(byte[] data, int commandBytesQuantity)
        {
            byte[] command = new byte [commandBytesQuantity];
            byte commandHeader = 0x33;
            byte commandStatus = InvalidCommandMessage;

            // Извлечение команды из массива data.
            for (int i = 0; i < commandBytesQuantity; i++)
            {
                command[i] = data[i];
            }
        
            // Проверка заголовка команды.
            if (command[0] != commandHeader)
            {
                commandStatus = InvalidCommandMessage;

                return GetAnswer(command, commandStatus);
            }

            // Для команд смены режима управления, начать/остановить запись потока, получить статус синхронизации.
            if (commandBytesQuantity == 3)
            {
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
            }

            // Для команды установки параметров записи потока.
            if (commandBytesQuantity == 6)
            {
                commandStatus = SetReceiveParameters(command);               
            }

            return GetAnswer(command, commandStatus);
        }

        #endregion

        #region Получить статус переключения на удаленный или местный режим управления.
        private byte GetChangeModeStatus(byte commandValue)
        {
            if (commandValue == 0x01)
            {
                // Режим местного управления.
                if (_remoteControlFlag)
                {
                    _remoteControlFlag = false;
                    _form.Invoke(new Action(() => { ThreadSafeChangeMode(1); }));
                }
                else
                {
                    return LocalModeMessage;
                }
            }

            else if (commandValue == 0xFF)
            {
                // Режим дистанционного управления.
                if (!_remoteControlFlag)
                {
                    _remoteControlFlag = true;
                    _form.Invoke(new Action(() => { ThreadSafeChangeMode(0); }));
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
            if (_remoteControlFlag)
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
                _form.Invoke(new Action(() => { ThreadSafeSetReceiveParameters(command[1], command[2], command[3], command[4]); }));

                return OkMessage;
            }

            return LocalModeMessage;
        }

        #endregion

        #region Получить статус Начала/Остановки приема потока.
        private byte GetStartStopReceivingStatus(byte command)
        {
            if (command == 0xFC)
            {
                // Начать запись потока.
                if (_setParametersFlag && !_receivingStartedFlag)
                {
                    _receivingStartedFlag = true;
                    _form.Invoke(new Action(() => { ThreadSafeStartReceiving(); }));
                }
                else if (_receivingStartedFlag)
                {
                    return ReceivingStartedMessage;
                }
                else
                {
                    return ParametersNotSetMessage;
                }
            }

            else if (command == 0xFD)
            {
                // Остановить запись потока.
                if (_receivingStartedFlag)
                {
                    _receivingStartedFlag = false;
                    _form.Invoke(new Action(() => { ThreadSafeStopReceiving(); }));
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
