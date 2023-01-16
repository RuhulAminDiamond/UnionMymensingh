namespace Store.Forms
{
    partial class frmWardInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWardInfo));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgWardInfo = new System.Windows.Forms.DataGridView();
            this.WardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnBedDelete = new System.Windows.Forms.Button();
            this.btnBedCancel = new System.Windows.Forms.Button();
            this.btnBedSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBadDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbWard = new System.Windows.Forms.ComboBox();
            this.dgWardBed = new System.Windows.Forms.DataGridView();
            this.WardBedId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedRent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWardInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWardBed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(326, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 36);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(204, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 36);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(82, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 36);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(105, 41);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(285, 29);
            this.txtDescription.TabIndex = 20;
            // 
            // dgWardInfo
            // 
            this.dgWardInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWardInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WardId,
            this.Description});
            this.dgWardInfo.Location = new System.Drawing.Point(82, 137);
            this.dgWardInfo.Name = "dgWardInfo";
            this.dgWardInfo.Size = new System.Drawing.Size(442, 305);
            this.dgWardInfo.TabIndex = 26;
            this.dgWardInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgWardInfo_RowHeaderMouseClick);
            // 
            // WardId
            // 
            this.WardId.DataPropertyName = "WardId";
            this.WardId.HeaderText = "Id";
            this.WardId.Name = "WardId";
            this.WardId.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // BtnBedDelete
            // 
            this.BtnBedDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBedDelete.Location = new System.Drawing.Point(805, 150);
            this.BtnBedDelete.Name = "BtnBedDelete";
            this.BtnBedDelete.Size = new System.Drawing.Size(90, 41);
            this.BtnBedDelete.TabIndex = 35;
            this.BtnBedDelete.Text = "Delete";
            this.BtnBedDelete.UseVisualStyleBackColor = true;
            this.BtnBedDelete.Visible = false;
            // 
            // btnBedCancel
            // 
            this.btnBedCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedCancel.Location = new System.Drawing.Point(710, 150);
            this.btnBedCancel.Name = "btnBedCancel";
            this.btnBedCancel.Size = new System.Drawing.Size(89, 41);
            this.btnBedCancel.TabIndex = 34;
            this.btnBedCancel.Text = "Cancel";
            this.btnBedCancel.UseVisualStyleBackColor = true;
            this.btnBedCancel.Visible = false;
            // 
            // btnBedSave
            // 
            this.btnBedSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedSave.Location = new System.Drawing.Point(615, 150);
            this.btnBedSave.Name = "btnBedSave";
            this.btnBedSave.Size = new System.Drawing.Size(89, 41);
            this.btnBedSave.TabIndex = 33;
            this.btnBedSave.Text = "Save";
            this.btnBedSave.UseVisualStyleBackColor = true;
            this.btnBedSave.Click += new System.EventHandler(this.btnBedSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(536, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Rent";
            // 
            // txtRent
            // 
            this.txtRent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRent.Location = new System.Drawing.Point(615, 102);
            this.txtRent.Name = "txtRent";
            this.txtRent.Size = new System.Drawing.Size(283, 29);
            this.txtRent.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(499, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Description";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBadDescription
            // 
            this.txtBadDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBadDescription.Location = new System.Drawing.Point(615, 60);
            this.txtBadDescription.Name = "txtBadDescription";
            this.txtBadDescription.Size = new System.Drawing.Size(283, 29);
            this.txtBadDescription.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(513, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Ward";
            // 
            // cbWard
            // 
            this.cbWard.FormattingEnabled = true;
            this.cbWard.Location = new System.Drawing.Point(615, 27);
            this.cbWard.Name = "cbWard";
            this.cbWard.Size = new System.Drawing.Size(163, 21);
            this.cbWard.TabIndex = 37;
            // 
            // dgWardBed
            // 
            this.dgWardBed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWardBed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WardBedId,
            this.BedDescription,
            this.BedRent});
            this.dgWardBed.Location = new System.Drawing.Point(615, 206);
            this.dgWardBed.Name = "dgWardBed";
            this.dgWardBed.Size = new System.Drawing.Size(419, 185);
            this.dgWardBed.TabIndex = 38;
            // 
            // WardBedId
            // 
            this.WardBedId.DataPropertyName = "WardBedId";
            this.WardBedId.HeaderText = "Id";
            this.WardBedId.Name = "WardBedId";
            // 
            // BedDescription
            // 
            this.BedDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BedDescription.DataPropertyName = "Description";
            this.BedDescription.HeaderText = "Description";
            this.BedDescription.Name = "BedDescription";
            // 
            // BedRent
            // 
            this.BedRent.DataPropertyName = "Rent";
            this.BedRent.HeaderText = "Rent";
            this.BedRent.Name = "BedRent";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(615, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 36);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWardInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 539);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgWardBed);
            this.Controls.Add(this.cbWard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnBedDelete);
            this.Controls.Add(this.btnBedCancel);
            this.Controls.Add(this.btnBedSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBadDescription);
            this.Controls.Add(this.dgWardInfo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWardInfo";
            this.Text = "Ward Info";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWardInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWardBed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView dgWardInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button BtnBedDelete;
        private System.Windows.Forms.Button btnBedCancel;
        private System.Windows.Forms.Button btnBedSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBadDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbWard;
        private System.Windows.Forms.DataGridView dgWardBed;
        private System.Windows.Forms.DataGridViewTextBoxColumn WardBedId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedRent;
        private System.Windows.Forms.Button btnClose;
    }
}