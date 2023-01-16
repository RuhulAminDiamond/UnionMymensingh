namespace HDMS.Windows.Forms.UI.Rx
{
    partial class RxReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RxReportControl));
            this.gvTestsDetails = new System.Windows.Forms.DataGridView();
            this.TestTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefdBy = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.dgTestList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBillIds = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvScannedReports = new System.Windows.Forms.ListView();
            this.imgListLarge2 = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall2 = new System.Windows.Forms.ImageList(this.components);
            this.lvReports = new System.Windows.Forms.ListView();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillIds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvTestsDetails
            // 
            this.gvTestsDetails.AllowUserToAddRows = false;
            this.gvTestsDetails.BackgroundColor = System.Drawing.Color.LightGray;
            this.gvTestsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestTitle,
            this.TestResult,
            this.ResultUnit,
            this.NormalValue,
            this.GroupTitle,
            this.DefId});
            this.gvTestsDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gvTestsDetails.Location = new System.Drawing.Point(590, 110);
            this.gvTestsDetails.Name = "gvTestsDetails";
            this.gvTestsDetails.Size = new System.Drawing.Size(688, 353);
            this.gvTestsDetails.TabIndex = 50;
            // 
            // TestTitle
            // 
            this.TestTitle.DataPropertyName = "TestTitle";
            this.TestTitle.HeaderText = "Title";
            this.TestTitle.Name = "TestTitle";
            this.TestTitle.ReadOnly = true;
            this.TestTitle.Width = 250;
            // 
            // TestResult
            // 
            this.TestResult.DataPropertyName = "TestResult";
            this.TestResult.HeaderText = "Result";
            this.TestResult.Name = "TestResult";
            this.TestResult.Width = 150;
            // 
            // ResultUnit
            // 
            this.ResultUnit.DataPropertyName = "ResultUnit";
            this.ResultUnit.HeaderText = "Unit";
            this.ResultUnit.Name = "ResultUnit";
            this.ResultUnit.ReadOnly = true;
            // 
            // NormalValue
            // 
            this.NormalValue.HeaderText = "N/Value";
            this.NormalValue.Name = "NormalValue";
            this.NormalValue.ReadOnly = true;
            this.NormalValue.Width = 250;
            // 
            // GroupTitle
            // 
            this.GroupTitle.HeaderText = "GroupTitle";
            this.GroupTitle.Name = "GroupTitle";
            // 
            // DefId
            // 
            this.DefId.DataPropertyName = "Id";
            this.DefId.HeaderText = "DefId";
            this.DefId.Name = "DefId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 78;
            this.label5.Text = "Refd. by";
            // 
            // txtSex
            // 
            this.txtSex.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSex.Location = new System.Drawing.Point(1084, 11);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(117, 27);
            this.txtSex.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1045, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 76;
            this.label4.Text = "Sex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(902, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Age";
            // 
            // txtRefdBy
            // 
            this.txtRefdBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefdBy.Location = new System.Drawing.Point(655, 44);
            this.txtRefdBy.Name = "txtRefdBy";
            this.txtRefdBy.Size = new System.Drawing.Size(546, 27);
            this.txtRefdBy.TabIndex = 73;
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(941, 11);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(96, 27);
            this.txtAge.TabIndex = 72;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(655, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 27);
            this.txtName.TabIndex = 71;
            // 
            // txtRxId
            // 
            this.txtRxId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtRxId.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRxId.Location = new System.Drawing.Point(339, 29);
            this.txtRxId.Name = "txtRxId";
            this.txtRxId.Size = new System.Drawing.Size(171, 33);
            this.txtRxId.TabIndex = 67;
            this.txtRxId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRxId_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 19);
            this.label6.TabIndex = 68;
            this.label6.Text = "Rx Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(601, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 74;
            this.label2.Text = "Name";
            // 
            // dtpDelivery
            // 
            this.dtpDelivery.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelivery.Location = new System.Drawing.Point(818, 77);
            this.dtpDelivery.Name = "dtpDelivery";
            this.dtpDelivery.Size = new System.Drawing.Size(102, 27);
            this.dtpDelivery.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(754, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 80;
            this.label8.Text = "D. Date";
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(653, 77);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(95, 27);
            this.dtpEntry.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(590, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 79;
            this.label7.Text = "E. Date";
            // 
            // txtRegNo
            // 
            this.txtRegNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtRegNo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegNo.Location = new System.Drawing.Point(66, 29);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(160, 33);
            this.txtRegNo.TabIndex = 1620;
            this.txtRegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNo_KeyPress);
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.BackColor = System.Drawing.Color.Transparent;
            this.lblRegNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(4, 29);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(56, 18);
            this.lblRegNo.TabIndex = 1621;
            this.lblRegNo.Text = "Reg. No";
            this.lblRegNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgTestList
            // 
            this.dgTestList.AllowUserToAddRows = false;
            this.dgTestList.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgTestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgTestList.Location = new System.Drawing.Point(253, 67);
            this.dgTestList.Name = "dgTestList";
            this.dgTestList.Size = new System.Drawing.Size(310, 554);
            this.dgTestList.TabIndex = 1698;
            this.dgTestList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTestList_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Test Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 210;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "BillNo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dgBillIds
            // 
            this.dgBillIds.AllowUserToAddRows = false;
            this.dgBillIds.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgBillIds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBillIds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.RxTime});
            this.dgBillIds.Location = new System.Drawing.Point(7, 68);
            this.dgBillIds.Name = "dgBillIds";
            this.dgBillIds.Size = new System.Drawing.Size(225, 554);
            this.dgBillIds.TabIndex = 1697;
            this.dgBillIds.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBillIds_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bill No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // RxTime
            // 
            this.RxTime.HeaderText = "Time";
            this.RxTime.Name = "RxTime";
            this.RxTime.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.lvScannedReports);
            this.panel1.Controls.Add(this.lvReports);
            this.panel1.Location = new System.Drawing.Point(590, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 135);
            this.panel1.TabIndex = 1699;
            // 
            // lvScannedReports
            // 
            this.lvScannedReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvScannedReports.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lvScannedReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvScannedReports.GridLines = true;
            this.lvScannedReports.HoverSelection = true;
            this.lvScannedReports.LargeImageList = this.imgListLarge2;
            this.lvScannedReports.Location = new System.Drawing.Point(375, 9);
            this.lvScannedReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvScannedReports.Name = "lvScannedReports";
            this.lvScannedReports.ShowItemToolTips = true;
            this.lvScannedReports.Size = new System.Drawing.Size(302, 116);
            this.lvScannedReports.SmallImageList = this.imgListSmall2;
            this.lvScannedReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvScannedReports.TabIndex = 1;
            this.lvScannedReports.UseCompatibleStateImageBehavior = false;
            this.lvScannedReports.DoubleClick += new System.EventHandler(this.lvScannedReports_DoubleClick);
            // 
            // imgListLarge2
            // 
            this.imgListLarge2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge2.ImageStream")));
            this.imgListLarge2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge2.Images.SetKeyName(0, "acrobat.png");
            this.imgListLarge2.Images.SetKeyName(1, "acrobat.bmp");
            // 
            // imgListSmall2
            // 
            this.imgListSmall2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall2.ImageStream")));
            this.imgListSmall2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall2.Images.SetKeyName(0, "acrobat.png");
            // 
            // lvReports
            // 
            this.lvReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvReports.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReports.GridLines = true;
            this.lvReports.HoverSelection = true;
            this.lvReports.LargeImageList = this.imgListLarge;
            this.lvReports.Location = new System.Drawing.Point(14, 9);
            this.lvReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvReports.Name = "lvReports";
            this.lvReports.ShowItemToolTips = true;
            this.lvReports.Size = new System.Drawing.Size(349, 116);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(590, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 1700;
            this.label1.Text = "Non-Lab Reports";
            // 
            // RxReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgTestList);
            this.Controls.Add(this.dgBillIds);
            this.Controls.Add(this.txtRegNo);
            this.Controls.Add(this.lblRegNo);
            this.Controls.Add(this.dtpDelivery);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRefdBy);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtRxId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvTestsDetails);
            this.Name = "RxReportControl";
            this.Size = new System.Drawing.Size(1437, 707);
            this.Load += new System.EventHandler(this.RxReportControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillIds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvTestsDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefdBy;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefId;
        private System.Windows.Forms.DateTimePicker dtpDelivery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.DataGridView dgTestList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgBillIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RxTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.ListView lvScannedReports;
        private System.Windows.Forms.ImageList imgListLarge2;
        private System.Windows.Forms.ImageList imgListSmall2;
    }
}
