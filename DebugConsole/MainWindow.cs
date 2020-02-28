using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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

            MessagesReset();

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
                richTextBoxMain.DeselectAll();

                // append newline if needed
                if (!string.IsNullOrEmpty(richTextBoxMain.Text))
                    richTextBoxMain.AppendText(Environment.NewLine);

                // specify color based on message type
                switch (message.MessageType)
                {
                    case MessageType.None: richTextBoxMain.SelectionColor = Color.LightGray; break;
                    case MessageType.Info: richTextBoxMain.SelectionColor = Color.Green; break;
                    case MessageType.Warning: richTextBoxMain.SelectionColor = Color.Yellow; break;
                    case MessageType.Error: richTextBoxMain.SelectionColor = Color.Red; break;
                    case MessageType.Exception: richTextBoxMain.SelectionColor = Color.Magenta; break;
                }

                // component name
                richTextBoxMain.SelectionFont = new Font(richTextBoxMain.SelectionFont, FontStyle.Bold);
                richTextBoxMain.AppendText(string.Format("[{0}] ", message.ComponentName));

                // message text
                richTextBoxMain.SelectionFont = new Font(richTextBoxMain.SelectionFont, FontStyle.Regular);
                richTextBoxMain.AppendText(string.Format("{0}", message.MessageText));
            }
        }

        private void TextBoxRefresh()
        {
            richTextBoxMain.Text = string.Empty;
            foreach (Message message in messages)
                TextBoxAppend(message);
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

        private void MessagesReset()
        {
            messages = new List<Message>();
            TextBoxRefresh();
        }

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
            MessagesReset();
            StatusTextSet("Messages cleared.");
        }
    }
}
