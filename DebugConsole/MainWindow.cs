using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class MainWindow : Form
    {
        private Listener listener;
        private List<Message> messages;

        private delegate void SetTextDelegate(string text);

        public MainWindow()
        {
            InitializeComponent();

            messages = new List<Message>();

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
                    StatusTextSet("Listener exception occured: " + e.Message);
                    break;
            }
        }

        private void Listener_MessageReceivedHandler(object sender, MessageReceivedEventArgs e)
        {
            TextBoxAppend(e.Message);
            StatusTextSet("Last message received at: " + e.TimeReceived.ToLongTimeString());
        }
        #endregion

        #region Text box
        private delegate void TextBoxAppendDelegate(Message message);

        private void TextBoxAppend(Message message)
        {
            if (richTextBoxMain.InvokeRequired)
            {
                var d = new TextBoxAppendDelegate(TextBoxAppend);
                richTextBoxMain.Invoke(d, new object[] { message });
            }
            else
            {
                string text = string.Format("[{0}] {1}", message.ComponentName, message.MessageText);

                if (richTextBoxMain.Text == string.Empty)
                    richTextBoxMain.Text = text;
                else
                    richTextBoxMain.Text += "\n" + text;
            }
        }

        private void TextBoxRefresh()
        {
            richTextBoxMain.Text = string.Empty;
            foreach (Message message in messages)
                TextBoxAppend(message);
        }

        private void TextBoxClear()
        {
            messages = new List<Message>();
            TextBoxRefresh();
        }

        private void TextboxTextChangedHandler(object sender, EventArgs e)
        {
            // automatically scroll to the end
            richTextBoxMain.SelectionStart = richTextBoxMain.Text.Length;
            richTextBoxMain.ScrollToCaret();
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TextBoxClear();
            StatusTextSet("Messages cleared.");
        }
    }
}
