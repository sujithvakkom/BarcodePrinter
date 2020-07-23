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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
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
            this.radioButtonCode128 = new System.Windows.Forms.RadioButton();
            this.radioButtonEAN13 = new System.Windows.Forms.RadioButton();
            this.radioButtonAuto = new System.Windows.Forms.RadioButton();
            this.groupBoxApplication = new System.Windows.Forms.GroupBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.buttonSaveApplicationSettings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonLSOne = new System.Windows.Forms.RadioButton();
            this.radioButtonNAV = new System.Windows.Forms.RadioButton();
            this.labelStore = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintTest = new System.Windows.Forms.Button();
            this.tbSample = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.setDefault = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.connectionSettingsGroupBox.SuspendLayout();
            this.printerSettingsGroupBox.SuspendLayout();
            this.groupBoxBarcodeMode.SuspendLayout();
            this.groupBoxApplication.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPrinters
            // 
            this.comboBoxPrinters.FormattingEnabled = true;
            this.comboBoxPrinters.Location = new System.Drawing.Point(124, 24);
            this.comboBoxPrinters.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPrinters.Name = "comboBoxPrinters";
            this.comboBoxPrinters.Size = new System.Drawing.Size(211, 24);
            this.comboBoxPrinters.TabIndex = 5;
            this.comboBoxPrinters.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelPrinter
            // 
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(17, 27);
            this.labelPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(99, 17);
            this.labelPrinter.TabIndex = 5;
            this.labelPrinter.Text = "Default &Printer";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApply.Location = new System.Drawing.Point(850, 591);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(100, 48);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "&Font Size";
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(124, 88);
            this.textBoxFontSize.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(211, 22);
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
            this.buttonOk.Location = new System.Drawing.Point(962, 591);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 48);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(27, 27);
            this.labelDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(87, 17);
            this.labelDataSource.TabIndex = 1;
            this.labelDataSource.Text = "Data &Source";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(45, 59);
            this.labelDataBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(69, 17);
            this.labelDataBase.TabIndex = 2;
            this.labelDataBase.Text = "&Database";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(36, 91);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(79, 17);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User &Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(45, 123);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(69, 17);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password";
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(124, 24);
            this.textBoxDataSource.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(211, 22);
            this.textBoxDataSource.TabIndex = 1;
            this.textBoxDataSource.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(124, 56);
            this.textBoxDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(211, 22);
            this.textBoxDatabase.TabIndex = 2;
            this.textBoxDatabase.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(124, 88);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(211, 22);
            this.textBoxUserName.TabIndex = 3;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(124, 120);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(211, 22);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // checkBoxPrintOnCommit
            // 
            this.checkBoxPrintOnCommit.AutoSize = true;
            this.checkBoxPrintOnCommit.Location = new System.Drawing.Point(204, 117);
            this.checkBoxPrintOnCommit.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPrintOnCommit.Name = "checkBoxPrintOnCommit";
            this.checkBoxPrintOnCommit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPrintOnCommit.Size = new System.Drawing.Size(129, 21);
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
            this.connectionSettingsGroupBox.Location = new System.Drawing.Point(16, 270);
            this.connectionSettingsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.connectionSettingsGroupBox.Name = "connectionSettingsGroupBox";
            this.connectionSettingsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.connectionSettingsGroupBox.Size = new System.Drawing.Size(352, 186);
            this.connectionSettingsGroupBox.TabIndex = 12;
            this.connectionSettingsGroupBox.TabStop = false;
            this.connectionSettingsGroupBox.Text = "Connection Settings";
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(200, 152);
            this.buttonTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(136, 28);
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
            this.printerSettingsGroupBox.Location = new System.Drawing.Point(16, 463);
            this.printerSettingsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.printerSettingsGroupBox.Name = "printerSettingsGroupBox";
            this.printerSettingsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.printerSettingsGroupBox.Size = new System.Drawing.Size(352, 145);
            this.printerSettingsGroupBox.TabIndex = 13;
            this.printerSettingsGroupBox.TabStop = false;
            this.printerSettingsGroupBox.Text = "Printer Settings";
            // 
            // marginLabel
            // 
            this.marginLabel.AutoSize = true;
            this.marginLabel.Location = new System.Drawing.Point(48, 60);
            this.marginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.marginLabel.Name = "marginLabel";
            this.marginLabel.Size = new System.Drawing.Size(51, 17);
            this.marginLabel.TabIndex = 6;
            this.marginLabel.Text = "&Margin";
            // 
            // marginTextBox
            // 
            this.marginTextBox.Location = new System.Drawing.Point(124, 56);
            this.marginTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.marginTextBox.Name = "marginTextBox";
            this.marginTextBox.Size = new System.Drawing.Size(211, 22);
            this.marginTextBox.TabIndex = 6;
            this.marginTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxFontSize_MouseClick);
            this.marginTextBox.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            this.marginTextBox.Enter += new System.EventHandler(this.textBoxFontSize_Enter);
            this.marginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSize_KeyPress);
            // 
            // textBoxEAN13Sample
            // 
            this.textBoxEAN13Sample.Location = new System.Drawing.Point(396, 48);
            this.textBoxEAN13Sample.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEAN13Sample.Multiline = true;
            this.textBoxEAN13Sample.Name = "textBoxEAN13Sample";
            this.textBoxEAN13Sample.ReadOnly = true;
            this.textBoxEAN13Sample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEAN13Sample.Size = new System.Drawing.Size(320, 196);
            this.textBoxEAN13Sample.TabIndex = 14;
            this.textBoxEAN13Sample.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxCode128Sample
            // 
            this.textBoxCode128Sample.Location = new System.Drawing.Point(396, 281);
            this.textBoxCode128Sample.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCode128Sample.Multiline = true;
            this.textBoxCode128Sample.Name = "textBoxCode128Sample";
            this.textBoxCode128Sample.ReadOnly = true;
            this.textBoxCode128Sample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode128Sample.Size = new System.Drawing.Size(320, 196);
            this.textBoxCode128Sample.TabIndex = 14;
            // 
            // textBoxEAN13ELN
            // 
            this.textBoxEAN13ELN.Location = new System.Drawing.Point(737, 48);
            this.textBoxEAN13ELN.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEAN13ELN.Multiline = true;
            this.textBoxEAN13ELN.Name = "textBoxEAN13ELN";
            this.textBoxEAN13ELN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEAN13ELN.Size = new System.Drawing.Size(320, 196);
            this.textBoxEAN13ELN.TabIndex = 1;
            this.textBoxEAN13ELN.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // textBoxCode128ELN
            // 
            this.textBoxCode128ELN.Location = new System.Drawing.Point(737, 281);
            this.textBoxCode128ELN.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCode128ELN.Multiline = true;
            this.textBoxCode128ELN.Name = "textBoxCode128ELN";
            this.textBoxCode128ELN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode128ELN.Size = new System.Drawing.Size(320, 196);
            this.textBoxCode128ELN.TabIndex = 2;
            this.textBoxCode128ELN.TextChanged += new System.EventHandler(this.comboBoxConnections_TextChanged);
            // 
            // labelCode128ELN
            // 
            this.labelCode128ELN.AutoSize = true;
            this.labelCode128ELN.Location = new System.Drawing.Point(400, 260);
            this.labelCode128ELN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCode128ELN.Name = "labelCode128ELN";
            this.labelCode128ELN.Size = new System.Drawing.Size(100, 17);
            this.labelCode128ELN.TabIndex = 2;
            this.labelCode128ELN.Text = "Code 128 ELN";
            // 
            // labelEAN13ELN
            // 
            this.labelEAN13ELN.AutoSize = true;
            this.labelEAN13ELN.Location = new System.Drawing.Point(400, 26);
            this.labelEAN13ELN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEAN13ELN.Name = "labelEAN13ELN";
            this.labelEAN13ELN.Size = new System.Drawing.Size(87, 17);
            this.labelEAN13ELN.TabIndex = 1;
            this.labelEAN13ELN.Text = "EAN 13 ELN";
            // 
            // groupBoxBarcodeMode
            // 
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonCode128);
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonEAN13);
            this.groupBoxBarcodeMode.Controls.Add(this.radioButtonAuto);
            this.groupBoxBarcodeMode.Location = new System.Drawing.Point(396, 494);
            this.groupBoxBarcodeMode.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxBarcodeMode.Name = "groupBoxBarcodeMode";
            this.groupBoxBarcodeMode.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxBarcodeMode.Size = new System.Drawing.Size(352, 145);
            this.groupBoxBarcodeMode.TabIndex = 15;
            this.groupBoxBarcodeMode.TabStop = false;
            this.groupBoxBarcodeMode.Text = "Barcode Mode";
            // 
            // radioButtonCode128
            // 
            this.radioButtonCode128.AutoSize = true;
            this.radioButtonCode128.Location = new System.Drawing.Point(21, 97);
            this.radioButtonCode128.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonCode128.Name = "radioButtonCode128";
            this.radioButtonCode128.Size = new System.Drawing.Size(17, 16);
            this.radioButtonCode128.TabIndex = 3;
            this.radioButtonCode128.UseVisualStyleBackColor = true;
            // 
            // radioButtonEAN13
            // 
            this.radioButtonEAN13.AutoSize = true;
            this.radioButtonEAN13.Location = new System.Drawing.Point(21, 67);
            this.radioButtonEAN13.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonEAN13.Name = "radioButtonEAN13";
            this.radioButtonEAN13.Size = new System.Drawing.Size(17, 16);
            this.radioButtonEAN13.TabIndex = 3;
            this.radioButtonEAN13.UseVisualStyleBackColor = true;
            // 
            // radioButtonAuto
            // 
            this.radioButtonAuto.AutoSize = true;
            this.radioButtonAuto.Checked = true;
            this.radioButtonAuto.Location = new System.Drawing.Point(21, 36);
            this.radioButtonAuto.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAuto.Name = "radioButtonAuto";
            this.radioButtonAuto.Size = new System.Drawing.Size(17, 16);
            this.radioButtonAuto.TabIndex = 3;
            this.radioButtonAuto.TabStop = true;
            this.radioButtonAuto.UseVisualStyleBackColor = true;
            this.radioButtonAuto.CheckedChanged += new System.EventHandler(this.radioButtonAuto_CheckedChanged);
            // 
            // groupBoxApplication
            // 
            this.groupBoxApplication.Controls.Add(this.labelCurrency);
            this.groupBoxApplication.Controls.Add(this.comboBoxStore);
            this.groupBoxApplication.Controls.Add(this.buttonSaveApplicationSettings);
            this.groupBoxApplication.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxApplication.Controls.Add(this.labelStore);
            this.groupBoxApplication.Controls.Add(this.labelCompany);
            this.groupBoxApplication.Controls.Add(this.textBoxCompany);
            this.groupBoxApplication.Controls.Add(this.panel1);
            this.groupBoxApplication.Location = new System.Drawing.Point(16, 4);
            this.groupBoxApplication.Name = "groupBoxApplication";
            this.groupBoxApplication.Size = new System.Drawing.Size(352, 240);
            this.groupBoxApplication.TabIndex = 16;
            this.groupBoxApplication.TabStop = false;
            this.groupBoxApplication.Text = "Aplication";
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrency.Location = new System.Drawing.Point(254, 131);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(72, 17);
            this.labelCurrency.TabIndex = 13;
            this.labelCurrency.Text = "0.000-N-";
            this.labelCurrency.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(122, 102);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(211, 24);
            this.comboBoxStore.TabIndex = 12;
            this.comboBoxStore.SelectedValueChanged += new System.EventHandler(this.comboBoxStore_SelectedValueChanged);
            // 
            // buttonSaveApplicationSettings
            // 
            this.buttonSaveApplicationSettings.Location = new System.Drawing.Point(209, 161);
            this.buttonSaveApplicationSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveApplicationSettings.Name = "buttonSaveApplicationSettings";
            this.buttonSaveApplicationSettings.Size = new System.Drawing.Size(136, 28);
            this.buttonSaveApplicationSettings.TabIndex = 11;
            this.buttonSaveApplicationSettings.TabStop = false;
            this.buttonSaveApplicationSettings.Text = "Save Application Settings";
            this.buttonSaveApplicationSettings.UseVisualStyleBackColor = true;
            this.buttonSaveApplicationSettings.Click += new System.EventHandler(this.buttonSaveApplicationSettings_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonLSOne);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonNAV);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 33);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // radioButtonLSOne
            // 
            this.radioButtonLSOne.AutoSize = true;
            this.radioButtonLSOne.Location = new System.Drawing.Point(3, 3);
            this.radioButtonLSOne.Name = "radioButtonLSOne";
            this.radioButtonLSOne.Size = new System.Drawing.Size(77, 21);
            this.radioButtonLSOne.TabIndex = 0;
            this.radioButtonLSOne.TabStop = true;
            this.radioButtonLSOne.Text = "LS One";
            this.radioButtonLSOne.UseVisualStyleBackColor = true;
            // 
            // radioButtonNAV
            // 
            this.radioButtonNAV.AutoSize = true;
            this.radioButtonNAV.Location = new System.Drawing.Point(86, 3);
            this.radioButtonNAV.Name = "radioButtonNAV";
            this.radioButtonNAV.Size = new System.Drawing.Size(75, 21);
            this.radioButtonNAV.TabIndex = 1;
            this.radioButtonNAV.TabStop = true;
            this.radioButtonNAV.Text = "LS Nav";
            this.radioButtonNAV.UseVisualStyleBackColor = true;
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Location = new System.Drawing.Point(74, 105);
            this.labelStore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(42, 17);
            this.labelStore.TabIndex = 1;
            this.labelStore.Text = "Store";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(49, 75);
            this.labelCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(67, 17);
            this.labelCompany.TabIndex = 1;
            this.labelCompany.Text = "Company";
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Location = new System.Drawing.Point(122, 72);
            this.textBoxCompany.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(211, 22);
            this.textBoxCompany.TabIndex = 1;
            this.textBoxCompany.TextChanged += new System.EventHandler(this.textBoxCompany_TextChanged);
            this.textBoxCompany.Leave += new System.EventHandler(this.textBoxCompany_Leave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(200, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 28);
            this.panel1.TabIndex = 17;
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(962, 490);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(95, 50);
            this.btnPrintTest.TabIndex = 17;
            this.btnPrintTest.Text = "Print Test";
            this.btnPrintTest.UseVisualStyleBackColor = true;
            this.btnPrintTest.Click += new System.EventHandler(this.btnPrintTest_Click);
            // 
            // tbSample
            // 
            this.tbSample.Location = new System.Drawing.Point(792, 487);
            this.tbSample.Name = "tbSample";
            this.tbSample.Size = new System.Drawing.Size(164, 22);
            this.tbSample.TabIndex = 18;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(792, 515);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(164, 22);
            this.tbDesc.TabIndex = 18;
            // 
            // setDefault
            // 
            this.setDefault.Location = new System.Drawing.Point(962, 546);
            this.setDefault.Name = "setDefault";
            this.setDefault.Size = new System.Drawing.Size(95, 31);
            this.setDefault.TabIndex = 19;
            this.setDefault.Text = "Set Default";
            this.setDefault.UseVisualStyleBackColor = true;
            this.setDefault.Click += new System.EventHandler(this.setDefault_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(861, 543);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 31);
            this.button1.TabIndex = 19;
            this.button1.Text = "Clean Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(1075, 657);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setDefault);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbSample);
            this.Controls.Add(this.btnPrintTest);
            this.Controls.Add(this.groupBoxApplication);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.groupBoxBarcodeMode.ResumeLayout(false);
            this.groupBoxBarcodeMode.PerformLayout();
            this.groupBoxApplication.ResumeLayout(false);
            this.groupBoxApplication.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxApplication;
        private System.Windows.Forms.Button buttonSaveApplicationSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonLSOne;
        private System.Windows.Forms.RadioButton radioButtonNAV;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Label labelStore;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintTest;
        private System.Windows.Forms.TextBox tbSample;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button setDefault;
        private System.Windows.Forms.Button button1;
    }
}