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
    public partial class UnitFrm : Form
    {
        UnitCls unit = new UnitCls();
        public UnitFrm()
        {
            InitializeComponent();
            LoadRecord();
        }
        private void LoadRecord()
        {
            DGV.DataSource = unit.SelectRecord().Tables[0];
            txtId.Text = "";
            txtName.Text = "";
            numQty.Value = 0;
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            unit.Unitname = txtName.Text;
            unit.Qty = numQty.Value;
            unit.Insert();
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select Record first!");
                return;
            }
            unit.Id = txtId.Text;
            unit.Unitname = txtName.Text;
            unit.Qty = numQty.Value;
            unit.Update();
            LoadRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            unit.Id = txtId.Text;
            unit.Delete();
            LoadRecord();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtId.Text = DGV.CurrentRow.Cells["ID"].Value.ToString();
            txtName.Text = DGV.CurrentRow.Cells["UNITNAME"].Value.ToString();
            numQty.Value = Convert.ToDecimal(DGV.CurrentRow.Cells["QTY"].Value);
            txtName.Enabled = true;
            numQty.Enabled = true;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }
    }
}
