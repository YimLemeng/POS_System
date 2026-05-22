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
    internal class ProductUnitCls
    {
        private string _id;
        private string _productid;
        private string _unittypeid;
        private string _cost;
        private string _price;
        private string _defaults;

        public string Id { get => _id; set => _id = value; }
        public string Productid { get => _productid; set => _productid = value; }
        public string Unittypeid { get => _unittypeid; set => _unittypeid = value; }
        public string Cost { get => _cost; set => _cost = value; }
        public string Price { get => _price; set => _price = value; }
        public string Defaults { get => _defaults; set => _defaults = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            try
            {
                OracleCommand cmd = new OracleCommand("PRODUCTUNIT_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int16).Value = Productid;
                cmd.Parameters.Add("P_UNITTYPEID", OracleDbType.Int16).Value = Unittypeid;
                cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
                cmd.Parameters.Add("P_PRICE", OracleDbType.Decimal).Value = Price;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ProductUnit Insert Successful");
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = false;
            }
            return b;
        }
        public bool Update(OracleTransaction tran)
        {
            bool b = false;
            try
            {
                OracleCommand cmd = new OracleCommand("PRODUCTUNIT_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;
                cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int16).Value = Productid;
                cmd.Parameters.Add("P_UNITTYPEID", OracleDbType.Int16).Value = Unittypeid;
                cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
                cmd.Parameters.Add("P_PRICE", OracleDbType.Decimal).Value = Price;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ProductUnit Update Successful");
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                b = false;
            }
            return b;
        }
        public void Delete()
        {
            OracleCommand cmd = new OracleCommand("PRODUCTUNIT_DELETE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;
            cmd.ExecuteNonQuery();
            MessageBox.Show("ProductUnit Delete Successful");
        }
        public DataSet SelectRecord(string proid)
        {
            DataSet ds = new DataSet();
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PRODUCTUNIT_TBL WHERE PRODUCTID = " + proid + "", Program.cn);
            try
            {
                cmd.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
    }
}
