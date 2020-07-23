using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using BarCodePrinter;
using System.Data.OleDb;
using System.Threading;
using Com.SharpZebra.Printing;
using System.IO;

namespace BarcodePrinter
{
    public partial class FormSettings : Form
    {
        Settings setting;

        static Thread loadStoreThread;

        /**/
        struct Settings
        {
            String _Connection;
            String _Printer;
            String _DataSource;
            String _Database;
            String _UserName;
            String _Password;
            String _Margin;
            int _FontSize;
            bool _PrintOnCommit;
            private string _EAN13ELN;
            private string _Code128ELN;
            private string _BarcodeMode;
            private string _Application;
            private string _Company;

            public String Connection { get { return _Connection; } set { _Connection = value; } }
            public String DataSource { get { return _DataSource; } set { _DataSource = value; } }
            public String Database { get { return _Database; } set { _Database = value; } }
            public String UserName { get { return _UserName; } set { _UserName = value; } }
            public String Password { get { return _Password; } set { _Password = value; } }
            public String Printer { get { return _Printer; } set { _Printer = value; } }
            public String Margin { get { return _Margin; } set { _Margin = value; } }
            public String EAN13ELN { get { return _EAN13ELN; } set { _EAN13ELN = value; } }
            public String Code128ELN { get { return _Code128ELN; } set { _Code128ELN = value; } }
            public String BarcodeMode { get { return _BarcodeMode; } set { _BarcodeMode = value; } }
            public int FontSize { get { return _FontSize; } set { _FontSize = value; } }
            public bool PrintOnCommit { get { return _PrintOnCommit; } set { _PrintOnCommit = value; } }
            public Settings(Boolean x)
            {
                _Connection = Properties.Settings.Default.ConnectionName;
                _Printer = Properties.Settings.Default.DefaultPrinterName;
                _FontSize = Properties.Settings.Default.FontSize;
                _DataSource = Properties.Settings.Default.DataSource;
                _Database = Properties.Settings.Default.Database;
                _UserName = Properties.Settings.Default.UserName;
                _Password = Properties.Settings.Default.Password;
                _PrintOnCommit = Properties.Settings.Default.PrintOnCommit;
                _Margin = "";
                _EAN13ELN = Properties.Settings.Default.ELNFormatEAN13;
                _Code128ELN = Properties.Settings.Default.ELNFormatCode128;
                _BarcodeMode = Properties.Settings.Default.BarcodeMode;
                _Application = Properties.Settings.Default.Application;
                _Company = Properties.Settings.Default.Company;
            }
        }
        public FormSettings()
        {
            InitializeComponent();
            setting = new Settings(true);
            this.textBoxEAN13Sample.Text = Properties.Resources.SampleEAN13ELN;
            this.textBoxCode128Sample.Text = Properties.Resources.SampleCode128ELN;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            /*
            OracelVersionHandler ver = new OracelVersionHandler();
            List<string> names = ver.LoadTNSNames();

            if (names.Count > 0)
                this.comboBoxConnections.Items.AddRange(names.ToArray());
            else
                this.comboBoxConnections.DropDownStyle = ComboBoxStyle.Simple;
             * */
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(printer);
            }
            comboBoxPrinters.SelectedItem = Properties.Settings.Default.DefaultPrinterName;
            //comboBoxConnections.SelectedItem = Properties.Settings.Default.ConnectionName;
            textBoxFontSize.Text = Properties.Settings.Default.FontSize.ToString();
            textBoxDataSource.Text = Properties.Settings.Default.DataSource.ToString();
            textBoxDatabase.Text = Properties.Settings.Default.Database.ToString();
            textBoxUserName.Text = Properties.Settings.Default.UserName.ToString();
            textBoxPassword.Text = Properties.Settings.Default.Password.ToString();
            this.checkBoxPrintOnCommit.Checked = Properties.Settings.Default.PrintOnCommit;
            this.textBoxEAN13ELN.Text = Properties.Settings.Default.ELNFormatEAN13.ToString();
            this.textBoxCode128ELN.Text = Properties.Settings.Default.ELNFormatCode128.ToString();
            this.Size = new Size(1093, 704);
            this.radioButtonAuto.Text = Properties.Resources.AutoEAN13Code128;
            this.radioButtonEAN13.Text = Properties.Resources.EAN13;
            this.radioButtonCode128.Text = Properties.Resources.Code128;
            this.radioButtonLSOne.Checked = (Properties.Settings.Default.Application == Properties.Resources.DefaultApplication);
            this.radioButtonNAV.Checked = (Properties.Settings.Default.Application != Properties.Resources.DefaultApplication);
            this.textBoxCompany.Text = Properties.Settings.Default.Company;
            foreach (var x in this.groupBoxBarcodeMode.Controls)
            {
                if (x.GetType() == typeof(RadioButton))
                    ((RadioButton)x).Checked = Properties.Settings.Default.BarcodeMode == ((Control)x).Text;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Authenticate Authenticate = new Authenticate();
            DialogResult result = Authenticate.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Properties.Settings.Default.DefaultPrinterName =
                        this.comboBoxPrinters.SelectedItem.ToString();
                }
                catch (Exception) { }
                /*
                try
                {
                    Properties.Settings.Default.ConnectionName =
                        this.comboBoxConnections.Text;
                }
                catch (Exception) { }
                */
                Int16 temp;
                try
                {

                    Int16.TryParse(this.textBoxFontSize.Text, out temp);
                    Properties.Settings.Default.FontSize = (int)temp;
                }
                catch (Exception) { }
                try
                {

                    Properties.Settings.Default.DataSource =
                        this.textBoxDataSource.Text.Trim();
                }
                catch (Exception) { }

