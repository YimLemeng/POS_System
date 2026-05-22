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
    internal class SalePaymentCls
    {
        private string _id;
        private string _paymentdate;
        private string _saleid;
        private string _paymentmethodid;
        private string _payamount;

        public string Id { get => _id; set => _id = value; }
        public string Paymentdate { get => _paymentdate; set => _paymentdate = value; }
        public string Saleid { get => _saleid; set => _saleid = value; }
        public string Paymentmethodid { get => _paymentmethodid; set => _paymentmethodid = value; }
        public string Payamount { get => _payamount; set => _payamount = value; }

        public bool Insert(OracleTransaction tran)
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("SALEPAYMENT_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_PAYMENTDATE", OracleDbType.Date).Value = DateTime.Parse(Paymentdate);
            cmd.Parameters.Add("P_SALEID", OracleDbType.Int32).Value = Saleid;
            cmd.Parameters.Add("P_PAYMENTMETHODID", OracleDbType.Int32).Value = Paymentmethodid;
            cmd.Parameters.Add("P_PAYAMOUNT", OracleDbType.Decimal).Value = Payamount;

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
            OracleCommand cmd = new OracleCommand("SALEPAYMENT_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_PAYMENTDATE", OracleDbType.Date).Value = DateTime.Parse(Paymentdate);
            cmd.Parameters.Add("P_SALEID", OracleDbType.Int32).Value = Saleid;
            cmd.Parameters.Add("P_PAYMENTMETHODID", OracleDbType.Int32).Value = Paymentmethodid;
            cmd.Parameters.Add("P_PAYAMOUNT", OracleDbType.Decimal).Value = Payamount;

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
            OracleCommand cmd = new OracleCommand("SALEPAYMENT_DELETE", Program.cn);
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
                    MessageBox.Show("This payment cannot be deleted");
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
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM SALEPAYMENT_V ORDER BY ID DESC", Program.cn);
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

