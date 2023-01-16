
namespace HDMS.Windows.Forms.UI.ShareHolder
{
    partial class frmRightShareDistribution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRightShareDistribution));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiscalYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRightShare = new System.Windows.Forms.TextBox();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgRightShare = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFiscalYear = new System.Windows.Forms.Label();
            this.ShareHolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuedShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalRightShare = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteCurrentDistribution = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgRightShare)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fiscal Year :";
            // 
            // cmbFiscalYear
            // 
            this.cmbFiscalYear.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiscalYear.FormattingEnabled = true;
            this.cmbFiscalYear.Location = new System.Drawing.Point(174, 44);
            this.cmbFiscalYear.Name = "cmbFiscalYear";
            this.cmbFiscalYear.Size = new System.Drawing.Size(135, 26);
            this.cmbFiscalYear.TabIndex = 1;
            this.cmbFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cmbFiscalYear_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Right Share :";
            // 
            // txtRightShare
            // 
            this.txtRightShare.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightShare.Location = new System.Drawing.Point(174, 79);
            this.txtRightShare.Name = "txtRightShare";
            this.txtRightShare.Size = new System.Drawing.Size(108, 26);
            this.txtRightShare.TabIndex = 2;
            // 
            // btnDistribute
            // 
            this.btnDistribute.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDistribute.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistribute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDistribute.Location = new System.Drawing.Point(173, 113);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(109, 40);
            this.btnDistribute.TabIndex = 3;
            this.btnDistribute.Text = "Distribute";
            this.btnDistribute.UseVisualStyleBackColor = false;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // dgRightShare
            // 
            this.dgRightShare.AllowUserToAddRows = false;
            this.dgRightShare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRightShare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShareHolderName,
            this.TotalShare,
            this.RightShare,
            this.IssuedShare,
            this.ExtraShare});
            this.dgRightShare.Location = new System.Drawing.Point(413, 44);
            this.dgRightShare.Name = "dgRightShare";
            this.dgRightShare.Size = new System.Drawing.Size(743, 585);
            this.dgRightShare.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fiscal Year :";
            // 
            // lblFiscalYear
            // 
            this.lblFiscalYear.AutoSize = true;
            this.lblFiscalYear.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiscalYear.Location = new System.Drawing.Point(516, 9);
            this.lblFiscalYear.Name = "lblFiscalYear";
            this.lblFiscalYear.Size = new System.Drawing.Size(0, 23);
            this.lblFiscalYear.TabIndex = 7;
            // 
            // ShareHolderName
            // 
            this.ShareHolderName.HeaderText = "Share Holder Name";
            this.ShareHolderName.Name = "ShareHolderName";
            this.ShareHolderName.Width = 300;
            // 
            // TotalShare
            // 
            this.TotalShare.HeaderText = "Total Share";
            this.TotalShare.Name = "TotalShare";
            // 
            // RightShare
            // 
            this.RightShare.HeaderText = "Right Share";
            this.RightShare.Name = "RightShare";
            // 
            // IssuedShare
            // 
            this.IssuedShare.HeaderText = "Issued Share";
            this.IssuedShare.Name = "IssuedShare";
            // 
            // ExtraShare
            // 
            this.ExtraShare.HeaderText = "Extra Share";
            this.ExtraShare.Name = "ExtraShare";
            // 
            // lblTotalRightShare
            // 
            this.lblTotalRightShare.AutoSize = true;
            this.lblTotalRightShare.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRightShare.Location = new System.Drawing.Point(1044, 646);
            this.lblTotalRightShare.Name = "lblTotalRightShare";
            this.lblTotalRightShare.Size = new System.Drawing.Size(0, 23);
            this.lblTotalRightShare.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(863, 646);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total Right Share :";
            // 
            // btnDeleteCurrentDistribution
            // 
            this.btnDeleteCurrentDistribution.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteCurrentDistribution.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCurrentDistribution.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteCurrentDistribution.Location = new System.Drawing.Point(413, 646);
            this.btnDeleteCurrentDistribution.Name = "btnDeleteCurrentDistribution";
            this.btnDeleteCurrentDistribution.Size = new System.Drawing.Size(268, 40);
            this.btnDeleteCurrentDistribution.TabIndex = 10;
            this.btnDeleteCurrentDistribution.Text = "Delete Current Distribution";
            this.btnDeleteCurrentDistribution.UseVisualStyleBackColor = false;
            this.btnDeleteCurrentDistribution.Click += new System.EventHandler(this.btnDeleteCurrentDistribution_Click);
            // 
            // frmRightShareDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1181, 744);
            this.Controls.Add(this.btnDeleteCurrentDistribution);
            this.Controls.Add(this.lblTotalRightShare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFiscalYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgRightShare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDistribute);
            this.Controls.Add(this.txtRightShare);
            this.Controls.Add(this.cmbFiscalYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRightShareDistribution";
            this.Text = "Right Share Distribution";
            this.Load += new System.EventHandler(this.frmRightShareDistribution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRightShare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiscalYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRightShare;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgRightShare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFiscalYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShareHolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuedShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraShare;
        private System.Windows.Forms.Label lblTotalRightShare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteCurrentDistribution;
    }
}