                try
                {

                    Properties.Settings.Default.Database =
                        this.textBoxDatabase.Text.Trim();
                }
                catch (Exception) { }

                try
                {

                    Properties.Settings.Default.UserName =
                        this.textBoxUserName.Text.Trim();
                }
                catch (Exception) { }

                try
                {

                    Properties.Settings.Default.Password =
                        this.textBoxPassword.Text.Trim();
                }
                catch (Exception) { }

                try
                {

                    Properties.Settings.Default.PrintOnCommit =
                        this.checkBoxPrintOnCommit.Checked;
                }
                catch (Exception) { }
                try
                {
                    Properties.Settings.Default.ELNFormatEAN13 = this.textBoxEAN13ELN.Text;
                }
                catch (Exception)
                {

                }
                try
                {
                    Properties.Settings.Default.ELNFormatCode128 = this.textBoxCode128ELN.Text;
                }
                catch (Exception)
                {

                }
                try
                {

                    //this.radioButtonAuto.Text = Properties.Resources.AutoEAN13Code128;
                    //this.radioButtonEAN13.Text = Properties.Resources.EAN13;
                    //this.radioButtonCode128.Text = Properties.Resources.Code128;
                    Properties.Settings.Default.BarcodeMode =
                        this.radioButtonAuto.Checked ? Properties.Resources.AutoEAN13Code128 :
                        this.radioButtonEAN13.Checked ? Properties.Resources.EAN13 :
                        this.radioButtonCode128.Checked ? Properties.Resources.EAN13 :
                        Properties.Resources.AutoEAN13Code128;
                }
                catch (Exception)
                {

                }
                try
                {
                    Properties.Settings.Default.Application =
                        this.radioButtonLSOne.Checked ? "LSONE" : this.radioButtonNAV.Checked ? "NAV" :
                        Properties.Resources.DefaultApplication;
                    Properties.Settings.Default.Company = this.textBoxCompany.Text.Trim();
                }
                catch (Exception)
                {

                }
                Properties.Settings.Default.Save();
                this.buttonApply.Enabled = false;
                MessageBox.Show(this, "The Settings are applied.", "Success");
            }
            else
            {
                MessageBox.Show(this, "Login Failed", "Failed");
            }
        }

        private void textBoxFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFontSize_Enter(object sender, EventArgs e)
        {
            this.textBoxFontSize.SelectAll();
        }

        private void textBoxFontSize_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBoxFontSize.SelectAll();
        }

        private void comboBoxConnections_TextChanged(object sender, EventArgs e)
        {
            var bModeSettingCur =
                        this.radioButtonAuto.Checked ? Properties.Resources.AutoEAN13Code128 :
                        this.radioButtonEAN13.Checked ? Properties.Resources.EAN13 :
                        this.radioButtonCode128.Checked ? Properties.Resources.EAN13 :
                        Properties.Resources.AutoEAN13Code128;
            if (
               //this.comboBoxConnections.Text == this.setting.Connection &&
               this.checkBoxPrintOnCommit.Checked == this.setting.PrintOnCommit &&
               this.comboBoxPrinters.Text == this.setting.Printer &&
               this.textBoxFontSize.Text == this.setting.FontSize.ToString() &&
               this.textBoxDataSource.Text == this.setting.DataSource.ToString() &&
               this.textBoxDatabase.Text == this.setting.Database.ToString() &&
               this.textBoxUserName.Text == this.setting.UserName.ToString() &&
               this.textBoxPassword.Text == this.setting.Password.ToString() &&
               this.textBoxEAN13ELN.Text == this.setting.EAN13ELN.ToString() &&
               this.textBoxCode128ELN.Text == this.setting.Code128ELN.ToString() &&
               bModeSettingCur == this.setting.BarcodeMode.ToString())
            {
                this.buttonApply.Enabled = false;
            }
            else
            {
                this.buttonApply.Enabled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var conn =
                MyOledbHandler.TestConnection(this.textBoxDataSource.Text.Trim(),
                    this.textBoxDatabase.Text.Trim(),
                    this.textBoxUserName.Text.Trim(),
                    this.textBoxPassword.Text.Trim(), true);
                conn.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, "Connection Successful");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(this, ex.InnerException.Message, ex.Message);
                this.buttonApply.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxConnections_TextChanged(sender, e);
        }

        private void buttonSaveApplicationSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Application =
                    this.radioButtonLSOne.Checked ? "LSONE" : this.radioButtonNAV.Checked ? "NAV" :
                    Properties.Resources.DefaultApplication;
                Properties.Settings.Default.Company = this.textBoxCompany.Text.Trim();
                Properties.Settings.Default.Store = this.comboBoxStore.SelectedValue.ToString().Trim();
            }
            catch (Exception)
            {

            }
            Properties.Settings.Default.Save();
            ((Button)sender).Enabled = false;

        }

        private void textBoxCompany_TextChanged(object sender, EventArgs e)
        {
            //this.comboBoxStore.Items.Clear();
            try
            {
                this.comboBoxStore.Cursor = Cursors.WaitCursor;
                if (loadStoreThread != null && loadStoreThread.IsAlive)
                {
                    loadStoreThread.Abort();
                    loadStoreThread = null;
                }
                loadStoreThread = new Thread(() =>
                {
                    try
                    {
                        var stores = MyOledbHandler.GetStores(this.textBoxCompany.Text.Trim());
                        setStoresSafe(stores);
                    }
                    catch (Exception) { setStoresSafe(null); }
                });
                if(!loadStoreThread.IsAlive)
                loadStoreThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    ex.InnerException == null ? "" : ex.InnerException.Message,
                    ex.Message);
                this.buttonSaveApplicationSettings.Enabled = false;
            }
            finally
            {
                this.comboBoxStore.Cursor = Cursors.Default;
            }
        }

        private delegate void SafeCallDelegate(Dictionary<string, string> stores);
        private void setStoresSafe(Dictionary<string, string> stores)
        {
            try
            {
                if (this.comboBoxStore.InvokeRequired)
                {
                    var d = new SafeCallDelegate(setStoresSafe);
                    Invoke(d, new object[] { stores });
                }
                else
                {
                    this.comboBoxStore.DataSource = new BindingSource(stores, null);
                    this.comboBoxStore.DisplayMember = "Key";
                    this.comboBoxStore.ValueMember = "Value";

                    try
                    {
                        this.comboBoxStore.SelectedValue = Properties.Settings.Default.Store;
                    }
                    catch (Exception) { }
                    enableSaveSettings();
                }
            }
            catch (Exception) { }
        }

        private void textBoxCompany_Leave(object sender, EventArgs e)
        {

            //this.comboBoxStore.Items.Clear();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var stores = MyOledbHandler.GetStores(this.textBoxCompany.Text.Trim());
                setStoresSafe(stores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    ex.InnerException == null ? "" : ex.InnerException.Message,
                    ex.Message);
                this.buttonSaveApplicationSettings.Enabled = false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comboBoxStore_SelectedValueChanged(object sender, EventArgs e)
        {
            var currency = MyOledbHandler.GetStoreCurrency(this.comboBoxStore.SelectedValue.ToString(), this.textBoxCompany.Text.Trim());
            var disp = BarcodeLabel.GetFormatedCurrency(currency, decimal.Zero);
            this.labelCurrency.Text = string.IsNullOrEmpty(currency) ? disp + "-N-" : disp+currency;
            enableSaveSettings();
        }

        private void enableSaveSettings()
        {
            if (
                this.textBoxCompany.Text.Trim() != Properties.Settings.Default.Company ||
                this.comboBoxStore.SelectedValue.ToString() != Properties.Settings.Default.Store
                )
                this.buttonSaveApplicationSettings.Enabled = true;
        }

        private void btnPrintTest_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = new ZebraPrinter(this.comboBoxPrinters.SelectedItem.ToString());
                BarcodeLabel label = null;
                label = new BarcodeLabel()
                {
                    Barcode = tbSample.Text,
                    Description = tbDesc.Text,
                    Currency = "XXXX",
                    PriceWithTax = 88888888.555M
                };
                printer.Print(label.ELN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
                this.textBoxEAN13ELN.Text = textBoxEAN13Sample.Text;
            this.textBoxCode128ELN.Text = textBoxCode128Sample.Text;
        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            const string file = "log.txt";
            try
            {
                File.WriteAllText(Path.GetFullPath(file), String.Empty);
            }
            catch (Exception) { }
        }
    }
}