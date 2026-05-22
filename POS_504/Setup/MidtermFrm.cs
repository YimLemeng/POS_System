using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using POS_504.Class;

namespace POS_504.Setup
{
    public partial class MidtermFrm : Form
    {
        BookingCls bo = new BookingCls();
        public MidtermFrm()
        {
            InitializeComponent();
            LoadCustomerCombo();
            LoadUserCombo();
            LoadRecord();
            txtId.ReadOnly = true;
        }
        private void LoadCustomerCombo()
        {
            DataTable dt = bo.SelectCustomer();
            if (dt != null)
            {
                cboCustomer.DisplayMember = "CUSTOMERNAME";
                cboCustomer.ValueMember = "ID";
                cboCustomer.DataSource = dt;
                cboCustomer.SelectedIndex = -1;

            }
        }

        private void LoadUserCombo()
        {
            DataTable dt = bo.SelectUser();
            if (dt != null)
            {
                cboUser.DisplayMember = "USERNAME";
                cboUser.ValueMember = "ID";
                cboUser.DataSource = dt;
                cboUser.SelectedIndex = -1;
            }
        }
        private void LoadRecord()
        {
            DataTable dt = bo.SelectRecord();
            if (dt != null)
            {
                dgvBooking.DataSource = dt;
            }
            ClearForm();
        }
        private void ClearForm()
        {
            txtId.Clear();
            cboCustomer.SelectedIndex = -1;
            cboUser.SelectedIndex = -1;
            dtpBookingDate.Value = DateTime.Today;
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null || cboUser.SelectedValue == null ||
                cboCustomer.SelectedIndex == -1 || cboUser.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Customer and User!");
                return;
            }
            try
            {
                bo.Bookingdate = dtpBookingDate.Value.ToString("yyyy-MM-dd");
                bo.Fromdate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                bo.Todate = dtpToDate.Value.ToString("yyyy-MM-dd");
                bo.Customerid = cboCustomer.SelectedValue.ToString();
                bo.Userid = cboUser.SelectedValue.ToString();
                bo.Insert();
                LoadRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select Booking to Update!");
                return;
            }
            if (cboCustomer.SelectedValue == null || cboUser.SelectedValue == null)
            {
                MessageBox.Show("Please select Customer and User!");
                return;
            }
            try
            {
                bo.Id = txtId.Text;
                bo.Bookingdate = dtpBookingDate.Value.ToString("yyyy-MM-dd");
                bo.Fromdate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                bo.Todate = dtpToDate.Value.ToString("yyyy-MM-dd");
                bo.Customerid = cboCustomer.SelectedValue.ToString();
                bo.Userid = cboUser.SelectedValue.ToString();
                bo.Update();
                LoadRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select Booking to Delete!");
                return;
            }
            try
            {
                bo.Id = txtId.Text;
                bo.Delete();
                LoadRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvBooking.CurrentRow;
                txtId.Text = row.Cells["ID"].Value.ToString();
                dtpBookingDate.Value = Convert.ToDateTime(row.Cells["BOOKINGDATE"].Value);
                dtpFromDate.Value = Convert.ToDateTime(row.Cells["FROMDATE"].Value);
                dtpToDate.Value = Convert.ToDateTime(row.Cells["TODATE"].Value);

                if (row.Cells["CUSTOMERID"] != null && row.Cells["CUSTOMERID"].Value != DBNull.Value)
                    cboCustomer.SelectedValue = Convert.ToInt32(row.Cells["CUSTOMERID"].Value);
                if (row.Cells["USERID"] != null && row.Cells["USERID"].Value != DBNull.Value)
                    cboUser.SelectedValue = Convert.ToInt32(row.Cells["USERID"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
