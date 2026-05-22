using POS_504.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Setup
{
    public partial class CategoryFrm : Form
    {
        CategoryCls cat = new CategoryCls();
        public CategoryFrm()
        {
            InitializeComponent();
            LoadRecord();
        }

        private void LoadRecord()
        {
            DGV.DataSource = cat.SelectRecord().Tables[0];
            txtName.Enabled = false;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtName.Focus();
            btnInsert.Enabled = true;
            txtName.Text = "";
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtName.Enabled = true;
            txtId.Text = DGV.CurrentRow.Cells["ID"].Value.ToString();
            txtName.Text = DGV.CurrentRow.Cells["CATNAME"].Value.ToString();
            int active = int.Parse(DGV.CurrentRow.Cells["ACTIVE"].Value.ToString());
            if(active == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cat.Catname = txtName.Text;
            cat.Insert();
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cat.Id = txtId.Text;
            cat.Catname = txtName.Text;
            cat.Update();
            LoadRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cat.Id = txtId.Text;
            cat.Delete();
            LoadRecord();
        }
    }
}
