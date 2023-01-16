namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmCollection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvLedger = new System.Windows.Forms.DataGridView();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdPrintReceipt = new System.Windows.Forms.Button();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountInPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPcDiscount = new System.Windows.Forms.Label();
            this.txtCancelled = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTestCostTk = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnResetTransations = new System.Windows.Forms.Button();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtDiscountTk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaidTk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbPaymentChannel = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtCardOrMobileReceiveTk = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountInPercent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblMediaName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(133, 12);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(222, 27);
            this.txtSerial.TabIndex = 0;
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill No :";
            // 
            // gvLedger
            // 
            this.gvLedger.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.gvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranDate,
            this.Debit,
            this.Credit,
            this.Balance,
            this.Particulars,
            this.Column3});
            this.gvLedger.Location = new System.Drawing.Point(16, 385);
            this.gvLedger.Name = "gvLedger";
            this.gvLedger.RowHeadersWidth = 51;
            this.gvLedger.Size = new System.Drawing.Size(866, 260);
            this.gvLedger.TabIndex = 2;
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "Date";
            this.TranDate.HeaderText = "Date";
            this.TranDate.MinimumWidth = 6;
            this.TranDate.Name = "TranDate";
            this.TranDate.Width = 125;
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "TestAmount";
            this.Debit.HeaderText = "Debit";
            this.Debit.MinimumWidth = 6;
            this.Debit.Name = "Debit";
            this.Debit.Width = 125;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "PaidAmount";
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
            // Particulars
            // 
            this.Particulars.DataPropertyName = "Particulars";
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.MinimumWidth = 6;
            this.Particulars.Name = "Particulars";
            this.Particulars.Width = 350;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OperateBy";
            this.Column3.HeaderText = "UserName";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(1172, 587);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(123, 43);
            this.cmdSave.TabIndex = 4;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdPrintReceipt
            // 
            this.cmdPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintReceipt.Location = new System.Drawing.Point(975, 587);
            this.cmdPrintReceipt.Name = "cmdPrintReceipt";
            this.cmdPrintReceipt.Size = new System.Drawing.Size(84, 43);
            this.cmdPrintReceipt.TabIndex = 11;
            this.cmdPrintReceipt.Text = "Print";
            this.cmdPrintReceipt.UseVisualStyleBackColor = true;
            this.cmdPrintReceipt.Click += new System.EventHandler(this.cmdPrintReceipt_Click);
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.BackgroundColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.tName,
            this.Rate,
            this.DiscountInPercent,
            this.Discount,
            this.Column1,
            this.Column2,
            this.Status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTests.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTests.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgTests.Location = new System.Drawing.Point(16, 93);
            this.dgTests.Name = "dgTests";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTests.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTests.RowHeadersWidth = 20;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgTests.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTests.Size = new System.Drawing.Size(866, 257);
            this.dgTests.TabIndex = 59;
            this.dgTests.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTests_CellValueChanged);
            this.dgTests.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgTests_KeyPress);
            // 
            // Code
            // 
            this.Code.HeaderText = "Test Code";
            this.Code.MinimumWidth = 6;
            this.Code.Name = "Code";
            this.Code.Width = 120;
            // 
            // tName
            // 
            this.tName.HeaderText = "Test Name";
            this.tName.MinimumWidth = 6;
            this.tName.Name = "tName";
            this.tName.Width = 300;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.Width = 120;
            // 
            // DiscountInPercent
            // 
            this.DiscountInPercent.DataPropertyName = "discountInPercent";
            this.DiscountInPercent.HeaderText = "Disc(%)";
            this.DiscountInPercent.MinimumWidth = 6;
            this.DiscountInPercent.Name = "DiscountInPercent";
            this.DiscountInPercent.Width = 125;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.MinimumWidth = 6;
            this.Discount.Name = "Discount";
            this.Discount.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Status";
            this.Column1.HeaderText = "Status";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CancelledBy";
            this.Column2.HeaderText = "UserName";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "None";
            this.Status.HeaderText = "Col5";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Visible = false;
            this.Status.Width = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 60;
            this.label4.Text = "Transaction History";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "Test/s List";
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(498, 10);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(125, 27);
            this.dtpEntry.TabIndex = 90;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(407, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 91;
            this.label10.Text = "Entry Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPcDiscount);
            this.groupBox1.Controls.Add(this.txtCancelled);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtTestCostTk);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnResetTransations);
            this.groupBox1.Controls.Add(this.txtDue);
            this.groupBox1.Controls.Add(this.txtDiscountTk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPaidTk);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(903, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 191);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous Transactions";
            // 
            // lblPcDiscount
            // 
            this.lblPcDiscount.AutoSize = true;
            this.lblPcDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblPcDiscount.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcDiscount.ForeColor = System.Drawing.Color.Red;
            this.lblPcDiscount.Location = new System.Drawing.Point(335, 159);
            this.lblPcDiscount.Name = "lblPcDiscount";
            this.lblPcDiscount.Size = new System.Drawing.Size(15, 18);
            this.lblPcDiscount.TabIndex = 33366;
            this.lblPcDiscount.Text = "0";
            // 
            // txtCancelled
            // 
            this.txtCancelled.Enabled = false;
            this.txtCancelled.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCancelled.Location = new System.Drawing.Point(310, 65);
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.Size = new System.Drawing.Size(102, 29);
            this.txtCancelled.TabIndex = 103;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(163, 159);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(169, 18);
            this.label21.TabIndex = 33367;
            this.label21.Text = "RF Commission  Remaing :";
            // 
            // txtTestCostTk
            // 
            this.txtTestCostTk.Enabled = false;
            this.txtTestCostTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTestCostTk.Location = new System.Drawing.Point(109, 19);
            this.txtTestCostTk.Name = "txtTestCostTk";
            this.txtTestCostTk.Size = new System.Drawing.Size(134, 29);
            this.txtTestCostTk.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(197, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.label11.TabIndex = 104;
            this.label11.Text = "Cancelled (Tk.)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnResetTransations
            // 
            this.btnResetTransations.Enabled = false;
            this.btnResetTransations.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetTransations.Location = new System.Drawing.Point(8, 149);
            this.btnResetTransations.Name = "btnResetTransations";
            this.btnResetTransations.Size = new System.Drawing.Size(149, 36);
            this.btnResetTransations.TabIndex = 96;
            this.btnResetTransations.Text = "Reset Transactions";
            this.btnResetTransations.UseVisualStyleBackColor = true;
            this.btnResetTransations.Click += new System.EventHandler(this.btnResetTransations_Click);
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.SystemColors.Window;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtDue.Location = new System.Drawing.Point(310, 109);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(102, 29);
            this.txtDue.TabIndex = 95;
            // 
            // txtDiscountTk
            // 
            this.txtDiscountTk.Enabled = false;
            this.txtDiscountTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountTk.Location = new System.Drawing.Point(109, 61);
            this.txtDiscountTk.Name = "txtDiscountTk";
            this.txtDiscountTk.Size = new System.Drawing.Size(84, 29);
            this.txtDiscountTk.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(235, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 96;
            this.label2.Text = "Due (Tk.)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 102;
            this.label8.Text = "Discount (Tk.)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Test Cost(Tk.)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaidTk
            // 
            this.txtPaidTk.Enabled = false;
            this.txtPaidTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPaidTk.Location = new System.Drawing.Point(109, 105);
            this.txtPaidTk.Name = "txtPaidTk";
            this.txtPaidTk.Size = new System.Drawing.Size(84, 29);
            this.txtPaidTk.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(34, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "Paid (Tk.)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbPaymentChannel);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.txtCardOrMobileReceiveTk);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtTransactionNo);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.cmbPaymentMode);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDiscountInPercent);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPaid);
            this.groupBox2.Location = new System.Drawing.Point(901, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 368);
            this.groupBox2.TabIndex = 95;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Transaction";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Remarks";
            // 
            // cmbPaymentChannel
            // 
            this.cmbPaymentChannel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentChannel.FormattingEnabled = true;
            this.cmbPaymentChannel.Location = new System.Drawing.Point(216, 153);
            this.cmbPaymentChannel.Name = "cmbPaymentChannel";
            this.cmbPaymentChannel.Size = new System.Drawing.Size(176, 31);
            this.cmbPaymentChannel.TabIndex = 11242;
            this.cmbPaymentChannel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentChannel_KeyDown);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Info;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(78, 320);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(314, 35);
            this.txtRemarks.TabIndex = 20;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(31, 192);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(179, 23);
            this.label31.TabIndex = 11239;
            this.label31.Text = "Card/Mob. Payment :";
            // 
            // txtCardOrMobileReceiveTk
            // 
            this.txtCardOrMobileReceiveTk.BackColor = System.Drawing.Color.MistyRose;
            this.txtCardOrMobileReceiveTk.Enabled = false;
            this.txtCardOrMobileReceiveTk.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardOrMobileReceiveTk.Location = new System.Drawing.Point(216, 192);
            this.txtCardOrMobileReceiveTk.Name = "txtCardOrMobileReceiveTk";
            this.txtCardOrMobileReceiveTk.Size = new System.Drawing.Size(178, 37);
            this.txtCardOrMobileReceiveTk.TabIndex = 11238;
            this.txtCardOrMobileReceiveTk.TextChanged += new System.EventHandler(this.txtCardOrMobileReceiveTk_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(74, 237);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(135, 23);
            this.label30.TabIndex = 11237;
            this.label30.Text = "Transaction No :";
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Enabled = false;
            this.txtTransactionNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNo.Location = new System.Drawing.Point(216, 237);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(178, 31);
            this.txtTransactionNo.TabIndex = 11236;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(54, 153);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(156, 23);
            this.label23.TabIndex = 11235;
            this.label23.Text = "Payment Terminal :";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(214, 110);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(178, 31);
            this.cmbPaymentMode.TabIndex = 11234;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(74, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 23);
            this.label16.TabIndex = 11233;
            this.label16.Text = "Payment Mode :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.MistyRose;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(214, 55);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(178, 33);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 23);
            this.label12.TabIndex = 16;
            this.label12.Text = "Discount (%)";
            // 
            // txtDiscountInPercent
            // 
            this.txtDiscountInPercent.BackColor = System.Drawing.Color.MistyRose;
            this.txtDiscountInPercent.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountInPercent.Location = new System.Drawing.Point(25, 55);
            this.txtDiscountInPercent.Name = "txtDiscountInPercent";
            this.txtDiscountInPercent.Size = new System.Drawing.Size(179, 33);
            this.txtDiscountInPercent.TabIndex = 15;
            this.txtDiscountInPercent.TextChanged += new System.EventHandler(this.txtDiscountInPercent_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cash Payment :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Discount Tk.";
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtPaid.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(216, 277);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(176, 37);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1065, 587);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 43);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblPatientName.Location = new System.Drawing.Point(126, 47);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(59, 20);
            this.lblPatientName.TabIndex = 98;
            this.lblPatientName.Text = "Patient";
            // 
            // lblMediaName
            // 
            this.lblMediaName.AutoSize = true;
            this.lblMediaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediaName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMediaName.Location = new System.Drawing.Point(494, 47);
            this.lblMediaName.Name = "lblMediaName";
            this.lblMediaName.Size = new System.Drawing.Size(52, 20);
            this.lblMediaName.TabIndex = 98;
            this.lblMediaName.Text = "Media";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(386, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 20);
            this.label14.TabIndex = 98;
            this.label14.Text = "Media Name :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 20);
            this.label15.TabIndex = 99;
            this.label15.Text = "Patient Name  :";
            // 
            // frmCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 637);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblMediaName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.cmdPrintReceipt);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.gvLedger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection from Patient";
            this.Load += new System.EventHandler(this.frmCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvLedger;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdPrintReceipt;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCancelled;
        private System.Windows.Forms.TextBox txtTestCostTk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.TextBox txtDiscountTk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaidTk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountInPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Button btnResetTransations;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountInPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtCardOrMobileReceiveTk;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbPaymentChannel;
        private System.Windows.Forms.Label lblPcDiscount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblMediaName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}