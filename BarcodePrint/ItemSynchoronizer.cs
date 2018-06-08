using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace BarcodePrinter
{
    internal class SynchOnGoingException : Exception
    {
        public SynchOnGoingException(string message):base(message)
        {
        }
    }
    /*
     * 'Bar Code Number'
     * 'Active'
SELECT DISTINCT item.inventory_item_id,
  item.segment1
  ||'-'
  || item.segment2
  ||'-'
  || item.segment3 AS item_code,
  item.description,
  MAX( item.last_update_date)   AS item_last_update_date,
  MAX(barcode.last_update_date) AS barcode_last_update_date
FROM mtl_system_items_b item,
  mtl_cross_references barcode
WHERE item.inventory_item_id       =barcode.inventory_item_id
AND barcode.cross_reference_type           = ?
AND item.inventory_item_status_code= ? 
AND item.last_update_date          >?
AND barcode.last_update_date       >?
GROUP BY item.inventory_item_id,
  item.segment1,
  item.segment2,
  item.segment3,
  item.description,
  barcode.cross_reference
ORDER BY inventory_item_id;
     */
    class ItemSynchoronizer:IDisposable
    {
        public ItemSynchoronizer()
        {
                if (IsAlive) throw new SynchOnGoingException("Current Synchoronization is not cumplete.");
        }
        public delegate void SynchStartedHandeler();
        public event SynchStartedHandeler SynchStarted;
        public delegate void SynchFinishedHandeler();
        public event SynchFinishedHandeler SynchFinished;
        public static bool _IsAlive = false;
        public bool IsAlive
        {
            get
            {
                return _IsAlive;
            }
            set
            {
                _IsAlive = value;
                try
                {
                    if (SynchFinished != null && !_IsAlive) SynchFinished.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        internal struct item
        {
            public string invId;
            public string itemCode;
            public string barcode;
            public string description;
            public DateTime itemUpdate;
            public DateTime barcodeUpdate;
        }
        private const string CROSS_REFERANCE_TYPE = "Bar Code Number";
        private const string ITEM_STATUS_ACTIVE = "Active";
        private const string ITEM_STATUS_INACTIVE = "Inactive";
        private const string ITEM_DETAILS = 
            @"SELECT DISTINCT "+
            @"item.inventory_item_id, "+
            @"item.segment1 ||'-' || item.segment2 ||'-' || item.segment3 AS item_code, "+
            @"barcode.cross_reference, "+
            @"item.description, "+
            @"MAX( item.last_update_date) AS item_last_update_date, "+
            @"MAX(barcode.last_update_date) AS barcode_last_update_date "+
            @"FROM mtl_system_items_b item, mtl_cross_references barcode "+
            @"WHERE item.inventory_item_id = barcode.inventory_item_id "+
            //@"AND ROWNUM <= 10 "+
            @"AND barcode.cross_reference_type = ? "+
            @"AND item.inventory_item_status_code= ? "+
            @"AND item.last_update_date >? "+
            @"AND barcode.last_update_date >? "+
            @"GROUP BY item.inventory_item_id, item.segment1, item.segment2, "+
            @"item.segment3, item.description, barcode.cross_reference ORDER BY inventory_item_id";

        private const string ITEM_DETAILS_INACTIVE = "SELECT DISTINCT item.inventory_item_id "+
            "FROM mtl_system_items_b item "+
            "WHERE item.last_update_date > ? "+
            "AND item.inventory_item_status_code = ?";
        public void synch()
        {
            #region ActiveItems
            IsAlive = true;
            if (SynchStarted != null) SynchStarted.Invoke();
            DateTime itemLastUpdate = getItemLastUpdate();
            DateTime barcodeLastUpdate = getBarcodeLastUpdate();

            using (OleDbConnection connection = new OleDbConnection())
            using (OleDbCommand cmd = new OleDbCommand())
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder("provider=MSDAORA;USER ID=apps/apps; PERSIST SECURITY INFO=FALSE");
                builder["Data Source"] = MyOledbHandler.DataSource;
                connection.ConnectionString = builder.ConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = ITEM_DETAILS;
                    cmd.Parameters.AddWithValue(@"barcode.cross_reference_type", CROSS_REFERANCE_TYPE).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue(@"item.inventory_item_status_code", ITEM_STATUS_ACTIVE).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue(@"item.last_update_date", itemLastUpdate).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue(@"barcode.last_update_date", barcodeLastUpdate).Direction = ParameterDirection.Input;

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item item = new item();
                            item.invId = reader.GetValue(0).ToString();
                            item.itemCode = reader.GetValue(1).ToString();
                            item.description = reader.GetValue(3).ToString();
                            item.barcode = reader.GetValue(2).ToString();
                            item.itemUpdate = reader.GetDateTime(4);
                            item.barcodeUpdate = reader.GetDateTime(5);
                            //ParameterizedThreadStart start = this.insertitem;
                            //Thread thread = new Thread(start);
                            //thread.Start(item);
                            this.insertitem(item);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
            #endregion ActiveItems
            #region InactiveItem
            itemLastUpdate = getItemLastUpdate();

            using (OleDbConnection connection = new OleDbConnection())
            using (OleDbCommand cmd = new OleDbCommand())
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder("provider=MSDAORA;USER ID=apps/apps; PERSIST SECURITY INFO=FALSE");
                builder["Data Source"] = MyOledbHandler.DataSource;
                connection.ConnectionString = builder.ConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = ITEM_DETAILS_INACTIVE;
                    cmd.Parameters.AddWithValue("item.inventory_item_status_code", ITEM_STATUS_INACTIVE);
                    cmd.Parameters.AddWithValue("item.last_update_date", itemLastUpdate);
                    using (OleDbDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            this.DeleteLocalItem(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
            #endregion InactiveItem
            IsAlive = false;

        }

        private void DeleteLocalItem(string p)
        {
            const string DELETE_ITEM = @"delete from item_master where inv_id = @inv_id";
            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                connection.ConnectionString = Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = DELETE_ITEM;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@inv_id", p);
                    using (SqlTransaction trans = connection.BeginTransaction())
                    {
                        cmd.Transaction = trans;
                        cmd.ExecuteScalar();
                    }
                }
                catch (Exception) { }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
        }

        private DateTime getBarcodeLastUpdate()
        {
            DateTime updateDate = new DateTime(2006, 1, 1);
            const string GET_DATE = @"SELECT MAX(last_date_update) FROM dbo.cross_referance";
            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                connection.ConnectionString = Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = GET_DATE;
                    cmd.CommandType = System.Data.CommandType.Text;
                    updateDate=(DateTime)cmd.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
                return updateDate;
            }
        }

        private DateTime getItemLastUpdate()
        {
            DateTime updateDate = new DateTime(2006, 1, 1);
            const string GET_DATE = @"SELECT MAX(last_update_date) FROM dbo.item_master";
            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    connection.ConnectionString = Properties.Settings.Default.item_masterConnectionString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = GET_DATE;
                    cmd.CommandType = System.Data.CommandType.Text;
                    updateDate=(DateTime)cmd.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
            return updateDate;
        }
        /*
         * dbo.Insert_item
         * @inv_id              VARCHAR(10),
         * @item_code           VARCHAR(15),
         * @description         VARCHAR(50),
         * @barcode             VARCHAR(50),
         * @item_last_update    DATETIME,
         * @barcode_last_update DATETIME
         */
        private const string INSERT_CMD = @"Insert_item";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invId"></param>
        /// <param name="itemCode"></param>
        /// <param name="barcode"></param>
        /// <param name="description"></param>
        /// <param name="itemLastUpdate"></param>
        /// <param name="barcodeLastUpdate"></param>
        private void insertitem(object itemIn)
        {
            item item = (item)itemIn;
            string invId=item.invId;
            string itemCode=item.itemCode;
            string barcode=item.barcode;
            string description;
            try
            {
                description = item.description.Substring(0, 50);
            }
            catch (ArgumentOutOfRangeException)
            { description = item.description; }
            DateTime itemLastUpdate= item.itemUpdate;
            DateTime barcodeLastUpdate = item.barcodeUpdate;

            using (SqlConnection connection = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                connection.ConnectionString = Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = INSERT_CMD;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;      //:inv_id,:item_code,:description,:barcode,:item_last_update,:barcode_last_update
                    cmd.Parameters.AddWithValue("@inv_id", invId);
                    cmd.Parameters.AddWithValue("@item_code", itemCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.Parameters.AddWithValue("@item_last_update", itemLastUpdate).SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.AddWithValue("@barcode_last_update", barcodeLastUpdate).SqlDbType = SqlDbType.DateTime;
                    SqlParameter error = new SqlParameter();
                    error.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(error);
                    //using (SqlTransaction trans = connection.BeginTransaction())
                    //{
                        //cmd.Transaction = trans;
                        try
                        {
                            int x = cmd.ExecuteNonQuery();
                            string ret = error.Value.ToString();
                            Console.WriteLine(ret);
                            //trans.Commit();
                        }
                        catch (InvalidOperationException)
                        {
                            //trans.Rollback();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            IsAlive = false;
        }

        #endregion
    }
}
