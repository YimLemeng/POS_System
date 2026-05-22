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

namespace POS_504.Transaction
{
    public partial class BeginingBalanceFrm : Form
    {
        BeginingBalanceCls balance = new BeginingBalanceCls();
        PaymentMethodCls paymentMethod = new PaymentMethodCls();
        UserCls userInfo = new UserCls();
        public BeginingBalanceFrm()
        {
            InitializeComponent();
            LoadGridData();
            LoadDropdowns();
            ClearInputs();
            LoadRecord();
            txtId.ReadOnly = true;
        }
        private void LoadGridData()
        {
            DataSet ds = balance.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvBalance.DataSource = ds.Tables[0];
                dgvBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadDropdowns()
        {
            try
            {
                DataSet dsMethod = paymentMethod.SelectRecord();
                if (dsMethod != null && dsMethod.Tables.Count > 0)
                {
                    cboPaymentMethod.DataSource = dsMethod.Tables[0];
                    cboPaymentMethod.DisplayMember = "METHODNAME";
                    cboPaymentMethod.ValueMember = "ID";
                    cboPaymentMethod.SelectedIndex = -1;
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
            catch (Exception ex) { MessageBox.Show("Dropdown Error: " + ex.Message); }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtAmount.Text = "0.00";
            dtpDate.Value = DateTime.Now;
            cboPaymentMethod.SelectedIndex = -1;
            cboUser.SelectedIndex = -1;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dtpDate.Focus();
        }
        private void LoadRecord()
        {
            txtAmount.Enabled = false;
            dtpDate.Enabled = false;
            cboPaymentMethod.Enabled = false;
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
            cboPaymentMethod.Enabled = true;
            cboUser.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboPaymentMethod.SelectedIndex == -1 || cboUser.SelectedIndex == -1)
            {
                MessageBox.Show("សូមបំពេញគណនី និងអ្នកប្រើប្រាស់ឱ្យបានគ្រប់គ្រាន់!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtAmount.Text, out decimal amt) || amt <= 0)
            {
                MessageBox.Show("Please insert correct balance!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            balance.BalanceDate = dtpDate.Value.ToString("yyyy-MM-dd");
            balance.PaymentMethodId = cboPaymentMethod.SelectedValue.ToString();
            balance.Amount = amt;
            balance.UserId = cboUser.SelectedValue.ToString();

            if (balance.Insert())
            {
                MessageBox.Show("Save successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            balance.Id = txtId.Text;
            balance.BalanceDate = dtpDate.Value.ToString("yyyy-MM-dd");
            balance.PaymentMethodId = cboPaymentMethod.SelectedValue.ToString();
            balance.Amount = Convert.ToDecimal(txtAmount.Text);
            balance.UserId = cboUser.SelectedValue.ToString();

            if (balance.Update())
            {
                MessageBox.Show("Update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show("Do you want delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                balance.Id = txtId.Text;
                if (balance.Delete())
                {
                    MessageBox.Show("Delete successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                    ClearInputs();
                }
            }
        }

        private void dgvBalance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBalance.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID"].Value.ToString();
                dtpDate.Value = DateTime.Parse(row.Cells["REG_DATE"].Value.ToString());
                cboPaymentMethod.SelectedValue = row.Cells["PAYMENTMETHODID"].Value;
                txtAmount.Text = Convert.ToDecimal(row.Cells["AMOUNT"].Value).ToString("N2");
                cboUser.SelectedValue = row.Cells["USERID"].Value;
                txtAmount.Enabled = true;
                dtpDate.Enabled = true;
                cboPaymentMethod.Enabled = true;
                cboUser.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
