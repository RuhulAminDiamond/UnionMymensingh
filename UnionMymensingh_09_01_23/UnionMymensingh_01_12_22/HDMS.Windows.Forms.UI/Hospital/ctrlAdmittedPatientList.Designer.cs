namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlAdmittedPatientList
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
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.btnConsultancyDetails = new System.Windows.Forms.Button();
            this.btnMedicidetails = new System.Windows.Forms.Button();
            this.btnInvestigationdetails = new System.Windows.Forms.Button();
            this.txtSearchByAddress = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByMobile = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByAssignDoc = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtAdmId = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPatient
            // 
            this.pnlPatient.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlPatient.Controls.Add(this.btnConsultancyDetails);
            this.pnlPatient.Controls.Add(this.btnMedicidetails);
            this.pnlPatient.Controls.Add(this.btnInvestigationdetails);
            this.pnlPatient.Controls.Add(this.txtSearchByAddress);
            this.pnlPatient.Controls.Add(this.txtSearchByMobile);
            this.pnlPatient.Controls.Add(this.txtSearchByAssignDoc);
            this.pnlPatient.Controls.Add(this.txtName);
            this.pnlPatient.Controls.Add(this.txtSearchByCabin);
            this.pnlPatient.Controls.Add(this.txtAdmId);
            this.pnlPatient.Controls.Add(this.label26);
            this.pnlPatient.Controls.Add(this.lblTotalPatient);
            this.pnlPatient.Controls.Add(this.dgPatient);
            this.pnlPatient.Controls.Add(this.cmbDept);
            this.pnlPatient.Controls.Add(this.label25);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPatient.Location = new System.Drawing.Point(0, 0);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(1404, 701);
            this.pnlPatient.TabIndex = 10022;
            this.pnlPatient.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPatient_Paint);
            // 
            // btnConsultancyDetails
            // 
            this.btnConsultancyDetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultancyDetails.Location = new System.Drawing.Point(860, 622);
            this.btnConsultancyDetails.Name = "btnConsultancyDetails";
            this.btnConsultancyDetails.Size = new System.Drawing.Size(164, 30);
            this.btnConsultancyDetails.TabIndex = 10039;
            this.btnConsultancyDetails.Text = "Consultancy Details";
            this.btnConsultancyDetails.UseVisualStyleBackColor = true;
            this.btnConsultancyDetails.Click += new System.EventHandler(this.btnConsultancyDetails_Click);
            // 
            // btnMedicidetails
            // 
            this.btnMedicidetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicidetails.Location = new System.Drawing.Point(673, 623);
            this.btnMedicidetails.Name = "btnMedicidetails";
            this.btnMedicidetails.Size = new System.Drawing.Size(123, 30);
            this.btnMedicidetails.TabIndex = 10038;
            this.btnMedicidetails.Text = "Medicine Details";
            this.btnMedicidetails.UseVisualStyleBackColor = true;
            this.btnMedicidetails.Click += new System.EventHandler(this.btnMedicidetails_Click);
            // 
            // btnInvestigationdetails
            // 
            this.btnInvestigationdetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvestigationdetails.Location = new System.Drawing.Point(430, 621);
            this.btnInvestigationdetails.Name = "btnInvestigationdetails";
            this.btnInvestigationdetails.Size = new System.Drawing.Size(149, 32);
            this.btnInvestigationdetails.TabIndex = 10037;
            this.btnInvestigationdetails.Text = "Investigation Details";
            this.btnInvestigationdetails.UseVisualStyleBackColor = true;
            this.btnInvestigationdetails.Click += new System.EventHandler(this.btnInvestigationdetails_Click);
            // 
            // txtSearchByAddress
            // 
            this.txtSearchByAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByAddress.Location = new System.Drawing.Point(875, 61);
            this.txtSearchByAddress.Name = "txtSearchByAddress";
            this.txtSearchByAddress.PlaceHolderText = "Search by Address";
            this.txtSearchByAddress.Size = new System.Drawing.Size(443, 23);
            this.txtSearchByAddress.TabIndex = 10035;
            this.txtSearchByAddress.Text = "Search by Address";
            this.txtSearchByAddress.TextChanged += new System.EventHandler(this.txtSearchByAddress_TextChanged);
            // 
            // txtSearchByMobile
            // 
            this.txtSearchByMobile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByMobile.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByMobile.Location = new System.Drawing.Point(710, 61);
            this.txtSearchByMobile.Name = "txtSearchByMobile";
            this.txtSearchByMobile.PlaceHolderText = "Search by Mobile No";
            this.txtSearchByMobile.Size = new System.Drawing.Size(147, 23);
            this.txtSearchByMobile.TabIndex = 10034;
            this.txtSearchByMobile.Text = "Search by Mobile No";
            this.txtSearchByMobile.TextChanged += new System.EventHandler(this.txtSearchByMobile_TextChanged);
            // 
            // txtSearchByAssignDoc
            // 
            this.txtSearchByAssignDoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByAssignDoc.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByAssignDoc.Location = new System.Drawing.Point(465, 62);
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
            this.txtName.Location = new System.Drawing.Point(101, 61);
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
            this.txtSearchByCabin.Location = new System.Drawing.Point(307, 61);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(144, 23);
            this.txtSearchByCabin.TabIndex = 10031;
            this.txtSearchByCabin.Text = "Search by cabin";
            // 
            // txtAdmId
            // 
            this.txtAdmId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtAdmId.ForeColor = System.Drawing.Color.Gray;
            this.txtAdmId.Location = new System.Drawing.Point(20, 61);
            this.txtAdmId.Name = "txtAdmId";
            this.txtAdmId.PlaceHolderText = "By Adm. Id";
            this.txtAdmId.Size = new System.Drawing.Size(71, 23);
            this.txtAdmId.TabIndex = 10032;
            this.txtAdmId.Text = "By Adm. Id";
            this.txtAdmId.TextChanged += new System.EventHandler(this.txtAdmId_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(17, 623);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 18);
            this.label26.TabIndex = 10025;
            this.label26.Text = "Total Patient : ";
            // 
            // lblTotalPatient
            // 
            this.lblTotalPatient.AutoSize = true;
            this.lblTotalPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatient.Location = new System.Drawing.Point(124, 623);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPatient.TabIndex = 10024;
            // 
            // dgPatient
            // 
            this.dgPatient.AllowUserToAddRows = false;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Time,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Phone,
            this.Address,
            this.Location});
            this.dgPatient.Location = new System.Drawing.Point(15, 98);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.RowHeadersWidth = 51;
            this.dgPatient.Size = new System.Drawing.Size(1303, 518);
            this.dgPatient.TabIndex = 10023;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Adm. No";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "AdmTime";
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Name";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Bed/Cabin";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Assigned Doctor";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 250;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.Width = 120;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 250;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.Width = 125;
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(174, 29);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(237, 26);
            this.cmbDept.TabIndex = 10021;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(21, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(146, 18);
            this.label25.TabIndex = 10020;
            this.label25.Text = "Selected Department";
            // 
            // ctrlAdmittedPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPatient);
            this.Name = "ctrlAdmittedPatientList";
            this.Size = new System.Drawing.Size(1404, 701);
            this.Load += new System.EventHandler(this.ctrlAdmittedPatientList_Load);
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPatient;
        private Controls.PlaceHolderTextBox txtSearchByAddress;
        private Controls.PlaceHolderTextBox txtSearchByMobile;
        private Controls.PlaceHolderTextBox txtSearchByAssignDoc;
        private Controls.PlaceHolderTextBox txtName;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private Controls.PlaceHolderTextBox txtAdmId;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnConsultancyDetails;
        private System.Windows.Forms.Button btnMedicidetails;
        private System.Windows.Forms.Button btnInvestigationdetails;
    }
}
