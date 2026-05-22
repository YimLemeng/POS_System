using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using POS_504.Class;

namespace POS_504.Setup
{
    public partial class PurchaseFrm : Form
    {
        PurchaseCls purchaseInfo = new PurchaseCls();
        PurchaseDetailCls purchaseDetail = new PurchaseDetailCls();
        PurchasePaymentCls purchasePayment = new PurchasePaymentCls();
        SupplierCls supplierInfo = new SupplierCls();
        UserCls userInfo = new UserCls();
        ProductCls productInfo = new ProductCls();
        private int selectedRowIndex = -1;
        public PurchaseFrm()
        {
            InitializeComponent();
            LoadPurchaseHistory();
            BindPaymentMethodComboBox();
            LoadRecord();
            LoadDropdowns();
            LoadPurchasePayment(purchasePayment.Id);
            txtPayAmount.ReadOnly = true;
            txtSubTotal.ReadOnly = true;
        }
        private void LoadPurchaseHistory()
        {
            try
            {
                DataSet ds = purchaseInfo.SelectRecord();
                if (ds != null)
                {
                    dgvPurchaseHistory.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load History: " + ex.Message);
            }
        }
        private void CalculateTotals()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvPurchaseDetail.Rows)
            {
                if (row.IsNewRow) continue;
                decimal.TryParse(row.Cells["LineTotal"].Value?.ToString(), out decimal lineTotal);
                subTotal += lineTotal;
            }

