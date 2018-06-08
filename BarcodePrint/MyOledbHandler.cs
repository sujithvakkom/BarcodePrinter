using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BarcodePrinter
{
    class MyOledbHandler : IDisposable
    {
        string selectFromLocal =
            @"SELECT TOP (20) item_master.item_code, item_master.item_desc, cross_referance.barcode " +
            @"FROM cross_referance INNER JOIN item_master ON cross_referance.inv_id = item_master.inv_id "+
            @"WHERE (item_master.item_code LIKE @key_item) OR (cross_referance.barcode LIKE @key_barcode)";

        private String configFile = @"service";
        System.Windows.Forms.IWin32Window _owner;
        private System.Data.OleDb.OleDbConnectionStringBuilder StringBuilder;
        public System.Windows.Forms.IWin32Window Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }
        public static string DataSource
        {
            get
            {
                return
                    BarcodePrinter.Properties.Settings.Default.ConnectionName;
            }
        }
        public MyOledbHandler()
        {
            StringBuilder = new OleDbConnectionStringBuilder("provider=MSDAORA;USER ID=xxgs/xxgs; PERSIST SECURITY INFO=FALSE");
            StringBuilder["Data Source"] = DataSource;
            oDRDBConnectionString = StringBuilder.ConnectionString;
        }


        String oDRDBConnectionString;
        private System.Data.OleDb.OleDbCommand cmd;
        private System.Data.OleDb.OleDbConnection connection;
        //private String insertCommend = "INSERT INTO xxgs_pos_show_credit_card( BANK_CODE,TERM_ID,BATCH_ID,CARD_NUMBER,CARD_TYPE,CARD_MODE,CARD_RATE,INV_AMT,NET_AMT)" +
        //    "VALUES( :Bank_Code,:Term_id,:Batch_id, :Card_number, :Card_type, :Card_mode, :Card_rate, :Inv_amt, :Net_amt)";

        private String getItemCommand = "SELECT item.item_code, SUBSTR(item.item_name,1,40) AS item_name, barcode.CROSS_REFERENCE AS cross_reference FROM xxgs.xxgs_pos_stocks_v item, XXGS.XXGS_POS_BAR_CODE_V barcode WHERE ((REPLACE(item.item_code,'-','') LIKE ?) OR (barcode.CROSS_REFERENCE LIKE ?)) AND ROWNUM <= 10 and item.INVENTORY_ITEM_ID = barcode.INVENTORY_ITEM_ID ORDER BY item_code ";

        internal System.Data.DataTable getDiscriptionLocal(string value)
        {
            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                connection.ConnectionString = Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = selectFromLocal;
                    cmd.Parameters.AddWithValue("@key_item", value+"%");
                    cmd.Parameters.AddWithValue("@key_barcode", value+"%");
                    using (SqlDataAdapter adptor = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adptor.Fill(table);
                        return table;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return null;
        }
        internal System.Data.DataTable getDiscription(string value)
        {
            DataTable itemDiscription = new DataTable();
            /*
            try
            {
                connection = new OleDbConnection(oDRDBConnectionString);
                connection.Open();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception)
            {

            }
            cmd = new OleDbCommand(getItemCommand, connection);
            cmd.Parameters.AddWithValue("item_code", value + '%');
            cmd.Parameters.AddWithValue("cross_reference", value + '%');
            OleDbDataAdapter OleDbDataAdapter;
            OleDbDataAdapter = new OleDbDataAdapter(cmd);
            try
            {
                OleDbDataAdapter.Fill(itemDiscription);
            }
            catch (Exception ex)
            {
                //throw(new Exception(ex.Message));
                MessageBox.Show(ex.Message);
            }
            try
            {
                connection.Close();
            }
            catch (Exception)
            {
            }
             * */
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("");
            builder.DataSource = BarcodePrinter.Properties.Settings.Default.DataSource;
            builder.UserID = BarcodePrinter.Properties.Settings.Default.UserName;
            builder.Password = BarcodePrinter.Properties.Settings.Default.Password;
            builder.InitialCatalog = BarcodePrinter.Properties.Settings.Default.Database;
            string cons = builder.ToString();
            string cmd = @"SELECT TOP (10) ITM.ITEMID AS ITEM_CODE,
                ITM.ITEMNAME AS ITEM_NAME,
                BAR.ITEMBARCODE AS CROSS_REFERENCE,
			 'AED' as CURRENCY,
                ISNULL(DISC.AMOUNTINCLTAX, ITM.SALESPRICEINCLTAX) AS SALESPRICEINCLTAX
FROM RETAILITEM ITM
     INNER JOIN INVENTITEMBARCODE BAR ON ITM.ITEMID = BAR.ITEMID
     LEFT JOIN PRICEDISCTABLE DISC ON ITM.ITEMID = DISC.ITEMRELATION
                                      AND bar.UNITID = DISC.UNITID
WHERE isnull(DISC.ACCOUNTCODE, 2) = 2
      AND isnull(DISC.RELATION, 4) = 4
      AND ITM.DELETED = 0
      AND (ITM.ITEMID LIKE @ITEMID
           OR BAR.ITEMBARCODE LIKE @ITEMBARCODE)
ORDER BY ITEM_CODE";
            using (SqlConnection connection = new SqlConnection(cons))
            using (SqlCommand command = new SqlCommand(cmd, connection))
            {
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ITEMID", value+"%");
                    command.Parameters.AddWithValue("@ITEMBARCODE", value+"%");
                    SqlDataAdapter adaptor = new SqlDataAdapter(command);
                    adaptor.Fill(itemDiscription);
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
            }
            return itemDiscription;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (connection != null)
                if (connection.State == ConnectionState.Open)
                    this.connection.Close();
        }

        #endregion


        internal string GetConnection()
        {
            try
            {
                connection = new OleDbConnection(oDRDBConnectionString);
                connection.Open();
                return connection.DataSource;
            }
            catch (Exception)
            {
                return ("Failure in connection");
            }
        }

        internal static SqlConnection TestConnection(string DataSource, string Database, string UserName, string Password, bool p_5)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("");
            builder.DataSource = DataSource;
            builder.UserID = UserName;
            builder.Password = Password;
            builder.InitialCatalog = Database;
            SqlConnection connection = new SqlConnection(builder.ToString());
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Failed", ex);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return connection;
        }
    }
}
