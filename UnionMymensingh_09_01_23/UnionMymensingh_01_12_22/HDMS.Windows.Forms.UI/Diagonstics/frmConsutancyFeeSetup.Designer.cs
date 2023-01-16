namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmConsutancyFeeSetup
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
            this.cmbConsultant = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.gvTestlist = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultancyInPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultancyGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbConsultant
            // 
            this.cmbConsultant.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsultant.FormattingEnabled = true;
            this.cmbConsultant.Location = new System.Drawing.Point(145, 23);
            this.cmbConsultant.Name = "cmbConsultant";
            this.cmbConsultant.Size = new System.Drawing.Size(235, 28);
            this.cmbConsultant.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Select Consultant";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(716, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Select Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DisplayMember = "Name";
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(855, 23);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(213, 28);
            this.cmbReportType.TabIndex = 41;
            this.cmbReportType.ValueMember = "Id";
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(396, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Select Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(495, 23);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(204, 28);
            this.cmbGroup.TabIndex = 40;
            this.cmbGroup.ValueMember = "Id";
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // gvTestlist
            // 
            this.gvTestlist.AllowUserToAddRows = false;
            this.gvTestlist.BackgroundColor = System.Drawing.Color.Bisque;
            this.gvTestlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TestName,
            this.ConsultancyInPercent,
            this.ConsultancyGross});
            this.gvTestlist.Location = new System.Drawing.Point(158, 70);
            this.gvTestlist.Name = "gvTestlist";
            this.gvTestlist.RowTemplate.Height = 35;
            this.gvTestlist.Size = new System.Drawing.Size(825, 454);
            this.gvTestlist.TabIndex = 44;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "TestId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 60;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 320;
            // 
            // ConsultancyInPercent
            // 
            this.ConsultancyInPercent.HeaderText = "Consultancy(%)";
            this.ConsultancyInPercent.Name = "ConsultancyInPercent";
            this.ConsultancyInPercent.Width = 200;
            // 
            // ConsultancyGross
            // 
            this.ConsultancyGross.HeaderText = "Consultancy(Gross)";
            this.ConsultancyGross.Name = "ConsultancyGross";
            this.ConsultancyGross.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(158, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 39);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(289, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 39);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConsutancyFeeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 596);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gvTestlist);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.cmbConsultant);
            this.Controls.Add(this.label10);
            this.Name = "frmConsutancyFeeSetup";
            this.Text = "Consutancy Fee Setup";
            this.Load += new System.EventHandler(this.frmConsutancyFeeSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbConsultant;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.DataGridView gvTestlist;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsultancyInPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsultancyGross;
        private System.Windows.Forms.Button btnClose;
    }
}