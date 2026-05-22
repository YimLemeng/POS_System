using Oracle.ManagedDataAccess.Client;
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
    public partial class ProductFrm : Form
    {
        ProductCls pro = new ProductCls();
        ProductUnitCls prounit = new ProductUnitCls();
        public ProductFrm()
        {
            InitializeComponent();
            BindSelectSupplier();
            BindSelectCategory();
            dgvProduct.AutoGenerateColumns = true;
            LoadRecords();
           
            BoundCboDGV(unittypeid, "SELECT ID, UNITNAME || '-' || QTY AS UNAME FROM UNIT_TBL");
            txtId.ReadOnly = true;

        }
        private void LoadRecords()
        {
            dgvProduct.DataSource = pro.SelectRecord().Tables[0];
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtProName.Enabled = false;
            txtBarcode.Enabled = false;
            txtProCode.Enabled = false;
            txtProNameKh.Enabled = false;
            cboCategory.Enabled = false;
            cboSupplier.Enabled = false;
            cboStock.Enabled = false;
            txtQtyonhand.Enabled = false;
            txtQtyAlert.Enabled = false;
            dgvProduct.Columns[0].Visible = false;
            dgvProductUnit.Columns[0].Visible = false;
            dgvProductUnit.Columns[1].Visible = false;

        }
        private void BindSelectSupplier()
        {
            DataSet ds = pro.SelectSupplier();
            cboSupplier.DataSource = ds.Tables[0];
            cboSupplier.DisplayMember = "Suppliername";
            cboSupplier.ValueMember = "Id";
        }
        private void BindSelectCategory()
        {
            DataSet ds = pro.SelectCategory();
            cboCategory.DataSource = ds.Tables[0];
            cboCategory.DisplayMember = "Catname";
            cboCategory.ValueMember = "Id";
        }
        private void BoundCboDGV(DataGridViewComboBoxColumn cbo, String sqlText)
        {
            try
            {
                DataTable tbl = new DataTable();
                OracleDataAdapter dap = new OracleDataAdapter(sqlText, Program.cn);
                dap.Fill(tbl);
                cbo.DataSource = tbl;
                cbo.DisplayMember = tbl.Columns[1].ColumnName;
                cbo.ValueMember = tbl.Columns[0].ColumnName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileName != null)
            {
                picPicture.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OracleTransaction tran;
            tran = Program.cn.BeginTransaction();
            try
            {
                SetData();
                if (pro.Insert(tran))
                {
                    foreach (DataGridViewRow dr in dgvProductUnit.Rows)
                    {
                        if (dr.Cells[2].Value != null)
                        {
                            prounit.Productid = pro.Id;
                            prounit.Unittypeid = dr.Cells[2].Value.ToString();
                            prounit.Cost = dr.Cells[3].Value.ToString();
                            prounit.Price = dr.Cells[4].Value.ToString();
                            bool isChecked = Convert.ToBoolean(dr.Cells[5].Value);
                            if (isChecked)
                            {
                                prounit.Defaults = "1";
                            }
                            else
                            {
                                prounit.Defaults = "0";
                            }
                            if (prounit.Insert(tran) == false)
                            {
                                tran.Rollback();
                                return;
                            }
                        }
                    }
                    tran.Commit();
                    LoadRecords();
                }

            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());
            }
        }
        private void SetData()
        {
            pro.Productcode = txtProCode.Text;
            pro.Barcode = txtBarcode.Text;
            pro.Productname = txtProName.Text;
            pro.Productnamekh = txtProNameKh.Text;
            pro.Categoryid = cboCategory.SelectedValue.ToString();
            pro.Supplierid = cboSupplier.SelectedValue.ToString();
            pro.Stocktype = cboStock.Text;
            pro.Qtyonhand = txtQtyonhand.Text;
            pro.Qtyalert = txtQtyAlert.Text;
            GetImage(picPicture);
        }
        public void GetImage(PictureBox picPhoto)
        {
            if (picPhoto.Image == null)
            {
                pro.Picture = DBNull.Value;
                return;
            }

            using (var ms = new System.IO.MemoryStream())
            {
                using (var bmp = new Bitmap(picPhoto.Image))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                pro.Picture = ms.ToArray();
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProCode.Enabled = true;
            txtBarcode.Enabled = true;
            txtProName.Enabled = true;
            txtProNameKh.Enabled = true;
            cboCategory.Enabled = true;
            cboSupplier.Enabled = true;
            cboStock.Enabled = true;
            txtQtyonhand.Enabled = true;
            txtQtyAlert.Enabled = true;
            txtId.Text = dgvProduct.CurrentRow.Cells[0].Value.ToString();
            txtProCode.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
            txtBarcode.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
            txtProName.Text = dgvProduct.CurrentRow.Cells[3].Value.ToString();
            txtProNameKh.Text = dgvProduct.CurrentRow.Cells[4].Value.ToString();
            cboCategory.SelectedValue = dgvProduct.CurrentRow.Cells[5].Value.ToString();
            cboSupplier.SelectedValue = dgvProduct.CurrentRow.Cells[6].Value.ToString();
            cboStock.Text = dgvProduct.CurrentRow.Cells[7].Value.ToString();
            txtQtyonhand.Text = dgvProduct.CurrentRow.Cells[8].Value.ToString();
            txtQtyAlert.Text = dgvProduct.CurrentRow.Cells[9].Value.ToString();
            if (dgvProduct.CurrentRow.Cells[10].Value != DBNull.Value && dgvProduct.CurrentRow.Cells[10].Value.ToString() != "")
            {
                byte[] Photo = (byte[])dgvProduct.CurrentRow.Cells[10].Value;
                if (Photo.Length > 1)
                {
                    PictureBox pic = picPicture;
                    using (System.IO.MemoryStream streamPhoto = new System.IO.MemoryStream(Photo, true))
                    {
                        streamPhoto.Write(Photo, 0, Photo.Length);
                        Bitmap bmp = new Bitmap(streamPhoto);
                        Bitmap bmp1 = new Bitmap(bmp, new Size(870, 1130));
                        pic.Image = bmp1;
                    }
                }
            }
            dgvProductUnit.Rows.Clear();
            DataTable dt = prounit.SelectRecord(dgvProduct.CurrentRow.Cells[0].Value.ToString()).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                dgvProductUnit.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prounit.Id = dgvProductUnit.CurrentRow.Cells[0].Value.ToString();
            prounit.Delete();
            dgvProductUnit.Rows.RemoveAt(dgvProductUnit.CurrentRow.Index);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OracleTransaction tran;
            tran = Program.cn.BeginTransaction();
            try
            {
                SetData();
                pro.Id = txtId.Text;
                if (pro.Update(tran))
                {
                    foreach (DataGridViewRow dr in dgvProductUnit.Rows)
                    {
                        if (dr.Cells[2].Value != null)
                        {
                            if (dr.Cells[0].Value != null && dr.Cells[0].Value.ToString() != "")
                            {
                                prounit.Id = dr.Cells[0].Value.ToString();
                                prounit.Productid = dr.Cells[1].Value.ToString();
                                prounit.Unittypeid = dr.Cells[2].Value.ToString();
                                prounit.Cost = dr.Cells[3].Value.ToString();
                                prounit.Price = dr.Cells[4].Value.ToString();
                                bool isChecked = Convert.ToBoolean(dr.Cells[5].Value);
                                if (isChecked)
                                {
                                    prounit.Defaults = "1";
                                }
                                else
                                {
                                    prounit.Defaults = "0";
                                }
                                if (prounit.Update(tran) == false)
                                {
                                    tran.Rollback();
                                    return;
                                }
                            }
                            else
                            {
                                prounit.Productid = txtId.Text;
                                prounit.Unittypeid = dr.Cells[2].Value.ToString();
                                prounit.Cost = dr.Cells[3].Value.ToString();
                                prounit.Price = dr.Cells[4].Value.ToString();
                                bool isChecked = Convert.ToBoolean(dr.Cells[5].Value);
                                if (isChecked)
                                {
                                    prounit.Defaults = "1";
                                }
                                else
                                {
                                    prounit.Defaults = "0";
                                }
                                if (prounit.Insert(tran) == false)
                                {
                                    tran.Rollback();
                                    return;
                                }
                            }
                        }
                    }
                    tran.Commit();
                    LoadRecords();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtProCode.Enabled = true;
            txtBarcode.Enabled = true;
            txtProName.Enabled = true;
            txtProNameKh.Enabled = true;
            cboCategory.Enabled = true;
            cboSupplier.Enabled = true;
            cboStock.Enabled = true;
            txtQtyonhand.Enabled = true;
            txtQtyAlert.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtId.Text = "";
            txtProCode.Text = "";
            txtBarcode.Text = "";
            txtProName.Text = "";
            txtProNameKh.Text = "";
            txtQtyonhand.Text = "0";
            txtQtyAlert.Text = "0";
            picPicture.Image = null;
            dgvProductUnit.Rows.Clear();
            txtProCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pro.Id = txtId.Text;
            pro.Delete();
            LoadRecords();
        }

        private void dgvProductUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProductUnit.CurrentRow == null) return;
            var row = dgvProductUnit.CurrentRow;
            if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void txtFindBy_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = pro.FindProduct(txtFindBy.Text.Trim());

            if (dt != null)
            {
                dgvProduct.DataSource = dt;
            }
        }

        private void cboFindby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFindby.SelectedIndex != -1)
            {
                string selectedBarcode = cboFindby.Text;
                DataTable dt = pro.GetProductByBarcode(selectedBarcode);

                if (dt.Rows.Count > 0)
                {
                    txtProName.Text = dt.Rows[0]["PRODUCTNAME"].ToString();
                    txtProNameKh.Text = dt.Rows[0]["PRODUCTNAMEKH"].ToString();

                    cboCategory.SelectedValue = dt.Rows[0]["CATEGORYID"];
                    cboSupplier.SelectedValue = dt.Rows[0]["SUPPLIERID"];
                }
            }
        }
    }
}
