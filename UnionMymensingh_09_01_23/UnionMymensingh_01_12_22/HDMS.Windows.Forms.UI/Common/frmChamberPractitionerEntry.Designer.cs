namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmChamberPractitionerEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChamberPractitionerEntry));
            this.btnClose = new System.Windows.Forms.Button();
            this.dgCP = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speciality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdentityLine6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity5 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdentityLine5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIdentityLine4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdentityLine3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdentityLine2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdentityLine1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameFontSize = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbSpeciality = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddSpeciality = new System.Windows.Forms.Button();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPatientQuota = new System.Windows.Forms.TextBox();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dgOffDay = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyOffDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbWeekDay = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpOffDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsMonthlyOffDay = new System.Windows.Forms.CheckBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.dtpfrmTime = new System.Windows.Forms.DateTimePicker();
            this.dtptoTime = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.sgnbox = new System.Windows.Forms.PictureBox();
            this.lnkBtnUploadSignature = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnClearSignature = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOffDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sgnbox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(277, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 36);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgCP
            // 
            this.dgCP.AllowUserToAddRows = false;
            this.dgCP.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgCP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CName,
            this.Speciality,
            this.DIdentityLine1,
            this.DIdentityLine2});
            this.dgCP.Location = new System.Drawing.Point(621, 276);
            this.dgCP.Name = "dgCP";
            this.dgCP.Size = new System.Drawing.Size(548, 248);
            this.dgCP.TabIndex = 94;
            this.dgCP.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgCP_RowHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "RCId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // CName
            // 
            this.CName.DataPropertyName = "Name";
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.Width = 280;
            // 
            // Speciality
            // 
            this.Speciality.HeaderText = "Speciality";
            this.Speciality.Name = "Speciality";
            this.Speciality.Width = 180;
            // 
            // DIdentityLine1
            // 
            this.DIdentityLine1.DataPropertyName = "DIdentityLine1";
            this.DIdentityLine1.HeaderText = "Identity Line1";
            this.DIdentityLine1.Name = "DIdentityLine1";
            this.DIdentityLine1.Width = 200;
            // 
            // DIdentityLine2
            // 
            this.DIdentityLine2.DataPropertyName = "DIdentityLine2";
            this.DIdentityLine2.HeaderText = "Identity Line2";
            this.DIdentityLine2.Name = "DIdentityLine2";
            this.DIdentityLine2.Width = 200;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(457, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 93;
            this.label10.Text = "Font Size";
            // 
            // txtFontSizeforIdentity6
            // 
            this.txtFontSizeforIdentity6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity6.Location = new System.Drawing.Point(527, 296);
            this.txtFontSizeforIdentity6.Name = "txtFontSizeforIdentity6";
            this.txtFontSizeforIdentity6.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity6.TabIndex = 92;
            this.txtFontSizeforIdentity6.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(64, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 91;
            this.label11.Text = "Identity-6";
            // 
            // txtIdentityLine6
            // 
            this.txtIdentityLine6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine6.Location = new System.Drawing.Point(143, 296);
            this.txtIdentityLine6.Name = "txtIdentityLine6";
            this.txtIdentityLine6.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine6.TabIndex = 90;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(456, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 89;
            this.label12.Text = "Font Size";
            // 
            // txtFontSizeforIdentity5
            // 
            this.txtFontSizeforIdentity5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity5.Location = new System.Drawing.Point(526, 253);
            this.txtFontSizeforIdentity5.Name = "txtFontSizeforIdentity5";
            this.txtFontSizeforIdentity5.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity5.TabIndex = 88;
            this.txtFontSizeforIdentity5.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(63, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 87;
            this.label13.Text = "Identity-5";
            // 
            // txtIdentityLine5
            // 
            this.txtIdentityLine5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine5.Location = new System.Drawing.Point(142, 253);
            this.txtIdentityLine5.Name = "txtIdentityLine5";
            this.txtIdentityLine5.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine5.TabIndex = 86;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(456, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 85;
            this.label14.Text = "Font Size";
            // 
            // txtFontSizeforIdentity4
            // 
            this.txtFontSizeforIdentity4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity4.Location = new System.Drawing.Point(526, 208);
            this.txtFontSizeforIdentity4.Name = "txtFontSizeforIdentity4";
            this.txtFontSizeforIdentity4.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity4.TabIndex = 84;
            this.txtFontSizeforIdentity4.Text = "10";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(63, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 83;
            this.label15.Text = "Identity-4";
            // 
            // txtIdentityLine4
            // 
            this.txtIdentityLine4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine4.Location = new System.Drawing.Point(142, 208);
            this.txtIdentityLine4.Name = "txtIdentityLine4";
            this.txtIdentityLine4.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine4.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(457, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "Font Size";
            // 
            // txtFontSizeforIdentity3
            // 
            this.txtFontSizeforIdentity3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity3.Location = new System.Drawing.Point(527, 163);
            this.txtFontSizeforIdentity3.Name = "txtFontSizeforIdentity3";
            this.txtFontSizeforIdentity3.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity3.TabIndex = 80;
            this.txtFontSizeforIdentity3.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 79;
            this.label9.Text = "Identity-3";
            // 
            // txtIdentityLine3
            // 
            this.txtIdentityLine3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine3.Location = new System.Drawing.Point(143, 163);
            this.txtIdentityLine3.Name = "txtIdentityLine3";
            this.txtIdentityLine3.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine3.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(456, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 77;
            this.label6.Text = "Font Size";
            // 
            // txtFontSizeforIdentity2
            // 
            this.txtFontSizeforIdentity2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity2.Location = new System.Drawing.Point(526, 120);
            this.txtFontSizeforIdentity2.Name = "txtFontSizeforIdentity2";
            this.txtFontSizeforIdentity2.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity2.TabIndex = 76;
            this.txtFontSizeforIdentity2.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 75;
            this.label7.Text = "Identity-2";
            // 
            // txtIdentityLine2
            // 
            this.txtIdentityLine2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine2.Location = new System.Drawing.Point(142, 120);
            this.txtIdentityLine2.Name = "txtIdentityLine2";
            this.txtIdentityLine2.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine2.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(456, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Font Size";
            // 
            // txtFontSizeforIdentity1
            // 
            this.txtFontSizeforIdentity1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity1.Location = new System.Drawing.Point(526, 75);
            this.txtFontSizeforIdentity1.Name = "txtFontSizeforIdentity1";
            this.txtFontSizeforIdentity1.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity1.TabIndex = 72;
            this.txtFontSizeforIdentity1.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Identity-1";
            // 
            // txtIdentityLine1
            // 
            this.txtIdentityLine1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine1.Location = new System.Drawing.Point(142, 75);
            this.txtIdentityLine1.Name = "txtIdentityLine1";
            this.txtIdentityLine1.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine1.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(456, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Font Size";
            // 
            // txtNameFontSize
            // 
            this.txtNameFontSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameFontSize.Location = new System.Drawing.Point(526, 33);
            this.txtNameFontSize.Name = "txtNameFontSize";
            this.txtNameFontSize.Size = new System.Drawing.Size(76, 27);
            this.txtNameFontSize.TabIndex = 68;
            this.txtNameFontSize.Text = "10";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(142, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(297, 27);
            this.txtName.TabIndex = 67;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(141, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 36);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbSpeciality
            // 
            this.cmbSpeciality.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpeciality.FormattingEnabled = true;
            this.cmbSpeciality.Location = new System.Drawing.Point(146, 339);
            this.cmbSpeciality.Name = "cmbSpeciality";
            this.cmbSpeciality.Size = new System.Drawing.Size(293, 28);
            this.cmbSpeciality.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 103;
            this.label5.Text = "Select Speciality";
            // 
            // btnAddSpeciality
            // 
            this.btnAddSpeciality.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSpeciality.Location = new System.Drawing.Point(445, 339);
            this.btnAddSpeciality.Name = "btnAddSpeciality";
            this.btnAddSpeciality.Size = new System.Drawing.Size(25, 28);
            this.btnAddSpeciality.TabIndex = 104;
            this.btnAddSpeciality.Text = "+";
            this.btnAddSpeciality.UseVisualStyleBackColor = true;
            this.btnAddSpeciality.Click += new System.EventHandler(this.btnAddSpeciality_Click);
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(985, 99);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(603, 474);
            this.ctlDoctorSearch.TabIndex = 10019;
            this.ctlDoctorSearch.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(42, 405);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 20);
            this.label16.TabIndex = 10025;
            this.label16.Text = "Practice Time";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(41, 373);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 10024;
            this.label17.Text = "Patient Quota";
            // 
            // txtPatientQuota
            // 
            this.txtPatientQuota.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientQuota.Location = new System.Drawing.Point(146, 373);
            this.txtPatientQuota.Name = "txtPatientQuota";
            this.txtPatientQuota.Size = new System.Drawing.Size(113, 27);
            this.txtPatientQuota.TabIndex = 10020;
            // 
            // cmbstatus
            // 
            this.cmbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbstatus.Location = new System.Drawing.Point(143, 472);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(123, 26);
            this.cmbstatus.TabIndex = 10022;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(85, 474);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 10023;
            this.label18.Text = "Status";
            // 
            // dgOffDay
            // 
            this.dgOffDay.AllowUserToAddRows = false;
            this.dgOffDay.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgOffDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOffDay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.MonthlyOffDate});
            this.dgOffDay.Location = new System.Drawing.Point(622, 59);
            this.dgOffDay.Name = "dgOffDay";
            this.dgOffDay.Size = new System.Drawing.Size(509, 202);
            this.dgOffDay.TabIndex = 10026;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Weekly Off Day";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // MonthlyOffDate
            // 
            this.MonthlyOffDate.HeaderText = "Monthly Off Date";
            this.MonthlyOffDate.Name = "MonthlyOffDate";
            this.MonthlyOffDate.Width = 180;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(618, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 18);
            this.label19.TabIndex = 10028;
            this.label19.Text = "Select Week Day";
            // 
            // cmbWeekDay
            // 
            this.cmbWeekDay.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWeekDay.FormattingEnabled = true;
            this.cmbWeekDay.Items.AddRange(new object[] {
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"});
            this.cmbWeekDay.Location = new System.Drawing.Point(622, 25);
            this.cmbWeekDay.Name = "cmbWeekDay";
            this.cmbWeekDay.Size = new System.Drawing.Size(170, 26);
            this.cmbWeekDay.TabIndex = 10027;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(904, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 18);
            this.label20.TabIndex = 10030;
            this.label20.Text = "Select Off Date";
            // 
            // dtpOffDate
            // 
            this.dtpOffDate.Enabled = false;
            this.dtpOffDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOffDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOffDate.Location = new System.Drawing.Point(907, 27);
            this.dtpOffDate.Name = "dtpOffDate";
            this.dtpOffDate.Size = new System.Drawing.Size(119, 26);
            this.dtpOffDate.TabIndex = 10031;
            // 
            // chkIsMonthlyOffDay
            // 
            this.chkIsMonthlyOffDay.AutoSize = true;
            this.chkIsMonthlyOffDay.Location = new System.Drawing.Point(808, 30);
            this.chkIsMonthlyOffDay.Name = "chkIsMonthlyOffDay";
            this.chkIsMonthlyOffDay.Size = new System.Drawing.Size(80, 17);
            this.chkIsMonthlyOffDay.TabIndex = 10032;
            this.chkIsMonthlyOffDay.Text = "Is Monthly?";
            this.chkIsMonthlyOffDay.UseVisualStyleBackColor = true;
            this.chkIsMonthlyOffDay.CheckedChanged += new System.EventHandler(this.chkIsMonthlyOffDay_CheckedChanged);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToList.Location = new System.Drawing.Point(1042, 25);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(89, 29);
            this.btnAddToList.TabIndex = 10033;
            this.btnAddToList.Text = "Add to List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // dtpfrmTime
            // 
            this.dtpfrmTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrmTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpfrmTime.Location = new System.Drawing.Point(146, 405);
            this.dtpfrmTime.Name = "dtpfrmTime";
            this.dtpfrmTime.Size = new System.Drawing.Size(98, 27);
            this.dtpfrmTime.TabIndex = 10034;
            // 
            // dtptoTime
            // 
            this.dtptoTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptoTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtptoTime.Location = new System.Drawing.Point(146, 437);
            this.dtptoTime.Name = "dtptoTime";
            this.dtptoTime.Size = new System.Drawing.Size(101, 27);
            this.dtptoTime.TabIndex = 10035;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(117, 442);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 20);
            this.label21.TabIndex = 10036;
            this.label21.Text = "to";
            // 
            // sgnbox
            // 
            this.sgnbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sgnbox.Location = new System.Drawing.Point(328, 373);
            this.sgnbox.Name = "sgnbox";
            this.sgnbox.Size = new System.Drawing.Size(275, 105);
            this.sgnbox.TabIndex = 10037;
            this.sgnbox.TabStop = false;
            // 
            // lnkBtnUploadSignature
            // 
            this.lnkBtnUploadSignature.AutoSize = true;
            this.lnkBtnUploadSignature.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBtnUploadSignature.Location = new System.Drawing.Point(361, 481);
            this.lnkBtnUploadSignature.Name = "lnkBtnUploadSignature";
            this.lnkBtnUploadSignature.Size = new System.Drawing.Size(109, 17);
            this.lnkBtnUploadSignature.TabIndex = 10038;
            this.lnkBtnUploadSignature.TabStop = true;
            this.lnkBtnUploadSignature.Text = "Upload Signature";
            this.lnkBtnUploadSignature.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBtnUploadSignature_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnClearSignature
            // 
            this.btnClearSignature.AutoSize = true;
            this.btnClearSignature.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSignature.Location = new System.Drawing.Point(493, 481);
            this.btnClearSignature.Name = "btnClearSignature";
            this.btnClearSignature.Size = new System.Drawing.Size(99, 17);
            this.btnClearSignature.TabIndex = 10039;
            this.btnClearSignature.TabStop = true;
            this.btnClearSignature.Text = "Clear Signature";
            this.btnClearSignature.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClearSignature_LinkClicked);
            // 
            // frmChamberPractitionerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 651);
            this.Controls.Add(this.btnClearSignature);
            this.Controls.Add(this.lnkBtnUploadSignature);
            this.Controls.Add(this.sgnbox);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtptoTime);
            this.Controls.Add(this.dtpfrmTime);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.chkIsMonthlyOffDay);
            this.Controls.Add(this.dtpOffDate);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbWeekDay);
            this.Controls.Add(this.dgOffDay);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtPatientQuota);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnAddSpeciality);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSpeciality);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgCP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFontSizeforIdentity6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIdentityLine6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFontSizeforIdentity5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtIdentityLine5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtFontSizeforIdentity4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtIdentityLine4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFontSizeforIdentity3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdentityLine3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFontSizeforIdentity2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdentityLine2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFontSizeforIdentity1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdentityLine1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameFontSize);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChamberPractitionerEntry";
            this.Text = "Chamber Practitioner Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChamberPractitionerEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOffDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sgnbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgCP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdentityLine6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdentityLine5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIdentityLine4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdentityLine3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdentityLine2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentityLine1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameFontSize;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSpeciality;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddSpeciality;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speciality;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPatientQuota;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgOffDay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbWeekDay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpOffDate;
        private System.Windows.Forms.CheckBox chkIsMonthlyOffDay;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.DateTimePicker dtpfrmTime;
        private System.Windows.Forms.DateTimePicker dtptoTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthlyOffDate;
        private System.Windows.Forms.PictureBox sgnbox;
        private System.Windows.Forms.LinkLabel lnkBtnUploadSignature;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel btnClearSignature;
    }
}