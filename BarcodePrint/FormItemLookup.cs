using BarcodePrinter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodePrinter
{
    public partial class FormItemLookup : Form
    {
        private DataTable ItemResult;
        System.Windows.Forms.DataGridViewCellStyle dGVCPriceStyle = new System.Windows.Forms.DataGridViewCellStyle();

        public String Result { get; set; }

        public FormItemLookup()
        {
            InitializeComponent();
            dataGridViewItems.AutoGenerateColumns = false;
            SetStyle();
        }

        private void SetStyle()
        {
            dGVCPriceStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            var currency = MyOledbHandler.GetStoreCurrency(Settings.Default.Store, Settings.Default.Company);            
            dGVCPriceStyle.Format = BarcodeLabel.GetFormat(currency);
            this.SALESPRICEINCLTAX.DefaultCellStyle = dGVCPriceStyle;
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        { }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.ItemResult = getDiscription(textBoxFilter.Text.Trim());
                    this.dataGridViewItems.DataSource = ItemResult;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        internal System.Data.DataTable getDiscription(string value)
        {
            DataTable itemDiscription = new DataTable();

            using (MyOledbHandler connection = new MyOledbHandler())
            {
                try
                {
                    itemDiscription = connection.getDiscription(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, @"Connection Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #region oldItemQuery
            /*

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("");
            builder.DataSource = BarcodePrinter.Properties.Settings.Default.DataSource;
            builder.UserID = BarcodePrinter.Properties.Settings.Default.UserName;
            builder.Password = BarcodePrinter.Properties.Settings.Default.Password;
            builder.InitialCatalog = BarcodePrinter.Properties.Settings.Default.Database;
            string cons = builder.ToString();
            string cmd = "";
            switch (Properties.Settings.Default.Application)
            {
                case "LSAPPS":
                    cmd = @"SELECT TOP (10) ITM.ITEMID AS                                         ITEM_CODE ,
                ITM.ITEMNAME AS                                       ITEM_NAME ,
                BAR.ITEMBARCODE AS                                    CROSS_REFERENCE ,
                c.CURRENCYCODE AS                                     CURRENCY ,
                ISNULL(DISC.AMOUNTINCLTAX , ITM.SALESPRICEINCLTAX) AS SALESPRICEINCLTAX
FROM RETAILITEM AS ITM INNER JOIN INVENTITEMBARCODE AS BAR ON ITM.ITEMID = BAR.ITEMID
                       LEFT JOIN PRICEDISCTABLE AS DISC ON ITM.ITEMID = DISC.ITEMRELATION
                                                           AND
                                                           bar.UNITID = DISC.UNITID
                       LEFT JOIN COMPANYINFO AS c ON c.KEY_ = 0
WHERE isnull(DISC.ACCOUNTCODE , 2) = 2
      AND
      isnull(DISC.RELATION , 4) = 4
      AND
      ITM.DELETED = 0
      AND
      ( UPPER(ITM.ITEMID) LIKE UPPER(@ITEMID)
        OR
        UPPER(ITM.ITEMNAME) LIKE UPPER(@ITEMNAME) )
ORDER BY ITEM_CODE";
                    break;
                case "NAV":
                    string temp =
                        @"SELECT TOP (10) ITM.[No_] AS                                     ITEM_CODE ,
                ITM.[Description] AS                             ITEM_NAME ,
                BAR.[Barcode No_] AS                             CROSS_REFERENCE ,
                'AED' AS                                         CURRENCY ,
                ISNULL(prc.[Unit Price Including VAT] , 0.00) AS SALESPRICEINCLTAX --,
                --ITM.[Vendor Item No_] AS                         VENDORITEMNO
FROM [dbo].[{0}$Item] AS ITM INNER JOIN [dbo].[{0}$Barcodes] AS BAR ON ITM.No_ = BAR.[Item No_]
                             LEFT JOIN [dbo].[{0}$Sales Price] AS prc ON ITM.No_ = prc.[Item No_]
                             INNER JOIN [dbo].[{0}$Retail Setup] AS pg ON prc.[Sales Code] = pg.[Default Price Group]
WHERE ITM.[No_] LIKE @ITEMID
      OR
      UPPER(ITM.[Description]) LIKE UPPER(@ITEMNAME)
      OR
      UPPER(ITM.[Vendor Item No_]) LIKE UPPER(@ITEMID)
ORDER BY ITEM_CODE";
                    cmd = String.Format(temp,
                        Properties.Settings.Default.Company);
                    break;
                default:
                    cmd = @"SELECT TOP (10) ITM.ITEMID AS                                         ITEM_CODE ,
                ITM.ITEMNAME AS                                       ITEM_NAME ,
                BAR.ITEMBARCODE AS                                    CROSS_REFERENCE ,
                c.CURRENCYCODE AS                                     CURRENCY ,
                ISNULL(DISC.AMOUNTINCLTAX , ITM.SALESPRICEINCLTAX) AS SALESPRICEINCLTAX
FROM RETAILITEM AS ITM INNER JOIN INVENTITEMBARCODE AS BAR ON ITM.ITEMID = BAR.ITEMID
                       LEFT JOIN PRICEDISCTABLE AS DISC ON ITM.ITEMID = DISC.ITEMRELATION
                                                           AND
                                                           bar.UNITID = DISC.UNITID
                       LEFT JOIN COMPANYINFO AS c ON c.KEY_ = 0
WHERE isnull(DISC.ACCOUNTCODE , 2) = 2
      AND
      isnull(DISC.RELATION , 4) = 4
      AND
      ITM.DELETED = 0
      AND
      ( UPPER(ITM.ITEMID) LIKE UPPER(@ITEMID)
        OR
        UPPER(ITM.ITEMNAME) LIKE UPPER(@ITEMNAME) )
ORDER BY ITEM_CODE";
                    break;

            }
            using (SqlConnection connection = new SqlConnection(cons))
            using (SqlCommand command = new SqlCommand(cmd, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ITEMID", value + "%");
                    command.Parameters.AddWithValue("@ITEMNAME", value + "%");
                    SqlDataAdapter adaptor = new SqlDataAdapter(command);
                    adaptor.Fill(itemDiscription);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
            }
            */
            #endregion
            return itemDiscription;
        }

        private void dataGridViewItems_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            try
            {
                this.Result = e.Row.Cells[0].Value.ToString();
                this.Text = e.Row.Cells[1].Value.ToString();
            }
            catch (NullReferenceException) { }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
