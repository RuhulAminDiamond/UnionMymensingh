namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlHpRoughBilling
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
            this.components = new System.ComponentModel.Container();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLedger = new System.Windows.Forms.DataGridView();
            this.SrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBillSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGtotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.dtpDischarge = new System.Windows.Forms.DateTimePicker();
            this.lblCabin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRoughBill = new System.Windows.Forms.Button();
            this.btnDueCollection = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAdvancePaid = new System.Windows.Forms.TextBox();
            this.btnMoneyReceipt = new System.Windows.Forms.Button();
            this.btnCCNote = new System.Windows.Forms.PictureBox();
            this.txtAdvanceReturn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAdvReturn = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.txtCardOrMobileReceiveTk = new System.Windows.Forms.TextBox();
            this.cmbPaymentTerminal = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.txtAdmissionFee = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCCNote)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPatient
            // 
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatient.Location = new System.Drawing.Point(3, 57);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.RowHeadersWidth = 51;
            this.dgPatient.Size = new System.Drawing.Size(484, 667);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cabin No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Patinet Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // dgLedger
            // 
            this.dgLedger.AllowUserToAddRows = false;
            this.dgLedger.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrlNo,
            this.ServiceName,
            this.Qty,
            this.Rate,
            this.Total});
            this.dgLedger.Location = new System.Drawing.Point(496, 33);
            this.dgLedger.MultiSelect = false;
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.RowHeadersWidth = 51;
            this.dgLedger.Size = new System.Drawing.Size(684, 286);
            this.dgLedger.TabIndex = 3;
            this.dgLedger.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLedger_RowHeaderMouseClick);
            // 
            // SrlNo
            // 
            this.SrlNo.HeaderText = "SrlNo";
            this.SrlNo.MinimumWidth = 6;
            this.SrlNo.Name = "SrlNo";
            this.SrlNo.Width = 125;
            // 
            // ServiceName
            // 
            this.ServiceName.HeaderText = "Service Name";
            this.ServiceName.MinimumWidth = 6;
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Width = 250;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.Width = 125;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.Width = 125;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Enabled = false;
            this.txtTotalBill.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(700, 345);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(130, 31);
            this.txtTotalBill.TabIndex = 5;
            this.txtTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalBill.TextChanged += new System.EventHandler(this.txtTotalBill_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(617, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Bill :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBillSave
            // 
            this.btnBillSave.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillSave.ForeColor = System.Drawing.Color.Red;
            this.btnBillSave.Location = new System.Drawing.Point(-200, 401);
            this.btnBillSave.Name = "btnBillSave";
            this.btnBillSave.Size = new System.Drawing.Size(131, 39);
            this.btnBillSave.TabIndex = 7;
            this.btnBillSave.Text = "DISCHARGE";
            this.btnBillSave.UseVisualStyleBackColor = true;
            this.btnBillSave.Click += new System.EventHandler(this.btnBillSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(566, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Service Charge :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Enabled = false;
            this.txtServiceCharge.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceCharge.Location = new System.Drawing.Point(700, 380);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Size = new System.Drawing.Size(131, 31);
            this.txtServiceCharge.TabIndex = 8;
            this.txtServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceCharge.TextChanged += new System.EventHandler(this.txtServiceCharge_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(592, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Grand Total :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGtotal
            // 
            this.txtGtotal.Enabled = false;
            this.txtGtotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGtotal.Location = new System.Drawing.Point(701, 484);
            this.txtGtotal.Name = "txtGtotal";
            this.txtGtotal.Size = new System.Drawing.Size(130, 31);
            this.txtGtotal.TabIndex = 10;
            this.txtGtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGtotal.TextChanged += new System.EventHandler(this.txtGtotal_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(611, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Discount :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(700, 415);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(131, 31);
            this.txtDiscount.TabIndex = 12;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(583, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Due Amount :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtPaid.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPaid.Location = new System.Drawing.Point(1033, 519);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(150, 37);
            this.txtPaid.TabIndex = 16;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(905, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Adv. Payment :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDue
            // 
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.Location = new System.Drawing.Point(700, 555);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(131, 31);
            this.txtDue.TabIndex = 14;
            this.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(698, 589);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(484, 39);
            this.txtRemarks.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(610, 590);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Remarks :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1185, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 20);
            this.label11.TabIndex = 82;
            this.label11.Text = "Billing Date_Time";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTime.Location = new System.Drawing.Point(1189, 72);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(122, 29);
            this.txtTime.TabIndex = 81;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDischarge
            // 
            this.dtpDischarge.CustomFormat = "dd-MM-yyyy";
            this.dtpDischarge.Enabled = false;
            this.dtpDischarge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDischarge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDischarge.Location = new System.Drawing.Point(1189, 37);
            this.dtpDischarge.Name = "dtpDischarge";
            this.dtpDischarge.Size = new System.Drawing.Size(122, 29);
            this.dtpDischarge.TabIndex = 80;
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(952, 9);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10035;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(896, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 10034;
            this.label8.Text = "Cabin :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(492, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 10033;
            this.label9.Text = "Name :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(551, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10032;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRoughBill
            // 
            this.btnRoughBill.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoughBill.Location = new System.Drawing.Point(942, 633);
            this.btnRoughBill.Name = "btnRoughBill";
            this.btnRoughBill.Size = new System.Drawing.Size(126, 39);
            this.btnRoughBill.TabIndex = 10036;
            this.btnRoughBill.Text = "ROUGH BILL";
            this.btnRoughBill.UseVisualStyleBackColor = true;
            this.btnRoughBill.Click += new System.EventHandler(this.btnRoughBill_Click);
            // 
            // btnDueCollection
            // 
            this.btnDueCollection.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDueCollection.Location = new System.Drawing.Point(621, 633);
            this.btnDueCollection.Name = "btnDueCollection";
            this.btnDueCollection.Size = new System.Drawing.Size(129, 39);
            this.btnDueCollection.TabIndex = 10037;
            this.btnDueCollection.Text = "DUE COLL.";
            this.btnDueCollection.UseVisualStyleBackColor = true;
            this.btnDueCollection.Click += new System.EventHandler(this.btnDueCollection_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 727);
            this.panel1.TabIndex = 10038;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgPatient, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchByCabin, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.484407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.51559F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 727);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(109, 14);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(272, 25);
            this.txtSearchByCabin.TabIndex = 1;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(577, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 23);
            this.label10.TabIndex = 10040;
            this.label10.Text = "Advance Paid :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdvancePaid
            // 
            this.txtAdvancePaid.Enabled = false;
            this.txtAdvancePaid.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvancePaid.Location = new System.Drawing.Point(701, 520);
            this.txtAdvancePaid.Name = "txtAdvancePaid";
            this.txtAdvancePaid.Size = new System.Drawing.Size(130, 31);
            this.txtAdvancePaid.TabIndex = 10039;
            this.txtAdvancePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdvancePaid.TextChanged += new System.EventHandler(this.txtAdvancePaid_TextChanged);
            // 
            // btnMoneyReceipt
            // 
            this.btnMoneyReceipt.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoneyReceipt.Location = new System.Drawing.Point(1074, 633);
            this.btnMoneyReceipt.Name = "btnMoneyReceipt";
            this.btnMoneyReceipt.Size = new System.Drawing.Size(108, 39);
            this.btnMoneyReceipt.TabIndex = 10041;
            this.btnMoneyReceipt.Text = "Advance";
            this.btnMoneyReceipt.UseVisualStyleBackColor = true;
            this.btnMoneyReceipt.Click += new System.EventHandler(this.btnMoneyReceipt_Click);
            // 
            // btnCCNote
            // 
            this.btnCCNote.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.note2;
            this.btnCCNote.Location = new System.Drawing.Point(1189, 118);
            this.btnCCNote.Name = "btnCCNote";
            this.btnCCNote.Size = new System.Drawing.Size(77, 75);
            this.btnCCNote.TabIndex = 10042;
            this.btnCCNote.TabStop = false;
            this.btnCCNote.Click += new System.EventHandler(this.btnCCNote_Click);
            // 
            // txtAdvanceReturn
            // 
            this.txtAdvanceReturn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvanceReturn.Location = new System.Drawing.Point(1033, 483);
            this.txtAdvanceReturn.Name = "txtAdvanceReturn";
            this.txtAdvanceReturn.Size = new System.Drawing.Size(150, 31);
            this.txtAdvanceReturn.TabIndex = 10051;
            this.txtAdvanceReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdvanceReturn.TextChanged += new System.EventHandler(this.txtAdvanceReturn_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(921, 484);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 23);
            this.label12.TabIndex = 10050;
            this.label12.Text = "Adv. Return :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdvReturn
            // 
            this.btnAdvReturn.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvReturn.Location = new System.Drawing.Point(756, 633);
            this.btnAdvReturn.Name = "btnAdvReturn";
            this.btnAdvReturn.Size = new System.Drawing.Size(180, 39);
            this.btnAdvReturn.TabIndex = 10052;
            this.btnAdvReturn.Text = "Advance Ret.";
            this.btnAdvReturn.UseVisualStyleBackColor = true;
            this.btnAdvReturn.Click += new System.EventHandler(this.btnAdvReturn_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(851, 401);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(179, 23);
            this.label31.TabIndex = 11246;
            this.label31.Text = "Card/Mob. Payment :";
            // 
            // txtCardOrMobileReceiveTk
            // 
            this.txtCardOrMobileReceiveTk.BackColor = System.Drawing.Color.MistyRose;
            this.txtCardOrMobileReceiveTk.Enabled = false;
            this.txtCardOrMobileReceiveTk.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileReceiveTk.Location = new System.Drawing.Point(1033, 401);
            this.txtCardOrMobileReceiveTk.Name = "txtCardOrMobileReceiveTk";
            this.txtCardOrMobileReceiveTk.Size = new System.Drawing.Size(147, 37);
            this.txtCardOrMobileReceiveTk.TabIndex = 11245;
            this.txtCardOrMobileReceiveTk.TextChanged += new System.EventHandler(this.cashRecByCardOrMob);
            // 
            // cmbPaymentTerminal
            // 
            this.cmbPaymentTerminal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentTerminal.FormattingEnabled = true;
            this.cmbPaymentTerminal.Location = new System.Drawing.Point(1033, 363);
            this.cmbPaymentTerminal.Name = "cmbPaymentTerminal";
            this.cmbPaymentTerminal.Size = new System.Drawing.Size(147, 31);
            this.cmbPaymentTerminal.TabIndex = 11244;
            this.cmbPaymentTerminal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbKeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(877, 366);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(156, 23);
            this.label23.TabIndex = 11243;
            this.label23.Text = "Payment Terminal :";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(1033, 326);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(147, 31);
            this.cmbPaymentMode.TabIndex = 11242;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(894, 329);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 23);
            this.label16.TabIndex = 11241;
            this.label16.Text = "Payment Mode :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(892, 444);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(135, 23);
            this.label30.TabIndex = 11248;
            this.label30.Text = "Transaction No :";
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Enabled = false;
            this.txtTransactionNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNo.Location = new System.Drawing.Point(1033, 444);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(147, 31);
            this.txtTransactionNo.TabIndex = 11247;
            // 
            // txtAdmissionFee
            // 
            this.txtAdmissionFee.Enabled = false;
            this.txtAdmissionFee.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdmissionFee.Location = new System.Drawing.Point(701, 450);
            this.txtAdmissionFee.Name = "txtAdmissionFee";
            this.txtAdmissionFee.Size = new System.Drawing.Size(130, 31);
            this.txtAdmissionFee.TabIndex = 11249;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(565, 453);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 23);
            this.label13.TabIndex = 11250;
            this.label13.Text = "Admission Fee :";
            // 
            // ctrlHpRoughBilling
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.txtAdmissionFee);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtCardOrMobileReceiveTk);
            this.Controls.Add(this.cmbPaymentTerminal);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnAdvReturn);
            this.Controls.Add(this.txtAdvanceReturn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCCNote);
            this.Controls.Add(this.btnMoneyReceipt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAdvancePaid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDueCollection);
            this.Controls.Add(this.btnRoughBill);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dtpDischarge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGtotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServiceCharge);
            this.Controls.Add(this.btnBillSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalBill);
            this.Controls.Add(this.dgLedger);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlHpRoughBilling";
            this.Size = new System.Drawing.Size(1480, 727);
            this.Load += new System.EventHandler(this.ctrlMR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCCNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBillSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGtotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DateTimePicker dtpDischarge;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRoughBill;
        private System.Windows.Forms.Button btnDueCollection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAdvancePaid;
        private System.Windows.Forms.Button btnMoneyReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.PictureBox btnCCNote;
        private System.Windows.Forms.TextBox txtAdvanceReturn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAdvReturn;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtCardOrMobileReceiveTk;
        private System.Windows.Forms.ComboBox cmbPaymentTerminal;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.TextBox txtAdmissionFee;
        private System.Windows.Forms.Label label13;
    }
}
