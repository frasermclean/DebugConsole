using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DebugConsole
{
    public class Settings
    {
        const string FileName = "Settings.json";
        const string Subdirectory = "DebugConsole";

        private string directoryPath;
        private string filePath;

        public event EventHandler<SettingsEventArgs> EventHandler;

        #region Properties
        public int ListeningPortNumber { get; set; }
        public Font Font { get; set; }

        // colors
        public Color BackgroundColor { get; set; }
        public Color NormalTextColor { get; set; }
        public Color InfoTextColor { get; set; }
        public Color WarningTextColor { get; set; }
        public Color ErrorTextColor { get; set; }
        #endregion

        public Settings()
        {
            CreatePaths();

            // set defaults
            ListeningPortNumber = Listener.PortDefault;
            Font = new Font("Segoe UI", 9.0f);
            BackgroundColor = Color.Black;
            NormalTextColor = Color.Silver;
            InfoTextColor = Color.DodgerBlue;
            WarningTextColor = Color.Gold;
            ErrorTextColor = Color.Red;
        }

        public bool Save()
        {
            try
            {
                // serializer settings
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                // font object
                JObject fontObject = new JObject
                {
                    ["Family"] = Font.FontFamily.Name,
                    ["Size"] = Font.Size
                };

                // color objects
                JObject backgroundColorObject = ConvertColor(BackgroundColor);
                JObject normalTextColorObject = ConvertColor(NormalTextColor);
                JObject infoTextColorObject = ConvertColor(InfoTextColor);
                JObject warningTextColorObject = ConvertColor(WarningTextColor);
                JObject errorTextColorObject = ConvertColor(ErrorTextColor);

                // root object
                JObject rootObject = new JObject
                {
                    ["ListeningPortNumber"] = ListeningPortNumber,
                    ["Font"] = fontObject,
                    ["BackgroundColor"] = backgroundColorObject,
                    ["NormalTextColor"] = normalTextColorObject,
                    ["InfoTextColor"] = infoTextColorObject,
                    ["WarningTextColor"] = warningTextColorObject,
                    ["ErrorTextColor"] = errorTextColorObject,
                };
                
                string jsonString = JsonConvert.SerializeObject(rootObject, settings); // serialize root object
                Directory.CreateDirectory(directoryPath); // make directory if it does not exist
                File.WriteAllText(filePath, jsonString); // write file

                return true;
            }
            catch (Exception e)
            {
                RaiseEvent("Save() exception occured: " + e.Message);
                return false;
            }
        }

        public bool Load()
        {
            try
            {
                string jsonString = File.ReadAllText(filePath); // read settings file into string
                var obj = (JObject)JsonConvert.DeserializeObject(jsonString);

                // parse json
                ListeningPortNumber = (int)obj.SelectToken("ListeningPortNumber");
                Font = ConvertFont((JObject)obj.SelectToken("Font"));
                BackgroundColor = ConvertColor((JObject)obj.SelectToken("BackgroundColor"));
                NormalTextColor = ConvertColor((JObject)obj.SelectToken("NormalTextColor"));
                InfoTextColor = ConvertColor((JObject)obj.SelectToken("InfoTextColor"));
                WarningTextColor = ConvertColor((JObject)obj.SelectToken("WarningTextColor"));
                ErrorTextColor = ConvertColor((JObject)obj.SelectToken("ErrorTextColor"));

                return true;
            }
            catch (Exception e)
            {
                RaiseEvent("Load() exception occured: " + e.Message);
                return false;
            }
        }

        private void CreatePaths()
        {
            directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + Subdirectory;
            filePath = directoryPath + Path.DirectorySeparatorChar + FileName;
        }

        JObject ConvertColor(Color color)
        {
            try
            {
                JObject obj = new JObject
                {
                    ["R"] = color.R,
                    ["G"] = color.G,
                    ["B"] = color.B
                };

                return obj;
            }
            catch (Exception e)
            {
                RaiseEvent("ConverColor() exception occured: " + e.Message);
                return null;
            }
        }

        Color ConvertColor(JObject jObject)
        {
            try
            {
                var r = (int)jObject.SelectToken("R");
                var g = (int)jObject.SelectToken("G");
                var b = (int)jObject.SelectToken("B");

                return Color.FromArgb(r, g, b);
            }
            catch (Exception e)
            {
                RaiseEvent("ConverColor() exception occured: " + e.Message);
                return Color.Black;
            }
        }

        Font ConvertFont(JObject jObject)
        {
            try
            {
                var family = (string)jObject.SelectToken("Family");
                var size = (float)jObject.SelectToken("Size");

                return new Font(family, size);
            }
            catch (Exception e)
            {
                RaiseEvent("ConvertFont() exception occured: " + e.Message);
                return new Font("Segoe UI", 9.0f);
            }
        }

        void RaiseEvent(string message)
        {
            if (EventHandler != null)
            {
                SettingsEventArgs args = new SettingsEventArgs(message);
                EventHandler(this, args);
            }
        }
    }

    public class SettingsEventArgs : EventArgs
    {
        public string Message { get; set; }

        public SettingsEventArgs(string message)
        {
            Message = message;
        }
    }
}
