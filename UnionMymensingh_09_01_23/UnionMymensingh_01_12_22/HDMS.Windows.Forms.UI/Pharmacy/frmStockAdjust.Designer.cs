namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmStockAdjust
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
            this.label7 = new System.Windows.Forms.Label();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outlet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoftwareStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhysicalStock = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ctrlManufacturerSearchControl = new HDMS.Windows.Forms.UI.Controls.ManufacturerSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Select Manufacturer";
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Generic,
            this.BrandName,
            this.Stock,
            this.Outlet});
            this.dgProducts.Location = new System.Drawing.Point(42, 123);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(925, 490);
            this.dgProducts.TabIndex = 34;
            this.dgProducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProducts_RowHeaderMouseClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 80;
            // 
            // Generic
            // 
            this.Generic.HeaderText = "LotNo";
            this.Generic.Name = "Generic";
            this.Generic.Width = 120;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 350;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Current Software Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 200;
            // 
            // Outlet
            // 
            this.Outlet.HeaderText = "Outlet";
            this.Outlet.Name = "Outlet";
            this.Outlet.Width = 130;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(39, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 21);
            this.label23.TabIndex = 36;
            this.label23.Text = "Brand Name";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandName.Location = new System.Drawing.Point(142, 88);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(243, 29);
            this.txtBrandName.TabIndex = 35;
            this.txtBrandName.TextChanged += new System.EventHandler(this.txtBrandName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(401, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Software Stock";
            // 
            // txtSoftwareStock
            // 
            this.txtSoftwareStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftwareStock.Location = new System.Drawing.Point(520, 88);
            this.txtSoftwareStock.Name = "txtSoftwareStock";
            this.txtSoftwareStock.Size = new System.Drawing.Size(100, 29);
            this.txtSoftwareStock.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(637, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Physical Stock";
            // 
            // txtPhysicalStock
            // 
            this.txtPhysicalStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysicalStock.Location = new System.Drawing.Point(750, 88);
            this.txtPhysicalStock.Name = "txtPhysicalStock";
            this.txtPhysicalStock.Size = new System.Drawing.Size(100, 29);
            this.txtPhysicalStock.TabIndex = 39;
            this.txtPhysicalStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhysicalStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhysicalStock_KeyPress);
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManufacturer.Location = new System.Drawing.Point(193, 29);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(354, 29);
            this.txtManufacturer.TabIndex = 41;
            this.txtManufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtManufacturer_KeyPress);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(856, 86);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(111, 31);
            this.btnRefreshList.TabIndex = 44;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(673, 29);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(188, 29);
            this.cmbOutlet.TabIndex = 51;
            this.cmbOutlet.SelectedIndexChanged += new System.EventHandler(this.cmbOutlet_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(573, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "Select Outlet";
            // 
            // ctrlManufacturerSearchControl
            // 
            this.ctrlManufacturerSearchControl.Location = new System.Drawing.Point(320, 212);
            this.ctrlManufacturerSearchControl.Name = "ctrlManufacturerSearchControl";
            this.ctrlManufacturerSearchControl.Size = new System.Drawing.Size(754, 650);
            this.ctrlManufacturerSearchControl.TabIndex = 43;
            this.ctrlManufacturerSearchControl.Visible = false;
            // 
            // frmStockAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 643);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlManufacturerSearchControl);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhysicalStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoftwareStock);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.label7);
            this.Name = "frmStockAdjust";
            this.Text = "Stock Adjust";
            this.Load += new System.EventHandler(this.frmStockAdjust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoftwareStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhysicalStock;
        private Controls.ManufacturerSearchControl ctrlManufacturerSearchControl;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generic;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outlet;
    }
}