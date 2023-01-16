namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmTestDetailsEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestDetailsEntry));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTestCriteria = new System.Windows.Forms.TextBox();
            this.txtNormalValues = new System.Windows.Forms.TextBox();
            this.txtLowerLimit = new System.Windows.Forms.TextBox();
            this.txtUpperLimit = new System.Windows.Forms.TextBox();
            this.chkIsAgeVariant = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResultUnit = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gvTestItemDetail = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReportOrder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGrouptitle = new System.Windows.Forms.TextBox();
            this.cmbFontBold = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbItalic = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbUnderline = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkKeyValue = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtResultOptions = new System.Windows.Forms.TextBox();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Diagonstics.TestSearchControl();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Reportorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTitle_FontBold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTitle_FontUnderline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsKeyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Select Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(155, 20);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(245, 28);
            this.cmbGroup.TabIndex = 0;
            this.cmbGroup.ValueMember = "Id";
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select Test";
            // 
            // txtTestCriteria
            // 
            this.txtTestCriteria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCriteria.Location = new System.Drawing.Point(155, 104);
            this.txtTestCriteria.Name = "txtTestCriteria";
            this.txtTestCriteria.Size = new System.Drawing.Size(245, 27);
            this.txtTestCriteria.TabIndex = 3;
            // 
            // txtNormalValues
            // 
            this.txtNormalValues.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNormalValues.Location = new System.Drawing.Point(519, 144);
            this.txtNormalValues.Multiline = true;
            this.txtNormalValues.Name = "txtNormalValues";
            this.txtNormalValues.Size = new System.Drawing.Size(245, 69);
            this.txtNormalValues.TabIndex = 8;
            // 
            // txtLowerLimit
            // 
            this.txtLowerLimit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowerLimit.Location = new System.Drawing.Point(923, 183);
            this.txtLowerLimit.Name = "txtLowerLimit";
            this.txtLowerLimit.Size = new System.Drawing.Size(108, 27);
            this.txtLowerLimit.TabIndex = 9;
            // 
            // txtUpperLimit
            // 
            this.txtUpperLimit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpperLimit.Location = new System.Drawing.Point(1150, 185);
            this.txtUpperLimit.Name = "txtUpperLimit";
            this.txtUpperLimit.Size = new System.Drawing.Size(124, 27);
            this.txtUpperLimit.TabIndex = 10;
            // 
            // chkIsAgeVariant
            // 
            this.chkIsAgeVariant.AutoSize = true;
            this.chkIsAgeVariant.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsAgeVariant.Location = new System.Drawing.Point(1150, 219);
            this.chkIsAgeVariant.Name = "chkIsAgeVariant";
            this.chkIsAgeVariant.Size = new System.Drawing.Size(145, 24);
            this.chkIsAgeVariant.TabIndex = 6;
            this.chkIsAgeVariant.Text = "Has Age Variant ?";
            this.chkIsAgeVariant.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Report Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Normal Value/s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(831, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Lower Limit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1057, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Upper Limit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Result Unit";
            // 
            // txtResultUnit
            // 
            this.txtResultUnit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultUnit.Location = new System.Drawing.Point(155, 143);
            this.txtResultUnit.Name = "txtResultUnit";
            this.txtResultUnit.Size = new System.Drawing.Size(245, 27);
            this.txtResultUnit.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(155, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 36);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvTestItemDetail
            // 
            this.gvTestItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestItemDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reportorder,
            this.GroupTitle,
            this.TestId,
            this.TestCriteria,
            this.DefaultValue,
            this.NormalValues,
            this.ResultUnit,
            this.ResultOption,
            this.TestTitle_FontBold,
            this.TestTitle_FontUnderline,
            this.IsKeyValue,
            this.Id});
            this.gvTestItemDetail.Location = new System.Drawing.Point(28, 280);
            this.gvTestItemDetail.Name = "gvTestItemDetail";
            this.gvTestItemDetail.Size = new System.Drawing.Size(1315, 417);
            this.gvTestItemDetail.TabIndex = 41;
            this.gvTestItemDetail.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTestItemDetail_RowHeaderMouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "Report Order";
            // 
            // txtReportOrder
            // 
            this.txtReportOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportOrder.Location = new System.Drawing.Point(155, 183);
            this.txtReportOrder.Name = "txtReportOrder";
            this.txtReportOrder.Size = new System.Drawing.Size(108, 27);
            this.txtReportOrder.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(430, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Group Title";
            // 
            // txtGrouptitle
            // 
            this.txtGrouptitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrouptitle.Location = new System.Drawing.Point(519, 20);
            this.txtGrouptitle.Name = "txtGrouptitle";
            this.txtGrouptitle.Size = new System.Drawing.Size(321, 27);
            this.txtGrouptitle.TabIndex = 1;
            // 
            // cmbFontBold
            // 
            this.cmbFontBold.DisplayMember = "Name";
            this.cmbFontBold.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFontBold.FormattingEnabled = true;
            this.cmbFontBold.ItemHeight = 20;
            this.cmbFontBold.Items.AddRange(new object[] {
            "1",
            "0"});
            this.cmbFontBold.Location = new System.Drawing.Point(519, 102);
            this.cmbFontBold.Name = "cmbFontBold";
            this.cmbFontBold.Size = new System.Drawing.Size(57, 28);
            this.cmbFontBold.TabIndex = 4;
            this.cmbFontBold.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(444, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Font Bold";
            // 
            // cmbItalic
            // 
            this.cmbItalic.DisplayMember = "Name";
            this.cmbItalic.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItalic.FormattingEnabled = true;
            this.cmbItalic.ItemHeight = 20;
            this.cmbItalic.Items.AddRange(new object[] {
            "1",
            "0"});
            this.cmbItalic.Location = new System.Drawing.Point(653, 102);
            this.cmbItalic.Name = "cmbItalic";
            this.cmbItalic.Size = new System.Drawing.Size(57, 28);
            this.cmbItalic.TabIndex = 5;
            this.cmbItalic.ValueMember = "Id";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(582, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 20);
            this.label11.TabIndex = 54;
            this.label11.Text = "Font Italic";
            // 
            // cmbUnderline
            // 
            this.cmbUnderline.DisplayMember = "Name";
            this.cmbUnderline.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnderline.FormattingEnabled = true;
            this.cmbUnderline.ItemHeight = 20;
            this.cmbUnderline.Items.AddRange(new object[] {
            "1",
            "0"});
            this.cmbUnderline.Location = new System.Drawing.Point(783, 102);
            this.cmbUnderline.Name = "cmbUnderline";
            this.cmbUnderline.Size = new System.Drawing.Size(57, 28);
            this.cmbUnderline.TabIndex = 6;
            this.cmbUnderline.ValueMember = "Id";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(713, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 56;
            this.label13.Text = "Underline";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(286, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 36);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(409, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 36);
            this.btnDelete.TabIndex = 58;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkKeyValue
            // 
            this.chkKeyValue.AutoSize = true;
            this.chkKeyValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeyValue.Location = new System.Drawing.Point(269, 185);
            this.chkKeyValue.Name = "chkKeyValue";
            this.chkKeyValue.Size = new System.Drawing.Size(174, 24);
            this.chkKeyValue.TabIndex = 59;
            this.chkKeyValue.Text = "Request On Discharge";
            this.chkKeyValue.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(778, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 61;
            this.label12.Text = "Result Value Option";
            // 
            // txtResultOptions
            // 
            this.txtResultOptions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultOptions.Location = new System.Drawing.Point(923, 144);
            this.txtResultOptions.Name = "txtResultOptions";
            this.txtResultOptions.Size = new System.Drawing.Size(351, 27);
            this.txtResultOptions.TabIndex = 62;
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(75, 375);
            this.ctlTestSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(438, 496);
            this.ctlTestSearch.TabIndex = 11219;
            this.ctlTestSearch.Visible = false;
            this.ctlTestSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.TestItem>.SearchEscapeEventHandler(this.ctlTestSearch_SearchEsacaped);
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCode.Location = new System.Drawing.Point(154, 62);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(343, 29);
            this.txtTestCode.TabIndex = 11220;
            this.txtTestCode.TextChanged += new System.EventHandler(this.txtTestCode_TextChanged);
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultValue.Location = new System.Drawing.Point(949, 105);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(312, 27);
            this.txtDefaultValue.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(846, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "Default Value";
            // 
            // Reportorder
            // 
            this.Reportorder.DataPropertyName = "DetailReportOrder";
            this.Reportorder.HeaderText = "R/order";
            this.Reportorder.Name = "Reportorder";
            this.Reportorder.Width = 80;
            // 
            // GroupTitle
            // 
            this.GroupTitle.DataPropertyName = "GroupTitle";
            this.GroupTitle.HeaderText = "GroupTitle";
            this.GroupTitle.Name = "GroupTitle";
            // 
            // TestId
            // 
            this.TestId.DataPropertyName = "TestId";
            this.TestId.HeaderText = "Test Id";
            this.TestId.Name = "TestId";
            this.TestId.Width = 70;
            // 
            // TestCriteria
            // 
            this.TestCriteria.DataPropertyName = "TestTitle";
            this.TestCriteria.HeaderText = "Test Title";
            this.TestCriteria.Name = "TestCriteria";
            this.TestCriteria.Width = 300;
            // 
            // DefaultValue
            // 
            this.DefaultValue.DataPropertyName = "DefaultValue";
            this.DefaultValue.HeaderText = "Default Value";
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.Width = 150;
            // 
            // NormalValues
            // 
            this.NormalValues.DataPropertyName = "NormalValue";
            this.NormalValues.HeaderText = "Normal Value";
            this.NormalValues.Name = "NormalValues";
            this.NormalValues.Width = 150;
            // 
            // ResultUnit
            // 
            this.ResultUnit.DataPropertyName = "ResultUnit";
            this.ResultUnit.HeaderText = "Unit";
            this.ResultUnit.Name = "ResultUnit";
            this.ResultUnit.Width = 70;
            // 
            // ResultOption
            // 
            this.ResultOption.DataPropertyName = "ResultOption";
            this.ResultOption.HeaderText = "Result Option";
            this.ResultOption.Name = "ResultOption";
            this.ResultOption.Width = 170;
            // 
            // TestTitle_FontBold
            // 
            this.TestTitle_FontBold.DataPropertyName = "TestTitle_FontBold";
            this.TestTitle_FontBold.HeaderText = "TT_FontBold";
            this.TestTitle_FontBold.Name = "TestTitle_FontBold";
            // 
            // TestTitle_FontUnderline
            // 
            this.TestTitle_FontUnderline.DataPropertyName = "TestTitle_FontUnderline";
            this.TestTitle_FontUnderline.HeaderText = "TT_Underline";
            this.TestTitle_FontUnderline.Name = "TestTitle_FontUnderline";
            // 
            // IsKeyValue
            // 
            this.IsKeyValue.DataPropertyName = "IsKeyValue";
            this.IsKeyValue.HeaderText = "On Discharge";
            this.IsKeyValue.Name = "IsKeyValue";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 50;
            // 
            // frmTestDetailsEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.txtTestCode);
            this.Controls.Add(this.txtResultOptions);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkKeyValue);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbUnderline);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbItalic);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbFontBold);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGrouptitle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReportOrder);
            this.Controls.Add(this.gvTestItemDetail);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtResultUnit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkIsAgeVariant);
            this.Controls.Add(this.txtDefaultValue);
            this.Controls.Add(this.txtUpperLimit);
            this.Controls.Add(this.txtLowerLimit);
            this.Controls.Add(this.txtNormalValues);
            this.Controls.Add(this.txtTestCriteria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestDetailsEntry";
            this.Text = "Report Settings";
            this.Load += new System.EventHandler(this.frmTestDetailsEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestItemDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTestCriteria;
        private System.Windows.Forms.TextBox txtNormalValues;
        private System.Windows.Forms.TextBox txtLowerLimit;
        private System.Windows.Forms.TextBox txtUpperLimit;
        private System.Windows.Forms.CheckBox chkIsAgeVariant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResultUnit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvTestItemDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReportOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGrouptitle;
        private System.Windows.Forms.ComboBox cmbFontBold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbItalic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbUnderline;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkKeyValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtResultOptions;
        private TestSearchControl ctlTestSearch;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reportorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTitle_FontBold;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTitle_FontUnderline;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsKeyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}