using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_504.Class;

namespace POS_504.Setup
{
    public partial class StaffFrm : Form
    {
        StaffCls staff = new StaffCls();
        public StaffFrm()
        {
            InitializeComponent();
            LoadRecord();
            cboSex.Items.Add("Male");
            cboSex.Items.Add("Female");
            txtstaffId.ReadOnly = true;
        }
        private void LoadRecord()
        {
            dgvStaff.DataSource = staff.SelectRecord().Tables[0];
            txtstaffId.BackColor = SystemColors.Control;
            txtName.Enabled = false;
            cboSex.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtAdress.Enabled = false;
            chkActive.Enabled = false;
            btnBrowse.Enabled = false;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            cboSex.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtAdress.Enabled = true;
            chkActive.Enabled = true;
            btnBrowse.Enabled = true;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            ClearForm();
            txtName.Focus();
        }
        private void ClearForm()
        {
            txtstaffId.Text = "";
            txtName.Text = "";
            cboSex.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";
            chkActive.Checked = true;
            picPhoto.Image = null;
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtName.Enabled = true;
            cboSex.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtAdress.Enabled = true;
            chkActive.Enabled = true;
            btnBrowse.Enabled = true;

            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtstaffId.Text = dgvStaff.CurrentRow.Cells["ID"].Value.ToString();
            txtName.Text = dgvStaff.CurrentRow.Cells["STAFFNAME"].Value.ToString();
            cboSex.Text = dgvStaff.CurrentRow.Cells["SEX"].Value.ToString();
            txtPhone.Text = dgvStaff.CurrentRow.Cells["PHONE"].Value.ToString();
            txtEmail.Text = dgvStaff.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtAdress.Text = dgvStaff.CurrentRow.Cells["ADDRESS"].Value.ToString();

            int active = int.Parse(dgvStaff.CurrentRow.Cells["ACTIVE"].Value.ToString());
            chkActive.Checked = (active == 1);

            object photoVal = dgvStaff.CurrentRow.Cells["PHOTO"].Value;
            if (photoVal != DBNull.Value && photoVal != null)
            {
                byte[] photoBytes = (byte[])photoVal;
                using (MemoryStream ms = new MemoryStream(photoBytes))
                {
                    picPhoto.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picPhoto.Image = null;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            staff.Staffname = txtName.Text;
            staff.Sex = cboSex.Text;
            staff.Phone = txtPhone.Text;
            staff.Email = txtEmail.Text;
            staff.Adress = txtAdress.Text;
            staff.Active = chkActive.Checked ? "1" : "0";
            staff.Photo = GetPhotoBytes();

            staff.Insert();
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            staff.Id = txtstaffId.Text;
            staff.Staffname = txtName.Text;
            staff.Sex = cboSex.Text;
            staff.Phone = txtPhone.Text;
            staff.Email = txtEmail.Text;
            staff.Adress = txtAdress.Text;
            staff.Active = chkActive.Checked ? "1" : "0";
            staff.Photo = GetPhotoBytes();

            staff.Update();
            LoadRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            staff.Id = txtstaffId.Text;
            staff.Delete();
            LoadRecord();
            ClearForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picPhoto.Image = Image.FromFile(ofd.FileName);
            }
        }
        private byte[] GetPhotoBytes()
        {
            if (picPhoto.Image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                picPhoto.Image.Save(ms, picPhoto.Image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
