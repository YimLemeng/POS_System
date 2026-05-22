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
    internal class SaleDetailCls
    {
        private string _id;
        private string _productid;
        private string _qty;
        private string _cost;
        private string _price;
        private string _discounts;
        private string _saleid;

        public string Id { get => _id; set => _id = value; }
        public string Productid { get => _productid; set => _productid = value; }
        public string Qty { get => _qty; set => _qty = value; }
        public string Cost { get => _cost; set => _cost = value; }
        public string Price { get => _price; set => _price = value; }
        public string Discounts { get => _discounts; set => _discounts = value; }
        public string Saleid { get => _saleid; set => _saleid = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("SALEDETAIL_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int32).Value = Productid;
            cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
            cmd.Parameters.Add("P_PRICE", OracleDbType.Decimal).Value = Price;
            cmd.Parameters.Add("P_DISCOUNTS", OracleDbType.Decimal).Value = Discounts;
            cmd.Parameters.Add("P_SALEID", OracleDbType.Int32).Value = Saleid;

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
            OracleCommand cmd = new OracleCommand("SALEDETAIL_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_PRODUCTID", OracleDbType.Int32).Value = Productid;
            cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("P_COST", OracleDbType.Decimal).Value = Cost;
            cmd.Parameters.Add("P_PRICE", OracleDbType.Decimal).Value = Price;
            cmd.Parameters.Add("P_DISCOUNTS", OracleDbType.Decimal).Value = Discounts;
            cmd.Parameters.Add("P_SALEID", OracleDbType.Int32).Value = Saleid;

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
            OracleCommand cmd = new OracleCommand("SALEDETAIL_DELETE", Program.cn);
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
                    MessageBox.Show("This sale detail cannot be deleted");
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
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALEDETAIL_V ORDER BY ID DESC", Program.cn);
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

        //public DataTable SelectById()
        //{
        //    OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALEDETAIL_V WHERE ID = :id", Program.cn);
        //    cmd.SelectCommand.Parameters.Add(new OracleParameter("id", Id));
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        cmd.Fill(dt);
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public DataTable SelectBySaleId()
        //{
        //    OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALEDETAIL_V WHERE SALEID = :saleid", Program.cn);
        //    cmd.SelectCommand.Parameters.Add(new OracleParameter("saleid", Saleid));
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        cmd.Fill(dt);
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public DataTable SelectByProductId() { 
        //    OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PRODUCT_V WHERE PRODUCTID = :productid", Program.cn);
        //    cmd.SelectCommand.Parameters.Add(new OracleParameter("productid", Productid));
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        cmd.Fill(dt);
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
