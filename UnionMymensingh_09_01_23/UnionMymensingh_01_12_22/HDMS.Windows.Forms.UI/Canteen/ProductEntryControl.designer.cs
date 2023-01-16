namespace POS.Forms
{
    partial class ProductEntryControl
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
            this.txtPName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaleRate = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPName
            // 
            this.txtPName.BackColor = System.Drawing.Color.White;
            this.txtPName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPName.Location = new System.Drawing.Point(142, 69);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(423, 29);
            this.txtPName.TabIndex = 1;
            this.txtPName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPName_KeyPress);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(86, 69);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(49, 20);
            this.lblPatientName.TabIndex = 33;
            this.lblPatientName.Text = "Name";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(65, 174);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(71, 20);
            this.lblRefBy.TabIndex = 30;
            this.lblRefBy.Text = "Cost/Unit";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGroup
            // 
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Items.AddRange(new object[] {
            "Male",
            "Female",
            "None"});
            this.cmbGroup.Location = new System.Drawing.Point(142, 104);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(210, 29);
            this.cmbGroup.TabIndex = 2;
            this.cmbGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGroup_KeyPress);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(86, 104);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(50, 20);
            this.lblGender.TabIndex = 38;
            this.lblGender.Text = "Group";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbUnit
            // 
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "Male",
            "Female",
            "None"});
            this.cmbUnit.Location = new System.Drawing.Point(142, 139);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(112, 29);
            this.cmbUnit.TabIndex = 3;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            this.cmbUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Unit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(143, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 42);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Sale Rate/Unit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaleRate
            // 
            this.txtSaleRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtSaleRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleRate.Location = new System.Drawing.Point(142, 213);
            this.txtSaleRate.Name = "txtSaleRate";
            this.txtSaleRate.Size = new System.Drawing.Size(151, 29);
            this.txtSaleRate.TabIndex = 47;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(142, 174);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(151, 29);
            this.txtCost.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Item Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtItemCode.Location = new System.Drawing.Point(142, 34);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(134, 29);
            this.txtItemCode.TabIndex = 0;
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPId_KeyPress);
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.PurchasePrice,
            this.SalePrice,
            this.Unit,
            this.Group});
            this.dgProducts.Location = new System.Drawing.Point(36, 319);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(1277, 323);
            this.dgProducts.TabIndex = 50;
            this.dgProducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProducts_RowHeaderMouseClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Product Code";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 150;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Product Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 380;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.HeaderText = "P.Price";
            this.PurchasePrice.Name = "PurchasePrice";
            this.PurchasePrice.Width = 80;
            // 
            // SalePrice
            // 
            this.SalePrice.HeaderText = "S.Price";
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.Width = 80;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // Group
            // 
            this.Group.HeaderText = "Group Name";
            this.Group.Name = "Group";
            this.Group.Width = 180;
            // 
            // ctlProductSearch
            // 
           
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(303, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 42);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProductEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtSaleRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtItemCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblRefBy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductEntryControl";
            this.Size = new System.Drawing.Size(1468, 706);
            this.Load += new System.EventHandler(this.ProductEntryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaleRate;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.Button btnCancel;
    }
}
