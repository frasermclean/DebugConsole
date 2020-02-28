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
                // create json
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };
                string jsonString = JsonConvert.SerializeObject(this);

                // make directory if it does not exist
                string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + Subdirectory;
                Directory.CreateDirectory(directoryPath);

                // write file
                string filePath = directoryPath + Path.DirectorySeparatorChar + FileName;
                File.WriteAllText(filePath, jsonString);

                return true;
            }
            catch (Exception e)
            {
                if (EventHandler != null)
                {
                    SettingsEventArgs args = new SettingsEventArgs("Exception occured: " + e.Message);
                    EventHandler(this, args);
                }
                return false;
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
