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
        }       

        private void ButtonSelectFont_Click(object sender, EventArgs e)
        {
            // show font dialog and get result
            DialogResult result = fontDialog.ShowDialog(this);

            // apply new font
            if (result == DialogResult.OK)
            {
                settings.Font = fontDialog.Font;
                labelSelectedFont.Font = settings.Font;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

        }
    }
}
