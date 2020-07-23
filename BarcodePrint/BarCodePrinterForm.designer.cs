using System;
using System.Windows.Forms;
using BarcodePrinter;
namespace BarCodePrinter
{
    partial class barcodePrinterForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(barcodePrinterForm));
            this.barCodeLabel = new System.Windows.Forms.Label();
            this.numberPrintLabel = new System.Windows.Forms.Label();
            this.barCodeTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.addToPrintListButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.jobListPanel = new System.Windows.Forms.Panel();
            this.selectedDataGridView = new System.Windows.Forms.DataGridView();
            this.itemListForPrint = new System.Data.DataTable();
            this.listLabel = new System.Windows.Forms.Label();
            this.discriptionLabel = new System.Windows.Forms.Label();
            this.discriptionListBox = new System.Windows.Forms.ListBox();
            this.removeListButton = new System.Windows.Forms.Button();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crossreferenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isItemcodePrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isDiscriprionPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noofprintDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listDiscriptionLabel = new System.Windows.Forms.Label();
            this.customeDiscriptionLabel = new System.Windows.Forms.Label();
            this.customeDiscriprionTextBox = new System.Windows.Forms.TextBox();
            this.printerListComboBox = new System.Windows.Forms.ComboBox();
            this.avilablePrintersLabel = new System.Windows.Forms.Label();
            this.modeOfPrinting = new System.Windows.Forms.MenuStrip();
            this.modeOfPrintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gSProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.customBarcodes = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.modeLabel = new System.Windows.Forms.Label();
            this.printModeLabel = new System.Windows.Forms.Label();
            this.barcodePanel = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.synchProgress = new BarcodePrinter.MYProgressView();
            this.buttonItemLookup = new System.Windows.Forms.Button();
            this.jobListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListForPrint)).BeginInit();
            this.modeOfPrinting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // barCodeLabel
            // 
            this.barCodeLabel.AutoSize = true;
            this.barCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barCodeLabel.Location = new System.Drawing.Point(8, 50);
            this.barCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.barCodeLabel.Name = "barCodeLabel";
            this.barCodeLabel.Size = new System.Drawing.Size(134, 17);
            this.barCodeLabel.TabIndex = 0;
            this.barCodeLabel.Text = "Barcode / Item code";
            // 
            // numberPrintLabel
            // 
            this.numberPrintLabel.AutoSize = true;
            this.numberPrintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberPrintLabel.Location = new System.Drawing.Point(32, 81);
            this.numberPrintLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberPrintLabel.Name = "numberPrintLabel";
            this.numberPrintLabel.Size = new System.Drawing.Size(113, 17);
            this.numberPrintLabel.TabIndex = 0;
            this.numberPrintLabel.Text = "Number of prints";
            // 
            // barCodeTextBox
            // 
            this.barCodeTextBox.Location = new System.Drawing.Point(163, 46);
            this.barCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.barCodeTextBox.MaxLength = 13;
            this.barCodeTextBox.Name = "barCodeTextBox";
            this.barCodeTextBox.Size = new System.Drawing.Size(193, 22);
            this.barCodeTextBox.TabIndex = 1;
            this.barCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barCodeTextBox_KeyPress);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Enabled = false;
            this.numberTextBox.Location = new System.Drawing.Point(163, 76);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.numberTextBox.MaxLength = 13;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(193, 22);
            this.numberTextBox.TabIndex = 2;
            this.numberTextBox.EnabledChanged += new System.EventHandler(this.numberTextBox_EnabledChanged);
            this.numberTextBox.TextChanged += new System.EventHandler(this.numberTextBox_TextChanged);
            this.numberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
            // 
            // addToPrintListButton
            // 
            this.addToPrintListButton.Enabled = false;
            this.addToPrintListButton.Location = new System.Drawing.Point(209, 137);
            this.addToPrintListButton.Margin = new System.Windows.Forms.Padding(4);
            this.addToPrintListButton.Name = "addToPrintListButton";
            this.addToPrintListButton.Size = new System.Drawing.Size(148, 28);
            this.addToPrintListButton.TabIndex = 4;
            this.addToPrintListButton.Text = "&Add to Print List";
            this.addToPrintListButton.UseVisualStyleBackColor = true;
            this.addToPrintListButton.Click += new System.EventHandler(this.addToPrintList_Click);
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Location = new System.Drawing.Point(627, 170);
            this.printButton.Margin = new System.Windows.Forms.Padding(4);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(84, 28);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "&Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.EnabledChanged += new System.EventHandler(this.printButton_EnabledChanged);
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // jobListPanel
            // 
            this.jobListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobListPanel.Controls.Add(this.selectedDataGridView);
            this.jobListPanel.Location = new System.Drawing.Point(0, 215);
            this.jobListPanel.Margin = new System.Windows.Forms.Padding(4);
            this.jobListPanel.Name = "jobListPanel";
            this.jobListPanel.Size = new System.Drawing.Size(891, 366);
            this.jobListPanel.TabIndex = 7;
            // 
            // selectedDataGridView
            // 
            this.selectedDataGridView.AllowUserToAddRows = false;
            this.selectedDataGridView.AllowUserToResizeColumns = false;
            this.selectedDataGridView.AllowUserToResizeRows = false;
            this.selectedDataGridView.AutoGenerateColumns = false;
            this.selectedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.selectedDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.selectedDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.selectedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.selectedDataGridView.DataSource = this.itemListForPrint;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.selectedDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.selectedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.selectedDataGridView.Location = new System.Drawing.Point(0, 0);
            this.selectedDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.selectedDataGridView.MinimumSize = new System.Drawing.Size(879, 337);
            this.selectedDataGridView.Name = "selectedDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.selectedDataGridView.RowHeadersVisible = false;
            this.selectedDataGridView.RowHeadersWidth = 50;
            this.selectedDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.selectedDataGridView.RowTemplate.Height = 70;
            this.selectedDataGridView.ShowEditingIcon = false;
            this.selectedDataGridView.Size = new System.Drawing.Size(891, 366);
            this.selectedDataGridView.TabIndex = 3;
            this.selectedDataGridView.MouseLeave += new System.EventHandler(this.selectedDataGridView_MouseLeave);
            this.selectedDataGridView.MouseHover += new System.EventHandler(this.selectedDataGridView_MouseHover);
            // 
            // itemListForPrint
            // 
            this.itemListForPrint.TableName = "Item_For_print";
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listLabel.Location = new System.Drawing.Point(0, 191);
            this.listLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(160, 23);
            this.listLabel.TabIndex = 9;
            this.listLabel.Text = "Barcodes for printing";
            this.listLabel.Visible = false;
            // 
            // discriptionLabel
            // 
            this.discriptionLabel.AutoSize = true;
            this.discriptionLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discriptionLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.discriptionLabel.Location = new System.Drawing.Point(7, 74);
            this.discriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.discriptionLabel.Name = "discriptionLabel";
            this.discriptionLabel.Size = new System.Drawing.Size(0, 18);
            this.discriptionLabel.TabIndex = 10;
            // 
            // discriptionListBox
            // 
            this.discriptionListBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discriptionListBox.FormattingEnabled = true;
            this.discriptionListBox.ItemHeight = 16;
            this.discriptionListBox.Location = new System.Drawing.Point(364, 64);
            this.discriptionListBox.Margin = new System.Windows.Forms.Padding(4);
            this.discriptionListBox.Name = "discriptionListBox";
            this.discriptionListBox.Size = new System.Drawing.Size(485, 100);
            this.discriptionListBox.TabIndex = 8;
            this.discriptionListBox.Visible = false;
            this.discriptionListBox.VisibleChanged += new System.EventHandler(this.discriptionListBox_VisibleChanged);
            this.discriptionListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.discriptionListBox_MouseDoubleClick);
            // 
            // removeListButton
            // 
            this.removeListButton.Enabled = false;
            this.removeListButton.Location = new System.Drawing.Point(719, 170);
            this.removeListButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeListButton.Name = "removeListButton";
            this.removeListButton.Size = new System.Drawing.Size(133, 28);
            this.removeListButton.TabIndex = 6;
            this.removeListButton.Text = "&Remove from list";
            this.removeListButton.UseVisualStyleBackColor = true;
            this.removeListButton.Click += new System.EventHandler(this.removeListButton_Click);
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            // 
            // crossreferenceDataGridViewTextBoxColumn
            // 
            this.crossreferenceDataGridViewTextBoxColumn.Name = "crossreferenceDataGridViewTextBoxColumn";
            // 
            // isItemcodePrint
            // 
            this.isItemcodePrint.Name = "isItemcodePrint";
            // 
            // isDiscriprionPrint
            // 
            this.isDiscriprionPrint.Name = "isDiscriprionPrint";
            // 
            // noofprintDataGridViewTextBoxColumn
            // 
            this.noofprintDataGridViewTextBoxColumn.Name = "noofprintDataGridViewTextBoxColumn";
            // 
            // listDiscriptionLabel
            // 
            this.listDiscriptionLabel.AutoSize = true;
            this.listDiscriptionLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDiscriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listDiscriptionLabel.Location = new System.Drawing.Point(364, 33);
            this.listDiscriptionLabel.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.listDiscriptionLabel.Name = "listDiscriptionLabel";
            this.listDiscriptionLabel.Padding = new System.Windows.Forms.Padding(13, 6, 7, 6);
            this.listDiscriptionLabel.Size = new System.Drawing.Size(312, 33);
            this.listDiscriptionLabel.TabIndex = 9;
            this.listDiscriptionLabel.Text = "ITEM CODE   @  BARCODE,   Description";
            this.listDiscriptionLabel.Visible = false;
            // 
            // customeDiscriptionLabel
            // 
            this.customeDiscriptionLabel.AutoSize = true;
            this.customeDiscriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customeDiscriptionLabel.Location = new System.Drawing.Point(19, 112);
            this.customeDiscriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customeDiscriptionLabel.Name = "customeDiscriptionLabel";
            this.customeDiscriptionLabel.Size = new System.Drawing.Size(130, 17);
            this.customeDiscriptionLabel.TabIndex = 11;
            this.customeDiscriptionLabel.Text = "Custom Description";
            // 
            // customeDiscriprionTextBox
            // 
            this.customeDiscriprionTextBox.Enabled = false;
            this.customeDiscriprionTextBox.Location = new System.Drawing.Point(163, 107);
            this.customeDiscriprionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.customeDiscriprionTextBox.MaxLength = 40;
            this.customeDiscriprionTextBox.Name = "customeDiscriprionTextBox";
            this.customeDiscriprionTextBox.Size = new System.Drawing.Size(193, 22);
            this.customeDiscriprionTextBox.TabIndex = 3;
            this.customeDiscriprionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customeDiscriprionTextBox_KeyPress);
            // 
            // printerListComboBox
            // 
            this.printerListComboBox.Enabled = false;
            this.printerListComboBox.FormattingEnabled = true;
            this.printerListComboBox.Location = new System.Drawing.Point(431, 171);
            this.printerListComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.printerListComboBox.Name = "printerListComboBox";
            this.printerListComboBox.Size = new System.Drawing.Size(189, 24);
            this.printerListComboBox.TabIndex = 12;
            // 
            // avilablePrintersLabel
            // 
            this.avilablePrintersLabel.AutoSize = true;
            this.avilablePrintersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avilablePrintersLabel.Location = new System.Drawing.Point(289, 176);
            this.avilablePrintersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avilablePrintersLabel.Name = "avilablePrintersLabel";
            this.avilablePrintersLabel.Size = new System.Drawing.Size(118, 17);
            this.avilablePrintersLabel.TabIndex = 13;
            this.avilablePrintersLabel.Text = "Available Printers";
            // 
            // modeOfPrinting
            // 
            this.modeOfPrinting.BackColor = System.Drawing.SystemColors.Control;
            this.modeOfPrinting.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.modeOfPrinting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.modeOfPrinting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeOfPrintingToolStripMenuItem,
            this.settingsToolStripMenuItemTools});
            this.modeOfPrinting.Location = new System.Drawing.Point(0, 0);
            this.modeOfPrinting.Name = "modeOfPrinting";
            this.modeOfPrinting.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.modeOfPrinting.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.modeOfPrinting.Size = new System.Drawing.Size(891, 28);
            this.modeOfPrinting.TabIndex = 14;
            // 
            // modeOfPrintingToolStripMenuItem
            // 
            this.modeOfPrintingToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.modeOfPrintingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gSProducts,
            this.customBarcodes});
            this.modeOfPrintingToolStripMenuItem.Name = "modeOfPrintingToolStripMenuItem";
            this.modeOfPrintingToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.modeOfPrintingToolStripMenuItem.Text = "&Mode of Printing >>";
            // 
            // gSProducts
            // 
            this.gSProducts.Checked = true;
            this.gSProducts.CheckOnClick = true;
            this.gSProducts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gSProducts.Name = "gSProducts";
            this.gSProducts.Size = new System.Drawing.Size(199, 26);
            this.gSProducts.Text = "&LS Products";
            this.gSProducts.Click += new System.EventHandler(this.gSProducts_Click);
            // 
            // customBarcodes
            // 
            this.customBarcodes.CheckOnClick = true;
            this.customBarcodes.Name = "customBarcodes";
            this.customBarcodes.Size = new System.Drawing.Size(199, 26);
            this.customBarcodes.Text = "&Custom Barcodes";
            this.customBarcodes.Click += new System.EventHandler(this.customBarcodes_Click);
            // 
            // settingsToolStripMenuItemTools
            // 
            this.settingsToolStripMenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItemSettings});
            this.settingsToolStripMenuItemTools.Name = "settingsToolStripMenuItemTools";
            this.settingsToolStripMenuItemTools.Size = new System.Drawing.Size(56, 24);
            this.settingsToolStripMenuItemTools.Text = "Tools";
            // 
            // settingsToolStripMenuItemSettings
            // 
            this.settingsToolStripMenuItemSettings.Name = "settingsToolStripMenuItemSettings";
            this.settingsToolStripMenuItemSettings.Size = new System.Drawing.Size(137, 26);
            this.settingsToolStripMenuItemSettings.Text = "Settings";
            this.settingsToolStripMenuItemSettings.Click += new System.EventHandler(this.settingsToolStripMenuItemSettings_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.ForeColor = System.Drawing.Color.Maroon;
            this.modeLabel.Location = new System.Drawing.Point(540, 4);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(125, 23);
            this.modeLabel.TabIndex = 15;
            this.modeLabel.Text = "Mode of Print:";
            // 
            // printModeLabel
            // 
            this.printModeLabel.AutoSize = true;
            this.printModeLabel.BackColor = System.Drawing.Color.White;
            this.printModeLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printModeLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.printModeLabel.Location = new System.Drawing.Point(679, 4);
            this.printModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.printModeLabel.Name = "printModeLabel";
            this.printModeLabel.Size = new System.Drawing.Size(0, 23);
            this.printModeLabel.TabIndex = 16;
            // 
            // barcodePanel
            // 
            this.barcodePanel.Location = new System.Drawing.Point(365, 41);
            this.barcodePanel.Margin = new System.Windows.Forms.Padding(4);
            this.barcodePanel.MaximumSize = new System.Drawing.Size(400, 246);
            this.barcodePanel.MinimumSize = new System.Drawing.Size(200, 123);
            this.barcodePanel.Name = "barcodePanel";
            this.barcodePanel.Size = new System.Drawing.Size(200, 123);
            this.barcodePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.barcodePanel.TabIndex = 17;
            this.barcodePanel.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 587);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(891, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip1";
            // 
            // synchProgress
            // 
            this.synchProgress.IsProcessRunning = false;
            this.synchProgress.Location = new System.Drawing.Point(855, 33);
            this.synchProgress.Margin = new System.Windows.Forms.Padding(4);
            this.synchProgress.Name = "synchProgress";
            this.synchProgress.Size = new System.Drawing.Size(20, 18);
            this.synchProgress.TabIndex = 19;
            this.synchProgress.Text = "myProgressView1";
            // 
            // buttonItemLookup
            // 
            this.buttonItemLookup.Location = new System.Drawing.Point(77, 137);
            this.buttonItemLookup.Name = "buttonItemLookup";
            this.buttonItemLookup.Size = new System.Drawing.Size(125, 28);
            this.buttonItemLookup.TabIndex = 20;
            this.buttonItemLookup.Text = "Item Lookup";
            this.buttonItemLookup.UseVisualStyleBackColor = true;
            this.buttonItemLookup.Click += new System.EventHandler(this.buttonItemLookup_Click);
            // 
            // barcodePrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 609);
            this.Controls.Add(this.buttonItemLookup);
            this.Controls.Add(this.synchProgress);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.printModeLabel);
            this.Controls.Add(this.discriptionListBox);
            this.Controls.Add(this.removeListButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.avilablePrintersLabel);
            this.Controls.Add(this.printerListComboBox);
            this.Controls.Add(this.customeDiscriprionTextBox);
            this.Controls.Add(this.customeDiscriptionLabel);
            this.Controls.Add(this.discriptionLabel);
            this.Controls.Add(this.listDiscriptionLabel);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.jobListPanel);
            this.Controls.Add(this.addToPrintListButton);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.barCodeTextBox);
            this.Controls.Add(this.numberPrintLabel);
            this.Controls.Add(this.barCodeLabel);
            this.Controls.Add(this.modeOfPrinting);
            this.Controls.Add(this.barcodePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.modeOfPrinting;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(906, 645);
            this.Name = "barcodePrinterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Printer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.barcodePrinterForm_FormClosing);
            this.Load += new System.EventHandler(this.barcodePrinterForm_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.barcodePrinterForm_HelpRequested);
            this.jobListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemListForPrint)).EndInit();
            this.modeOfPrinting.ResumeLayout(false);
            this.modeOfPrinting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label barCodeLabel;
        private System.Windows.Forms.Label numberPrintLabel;
        private System.Windows.Forms.TextBox barCodeTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button addToPrintListButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Panel jobListPanel;
        private System.Windows.Forms.DataGridView selectedDataGridView;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label discriptionLabel;
        private System.Windows.Forms.ListBox discriptionListBox;
        private System.Windows.Forms.Button removeListButton;
        private System.Data.DataTable itemListForPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn crossreferenceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn noofprintDataGridViewTextBoxColumn;
        private DataGridViewImageColumn barcodePictureDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isItemcodePrint;
        private DataGridViewCheckBoxColumn isDiscriprionPrint;

        private Label listDiscriptionLabel;
        private Label customeDiscriptionLabel;
        private TextBox customeDiscriprionTextBox;
        private ComboBox printerListComboBox;
        private Label avilablePrintersLabel;
        private MenuStrip modeOfPrinting;
        private ToolStripMenuItem modeOfPrintingToolStripMenuItem;
        private ToolStripMenuItem gSProducts;
        private ToolStripMenuItem customBarcodes;
        private Label modeLabel;
        private Label printModeLabel;
        private PictureBox barcodePanel;
        private ToolStripMenuItem settingsToolStripMenuItemTools;
        private ToolStripMenuItem settingsToolStripMenuItemSettings;
        private StatusStrip statusStrip;
        private MYProgressView synchProgress;
        private Button buttonItemLookup;
    }
}

