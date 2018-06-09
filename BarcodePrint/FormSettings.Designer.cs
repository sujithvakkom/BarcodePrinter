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
            this.comboBoxPrinters = new System.Windows.Forms.ComboBox();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFontSize = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxPrintOnCommit = new System.Windows.Forms.CheckBox();
            this.connectionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.printerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.marginLabel = new System.Windows.Forms.Label();
            this.marginTextBox = new System.Windows.Forms.TextBox();
            this.textBoxEAN13Sample = new System.Windows.Forms.TextBox();
            this.textBoxCode128Sample = new System.Windows.Forms.TextBox();
            this.textBoxEAN13ELN = new System.Windows.Forms.TextBox();
            this.textBoxCode128ELN = new System.Windows.Forms.TextBox();
            this.labelCode128ELN = new System.Windows.Forms.Label();
            this.labelEAN13ELN = new System.Windows.Forms.Label();
            this.groupBoxBarcodeMode = new System.Windows.Forms.GroupBox();
            this.radioButtonAuto = new System.Windows.Forms.RadioButton();
            this.radioButtonEAN13 = new System.Windows.Forms.RadioButton();
            this.radioButtonCode128 = new System.Windows.Forms.RadioButton();
            this.connectionSettingsGroupBox.SuspendLayout();
            this.printerSettingsGroupBox.SuspendLayout();
            this.groupBoxBarcodeMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPrinters
            // 
            this.comboBoxPrinters.FormattingEnabled = true;
            this.comboBoxPrinters.Location = new System.Drawing.Point(186, 37);
            this.comboBoxPrinters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxPrinters.Name = "comboBoxPrinters";
            this.comboBoxPrinters.Size = new System.Drawing.Size(314, 33);
            this.comboBoxPrinters.TabIndex = 5;
            this.comboBoxPrinters.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(26, 42);
            this.labelPrinter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(149, 25);
            this.labelPrinter.TabIndex = 5;
            this.labelPrinter.Text = "Default &Printer";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApply.Location = new System.Drawing.Point(593, 773);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(150, 44);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "&Font Size";
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(186, 138);
            this.textBoxFontSize.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(314, 31);
            this.textBoxFontSize.TabIndex = 7;
            this.textBoxFontSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.textBoxFontSize.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.textBoxFontSize.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            this.textBoxFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(761, 773);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(150, 44);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(40, 42);
            this.labelDataSource.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(131, 25);
            this.labelDataSource.TabIndex = 1;
            this.labelDataSource.Text = "Data &Source";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(68, 92);
            this.labelDataBase.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(104, 25);
            this.labelDataBase.TabIndex = 2;
            this.labelDataBase.Text = "&Database";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(54, 142);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(119, 25);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User &Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(68, 192);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(106, 25);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(186, 37);
            this.textBoxDataSource.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(314, 31);
            this.textBoxDataSource.TabIndex = 1;
            this.textBoxDataSource.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(186, 87);
            this.textBoxDatabase.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(314, 31);
            this.textBoxDatabase.TabIndex = 2;
            this.textBoxDatabase.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(186, 137);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(314, 31);
            this.textBoxUserName.TabIndex = 3;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(186, 187);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(314, 31);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // checkBoxPrintOnCommit
            // 
            this.checkBoxPrintOnCommit.AutoSize = true;
            this.checkBoxPrintOnCommit.Location = new System.Drawing.Point(306, 183);
            this.checkBoxPrintOnCommit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBoxPrintOnCommit.Name = "checkBoxPrintOnCommit";
            this.checkBoxPrintOnCommit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPrintOnCommit.Size = new System.Drawing.Size(196, 29);
            this.checkBoxPrintOnCommit.TabIndex = 8;
            this.checkBoxPrintOnCommit.TabStop = false;
            this.checkBoxPrintOnCommit.Text = "Print on &Commit";
            this.checkBoxPrintOnCommit.UseVisualStyleBackColor = true;
            this.checkBoxPrintOnCommit.CheckedChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // connectionSettingsGroupBox
            // 
            this.connectionSettingsGroupBox.Controls.Add(this.buttonTestConnection);
            this.connectionSettingsGroupBox.Controls.Add(this.labelDataSource);
            this.connectionSettingsGroupBox.Controls.Add(this.labelDataBase);
            this.connectionSettingsGroupBox.Controls.Add(this.textBoxPassword);
            this.connectionSettingsGroupBox.Controls.Add(this.labelUserName);
            this.connectionSettingsGroupBox.Controls.Add(this.textBoxUserName);
            this.connectionSettingsGroupBox.Controls.Add(this.labelPassword);
            this.connectionSettingsGroupBox.Controls.Add(this.textBoxDatabase);
            this.connectionSettingsGroupBox.Controls.Add(this.textBoxDataSource);
            this.connectionSettingsGroupBox.Location = new System.Drawing.Point(24, 23);
            this.connectionSettingsGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.connectionSettingsGroupBox.Name = "connectionSettingsGroupBox";
            this.connectionSettingsGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.connectionSettingsGroupBox.Size = new System.Drawing.Size(528, 290);
            this.connectionSettingsGroupBox.TabIndex = 12;
            this.connectionSettingsGroupBox.TabStop = false;
            this.connectionSettingsGroupBox.Text = "Connection Settings";
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(300, 237);
            this.buttonTestConnection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(204, 44);
            this.buttonTestConnection.TabIndex = 11;
            this.buttonTestConnection.TabStop = false;
            this.buttonTestConnection.Text = "Test &Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // printerSettingsGroupBox
            // 
            this.printerSettingsGroupBox.Controls.Add(this.labelPrinter);
            this.printerSettingsGroupBox.Controls.Add(this.comboBoxPrinters);
            this.printerSettingsGroupBox.Controls.Add(this.checkBoxPrintOnCommit);
            this.printerSettingsGroupBox.Controls.Add(this.marginLabel);
            this.printerSettingsGroupBox.Controls.Add(this.label1);
            this.printerSettingsGroupBox.Controls.Add(this.marginTextBox);
            this.printerSettingsGroupBox.Controls.Add(this.textBoxFontSize);
            this.printerSettingsGroupBox.Location = new System.Drawing.Point(24, 325);
            this.printerSettingsGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.printerSettingsGroupBox.Name = "printerSettingsGroupBox";
            this.printerSettingsGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.printerSettingsGroupBox.Size = new System.Drawing.Size(528, 227);
            this.printerSettingsGroupBox.TabIndex = 13;
            this.printerSettingsGroupBox.TabStop = false;
            this.printerSettingsGroupBox.Text = "Printer Settings";
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(72, 94);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(78, 25);
            this.marginLabel.TabIndex = 6;
            this.marginLabel.Text = "&Margin";
            // 
            // marginTextBox
            // 
            this.marginTextBox.Location = new System.Drawing.Point(186, 88);
            this.marginTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.marginTextBox.Name = "marginTextBox";
            this.marginTextBox.Size = new System.Drawing.Size(314, 31);
            this.marginTextBox.TabIndex = 6;
            this.marginTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.marginTextBox.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.marginTextBox.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            this.marginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            // 
            // textBoxEAN13Sample
            // 
            this.textBoxEAN13Sample.Location = new System.Drawing.Point(594, 75);
            this.textBoxEAN13Sample.Multiline = true;
            this.textBoxEAN13Sample.Name = "textBoxEAN13Sample";
            this.textBoxEAN13Sample.ReadOnly = true;
            this.textBoxEAN13Sample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEAN13Sample.Size = new System.Drawing.Size(478, 304);
            this.textBoxEAN13Sample.TabIndex = 14;
            this.textBoxEAN13Sample.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxCode128Sample
            // 
            this.textBoxCode128Sample.Location = new System.Drawing.Point(594, 439);
            this.textBoxCode128Sample.Multiline = true;
            this.textBoxCode128Sample.Name = "textBoxCode128Sample";
            this.textBoxCode128Sample.ReadOnly = true;
            this.textBoxCode128Sample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode128Sample.Size = new System.Drawing.Size(478, 304);
            this.textBoxCode128Sample.TabIndex = 14;
            // 
            // textBoxEAN13ELN
            // 
            this.textBoxEAN13ELN.Location = new System.Drawing.Point(1106, 75);
            this.textBoxEAN13ELN.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxEAN13ELN.Multiline = true;
            this.textBoxEAN13ELN.Name = "textBoxEAN13ELN";
            this.textBoxEAN13ELN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEAN13ELN.Size = new System.Drawing.Size(478, 304);
            this.textBoxEAN13ELN.TabIndex = 1;
            this.textBoxEAN13ELN.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxCode128ELN
            // 
            this.textBoxCode128ELN.Location = new System.Drawing.Point(1106, 439);
            this.textBoxCode128ELN.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxCode128ELN.Multiline = true;
            this.textBoxCode128ELN.Name = "textBoxCode128ELN";
            this.textBoxCode128ELN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode128ELN.Size = new System.Drawing.Size(478, 304);
            this.textBoxCode128ELN.TabIndex = 2;
            this.textBoxCode128ELN.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelCode128ELN
            // 
            this.labelCode128ELN.AutoSize = true;
            this.labelCode128ELN.Location = new System.Drawing.Point(600, 407);
            this.labelCode128ELN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelCode128ELN.Name = "labelCode128ELN";
            this.labelCode128ELN.Size = new System.Drawing.Size(152, 25);
            this.labelCode128ELN.TabIndex = 2;
            this.labelCode128ELN.Text = "Code 128 ELN";
            // 
            // labelEAN13ELN
            // 
            this.labelEAN13ELN.AutoSize = true;
            this.labelEAN13ELN.Location = new System.Drawing.Point(600, 41);
            this.labelEAN13ELN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEAN13ELN.Name = "labelEAN13ELN";
            this.labelEAN13ELN.Size = new System.Drawing.Size(132, 25);
            this.labelEAN13ELN.TabIndex = 1;
            this.labelEAN13ELN.Text = "EAN 13 ELN";
            // 
            // groupBoxBarcodeMode
            // 
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonCode128);
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonEAN13);
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonAuto);
            this.groupBoxBarcodeMode.Location = new System.Drawing.Point(24, 589);
            this.groupBoxBarcodeMode.Name = "groupBoxBarcodeMode";
            this.groupBoxBarcodeMode.Size = new System.Drawing.Size(528, 227);
            this.groupBoxBarcodeMode.TabIndex = 15;
            this.groupBoxBarcodeMode.TabStop = false;
            this.groupBoxBarcodeMode.Text = "Barcode Mode";
            // 
            // radioButtonAuto
            // 
            this.radioButtonAuto.AutoSize = true;
            this.radioButtonAuto.Checked = true;
            this.radioButtonAuto.Location = new System.Drawing.Point(32, 57);
            this.radioButtonAuto.Name = "radioButtonAuto";
            this.radioButtonAuto.Size = new System.Drawing.Size(27, 26);
            this.radioButtonAuto.TabIndex = 3;
            this.radioButtonAuto.TabStop = true;
            this.radioButtonAuto.UseVisualStyleBackColor = true;
            // 
            // radioButtonEAN13
            // 
            this.radioButtonEAN13.AutoSize = true;
            this.radioButtonEAN13.Location = new System.Drawing.Point(32, 104);
            this.radioButtonEAN13.Name = "radioButtonEAN13";
            this.radioButtonEAN13.Size = new System.Drawing.Size(27, 26);
            this.radioButtonEAN13.TabIndex = 3;
            this.radioButtonEAN13.UseVisualStyleBackColor = true;
            // 
            // radioButtonCode128
            // 
            this.radioButtonCode128.AutoSize = true;
            this.radioButtonCode128.Location = new System.Drawing.Point(32, 151);
            this.radioButtonCode128.Name = "radioButtonCode128";
            this.radioButtonCode128.Size = new System.Drawing.Size(27, 26);
            this.radioButtonCode128.TabIndex = 3;
            this.radioButtonCode128.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(1612, 832);
            this.Controls.Add(this.groupBoxBarcodeMode);
            this.Controls.Add(this.textBoxCode128Sample);
            this.Controls.Add(this.labelEAN13ELN);
            this.Controls.Add(this.textBoxEAN13Sample);
            this.Controls.Add(this.labelCode128ELN);
            this.Controls.Add(this.printerSettingsGroupBox);
            this.Controls.Add(this.connectionSettingsGroupBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textBoxCode128ELN);
            this.Controls.Add(this.textBoxEAN13ELN);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1638, 903);
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.connectionSettingsGroupBox.ResumeLayout(false);
            this.connectionSettingsGroupBox.PerformLayout();
            this.printerSettingsGroupBox.ResumeLayout(false);
            this.printerSettingsGroupBox.PerformLayout();
            this.groupBoxBarcodeMode.ResumeLayout(false);
            this.groupBoxBarcodeMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPrinters;
        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxPrintOnCommit;
        private System.Windows.Forms.GroupBox connectionSettingsGroupBox;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.GroupBox printerSettingsGroupBox;
        private System.Windows.Forms.Label marginLabel;
        private System.Windows.Forms.TextBox marginTextBox;
        private System.Windows.Forms.TextBox textBoxEAN13Sample;
        private System.Windows.Forms.TextBox textBoxCode128Sample;
        private System.Windows.Forms.TextBox textBoxEAN13ELN;
        private System.Windows.Forms.TextBox textBoxCode128ELN;
        private System.Windows.Forms.Label labelCode128ELN;
        private System.Windows.Forms.Label labelEAN13ELN;
        private System.Windows.Forms.GroupBox groupBoxBarcodeMode;
        private System.Windows.Forms.RadioButton radioButtonCode128;
        private System.Windows.Forms.RadioButton radioButtonEAN13;
        private System.Windows.Forms.RadioButton radioButtonAuto;
    }
}