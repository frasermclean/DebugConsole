using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace DebugConsole
{
    class Listener
    {
        public const int PortDefault = 5000;
        private readonly int port;

        public Listener(int port)
        {
            this.port = port;
            Thread thread = new Thread(new ThreadStart(WorkerMethod));
        }

        void WorkerMethod()
        {
            // create udp client for reading incoming data
            UdpClient client = new UdpClient(port);

            // remote end point to record ip address and port number of sender
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                // blocks until a message returns on this socket from a remote host.
                byte[] receiveBytes = client.Receive(ref remoteEndPoint);

                string returnData = Encoding.ASCII.GetString(receiveBytes);
            }
            catch (Exception e)
            {
            }
        }

        List<string> GetJsonStrings(string receivedString)
        {
            if (receivedString == null)
                return null;

            List<string> list = new List<string>();

            int startPos, endPos;
            startPos = 0;
            while (startPos < receivedString.Length)
            {
                startPos = receivedString.IndexOf("{", startPos);
                endPos = receivedString.IndexOf("}", startPos + 1);
                if (startPos < 0 || endPos < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("GetJsonStrings() processing error.");
                    break;
                }
                int length = endPos - startPos + 1;
                string jsonString = receivedString.Substring(startPos, length);
                list.Add(jsonString);
                startPos = endPos + 1;
            }

            return list;
        }
    }
}
