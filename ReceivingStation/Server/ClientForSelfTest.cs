using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ReceivingStation
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

        private readonly byte[] remoteModeMsg = new byte[] { 0x33, 0xFF, 0x34 };
        private readonly byte[] localModeMsg = new byte[] { 0x33, 0x01, 0x03 };
        private readonly byte[] setParametersMsg = new byte[] { 0x33, 0x02, 0x01, 0x02, 0x02, 0x55 };
        private readonly byte[] startStreamRecordMsg = new byte[] { 0x33, 0xFC, 0x03 };
        private readonly byte[] stopStreamRecordMsg = new byte[] { 0x33, 0xFD, 0x03 };

        private List<byte[]> messages = new List<byte[]>();
        private byte[] _bytes = new byte[1024];

        public ClientForSelfTest()
        {
            messages.Add(remoteModeMsg);
            messages.Add(setParametersMsg);
            messages.Add(startStreamRecordMsg);
            messages.Add(stopStreamRecordMsg);
            messages.Add(localModeMsg);
        }

        public void StartClient()
        {           
            try
            {
                IPAddress ipAddress = IPAddress.Parse(Settings.Default.ipAddressLocal);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11005);

                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    for (int i = 0; i < 5; i++)
                    {
                        SendReceiveMsg(messages[i], sender, i);
                        Thread.Sleep(500);
                    }

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
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
                case 0: await Task.Run(() => { ThreadSafeWriteActions($"Переход в дистанционное управление\n", Color.Black); }); break;
                case 1: await Task.Run(() => { ThreadSafeWriteActions($"Установка параметров записи потока\n", Color.Black); }); break;
                case 2: await Task.Run(() => { ThreadSafeWriteActions($"Запуск записи потока\n", Color.Black); }); break;
                case 3: await Task.Run(() => { ThreadSafeWriteActions($"Остановка записи потока\n", Color.Black); }); break;
                case 4: await Task.Run(() => { ThreadSafeWriteActions($"Переход в местное управление\n", Color.Black); }); break;
                default: break;
            }

            int bytesSent = sender.Send(msg);
            await Task.Run(() => { ThreadSafeWriteActions($"Командное слово: {BitConverter.ToString(msg, 0, bytesSent)}\n", Color.Black); });

            int bytesRec = sender.Receive(_bytes);
            await Task.Run(() => { ThreadSafeWriteActions($"Ответная квитанция: {BitConverter.ToString(_bytes, 0, bytesRec)}\n", Color.Black); });

            switch (_bytes[bytesRec - 1])
            {
                case OkMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"Команда выполнена\n\n", GuiUpdater.okColor); });
                    break;
                case InvalidCommandMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"Ошибочная команда\n\n", GuiUpdater.errorColor); });
                    break;
                case ParametersNotSetMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"Не установлены параметры записи потока.\n\n", GuiUpdater.errorColor); });
                    break;
                case LocalModeMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"КПА находится в режиме местного управления\n\n", GuiUpdater.errorColor); });
                    break;
                case RemoteModeMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"КПА находится в режиме дистанционного управления\n\n", GuiUpdater.errorColor); });
                    break;
                case ReceivingStartedMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"Прием потока уже начат\n\n", GuiUpdater.errorColor); });
                    break;
                case ReceivingNotStartedMessage:
                    await Task.Run(() => { ThreadSafeWriteActions($"Прием потока еще не начат\n\n", GuiUpdater.errorColor); });
                    break;
                default:
                    break;
            }
        }
    }
}
