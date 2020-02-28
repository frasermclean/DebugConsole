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
            this.labelPortNumber = new System.Windows.Forms.Label();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.buttonSelectFont = new System.Windows.Forms.Button();
            this.labelSelectedFont = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.labelColorBackground = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(this.labelColorBackground, 0, 2);
            tableLayoutPanel.Controls.Add(this.labelPortNumber, 0, 0);
            tableLayoutPanel.Controls.Add(this.textBoxPortNumber, 1, 0);
            tableLayoutPanel.Controls.Add(this.buttonSelectFont, 1, 1);
            tableLayoutPanel.Controls.Add(this.labelSelectedFont, 0, 1);
            tableLayoutPanel.Controls.Add(this.pictureBoxBackground, 1, 2);
            tableLayoutPanel.Controls.Add(this.buttonSave, 0, 3);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(344, 201);
            tableLayoutPanel.TabIndex = 0;
            // 
            // labelPortNumber
            // 
            this.labelPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPortNumber.AutoSize = true;
            this.labelPortNumber.Location = new System.Drawing.Point(42, 12);
            this.labelPortNumber.Name = "labelPortNumber";
            this.labelPortNumber.Size = new System.Drawing.Size(127, 15);
            this.labelPortNumber.TabIndex = 0;
            this.labelPortNumber.Text = "Listening Port Number";
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxPortNumber.Location = new System.Drawing.Point(175, 8);
            this.textBoxPortNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPortNumber.MaxLength = 5;
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(116, 23);
            this.textBoxPortNumber.TabIndex = 1;
            // 
            // buttonSelectFont
            // 
            this.buttonSelectFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSelectFont.Location = new System.Drawing.Point(175, 48);
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
            this.labelSelectedFont.Location = new System.Drawing.Point(94, 52);
            this.labelSelectedFont.Name = "labelSelectedFont";
            this.labelSelectedFont.Size = new System.Drawing.Size(75, 15);
            this.labelSelectedFont.TabIndex = 3;
            this.labelSelectedFont.Text = "Font Preview\r\n";
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog.MaxSize = 24;
            this.fontDialog.MinSize = 8;
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBoxBackground.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBackground.Location = new System.Drawing.Point(175, 84);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxBackground.TabIndex = 4;
            this.pictureBoxBackground.TabStop = false;
            // 
            // labelColorBackground
            // 
            this.labelColorBackground.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelColorBackground.AutoSize = true;
            this.labelColorBackground.Location = new System.Drawing.Point(66, 88);
            this.labelColorBackground.Name = "labelColorBackground";
            this.labelColorBackground.Size = new System.Drawing.Size(103, 15);
            this.labelColorBackground.TabIndex = 5;
            this.labelColorBackground.Text = "Background Color";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            tableLayoutPanel.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(112, 140);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 32);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save Settings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 201);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPortNumber;
        private System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button buttonSelectFont;
        private System.Windows.Forms.Label labelSelectedFont;
        private System.Windows.Forms.Label labelColorBackground;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Button buttonSave;
    }
}