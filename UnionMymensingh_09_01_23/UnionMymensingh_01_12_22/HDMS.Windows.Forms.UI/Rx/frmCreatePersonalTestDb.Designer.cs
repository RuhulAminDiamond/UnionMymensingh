namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmCreatePersonalTestDb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatePersonalTestDb));
            this.txtTestNamePDB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestCDb = new System.Windows.Forms.TextBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Diagonstics.TestSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTestNamePDB
            // 
            this.txtTestNamePDB.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestNamePDB.Location = new System.Drawing.Point(192, 63);
            this.txtTestNamePDB.Name = "txtTestNamePDB";
            this.txtTestNamePDB.Size = new System.Drawing.Size(318, 26);
            this.txtTestNamePDB.TabIndex = 10206;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 18);
            this.label11.TabIndex = 10224;
            this.label11.Text = "Test Name (Personal DB)";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(192, 94);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(318, 27);
            this.cmbGroup.TabIndex = 10207;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 10222;
            this.label3.Text = "Test Group";
            // 
            // txtTestCDb
            // 
            this.txtTestCDb.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCDb.Location = new System.Drawing.Point(192, 31);
            this.txtTestCDb.Name = "txtTestCDb";
            this.txtTestCDb.Size = new System.Drawing.Size(318, 26);
            this.txtTestCDb.TabIndex = 10205;
            this.txtTestCDb.TextChanged += new System.EventHandler(this.txtTestCDb_TextChanged);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(25, 31);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(152, 18);
            this.lblTest.TabIndex = 10216;
            this.lblTest.Text = "Select Test (Central DB)";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(192, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 31);
            this.btnSave.TabIndex = 10215;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Diagnosis});
            this.dgTests.Location = new System.Drawing.Point(43, 191);
            this.dgTests.Name = "dgTests";
            this.dgTests.Size = new System.Drawing.Size(642, 323);
            this.dgTests.TabIndex = 10225;
            this.dgTests.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgTests_UserDeletedRow);
            // 
            // Id
            // 
            this.Id.HeaderText = "IdNo";
            this.Id.Name = "Id";
            // 
            // Diagnosis
            // 
            this.Diagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Diagnosis.HeaderText = "Test Name";
            this.Diagnosis.Name = "Diagnosis";
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(137, 176);
            this.ctlTestSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(536, 365);
            this.ctlTestSearch.TabIndex = 10226;
            this.ctlTestSearch.Visible = false;
            // 
            // frmCreatePersonalTestDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 526);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.txtTestNamePDB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTestCDb);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCreatePersonalTestDb";
            this.Text = "Create Personal Test Database";
            this.Load += new System.EventHandler(this.frmCreatePersonalTestDb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTestNamePDB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTestCDb;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private Diagonstics.TestSearchControl ctlTestSearch;
    }
}