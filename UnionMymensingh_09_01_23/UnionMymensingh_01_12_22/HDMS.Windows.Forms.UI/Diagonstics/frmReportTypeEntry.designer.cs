namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmReportTypeEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportTypeEntry));
            this.dgvReportType = new System.Windows.Forms.DataGridView();
            this.ReportTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPathReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsImageReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCarriedOutBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReportType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioPath = new System.Windows.Forms.RadioButton();
            this.radioImage = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestCarriedoutby = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportType)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportType
            // 
            this.dgvReportType.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvReportType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportTypeId,
            this.Report_Type,
            this.IsPathReport,
            this.IsImageReport,
            this.TestCarriedOutBy});
            this.dgvReportType.Location = new System.Drawing.Point(90, 249);
            this.dgvReportType.Name = "dgvReportType";
            this.dgvReportType.RowTemplate.Height = 35;
            this.dgvReportType.Size = new System.Drawing.Size(1079, 337);
            this.dgvReportType.TabIndex = 19;
            this.dgvReportType.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReportType_RowHeaderMouseClick);
            // 
            // ReportTypeId
            // 
            this.ReportTypeId.DataPropertyName = "ReportTypeId";
            this.ReportTypeId.HeaderText = "Id";
            this.ReportTypeId.Name = "ReportTypeId";
            this.ReportTypeId.Width = 60;
            // 
            // Report_Type
            // 
            this.Report_Type.DataPropertyName = "Report_Type";
            this.Report_Type.HeaderText = "Report Type";
            this.Report_Type.Name = "Report_Type";
            this.Report_Type.Width = 250;
            // 
            // IsPathReport
            // 
            this.IsPathReport.DataPropertyName = "IsPathReport";
            this.IsPathReport.HeaderText = "IsPathologicalReport";
            this.IsPathReport.Name = "IsPathReport";
            this.IsPathReport.Width = 150;
            // 
            // IsImageReport
            // 
            this.IsImageReport.DataPropertyName = "IsImageReport";
            this.IsImageReport.HeaderText = "IsImageReport";
            this.IsImageReport.Name = "IsImageReport";
            this.IsImageReport.Width = 120;
            // 
            // TestCarriedOutBy
            // 
            this.TestCarriedOutBy.DataPropertyName = "TestCarriedOutBy";
            this.TestCarriedOutBy.HeaderText = "Test Carried Out By";
            this.TestCarriedOutBy.Name = "TestCarriedOutBy";
            this.TestCarriedOutBy.Width = 450;
            // 
            // txtReportType
            // 
            this.txtReportType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportType.Location = new System.Drawing.Point(203, 60);
            this.txtReportType.Name = "txtReportType";
            this.txtReportType.Size = new System.Drawing.Size(297, 27);
            this.txtReportType.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Report Type Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(203, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 32);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(203, 15);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(245, 28);
            this.cmbGroup.TabIndex = 20;
            this.cmbGroup.ValueMember = "Id";
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Select Group";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(635, 198);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(118, 32);
            this.cmdDelete.TabIndex = 24;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Visible = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtGroupId
            // 
            this.txtGroupId.Enabled = false;
            this.txtGroupId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupId.Location = new System.Drawing.Point(537, 14);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(173, 27);
            this.txtGroupId.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(464, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Group Id";
            // 
            // radioPath
            // 
            this.radioPath.AutoSize = true;
            this.radioPath.Location = new System.Drawing.Point(206, 108);
            this.radioPath.Name = "radioPath";
            this.radioPath.Size = new System.Drawing.Size(118, 17);
            this.radioPath.TabIndex = 33;
            this.radioPath.TabStop = true;
            this.radioPath.Text = "Pathological Report";
            this.radioPath.UseVisualStyleBackColor = true;
            // 
            // radioImage
            // 
            this.radioImage.AutoSize = true;
            this.radioImage.Location = new System.Drawing.Point(352, 108);
            this.radioImage.Name = "radioImage";
            this.radioImage.Size = new System.Drawing.Size(89, 17);
            this.radioImage.TabIndex = 34;
            this.radioImage.TabStop = true;
            this.radioImage.Text = "Image Report";
            this.radioImage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Report Group";
            // 
            // txtTestCarriedoutby
            // 
            this.txtTestCarriedoutby.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCarriedoutby.Location = new System.Drawing.Point(203, 144);
            this.txtTestCarriedoutby.Name = "txtTestCarriedoutby";
            this.txtTestCarriedoutby.Size = new System.Drawing.Size(966, 27);
            this.txtTestCarriedoutby.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Test Carried Out By";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(493, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 32);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(343, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 32);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReportTypeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 604);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTestCarriedoutby);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioImage);
            this.Controls.Add(this.radioPath);
            this.Controls.Add(this.txtGroupId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.dgvReportType);
            this.Controls.Add(this.txtReportType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportTypeEntry";
            this.Text = "Report Type Entry";
            this.Load += new System.EventHandler(this.frmTestEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReportType;
        private System.Windows.Forms.TextBox txtReportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioPath;
        private System.Windows.Forms.RadioButton radioImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestCarriedoutby;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPathReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsImageReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCarriedOutBy;
        private System.Windows.Forms.Button btnClose;
    }
}