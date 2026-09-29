using POS_504.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Setup
{
    public partial class SupplierFrm : Form
    {
        SupplierCls sup = new SupplierCls();
        public SupplierFrm()
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            LoadRecord();
            cboSex.Items.Add("Male");
            cboSex.Items.Add("Female");
        }
        private void LoadRecord()
        {
            DGV.DataSource = sup.SelectRecord().Tables[0];
            txtId.ReadOnly = true;
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

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Enabled = true;
            cboSex.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtAdress.Enabled = true;
            chkActive.Enabled = true;
            btnBrowse.Enabled = true;
            txtId.Text = DGV.CurrentRow.Cells["ID"].Value.ToString();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtId.Text = DGV.CurrentRow.Cells["ID"].Value.ToString();
            txtName.Text = DGV.CurrentRow.Cells["SUPPLIERNAME"].Value.ToString();
            cboSex.Text = DGV.CurrentRow.Cells["SEX"].Value.ToString();
            txtPhone.Text = DGV.CurrentRow.Cells["PHONE"].Value.ToString();
            txtEmail.Text = DGV.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtAdress.Text = DGV.CurrentRow.Cells["ADRESS"].Value.ToString();

            int active = int.Parse(DGV.CurrentRow.Cells["ACTIVE"].Value.ToString());
            chkActive.Checked = (active == 1);

            // load photo
            object photoVal = DGV.CurrentRow.Cells["PHOTO"].Value;
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
            sup.Suppliername = txtName.Text;
            sup.Sex = cboSex.Text;
            sup.Phone = txtPhone.Text;
            sup.Email = txtEmail.Text;
            sup.Adress = txtAdress.Text;
            sup.Active = chkActive.Checked ? "1" : "0";
            sup.Photo = GetPhotoBytes();

            sup.Insert();
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sup.Id = txtId.Text;
            sup.Suppliername = txtName.Text;
            sup.Sex = cboSex.Text;
            sup.Phone = txtPhone.Text;
            sup.Email = txtEmail.Text;
            sup.Adress = txtAdress.Text;
            sup.Active = chkActive.Checked ? "1" : "0";
            sup.Photo = GetPhotoBytes();

            sup.Update();
            LoadRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sup.Id = txtId.Text;
            sup.Delete();
            LoadRecord();
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
                using (Bitmap bmp = new Bitmap(picPhoto.Image))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return ms.ToArray();
            }
        }
        private void ClearForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            cboSex.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";
            chkActive.Checked = true;
            picPhoto.Image = null;
        }
    }
}
