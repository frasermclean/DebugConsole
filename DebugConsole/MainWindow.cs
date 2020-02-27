using System;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class MainWindow : Form
    {
        Listener listener;

        private delegate void SetTextDelegate(string text);

        public MainWindow()
        {
            InitializeComponent();

            // create new listener object
            listener = new Listener(Listener.PortDefault);
            listener.GeneralEventHandler += Listener_GeneralEventHandler;
            listener.MessageReceivedHandler += Listener_MessageReceivedHandler;
            listener.Start();
        }

        #region Listener callbacks
        private void Listener_GeneralEventHandler(object sender, GeneralEventArgs e)
        {
            switch (e.GeneralEvent)
            {
                case GeneralEvent.ActiveStateUpdated:
                    if (listener.IsActive)
                    {
                        StatusTextSet("Listener active on port: " + listener.Port);
                        ToggleListeningButtonSetText("Stop Listening");
                    }
                    else
                    {
                        StatusTextSet("Not listening for incoming messages.");
                        ToggleListeningButtonSetText("Start Listening");
                    }
                    break;
                case GeneralEvent.ExceptionOccured:
                    TextBoxAppend("Listener exception occured: " + e.Message);
                    break;
            }
        }

        private void Listener_MessageReceivedHandler(object sender, MessageReceivedEventArgs e)
        {
            string text = String.Format("[{0}] {1}", e.Message.ComponentName, e.Message.MessageText);
            TextBoxAppend(text);
        }
        #endregion

        #region Text box
        private void TextBoxAppend(string text)
        {
            if (richTextBoxMain.InvokeRequired)
            {
                var d = new SetTextDelegate(TextBoxAppend);
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

        #region Status text
        void StatusTextSet(string text)
        {
            if (labelStatusText.InvokeRequired)
            {
                var d = new SetTextDelegate(StatusTextSet);
                labelStatusText.Invoke(d, new object[] { text });
            }
            else
            {
                labelStatusText.Text = text;
            }
        }
        #endregion

        #region Toggle listening button
        private void ToggleListeningButtonSetText(string text)
        {
            if (buttonToggleListening.InvokeRequired)
            {
                var d = new SetTextDelegate(ToggleListeningButtonSetText);
                buttonToggleListening.Invoke(d, new object[] { text });
            }
            else
            {
                buttonToggleListening.Text = text;
            }
        }
        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
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
