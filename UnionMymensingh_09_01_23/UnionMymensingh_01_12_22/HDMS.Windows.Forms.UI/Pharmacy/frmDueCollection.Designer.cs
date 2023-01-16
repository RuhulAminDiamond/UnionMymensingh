namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmDueCollection
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
            this.label4 = new System.Windows.Forms.Label();
            this.gvLedger = new System.Windows.Forms.DataGridView();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCancelled = new System.Windows.Forms.TextBox();
            this.txtTotalTk = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtDiscountTk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPaidTk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdPrintReceipt = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIPDBillNo = new System.Windows.Forms.TextBox();
            this.ctlPatientList = new HDMS.Windows.Forms.UI.Controls.HospitalPatientSearch();
            this.lblPatientInfo = new System.Windows.Forms.Label();
            this.btnPrintLedger = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Transaction History";
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
            this.gvLedger.Location = new System.Drawing.Point(35, 118);
            this.gvLedger.Name = "gvLedger";
            this.gvLedger.Size = new System.Drawing.Size(866, 337);
            this.gvLedger.TabIndex = 61;
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "TranDate";
            this.TranDate.HeaderText = "Date";
            this.TranDate.Name = "TranDate";
            // 
            // Debit
            // 
            this.Debit.DataPropertyName = "Debit";
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "Credit";
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
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 64;
            this.label1.Text = "IPD Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(503, 28);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(222, 27);
            this.txtBillNo.TabIndex = 63;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1023, 487);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 43);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPaid);
            this.groupBox2.Location = new System.Drawing.Point(919, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 171);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Transaction";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(124, 56);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(117, 27);
            this.txtDiscount.TabIndex = 17;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Paid Tk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Discount";
            // 
            // txtPaid
            // 
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(124, 102);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(119, 27);
            this.txtPaid.TabIndex = 12;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCancelled);
            this.groupBox1.Controls.Add(this.txtTotalTk);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDue);
            this.groupBox1.Controls.Add(this.txtDiscountTk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPaidTk);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(919, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 245);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous Transactions";
            // 
            // txtCancelled
            // 
            this.txtCancelled.Enabled = false;
            this.txtCancelled.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCancelled.Location = new System.Drawing.Point(124, 144);
            this.txtCancelled.Name = "txtCancelled";
            this.txtCancelled.Size = new System.Drawing.Size(134, 29);
            this.txtCancelled.TabIndex = 103;
            // 
            // txtTotalTk
            // 
            this.txtTotalTk.Enabled = false;
            this.txtTotalTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTotalTk.Location = new System.Drawing.Point(124, 19);
            this.txtTotalTk.Name = "txtTotalTk";
            this.txtTotalTk.Size = new System.Drawing.Size(134, 29);
            this.txtTotalTk.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(29, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 104;
            this.label11.Text = "Return (Tk.)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtDue.Location = new System.Drawing.Point(124, 187);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(134, 29);
            this.txtDue.TabIndex = 95;
            // 
            // txtDiscountTk
            // 
            this.txtDiscountTk.Enabled = false;
            this.txtDiscountTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountTk.Location = new System.Drawing.Point(124, 61);
            this.txtDiscountTk.Name = "txtDiscountTk";
            this.txtDiscountTk.Size = new System.Drawing.Size(134, 29);
            this.txtDiscountTk.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 187);
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
            this.label8.Location = new System.Drawing.Point(19, 65);
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
            this.label9.Location = new System.Drawing.Point(44, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Total Tk.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaidTk
            // 
            this.txtPaidTk.Enabled = false;
            this.txtPaidTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPaidTk.Location = new System.Drawing.Point(124, 105);
            this.txtPaidTk.Name = "txtPaidTk";
            this.txtPaidTk.Size = new System.Drawing.Size(134, 29);
            this.txtPaidTk.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "Paid (Tk.)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdPrintReceipt
            // 
            this.cmdPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintReceipt.Location = new System.Drawing.Point(919, 487);
            this.cmdPrintReceipt.Name = "cmdPrintReceipt";
            this.cmdPrintReceipt.Size = new System.Drawing.Size(84, 43);
            this.cmdPrintReceipt.TabIndex = 99;
            this.cmdPrintReceipt.Text = "Print";
            this.cmdPrintReceipt.UseVisualStyleBackColor = true;
            this.cmdPrintReceipt.Click += new System.EventHandler(this.cmdPrintReceipt_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(1126, 487);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 43);
            this.cmdSave.TabIndex = 98;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(443, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "Bill No";
            // 
            // txtIPDBillNo
            // 
            this.txtIPDBillNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPDBillNo.Location = new System.Drawing.Point(105, 28);
            this.txtIPDBillNo.Name = "txtIPDBillNo";
            this.txtIPDBillNo.Size = new System.Drawing.Size(222, 27);
            this.txtIPDBillNo.TabIndex = 104;
            this.txtIPDBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIPDBillNo_KeyPress);
            // 
            // ctlPatientList
            // 
            this.ctlPatientList.Location = new System.Drawing.Point(22, 174);
            this.ctlPatientList.Name = "ctlPatientList";
            this.ctlPatientList.Size = new System.Drawing.Size(649, 504);
            this.ctlPatientList.TabIndex = 10034;
            this.ctlPatientList.Visible = false;
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.AutoSize = true;
            this.lblPatientInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientInfo.ForeColor = System.Drawing.Color.Tomato;
            this.lblPatientInfo.Location = new System.Drawing.Point(101, 58);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(0, 20);
            this.lblPatientInfo.TabIndex = 10035;
            // 
            // btnPrintLedger
            // 
            this.btnPrintLedger.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintLedger.Location = new System.Drawing.Point(703, 487);
            this.btnPrintLedger.Name = "btnPrintLedger";
            this.btnPrintLedger.Size = new System.Drawing.Size(165, 43);
            this.btnPrintLedger.TabIndex = 10036;
            this.btnPrintLedger.Text = "Print Ledger";
            this.btnPrintLedger.UseVisualStyleBackColor = true;
            this.btnPrintLedger.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDueCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 606);
            this.Controls.Add(this.ctlPatientList);
            this.Controls.Add(this.btnPrintLedger);
            this.Controls.Add(this.lblPatientInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIPDBillNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdPrintReceipt);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvLedger);
            this.Name = "frmDueCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Due Collection";
            this.Load += new System.EventHandler(this.frmDueCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gvLedger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCancelled;
        private System.Windows.Forms.TextBox txtTotalTk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.TextBox txtDiscountTk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPaidTk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdPrintReceipt;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIPDBillNo;
        private Controls.HospitalPatientSearch ctlPatientList;
        private System.Windows.Forms.Label lblPatientInfo;
        private System.Windows.Forms.Button btnPrintLedger;
    }
}