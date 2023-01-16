namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlDepartmentalDischargedPatientList
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
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.cmdShow = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label26 = new System.Windows.Forms.Label();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.btnInvestigationdetails = new System.Windows.Forms.Button();
            this.btnMedicidetails = new System.Windows.Forms.Button();
            this.btnConsultancyDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPatient
            // 
            this.dgPatient.AllowUserToAddRows = false;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column3,
            this.Adime,
            this.Column5,
            this.DTime,
            this.Column6,
            this.Phone,
            this.Address,
            this.Location,
            this.ServiceCharge,
            this.Discount,
            this.GTotal,
            this.Paid,
            this.Due,
            this.AssignDoctor,
            this.Remark});
            this.dgPatient.Location = new System.Drawing.Point(13, 60);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(1338, 518);
            this.dgPatient.TabIndex = 10024;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(573, 25);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(237, 26);
            this.cmbDept.TabIndex = 10026;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Unicode MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(420, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(147, 20);
            this.label25.TabIndex = 10025;
            this.label25.Text = "Selected Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 10030;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 10029;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(261, 25);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 10028;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(63, 24);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 10027;
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(836, 19);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(125, 33);
            this.cmdShow.TabIndex = 10031;
            this.cmdShow.Text = "Refresh List";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BillNo";
            this.Column2.HeaderText = "Bill No";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Name";
            this.Column4.HeaderText = "Name";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "AdmDate";
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Adime
            // 
            this.Adime.DataPropertyName = "AdmTime";
            this.Adime.HeaderText = "Ad.Time";
            this.Adime.Name = "Adime";
            this.Adime.Width = 80;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DischargeDate";
            this.Column5.HeaderText = "D. Date";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // DTime
            // 
            this.DTime.DataPropertyName = "DischargeTime";
            this.DTime.HeaderText = "D.Time";
            this.DTime.Name = "DTime";
            this.DTime.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "HospitalBill";
            this.Column6.HeaderText = "Hp. Bill";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "MedicineBill";
            this.Phone.HeaderText = "Med. Bill";
            this.Phone.Name = "Phone";
            this.Phone.Width = 80;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "InvestigationBill";
            this.Address.HeaderText = "Invest. Bill";
            this.Address.Name = "Address";
            this.Address.Width = 80;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "TotalBill";
            this.Location.HeaderText = "Total";
            this.Location.Name = "Location";
            this.Location.Width = 80;
            // 
            // ServiceCharge
            // 
            this.ServiceCharge.DataPropertyName = "ServiceCharge";
            this.ServiceCharge.HeaderText = "Service Charge";
            this.ServiceCharge.Name = "ServiceCharge";
            this.ServiceCharge.Width = 110;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.Width = 80;
            // 
            // GTotal
            // 
            this.GTotal.DataPropertyName = "GTotal";
            this.GTotal.HeaderText = "G.Total";
            this.GTotal.Name = "GTotal";
            this.GTotal.Width = 80;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "PaidAmount";
            this.Paid.HeaderText = "Paid Amnt.";
            this.Paid.Name = "Paid";
            this.Paid.Width = 90;
            // 
            // Due
            // 
            this.Due.DataPropertyName = "DueAmount";
            this.Due.HeaderText = "Due Amnt.";
            this.Due.Name = "Due";
            // 
            // AssignDoctor
            // 
            this.AssignDoctor.DataPropertyName = "AssignDoc";
            this.AssignDoctor.HeaderText = "Assign Doctor";
            this.AssignDoctor.Name = "AssignDoctor";
            this.AssignDoctor.Width = 230;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remarks";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(15, 596);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 18);
            this.label26.TabIndex = 10033;
            this.label26.Text = "Total Patient : ";
            // 
            // lblTotalPatient
            // 
            this.lblTotalPatient.AutoSize = true;
            this.lblTotalPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatient.Location = new System.Drawing.Point(122, 596);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPatient.TabIndex = 10032;
            // 
            // btnInvestigationdetails
            // 
            this.btnInvestigationdetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvestigationdetails.Location = new System.Drawing.Point(343, 589);
            this.btnInvestigationdetails.Name = "btnInvestigationdetails";
            this.btnInvestigationdetails.Size = new System.Drawing.Size(149, 32);
            this.btnInvestigationdetails.TabIndex = 10034;
            this.btnInvestigationdetails.Text = "Investigation Details";
            this.btnInvestigationdetails.UseVisualStyleBackColor = true;
            this.btnInvestigationdetails.Click += new System.EventHandler(this.btnInvestigationdetails_Click);
            // 
            // btnMedicidetails
            // 
            this.btnMedicidetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicidetails.Location = new System.Drawing.Point(586, 591);
            this.btnMedicidetails.Name = "btnMedicidetails";
            this.btnMedicidetails.Size = new System.Drawing.Size(123, 30);
            this.btnMedicidetails.TabIndex = 10035;
            this.btnMedicidetails.Text = "Medicine Details";
            this.btnMedicidetails.UseVisualStyleBackColor = true;
            this.btnMedicidetails.Click += new System.EventHandler(this.btnMedicidetails_Click);
            // 
            // btnConsultancyDetails
            // 
            this.btnConsultancyDetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultancyDetails.Location = new System.Drawing.Point(773, 590);
            this.btnConsultancyDetails.Name = "btnConsultancyDetails";
            this.btnConsultancyDetails.Size = new System.Drawing.Size(164, 30);
            this.btnConsultancyDetails.TabIndex = 10036;
            this.btnConsultancyDetails.Text = "Consultancy Details";
            this.btnConsultancyDetails.UseVisualStyleBackColor = true;
            this.btnConsultancyDetails.Click += new System.EventHandler(this.btnConsultancyDetails_Click);
            // 
            // ctrlDepartmentalDischargedPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnConsultancyDetails);
            this.Controls.Add(this.btnMedicidetails);
            this.Controls.Add(this.btnInvestigationdetails);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblTotalPatient);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.dgPatient);
            this.Name = "ctrlDepartmentalDischargedPatientList";
            this.Size = new System.Drawing.Size(1378, 643);
            this.Load += new System.EventHandler(this.ctrlDepartmentalDischargedPatientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.Button btnInvestigationdetails;
        private System.Windows.Forms.Button btnMedicidetails;
        private System.Windows.Forms.Button btnConsultancyDetails;
    }
}
