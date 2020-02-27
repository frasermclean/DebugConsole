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
        private int port;
        private Thread thread;

        public Listener(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(WorkerMethod));
                thread.Start();
                RaiseEvent("Listener thread created.");
            }
        }

        void WorkerMethod()
        {
            // create udp client for reading incoming data
            UdpClient client = new UdpClient(port);

            // remote end point to record ip address and port number of sender
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            RaiseEvent("Worker thread running.");

            try
            {
                while (true)
                {
                    // blocks until a message returns on this socket from a remote host.
                    byte[] receiveBytes = client.Receive(ref remoteEndPoint);

                    // decode string
                    string receivedString = Encoding.ASCII.GetString(receiveBytes);

                    // parse received strings looking for messages
                    foreach (string jsonString in GetJsonStrings(receivedString))
                    {
                        Message receivedMessage = Message.DecodeFromJson(jsonString);
                        if (receivedMessage != null)
                            RaiseEvent(receivedMessage);
                    }
                }
            }
            catch (Exception e)
            {
                RaiseEvent("Exception occured: " + e.Message);
            }
        }

        #region Events
        public event EventHandler<GeneralEventArgs> GeneralEventHandler;

        /// <summary>
        /// Raises a general event
        /// </summary>
        /// <param name="message">Description of the general event</param>
        void RaiseEvent(string message)
        {
            if (GeneralEventHandler != null)
            {
                GeneralEventArgs args = new GeneralEventArgs(message);
                GeneralEventHandler(this, args);
            }
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceivedHandler;

        /// <summary>
        /// Raises a message received event
        /// </summary>
        /// <param name="message">The message that was received.</param>
        void RaiseEvent(Message message)
        {
            if (MessageReceivedHandler != null)
            {
                MessageReceivedEventArgs args = new MessageReceivedEventArgs(message);
                MessageReceivedHandler(this, args);
            }
        }
        #endregion

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

    public class MessageReceivedEventArgs : EventArgs
    {
        public Message Message { get; set; }
        public DateTime TimeReceived { get; set; }

        public MessageReceivedEventArgs(Message message)
        {
            this.Message = message;
            this.TimeReceived = DateTime.Now;
        }
    }

    public class GeneralEventArgs : EventArgs
    {
        public string Message { get; set; }

        public GeneralEventArgs(string message)
        {
            Message = message;
        }
    }
}
