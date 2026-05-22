using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace POS_504.Class
{
    internal class PurchaseDetailCls
    {
        private string _id;
        private string _productid;
        private string _qty;
        private string _cost;
        private string _discounts;
        private string _purchaseid;

        public string Id { get => _id; set => _id = value; }
        public string Productid { get => _productid; set => _productid = value; }
        public string Qty { get => _qty; set => _qty = value; }
        public string Cost { get => _cost; set => _cost = value; }
        public string Discounts { get => _discounts; set => _discounts = value; }
        public string Purchaseid { get => _purchaseid; set => _purchaseid = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PURCHASEDETAIL_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int32).Value = Productid;
            cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
            cmd.Parameters.Add("P_DISCOUNTS", OracleDbType.Decimal).Value = Discounts;
            cmd.Parameters.Add("P_PURCHASEID", OracleDbType.Int32).Value = Purchaseid;

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

        public bool Update(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PURCHASEDETAIL_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int32).Value = Productid;
            cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
            cmd.Parameters.Add("P_DISCOUNTS", OracleDbType.Decimal).Value = Discounts;

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
            OracleCommand cmd = new OracleCommand("PURCHASEDETAIL_DELETE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 100).Direction = ParameterDirection.Output;

            try
            {
                cmd.ExecuteNonQuery();
                string message = cmd.Parameters["P_SMS"].Value.ToString();
                if (message == "ALREADY USED")
                {
                    MessageBox.Show("This detail record cannot be deleted");
                }
                else
                {
                    MessageBox.Show("Delete successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public DataSet SelectRecord()
        //{
        //    OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PURCHASEDETAIL_V ORDER BY ID DESC", Program.cn);
        //    DataSet dts = new DataSet();
        //    try
        //    {
        //        cmd.Fill(dts);
        //        return dts;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
