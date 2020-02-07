using System;
using Newtonsoft.Json;

namespace DebugConsole
{
    class DebugMessage
    {
        public int MessageType { get; set; }
        public string MessageText { get; set; }

        public DebugMessage(int messageType, string messageText)
        {
            MessageType = messageType;
            MessageText = messageText;
        }

        public string EncodeToJson()
        {
            try
            {
                string serializedMessage = JsonConvert.SerializeObject(this);
                return serializedMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EncodeToJson() exception caught: " + ex.Message);
                return String.Empty;
            }
        }
    }
}
