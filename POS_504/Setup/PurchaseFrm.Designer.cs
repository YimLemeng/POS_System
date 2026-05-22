namespace POS_504.Setup
{
    partial class PurchaseFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProductId = new System.Windows.Forms.ComboBox();
            this.numericQty = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveTransaction = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPurchasePayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(50, 181);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(260, 38);
            this.txtBillNo.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(440, 181);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(238, 38);
            this.dtpDate.TabIndex = 1;
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(50, 324);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(260, 39);
            this.cboUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "User/Cashier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(434, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Supplier";
            // 
            // cboSupplier
            // 
            this.cboSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(440, 324);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(260, 39);
            this.cboSupplier.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1125, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(404, 53);
            this.label9.TabIndex = 47;
            this.label9.Text = "Purchase Information";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(635, 451);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(227, 38);
            this.txtPrice.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(352, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 31);
            this.label5.TabIndex = 48;
            this.label5.Text = "Qty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 31);
            this.label6.TabIndex = 51;
            this.label6.Text = "Product ID";
            // 
            // cboProductId
            // 
            this.cboProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductId.FormattingEnabled = true;
            this.cboProductId.Location = new System.Drawing.Point(50, 450);
            this.cboProductId.Name = "cboProductId";
            this.cboProductId.Size = new System.Drawing.Size(260, 39);
            this.cboProductId.TabIndex = 4;
            // 
            // numericQty
            // 
            this.numericQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericQty.Location = new System.Drawing.Point(358, 450);
            this.numericQty.Name = "numericQty";
            this.numericQty.Size = new System.Drawing.Size(219, 38);
            this.numericQty.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(638, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 31);
            this.label7.TabIndex = 53;
            this.label7.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(898, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 31);
            this.label8.TabIndex = 55;
            this.label8.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(895, 451);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(227, 38);
            this.txtDiscount.TabIndex = 7;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1157, 529);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 62);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(1157, 614);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(139, 62);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1157, 696);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 62);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1157, 775);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 62);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvPurchaseDetail
            // 
            this.dgvPurchaseDetail.AllowUserToAddRows = false;
            this.dgvPurchaseDetail.AllowUserToDeleteRows = false;
            this.dgvPurchaseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseDetail.Location = new System.Drawing.Point(55, 529);
            this.dgvPurchaseDetail.Name = "dgvPurchaseDetail";
            this.dgvPurchaseDetail.ReadOnly = true;
            this.dgvPurchaseDetail.RowHeadersWidth = 82;
            this.dgvPurchaseDetail.RowTemplate.Height = 33;
            this.dgvPurchaseDetail.Size = new System.Drawing.Size(1066, 540);
            this.dgvPurchaseDetail.TabIndex = 8;
            this.dgvPurchaseDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseDetail_CellClick);
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.AllowUserToAddRows = false;
            this.dgvPurchaseHistory.AllowUserToDeleteRows = false;
            this.dgvPurchaseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(238, 1088);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.ReadOnly = true;
            this.dgvPurchaseHistory.RowHeadersWidth = 82;
            this.dgvPurchaseHistory.RowTemplate.Height = 33;
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(2117, 435);
            this.dgvPurchaseHistory.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteInvoice);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtSubTotal);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSaveTransaction);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtPayAmount);
            this.groupBox1.Controls.Add(this.cboPaymentMethod);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1351, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1273, 439);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment";
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(614, 321);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(195, 79);
            this.btnDeleteInvoice.TabIndex = 4;
            this.btnDeleteInvoice.Text = "Delete";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(751, 208);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(27, 37);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(569, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 29);
            this.label15.TabIndex = 73;
            this.label15.Text = "NEW TOTAL : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(569, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 29);
            this.label13.TabIndex = 70;
            this.label13.Text = "Sub Total : ";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(742, 105);
            this.txtSubTotal.Multiline = true;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(349, 47);
            this.txtSubTotal.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(837, 321);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 79);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.Location = new System.Drawing.Point(331, 321);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(257, 79);
            this.btnSaveTransaction.TabIndex = 3;
            this.btnSaveTransaction.Text = "Save Transaction";
            this.btnSaveTransaction.UseVisualStyleBackColor = true;
            this.btnSaveTransaction.Click += new System.EventHandler(this.btnSaveTransaction_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 29);
            this.label12.TabIndex = 66;
            this.label12.Text = "Pay Amount";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(28, 207);
            this.txtPayAmount.Multiline = true;
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(412, 48);
            this.txtPayAmount.TabIndex = 1;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(28, 107);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(412, 45);
            this.cboPaymentMethod.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 29);
            this.label10.TabIndex = 50;
            this.label10.Text = "Payment Method";
            // 
            // dgvPurchasePayment
            // 
            this.dgvPurchasePayment.AllowUserToAddRows = false;
            this.dgvPurchasePayment.AllowUserToDeleteRows = false;
            this.dgvPurchasePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchasePayment.Location = new System.Drawing.Point(1351, 657);
            this.dgvPurchasePayment.Name = "dgvPurchasePayment";
            this.dgvPurchasePayment.ReadOnly = true;
            this.dgvPurchasePayment.RowHeadersWidth = 82;
            this.dgvPurchasePayment.RowTemplate.Height = 33;
            this.dgvPurchasePayment.Size = new System.Drawing.Size(1273, 412);
            this.dgvPurchasePayment.TabIndex = 63;
            this.dgvPurchasePayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchasePayment_CellClick);
            // 
            // PurchaseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2690, 1598);
            this.Controls.Add(this.dgvPurchasePayment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPurchaseHistory);
            this.Controls.Add(this.dgvPurchaseDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboProductId);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PurchaseFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchasePayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProductId;
        private System.Windows.Forms.NumericUpDown numericQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvPurchaseDetail;
        private System.Windows.Forms.DataGridView dgvPurchaseHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveTransaction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.DataGridView dgvPurchasePayment;
    }
}