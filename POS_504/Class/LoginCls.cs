using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Class
{
    internal class LoginCls
    {
        public string Login(string username, string password)
        {
            {
                using (OracleCommand cmd = new OracleCommand("USER_LOGIN", Program.cn))
                {
                    string sms = "";
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("P_USERNAME", OracleDbType.NVarchar2).Value = username;
                        cmd.Parameters.Add("P_PASSWORD", OracleDbType.NVarchar2).Value = password;

                        cmd.Parameters.Add("P_MESSAGE", OracleDbType.NVarchar2, 200).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        sms = cmd.Parameters["P_MESSAGE"].Value.ToString();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        sms = e.ToString();
                    }
                    return sms;
                }
            }
        }
    }
}
