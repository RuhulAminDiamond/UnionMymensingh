namespace HDMS.Windows.Forms.UI.Accounts
{
    partial class frmCashBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashBook));
            this.cmdShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.chkWithoutCheck = new System.Windows.Forms.CheckBox();
            this.chkWithCheck = new System.Windows.Forms.CheckBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbBusinessUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowByDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(143, 203);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(125, 34);
            this.cmdShow.TabIndex = 24;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(341, 106);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 21;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(143, 106);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 20;
            // 
            // chkWithoutCheck
            // 
            this.chkWithoutCheck.AutoSize = true;
            this.chkWithoutCheck.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWithoutCheck.Location = new System.Drawing.Point(143, 157);
            this.chkWithoutCheck.Name = "chkWithoutCheck";
            this.chkWithoutCheck.Size = new System.Drawing.Size(135, 24);
            this.chkWithoutCheck.TabIndex = 25;
            this.chkWithoutCheck.Tag = "Cash";
            this.chkWithoutCheck.Text = "Without Cheque";
            this.chkWithoutCheck.UseVisualStyleBackColor = true;
            this.chkWithoutCheck.CheckedChanged += new System.EventHandler(this.chkWithoutCheck_CheckedChanged);
            // 
            // chkWithCheck
            // 
            this.chkWithCheck.AutoSize = true;
            this.chkWithCheck.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWithCheck.Location = new System.Drawing.Point(285, 157);
            this.chkWithCheck.Name = "chkWithCheck";
            this.chkWithCheck.Size = new System.Drawing.Size(113, 24);
            this.chkWithCheck.TabIndex = 26;
            this.chkWithCheck.Tag = "Check";
            this.chkWithCheck.Text = "With Cheque";
            this.chkWithCheck.UseVisualStyleBackColor = true;
            this.chkWithCheck.CheckedChanged += new System.EventHandler(this.chkWithCheck_CheckedChanged);
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
            this.cmbUser.Location = new System.Drawing.Point(144, 33);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(164, 29);
            this.cmbUser.TabIndex = 27;
            this.cmbUser.ValueMember = "Id";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(55, 33);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(82, 20);
            this.lblGender.TabIndex = 28;
            this.lblGender.Text = "Select User";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBusinessUnit
            // 
            this.cmbBusinessUnit.DisplayMember = "Name";
            this.cmbBusinessUnit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbBusinessUnit.FormattingEnabled = true;
            this.cmbBusinessUnit.Items.AddRange(new object[] {
            "J",
            "D",
            "C",
            "Cash"});
            this.cmbBusinessUnit.Location = new System.Drawing.Point(144, 68);
            this.cmbBusinessUnit.Name = "cmbBusinessUnit";
            this.cmbBusinessUnit.Size = new System.Drawing.Size(164, 29);
            this.cmbBusinessUnit.TabIndex = 29;
            this.cmbBusinessUnit.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Business Unit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnShowByDate
            // 
            this.btnShowByDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowByDate.Location = new System.Drawing.Point(285, 203);
            this.btnShowByDate.Name = "btnShowByDate";
            this.btnShowByDate.Size = new System.Drawing.Size(125, 34);
            this.btnShowByDate.TabIndex = 31;
            this.btnShowByDate.Text = "Show By Date";
            this.btnShowByDate.UseVisualStyleBackColor = true;
            this.btnShowByDate.Click += new System.EventHandler(this.btnShowByDate_Click);
            // 
            // frmCashBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 284);
            this.Controls.Add(this.btnShowByDate);
            this.Controls.Add(this.cmbBusinessUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.chkWithCheck);
            this.Controls.Add(this.chkWithoutCheck);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCashBook";
            this.Text = "Cash Book";
            this.Load += new System.EventHandler(this.frmCashBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.CheckBox chkWithoutCheck;
        private System.Windows.Forms.CheckBox chkWithCheck;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbBusinessUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowByDate;
    }
}