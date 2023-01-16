namespace HDMS.Windows.Forms.UI.Common
{
    partial class frmDiscountPlanSetup
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
            this.cmbCompanyName = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbRegDesignation = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtLabDiscount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRadiologyImagingDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIPDBedDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiscountOnOxygenBill = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVentilationDiscount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiscountOnPharmacyBill = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscountOnServiceCharge = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(328, 38);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(447, 29);
            this.cmbCompanyName.TabIndex = 11125;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(206, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(116, 20);
            this.label23.TabIndex = 11128;
            this.label23.Text = "Company Name";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRegDesignation
            // 
            this.cmbRegDesignation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbRegDesignation.FormattingEnabled = true;
            this.cmbRegDesignation.Items.AddRange(new object[] {
            "Married",
            "Unmarried",
            "Not Applicable"});
            this.cmbRegDesignation.Location = new System.Drawing.Point(328, 73);
            this.cmbRegDesignation.Name = "cmbRegDesignation";
            this.cmbRegDesignation.Size = new System.Drawing.Size(173, 29);
            this.cmbRegDesignation.TabIndex = 11126;
            this.cmbRegDesignation.SelectedIndexChanged += new System.EventHandler(this.cmbRegDesignation_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(233, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 20);
            this.label22.TabIndex = 11127;
            this.label22.Text = "Designation";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLabDiscount
            // 
            this.txtLabDiscount.BackColor = System.Drawing.Color.White;
            this.txtLabDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLabDiscount.Location = new System.Drawing.Point(328, 108);
            this.txtLabDiscount.Name = "txtLabDiscount";
            this.txtLabDiscount.Size = new System.Drawing.Size(115, 29);
            this.txtLabDiscount.TabIndex = 11129;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(147, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 20);
            this.label11.TabIndex = 11130;
            this.label11.Text = "Lab Discount (Pathology)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 11131;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 11134;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRadiologyImagingDiscount
            // 
            this.txtRadiologyImagingDiscount.BackColor = System.Drawing.Color.White;
            this.txtRadiologyImagingDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRadiologyImagingDiscount.Location = new System.Drawing.Point(328, 143);
            this.txtRadiologyImagingDiscount.Name = "txtRadiologyImagingDiscount";
            this.txtRadiologyImagingDiscount.Size = new System.Drawing.Size(115, 29);
            this.txtRadiologyImagingDiscount.TabIndex = 11132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 20);
            this.label3.TabIndex = 11133;
            this.label3.Text = "Non-Lab Discount (Radiology and Imaging)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 11137;
            this.label4.Text = "%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIPDBedDiscount
            // 
            this.txtIPDBedDiscount.BackColor = System.Drawing.Color.White;
            this.txtIPDBedDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtIPDBedDiscount.Location = new System.Drawing.Point(328, 178);
            this.txtIPDBedDiscount.Name = "txtIPDBedDiscount";
            this.txtIPDBedDiscount.Size = new System.Drawing.Size(115, 29);
            this.txtIPDBedDiscount.TabIndex = 11135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(154, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 11136;
            this.label5.Text = "Bed Rent Discount (IPD)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(449, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 11140;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountOnOxygenBill
            // 
            this.txtDiscountOnOxygenBill.BackColor = System.Drawing.Color.White;
            this.txtDiscountOnOxygenBill.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountOnOxygenBill.Location = new System.Drawing.Point(328, 213);
            this.txtDiscountOnOxygenBill.Name = "txtDiscountOnOxygenBill";
            this.txtDiscountOnOxygenBill.Size = new System.Drawing.Size(115, 29);
            this.txtDiscountOnOxygenBill.TabIndex = 11138;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(153, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 11139;
            this.label7.Text = "Discount On Oxygen Bill";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(449, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 20);
            this.label8.TabIndex = 11143;
            this.label8.Text = "%";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVentilationDiscount
            // 
            this.txtVentilationDiscount.BackColor = System.Drawing.Color.White;
            this.txtVentilationDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVentilationDiscount.Location = new System.Drawing.Point(328, 248);
            this.txtVentilationDiscount.Name = "txtVentilationDiscount";
            this.txtVentilationDiscount.Size = new System.Drawing.Size(115, 29);
            this.txtVentilationDiscount.TabIndex = 11141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(153, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 11142;
            this.label9.Text = "Discount On Ventilation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(449, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 11146;
            this.label10.Text = "%";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountOnPharmacyBill
            // 
            this.txtDiscountOnPharmacyBill.BackColor = System.Drawing.Color.White;
            this.txtDiscountOnPharmacyBill.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountOnPharmacyBill.Location = new System.Drawing.Point(328, 283);
            this.txtDiscountOnPharmacyBill.Name = "txtDiscountOnPharmacyBill";
            this.txtDiscountOnPharmacyBill.Size = new System.Drawing.Size(115, 29);
            this.txtDiscountOnPharmacyBill.TabIndex = 11144;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(139, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 20);
            this.label12.TabIndex = 11145;
            this.label12.Text = "Discount On Pharmacy Bill";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(449, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 20);
            this.label13.TabIndex = 11149;
            this.label13.Text = "%";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountOnServiceCharge
            // 
            this.txtDiscountOnServiceCharge.BackColor = System.Drawing.Color.White;
            this.txtDiscountOnServiceCharge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountOnServiceCharge.Location = new System.Drawing.Point(328, 318);
            this.txtDiscountOnServiceCharge.Name = "txtDiscountOnServiceCharge";
            this.txtDiscountOnServiceCharge.Size = new System.Drawing.Size(115, 29);
            this.txtDiscountOnServiceCharge.TabIndex = 11147;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(103, 318);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(219, 20);
            this.label14.TabIndex = 11148;
            this.label14.Text = "Discount On IPD Service Charge";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(328, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 11150;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(435, 370);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 29);
            this.btnClose.TabIndex = 11151;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDiscountPlanSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 549);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDiscountOnServiceCharge);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDiscountOnPharmacyBill);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVentilationDiscount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiscountOnOxygenBill);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIPDBedDiscount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRadiologyImagingDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLabDiscount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbRegDesignation);
            this.Controls.Add(this.label22);
            this.Name = "frmDiscountPlanSetup";
            this.Text = "Discount Plan Setup";
            this.Load += new System.EventHandler(this.frmDiscountPlanSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCompanyName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbRegDesignation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtLabDiscount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRadiologyImagingDiscount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIPDBedDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiscountOnOxygenBill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVentilationDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiscountOnPharmacyBill;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiscountOnServiceCharge;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}