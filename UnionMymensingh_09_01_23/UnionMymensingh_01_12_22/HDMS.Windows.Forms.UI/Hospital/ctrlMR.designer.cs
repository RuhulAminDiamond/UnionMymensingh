namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlMR
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtAdvancePaid = new System.Windows.Forms.TextBox();
            this.btnMoneyReceipt = new System.Windows.Forms.Button();
            this.btnCCNote = new System.Windows.Forms.PictureBox();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.txtSearchByRefdDoc = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByAssignDoc = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtAdmId = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.btnMinView = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefdDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMaxView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtCardOrMobileReceiveTk = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.cmbPaymentChannel = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRounding = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAdmissionFee = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCCNote)).BeginInit();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
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
            this.dgLedger.Location = new System.Drawing.Point(8, 116);
            this.dgLedger.MultiSelect = false;
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.RowHeadersWidth = 51;
            this.dgLedger.Size = new System.Drawing.Size(475, 500);
            this.dgLedger.TabIndex = 3;
            this.dgLedger.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgLedger_RowHeaderMouseClick);
            // 
            // SrlNo
            // 
            this.SrlNo.HeaderText = "SrlNo";
            this.SrlNo.MinimumWidth = 6;
            this.SrlNo.Name = "SrlNo";
            this.SrlNo.Width = 60;
            // 
            // ServiceName
            // 
            this.ServiceName.HeaderText = "Service Name";
            this.ServiceName.MinimumWidth = 6;
            this.ServiceName.Name = "ServiceName";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.Width = 60;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Enabled = false;
            this.txtTotalBill.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(619, 120);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(141, 31);
            this.txtTotalBill.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(538, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Bill :";
            // 
            // btnBillSave
            // 
            this.btnBillSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillSave.ForeColor = System.Drawing.Color.Red;
            this.btnBillSave.Location = new System.Drawing.Point(938, 503);
            this.btnBillSave.Name = "btnBillSave";
            this.btnBillSave.Size = new System.Drawing.Size(159, 52);
            this.btnBillSave.TabIndex = 7;
            this.btnBillSave.Text = "DISCHARGE";
            this.btnBillSave.UseVisualStyleBackColor = true;
            this.btnBillSave.Click += new System.EventHandler(this.btnBillSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(487, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Service Charge :";
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Enabled = false;
            this.txtServiceCharge.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceCharge.Location = new System.Drawing.Point(619, 157);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Size = new System.Drawing.Size(141, 31);
            this.txtServiceCharge.TabIndex = 8;
            this.txtServiceCharge.TextChanged += new System.EventHandler(this.txtServiceCharge_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Grand Total :";
            // 
            // txtGtotal
            // 
            this.txtGtotal.Enabled = false;
            this.txtGtotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGtotal.Location = new System.Drawing.Point(619, 320);
            this.txtGtotal.Name = "txtGtotal";
            this.txtGtotal.Size = new System.Drawing.Size(143, 31);
            this.txtGtotal.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(529, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Discount :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.MistyRose;
            this.txtDiscount.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(619, 231);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(141, 37);
            this.txtDiscount.TabIndex = 12;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(498, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Due Amount :";
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtPaid.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(952, 354);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(147, 47);
            this.txtPaid.TabIndex = 16;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(819, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cash Payment :";
            // 
            // txtDue
            // 
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.Location = new System.Drawing.Point(617, 404);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(143, 31);
            this.txtDue.TabIndex = 14;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Info;
            this.txtRemarks.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(619, 443);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(480, 47);
            this.txtRemarks.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(533, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Remarks :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 48);
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
            this.txtTime.Location = new System.Drawing.Point(262, 48);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(159, 29);
            this.txtTime.TabIndex = 81;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDischarge
            // 
            this.dtpDischarge.CustomFormat = "dd-MM-yyyy";
            this.dtpDischarge.Enabled = false;
            this.dtpDischarge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDischarge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDischarge.Location = new System.Drawing.Point(149, 48);
            this.dtpDischarge.Name = "dtpDischarge";
            this.dtpDischarge.Size = new System.Drawing.Size(107, 29);
            this.dtpDischarge.TabIndex = 80;
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(413, 92);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10035;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(357, 92);
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
            this.label9.Location = new System.Drawing.Point(13, 90);
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
            this.lblName.Location = new System.Drawing.Point(72, 90);
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
            this.btnRoughBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoughBill.Location = new System.Drawing.Point(-200, 401);
            this.btnRoughBill.Name = "btnRoughBill";
            this.btnRoughBill.Size = new System.Drawing.Size(126, 39);
            this.btnRoughBill.TabIndex = 10036;
            this.btnRoughBill.Text = "ROUGH BILL";
            this.btnRoughBill.UseVisualStyleBackColor = true;
            this.btnRoughBill.Click += new System.EventHandler(this.btnRoughBill_Click);
            // 
            // btnDueCollection
            // 
            this.btnDueCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDueCollection.Location = new System.Drawing.Point(617, 503);
            this.btnDueCollection.Name = "btnDueCollection";
            this.btnDueCollection.Size = new System.Drawing.Size(143, 52);
            this.btnDueCollection.TabIndex = 10037;
            this.btnDueCollection.Text = "DUE COLL.";
            this.btnDueCollection.UseVisualStyleBackColor = true;
            this.btnDueCollection.Click += new System.EventHandler(this.btnDueCollection_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(497, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 23);
            this.label10.TabIndex = 10040;
            this.label10.Text = "Advance Paid :";
            // 
            // txtAdvancePaid
            // 
            this.txtAdvancePaid.Enabled = false;
            this.txtAdvancePaid.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvancePaid.Location = new System.Drawing.Point(619, 363);
            this.txtAdvancePaid.Name = "txtAdvancePaid";
            this.txtAdvancePaid.Size = new System.Drawing.Size(143, 31);
            this.txtAdvancePaid.TabIndex = 10039;
            // 
            // btnMoneyReceipt
            // 
            this.btnMoneyReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoneyReceipt.Location = new System.Drawing.Point(-200, 401);
            this.btnMoneyReceipt.Name = "btnMoneyReceipt";
            this.btnMoneyReceipt.Size = new System.Drawing.Size(104, 39);
            this.btnMoneyReceipt.TabIndex = 10041;
            this.btnMoneyReceipt.Text = "Advance";
            this.btnMoneyReceipt.UseVisualStyleBackColor = true;
            this.btnMoneyReceipt.Click += new System.EventHandler(this.btnMoneyReceipt_Click);
            // 
            // btnCCNote
            // 
            this.btnCCNote.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.note2;
            this.btnCCNote.Location = new System.Drawing.Point(545, 0);
            this.btnCCNote.Name = "btnCCNote";
            this.btnCCNote.Size = new System.Drawing.Size(77, 75);
            this.btnCCNote.TabIndex = 10042;
            this.btnCCNote.TabStop = false;
            this.btnCCNote.Click += new System.EventHandler(this.btnCCNote_Click);
            // 
            // pnlPatient
            // 
            this.pnlPatient.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlPatient.Controls.Add(this.txtSearchByRefdDoc);
            this.pnlPatient.Controls.Add(this.txtSearchByAssignDoc);
            this.pnlPatient.Controls.Add(this.txtName);
            this.pnlPatient.Controls.Add(this.txtSearchByCabin);
            this.pnlPatient.Controls.Add(this.txtAdmId);
            this.pnlPatient.Controls.Add(this.btnMinView);
            this.pnlPatient.Controls.Add(this.label26);
            this.pnlPatient.Controls.Add(this.lblTotalPatient);
            this.pnlPatient.Controls.Add(this.dgPatient);
            this.pnlPatient.Controls.Add(this.btnMaxView);
            this.pnlPatient.Controls.Add(this.btnRefresh);
            this.pnlPatient.Controls.Add(this.cmbDept);
            this.pnlPatient.Controls.Add(this.label25);
            this.pnlPatient.Location = new System.Drawing.Point(62, 45);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(1333, 353);
            this.pnlPatient.TabIndex = 10043;
            this.pnlPatient.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPatient_Paint);
            // 
            // txtSearchByRefdDoc
            // 
            this.txtSearchByRefdDoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByRefdDoc.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByRefdDoc.Location = new System.Drawing.Point(801, 61);
            this.txtSearchByRefdDoc.Name = "txtSearchByRefdDoc";
            this.txtSearchByRefdDoc.PlaceHolderText = "Search by Refd. Doc";
            this.txtSearchByRefdDoc.Size = new System.Drawing.Size(245, 23);
            this.txtSearchByRefdDoc.TabIndex = 10036;
            this.txtSearchByRefdDoc.Text = "Search by Refd. Doc";
            this.txtSearchByRefdDoc.TextChanged += new System.EventHandler(this.txtSearchByRefdDoc_TextChanged);
            // 
            // txtSearchByAssignDoc
            // 
            this.txtSearchByAssignDoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByAssignDoc.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByAssignDoc.Location = new System.Drawing.Point(545, 61);
            this.txtSearchByAssignDoc.Name = "txtSearchByAssignDoc";
            this.txtSearchByAssignDoc.PlaceHolderText = "Search by Assign Doc";
            this.txtSearchByAssignDoc.Size = new System.Drawing.Size(239, 23);
            this.txtSearchByAssignDoc.TabIndex = 10033;
            this.txtSearchByAssignDoc.Text = "Search by Assign Doc";
            this.txtSearchByAssignDoc.TextChanged += new System.EventHandler(this.txtSearchByAssignDoc_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Location = new System.Drawing.Point(149, 61);
            this.txtName.Name = "txtName";
            this.txtName.PlaceHolderText = "Search by name";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 10030;
            this.txtName.Text = "Search by name";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(367, 61);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(144, 23);
            this.txtSearchByCabin.TabIndex = 10031;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // txtAdmId
            // 
            this.txtAdmId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtAdmId.ForeColor = System.Drawing.Color.Gray;
            this.txtAdmId.Location = new System.Drawing.Point(20, 61);
            this.txtAdmId.Name = "txtAdmId";
            this.txtAdmId.PlaceHolderText = "By Bill No";
            this.txtAdmId.Size = new System.Drawing.Size(123, 23);
            this.txtAdmId.TabIndex = 10032;
            this.txtAdmId.Text = "By Bill No";
            this.txtAdmId.TextChanged += new System.EventHandler(this.txtAdmId_TextChanged);
            // 
            // btnMinView
            // 
            this.btnMinView.Location = new System.Drawing.Point(860, 15);
            this.btnMinView.Name = "btnMinView";
            this.btnMinView.Size = new System.Drawing.Size(96, 31);
            this.btnMinView.TabIndex = 10026;
            this.btnMinView.Text = ">> >> >>--->";
            this.btnMinView.UseVisualStyleBackColor = true;
            this.btnMinView.Click += new System.EventHandler(this.btnMinView_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(17, 601);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 18);
            this.label26.TabIndex = 10025;
            this.label26.Text = "Total Patient : ";
            // 
            // lblTotalPatient
            // 
            this.lblTotalPatient.AutoSize = true;
            this.lblTotalPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatient.Location = new System.Drawing.Point(124, 601);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPatient.TabIndex = 10024;
            // 
            // dgPatient
            // 
            this.dgPatient.AllowUserToAddRows = false;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.dataGridViewTextBoxColumn2,
            this.Time,
            this.Column5,
            this.Column6,
            this.Phone,
            this.Address,
            this.AssignedDoctor,
            this.RefdDoctor});
            this.dgPatient.Location = new System.Drawing.Point(17, 96);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.RowHeadersWidth = 51;
            this.dgPatient.Size = new System.Drawing.Size(1313, 502);
            this.dgPatient.TabIndex = 10023;
            this.dgPatient.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Adm. Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Name";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 220;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Adm. Date";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "AdmTime";
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 110;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Bed/Cabin";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "W.D.O(Date)";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "W.D.O(Time)";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.Width = 120;
            // 
            // Address
            // 
            this.Address.HeaderText = "Confirmed By";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 150;
            // 
            // AssignedDoctor
            // 
            this.AssignedDoctor.HeaderText = "Assigned Doctor";
            this.AssignedDoctor.MinimumWidth = 6;
            this.AssignedDoctor.Name = "AssignedDoctor";
            this.AssignedDoctor.Width = 250;
            // 
            // RefdDoctor
            // 
            this.RefdDoctor.HeaderText = "Refd. Doctor";
            this.RefdDoctor.MinimumWidth = 6;
            this.RefdDoctor.Name = "RefdDoctor";
            this.RefdDoctor.Width = 250;
            // 
            // btnMaxView
            // 
            this.btnMaxView.Location = new System.Drawing.Point(17, 17);
            this.btnMaxView.Name = "btnMaxView";
            this.btnMaxView.Size = new System.Drawing.Size(96, 31);
            this.btnMaxView.TabIndex = 10021;
            this.btnMaxView.Text = "<---<< << <<";
            this.btnMaxView.UseVisualStyleBackColor = true;
            this.btnMaxView.Click += new System.EventHandler(this.btnMaxView_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(683, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 31);
            this.btnRefresh.TabIndex = 10022;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_clicked);
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(440, 20);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(237, 26);
            this.cmbDept.TabIndex = 10021;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(259, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(130, 18);
            this.label25.TabIndex = 10020;
            this.label25.Text = "Select Department";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(768, 262);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(179, 23);
            this.label31.TabIndex = 11240;
            this.label31.Text = "Card/Mob. Payment :";
            // 
            // txtCardOrMobileReceiveTk
            // 
            this.txtCardOrMobileReceiveTk.BackColor = System.Drawing.Color.MistyRose;
            this.txtCardOrMobileReceiveTk.Enabled = false;
            this.txtCardOrMobileReceiveTk.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileReceiveTk.Location = new System.Drawing.Point(952, 262);
            this.txtCardOrMobileReceiveTk.Name = "txtCardOrMobileReceiveTk";
            this.txtCardOrMobileReceiveTk.Size = new System.Drawing.Size(147, 47);
            this.txtCardOrMobileReceiveTk.TabIndex = 11239;
            this.txtCardOrMobileReceiveTk.TextChanged += new System.EventHandler(this.txtCardOrMobileReceiveTk_TextChanged);
            this.txtCardOrMobileReceiveTk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardOrMobileReceiveTk_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(814, 311);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(135, 23);
            this.label30.TabIndex = 11238;
            this.label30.Text = "Transaction No :";
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Enabled = false;
            this.txtTransactionNo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNo.Location = new System.Drawing.Point(952, 311);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(147, 37);
            this.txtTransactionNo.TabIndex = 11237;
            // 
            // cmbPaymentChannel
            // 
            this.cmbPaymentChannel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentChannel.FormattingEnabled = true;
            this.cmbPaymentChannel.Location = new System.Drawing.Point(952, 215);
            this.cmbPaymentChannel.Name = "cmbPaymentChannel";
            this.cmbPaymentChannel.Size = new System.Drawing.Size(147, 37);
            this.cmbPaymentChannel.TabIndex = 11236;
            this.cmbPaymentChannel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentChannel_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(793, 218);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(156, 23);
            this.label23.TabIndex = 11235;
            this.label23.Text = "Payment Terminal :";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(952, 172);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(147, 37);
            this.cmbPaymentMode.TabIndex = 11234;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(813, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 23);
            this.label16.TabIndex = 11233;
            this.label16.Text = "Payment Mode :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(486, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 23);
            this.label12.TabIndex = 11244;
            this.label12.Text = "Rounding (+/-) :";
            // 
            // txtRounding
            // 
            this.txtRounding.BackColor = System.Drawing.Color.MistyRose;
            this.txtRounding.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRounding.Location = new System.Drawing.Point(619, 276);
            this.txtRounding.Name = "txtRounding";
            this.txtRounding.Size = new System.Drawing.Size(141, 37);
            this.txtRounding.TabIndex = 11243;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(483, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 23);
            this.label13.TabIndex = 11246;
            this.label13.Text = "Admission Fee :";
            // 
            // txtAdmissionFee
            // 
            this.txtAdmissionFee.Enabled = false;
            this.txtAdmissionFee.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdmissionFee.Location = new System.Drawing.Point(619, 193);
            this.txtAdmissionFee.Name = "txtAdmissionFee";
            this.txtAdmissionFee.Size = new System.Drawing.Size(143, 31);
            this.txtAdmissionFee.TabIndex = 11245;
            // 
            // ctrlMR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRounding);
            this.Controls.Add(this.txtCardOrMobileReceiveTk);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.cmbPaymentChannel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnCCNote);
            this.Controls.Add(this.btnMoneyReceipt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAdvancePaid);
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
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtAdmissionFee);
            this.Controls.Add(this.label13);
            this.Name = "ctrlMR";
            this.Size = new System.Drawing.Size(1641, 677);
            this.Load += new System.EventHandler(this.ctrlMR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCCNote)).EndInit();
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBillSave;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAdvancePaid;
        private System.Windows.Forms.Button btnMoneyReceipt;
        private System.Windows.Forms.PictureBox btnCCNote;
        private System.Windows.Forms.Panel pnlPatient;
        private Controls.PlaceHolderTextBox txtSearchByAssignDoc;
        private Controls.PlaceHolderTextBox txtName;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private Controls.PlaceHolderTextBox txtAdmId;
        private System.Windows.Forms.Button btnMinView;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.Button btnMaxView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtCardOrMobileReceiveTk;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.ComboBox cmbPaymentChannel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRounding;
        private Controls.PlaceHolderTextBox txtSearchByRefdDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefdDoctor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAdmissionFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}
