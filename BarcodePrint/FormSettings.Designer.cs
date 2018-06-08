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
            this.connectionSettingsGroupBox.SuspendLayout();
            this.printerSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPrinters
            // 
            this.comboBoxPrinters.FormattingEnabled = true;
            this.comboBoxPrinters.Location = new System.Drawing.Point(93, 19);
            this.comboBoxPrinters.Name = "comboBoxPrinters";
            this.comboBoxPrinters.Size = new System.Drawing.Size(159, 21);
            this.comboBoxPrinters.TabIndex = 5;
            this.comboBoxPrinters.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(13, 22);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(74, 13);
            this.labelPrinter.TabIndex = 5;
            this.labelPrinter.Text = "Default &Printer";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(117, 292);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "&Font Size";
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(93, 72);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(159, 20);
            this.textBoxFontSize.TabIndex = 7;
            this.textBoxFontSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.textBoxFontSize.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.textBoxFontSize.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            this.textBoxFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(201, 292);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(20, 22);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(67, 13);
            this.labelDataSource.TabIndex = 1;
            this.labelDataSource.Text = "Data &Source";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(34, 48);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(53, 13);
            this.labelDataBase.TabIndex = 2;
            this.labelDataBase.Text = "&Database";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(27, 74);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(60, 13);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User &Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(34, 100);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(93, 19);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(159, 20);
            this.textBoxDataSource.TabIndex = 1;
            this.textBoxDataSource.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(93, 45);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabase.TabIndex = 2;
            this.textBoxDatabase.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(93, 71);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(159, 20);
            this.textBoxUserName.TabIndex = 3;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(93, 97);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(159, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // checkBoxPrintOnCommit
            // 
            this.checkBoxPrintOnCommit.AutoSize = true;
            this.checkBoxPrintOnCommit.Location = new System.Drawing.Point(153, 95);
            this.checkBoxPrintOnCommit.Name = "checkBoxPrintOnCommit";
            this.checkBoxPrintOnCommit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPrintOnCommit.Size = new System.Drawing.Size(99, 17);
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
            this.connectionSettingsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.connectionSettingsGroupBox.Name = "connectionSettingsGroupBox";
            this.connectionSettingsGroupBox.Size = new System.Drawing.Size(264, 151);
            this.connectionSettingsGroupBox.TabIndex = 12;
            this.connectionSettingsGroupBox.TabStop = false;
            this.connectionSettingsGroupBox.Text = "Connection Settings";
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(150, 123);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(102, 23);
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
            this.printerSettingsGroupBox.Location = new System.Drawing.Point(12, 169);
            this.printerSettingsGroupBox.Name = "printerSettingsGroupBox";
            this.printerSettingsGroupBox.Size = new System.Drawing.Size(264, 118);
            this.printerSettingsGroupBox.TabIndex = 13;
            this.printerSettingsGroupBox.TabStop = false;
            this.printerSettingsGroupBox.Text = "Printer Settings";
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(36, 49);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(39, 13);
            this.marginLabel.TabIndex = 6;
            this.marginLabel.Text = "&Margin";
            // 
            // marginTextBox
            // 
            this.marginTextBox.Location = new System.Drawing.Point(93, 46);
            this.marginTextBox.Name = "marginTextBox";
            this.marginTextBox.Size = new System.Drawing.Size(159, 20);
            this.marginTextBox.TabIndex = 6;
            this.marginTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.marginTextBox.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.marginTextBox.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            this.marginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(288, 323);
            this.Controls.Add(this.printerSettingsGroupBox);
            this.Controls.Add(this.connectionSettingsGroupBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
            this.ResumeLayout(false);

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
    }
}