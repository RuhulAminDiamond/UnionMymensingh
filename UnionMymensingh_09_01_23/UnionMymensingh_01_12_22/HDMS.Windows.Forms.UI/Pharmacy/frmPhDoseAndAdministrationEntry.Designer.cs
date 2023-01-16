namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmPhDoseAndAdministrationEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhDoseAndAdministrationEntry));
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContraIndication = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSideEffact = new System.Windows.Forms.TextBox();
            this.txtIndicate = new System.Windows.Forms.TextBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGeneric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlDoseBnLong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoseEnLong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDoseShortBn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDoseShortEn = new System.Windows.Forms.TextBox();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseBnLn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseLnEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseShBn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoseShortEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SideEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddDosage = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBeforeAfter = new System.Windows.Forms.ComboBox();
            this.txtDurationValue = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.cmbDurationUnit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbltotalItems = new System.Windows.Forms.Label();
            this.ctrlDosageSearch = new HDMS.Windows.Forms.UI.Controls.RxDosageSearchControl();
            this.txtSearchByGen = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(942, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 19);
            this.label14.TabIndex = 43;
            this.label14.Text = "Side Effect";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(946, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 19);
            this.label11.TabIndex = 41;
            this.label11.Text = "Indication";
            // 
            // txtContraIndication
            // 
            this.txtContraIndication.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraIndication.Location = new System.Drawing.Point(1025, 55);
            this.txtContraIndication.Multiline = true;
            this.txtContraIndication.Name = "txtContraIndication";
            this.txtContraIndication.Size = new System.Drawing.Size(291, 38);
            this.txtContraIndication.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(903, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 19);
            this.label13.TabIndex = 45;
            this.label13.Text = "Contraindication";
            // 
            // txtSideEffact
            // 
            this.txtSideEffact.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSideEffact.Location = new System.Drawing.Point(1025, 105);
            this.txtSideEffact.Multiline = true;
            this.txtSideEffact.Name = "txtSideEffact";
            this.txtSideEffact.Size = new System.Drawing.Size(291, 38);
            this.txtSideEffact.TabIndex = 40;
            // 
            // txtIndicate
            // 
            this.txtIndicate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicate.Location = new System.Drawing.Point(1025, 14);
            this.txtIndicate.Multiline = true;
            this.txtIndicate.Name = "txtIndicate";
            this.txtIndicate.Size = new System.Drawing.Size(291, 34);
            this.txtIndicate.TabIndex = 38;
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbManufacturer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(137, 154);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(263, 27);
            this.cmbManufacturer.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 55;
            this.label7.Text = "Manufacturer";
            // 
            // cmbFormation
            // 
            this.cmbFormation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(137, 121);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(187, 27);
            this.cmbFormation.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 54;
            this.label6.Text = "Formulation";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(137, 55);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(263, 27);
            this.cmbGroup.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 53;
            this.label4.Text = "Group Name";
            // 
            // cmbGeneric
            // 
            this.cmbGeneric.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneric.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneric.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneric.FormattingEnabled = true;
            this.cmbGeneric.Location = new System.Drawing.Point(137, 88);
            this.cmbGeneric.Name = "cmbGeneric";
            this.cmbGeneric.Size = new System.Drawing.Size(266, 27);
            this.cmbGeneric.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 50;
            this.label3.Text = "Generic";
            // 
            // txtBName
            // 
            this.txtBName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBName.Location = new System.Drawing.Point(137, 21);
            this.txtBName.Name = "txtBName";
            this.txtBName.Size = new System.Drawing.Size(266, 27);
            this.txtBName.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "Brand Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(430, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 19);
            this.label5.TabIndex = 10180;
            this.label5.Text = "Long Dose (Bangla)";
            // 
            // txtlDoseBnLong
            // 
            this.txtlDoseBnLong.Enabled = false;
            this.txtlDoseBnLong.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlDoseBnLong.Location = new System.Drawing.Point(572, 121);
            this.txtlDoseBnLong.Multiline = true;
            this.txtlDoseBnLong.Name = "txtlDoseBnLong";
            this.txtlDoseBnLong.Size = new System.Drawing.Size(318, 26);
            this.txtlDoseBnLong.TabIndex = 10177;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 10179;
            this.label1.Text = "Long Dose (English)";
            // 
            // txtDoseEnLong
            // 
            this.txtDoseEnLong.Enabled = false;
            this.txtDoseEnLong.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseEnLong.Location = new System.Drawing.Point(572, 88);
            this.txtDoseEnLong.Multiline = true;
            this.txtDoseEnLong.Name = "txtDoseEnLong";
            this.txtDoseEnLong.Size = new System.Drawing.Size(318, 26);
            this.txtDoseEnLong.TabIndex = 10175;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(428, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 19);
            this.label8.TabIndex = 10178;
            this.label8.Text = "Short Dose (Bangla)";
            // 
            // txtDoseShortBn
            // 
            this.txtDoseShortBn.Enabled = false;
            this.txtDoseShortBn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseShortBn.Location = new System.Drawing.Point(572, 55);
            this.txtDoseShortBn.Multiline = true;
            this.txtDoseShortBn.Name = "txtDoseShortBn";
            this.txtDoseShortBn.Size = new System.Drawing.Size(134, 26);
            this.txtDoseShortBn.TabIndex = 10176;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(426, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 19);
            this.label9.TabIndex = 10173;
            this.label9.Text = "Short Dose (English)";
            // 
            // txtDoseShortEn
            // 
            this.txtDoseShortEn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseShortEn.Location = new System.Drawing.Point(572, 21);
            this.txtDoseShortEn.Multiline = true;
            this.txtDoseShortEn.Name = "txtDoseShortEn";
            this.txtDoseShortEn.Size = new System.Drawing.Size(134, 26);
            this.txtDoseShortEn.TabIndex = 10174;
            this.txtDoseShortEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoseShortEn_KeyPress);
            // 
            // dgProducts
            // 
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.Group,
            this.Generic,
            this.Manufacturer,
            this.DoseBnLn,
            this.DoseLnEn,
            this.DoseShBn,
            this.DoseShortEn,
            this.SideEffect,
            this.Duration});
            this.dgProducts.Location = new System.Drawing.Point(38, 231);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(1302, 423);
            this.dgProducts.TabIndex = 10181;
            this.dgProducts.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProducts_RowHeaderMouseDoubleClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 80;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 150;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.Width = 150;
            // 
            // Generic
            // 
            this.Generic.HeaderText = "Generic";
            this.Generic.Name = "Generic";
            this.Generic.Width = 150;
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Width = 150;
            // 
            // DoseBnLn
            // 
            this.DoseBnLn.HeaderText = "Dose Longn(Bn)";
            this.DoseBnLn.Name = "DoseBnLn";
            this.DoseBnLn.Width = 120;
            // 
            // DoseLnEn
            // 
            this.DoseLnEn.HeaderText = "Dose Long (En)";
            this.DoseLnEn.Name = "DoseLnEn";
            this.DoseLnEn.Width = 120;
            // 
            // DoseShBn
            // 
            this.DoseShBn.HeaderText = "Dose Short(Bn)";
            this.DoseShBn.Name = "DoseShBn";
            this.DoseShBn.Width = 120;
            // 
            // DoseShortEn
            // 
            this.DoseShortEn.HeaderText = "Dose Short(En)";
            this.DoseShortEn.Name = "DoseShortEn";
            this.DoseShortEn.Width = 120;
            // 
            // SideEffect
            // 
            this.SideEffect.HeaderText = "Before/After";
            this.SideEffect.Name = "SideEffect";
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(1218, 196);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(122, 29);
            this.btnRefreshList.TabIndex = 10183;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(272, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 38);
            this.btnCancel.TabIndex = 10185;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(136, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 38);
            this.btnSave.TabIndex = 10184;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddDosage
            // 
            this.btnAddDosage.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources.Untitled_6_13;
            this.btnAddDosage.Location = new System.Drawing.Point(712, 21);
            this.btnAddDosage.Name = "btnAddDosage";
            this.btnAddDosage.Size = new System.Drawing.Size(24, 24);
            this.btnAddDosage.TabIndex = 10217;
            this.btnAddDosage.UseVisualStyleBackColor = true;
            this.btnAddDosage.Click += new System.EventHandler(this.btnAddDosage_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(440, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 18);
            this.label10.TabIndex = 10223;
            this.label10.Text = "After/Before Meal";
            // 
            // cmbBeforeAfter
            // 
            this.cmbBeforeAfter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBeforeAfter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBeforeAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBeforeAfter.FormattingEnabled = true;
            this.cmbBeforeAfter.Location = new System.Drawing.Point(572, 154);
            this.cmbBeforeAfter.Name = "cmbBeforeAfter";
            this.cmbBeforeAfter.Size = new System.Drawing.Size(152, 26);
            this.cmbBeforeAfter.TabIndex = 10219;
            // 
            // txtDurationValue
            // 
            this.txtDurationValue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDurationValue.Location = new System.Drawing.Point(572, 187);
            this.txtDurationValue.Name = "txtDurationValue";
            this.txtDurationValue.Size = new System.Drawing.Size(48, 26);
            this.txtDurationValue.TabIndex = 10220;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(509, 188);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(61, 18);
            this.label77.TabIndex = 10222;
            this.label77.Text = "Duration";
            // 
            // cmbDurationUnit
            // 
            this.cmbDurationUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDurationUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDurationUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDurationUnit.FormattingEnabled = true;
            this.cmbDurationUnit.Location = new System.Drawing.Point(626, 187);
            this.cmbDurationUnit.Name = "cmbDurationUnit";
            this.cmbDurationUnit.Size = new System.Drawing.Size(98, 26);
            this.cmbDurationUnit.TabIndex = 10221;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(34, 660);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 10225;
            this.label12.Text = "Total Items :";
            // 
            // lbltotalItems
            // 
            this.lbltotalItems.AutoSize = true;
            this.lbltotalItems.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalItems.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltotalItems.Location = new System.Drawing.Point(132, 660);
            this.lbltotalItems.Name = "lbltotalItems";
            this.lbltotalItems.Size = new System.Drawing.Size(0, 19);
            this.lbltotalItems.TabIndex = 10226;
            // 
            // ctrlDosageSearch
            // 
            this.ctrlDosageSearch.Location = new System.Drawing.Point(50, 284);
            this.ctrlDosageSearch.Name = "ctrlDosageSearch";
            this.ctrlDosageSearch.Size = new System.Drawing.Size(1071, 650);
            this.ctrlDosageSearch.TabIndex = 10218;
            // 
            // txtSearchByGen
            // 
            this.txtSearchByGen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByGen.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByGen.Location = new System.Drawing.Point(754, 199);
            this.txtSearchByGen.Name = "txtSearchByGen";
            this.txtSearchByGen.PlaceHolderText = "Search by generic";
            this.txtSearchByGen.Size = new System.Drawing.Size(231, 26);
            this.txtSearchByGen.TabIndex = 10224;
            this.txtSearchByGen.Text = "Search by generic";
            this.txtSearchByGen.TextChanged += new System.EventHandler(this.txtSearchByGen_TextChanged);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByName.Location = new System.Drawing.Point(991, 199);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PlaceHolderText = "Search by brand name";
            this.txtSearchByName.Size = new System.Drawing.Size(221, 26);
            this.txtSearchByName.TabIndex = 10182;
            this.txtSearchByName.Text = "Search by brand name";
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // frmPhDoseAndAdministrationEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 699);
            this.Controls.Add(this.lbltotalItems);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ctrlDosageSearch);
            this.Controls.Add(this.txtSearchByGen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbBeforeAfter);
            this.Controls.Add(this.txtDurationValue);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.cmbDurationUnit);
            this.Controls.Add(this.btnAddDosage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlDoseBnLong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoseEnLong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDoseShortBn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDoseShortEn);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbFormation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbGeneric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtContraIndication);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSideEffact);
            this.Controls.Add(this.txtIndicate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhDoseAndAdministrationEntry";
            this.Text = "Drug Dose And Administration Entry";
            this.Load += new System.EventHandler(this.frmPhDoseAndAdministrationEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContraIndication;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSideEffact;
        private System.Windows.Forms.TextBox txtIndicate;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGeneric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlDoseBnLong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoseEnLong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDoseShortBn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDoseShortEn;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Button btnRefreshList;
        private Controls.PlaceHolderTextBox txtSearchByName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddDosage;
        private Controls.RxDosageSearchControl ctrlDosageSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBeforeAfter;
        private System.Windows.Forms.TextBox txtDurationValue;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox cmbDurationUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseBnLn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseLnEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseShBn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoseShortEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SideEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private Controls.PlaceHolderTextBox txtSearchByGen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbltotalItems;
    }
}