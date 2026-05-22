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
    internal class ExpenseTypeCls
    {
        public string Id { get; set; }
        public string TypeName { get; set; }
        public int Active { get; set; }

        public bool Insert()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("ExpenseType_Insert", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_typename", OracleDbType.Varchar2).Value = TypeName;
                    cmd.Parameters.Add("p_active", OracleDbType.Int32).Value = Active;
                    OracleParameter outId = new OracleParameter("p_id", OracleDbType.Int32);
                    outId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outId);

                    cmd.ExecuteNonQuery();
                    this.Id = outId.Value.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expense Type Insert Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("ExpenseType_Update", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);
                    cmd.Parameters.Add("p_typename", OracleDbType.Varchar2).Value = TypeName;
                    cmd.Parameters.Add("p_active", OracleDbType.Int32).Value = Active;

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expense Type Update Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("ExpenseType_Delete", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_id", OracleDbType.Int32).Value = Convert.ToInt32(Id);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expense Type Delete Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                using (OracleCommand cmd = new OracleCommand("SelectAllExpenseType", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("p_recordset", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expense Type Fetch Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }
    }
}
