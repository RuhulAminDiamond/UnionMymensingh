using HDMS.Model.Pharmacy.ViewModels;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class PhOPDProductSalesControl
    {
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDrescription;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgSales;

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.lblOutletItems = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbInvoiceType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDrescription = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDueTk = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtChangeTk = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReceiveTk = new System.Windows.Forms.TextBox();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgSales = new System.Windows.Forms.DataGridView();
            this.CodeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDrescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPrevId = new System.Windows.Forms.Button();
            this.btnNextId = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnDueCollection = new System.Windows.Forms.Button();
            this.btnStockEntry = new System.Windows.Forms.Button();
            this.txtRxId = new System.Windows.Forms.TextBox();
            this.lblDailyId = new System.Windows.Forms.Label();
            this.lblAssignedDoc = new System.Windows.Forms.Label();
            this.txtDiscInPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStockAvailable = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPaymentChannel = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtCardOrMobileReceiveTk = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtCardOrMobileCharge = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlPhMemberSearch = new HDMS.Windows.Forms.UI.Controls.ctrlPhMemberSearchControl();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.PhProductSaleSearchControl();
            this.ctlMemberSearchControl = new HDMS.Windows.Forms.UI.Controls.MemberSearchControl();
            this.ctlEmployeeSearchControl = new HDMS.Windows.Forms.UI.Controls.EmployeeSearchControl();
            this.lblPurchaseRate = new System.Windows.Forms.Label();
            this.lblPR = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPurchaseTotal = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtCustomerInvoiceNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(779, 9);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(189, 25);
            this.cmbOutlet.TabIndex = 49;
            this.cmbOutlet.SelectedIndexChanged += new System.EventHandler(this.cmbOutlet_SelectedIndexChanged);
            // 
            // lblOutletItems
            // 
            this.lblOutletItems.AutoSize = true;
            this.lblOutletItems.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutletItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutletItems.Location = new System.Drawing.Point(733, 9);
            this.lblOutletItems.Name = "lblOutletItems";
            this.lblOutletItems.Size = new System.Drawing.Size(43, 17);
            this.lblOutletItems.TabIndex = 48;
            this.lblOutletItems.Text = "Outlet";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(943, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(119, 20);
            this.label29.TabIndex = 21;
            this.label29.Text = "Date and Time :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(40, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 17);
            this.label19.TabIndex = 20;
            this.label19.Text = "Bill No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(90, 16);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(183, 25);
            this.txtInvoiceNo.TabIndex = 19;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNo_KeyPress);
            // 
            // txtMember
            // 
            this.txtMember.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMember.Location = new System.Drawing.Point(586, 48);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(189, 31);
            this.txtMember.TabIndex = 18;
            this.txtMember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMember_KeyPress);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(1192, 32);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(42, 20);
            this.lblTime.TabIndex = 14;
            this.lblTime.Text = "Time";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(514, 53);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 21);
            this.label28.TabIndex = 17;
            this.label28.Text = "Member";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Red;
            this.lblDate.Location = new System.Drawing.Point(1078, 32);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 20);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Date";
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeNo.Location = new System.Drawing.Point(335, 48);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(179, 31);
            this.txtEmployeeNo.TabIndex = 16;
            this.txtEmployeeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployeeNo_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(271, 53);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 21);
            this.label27.TabIndex = 15;
            this.label27.Text = "Emp. No";
            // 
            // cbInvoiceType
            // 
            this.cbInvoiceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInvoiceType.FormattingEnabled = true;
            this.cbInvoiceType.Location = new System.Drawing.Point(558, 11);
            this.cbInvoiceType.Name = "cbInvoiceType";
            this.cbInvoiceType.Size = new System.Drawing.Size(162, 25);
            this.cbInvoiceType.TabIndex = 14;
            this.cbInvoiceType.SelectedIndexChanged += new System.EventHandler(this.cbInvoiceType_SelectedIndexChanged);
            this.cbInvoiceType.TextChanged += new System.EventHandler(this.cbInvoiceType_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(502, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Inv. Type";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(287, 85);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 21);
            this.label21.TabIndex = 12;
            this.label21.Text = "Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(354, 85);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(440, 28);
            this.txtCustomerName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(140, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Item Description";
            // 
            // txtDrescription
            // 
            this.txtDrescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrescription.Location = new System.Drawing.Point(138, 151);
            this.txtDrescription.Name = "txtDrescription";
            this.txtDrescription.Size = new System.Drawing.Size(483, 29);
            this.txtDrescription.TabIndex = 77;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(764, 151);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 29);
            this.txtQuantity.TabIndex = 99;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(656, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Unit Price";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(24, 151);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 29);
            this.txtProductCode.TabIndex = 6;
            this.txtProductCode.Text = " ";
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(653, 151);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(92, 29);
            this.txtUnitPrice.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(775, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(25, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Product Code";
            // 
            // txtDueTk
            // 
            this.txtDueTk.Enabled = false;
            this.txtDueTk.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueTk.Location = new System.Drawing.Point(1046, 509);
            this.txtDueTk.Name = "txtDueTk";
            this.txtDueTk.Size = new System.Drawing.Size(178, 31);
            this.txtDueTk.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(955, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 23);
            this.label17.TabIndex = 19;
            this.label17.Text = "Sub Total :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(968, 512);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 26;
            this.label25.Text = "Due Tk :";
            // 
            // txtVat
            // 
            this.txtVat.Enabled = false;
            this.txtVat.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVat.Location = new System.Drawing.Point(1046, 131);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(178, 31);
            this.txtVat.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(999, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 23);
            this.label15.TabIndex = 15;
            this.label15.Text = "Vat :";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(1046, 94);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(178, 31);
            this.txtSubTotal.TabIndex = 14;
            // 
            // txtChangeTk
            // 
            this.txtChangeTk.Enabled = false;
            this.txtChangeTk.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeTk.Location = new System.Drawing.Point(1046, 468);
            this.txtChangeTk.Name = "txtChangeTk";
            this.txtChangeTk.Size = new System.Drawing.Size(178, 31);
            this.txtChangeTk.TabIndex = 25;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(1046, 209);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(178, 31);
            this.txtGrandTotal.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(936, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 23);
            this.label16.TabIndex = 16;
            this.label16.Text = "Grand Total :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(962, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 23);
            this.label18.TabIndex = 21;
            this.label18.Text = "Disc (%) :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(942, 471);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 23);
            this.label20.TabIndex = 24;
            this.label20.Text = "Change Tk :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(1157, 168);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(67, 31);
            this.txtDiscount.TabIndex = 16;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(910, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cash Payment :";
            // 
            // txtReceiveTk
            // 
            this.txtReceiveTk.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveTk.Location = new System.Drawing.Point(1046, 431);
            this.txtReceiveTk.Name = "txtReceiveTk";
            this.txtReceiveTk.Size = new System.Drawing.Size(178, 31);
            this.txtReceiveTk.TabIndex = 8;
            this.txtReceiveTk.TextChanged += new System.EventHandler(this.txtReceiveTk_TextChanged);
            this.txtReceiveTk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiveTk_KeyPress);
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.Location = new System.Drawing.Point(326, 638);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.Size = new System.Drawing.Size(112, 25);
            this.txtTotalItem.TabIndex = 13;
            this.txtTotalItem.TextChanged += new System.EventHandler(this.txtTotalItem_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(231, 638);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 21);
            this.label13.TabIndex = 12;
            this.label13.Text = "Total Items :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(1096, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 42);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgSales
            // 
            this.dgSales.AllowUserToAddRows = false;
            this.dgSales.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeNo,
            this.ItemDrescription,
            this.Column2,
            this.UnitPrice,
            this.Quantity,
            this.Total,
            this.Column1,
            this.PTotal});
            this.dgSales.Location = new System.Drawing.Point(24, 186);
            this.dgSales.Name = "dgSales";
            this.dgSales.RowHeadersWidth = 51;
            this.dgSales.Size = new System.Drawing.Size(849, 446);
            this.dgSales.TabIndex = 0;
            this.dgSales.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSales_CellValueChanged);
            this.dgSales.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSales_RowHeaderMouseDoubleClick);
            this.dgSales.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgSales_UserDeletedRow);
            // 
            // CodeNo
            // 
            this.CodeNo.HeaderText = "Code No";
            this.CodeNo.MinimumWidth = 6;
            this.CodeNo.Name = "CodeNo";
            this.CodeNo.Width = 125;
            // 
            // ItemDrescription
            // 
            this.ItemDrescription.HeaderText = "Item Drescription";
            this.ItemDrescription.MinimumWidth = 6;
            this.ItemDrescription.Name = "ItemDrescription";
            this.ItemDrescription.Width = 180;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ExpireDate";
            this.Column2.HeaderText = "ExpireDate";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 120;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BatchNo";
            this.Column1.HeaderText = "BatchNo";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // PTotal
            // 
            this.PTotal.HeaderText = "P. Total";
            this.PTotal.MinimumWidth = 6;
            this.PTotal.Name = "PTotal";
            this.PTotal.Width = 125;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(95, 638);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(112, 25);
            this.txtStaffName.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(22, 638);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 21);
            this.label11.TabIndex = 13;
            this.label11.Text = "Sale By :";
            // 
            // btnPrevId
            // 
            this.btnPrevId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevId.Location = new System.Drawing.Point(889, 546);
            this.btnPrevId.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevId.Name = "btnPrevId";
            this.btnPrevId.Size = new System.Drawing.Size(52, 42);
            this.btnPrevId.TabIndex = 10012;
            this.btnPrevId.Text = "<<";
            this.btnPrevId.UseVisualStyleBackColor = true;
            this.btnPrevId.Click += new System.EventHandler(this.btnPrevId_Click);
            // 
            // btnNextId
            // 
            this.btnNextId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextId.Location = new System.Drawing.Point(945, 546);
            this.btnNextId.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextId.Name = "btnNextId";
            this.btnNextId.Size = new System.Drawing.Size(46, 42);
            this.btnNextId.TabIndex = 10011;
            this.btnNextId.Text = ">>";
            this.btnNextId.UseVisualStyleBackColor = true;
            this.btnNextId.Click += new System.EventHandler(this.btnNextId_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnPrint.Location = new System.Drawing.Point(879, 599);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 42);
            this.btnPrint.TabIndex = 10013;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnNext.Location = new System.Drawing.Point(1096, 598);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(128, 42);
            this.btnNext.TabIndex = 10014;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnDueCollection
            // 
            this.btnDueCollection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDueCollection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnDueCollection.Location = new System.Drawing.Point(995, 546);
            this.btnDueCollection.Name = "btnDueCollection";
            this.btnDueCollection.Size = new System.Drawing.Size(95, 42);
            this.btnDueCollection.TabIndex = 10015;
            this.btnDueCollection.Text = "Due Collec.";
            this.btnDueCollection.UseVisualStyleBackColor = true;
            this.btnDueCollection.Click += new System.EventHandler(this.btnDueCollection_Click);
            // 
            // btnStockEntry
            // 
            this.btnStockEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockEntry.Location = new System.Drawing.Point(161, -200);
            this.btnStockEntry.Name = "btnStockEntry";
            this.btnStockEntry.Size = new System.Drawing.Size(102, 34);
            this.btnStockEntry.TabIndex = 10019;
            this.btnStockEntry.Text = "Stock Entry";
            this.btnStockEntry.UseVisualStyleBackColor = true;
            this.btnStockEntry.Click += new System.EventHandler(this.btnStockEntry_Click);
            // 
            // txtRxId
            // 
            this.txtRxId.BackColor = System.Drawing.Color.LightSalmon;
            this.txtRxId.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRxId.Location = new System.Drawing.Point(90, 88);
            this.txtRxId.Name = "txtRxId";
            this.txtRxId.Size = new System.Drawing.Size(166, 31);
            this.txtRxId.TabIndex = 10025;
            this.txtRxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRxId_KeyPress);
            // 
            // lblDailyId
            // 
            this.lblDailyId.AutoSize = true;
            this.lblDailyId.BackColor = System.Drawing.Color.Transparent;
            this.lblDailyId.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyId.Location = new System.Drawing.Point(45, 88);
            this.lblDailyId.Name = "lblDailyId";
            this.lblDailyId.Size = new System.Drawing.Size(39, 21);
            this.lblDailyId.TabIndex = 10024;
            this.lblDailyId.Text = "RxId";
            // 
            // lblAssignedDoc
            // 
            this.lblAssignedDoc.AutoSize = true;
            this.lblAssignedDoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignedDoc.ForeColor = System.Drawing.Color.Red;
            this.lblAssignedDoc.Location = new System.Drawing.Point(224, 7);
            this.lblAssignedDoc.Name = "lblAssignedDoc";
            this.lblAssignedDoc.Size = new System.Drawing.Size(0, 16);
            this.lblAssignedDoc.TabIndex = 10026;
            // 
            // txtDiscInPercent
            // 
            this.txtDiscInPercent.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscInPercent.Location = new System.Drawing.Point(1046, 168);
            this.txtDiscInPercent.Name = "txtDiscInPercent";
            this.txtDiscInPercent.Size = new System.Drawing.Size(67, 31);
            this.txtDiscInPercent.TabIndex = 7;
            this.txtDiscInPercent.TextChanged += new System.EventHandler(this.txtDiscInPercent_TextChanged);
            this.txtDiscInPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscInPercent_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(1113, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 10032;
            this.label3.Text = " (Tk.)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(316, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 10034;
            this.label8.Text = "Stock Available :";
            // 
            // lblStockAvailable
            // 
            this.lblStockAvailable.AutoSize = true;
            this.lblStockAvailable.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStockAvailable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockAvailable.ForeColor = System.Drawing.SystemColors.Info;
            this.lblStockAvailable.Location = new System.Drawing.Point(445, 131);
            this.lblStockAvailable.Name = "lblStockAvailable";
            this.lblStockAvailable.Size = new System.Drawing.Size(0, 17);
            this.lblStockAvailable.TabIndex = 10035;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(765, -100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 26);
            this.button2.TabIndex = 10036;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(1046, 246);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(178, 31);
            this.cmbPaymentMode.TabIndex = 10038;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            this.cmbPaymentMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentMode_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(907, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 23);
            this.label14.TabIndex = 10037;
            this.label14.Text = "Payment Mode :";
            // 
            // cmbPaymentChannel
            // 
            this.cmbPaymentChannel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentChannel.FormattingEnabled = true;
            this.cmbPaymentChannel.Location = new System.Drawing.Point(1046, 283);
            this.cmbPaymentChannel.Name = "cmbPaymentChannel";
            this.cmbPaymentChannel.Size = new System.Drawing.Size(178, 31);
            this.cmbPaymentChannel.TabIndex = 10040;
            this.cmbPaymentChannel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentChannel_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(890, 286);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(153, 23);
            this.label23.TabIndex = 10039;
            this.label23.Text = "Payment Channel :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(905, 360);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(135, 23);
            this.label30.TabIndex = 10042;
            this.label30.Text = "Transaction No :";
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Enabled = false;
            this.txtTransactionNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNo.Location = new System.Drawing.Point(1046, 357);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(178, 31);
            this.txtTransactionNo.TabIndex = 10041;
            this.txtTransactionNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionNo_KeyPress);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(875, 320);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(165, 23);
            this.label31.TabIndex = 10044;
            this.label31.Text = "Card/Mob. Rec. Tk :";
            // 
            // txtCardOrMobileReceiveTk
            // 
            this.txtCardOrMobileReceiveTk.Enabled = false;
            this.txtCardOrMobileReceiveTk.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileReceiveTk.Location = new System.Drawing.Point(1046, 320);
            this.txtCardOrMobileReceiveTk.Name = "txtCardOrMobileReceiveTk";
            this.txtCardOrMobileReceiveTk.Size = new System.Drawing.Size(178, 31);
            this.txtCardOrMobileReceiveTk.TabIndex = 10043;
            this.txtCardOrMobileReceiveTk.TextChanged += new System.EventHandler(this.txtCardOrMobileReceiveTk_TextChanged);
            this.txtCardOrMobileReceiveTk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardOrMobileReceiveTk_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(875, 397);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(168, 23);
            this.label32.TabIndex = 10046;
            this.label32.Text = "Card/Mob. Char. Tk :";
            // 
            // txtCardOrMobileCharge
            // 
            this.txtCardOrMobileCharge.Enabled = false;
            this.txtCardOrMobileCharge.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileCharge.Location = new System.Drawing.Point(1046, 394);
            this.txtCardOrMobileCharge.Name = "txtCardOrMobileCharge";
            this.txtCardOrMobileCharge.Size = new System.Drawing.Size(178, 31);
            this.txtCardOrMobileCharge.TabIndex = 10045;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(90, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 31);
            this.textBox1.TabIndex = 10048;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 10047;
            this.label2.Text = "Mobile No";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(987, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 43);
            this.button1.TabIndex = 10049;
            this.button1.Text = "Stock Entry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlPhMemberSearch
            // 
            this.ctlPhMemberSearch.Location = new System.Drawing.Point(227, 394);
            this.ctlPhMemberSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlPhMemberSearch.Name = "ctlPhMemberSearch";
            this.ctlPhMemberSearch.Size = new System.Drawing.Size(604, 428);
            this.ctlPhMemberSearch.TabIndex = 10027;
            this.ctlPhMemberSearch.Visible = false;
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(-95, 249);
            this.ctlProductSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(993, 499);
            this.ctlProductSearchControl.TabIndex = 10021;
            this.ctlProductSearchControl.Visible = false;
            this.ctlProductSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControlForPharmacy<HDMS.Model.Pharmacy.ViewModels.VWPhProductListForSale>.SearchEscapeEventHandler(this.ctlProductSearchControl_SearchEsacaped_1);
            this.ctlProductSearchControl.Load += new System.EventHandler(this.ctlProductSearchControl_Load);
            // 
            // ctlMemberSearchControl
            // 
            this.ctlMemberSearchControl.Location = new System.Drawing.Point(177, 410);
            this.ctlMemberSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctlMemberSearchControl.Name = "ctlMemberSearchControl";
            this.ctlMemberSearchControl.Size = new System.Drawing.Size(691, 456);
            this.ctlMemberSearchControl.TabIndex = 10023;
            this.ctlMemberSearchControl.Visible = false;
            // 
            // ctlEmployeeSearchControl
            // 
            this.ctlEmployeeSearchControl.Location = new System.Drawing.Point(143, 431);
            this.ctlEmployeeSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctlEmployeeSearchControl.Name = "ctlEmployeeSearchControl";
            this.ctlEmployeeSearchControl.Size = new System.Drawing.Size(633, 330);
            this.ctlEmployeeSearchControl.TabIndex = 10022;
            this.ctlEmployeeSearchControl.Visible = false;
            this.ctlEmployeeSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.HR.VMEmployeeInfo>.SearchEscapeEventHandler(this.ctlEmployeeSearchControl_SearchEsacaped);
            // 
            // lblPurchaseRate
            // 
            this.lblPurchaseRate.AutoSize = true;
            this.lblPurchaseRate.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblPurchaseRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseRate.ForeColor = System.Drawing.Color.White;
            this.lblPurchaseRate.Location = new System.Drawing.Point(574, 131);
            this.lblPurchaseRate.Name = "lblPurchaseRate";
            this.lblPurchaseRate.Size = new System.Drawing.Size(0, 17);
            this.lblPurchaseRate.TabIndex = 10050;
            // 
            // lblPR
            // 
            this.lblPR.AutoSize = true;
            this.lblPR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPR.ForeColor = System.Drawing.Color.Maroon;
            this.lblPR.Location = new System.Drawing.Point(530, 129);
            this.lblPR.Name = "lblPR";
            this.lblPR.Size = new System.Drawing.Size(38, 17);
            this.lblPR.TabIndex = 10051;
            this.lblPR.Text = "P.R : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(955, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "P.R Total :";
            // 
            // txtPurchaseTotal
            // 
            this.txtPurchaseTotal.Enabled = false;
            this.txtPurchaseTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseTotal.Location = new System.Drawing.Point(1049, 57);
            this.txtPurchaseTotal.Name = "txtPurchaseTotal";
            this.txtPurchaseTotal.Size = new System.Drawing.Size(175, 31);
            this.txtPurchaseTotal.TabIndex = 15;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(279, 21);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 17);
            this.label34.TabIndex = 10053;
            this.label34.Text = "Inv. No";
            // 
            // txtCustomerInvoiceNo
            // 
            this.txtCustomerInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerInvoiceNo.Location = new System.Drawing.Point(331, 17);
            this.txtCustomerInvoiceNo.Name = "txtCustomerInvoiceNo";
            this.txtCustomerInvoiceNo.Size = new System.Drawing.Size(162, 25);
            this.txtCustomerInvoiceNo.TabIndex = 10052;
            this.txtCustomerInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerInvoiceNo_KeyPress);
            // 
            // PhOPDProductSalesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.label34);
            this.Controls.Add(this.txtCustomerInvoiceNo);
            this.Controls.Add(this.ctlEmployeeSearchControl);
            this.Controls.Add(this.lblPurchaseRate);
            this.Controls.Add(this.lblPR);
            this.Controls.Add(this.ctlPhMemberSearch);
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlMemberSearchControl);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txtCardOrMobileCharge);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtCardOrMobileReceiveTk);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbPaymentChannel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblStockAvailable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscInPercent);
            this.Controls.Add(this.lblAssignedDoc);
            this.Controls.Add(this.txtRxId);
            this.Controls.Add(this.lblDailyId);
            this.Controls.Add(this.txtDueTk);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtPurchaseTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVat);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgSales);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtChangeTk);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtDrescription);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblOutletItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStockEntry);
            this.Controls.Add(this.txtReceiveTk);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.btnDueCollection);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtEmployeeNo);
            this.Controls.Add(this.btnPrevId);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbInvoiceType);
            this.Controls.Add(this.btnNextId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.button1);
            this.Name = "PhOPDProductSalesControl";
            this.Size = new System.Drawing.Size(1647, 870);
            this.Load += new System.EventHandler(this.PhProductSalesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtReceiveTk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChangeTk;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDueTk;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cbInvoiceType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label11;
        private HDMS.Windows.Forms.UI.Controls.PhProductSaleSearchControl ctlProductSearchControl;
        private System.Windows.Forms.Button btnPrevId;
        private System.Windows.Forms.Button btnNextId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnDueCollection;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label lblOutletItems;
        private System.Windows.Forms.Button btnStockEntry;
        private HDMS.Windows.Forms.UI.Controls.EmployeeSearchControl ctlEmployeeSearchControl;
        private HDMS.Windows.Forms.UI.Controls.MemberSearchControl ctlMemberSearchControl;
        private System.Windows.Forms.TextBox txtRxId;
        private System.Windows.Forms.Label lblDailyId;
        private System.Windows.Forms.Label lblAssignedDoc;
        private HDMS.Windows.Forms.UI.Controls.ctrlPhMemberSearchControl ctlPhMemberSearch;
        private System.Windows.Forms.TextBox txtDiscInPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStockAvailable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPaymentChannel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtCardOrMobileReceiveTk;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtCardOrMobileCharge;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDrescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTotal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPurchaseRate;
        private System.Windows.Forms.Label lblPR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPurchaseTotal;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtCustomerInvoiceNo;
    }
}
