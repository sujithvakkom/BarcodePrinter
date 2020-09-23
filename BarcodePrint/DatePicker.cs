using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrinter
{
    public partial class DatePicker : Form
    {
        public string SelectedPackingDate { get; private set; }
        public string SelectedExperyDateDate { get; private set; }

        public DatePicker()
        {
            InitializeComponent();
        }

        private void packedDate_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void lblPackedDate_Click(object sender, EventArgs e)
        {

        }

        private void Offset_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, 
                string.Format("Are you sure?\nPacking Date{0}\nExpairy Date{1}", packedDate.SelectionStart.ToShortDateString(), packedDate.SelectionEnd.ToShortDateString())
                , "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.SelectedPackingDate = packedDate.SelectionStart.ToShortDateString();
                this.SelectedExperyDateDate = packedDate.SelectionEnd.ToShortDateString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.SelectedPackingDate = "";
                this.SelectedExperyDateDate = "";
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
            }
        }

        private void Offset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.packedDate.SelectionEnd = this.packedDate.SelectionStart.AddDays(int.Parse(Offset.Text.Trim()));
            }
            catch (Exception) { }
        } 
    }
}