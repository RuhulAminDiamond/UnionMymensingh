namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    partial class frmReferralByDoctorPatientWise
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefdBy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.cmdShow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.btnMediaStatement = new System.Windows.Forms.Button();
            this.ctlMediaSearchControl = new HDMS.Windows.Forms.UI.Controls.MediaSearchControl();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Select Referral";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtRefdBy
            // 
            this.txtRefdBy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefdBy.Location = new System.Drawing.Point(282, 34);
            this.txtRefdBy.Name = "txtRefdBy";
            this.txtRefdBy.Size = new System.Drawing.Size(346, 26);
            this.txtRefdBy.TabIndex = 26;
            this.txtRefdBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefdBy_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(444, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(489, 84);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 23;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(282, 84);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 22;
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(280, 127);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(147, 34);
            this.cmdShow.TabIndex = 29;
            this.cmdShow.Text = "Doctor Statement";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(482, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 34);
            this.button1.TabIndex = 30;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMedia
            // 
            this.txtMedia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedia.Location = new System.Drawing.Point(736, -26);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(15, 26);
            this.txtMedia.TabIndex = 32;
            this.txtMedia.TextChanged += new System.EventHandler(this.txtMedia_TextChanged);
            this.txtMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(12, 245);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(636, 385);
            this.ctlDoctorSearch.TabIndex = 28;
            this.ctlDoctorSearch.Visible = false;
            this.ctlDoctorSearch.Load += new System.EventHandler(this.ctlDoctorSearch_Load);
            // 
            // btnMediaStatement
            // 
            this.btnMediaStatement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaStatement.Location = new System.Drawing.Point(786, -38);
            this.btnMediaStatement.Name = "btnMediaStatement";
            this.btnMediaStatement.Size = new System.Drawing.Size(28, 33);
            this.btnMediaStatement.TabIndex = 34;
            this.btnMediaStatement.Text = ".";
            this.btnMediaStatement.UseVisualStyleBackColor = true;
            this.btnMediaStatement.Click += new System.EventHandler(this.btnMediaStatement_Click);
            // 
            // ctlMediaSearchControl
            // 
            this.ctlMediaSearchControl.Location = new System.Drawing.Point(294, 233);
            this.ctlMediaSearchControl.Name = "ctlMediaSearchControl";
            this.ctlMediaSearchControl.Size = new System.Drawing.Size(656, 532);
            this.ctlMediaSearchControl.TabIndex = 11131;
            this.ctlMediaSearchControl.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(838, -41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 34);
            this.button2.TabIndex = 11132;
            this.button2.Text = ".";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmReferralByDoctorPatientWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 476);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ctlMediaSearchControl);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRefdBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMediaStatement);
            this.Name = "frmReferralByDoctorPatientWise";
            this.Text = "Referral By Doctor Patient Wise";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmReferralByDoctorPatientWise_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefdBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.Button btnMediaStatement;
        private Controls.MediaSearchControl ctlMediaSearchControl;
        private System.Windows.Forms.Button button2;
    }
}