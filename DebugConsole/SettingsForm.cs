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
        }
    }
}
