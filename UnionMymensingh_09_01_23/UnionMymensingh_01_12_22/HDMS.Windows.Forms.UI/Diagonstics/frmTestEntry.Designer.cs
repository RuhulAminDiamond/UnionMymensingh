namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmTestEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestEntry));
            this.gvTestlist = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speciman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediaComm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferralCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGLU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLUExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSpecimen = new System.Windows.Forms.ComboBox();
            this.dgvTestSubItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveSubItem = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodeNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPkgRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProcessDays = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.txtGLUExt = new System.Windows.Forms.TextBox();
            this.txtReportType = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radPkgNo = new System.Windows.Forms.RadioButton();
            this.radPkgYes = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPkgDiscount = new System.Windows.Forms.TextBox();
            this.ctrlReportTypeSearch = new HDMS.Windows.Forms.UI.Controls.ReportTypeSearchControl();
            this.ctrlTestGroupSearch = new HDMS.Windows.Forms.UI.Controls.TestGroupSearchControl();
            this.txtSearchTest = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Diagonstics.TestSearchControl();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMediaComm = new System.Windows.Forms.TextBox();
            this.txtReferralComm = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestSubItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvTestlist
            // 
            this.gvTestlist.BackgroundColor = System.Drawing.Color.Bisque;
            this.gvTestlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TestCode,
            this.TestName,
            this.Speciman,
            this.Cost,
            this.MediaComm,
            this.ReferralCommission,
            this.IsGLU,
            this.GLUExt,
            this.ReportOrder});
            this.gvTestlist.Location = new System.Drawing.Point(12, 287);
            this.gvTestlist.Name = "gvTestlist";
            this.gvTestlist.RowTemplate.Height = 35;
            this.gvTestlist.Size = new System.Drawing.Size(714, 393);
            this.gvTestlist.TabIndex = 19;
            this.gvTestlist.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTestlist_RowHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "TestId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 60;
            // 
            // TestCode
            // 
            this.TestCode.DataPropertyName = "TestCode";
            this.TestCode.HeaderText = "TestCode";
            this.TestCode.Name = "TestCode";
            this.TestCode.Width = 80;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 220;
            // 
            // Speciman
            // 
            this.Speciman.DataPropertyName = "Specimen";
            this.Speciman.HeaderText = "Speciman";
            this.Speciman.Name = "Speciman";
            this.Speciman.Width = 85;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Rate";
            this.Cost.HeaderText = "Rate";
            this.Cost.Name = "Cost";
            // 
            // MediaComm
            // 
            this.MediaComm.HeaderText = "Media Com.";
            this.MediaComm.Name = "MediaComm";
            // 
            // ReferralCommission
            // 
            this.ReferralCommission.HeaderText = "Ref. Com";
            this.ReferralCommission.Name = "ReferralCommission";
            // 
            // IsGLU
            // 
            this.IsGLU.HeaderText = "IsGLU";
            this.IsGLU.Name = "IsGLU";
            // 
            // GLUExt
            // 
            this.GLUExt.HeaderText = "GLUExt";
            this.GLUExt.Name = "GLUExt";
            // 
            // ReportOrder
            // 
            this.ReportOrder.DataPropertyName = "ReportOrder";
            this.ReportOrder.HeaderText = "Report Order";
            this.ReportOrder.Name = "ReportOrder";
            this.ReportOrder.Width = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Test Rate/Cost";
            // 
            // txtCost
            // 
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(147, 130);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(115, 27);
            this.txtCost.TabIndex = 5;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(539, 49);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(292, 27);
            this.txtName.TabIndex = 3;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Test Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(42, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(272, 217);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(106, 32);
            this.cmdDelete.TabIndex = 24;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroup.Location = new System.Drawing.Point(147, 48);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(251, 27);
            this.txtGroup.TabIndex = 111;
            this.txtGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroup_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select Group";
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(841, 28);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(390, 57);
            this.txtComments.TabIndex = 6;
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(837, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Any Comments (On Report Printing)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(283, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Specimen.";
            // 
            // cmbSpecimen
            // 
            this.cmbSpecimen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecimen.FormattingEnabled = true;
            this.cmbSpecimen.Items.AddRange(new object[] {
            "ASCITIC FLUID",
            "Aural Swab",
            "Blood",
            "BAL",
            "Bone Marrow",
            "BRAIN ABSCESS",
            "BRONCHIAL WASH",
            "Cathater tip",
            "Cervical Smear",
            "CONJ. SWAB (LT.)",
            "CONJ. SWAB (RT.)",
            "CONJ. SWAB",
            "CSF",
            "EAR SWAB",
            "SWAB GM.STAIN",
            "ETT",
            "FNAC",
            "GASTRIC ASPIRATE",
            "GASTRIC FLUID",
            "HISTOPATH",
            "HVS",
            "CELLS",
            "M.T.",
            "NAIL CLIPING",
            "Nail scraping",
            "NASAL SWAB",
            "P/S",
            "PAP`S SMEAR",
            "URINE",
            "Pleural Fluid",
            "PUS SWAB",
            "SPUTUM",
            "SKIN SCRAPING",
            "STOOL",
            "SYNOVIAL FLUID",
            "URETHRAL SMEAR",
            "SEMEN"});
            this.cmbSpecimen.Location = new System.Drawing.Point(362, 167);
            this.cmbSpecimen.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSpecimen.Name = "cmbSpecimen";
            this.cmbSpecimen.Size = new System.Drawing.Size(128, 28);
            this.cmbSpecimen.TabIndex = 4;
            this.cmbSpecimen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSpecimen_KeyPress);
            // 
            // dgvTestSubItem
            // 
            this.dgvTestSubItem.AllowUserToAddRows = false;
            this.dgvTestSubItem.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvTestSubItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestSubItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.Column2});
            this.dgvTestSubItem.Location = new System.Drawing.Point(744, 290);
            this.dgvTestSubItem.Name = "dgvTestSubItem";
            this.dgvTestSubItem.RowTemplate.Height = 35;
            this.dgvTestSubItem.Size = new System.Drawing.Size(637, 267);
            this.dgvTestSubItem.TabIndex = 31;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MainTestId";
            this.dataGridViewTextBoxColumn1.HeaderText = "MainTestId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TestId";
            this.Column1.HeaderText = "TestId";
            this.Column1.Name = "Column1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Rate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Qty";
            this.Column2.HeaderText = "Qty";
            this.Column2.Name = "Column2";
            // 
            // btnSaveSubItem
            // 
            this.btnSaveSubItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSubItem.Location = new System.Drawing.Point(764, 575);
            this.btnSaveSubItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSubItem.Name = "btnSaveSubItem";
            this.btnSaveSubItem.Size = new System.Drawing.Size(146, 38);
            this.btnSaveSubItem.TabIndex = 32;
            this.btnSaveSubItem.Text = "Save";
            this.btnSaveSubItem.UseVisualStyleBackColor = true;
            this.btnSaveSubItem.Click += new System.EventHandler(this.btnSaveSubItem_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(716, 257);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(100, 18);
            this.lblTest.TabIndex = 33;
            this.lblTest.Text = "Add New Test";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCode.Location = new System.Drawing.Point(822, 252);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(215, 29);
            this.txtTestCode.TabIndex = 34;
            this.txtTestCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestCode_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1053, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 35;
            this.label7.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(1108, 252);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(71, 29);
            this.txtQty.TabIndex = 36;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(159, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(456, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Test Code";
            // 
            // txtCodeNo
            // 
            this.txtCodeNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeNo.Location = new System.Drawing.Point(539, 16);
            this.txtCodeNo.Name = "txtCodeNo";
            this.txtCodeNo.Size = new System.Drawing.Size(152, 27);
            this.txtCodeNo.TabIndex = 2;
            this.txtCodeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeNo_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(445, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 20);
            this.label11.TabIndex = 335;
            this.label11.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortName.Location = new System.Drawing.Point(539, 85);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(128, 27);
            this.txtShortName.TabIndex = 334;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1192, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 18);
            this.label12.TabIndex = 336;
            this.label12.Text = "Rate";
            // 
            // txtPkgRate
            // 
            this.txtPkgRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgRate.Location = new System.Drawing.Point(1254, 250);
            this.txtPkgRate.Name = "txtPkgRate";
            this.txtPkgRate.Size = new System.Drawing.Size(98, 29);
            this.txtPkgRate.TabIndex = 337;
            this.txtPkgRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPkgRate_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(500, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 20);
            this.label13.TabIndex = 339;
            this.label13.Text = "Process Time";
            // 
            // txtProcessDays
            // 
            this.txtProcessDays.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessDays.Location = new System.Drawing.Point(598, 167);
            this.txtProcessDays.Name = "txtProcessDays";
            this.txtProcessDays.Size = new System.Drawing.Size(77, 27);
            this.txtProcessDays.TabIndex = 338;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(681, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 20);
            this.label14.TabIndex = 340;
            this.label14.Text = "day/s";
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYes.Location = new System.Drawing.Point(859, 95);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(51, 22);
            this.radYes.TabIndex = 342;
            this.radYes.TabStop = true;
            this.radYes.Text = "Yes";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(754, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 20);
            this.label15.TabIndex = 343;
            this.label15.Text = "Is GLU Test?";
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNo.Location = new System.Drawing.Point(916, 95);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(46, 22);
            this.radNo.TabIndex = 344;
            this.radNo.TabStop = true;
            this.radNo.Text = "No";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(987, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 20);
            this.label16.TabIndex = 346;
            this.label16.Text = "GLU Ext.";
            // 
            // txtGLUExt
            // 
            this.txtGLUExt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGLUExt.Location = new System.Drawing.Point(1056, 95);
            this.txtGLUExt.Name = "txtGLUExt";
            this.txtGLUExt.Size = new System.Drawing.Size(72, 27);
            this.txtGLUExt.TabIndex = 345;
            // 
            // txtReportType
            // 
            this.txtReportType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportType.Location = new System.Drawing.Point(147, 13);
            this.txtReportType.Name = "txtReportType";
            this.txtReportType.Size = new System.Drawing.Size(251, 27);
            this.txtReportType.TabIndex = 347;
            this.txtReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportType_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 20);
            this.label17.TabIndex = 348;
            this.label17.Text = "Select Report Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radPkgNo);
            this.groupBox1.Controls.Add(this.radPkgYes);
            this.groupBox1.Location = new System.Drawing.Point(147, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 43);
            this.groupBox1.TabIndex = 351;
            this.groupBox1.TabStop = false;
            // 
            // radPkgNo
            // 
            this.radPkgNo.AutoSize = true;
            this.radPkgNo.Checked = true;
            this.radPkgNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPkgNo.Location = new System.Drawing.Point(63, 14);
            this.radPkgNo.Name = "radPkgNo";
            this.radPkgNo.Size = new System.Drawing.Size(46, 22);
            this.radPkgNo.TabIndex = 346;
            this.radPkgNo.TabStop = true;
            this.radPkgNo.Text = "No";
            this.radPkgNo.UseVisualStyleBackColor = true;
            // 
            // radPkgYes
            // 
            this.radPkgYes.AutoSize = true;
            this.radPkgYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPkgYes.Location = new System.Drawing.Point(6, 14);
            this.radPkgYes.Name = "radPkgYes";
            this.radPkgYes.Size = new System.Drawing.Size(51, 22);
            this.radPkgYes.TabIndex = 345;
            this.radPkgYes.Text = "Yes";
            this.radPkgYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 352;
            this.label5.Text = "Is Package ?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(44, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 354;
            this.label8.Text = "Pkg. Discount";
            // 
            // txtPkgDiscount
            // 
            this.txtPkgDiscount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgDiscount.Location = new System.Drawing.Point(147, 167);
            this.txtPkgDiscount.Name = "txtPkgDiscount";
            this.txtPkgDiscount.Size = new System.Drawing.Size(115, 27);
            this.txtPkgDiscount.TabIndex = 353;
            // 
            // ctrlReportTypeSearch
            // 
            this.ctrlReportTypeSearch.Location = new System.Drawing.Point(501, 618);
            this.ctrlReportTypeSearch.Name = "ctrlReportTypeSearch";
            this.ctrlReportTypeSearch.Size = new System.Drawing.Size(434, 564);
            this.ctrlReportTypeSearch.TabIndex = 350;
            this.ctrlReportTypeSearch.Visible = false;
            // 
            // ctrlTestGroupSearch
            // 
            this.ctrlTestGroupSearch.Location = new System.Drawing.Point(21, 618);
            this.ctrlTestGroupSearch.Name = "ctrlTestGroupSearch";
            this.ctrlTestGroupSearch.Size = new System.Drawing.Size(432, 489);
            this.ctrlTestGroupSearch.TabIndex = 349;
            this.ctrlTestGroupSearch.Visible = false;
            // 
            // txtSearchTest
            // 
            this.txtSearchTest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchTest.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchTest.Location = new System.Drawing.Point(13, 255);
            this.txtSearchTest.Name = "txtSearchTest";
            this.txtSearchTest.PlaceHolderText = "Search Test";
            this.txtSearchTest.Size = new System.Drawing.Size(697, 26);
            this.txtSearchTest.TabIndex = 341;
            this.txtSearchTest.Text = "Search Test";
            this.txtSearchTest.TextChanged += new System.EventHandler(this.txtSearchTest_TextChanged);
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(1036, 536);
            this.ctlTestSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(532, 496);
            this.ctlTestSearch.TabIndex = 37;
            this.ctlTestSearch.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(268, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 356;
            this.label9.Text = "Media Com.";
            // 
            // txtMediaComm
            // 
            this.txtMediaComm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaComm.Location = new System.Drawing.Point(362, 130);
            this.txtMediaComm.Name = "txtMediaComm";
            this.txtMediaComm.Size = new System.Drawing.Size(128, 27);
            this.txtMediaComm.TabIndex = 355;
            // 
            // txtReferralComm
            // 
            this.txtReferralComm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferralComm.Location = new System.Drawing.Point(594, 133);
            this.txtReferralComm.Name = "txtReferralComm";
            this.txtReferralComm.Size = new System.Drawing.Size(132, 27);
            this.txtReferralComm.TabIndex = 357;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(511, 140);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 20);
            this.label18.TabIndex = 358;
            this.label18.Text = "Ref Com.";
            // 
            // frmTestEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1364, 741);
            this.Controls.Add(this.ctrlReportTypeSearch);
            this.Controls.Add(this.ctrlTestGroupSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPkgDiscount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtReportType);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtGLUExt);
            this.Controls.Add(this.radNo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.radYes);
            this.Controls.Add(this.txtSearchTest);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtProcessDays);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPkgRate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCodeNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtTestCode);
            this.Controls.Add(this.btnSaveSubItem);
            this.Controls.Add(this.dgvTestSubItem);
            this.Controls.Add(this.cmbSpecimen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.gvTestlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtReferralComm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMediaComm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestEntry";
            this.Text = "Test Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestSubItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTestlist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSpecimen;
        private System.Windows.Forms.DataGridView dgvTestSubItem;
        private System.Windows.Forms.Button btnSaveSubItem;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQty;
        private TestSearchControl ctlTestSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodeNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPkgRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProcessDays;
        private System.Windows.Forms.Label label14;
        private Controls.PlaceHolderTextBox txtSearchTest;
        private System.Windows.Forms.RadioButton radYes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton radNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtGLUExt;
        private System.Windows.Forms.TextBox txtReportType;
        private System.Windows.Forms.Label label17;
        private Controls.TestGroupSearchControl ctrlTestGroupSearch;
        private Controls.ReportTypeSearchControl ctrlReportTypeSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radPkgNo;
        private System.Windows.Forms.RadioButton radPkgYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPkgDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMediaComm;
        private System.Windows.Forms.TextBox txtReferralComm;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speciman;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediaComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferralCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGLU;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLUExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportOrder;
    }
}