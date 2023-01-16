namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlTemplateDischargePart1
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
            this.label16 = new System.Windows.Forms.Label();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Srl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.btnAddDosage = new System.Windows.Forms.Button();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtDosages = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGeneric = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCabin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.cmbBeforeAfter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radAdviceEn = new System.Windows.Forms.RadioButton();
            this.radAdviceBn = new System.Windows.Forms.RadioButton();
            this.ctrlPhProductSearchControl = new HDMS.Windows.Forms.UI.Controls.ctrlPhProductInfoWithGenMan();
            this.ctrlDosageSearch = new HDMS.Windows.Forms.UI.Controls.RxDosageSearchControl();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(943, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 18);
            this.label16.TabIndex = 10146;
            this.label16.Text = "Duration";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MName,
            this.Dosage,
            this.ApplyOn,
            this.Duration,
            this.Unit,
            this.MId,
            this.Srl});
            this.dgProducts.Location = new System.Drawing.Point(398, 150);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(747, 223);
            this.dgProducts.TabIndex = 10144;
            // 
            // MName
            // 
            this.MName.DataPropertyName = "Name";
            this.MName.HeaderText = "Name";
            this.MName.Name = "MName";
            this.MName.Width = 200;
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage";
            this.Dosage.HeaderText = "Dosage";
            this.Dosage.Name = "Dosage";
            this.Dosage.Width = 150;
            // 
            // ApplyOn
            // 
            this.ApplyOn.HeaderText = "Apply On";
            this.ApplyOn.Name = "ApplyOn";
            this.ApplyOn.Width = 120;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // MId
            // 
            this.MId.DataPropertyName = "Id";
            this.MId.HeaderText = "MId";
            this.MId.Name = "MId";
            // 
            // Srl
            // 
            this.Srl.HeaderText = "Srl#";
            this.Srl.Name = "Srl";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(1091, 119);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 24);
            this.btnAdd.TabIndex = 10142;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(996, 120);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(89, 26);
            this.cmbUnit.TabIndex = 10141;
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnit_KeyDown);
            // 
            // btnAddDosage
            // 
            this.btnAddDosage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDosage.Location = new System.Drawing.Point(759, 120);
            this.btnAddDosage.Name = "btnAddDosage";
            this.btnAddDosage.Size = new System.Drawing.Size(28, 23);
            this.btnAddDosage.TabIndex = 10140;
            this.btnAddDosage.Text = "+";
            this.btnAddDosage.UseVisualStyleBackColor = true;
            this.btnAddDosage.Click += new System.EventHandler(this.btnAddDosage_Click);
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrand.Location = new System.Drawing.Point(398, 120);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(160, 26);
            this.txtBrand.TabIndex = 10139;
            this.txtBrand.TextChanged += new System.EventHandler(this.txtBrand_TextChanged);
            // 
            // txtDosages
            // 
            this.txtDosages.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDosages.Location = new System.Drawing.Point(648, 120);
            this.txtDosages.Name = "txtDosages";
            this.txtDosages.Size = new System.Drawing.Size(105, 26);
            this.txtDosages.TabIndex = 10138;
            this.txtDosages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDosages_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(395, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 18);
            this.label11.TabIndex = 10137;
            this.label11.Text = "Brand Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(645, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 18);
            this.label13.TabIndex = 10136;
            this.label13.Text = "Dosage/s";
            // 
            // txtGeneric
            // 
            this.txtGeneric.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneric.Location = new System.Drawing.Point(398, 71);
            this.txtGeneric.Name = "txtGeneric";
            this.txtGeneric.Size = new System.Drawing.Size(355, 26);
            this.txtGeneric.TabIndex = 10149;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 10148;
            this.label1.Text = "Generic";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 698);
            this.panel1.TabIndex = 10150;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 698);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgPatient
            // 
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatient.Location = new System.Drawing.Point(3, 55);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(379, 640);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cabin No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Patinet Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(398, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 35);
            this.btnSave.TabIndex = 10152;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(903, 17);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10156;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(847, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 10155;
            this.label8.Text = "Cabin :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(394, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 10154;
            this.label9.Text = "Name :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(453, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10153;
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(942, 120);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(48, 26);
            this.txtDuration.TabIndex = 10157;
            this.txtDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuration_KeyPress);
            // 
            // cmbBeforeAfter
            // 
            this.cmbBeforeAfter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBeforeAfter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBeforeAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBeforeAfter.FormattingEnabled = true;
            this.cmbBeforeAfter.Location = new System.Drawing.Point(793, 120);
            this.cmbBeforeAfter.Name = "cmbBeforeAfter";
            this.cmbBeforeAfter.Size = new System.Drawing.Size(143, 26);
            this.cmbBeforeAfter.TabIndex = 10158;
            this.cmbBeforeAfter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBeforeAfter_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(790, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 10159;
            this.label2.Text = "After/Before Meal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1010, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 10160;
            this.label3.Text = "Unit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radAdviceEn
            // 
            this.radAdviceEn.AutoSize = true;
            this.radAdviceEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAdviceEn.Location = new System.Drawing.Point(607, 121);
            this.radAdviceEn.Name = "radAdviceEn";
            this.radAdviceEn.Size = new System.Drawing.Size(41, 22);
            this.radAdviceEn.TabIndex = 10214;
            this.radAdviceEn.Text = "En";
            this.radAdviceEn.UseVisualStyleBackColor = true;
            // 
            // radAdviceBn
            // 
            this.radAdviceBn.AutoSize = true;
            this.radAdviceBn.Checked = true;
            this.radAdviceBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAdviceBn.Location = new System.Drawing.Point(564, 121);
            this.radAdviceBn.Name = "radAdviceBn";
            this.radAdviceBn.Size = new System.Drawing.Size(42, 22);
            this.radAdviceBn.TabIndex = 10213;
            this.radAdviceBn.TabStop = true;
            this.radAdviceBn.Text = "Bn";
            this.radAdviceBn.UseVisualStyleBackColor = true;
            // 
            // ctrlPhProductSearchControl
            // 
            this.ctrlPhProductSearchControl.Location = new System.Drawing.Point(738, 424);
            this.ctrlPhProductSearchControl.Name = "ctrlPhProductSearchControl";
            this.ctrlPhProductSearchControl.Size = new System.Drawing.Size(853, 503);
            this.ctrlPhProductSearchControl.TabIndex = 10147;
            this.ctrlPhProductSearchControl.Visible = false;
            this.ctrlPhProductSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Pharmacy.VWPhProductList>.SearchEscapeEventHandler(this.ctrlPhProductSearchControl_SearchEsacaped);
            // 
            // ctrlDosageSearch
            // 
            this.ctrlDosageSearch.Location = new System.Drawing.Point(354, 186);
            this.ctrlDosageSearch.Name = "ctrlDosageSearch";
            this.ctrlDosageSearch.Size = new System.Drawing.Size(905, 443);
            this.ctrlDosageSearch.TabIndex = 10151;
            this.ctrlDosageSearch.Visible = false;
            this.ctrlDosageSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Rx.RxDosage>.SearchEscapeEventHandler(this.ctrlDosageSearch_SearchEsacaped);
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(6, 13);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(373, 25);
            this.txtSearchByCabin.TabIndex = 1;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // ctrlTemplateDischargePart1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDosageSearch);
            this.Controls.Add(this.radAdviceEn);
            this.Controls.Add(this.radAdviceBn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBeforeAfter);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ctrlPhProductSearchControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtGeneric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.btnAddDosage);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtDosages);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Name = "ctrlTemplateDischargePart1";
            this.Size = new System.Drawing.Size(1218, 698);
            this.Load += new System.EventHandler(this.ctrlTemplateDischargePart1_Load);
            this.Resize += new System.EventHandler(this.ctrlTemplateDischargePart1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Button btnAddDosage;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtDosages;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private Controls.ctrlPhProductInfoWithGenMan ctrlPhProductSearchControl;
        private System.Windows.Forms.TextBox txtGeneric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private Controls.RxDosageSearchControl ctrlDosageSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox cmbBeforeAfter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplyOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Srl;
        private System.Windows.Forms.RadioButton radAdviceEn;
        private System.Windows.Forms.RadioButton radAdviceBn;
    }
}
