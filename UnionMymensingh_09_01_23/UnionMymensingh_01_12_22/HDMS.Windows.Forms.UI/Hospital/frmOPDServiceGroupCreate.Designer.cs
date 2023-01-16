namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmOPDServiceGroupCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPDServiceGroupCreate));
            this.btnDeleteSubGroup = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.MSubGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBedCancel = new System.Windows.Forms.Button();
            this.btnBedSave = new System.Windows.Forms.Button();
            this.txtSubGroupNamme = new System.Windows.Forms.TextBox();
            this.dgGroups = new System.Windows.Forms.DataGridView();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.SubGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgServiceSubGroups = new System.Windows.Forms.DataGridView();
            this.BedDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceSubGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteSubGroup
            // 
            this.btnDeleteSubGroup.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSubGroup.Location = new System.Drawing.Point(823, 93);
            this.btnDeleteSubGroup.Name = "btnDeleteSubGroup";
            this.btnDeleteSubGroup.Size = new System.Drawing.Size(89, 36);
            this.btnDeleteSubGroup.TabIndex = 71;
            this.btnDeleteSubGroup.Text = "Delete";
            this.btnDeleteSubGroup.UseVisualStyleBackColor = true;
            this.btnDeleteSubGroup.Visible = false;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Name";
            this.Description.HeaderText = "Name";
            this.Description.Name = "Description";
            // 
            // GroupId
            // 
            this.GroupId.DataPropertyName = "GroupId";
            this.GroupId.HeaderText = "GroupId";
            this.GroupId.Name = "GroupId";
            this.GroupId.Width = 150;
            // 
            // SubGroupType
            // 
            this.SubGroupType.DataPropertyName = "SubGroupType";
            this.SubGroupType.HeaderText = "SubGroupType";
            this.SubGroupType.Name = "SubGroupType";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(492, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 36);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MSubGroupId
            // 
            this.MSubGroupId.DataPropertyName = "GroupId";
            this.MSubGroupId.HeaderText = "GroupId";
            this.MSubGroupId.Name = "MSubGroupId";
            // 
            // cmbGroups
            // 
            this.cmbGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(629, 12);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(222, 28);
            this.cmbGroups.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(529, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "Select Group";
            // 
            // btnBedCancel
            // 
            this.btnBedCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedCancel.Location = new System.Drawing.Point(724, 93);
            this.btnBedCancel.Name = "btnBedCancel";
            this.btnBedCancel.Size = new System.Drawing.Size(89, 36);
            this.btnBedCancel.TabIndex = 66;
            this.btnBedCancel.Text = "Cancel";
            this.btnBedCancel.UseVisualStyleBackColor = true;
            this.btnBedCancel.Visible = false;
            this.btnBedCancel.Click += new System.EventHandler(this.btnBedCancel_Click);
            // 
            // btnBedSave
            // 
            this.btnBedSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedSave.Location = new System.Drawing.Point(629, 93);
            this.btnBedSave.Name = "btnBedSave";
            this.btnBedSave.Size = new System.Drawing.Size(89, 36);
            this.btnBedSave.TabIndex = 65;
            this.btnBedSave.Text = "Save";
            this.btnBedSave.UseVisualStyleBackColor = true;
            this.btnBedSave.Click += new System.EventHandler(this.btnBedSave_Click);
            // 
            // txtSubGroupNamme
            // 
            this.txtSubGroupNamme.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSubGroupNamme.Location = new System.Drawing.Point(629, 50);
            this.txtSubGroupNamme.Name = "txtSubGroupNamme";
            this.txtSubGroupNamme.Size = new System.Drawing.Size(283, 29);
            this.txtSubGroupNamme.TabIndex = 64;
            // 
            // dgGroups
            // 
            this.dgGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupId,
            this.Description});
            this.dgGroups.Location = new System.Drawing.Point(55, 151);
            this.dgGroups.Name = "dgGroups";
            this.dgGroups.Size = new System.Drawing.Size(442, 354);
            this.dgGroups.TabIndex = 62;
            this.dgGroups.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgGroups_RowHeaderMouseClick);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGroupName.Location = new System.Drawing.Point(126, 50);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(278, 29);
            this.txtGroupName.TabIndex = 58;
            // 
            // SubGroupId
            // 
            this.SubGroupId.DataPropertyName = "SubGroupId";
            this.SubGroupId.HeaderText = "Id";
            this.SubGroupId.Name = "SubGroupId";
            // 
            // dgServiceSubGroups
            // 
            this.dgServiceSubGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgServiceSubGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubGroupId,
            this.MSubGroupId,
            this.BedDescription,
            this.SubGroupType});
            this.dgServiceSubGroups.Location = new System.Drawing.Point(542, 151);
            this.dgServiceSubGroups.Name = "dgServiceSubGroups";
            this.dgServiceSubGroups.Size = new System.Drawing.Size(528, 354);
            this.dgServiceSubGroups.TabIndex = 69;
            this.dgServiceSubGroups.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgServiceSubGroups_RowHeaderMouseClick);
            // 
            // BedDescription
            // 
            this.BedDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BedDescription.DataPropertyName = "Name";
            this.BedDescription.HeaderText = "Name";
            this.BedDescription.Name = "BedDescription";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(370, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 36);
            this.btnDelete.TabIndex = 61;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(248, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 36);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(126, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 36);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(26, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Group Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(500, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Sub Group Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmOPDServiceGroupCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 576);
            this.Controls.Add(this.btnDeleteSubGroup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbGroups);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBedCancel);
            this.Controls.Add(this.btnBedSave);
            this.Controls.Add(this.txtSubGroupNamme);
            this.Controls.Add(this.dgGroups);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.dgServiceSubGroups);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPDServiceGroupCreate";
            this.Text = "OPD Service Group Create";
            this.Load += new System.EventHandler(this.frmOPDServiceGroupCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceSubGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteSubGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroupType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSubGroupId;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBedCancel;
        private System.Windows.Forms.Button btnBedSave;
        private System.Windows.Forms.TextBox txtSubGroupNamme;
        private System.Windows.Forms.DataGridView dgGroups;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroupId;
        private System.Windows.Forms.DataGridView dgServiceSubGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}