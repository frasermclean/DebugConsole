using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DebugConsole
{
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string ComponentName { get; set; }
        public string MessageText { get; set; }

        public Message(MessageType messageType, string componentName, string messageText)
        {
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

                // parse json
                var messageTypeInt = (int)obj.SelectToken("MessageType");
                MessageType messageType = (MessageType)messageTypeInt;
                var componentName = (string)obj.SelectToken("ComponentName");
                var messageText = (string)obj.SelectToken("MessageText");

                Message dcm = new Message(messageType, componentName, messageText);

                return dcm;
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
