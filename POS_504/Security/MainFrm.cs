using POS_504.Class;
using POS_504.Report;
using POS_504.Setup;
using POS_504.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_504.Security
{
    public partial class MainFrm : Form
    {
        public MainFrm(string username)
        {
            InitializeComponent();
            UITheme.ApplyModernTheme(this);
            UITheme.SetMdiBackground(this, UITheme.SlateHeader);
            toolUser.Text = username;
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginFrm lg = new LoginFrm();
            lg.Show();
            this.Hide();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryFrm cat = new CategoryFrm();
            cat.MdiParent = this;
            cat.Show(); 
        }

        private void unitTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitFrm un = new UnitFrm();
            un.MdiParent = this;
            un.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierFrm supp = new SupplierFrm();
            supp.MdiParent = this;
            supp.Show();
        }

        private void tsbCustomer_Click(object sender, EventArgs e)
        {
            CustomerFrm customer = new CustomerFrm();
            customer.MdiParent = this;
            customer.Show();
        }

        private void tsbProduct_Click(object sender, EventArgs e)
        {
            ProductFrm product = new ProductFrm();
            product.MdiParent = this;
            product.Show();
        }

        private void tsbCategory_Click(object sender, EventArgs e)
        {
            CategoryFrm cat = new CategoryFrm();
            cat.MdiParent = this;
            cat.Show();
        }

        private void tsbUnit_Click(object sender, EventArgs e)
        {
            UnitFrm un = new UnitFrm();
            un.MdiParent = this;
            un.Show();
        }

        private void tsbSupplier_Click(object sender, EventArgs e)
        {
            SupplierFrm supp = new SupplierFrm();
            supp.MdiParent = this;
            supp.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductFrm pro = new ProductFrm();
            pro.MdiParent = this;
            pro.Show();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductListRpt product = new ProductListRpt();
            product.MdiParent = this;
            product.WindowState = FormWindowState.Maximized;
            product.Show();
        }

        private void tsbSale_Click(object sender, EventArgs e)
        {
            SaleFrm sale = new SaleFrm();
            sale.MdiParent = this;
            //sale.WindowState = FormWindowState.Maximized;
            sale.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleFrm sale = new SaleFrm();
            sale.MdiParent = this;
            sale.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffFrm staff = new StaffFrm();
            staff.MdiParent = this;
            staff.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserFrm user = new UserFrm();
            user.MdiParent = this;
            user.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseFrm ps = new PurchaseFrm();
            ps.MdiParent = this;
            ps.Show();
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseFrm expense = new ExpenseFrm();
            expense.MdiParent = this;
            expense.Show();
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseTypeFrm expenseType = new ExpenseTypeFrm();
            expenseType.MdiParent = this;
            expenseType.Show();
        }

        private void incomeTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncomeFrm income = new IncomeFrm();
            income.MdiParent = this;
            income.Show();
        }

        private void incomeTypeSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncomeTypeFrm incomeType = new IncomeTypeFrm();
            incomeType.MdiParent = this;
            incomeType.Show();
        }

        private void cashTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashTransferFrm cashTransfer = new CashTransferFrm();
            cashTransfer.MdiParent = this;
            cashTransfer.Show();
        }

        private void beginingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginingBalanceFrm beginingBalance = new BeginingBalanceFrm();
            beginingBalance.MdiParent = this;
            beginingBalance.Show();
        }

        private void moreCapitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoreCapitalFrm capital = new MoreCapitalFrm();
            capital.MdiParent = this;
            capital.Show();
        }

        private void ownerDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OwnerDrawingFrm ownerDrawing = new OwnerDrawingFrm();
            ownerDrawing.MdiParent = this;
            ownerDrawing.Show();
        }

        private void accountAdjustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountAdjustFrm accountAdjust = new AccountAdjustFrm();
            accountAdjust.MdiParent = this;
            accountAdjust.Show();
        }
    }
}
