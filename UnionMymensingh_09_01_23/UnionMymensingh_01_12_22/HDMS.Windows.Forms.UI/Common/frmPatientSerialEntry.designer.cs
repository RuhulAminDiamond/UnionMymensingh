namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmPatientSerialEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientSerialEntry));
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.TV = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.gvPList = new System.Windows.Forms.DataGridView();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.lblSerialFor = new System.Windows.Forms.Label();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPQuota = new System.Windows.Forms.Label();
            this.lblBooked = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNameOfWeekday = new System.Windows.Forms.Label();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.cmbVisitType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMarketingAgent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtDateofBirth = new System.Windows.Forms.TextBox();
            this.lblEntrtyDate = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblYears = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.cmbStartAmPm = new System.Windows.Forms.ComboBox();
            this.cmbEndtAmPm = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPatientSearchMobile = new System.Windows.Forms.TextBox();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.ctrlPatientSerialBooking1 = new HDMS.Windows.Forms.UI.Controls.ctrlPatientSerialBooking();
            this.ctrlMarketingAgentSearchControl = new HDMS.Windows.Forms.UI.Controls.MarketingAgentSearchControl();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDailyId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvPList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCellPhone.Location = new System.Drawing.Point(1180, 156);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(178, 29);
            this.txtCellPhone.TabIndex = 6;
            this.txtCellPhone.TextChanged += new System.EventHandler(this.txtCellPhone_TextChanged);
            this.txtCellPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCellPhone_KeyPress);
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblCellPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellPhone.Location = new System.Drawing.Point(1087, 159);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(87, 20);
            this.lblCellPhone.TabIndex = 36;
            this.lblCellPhone.Text = "Mobile No :";
            this.lblCellPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCellPhone.Click += new System.EventHandler(this.lblCellPhone_Click);
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "None"});
            this.cmbGender.Location = new System.Drawing.Point(1180, 124);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(178, 29);
            this.cmbGender.TabIndex = 3;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(1135, 128);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(39, 20);
            this.lblGender.TabIndex = 35;
            this.lblGender.Text = "Sex :";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGender.Click += new System.EventHandler(this.lblGender_Click);
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAge.Location = new System.Drawing.Point(1209, -29);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(118, 29);
            this.txtAge.TabIndex = 28;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(1174, -24);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(36, 20);
            this.lblAge.TabIndex = 34;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(628, 123);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(425, 29);
            this.txtPatientName.TabIndex = 2;
            this.txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientName_KeyPress);
            this.txtPatientName.Leave += new System.EventHandler(this.txtPatientName_Leave);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(405, 128);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(105, 20);
            this.lblPatientName.TabIndex = 33;
            this.lblPatientName.Text = "Patient Name :";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPatientName.Click += new System.EventHandler(this.lblPatientName_Click);
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(0, 9);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(99, 20);
            this.lblRefBy.TabIndex = 30;
            this.lblRefBy.Text = "Select Doctor";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRefBy.Click += new System.EventHandler(this.lblRefBy_Click);
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.SystemColors.Window;
            this.txtDoctor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor.Location = new System.Drawing.Point(517, 85);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(841, 29);
            this.txtDoctor.TabIndex = 32;
            // 
            // dtp
            // 
            this.dtp.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(517, 55);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(126, 24);
            this.dtp.TabIndex = 37;
            this.dtp.TabStop = false;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(457, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Date :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(961, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TV
            // 
            this.TV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.TV.Location = new System.Drawing.Point(-5, 33);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(390, 666);
            this.TV.TabIndex = 45;
            this.TV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Doctor Name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gvPList
            // 
            this.gvPList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNo,
            this.PatientName,
            this.VisitType,
            this.MobileNo,
            this.StartTime,
            this.EndTime,
            this.Address,
            this.Remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvPList.Location = new System.Drawing.Point(409, 330);
            this.gvPList.Name = "gvPList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvPList.Size = new System.Drawing.Size(949, 360);
            this.gvPList.TabIndex = 47;
            this.gvPList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvPList_RowHeaderMouseClick);
            // 
            // SerialNo
            // 
            this.SerialNo.DataPropertyName = "SerialNo";
            this.SerialNo.HeaderText = "SI NO";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Width = 60;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.HeaderText = "Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.Width = 130;
            // 
            // VisitType
            // 
            this.VisitType.HeaderText = "Visit Type";
            this.VisitType.Name = "VisitType";
            this.VisitType.Width = 90;
            // 
            // MobileNo
            // 
            this.MobileNo.DataPropertyName = "MobileNo";
            this.MobileNo.HeaderText = "Mobile No";
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.Width = 110;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "St. Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 70;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "EndTime";
            this.EndTime.Name = "EndTime";
            this.EndTime.Width = 70;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Width = 80;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Manual Serial No :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.ForeColor = System.Drawing.Color.Red;
            this.lblSerialNo.Location = new System.Drawing.Point(804, -55);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(0, 18);
            this.lblSerialNo.TabIndex = 49;
            this.lblSerialNo.Click += new System.EventHandler(this.lblSerialNo_Click);
            // 
            // lblSerialFor
            // 
            this.lblSerialFor.AutoSize = true;
            this.lblSerialFor.BackColor = System.Drawing.Color.Transparent;
            this.lblSerialFor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblSerialFor.Location = new System.Drawing.Point(427, 11);
            this.lblSerialFor.Name = "lblSerialFor";
            this.lblSerialFor.Size = new System.Drawing.Size(0, 20);
            this.lblSerialFor.TabIndex = 50;
            this.lblSerialFor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdPrint
            // 
            this.cmdPrint.BackColor = System.Drawing.Color.White;
            this.cmdPrint.FlatAppearance.BorderSize = 0;
            this.cmdPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmdPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Location = new System.Drawing.Point(1057, 284);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(76, 40);
            this.cmdPrint.TabIndex = 1411111;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Patient Quota :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPQuota
            // 
            this.lblPQuota.AutoSize = true;
            this.lblPQuota.BackColor = System.Drawing.Color.Transparent;
            this.lblPQuota.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQuota.ForeColor = System.Drawing.Color.Red;
            this.lblPQuota.Location = new System.Drawing.Point(533, 307);
            this.lblPQuota.Name = "lblPQuota";
            this.lblPQuota.Size = new System.Drawing.Size(0, 18);
            this.lblPQuota.TabIndex = 53;
            this.lblPQuota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBooked
            // 
            this.lblBooked.AutoSize = true;
            this.lblBooked.BackColor = System.Drawing.Color.Transparent;
            this.lblBooked.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooked.ForeColor = System.Drawing.Color.Red;
            this.lblBooked.Location = new System.Drawing.Point(-744, 307);
            this.lblBooked.Name = "lblBooked";
            this.lblBooked.Size = new System.Drawing.Size(0, 18);
            this.lblBooked.TabIndex = 55;
            this.lblBooked.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailable.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.ForeColor = System.Drawing.Color.Red;
            this.lblAvailable.Location = new System.Drawing.Point(718, 307);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(0, 18);
            this.lblAvailable.TabIndex = 57;
            this.lblAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(637, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Available :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1139, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 40);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNameOfWeekday
            // 
            this.lblNameOfWeekday.AutoSize = true;
            this.lblNameOfWeekday.BackColor = System.Drawing.Color.Transparent;
            this.lblNameOfWeekday.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfWeekday.ForeColor = System.Drawing.Color.Gold;
            this.lblNameOfWeekday.Location = new System.Drawing.Point(521, 33);
            this.lblNameOfWeekday.Name = "lblNameOfWeekday";
            this.lblNameOfWeekday.Size = new System.Drawing.Size(0, 20);
            this.lblNameOfWeekday.TabIndex = 59;
            this.lblNameOfWeekday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailability.ForeColor = System.Drawing.Color.Yellow;
            this.lblAvailability.Location = new System.Drawing.Point(665, 33);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(0, 18);
            this.lblAvailability.TabIndex = 60;
            // 
            // cmbVisitType
            // 
            this.cmbVisitType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbVisitType.FormattingEnabled = true;
            this.cmbVisitType.Items.AddRange(new object[] {
            "New Patient",
            "Old Patient",
            "Report Opinion"});
            this.cmbVisitType.Location = new System.Drawing.Point(517, 188);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(148, 29);
            this.cmbVisitType.TabIndex = 7;
            this.cmbVisitType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbVisitType_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(432, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Visit Type :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMarketingAgent
            // 
            this.txtMarketingAgent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMarketingAgent.Location = new System.Drawing.Point(1143, -30);
            this.txtMarketingAgent.Name = "txtMarketingAgent";
            this.txtMarketingAgent.Size = new System.Drawing.Size(218, 29);
            this.txtMarketingAgent.TabIndex = 63;
            this.txtMarketingAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarketingAgent_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1017, -23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Marketing Agent";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(517, 262);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(256, 29);
            this.txtRemarks.TabIndex = 14;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(439, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 66;
            this.label9.Text = "Remarks :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.Color.Transparent;
            this.label89.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(427, 234);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(87, 18);
            this.label89.TabIndex = 11158;
            this.label89.Text = "E-mail Addr :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label89.Click += new System.EventHandler(this.label89_Click);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(517, 230);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailAddress.Size = new System.Drawing.Size(256, 26);
            this.txtEmailAddress.TabIndex = 10;
            this.txtEmailAddress.TextChanged += new System.EventHandler(this.txtEmailAddress_TextChanged);
            this.txtEmailAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmailAddress_KeyPress);
            // 
            // txtDateofBirth
            // 
            this.txtDateofBirth.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateofBirth.Location = new System.Drawing.Point(517, 156);
            this.txtDateofBirth.Margin = new System.Windows.Forms.Padding(2);
            this.txtDateofBirth.Name = "txtDateofBirth";
            this.txtDateofBirth.Size = new System.Drawing.Size(148, 27);
            this.txtDateofBirth.TabIndex = 4;
            this.txtDateofBirth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDateofBirth_KeyPress);
            this.txtDateofBirth.Leave += new System.EventHandler(this.txtDateofBirth_Leave);
            // 
            // lblEntrtyDate
            // 
            this.lblEntrtyDate.AutoSize = true;
            this.lblEntrtyDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrtyDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrtyDate.Location = new System.Drawing.Point(469, 160);
            this.lblEntrtyDate.Name = "lblEntrtyDate";
            this.lblEntrtyDate.Size = new System.Drawing.Size(42, 18);
            this.lblEntrtyDate.TabIndex = 9000002;
            this.lblEntrtyDate.Text = "DOB :";
            this.lblEntrtyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.BackColor = System.Drawing.Color.Transparent;
            this.lblDays.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(960, 163);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(37, 18);
            this.lblDays.TabIndex = 9000010;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.BackColor = System.Drawing.Color.Transparent;
            this.lblMonths.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(843, 165);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(55, 18);
            this.lblMonths.TabIndex = 9000009;
            this.lblMonths.Text = "Months";
            this.lblMonths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYears
            // 
            this.lblYears.AutoSize = true;
            this.lblYears.BackColor = System.Drawing.Color.Transparent;
            this.lblYears.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYears.Location = new System.Drawing.Point(733, 165);
            this.lblYears.Name = "lblYears";
            this.lblYears.Size = new System.Drawing.Size(40, 18);
            this.lblYears.TabIndex = 9000008;
            this.lblYears.Text = "Years";
            this.lblYears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblYears.Click += new System.EventHandler(this.lblYears_Click);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(1003, 159);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(50, 26);
            this.txtDays.TabIndex = 9000006;
            this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // txtMonths
            // 
            this.txtMonths.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonths.Location = new System.Drawing.Point(904, 159);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(50, 26);
            this.txtMonths.TabIndex = 9000005;
            this.txtMonths.TextChanged += new System.EventHandler(this.txtMonths_TextChanged);
            this.txtMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonths_KeyPress);
            // 
            // txtYears
            // 
            this.txtYears.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYears.Location = new System.Drawing.Point(779, 159);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(50, 26);
            this.txtYears.TabIndex = 5;
            this.txtYears.TextChanged += new System.EventHandler(this.txtYears_TextChanged);
            this.txtYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYears_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(819, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 9000011;
            this.label10.Text = "Start Time :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(-1096, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 9000012;
            this.label11.Text = "End Time :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(704, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 9000013;
            this.label12.Text = "Adderss :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddress.Location = new System.Drawing.Point(779, 191);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(274, 29);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1082, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 20);
            this.label13.TabIndex = 9000015;
            this.label13.Text = "Occupation :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOccupation
            // 
            this.txtOccupation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOccupation.Location = new System.Drawing.Point(1180, 191);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(178, 29);
            this.txtOccupation.TabIndex = 9;
            this.txtOccupation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOccupation_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1213, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 40);
            this.btnCancel.TabIndex = 9000016;
            this.btnCancel.Text = "Refresh";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbTitle
            // 
            this.cmbTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.ItemHeight = 19;
            this.cmbTitle.Items.AddRange(new object[] {
            "Mr. ",
            "Ms. "});
            this.cmbTitle.Location = new System.Drawing.Point(516, 123);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(101, 27);
            this.cmbTitle.TabIndex = 1;
            this.cmbTitle.SelectedIndexChanged += new System.EventHandler(this.cmbTitle_SelectedIndexChanged);
            this.cmbTitle.TextChanged += new System.EventHandler(this.cmbTitle_TextChanged);
            this.cmbTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTitle_KeyPress);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStartTime.Location = new System.Drawing.Point(904, 230);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(80, 29);
            this.txtStartTime.TabIndex = 11;
            this.txtStartTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartTime_KeyPress);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEndTime.Location = new System.Drawing.Point(-1180, 230);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(108, 29);
            this.txtEndTime.TabIndex = 13;
            this.txtEndTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndTime_KeyPress);
            // 
            // cmbStartAmPm
            // 
            this.cmbStartAmPm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStartAmPm.FormattingEnabled = true;
            this.cmbStartAmPm.ItemHeight = 21;
            this.cmbStartAmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbStartAmPm.Location = new System.Drawing.Point(990, 230);
            this.cmbStartAmPm.Name = "cmbStartAmPm";
            this.cmbStartAmPm.Size = new System.Drawing.Size(63, 29);
            this.cmbStartAmPm.TabIndex = 12;
            this.cmbStartAmPm.TextChanged += new System.EventHandler(this.cmbStartAmPm_TextChanged);
            this.cmbStartAmPm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStartAmPm_KeyPress);
            // 
            // cmbEndtAmPm
            // 
            this.cmbEndtAmPm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEndtAmPm.FormattingEnabled = true;
            this.cmbEndtAmPm.ItemHeight = 21;
            this.cmbEndtAmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cmbEndtAmPm.Location = new System.Drawing.Point(-1294, 230);
            this.cmbEndtAmPm.Name = "cmbEndtAmPm";
            this.cmbEndtAmPm.Size = new System.Drawing.Size(64, 29);
            this.cmbEndtAmPm.TabIndex = 14;
            this.cmbEndtAmPm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEndtAmPm_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(457, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 9000022;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(1121, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 9000023;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(418, 187);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 20);
            this.label16.TabIndex = 9000024;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(808, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 20);
            this.label17.TabIndex = 9000025;
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(1074, 155);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 20);
            this.label18.TabIndex = 9000026;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(394, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 20);
            this.label19.TabIndex = 9000027;
            this.label19.Text = "*";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(1082, 228);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 20);
            this.label20.TabIndex = 9000028;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(779, 53);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(96, 27);
            this.txtSerialNo.TabIndex = 9000029;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(900, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(172, 20);
            this.label21.TabIndex = 9000031;
            this.label21.Text = "Patient Serch by Mobile :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientSearchMobile
            // 
            this.txtPatientSearchMobile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPatientSearchMobile.Location = new System.Drawing.Point(904, 50);
            this.txtPatientSearchMobile.Name = "txtPatientSearchMobile";
            this.txtPatientSearchMobile.Size = new System.Drawing.Size(454, 29);
            this.txtPatientSearchMobile.TabIndex = 9000032;
            this.txtPatientSearchMobile.TextChanged += new System.EventHandler(this.txtPatientSearchMobile_TextChanged);
            // 
            // btnDoctor
            // 
            this.btnDoctor.BackColor = System.Drawing.Color.White;
            this.btnDoctor.FlatAppearance.BorderSize = 0;
            this.btnDoctor.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDoctor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctor.Location = new System.Drawing.Point(803, 285);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(151, 40);
            this.btnDoctor.TabIndex = 9000034;
            this.btnDoctor.Text = "Available Doctor";
            this.btnDoctor.UseVisualStyleBackColor = false;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // ctrlPatientSerialBooking1
            // 
            this.ctrlPatientSerialBooking1.Location = new System.Drawing.Point(748, 431);
            this.ctrlPatientSerialBooking1.Name = "ctrlPatientSerialBooking1";
            this.ctrlPatientSerialBooking1.Size = new System.Drawing.Size(570, 562);
            this.ctrlPatientSerialBooking1.TabIndex = 9000033;
            this.ctrlPatientSerialBooking1.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.PractitionerWisePatientSerial>.SearchEscapeEventHandler(this.ctrlPatientSerialBooking1_SearchEsacaped);
            // 
            // ctrlMarketingAgentSearchControl
            // 
            this.ctrlMarketingAgentSearchControl.Location = new System.Drawing.Point(430, 373);
            this.ctrlMarketingAgentSearchControl.Name = "ctrlMarketingAgentSearchControl";
            this.ctrlMarketingAgentSearchControl.Size = new System.Drawing.Size(752, 442);
            this.ctrlMarketingAgentSearchControl.TabIndex = 67;
            this.ctrlMarketingAgentSearchControl.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(1293, 285);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 40);
            this.btnDelete.TabIndex = 9000035;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDailyId
            // 
            this.txtDailyId.BackColor = System.Drawing.Color.LightSalmon;
            this.txtDailyId.Enabled = false;
            this.txtDailyId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDailyId.Location = new System.Drawing.Point(165, 5);
            this.txtDailyId.Name = "txtDailyId";
            this.txtDailyId.Size = new System.Drawing.Size(97, 29);
            this.txtDailyId.TabIndex = 9000036;
            // 
            // frmPatientSerialEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.txtDailyId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ctrlPatientSerialBooking1);
            this.Controls.Add(this.txtPatientSearchMobile);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbEndtAmPm);
            this.Controls.Add(this.cmbStartAmPm);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtOccupation);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lblYears);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.txtDateofBirth);
            this.Controls.Add(this.lblEntrtyDate);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.ctrlMarketingAgentSearchControl);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMarketingAgent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbVisitType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAvailability);
            this.Controls.Add(this.lblNameOfWeekday);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBooked);
            this.Controls.Add(this.lblPQuota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.lblSerialFor);
            this.Controls.Add(this.lblSerialNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvPList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TV);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.txtCellPhone);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.cmbTitle);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.btnDoctor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPatientSerialEntry";
            this.Text = "Doctor\'s Patient Serial Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPatientSerialEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView TV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvPList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label lblSerialFor;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPQuota;
        private System.Windows.Forms.Label lblBooked;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNameOfWeekday;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.ComboBox cmbVisitType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMarketingAgent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label9;
        private Controls.MarketingAgentSearchControl ctrlMarketingAgentSearchControl;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtDateofBirth;
        private System.Windows.Forms.Label lblEntrtyDate;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblYears;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbTitle;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.ComboBox cmbStartAmPm;
        private System.Windows.Forms.ComboBox cmbEndtAmPm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPatientSearchMobile;
        private Controls.ctrlPatientSerialBooking ctrlPatientSerialBooking1;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDailyId;
    }
}