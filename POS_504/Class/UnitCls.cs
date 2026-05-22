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
    internal class UnitCls
    {
        private string _id;
        private string _unitname;
        private decimal _qty;

        public string Id { get => _id; set => _id = value; }
        public string Unitname { get => _unitname; set => _unitname = value; }
        public decimal Qty { get => _qty; set => _qty = value; }
        public MainFrm MdiParent { get; internal set; }

        public void Insert()
        {
            string message = "";
            try
            {
                OracleCommand cmd = new OracleCommand("UNIT_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_UNITNAME", OracleDbType.NVarchar2).Value = Unitname;
                cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();
                if (message == "SUCCESSFULLY")
                {
                    MessageBox.Show("Unit Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Unit already exists");
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
                OracleCommand cmd = new OracleCommand("UNIT_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;
                cmd.Parameters.Add("P_UNITNAME", OracleDbType.NVarchar2).Value = Unitname;
                cmd.Parameters.Add("P_QTY", OracleDbType.Decimal).Value = Qty;
                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();
                if (message == "SUCCESSFULLY")
                {
                    MessageBox.Show("Unit Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Unit not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void Delete()
        {
            string message = "";
            try
            {
                OracleCommand cmd = new OracleCommand("UNIT_DELETE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Id;
                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();
                if (message == "SUCCESSFULLY")
                {
                    MessageBox.Show("Unit Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Unit not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public DataSet SelectRecord()
        {
            OracleDataAdapter cmd = new OracleDataAdapter("SELECT * FROM UNIT_TBL ORDER BY ID ASC", Program.cn);
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
