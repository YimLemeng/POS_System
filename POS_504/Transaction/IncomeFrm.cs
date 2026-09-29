using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using POS_504.Class;

namespace POS_504.Setup
{
    public partial class IncomeFrm : Form
    {
        IncomeCls Income = new IncomeCls();
        IncomeTypeCls IncomeType = new IncomeTypeCls();
        UserCls user = new UserCls();
        PaymentMethodCls paymentMethod = new PaymentMethodCls();
        public IncomeFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadIncomeData();
            LoadDropdowns();
            ClearInputs();
            LoadRecords();
            txtId.ReadOnly = true;
        }
        private void LoadIncomeData()
        {
            System.Data.DataSet ds = Income.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvIncome.DataSource = ds.Tables[0];
                dgvIncome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LoadDropdowns()
        {
            try
            {
                System.Data.DataSet dsUser = user.SelectRecord();
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    cboUser.DataSource = dsUser.Tables[0];
                    cboUser.DisplayMember = "USERNAME";
                    cboUser.ValueMember = "ID";
                    cboUser.SelectedIndex = -1;
                }

                System.Data.DataSet dsImcometype = IncomeType.SelectAll();
                if (dsImcometype != null && dsImcometype.Tables.Count > 0)
                {
                    cboIncomeType.DataSource = dsImcometype.Tables[0];
                    cboIncomeType.DisplayMember = "TYPENAME";
                    cboIncomeType.ValueMember = "ID";
                    cboIncomeType.SelectedIndex = -1;
                }

                System.Data.DataSet dspaymentmethod = paymentMethod.SelectRecord();
                if (dspaymentmethod != null && dspaymentmethod.Tables.Count > 0)
                {
                    cboPaymentMethod.DataSource = dspaymentmethod.Tables[0];
                    cboPaymentMethod.DisplayMember = "METHODNAME";
                    cboPaymentMethod.ValueMember = "ID";
                    cboPaymentMethod.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadRecords()
        {
            dtpIncomeDate.Enabled = false;
            cboPaymentMethod.Enabled = false;
            txtAmount.Enabled = false;
            cboIncomeType.Enabled = false;
            cboPaymentMethod.Enabled = false;
            cboUser.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = false;
        }
        private void ClearInputs()
        {
            txtId.Clear();
            dtpIncomeDate.Value = DateTime.Now;
            cboPaymentMethod.SelectedIndex = -1;
            cboIncomeType.SelectedIndex = -1;
            txtAmount.Clear();
            cboUser.SelectedIndex = -1;
            dtpIncomeDate.Enabled = true;
            cboPaymentMethod.Enabled = true;
            txtAmount.Enabled = true;
            cboIncomeType.Enabled = true;
            cboPaymentMethod.Enabled = true;
            cboUser.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text) || cboIncomeType.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete Data!");
                return;
            }

            Income.IncomeDate = dtpIncomeDate.Value.ToString("yyyy-MM-dd");
            Income.PaymentMethodId = cboPaymentMethod.SelectedValue?.ToString() ?? "1";
            Income.IncomeTypeId = cboIncomeType.SelectedValue.ToString();
            Income.Amount = Convert.ToDecimal(txtAmount.Text);
            Income.UserId = cboUser.SelectedValue.ToString();

            if (Income.Insert())
            {
                MessageBox.Show("Insert successfully");
                LoadIncomeData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            Income.Id = txtId.Text;
            Income.IncomeDate = dtpIncomeDate.Value.ToString("yyyy-MM-dd");
            Income.PaymentMethodId = cboPaymentMethod.SelectedValue.ToString();
            Income.IncomeTypeId = cboIncomeType.SelectedValue.ToString();
            Income.Amount = Convert.ToDecimal(txtAmount.Text);
            Income.UserId = cboUser.SelectedValue.ToString();

            if (Income.Update())
            {
                MessageBox.Show("Update successfully!");
                LoadIncomeData();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show("Do you want delete this DATA?", "delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Income.Id = txtId.Text;
                if (Income.Delete())
                {
                    MessageBox.Show("Delete successfully!");
                    LoadIncomeData();
                    ClearInputs();
                }
            }
        }

        private void dgvIncome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIncome.Rows[e.RowIndex];

                txtId.Text = row.Cells["ID"].Value.ToString();
                dtpIncomeDate.Value = DateTime.Parse(row.Cells["INC_DATE"].Value.ToString());
                cboPaymentMethod.SelectedValue = row.Cells["PAYMENTMETHODID"].Value;
                cboIncomeType.Text = row.Cells["TYPENAME"].Value.ToString();
                txtAmount.Text = Convert.ToDecimal(row.Cells["AMOUNT"].Value).ToString("N2");
                cboUser.SelectedValue = row.Cells["USERID"].Value;
                dtpIncomeDate.Enabled = true;
                cboPaymentMethod.Enabled = true;
                txtAmount.Enabled = true;
                cboIncomeType.Enabled = true;
                cboPaymentMethod.Enabled = true;
                cboUser.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
