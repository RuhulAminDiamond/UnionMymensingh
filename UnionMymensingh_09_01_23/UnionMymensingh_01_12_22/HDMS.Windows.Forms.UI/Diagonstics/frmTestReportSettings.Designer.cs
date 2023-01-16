namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmTestReportSettings
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReportOrder = new System.Windows.Forms.TextBox();
            this.gvTestlist = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(191, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Select Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(291, 29);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(245, 28);
            this.cmbGroup.TabIndex = 22;
            this.cmbGroup.ValueMember = "Id";
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Report Order";
            // 
            // txtReportOrder
            // 
            this.txtReportOrder.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportOrder.Location = new System.Drawing.Point(291, 135);
            this.txtReportOrder.Name = "txtReportOrder";
            this.txtReportOrder.Size = new System.Drawing.Size(205, 27);
            this.txtReportOrder.TabIndex = 24;
            // 
            // gvTestlist
            // 
            this.gvTestlist.AllowUserToOrderColumns = true;
            this.gvTestlist.BackgroundColor = System.Drawing.Color.Bisque;
            this.gvTestlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TestName,
            this.ReportOrder});
            this.gvTestlist.Location = new System.Drawing.Point(186, 228);
            this.gvTestlist.Name = "gvTestlist";
            this.gvTestlist.Size = new System.Drawing.Size(544, 330);
            this.gvTestlist.TabIndex = 28;
            this.gvTestlist.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTestlist_RowHeaderMouseClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(291, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(153, 34);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(157, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Select Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DisplayMember = "Name";
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(291, 65);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(245, 28);
            this.cmbReportType.TabIndex = 40;
            this.cmbReportType.ValueMember = "Id";
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "TestId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 250;
            // 
            // ReportOrder
            // 
            this.ReportOrder.DataPropertyName = "ReportOrder";
            this.ReportOrder.HeaderText = "Report Order";
            this.ReportOrder.Name = "ReportOrder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Name";
            // 
            // txtTestName
            // 
            this.txtTestName.Enabled = false;
            this.txtTestName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestName.Location = new System.Drawing.Point(291, 100);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(326, 27);
            this.txtTestName.TabIndex = 42;
            // 
            // frmTestReportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTestName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gvTestlist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReportOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbGroup);
            this.Name = "frmTestReportSettings";
            this.Text = "Test Report Settings";
            this.Load += new System.EventHandler(this.frmTestReportSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReportOrder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView gvTestlist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTestName;
    }
}