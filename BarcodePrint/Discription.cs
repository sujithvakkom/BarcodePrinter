using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace BarCodePrinter 
{
    
    public class Description
    {
        private string itemCode;
        private string itemDiscription;
        private string barcode;
        private decimal price;
        private string currency;
        private string searchCode;
        private bool addToPrintList;
        public int numberOfPrint = -1;
        public delegate void ItemChanged(Description item);
        public event ItemChanged itemChanged;
        public delegate void AddToPrintListDelegate(EventArgument e);
        public event AddToPrintListDelegate addItemToPrintList;
        public delegate bool ValidForPrint(String e);
        public event ValidForPrint validForPrint;
        public delegate bool ItemClearedDelegate(EventArgument e);
        public event ItemClearedDelegate itemCleared;
        public bool f;
        public Description(string itemcode, string itemDiscription, string barcode)
        {
            f = false;
            this.itemCode = itemcode;
            this.itemDiscription = itemDiscription;
            this.barcode = barcode;
        }
        public Description(string itemcode, string itemDiscription, string barcode,decimal price,String currency)
        {
            f = false;
            this.itemCode = itemcode;
            this.itemDiscription = itemDiscription;
            this.barcode = barcode;
            this.price = price;
            this.currency = currency;
        }

        public String NumberOfPrint
        {
            get
            {
                return numberOfPrint.ToString(); 
            }
            set
            {
                Int32.TryParse(value, out this.numberOfPrint);
                validForPrint.Invoke(NumberOfPrint);
            }
        }
        public string ItemCode
        {
            set
            {
                itemCode = value;
            }
            get
            {
                return itemCode;
            }
        }
        public decimal Price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }
        public string Currency
        {
            set
            {
                currency = value;
            }
            get
            {
                return currency;
            }
        }
        public string ItemDiscription
        {
            get
            {
                return itemDiscription;
            }
            set
            {
                itemDiscription = value;
            }
        }
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;;

            }
        }
        public string SearchCode
        {
            get
            {
                return searchCode;
            }
            set
            {
                searchCode = value;
                try
                {
                    itemChanged.Invoke(this);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
        public bool AddToPrintList
        {
            get
            {
                return addToPrintList;
            }
            set
            {
                addToPrintList=value;
                if (this.numberOfPrint>0)
                {
                    try
                    {
                        addItemToPrintList.Invoke(new EventArgument(this));
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    f = true;
                }

            }
        }

        public string BarcodeMode { get; internal set; }

        public override string ToString()
        {
            const string format= @"{0} {1} {2}";
            var value = String.Format(format, 
                itemCode.PadRight(15,' ').Substring(0,15), 
                barcode.PadRight(13, ' ').Substring(0, 13), 
                ItemDiscription);
            return value; //(this.ItemCode + "  @  " +this.barcode +", " + this.ItemDiscription);
        }

        internal void clear()
        {
            this.addToPrintList = false;
            this.ItemCode = "";
            this.Barcode = "";
            this.Price = 0;
            this.Currency = "";
            this.itemDiscription = "";
            this.NumberOfPrint = "-1";
            this.SearchCode = "";
            try
            {
                itemCleared.Invoke(new EventArgument(this));
            }
            catch (Exception)
            {
            }

        }

        internal void copy(Description discription)
        {
            this.itemCode = discription.ItemCode;
            this.itemDiscription = discription.ItemDiscription;
            this.barcode = discription.Barcode;
            this.addToPrintList = discription.AddToPrintList;
            this.numberOfPrint = discription.numberOfPrint;
            this.searchCode = discription.barcode;
            this.currency = discription.Currency;
            this.price = discription.Price;
        }

        internal void insert()
        {
            const String DELETE_CMD = @"DELETE FROM custome_barcodes WHERE cross_referance = ?";
            const String INSERT_CMD = @"INSERT INTO custome_barcodes
                         (cross_referance, description)
VALUES       (?, ?)";
            using (OleDbConnection connection = LocalDatabase.Connection())
            using (OleDbCommand cmd = new OleDbCommand())
            {
                //connection.ConnectionString = BarcodePrinter.Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.Transaction = connection.BeginTransaction();
                    try
                    {
                        cmd.CommandText = DELETE_CMD;
                        cmd.Parameters.AddWithValue("?", barcode);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = INSERT_CMD;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("?", barcode);
                        cmd.Parameters.AddWithValue("?", this.itemDiscription);
                        cmd.ExecuteNonQuery();
                        cmd.Transaction.Commit();
                    }
                    catch (InvalidOperationException)
                    {
                        cmd.Transaction.Rollback();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            cmd.CommandText = @"update custome_barcodes set description = @description where cross_referance = @cross_referance";

                            try
                            {
                                cmd.ExecuteNonQuery();
                                cmd.Transaction.Commit();
                            }
                            catch (Exception)
                            {
                                cmd.Transaction.Rollback();
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            cmd.Transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        cmd.Transaction.Rollback();
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

        internal static Description getCustomeItem(string barcode)
        {
            Description description = null;
            const String SELECT_CMD = @"SELECT description
                                        FROM custome_barcodes
                                        where cross_referance = ?";
            using (OleDbConnection connection = LocalDatabase.Connection())
            using (OleDbCommand cmd = new OleDbCommand())
            {
                //connection.ConnectionString = BarcodePrinter.Properties.Settings.Default.item_masterConnectionString;
                try
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = SELECT_CMD;
                    cmd.Parameters.AddWithValue("?", barcode);
                    try
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                description = new Description(barcode, reader.GetString(0), barcode);
                            }
                        }
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
                    throw new Exception(BarcodePrinter.Properties.Settings.Default.item_masterConnectionString, ex);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    { connection.Close(); }
                }
            }
            return description;
        }
    
    
    }
    public class EventArgument : EventArgs
    {
        private Description module;
        public Description Module
        {
            get
            {
                return module;
            }
        }
        public EventArgument(Description obj)
        {
            module = obj;
        }
    }

    public static class LocalDatabase
    {
        public static void CreateSqlDatabase(string filename)
        {            
            string databaseName = System.IO.Path.GetFileNameWithoutExtension(filename);
            using (var connection = new System.Data.SqlClient.SqlConnection(
                "Data Source=.\\sqlexpress;Initial Catalog=tempdb; Integrated Security=true;User Instance=True;"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, filename);
                    command.ExecuteNonQuery();

                    command.CommandText =
                        String.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static OleDbConnection Connection()
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder(BarcodePrinter.Properties.Settings.Default.InventoryConnectionString);
            return new OleDbConnection(builder.ConnectionString);
        }
    }
}

