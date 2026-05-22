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
    internal class PaymentMethodCls
    {
        private string _id;
        private string _methodname;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Methodname { get => _methodname; set => _methodname = value; }
        public string Active { get => _active; set => _active = value; }

        public bool Insert()
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PAYMENTMETHOD_INSERT", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_METHODNAME", OracleDbType.NVarchar2).Value = Methodname;
            cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int32).Value = Active;

            try
            {
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

        public bool Update()
        {
            bool b = false;
            OracleCommand cmd = new OracleCommand("PAYMENTMETHOD_UPDATE", Program.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("P_ID", OracleDbType.Int32).Value = Id;
            cmd.Parameters.Add("P_METHODNAME", OracleDbType.NVarchar2).Value = Methodname;
            cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int32).Value = Active;

            try
            {
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
            OracleCommand cmd = new OracleCommand("PAYMENTMETHOD_DELETE", Program.cn);
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
                    MessageBox.Show("This payment method is in use and cannot be deleted");
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
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM PAYMENTMETHOD_TBL ORDER BY ID ASC", Program.cn);
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
