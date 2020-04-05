using System;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class SettingsForm : Form
    {
        private Settings settings;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();

            this.settings = settings;
            Refresh();
        }

        #region Event handlers
        private void TextBoxPortNumber_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(textBoxPortNumber.Text, out ushort result) && result > 0 && result <= 65535)
                settings.ListeningPortNumber = result;
            else
            {
                MessageBox.Show("Invalid port number", "Invalid port number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings.ListeningPortNumber = Listener.PortDefault;
                Refresh();
            }
        }
        private void ButtonSelectFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = settings.Font;

            // apply new font
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                settings.Font = fontDialog.Font;
                Refresh();
            }
        }

        private void ButtonColorSelect_Click(object sender, EventArgs e)
        {
            // show color dialog
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                // determine which color was selected
                if (sender == pictureBoxBackground)
                    settings.BackgroundColor = colorDialog.Color;
                else if (sender == pictureBoxNormalText)
                    settings.NormalTextColor = colorDialog.Color;
                else if (sender == pictureBoxInfoText)
                    settings.InfoTextColor = colorDialog.Color;
                else if (sender == pictureBoxWarningText)
                    settings.WarningTextColor = colorDialog.Color;
                else if (sender == pictureBoxErrorText)
                    settings.ErrorTextColor = colorDialog.Color;
                else if (sender == pictureBoxExceptionText)
                    settings.ExceptionTextColor = colorDialog.Color;
                else if (sender == pictureBoxRawText)
                    settings.RawTextColor = colorDialog.Color;

                Refresh();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!settings.Save())
                MessageBox.Show("Could not save settings file to disk.", "Error saving settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        public override void Refresh()
        {
            base.Refresh();

            textBoxPortNumber.Text = settings.ListeningPortNumber.ToString();
            labelSelectedFont.Font = settings.Font;
            pictureBoxBackground.BackColor = settings.BackgroundColor;
            pictureBoxNormalText.BackColor = settings.NormalTextColor;
            pictureBoxInfoText.BackColor = settings.InfoTextColor;
            pictureBoxWarningText.BackColor = settings.WarningTextColor;
            pictureBoxErrorText.BackColor = settings.ErrorTextColor;
            pictureBoxExceptionText.BackColor = settings.ExceptionTextColor;
            pictureBoxRawText.BackColor = settings.RawTextColor;
        }
    }
}
