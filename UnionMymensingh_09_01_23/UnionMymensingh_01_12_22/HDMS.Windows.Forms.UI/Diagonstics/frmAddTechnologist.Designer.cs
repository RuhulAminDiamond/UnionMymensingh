namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmAddTechnologist
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
            this.dgTechnologist = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIdentityLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdentityLine3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdentityLine2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFontSizeforIdentity1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdentityLine1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameFontSize = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTechnologist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTechnologist
            // 
            this.dgTechnologist.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgTechnologist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTechnologist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CName,
            this.DIdentityLine1,
            this.DIdentityLine2});
            this.dgTechnologist.Location = new System.Drawing.Point(625, 35);
            this.dgTechnologist.Name = "dgTechnologist";
            this.dgTechnologist.Size = new System.Drawing.Size(626, 418);
            this.dgTechnologist.TabIndex = 74;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "RCId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // CName
            // 
            this.CName.DataPropertyName = "Name";
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.Width = 280;
            // 
            // DIdentityLine1
            // 
            this.DIdentityLine1.DataPropertyName = "DIdentityLine1";
            this.DIdentityLine1.HeaderText = "Identity Line1";
            this.DIdentityLine1.Name = "DIdentityLine1";
            this.DIdentityLine1.Width = 200;
            // 
            // DIdentityLine2
            // 
            this.DIdentityLine2.DataPropertyName = "DIdentityLine2";
            this.DIdentityLine2.HeaderText = "Identity Line2";
            this.DIdentityLine2.Name = "DIdentityLine2";
            this.DIdentityLine2.Width = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(464, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 73;
            this.label8.Text = "Font Size";
            // 
            // txtFontSizeforIdentity3
            // 
            this.txtFontSizeforIdentity3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity3.Location = new System.Drawing.Point(534, 168);
            this.txtFontSizeforIdentity3.Name = "txtFontSizeforIdentity3";
            this.txtFontSizeforIdentity3.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity3.TabIndex = 72;
            this.txtFontSizeforIdentity3.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(61, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 71;
            this.label9.Text = "Identity-3";
            // 
            // txtIdentityLine3
            // 
            this.txtIdentityLine3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine3.Location = new System.Drawing.Point(150, 168);
            this.txtIdentityLine3.Name = "txtIdentityLine3";
            this.txtIdentityLine3.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine3.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "Font Size";
            // 
            // txtFontSizeforIdentity2
            // 
            this.txtFontSizeforIdentity2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity2.Location = new System.Drawing.Point(533, 125);
            this.txtFontSizeforIdentity2.Name = "txtFontSizeforIdentity2";
            this.txtFontSizeforIdentity2.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity2.TabIndex = 68;
            this.txtFontSizeforIdentity2.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Identity-2";
            // 
            // txtIdentityLine2
            // 
            this.txtIdentityLine2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine2.Location = new System.Drawing.Point(149, 125);
            this.txtIdentityLine2.Name = "txtIdentityLine2";
            this.txtIdentityLine2.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine2.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(463, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "Font Size";
            // 
            // txtFontSizeforIdentity1
            // 
            this.txtFontSizeforIdentity1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSizeforIdentity1.Location = new System.Drawing.Point(533, 80);
            this.txtFontSizeforIdentity1.Name = "txtFontSizeforIdentity1";
            this.txtFontSizeforIdentity1.Size = new System.Drawing.Size(76, 27);
            this.txtFontSizeforIdentity1.TabIndex = 64;
            this.txtFontSizeforIdentity1.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "Identity-1";
            // 
            // txtIdentityLine1
            // 
            this.txtIdentityLine1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityLine1.Location = new System.Drawing.Point(149, 80);
            this.txtIdentityLine1.Name = "txtIdentityLine1";
            this.txtIdentityLine1.Size = new System.Drawing.Size(297, 27);
            this.txtIdentityLine1.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 61;
            this.label3.Text = "Font Size";
            // 
            // txtNameFontSize
            // 
            this.txtNameFontSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameFontSize.Location = new System.Drawing.Point(533, 38);
            this.txtNameFontSize.Name = "txtNameFontSize";
            this.txtNameFontSize.Size = new System.Drawing.Size(76, 27);
            this.txtNameFontSize.TabIndex = 60;
            this.txtNameFontSize.Text = "10";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(149, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(297, 27);
            this.txtName.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Technogist Name";
            // 
            // frmAddTechnologist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 588);
            this.Controls.Add(this.dgTechnologist);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFontSizeforIdentity3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdentityLine3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFontSizeforIdentity2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIdentityLine2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFontSizeforIdentity1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdentityLine1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameFontSize);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmAddTechnologist";
            this.Text = "Add/Edit Technologist";
            ((System.ComponentModel.ISupportInitialize)(this.dgTechnologist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTechnologist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIdentityLine2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdentityLine3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdentityLine2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFontSizeforIdentity1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdentityLine1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameFontSize;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}