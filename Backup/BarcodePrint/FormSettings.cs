using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BarcodePrinter
{
    public partial class FormSettings : Form
    {
        Settings setting;
        struct Settings
        {
            String _Connection;
            String _Printer;
            int _FontSize;
            public String Connection { get { return _Connection; } set { _Connection = value; } }
            public String Printer { get { return _Printer; } set { _Printer = value; } }
            public int FontSize { get { return _FontSize; } set { _FontSize = value; } }
            public Settings(Boolean x)
            {
                _Connection = Properties.Settings.Default.ConnectionName;
                _Printer = Properties.Settings.Default.DefaultPrinterName;
                _FontSize = Properties.Settings.Default.FontSize;
            }
        }
        public FormSettings()
        {
            InitializeComponent();
            setting = new Settings(true);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            OracelVersionHandler ver = new OracelVersionHandler();
            List<string> names = ver.LoadTNSNames();

            if (names.Count > 0)
                this.comboBoxConnections.Items.AddRange(names.ToArray());
            else
                this.comboBoxConnections.DropDownStyle = ComboBoxStyle.Simple;
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(printer);
            }
            comboBoxPrinters.SelectedItem = Properties.Settings.Default.DefaultPrinterName;
            comboBoxConnections.SelectedItem = Properties.Settings.Default.ConnectionName;
            textBoxFontSize.Text = Properties.Settings.Default.FontSize.ToString();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.DefaultPrinterName =
                    this.comboBoxPrinters.SelectedItem.ToString();
            }
            catch (Exception) { }
            try
            {

                Properties.Settings.Default.ConnectionName =
                    this.comboBoxConnections.Text;
            }
            catch (Exception) { }
            Int16 temp;
            try
            {

                Int16.TryParse(this.textBoxFontSize.Text, out temp);
                Properties.Settings.Default.FontSize = (int)temp;
            }
            catch (Exception) { }
            Properties.Settings.Default.Save();
            this.buttonApply.Enabled = false;
            MessageBox.Show(this, "The Settinngs are applied.");
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
               this.comboBoxConnections.Text == this.setting.Connection &&
               this.comboBoxPrinters.Text == this.setting.Printer &&
               this.textBoxFontSize.Text == this.setting.FontSize.ToString())
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
    }
}