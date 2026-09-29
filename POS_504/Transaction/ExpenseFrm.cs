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
    public partial class ExpenseFrm : Form
    {
        ExpenseCls expense = new ExpenseCls();
        ExpenseTypeCls expenseType = new ExpenseTypeCls();
        UserCls user = new UserCls();
        PaymentMethodCls paymentMethod = new PaymentMethodCls();
        public ExpenseFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadExpenseData();
            LoadDropdowns();
            ClearInputs();
            LoadRecords();
            txtId.ReadOnly = true;
        }
        private void LoadExpenseData()
        {
            DataSet ds = expense.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvExpense.DataSource = ds.Tables[0];
                dgvExpense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LoadDropdowns()
        {
            try
            {
                DataSet dsUser = user.SelectRecord();
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    cboUser.DataSource = dsUser.Tables[0];
                    cboUser.DisplayMember = "USERNAME";
                    cboUser.ValueMember = "ID";
                    cboUser.SelectedIndex = -1;
                }

                DataSet dsexpenseType = expenseType.SelectAll();
                if (dsexpenseType != null && dsexpenseType.Tables.Count > 0)
                {
                    cboExpenseType.DataSource = dsexpenseType.Tables[0];
                    cboExpenseType.DisplayMember = "TYPENAME";
                    cboExpenseType.ValueMember = "ID";
                    cboExpenseType.SelectedIndex = -1;
                }

                DataSet dspaymentMethod = paymentMethod.SelectRecord();
                if (dspaymentMethod != null && dspaymentMethod.Tables.Count > 0)
                {
                    cboPaymentMethod.DataSource = dspaymentMethod.Tables[0];
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
            dtpExpenseDate.Enabled = false;
            cboPaymentMethod.Enabled = false;
            txtAmount.Enabled = false;
            cboExpenseType.Enabled = false;
            cboPaymentMethod.Enabled = false;
            cboUser.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = false;
        }
        private void ClearInputs()
        {
            txtId.Clear();
            dtpExpenseDate.Value = DateTime.Now;
            cboPaymentMethod.SelectedIndex = -1;
            cboExpenseType.SelectedIndex = -1;
            txtAmount.Clear();
            cboUser.SelectedIndex = -1;
            dtpExpenseDate.Enabled = true;
            cboPaymentMethod.Enabled = true;
            txtAmount.Enabled = true;
            cboExpenseType.Enabled = true;
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
            if (string.IsNullOrEmpty(txtAmount.Text) || cboExpenseType.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete Data!");
                return;
            }

            expense.ExpenseDate = dtpExpenseDate.Value.ToString("yyyy-MM-dd");
            expense.PaymentMethodId = cboPaymentMethod.SelectedValue?.ToString() ?? "1";
            expense.ExpenseTypeId = cboExpenseType.SelectedValue.ToString();
            expense.Amount = Convert.ToDecimal(txtAmount.Text);
            expense.UserId = cboUser.SelectedValue.ToString();

            if (expense.Insert())
            {
                MessageBox.Show("Insert successfully");
                LoadExpenseData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            expense.Id = txtId.Text;
            expense.ExpenseDate = dtpExpenseDate.Value.ToString("yyyy-MM-dd");
            expense.PaymentMethodId = cboPaymentMethod.SelectedValue.ToString();
            expense.ExpenseTypeId = cboExpenseType.SelectedValue.ToString();
            expense.Amount = Convert.ToDecimal(txtAmount.Text);
            expense.UserId = cboUser.SelectedValue.ToString();

            if (expense.Update())
            {
                MessageBox.Show("Update successfully!");
                LoadExpenseData();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show("Do you want delete this DATA?", "delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                expense.Id = txtId.Text;
                if (expense.Delete())
                {
                    MessageBox.Show("Delete successfully!");
                    LoadExpenseData();
                    ClearInputs();
                }
            }
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpense.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID"].Value.ToString();
                dtpExpenseDate.Value = DateTime.Parse(row.Cells["EXP_DATE"].Value.ToString());
                cboPaymentMethod.SelectedValue = row.Cells["PAYMENTMETHODID"].Value;
                cboExpenseType.Text = row.Cells["TYPENAME"].Value.ToString();
                txtAmount.Text = row.Cells["AMOUNT"].Value.ToString();
                dtpExpenseDate.Enabled = true;
                cboPaymentMethod.Enabled = true;
                txtAmount.Enabled = true;
                cboExpenseType.Enabled = true;
                cboPaymentMethod.Enabled = true;
                cboUser.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
