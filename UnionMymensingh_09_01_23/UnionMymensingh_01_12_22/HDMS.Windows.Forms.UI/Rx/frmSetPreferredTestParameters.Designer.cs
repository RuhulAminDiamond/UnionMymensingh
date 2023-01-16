namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmSetPreferredTestParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetPreferredTestParameters));
            this.lblTest = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.dgTestParams = new System.Windows.Forms.DataGridView();
            this.btnSavePreferredList = new System.Windows.Forms.Button();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboxcol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Controls.RxTestSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestParams)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(14, 26);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(37, 18);
            this.lblTest.TabIndex = 11219;
            this.lblTest.Text = "Test";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCode.Location = new System.Drawing.Point(54, 26);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(553, 29);
            this.txtTestCode.TabIndex = 11220;
            this.txtTestCode.TextChanged += new System.EventHandler(this.txtTestCode_TextChanged);
            // 
            // dgTestParams
            // 
            this.dgTestParams.AllowUserToAddRows = false;
            this.dgTestParams.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgTestParams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTestParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTestParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MName,
            this.Dosage,
            this.cboxcol});
            this.dgTestParams.Location = new System.Drawing.Point(54, 71);
            this.dgTestParams.Name = "dgTestParams";
            this.dgTestParams.RowHeadersWidth = 25;
            this.dgTestParams.Size = new System.Drawing.Size(698, 461);
            this.dgTestParams.TabIndex = 11222;
            // 
            // btnSavePreferredList
            // 
            this.btnSavePreferredList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePreferredList.Location = new System.Drawing.Point(54, 551);
            this.btnSavePreferredList.Name = "btnSavePreferredList";
            this.btnSavePreferredList.Size = new System.Drawing.Size(170, 45);
            this.btnSavePreferredList.TabIndex = 11223;
            this.btnSavePreferredList.Text = "Save Preferred List";
            this.btnSavePreferredList.UseVisualStyleBackColor = true;
            // 
            // MName
            // 
            this.MName.DataPropertyName = "Name";
            this.MName.HeaderText = "SrlNo";
            this.MName.Name = "MName";
            // 
            // Dosage
            // 
            this.Dosage.DataPropertyName = "Dosage";
            this.Dosage.HeaderText = "Parameter Name";
            this.Dosage.Name = "Dosage";
            this.Dosage.Width = 450;
            // 
            // cboxcol
            // 
            this.cboxcol.HeaderText = "Tick";
            this.cboxcol.Name = "cboxcol";
            this.cboxcol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboxcol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cboxcol.Width = 120;
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(202, 50);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(430, 525);
            this.ctlTestSearch.TabIndex = 11221;
            this.ctlTestSearch.Visible = false;
            // 
            // frmSetPreferredTestParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 630);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.btnSavePreferredList);
            this.Controls.Add(this.dgTestParams);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtTestCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetPreferredTestParameters";
            this.Text = "Set Preferred Test Parameters";
            this.Load += new System.EventHandler(this.frmSetPreferredTestParameters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTestParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtTestCode;
        private Controls.RxTestSearchControl ctlTestSearch;
        private System.Windows.Forms.DataGridView dgTestParams;
        private System.Windows.Forms.Button btnSavePreferredList;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dosage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cboxcol;
    }
}