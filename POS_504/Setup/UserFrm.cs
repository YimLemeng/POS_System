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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace POS_504.Setup
{
    public partial class UserFrm : Form
    {
        UserCls user = new UserCls();
        public UserFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadRecord();
            BindSelectStaff();
            txtId.ReadOnly = true;
        }

        private void LoadRecord()
        {
            dgvUser.DataSource = user.SelectRecord().Tables[0];
            txtId.BackColor = SystemColors.Control;
            cboStaffId.Enabled = false;
            txtName.Enabled = false;
            txtPassword.Enabled = false;
            dtpdate.Enabled = false;
            chkActive.Enabled = false;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void ClearForm()
        {
            txtId.Text = "";
            cboStaffId.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            dtpdate.Value = DateTime.Now;
            chkActive.Checked = false;
        }
        private void BindSelectStaff()
        {
            DataSet dt = user.SelectStaffId();
            if (dt != null && dt.Tables[0].Rows.Count > 0)
            {
                cboStaffId.DataSource = dt.Tables[0];
                cboStaffId.DisplayMember = "staffname";
                cboStaffId.ValueMember = "id";   
                cboStaffId.SelectedIndex = -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cboStaffId.Enabled = true;
            txtName.Enabled = true;
            txtPassword.Enabled = true;
            dtpdate.Enabled = true;
            chkActive.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ClearForm();
            cboStaffId.Focus();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cboStaffId.Enabled = true;
                txtName.Enabled = true;
                txtPassword.Enabled = true;
                dtpdate.Enabled = true;
                chkActive.Enabled = true;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];
                txtId.Text = row.Cells["ID"].Value.ToString();
                if (row.Cells["STAFFID"].Value != DBNull.Value && row.Cells["STAFFID"].Value != null)
                {
                    cboStaffId.SelectedValue = row.Cells["STAFFID"].Value;
                }
                txtName.Text = row.Cells["USERNAME"].Value.ToString();
                txtPassword.Text = row.Cells["PASSWORD"].Value.ToString();
                if (row.Cells["EXPIREDDATE"].Value != DBNull.Value && row.Cells["EXPIREDDATE"].Value != null)
                {
                    dtpdate.Value = Convert.ToDateTime(row.Cells["EXPIREDDATE"].Value);
                }
                else
                {
                    dtpdate.Value = DateTime.Now;
                }
                if (row.Cells["ACTIVE"].Value != DBNull.Value && row.Cells["ACTIVE"].Value != null)
                {
                    chkActive.Checked = Convert.ToInt16(row.Cells["ACTIVE"].Value) == 1 ? true : false;
                }
                else
                {
                    chkActive.Checked = false;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            user.Staffid = cboStaffId.SelectedValue.ToString();
            user.Username = txtName.Text;
            user.Password = txtPassword.Text;
            user.Expireddate = dtpdate.Value.ToString("yyyy-MM-dd");
            user.Insert();
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            user.Id = txtId.Text;
            user.Staffid = cboStaffId.SelectedValue.ToString();
            user.Username = txtName.Text;
            user.Password = txtPassword.Text;
            user.Expireddate = dtpdate.Value.ToString("yyyy-MM-dd");
            user.Active = chkActive.Checked ? "1" : "0";
            user.Update();
            LoadRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            user.Id = txtId.Text;
            user.Delete();
            user.Update();
            ClearForm();
        }
    }
}