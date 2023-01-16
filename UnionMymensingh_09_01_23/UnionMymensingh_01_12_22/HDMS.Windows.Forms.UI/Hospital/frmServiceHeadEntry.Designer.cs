namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmServiceHeadEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceHeadEntry));
            this.cmbSubGroups = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgServiceHeads = new System.Windows.Forms.DataGridView();
            this.ServiceHeadId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVatable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDocVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSGroupId = new System.Windows.Forms.TextBox();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.chkServiceCharge = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceHeads)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubGroups
            // 
            this.cmbSubGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGroups.FormattingEnabled = true;
            this.cmbSubGroups.Location = new System.Drawing.Point(147, 12);
            this.cmbSubGroups.Name = "cmbSubGroups";
            this.cmbSubGroups.Size = new System.Drawing.Size(553, 28);
            this.cmbSubGroups.TabIndex = 57;
            this.cmbSubGroups.SelectedIndexChanged += new System.EventHandler(this.cmbSubGroups_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Select Sub Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(322, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Head Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(417, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(283, 29);
            this.txtName.TabIndex = 55;
            // 
            // dgServiceHeads
            // 
            this.dgServiceHeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgServiceHeads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceHeadId,
            this.BedDescription,
            this.Rate,
            this.IsVatable,
            this.ServiceCharge,
            this.IsDocVisit});
            this.dgServiceHeads.Location = new System.Drawing.Point(147, 213);
            this.dgServiceHeads.Name = "dgServiceHeads";
            this.dgServiceHeads.Size = new System.Drawing.Size(905, 424);
            this.dgServiceHeads.TabIndex = 58;
            this.dgServiceHeads.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgServiceHeads_RowHeaderMouseClick);
            // 
            // ServiceHeadId
            // 
            this.ServiceHeadId.DataPropertyName = "ServiceHeadId";
            this.ServiceHeadId.HeaderText = "Id";
            this.ServiceHeadId.Name = "ServiceHeadId";
            // 
            // BedDescription
            // 
            this.BedDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BedDescription.DataPropertyName = "ServiceHeadName";
            this.BedDescription.HeaderText = "Name";
            this.BedDescription.Name = "BedDescription";
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // IsVatable
            // 
            this.IsVatable.DataPropertyName = "Vat";
            this.IsVatable.HeaderText = "Vatable";
            this.IsVatable.Name = "IsVatable";
            // 
            // ServiceCharge
            // 
            this.ServiceCharge.DataPropertyName = "ServiceCharge";
            this.ServiceCharge.HeaderText = "ServiceCharge";
            this.ServiceCharge.Name = "ServiceCharge";
            // 
            // IsDocVisit
            // 
            this.IsDocVisit.DataPropertyName = "DocVisit";
            this.IsDocVisit.HeaderText = "DocVisit";
            this.IsDocVisit.Name = "IsDocVisit";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRate.Location = new System.Drawing.Point(787, 52);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(143, 29);
            this.txtRate.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(742, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(144, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(417, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(74, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Group Id";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSGroupId
            // 
            this.txtSGroupId.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSGroupId.Location = new System.Drawing.Point(147, 52);
            this.txtSGroupId.Name = "txtSGroupId";
            this.txtSGroupId.Size = new System.Drawing.Size(160, 29);
            this.txtSGroupId.TabIndex = 64;
            // 
            // chkVat
            // 
            this.chkVat.AutoSize = true;
            this.chkVat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVat.Location = new System.Drawing.Point(146, 99);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(125, 24);
            this.chkVat.TabIndex = 65;
            this.chkVat.Text = "Vat Applicable";
            this.chkVat.UseVisualStyleBackColor = true;
            // 
            // chkServiceCharge
            // 
            this.chkServiceCharge.AutoSize = true;
            this.chkServiceCharge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkServiceCharge.Location = new System.Drawing.Point(279, 99);
            this.chkServiceCharge.Name = "chkServiceCharge";
            this.chkServiceCharge.Size = new System.Drawing.Size(151, 24);
            this.chkServiceCharge.TabIndex = 66;
            this.chkServiceCharge.Text = "Service Applicable";
            this.chkServiceCharge.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(279, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 38);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmServiceHeadEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 620);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkServiceCharge);
            this.Controls.Add(this.chkVat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSGroupId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.dgServiceHeads);
            this.Controls.Add(this.cmbSubGroups);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServiceHeadEntry";
            this.Text = "Service Head Entry";
            this.Load += new System.EventHandler(this.frmServiceHeadEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceHeads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgServiceHeads;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceHeadId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsVatable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDocVisit;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSGroupId;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.CheckBox chkServiceCharge;
        private System.Windows.Forms.Button btnCancel;
    }
}