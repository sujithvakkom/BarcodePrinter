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

namespace BarcodePrinter
{
    public partial class FormSettings : Form
    {
        Settings setting;
        struct Settings
        {
            String _Connection;
            String _Printer;
            String _DataSource;
            String _Database;
            String _UserName;
            String _Password;
            int _FontSize;
            bool _PrintOnCommit;
            public String Connection { get { return _Connection; } set { _Connection = value; } }
            public String DataSource { get { return _DataSource; } set { _DataSource = value; } }
            public String Database { get { return _Database; } set { _Database = value; } }
            public String UserName { get { return _UserName; } set { _UserName = value; } }
            public String Password { get { return _Password; } set { _Password = value; } }
            public String Printer { get { return _Printer; } set { _Printer = value; } }
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
            }
        }
        public FormSettings()
        {
            InitializeComponent();
            setting = new Settings(true);
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
                Properties.Settings.Default.Save();
                this.buttonApply.Enabled = false;
                MessageBox.Show(this, "The Settings are applied.","Success");
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Login Failed","Failed");
                this.Close();
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
            if (
                //this.comboBoxConnections.Text == this.setting.Connection &&
               this.checkBoxPrintOnCommit.Checked == this.setting.PrintOnCommit &&
               this.comboBoxPrinters.Text == this.setting.Printer &&
               this.textBoxFontSize.Text == this.setting.FontSize.ToString() &&
               this.textBoxDataSource.Text == this.setting.DataSource.ToString() &&
               this.textBoxDatabase.Text == this.setting.Database.ToString() &&
               this.textBoxUserName.Text == this.setting.UserName.ToString() &&
               this.textBoxPassword.Text == this.setting.Password.ToString())
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
    }
}