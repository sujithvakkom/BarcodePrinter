using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrinter
{
    public partial class Authenticate : Form
    {
        public Authenticate()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string pass = @"ADMIN" + now.ToString("ddMMyy");
            string user = this.textBoxUserName.Text.Trim();
            string password = this.textBoxPassword.Text.Trim();
            this.DialogResult =
                (user == @"ADMIN" && password == pass) ? System.Windows.Forms.DialogResult.OK :
                System.Windows.Forms.DialogResult.Cancel;
            if (this.DialogResult == DialogResult.OK) this.Close();
            else labelLoginMessage.Text = @"Login Failed." +pass;
        }
    }
}
