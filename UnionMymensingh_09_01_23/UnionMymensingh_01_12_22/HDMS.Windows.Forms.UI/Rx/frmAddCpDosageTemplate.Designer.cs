namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmAddCpDosageTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCpDosageTemplate));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLongDoseBn = new System.Windows.Forms.TextBox();
            this.txtLongDoseEn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShortDoseEn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortDoseBn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtshortkey = new System.Windows.Forms.TextBox();
            this.cmbEMR = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgDosage = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDosage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Long Dose (Bangla)";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(177, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLongDoseBn
            // 
            this.txtLongDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseBn.Location = new System.Drawing.Point(177, 23);
            this.txtLongDoseBn.Multiline = true;
            this.txtLongDoseBn.Name = "txtLongDoseBn";
            this.txtLongDoseBn.Size = new System.Drawing.Size(391, 32);
            this.txtLongDoseBn.TabIndex = 0;
            // 
            // txtLongDoseEn
            // 
            this.txtLongDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseEn.Location = new System.Drawing.Point(177, 62);
            this.txtLongDoseEn.Multiline = true;
            this.txtLongDoseEn.Name = "txtLongDoseEn";
            this.txtLongDoseEn.Size = new System.Drawing.Size(391, 32);
            this.txtLongDoseEn.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Long Dose (English)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Short  Dose (English)";
            // 
            // txtShortDoseEn
            // 
            this.txtShortDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseEn.Location = new System.Drawing.Point(712, 23);
            this.txtShortDoseEn.Multiline = true;
            this.txtShortDoseEn.Name = "txtShortDoseEn";
            this.txtShortDoseEn.Size = new System.Drawing.Size(179, 32);
            this.txtShortDoseEn.TabIndex = 3;
            this.txtShortDoseEn.TextChanged += new System.EventHandler(this.txtShortDoseEn_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(577, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Short  Dose (Bangla)";
            // 
            // txtShortDoseBn
            // 
            this.txtShortDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseBn.Location = new System.Drawing.Point(712, 62);
            this.txtShortDoseBn.Multiline = true;
            this.txtShortDoseBn.Name = "txtShortDoseBn";
            this.txtShortDoseBn.Size = new System.Drawing.Size(179, 32);
            this.txtShortDoseBn.TabIndex = 1;
            this.txtShortDoseBn.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(636, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Short Key";
            // 
            // txtshortkey
            // 
            this.txtshortkey.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshortkey.Location = new System.Drawing.Point(712, 100);
            this.txtshortkey.Multiline = true;
            this.txtshortkey.Name = "txtshortkey";
            this.txtshortkey.Size = new System.Drawing.Size(146, 32);
            this.txtshortkey.TabIndex = 4;
            // 
            // cmbEMR
            // 
            this.cmbEMR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEMR.FormattingEnabled = true;
            this.cmbEMR.Location = new System.Drawing.Point(177, 108);
            this.cmbEMR.Name = "cmbEMR";
            this.cmbEMR.Size = new System.Drawing.Size(233, 27);
            this.cmbEMR.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Dose EMR Interpretation";
            // 
            // dgDosage
            // 
            this.dgDosage.AllowUserToAddRows = false;
            this.dgDosage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDosage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Diagnosis,
            this.LongDescription,
            this.LongEn,
            this.ShortEn,
            this.ShortKey,
            this.EMR});
            this.dgDosage.Location = new System.Drawing.Point(38, 201);
            this.dgDosage.Name = "dgDosage";
            this.dgDosage.Size = new System.Drawing.Size(1094, 383);
            this.dgDosage.TabIndex = 24;
            this.dgDosage.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDosage_RowHeaderMouseDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "IdNo";
            this.Id.Name = "Id";
            // 
            // Diagnosis
            // 
            this.Diagnosis.HeaderText = "Long (Bangla)";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.Width = 270;
            // 
            // LongDescription
            // 
            this.LongDescription.HeaderText = "Short (Bn)";
            this.LongDescription.Name = "LongDescription";
            this.LongDescription.Width = 120;
            // 
            // LongEn
            // 
            this.LongEn.HeaderText = "Long (English)";
            this.LongEn.Name = "LongEn";
            this.LongEn.Width = 240;
            // 
            // ShortEn
            // 
            this.ShortEn.HeaderText = "Short (En)";
            this.ShortEn.Name = "ShortEn";
            this.ShortEn.Width = 120;
            // 
            // ShortKey
            // 
            this.ShortKey.HeaderText = "Short Key";
            this.ShortKey.Name = "ShortKey";
            // 
            // EMR
            // 
            this.EMR.HeaderText = "EMR Interpret.";
            this.EMR.Name = "EMR";
            // 
            // frmAddCpDosageTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 607);
            this.Controls.Add(this.dgDosage);
            this.Controls.Add(this.cmbEMR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtshortkey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShortDoseEn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtShortDoseBn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLongDoseEn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLongDoseBn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddCpDosageTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Dosage/s";
            this.Load += new System.EventHandler(this.frmAddDosageTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDosage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLongDoseBn;
        private System.Windows.Forms.TextBox txtLongDoseEn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShortDoseEn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShortDoseBn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtshortkey;
        private System.Windows.Forms.ComboBox cmbEMR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMR;
    }
}