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
    internal class StaffCls
    {
        private string _id;
        private string _staffname;
        private string _sex;
        private string _phone;
        private string _email;
        private string _adress;
        private byte[] _photo; 
        private string _active;
        public string Id { get => _id; set => _id = value; }
        public string Staffname { get => _staffname; set => _staffname = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public byte[] Photo { get => _photo; set => _photo = value; }
        public string Active { get => _active; set => _active = value; }

        public void Insert()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("STAFF_INSERT", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_STAFFNAME", OracleDbType.NVarchar2).Value = Staffname;
                cmd.Parameters.Add("P_SEX", OracleDbType.NVarchar2).Value = Sex;
                cmd.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = Phone;
                cmd.Parameters.Add("P_EMAIL", OracleDbType.NVarchar2).Value = Email;
                cmd.Parameters.Add("P_ADRESS", OracleDbType.NVarchar2).Value = Adress;
                cmd.Parameters.Add("P_PHOTO", OracleDbType.Blob).Value = Photo;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Insert Successful");
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
                OracleCommand cmd = new OracleCommand("STAFF_UPDATE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Convert.ToInt64(Id);
                cmd.Parameters.Add("P_STAFFNAME", OracleDbType.NVarchar2).Value = Staffname;
                cmd.Parameters.Add("P_SEX", OracleDbType.NVarchar2).Value = Sex;
                cmd.Parameters.Add("P_PHONE", OracleDbType.NVarchar2).Value = Phone;
                cmd.Parameters.Add("P_EMAIL", OracleDbType.NVarchar2).Value = Email;
                cmd.Parameters.Add("P_ADRESS", OracleDbType.NVarchar2).Value = Adress;
                cmd.Parameters.Add("P_PHOTO", OracleDbType.Blob).Value = Photo;
                cmd.Parameters.Add("P_ACTIVE", OracleDbType.Int16).Value = Convert.ToInt16(Active);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Update Successful");
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
                OracleCommand cmd = new OracleCommand("STAFF_DELETE", Program.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ID", OracleDbType.Int64).Value = Convert.ToInt64(Id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Delete Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public DataSet SelectRecord()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Staff_tbl", Program.cn);
            DataSet ds = new DataSet();
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
