using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ReceivingStation.Other;
using ReceivingStation.Properties;

namespace ReceivingStation.Server
{
    class ClientForSelfTest
    {
        public delegate void WriteActionsDelegate(string msg, Color color);
        public WriteActionsDelegate ThreadSafeWriteActions;

        private const byte OkMessage = 0x0; // Команда выполнена.
        private const byte InvalidCommandMessage = 0x1; // Ошибочная команда.
        private const byte ParametersNotSetMessage = 0x2; // Не установлены параметры записи потока.
        private const byte LocalModeMessage = 0x3; // КПА находится в режиме местного управления.
        private const byte RemoteModeMessage = 0x4; // КПА находится в режиме дистанционного управления.
        private const byte ReceivingStartedMessage = 0x5; // Прием потока уже начат.
        private const byte ReceivingNotStartedMessage = 0x6; // Прием потока еще не начат.
        private const byte CommandNotComletedMessage = 0x7; // Выполнение предыдущей команды не завершено.

        private byte[] _remoteModeMsg = { 0x33, 0xFF, 0x34 };
        private byte[] _localModeMsg = { 0x33, 0x01, 0x03 };
        private byte[] _setParametersMsg = { 0x33, 0x02, 0x01, 0x02, 0x02, 0x55 };
        private byte[] _startStreamRecordMsg = { 0x33, 0xFC, 0x03 };
        private byte[] _stopStreamRecordMsg = { 0x33, 0xFD, 0x03 };

        private List<byte[]> _messages = new List<byte[]>();
        private byte[] _bytes = new byte[1024];

        public ClientForSelfTest()
        {
            _messages.Add(_remoteModeMsg);
            _messages.Add(_setParametersMsg);
            _messages.Add(_startStreamRecordMsg);
            _messages.Add(_stopStreamRecordMsg);
            _messages.Add(_localModeMsg);
        }

        public void StartClient(bool isSeqTestType)
        {
            Random rand = new Random();
            List<byte> commandsNumbers = new List<byte> { 0, 1, 2, 3, 4 }; // Для того чтобы случайный перебор команд был не таким уж случайным.

            try
            {
                IPAddress ipAddress = IPAddress.Parse(Settings.Default.ipAddressLocal);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11005);

                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine(@"Socket connected to {0}", sender.RemoteEndPoint);

                    for (int i = 0; i < 5; i++)
                    {
                        if (isSeqTestType)
                        {
                            SendReceiveMsg(_messages[i], sender, i);
                            Thread.Sleep(500);
                        }
                        else
                        {
                            int temp = rand.Next(0, commandsNumbers.Count);
                            SendReceiveMsg(_messages[commandsNumbers[temp]], sender, commandsNumbers[temp]);
                            commandsNumbers.RemoveAt(temp);
                            Thread.Sleep(500);
                        }
                    }
                    

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(@"ArgumentNullException : {0}", ane);
                }
                catch (SocketException se)
                {
                    Console.WriteLine(@"SocketException : {0}", se);
                }
                catch (Exception e)
                {
                    Console.WriteLine(@"Unexpected exception : {0}", e);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private async void SendReceiveMsg(byte[] msg, Socket sender, int index)
        {
            switch (index)
            {
                case 0: await Task.Run(() => { ThreadSafeWriteActions("  Переход в дистанционное управление\n", Color.White); }); break;
                case 1: await Task.Run(() => { ThreadSafeWriteActions("  Установка параметров записи потока\n", Color.White); }); break;
                case 2: await Task.Run(() => { ThreadSafeWriteActions("  Запуск записи потока\n", Color.White); }); break;
                case 3: await Task.Run(() => { ThreadSafeWriteActions("  Остановка записи потока\n", Color.White); }); break;
                case 4: await Task.Run(() => { ThreadSafeWriteActions("  Переход в местное управление\n", Color.White); }); break;
            }

            int bytesSent = sender.Send(msg);
            await Task.Run(() =>
            {
                ThreadSafeWriteActions($"  Командное слово: {BitConverter.ToString(msg, 0, bytesSent)}\n", Color.White);
            });

            int bytesRec = sender.Receive(_bytes);
            await Task.Run(() => { ThreadSafeWriteActions($"  Ответная квитанция: {BitConverter.ToString(_bytes, 0, bytesRec)}\n", Color.White); });

            switch (_bytes[bytesRec - 1])
            {
                case OkMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Успешное выполнение КМС\n\n", GuiUpdater.OkColor); });
                    break;
                case InvalidCommandMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Ошибочное КМС\n\n", GuiUpdater.ErrorColor); });
                    break;
                case ParametersNotSetMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Не установлены параметры записи потока.\n\n", GuiUpdater.ErrorColor); });
                    break;
                case LocalModeMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  КПА находится в режиме МУ\n\n", GuiUpdater.ErrorColor); });
                    break;
                case RemoteModeMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  КПА находится в режиме ДУ\n\n", GuiUpdater.ErrorColor); });
                    break;
                case ReceivingStartedMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Запись потока уже начата\n\n", GuiUpdater.ErrorColor); });
                    break;
                case ReceivingNotStartedMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Запись потока еще не начата\n\n", GuiUpdater.ErrorColor); });
                    break;
                case CommandNotComletedMessage:
                    await Task.Run(() => { ThreadSafeWriteActions("  Выполнение предыдущей команды не завершено\n\n", GuiUpdater.ErrorColor); });
                    break;
            }
        }
    }
}
