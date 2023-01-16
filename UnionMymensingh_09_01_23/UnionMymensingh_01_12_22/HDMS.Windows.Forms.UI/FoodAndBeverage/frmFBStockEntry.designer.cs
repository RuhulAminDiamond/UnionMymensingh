using Models.Store;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    partial class frmFBStockEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFBStockEntry));
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSInvDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalTk = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpRDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupInvoice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrevId = new System.Windows.Forms.Button();
            this.btnNextId = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReceiveNo = new System.Windows.Forms.TextBox();
            this.btnNextReceive = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.StoreProductSearchControl();
            this.ctlSupplierSearch = new HDMS.Windows.Forms.UI.Controls.SupplierSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(218, 113);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(294, 26);
            this.txtProductName.TabIndex = 88;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.Width = 80;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.tName,
            this.DDate,
            this.DTime,
            this.Rate,
            this.Total});
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgItems.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgItems.Location = new System.Drawing.Point(112, 145);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.Size = new System.Drawing.Size(665, 356);
            this.dgItems.TabIndex = 68;
            this.dgItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgItems_UserDeletedRow);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Width = 50;
            // 
            // tName
            // 
            this.tName.HeaderText = "Name";
            this.tName.Name = "tName";
            this.tName.Width = 230;
            // 
            // DDate
            // 
            this.DDate.HeaderText = "Qty";
            this.DDate.Name = "DDate";
            this.DDate.Width = 80;
            // 
            // DTime
            // 
            this.DTime.HeaderText = "Unit";
            this.DTime.Name = "DTime";
            this.DTime.Width = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(614, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 77;
            this.label6.Text = "R. Date";
            // 
            // dtpSInvDate
            // 
            this.dtpSInvDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSInvDate.Location = new System.Drawing.Point(678, 59);
            this.dtpSInvDate.Name = "dtpSInvDate";
            this.dtpSInvDate.Size = new System.Drawing.Size(138, 26);
            this.dtpSInvDate.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(568, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 86;
            this.label7.Text = "S/Invoice Date";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(678, 567);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 46);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtDiscount.Location = new System.Drawing.Point(903, 326);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(160, 32);
            this.txtDiscount.TabIndex = 81;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(787, 326);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 25);
            this.label16.TabIndex = 84;
            this.label16.Text = "Discount Tk";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalTk
            // 
            this.txtTotalTk.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtTotalTk.Enabled = false;
            this.txtTotalTk.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTk.ForeColor = System.Drawing.Color.Green;
            this.txtTotalTk.Location = new System.Drawing.Point(903, 281);
            this.txtTotalTk.Name = "txtTotalTk";
            this.txtTotalTk.Size = new System.Drawing.Size(160, 39);
            this.txtTotalTk.TabIndex = 82;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(489, 507);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 32);
            this.label12.TabIndex = 83;
            this.label12.Text = "Total Qty.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpRDate
            // 
            this.dtpRDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRDate.Location = new System.Drawing.Point(678, 27);
            this.dtpRDate.Name = "dtpRDate";
            this.dtpRDate.Size = new System.Drawing.Size(138, 26);
            this.dtpRDate.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "S/Invoice No";
            // 
            // txtSupInvoice
            // 
            this.txtSupInvoice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupInvoice.Location = new System.Drawing.Point(142, 40);
            this.txtSupInvoice.Name = "txtSupInvoice";
            this.txtSupInvoice.Size = new System.Drawing.Size(187, 26);
            this.txtSupInvoice.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(142, 72);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(370, 26);
            this.txtSupplier.TabIndex = 74;
            this.txtSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupplier_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(659, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(536, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 71;
            this.label1.Text = "Rate";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(696, 113);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(81, 26);
            this.txtQty.TabIndex = 70;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(581, 113);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(72, 26);
            this.txtRate.TabIndex = 69;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(52, 116);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(60, 18);
            this.lblTest.TabIndex = 66;
            this.lblTest.Text = "Product";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(112, 113);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 26);
            this.txtProduct.TabIndex = 67;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            this.txtProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(346, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 46);
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.ForeColor = System.Drawing.Color.Green;
            this.txtPaid.Location = new System.Drawing.Point(903, 373);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(160, 39);
            this.txtPaid.TabIndex = 91;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(791, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 32);
            this.label5.TabIndex = 92;
            this.label5.Text = "Paid Tk.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.Green;
            this.txtDue.Location = new System.Drawing.Point(903, 425);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(160, 39);
            this.txtDue.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(794, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 32);
            this.label8.TabIndex = 94;
            this.label8.Text = "Due Tk.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.ForeColor = System.Drawing.Color.Green;
            this.txtTotalQty.Location = new System.Drawing.Point(617, 507);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(160, 39);
            this.txtTotalQty.TabIndex = 97;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(569, 567);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 46);
            this.btnPrint.TabIndex = 98;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrevId
            // 
            this.btnPrevId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevId.Location = new System.Drawing.Point(250, 520);
            this.btnPrevId.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevId.Name = "btnPrevId";
            this.btnPrevId.Size = new System.Drawing.Size(52, 26);
            this.btnPrevId.TabIndex = 10012;
            this.btnPrevId.Text = "<<";
            this.btnPrevId.UseVisualStyleBackColor = true;
            this.btnPrevId.Click += new System.EventHandler(this.btnPrevId_Click);
            // 
            // btnNextId
            // 
            this.btnNextId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextId.Location = new System.Drawing.Point(334, 520);
            this.btnNextId.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextId.Name = "btnNextId";
            this.btnNextId.Size = new System.Drawing.Size(46, 26);
            this.btnNextId.TabIndex = 10011;
            this.btnNextId.Text = ">>";
            this.btnNextId.UseVisualStyleBackColor = true;
            this.btnNextId.Click += new System.EventHandler(this.btnNextId_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 10013;
            this.label9.Text = "St. Receive No";
            // 
            // txtReceiveNo
            // 
            this.txtReceiveNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveNo.Location = new System.Drawing.Point(142, 8);
            this.txtReceiveNo.Name = "txtReceiveNo";
            this.txtReceiveNo.Size = new System.Drawing.Size(127, 26);
            this.txtReceiveNo.TabIndex = 10014;
            // 
            // btnNextReceive
            // 
            this.btnNextReceive.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextReceive.Location = new System.Drawing.Point(455, 567);
            this.btnNextReceive.Name = "btnNextReceive";
            this.btnNextReceive.Size = new System.Drawing.Size(103, 46);
            this.btnNextReceive.TabIndex = 10015;
            this.btnNextReceive.Text = "Clear";
            this.btnNextReceive.UseVisualStyleBackColor = true;
            this.btnNextReceive.Click += new System.EventHandler(this.btnNextReceive_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(812, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 25);
            this.label10.TabIndex = 10016;
            this.label10.Text = "Total Tk";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlProductSearchControl
            // 
            this.ctrlProductSearchControl.Location = new System.Drawing.Point(-42, 50);
            this.ctrlProductSearchControl.Name = "ctrlProductSearchControl";
            this.ctrlProductSearchControl.Size = new System.Drawing.Size(773, 414);
            this.ctrlProductSearchControl.TabIndex = 96;
            this.ctrlProductSearchControl.Visible = false;
            // 
            // ctlSupplierSearch
            // 
            this.ctlSupplierSearch.Location = new System.Drawing.Point(21, -135);
            this.ctlSupplierSearch.Name = "ctlSupplierSearch";
            this.ctlSupplierSearch.Size = new System.Drawing.Size(684, 650);
            this.ctlSupplierSearch.TabIndex = 95;
            this.ctlSupplierSearch.Visible = false;
            this.ctlSupplierSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Common.SupplierInfo>.SearchEscapeEventHandler(this.ctlSupplierSearch_SearchEsacaped);
            // 
            // frmStoreStockEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 734);
            this.Controls.Add(this.ctrlProductSearchControl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ctlSupplierSearch);
            this.Controls.Add(this.btnNextReceive);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReceiveNo);
            this.Controls.Add(this.btnPrevId);
            this.Controls.Add(this.btnNextId);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtDue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpSInvDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotalTk);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpRDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSupInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStoreStockEntry";
            this.Text = "Stock Entry";
            this.Load += new System.EventHandler(this.frmStockEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpSInvDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotalTk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpRDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtProduct;
      
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.Label label8;
        private HDMS.Windows.Forms.UI.Controls.SupplierSearchControl ctlSupplierSearch;
        private Windows.Forms.UI.Controls.StoreProductSearchControl ctrlProductSearchControl;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrevId;
        private System.Windows.Forms.Button btnNextId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReceiveNo;
        private System.Windows.Forms.Button btnNextReceive;
        private System.Windows.Forms.Label label10;
    }
}