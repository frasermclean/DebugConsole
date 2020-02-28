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

        public Settings()
        {
            ListeningPortNumber = Listener.PortDefault;
            Font = new Font("Segoe UI", 9.0f);
        }
    }
}
