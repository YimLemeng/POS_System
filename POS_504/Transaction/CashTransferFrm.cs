using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_504.Class;

namespace POS_504.Setup
{
    public partial class CashTransferFrm : Form
    {
        CashTransferCls transfer = new CashTransferCls();
        PaymentMethodCls paymentMethod = new PaymentMethodCls();
        UserCls userInfo = new UserCls();
        public CashTransferFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadTransferData();
            LoadDropdowns();
            ClearInputs();
            LoadRecord();
        }
        private void LoadTransferData()
        {
            DataSet ds = transfer.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvTransfer.DataSource = ds.Tables[0];
                dgvTransfer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LoadDropdowns()
        {
            try
            {
                DataSet dsMethod = paymentMethod.SelectRecord();

                if (dsMethod != null && dsMethod.Tables.Count > 0)
                {
                    DataTable dtFrom = dsMethod.Tables[0].Copy();
                    DataTable dtTo = dsMethod.Tables[0].Copy();
                    cboPaymentMethodFrom.DataSource = dtFrom;
                    cboPaymentMethodFrom.DisplayMember = "METHODNAME";
                    cboPaymentMethodFrom.ValueMember = "ID";
                    cboPaymentMethodFrom.SelectedIndex = -1;

                    cboPaymentMethodTo.DataSource = dtTo;
                    cboPaymentMethodTo.DisplayMember = "METHODNAME";
                    cboPaymentMethodTo.ValueMember = "ID";
                    cboPaymentMethodTo.SelectedIndex = -1;
                }

                DataSet dsUser = userInfo.SelectRecord();
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    cboUser.DataSource = dsUser.Tables[0];
                    cboUser.DisplayMember = "USERNAME";
                    cboUser.ValueMember = "ID";
                    cboUser.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Dropdowns: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            txtId.Clear();
            txtAmount.Text = "0.00";
            dtpDate.Value = DateTime.Now;
            cboPaymentMethodFrom.SelectedIndex = -1;
            cboPaymentMethodTo.SelectedIndex = -1;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dtpDate.Focus();
        }
        private void LoadRecord()
        {
            txtAmount.Enabled = false;
            dtpDate.Enabled = false;
            cboPaymentMethodFrom.Enabled = false;
            cboPaymentMethodTo.Enabled = false;
            cboUser.Enabled = false;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtAmount.Enabled = true;
            dtpDate.Enabled = true;
            cboPaymentMethodFrom.Enabled = true;
            cboPaymentMethodTo.Enabled = true;
            cboUser.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboPaymentMethodFrom.SelectedIndex == -1 || cboPaymentMethodTo.SelectedIndex == -1)
            {
                MessageBox.Show("សូមជ្រើសរើសគណនីផ្ទេរចេញ និងគណនីទទួលលុយឱ្យបានត្រឹមត្រូវ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPaymentMethodFrom.SelectedValue.ToString() == cboPaymentMethodTo.SelectedValue.ToString())
            {
                MessageBox.Show("គណនីផ្ទេរចេញ និងគណនីទទួលលុយ មិនអាចជាន់គ្នា/ដូចគ្នាបានទេ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("PLease enter Balance > 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }
            transfer.TransferDate = dtpDate.Value.ToString("yyyy-MM-dd");
            transfer.PaymentMethodIdFrom = cboPaymentMethodFrom.SelectedValue.ToString();
            transfer.PaymentMethodIdTo = cboPaymentMethodTo.SelectedValue.ToString();
            transfer.Amount = amount;
            transfer.UserId = cboUser.SelectedValue.ToString();

            if (transfer.Insert())
            {
                MessageBox.Show("Insert successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransferData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            if (cboPaymentMethodFrom.SelectedIndex == -1 || cboPaymentMethodTo.SelectedIndex == -1)
            {
                MessageBox.Show("សូមជ្រើសរើសគណនីឱ្យបានគ្រប់គ្រាន់!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboPaymentMethodFrom.SelectedValue.ToString() == cboPaymentMethodTo.SelectedValue.ToString())
            {
                MessageBox.Show("គណនីផ្ទេរចេញ និងគណនីទទួលលុយ មិនអាចដូចគ្នាបានទេ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            transfer.Id = txtId.Text;
            transfer.TransferDate = dtpDate.Value.ToString("yyyy-MM-dd");
            transfer.PaymentMethodIdFrom = cboPaymentMethodFrom.SelectedValue.ToString();
            transfer.PaymentMethodIdTo = cboPaymentMethodTo.SelectedValue.ToString();
            transfer.Amount = Convert.ToDecimal(txtAmount.Text);
            transfer.UserId = cboUser.SelectedValue.ToString();

            if (transfer.Update())
            {
                MessageBox.Show("Update sucessful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransferData();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show("Do you want delete?", "Delete DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                transfer.Id = txtId.Text;
                if (transfer.Delete())
                {
                    MessageBox.Show("Delete successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransferData();
                    ClearInputs();
                }
            }
        }

        private void dgvTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransfer.Rows[e.RowIndex];

                txtId.Text = row.Cells["ID"].Value.ToString();
                dtpDate.Value = DateTime.Parse(row.Cells["TRANS_DATE"].Value.ToString());
                cboPaymentMethodFrom.SelectedValue = row.Cells["PAYMENTMETHODID_FROM"].Value;
                cboPaymentMethodTo.SelectedValue = row.Cells["PAYMENTMETHODID_TO"].Value;
                txtAmount.Text = Convert.ToDecimal(row.Cells["AMOUNT"].Value).ToString("N2");
                txtAmount.Enabled = true;
                dtpDate.Enabled = true;
                cboPaymentMethodFrom.Enabled = true;
                cboPaymentMethodTo.Enabled = true;
                cboUser.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
