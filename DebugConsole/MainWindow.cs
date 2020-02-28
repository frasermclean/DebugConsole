using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace DebugConsole
{
    public partial class MainWindow : Form
    {
        private Listener listener;
        private List<Message> messages;
        private Settings settings;

        private delegate void SetTextDelegate(string text);

        public MainWindow()
        {
            InitializeComponent();

            // settings
            settings = new Settings();
            settings.EventHandler += Settings_EventHandler;

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
                    case MessageType.None: richTextBoxMain.SelectionColor = settings.NormalTextColor; break;
                    case MessageType.Info: richTextBoxMain.SelectionColor = settings.InfoTextColor; break;
                    case MessageType.Warning: richTextBoxMain.SelectionColor = settings.WarningTextColor; break;
                    case MessageType.Error: richTextBoxMain.SelectionColor = settings.ErrorTextColor; break;
                    case MessageType.Exception: richTextBoxMain.SelectionColor = settings.ErrorTextColor; break;
                }

                // component name
                richTextBoxMain.SelectionFont = new Font(settings.Font, FontStyle.Bold);
                richTextBoxMain.AppendText(string.Format("[{0}] ", message.ComponentName));

                // message text
                richTextBoxMain.SelectionFont = new Font(settings.Font, FontStyle.Regular);
                richTextBoxMain.AppendText(string.Format("{0}", message.MessageText));
            }
        }

        private void TextBoxRefresh()
        {
            richTextBoxMain.Text = string.Empty;
            richTextBoxMain.Font = settings.Font;
            richTextBoxMain.BackColor = settings.BackgroundColor;
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
            Refresh();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // show version number in window title
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            string versionString = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
            Text = string.Format("{0} - v{1}", assemblyName, versionString);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm optionsForm = new SettingsForm(settings);
            if (optionsForm.ShowDialog(this) == DialogResult.OK)
                Refresh();
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

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // kill any active listener
            if (listener.IsActive)
                listener.Stop();

            // automatically exit the application when the form is closed
            Application.Exit();
        }

        public override void Refresh()
        {
            base.Refresh();

            TextBoxRefresh();
        }

        private void Settings_EventHandler(object sender, SettingsEventArgs e)
        {
            MessageBox.Show(e.Message, "Settings exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
