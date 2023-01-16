namespace HDMS.Windows.Forms.UI.HR
{
    partial class frmJobCV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobCV));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtApplicantName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCirculationNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPosts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.opfd = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.opdWord = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseWord = new System.Windows.Forms.Button();
            this.txtWordCV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgCVs = new System.Windows.Forms.DataGridView();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.imgListLarge2 = new System.Windows.Forms.ImageList(this.components);
            this.imgListSmall2 = new System.Windows.Forms.ImageList(this.components);
            this.ctrlJobCircularSearch = new HDMS.Windows.Forms.UI.Controls.JobCircularSearchControl();
            this.btnPrintShortList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCVs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(116, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(211, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(305, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtApplicantName
            // 
            this.txtApplicantName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicantName.Location = new System.Drawing.Point(26, 162);
            this.txtApplicantName.Name = "txtApplicantName";
            this.txtApplicantName.Size = new System.Drawing.Size(322, 29);
            this.txtApplicantName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Apply for";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(26, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCirculationNo
            // 
            this.txtCirculationNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCirculationNo.Location = new System.Drawing.Point(27, 51);
            this.txtCirculationNo.Name = "txtCirculationNo";
            this.txtCirculationNo.Size = new System.Drawing.Size(321, 29);
            this.txtCirculationNo.TabIndex = 14;
            this.txtCirculationNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCirculationNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select Circular";
            // 
            // cmbPosts
            // 
            this.cmbPosts.DisplayMember = "Name";
            this.cmbPosts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosts.FormattingEnabled = true;
            this.cmbPosts.Items.AddRange(new object[] {
            "Admin Officer",
            "Accounts Officer",
            "Accounts Trainee",
            "IT-Officer",
            "Duty Doctor",
            "Lab-InCharge",
            "Lab Technologist",
            "Radiology Technologist",
            "Pharmacist",
            "Staff Nurse",
            "OT Boy",
            "Ward Boy",
            "Cleaner"});
            this.cmbPosts.Location = new System.Drawing.Point(26, 107);
            this.cmbPosts.Name = "cmbPosts";
            this.cmbPosts.Size = new System.Drawing.Size(252, 28);
            this.cmbPosts.TabIndex = 335;
            this.cmbPosts.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 21);
            this.label3.TabIndex = 336;
            this.label3.Text = "Applicant\'s Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 21);
            this.label4.TabIndex = 338;
            this.label4.Text = "Applicant\'s Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(26, 218);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(187, 29);
            this.txtMobileNo.TabIndex = 337;
            // 
            // opfd
            // 
            this.opfd.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(253, 273);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(41, 27);
            this.btnBrowse.TabIndex = 341;
            this.btnBrowse.Text = "......";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(26, 274);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(221, 27);
            this.txtFile.TabIndex = 340;
            // 
            // opdWord
            // 
            this.opdWord.FileName = "opdWord";
            // 
            // btnBrowseWord
            // 
            this.btnBrowseWord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseWord.Location = new System.Drawing.Point(253, 327);
            this.btnBrowseWord.Name = "btnBrowseWord";
            this.btnBrowseWord.Size = new System.Drawing.Size(41, 27);
            this.btnBrowseWord.TabIndex = 343;
            this.btnBrowseWord.Text = "......";
            this.btnBrowseWord.UseVisualStyleBackColor = true;
            this.btnBrowseWord.Click += new System.EventHandler(this.btnBrowseWord_Click);
            // 
            // txtWordCV
            // 
            this.txtWordCV.Enabled = false;
            this.txtWordCV.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWordCV.Location = new System.Drawing.Point(27, 328);
            this.txtWordCV.Name = "txtWordCV";
            this.txtWordCV.Size = new System.Drawing.Size(221, 27);
            this.txtWordCV.TabIndex = 342;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 344;
            this.label5.Text = "Pdf CV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 345;
            this.label6.Text = "MS-Word CV";
            // 
            // dgCVs
            // 
            this.dgCVs.AllowUserToAddRows = false;
            this.dgCVs.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgCVs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCVs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CName,
            this.DIdentityLine1,
            this.DIdentityLine2,
            this.MobileNo});
            this.dgCVs.Location = new System.Drawing.Point(354, 27);
            this.dgCVs.Name = "dgCVs";
            this.dgCVs.Size = new System.Drawing.Size(716, 581);
            this.dgCVs.TabIndex = 346;
            this.dgCVs.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCVs_CellContentDoubleClick);
            // 
            // CName
            // 
            this.CName.DataPropertyName = "Name";
            this.CName.HeaderText = "Circulation No";
            this.CName.Name = "CName";
            // 
            // DIdentityLine1
            // 
            this.DIdentityLine1.DataPropertyName = "DIdentityLine1";
            this.DIdentityLine1.HeaderText = "Apply for";
            this.DIdentityLine1.Name = "DIdentityLine1";
            this.DIdentityLine1.Width = 120;
            // 
            // DIdentityLine2
            // 
            this.DIdentityLine2.DataPropertyName = "DIdentityLine2";
            this.DIdentityLine2.HeaderText = "Applicant Name";
            this.DIdentityLine2.Name = "DIdentityLine2";
            this.DIdentityLine2.Width = 150;
            // 
            // MobileNo
            // 
            this.MobileNo.HeaderText = "Mobile No";
            this.MobileNo.Name = "MobileNo";
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "download11.png");
            this.imgListLarge.Images.SetKeyName(1, "imgL.bmp");
            this.imgListLarge.Images.SetKeyName(2, "img_2.bmp");
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
            this.imgListLarge2.Images.SetKeyName(2, "pdf7.png");
            // 
            // imgListSmall2
            // 
            this.imgListSmall2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall2.ImageStream")));
            this.imgListSmall2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall2.Images.SetKeyName(0, "acrobat.png");
            // 
            // ctrlJobCircularSearch
            // 
            this.ctrlJobCircularSearch.Location = new System.Drawing.Point(-306, 384);
            this.ctrlJobCircularSearch.Name = "ctrlJobCircularSearch";
            this.ctrlJobCircularSearch.Size = new System.Drawing.Size(654, 588);
            this.ctrlJobCircularSearch.TabIndex = 347;
            this.ctrlJobCircularSearch.Visible = false;
            this.ctrlJobCircularSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.HR.JobCirculation>.SearchEscapeEventHandler(this.ctrlJobCircularSearch_SearchEsacaped);
            // 
            // btnPrintShortList
            // 
            this.btnPrintShortList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintShortList.Location = new System.Drawing.Point(354, 614);
            this.btnPrintShortList.Name = "btnPrintShortList";
            this.btnPrintShortList.Size = new System.Drawing.Size(150, 37);
            this.btnPrintShortList.TabIndex = 348;
            this.btnPrintShortList.Text = "Print Short List";
            this.btnPrintShortList.UseVisualStyleBackColor = true;
            this.btnPrintShortList.Click += new System.EventHandler(this.btnPrintShortList_Click);
            // 
            // frmJobCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 672);
            this.Controls.Add(this.btnPrintShortList);
            this.Controls.Add(this.ctrlJobCircularSearch);
            this.Controls.Add(this.dgCVs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBrowseWord);
            this.Controls.Add(this.txtWordCV);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPosts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCirculationNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtApplicantName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJobCV";
            this.Text = "Curriculum vitae";
            this.Load += new System.EventHandler(this.frmDeptEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCVs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtApplicantName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCirculationNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPosts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobileNo;
       // private Controls.JobCircularSearchControl ctrlJobCircularSearch;
        private System.Windows.Forms.OpenFileDialog opfd;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog opdWord;
        private System.Windows.Forms.Button btnBrowseWord;
        private System.Windows.Forms.TextBox txtWordCV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgCVs;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.ImageList imgListSmall;
        private System.Windows.Forms.ImageList imgListLarge2;
        private System.Windows.Forms.ImageList imgListSmall2;
        private Controls.JobCircularSearchControl ctrlJobCircularSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNo;
        private System.Windows.Forms.Button btnPrintShortList;
    }
}