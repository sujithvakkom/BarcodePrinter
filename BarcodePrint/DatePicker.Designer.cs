namespace BarcodePrinter
{
    partial class DatePicker
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
            this.packedDate = new System.Windows.Forms.MonthCalendar();
            this.lblPackedDate = new System.Windows.Forms.Label();
            this.Offset = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // packedDate
            // 
            this.packedDate.Location = new System.Drawing.Point(28, 95);
            this.packedDate.MaxSelectionCount = 1000;
            this.packedDate.Name = "packedDate";
            this.packedDate.TabIndex = 1;
            this.packedDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.packedDate_DateChanged);
            // 
            // lblPackedDate
            // 
            this.lblPackedDate.AutoSize = true;
            this.lblPackedDate.Location = new System.Drawing.Point(23, 55);
            this.lblPackedDate.Name = "lblPackedDate";
            this.lblPackedDate.Size = new System.Drawing.Size(198, 25);
            this.lblPackedDate.TabIndex = 2;
            this.lblPackedDate.Text = "Packing and Expair";
            this.lblPackedDate.Click += new System.EventHandler(this.lblPackedDate_Click);
            // 
            // Offset
            // 
            this.Offset.Location = new System.Drawing.Point(296, 52);
            this.Offset.Name = "Offset";
            this.Offset.Size = new System.Drawing.Size(136, 31);
            this.Offset.TabIndex = 4;
            this.Offset.TextChanged += new System.EventHandler(this.Offset_TextChanged);
            this.Offset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Offset_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(247, 437);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(172, 57);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(53, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(172, 57);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DatePicker
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(486, 527);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.Offset);
            this.Controls.Add(this.lblPackedDate);
            this.Controls.Add(this.packedDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatePicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Date Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar packedDate;
        private System.Windows.Forms.Label lblPackedDate;
        private System.Windows.Forms.TextBox Offset;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}