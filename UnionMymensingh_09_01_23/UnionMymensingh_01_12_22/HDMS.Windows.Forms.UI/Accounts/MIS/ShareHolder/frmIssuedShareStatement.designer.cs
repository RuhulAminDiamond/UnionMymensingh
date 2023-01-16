
namespace HDMS.Windows.Forms.UI.Accounts.MIS.ShareHolder
{
    partial class frmIssuedShareStatement
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
            this.cmbFiscalYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowStatement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbFiscalYear
            // 
            this.cmbFiscalYear.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiscalYear.FormattingEnabled = true;
            this.cmbFiscalYear.Location = new System.Drawing.Point(143, 49);
            this.cmbFiscalYear.Name = "cmbFiscalYear";
            this.cmbFiscalYear.Size = new System.Drawing.Size(241, 26);
            this.cmbFiscalYear.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Fiscal Year";
            // 
            // btnShowStatement
            // 
            this.btnShowStatement.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStatement.Location = new System.Drawing.Point(143, 88);
            this.btnShowStatement.Name = "btnShowStatement";
            this.btnShowStatement.Size = new System.Drawing.Size(136, 37);
            this.btnShowStatement.TabIndex = 2;
            this.btnShowStatement.Text = "Show Statement";
            this.btnShowStatement.UseVisualStyleBackColor = true;
            this.btnShowStatement.Click += new System.EventHandler(this.btnShowStatement_Click);
            // 
            // frmIssuedShareStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 235);
            this.Controls.Add(this.btnShowStatement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiscalYear);
            this.Name = "frmIssuedShareStatement";
            this.Text = "Issued Share Statement";
            this.Load += new System.EventHandler(this.frmRightShareStatement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFiscalYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowStatement;
    }
}