namespace POS.Forms
{
    partial class PhProductEntryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGeneric = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PkgSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPerBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.btnAddFormation = new System.Windows.Forms.Button();
            this.btnAddGeneric = new System.Windows.Forms.Button();
            this.txtROLIndoor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtROLOutDoor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.cmbPackagingStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtyPerBox = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.PhProductSearchControl();
            this.txtSearchByName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtPerceneDecrease = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brand Name";
            // 
            // txtBName
            // 
            this.txtBName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBName.Location = new System.Drawing.Point(107, 7);
            this.txtBName.Name = "txtBName";
            this.txtBName.Size = new System.Drawing.Size(207, 29);
            this.txtBName.TabIndex = 1;
            this.txtBName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Generic";
            // 
            // cmbGeneric
            // 
            this.cmbGeneric.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneric.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneric.FormattingEnabled = true;
            this.cmbGeneric.Location = new System.Drawing.Point(445, 43);
            this.cmbGeneric.Name = "cmbGeneric";
            this.cmbGeneric.Size = new System.Drawing.Size(302, 29);
            this.cmbGeneric.TabIndex = 6;
            this.cmbGeneric.SelectedIndexChanged += new System.EventHandler(this.cmbGeneric_SelectedIndexChanged);
            this.cmbGeneric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGeneric_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(445, 7);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(302, 29);
            this.cmbGroup.TabIndex = 2;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            this.cmbGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGroup_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Formulation";
            // 
            // cmbFormation
            // 
            this.cmbFormation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(445, 113);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(118, 29);
            this.cmbFormation.TabIndex = 8;
            this.cmbFormation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFormation_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(351, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Manufacturer";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbManufacturer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(445, 78);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(302, 29);
            this.cmbManufacturer.TabIndex = 7;
            this.cmbManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbManufacturer_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Sale Unit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-4, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Purchase Price";
            // 
            // txtPPrice
            // 
            this.txtPPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPrice.Location = new System.Drawing.Point(109, 175);
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.Size = new System.Drawing.Size(118, 29);
            this.txtPPrice.TabIndex = 3;
            this.txtPPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPharchase_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "Sale Price";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePrice.Location = new System.Drawing.Point(107, 114);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(120, 29);
            this.txtSalePrice.TabIndex = 4;
            this.txtSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePrice_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(102, 208);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 44);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "Piece",
            "Box",
            "Cartoon",
            "Pata",
            "Shishi",
            "Bottle",
            "Ltr"});
            this.cmbUnit.Location = new System.Drawing.Point(107, 43);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(141, 29);
            this.cmbUnit.TabIndex = 10;
            this.cmbUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnit_KeyPress);
            // 
            // dgProducts
            // 
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.Group,
            this.Generic,
            this.Manufacturer,
            this.PurchasePrice,
            this.SalePrice,
            this.Unit,
            this.PkgSize,
            this.QtyPerBox,
            this.ROL,
            this.ROLOut});
            this.dgProducts.Location = new System.Drawing.Point(42, 258);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(1110, 323);
            this.dgProducts.TabIndex = 33;
            this.dgProducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProducts_RowHeaderMouseClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 80;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 150;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.Width = 220;
            // 
            // Generic
            // 
            this.Generic.HeaderText = "Generic";
            this.Generic.Name = "Generic";
            this.Generic.Width = 190;
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Width = 150;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.HeaderText = "P.Price";
            this.PurchasePrice.Name = "PurchasePrice";
            this.PurchasePrice.Width = 70;
            // 
            // SalePrice
            // 
            this.SalePrice.HeaderText = "S.Price";
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.Width = 70;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Width = 70;
            // 
            // PkgSize
            // 
            this.PkgSize.HeaderText = "Pkg. Size";
            this.PkgSize.Name = "PkgSize";
            this.PkgSize.Width = 90;
            // 
            // QtyPerBox
            // 
            this.QtyPerBox.HeaderText = "QtyPerBox";
            this.QtyPerBox.Name = "QtyPerBox";
            this.QtyPerBox.Width = 80;
            // 
            // ROL
            // 
            this.ROL.HeaderText = "R.O.L(In)";
            this.ROL.Name = "ROL";
            this.ROL.Width = 80;
            // 
            // ROLOut
            // 
            this.ROLOut.HeaderText = "R.O.L.(Out)";
            this.ROLOut.Name = "ROLOut";
            this.ROLOut.Width = 80;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(238, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 44);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.Location = new System.Drawing.Point(753, 6);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(25, 28);
            this.btnAddGroup.TabIndex = 38;
            this.btnAddGroup.Text = "+";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(8, 217);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 10028;
            // 
            // btnAddManufacturer
            // 
            this.btnAddManufacturer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddManufacturer.Location = new System.Drawing.Point(753, 79);
            this.btnAddManufacturer.Name = "btnAddManufacturer";
            this.btnAddManufacturer.Size = new System.Drawing.Size(25, 28);
            this.btnAddManufacturer.TabIndex = 42;
            this.btnAddManufacturer.Text = "+";
            this.btnAddManufacturer.UseVisualStyleBackColor = true;
            this.btnAddManufacturer.Click += new System.EventHandler(this.btnAddManufacturer_Click);
            // 
            // btnAddFormation
            // 
            this.btnAddFormation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFormation.Location = new System.Drawing.Point(569, 113);
            this.btnAddFormation.Name = "btnAddFormation";
            this.btnAddFormation.Size = new System.Drawing.Size(25, 28);
            this.btnAddFormation.TabIndex = 43;
            this.btnAddFormation.Text = "+";
            this.btnAddFormation.UseVisualStyleBackColor = true;
            this.btnAddFormation.Click += new System.EventHandler(this.btnAddFormation_Click);
            // 
            // btnAddGeneric
            // 
            this.btnAddGeneric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGeneric.Location = new System.Drawing.Point(753, 45);
            this.btnAddGeneric.Name = "btnAddGeneric";
            this.btnAddGeneric.Size = new System.Drawing.Size(25, 28);
            this.btnAddGeneric.TabIndex = 44;
            this.btnAddGeneric.Text = "+";
            this.btnAddGeneric.UseVisualStyleBackColor = true;
            this.btnAddGeneric.Click += new System.EventHandler(this.btnAddGeneric_Click);
            // 
            // txtROLIndoor
            // 
            this.txtROLIndoor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtROLIndoor.Location = new System.Drawing.Point(445, 149);
            this.txtROLIndoor.Name = "txtROLIndoor";
            this.txtROLIndoor.Size = new System.Drawing.Size(118, 29);
            this.txtROLIndoor.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(355, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 21);
            this.label15.TabIndex = 46;
            this.label15.Text = "R.O.L (Indoor)";
            // 
            // txtROLOutDoor
            // 
            this.txtROLOutDoor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtROLOutDoor.Location = new System.Drawing.Point(445, 185);
            this.txtROLOutDoor.Name = "txtROLOutDoor";
            this.txtROLOutDoor.Size = new System.Drawing.Size(120, 29);
            this.txtROLOutDoor.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(345, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 21);
            this.label16.TabIndex = 48;
            this.label16.Text = "R.O.L (Out door)";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(1007, 211);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(145, 29);
            this.btnRefreshList.TabIndex = 49;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // cmbPackagingStyle
            // 
            this.cmbPackagingStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPackagingStyle.FormattingEnabled = true;
            this.cmbPackagingStyle.Items.AddRange(new object[] {
            "Box",
            "Cartoon",
            "Pata",
            "Shishi",
            "Bottle",
            "Ltr"});
            this.cmbPackagingStyle.Location = new System.Drawing.Point(107, 78);
            this.cmbPackagingStyle.Name = "cmbPackagingStyle";
            this.cmbPackagingStyle.Size = new System.Drawing.Size(139, 29);
            this.cmbPackagingStyle.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 51;
            this.label1.Text = "Pkg. Unit";
            // 
            // txtQtyPerBox
            // 
            this.txtQtyPerBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.txtQtyPerBox.ForeColor = System.Drawing.Color.Gray;
            this.txtQtyPerBox.Location = new System.Drawing.Point(252, 78);
            this.txtQtyPerBox.Name = "txtQtyPerBox";
            this.txtQtyPerBox.PlaceHolderText = "Qty per box";
            this.txtQtyPerBox.Size = new System.Drawing.Size(98, 29);
            this.txtQtyPerBox.TabIndex = 52;
            this.txtQtyPerBox.Text = "Qty per box";
            this.txtQtyPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(8, 359);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(955, 575);
            this.ctlProductSearchControl.TabIndex = 30;
            this.ctlProductSearchControl.Visible = false;
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByName.Location = new System.Drawing.Point(621, 214);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PlaceHolderText = "Search by name";
            this.txtSearchByName.Size = new System.Drawing.Size(370, 26);
            this.txtSearchByName.TabIndex = 34;
            this.txtSearchByName.Text = "Search by name";
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // txtPerceneDecrease
            // 
            this.txtPerceneDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerceneDecrease.Location = new System.Drawing.Point(107, 145);
            this.txtPerceneDecrease.Name = "txtPerceneDecrease";
            this.txtPerceneDecrease.Size = new System.Drawing.Size(81, 26);
            this.txtPerceneDecrease.TabIndex = 10027;
            this.txtPerceneDecrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerceneDecrease_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(72, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 10026;
            this.label5.Text = "(%-)";
            // 
            // PhProductEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.txtPerceneDecrease);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.txtQtyPerBox);
            this.Controls.Add(this.cmbPackagingStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.txtROLOutDoor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtROLIndoor);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnAddGeneric);
            this.Controls.Add(this.btnAddFormation);
            this.Controls.Add(this.btnAddManufacturer);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbFormation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbGeneric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBName);
            this.Controls.Add(this.label2);
            this.Name = "PhProductEntryControl";
            this.Size = new System.Drawing.Size(1319, 599);
            this.Load += new System.EventHandler(this.PhProductEntryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGeneric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbUnit;
        private HDMS.Windows.Forms.UI.Controls.PhProductSearchControl ctlProductSearchControl;
        private System.Windows.Forms.DataGridView dgProducts;
        private HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox txtSearchByName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btnAddManufacturer;
        private System.Windows.Forms.Button btnAddFormation;
        private System.Windows.Forms.Button btnAddGeneric;
        private System.Windows.Forms.TextBox txtROLIndoor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtROLOutDoor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.ComboBox cmbPackagingStyle;
        private System.Windows.Forms.Label label1;
        private HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox txtQtyPerBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PkgSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyPerBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLOut;
        private System.Windows.Forms.TextBox txtPerceneDecrease;
        private System.Windows.Forms.Label label5;
    }
}
