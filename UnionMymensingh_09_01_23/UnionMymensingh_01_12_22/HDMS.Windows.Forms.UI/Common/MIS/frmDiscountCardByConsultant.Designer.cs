namespace HDMS.Windows.Forms.UI.Common.MIS
{
    partial class frmDiscountCardByConsultant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscountCardByConsultant));
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtConsultant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.btnUnUsedCardList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.SuspendLayout();
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(24, 30);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(123, 20);
            this.lblRefBy.TabIndex = 9;
            this.lblRefBy.Text = "Select Consultant";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsultant
            // 
            this.txtConsultant.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsultant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultant.Location = new System.Drawing.Point(148, 30);
            this.txtConsultant.Name = "txtConsultant";
            this.txtConsultant.Size = new System.Drawing.Size(363, 29);
            this.txtConsultant.TabIndex = 10;
            this.txtConsultant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultant_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Card Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCardType
            // 
            this.cmbCardType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Location = new System.Drawing.Point(148, 65);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(195, 29);
            this.cmbCardType.TabIndex = 12;
            // 
            // btnUnUsedCardList
            // 
            this.btnUnUsedCardList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnUsedCardList.Location = new System.Drawing.Point(148, 106);
            this.btnUnUsedCardList.Name = "btnUnUsedCardList";
            this.btnUnUsedCardList.Size = new System.Drawing.Size(154, 34);
            this.btnUnUsedCardList.TabIndex = 55;
            this.btnUnUsedCardList.Text = "Used Card List";
            this.btnUnUsedCardList.UseVisualStyleBackColor = true;
            this.btnUnUsedCardList.Click += new System.EventHandler(this.btnUnUsedCardList_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(323, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 34);
            this.button1.TabIndex = 56;
            this.button1.Text = "Un-Used Card List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(505, 106);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 34);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(71, 146);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(602, 368);
            this.ctlDoctorSearch.TabIndex = 14;
            this.ctlDoctorSearch.Visible = false;
            // 
            // frmDiscountCardByConsultant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 536);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUnUsedCardList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtConsultant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiscountCardByConsultant";
            this.Text = "Discount Card By Consultant";
            this.Load += new System.EventHandler(this.frmDiscountCardByConsultant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtConsultant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCardType;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.Button btnUnUsedCardList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
    }
}