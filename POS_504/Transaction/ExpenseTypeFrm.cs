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
    public partial class ExpenseTypeFrm : Form
    {
        ExpenseTypeCls expenseType = new ExpenseTypeCls();
        public ExpenseTypeFrm()
        {
            InitializeComponent();
            LoadExpenseTypeData();
            ClearInputs();
            txtId.ReadOnly = true;
        }
        private void LoadExpenseTypeData()
        {
            DataSet ds = expenseType.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvExpenseType.DataSource = ds.Tables[0];
                dgvExpenseType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtName.Enabled = false;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please select DATA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            expenseType.TypeName = txtName.Text.Trim();
            expenseType.Active = chkActive.Checked ? 1 : 0;

            if (expenseType.Insert())
            {
                MessageBox.Show("Save successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadExpenseTypeData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            expenseType.Id = txtId.Text;
            expenseType.TypeName = txtName.Text.Trim();
            expenseType.Active = chkActive.Checked ? 1 : 0;

            if (expenseType.Update())
            {
                MessageBox.Show("Update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadExpenseTypeData();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult dr = MessageBox.Show("Do you want delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                expenseType.Id = txtId.Text;
                if (expenseType.Delete())
                {
                    MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadExpenseTypeData();
                    ClearInputs();
                }
            }
        }

        private void dgvExpenseType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenseType.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["TYPENAME"].Value.ToString();
                int activeStatus = Convert.ToInt32(row.Cells["ACTIVE"].Value);
                if (activeStatus == 1) chkActive.Checked = true;
                else chkActive.Checked = true;
                txtName.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
    }
}
