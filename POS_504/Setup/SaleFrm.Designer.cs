namespace POS_504.Setup
{
    partial class SaleFrm
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
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.dgvSaleDetail = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.cboProductId = new System.Windows.Forms.ComboBox();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.dgvSalePayment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(33, 174);
            this.txtInvoiceID.Multiline = true;
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(302, 47);
            this.txtInvoiceID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Invoce No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "User / Cashier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1090, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(314, 53);
            this.label9.TabIndex = 46;
            this.label9.Text = "Sale Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 48;
            this.label4.Text = "Customer";
            // 
            // cboCustomer
            // 
            this.cboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(33, 283);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(994, 45);
            this.cboCustomer.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(609, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 55;
            this.label5.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(614, 388);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(172, 44);
            this.txtPrice.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 25);
            this.label6.TabIndex = 53;
            this.label6.Text = "Qty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 51;
            this.label7.Text = "Product ID";
            // 
            // numericQty
            // 
            this.numericQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericQty.Location = new System.Drawing.Point(311, 388);
            this.numericQty.Name = "numericQty";
            this.numericQty.Size = new System.Drawing.Size(258, 44);
            this.numericQty.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1099, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 63);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(1294, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 439);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(866, 201);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(27, 37);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(684, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 29);
            this.label15.TabIndex = 73;
            this.label15.Text = "NEW TOTAL : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(684, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 29);
            this.label13.TabIndex = 70;
            this.label13.Text = "Sub Total : ";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(857, 105);
            this.txtSubTotal.Multiline = true;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(302, 47);
            this.txtSubTotal.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(334, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 79);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.Location = new System.Drawing.Point(28, 326);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(257, 79);
            this.btnSaveTransaction.TabIndex = 4;
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
            this.txtPayAmount.Size = new System.Drawing.Size(473, 48);
            this.txtPayAmount.TabIndex = 1;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(28, 107);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(473, 45);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(829, 344);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 25);
            this.label14.TabIndex = 72;
            this.label14.Text = "Discount ";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(834, 385);
            this.txtDiscount.Multiline = true;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(193, 47);
            this.txtDiscount.TabIndex = 6;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(377, 177);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(286, 44);
            this.dtpInvoiceDate.TabIndex = 0;
            // 
            // dgvSaleDetail
            // 
            this.dgvSaleDetail.AllowUserToAddRows = false;
            this.dgvSaleDetail.AllowUserToDeleteRows = false;
            this.dgvSaleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleDetail.Location = new System.Drawing.Point(33, 483);
            this.dgvSaleDetail.Name = "dgvSaleDetail";
            this.dgvSaleDetail.ReadOnly = true;
            this.dgvSaleDetail.RowHeadersWidth = 82;
            this.dgvSaleDetail.RowTemplate.Height = 33;
            this.dgvSaleDetail.Size = new System.Drawing.Size(1215, 601);
            this.dgvSaleDetail.TabIndex = 11;
            this.dgvSaleDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleDetail_CellClick);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(1099, 208);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(139, 63);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cboProductId
            // 
            this.cboProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductId.FormattingEnabled = true;
            this.cboProductId.Location = new System.Drawing.Point(33, 390);
            this.cboProductId.Name = "cboProductId";
            this.cboProductId.Size = new System.Drawing.Size(244, 45);
            this.cboProductId.TabIndex = 3;
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.AllowUserToDeleteRows = false;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.Location = new System.Drawing.Point(292, 1122);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.ReadOnly = true;
            this.dgvTransaction.RowHeadersWidth = 82;
            this.dgvTransaction.RowTemplate.Height = 33;
            this.dgvTransaction.Size = new System.Drawing.Size(1955, 476);
            this.dgvTransaction.TabIndex = 12;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1099, 369);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 63);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1099, 290);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 63);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(719, 179);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(287, 45);
            this.cboUser.TabIndex = 73;
            // 
            // dgvSalePayment
            // 
            this.dgvSalePayment.AllowUserToAddRows = false;
            this.dgvSalePayment.AllowUserToDeleteRows = false;
            this.dgvSalePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalePayment.Location = new System.Drawing.Point(1314, 615);
            this.dgvSalePayment.Name = "dgvSalePayment";
            this.dgvSalePayment.ReadOnly = true;
            this.dgvSalePayment.RowHeadersWidth = 82;
            this.dgvSalePayment.RowTemplate.Height = 33;
            this.dgvSalePayment.Size = new System.Drawing.Size(1198, 468);
            this.dgvSalePayment.TabIndex = 74;
            this.dgvSalePayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalePayment_CellClick);
            // 
            // SaleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2582, 1644);
            this.Controls.Add(this.dgvSalePayment);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvTransaction);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cboProductId);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgvSaleDetail);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numericQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvoiceID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalePayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.DataGridView dgvSaleDetail;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveTransaction;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboProductId;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.DataGridView dgvSalePayment;
    }
}