            txtSubTotal.Text = subTotal.ToString("N2");
            decimal.TryParse(txtDiscount.Text, out decimal mainDiscount);
            decimal newTotal = subTotal - mainDiscount;
            lblTotal.Text = newTotal.ToString("N2");
            txtPayAmount.Text = newTotal.ToString("N2"); 
        }
        private void LoadRecord()
        {
            txtBillNo.Enabled = false;
            dtpDate.Enabled = false;
            cboUser.Enabled = false;
            cboSupplier.Enabled = false;
            cboProductId.Enabled = false;
            numericQty.Enabled = false;
            txtPrice.Enabled = false;
            txtDiscount.Text = "0";
            txtDiscount.Enabled = false;
            cboSupplier.Enabled = false;
            txtPayAmount.Enabled = false;
            cboPaymentMethod.Enabled = false;

            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveTransaction.Enabled = false;
        }
        private void PrepareNewPurchase()
        {
            ClearProductInputs();
            dgvPurchaseDetail.Rows.Clear();
            dgvPurchaseDetail.Columns.Clear();
            dgvPurchaseDetail.Columns.Add("ProductId", "Product ID");
            dgvPurchaseDetail.Columns.Add("Qty", "Quantity");
            dgvPurchaseDetail.Columns.Add("Cost", "Cost");
            dgvPurchaseDetail.Columns.Add("Price", "Price");
            dgvPurchaseDetail.Columns.Add("Discount", "Discount");
            dgvPurchaseDetail.Columns.Add("LineTotal", "Total");
            dgvPurchaseDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
            txtPayAmount.Text = "0.00";
        }
        private void ClearProductInputs()
        {
            cboProductId.SelectedIndex = -1;
            numericQty.Value = 0;
            txtPrice.Text = "0";
            txtDiscount.Text = "0";
        }
        private void LoadDropdowns()
        {
            try
            {
                DataSet dsUser = userInfo.SelectRecord();
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    cboUser.DataSource = dsUser.Tables[0];
                    cboUser.DisplayMember = "USERNAME";
                    cboUser.ValueMember = "ID";
                    cboUser.SelectedIndex = -1;
                }

                DataSet dsSupplier = supplierInfo.SelectRecord();
                if (dsSupplier != null && dsSupplier.Tables.Count > 0)
                {
                    cboSupplier.DataSource = dsSupplier.Tables[0];
                    cboSupplier.DisplayMember = "SUPPLIERNAME";
                    cboSupplier.ValueMember = "ID";
                    cboSupplier.SelectedIndex = -1;
                }
                DataSet dsProduct = productInfo.SelectRecord();
                if (dsProduct != null && dsProduct.Tables.Count > 0)
                {
                    cboProductId.DataSource = dsProduct.Tables[0];
                    cboProductId.DisplayMember = "PRODUCTNAME";
                    cboProductId.ValueMember = "ID";
                    cboProductId.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindPaymentMethodComboBox()
        {
            try
            {
                PaymentMethodCls pm = new PaymentMethodCls();
                DataSet ds = pm.SelectRecord();
                if (ds != null && ds.Tables.Count > 0)
                {
                    cboPaymentMethod.DataSource = ds.Tables[0];
                    cboPaymentMethod.DisplayMember = "METHODNAME";
                    cboPaymentMethod.ValueMember = "ID";
                    cboPaymentMethod.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Binding Payment Method: " + ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PrepareNewPurchase();
            txtBillNo.Enabled = true;
            dtpDate.Enabled = true;
            cboUser.Enabled = true;
            cboSupplier.Enabled = true;
            cboProductId.Enabled = true;
            numericQty.Enabled = true;
            txtPrice.Enabled = true;
            txtDiscount.Text = "0";
            txtDiscount.Enabled = true;
            cboSupplier.Enabled = true;
            txtPayAmount.Enabled = true;
            cboPaymentMethod.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveTransaction.Enabled = true;
            dtpDate.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboProductId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Product first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = cboProductId.SelectedValue.ToString();
            decimal qty = numericQty.Value;
            decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
            decimal discount = 0;
            decimal cost = price;
            decimal lineTotal = (qty * price) - discount;
            dgvPurchaseDetail.Rows.Add(productId, qty, cost, price, discount, lineTotal);
            ClearProductInputs();
            CalculateTotals();
            cboProductId.Focus();
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if(dgvPurchaseDetail.Rows.Count == 0 || (dgvPurchaseDetail.Rows.Count == 1 && dgvPurchaseDetail.Rows[0].IsNewRow))
            {
                MessageBox.Show("Please Insert Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBillNo.Text))
            {
                MessageBox.Show("Please Insert (Bill No)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBillNo.Focus();
                return;
            }
            if (cboSupplier.SelectedIndex == -1 || cboUser.SelectedIndex == -1 || cboPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete Supplier, User and Payment Method!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
            OracleTransaction tran = Program.cn.BeginTransaction();

            try
            {
                purchaseInfo.Billno = txtBillNo.Text;
                purchaseInfo.Date = dtpDate.Value.ToString("yyyy-MM-dd");
                purchaseInfo.Supplierid = cboSupplier.SelectedValue.ToString();
                purchaseInfo.Userid = cboUser.SelectedValue.ToString();
                purchaseInfo.Totalamount = lblTotal.Text.Trim();
                purchaseInfo.Discount = string.IsNullOrWhiteSpace(txtDiscount.Text) ? "0" : txtDiscount.Text.Trim();

                if (!purchaseInfo.Insert(tran))
                {
                    tran.Rollback();
                    return;
                }

                string currentPurchaseId = purchaseInfo.Id;
                foreach (DataGridViewRow row in dgvPurchaseDetail.Rows)
                {
                    if (row.IsNewRow) continue;
                    purchaseDetail.Purchaseid = currentPurchaseId;
                    purchaseDetail.Productid = row.Cells["ProductId"].Value?.ToString() ?? row.Cells["Product ID"].Value.ToString();
                    purchaseDetail.Qty = row.Cells["Qty"].Value?.ToString() ?? row.Cells["Quantity"].Value.ToString();
                    purchaseDetail.Cost = row.Cells["Cost"].Value.ToString();
                    purchaseDetail.Discounts = row.Cells["Discount"].Value?.ToString() ?? "0";

                    if (!purchaseDetail.Insert(tran))
                    {
                        tran.Rollback();
                        return;
                    }
                }
                purchasePayment.Purchaseid = currentPurchaseId;
                purchasePayment.Paymentdate = dtpDate.Value.ToString("yyyy-MM-dd");
                purchasePayment.Paymentmethodid = cboPaymentMethod.SelectedValue.ToString();
                purchasePayment.Payamount = txtPayAmount.Text.Trim();

                if (!purchasePayment.Insert(tran))
                {
                    tran.Rollback();
                    return;
                }

                tran.Commit();
                MessageBox.Show("Save Transaction Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrepareNewPurchase();
                LoadPurchaseHistory();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPurchaseDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            if (e.RowIndex >= 0 && !dgvPurchaseDetail.Rows[e.RowIndex].IsNewRow)
            {
                selectedRowIndex = e.RowIndex; 
                DataGridViewRow row = dgvPurchaseDetail.Rows[selectedRowIndex];
                cboProductId.SelectedValue = row.Cells["ProductId"].Value;
                numericQty.Value = Convert.ToDecimal(row.Cells["Qty"].Value);
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Please select Product in table for update!");
                return;
            }

            DataGridViewRow row = dgvPurchaseDetail.Rows[selectedRowIndex];
            decimal qty = numericQty.Value;
            decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
            decimal discount = 0;
            decimal lineTotal = (qty * price) - discount;
            row.Cells["ProductId"].Value = cboProductId.SelectedValue;
            row.Cells["Qty"].Value = qty;
            row.Cells["Cost"].Value = price;
            row.Cells["Price"].Value = price;
            row.Cells["LineTotal"].Value = lineTotal;
            selectedRowIndex = -1; 
            ClearProductInputs();
            CalculateTotals();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Please select Product in table for delete!");
                return;
            }

            DialogResult r = MessageBox.Show("Do you want to delete this product", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                dgvPurchaseDetail.Rows.RemoveAt(selectedRowIndex);
                selectedRowIndex = -1;
                ClearProductInputs();
                CalculateTotals();
            }
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(purchaseInfo.Id))
            {
                MessageBox.Show("Please choose Invoice below Table!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Do you want delete this Invoice?", "Delete Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (Program.cn.State != ConnectionState.Open) Program.cn.Open();
                OracleTransaction tran = Program.cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd1 = new OracleCommand("DELETE FROM PURCHASEPAYMENT_V WHERE PURCHASEID = :pid", Program.cn))
                    {
                        cmd1.Parameters.Add("pid", OracleDbType.Varchar2).Value = purchaseInfo.Id;
                        cmd1.Transaction = tran;
                        cmd1.ExecuteNonQuery();
                    }

                    using (OracleCommand cmd2 = new OracleCommand("DELETE FROM PURCHASEDETAIL_TBL WHERE PURCHASEID = :pid", Program.cn))
                    {
                        cmd2.Parameters.Add("pid", OracleDbType.Varchar2).Value = purchaseInfo.Id;
                        cmd2.Transaction = tran;
                        cmd2.ExecuteNonQuery();
                    }
                    using (OracleCommand cmd3 = new OracleCommand("DELETE FROM PURCHASE_TBL WHERE ID = :id", Program.cn))
                    {
                        cmd3.Parameters.Add("id", OracleDbType.Varchar2).Value = purchaseInfo.Id;
                        cmd3.Transaction = tran;
                        cmd3.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Delete Invoice Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PrepareNewPurchase();
                    LoadPurchaseHistory();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void LoadPurchasePayment(string purchaseId)
        {
            try
            {
                purchasePayment.Purchaseid = purchaseId;
                DataSet ds = purchasePayment.SelectRecord();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvPurchasePayment.DataSource = ds.Tables[0];
                    dgvPurchasePayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    dgvPurchasePayment.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvPurchasePayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvPurchasePayment.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvPurchasePayment.Rows[e.RowIndex];
                purchasePayment.Id = row.Cells["ID"].Value.ToString();
                purchasePayment.Paymentdate = row.Cells["PAYMENTDATE"].Value.ToString();
                purchasePayment.Paymentmethodid = row.Cells["PAYMENTMETHODID"].Value.ToString();
                purchasePayment.Payamount = row.Cells["PAYAMOUNT"].Value.ToString();
            }
        }
    }
}
