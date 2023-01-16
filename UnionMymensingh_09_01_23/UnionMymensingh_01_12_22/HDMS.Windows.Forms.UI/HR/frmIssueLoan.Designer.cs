namespace HDMS.Windows.Forms.UI.HR
{
    partial class frmIssueLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueLoan));
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIssueAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalInstallment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmountPerInstallment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvConsultants = new System.Windows.Forms.DataGridView();
            this.ctlEmployeeSearchControl = new HDMS.Windows.Forms.UI.Controls.EmployeeSearchControl();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPerInstallment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfPaidInstallment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultants)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmployee
            // 
            this.txtEmployee.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtEmployee.Location = new System.Drawing.Point(138, 30);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(234, 27);
            this.txtEmployee.TabIndex = 10030;
            this.txtEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployee_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(23, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 10029;
            this.label5.Text = "Select Member";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtName.Location = new System.Drawing.Point(138, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 27);
            this.txtName.TabIndex = 10033;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(83, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 10032;
            this.label1.Text = "Name";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtDesignation.Location = new System.Drawing.Point(138, 96);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(234, 27);
            this.txtDesignation.TabIndex = 10035;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(43, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 10034;
            this.label2.Text = "Designation";
            // 
            // txtDept
            // 
            this.txtDept.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtDept.Location = new System.Drawing.Point(138, 129);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(234, 27);
            this.txtDept.TabIndex = 10037;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(43, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 10036;
            this.label3.Text = "Department";
            // 
            // txtIssueAmount
            // 
            this.txtIssueAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtIssueAmount.Location = new System.Drawing.Point(138, 163);
            this.txtIssueAmount.Name = "txtIssueAmount";
            this.txtIssueAmount.Size = new System.Drawing.Size(234, 27);
            this.txtIssueAmount.TabIndex = 10039;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(34, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 10038;
            this.label4.Text = "Issue Amount";
            // 
            // txtTotalInstallment
            // 
            this.txtTotalInstallment.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTotalInstallment.Location = new System.Drawing.Point(138, 196);
            this.txtTotalInstallment.Name = "txtTotalInstallment";
            this.txtTotalInstallment.Size = new System.Drawing.Size(153, 27);
            this.txtTotalInstallment.TabIndex = 10041;
            this.txtTotalInstallment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalInstallment_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label6.Location = new System.Drawing.Point(13, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 10040;
            this.label6.Text = "Total Installment";
            // 
            // txtAmountPerInstallment
            // 
            this.txtAmountPerInstallment.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtAmountPerInstallment.Location = new System.Drawing.Point(138, 229);
            this.txtAmountPerInstallment.Name = "txtAmountPerInstallment";
            this.txtAmountPerInstallment.Size = new System.Drawing.Size(153, 27);
            this.txtAmountPerInstallment.TabIndex = 10043;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label7.Location = new System.Drawing.Point(70, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 10042;
            this.label7.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label8.Location = new System.Drawing.Point(297, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 10044;
            this.label8.Text = "/Installment";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label9.Location = new System.Drawing.Point(13, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 10045;
            this.label9.Text = "Inst. Start Month";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(138, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 39);
            this.btnSave.TabIndex = 10051;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(138, 273);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(123, 28);
            this.cmbMonth.TabIndex = 10052;
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cmbYear.Location = new System.Drawing.Point(314, 276);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(123, 28);
            this.cmbYear.TabIndex = 10053;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label10.Location = new System.Drawing.Point(271, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 10054;
            this.label10.Text = "Year";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(275, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 39);
            this.btnClose.TabIndex = 10055;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvConsultants
            // 
            this.dgvConsultants.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvConsultants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CName,
            this.DIdentityLine1,
            this.DIdentityLine2,
            this.AmountPerInstallment,
            this.NoOfPaidInstallment});
            this.dgvConsultants.Location = new System.Drawing.Point(463, 30);
            this.dgvConsultants.Name = "dgvConsultants";
            this.dgvConsultants.Size = new System.Drawing.Size(694, 525);
            this.dgvConsultants.TabIndex = 10056;
            // 
            // ctlEmployeeSearchControl
            // 
            this.ctlEmployeeSearchControl.Location = new System.Drawing.Point(-17, 359);
            this.ctlEmployeeSearchControl.Name = "ctlEmployeeSearchControl";
            this.ctlEmployeeSearchControl.Size = new System.Drawing.Size(598, 415);
            this.ctlEmployeeSearchControl.TabIndex = 10031;
            this.ctlEmployeeSearchControl.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "RCId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 60;
            // 
            // CName
            // 
            this.CName.DataPropertyName = "Name";
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.Width = 120;
            // 
            // DIdentityLine1
            // 
            this.DIdentityLine1.HeaderText = "IssueAmount";
            this.DIdentityLine1.Name = "DIdentityLine1";
            // 
            // DIdentityLine2
            // 
            this.DIdentityLine2.DataPropertyName = "DIdentityLine2";
            this.DIdentityLine2.HeaderText = "NoOfInstallemnt";
            this.DIdentityLine2.Name = "DIdentityLine2";
            this.DIdentityLine2.Width = 120;
            // 
            // AmountPerInstallment
            // 
            this.AmountPerInstallment.HeaderText = "Amount/Inst.";
            this.AmountPerInstallment.Name = "AmountPerInstallment";
            this.AmountPerInstallment.Width = 120;
            // 
            // NoOfPaidInstallment
            // 
            this.NoOfPaidInstallment.HeaderText = "NoOfPaidInstallment";
            this.NoOfPaidInstallment.Name = "NoOfPaidInstallment";
            this.NoOfPaidInstallment.Width = 150;
            // 
            // frmIssueLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 567);
            this.Controls.Add(this.ctlEmployeeSearchControl);
            this.Controls.Add(this.dgvConsultants);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAmountPerInstallment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalInstallment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIssueAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIssueLoan";
            this.Text = "Issue Loan";
            this.Load += new System.EventHandler(this.frmIssueLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.EmployeeSearchControl ctlEmployeeSearchControl;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIssueAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalInstallment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmountPerInstallment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvConsultants;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPerInstallment;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfPaidInstallment;
    }
}