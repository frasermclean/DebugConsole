namespace DebugConsole
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
            this.textPortNumber = new System.Windows.Forms.TextBox();
            this.labelPortNumber = new System.Windows.Forms.Label();
            this.buttonStartListening = new System.Windows.Forms.Button();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textPortNumber
            // 
            this.textPortNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPortNumber.Location = new System.Drawing.Point(107, 12);
            this.textPortNumber.MaxLength = 5;
            this.textPortNumber.Name = "textPortNumber";
            this.textPortNumber.Size = new System.Drawing.Size(64, 22);
            this.textPortNumber.TabIndex = 0;
            this.textPortNumber.TextChanged += new System.EventHandler(this.textPortNumber_TextChanged);
            // 
            // labelPortNumber
            // 
            this.labelPortNumber.AutoSize = true;
            this.labelPortNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPortNumber.Location = new System.Drawing.Point(26, 18);
            this.labelPortNumber.Name = "labelPortNumber";
            this.labelPortNumber.Size = new System.Drawing.Size(75, 13);
            this.labelPortNumber.TabIndex = 1;
            this.labelPortNumber.Text = "Port Number:";
            this.labelPortNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPortNumber.Click += new System.EventHandler(this.labelPortNumber_Click);
            // 
            // buttonStartListening
            // 
            this.buttonStartListening.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartListening.Location = new System.Drawing.Point(177, 12);
            this.buttonStartListening.Name = "buttonStartListening";
            this.buttonStartListening.Size = new System.Drawing.Size(96, 25);
            this.buttonStartListening.TabIndex = 2;
            this.buttonStartListening.Text = "Start Listening";
            this.buttonStartListening.UseVisualStyleBackColor = true;
            this.buttonStartListening.Click += new System.EventHandler(this.buttonStartListening_Click);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.Location = new System.Drawing.Point(12, 43);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(760, 506);
            this.richTextBoxMain.TabIndex = 3;
            this.richTextBoxMain.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.buttonStartListening);
            this.Controls.Add(this.labelPortNumber);
            this.Controls.Add(this.textPortNumber);
            this.Name = "MainWindow";
            this.Text = "DebugConsole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPortNumber;
        private System.Windows.Forms.Label labelPortNumber;
        private System.Windows.Forms.Button buttonStartListening;
        private System.Windows.Forms.RichTextBox richTextBoxMain;
    }
}

