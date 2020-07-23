using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using BarcodePrinter;
using System.Collections;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;

namespace BarCodePrinter
{
    public partial class barcodePrinterForm : Form
    {
        public DataTable discriptionInstence = new DataTable();
        Barcode x;
        private ArrayList discriptionList = new ArrayList();
        private Description item = new Description("", "", "");
        private Barcode temp;
        private List<Description> list = new List<Description>(5);
        private bool alreadyFocused = false;
        private ToolTip barcodeTextBoxToolTip = new ToolTip();
        private ToolTip discriptionListBoxToolTip = new ToolTip();
        private ToolTip removeItemButtonToolTip = new ToolTip();
        private ToolTip printingListDataGridViewToolTip = new ToolTip();
        private ToolTip addToListButtonToolTip = new ToolTip();
        private ToolTip printButtonToolTip = new ToolTip();
        private ToolTip numnerOfPrintTextBoxToolTip = new ToolTip();
        private ToolTip connectionDetailToolTip = new ToolTip();
        PrinterSettings defaultPrinterSettings;
        private BarcodePrinter.ModeOfPrinting modeOfPrintingNow;
        public barcodePrinterForm()
        {
            list = new List<Description>(5);
            item.itemChanged += new Description.ItemChanged(item_itemChanged);
            item.itemCleared += new Description.ItemClearedDelegate(item_itemCleared);
            this.MaximizeBox = false;
            InitializeComponent();
            this.itemListForPrint.TableName = "Item_For_print";
            this.itemListForPrint.Columns.Add("ptint_item", typeof(bool));
            this.itemListForPrint.Columns.Add("item_code", typeof(String));
            this.itemListForPrint.Columns.Add("print_name", typeof(bool));
            this.itemListForPrint.Columns.Add("item_name", typeof(String));
            this.itemListForPrint.Columns.Add("barcode", typeof(String));
            this.itemListForPrint.Columns.Add("#print", typeof(int));
            this.itemListForPrint.Columns.Add("barcode_picture", typeof(Image));
            this.itemListForPrint.Columns.Add("header", typeof(Barcode));
            this.itemListForPrint.Columns.Add("currency", typeof(string));
            this.itemListForPrint.Columns.Add("price", typeof(decimal));
            this.itemListForPrint.ColumnChanged += new DataColumnChangeEventHandler(itemListForPrint_ColumnChanged);
            this.itemListForPrint.RowChanged += new DataRowChangeEventHandler(itemListForPrint_RowChanged);
            this.itemListForPrint.RowDeleted += new DataRowChangeEventHandler(itemListForPrint_RowDeleted);
            //this.itemListForPrint.Columns.Add("barcode_picture", typeof(Image));
            initSelecetedDataGridView();
            this.selectedDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(selectedDataGridView_KeyDown);
            this.selectedDataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(selectedDataGridView_CellMouseClick);
            this.selectedDataGridView.DataError += new DataGridViewDataErrorEventHandler(selectedDataGridView_DataError);
            this.discriptionListBox.KeyPress += new KeyPressEventHandler(discriptionListBox_KeyPress);
            this.barCodeTextBox.GotFocus += textBox1_GotFocus;
            this.barCodeTextBox.MouseUp += textBox1_MouseUp;
            this.barCodeTextBox.Leave += textBox1_Leave;
            this.numberTextBox.GotFocus += textBox1_GotFocus;
            this.numberTextBox.MouseUp += textBox1_MouseUp;
            this.numberTextBox.Leave += textBox1_Leave;
            defaultPrinterSettings = new PrinterSettings();
            #region ToolTips
            barcodeTextBoxToolTip.SetToolTip(this.barCodeTextBox,
                "Enter the barcode or the item code preceded by Enter Key");
            barcodeTextBoxToolTip.UseFading = true;
            barcodeTextBoxToolTip.InitialDelay = 1;
            discriptionListBoxToolTip.SetToolTip(this.discriptionListBox,
                "Select the item press Enter or Double Click to Enter the number of prints");
            discriptionListBoxToolTip.UseFading = true;
            discriptionListBoxToolTip.InitialDelay = 1;
            removeItemButtonToolTip.SetToolTip(removeListButton,
                "Remove current selected printing job");
            removeItemButtonToolTip.UseFading = true;
            removeItemButtonToolTip.InitialDelay = 1;
            printingListDataGridViewToolTip.SetToolTip(selectedDataGridView,
                "Printing Job List.\nPress enter to edit the number of print.\nPress delete to delete.");
            printingListDataGridViewToolTip.UseFading = true;
            printingListDataGridViewToolTip.InitialDelay = 1;
            addToListButtonToolTip.SetToolTip(addToPrintListButton,
                "Add the job to current print list.");
            addToListButtonToolTip.UseFading = true;
            addToListButtonToolTip.InitialDelay = 1;
            printButtonToolTip.SetToolTip(printButton,
                "Print the current job profile.");
            printButtonToolTip.UseFading = true;
            printButtonToolTip.InitialDelay = 5;
            numnerOfPrintTextBoxToolTip.SetToolTip(numberTextBox,
                "Enter the number of prints.");
            numnerOfPrintTextBoxToolTip.UseFading = true;
            numnerOfPrintTextBoxToolTip.InitialDelay = 1;
            connectionDetailToolTip.SetToolTip(this.modeLabel,
                GetConnectionDetail());
            connectionDetailToolTip.UseFading = true;
            connectionDetailToolTip.InitialDelay = 1;
            #endregion
            BarcodePrinter.Properties.Settings.Default.PrinterChanged +=
                new BarcodePrinter.Properties.Settings.PrinterChangedHandeler(Default_PrinterChanged);

            FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "BarcodePrinter.exe"));
            this.Text+=(" "+ FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "BarcodePrinter.exe")).ProductVersion);
        }
        private string GetConnectionDetail()
        {
            string conn;
            using (MyOledbHandler handeler = new MyOledbHandler())
            {
                conn = handeler.GetConnection();
            }
            return conn;
        }
        void Default_PrinterChanged()
        {
            this.printerListComboBox.SelectedItem = BarcodePrinter.Properties.Settings.Default.DefaultPrinterName;
        }
        void itemListForPrint_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            bool flag = this.itemListForPrint.Rows.Count > 0;
            if (!flag)
            {
                this.printButton.Enabled = flag;
                this.removeListButton.Enabled = flag;
                this.barcodePanel.Image = null;
            }
        }
        void itemListForPrint_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if ((e.Column.Caption == "ptint_item") || (e.Column.Caption == "print_name"))
            {
                temp = (Barcode)(e.Row["header"]);
                temp.DisplayDiscription = (bool)e.Row["print_name"];
                temp.DisplayItemcode = (bool)e.Row["ptint_item"];
                e.Row["barcode_picture"] = (Image)temp;
            }
            else if (e.Column.Caption == "header")
            {
                temp = (Barcode)(e.Row["header"]);
            }
        }
        void discriptionListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.discriptionListBox_MouseDoubleClick(this.discriptionListBox, new System.Windows.Forms.MouseEventArgs(MouseButtons.Left, 2, 1, 1, 1));
        }
        void textBox1_Leave(object sender, EventArgs e)
        {
            alreadyFocused = false;
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            // Select all text only if the mouse isn't down.
            // This makes tabbing to the textbox give focus.
            if (MouseButtons == MouseButtons.None)
            {
                this.barCodeTextBox.SelectAll();
                alreadyFocused = true;
            }
        }
        void textBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Web browsers like Google Chrome select the text on mouse up.
            // They only do it if the textbox isn't already focused,
            // and if the user hasn't selected all text.
            if (!alreadyFocused && this.barCodeTextBox.SelectionLength == 0)
            {
                alreadyFocused = true;
                this.barCodeTextBox.SelectAll();
            }
        }
        void selectedDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        void selectedDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool val;
            try
            {
                if (!((selectedDataGridView.SelectedCells[0].ColumnIndex == 0) || (selectedDataGridView.SelectedCells[0].ColumnIndex == 2)))
                {
                    this.barcodePanel.Controls.Clear();
                }
                else
                {
                    val = (bool)selectedDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    selectedDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !val;
                }
                this.barcodePanel.Image = (Image)itemListForPrint.Rows[selectedDataGridView.SelectedCells[0].RowIndex][6];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (e.RowIndex > 0 && e.RowIndex < selectedDataGridView.RowCount)
                selectedDataGridView.Rows[e.RowIndex].Selected = true;
        }
        void selectedDataGridView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("Enter number of prints");
                try
                {
                    selectedDataGridView.CurrentCell = selectedDataGridView.SelectedRows[0].Cells[5];
                }
                catch (Exception)
                {
                    return;
                }
                selectedDataGridView.BeginEdit(true);
            }
            if (e.KeyCode != Keys.Delete)
                e.Handled = true;
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete the document?", "Delete from print list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    e.Handled = true;
                else
                    try
                    {
                        if (selectedDataGridView.SelectedRows.Count > 0)
                            this.selectedDataGridView.Rows.Remove(selectedDataGridView.SelectedRows[0]);
                        else
                            this.selectedDataGridView.Rows.Remove(selectedDataGridView.Rows[0]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                e.Handled = true;
            }
        }
        void itemListForPrint_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bool flag = selectedDataGridView.Rows.Count > 0;
            this.printButton.Enabled = flag;
            this.removeListButton.Enabled = flag;
            if (flag)
            {
                this.barcodePanel.Controls.Clear();
            }
        }
        bool item_itemCleared(EventArgument e)
        {
            discriptionListBox.Visible = false;
            this.barCodeTextBox.Text = "";
            this.numberTextBox.Text = "";
            return true;
        }
        bool item_validForPrint(string e)
        {
            int i;
            Int32.TryParse(e, out i);
            bool f = i > 0;
            this.numberTextBox.Enabled = f;
            this.addToPrintListButton.Enabled = f;
            return (f);
        }
        void item_itemChanged(Description item)
        {
            item.AddToPrintList = false;
            if (item.SearchCode != "")
            {
                using (MyOledbHandler connection = new MyOledbHandler())
                {
                    try
                    {
                        discriptionInstence = connection.getDiscription(item.SearchCode);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, @"Connection Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            list.Clear();
            for (int i = 0; i < discriptionInstence.Rows.Count; i++)
            {
                list.Add(new Description(discriptionInstence.Rows[i][0].ToString(),
                    discriptionInstence.Rows[i][1].ToString(),
                    discriptionInstence.Rows[i][2].ToString())
                {
                    Currency = discriptionInstence.Rows[i][3].ToString(),
                    Price = Decimal.Parse(discriptionInstence.Rows[i][4].ToString())
                });
            }
            this.discriptionListBox.DataSource = null;
            this.discriptionListBox.DataSource = list;
            discriptionListBox.Show();
        }
        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Return)
            {
                this.addToPrintList_Click(addToPrintListButton, new EventArgs());
            }
        }
        //Item Search
        private void barCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogResult result = System.Windows.Forms.DialogResult.No;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.numberTextBox.Enabled = false;
            this.numberTextBox.Text = "";
            //if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (modeOfPrintingNow == ModeOfPrinting.LSProduct)
                {
                    item.SearchCode = barCodeTextBox.Text.Replace("-", "").Trim();
                    if (discriptionListBox.Items.Count > 0)
                    {
                        discriptionListBox.Focus();
                        discriptionListBox.SelectedIndex = 0;
                    }
                    else
                    {
                        if (this.barCodeTextBox.Text.Trim().Length == 13)
                        {
                            //DialogResult result;
                            result = MessageBox.Show("Item does not exists.\nDo you want to print the Barcode?",
                                "Item not in found.",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation);
                            item.copy(new Description(this.barCodeTextBox.Text.Trim(),
                                "",
                                this.barCodeTextBox.Text.Trim()));
                            this.numberTextBox.Enabled = true;
                            this.numberTextBox.Text = "1";
                            item.AddToPrintList = true;
                            this.numberTextBox.Focus();
                        }
                    }
                }
                else
                {
                    try
                    {
                        Description description = Description.getCustomeItem(this.barCodeTextBox.Text.Trim());
                        if (description == null)
                        {
                            description = new Description(this.barCodeTextBox.Text.Trim(),
                                "",
                                this.barCodeTextBox.Text.Trim());
                        }
                        this.customeDiscriprionTextBox.Text = description.ItemDiscription;
                        item.copy(description);
                        this.numberTextBox.Enabled = true;
                        this.numberTextBox.Text = "1";
                        item.AddToPrintList = true;
                        this.numberTextBox.Focus();
                        this.discriptionListBox.Visible = false;
                        this.discriptionLabel.Visible = false;
                    }
                    catch (Exception)
                    {
                        result =
                        MessageBox.Show(this, "Unknown error occurred.\nDo you want to Continue?"//ex.Message
                        , "Error", MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.Yes) { 
                        //Print whether any thing happens
                        Description description = new Description(this.barCodeTextBox.Text.Trim(), ""
                            , this.barCodeTextBox.Text.Trim());
                        this.customeDiscriprionTextBox.Text = description.ItemDiscription;
                        item.copy(description);
                        this.numberTextBox.Enabled = true;
                        this.numberTextBox.Text = "1";
                        item.AddToPrintList = true;
                        this.numberTextBox.Focus();
                        this.discriptionListBox.Visible = false;
                        this.discriptionLabel.Visible = false;
                    }
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        
        
        private void discriptionListBox_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            item.copy(list[discriptionListBox.SelectedIndex]);
            this.barCodeTextBox.Text = item.ItemCode.Trim();
            this.numberTextBox.Enabled = true;
            this.numberTextBox.Text = "1";
            item.AddToPrintList = true;
            this.numberTextBox.Focus();
        }
        private void addToPrintList_Click(object sender, EventArgs e)
        {
            if (this.customeDiscriprionTextBox.Text.Trim() == "")
            {
                try
                {
                    this.customeDiscriprionTextBox.Text = item.ItemDiscription;
                }
                catch (Exception)
                {
                    this.customeDiscriprionTextBox.Text = item.ItemDiscription;
                }
            }
            item.ItemDiscription = this.customeDiscriprionTextBox.Text.Trim();
            if (this.modeOfPrintingNow == ModeOfPrinting.CustomeBarcode)
            {
                Description description = new Description(item.Barcode, item.ItemDiscription, item.Barcode);
                try
                {
                    description.insert();
                }
                catch (Exception) { }
            }
            x = new Barcode(item.Barcode, item.ItemDiscription, item.ItemCode);
            x.NumberOfPrint = item.numberOfPrint;
            this.itemListForPrint.Rows.Add(x.DisplayItemcode, item.ItemCode, x.DisplayDiscription,
                 this.customeDiscriprionTextBox.Text.Trim(),
                item.Barcode,
                item.numberOfPrint,
                (Image)x,
                x,item.Currency,item.Price);
            this.selectedDataGridView.Refresh();
            this.customeDiscriprionTextBox.Text = "";
            item.clear();
            if (BarcodePrinter.Properties.Settings.Default.PrintOnCommit)
                printButton_Click(printButton, new EventArgs());
            this.barCodeTextBox.Focus();
        }
        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {
            item.NumberOfPrint = this.numberTextBox.Text.Trim();
        }
        private void removeListButton_Click(object sender, EventArgs e)
        {
            selectedDataGridView_KeyDown(selectedDataGridView, new System.Windows.Forms.KeyEventArgs(Keys.Delete));
            this.barCodeTextBox.Focus();
        }
        internal void initSelecetedDataGridView()
        {
            this.itemcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.printDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.barcodePictureDataGridViewTextBoxColumn = new DataGridViewImageColumn();
            this.selectedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.isItemcodePrint,
            this.itemcodeDataGridViewTextBoxColumn,
                this.isDiscriprionPrint,
            this.itemnameDataGridViewTextBoxColumn,
            this.crossreferenceDataGridViewTextBoxColumn,
            this.noofprintDataGridViewTextBoxColumn,
            this.barcodePictureDataGridViewTextBoxColumn});
            // 
            // isItemcodePrint
            // 
            this.isItemcodePrint.DataPropertyName = "ptint_item";
            this.isItemcodePrint.HeaderText = "";
            this.isItemcodePrint.Name = "ptint_item";
            this.isItemcodePrint.Width = 30;
            this.isItemcodePrint.ReadOnly = false;
            this.isItemcodePrint.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // isItemcodePrint
            // 
            this.isDiscriprionPrint.DataPropertyName = "print_name";
            this.isDiscriprionPrint.HeaderText = "";
            this.isDiscriprionPrint.Name = "print_name";
            this.isDiscriprionPrint.Width = 30;
            this.isDiscriprionPrint.ReadOnly = false;
            this.isDiscriprionPrint.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "item_code";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "Item Code";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.Width = 160;
            this.itemnameDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // crossreferenceDataGridViewTextBoxColumn
            // 
            this.crossreferenceDataGridViewTextBoxColumn.DataPropertyName = "barcode";
            this.crossreferenceDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.crossreferenceDataGridViewTextBoxColumn.Name = "crossreferenceDataGridViewTextBoxColumn";
            this.crossreferenceDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // noofprintDataGridViewTextBoxColumn
            // 
            this.noofprintDataGridViewTextBoxColumn.DataPropertyName = "#print";
            this.noofprintDataGridViewTextBoxColumn.HeaderText = "No. Print";
            this.noofprintDataGridViewTextBoxColumn.Width = 60;
            this.noofprintDataGridViewTextBoxColumn.Name = "noofprintDataGridViewTextBoxColumn";
            this.noofprintDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodePictureDataGridViewTextBoxColumn.DataPropertyName = "barcode_picture";
            this.barcodePictureDataGridViewTextBoxColumn.HeaderText = "Barcode";
            this.barcodePictureDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodePictureDataGridViewTextBoxColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            this.barcodePictureDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                PrintingList itemPrintList = new PrintingList(this.itemListForPrint, this.printerListComboBox.SelectedItem.ToString());
                this.discriptionListBox.Visible = false;
                this.discriptionLabel.Visible = false;
                this.barcodePanel.Controls.Clear();
                this.barCodeTextBox.Focus();
                GC.Collect();
            }
            catch (Exception ex)
            {
                if (ex.Message != @"There is no row at position 0.")
                    MessageBox.Show(this, ex.Message, "Operation failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void barcodePrinterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No ==
                MessageBox.Show(this, "Do you want to close the application?",
                "Application closing.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                e.Cancel = true;
            else
            {
                GC.Collect();
                //Application.Exit();
            }
        }
        private void numberTextBox_EnabledChanged(object sender, EventArgs e)
        {
            this.customeDiscriprionTextBox.Enabled = ((TextBox)sender).Enabled;
            item.validForPrint += new Description.ValidForPrint(item_validForPrint);
        }
        private void discriptionListBox_VisibleChanged(object sender, EventArgs e)
        {
            this.listDiscriptionLabel.Visible = ((ListBox)sender).Visible;
        }
        private void customeDiscriprionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.addToPrintList_Click(printButton, new EventArgs());
            }
        }
        private void printButton_EnabledChanged(object sender, EventArgs e)
        {
            if (((Button)sender).Enabled == true)
            {
                printerListComboBox.Items.Clear();
                //printerListComboBox.Enabled = true;
                foreach (String printer in PrinterSettings.InstalledPrinters)
                {
                    printerListComboBox.Items.Add(printer);
                }
                printerListComboBox.SelectedIndex = printerListComboBox.Items.IndexOf(DefaultPrinter);
                printerListComboBox.Enabled = true;
            }
            else
            {
                printerListComboBox.Enabled = false;
            }
        }
        public PrinterSettings DefaultPrinterSettings
        {
            get
            {
                defaultPrinterSettings.PrinterName = printerListComboBox.SelectedItem.ToString(); ;
                return (defaultPrinterSettings);
            }
        }
        public string DefaultPrinter
        {
            get
            {
                return (BarcodePrinter.Properties.Settings.Default.DefaultPrinterName);
            }
        }
        private void selectedDataGridView_MouseHover(object sender, EventArgs e)
        {
            this.listLabel.Visible = true;
        }
        private void selectedDataGridView_MouseLeave(object sender, EventArgs e)
        {
            this.listLabel.Visible = false;
        }
        private void gSProducts_Click(object sender, EventArgs e)
        {
            this.gSProducts.Checked = true;
            this.customBarcodes.Checked = false;
            modeOfPrintingNow = ModeOfPrinting.LSProduct;
            this.printModeLabel.Text = "LS Products";
        }
        private void customBarcodes_Click(object sender, EventArgs e)
        {
            this.gSProducts.Checked = false;
            this.customBarcodes.Checked = true;
            modeOfPrintingNow = ModeOfPrinting.CustomeBarcode;
            this.printModeLabel.Text = "Custom Barcode";
        }
        private void barcodePrinterForm_Load(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.printModeLabel.Text = "LS Products";
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void barcodePrinterForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, @"..\BarcodePrint\HelpBarcodePrint.chm");
        }
        private void settingsToolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            settings.ShowDialog(this);
        }
        private void synchoronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ItemSynchoronizer sych = new ItemSynchoronizer())
                {
                    sych.SynchStarted += new ItemSynchoronizer.SynchStartedHandeler(sych_SynchStarted);
                    sych.SynchFinished += new ItemSynchoronizer.SynchFinishedHandeler(sych_SynchFinished);
                    Thread thread = new Thread(sych.synch);
                    Program.ThreadPool.Add(thread);
                    thread.Start();
                }
            }
            catch (SynchOnGoingException ex)
            { MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception exception)
            { MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        void sych_SynchStarted()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.synchProgress.IsProcessRunning = true;
                });
            }
        }
        void sych_SynchFinished()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(this, "Synchronization Completed.");
                    this.synchProgress.IsProcessRunning = false;
                });
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                if (this.printButton.Enabled)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    try
                    {
                        PrintingList itemPrintList = new PrintingList(this.itemListForPrint, this.printerListComboBox.SelectedItem.ToString());
                        this.discriptionListBox.Visible = false;
                        this.discriptionLabel.Visible = false;
                        this.barcodePanel.Controls.Clear();
                        this.barCodeTextBox.Focus();
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Operation failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Select Items.", "Message.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonItemLookup_Click(object sender, EventArgs e)
        {
            FormItemLookup lookup = new FormItemLookup();
            if (lookup.ShowDialog(this) == DialogResult.OK) {
                this.barCodeTextBox.Text = lookup.Result;
                this.barCodeTextBox.Focus();
            }
        }
    }
}