namespace BarcodePrinter
{
    partial class FormSettings
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
            this.comboBoxConnections = new System.Windows.Forms.ComboBox();
            this.comboBoxPrinters = new System.Windows.Forms.ComboBox();
            this.labelConnction = new System.Windows.Forms.Label();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFontSize = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxConnections
            // 
            this.comboBoxConnections.FormattingEnabled = true;
            this.comboBoxConnections.Location = new System.Drawing.Point(113, 11);
            this.comboBoxConnections.Name = "comboBoxConnections";
            this.comboBoxConnections.Size = new System.Drawing.Size(159, 21);
            this.comboBoxConnections.TabIndex = 0;
            this.comboBoxConnections.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // comboBoxPrinters
            // 
            this.comboBoxPrinters.FormattingEnabled = true;
            this.comboBoxPrinters.Location = new System.Drawing.Point(113, 40);
            this.comboBoxPrinters.Name = "comboBoxPrinters";
            this.comboBoxPrinters.Size = new System.Drawing.Size(159, 21);
            this.comboBoxPrinters.TabIndex = 1;
            this.comboBoxPrinters.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelConnction
            // 
            this.labelConnction.AutoSize = true;
            this.labelConnction.Location = new System.Drawing.Point(29, 15);
            this.labelConnction.Name = "labelConnction";
            this.labelConnction.Size = new System.Drawing.Size(61, 13);
            this.labelConnction.TabIndex = 0;
            this.labelConnction.Text = "&Connection";
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(16, 44);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(74, 13);
            this.labelPrinter.TabIndex = 1;
            this.labelPrinter.Text = "&Default Printer";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(113, 95);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Font Size";
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(113, 69);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(159, 20);
            this.textBoxFontSize.TabIndex = 2;
            this.textBoxFontSize.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.textBoxFontSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.textBoxFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            this.textBoxFontSize.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(197, 95);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 126);
            this.Controls.Add(this.textBoxFontSize);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPrinter);
            this.Controls.Add(this.labelConnction);
            this.Controls.Add(this.comboBoxPrinters);
            this.Controls.Add(this.comboBoxConnections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxConnections;
        private System.Windows.Forms.ComboBox comboBoxPrinters;
        private System.Windows.Forms.Label labelConnction;
        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.Button buttonOk;
    }
}