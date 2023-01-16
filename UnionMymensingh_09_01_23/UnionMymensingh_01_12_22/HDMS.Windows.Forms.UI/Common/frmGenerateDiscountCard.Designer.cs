namespace HDMS.Windows.Forms.UI.Common
{
    partial class frmGenerateDiscountCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerateDiscountCard));
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtConsultant = new System.Windows.Forms.TextBox();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalCard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.expDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCardUnused = new System.Windows.Forms.Label();
            this.lblCardUsed = new System.Windows.Forms.Label();
            this.lblCardIssued = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCardLabel = new System.Windows.Forms.Label();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvUxList = new System.Windows.Forms.DataGridView();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUxList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(95, 51);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(123, 20);
            this.lblRefBy.TabIndex = 7;
            this.lblRefBy.Text = "Select Consultant";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsultant
            // 
            this.txtConsultant.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsultant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultant.Location = new System.Drawing.Point(219, 51);
            this.txtConsultant.Name = "txtConsultant";
            this.txtConsultant.Size = new System.Drawing.Size(363, 29);
            this.txtConsultant.TabIndex = 8;
            this.txtConsultant.TextChanged += new System.EventHandler(this.txtConsultant_TextChanged);
            this.txtConsultant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsultant_KeyPress);
            // 
            // cmbCardType
            // 
            this.cmbCardType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Location = new System.Drawing.Point(219, 97);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(195, 29);
            this.cmbCardType.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Card Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalCard
            // 
            this.txtTotalCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCard.Location = new System.Drawing.Point(219, 142);
            this.txtTotalCard.Name = "txtTotalCard";
            this.txtTotalCard.Size = new System.Drawing.Size(132, 29);
            this.txtTotalCard.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total Card";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(219, 232);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 34);
            this.btnGenerate.TabIndex = 54;
            this.btnGenerate.Text = "Generate Card";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // expDate
            // 
            this.expDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expDate.Location = new System.Drawing.Point(219, 187);
            this.expDate.Name = "expDate";
            this.expDate.Size = new System.Drawing.Size(132, 29);
            this.expDate.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Total Card Issued : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Total Card Used : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(187, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 58;
            this.label5.Text = "Card Remain Un-used : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCardUnused
            // 
            this.lblCardUnused.AutoSize = true;
            this.lblCardUnused.BackColor = System.Drawing.Color.Transparent;
            this.lblCardUnused.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardUnused.Location = new System.Drawing.Point(357, 374);
            this.lblCardUnused.Name = "lblCardUnused";
            this.lblCardUnused.Size = new System.Drawing.Size(0, 20);
            this.lblCardUnused.TabIndex = 61;
            this.lblCardUnused.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardUsed
            // 
            this.lblCardUsed.AutoSize = true;
            this.lblCardUsed.BackColor = System.Drawing.Color.Transparent;
            this.lblCardUsed.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardUsed.Location = new System.Drawing.Point(357, 339);
            this.lblCardUsed.Name = "lblCardUsed";
            this.lblCardUsed.Size = new System.Drawing.Size(0, 20);
            this.lblCardUsed.TabIndex = 60;
            this.lblCardUsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardIssued
            // 
            this.lblCardIssued.AutoSize = true;
            this.lblCardIssued.BackColor = System.Drawing.Color.Transparent;
            this.lblCardIssued.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardIssued.Location = new System.Drawing.Point(357, 307);
            this.lblCardIssued.Name = "lblCardIssued";
            this.lblCardIssued.Size = new System.Drawing.Size(0, 20);
            this.lblCardIssued.TabIndex = 59;
            this.lblCardIssued.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(215, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Card Label Top: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCardLabel
            // 
            this.lblCardLabel.AutoSize = true;
            this.lblCardLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblCardLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardLabel.Location = new System.Drawing.Point(337, 18);
            this.lblCardLabel.Name = "lblCardLabel";
            this.lblCardLabel.Size = new System.Drawing.Size(0, 20);
            this.lblCardLabel.TabIndex = 63;
            this.lblCardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(-169, 165);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(602, 576);
            this.ctlDoctorSearch.TabIndex = 9;
            this.ctlDoctorSearch.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(357, 232);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 34);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(132, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Expire Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(661, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 28);
            this.btnRefresh.TabIndex = 67;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvUxList
            // 
            this.dgvUxList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUxList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNo,
            this.Column2});
            this.dgvUxList.Location = new System.Drawing.Point(661, 44);
            this.dgvUxList.Name = "dgvUxList";
            this.dgvUxList.Size = new System.Drawing.Size(571, 552);
            this.dgvUxList.TabIndex = 66;
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "SrlNo";
            this.BillNo.Name = "BillNo";
            this.BillNo.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PatientName";
            this.Column2.HeaderText = "Consultant Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 550;
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(819, 13);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 27);
            this.dtp1.TabIndex = 68;
            // 
            // dtp2
            // 
            this.dtp2.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(966, 14);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(110, 27);
            this.dtp2.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(770, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 70;
            this.label8.Text = "From";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(935, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 71;
            this.label9.Text = "To";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGenerateDiscountCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 608);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUxList);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCardLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCardUnused);
            this.Controls.Add(this.lblCardUsed);
            this.Controls.Add(this.lblCardIssued);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expDate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtConsultant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerateDiscountCard";
            this.Text = "Generate Discount Card";
            this.Load += new System.EventHandler(this.frmGenerateDiscountCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUxList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtConsultant;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker expDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCardUnused;
        private System.Windows.Forms.Label lblCardUsed;
        private System.Windows.Forms.Label lblCardIssued;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCardLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvUxList;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}