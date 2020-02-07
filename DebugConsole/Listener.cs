using System;
using System.Net;
using System.Net.Sockets;

namespace DebugConsole
{
    class Listener
    {
        public const int PortDefault = 5000;

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
                byte[] bytes = new byte[256];

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
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // get received string
                        string receivedString = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Trim();
                        if (receivedString.Trim().Length == 0)
                            continue;
                        Console.WriteLine("Received {0} bytes: \"{1}\"", i, receivedString);

                        // generate response
                        DebugMessage responseMessage = new DebugMessage(0, "OK");
                        string responseString = responseMessage.EncodeToJson();
                        responseString =  responseString + "\r\n"; // append carriage return and newline
                        
                        byte[] responseBytes = System.Text.Encoding.ASCII.GetBytes(responseString);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        Console.WriteLine("Sent: {0}", responseString);
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
    }
}
