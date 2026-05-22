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
    internal class PurchaseCls
    {
        private string _id;
        private string _billno;
        private string _date;
        private string _supplierid;
        private string _userid;
        private string _totalamount;
        private string _discount;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Billno { get => _billno; set => _billno = value; }
        public string Date { get => _date; set => _date = value; }
        public string Supplierid { get => _supplierid; set => _supplierid = value; }
        public string Userid { get => _userid; set => _userid = value; }
        public string Totalamount { get => _totalamount; set => _totalamount = value; }
        public string Discount { get => _discount; set => _discount = value; }
        public string Active { get => _active; set => _active = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PURCHASE_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_BILLNO", OracleDbType.Int32).Value = Billno;
            cmd.Parameters.Add("P_DATE", OracleDbType.Date).Value = DateTime.Parse(Date);
            cmd.Parameters.Add("P_SUPPLIERID", OracleDbType.Int32).Value = Supplierid;
            cmd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = Userid;
            cmd.Parameters.Add("totalamount", OracleDbType.Decimal).Value = decimal.Parse(Totalamount);
            cmd.Parameters.Add("discount", OracleDbType.Decimal).Value = decimal.Parse(Discount);
            cmd.Parameters.Add("P_NEW_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            try
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                Id = cmd.Parameters["P_NEW_ID"].Value.ToString();
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
            OracleCommand cmd = new OracleCommand("PURCHASE_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_BILLNO", OracleDbType.Int32).Value = Billno;
            cmd.Parameters.Add("P_DATE", OracleDbType.Date).Value = DateTime.Parse(Date);
            cmd.Parameters.Add("P_SUPPLIERID", OracleDbType.Int32).Value = Supplierid;
            cmd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = Userid;
            cmd.Parameters.Add("P_TOTALAMOUNT", OracleDbType.Decimal).Value = Totalamount;
            cmd.Parameters.Add("P_DISCOUNT", OracleDbType.Decimal).Value = Discount;

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
            OracleCommand cmd = new OracleCommand("PURCHASE_DELETE", Program.cn);
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
                    MessageBox.Show("This purchase record cannot be deleted");
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
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PURCHASE_V ORDER BY ID DESC", Program.cn);
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
    }
}
