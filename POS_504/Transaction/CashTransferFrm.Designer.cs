namespace POS_504.Setup
{
    partial class CashTransferFrm
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
            this.dgvTransfer = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboPaymentMethodFrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPaymentMethodTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransfer
            // 
            this.dgvTransfer.AllowUserToAddRows = false;
            this.dgvTransfer.AllowUserToDeleteRows = false;
            this.dgvTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfer.Location = new System.Drawing.Point(64, 479);
            this.dgvTransfer.Name = "dgvTransfer";
            this.dgvTransfer.ReadOnly = true;
            this.dgvTransfer.RowHeadersWidth = 82;
            this.dgvTransfer.RowTemplate.Height = 33;
            this.dgvTransfer.Size = new System.Drawing.Size(1075, 423);
            this.dgvTransfer.TabIndex = 9;
            this.dgvTransfer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransfer_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(589, 384);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(139, 63);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(754, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 63);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(419, 384);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(139, 63);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(256, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 63);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboPaymentMethodFrom
            // 
            this.cboPaymentMethodFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethodFrom.FormattingEnabled = true;
            this.cboPaymentMethodFrom.Location = new System.Drawing.Point(66, 299);
            this.cboPaymentMethodFrom.Name = "cboPaymentMethodFrom";
            this.cboPaymentMethodFrom.Size = new System.Drawing.Size(287, 45);
            this.cboPaymentMethodFrom.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 90;
            this.label4.Text = "From Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(832, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 25);
            this.label3.TabIndex = 89;
            this.label3.Text = "Amount to Transfer ($)";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(837, 180);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(302, 47);
            this.txtAmount.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(474, 180);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(286, 44);
            this.dtpDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 88;
            this.label2.Text = "Transfer Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 87;
            this.label1.Text = "Transfer ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(64, 180);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(302, 47);
            this.txtId.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(345, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(415, 53);
            this.label9.TabIndex = 85;
            this.label9.Text = "Internal Cash Transfer";
            // 
            // cboPaymentMethodTo
            // 
            this.cboPaymentMethodTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethodTo.FormattingEnabled = true;
            this.cboPaymentMethodTo.Location = new System.Drawing.Point(473, 299);
            this.cboPaymentMethodTo.Name = "cboPaymentMethodTo";
            this.cboPaymentMethodTo.Size = new System.Drawing.Size(287, 45);
            this.cboPaymentMethodTo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 25);
            this.label5.TabIndex = 93;
            this.label5.Text = "To Account";
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(837, 299);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(302, 45);
            this.cboUser.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 25);
            this.label6.TabIndex = 95;
            this.label6.Text = "User / Cashier";
            // 
            // CashTransferFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 973);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.cboPaymentMethodTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvTransfer);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboPaymentMethodFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CashTransferFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashTransferFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransfer;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboPaymentMethodFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPaymentMethodTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label6;
    }
}