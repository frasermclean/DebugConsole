using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugConsole
{
    class Settings
    {
        public int ListeningPortNumber { get; set; }

        public Settings()
        {
            ListeningPortNumber = Listener.PortDefault;
        }
    }
}
