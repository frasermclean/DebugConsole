﻿namespace DebugConsole
{
    partial class MainWindow
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
            System.Windows.Forms.TableLayoutPanel tableLayoutMain;
            System.Windows.Forms.TableLayoutPanel tableLayoutTop;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonToggleListening = new System.Windows.Forms.Button();
            this.labelStatusText = new System.Windows.Forms.Label();
            tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutMain.SuspendLayout();
            tableLayoutTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(this.richTextBoxMain, 0, 1);
            tableLayoutMain.Controls.Add(tableLayoutTop, 0, 0);
            tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 2;
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.Size = new System.Drawing.Size(784, 561);
            tableLayoutMain.TabIndex = 5;
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.BackColor = System.Drawing.Color.Black;
            this.richTextBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMain.ForeColor = System.Drawing.Color.White;
            this.richTextBoxMain.Location = new System.Drawing.Point(3, 43);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.ReadOnly = true;
            this.richTextBoxMain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxMain.Size = new System.Drawing.Size(778, 515);
            this.richTextBoxMain.TabIndex = 6;
            this.richTextBoxMain.Text = "";
            this.richTextBoxMain.TextChanged += new System.EventHandler(this.TextboxTextChangedHandler);
            // 
            // tableLayoutTop
            // 
            tableLayoutTop.ColumnCount = 4;
            tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutTop.Controls.Add(this.buttonClear, 0, 0);
            tableLayoutTop.Controls.Add(this.buttonSettings, 1, 0);
            tableLayoutTop.Controls.Add(this.buttonToggleListening, 2, 0);
            tableLayoutTop.Controls.Add(this.labelStatusText, 3, 0);
            tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutTop.Location = new System.Drawing.Point(3, 3);
            tableLayoutTop.Name = "tableLayoutTop";
            tableLayoutTop.RowCount = 1;
            tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutTop.Size = new System.Drawing.Size(778, 34);
            tableLayoutTop.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Image = global::DebugConsole.Properties.Resources.DeleteIcon;
            this.buttonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClear.Location = new System.Drawing.Point(3, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(90, 28);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSettings.Location = new System.Drawing.Point(99, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(90, 28);
            this.buttonSettings.TabIndex = 1;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonToggleListening
            // 
            this.buttonToggleListening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToggleListening.Location = new System.Drawing.Point(195, 3);
            this.buttonToggleListening.Name = "buttonToggleListening";
            this.buttonToggleListening.Size = new System.Drawing.Size(90, 28);
            this.buttonToggleListening.TabIndex = 2;
            this.buttonToggleListening.Text = "Start Listening";
            this.buttonToggleListening.UseVisualStyleBackColor = true;
            this.buttonToggleListening.Click += new System.EventHandler(this.buttonToggleListening_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Location = new System.Drawing.Point(291, 9);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(63, 15);
            this.labelStatusText.TabIndex = 0;
            this.labelStatusText.Text = "Status Text";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(tableLayoutMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainWindow";
            this.Text = "DebugConsole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutTop.ResumeLayout(false);
            tableLayoutTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonToggleListening;
        private System.Windows.Forms.Button buttonClear;
    }
}

