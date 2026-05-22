using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace POS_504.Class
{
    internal class BookingCls
    {
        private string _id;
        private string _bookingdate;
        private string _fromdate;
        private string _todate;
        private string _customerid;
        private string _userid;

        public string Id { get => _id; set => _id = value; }
        public string Bookingdate { get => _bookingdate; set => _bookingdate = value; }
        public string Fromdate { get => _fromdate; set => _fromdate = value; }
        public string Todate { get => _todate; set => _todate = value; }
        public string Customerid { get => _customerid; set => _customerid = value; }
        public string Userid { get => _userid; set => _userid = value; }

        public void Insert()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("BOOKING_INSERT", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_bookingdate", OracleDbType.Date).Value = DateTime.Parse(Bookingdate);
                    cmd.Parameters.Add("p_fromdate", OracleDbType.Date).Value = DateTime.Parse(Fromdate);
                    cmd.Parameters.Add("p_todate", OracleDbType.Date).Value = DateTime.Parse(Todate);
                    cmd.Parameters.Add("p_customerid", OracleDbType.Int64).Value = Convert.ToInt64(Customerid);
                    cmd.Parameters.Add("p_userid", OracleDbType.Int64).Value = Convert.ToInt64(Userid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void Update()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("BOOKING_UPDATE", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = Convert.ToInt64(Id);
                    cmd.Parameters.Add("p_bookingdate", OracleDbType.Date).Value = DateTime.Parse(Bookingdate);
                    cmd.Parameters.Add("p_fromdate", OracleDbType.Date).Value = DateTime.Parse(Fromdate);
                    cmd.Parameters.Add("p_todate", OracleDbType.Date).Value = DateTime.Parse(Todate);
                    cmd.Parameters.Add("p_customerid", OracleDbType.Int64).Value = Convert.ToInt64(Customerid);
                    cmd.Parameters.Add("p_userid", OracleDbType.Int64).Value = Convert.ToInt64(Userid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void Delete()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("BOOKING_DELETE", Program.cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_id", OracleDbType.Int64).Value = Convert.ToInt64(Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public DataTable SelectRecord()
        {
            try
            {
               using(OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM Booking_v ORDER BY bookingdate DESC", Program.cn))
                {
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch { return null; }
        }
        public DataTable SelectCustomer()
        {
            try
            {
                using (OracleDataAdapter da = new OracleDataAdapter("SELECT id, customername FROM Customers_tbl ORDER BY customername", Program.cn))
                {
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch { return null; }
        }
        public DataTable SelectUser()
        {
            try
            {
                using (OracleDataAdapter da = new OracleDataAdapter("SELECT id, username FROM Users_tbl ORDER BY username", Program.cn))
                {
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch { return null; }
        }
    }
}
