namespace DebugConsole
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            System.Windows.Forms.Label labelErrorTextColor;
            System.Windows.Forms.Label labelWarningTextColor;
            System.Windows.Forms.Label labelInfoTextColor;
            System.Windows.Forms.Label labelNormalTextColor;
            System.Windows.Forms.Label labelColorBackground;
            this.pictureBoxErrorText = new System.Windows.Forms.PictureBox();
            this.pictureBoxWarningText = new System.Windows.Forms.PictureBox();
            this.pictureBoxInfoText = new System.Windows.Forms.PictureBox();
            this.pictureBoxNormalText = new System.Windows.Forms.PictureBox();
            this.labelPortNumber = new System.Windows.Forms.Label();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.buttonSelectFont = new System.Windows.Forms.Button();
            this.labelSelectedFont = new System.Windows.Forms.Label();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            labelErrorTextColor = new System.Windows.Forms.Label();
            labelWarningTextColor = new System.Windows.Forms.Label();
            labelInfoTextColor = new System.Windows.Forms.Label();
            labelNormalTextColor = new System.Windows.Forms.Label();
            labelColorBackground = new System.Windows.Forms.Label();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormalText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(this.pictureBoxErrorText, 1, 6);
            tableLayoutPanel.Controls.Add(labelErrorTextColor, 0, 6);
            tableLayoutPanel.Controls.Add(this.pictureBoxWarningText, 1, 5);
            tableLayoutPanel.Controls.Add(labelWarningTextColor, 0, 5);
            tableLayoutPanel.Controls.Add(this.pictureBoxInfoText, 1, 4);
            tableLayoutPanel.Controls.Add(labelInfoTextColor, 0, 4);
            tableLayoutPanel.Controls.Add(this.pictureBoxNormalText, 1, 3);
            tableLayoutPanel.Controls.Add(labelNormalTextColor, 0, 3);
            tableLayoutPanel.Controls.Add(labelColorBackground, 0, 2);
            tableLayoutPanel.Controls.Add(this.labelPortNumber, 0, 0);
            tableLayoutPanel.Controls.Add(this.textBoxPortNumber, 1, 0);
            tableLayoutPanel.Controls.Add(this.buttonSelectFont, 1, 1);
            tableLayoutPanel.Controls.Add(this.labelSelectedFont, 0, 1);
            tableLayoutPanel.Controls.Add(this.pictureBoxBackground, 1, 2);
            tableLayoutPanel.Controls.Add(this.buttonOK, 0, 7);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 8;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(344, 321);
            tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBoxErrorText
            // 
            this.pictureBoxErrorText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxErrorText.BackColor = System.Drawing.Color.Red;
            this.pictureBoxErrorText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxErrorText.Location = new System.Drawing.Point(175, 195);
            this.pictureBoxErrorText.Name = "pictureBoxErrorText";
            this.pictureBoxErrorText.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxErrorText.TabIndex = 14;
            this.pictureBoxErrorText.TabStop = false;
            this.pictureBoxErrorText.Click += new System.EventHandler(this.ButtonColorSelect_Click);
            // 
            // labelErrorTextColor
            // 
            labelErrorTextColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelErrorTextColor.AutoSize = true;
            labelErrorTextColor.Location = new System.Drawing.Point(81, 199);
            labelErrorTextColor.Name = "labelErrorTextColor";
            labelErrorTextColor.Size = new System.Drawing.Size(88, 15);
            labelErrorTextColor.TabIndex = 13;
            labelErrorTextColor.Text = "Error Text Color";
            // 
            // pictureBoxWarningText
            // 
            this.pictureBoxWarningText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxWarningText.BackColor = System.Drawing.Color.Gold;
            this.pictureBoxWarningText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWarningText.Location = new System.Drawing.Point(175, 164);
            this.pictureBoxWarningText.Name = "pictureBoxWarningText";
            this.pictureBoxWarningText.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxWarningText.TabIndex = 12;
            this.pictureBoxWarningText.TabStop = false;
            this.pictureBoxWarningText.Click += new System.EventHandler(this.ButtonColorSelect_Click);
            // 
            // labelWarningTextColor
            // 
            labelWarningTextColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelWarningTextColor.AutoSize = true;
            labelWarningTextColor.Location = new System.Drawing.Point(61, 168);
            labelWarningTextColor.Name = "labelWarningTextColor";
            labelWarningTextColor.Size = new System.Drawing.Size(108, 15);
            labelWarningTextColor.TabIndex = 11;
            labelWarningTextColor.Text = "Warning Text Color";
            // 
            // pictureBoxInfoText
            // 
            this.pictureBoxInfoText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxInfoText.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBoxInfoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxInfoText.Location = new System.Drawing.Point(175, 132);
            this.pictureBoxInfoText.Name = "pictureBoxInfoText";
            this.pictureBoxInfoText.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxInfoText.TabIndex = 10;
            this.pictureBoxInfoText.TabStop = false;
            this.pictureBoxInfoText.Click += new System.EventHandler(this.ButtonColorSelect_Click);
            // 
            // labelInfoTextColor
            // 
            labelInfoTextColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelInfoTextColor.AutoSize = true;
            labelInfoTextColor.Location = new System.Drawing.Point(43, 136);
            labelInfoTextColor.Name = "labelInfoTextColor";
            labelInfoTextColor.Size = new System.Drawing.Size(126, 15);
            labelInfoTextColor.TabIndex = 9;
            labelInfoTextColor.Text = "Information Text Color";
            // 
            // pictureBoxNormalText
            // 
            this.pictureBoxNormalText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxNormalText.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxNormalText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNormalText.Location = new System.Drawing.Point(175, 100);
            this.pictureBoxNormalText.Name = "pictureBoxNormalText";
            this.pictureBoxNormalText.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxNormalText.TabIndex = 8;
            this.pictureBoxNormalText.TabStop = false;
            this.pictureBoxNormalText.Click += new System.EventHandler(this.ButtonColorSelect_Click);
            // 
            // labelNormalTextColor
            // 
            labelNormalTextColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelNormalTextColor.AutoSize = true;
            labelNormalTextColor.Location = new System.Drawing.Point(66, 104);
            labelNormalTextColor.Name = "labelNormalTextColor";
            labelNormalTextColor.Size = new System.Drawing.Size(103, 15);
            labelNormalTextColor.TabIndex = 7;
            labelNormalTextColor.Text = "Normal Text Color";
            // 
            // labelColorBackground
            // 
            labelColorBackground.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelColorBackground.AutoSize = true;
            labelColorBackground.Location = new System.Drawing.Point(66, 72);
            labelColorBackground.Name = "labelColorBackground";
            labelColorBackground.Size = new System.Drawing.Size(103, 15);
            labelColorBackground.TabIndex = 5;
            labelColorBackground.Text = "Background Color";
            // 
            // labelPortNumber
            // 
            this.labelPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPortNumber.AutoSize = true;
            this.labelPortNumber.Location = new System.Drawing.Point(42, 8);
            this.labelPortNumber.Name = "labelPortNumber";
            this.labelPortNumber.Size = new System.Drawing.Size(127, 15);
            this.labelPortNumber.TabIndex = 0;
            this.labelPortNumber.Text = "Listening Port Number";
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxPortNumber.Location = new System.Drawing.Point(175, 4);
            this.textBoxPortNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPortNumber.MaxLength = 5;
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(80, 23);
            this.textBoxPortNumber.TabIndex = 1;
            // 
            // buttonSelectFont
            // 
            this.buttonSelectFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSelectFont.Location = new System.Drawing.Point(175, 36);
            this.buttonSelectFont.Name = "buttonSelectFont";
            this.buttonSelectFont.Size = new System.Drawing.Size(80, 24);
            this.buttonSelectFont.TabIndex = 2;
            this.buttonSelectFont.Text = "Select Font";
            this.buttonSelectFont.UseVisualStyleBackColor = true;
            this.buttonSelectFont.Click += new System.EventHandler(this.ButtonSelectFont_Click);
            // 
            // labelSelectedFont
            // 
            this.labelSelectedFont.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSelectedFont.AutoSize = true;
            this.labelSelectedFont.Location = new System.Drawing.Point(94, 40);
            this.labelSelectedFont.Name = "labelSelectedFont";
            this.labelSelectedFont.Size = new System.Drawing.Size(75, 15);
            this.labelSelectedFont.TabIndex = 3;
            this.labelSelectedFont.Text = "Font Preview\r\n";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxBackground.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackground.Location = new System.Drawing.Point(175, 68);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxBackground.TabIndex = 4;
            this.pictureBoxBackground.TabStop = false;
            this.pictureBoxBackground.Click += new System.EventHandler(this.ButtonColorSelect_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            tableLayoutPanel.SetColumnSpan(this.buttonOK, 2);
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(92, 255);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(160, 32);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "Save Settings";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog.MaxSize = 24;
            this.fontDialog.MinSize = 8;
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowEffects = false;
            this.fontDialog.ShowHelp = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 321);
            this.Controls.Add(tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarningText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormalText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPortNumber;
        private System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button buttonSelectFont;
        private System.Windows.Forms.Label labelSelectedFont;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.PictureBox pictureBoxNormalText;
        private System.Windows.Forms.PictureBox pictureBoxInfoText;
        private System.Windows.Forms.PictureBox pictureBoxErrorText;
        private System.Windows.Forms.PictureBox pictureBoxWarningText;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}