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

            // create new listener object
            listener = new Listener(Listener.PortDefault);
            listener.GeneralEventHandler += Listener_GeneralEventHandler;
            listener.MessageReceivedHandler += Listener_MessageReceivedHandler;
        }

        private void textPortNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void labelPortNumber_Click(object sender, EventArgs e)
        {
        }

        private void buttonStartListening_Click(object sender, EventArgs e)
        {
            listener.Start();
        }

        #region Listener callbacks
        private void Listener_GeneralEventHandler(object sender, GeneralEventArgs e)
        {
            TextBoxAppend(e.Message);
        }

        private void Listener_MessageReceivedHandler(object sender, MessageReceivedEventArgs e)
        {
            string text = String.Format("[{0}] {1}", e.Message.ComponentName, e.Message.MessageText);
            TextBoxAppend(text);
        }
        #endregion

        #region Text box
        private delegate void TextBoxAppendDelegate(string text);

        private void TextBoxAppend(string text)
        {
            if (richTextBoxMain.InvokeRequired)
            {
                var d = new TextBoxAppendDelegate(TextBoxAppend);
                richTextBoxMain.Invoke(d, new object[] { text });
            }
            else
            {
                if (richTextBoxMain.Text == String.Empty)
                    richTextBoxMain.Text = text;
                else
                    richTextBoxMain.Text += "\n" + text;
            }
        }
        #endregion
    }
}
