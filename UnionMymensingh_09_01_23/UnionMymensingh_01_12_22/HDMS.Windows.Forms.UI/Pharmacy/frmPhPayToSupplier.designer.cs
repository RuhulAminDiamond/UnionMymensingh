namespace POS.Forms
{
    partial class frmPhPayToSupplier
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaymentTk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBalanceTk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gvLedger = new System.Windows.Forms.DataGridView();
            this.TranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlManufacturerSearchControl = new HDMS.Windows.Forms.UI.Controls.ManufacturerSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "Payment Tk";
            // 
            // txtPaymentTk
            // 
            this.txtPaymentTk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentTk.Location = new System.Drawing.Point(123, 196);
            this.txtPaymentTk.Name = "txtPaymentTk";
            this.txtPaymentTk.Size = new System.Drawing.Size(228, 26);
            this.txtPaymentTk.TabIndex = 49;
            this.txtPaymentTk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentTk_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Balance Tk";
            // 
            // txtBalanceTk
            // 
            this.txtBalanceTk.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalanceTk.Enabled = false;
            this.txtBalanceTk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceTk.Location = new System.Drawing.Point(123, 160);
            this.txtBalanceTk.Name = "txtBalanceTk";
            this.txtBalanceTk.Size = new System.Drawing.Size(161, 26);
            this.txtBalanceTk.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Select Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(123, 126);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(336, 26);
            this.txtSupplier.TabIndex = 45;
            this.txtSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupplier_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(123, 239);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(276, 77);
            this.txtRemarks.TabIndex = 53;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(123, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 42);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save.";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 71;
            this.label6.Text = "Date";
            // 
            // dtp
            // 
            this.dtp.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(123, 58);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(161, 25);
            this.dtp.TabIndex = 70;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(258, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 42);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close.";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 10036;
            this.label8.Text = "Purchase Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(123, 91);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(180, 26);
            this.txtBillNo.TabIndex = 10037;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(502, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 20);
            this.label9.TabIndex = 10039;
            this.label9.Text = "Transaction History";
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
            this.gvLedger.Location = new System.Drawing.Point(506, 48);
            this.gvLedger.Name = "gvLedger";
            this.gvLedger.Size = new System.Drawing.Size(625, 391);
            this.gvLedger.TabIndex = 10038;
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
            this.Debit.Width = 80;
            // 
            // Credit
            // 
            this.Credit.DataPropertyName = "PaidAmount";
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.Width = 80;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.Width = 90;
            // 
            // Particulars
            // 
            this.Particulars.DataPropertyName = "Particulars";
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.Name = "Particulars";
            this.Particulars.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OperateBy";
            this.Column3.HeaderText = "UserName";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // ctrlManufacturerSearchControl
            // 
            this.ctrlManufacturerSearchControl.Location = new System.Drawing.Point(-361, 409);
            this.ctrlManufacturerSearchControl.Name = "ctrlManufacturerSearchControl";
            this.ctrlManufacturerSearchControl.Size = new System.Drawing.Size(760, 650);
            this.ctrlManufacturerSearchControl.TabIndex = 72;
            this.ctrlManufacturerSearchControl.Visible = false;
            // 
            // frmPhPayToSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 602);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.ctrlManufacturerSearchControl);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPaymentTk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBalanceTk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.gvLedger);
            this.Name = "frmPhPayToSupplier";
            this.Text = "Pay To Supplier";
            this.Load += new System.EventHandler(this.frmPayToSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaymentTk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBalanceTk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemarks;
       
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp;
        private HDMS.Windows.Forms.UI.Controls.ManufacturerSearchControl ctrlManufacturerSearchControl;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gvLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}