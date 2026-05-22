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
    internal class SupplierCls
    {
        private string _id;
        private string _suppliername;
        private string _sex;
        private string _phone;
        private string _email;
        private string _adress;
        private byte[] _photo;
        private string _active;

        public string Id { get => _id; set => _id = value; }
        public string Suppliername { get => _suppliername; set => _suppliername = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public byte[] Photo { get => _photo; set => _photo = value; }
        public string Active { get => _active; set => _active = value; }

        public MainFrm MdiParent { get; internal set; }

        public void Insert()
        {
            string message = "";
            try
            {
                OracleCommand cmd = new OracleCommand("SUPPLIER_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_SUPPLIERNAME", OracleDbType.NVarchar2).Value = Suppliername;
                cmd.Parameters.Add("P_SEX", OracleDbType.NVarchar2).Value = Sex;
                cmd.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = Phone;
                cmd.Parameters.Add("P_EMAIL", OracleDbType.NVarchar2).Value = Email;
                cmd.Parameters.Add("P_ADRESS", OracleDbType.NVarchar2).Value = Adress;
                cmd.Parameters.Add("P_ACTIVE", OracleDbType.NVarchar2).Value = Active;

                OracleParameter photoParam = cmd.Parameters.Add("P_PHOTO", OracleDbType.Blob);
                photoParam.Value = (object)Photo ?? DBNull.Value;

                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();

                if (message == "SUCCESSFULLY")
                    MessageBox.Show("Supplier Inserted Successfully");
                else
                    MessageBox.Show("Supplier already exists");
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
                OracleCommand cmd = new OracleCommand("SUPPLIER_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ID", OracleDbType.NVarchar2).Value = Id;
                cmd.Parameters.Add("P_SUPPLIERNAME", OracleDbType.NVarchar2).Value = Suppliername;
                cmd.Parameters.Add("P_SEX", OracleDbType.NVarchar2).Value = Sex;
                cmd.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = Phone;
                cmd.Parameters.Add("P_EMAIL", OracleDbType.NVarchar2).Value = Email;
                cmd.Parameters.Add("P_ADRESS", OracleDbType.NVarchar2).Value = Adress;
                cmd.Parameters.Add("P_ACTIVE", OracleDbType.NVarchar2).Value = Active;

                OracleParameter photoParam = cmd.Parameters.Add("P_PHOTO", OracleDbType.Blob);
                photoParam.Value = (object)Photo ?? DBNull.Value;

                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();

                if (message == "SUCCESSFULLY")
                    MessageBox.Show("Supplier Updated Successfully");
                else
                    MessageBox.Show("Update Failed: " + message);
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
                OracleCommand cmd = new OracleCommand("SUPPLIER_DELETE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ID", OracleDbType.NVarchar2).Value = Id;
                cmd.Parameters.Add("P_SMS", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                message = cmd.Parameters["P_SMS"].Value.ToString();

                if (message == "SUCCESSFULLY")
                    MessageBox.Show("Supplier Deleted Successfully");
                else
                    MessageBox.Show("Delete Failed: " + message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public DataSet SelectRecord()
        {
            OracleDataAdapter cmd = new OracleDataAdapter(
                "SELECT * FROM SUPPLIER_TBL WHERE ACTIVE=1 ORDER BY ID ASC", Program.cn);
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
