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
using static System.Windows.Forms.AxHost;

namespace POS_504.Setup
{
    public partial class SaleFrm : Form
    {
        SaleCls saleInfo = new SaleCls();
        SaleDetailCls saledetailInfo = new SaleDetailCls();
        PaymentMethodCls paymentInfo = new PaymentMethodCls();
        SalePaymentCls paymentdetailInfo = new SalePaymentCls();
        public SaleFrm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadDropdowns();
            PrepareNewSale();
            LoadTransactionHistory();
            LoadRecord();
            LoadSalePayment();
            txtInvoiceID.ReadOnly = true;
            txtPayAmount.ReadOnly = true;
            txtSubTotal.ReadOnly = true;
        }
        private void SetupDataGridView()
        {
            dgvSaleDetail.ColumnCount = 6;
            dgvSaleDetail.Columns[0].Name = "ProductId";
            dgvSaleDetail.Columns[1].Name = "Qty";
            dgvSaleDetail.Columns[2].Name = "Cost";
            dgvSaleDetail.Columns[3].Name = "Price";
            dgvSaleDetail.Columns[4].Name = "Discount";
            dgvSaleDetail.Columns[5].Name = "LineTotal";
            dgvSaleDetail.AllowUserToAddRows = false;
        }

        private void LoadDropdowns()
        {
            try
            {
                DataSet dsCustomer = saleInfo.SelectCustomer();
                if (dsCustomer != null && dsCustomer.Tables.Count > 0)
                {
                    cboCustomer.DataSource = dsCustomer.Tables[0];
                    cboCustomer.DisplayMember = "CUSTOMERNAME";
                    cboCustomer.ValueMember = "ID";
                    cboCustomer.SelectedIndex = -1;
                }

                DataSet dsPayment = paymentInfo.SelectRecord();
                if (dsPayment != null && dsPayment.Tables.Count > 0)
                {
                    cboPaymentMethod.DataSource = dsPayment.Tables[0];
                    cboPaymentMethod.DisplayMember = "METHODNAME";
                    cboPaymentMethod.ValueMember = "ID";
                    cboPaymentMethod.SelectedIndex = -1;
                }
                DataSet dsProduct = saleInfo.SelectProduct();
                if (dsProduct != null && dsProduct.Tables.Count > 0)
                {
                    cboProductId.DataSource = dsProduct.Tables[0];
                    cboProductId.DisplayMember = "PRODUCTNAME";
                    cboProductId.ValueMember = "ID";
                    cboProductId.SelectedIndex = -1;
                }

                DataSet dsUser = saleInfo.SelectUser();
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    cboUser.DataSource = dsUser.Tables[0];
                    cboUser.DisplayMember = "USERNAME";
                    cboUser.ValueMember = "ID";
                    cboUser.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PrepareNewSale()
        {
            cboProductId.SelectedIndex = -1;
            numericQty.Value = 0;
            txtPrice.Text = "0";
            txtDiscount.Text = "";
            txtPayAmount.Text = "";

            dgvSaleDetail.Rows.Clear();
            CalculateTotals();
            dtpInvoiceDate.Value = DateTime.Now;
            txtInvoiceID.Text = saleInfo.GetNextInvoiceNo().ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboProductId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string productId = cboProductId.SelectedValue.ToString();
            decimal qty = numericQty.Value;
            decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
            decimal discount = decimal.TryParse(txtDiscount.Text, out decimal d) ? d : 0;
            decimal cost = price * 0.7m;
            decimal lineTotal = (qty * price) - discount;
            dgvSaleDetail.Rows.Add(productId, qty, cost, price, discount, lineTotal);
            cboProductId.SelectedIndex = -1;
            numericQty.Value = 1;
            txtPrice.Text = "";
            txtDiscount.Text = "";
            cboProductId.Focus();
            CalculateTotals();
        }
        private void CalculateTotals()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvSaleDetail.Rows)
            {
                if (row.Cells["LineTotal"].Value != null && !row.IsNewRow)
                {
                    subTotal += Convert.ToDecimal(row.Cells["LineTotal"].Value);
                }
            }
            decimal globalDiscount = decimal.TryParse(txtDiscount.Text, out decimal gd) ? gd : 0;
            decimal netTotal = subTotal - globalDiscount;
            txtSubTotal.Text = subTotal.ToString("0.00");
            lblTotal.Text = netTotal.ToString("0.00");
            txtPayAmount.Text = netTotal.ToString("0.00");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            txtDiscount.Text = lblTotal.Text;
            CalculateTotals();
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            if (dgvSaleDetail.Rows.Count == 0)
            {
                MessageBox.Show("Cannot save an empty sale.");
                return;
            }

            if (Program.cn.State != ConnectionState.Open)
                Program.cn.Open();

            using (OracleTransaction tran = Program.cn.BeginTransaction())
            {
                try
                {
                    saleInfo.Invoiceno = txtInvoiceID.Text;
                    saleInfo.Date = dtpInvoiceDate.Value.ToString("yyyy-MM-dd");
                    saleInfo.Customerid = cboCustomer.SelectedValue?.ToString() ?? "1";
                    saleInfo.Userid = cboUser.SelectedValue.ToString();
                    saleInfo.Totalamount = lblTotal.Text;
                    saleInfo.Discount = string.IsNullOrWhiteSpace(txtDiscount.Text) ? "0" : txtDiscount.Text;
                    saleInfo.Active = "1";

                    if (!saleInfo.Insert(tran))
                    {
                        tran.Rollback();
                        return;
                    }
                    OracleCommand cmdGetId = new OracleCommand("SELECT MAX(id) FROM Sale_tbl", Program.cn);
                    cmdGetId.Transaction = tran;
                    string newSaleId = cmdGetId.ExecuteScalar().ToString();

                    foreach (DataGridViewRow row in dgvSaleDetail.Rows)
                    {
                        SaleDetailCls detail = new SaleDetailCls();
                        detail.Saleid = newSaleId;
                        detail.Productid = row.Cells["ProductId"].Value.ToString();
                        detail.Qty = row.Cells["Qty"].Value.ToString();
                        detail.Cost = row.Cells["Cost"].Value.ToString();
                        detail.Price = row.Cells["Price"].Value.ToString();
                        detail.Discounts = row.Cells["Discount"].Value.ToString();

                        if (!detail.Insert(tran))
                        {
                            tran.Rollback();
                            return;
                        }
                    }
                    SalePaymentCls payment = new SalePaymentCls();
                    payment.Saleid = newSaleId;
                    payment.Paymentdate = dtpInvoiceDate.Value.ToString("yyyy-MM-dd");
                    payment.Paymentmethodid = cboPaymentMethod.SelectedValue?.ToString() ?? "1";
                    payment.Payamount = txtPayAmount.Text;

                    if (!payment.Insert(tran))
                    {
                        tran.Rollback();
                        return;
                    }
                    tran.Commit();
                    MessageBox.Show("Transaction Completed Successfully!");
                    PrepareNewSale();
                    LoadTransactionHistory();
                    LoadSalePayment();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PrepareNewSale();
            dtpInvoiceDate.Enabled = true;
            cboUser.Enabled = true;
            cboCustomer.Enabled = true;
            cboProductId.Enabled = true;
            cboPaymentMethod.Enabled = true;
            numericQty.Enabled = true;
            txtDiscount.Enabled = true;
            txtPrice.Enabled = true;
            txtPayAmount.Enabled = true;
            btnInsert.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSaveTransaction.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadRecord()
        {
            dtpInvoiceDate.Enabled = false;
            cboUser.Enabled = false;
            cboCustomer.Enabled = false;
            cboProductId.Enabled = false;
            cboPaymentMethod.Enabled = false;
            numericQty.Enabled = false;
            txtDiscount.Enabled = false;
            txtPrice.Enabled = false;
            txtPayAmount.Enabled = false;

            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveTransaction.Enabled = false;
        }
        private void LoadTransactionHistory()
        {
            try
            {
                DataSet ds = saledetailInfo.SelectRecord();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvTransaction.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        int selectedRowIndex = -1;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                decimal qty = numericQty.Value;
                decimal price = Convert.ToDecimal(txtPrice.Text);
                decimal lineTotal = qty * price;

                DataGridViewRow row = dgvSaleDetail.Rows[selectedRowIndex];
                row.Cells["ProductId"].Value = cboProductId.Text;
                row.Cells["Qty"].Value = qty;
                row.Cells["Price"].Value = price;
                row.Cells["LineTotal"].Value = lineTotal;

                selectedRowIndex = -1;
                cboProductId.SelectedIndex = -1;
                numericQty.Value = 1;
                txtPrice.Clear();
                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select Data!");
            }
        }

        private void dgvSaleDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dgvSaleDetail.Rows[selectedRowIndex];
                cboProductId.Text = row.Cells["ProductId"].Value.ToString();
                numericQty.Value = Convert.ToDecimal(row.Cells["Qty"].Value);
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSaleDetail.CurrentRow != null && !dgvSaleDetail.CurrentRow.IsNewRow)
            {
                dgvSaleDetail.Rows.Remove(dgvSaleDetail.CurrentRow);
                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select to delete");
            }
        }
        private void LoadSalePayment()
        {
            try
            {
                DataSet ds = paymentdetailInfo.SelectRecord();
                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvSalePayment.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvSalePayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalePayment.Rows[e.RowIndex];
                txtPayAmount.Text = row.Cells["PAYAMOUNT"].Value.ToString();
                cboPaymentMethod.Text = row.Cells["METHODNAME"].Value.ToString();
                dtpInvoiceDate.Value = Convert.ToDateTime(row.Cells["PAYMENTDATE"].Value);
            }
        }
    }
}
