
namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmHpDayWiseDueCollection
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
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.txtPrevDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdPrintReceipt = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.gvLedger = new System.Windows.Forms.DataGridView();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLedger = new System.Windows.Forms.DataGridView();
            this.SrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnResetTransations = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtCardOrMobileReceiveTk = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.cmbPaymentChannel = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtHBillNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrevPaid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Enabled = false;
            this.txtServiceCharge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtServiceCharge.Location = new System.Drawing.Point(124, 54);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Size = new System.Drawing.Size(134, 29);
            this.txtServiceCharge.TabIndex = 103;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 104;
            this.label11.Text = "Service Charge";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Enabled = false;
            this.txtTotalBill.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTotalBill.Location = new System.Drawing.Point(124, 19);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(134, 29);
            this.txtTotalBill.TabIndex = 97;
            // 
            // txtPrevDiscount
            // 
            this.txtPrevDiscount.Enabled = false;
            this.txtPrevDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrevDiscount.Location = new System.Drawing.Point(352, 23);
            this.txtPrevDiscount.Name = "txtPrevDiscount";
            this.txtPrevDiscount.Size = new System.Drawing.Size(134, 29);
            this.txtPrevDiscount.TabIndex = 101;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(411, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 121;
            this.label10.Text = "Entry Date";
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(493, 23);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(125, 27);
            this.dtpEntry.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 119;
            this.label6.Text = "Service List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "Transaction History";
            // 
            // cmdPrintReceipt
            // 
            this.cmdPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintReceipt.Location = new System.Drawing.Point(873, 556);
            this.cmdPrintReceipt.Name = "cmdPrintReceipt";
            this.cmdPrintReceipt.Size = new System.Drawing.Size(113, 43);
            this.cmdPrintReceipt.TabIndex = 117;
            this.cmdPrintReceipt.Text = "Print";
            this.cmdPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(1148, 556);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(134, 43);
            this.cmdSave.TabIndex = 116;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // gvLedger
            // 
            this.gvLedger.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.gvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranDate,
            this.Particulars,
            this.Debit,
            this.Credit,
            this.Balance,
            this.Column3});
            this.gvLedger.Location = new System.Drawing.Point(14, 355);
            this.gvLedger.Name = "gvLedger";
            this.gvLedger.RowHeadersWidth = 51;
            this.gvLedger.Size = new System.Drawing.Size(745, 268);
            this.gvLedger.TabIndex = 115;
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "TranDate";
            this.TranDate.HeaderText = "Date";
            this.TranDate.MinimumWidth = 6;
            this.TranDate.Name = "TranDate";
            this.TranDate.Width = 125;
            // 
            // Particulars
            // 
            this.Particulars.DataPropertyName = "Particulars";
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.MinimumWidth = 6;
            this.Particulars.Name = "Particulars";
            this.Particulars.Width = 200;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            this.Debit.HeaderText = "Debit";
            this.Debit.MinimumWidth = 6;
            this.Debit.Name = "Debit";
            this.Debit.Width = 125;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
            this.Credit.HeaderText = "Credit";
            this.Credit.MinimumWidth = 6;
            this.Credit.Name = "Credit";
            this.Credit.Width = 125;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.MinimumWidth = 6;
            this.Balance.Name = "Balance";
            this.Balance.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OperateBy";
            this.Column3.HeaderText = "UserName";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
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
            this.dgLedger.Location = new System.Drawing.Point(15, 79);
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.RowHeadersWidth = 51;
            this.dgLedger.Size = new System.Drawing.Size(744, 248);
            this.dgLedger.TabIndex = 126;
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
            this.ServiceName.Width = 300;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 114;
            this.label1.Text = "Bill No";
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.SystemColors.Window;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtDue.Location = new System.Drawing.Point(352, 93);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(134, 35);
            this.txtDue.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 96;
            this.label2.Text = "Due";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(998, 556);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 43);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnResetTransations
            // 
            this.btnResetTransations.Enabled = false;
            this.btnResetTransations.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetTransations.Location = new System.Drawing.Point(783, 161);
            this.btnResetTransations.Name = "btnResetTransations";
            this.btnResetTransations.Size = new System.Drawing.Size(219, 36);
            this.btnResetTransations.TabIndex = 124;
            this.btnResetTransations.Text = "Reset Transactions";
            this.btnResetTransations.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtCardOrMobileReceiveTk);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtTransactionNo);
            this.groupBox2.Controls.Add(this.cmbPaymentChannel);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.cmbPaymentMode);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPaid);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Location = new System.Drawing.Point(783, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 347);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Transaction";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(161, 145);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(179, 23);
            this.label31.TabIndex = 11252;
            this.label31.Text = "Card/Mob. Payment :";
            // 
            // txtCardOrMobileReceiveTk
            // 
            this.txtCardOrMobileReceiveTk.BackColor = System.Drawing.Color.MistyRose;
            this.txtCardOrMobileReceiveTk.Enabled = false;
            this.txtCardOrMobileReceiveTk.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileReceiveTk.Location = new System.Drawing.Point(343, 145);
            this.txtCardOrMobileReceiveTk.Name = "txtCardOrMobileReceiveTk";
            this.txtCardOrMobileReceiveTk.Size = new System.Drawing.Size(147, 37);
            this.txtCardOrMobileReceiveTk.TabIndex = 11251;
            this.txtCardOrMobileReceiveTk.TextChanged += new System.EventHandler(this.txtCardOrMobileReceiveTk_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(202, 191);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(135, 23);
            this.label30.TabIndex = 11250;
            this.label30.Text = "Transaction No :";
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Enabled = false;
            this.txtTransactionNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNo.Location = new System.Drawing.Point(343, 188);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(147, 31);
            this.txtTransactionNo.TabIndex = 11249;
            // 
            // cmbPaymentChannel
            // 
            this.cmbPaymentChannel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentChannel.FormattingEnabled = true;
            this.cmbPaymentChannel.Location = new System.Drawing.Point(343, 42);
            this.cmbPaymentChannel.Name = "cmbPaymentChannel";
            this.cmbPaymentChannel.Size = new System.Drawing.Size(147, 34);
            this.cmbPaymentChannel.TabIndex = 11248;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(186, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(151, 23);
            this.label23.TabIndex = 11247;
            this.label23.Text = "Payment Terminal ";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(13, 55);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(147, 31);
            this.cmbPaymentMode.TabIndex = 11246;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(9, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 23);
            this.label16.TabIndex = 11245;
            this.label16.Text = "Payment Mode ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(205, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 23);
            this.label13.TabIndex = 11243;
            this.label13.Text = "Cash Payment :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 279);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 23);
            this.label12.TabIndex = 19;
            this.label12.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Discount Tk.";
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtPaid.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(343, 225);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(147, 37);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Info;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(112, 279);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(387, 48);
            this.txtRemarks.TabIndex = 18;
            this.txtRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.MistyRose;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(343, 92);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(147, 37);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // txtHBillNo
            // 
            this.txtHBillNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHBillNo.Location = new System.Drawing.Point(104, 21);
            this.txtHBillNo.Name = "txtHBillNo";
            this.txtHBillNo.Size = new System.Drawing.Size(222, 27);
            this.txtHBillNo.TabIndex = 113;
            this.txtHBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHBillNo_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServiceCharge);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTotalBill);
            this.groupBox1.Controls.Add(this.txtDue);
            this.groupBox1.Controls.Add(this.txtPrevDiscount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPrevPaid);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(783, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 142);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous Transactions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(277, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 102;
            this.label8.Text = "Discount";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Total Bill";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevPaid
            // 
            this.txtPrevPaid.Enabled = false;
            this.txtPrevPaid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrevPaid.Location = new System.Drawing.Point(352, 58);
            this.txtPrevPaid.Name = "txtPrevPaid";
            this.txtPrevPaid.Size = new System.Drawing.Size(134, 29);
            this.txtPrevPaid.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(308, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "Paid";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmHpDayWiseDueCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdPrintReceipt);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.gvLedger);
            this.Controls.Add(this.dgLedger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnResetTransations);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtHBillNo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHpDayWiseDueCollection";
            this.Text = "Hp Day WiseDueCollection";
            this.Load += new System.EventHandler(this.frmHpDayWiseDueCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.TextBox txtPrevDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdPrintReceipt;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView gvLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResetTransations;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtCardOrMobileReceiveTk;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.ComboBox cmbPaymentChannel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtHBillNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrevPaid;
        private System.Windows.Forms.Label label7;
    }
}