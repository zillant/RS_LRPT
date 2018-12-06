using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ReceivingStation
{
    class ClientForSelfTest
    {
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
                        SendReceiveMsg(messages[i], sender);
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

        private void SendReceiveMsg(byte[] msg, Socket sender)
        {           
            int bytesSent = sender.Send(msg);

            int bytesRec = sender.Receive(_bytes);
            Console.WriteLine("Echoed test = {0}", BitConverter.ToString(_bytes, 0, bytesRec));
        }
    }
}
