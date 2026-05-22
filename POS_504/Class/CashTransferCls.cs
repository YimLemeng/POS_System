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
    internal class CashTransferCls
    {
        public string Id { get; set; }
        public string TransferDate { get; set; }
        public string PaymentMethodIdFrom { get; set; }
        public string PaymentMethodIdTo { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }

        public bool Insert()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("CashTransfer_Insert", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_date", OracleDbType.Varchar2).Value = TransferDate;
                    cmd.Parameters.Add("p_from", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodIdFrom);
                    cmd.Parameters.Add("p_to", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodIdTo);
                    cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = Amount;
                    cmd.Parameters.Add("p_userid", OracleDbType.Int32).Value = Convert.ToInt32(UserId);
                    OracleParameter outId = new OracleParameter("p_id", OracleDbType.Int32) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outId);
                    cmd.ExecuteNonQuery();
                    this.Id = outId.Value.ToString(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Insert Error: " + ex.Message); return false; }
        }

        public bool Update()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("CashTransfer_Update", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);
                    cmd.Parameters.Add("p_date", OracleDbType.Varchar2).Value = TransferDate;
                    cmd.Parameters.Add("p_from", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodIdFrom);
                    cmd.Parameters.Add("p_to", OracleDbType.Int32).Value = Convert.ToInt32(PaymentMethodIdTo);
                    cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = Amount;
                    cmd.Parameters.Add("p_userid", OracleDbType.Int32).Value = Convert.ToInt32(UserId);
                    cmd.ExecuteNonQuery(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); return false; }
        }

        public bool Delete()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("CashTransfer_Delete", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);
                    cmd.ExecuteNonQuery(); return true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); return false; }
        }

        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("SelectAllCashTransfer", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_recordset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd)) { da.Fill(ds); }
                }
            }
            catch (Exception ex) { MessageBox.Show("Fetch Error: " + ex.Message); }
            return ds;
        }
    }
}
