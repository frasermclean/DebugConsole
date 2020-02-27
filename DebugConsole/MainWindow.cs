using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class MainWindow : Form
    {
        Listener listener;

        public MainWindow()
        {
            InitializeComponent();

            // set default values
            textPortNumber.Text = Listener.PortDefault.ToString();
        }

        private void textPortNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPortNumber_Click(object sender, EventArgs e)
        {

        }

        private void buttonStartListening_Click(object sender, EventArgs e)
        {
            // create new listener object
            listener = new Listener(Listener.PortDefault);
            listener.MessageReceivedHandler += Listener_MessageReceivedHandler;
        }

        private void Listener_MessageReceivedHandler(object sender, MessageReceivedEventArgs e)
        {
            string lineText = String.Format("[{0}] {1}", e.Message.ComponentName, e.Message.MessageText);
            if (richTextBoxMain.Text == String.Empty)
                richTextBoxMain.Text = lineText;
            else
                richTextBoxMain.Text += "\n" + lineText;
        }
    }
}
