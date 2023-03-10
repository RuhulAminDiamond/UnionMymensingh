namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlOTOld
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
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheifSurgeon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOTName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOTtype = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCabinNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssignedDoctor = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtServiceItem = new System.Windows.Forms.TextBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIndicationOfSurgery = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIncisionType = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbAnaesthesiaType = new System.Windows.Forms.ComboBox();
            this.ctrlSurgeon = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.ctlPatientList = new HDMS.Windows.Forms.UI.Controls.HospitalPatientSearch();
            this.ctrlDoctor = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.ctrlServicetem = new HDMS.Windows.Forms.UI.Controls.HospitalBillItemSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPatient
            // 
            this.txtPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatient.Location = new System.Drawing.Point(137, 37);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(251, 26);
            this.txtPatient.TabIndex = 0;
            this.txtPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatient_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(137, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 26);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(536, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chief Surgeon";
            // 
            // txtCheifSurgeon
            // 
            this.txtCheifSurgeon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheifSurgeon.Location = new System.Drawing.Point(645, 87);
            this.txtCheifSurgeon.Name = "txtCheifSurgeon";
            this.txtCheifSurgeon.Size = new System.Drawing.Size(455, 26);
            this.txtCheifSurgeon.TabIndex = 5;
            this.txtCheifSurgeon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheifSurgeon_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(565, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "OT Name";
            // 
            // txtOTName
            // 
            this.txtOTName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTName.Location = new System.Drawing.Point(645, 121);
            this.txtOTName.Name = "txtOTName";
            this.txtOTName.Size = new System.Drawing.Size(215, 26);
            this.txtOTName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(571, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "OT Type";
            // 
            // cmbOTtype
            // 
            this.cmbOTtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOTtype.FormattingEnabled = true;
            this.cmbOTtype.Items.AddRange(new object[] {
            "Minor",
            "Intermediate",
            "Critical"});
            this.cmbOTtype.Location = new System.Drawing.Point(645, 154);
            this.cmbOTtype.Name = "cmbOTtype";
            this.cmbOTtype.Size = new System.Drawing.Size(122, 28);
            this.cmbOTtype.TabIndex = 10;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(645, 189);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(107, 26);
            this.dtpStartDate.TabIndex = 11;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(758, 189);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(112, 26);
            this.dtpStartTime.TabIndex = 12;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(1003, 189);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(110, 26);
            this.dtpEndTime.TabIndex = 14;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(890, 189);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(107, 26);
            this.dtpEndDate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(571, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Start On";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(887, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "End On";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cabin No";
            // 
            // txtCabinNo
            // 
            this.txtCabinNo.Enabled = false;
            this.txtCabinNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinNo.Location = new System.Drawing.Point(137, 102);
            this.txtCabinNo.Name = "txtCabinNo";
            this.txtCabinNo.Size = new System.Drawing.Size(359, 26);
            this.txtCabinNo.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Assigned Doctor";
            // 
            // txtAssignedDoctor
            // 
            this.txtAssignedDoctor.Enabled = false;
            this.txtAssignedDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedDoctor.Location = new System.Drawing.Point(137, 137);
            this.txtAssignedDoctor.Name = "txtAssignedDoctor";
            this.txtAssignedDoctor.Size = new System.Drawing.Size(359, 26);
            this.txtAssignedDoctor.TabIndex = 19;
            // 
            // dgService
            // 
            this.dgService.AllowUserToAddRows = false;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Rate,
            this.Column3,
            this.ServiceCharge,
            this.Column4,
            this.Column5});
            this.dgService.Location = new System.Drawing.Point(26, 271);
            this.dgService.Name = "dgService";
            this.dgService.Size = new System.Drawing.Size(1087, 300);
            this.dgService.TabIndex = 21;
            this.dgService.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgService_UserDeletedRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Service Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Doctor Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 320;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Qty";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // ServiceCharge
            // 
            this.ServiceCharge.HeaderText = "Service Charge";
            this.ServiceCharge.Name = "ServiceCharge";
            this.ServiceCharge.Width = 140;
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
            // txtServiceItem
            // 
            this.txtServiceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceItem.Location = new System.Drawing.Point(24, 239);
            this.txtServiceItem.Name = "txtServiceItem";
            this.txtServiceItem.Size = new System.Drawing.Size(198, 26);
            this.txtServiceItem.TabIndex = 22;
            this.txtServiceItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceItem_KeyPress);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor.Location = new System.Drawing.Point(248, 239);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(524, 26);
            this.txtDoctor.TabIndex = 23;
            this.txtDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoctor_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(791, 240);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(101, 26);
            this.txtRate.TabIndex = 24;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(926, 239);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(101, 26);
            this.txtQty.TabIndex = 25;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "Service Item";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(245, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "Doctor Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(788, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 18);
            this.label12.TabIndex = 28;
            this.label12.Text = "Rate";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(923, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 18);
            this.label13.TabIndex = 29;
            this.label13.Text = "Qty";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(26, 577);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 49);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(494, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 18);
            this.label14.TabIndex = 35;
            this.label14.Text = "Indication Of Surgery";
            // 
            // txtIndicationOfSurgery
            // 
            this.txtIndicationOfSurgery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicationOfSurgery.Location = new System.Drawing.Point(645, 13);
            this.txtIndicationOfSurgery.Name = "txtIndicationOfSurgery";
            this.txtIndicationOfSurgery.Size = new System.Drawing.Size(482, 26);
            this.txtIndicationOfSurgery.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(540, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 18);
            this.label15.TabIndex = 37;
            this.label15.Text = "Incision Type";
            // 
            // txtIncisionType
            // 
            this.txtIncisionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncisionType.Location = new System.Drawing.Point(645, 45);
            this.txtIncisionType.Name = "txtIncisionType";
            this.txtIncisionType.Size = new System.Drawing.Size(182, 26);
            this.txtIncisionType.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(837, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 18);
            this.label16.TabIndex = 39;
            this.label16.Text = "Anaesthesia Type";
            // 
            // cmbAnaesthesiaType
            // 
            this.cmbAnaesthesiaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnaesthesiaType.FormattingEnabled = true;
            this.cmbAnaesthesiaType.Items.AddRange(new object[] {
            "GA",
            "Local"});
            this.cmbAnaesthesiaType.Location = new System.Drawing.Point(967, 45);
            this.cmbAnaesthesiaType.Name = "cmbAnaesthesiaType";
            this.cmbAnaesthesiaType.Size = new System.Drawing.Size(158, 28);
            this.cmbAnaesthesiaType.TabIndex = 40;
            // 
            // ctrlSurgeon
            // 
            this.ctrlSurgeon.Location = new System.Drawing.Point(76, 171);
            this.ctrlSurgeon.Name = "ctrlSurgeon";
            this.ctrlSurgeon.Size = new System.Drawing.Size(610, 406);
            this.ctrlSurgeon.TabIndex = 32;
            this.ctrlSurgeon.Visible = false;
            // 
            // ctlPatientList
            // 
            this.ctlPatientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ctlPatientList.Location = new System.Drawing.Point(293, 198);
            this.ctlPatientList.Margin = new System.Windows.Forms.Padding(4);
            this.ctlPatientList.Name = "ctlPatientList";
            this.ctlPatientList.Size = new System.Drawing.Size(673, 462);
            this.ctlPatientList.TabIndex = 1;
            this.ctlPatientList.Visible = false;
            this.ctlPatientList.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMIPDInfo>.SearchEscapeEventHandler(this.ctlPatientList_SearchEsacaped);
            // 
            // ctrlDoctor
            // 
            this.ctrlDoctor.Location = new System.Drawing.Point(394, 169);
            this.ctrlDoctor.Name = "ctrlDoctor";
            this.ctrlDoctor.Size = new System.Drawing.Size(603, 613);
            this.ctrlDoctor.TabIndex = 31;
            this.ctrlDoctor.Visible = false;
            this.ctrlDoctor.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Doctor>.SearchEscapeEventHandler(this.ctrlDoctor_SearchEsacaped);
            // 
            // ctrlServicetem
            // 
            this.ctrlServicetem.Location = new System.Drawing.Point(166, 282);
            this.ctrlServicetem.Name = "ctrlServicetem";
            this.ctrlServicetem.Size = new System.Drawing.Size(559, 406);
            this.ctrlServicetem.TabIndex = 30;
            this.ctrlServicetem.Visible = false;
            this.ctrlServicetem.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ServiceHead>.SearchEscapeEventHandler(this.ctrlServicetem_SearchEsacaped);
            // 
            // ctrlOTOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.ctrlSurgeon);
            this.Controls.Add(this.cmbAnaesthesiaType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtIncisionType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtIndicationOfSurgery);
            this.Controls.Add(this.ctlPatientList);
            this.Controls.Add(this.ctrlDoctor);
            this.Controls.Add(this.ctrlServicetem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.txtServiceItem);
            this.Controls.Add(this.dgService);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAssignedDoctor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCabinNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cmbOTtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOTName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCheifSurgeon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatient);
            this.Name = "ctrlOTOld";
            this.Size = new System.Drawing.Size(1177, 756);
            this.Load += new System.EventHandler(this.ctrlOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPatient;
        private Controls.HospitalPatientSearch ctlPatientList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheifSurgeon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOTName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOTtype;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCabinNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAssignedDoctor;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.TextBox txtServiceItem;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Controls.HospitalBillItemSearchControl ctrlServicetem;
        private Controls.DoctorSearchControl ctrlDoctor;
        private Controls.DoctorSearchControl ctrlSurgeon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIndicationOfSurgery;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIncisionType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbAnaesthesiaType;
    }
}
