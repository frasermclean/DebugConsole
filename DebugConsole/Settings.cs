using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DebugConsole
{
    public class Settings
    {
        public int ListeningPortNumber { get; set; }
        public Font Font { get; set; }

        // colors
        public Color BackgroundColor { get; set; }
        public Color NormalTextColor { get; set; }
        public Color InfoTextColor { get; set; }
        public Color WarningTextColor { get; set; }
        public Color ErrorTextColor { get; set; }

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
            return false;
        }
    }
}
