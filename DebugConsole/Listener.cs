using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace DebugConsole
{
    public class Listener
    {
        public const int PortDefault = 64000;
        private Thread thread;
        private UdpClient client;

        public bool IsActive
        {
            get { return client != null; }
        }

        public int Port { get; }

        public Listener(int port)
        {
            Port = port;
        }

        public void Start()
        {
            if (client == null)
            {
                // create udp client for reading incoming data
                client = new UdpClient(Port);

                // start worker thread
                thread = new Thread(new ThreadStart(WorkerMethod));
                thread.Start();

                RaiseEvent(GeneralEvent.ActiveStateUpdated, "Listener thread created.");
            }
        }

        public void Stop()
        {
            if (client != null)
            {
                // kill thread
                thread.Abort();
                thread = null;

                // close client
                client.Close();
                client.Dispose();
                client = null;

                RaiseEvent(GeneralEvent.ActiveStateUpdated, "UDP client disposed.");
            }
        }

        void WorkerMethod()
        {
            // remote end point to record ip address and port number of sender
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

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
            catch (ThreadAbortException)
            { }
            catch (Exception e)
            {
                RaiseEvent(GeneralEvent.ExceptionOccured, e.Message);

                if (IsActive)
                    Stop();
            }
        }

        #region Events
        public event EventHandler<GeneralEventArgs> GeneralEventHandler;

        /// <summary>
        /// Raises a general event
        /// </summary>
        /// <param name="eventType">The type of event to raise</param>
        void RaiseEvent(GeneralEvent eventType)
        {
            RaiseEvent(eventType, string.Empty);
        }

        /// <summary>
        /// Raises a general event
        /// </summary>
        /// <param name="eventType">The type of event to raise</param>
        /// <param name="message">Description of the general event</param>
        void RaiseEvent(GeneralEvent eventType, string message)
        {
            if (GeneralEventHandler != null)
            {
                GeneralEventArgs args = new GeneralEventArgs(eventType, message);
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
        public GeneralEvent GeneralEvent { get; set; }
        public string Message { get; set; }

        public GeneralEventArgs(GeneralEvent generalEvent, string message)
        {
            GeneralEvent = generalEvent;
            Message = message;
        }
    }
    public enum GeneralEvent
    {
        ActiveStateUpdated,
        ExceptionOccured,
    }
}
