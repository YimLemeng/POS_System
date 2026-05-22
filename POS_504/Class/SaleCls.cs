using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.AxHost;

namespace POS_504.Class
{
    internal class SaleCls
    {
        private string _id;
        private string _invoiceno;
        private string _date;
        private string _customerid;
        private string _userid;
        private string _totalamount;
        private string _discount;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Invoiceno { get => _invoiceno; set => _invoiceno = value; }
        public string Date { get => _date; set => _date = value; }
        public string Customerid { get => _customerid; set => _customerid = value; }
        public string Userid { get => _userid; set => _userid = value; }
        public string Totalamount { get => _totalamount; set => _totalamount = value; }
        public string Discount { get => _discount; set => _discount = value; }
        public string Active { get => _active; set => _active = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("SALE_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_INVOICEID", OracleDbType.Int32).Value = Invoiceno;
            cmd.Parameters.Add("P_DATE", OracleDbType.Date).Value = DateTime.Parse(Date);
            cmd.Parameters.Add("P_CUSTOMERID", OracleDbType.Int32).Value = Customerid;
            cmd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = Userid;
            cmd.Parameters.Add("P_TOTALAMOUNT", OracleDbType.Decimal).Value = Totalamount;
            cmd.Parameters.Add("P_DISCOUNT", OracleDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int32).Value = Active;

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
            OracleCommand cmd = new OracleCommand("SALE_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_INVOICEID", OracleDbType.Int32).Value = Invoiceno;
            cmd.Parameters.Add("P_DATE", OracleDbType.Date).Value = DateTime.Parse(Date);
            cmd.Parameters.Add("P_CUSTOMERID", OracleDbType.Int32).Value = Customerid;
            cmd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = Userid;
            cmd.Parameters.Add("P_TOTALAMOUNT", OracleDbType.Decimal).Value = Totalamount;
            cmd.Parameters.Add("P_DISCOUNT", OracleDbType.Decimal).Value = Discount;
            cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int32).Value = Active;

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
            OracleCommand cmd = new OracleCommand("SALE_DELETE", Program.cn);
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
                    MessageBox.Show("This sale cannot be deleted");
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

        public DataSet SelectRecord()
        {
            OracleDataAdapter cmd = new OracleDataAdapter(
                "SELECT * FROM SALE_V ORDER BY ID DESC", Program.cn);
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

        public DataTable SelectById()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALE_V WHERE ID = :id", Program.cn);
            cmd.SelectCommand.Parameters.Add(new OracleParameter("id", Id));
            DataTable dt = new DataTable();
            try
            {
                cmd.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable SelectDetails()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALEDETAIL_V WHERE SALEID = :saleid", Program.cn);
            cmd.SelectCommand.Parameters.Add(new OracleParameter("saleid", Id));
            DataTable dt = new DataTable();
            try
            {
                cmd.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataSet SelectCustomer()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM CUSTOMER_TBL WHERE ACTIVE = 1", Program.cn);
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
        public DataSet SelectProduct()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PRODUCT_TBL WHERE ACTIVE = 1", Program.cn);
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
        public DataSet SelectUser()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM USER_TBL WHERE ACTIVE = 1", Program.cn);
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

        public DataSet SelectPaymentMethod()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PAYMENTMETHOD_TBL WHERE ACTIVE = 1", Program.cn);
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

        //public DataTable FindSale(string searchText)
        //{
        //    string query = @"SELECT * FROM SALE_V
        //                     WHERE CAST(INVOICENO AS VARCHAR2(20)) LIKE :searchText
        //                        OR CUSTOMERNAME LIKE :searchText
        //                        OR CAST(DATE AS VARCHAR2(20)) LIKE :searchText";
        //    using (OracleCommand cmd = new OracleCommand(query, Program.cn))
        //    {
        //        cmd.Parameters.Add(new OracleParameter("searchText", "%" + searchText + "%"));
        //        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        public int GetNextInvoiceNo()
        {
            OracleCommand cmd = new OracleCommand("SELECT NVL(MAX(INVOICEID), 0) + 1 FROM Sale_tbl", Program.cn);
            try
            {
                object result = cmd.ExecuteScalar();
                return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("បញ្ហាក្នុងការទាញលេខ Invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }
    }
}
