namespace HDMS.Windows.Forms.UI.Accounts
{
    partial class frmUserwisePatientReceiptStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserwisePatientReceiptStatement));
            this.cmdShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radOPD = new System.Windows.Forms.RadioButton();
            this.radIPD = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(174, 177);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(125, 34);
            this.cmdShow.TabIndex = 14;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(372, 132);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 11;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(174, 132);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 10;
            // 
            // cmbUser
            // 
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "J",
            "D",
            "C",
            "Cash"});
            this.cmbUser.Location = new System.Drawing.Point(174, 49);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(164, 29);
            this.cmbUser.TabIndex = 29;
            this.cmbUser.ValueMember = "Id";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(85, 49);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(82, 20);
            this.lblGender.TabIndex = 30;
            this.lblGender.Text = "Select User";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Report Option";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(340, 93);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(45, 24);
            this.radAll.TabIndex = 33;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radOPD
            // 
            this.radOPD.AutoSize = true;
            this.radOPD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOPD.Location = new System.Drawing.Point(262, 93);
            this.radOPD.Name = "radOPD";
            this.radOPD.Size = new System.Drawing.Size(57, 24);
            this.radOPD.TabIndex = 32;
            this.radOPD.TabStop = true;
            this.radOPD.Text = "OPD";
            this.radOPD.UseVisualStyleBackColor = true;
            // 
            // radIPD
            // 
            this.radIPD.AutoSize = true;
            this.radIPD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIPD.Location = new System.Drawing.Point(186, 93);
            this.radIPD.Name = "radIPD";
            this.radIPD.Size = new System.Drawing.Size(50, 24);
            this.radIPD.TabIndex = 31;
            this.radIPD.TabStop = true;
            this.radIPD.Text = "IPD";
            this.radIPD.UseVisualStyleBackColor = true;
            // 
            // frmUserwisePatientReceiptStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 280);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.radOPD);
            this.Controls.Add(this.radIPD);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUserwisePatientReceiptStatement";
            this.Text = "Userwise Patient Receipt Statement";
            this.Load += new System.EventHandler(this.frmUserwisePatientReceiptStatement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radOPD;
        private System.Windows.Forms.RadioButton radIPD;
    }
}