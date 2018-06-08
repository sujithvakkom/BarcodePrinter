//using System;
//using System.Data;
//using System.IO;
//using System.Text;
//using System.Windows.Forms;
//using Oracle.DataAccess.Client;

//namespace BarcodePrinter
//{
//    class OracleConnectionAgent : IDisposable
//    {
//#region Basic connection Setup
//        private String getItemCommand = @"SELECT DISTINCT " +
//            "xxgs_pos_stocks_v.item_code as item_code, " +
//            "SUBSTR(xxgs_pos_stocks_v.item_name,1,40) as item_name, " +
//            "xxgs_pos_bar_code_v.cross_reference as cross_reference " +
//            "FROM xxgs_pos_stocks_v INNER JOIN xxgs_pos_bar_code_v on xxgs_pos_stocks_v.inventory_item_id = xxgs_pos_bar_code_v.inventory_item_id " +
//            "WHERE ((REPLACE(item_code,'-','') LIKE :itemCode) or (cross_reference LIKE :barcode)) and (ROWNUM <= 6)";
//        private OracleConnection connection;
//        private OracleCommand cmd;
//        private OracleDataAdapter oracleDataAdapter;
//        private String oDRDBConnectionString;
//        private String configFile = @"..\BarcodePrint\service";
//        public string ServiceName
//        {
//            get
//            {
//                using (FileStream fileStream = new FileStream(configFile, FileMode.Open))
//                {
//                    StreamReader streamReader = new StreamReader(fileStream, Encoding.ASCII);
//                    return (streamReader.ReadLine());
//                }
//            }
//        }
//        public string Host
//        {
//            get
//            {
//                using (FileStream fileStream = new FileStream(configFile, FileMode.Open))
//                {
//                    StreamReader streamReader = new StreamReader(fileStream, Encoding.ASCII);
//                    streamReader.ReadLine();
//                    return (streamReader.ReadLine());
//                }
//            }
//        }
//        public string Port
//        {
//            get
//            {
//                using (FileStream fileStream = new FileStream(configFile, FileMode.Open))
//                {
//                    StreamReader streamReader = new StreamReader(fileStream, Encoding.ASCII);
//                    streamReader.ReadLine();
//                    streamReader.ReadLine();
//                    return (streamReader.ReadLine());
//                }
//            }
//        }
//        public OracleConnectionAgent()
//        {
//            oDRDBConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Host + ")" +
//                "(PORT=" + Port + "))(CONNECT_DATA=(SERVICE_NAME=" + ServiceName + ")));User Id=xxgs;Password=xxgs;";
//            connection = new OracleConnection(oDRDBConnectionString);
//            cmd = new OracleCommand();
//        }
//#region IDisposable Members
//        public void Dispose()
//        {
//            if (connection.State == ConnectionState.Open)
//                this.connection.Close();
//            connection.Dispose();
//        }
//#endregion
//#endregion
//        internal DataTable getDiscription(string value)
//        {
//            DataTable itemDiscription=new DataTable();
//            try
//            {
//                connection.Open();
//            }
//            catch (InvalidOperationException ex)
//            {
//                throw ex;
//            }
//            catch (OracleException ex)
//            {

//            }
//            cmd.CommandText = getItemCommand;
//            cmd.Connection = connection;
//            cmd.Parameters.Add("itemCode", value+'%');
//            cmd.Parameters.Add("barcode", value+'%');
//            oracleDataAdapter = new OracleDataAdapter(cmd);
//            try
//            {
//                oracleDataAdapter.Fill(itemDiscription);
//            }
//            catch (Exception ex)
//            {
//                //throw(new Exception(ex.Message));
//                MessageBox.Show(ex.Message);
//            }
//            return itemDiscription;
//        }
//    }
//}
