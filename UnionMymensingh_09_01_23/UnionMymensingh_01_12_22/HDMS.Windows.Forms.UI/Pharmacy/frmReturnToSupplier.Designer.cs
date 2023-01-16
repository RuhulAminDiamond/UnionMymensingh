using HDMS.Model.Pharmacy.ViewModels;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmReturnToSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnToSupplier));
            this.btnReturnNow = new System.Windows.Forms.Button();
            this.txtOrderTo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDrescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReturnTime = new System.Windows.Forms.TextBox();
            this.dtpReturn = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.PhProductSaleSearchControl();
            this.ctrlManufacturerSearchControl = new HDMS.Windows.Forms.UI.Controls.ManufacturerSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnNow
            // 
            this.btnReturnNow.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnNow.Location = new System.Drawing.Point(169, 552);
            this.btnReturnNow.Name = "btnReturnNow";
            this.btnReturnNow.Size = new System.Drawing.Size(144, 39);
            this.btnReturnNow.TabIndex = 0;
            this.btnReturnNow.Text = "Return ";
            this.btnReturnNow.UseVisualStyleBackColor = true;
            this.btnReturnNow.Click += new System.EventHandler(this.btnReturnNow_Click);
            // 
            // txtOrderTo
            // 
            this.txtOrderTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderTo.Location = new System.Drawing.Point(171, 12);
            this.txtOrderTo.Name = "txtOrderTo";
            this.txtOrderTo.Size = new System.Drawing.Size(301, 29);
            this.txtOrderTo.TabIndex = 38;
            this.txtOrderTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderTo_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(52, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 21);
            this.label11.TabIndex = 39;
            this.label11.Text = "Select Supplier";
            // 
            // txtDrescription
            // 
            this.txtDrescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrescription.Location = new System.Drawing.Point(376, 87);
            this.txtDrescription.Name = "txtDrescription";
            this.txtDrescription.Size = new System.Drawing.Size(422, 29);
            this.txtDrescription.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(372, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 21);
            this.label5.TabIndex = 44;
            this.label5.Text = "Item Description";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(947, 87);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 29);
            this.txtQuantity.TabIndex = 47;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(171, 87);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(188, 29);
            this.txtProductCode.TabIndex = 41;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(820, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 45;
            this.label6.Text = "Unit Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(176, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 42;
            this.label4.Text = "Product Code";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(817, 87);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(80, 29);
            this.txtUnitPrice.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(957, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 21);
            this.label7.TabIndex = 48;
            this.label7.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(686, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Return date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReturnTime
            // 
            this.txtReturnTime.Enabled = false;
            this.txtReturnTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReturnTime.Location = new System.Drawing.Point(903, 12);
            this.txtReturnTime.Name = "txtReturnTime";
            this.txtReturnTime.Size = new System.Drawing.Size(124, 29);
            this.txtReturnTime.TabIndex = 81;
            this.txtReturnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpReturn
            // 
            this.dtpReturn.CustomFormat = "dd-MM-yyyy";
            this.dtpReturn.Enabled = false;
            this.dtpReturn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturn.Location = new System.Drawing.Point(778, 12);
            this.dtpReturn.Name = "dtpReturn";
            this.dtpReturn.Size = new System.Drawing.Size(119, 29);
            this.dtpReturn.TabIndex = 80;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(237, 503);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(340, 26);
            this.txtRemarks.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 84;
            this.label2.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(340, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 39);
            this.btnClose.TabIndex = 85;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(860, 506);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(169, 29);
            this.txtTotalAmount.TabIndex = 86;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(749, 509);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 21);
            this.label20.TabIndex = 87;
            this.label20.Text = "Total Amount:";
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.Qty,
            this.UnitPrice,
            this.Total});
            this.dgProducts.Location = new System.Drawing.Point(170, 122);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(859, 375);
            this.dgProducts.TabIndex = 88;
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 418;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(537, 12);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(142, 29);
            this.cmbOutlet.TabIndex = 90;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(478, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 21);
            this.label8.TabIndex = 89;
            this.label8.Text = "Outlet";
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(319, 102);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(955, 457);
            this.ctlProductSearchControl.TabIndex = 10022;
            this.ctlProductSearchControl.Visible = false;
            this.ctlProductSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControlForPharmacy<HDMS.Model.Pharmacy.ViewModels.VWPhProductListForSale>.SearchEscapeEventHandler(this.ctlProductSearchControl_SearchEsacaped_1);
            // 
            // ctrlManufacturerSearchControl
            // 
            this.ctrlManufacturerSearchControl.Location = new System.Drawing.Point(438, 184);
            this.ctrlManufacturerSearchControl.Name = "ctrlManufacturerSearchControl";
            this.ctrlManufacturerSearchControl.Size = new System.Drawing.Size(754, 650);
            this.ctrlManufacturerSearchControl.TabIndex = 40;
            this.ctrlManufacturerSearchControl.Visible = false;
            // 
            // frmReturnToSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 729);
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlManufacturerSearchControl);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReturnTime);
            this.Controls.Add(this.dtpReturn);
            this.Controls.Add(this.txtDrescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrderTo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnReturnNow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReturnToSupplier";
            this.Text = "Return to supplier";
            this.Load += new System.EventHandler(this.frmReturnToSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturnNow;
        private Controls.ManufacturerSearchControl ctrlManufacturerSearchControl;
        private System.Windows.Forms.TextBox txtOrderTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDrescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReturnTime;
        private System.Windows.Forms.DateTimePicker dtpReturn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label8;
        private Controls.PhProductSaleSearchControl ctlProductSearchControl;
    }
}