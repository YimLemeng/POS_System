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
    internal class MoreCapitalCls
    {
        public string Id { get; set; }
        public string CapitalDate { get; set; }
        public string PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }

        public bool Insert()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("MoreCapital_Insert", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_date", OracleDbType.Varchar2).Value = CapitalDate;
                    cmd.Parameters.Add("p_paymentmethodid", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodId);
                    cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = Amount;
                    cmd.Parameters.Add("p_userid", OracleDbType.Int32).Value = Convert.ToInt32(UserId);
                    OracleParameter outId = new OracleParameter("p_id", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outId); cmd.ExecuteNonQuery(); this.Id = outId.Value.ToString(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return false; }
        }
        public bool Update()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("MoreCapital_Update", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);
                    cmd.Parameters.Add("p_date", OracleDbType.Varchar2).Value = CapitalDate;
                    cmd.Parameters.Add("p_paymentmethodid", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodId);
                    cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = Amount;
                    cmd.Parameters.Add("p_userid", OracleDbType.Int32).Value = Convert.ToInt32(UserId);
                    cmd.ExecuteNonQuery(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return false; }
        }
        public bool Delete()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("MoreCapital_Delete", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);
                    cmd.ExecuteNonQuery(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return false; }
        }
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("SelectAllMoreCapital", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_recordset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd)) { da.Fill(ds); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            return ds;
        }
    }
}
