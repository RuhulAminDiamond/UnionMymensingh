namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class TestGroupEntry
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.gvTestGroup = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokenOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReportOrder = new System.Windows.Forms.TextBox();
            this.txtTokenOrder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.txtMasterGroupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMasterReportOrder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMasterTokenOrder = new System.Windows.Forms.TextBox();
            this.btnDeleteMaster = new System.Windows.Forms.Button();
            this.btnCancelMaster = new System.Windows.Forms.Button();
            this.btnSaveMaster = new System.Windows.Forms.Button();
            this.MasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterReportOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MasterTokenOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestGroup)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(650, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(595, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.Location = new System.Drawing.Point(650, 35);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(297, 27);
            this.txtGroupName.TabIndex = 2;
            // 
            // gvTestGroup
            // 
            this.gvTestGroup.BackgroundColor = System.Drawing.Color.Bisque;
            this.gvTestGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.GroupName,
            this.ParentGroup,
            this.ReportOrder,
            this.TokenOrder});
            this.gvTestGroup.Location = new System.Drawing.Point(595, 182);
            this.gvTestGroup.Name = "gvTestGroup";
            this.gvTestGroup.Size = new System.Drawing.Size(710, 355);
            this.gvTestGroup.TabIndex = 9;
            this.gvTestGroup.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTestGroup_RowHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "TestGroupId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Name";
            this.GroupName.HeaderText = "Name";
            this.GroupName.Name = "GroupName";
            this.GroupName.Width = 280;
            // 
            // ParentGroup
            // 
            this.ParentGroup.DataPropertyName = "SummaryGroup";
            this.ParentGroup.HeaderText = "ParentGroup";
            this.ParentGroup.Name = "ParentGroup";
            this.ParentGroup.Width = 180;
            // 
            // ReportOrder
            // 
            this.ReportOrder.DataPropertyName = "ReportOrder";
            this.ReportOrder.HeaderText = "Report Order";
            this.ReportOrder.Name = "ReportOrder";
            // 
            // TokenOrder
            // 
            this.TokenOrder.DataPropertyName = "TokenOrder";
            this.TokenOrder.HeaderText = "Token Order";
            this.TokenOrder.Name = "TokenOrder";
            // 
            // txtReportOrder
            // 
            this.txtReportOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportOrder.Location = new System.Drawing.Point(1097, 32);
            this.txtReportOrder.Name = "txtReportOrder";
            this.txtReportOrder.Size = new System.Drawing.Size(106, 27);
            this.txtReportOrder.TabIndex = 11;
            // 
            // txtTokenOrder
            // 
            this.txtTokenOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenOrder.Location = new System.Drawing.Point(1097, 80);
            this.txtTokenOrder.Name = "txtTokenOrder";
            this.txtTokenOrder.Size = new System.Drawing.Size(106, 27);
            this.txtTokenOrder.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(543, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Parent Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(995, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Report Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(995, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Token Order";
            // 
            // cmbParent
            // 
            this.cmbParent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Items.AddRange(new object[] {
            "Pathology",
            "X-Ray",
            "USG",
            "Cardiology",
            "Echo",
            "ECG",
            "Endoscopy",
            "Histology",
            "Package",
            "Vacutainer",
            "CTScan"});
            this.cmbParent.Location = new System.Drawing.Point(650, 77);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(296, 28);
            this.cmbParent.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(815, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(983, 128);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 32);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteMaster);
            this.groupBox1.Controls.Add(this.btnCancelMaster);
            this.groupBox1.Controls.Add(this.btnSaveMaster);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMasterTokenOrder);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMasterReportOrder);
            this.groupBox1.Controls.Add(this.txtMasterGroupName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgvMaster);
            this.groupBox1.Location = new System.Drawing.Point(22, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 610);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master Group";
            // 
            // dgvMaster
            // 
            this.dgvMaster.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MasterId,
            this.MasterName,
            this.MasterReportOrder,
            this.MasterTokenOrder});
            this.dgvMaster.Location = new System.Drawing.Point(6, 147);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.Size = new System.Drawing.Size(487, 325);
            this.dgvMaster.TabIndex = 10;
            this.dgvMaster.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMaster_RowHeaderMouseClick);
            // 
            // txtMasterGroupName
            // 
            this.txtMasterGroupName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterGroupName.Location = new System.Drawing.Point(124, 19);
            this.txtMasterGroupName.Name = "txtMasterGroupName";
            this.txtMasterGroupName.Size = new System.Drawing.Size(328, 27);
            this.txtMasterGroupName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Report Order";
            // 
            // txtMasterReportOrder
            // 
            this.txtMasterReportOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterReportOrder.Location = new System.Drawing.Point(124, 52);
            this.txtMasterReportOrder.Name = "txtMasterReportOrder";
            this.txtMasterReportOrder.Size = new System.Drawing.Size(106, 27);
            this.txtMasterReportOrder.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(250, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Token Order";
            // 
            // txtMasterTokenOrder
            // 
            this.txtMasterTokenOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterTokenOrder.Location = new System.Drawing.Point(346, 52);
            this.txtMasterTokenOrder.Name = "txtMasterTokenOrder";
            this.txtMasterTokenOrder.Size = new System.Drawing.Size(106, 27);
            this.txtMasterTokenOrder.TabIndex = 17;
            // 
            // btnDeleteMaster
            // 
            this.btnDeleteMaster.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMaster.Location = new System.Drawing.Point(346, 93);
            this.btnDeleteMaster.Name = "btnDeleteMaster";
            this.btnDeleteMaster.Size = new System.Drawing.Size(106, 32);
            this.btnDeleteMaster.TabIndex = 21;
            this.btnDeleteMaster.Text = "Delete";
            this.btnDeleteMaster.UseVisualStyleBackColor = true;
            this.btnDeleteMaster.Visible = false;
            // 
            // btnCancelMaster
            // 
            this.btnCancelMaster.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelMaster.Location = new System.Drawing.Point(233, 93);
            this.btnCancelMaster.Name = "btnCancelMaster";
            this.btnCancelMaster.Size = new System.Drawing.Size(90, 32);
            this.btnCancelMaster.TabIndex = 20;
            this.btnCancelMaster.Text = "Cancel";
            this.btnCancelMaster.UseVisualStyleBackColor = true;
            this.btnCancelMaster.Visible = false;
            this.btnCancelMaster.Click += new System.EventHandler(this.btnCancelMaster_Click);
            // 
            // btnSaveMaster
            // 
            this.btnSaveMaster.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMaster.Location = new System.Drawing.Point(124, 93);
            this.btnSaveMaster.Name = "btnSaveMaster";
            this.btnSaveMaster.Size = new System.Drawing.Size(91, 32);
            this.btnSaveMaster.TabIndex = 19;
            this.btnSaveMaster.Text = "Save";
            this.btnSaveMaster.UseVisualStyleBackColor = true;
            this.btnSaveMaster.Click += new System.EventHandler(this.btnSaveMaster_Click);
            // 
            // MasterId
            // 
            this.MasterId.DataPropertyName = "MasterTestGroupId";
            this.MasterId.HeaderText = "Id";
            this.MasterId.Name = "MasterId";
            // 
            // MasterName
            // 
            this.MasterName.DataPropertyName = "Name";
            this.MasterName.HeaderText = "Name";
            this.MasterName.Name = "MasterName";
            this.MasterName.Width = 280;
            // 
            // MasterReportOrder
            // 
            this.MasterReportOrder.DataPropertyName = "ReportOrder";
            this.MasterReportOrder.HeaderText = "Report Order";
            this.MasterReportOrder.Name = "MasterReportOrder";
            // 
            // MasterTokenOrder
            // 
            this.MasterTokenOrder.DataPropertyName = "TokenOrder";
            this.MasterTokenOrder.HeaderText = "Token Order";
            this.MasterTokenOrder.Name = "MasterTokenOrder";
            // 
            // TestGroupEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 609);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbParent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTokenOrder);
            this.Controls.Add(this.txtReportOrder);
            this.Controls.Add(this.gvTestGroup);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "TestGroupEntry";
            this.Text = "Test Group Entry";
            this.Load += new System.EventHandler(this.TestGroupEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestGroup)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridView gvTestGroup;
        private System.Windows.Forms.TextBox txtReportOrder;
        private System.Windows.Forms.TextBox txtTokenOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbParent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.Button btnDeleteMaster;
        private System.Windows.Forms.Button btnCancelMaster;
        private System.Windows.Forms.Button btnSaveMaster;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMasterTokenOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMasterReportOrder;
        private System.Windows.Forms.TextBox txtMasterGroupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterReportOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn MasterTokenOrder;
    }
}