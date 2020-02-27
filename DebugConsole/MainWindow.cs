using System;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class MainWindow : Form
    {
        Listener listener;

        public MainWindow()
        {
            InitializeComponent();

            // create new listener object
            listener = new Listener(Listener.PortDefault);
            listener.GeneralEventHandler += Listener_GeneralEventHandler;
            listener.MessageReceivedHandler += Listener_MessageReceivedHandler;
        }

        #region Listener callbacks
        private void Listener_GeneralEventHandler(object sender, GeneralEventArgs e)
        {
            if (listener.IsActive)
                labelStatusText.Text = "Listener active on port: " + listener.Port;
            else
                labelStatusText.Text = "Not listening for incoming messages.";

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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            labelStatusText.Text = "Main Window Loaded";
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog(this);
        }

        private void buttonToggleListening_Click(object sender, EventArgs e)
        {
            if (listener.IsActive)
                listener.Stop();
            else
                listener.Start();
        }
    }
}
