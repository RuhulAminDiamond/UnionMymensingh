namespace HDMS.Windows.Forms.UI.OPD
{
    partial class frmOPDCashCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPDCashCollection));
            this.btnResetTransations = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCancelled = new System.Windows.Forms.TextBox();
            this.txtTestCostTk = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtDiscountTk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaidTk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountInPercent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.gvLedger = new System.Windows.Forms.DataGridView();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdPrintReceipt = new System.Windows.Forms.Button();
            this.txtOPDBillNo = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.ServiceHeadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResetTransations
            // 
            this.btnResetTransations.Enabled = false;
            this.btnResetTransations.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetTransations.Location = new System.Drawing.Point(742, 324);
            this.btnResetTransations.Name = "btnResetTransations";
            this.btnResetTransations.Size = new System.Drawing.Size(219, 36);
            this.btnResetTransations.TabIndex = 110;
            this.btnResetTransations.Text = "Reset Transactions";
            this.btnResetTransations.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCancelled);
            this.groupBox1.Controls.Add(this.txtTestCostTk);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDue);
            this.groupBox1.Controls.Add(this.txtDiscountTk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPaidTk);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(704, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 245);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous Transactions";
            // 
            // txtCancelled
            // 
            this.txtCancelled.Enabled = false;
            this.txtCancelled.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCancelled.Location = new System.Drawing.Point(137, 145);
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.Size = new System.Drawing.Size(134, 29);
            this.txtCancelled.TabIndex = 103;
            // 
            // txtTestCostTk
            // 
            this.txtTestCostTk.Enabled = false;
            this.txtTestCostTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTestCostTk.Location = new System.Drawing.Point(137, 20);
            this.txtTestCostTk.Name = "txtTestCostTk";
            this.txtTestCostTk.Size = new System.Drawing.Size(134, 29);
            this.txtTestCostTk.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.label11.TabIndex = 104;
            this.label11.Text = "Cancelled (Tk.)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.SystemColors.Window;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtDue.Location = new System.Drawing.Point(137, 188);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(134, 29);
            this.txtDue.TabIndex = 95;
            // 
            // txtDiscountTk
            // 
            this.txtDiscountTk.Enabled = false;
            this.txtDiscountTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountTk.Location = new System.Drawing.Point(137, 62);
            this.txtDiscountTk.Name = "txtDiscountTk";
            this.txtDiscountTk.Size = new System.Drawing.Size(134, 29);
            this.txtDiscountTk.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 188);
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
            this.label8.Location = new System.Drawing.Point(32, 66);
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
            this.label9.Location = new System.Drawing.Point(9, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Service Cost(Tk.)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaidTk
            // 
            this.txtPaidTk.Enabled = false;
            this.txtPaidTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPaidTk.Location = new System.Drawing.Point(137, 106);
            this.txtPaidTk.Name = "txtPaidTk";
            this.txtPaidTk.Size = new System.Drawing.Size(134, 29);
            this.txtPaidTk.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "Paid (Tk.)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(435, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 107;
            this.label10.Text = "Entry Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDiscountInPercent);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPaid);
            this.groupBox2.Location = new System.Drawing.Point(704, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 171);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Transaction";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(124, 79);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(117, 27);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Discount (%)";
            // 
            // txtDiscountInPercent
            // 
            this.txtDiscountInPercent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountInPercent.Location = new System.Drawing.Point(124, 36);
            this.txtDiscountInPercent.Name = "txtDiscountInPercent";
            this.txtDiscountInPercent.Size = new System.Drawing.Size(117, 27);
            this.txtDiscountInPercent.TabIndex = 15;
            this.txtDiscountInPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountInPercent.TextChanged += new System.EventHandler(this.txtDiscountInPercent_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Paid Tk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Discount";
            // 
            // txtPaid
            // 
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(124, 125);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(119, 27);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(808, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 43);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(517, 25);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(125, 27);
            this.dtpEntry.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "Service/s List";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(911, 543);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 43);
            this.cmdSave.TabIndex = 101;
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
            this.Debit,
            this.Credit,
            this.Balance,
            this.Particulars,
            this.Column3});
            this.gvLedger.Location = new System.Drawing.Point(38, 357);
            this.gvLedger.Name = "gvLedger";
            this.gvLedger.Size = new System.Drawing.Size(617, 218);
            this.gvLedger.TabIndex = 100;
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "Date";
            this.TranDate.HeaderText = "Date";
            this.TranDate.Name = "TranDate";
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "TestAmount";
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "PaidAmount";
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            // 
            // Particulars
            // 
            this.Particulars.DataPropertyName = "Particulars";
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.Name = "Particulars";
            this.Particulars.Width = 350;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OperateBy";
            this.Column3.HeaderText = "UserName";
            this.Column3.Name = "Column3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 99;
            this.label1.Text = "OPD Bill No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Transaction History";
            // 
            // cmdPrintReceipt
            // 
            this.cmdPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintReceipt.Location = new System.Drawing.Point(704, 543);
            this.cmdPrintReceipt.Name = "cmdPrintReceipt";
            this.cmdPrintReceipt.Size = new System.Drawing.Size(84, 43);
            this.cmdPrintReceipt.TabIndex = 102;
            this.cmdPrintReceipt.Text = "Print";
            this.cmdPrintReceipt.UseVisualStyleBackColor = true;
            this.cmdPrintReceipt.Click += new System.EventHandler(this.cmdPrintReceipt_Click);
            // 
            // txtOPDBillNo
            // 
            this.txtOPDBillNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOPDBillNo.Location = new System.Drawing.Point(128, 23);
            this.txtOPDBillNo.Name = "txtOPDBillNo";
            this.txtOPDBillNo.Size = new System.Drawing.Size(222, 27);
            this.txtOPDBillNo.TabIndex = 98;
            this.txtOPDBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPDBillNo_KeyPress);
            // 
            // dgService
            // 
            this.dgService.AllowUserToAddRows = false;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceHeadName,
            this.Rate,
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.Column5});
            this.dgService.Location = new System.Drawing.Point(39, 84);
            this.dgService.Name = "dgService";
            this.dgService.Size = new System.Drawing.Size(616, 245);
            this.dgService.TabIndex = 11203;
            // 
            // ServiceHeadName
            // 
            this.ServiceHeadName.HeaderText = "Service Name";
            this.ServiceHeadName.Name = "ServiceHeadName";
            this.ServiceHeadName.Width = 220;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "User";
            this.Column5.Name = "Column5";
            // 
            // frmOPDCashCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 652);
            this.Controls.Add(this.dgService);
            this.Controls.Add(this.btnResetTransations);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.gvLedger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdPrintReceipt);
            this.Controls.Add(this.txtOPDBillNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPDCashCollection";
            this.Text = "OPD Cash Collection";
            this.Load += new System.EventHandler(this.frmOPDCashCollection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResetTransations;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountInPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView gvLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdPrintReceipt;
        private System.Windows.Forms.TextBox txtOPDBillNo;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceHeadName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}