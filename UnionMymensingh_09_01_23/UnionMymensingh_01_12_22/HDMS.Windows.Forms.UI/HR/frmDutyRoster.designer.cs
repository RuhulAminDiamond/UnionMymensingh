namespace HDMS.Windows.Forms.UI.HR
{
    partial class frmDutyRoster
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpRosterStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpRosterEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgEmployeeRoster = new System.Windows.Forms.DataGridView();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnCreateRoster = new System.Windows.Forms.Button();
            this.lbMorning = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMorning = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEvening = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNight = new System.Windows.Forms.ComboBox();
            this.btnMorning = new System.Windows.Forms.Button();
            this.btnEvening = new System.Windows.Forms.Button();
            this.btnNight = new System.Windows.Forms.Button();
            this.lbEvening = new System.Windows.Forms.ListBox();
            this.lbNight = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOverTime = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbOverTime = new System.Windows.Forms.ComboBox();
            this.lbOverTime = new System.Windows.Forms.ListBox();
            this.btnDayOf = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDayof = new System.Windows.Forms.ComboBox();
            this.lbDayof = new System.Windows.Forms.ListBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.NameOfDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RosterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MorningEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EveningEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NightEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverTimeEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOffEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearM = new System.Windows.Forms.Button();
            this.btnClearN = new System.Windows.Forms.Button();
            this.btnClearE = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeRoster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(159, 614);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(240, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(321, 613);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(566, 626);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 29);
            this.txtName.TabIndex = 8;
            this.txtName.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 345;
            this.label8.Text = "Designation";
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DisplayMember = "Name";
            this.cmbDesignation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(147, 46);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(217, 28);
            this.cmbDesignation.TabIndex = 343;
            this.cmbDesignation.ValueMember = "Id";
            this.cmbDesignation.SelectedIndexChanged += new System.EventHandler(this.cmbDesignation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 344;
            this.label5.Text = "Department";
            // 
            // cmbDept
            // 
            this.cmbDept.DisplayMember = "Name";
            this.cmbDept.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(147, 12);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(217, 28);
            this.cmbDept.TabIndex = 342;
            this.cmbDept.ValueMember = "Id";
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 731);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 347;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 358;
            this.label7.Text = "Roster Start Date";
            // 
            // dtpRosterStartDate
            // 
            this.dtpRosterStartDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRosterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRosterStartDate.Location = new System.Drawing.Point(491, 18);
            this.dtpRosterStartDate.Name = "dtpRosterStartDate";
            this.dtpRosterStartDate.Size = new System.Drawing.Size(217, 27);
            this.dtpRosterStartDate.TabIndex = 357;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(716, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 360;
            this.label1.Text = "Roster End Date";
            // 
            // dtpRosterEndDate
            // 
            this.dtpRosterEndDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRosterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRosterEndDate.Location = new System.Drawing.Point(840, 18);
            this.dtpRosterEndDate.Name = "dtpRosterEndDate";
            this.dtpRosterEndDate.Size = new System.Drawing.Size(217, 27);
            this.dtpRosterEndDate.TabIndex = 359;
            // 
            // dgEmployeeRoster
            // 
            this.dgEmployeeRoster.AllowUserToAddRows = false;
            this.dgEmployeeRoster.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgEmployeeRoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployeeRoster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOfDay,
            this.RosterDate,
            this.MorningEmpName,
            this.EveningEmpName,
            this.NightEmpName,
            this.OverTimeEmpName,
            this.DayOffEmpName});
            this.dgEmployeeRoster.Location = new System.Drawing.Point(6, 249);
            this.dgEmployeeRoster.Name = "dgEmployeeRoster";
            this.dgEmployeeRoster.Size = new System.Drawing.Size(1356, 316);
            this.dgEmployeeRoster.TabIndex = 361;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToList.Location = new System.Drawing.Point(145, 215);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(100, 28);
            this.btnAddToList.TabIndex = 362;
            this.btnAddToList.Text = "Add to List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnDisplayRoster_Click);
            // 
            // btnCreateRoster
            // 
            this.btnCreateRoster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRoster.Location = new System.Drawing.Point(12, 615);
            this.btnCreateRoster.Name = "btnCreateRoster";
            this.btnCreateRoster.Size = new System.Drawing.Size(136, 40);
            this.btnCreateRoster.TabIndex = 363;
            this.btnCreateRoster.Text = "Create Roster";
            this.btnCreateRoster.UseVisualStyleBackColor = true;
            this.btnCreateRoster.Click += new System.EventHandler(this.btnCreateRoster_Click);
            // 
            // lbMorning
            // 
            this.lbMorning.DisplayMember = "EmployeeName";
            this.lbMorning.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMorning.FormattingEnabled = true;
            this.lbMorning.ItemHeight = 20;
            this.lbMorning.Location = new System.Drawing.Point(145, 145);
            this.lbMorning.Name = "lbMorning";
            this.lbMorning.Size = new System.Drawing.Size(168, 64);
            this.lbMorning.TabIndex = 364;
            this.lbMorning.ValueMember = "EmployeeId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 368;
            this.label3.Text = "Morning ";
            // 
            // cmbMorning
            // 
            this.cmbMorning.DisplayMember = "Name";
            this.cmbMorning.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMorning.FormattingEnabled = true;
            this.cmbMorning.Location = new System.Drawing.Point(146, 111);
            this.cmbMorning.Name = "cmbMorning";
            this.cmbMorning.Size = new System.Drawing.Size(167, 28);
            this.cmbMorning.TabIndex = 367;
            this.cmbMorning.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(367, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 370;
            this.label4.Text = "Evening";
            // 
            // cmbEvening
            // 
            this.cmbEvening.DisplayMember = "Name";
            this.cmbEvening.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEvening.FormattingEnabled = true;
            this.cmbEvening.Location = new System.Drawing.Point(364, 111);
            this.cmbEvening.Name = "cmbEvening";
            this.cmbEvening.Size = new System.Drawing.Size(163, 28);
            this.cmbEvening.TabIndex = 369;
            this.cmbEvening.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(576, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 372;
            this.label6.Text = "Night";
            // 
            // cmbNight
            // 
            this.cmbNight.DisplayMember = "Name";
            this.cmbNight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNight.FormattingEnabled = true;
            this.cmbNight.Location = new System.Drawing.Point(580, 114);
            this.cmbNight.Name = "cmbNight";
            this.cmbNight.Size = new System.Drawing.Size(176, 28);
            this.cmbNight.TabIndex = 371;
            this.cmbNight.ValueMember = "Id";
            // 
            // btnMorning
            // 
            this.btnMorning.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMorning.Location = new System.Drawing.Point(317, 111);
            this.btnMorning.Name = "btnMorning";
            this.btnMorning.Size = new System.Drawing.Size(41, 28);
            this.btnMorning.TabIndex = 373;
            this.btnMorning.Text = "+";
            this.btnMorning.UseVisualStyleBackColor = true;
            this.btnMorning.Click += new System.EventHandler(this.btnMorning_Click);
            // 
            // btnEvening
            // 
            this.btnEvening.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvening.Location = new System.Drawing.Point(533, 112);
            this.btnEvening.Name = "btnEvening";
            this.btnEvening.Size = new System.Drawing.Size(41, 28);
            this.btnEvening.TabIndex = 374;
            this.btnEvening.Text = "+";
            this.btnEvening.UseVisualStyleBackColor = true;
            this.btnEvening.Click += new System.EventHandler(this.btnEvening_Click);
            // 
            // btnNight
            // 
            this.btnNight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNight.Location = new System.Drawing.Point(762, 114);
            this.btnNight.Name = "btnNight";
            this.btnNight.Size = new System.Drawing.Size(41, 28);
            this.btnNight.TabIndex = 375;
            this.btnNight.Text = "+";
            this.btnNight.UseVisualStyleBackColor = true;
            this.btnNight.Click += new System.EventHandler(this.btnNight_Click);
            // 
            // lbEvening
            // 
            this.lbEvening.DisplayMember = "EmployeeName";
            this.lbEvening.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEvening.FormattingEnabled = true;
            this.lbEvening.ItemHeight = 20;
            this.lbEvening.Location = new System.Drawing.Point(364, 145);
            this.lbEvening.Name = "lbEvening";
            this.lbEvening.Size = new System.Drawing.Size(163, 64);
            this.lbEvening.TabIndex = 376;
            this.lbEvening.ValueMember = "EmployeeId";
            // 
            // lbNight
            // 
            this.lbNight.DisplayMember = "EmployeeName";
            this.lbNight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNight.FormattingEnabled = true;
            this.lbNight.ItemHeight = 20;
            this.lbNight.Location = new System.Drawing.Point(580, 148);
            this.lbNight.Name = "lbNight";
            this.lbNight.Size = new System.Drawing.Size(176, 64);
            this.lbNight.TabIndex = 377;
            this.lbNight.ValueMember = "EmployeeId";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(1124, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 18);
            this.label9.TabIndex = 378;
            this.label9.Text = "Morning Shift :  8 AM to 4 PM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(1124, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 18);
            this.label10.TabIndex = 379;
            this.label10.Text = "Evening Shift :  4 PM to 12 AM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.OrangeRed;
            this.label11.Location = new System.Drawing.Point(1124, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 18);
            this.label11.TabIndex = 380;
            this.label11.Text = "Night Shift :  12 AM to 8 AM";
            // 
            // btnOverTime
            // 
            this.btnOverTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverTime.Location = new System.Drawing.Point(978, 114);
            this.btnOverTime.Name = "btnOverTime";
            this.btnOverTime.Size = new System.Drawing.Size(41, 28);
            this.btnOverTime.TabIndex = 384;
            this.btnOverTime.Text = "+";
            this.btnOverTime.UseVisualStyleBackColor = true;
            this.btnOverTime.Click += new System.EventHandler(this.btnOverTime_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(810, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.TabIndex = 383;
            this.label12.Text = "Over Time";
            // 
            // cmbOverTime
            // 
            this.cmbOverTime.DisplayMember = "Name";
            this.cmbOverTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOverTime.FormattingEnabled = true;
            this.cmbOverTime.Location = new System.Drawing.Point(814, 114);
            this.cmbOverTime.Name = "cmbOverTime";
            this.cmbOverTime.Size = new System.Drawing.Size(158, 28);
            this.cmbOverTime.TabIndex = 382;
            this.cmbOverTime.ValueMember = "Id";
            // 
            // lbOverTime
            // 
            this.lbOverTime.DisplayMember = "EmployeeName";
            this.lbOverTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOverTime.FormattingEnabled = true;
            this.lbOverTime.ItemHeight = 20;
            this.lbOverTime.Location = new System.Drawing.Point(813, 148);
            this.lbOverTime.Name = "lbOverTime";
            this.lbOverTime.Size = new System.Drawing.Size(159, 64);
            this.lbOverTime.TabIndex = 381;
            this.lbOverTime.ValueMember = "EmployeeId";
            // 
            // btnDayOf
            // 
            this.btnDayOf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayOf.Location = new System.Drawing.Point(1257, 114);
            this.btnDayOf.Name = "btnDayOf";
            this.btnDayOf.Size = new System.Drawing.Size(41, 28);
            this.btnDayOf.TabIndex = 388;
            this.btnDayOf.Text = "+";
            this.btnDayOf.UseVisualStyleBackColor = true;
            this.btnDayOf.Click += new System.EventHandler(this.btnDayOf_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1030, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 20);
            this.label13.TabIndex = 387;
            this.label13.Text = "Day of";
            // 
            // cmbDayof
            // 
            this.cmbDayof.DisplayMember = "Name";
            this.cmbDayof.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDayof.FormattingEnabled = true;
            this.cmbDayof.Location = new System.Drawing.Point(1034, 113);
            this.cmbDayof.Name = "cmbDayof";
            this.cmbDayof.Size = new System.Drawing.Size(217, 28);
            this.cmbDayof.TabIndex = 386;
            this.cmbDayof.ValueMember = "Id";
            // 
            // lbDayof
            // 
            this.lbDayof.DisplayMember = "EmployeeName";
            this.lbDayof.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDayof.FormattingEnabled = true;
            this.lbDayof.ItemHeight = 20;
            this.lbDayof.Location = new System.Drawing.Point(1034, 147);
            this.lbDayof.Name = "lbDayof";
            this.lbDayof.Size = new System.Drawing.Size(216, 64);
            this.lbDayof.TabIndex = 385;
            this.lbDayof.ValueMember = "EmployeeId";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(148, 571);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1214, 29);
            this.txtRemarks.TabIndex = 389;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 575);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 390;
            this.label14.Text = "Remarks";
            // 
            // NameOfDay
            // 
            this.NameOfDay.DataPropertyName = "NameOfDay";
            this.NameOfDay.HeaderText = "Day";
            this.NameOfDay.Name = "NameOfDay";
            this.NameOfDay.ReadOnly = true;
            // 
            // RosterDate
            // 
            this.RosterDate.DataPropertyName = "RosterDate";
            this.RosterDate.HeaderText = "Date";
            this.RosterDate.Name = "RosterDate";
            // 
            // MorningEmpName
            // 
            this.MorningEmpName.DataPropertyName = "MorningEmpName";
            this.MorningEmpName.HeaderText = "Morning";
            this.MorningEmpName.Name = "MorningEmpName";
            this.MorningEmpName.ReadOnly = true;
            this.MorningEmpName.Width = 250;
            // 
            // EveningEmpName
            // 
            this.EveningEmpName.DataPropertyName = "EveningEmpName";
            this.EveningEmpName.HeaderText = "Evening";
            this.EveningEmpName.Name = "EveningEmpName";
            this.EveningEmpName.ReadOnly = true;
            this.EveningEmpName.Width = 250;
            // 
            // NightEmpName
            // 
            this.NightEmpName.DataPropertyName = "NightEmpName";
            this.NightEmpName.HeaderText = "Night";
            this.NightEmpName.Name = "NightEmpName";
            this.NightEmpName.ReadOnly = true;
            this.NightEmpName.Width = 250;
            // 
            // OverTimeEmpName
            // 
            this.OverTimeEmpName.DataPropertyName = "OverTimeEmpName";
            this.OverTimeEmpName.HeaderText = "Over Time";
            this.OverTimeEmpName.Name = "OverTimeEmpName";
            this.OverTimeEmpName.ReadOnly = true;
            this.OverTimeEmpName.Width = 180;
            // 
            // DayOffEmpName
            // 
            this.DayOffEmpName.DataPropertyName = "DayOffEmpName";
            this.DayOffEmpName.HeaderText = "Day Off";
            this.DayOffEmpName.Name = "DayOffEmpName";
            this.DayOffEmpName.ReadOnly = true;
            this.DayOffEmpName.Width = 180;
            // 
            // btnClearM
            // 
            this.btnClearM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearM.Location = new System.Drawing.Point(317, 147);
            this.btnClearM.Name = "btnClearM";
            this.btnClearM.Size = new System.Drawing.Size(41, 28);
            this.btnClearM.TabIndex = 391;
            this.btnClearM.Text = "-";
            this.btnClearM.UseVisualStyleBackColor = true;
            this.btnClearM.Click += new System.EventHandler(this.btnClearM_Click);
            // 
            // btnClearN
            // 
            this.btnClearN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearN.Location = new System.Drawing.Point(762, 148);
            this.btnClearN.Name = "btnClearN";
            this.btnClearN.Size = new System.Drawing.Size(41, 28);
            this.btnClearN.TabIndex = 392;
            this.btnClearN.Text = "-";
            this.btnClearN.UseVisualStyleBackColor = true;
            // 
            // btnClearE
            // 
            this.btnClearE.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearE.Location = new System.Drawing.Point(533, 146);
            this.btnClearE.Name = "btnClearE";
            this.btnClearE.Size = new System.Drawing.Size(41, 28);
            this.btnClearE.TabIndex = 393;
            this.btnClearE.Text = "-";
            this.btnClearE.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(978, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 28);
            this.button4.TabIndex = 394;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1256, 146);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 28);
            this.button5.TabIndex = 395;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // frmDutyRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnClearE);
            this.Controls.Add(this.btnClearN);
            this.Controls.Add(this.btnClearM);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnDayOf);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbDayof);
            this.Controls.Add(this.lbDayof);
            this.Controls.Add(this.btnOverTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbOverTime);
            this.Controls.Add(this.lbOverTime);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbNight);
            this.Controls.Add(this.lbEvening);
            this.Controls.Add(this.btnNight);
            this.Controls.Add(this.btnEvening);
            this.Controls.Add(this.btnMorning);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbNight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbEvening);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMorning);
            this.Controls.Add(this.lbMorning);
            this.Controls.Add(this.btnCreateRoster);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.dgEmployeeRoster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpRosterEndDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpRosterStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDesignation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtName);
            this.Name = "frmDutyRoster";
            this.Text = "Dept. Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadDutyRoster);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployeeRoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpRosterStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRosterEndDate;
        private System.Windows.Forms.DataGridView dgEmployeeRoster;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnCreateRoster;
        private System.Windows.Forms.ListBox lbMorning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMorning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEvening;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNight;
        private System.Windows.Forms.Button btnMorning;
        private System.Windows.Forms.Button btnEvening;
        private System.Windows.Forms.Button btnNight;
        private System.Windows.Forms.ListBox lbEvening;
        private System.Windows.Forms.ListBox lbNight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOverTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbOverTime;
        private System.Windows.Forms.ListBox lbOverTime;
        private System.Windows.Forms.Button btnDayOf;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDayof;
        private System.Windows.Forms.ListBox lbDayof;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn RosterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MorningEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EveningEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NightEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverTimeEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOffEmpName;
        private System.Windows.Forms.Button btnClearM;
        private System.Windows.Forms.Button btnClearN;
        private System.Windows.Forms.Button btnClearE;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}