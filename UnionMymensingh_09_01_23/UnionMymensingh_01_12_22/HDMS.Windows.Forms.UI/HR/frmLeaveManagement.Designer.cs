namespace HDMS.Windows.Forms.UI.HR
{
    partial class frmLeaveManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeaveManagement));
            this.dgEmployee = new System.Windows.Forms.DataGridView();
            this.ManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LDecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.datefrm = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.txtPurposeOfLeave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDateto = new System.Windows.Forms.Label();
            this.lblDatefrm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalCL = new System.Windows.Forms.Label();
            this.lblCLExp = new System.Windows.Forms.Label();
            this.lblCLRemains = new System.Windows.Forms.Label();
            this.lblTotaldays = new System.Windows.Forms.Label();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnOnHold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEmployee
            // 
            this.dgEmployee.AllowUserToAddRows = false;
            this.dgEmployee.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManufacturerId,
            this.ManuName,
            this.Dept,
            this.Designation,
            this.LDecision,
            this.HOO});
            this.dgEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEmployee.Location = new System.Drawing.Point(3, 82);
            this.dgEmployee.Name = "dgEmployee";
            this.dgEmployee.Size = new System.Drawing.Size(667, 451);
            this.dgEmployee.TabIndex = 346;
            this.dgEmployee.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgEmployee_RowHeaderMouseClick);
            // 
            // ManufacturerId
            // 
            this.ManufacturerId.DataPropertyName = "ManufacturerId";
            this.ManufacturerId.HeaderText = "Emp No";
            this.ManufacturerId.Name = "ManufacturerId";
            // 
            // ManuName
            // 
            this.ManuName.DataPropertyName = "Name";
            this.ManuName.HeaderText = "Name";
            this.ManuName.Name = "ManuName";
            this.ManuName.Width = 180;
            // 
            // Dept
            // 
            this.Dept.HeaderText = "Department";
            this.Dept.Name = "Dept";
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.Name = "Designation";
            // 
            // LDecision
            // 
            this.LDecision.HeaderText = "HoD";
            this.LDecision.Name = "LDecision";
            this.LDecision.Width = 80;
            // 
            // HOO
            // 
            this.HOO.HeaderText = "HOO";
            this.HOO.Name = "HOO";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgEmployee, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.73881F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.26119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 599);
            this.tableLayoutPanel1.TabIndex = 347;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 73);
            this.tableLayoutPanel2.TabIndex = 347;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.69884F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.30116F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel3.Controls.Add(this.datefrm, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(628, 30);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // datefrm
            // 
            this.datefrm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datefrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datefrm.Location = new System.Drawing.Point(80, 3);
            this.datefrm.Name = "datefrm";
            this.datefrm.Size = new System.Drawing.Size(102, 26);
            this.datefrm.TabIndex = 354;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 18);
            this.label9.TabIndex = 353;
            this.label9.Text = "Date from";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(194, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 18);
            this.label10.TabIndex = 355;
            this.label10.Text = "to";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(228, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 26);
            this.dateTimePicker1.TabIndex = 356;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.59916F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.40084F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbStatus, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(628, 31);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 18);
            this.label11.TabIndex = 354;
            this.label11.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Approved",
            "Rejected"});
            this.cmbStatus.Location = new System.Drawing.Point(81, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(138, 26);
            this.cmbStatus.TabIndex = 355;
            this.cmbStatus.Text = "Pending";
            // 
            // txtApplication
            // 
            this.txtApplication.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplication.Location = new System.Drawing.Point(693, 160);
            this.txtApplication.Multiline = true;
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(561, 145);
            this.txtApplication.TabIndex = 351;
            // 
            // txtPurposeOfLeave
            // 
            this.txtPurposeOfLeave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurposeOfLeave.Location = new System.Drawing.Point(693, 103);
            this.txtPurposeOfLeave.Name = "txtPurposeOfLeave";
            this.txtPurposeOfLeave.Size = new System.Drawing.Size(561, 26);
            this.txtPurposeOfLeave.TabIndex = 350;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(690, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 349;
            this.label2.Text = "Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(690, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 348;
            this.label1.Text = "Purpose of Leave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 353;
            this.label5.Text = "Date to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(690, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 352;
            this.label4.Text = "Date from";
            // 
            // lblDateto
            // 
            this.lblDateto.AutoSize = true;
            this.lblDateto.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateto.ForeColor = System.Drawing.Color.Red;
            this.lblDateto.Location = new System.Drawing.Point(768, 352);
            this.lblDateto.Name = "lblDateto";
            this.lblDateto.Size = new System.Drawing.Size(0, 18);
            this.lblDateto.TabIndex = 355;
            // 
            // lblDatefrm
            // 
            this.lblDatefrm.AutoSize = true;
            this.lblDatefrm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatefrm.ForeColor = System.Drawing.Color.Red;
            this.lblDatefrm.Location = new System.Drawing.Point(768, 325);
            this.lblDatefrm.Name = "lblDatefrm";
            this.lblDatefrm.Size = new System.Drawing.Size(0, 18);
            this.lblDatefrm.TabIndex = 354;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(690, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 356;
            this.label3.Text = "Total days";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1018, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 357;
            this.label6.Text = "Total CL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1018, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 358;
            this.label7.Text = "CL. Exp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1018, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 359;
            this.label8.Text = "CL Remains";
            // 
            // lblTotalCL
            // 
            this.lblTotalCL.AutoSize = true;
            this.lblTotalCL.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCL.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCL.Location = new System.Drawing.Point(1096, 325);
            this.lblTotalCL.Name = "lblTotalCL";
            this.lblTotalCL.Size = new System.Drawing.Size(0, 18);
            this.lblTotalCL.TabIndex = 360;
            // 
            // lblCLExp
            // 
            this.lblCLExp.AutoSize = true;
            this.lblCLExp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCLExp.ForeColor = System.Drawing.Color.Red;
            this.lblCLExp.Location = new System.Drawing.Point(1096, 352);
            this.lblCLExp.Name = "lblCLExp";
            this.lblCLExp.Size = new System.Drawing.Size(0, 18);
            this.lblCLExp.TabIndex = 361;
            // 
            // lblCLRemains
            // 
            this.lblCLRemains.AutoSize = true;
            this.lblCLRemains.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCLRemains.ForeColor = System.Drawing.Color.Red;
            this.lblCLRemains.Location = new System.Drawing.Point(1102, 383);
            this.lblCLRemains.Name = "lblCLRemains";
            this.lblCLRemains.Size = new System.Drawing.Size(0, 18);
            this.lblCLRemains.TabIndex = 362;
            // 
            // lblTotaldays
            // 
            this.lblTotaldays.AutoSize = true;
            this.lblTotaldays.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaldays.ForeColor = System.Drawing.Color.Red;
            this.lblTotaldays.Location = new System.Drawing.Point(768, 383);
            this.lblTotaldays.Name = "lblTotaldays";
            this.lblTotaldays.Size = new System.Drawing.Size(0, 18);
            this.lblTotaldays.TabIndex = 363;
            // 
            // btnApproved
            // 
            this.btnApproved.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.Location = new System.Drawing.Point(693, 489);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(126, 32);
            this.btnApproved.TabIndex = 366;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(842, 489);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(126, 32);
            this.btnReject.TabIndex = 367;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnOnHold
            // 
            this.btnOnHold.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnHold.Location = new System.Drawing.Point(992, 489);
            this.btnOnHold.Name = "btnOnHold";
            this.btnOnHold.Size = new System.Drawing.Size(126, 32);
            this.btnOnHold.TabIndex = 368;
            this.btnOnHold.Text = "On hold";
            this.btnOnHold.UseVisualStyleBackColor = true;
            // 
            // frmLeaveManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 599);
            this.Controls.Add(this.btnOnHold);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.lblTotaldays);
            this.Controls.Add(this.lblCLRemains);
            this.Controls.Add(this.lblCLExp);
            this.Controls.Add(this.lblTotalCL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDateto);
            this.Controls.Add(this.lblDatefrm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApplication);
            this.Controls.Add(this.txtPurposeOfLeave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLeaveManagement";
            this.Text = "Leave Management";
            this.Load += new System.EventHandler(this.frmLeaveManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmployee;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtApplication;
        private System.Windows.Forms.TextBox txtPurposeOfLeave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDateto;
        private System.Windows.Forms.Label lblDatefrm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalCL;
        private System.Windows.Forms.Label lblCLExp;
        private System.Windows.Forms.Label lblCLRemains;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datefrm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTotaldays;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnOnHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn LDecision;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOO;
    }
}