namespace POS_504.Setup
{
    partial class ProductFrm
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
            this.components = new System.ComponentModel.Container();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtProNameKh = new System.Windows.Forms.TextBox();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtProCode = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQtyAlert = new System.Windows.Forms.TextBox();
            this.txtQtyonhand = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.picPicture = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboFindby = new System.Windows.Forms.ComboBox();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvProductUnit = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unittypeid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaults = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(225, 105);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(250, 43);
            this.txtId.TabIndex = 0;
            // 
            // txtProNameKh
            // 
            this.txtProNameKh.Location = new System.Drawing.Point(225, 350);
            this.txtProNameKh.Multiline = true;
            this.txtProNameKh.Name = "txtProNameKh";
            this.txtProNameKh.Size = new System.Drawing.Size(250, 43);
            this.txtProNameKh.TabIndex = 3;
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(225, 288);
            this.txtProName.Multiline = true;
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(250, 43);
            this.txtProName.TabIndex = 2;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(225, 225);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(250, 43);
            this.txtBarcode.TabIndex = 1;
            // 
            // txtProCode
            // 
            this.txtProCode.Location = new System.Drawing.Point(225, 165);
            this.txtProCode.Multiline = true;
            this.txtProCode.Name = "txtProCode";
            this.txtProCode.Size = new System.Drawing.Size(250, 43);
            this.txtProCode.TabIndex = 0;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(225, 419);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(250, 33);
            this.cboCategory.TabIndex = 4;
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Items.AddRange(new object[] {
            "Cut Stock",
            "Not Cut Stock"});
            this.cboStock.Location = new System.Drawing.Point(225, 537);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(250, 33);
            this.cboStock.TabIndex = 6;
            this.cboStock.Text = "Cut Stock";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(225, 478);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(250, 33);
            this.cboSupplier.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "ProductID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "ProductCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Barcode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Product NameKh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Supplier";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 545);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Stock Type";
            // 
            // txtQtyAlert
            // 
            this.txtQtyAlert.Location = new System.Drawing.Point(225, 659);
            this.txtQtyAlert.Multiline = true;
            this.txtQtyAlert.Name = "txtQtyAlert";
            this.txtQtyAlert.Size = new System.Drawing.Size(250, 43);
            this.txtQtyAlert.TabIndex = 8;
            // 
            // txtQtyonhand
            // 
            this.txtQtyonhand.Location = new System.Drawing.Point(225, 598);
            this.txtQtyonhand.Multiline = true;
            this.txtQtyonhand.Name = "txtQtyonhand";
            this.txtQtyonhand.Size = new System.Drawing.Size(250, 43);
            this.txtQtyonhand.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 662);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Qty Alert";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 601);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "QtyOnHand";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Impact", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(514, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(374, 53);
            this.label11.TabIndex = 46;
            this.label11.Text = "Product Information";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picPicture
            // 
            this.picPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPicture.Location = new System.Drawing.Point(542, 110);
            this.picPicture.Name = "picPicture";
            this.picPicture.Size = new System.Drawing.Size(196, 238);
            this.picPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPicture.TabIndex = 47;
            this.picPicture.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(821, 975);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 51);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(679, 975);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 51);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(536, 975);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(116, 51);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(382, 975);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 51);
            this.btnAdd.TabIndex = 48;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(574, 376);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(116, 51);
            this.btnBrowser.TabIndex = 9;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 42);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cboFindby
            // 
            this.cboFindby.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFindby.FormattingEnabled = true;
            this.cboFindby.Items.AddRange(new object[] {
            "Barcode",
            "ProductName",
            "ProductNameKh"});
            this.cboFindby.Location = new System.Drawing.Point(774, 110);
            this.cboFindby.Name = "cboFindby";
            this.cboFindby.Size = new System.Drawing.Size(250, 39);
            this.cboFindby.TabIndex = 54;
            this.cboFindby.Text = "Barcode";
            this.cboFindby.SelectedIndexChanged += new System.EventHandler(this.cboFindby_SelectedIndexChanged);
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(1047, 110);
            this.txtFindBy.Multiline = true;
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(329, 39);
            this.txtFindBy.TabIndex = 55;
            this.txtFindBy.TextChanged += new System.EventHandler(this.txtFindBy_TextChanged);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(774, 168);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersWidth = 82;
            this.dgvProduct.RowTemplate.Height = 33;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(602, 534);
            this.dgvProduct.TabIndex = 60;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dgvProductUnit
            // 
            this.dgvProductUnit.AllowUserToDeleteRows = false;
            this.dgvProductUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductUnit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.productid,
            this.unittypeid,
            this.cost,
            this.price,
            this.defaults});
            this.dgvProductUnit.Location = new System.Drawing.Point(57, 721);
            this.dgvProductUnit.Name = "dgvProductUnit";
            this.dgvProductUnit.RowHeadersWidth = 82;
            this.dgvProductUnit.RowTemplate.Height = 33;
            this.dgvProductUnit.Size = new System.Drawing.Size(1284, 248);
            this.dgvProductUnit.TabIndex = 61;
            this.dgvProductUnit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductUnit_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 10;
            this.id.Name = "id";
            this.id.Width = 200;
            // 
            // productid
            // 
            this.productid.HeaderText = "ProductID";
            this.productid.MinimumWidth = 10;
            this.productid.Name = "productid";
            this.productid.Width = 200;
            // 
            // unittypeid
            // 
            this.unittypeid.HeaderText = "UnitType";
            this.unittypeid.MinimumWidth = 10;
            this.unittypeid.Name = "unittypeid";
            this.unittypeid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unittypeid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.unittypeid.Width = 200;
            // 
            // cost
            // 
            this.cost.HeaderText = "Cost";
            this.cost.MinimumWidth = 10;
            this.cost.Name = "cost";
            this.cost.Width = 200;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 10;
            this.price.Name = "price";
            this.price.Width = 200;
            // 
            // defaults
            // 
            this.defaults.HeaderText = "Defaults";
            this.defaults.MinimumWidth = 10;
            this.defaults.Name = "defaults";
            this.defaults.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.defaults.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.defaults.Width = 200;
            // 
            // ProductFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1405, 1066);
            this.Controls.Add(this.dgvProductUnit);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.txtFindBy);
            this.Controls.Add(this.cboFindby);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.picPicture);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQtyonhand);
            this.Controls.Add(this.txtQtyAlert);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.txtProCode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtProName);
            this.Controls.Add(this.txtProNameKh);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductFrm";
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtProNameKh;
        private System.Windows.Forms.TextBox txtProName;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtProCode;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQtyAlert;
        private System.Windows.Forms.TextBox txtQtyonhand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picPicture;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.ComboBox cboFindby;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvProductUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewComboBoxColumn unittypeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewCheckBoxColumn defaults;
    }
}