using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace DebugConsole
{
    class Listener
    {
        public const int PortDefault = 5000;
        const int BufferSize = 4096;

        public Listener(int port)
        {
            TcpListener server = null;
            try
            {                
                IPAddress allInterfaces = IPAddress.Any;

                // start listening for client requests.
                server = new TcpListener(allInterfaces, port);
                server.Start();

                // buffer for storing incoming data
                byte[] receiveBuffer = new byte[BufferSize];

                // main loop
                while (true)
                {
                    Console.WriteLine("Listening for incoming connections on port: " + port);
                    TcpClient client = server.AcceptTcpClient(); // blocking call
                    Console.WriteLine("Accepted connection from: " + client.Client.RemoteEndPoint.ToString());

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(receiveBuffer, 0, receiveBuffer.Length)) != 0)
                    {
                        // get received string
                        string receivedString = System.Text.Encoding.ASCII.GetString(receiveBuffer, 0, i).Trim();
                        //Console.WriteLine(receivedString);

                        foreach (string jsonString in GetJsonStrings(receivedString))
                        {
                            Message receivedMessage = Message.DecodeFromJson(jsonString);
                            if (receivedMessage != null)
                            {
                                // set foreground colour based on message type
                                switch (receivedMessage.MessageType)
                                {
                                    case MessageType.None: Console.ForegroundColor = ConsoleColor.White; break;
                                    case MessageType.Info: Console.ForegroundColor = ConsoleColor.Green; break;
                                    case MessageType.Warning: Console.ForegroundColor = ConsoleColor.Yellow; break;
                                    case MessageType.Error: Console.ForegroundColor = ConsoleColor.Red; break;
                                    case MessageType.Exception: Console.ForegroundColor = ConsoleColor.Magenta; break;
                                }

                                Console.WriteLine("[{0}] {1}", receivedMessage.ComponentName, receivedMessage.MessageText);
                                Console.ForegroundColor = ConsoleColor.White; // reset foreground color to default
                            }
                        }

                        //// generate response
                        //DebugConsoleMessage responseMessage = new DebugConsoleMessage(MessageType.None, "DebugConsole", "OK");
                        //string responseString = DebugConsoleMessage.EncodeToJson(responseMessage);

                        //byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(responseString);
                        //stream.Write(responseBytes, 0, responseBytes.Length);
                        //Console.WriteLine("Sent: {0}", responseString);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        List<string> GetJsonStrings(string receivedString)
        {
            if (receivedString == null)
                return null;

            List<string> list = new List<string>();

            int startPos, endPos;
            startPos = 0;
            while(startPos < receivedString.Length)
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
                //Console.WriteLine("GetJsonStrings() StartPos: {0}, EndPos: {1}, Length: {2}", startPos, endPos, length);
                string jsonString = receivedString.Substring(startPos, length);
                list.Add(jsonString);
                startPos = endPos + 1;
            }

            return list;
        }
    }
}
