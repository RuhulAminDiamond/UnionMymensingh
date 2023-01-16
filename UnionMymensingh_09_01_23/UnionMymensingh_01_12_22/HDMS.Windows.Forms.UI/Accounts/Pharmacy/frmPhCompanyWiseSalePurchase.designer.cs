namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    partial class frmPhCompanyWiseSalePurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhCompanyWiseSalePurchase));
            this.cmdViewStatement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateto = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cmdViewStatement
            // 
            this.cmdViewStatement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewStatement.Location = new System.Drawing.Point(196, 116);
            this.cmdViewStatement.Name = "cmdViewStatement";
            this.cmdViewStatement.Size = new System.Drawing.Size(171, 34);
            this.cmdViewStatement.TabIndex = 48;
            this.cmdViewStatement.Text = "View Statement";
            this.cmdViewStatement.UseVisualStyleBackColor = true;
            this.cmdViewStatement.Click += new System.EventHandler(this.btnSummaryReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Date from";
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(196, 70);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 29);
            this.dtpfrm.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 50;
            this.label2.Text = "Date to";
            // 
            // dateto
            // 
            this.dateto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateto.Location = new System.Drawing.Point(414, 70);
            this.dateto.Name = "dateto";
            this.dateto.Size = new System.Drawing.Size(145, 29);
            this.dateto.TabIndex = 49;
            // 
            // frmPhCompanyWiseSalePurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 285);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateto);
            this.Controls.Add(this.cmdViewStatement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhCompanyWiseSalePurchase";
            this.Text = "Daily Sale Summary";
            this.Load += new System.EventHandler(this.frmPhDailySaleSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdViewStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateto;
    }
}