namespace HDMS.Windows.Forms.UI.Accounts
{
    partial class frmRefundReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.cmdRefundDateWise = new System.Windows.Forms.Button();
            this.cmdRefundPatientWise = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(314, 58);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(199, 27);
            this.dtpto.TabIndex = 25;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(78, 58);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(194, 27);
            this.dtpfrm.TabIndex = 24;
            // 
            // cmdRefundDateWise
            // 
            this.cmdRefundDateWise.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefundDateWise.Location = new System.Drawing.Point(74, 129);
            this.cmdRefundDateWise.Name = "cmdRefundDateWise";
            this.cmdRefundDateWise.Size = new System.Drawing.Size(145, 34);
            this.cmdRefundDateWise.TabIndex = 28;
            this.cmdRefundDateWise.Text = "Refund Date Wise";
            this.cmdRefundDateWise.UseVisualStyleBackColor = true;
            this.cmdRefundDateWise.Click += new System.EventHandler(this.cmdRefundDateWise_Click);
            // 
            // cmdRefundPatientWise
            // 
            this.cmdRefundPatientWise.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefundPatientWise.Location = new System.Drawing.Point(227, 129);
            this.cmdRefundPatientWise.Name = "cmdRefundPatientWise";
            this.cmdRefundPatientWise.Size = new System.Drawing.Size(171, 34);
            this.cmdRefundPatientWise.TabIndex = 29;
            this.cmdRefundPatientWise.Text = "Refund Patient Wise";
            this.cmdRefundPatientWise.UseVisualStyleBackColor = true;
            this.cmdRefundPatientWise.Click += new System.EventHandler(this.cmdRefundPatientWise_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDetails.FlatAppearance.BorderSize = 3;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.Turquoise;
            this.btnDetails.Location = new System.Drawing.Point(411, 129);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(128, 43);
            this.btnDetails.TabIndex = 29;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // frmRefundReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 240);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.cmdRefundPatientWise);
            this.Controls.Add(this.cmdRefundDateWise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.MaximizeBox = false;
            this.Name = "frmRefundReport";
            this.Text = "Refund Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.Button cmdRefundDateWise;
        private System.Windows.Forms.Button cmdRefundPatientWise;
        private System.Windows.Forms.Button btnDetails;
    }
}