namespace HDMS.Windows.Forms.UI
{
    partial class FromUXEReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromUXEReport));
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPreparedBy = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTemplates = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvReports = new System.Windows.Forms.ListView();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmbConsultant = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCurrentTestName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tv = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLabelPrint = new System.Windows.Forms.Button();
            this.txtSelectedPatientId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvUxList = new System.Windows.Forms.DataGridView();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMemberRegNo = new System.Windows.Forms.TextBox();
            this.txtCabin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ctrlTemplateSearch = new HDMS.Windows.Forms.UI.Diagonstics.TemplateSearchControl();
            this.tabControl1.SuspendLayout();
            this.tabTemplates.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUxList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientName.Location = new System.Drawing.Point(88, 12);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(235, 26);
            this.txtPatientName.TabIndex = 12;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(31, 12);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(48, 18);
            this.lblPatientName.TabIndex = 11;
            this.lblPatientName.Text = "Name";
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(15, 53);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(64, 18);
            this.lblRefBy.TabIndex = 10;
            this.lblRefBy.Text = "Refd. By";
            this.lblRefBy.Click += new System.EventHandler(this.lblRefBy_Click);
            // 
            // txtRefBy
            // 
            this.txtRefBy.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefBy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefBy.Location = new System.Drawing.Point(88, 53);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(399, 26);
            this.txtRefBy.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Age";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(520, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sex";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(386, 12);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(101, 26);
            this.txtAge.TabIndex = 15;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSex
            // 
            this.txtSex.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSex.Location = new System.Drawing.Point(554, 12);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(101, 26);
            this.txtSex.TabIndex = 16;
            this.txtSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(734, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Prepared By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(719, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Date and Time";
            // 
            // lblPreparedBy
            // 
            this.lblPreparedBy.AutoSize = true;
            this.lblPreparedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblPreparedBy.ForeColor = System.Drawing.Color.Red;
            this.lblPreparedBy.Location = new System.Drawing.Point(841, 49);
            this.lblPreparedBy.Name = "lblPreparedBy";
            this.lblPreparedBy.Size = new System.Drawing.Size(99, 18);
            this.lblPreparedBy.TabIndex = 20;
            this.lblPreparedBy.Text = "lblPreparedBy";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDateTime.ForeColor = System.Drawing.Color.Red;
            this.lblDateTime.Location = new System.Drawing.Point(841, 67);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(146, 18);
            this.lblDateTime.TabIndex = 21;
            this.lblDateTime.Text = "lblPreparedDateTime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Bill No";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(88, 109);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(195, 35);
            this.txtBillNo.TabIndex = 0;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNo_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTemplates);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tabControl1.Location = new System.Drawing.Point(289, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 575);
            this.tabControl1.TabIndex = 23;
            this.tabControl1.TabStop = false;
            // 
            // tabTemplates
            // 
            this.tabTemplates.BackColor = System.Drawing.Color.Gainsboro;
            this.tabTemplates.Controls.Add(this.panel1);
            this.tabTemplates.Controls.Add(this.cmbConsultant);
            this.tabTemplates.Controls.Add(this.label10);
            this.tabTemplates.Controls.Add(this.label9);
            this.tabTemplates.Controls.Add(this.label8);
            this.tabTemplates.Controls.Add(this.txtCurrentTestName);
            this.tabTemplates.Controls.Add(this.label7);
            this.tabTemplates.Controls.Add(this.DateTimePicker);
            this.tabTemplates.Controls.Add(this.txtTemplate);
            this.tabTemplates.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTemplates.Location = new System.Drawing.Point(4, 27);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tabTemplates.Size = new System.Drawing.Size(722, 544);
            this.tabTemplates.TabIndex = 0;
            this.tabTemplates.Text = "Report Templates & Delivered Report";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.ctrlTemplateSearch);
            this.panel1.Controls.Add(this.lvReports);
            this.panel1.Location = new System.Drawing.Point(4, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 462);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.lvReports.Location = new System.Drawing.Point(10, 10);
            this.lvReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvReports.Name = "lvReports";
            this.lvReports.ShowItemToolTips = true;
            this.lvReports.Size = new System.Drawing.Size(690, 438);
            this.lvReports.SmallImageList = this.imgListSmall;
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
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "smallIcon.bmp");
            // 
            // cmbConsultant
            // 
            this.cmbConsultant.FormattingEnabled = true;
            this.cmbConsultant.Location = new System.Drawing.Point(484, 7);
            this.cmbConsultant.Name = "cmbConsultant";
            this.cmbConsultant.Size = new System.Drawing.Size(235, 25);
            this.cmbConsultant.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Consultant";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Select Template";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Selected Test";
            // 
            // txtCurrentTestName
            // 
            this.txtCurrentTestName.Location = new System.Drawing.Point(129, 7);
            this.txtCurrentTestName.Name = "txtCurrentTestName";
            this.txtCurrentTestName.Size = new System.Drawing.Size(275, 25);
            this.txtCurrentTestName.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Date";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker.Location = new System.Drawing.Point(531, 48);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(126, 25);
            this.DateTimePicker.TabIndex = 3;
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // txtTemplate
            // 
            this.txtTemplate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.Location = new System.Drawing.Point(129, 48);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(341, 25);
            this.txtTemplate.TabIndex = 1;
            this.txtTemplate.TextChanged += new System.EventHandler(this.txtTemplate_TextChanged);
            this.txtTemplate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemplate_KeyPress);
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(737, 9);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(117, 26);
            this.txtDate.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(696, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Date";
            // 
            // Tv
            // 
            this.Tv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Tv.Location = new System.Drawing.Point(3, 159);
            this.Tv.Name = "Tv";
            this.Tv.Size = new System.Drawing.Size(280, 504);
            this.Tv.TabIndex = 26;
            this.Tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tv_AfterSelect);
            this.Tv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tv_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnLabelPrint);
            this.panel2.Controls.Add(this.txtSelectedPatientId);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dgvUxList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1021, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 745);
            this.panel2.TabIndex = 27;
            // 
            // btnLabelPrint
            // 
            this.btnLabelPrint.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabelPrint.Location = new System.Drawing.Point(145, 569);
            this.btnLabelPrint.Name = "btnLabelPrint";
            this.btnLabelPrint.Size = new System.Drawing.Size(148, 39);
            this.btnLabelPrint.TabIndex = 22;
            this.btnLabelPrint.Text = "Print Token";
            this.btnLabelPrint.UseVisualStyleBackColor = true;
            this.btnLabelPrint.Click += new System.EventHandler(this.btnPrintLabel);
            // 
            // txtSelectedPatientId
            // 
            this.txtSelectedPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtSelectedPatientId.Location = new System.Drawing.Point(156, 516);
            this.txtSelectedPatientId.Name = "txtSelectedPatientId";
            this.txtSelectedPatientId.Size = new System.Drawing.Size(119, 29);
            this.txtSelectedPatientId.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 516);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 18);
            this.label13.TabIndex = 20;
            this.label13.Text = "Selected Patient";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(99, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvUxList
            // 
            this.dgvUxList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUxList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNo,
            this.Column2});
            this.dgvUxList.Location = new System.Drawing.Point(4, 46);
            this.dgvUxList.Name = "dgvUxList";
            this.dgvUxList.Size = new System.Drawing.Size(329, 444);
            this.dgvUxList.TabIndex = 0;
            this.dgvUxList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUxList_RowHeaderMouseClick);
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "BillNo";
            this.BillNo.Name = "BillNo";
            this.BillNo.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PatientName";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // txtDID
            // 
            this.txtDID.Enabled = false;
            this.txtDID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDID.Location = new System.Drawing.Point(644, -100);
            this.txtDID.Name = "txtDID";
            this.txtDID.Size = new System.Drawing.Size(53, 26);
            this.txtDID.TabIndex = 29;
            this.txtDID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(610, -100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 18);
            this.label12.TabIndex = 28;
            this.label12.Text = "DID";
            // 
            // txtMemberRegNo
            // 
            this.txtMemberRegNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberRegNo.Location = new System.Drawing.Point(88, -100);
            this.txtMemberRegNo.Name = "txtMemberRegNo";
            this.txtMemberRegNo.Size = new System.Drawing.Size(195, 26);
            this.txtMemberRegNo.TabIndex = 30;
            // 
            // txtCabin
            // 
            this.txtCabin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabin.Location = new System.Drawing.Point(554, 56);
            this.txtCabin.Name = "txtCabin";
            this.txtCabin.Size = new System.Drawing.Size(101, 26);
            this.txtCabin.TabIndex = 32;
            this.txtCabin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(508, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 18);
            this.label14.TabIndex = 31;
            this.label14.Text = "Cabin";
            // 
            // ctrlTemplateSearch
            // 
            this.ctrlTemplateSearch.Location = new System.Drawing.Point(93, 0);
            this.ctrlTemplateSearch.Margin = new System.Windows.Forms.Padding(16);
            this.ctrlTemplateSearch.Name = "ctrlTemplateSearch";
            this.ctrlTemplateSearch.Size = new System.Drawing.Size(560, 1561);
            this.ctrlTemplateSearch.TabIndex = 31;
            this.ctrlTemplateSearch.Visible = false;
            this.ctrlTemplateSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Template>.SearchEscapeEventHandler(this.ctrlTemplateSearch_SearchEsacaped);
            // 
            // FromUXEReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 745);
            this.Controls.Add(this.txtCabin);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMemberRegNo);
            this.Controls.Add(this.txtDID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblPreparedBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tv);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtRefBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FromUXEReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radiology & Imaging Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FromUXEReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTemplates.ResumeLayout(false);
            this.tabTemplates.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUxList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPreparedBy;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTemplates;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView Tv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCurrentTestName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbConsultant;
        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvUxList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSelectedPatientId;
        private System.Windows.Forms.Label label13;
        private Diagonstics.TemplateSearchControl ctrlTemplateSearch;
        private System.Windows.Forms.TextBox txtDID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMemberRegNo;
        private System.Windows.Forms.TextBox txtCabin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnLabelPrint;
    }
}