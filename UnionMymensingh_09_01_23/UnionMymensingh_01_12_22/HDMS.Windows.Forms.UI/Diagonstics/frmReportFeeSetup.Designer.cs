
namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmReportFeeSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsultant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReportType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefaultFee = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSingleConsultant = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSingleTestName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSingleFee = new System.Windows.Forms.TextBox();
            this.btnSingleSave = new System.Windows.Forms.Button();
            this.btnSngleClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSingleReportType = new System.Windows.Forms.TextBox();
            this.ctrlReportTypeSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportTypeSearchControl();
            this.ctrlReportConsultantSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportConsultantSearchControl();
            this.ctrlReportConsultantSearchControlSingle = new HDMS.Windows.Forms.UI.Controls.ReportConsultantSearchControl();
            this.ctrlreportTypeSearchControlSingle = new HDMS.Windows.Forms.UI.Controls.ReportTypeSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Consultant :";
            // 
            // txtConsultant
            // 
            this.txtConsultant.Location = new System.Drawing.Point(181, 62);
            this.txtConsultant.Name = "txtConsultant";
            this.txtConsultant.Size = new System.Drawing.Size(314, 26);
            this.txtConsultant.TabIndex = 1;
            this.txtConsultant.TextChanged += new System.EventHandler(this.txtConsultant_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Report Type :";
            // 
            // txtReportType
            // 
            this.txtReportType.Location = new System.Drawing.Point(181, 115);
            this.txtReportType.Name = "txtReportType";
            this.txtReportType.Size = new System.Drawing.Size(314, 26);
            this.txtReportType.TabIndex = 1;
            this.txtReportType.TextChanged += new System.EventHandler(this.txtReportType_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enter Default Fee  (%)";
            // 
            // txtDefaultFee
            // 
            this.txtDefaultFee.Location = new System.Drawing.Point(181, 168);
            this.txtDefaultFee.Name = "txtDefaultFee";
            this.txtDefaultFee.Size = new System.Drawing.Size(314, 26);
            this.txtDefaultFee.TabIndex = 1;
            this.txtDefaultFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDefaultFee_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(181, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(355, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 45);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgTests
            // 
            this.dgTests.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestName,
            this.Fee,
            this.TestFree});
            this.dgTests.Location = new System.Drawing.Point(501, 12);
            this.dgTests.Name = "dgTests";
            this.dgTests.Size = new System.Drawing.Size(602, 645);
            this.dgTests.TabIndex = 3;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 350;
            // 
            // Fee
            // 
            this.Fee.HeaderText = "Fee";
            this.Fee.Name = "Fee";
            // 
            // TestFree
            // 
            this.TestFree.HeaderText = "Test Rate";
            this.TestFree.Name = "TestFree";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Select Consultant :";
            this.label4.Visible = false;
            // 
            // txtSingleConsultant
            // 
            this.txtSingleConsultant.Location = new System.Drawing.Point(181, 321);
            this.txtSingleConsultant.Name = "txtSingleConsultant";
            this.txtSingleConsultant.Size = new System.Drawing.Size(314, 26);
            this.txtSingleConsultant.TabIndex = 1;
            this.txtSingleConsultant.Visible = false;
            this.txtSingleConsultant.TextChanged += new System.EventHandler(this.txtSingleConsultant_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Test Name :";
            this.label5.Visible = false;
            // 
            // txtSingleTestName
            // 
            this.txtSingleTestName.Location = new System.Drawing.Point(181, 392);
            this.txtSingleTestName.Name = "txtSingleTestName";
            this.txtSingleTestName.Size = new System.Drawing.Size(314, 26);
            this.txtSingleTestName.TabIndex = 1;
            this.txtSingleTestName.Visible = false;
            this.txtSingleTestName.TextChanged += new System.EventHandler(this.txtSingleTestName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fee  (%) :";
            this.label6.Visible = false;
            // 
            // txtSingleFee
            // 
            this.txtSingleFee.Location = new System.Drawing.Point(181, 427);
            this.txtSingleFee.Name = "txtSingleFee";
            this.txtSingleFee.Size = new System.Drawing.Size(314, 26);
            this.txtSingleFee.TabIndex = 1;
            this.txtSingleFee.Visible = false;
            // 
            // btnSingleSave
            // 
            this.btnSingleSave.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSingleSave.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSingleSave.Location = new System.Drawing.Point(181, 476);
            this.btnSingleSave.Name = "btnSingleSave";
            this.btnSingleSave.Size = new System.Drawing.Size(150, 45);
            this.btnSingleSave.TabIndex = 2;
            this.btnSingleSave.Text = "Save";
            this.btnSingleSave.UseVisualStyleBackColor = false;
            this.btnSingleSave.Visible = false;
            // 
            // btnSngleClose
            // 
            this.btnSngleClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSngleClose.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSngleClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSngleClose.Location = new System.Drawing.Point(355, 476);
            this.btnSngleClose.Name = "btnSngleClose";
            this.btnSngleClose.Size = new System.Drawing.Size(140, 45);
            this.btnSngleClose.TabIndex = 2;
            this.btnSngleClose.Text = "Close";
            this.btnSngleClose.UseVisualStyleBackColor = false;
            this.btnSngleClose.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(452, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Single Consultant Fee Setup By Test Name ";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Select Report Type :";
            this.label8.Visible = false;
            // 
            // txtSingleReportType
            // 
            this.txtSingleReportType.Location = new System.Drawing.Point(181, 358);
            this.txtSingleReportType.Name = "txtSingleReportType";
            this.txtSingleReportType.Size = new System.Drawing.Size(314, 26);
            this.txtSingleReportType.TabIndex = 1;
            this.txtSingleReportType.Visible = false;
            this.txtSingleReportType.TextChanged += new System.EventHandler(this.txtSingleReportType_TextChanged);
            // 
            // ctrlReportTypeSearchControl
            // 
            this.ctrlReportTypeSearchControl.Location = new System.Drawing.Point(605, 343);
            this.ctrlReportTypeSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlReportTypeSearchControl.Name = "ctrlReportTypeSearchControl";
            this.ctrlReportTypeSearchControl.Size = new System.Drawing.Size(411, 335);
            this.ctrlReportTypeSearchControl.TabIndex = 5;
            this.ctrlReportTypeSearchControl.Visible = false;
            this.ctrlReportTypeSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportType>.SearchEscapeEventHandler(this.ctrlReportTypeSearchControl_SearchEsacaped);
            // 
            // ctrlReportConsultantSearchControl
            // 
            this.ctrlReportConsultantSearchControl.Location = new System.Drawing.Point(816, 246);
            this.ctrlReportConsultantSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlReportConsultantSearchControl.Name = "ctrlReportConsultantSearchControl";
            this.ctrlReportConsultantSearchControl.Size = new System.Drawing.Size(419, 389);
            this.ctrlReportConsultantSearchControl.TabIndex = 4;
            this.ctrlReportConsultantSearchControl.Visible = false;
            this.ctrlReportConsultantSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.SearchEscapeEventHandler(this.ctrlReportConsultantSearchControl_SearchEsacaped);
            // 
            // ctrlReportConsultantSearchControlSingle
            // 
            this.ctrlReportConsultantSearchControlSingle.Location = new System.Drawing.Point(872, 291);
            this.ctrlReportConsultantSearchControlSingle.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlReportConsultantSearchControlSingle.Name = "ctrlReportConsultantSearchControlSingle";
            this.ctrlReportConsultantSearchControlSingle.Size = new System.Drawing.Size(401, 650);
            this.ctrlReportConsultantSearchControlSingle.TabIndex = 6;
            this.ctrlReportConsultantSearchControlSingle.ItemSelected += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.ItemSelectedEventHandler(this.ctrlReportConsultantSearchControlSingle_ItemSelected);
            // 
            // ctrlreportTypeSearchControlSingle
            // 
            this.ctrlreportTypeSearchControlSingle.Location = new System.Drawing.Point(528, 460);
            this.ctrlreportTypeSearchControlSingle.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlreportTypeSearchControlSingle.Name = "ctrlreportTypeSearchControlSingle";
            this.ctrlreportTypeSearchControlSingle.Size = new System.Drawing.Size(575, 650);
            this.ctrlreportTypeSearchControlSingle.TabIndex = 7;
            this.ctrlreportTypeSearchControlSingle.ItemSelected += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportType>.ItemSelectedEventHandler(this.ctrlreportTypeSearchControlSingle_ItemSelected);
            // 
            // frmReportFeeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1356, 732);
            this.Controls.Add(this.ctrlreportTypeSearchControlSingle);
            this.Controls.Add(this.ctrlReportConsultantSearchControlSingle);
            this.Controls.Add(this.ctrlReportTypeSearchControl);
            this.Controls.Add(this.ctrlReportConsultantSearchControl);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.btnSngleClose);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSingleSave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSingleFee);
            this.Controls.Add(this.txtDefaultFee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSingleTestName);
            this.Controls.Add(this.txtSingleReportType);
            this.Controls.Add(this.txtReportType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSingleConsultant);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConsultant);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReportFeeSetup";
            this.Text = "Report Fee Setup";
            this.Load += new System.EventHandler(this.frmReportFeeSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConsultant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReportType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefaultFee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgTests;
        private Controls.ReportConsultantSearchControl ctrlReportConsultantSearchControl;
        private Controls.ReportTypeSearchControl ctrlReportTypeSearchControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestFree;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSingleConsultant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSingleTestName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSingleFee;
        private System.Windows.Forms.Button btnSingleSave;
        private System.Windows.Forms.Button btnSngleClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSingleReportType;
        private Controls.ReportConsultantSearchControl ctrlReportConsultantSearchControlSingle;
        private Controls.ReportTypeSearchControl ctrlreportTypeSearchControlSingle;
    }
}