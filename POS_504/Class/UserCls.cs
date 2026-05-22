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
    internal class UserCls
    {
        private string _id;
        private string _staffid;
        private string _username;
        private string _password;
        private string _expireddate;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Staffid { get => _staffid; set => _staffid = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Expireddate { get => _expireddate; set => _expireddate = value; }
        public string Active { get => _active; set => _active = value; }

        public void Insert()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("USER_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_STAFFID", OracleDbType.Int64).Value = Convert.ToInt64(Staffid);
                cmd.Parameters.Add("P_USERNAME", OracleDbType.NVarchar2).Value = Username;
                cmd.Parameters.Add("P_PASSWORD", OracleDbType.NVarchar2).Value = Password;
                cmd.Parameters.Add("P_EXPIREDDATE", OracleDbType.Date).Value = Convert.ToDateTime(Expireddate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Insert Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Update()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("USER_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Convert.ToInt64(Id);
                cmd.Parameters.Add("P_STAFFID", OracleDbType.Int64).Value = Convert.ToInt64(Staffid);
                cmd.Parameters.Add("P_USERNAME", OracleDbType.NVarchar2).Value = Username;
                cmd.Parameters.Add("P_PASSWORD", OracleDbType.NVarchar2).Value = Password;
                cmd.Parameters.Add("P_EXPIREDDATE", OracleDbType.Date).Value = Convert.ToDateTime(Expireddate);
                cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int16).Value = Convert.ToInt16(Active);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Update Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Delete()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("USER_DELETE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Convert.ToInt64(Id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User Delete Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataSet SelectRecord()
        {
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM User_tbl", Program.cn);
            try
            {
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataSet SelectStaffId()
        {
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter("SELECT ID, STAFFNAME FROM STAFF_TBL", Program.cn);
            try
            {
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
    }
}
