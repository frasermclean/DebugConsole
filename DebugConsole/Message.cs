using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DebugConsole
{
    public class Message
    {
        public string ProgramName { get; private set; }
        public int ProgramNumber { get; private set; }
        public MessageType MessageType { get; set; }
        public string ComponentName { get; set; }
        public string MessageText { get; set; }

        public Message(MessageType messageType, string componentName, string messageText)
        {
            Initialize(String.Empty, 0, messageType, componentName, messageText);
        }

        public Message(string programName, int programNumber, MessageType messageType, string componentName, string messageText)
        {
            Initialize(programName, programNumber, messageType, componentName, messageText);
        }

        private void Initialize(string programName, int programNumber, MessageType messageType, string componentName, string messageText)
        {
            ProgramName = programName;
            ProgramNumber = programNumber;
            MessageType = messageType;
            ComponentName = componentName;
            MessageText = messageText;
        }

        /// <summary>
        /// Encode a DebugConsoleMessage object into a JSON formatted string.
        /// </summary>
        /// <param name="dcm">The object to convert.</param>
        /// <returns>The JSON formatted string.</returns>
        public static string EncodeToJson(Message dcm)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(dcm);
                return jsonString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DebugConsoleMessage.EncodeToJson() exception caught: " + ex.Message);
                return String.Empty;
            }
        }

        /// <summary>
        /// Decode a JSON formatted string into a DebugConsoleMessage object.
        /// </summary>
        /// <param name="jsonString">The JSON formatted string to decode.</param>
        /// <returns>The decode DebugConsoleMessage object.</returns>
        public static Message DecodeFromJson(string jsonString)
        {
            try
            {
                JObject obj = (JObject)JsonConvert.DeserializeObject(jsonString);

                // program name
                var programName = string.Empty;
                var programNameToken = obj.SelectToken("ProgramName");
                if (programNameToken != null)
                    programName = (string)programNameToken;

                // program number
                int programNumber = 0;
                var programNumberToken = obj.SelectToken("ProgramNumber");
                if (programNumberToken != null)
                    programNumber = (int)programNumberToken;

                // message type
                var messageTypeInt = (int)obj.SelectToken("MessageType");
                MessageType messageType = (MessageType)messageTypeInt;

                // component name
                var componentName = (string)obj.SelectToken("ComponentName");

                // message text
                var messageText = (string)obj.SelectToken("MessageText");

                // return new message object
                return new Message(programName, programNumber, messageType, componentName, messageText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DebugConsoleMessage.DecodeFromJson() exception caught: " + ex.Message);
                return null;
            }
        }
    }

    public enum MessageType
    {
        None,
        Info,
        Warning,
        Error,
        Exception,
        Raw,
    }
}
