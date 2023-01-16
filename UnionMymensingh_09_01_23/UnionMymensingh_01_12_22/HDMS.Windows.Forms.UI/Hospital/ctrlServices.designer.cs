namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlServices));
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssignedDoctor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCabinNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtServiceItem = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.lvPatients = new System.Windows.Forms.ListView();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoggedInInfo = new System.Windows.Forms.Label();
            this.btnCabin = new System.Windows.Forms.Button();
            this.btnOT = new System.Windows.Forms.Button();
            this.btnPostOperative = new System.Windows.Forms.Button();
            this.dgDeliveredServices = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlServicetem = new HDMS.Windows.Forms.UI.Controls.HospitalBillItemSearchControl();
            this.ctlPatientList = new HDMS.Windows.Forms.UI.Controls.HospitalPatientSearch();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveredServices)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Assigned Doctor";
            // 
            // txtAssignedDoctor
            // 
            this.txtAssignedDoctor.Enabled = false;
            this.txtAssignedDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedDoctor.Location = new System.Drawing.Point(14, 85);
            this.txtAssignedDoctor.Name = "txtAssignedDoctor";
            this.txtAssignedDoctor.Size = new System.Drawing.Size(505, 26);
            this.txtAssignedDoctor.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(522, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Cabin No";
            // 
            // txtCabinNo
            // 
            this.txtCabinNo.Enabled = false;
            this.txtCabinNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinNo.Location = new System.Drawing.Point(525, 85);
            this.txtCabinNo.Name = "txtCabinNo";
            this.txtCabinNo.Size = new System.Drawing.Size(124, 26);
            this.txtCabinNo.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(283, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 26);
            this.txtName.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(777, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 18);
            this.label13.TabIndex = 35;
            this.label13.Text = "Qty";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(621, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 18);
            this.label12.TabIndex = 34;
            this.label12.Text = "Rate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "Service Item";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(780, 147);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(88, 26);
            this.txtQty.TabIndex = 32;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(622, 147);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(101, 26);
            this.txtRate.TabIndex = 31;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // txtServiceItem
            // 
            this.txtServiceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceItem.Location = new System.Drawing.Point(13, 147);
            this.txtServiceItem.Name = "txtServiceItem";
            this.txtServiceItem.Size = new System.Drawing.Size(339, 26);
            this.txtServiceItem.TabIndex = 30;
            this.txtServiceItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceItem_KeyPress);
            // 
            // dgService
            // 
            this.dgService.AllowUserToAddRows = false;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Rate,
            this.Column3,
            this.ServiceCharge,
            this.Column4,
            this.Column2,
            this.Column5});
            this.dgService.Location = new System.Drawing.Point(14, 180);
            this.dgService.Name = "dgService";
            this.dgService.Size = new System.Drawing.Size(854, 145);
            this.dgService.TabIndex = 37;
            this.dgService.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgService_UserDeletedRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Service Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
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
            // Column2
            // 
            this.Column2.HeaderText = "Service Date";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "User";
            this.Column5.Name = "Column5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Service Date";
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpServiceDate.Location = new System.Drawing.Point(375, 147);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(145, 26);
            this.dtpServiceDate.TabIndex = 39;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(13, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 37);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(693, 336);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(175, 27);
            this.txtTotalAmount.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(591, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Total Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(578, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "Service Charge";
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceCharge.Location = new System.Drawing.Point(693, 373);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Size = new System.Drawing.Size(175, 27);
            this.txtServiceCharge.TabIndex = 43;
            // 
            // lvPatients
            // 
            this.lvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPatients.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPatients.HideSelection = false;
            this.lvPatients.LargeImageList = this.imgListLarge;
            this.lvPatients.Location = new System.Drawing.Point(3, 41);
            this.lvPatients.Name = "lvPatients";
            this.lvPatients.Size = new System.Drawing.Size(511, 633);
            this.lvPatients.SmallImageList = this.imgListLarge;
            this.lvPatients.TabIndex = 45;
            this.lvPatients.UseCompatibleStateImageBehavior = false;
            this.lvPatients.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPatients_MouseClick);
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "BedImageIcon.BMP");
            this.imgListLarge.Images.SetKeyName(1, "cabin.bmp");
            this.imgListLarge.Images.SetKeyName(2, "images.jpg");
            // 
            // txtPatient
            // 
            this.txtPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatient.Location = new System.Drawing.Point(10, 32);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(251, 26);
            this.txtPatient.TabIndex = 21;
            this.txtPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatient_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Search Patient";
            // 
            // lblLoggedInInfo
            // 
            this.lblLoggedInInfo.AutoSize = true;
            this.lblLoggedInInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInInfo.ForeColor = System.Drawing.Color.Red;
            this.lblLoggedInInfo.Location = new System.Drawing.Point(16, 18);
            this.lblLoggedInInfo.Name = "lblLoggedInInfo";
            this.lblLoggedInInfo.Size = new System.Drawing.Size(0, 14);
            this.lblLoggedInInfo.TabIndex = 47;
            // 
            // btnCabin
            // 
            this.btnCabin.BackColor = System.Drawing.SystemColors.Control;
            this.btnCabin.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCabin.Location = new System.Drawing.Point(781, 14);
            this.btnCabin.Name = "btnCabin";
            this.btnCabin.Size = new System.Drawing.Size(76, 27);
            this.btnCabin.TabIndex = 49;
            this.btnCabin.Text = "Cabin";
            this.btnCabin.UseVisualStyleBackColor = false;
            this.btnCabin.Click += new System.EventHandler(this.btnCabin_Click);
            // 
            // btnOT
            // 
            this.btnOT.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOT.Location = new System.Drawing.Point(666, 46);
            this.btnOT.Name = "btnOT";
            this.btnOT.Size = new System.Drawing.Size(76, 27);
            this.btnOT.TabIndex = 50;
            this.btnOT.Text = "OT";
            this.btnOT.UseVisualStyleBackColor = true;
            this.btnOT.Click += new System.EventHandler(this.btnOT_Click);
            // 
            // btnPostOperative
            // 
            this.btnPostOperative.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostOperative.Location = new System.Drawing.Point(781, 84);
            this.btnPostOperative.Name = "btnPostOperative";
            this.btnPostOperative.Size = new System.Drawing.Size(78, 27);
            this.btnPostOperative.TabIndex = 51;
            this.btnPostOperative.Text = "PO";
            this.btnPostOperative.UseVisualStyleBackColor = true;
            this.btnPostOperative.Click += new System.EventHandler(this.btnPostOperative_Click);
            // 
            // dgDeliveredServices
            // 
            this.dgDeliveredServices.AllowUserToAddRows = false;
            this.dgDeliveredServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliveredServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7});
            this.dgDeliveredServices.Location = new System.Drawing.Point(10, 429);
            this.dgDeliveredServices.Name = "dgDeliveredServices";
            this.dgDeliveredServices.Size = new System.Drawing.Size(854, 233);
            this.dgDeliveredServices.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Service Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 350;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "User";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Delivered Services :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.71943F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.28056F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1554, 683);
            this.tableLayoutPanel1.TabIndex = 54;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtSearchByCabin, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lvPatients, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.760709F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.23929F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(517, 677);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(3, 6);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(248, 26);
            this.txtSearchByCabin.TabIndex = 48;
            this.txtSearchByCabin.Text = "Search by cabin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlServicetem);
            this.panel1.Controls.Add(this.ctlPatientList);
            this.panel1.Controls.Add(this.dgService);
            this.panel1.Controls.Add(this.txtPatient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgDeliveredServices);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCabinNo);
            this.panel1.Controls.Add(this.btnPostOperative);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnOT);
            this.panel1.Controls.Add(this.txtServiceCharge);
            this.panel1.Controls.Add(this.txtAssignedDoctor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCabin);
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtServiceItem);
            this.panel1.Controls.Add(this.txtRate);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtpServiceDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(526, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 677);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ctrlServicetem
            // 
            this.ctrlServicetem.Location = new System.Drawing.Point(149, 406);
            this.ctrlServicetem.Name = "ctrlServicetem";
            this.ctrlServicetem.Size = new System.Drawing.Size(559, 440);
            this.ctrlServicetem.TabIndex = 36;
            this.ctrlServicetem.Visible = false;
            this.ctrlServicetem.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ServiceHead>.SearchEscapeEventHandler(this.ctrlServicetem_SearchEsacaped);
            // 
            // ctlPatientList
            // 
            this.ctlPatientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ctlPatientList.Location = new System.Drawing.Point(29, 409);
            this.ctlPatientList.Margin = new System.Windows.Forms.Padding(4);
            this.ctlPatientList.Name = "ctlPatientList";
            this.ctlPatientList.Size = new System.Drawing.Size(740, 479);
            this.ctlPatientList.TabIndex = 29;
            this.ctlPatientList.Visible = false;
            this.ctlPatientList.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMIPDInfo>.SearchEscapeEventHandler(this.ctlPatientList_SearchEsacaped);
            // 
            // ctrlServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblLoggedInInfo);
            this.Name = "ctrlServices";
            this.Size = new System.Drawing.Size(1554, 683);
            this.Load += new System.EventHandler(this.ctrlServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveredServices)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAssignedDoctor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCabinNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private Controls.HospitalPatientSearch ctlPatientList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtServiceItem;
        private Controls.HospitalBillItemSearchControl ctrlServicetem;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.ListView lvPatients;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoggedInInfo;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Button btnCabin;
        private System.Windows.Forms.Button btnOT;
        private System.Windows.Forms.Button btnPostOperative;
        private System.Windows.Forms.DataGridView dgDeliveredServices;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
    }
}
