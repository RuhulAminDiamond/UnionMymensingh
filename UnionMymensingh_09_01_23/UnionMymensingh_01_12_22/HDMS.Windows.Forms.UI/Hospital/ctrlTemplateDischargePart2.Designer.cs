namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlTemplateDischargePart2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTemplateDischargePart2));
            this.label15 = new System.Windows.Forms.Label();
            this.txtMedicalOfficer = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvReports = new System.Windows.Forms.ListView();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCabin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDischarge = new System.Windows.Forms.DateTimePicker();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnMinView = new System.Windows.Forms.Button();
            this.dgDischargePatientList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchByAddress = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByMobile = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtAdmId = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.btnMaxView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ctrlMedicalOfficerSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportConsultantSearchControl();
            this.ctrlDischareTemplateSearchControl = new HDMS.Windows.Forms.UI.Controls.DischargeTemplateSearchControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDischargePatientList)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(419, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 15);
            this.label15.TabIndex = 10154;
            this.label15.Text = "Medical Officer";
            // 
            // txtMedicalOfficer
            // 
            this.txtMedicalOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicalOfficer.Location = new System.Drawing.Point(517, 80);
            this.txtMedicalOfficer.Name = "txtMedicalOfficer";
            this.txtMedicalOfficer.Size = new System.Drawing.Size(638, 22);
            this.txtMedicalOfficer.TabIndex = 10155;
            this.txtMedicalOfficer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedicalOfficer_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lvReports);
            this.panel2.Location = new System.Drawing.Point(413, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 483);
            this.panel2.TabIndex = 10152;
            // 
            // lvReports
            // 
            this.lvReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvReports.BackColor = System.Drawing.Color.Lavender;
            this.lvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReports.GridLines = true;
            this.lvReports.HideSelection = false;
            this.lvReports.HoverSelection = true;
            this.lvReports.LargeImageList = this.imgListLarge;
            this.lvReports.Location = new System.Drawing.Point(9, 15);
            this.lvReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvReports.Name = "lvReports";
            this.lvReports.ShowItemToolTips = true;
            this.lvReports.Size = new System.Drawing.Size(753, 446);
            this.lvReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.DoubleClick += new System.EventHandler(this.lvReports_DoubleClick);
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "download11.png");
            this.imgListLarge.Images.SetKeyName(1, "imgL.bmp");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 10151;
            this.label1.Text = "Select Template";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.Location = new System.Drawing.Point(517, 108);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(389, 27);
            this.txtTemplate.TabIndex = 10150;
            this.txtTemplate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemplate_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(974, 39);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10149;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(918, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 10148;
            this.label8.Text = "Cabin :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(468, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 10147;
            this.label9.Text = "Name :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(527, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10146;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(410, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 18);
            this.label11.TabIndex = 10144;
            this.label11.Text = "Billing Date_Time";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(655, 5);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(159, 26);
            this.txtTime.TabIndex = 10143;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Patinet Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cabin No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // dgPatient
            // 
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatient.Location = new System.Drawing.Point(3, 58);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(379, 679);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgPatient, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchByCabin, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.484407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.51559F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 740);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(6, 15);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(373, 25);
            this.txtSearchByCabin.TabIndex = 1;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 740);
            this.panel1.TabIndex = 10145;
            // 
            // dtpDischarge
            // 
            this.dtpDischarge.CustomFormat = "dd-MM-yyyy";
            this.dtpDischarge.Enabled = false;
            this.dtpDischarge.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDischarge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDischarge.Location = new System.Drawing.Point(542, 5);
            this.dtpDischarge.Name = "dtpDischarge";
            this.dtpDischarge.Size = new System.Drawing.Size(107, 26);
            this.dtpDischarge.TabIndex = 10142;
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "smallIcon.bmp");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(923, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 10158;
            this.label2.Text = "Discharge Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd-MM-yyyy";
            this.dtp.Enabled = false;
            this.dtp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(1029, 108);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(126, 27);
            this.dtp.TabIndex = 10157;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(872, 10);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(103, 20);
            this.dtpfrm.TabIndex = 10163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(829, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 10164;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(981, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 18);
            this.label4.TabIndex = 10165;
            this.label4.Text = "To";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(1009, 11);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(103, 20);
            this.dtpto.TabIndex = 10166;
            // 
            // pnlPatient
            // 
            this.pnlPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPatient.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlPatient.Controls.Add(this.label6);
            this.pnlPatient.Controls.Add(this.label5);
            this.pnlPatient.Controls.Add(this.dtpEnd);
            this.pnlPatient.Controls.Add(this.dtpStart);
            this.pnlPatient.Controls.Add(this.btnMinView);
            this.pnlPatient.Controls.Add(this.dgDischargePatientList);
            this.pnlPatient.Controls.Add(this.txtSearchByAddress);
            this.pnlPatient.Controls.Add(this.txtSearchByMobile);
            this.pnlPatient.Controls.Add(this.txtAdmId);
            this.pnlPatient.Controls.Add(this.txtName);
            this.pnlPatient.Controls.Add(this.btnMaxView);
            this.pnlPatient.Controls.Add(this.btnRefresh);
            this.pnlPatient.Location = new System.Drawing.Point(0, 8);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(1453, 630);
            this.pnlPatient.TabIndex = 10167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(462, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 10041;
            this.label6.Text = "Date To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(249, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 10040;
            this.label5.Text = "Date From";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(525, 21);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(117, 26);
            this.dtpEnd.TabIndex = 10039;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(340, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(116, 26);
            this.dtpStart.TabIndex = 10038;
            // 
            // btnMinView
            // 
            this.btnMinView.Location = new System.Drawing.Point(947, 11);
            this.btnMinView.Name = "btnMinView";
            this.btnMinView.Size = new System.Drawing.Size(96, 31);
            this.btnMinView.TabIndex = 10026;
            this.btnMinView.Text = ">> >> >>--->";
            this.btnMinView.UseVisualStyleBackColor = true;
            this.btnMinView.Click += new System.EventHandler(this.btnMinView_Click);
            // 
            // dgDischargePatientList
            // 
            this.dgDischargePatientList.AllowUserToAddRows = false;
            this.dgDischargePatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDischargePatientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.Phone,
            this.Address,
            this.dataGridViewTextBoxColumn2,
            this.Location});
            this.dgDischargePatientList.Location = new System.Drawing.Point(20, 96);
            this.dgDischargePatientList.Name = "dgDischargePatientList";
            this.dgDischargePatientList.RowHeadersWidth = 51;
            this.dgDischargePatientList.Size = new System.Drawing.Size(1107, 443);
            this.dgDischargePatientList.TabIndex = 10023;
            this.dgDischargePatientList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDischargePatientList_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Adm. No";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Name";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 190;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.Width = 220;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Adm. Date";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // Location
            // 
            this.Location.HeaderText = "Discharge Date";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.Width = 125;
            // 
            // txtSearchByAddress
            // 
            this.txtSearchByAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByAddress.Location = new System.Drawing.Point(493, 64);
            this.txtSearchByAddress.Name = "txtSearchByAddress";
            this.txtSearchByAddress.PlaceHolderText = "Search by Address";
            this.txtSearchByAddress.Size = new System.Drawing.Size(634, 23);
            this.txtSearchByAddress.TabIndex = 10162;
            this.txtSearchByAddress.Text = "Search by Address";
            this.txtSearchByAddress.TextChanged += new System.EventHandler(this.txtSearchByAddress_TextChanged);
            // 
            // txtSearchByMobile
            // 
            this.txtSearchByMobile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtSearchByMobile.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByMobile.Location = new System.Drawing.Point(317, 64);
            this.txtSearchByMobile.Name = "txtSearchByMobile";
            this.txtSearchByMobile.PlaceHolderText = "Search by Mobile No";
            this.txtSearchByMobile.Size = new System.Drawing.Size(161, 23);
            this.txtSearchByMobile.TabIndex = 10161;
            this.txtSearchByMobile.Text = "Search by Mobile No";
            this.txtSearchByMobile.TextChanged += new System.EventHandler(this.txtSearchByMobile_TextChanged);
            // 
            // txtAdmId
            // 
            this.txtAdmId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtAdmId.ForeColor = System.Drawing.Color.Gray;
            this.txtAdmId.Location = new System.Drawing.Point(20, 64);
            this.txtAdmId.Name = "txtAdmId";
            this.txtAdmId.PlaceHolderText = "By Adm. Id";
            this.txtAdmId.Size = new System.Drawing.Size(124, 23);
            this.txtAdmId.TabIndex = 10160;
            this.txtAdmId.Text = "By Adm. No";
            this.txtAdmId.TextChanged += new System.EventHandler(this.txtAdmId_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Location = new System.Drawing.Point(151, 64);
            this.txtName.Name = "txtName";
            this.txtName.PlaceHolderText = "Search by name";
            this.txtName.Size = new System.Drawing.Size(150, 23);
            this.txtName.TabIndex = 10159;
            this.txtName.Text = "Search by name";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnMaxView
            // 
            this.btnMaxView.Location = new System.Drawing.Point(17, 17);
            this.btnMaxView.Name = "btnMaxView";
            this.btnMaxView.Size = new System.Drawing.Size(96, 31);
            this.btnMaxView.TabIndex = 10021;
            this.btnMaxView.Text = "<---<< << <<";
            this.btnMaxView.UseVisualStyleBackColor = true;
            this.btnMaxView.Visible = false;
            this.btnMaxView.Click += new System.EventHandler(this.btnMaxView_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(663, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 32);
            this.btnRefresh.TabIndex = 10022;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ctrlMedicalOfficerSearchControl
            // 
            this.ctrlMedicalOfficerSearchControl.Location = new System.Drawing.Point(1196, 237);
            this.ctrlMedicalOfficerSearchControl.Name = "ctrlMedicalOfficerSearchControl";
            this.ctrlMedicalOfficerSearchControl.Size = new System.Drawing.Size(1005, 519);
            this.ctrlMedicalOfficerSearchControl.TabIndex = 10156;
            this.ctrlMedicalOfficerSearchControl.Visible = false;
            this.ctrlMedicalOfficerSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.SearchEscapeEventHandler(this.ctrlMedicalOfficerSearchControl_SearchEsacaped);
            // 
            // ctrlDischareTemplateSearchControl
            // 
            this.ctrlDischareTemplateSearchControl.Location = new System.Drawing.Point(1196, 24);
            this.ctrlDischareTemplateSearchControl.Name = "ctrlDischareTemplateSearchControl";
            this.ctrlDischareTemplateSearchControl.Size = new System.Drawing.Size(524, 523);
            this.ctrlDischareTemplateSearchControl.TabIndex = 10153;
            this.ctrlDischareTemplateSearchControl.Visible = false;
            this.ctrlDischareTemplateSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.DischargeTemplate>.SearchEscapeEventHandler(this.ctrlDischareTemplateSearchControl_SearchEsacaped);
            // 
            // ctrlTemplateDischargePart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.ctrlMedicalOfficerSearchControl);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpfrm);
            this.Controls.Add(this.ctrlDischareTemplateSearchControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMedicalOfficer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDischarge);
            this.Name = "ctrlTemplateDischargePart2";
            this.Size = new System.Drawing.Size(1474, 740);
            this.Load += new System.EventHandler(this.ctrlTemplateBasedDischargeMainWindow_Load);
            this.Resize += new System.EventHandler(this.ctrlTemplateDischargePart2_Resize);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDischargePatientList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private Controls.DischargeTemplateSearchControl ctrlDischareTemplateSearchControl;
        private System.Windows.Forms.TextBox txtMedicalOfficer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvReports;
        private Controls.ReportConsultantSearchControl ctrlMedicalOfficerSearchControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTime;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDischarge;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp;
        private Controls.PlaceHolderTextBox txtSearchByMobile;
        private Controls.PlaceHolderTextBox txtName;
        private Controls.PlaceHolderTextBox txtAdmId;
        private Controls.PlaceHolderTextBox txtSearchByAddress;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnMinView;
        private System.Windows.Forms.DataGridView dgDischargePatientList;
        private System.Windows.Forms.Button btnMaxView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
    }
}
