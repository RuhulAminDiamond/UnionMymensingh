
namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    partial class frmMediaPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgMedia = new System.Windows.Forms.DataGridView();
            this.MediaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dgTest = new System.Windows.Forms.DataGridView();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.PatientId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegularDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCommission = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPayable = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkDirectExpense = new System.Windows.Forms.CheckBox();
            this.txtSearchMedia = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMediaPaid = new System.Windows.Forms.Button();
            this.btnMediaShow = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscountPluse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiscountMinus = new System.Windows.Forms.TextBox();
            this.btnInvestigation = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMedia
            // 
            this.dgMedia.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgMedia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMedia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMedia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMedia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MediaName});
            this.dgMedia.EnableHeadersVisualStyles = false;
            this.dgMedia.Location = new System.Drawing.Point(12, 40);
            this.dgMedia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgMedia.Name = "dgMedia";
            this.dgMedia.Size = new System.Drawing.Size(364, 574);
            this.dgMedia.TabIndex = 0;
            this.dgMedia.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgMedia_RowHeaderMouseClick);
            // 
            // MediaName
            // 
            this.MediaName.HeaderText = "Media Name";
            this.MediaName.Name = "MediaName";
            this.MediaName.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date :";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(438, 10);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(122, 24);
            this.dtFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(600, 10);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(122, 24);
            this.dtTo.TabIndex = 2;
            // 
            // dgTest
            // 
            this.dgTest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId,
            this.PatientName,
            this.TestName,
            this.Rate,
            this.Commission,
            this.TestId});
            this.dgTest.EnableHeadersVisualStyles = false;
            this.dgTest.Location = new System.Drawing.Point(387, 40);
            this.dgTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgTest.Name = "dgTest";
            this.dgTest.Size = new System.Drawing.Size(921, 275);
            this.dgTest.TabIndex = 0;
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "Patient Id";
            this.PatientId.Name = "PatientId";
            // 
            // PatientName
            // 
            this.PatientName.HeaderText = "Patient Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.Width = 250;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 300;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Test Price";
            this.Rate.Name = "Rate";
            // 
            // Commission
            // 
            this.Commission.HeaderText = "Commission";
            this.Commission.Name = "Commission";
            this.Commission.Width = 150;
            // 
            // TestId
            // 
            this.TestId.HeaderText = "Test Id";
            this.TestId.Name = "TestId";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.SystemColors.Window;
            this.btnShow.Location = new System.Drawing.Point(841, 8);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 27);
            this.btnShow.TabIndex = 8;
            this.btnShow.Text = "Show Patient ";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1075, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selected Media :";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMedia.Location = new System.Drawing.Point(1198, 13);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(20, 17);
            this.lblMedia.TabIndex = 1;
            this.lblMedia.Text = "...";
            // 
            // dgPatient
            // 
            this.dgPatient.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId2,
            this.PatientName2,
            this.RegularDiscount,
            this.DueDiscount,
            this.TotalDiscount,
            this.Check});
            this.dgPatient.EnableHeadersVisualStyles = false;
            this.dgPatient.Location = new System.Drawing.Point(382, 321);
            this.dgPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(926, 293);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatient_CellContentClick);
            // 
            // PatientId2
            // 
            this.PatientId2.HeaderText = "Patient Id";
            this.PatientId2.Name = "PatientId2";
            // 
            // PatientName2
            // 
            this.PatientName2.HeaderText = "Patient Name";
            this.PatientName2.Name = "PatientName2";
            this.PatientName2.Width = 200;
            // 
            // RegularDiscount
            // 
            this.RegularDiscount.HeaderText = "Regular Discount";
            this.RegularDiscount.Name = "RegularDiscount";
            this.RegularDiscount.Width = 160;
            // 
            // DueDiscount
            // 
            this.DueDiscount.HeaderText = "Due Discount";
            this.DueDiscount.Name = "DueDiscount";
            this.DueDiscount.Width = 150;
            // 
            // TotalDiscount
            // 
            this.TotalDiscount.HeaderText = "Total Discount";
            this.TotalDiscount.Name = "TotalDiscount";
            this.TotalDiscount.Width = 150;
            // 
            // Check
            // 
            this.Check.FalseValue = "0";
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.TrueValue = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 668);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Commission :";
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommission.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCommission.Location = new System.Drawing.Point(196, 668);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(17, 19);
            this.lblCommission.TabIndex = 1;
            this.lblCommission.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 668);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Discount :";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDiscount.Location = new System.Drawing.Point(329, 668);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(17, 19);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 668);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Payable :";
            // 
            // lblPayable
            // 
            this.lblPayable.AutoSize = true;
            this.lblPayable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPayable.Location = new System.Drawing.Point(472, 668);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.Size = new System.Drawing.Size(17, 19);
            this.lblPayable.TabIndex = 1;
            this.lblPayable.Text = "0";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPay.Location = new System.Drawing.Point(1026, 660);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(90, 35);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(1218, 659);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkDirectExpense
            // 
            this.chkDirectExpense.AutoSize = true;
            this.chkDirectExpense.Location = new System.Drawing.Point(795, 668);
            this.chkDirectExpense.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDirectExpense.Name = "chkDirectExpense";
            this.chkDirectExpense.Size = new System.Drawing.Size(129, 21);
            this.chkDirectExpense.TabIndex = 9;
            this.chkDirectExpense.Text = "Direct Expense";
            this.chkDirectExpense.UseVisualStyleBackColor = true;
            // 
            // txtSearchMedia
            // 
            this.txtSearchMedia.Location = new System.Drawing.Point(12, 10);
            this.txtSearchMedia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchMedia.Name = "txtSearchMedia";
            this.txtSearchMedia.Size = new System.Drawing.Size(273, 24);
            this.txtSearchMedia.TabIndex = 10;
            this.txtSearchMedia.TextChanged += new System.EventHandler(this.txtSearchMedia_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Location = new System.Drawing.Point(291, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 27);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Tag = "";
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMediaPaid
            // 
            this.btnMediaPaid.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMediaPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaPaid.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMediaPaid.Location = new System.Drawing.Point(1122, 660);
            this.btnMediaPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMediaPaid.Name = "btnMediaPaid";
            this.btnMediaPaid.Size = new System.Drawing.Size(90, 35);
            this.btnMediaPaid.TabIndex = 8;
            this.btnMediaPaid.Text = "Paid List";
            this.btnMediaPaid.UseVisualStyleBackColor = false;
            this.btnMediaPaid.Click += new System.EventHandler(this.btnMediaPaid_Click);
            // 
            // btnMediaShow
            // 
            this.btnMediaShow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMediaShow.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaShow.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMediaShow.Location = new System.Drawing.Point(728, 9);
            this.btnMediaShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMediaShow.Name = "btnMediaShow";
            this.btnMediaShow.Size = new System.Drawing.Size(112, 27);
            this.btnMediaShow.TabIndex = 8;
            this.btnMediaShow.Text = "Show Media";
            this.btnMediaShow.UseVisualStyleBackColor = false;
            this.btnMediaShow.Click += new System.EventHandler(this.btnMediaShow_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCalculate.Location = new System.Drawing.Point(930, 660);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(90, 35);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate ";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 671);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dis(+)";
            // 
            // txtDiscountPluse
            // 
            this.txtDiscountPluse.Location = new System.Drawing.Point(588, 667);
            this.txtDiscountPluse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountPluse.Name = "txtDiscountPluse";
            this.txtDiscountPluse.Size = new System.Drawing.Size(61, 24);
            this.txtDiscountPluse.TabIndex = 11;
            this.txtDiscountPluse.TextChanged += new System.EventHandler(this.txtDiscountPluse_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(654, 672);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Dis(-)";
            // 
            // txtDiscountMinus
            // 
            this.txtDiscountMinus.Location = new System.Drawing.Point(703, 667);
            this.txtDiscountMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountMinus.Name = "txtDiscountMinus";
            this.txtDiscountMinus.Size = new System.Drawing.Size(61, 24);
            this.txtDiscountMinus.TabIndex = 11;
            this.txtDiscountMinus.TextChanged += new System.EventHandler(this.txtDiscountMinus_TextChanged);
            // 
            // btnInvestigation
            // 
            this.btnInvestigation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnInvestigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvestigation.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInvestigation.Location = new System.Drawing.Point(930, 8);
            this.btnInvestigation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInvestigation.Name = "btnInvestigation";
            this.btnInvestigation.Size = new System.Drawing.Size(135, 27);
            this.btnInvestigation.TabIndex = 8;
            this.btnInvestigation.Text = "Investigation Page";
            this.btnInvestigation.UseVisualStyleBackColor = false;
            this.btnInvestigation.Click += new System.EventHandler(this.btnInvestigation_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(387, 627);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(921, 24);
            this.txtRemarks.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 630);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Remarks :";
            // 
            // frmMediaPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1484, 709);
            this.Controls.Add(this.txtDiscountMinus);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtDiscountPluse);
            this.Controls.Add(this.txtSearchMedia);
            this.Controls.Add(this.chkDirectExpense);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMediaPaid);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnMediaShow);
            this.Controls.Add(this.btnInvestigation);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPayable);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblCommission);
            this.Controls.Add(this.lblMedia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgPatient);
            this.Controls.Add(this.dgTest);
            this.Controls.Add(this.dgMedia);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMediaPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Payment";
            this.Load += new System.EventHandler(this.frmMediaPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMedia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DataGridView dgTest;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPayable;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediaName;
        private System.Windows.Forms.CheckBox chkDirectExpense;
        private System.Windows.Forms.TextBox txtSearchMedia;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMediaPaid;
        private System.Windows.Forms.Button btnMediaShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegularDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiscount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscountPluse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiscountMinus;
        private System.Windows.Forms.Button btnInvestigation;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commission;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestId;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
    }
}