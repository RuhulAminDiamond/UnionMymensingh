

using Models.Store;

namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    partial class frmIssueFBItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueFBItem));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.dtpInvData = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.btnPrevId = new System.Windows.Forms.Button();
            this.btnNextId = new System.Windows.Forms.Button();
            this.lblRequisitionPanel = new System.Windows.Forms.Panel();
            this.dgRequistions = new System.Windows.Forms.DataGridView();
            this.RequisitionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRequisitionList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsStockShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveredStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRequisitionNo = new System.Windows.Forms.TextBox();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.StoreProductSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.lblRequisitionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequistions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisitionList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(377, 587);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 47);
            this.btnClear.TabIndex = 109;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInvoice.Location = new System.Drawing.Point(503, 587);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(125, 47);
            this.btnPrintInvoice.TabIndex = 108;
            this.btnPrintInvoice.Text = "Print Invoice";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 106;
            this.label5.Text = "Issue No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(139, 34);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(210, 26);
            this.txtInvoiceNo.TabIndex = 107;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(647, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 47);
            this.btnSave.TabIndex = 105;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(491, 541);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 26);
            this.label7.TabIndex = 97;
            this.label7.Text = "Issue Qty";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Tomato;
            this.txtTotalAmount.Location = new System.Drawing.Point(290, -100);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(167, 35);
            this.txtTotalAmount.TabIndex = 98;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(233, 111);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(247, 29);
            this.txtProductName.TabIndex = 96;
            // 
            // dtpInvData
            // 
            this.dtpInvData.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvData.Location = new System.Drawing.Point(139, 66);
            this.dtpInvData.Name = "dtpInvData";
            this.dtpInvData.Size = new System.Drawing.Size(136, 25);
            this.dtpInvData.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 94;
            this.label6.Text = "Invoice Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(659, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 91;
            this.label2.Text = "Qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(515, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 90;
            this.label1.Text = "Rate";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(696, 111);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(76, 29);
            this.txtQty.TabIndex = 89;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
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
            this.tName.Width = 200;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 80;
            // 
            // DTime
            // 
            this.DTime.HeaderText = "Unit";
            this.DTime.Name = "DTime";
            this.DTime.Width = 80;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(560, 111);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(68, 29);
            this.txtRate.TabIndex = 88;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(65, 111);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(59, 17);
            this.lblTest.TabIndex = 85;
            this.lblTest.Text = "Product";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(138, 111);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(88, 29);
            this.txtProduct.TabIndex = 86;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            this.txtProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
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
            this.Qty,
            this.DTime,
            this.Rate,
            this.Total});
            this.dgItems.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgItems.Location = new System.Drawing.Point(138, 146);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.Size = new System.Drawing.Size(634, 383);
            this.dgItems.TabIndex = 87;
            this.dgItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellValueChanged);
            this.dgItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgItems_UserDeletedRow);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(267, 587);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 47);
            this.btnClose.TabIndex = 122;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.ForeColor = System.Drawing.Color.Tomato;
            this.txtTotalQty.Location = new System.Drawing.Point(605, 538);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(167, 35);
            this.txtTotalQty.TabIndex = 124;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrevId
            // 
            this.btnPrevId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevId.Location = new System.Drawing.Point(267, 541);
            this.btnPrevId.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevId.Name = "btnPrevId";
            this.btnPrevId.Size = new System.Drawing.Size(52, 26);
            this.btnPrevId.TabIndex = 10014;
            this.btnPrevId.Text = "<<";
            this.btnPrevId.UseVisualStyleBackColor = true;
            this.btnPrevId.Click += new System.EventHandler(this.btnPrevId_Click);
            // 
            // btnNextId
            // 
            this.btnNextId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextId.Location = new System.Drawing.Point(351, 541);
            this.btnNextId.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextId.Name = "btnNextId";
            this.btnNextId.Size = new System.Drawing.Size(46, 26);
            this.btnNextId.TabIndex = 10013;
            this.btnNextId.Text = ">>";
            this.btnNextId.UseVisualStyleBackColor = true;
            this.btnNextId.Click += new System.EventHandler(this.btnNextId_Click);
            // 
            // lblRequisitionPanel
            // 
            this.lblRequisitionPanel.BackColor = System.Drawing.SystemColors.Info;
            this.lblRequisitionPanel.Controls.Add(this.dgRequistions);
            this.lblRequisitionPanel.Controls.Add(this.dgRequisitionList);
            this.lblRequisitionPanel.Controls.Add(this.button1);
            this.lblRequisitionPanel.Controls.Add(this.btnRefresh);
            this.lblRequisitionPanel.Controls.Add(this.btnCancel);
            this.lblRequisitionPanel.Location = new System.Drawing.Point(292, 46);
            this.lblRequisitionPanel.Name = "lblRequisitionPanel";
            this.lblRequisitionPanel.Size = new System.Drawing.Size(1079, 573);
            this.lblRequisitionPanel.TabIndex = 10021;
            // 
            // dgRequistions
            // 
            this.dgRequistions.AllowUserToAddRows = false;
            this.dgRequistions.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgRequistions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequistions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequisitionId,
            this.CabinNo,
            this.Dept,
            this.Status});
            this.dgRequistions.Location = new System.Drawing.Point(39, 83);
            this.dgRequistions.Name = "dgRequistions";
            this.dgRequistions.Size = new System.Drawing.Size(465, 444);
            this.dgRequistions.TabIndex = 10023;
            this.dgRequistions.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRequistions_RowHeaderMouseClick);
            // 
            // RequisitionId
            // 
            this.RequisitionId.DataPropertyName = "RequisitionId";
            this.RequisitionId.HeaderText = "RequisitionNo";
            this.RequisitionId.Name = "RequisitionId";
            this.RequisitionId.Width = 120;
            // 
            // CabinNo
            // 
            this.CabinNo.DataPropertyName = "CabinNo";
            this.CabinNo.HeaderText = "Date";
            this.CabinNo.Name = "CabinNo";
            // 
            // Dept
            // 
            this.Dept.HeaderText = "Department";
            this.Dept.Name = "Dept";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // dgRequisitionList
            // 
            this.dgRequisitionList.AllowUserToAddRows = false;
            this.dgRequisitionList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgRequisitionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequisitionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column3,
            this.IsStockShort,
            this.DeliveredStatus,
            this.Remarks});
            this.dgRequisitionList.Location = new System.Drawing.Point(510, 83);
            this.dgRequisitionList.Name = "dgRequisitionList";
            this.dgRequisitionList.Size = new System.Drawing.Size(719, 461);
            this.dgRequisitionList.TabIndex = 10018;
            this.dgRequisitionList.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRequisitionList_RowHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RequisitionNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RequisitionBy";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn3.HeaderText = "Req. Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Avail. Qty";
            this.Column3.Name = "Column3";
            // 
            // IsStockShort
            // 
            this.IsStockShort.HeaderText = "IsStockShort";
            this.IsStockShort.Name = "IsStockShort";
            // 
            // DeliveredStatus
            // 
            this.DeliveredStatus.HeaderText = "Delivery Status";
            this.DeliveredStatus.Name = "DeliveredStatus";
            this.DeliveredStatus.Width = 120;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 250;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 10021;
            this.button1.Text = ">>  >>  >> ------>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(401, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 31);
            this.btnRefresh.TabIndex = 10022;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(242, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 31);
            this.btnCancel.TabIndex = 10019;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 10022;
            this.label3.Text = "Requisition No";
            // 
            // txtRequisitionNo
            // 
            this.txtRequisitionNo.Enabled = false;
            this.txtRequisitionNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequisitionNo.Location = new System.Drawing.Point(401, 67);
            this.txtRequisitionNo.Name = "txtRequisitionNo";
            this.txtRequisitionNo.Size = new System.Drawing.Size(136, 26);
            this.txtRequisitionNo.TabIndex = 10023;
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(-538, 558);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(764, 650);
            this.ctlProductSearchControl.TabIndex = 123;
            this.ctlProductSearchControl.Visible = false;
            this.ctlProductSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<StoreProductInfo>.SearchEscapeEventHandler(this.ctlProductSearchControl_SearchEsacaped);
            // 
            // frmIssueItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 646);
            this.Controls.Add(this.lblRequisitionPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRequisitionNo);
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.btnPrevId);
            this.Controls.Add(this.btnNextId);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.dtpInvData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.dgItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIssueItem";
            this.Text = "Issue Item";
            this.Load += new System.EventHandler(this.frmIssueItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.lblRequisitionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRequistions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisitionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.DateTimePicker dtpInvData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTime;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridView dgItems;
      
        private System.Windows.Forms.Button btnClose;
        private Windows.Forms.UI.Controls.StoreProductSearchControl ctlProductSearchControl;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Button btnPrevId;
        private System.Windows.Forms.Button btnNextId;
        private System.Windows.Forms.Panel lblRequisitionPanel;
        private System.Windows.Forms.DataGridView dgRequisitionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsStockShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveredStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgRequistions;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRequisitionNo;
    }
}