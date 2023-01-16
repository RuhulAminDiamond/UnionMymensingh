namespace HDMS.Windows.Forms.UI.Accounts
{
    partial class frmReferredCases
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
            this.cmdShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefdBy = new System.Windows.Forms.TextBox();
            this.btnByReferralDetail = new System.Windows.Forms.Button();
            this.btnOpd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.SuspendLayout();
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(357, 152);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(125, 34);
            this.cmdShow.TabIndex = 19;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(343, 99);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 16;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(145, 99);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Select Referral";
            // 
            // txtRefdBy
            // 
            this.txtRefdBy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefdBy.Location = new System.Drawing.Point(145, 58);
            this.txtRefdBy.Name = "txtRefdBy";
            this.txtRefdBy.Size = new System.Drawing.Size(335, 26);
            this.txtRefdBy.TabIndex = 20;
            this.txtRefdBy.TextChanged += new System.EventHandler(this.txtRefdBy_TextChanged);
            this.txtRefdBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefdBy_KeyPress);
            // 
            // btnByReferralDetail
            // 
            this.btnByReferralDetail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnByReferralDetail.Location = new System.Drawing.Point(145, 152);
            this.btnByReferralDetail.Name = "btnByReferralDetail";
            this.btnByReferralDetail.Size = new System.Drawing.Size(174, 34);
            this.btnByReferralDetail.TabIndex = 23;
            this.btnByReferralDetail.Text = "ByReferral Detail List";
            this.btnByReferralDetail.UseVisualStyleBackColor = true;
            this.btnByReferralDetail.Click += new System.EventHandler(this.btnByReferralDetail_Click);
            // 
            // btnOpd
            // 
            this.btnOpd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpd.Location = new System.Drawing.Point(145, 203);
            this.btnOpd.Name = "btnOpd";
            this.btnOpd.Size = new System.Drawing.Size(174, 34);
            this.btnOpd.TabIndex = 24;
            this.btnOpd.Text = "OPD Refd. List";
            this.btnOpd.UseVisualStyleBackColor = true;
            this.btnOpd.Click += new System.EventHandler(this.btnOpd_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(357, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 25;
            this.button1.Text = "IPD Refd. List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnIpd_Click);
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(54, 255);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(636, 385);
            this.ctlDoctorSearch.TabIndex = 22;
            this.ctlDoctorSearch.Visible = false;
            // 
            // frmReferredCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 418);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpd);
            this.Controls.Add(this.btnByReferralDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRefdBy);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.MinimizeBox = false;
            this.Name = "frmReferredCases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referred Cases";
            this.Load += new System.EventHandler(this.frmReferredCases_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefdBy;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.Button btnByReferralDetail;
        private System.Windows.Forms.Button btnOpd;
        private System.Windows.Forms.Button button1;
    }
}