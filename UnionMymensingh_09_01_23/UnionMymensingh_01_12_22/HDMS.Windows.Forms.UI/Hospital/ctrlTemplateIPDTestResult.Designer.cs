namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlTemplateIPDTestResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTemplateIPDTestResult));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.lblCabin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvScannedReports = new System.Windows.Forms.ListView();
            this.lvReports = new System.Windows.Forms.ListView();
            this.dgTestList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBillIds = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvTestsDetails = new System.Windows.Forms.DataGridView();
            this.TestTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRefdBy = new System.Windows.Forms.TextBox();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imgListLarge2 = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillIds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestsDetails)).BeginInit();
            this.SuspendLayout();
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
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(903, 0);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10156;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(847, 0);
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
            this.label9.Location = new System.Drawing.Point(394, 0);
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
            this.lblName.Location = new System.Drawing.Point(453, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10153;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(659, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 10161;
            this.label1.Text = "Non-Lab Reports";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.lvScannedReports);
            this.panel2.Controls.Add(this.lvReports);
            this.panel2.Location = new System.Drawing.Point(659, 432);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 135);
            this.panel2.TabIndex = 10160;
            // 
            // lvScannedReports
            // 
            this.lvScannedReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvScannedReports.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lvScannedReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvScannedReports.GridLines = true;
            this.lvScannedReports.HideSelection = false;
            this.lvScannedReports.HoverSelection = true;
            this.lvScannedReports.Location = new System.Drawing.Point(375, 9);
            this.lvScannedReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvScannedReports.Name = "lvScannedReports";
            this.lvScannedReports.ShowItemToolTips = true;
            this.lvScannedReports.Size = new System.Drawing.Size(302, 116);
            this.lvScannedReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvScannedReports.TabIndex = 1;
            this.lvScannedReports.UseCompatibleStateImageBehavior = false;
            // 
            // lvReports
            // 
            this.lvReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvReports.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReports.GridLines = true;
            this.lvReports.HideSelection = false;
            this.lvReports.HoverSelection = true;
            this.lvReports.Location = new System.Drawing.Point(14, 9);
            this.lvReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvReports.Name = "lvReports";
            this.lvReports.ShowItemToolTips = true;
            this.lvReports.Size = new System.Drawing.Size(349, 116);
            this.lvReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            // 
            // dgTestList
            // 
            this.dgTestList.AllowUserToAddRows = false;
            this.dgTestList.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgTestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgTestList.Location = new System.Drawing.Point(398, 247);
            this.dgTestList.Name = "dgTestList";
            this.dgTestList.Size = new System.Drawing.Size(255, 370);
            this.dgTestList.TabIndex = 10159;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.RxTime});
            this.dgBillIds.Location = new System.Drawing.Point(398, 55);
            this.dgBillIds.Name = "dgBillIds";
            this.dgBillIds.Size = new System.Drawing.Size(255, 186);
            this.dgBillIds.TabIndex = 10158;
            this.dgBillIds.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBillIds_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Bill No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // RxTime
            // 
            this.RxTime.HeaderText = "Time";
            this.RxTime.Name = "RxTime";
            this.RxTime.Width = 80;
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
            this.gvTestsDetails.Location = new System.Drawing.Point(659, 55);
            this.gvTestsDetails.Name = "gvTestsDetails";
            this.gvTestsDetails.Size = new System.Drawing.Size(688, 353);
            this.gvTestsDetails.TabIndex = 10157;
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
            this.label5.Location = new System.Drawing.Point(395, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 10163;
            this.label5.Text = "Refd. by";
            // 
            // txtRefdBy
            // 
            this.txtRefdBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefdBy.Location = new System.Drawing.Point(463, 23);
            this.txtRefdBy.Name = "txtRefdBy";
            this.txtRefdBy.Size = new System.Drawing.Size(751, 27);
            this.txtRefdBy.TabIndex = 10162;
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
            // ctrlTemplateIPDTestResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRefdBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgTestList);
            this.Controls.Add(this.dgBillIds);
            this.Controls.Add(this.gvTestsDetails);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlTemplateIPDTestResult";
            this.Size = new System.Drawing.Size(1363, 698);
            this.Load += new System.EventHandler(this.ctrlTemplateIPDTestResult_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillIds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestsDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvScannedReports;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.DataGridView dgTestList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgBillIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RxTime;
        private System.Windows.Forms.DataGridView gvTestsDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRefdBy;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.ImageList imgListLarge2;
        private System.Windows.Forms.ImageList imgListSmall2;
    }
}
