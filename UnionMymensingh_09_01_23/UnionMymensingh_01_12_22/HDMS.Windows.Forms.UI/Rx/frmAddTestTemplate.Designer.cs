namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmAddTestTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddTestTemplate));
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvestigation = new System.Windows.Forms.TextBox();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Diagonstics.TestSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Template Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(154, 36);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(496, 32);
            this.txtName.TabIndex = 18;
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Diagnosis});
            this.dgTests.Location = new System.Drawing.Point(154, 121);
            this.dgTests.Name = "dgTests";
            this.dgTests.Size = new System.Drawing.Size(520, 220);
            this.dgTests.TabIndex = 17;
            // 
            // Id
            // 
            this.Id.HeaderText = "Code No";
            this.Id.Name = "Id";
            // 
            // Diagnosis
            // 
            this.Diagnosis.HeaderText = "Name";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.Width = 375;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(154, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 40);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 10155;
            this.label1.Text = "Investigations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvestigation
            // 
            this.txtInvestigation.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvestigation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvestigation.Location = new System.Drawing.Point(154, 77);
            this.txtInvestigation.Name = "txtInvestigation";
            this.txtInvestigation.Size = new System.Drawing.Size(307, 29);
            this.txtInvestigation.TabIndex = 10154;
            this.txtInvestigation.TextChanged += new System.EventHandler(this.txtInvestigation_TextChanged);
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(154, 36);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(440, 403);
            this.ctlTestSearch.TabIndex = 10156;
            this.ctlTestSearch.Visible = false;
            // 
            // frmAddTestTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 480);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInvestigation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddTestTemplate";
            this.Text = "Add Test Template";
            this.Load += new System.EventHandler(this.frmAddTestTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvestigation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private Diagonstics.TestSearchControl ctlTestSearch;
    }
}