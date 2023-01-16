namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmOPDServiceHeadEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPDServiceHeadEntry));
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSGroupId = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.IsDocVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVatable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceHeadId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkServiceCharge = new System.Windows.Forms.CheckBox();
            this.dgServiceHeads = new System.Windows.Forms.DataGridView();
            this.cmbSubGroups = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceHeads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(289, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 38);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkVat
            // 
            this.chkVat.AutoSize = true;
            this.chkVat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVat.Location = new System.Drawing.Point(156, 110);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(125, 24);
            this.chkVat.TabIndex = 79;
            this.chkVat.Text = "Vat Applicable";
            this.chkVat.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(84, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 77;
            this.label2.Text = "Group Id";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSGroupId
            // 
            this.txtSGroupId.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSGroupId.Location = new System.Drawing.Point(157, 63);
            this.txtSGroupId.Name = "txtSGroupId";
            this.txtSGroupId.Size = new System.Drawing.Size(160, 29);
            this.txtSGroupId.TabIndex = 78;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(427, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(154, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(752, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRate.Location = new System.Drawing.Point(797, 63);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(143, 29);
            this.txtRate.TabIndex = 73;
            // 
            // IsDocVisit
            // 
            this.IsDocVisit.DataPropertyName = "DocVisit";
            this.IsDocVisit.HeaderText = "DocVisit";
            this.IsDocVisit.Name = "IsDocVisit";
            // 
            // ServiceCharge
            // 
            this.ServiceCharge.DataPropertyName = "ServiceCharge";
            this.ServiceCharge.HeaderText = "ServiceCharge";
            this.ServiceCharge.Name = "ServiceCharge";
            // 
            // IsVatable
            // 
            this.IsVatable.DataPropertyName = "Vat";
            this.IsVatable.HeaderText = "Vatable";
            this.IsVatable.Name = "IsVatable";
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // BedDescription
            // 
            this.BedDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BedDescription.DataPropertyName = "ServiceHeadName";
            this.BedDescription.HeaderText = "Name";
            this.BedDescription.Name = "BedDescription";
            // 
            // ServiceHeadId
            // 
            this.ServiceHeadId.DataPropertyName = "ServiceHeadId";
            this.ServiceHeadId.HeaderText = "Id";
            this.ServiceHeadId.Name = "ServiceHeadId";
            // 
            // chkServiceCharge
            // 
            this.chkServiceCharge.AutoSize = true;
            this.chkServiceCharge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkServiceCharge.Location = new System.Drawing.Point(289, 110);
            this.chkServiceCharge.Name = "chkServiceCharge";
            this.chkServiceCharge.Size = new System.Drawing.Size(151, 24);
            this.chkServiceCharge.TabIndex = 80;
            this.chkServiceCharge.Text = "Service Applicable";
            this.chkServiceCharge.UseVisualStyleBackColor = true;
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
            this.dgServiceHeads.Location = new System.Drawing.Point(157, 224);
            this.dgServiceHeads.Name = "dgServiceHeads";
            this.dgServiceHeads.Size = new System.Drawing.Size(905, 424);
            this.dgServiceHeads.TabIndex = 72;
            this.dgServiceHeads.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgServiceHeads_RowHeaderMouseClick);
            // 
            // cmbSubGroups
            // 
            this.cmbSubGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubGroups.FormattingEnabled = true;
            this.cmbSubGroups.Location = new System.Drawing.Point(157, 23);
            this.cmbSubGroups.Name = "cmbSubGroups";
            this.cmbSubGroups.Size = new System.Drawing.Size(553, 28);
            this.cmbSubGroups.TabIndex = 71;
            this.cmbSubGroups.SelectedIndexChanged += new System.EventHandler(this.cmbSubGroups_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(28, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 70;
            this.label5.Text = "Select Sub Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(332, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "Head Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(427, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(283, 29);
            this.txtName.TabIndex = 69;
            // 
            // frmOPDServiceHeadEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 682);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkVat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSGroupId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.chkServiceCharge);
            this.Controls.Add(this.dgServiceHeads);
            this.Controls.Add(this.cmbSubGroups);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPDServiceHeadEntry";
            this.Text = "OPD Service Head Entry";
            this.Load += new System.EventHandler(this.frmOPDServiceHeadEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceHeads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSGroupId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDocVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsVatable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceHeadId;
        private System.Windows.Forms.CheckBox chkServiceCharge;
        private System.Windows.Forms.DataGridView dgServiceHeads;
        private System.Windows.Forms.ComboBox cmbSubGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
    }
}