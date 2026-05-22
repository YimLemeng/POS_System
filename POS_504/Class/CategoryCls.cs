using Oracle.ManagedDataAccess.Client;
using POS_504.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Class
{
    internal class CategoryCls
    {
        private string _id;
        private string _catname;
        private string _active;
        public string Id { get => _id; set => _id = value; }
        public string Catname { get => _catname; set => _catname = value; }
        public string Active { get => _active; set => _active = value; }
        public MainFrm MdiParent { get; internal set; }

        public void Insert()
        {
            string message = "";
            try
            {
                OracleCommand cmd = new OracleCommand("CATEGORY_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CATNAME", OracleDbType.NVarchar2).Value = Catname;

                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();
                if(message == "SUCCESSFULLY")
                {
                    MessageBox.Show("Category Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Category already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Update()
        {
            string message = "";
            try
            {
                OracleCommand cmd = new OracleCommand("CATEGORY_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_CATNAME", OracleDbType.NVarchar2, 200).Value = Catname; 
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;                    
                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();
                if (message == "SUCCESSFULLY")
                {
                    MessageBox.Show("Category Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Updated already exists");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("CATEGORY_DELETE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Deleted Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataSet SelectRecord()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM CATEGORY_TBL WHERE ACTIVE=1 ORDER BY ID ASC", Program.cn);
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
