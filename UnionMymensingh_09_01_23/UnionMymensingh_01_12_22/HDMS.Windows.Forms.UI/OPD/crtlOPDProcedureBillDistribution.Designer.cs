
namespace HDMS.Windows.Forms.UI.OPD
{
    partial class crtlOPDProcedureBillDistribution
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgProcBills = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtServiceItem = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBillSave = new System.Windows.Forms.Button();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.lbldis = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtService = new System.Windows.Forms.TextBox();
            this.txtServiceRate = new System.Windows.Forms.TextBox();
            this.txtServiceQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dgNormalService = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStockAvailable = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgSales = new System.Windows.Forms.DataGridView();
            this.CodeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDrescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDrescription = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.PhProductSaleSearchControl();
            this.ctrlService = new HDMS.Windows.Forms.UI.Controls.HospitalBillItemSearchControl();
            this.ctrlDoctor = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.ctrlServicetem = new HDMS.Windows.Forms.UI.Controls.HospitalBillItemSearchControl();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNormalService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 719);
            this.panel1.TabIndex = 10040;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgProcBills, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchByCabin, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.849315F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.15069F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 719);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgProcBills
            // 
            this.dgProcBills.AllowUserToAddRows = false;
            this.dgProcBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProcBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.AdmDate});
            this.dgProcBills.Location = new System.Drawing.Point(3, 52);
            this.dgProcBills.Name = "dgProcBills";
            this.dgProcBills.RowHeadersWidth = 51;
            this.dgProcBills.Size = new System.Drawing.Size(389, 664);
            this.dgProcBills.TabIndex = 0;
            this.dgProcBills.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProcBills_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bill No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Patinet Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // AdmDate
            // 
            this.AdmDate.HeaderText = "Discharge Date";
            this.AdmDate.MinimumWidth = 6;
            this.AdmDate.Name = "AdmDate";
            this.AdmDate.Width = 140;
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(23, 12);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(356, 25);
            this.txtSearchByCabin.TabIndex = 1;
            this.txtSearchByCabin.Text = "Search by cabin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(546, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 10039;
            this.label9.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(385, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 10041;
            this.label1.Text = "Bill No :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(802, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 10042;
            this.label2.Text = "Total Bill :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(1080, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 10043;
            this.label3.Text = "Paid  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(952, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 10044;
            this.label4.Text = "Discount  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(1209, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 21);
            this.label5.TabIndex = 10045;
            this.label5.Text = "Due  :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1065, 445);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 18);
            this.label13.TabIndex = 10054;
            this.label13.Text = "Qty";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(930, 446);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 18);
            this.label12.TabIndex = 10053;
            this.label12.Text = "Rate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(601, 445);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 10052;
            this.label11.Text = "Doctor Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(407, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 18);
            this.label10.TabIndex = 10051;
            this.label10.Text = "Service Item";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(1068, 466);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(101, 26);
            this.txtQty.TabIndex = 10050;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(933, 467);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(101, 26);
            this.txtRate.TabIndex = 10049;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor.Location = new System.Drawing.Point(604, 466);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(302, 26);
            this.txtDoctor.TabIndex = 10048;
            this.txtDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoctor_KeyPress);
            // 
            // txtServiceItem
            // 
            this.txtServiceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceItem.Location = new System.Drawing.Point(408, 466);
            this.txtServiceItem.Name = "txtServiceItem";
            this.txtServiceItem.Size = new System.Drawing.Size(167, 26);
            this.txtServiceItem.TabIndex = 10047;
            this.txtServiceItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceItem_KeyPress);
            // 
            // dgService
            // 
            this.dgService.AllowUserToAddRows = false;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Rate,
            this.Column3,
            this.Column4});
            this.dgService.Location = new System.Drawing.Point(411, 498);
            this.dgService.Name = "dgService";
            this.dgService.RowHeadersWidth = 51;
            this.dgService.Size = new System.Drawing.Size(756, 139);
            this.dgService.TabIndex = 10046;
            this.dgService.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgService_UserDeletedRow);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Service Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Doctor Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.Width = 110;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Qty";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // btnBillSave
            // 
            this.btnBillSave.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillSave.ForeColor = System.Drawing.Color.Black;
            this.btnBillSave.Location = new System.Drawing.Point(1058, 643);
            this.btnBillSave.Name = "btnBillSave";
            this.btnBillSave.Size = new System.Drawing.Size(111, 39);
            this.btnBillSave.TabIndex = 10057;
            this.btnBillSave.Text = "Save";
            this.btnBillSave.UseVisualStyleBackColor = true;
            this.btnBillSave.Click += new System.EventHandler(this.btnBillSave_Click);
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.Red;
            this.lblBillNo.Location = new System.Drawing.Point(448, 3);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(0, 18);
            this.lblBillNo.TabIndex = 10058;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(612, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10059;
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Red;
            this.lblTotalBill.Location = new System.Drawing.Point(892, 5);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(0, 18);
            this.lblTotalBill.TabIndex = 10060;
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.ForeColor = System.Drawing.Color.Red;
            this.lblPaid.Location = new System.Drawing.Point(1129, 5);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(0, 18);
            this.lblPaid.TabIndex = 10061;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Red;
            this.lblDiscount.Location = new System.Drawing.Point(1044, 7);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(0, 18);
            this.lblDiscount.TabIndex = 10062;
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.ForeColor = System.Drawing.Color.Red;
            this.lblDue.Location = new System.Drawing.Point(1260, 8);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(0, 18);
            this.lblDue.TabIndex = 10063;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1174, 579);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 10065;
            this.label6.Text = "Total Amount :";
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Enabled = false;
            this.txtTotalBill.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.ForeColor = System.Drawing.Color.Red;
            this.txtTotalBill.Location = new System.Drawing.Point(1174, 602);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(106, 31);
            this.txtTotalBill.TabIndex = 10064;
            this.txtTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbldis
            // 
            this.lbldis.AutoSize = true;
            this.lbldis.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldis.ForeColor = System.Drawing.Color.Red;
            this.lbldis.Location = new System.Drawing.Point(1038, 2);
            this.lbldis.Name = "lbldis";
            this.lbldis.Size = new System.Drawing.Size(0, 18);
            this.lbldis.TabIndex = 10066;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1162, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 18);
            this.label16.TabIndex = 10088;
            this.label16.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(1162, 202);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(118, 27);
            this.txtTotalAmount.TabIndex = 10087;
            // 
            // txtService
            // 
            this.txtService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.Location = new System.Drawing.Point(409, 51);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(339, 26);
            this.txtService.TabIndex = 10079;
            this.txtService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtService_KeyPress);
            // 
            // txtServiceRate
            // 
            this.txtServiceRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceRate.Location = new System.Drawing.Point(910, 53);
            this.txtServiceRate.Name = "txtServiceRate";
            this.txtServiceRate.Size = new System.Drawing.Size(101, 26);
            this.txtServiceRate.TabIndex = 10080;
            this.txtServiceRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceRate_KeyPress);
            // 
            // txtServiceQty
            // 
            this.txtServiceQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceQty.Location = new System.Drawing.Point(1068, 53);
            this.txtServiceQty.Name = "txtServiceQty";
            this.txtServiceQty.Size = new System.Drawing.Size(88, 26);
            this.txtServiceQty.TabIndex = 10081;
            this.txtServiceQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceQty_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(408, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 10082;
            this.label7.Text = "Service Item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(909, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 18);
            this.label8.TabIndex = 10083;
            this.label8.Text = "Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1065, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 18);
            this.label14.TabIndex = 10084;
            this.label14.Text = "Qty";
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpServiceDate.Location = new System.Drawing.Point(771, 51);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(117, 26);
            this.dtpServiceDate.TabIndex = 10086;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(771, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 18);
            this.label15.TabIndex = 10085;
            this.label15.Text = "Service Date";
            // 
            // dgNormalService
            // 
            this.dgNormalService.AllowUserToAddRows = false;
            this.dgNormalService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNormalService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column5});
            this.dgNormalService.Location = new System.Drawing.Point(409, 83);
            this.dgNormalService.Name = "dgNormalService";
            this.dgNormalService.Size = new System.Drawing.Size(747, 146);
            this.dgNormalService.TabIndex = 10078;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Service Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Service Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "User";
            this.Column5.Name = "Column5";
            // 
            // lblStockAvailable
            // 
            this.lblStockAvailable.AutoSize = true;
            this.lblStockAvailable.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStockAvailable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockAvailable.ForeColor = System.Drawing.SystemColors.Info;
            this.lblStockAvailable.Location = new System.Drawing.Point(803, 239);
            this.lblStockAvailable.Name = "lblStockAvailable";
            this.lblStockAvailable.Size = new System.Drawing.Size(0, 17);
            this.lblStockAvailable.TabIndex = 10101;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.OrangeRed;
            this.label17.Location = new System.Drawing.Point(687, 239);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 17);
            this.label17.TabIndex = 10100;
            this.label17.Text = "Stock Available :";
            // 
            // dgSales
            // 
            this.dgSales.AllowUserToAddRows = false;
            this.dgSales.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodeNo,
            this.ItemDrescription,
            this.dataGridViewTextBoxColumn8,
            this.UnitPrice,
            this.Quantity,
            this.Total,
            this.dataGridViewTextBoxColumn9,
            this.PTotal});
            this.dgSales.Location = new System.Drawing.Point(403, 294);
            this.dgSales.Name = "dgSales";
            this.dgSales.RowHeadersWidth = 51;
            this.dgSales.Size = new System.Drawing.Size(764, 149);
            this.dgSales.TabIndex = 10091;
            // 
            // CodeNo
            // 
            this.CodeNo.HeaderText = "Code No";
            this.CodeNo.MinimumWidth = 6;
            this.CodeNo.Name = "CodeNo";
            // 
            // ItemDrescription
            // 
            this.ItemDrescription.HeaderText = "Item Drescription";
            this.ItemDrescription.MinimumWidth = 6;
            this.ItemDrescription.Name = "ItemDrescription";
            this.ItemDrescription.Width = 170;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ExpireDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "ExpireDate";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 115;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 110;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "BatchNo";
            this.dataGridViewTextBoxColumn9.HeaderText = "BatchNo";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 110;
            // 
            // PTotal
            // 
            this.PTotal.HeaderText = "P. Total";
            this.PTotal.MinimumWidth = 6;
            this.PTotal.Name = "PTotal";
            this.PTotal.Width = 110;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(514, 237);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 17);
            this.label18.TabIndex = 10093;
            this.label18.Text = "Item Description";
            // 
            // txtDrescription
            // 
            this.txtDrescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrescription.Location = new System.Drawing.Point(514, 259);
            this.txtDrescription.Name = "txtDrescription";
            this.txtDrescription.Size = new System.Drawing.Size(374, 29);
            this.txtDrescription.TabIndex = 10097;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(1057, 259);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 29);
            this.txtQuantity.TabIndex = 10099;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(904, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 17);
            this.label19.TabIndex = 10094;
            this.label19.Text = "Unit Price";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(403, 259);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(100, 29);
            this.txtProductCode.TabIndex = 10096;
            this.txtProductCode.Text = " ";
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(902, 259);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(93, 29);
            this.txtUnitPrice.TabIndex = 10098;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(1068, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 17);
            this.label20.TabIndex = 10095;
            this.label20.Text = "Quantity";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(404, 237);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 17);
            this.label21.TabIndex = 10092;
            this.label21.Text = "Product Code";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(1175, 404);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 18);
            this.label22.TabIndex = 10103;
            this.label22.Text = "Total Amount";
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(408, 686);
            this.ctlProductSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(993, 499);
            this.ctlProductSearchControl.TabIndex = 10090;
            this.ctlProductSearchControl.Visible = false;
            // 
            // ctrlService
            // 
            this.ctrlService.Location = new System.Drawing.Point(662, 705);
            this.ctrlService.Name = "ctrlService";
            this.ctrlService.Size = new System.Drawing.Size(559, 440);
            this.ctrlService.TabIndex = 10089;
            this.ctrlService.Visible = false;
            // 
            // ctrlDoctor
            // 
            this.ctrlDoctor.Location = new System.Drawing.Point(476, 710);
            this.ctrlDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDoctor.Name = "ctrlDoctor";
            this.ctrlDoctor.Size = new System.Drawing.Size(603, 613);
            this.ctrlDoctor.TabIndex = 10056;
            this.ctrlDoctor.Visible = false;
            // 
            // ctrlServicetem
            // 
            this.ctrlServicetem.Location = new System.Drawing.Point(991, 710);
            this.ctrlServicetem.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlServicetem.Name = "ctrlServicetem";
            this.ctrlServicetem.Size = new System.Drawing.Size(559, 406);
            this.ctrlServicetem.TabIndex = 10055;
            this.ctrlServicetem.Visible = false;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(-1175, 330);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(115, 25);
            this.cmbOutlet.TabIndex = 10105;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(1175, 425);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(118, 27);
            this.txtSubTotal.TabIndex = 10102;
            // 
            // crtlOPDProcedureBillDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.ctrlService);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.txtServiceRate);
            this.Controls.Add(this.txtServiceQty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtpServiceDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgNormalService);
            this.Controls.Add(this.lbldis);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBillNo);
            this.Controls.Add(this.ctrlDoctor);
            this.Controls.Add(this.ctrlServicetem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalBill);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtServiceItem);
            this.Controls.Add(this.dgService);
            this.Controls.Add(this.btnBillSave);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblStockAvailable);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dgSales);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDrescription);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Name = "crtlOPDProcedureBillDistribution";
            this.Size = new System.Drawing.Size(1520, 719);
            this.Load += new System.EventHandler(this.crtlOPDProcedureBillDistribution_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNormalService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Controls.DoctorSearchControl ctrlDoctor;
        private Controls.HospitalBillItemSearchControl ctrlServicetem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtServiceItem;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgProcBills;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Button btnBillSave;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label lbldis;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.TextBox txtServiceRate;
        private System.Windows.Forms.TextBox txtServiceQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgNormalService;
        private Controls.HospitalBillItemSearchControl ctrlService;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Controls.PhProductSaleSearchControl ctlProductSearchControl;
        private System.Windows.Forms.Label lblStockAvailable;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgSales;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDrescription;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDrescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTotal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.TextBox txtSubTotal;
    }
}
