using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace BarcodePrinter
{
    public class Extentions:IDisposable
    {
        private OleDbCommand cmd;
        private int inventory;
        private string dBCommandString;
        private OleDbDataAdapter dataAdaptor;
        public int getInventory(string parameter)
        {
            inventory = 0;
            OleDbConnection connection = new OleDbConnection(BarcodePrinter.Properties.Settings.Default.InventoryConnectionString);
            cmd = new OleDbCommand();
            if (parameter.Length == 15)
                dBCommandString = "SELECT inventory_item_id FROM xxgs_pos_stocks_v WHERE (item_code = @parameter )"; 
            else if (parameter.Length == 13)
                dBCommandString = "SELECT inventory_item_id FROM [xxgs_pos_bar_code_v] WHERE (cross_reference = @parameter )";

            connection.Open();
            cmd = new OleDbCommand(dBCommandString, connection);
            cmd.Parameters.AddWithValue("@parameter", parameter);
            inventory = Convert.ToInt32(cmd.ExecuteScalar());
            return inventory;
        }

        public DataTable getDiscription(string parameter)
        {
            DataTable discriptionInstence = new DataTable();

            OleDbConnection connection = new OleDbConnection(BarcodePrinter.Properties.Settings.Default.InventoryConnectionString);
            cmd = new OleDbCommand();
            dBCommandString = "SELECT a.item_code as Item, a.item_name as Discribtion, b.cross_reference as Barcode " +
                    "FROM (xxgs_pos_stocks_v a INNER JOIN xxgs_pos_bar_code_v b ON a.inventory_item_id = b.inventory_item_id) ";
            connection.Open();
            cmd = new OleDbCommand(dBCommandString, connection);
            //cmd.Parameters.AddWithValue("@parameter",(parameter.ToString()+'%'));
            dataAdaptor = new OleDbDataAdapter(cmd);
            dataAdaptor.Fill(discriptionInstence);
            return discriptionInstence;
        }

        public DataTable getDiscription1(string parameter)
        {

            DataTable discriptionInstence = new DataTable();
            //discriptionInstence.TableName = "discription";
            OleDbConnection connection = new OleDbConnection(BarcodePrinter.Properties.Settings.Default.InventoryConnectionString);
            cmd = new OleDbCommand();
            dBCommandString = "SELECT xxgs_pos_stocks_v.item_code, xxgs_pos_stocks_v.item_name "+
                "FROM xxgs_pos_stocks_v WHERE xxgs_pos_stocks_v.item_code Like @parameter+'%'";
            //dBCommandString = "SELECT xxgs_pos_stocks_v.item_code, xxgs_pos_stocks_v.item_name FROM xxgs_pos_stocks_v ";
            connection.Open();
            cmd = new OleDbCommand(dBCommandString, connection);
            cmd.Parameters.AddWithValue("@parameter", parameter.ToString());
            dataAdaptor = new OleDbDataAdapter(cmd);
            dataAdaptor.Fill(discriptionInstence);
            //System.Windows.Forms.MessageBox.Show( discriptionInstence.Rows.Count.ToString());

            return discriptionInstence;

        }

        void IDisposable.Dispose()
        {

        }
        

    }
}
