using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Class
{
    internal class ProductCls
    {
        private string _id;
        private string _barcode;
        private string _productcode;
        private string _productname;
        private string _productnamekh;
        private string _categoryid;
        private string _supplierid;
        private string _stocktype;
        private string _qtyonhand;
        private string _qtyalert;
        private object _picture;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Barcode { get => _barcode; set => _barcode = value; }
        public string Productcode { get => _productcode; set => _productcode = value; }
        public string Productname { get => _productname; set => _productname = value; }
        public string Productnamekh { get => _productnamekh; set => _productnamekh = value; }
        public string Categoryid { get => _categoryid; set => _categoryid = value; }
        public string Supplierid { get => _supplierid; set => _supplierid = value; }
        public string Stocktype { get => _stocktype; set => _stocktype = value; }
        public string Qtyonhand { get => _qtyonhand; set => _qtyonhand = value; }
        public string Qtyalert { get => _qtyalert; set => _qtyalert = value; }
        public object Picture { get => _picture; set => _picture = value; }
        public string Active { get => _active; set => _active = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PRODUCT_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_PRODUCTCODE", OracleDbType.NVarchar2, 50).Value = Productcode;
            cmd.Parameters.Add("P_BARCODE", OracleDbType.NVarchar2, 50).Value = Barcode;
            cmd.Parameters.Add("P_PRODUCTNAME", OracleDbType.NVarchar2, 50).Value = Productname;
            cmd.Parameters.Add("P_PRODUCTNAMEKH", OracleDbType.NVarchar2, 50).Value = Productnamekh;
            cmd.Parameters.Add("P_CATEGORYID", OracleDbType.Int16, 50).Value = Categoryid;
            cmd.Parameters.Add("P_SUPPLIERID", OracleDbType.Int16, 50).Value = Supplierid;
            cmd.Parameters.Add("P_STOCKTYPE", OracleDbType.NVarchar2, 50).Value = Stocktype;
            cmd.Parameters.Add("P_QTYONHAND", OracleDbType.Decimal).Value = Qtyonhand;
            cmd.Parameters.Add("P_QTYALERT", OracleDbType.Int64).Value = Qtyalert;
            cmd.Parameters.Add("P_PICTURE", OracleDbType.Blob).Value = Picture;

            try
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                OracleCommand cmd1 = new OracleCommand("SELECT MAX(ID) FROM PRODUCT_TBL", Program.cn);
                cmd1.Transaction = tran;
                object result = cmd1.ExecuteScalar();
                int i = 0;
                if (result != DBNull.Value && result != null)
                {
                    i = Convert.ToInt32(result);
                }
                Id = i.ToString();
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                b = false;
            }
            return b;
        }
        public bool Update(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PRODUCT_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int16).Value = Id;
            cmd.Parameters.Add("P_PRODUCTCODE", OracleDbType.NVarchar2, 50).Value = Productcode;
            cmd.Parameters.Add("P_BARCODE", OracleDbType.NVarchar2, 50).Value = Barcode;
            cmd.Parameters.Add("P_PRODUCTNAME", OracleDbType.NVarchar2, 50).Value = Productname;
            cmd.Parameters.Add("P_PRODUCTNAMEKH", OracleDbType.NVarchar2, 50).Value = Productnamekh;
            cmd.Parameters.Add("P_CATEGORYID", OracleDbType.Int16, 50).Value = Categoryid;
            cmd.Parameters.Add("P_SUPPLIERID", OracleDbType.Int16, 50).Value = Supplierid;
            cmd.Parameters.Add("P_STOCKTYPE", OracleDbType.NVarchar2, 50).Value = Stocktype;
            cmd.Parameters.Add("P_QTYONHAND", OracleDbType.Decimal).Value = Qtyonhand;
            cmd.Parameters.Add("P_QTYALERT", OracleDbType.Int64).Value = Qtyalert;
            cmd.Parameters.Add("P_PICTURE", OracleDbType.Blob).Value = Picture;
            try
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                b = false;
            }
            return b;
        }
        public void Delete()
        {
            OracleCommand cmd = new OracleCommand("PRODUCT_DELETE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int16).Value = Id;
            cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 50).Direction = System.Data.ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                string message = cmd.Parameters["P_SMS"].Value.ToString();
                if(message == "ALREADY USED")
                {
                    MessageBox.Show("This product relate with sale", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataSet SelectRecord()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PRODUCT_V ORDER BY ID DESC", Program.cn);
            DataSet dts = new DataSet();
            try
            {
                cmd.Fill(dts);
                return dts;
            }
            catch
            {
                return null;
            }
        }
        public DataSet SelectSupplier()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SUPPLIER_TBL", Program.cn);
            DataSet dts = new DataSet();
            try
            {
                cmd.Fill(dts);
                return dts;
            }
            catch
            {
                return null;
            }
        }
        public DataSet SelectCategory()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM CATEGORY_TBL", Program.cn);
            DataSet dts = new DataSet();
            try
            {
                cmd.Fill(dts);
                return dts;
            }
            catch
            {
                return null;
            }
        }
        public DataSet SelectUnitType()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT ID, UNITNAME || '-' || QTY AS UNAME FROM UNIT_TBL", Program.cn);
            DataSet dts = new DataSet();
            try
            {
                cmd.Fill(dts);
                return dts;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetProductByBarcode(string barcode)
        {
            using (var cmd = new OracleCommand("SELECT * FROM PRODUCT_TBL WHERE BARCODE = :barcode", Program.cn))
            {
                cmd.Parameters.Add(new OracleParameter("barcode", barcode));
                using (var adapter = new OracleDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable FindProduct(string searchText)
        {
            string query = @"SELECT * FROM PRODUCT_TBL 
                             WHERE PRODUCTNAME LIKE :searchText 
                                OR PRODUCTCODE LIKE :searchText 
                                OR BARCODE LIKE :searchText";
            using (OracleCommand cmd = new OracleCommand(query, Program.cn))
            {
                cmd.Parameters.Add(new OracleParameter("searchText", "%" + searchText + "%"));
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
