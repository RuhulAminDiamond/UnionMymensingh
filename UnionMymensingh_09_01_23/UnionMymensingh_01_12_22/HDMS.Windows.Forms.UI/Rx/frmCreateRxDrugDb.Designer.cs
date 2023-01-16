namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmCreateRxDrugDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateRxDrugDb));
            this.dgDrug = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDoseShortEn = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoseShortBn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlDoseBnLong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoseEnLong = new System.Windows.Forms.TextBox();
            this.txtDurationValue = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.cmbDurationUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBeforeAfter = new System.Windows.Forms.ComboBox();
            this.txtQtyOrPieces = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbGeneric = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBrandNamePDB = new System.Windows.Forms.TextBox();
            this.lblPDBBrandName = new System.Windows.Forms.Label();
            this.txtBrandShortName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.txtRxProductbyGroup = new System.Windows.Forms.TextBox();
            this.btnAddDosage = new System.Windows.Forms.Button();
            this.txtRxProductbyGen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearchByBrandName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.ctrlRxProductByBrand = new HDMS.Windows.Forms.UI.Controls.PhRxProductSearchControl();
            this.ctrlRxProductByGeneric = new HDMS.Windows.Forms.UI.Controls.PhRxProductSearchControlGeneric();
            this.ctrlDosageSearch = new HDMS.Windows.Forms.UI.Controls.RxCpDosageSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgDrug)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDrug
            // 
            this.dgDrug.AllowUserToAddRows = false;
            this.dgDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDrug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Diagnosis,
            this.ds4,
            this.ds3,
            this.LongDescription,
            this.ds2,
            this.ds5,
            this.Duration,
            this.Column1});
            this.dgDrug.Location = new System.Drawing.Point(12, 287);
            this.dgDrug.Name = "dgDrug";
            this.dgDrug.Size = new System.Drawing.Size(988, 323);
            this.dgDrug.TabIndex = 7;
            this.dgDrug.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDrug_RowHeaderMouseDoubleClick);
            this.dgDrug.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgDrug_UserDeletedRow);
            // 
            // Id
            // 
            this.Id.HeaderText = "IdNo";
            this.Id.Name = "Id";
            // 
            // Diagnosis
            // 
            this.Diagnosis.HeaderText = "Brand Name";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.Width = 180;
            // 
            // ds4
            // 
            this.ds4.HeaderText = "L.Dose(Bn)";
            this.ds4.Name = "ds4";
            this.ds4.Width = 170;
            // 
            // ds3
            // 
            this.ds3.HeaderText = "L.Dose(En)";
            this.ds3.Name = "ds3";
            this.ds3.Width = 170;
            // 
            // LongDescription
            // 
            this.LongDescription.HeaderText = "S.Dose(Bn)";
            this.LongDescription.Name = "LongDescription";
            this.LongDescription.Width = 120;
            // 
            // ds2
            // 
            this.ds2.HeaderText = "S.Dose(En)";
            this.ds2.Name = "ds2";
            this.ds2.Width = 120;
            // 
            // ds5
            // 
            this.ds5.HeaderText = "After/Before";
            this.ds5.Name = "ds5";
            this.ds5.Width = 120;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Unit";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(712, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Short Dose (English)";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(187, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 31);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDoseShortEn
            // 
            this.txtDoseShortEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseShortEn.Location = new System.Drawing.Point(847, 177);
            this.txtDoseShortEn.Multiline = true;
            this.txtDoseShortEn.Name = "txtDoseShortEn";
            this.txtDoseShortEn.Size = new System.Drawing.Size(134, 26);
            this.txtDoseShortEn.TabIndex = 6;
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrand.Location = new System.Drawing.Point(187, 12);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(243, 26);
            this.txtBrand.TabIndex = 0;
            this.txtBrand.TextChanged += new System.EventHandler(this.txtBrand_TextChanged);
            this.txtBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrand_KeyDown);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(20, 12);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(163, 18);
            this.lblBrand.TabIndex = 10165;
            this.lblBrand.Text = "Select Brand (Central DB)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(712, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 10168;
            this.label4.Text = "Short Dose (Bangla)";
            // 
            // txtDoseShortBn
            // 
            this.txtDoseShortBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseShortBn.Location = new System.Drawing.Point(847, 142);
            this.txtDoseShortBn.Multiline = true;
            this.txtDoseShortBn.Name = "txtDoseShortBn";
            this.txtDoseShortBn.Size = new System.Drawing.Size(134, 26);
            this.txtDoseShortBn.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 18);
            this.label5.TabIndex = 10172;
            this.label5.Text = "Long Dose (Bangla)";
            // 
            // txtlDoseBnLong
            // 
            this.txtlDoseBnLong.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlDoseBnLong.Location = new System.Drawing.Point(187, 142);
            this.txtlDoseBnLong.Multiline = true;
            this.txtlDoseBnLong.Name = "txtlDoseBnLong";
            this.txtlDoseBnLong.Size = new System.Drawing.Size(318, 26);
            this.txtlDoseBnLong.TabIndex = 9;
            this.txtlDoseBnLong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlDoseBnLong_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 10170;
            this.label6.Text = "Long Dose (English)";
            // 
            // txtDoseEnLong
            // 
            this.txtDoseEnLong.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoseEnLong.Location = new System.Drawing.Point(187, 177);
            this.txtDoseEnLong.Multiline = true;
            this.txtDoseEnLong.Name = "txtDoseEnLong";
            this.txtDoseEnLong.Size = new System.Drawing.Size(318, 26);
            this.txtDoseEnLong.TabIndex = 7;
            // 
            // txtDurationValue
            // 
            this.txtDurationValue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDurationValue.Location = new System.Drawing.Point(409, 211);
            this.txtDurationValue.Name = "txtDurationValue";
            this.txtDurationValue.Size = new System.Drawing.Size(48, 26);
            this.txtDurationValue.TabIndex = 11;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(342, 213);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(61, 18);
            this.label77.TabIndex = 10189;
            this.label77.Text = "Duration";
            // 
            // cmbDurationUnit
            // 
            this.cmbDurationUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDurationUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDurationUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDurationUnit.FormattingEnabled = true;
            this.cmbDurationUnit.Location = new System.Drawing.Point(459, 211);
            this.cmbDurationUnit.Name = "cmbDurationUnit";
            this.cmbDurationUnit.Size = new System.Drawing.Size(98, 26);
            this.cmbDurationUnit.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 10192;
            this.label7.Text = "After/Before Meal";
            // 
            // cmbBeforeAfter
            // 
            this.cmbBeforeAfter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBeforeAfter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBeforeAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBeforeAfter.FormattingEnabled = true;
            this.cmbBeforeAfter.Location = new System.Drawing.Point(187, 211);
            this.cmbBeforeAfter.Name = "cmbBeforeAfter";
            this.cmbBeforeAfter.Size = new System.Drawing.Size(143, 26);
            this.cmbBeforeAfter.TabIndex = 10;
            // 
            // txtQtyOrPieces
            // 
            this.txtQtyOrPieces.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyOrPieces.Location = new System.Drawing.Point(663, 212);
            this.txtQtyOrPieces.Name = "txtQtyOrPieces";
            this.txtQtyOrPieces.Size = new System.Drawing.Size(84, 26);
            this.txtQtyOrPieces.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 10194;
            this.label2.Text = "Qty/Pieces";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(187, 75);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(318, 27);
            this.cmbGroup.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 10197;
            this.label3.Text = "Group Name";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbManufacturer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(663, 107);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(318, 27);
            this.cmbManufacturer.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(561, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 19);
            this.label8.TabIndex = 10201;
            this.label8.Text = "Manufacturer";
            // 
            // cmbGeneric
            // 
            this.cmbGeneric.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneric.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneric.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneric.FormattingEnabled = true;
            this.cmbGeneric.Location = new System.Drawing.Point(663, 75);
            this.cmbGeneric.Name = "cmbGeneric";
            this.cmbGeneric.Size = new System.Drawing.Size(317, 27);
            this.cmbGeneric.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(556, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 19);
            this.label9.TabIndex = 10199;
            this.label9.Text = "Generic Name";
            // 
            // cmbFormation
            // 
            this.cmbFormation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(187, 107);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(318, 27);
            this.cmbFormation.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(90, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 19);
            this.label10.TabIndex = 10203;
            this.label10.Text = "Formulation";
            // 
            // txtBrandNamePDB
            // 
            this.txtBrandNamePDB.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandNamePDB.Location = new System.Drawing.Point(187, 44);
            this.txtBrandNamePDB.Name = "txtBrandNamePDB";
            this.txtBrandNamePDB.Size = new System.Drawing.Size(318, 26);
            this.txtBrandNamePDB.TabIndex = 1;
            // 
            // lblPDBBrandName
            // 
            this.lblPDBBrandName.AutoSize = true;
            this.lblPDBBrandName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDBBrandName.Location = new System.Drawing.Point(9, 44);
            this.lblPDBBrandName.Name = "lblPDBBrandName";
            this.lblPDBBrandName.Size = new System.Drawing.Size(171, 18);
            this.lblPDBBrandName.TabIndex = 10204;
            this.lblPDBBrandName.Text = "Brand Name (Personal DB)";
            // 
            // txtBrandShortName
            // 
            this.txtBrandShortName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandShortName.Location = new System.Drawing.Point(700, 44);
            this.txtBrandShortName.Name = "txtBrandShortName";
            this.txtBrandShortName.Size = new System.Drawing.Size(281, 26);
            this.txtBrandShortName.TabIndex = 10206;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(574, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 18);
            this.label12.TabIndex = 10207;
            this.label12.Text = "Brand Short Name";
            // 
            // chkDisable
            // 
            this.chkDisable.AutoSize = true;
            this.chkDisable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisable.Location = new System.Drawing.Point(540, 144);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.Size = new System.Drawing.Size(117, 22);
            this.chkDisable.TabIndex = 10208;
            this.chkDisable.Tag = "Pulse";
            this.chkDisable.Text = "Disable Search";
            this.chkDisable.UseVisualStyleBackColor = true;
            // 
            // txtRxProductbyGroup
            // 
            this.txtRxProductbyGroup.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRxProductbyGroup.Location = new System.Drawing.Point(494, 12);
            this.txtRxProductbyGroup.Name = "txtRxProductbyGroup";
            this.txtRxProductbyGroup.Size = new System.Drawing.Size(145, 26);
            this.txtRxProductbyGroup.TabIndex = 10209;
            // 
            // btnAddDosage
            // 
            this.btnAddDosage.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources.Untitled_6_13;
            this.btnAddDosage.Location = new System.Drawing.Point(511, 144);
            this.btnAddDosage.Name = "btnAddDosage";
            this.btnAddDosage.Size = new System.Drawing.Size(24, 24);
            this.btnAddDosage.TabIndex = 10216;
            this.btnAddDosage.UseVisualStyleBackColor = true;
            this.btnAddDosage.Click += new System.EventHandler(this.btnAddDosage_Click);
            // 
            // txtRxProductbyGen
            // 
            this.txtRxProductbyGen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRxProductbyGen.Location = new System.Drawing.Point(700, 12);
            this.txtRxProductbyGen.Name = "txtRxProductbyGen";
            this.txtRxProductbyGen.Size = new System.Drawing.Size(280, 26);
            this.txtRxProductbyGen.TabIndex = 10218;
            this.txtRxProductbyGen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRxProductbyGen_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(436, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 18);
            this.label13.TabIndex = 10219;
            this.label13.Text = "By Grp.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(645, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 18);
            this.label14.TabIndex = 10220;
            this.label14.Text = "By Gen.";
            // 
            // txtSearchByBrandName
            // 
            this.txtSearchByBrandName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByBrandName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByBrandName.Location = new System.Drawing.Point(377, 255);
            this.txtSearchByBrandName.Name = "txtSearchByBrandName";
            this.txtSearchByBrandName.PlaceHolderText = "Search by brand name";
            this.txtSearchByBrandName.Size = new System.Drawing.Size(623, 26);
            this.txtSearchByBrandName.TabIndex = 10221;
            this.txtSearchByBrandName.Text = "Search by brand name";
            this.txtSearchByBrandName.TextChanged += new System.EventHandler(this.txtSearchByBrandName_TextChanged);
            // 
            // ctrlRxProductByBrand
            // 
            this.ctrlRxProductByBrand.Location = new System.Drawing.Point(335, 372);
            this.ctrlRxProductByBrand.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlRxProductByBrand.Name = "ctrlRxProductByBrand";
            this.ctrlRxProductByBrand.Size = new System.Drawing.Size(804, 500);
            this.ctrlRxProductByBrand.TabIndex = 10193;
            this.ctrlRxProductByBrand.Visible = false;
            this.ctrlRxProductByBrand.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl_2<HDMS.Model.Pharmacy.ViewModels.VMPhProductListForRxPerspective>.SearchEscapeEventHandler(this.ctrlRxProductByBrand_SearchEsacaped);
            // 
            // ctrlRxProductByGeneric
            // 
            this.ctrlRxProductByGeneric.Location = new System.Drawing.Point(399, 358);
            this.ctrlRxProductByGeneric.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlRxProductByGeneric.Name = "ctrlRxProductByGeneric";
            this.ctrlRxProductByGeneric.Size = new System.Drawing.Size(775, 509);
            this.ctrlRxProductByGeneric.TabIndex = 10217;
            this.ctrlRxProductByGeneric.Visible = false;
            this.ctrlRxProductByGeneric.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl_2<HDMS.Model.Pharmacy.ViewModels.VMPhProductListForRxPerspective>.SearchEscapeEventHandler(this.ctrlRxProductByGeneric_SearchEsacaped);
            // 
            // ctrlDosageSearch
            // 
            this.ctrlDosageSearch.Location = new System.Drawing.Point(90, 287);
            this.ctrlDosageSearch.Name = "ctrlDosageSearch";
            this.ctrlDosageSearch.Size = new System.Drawing.Size(711, 549);
            this.ctrlDosageSearch.TabIndex = 10222;
            this.ctrlDosageSearch.Visible = false;
            this.ctrlDosageSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Rx.RxCpDosage>.SearchEscapeEventHandler(this.ctrlDosageSearch_SearchEsacaped_1);
            // 
            // frmCreateRxDrugDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 632);
            this.Controls.Add(this.ctrlDosageSearch);
            this.Controls.Add(this.ctrlRxProductByBrand);
            this.Controls.Add(this.ctrlRxProductByGeneric);
            this.Controls.Add(this.txtSearchByBrandName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRxProductbyGen);
            this.Controls.Add(this.btnAddDosage);
            this.Controls.Add(this.txtRxProductbyGroup);
            this.Controls.Add(this.chkDisable);
            this.Controls.Add(this.txtBrandShortName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBrandNamePDB);
            this.Controls.Add(this.lblPDBBrandName);
            this.Controls.Add(this.cmbFormation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbManufacturer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbGeneric);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQtyOrPieces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBeforeAfter);
            this.Controls.Add(this.txtDurationValue);
            this.Controls.Add(this.label77);
            this.Controls.Add(this.cmbDurationUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlDoseBnLong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDoseEnLong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDoseShortBn);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.dgDrug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDoseShortEn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCreateRxDrugDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Personal Drug Database";
            this.Load += new System.EventHandler(this.frmAddDosageTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDrug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDrug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDoseShortEn;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoseShortBn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlDoseBnLong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDoseEnLong;
        private System.Windows.Forms.TextBox txtDurationValue;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox cmbDurationUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBeforeAfter;
        private Controls.PhRxProductSearchControl ctrlRxProductByBrand;
        private System.Windows.Forms.TextBox txtQtyOrPieces;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGeneric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBrandNamePDB;
        private System.Windows.Forms.Label lblPDBBrandName;
        private System.Windows.Forms.TextBox txtBrandShortName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkDisable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox txtRxProductbyGroup;
        private System.Windows.Forms.Button btnAddDosage;
        private Controls.PhRxProductSearchControlGeneric ctrlRxProductByGeneric;
        private System.Windows.Forms.TextBox txtRxProductbyGen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Controls.PlaceHolderTextBox txtSearchByBrandName;
        private Controls.RxCpDosageSearchControl ctrlDosageSearch;
    }
}