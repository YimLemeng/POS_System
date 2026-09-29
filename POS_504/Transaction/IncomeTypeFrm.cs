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
    public partial class IncomeTypeFrm : Form
    {
        IncomeTypeCls incometype = new IncomeTypeCls();
        public IncomeTypeFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadExpenseTypeData();
            ClearInputs();
            txtId.ReadOnly = true;
        }
        private void LoadExpenseTypeData()
        {
            DataSet ds = incometype.SelectAll();
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvIncomeType.DataSource = ds.Tables[0];
                dgvIncomeType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please select DATA!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            incometype.TypeName = txtName.Text.Trim();
            incometype.Active = chkActive.Checked ? 1 : 0;

            if (incometype.Insert())
            {
                MessageBox.Show("Save successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadExpenseTypeData();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            incometype.Id = txtId.Text;
            incometype.TypeName = txtName.Text.Trim();
            incometype.Active = chkActive.Checked ? 1 : 0;

            if (incometype.Update())
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
                incometype.Id = txtId.Text;
                if (incometype.Delete())
                {
                    MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadExpenseTypeData();
                    ClearInputs();
                }
            }
        }

        private void dgvIncomeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIncomeType.Rows[e.RowIndex];
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
