
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmPathologyConsultantReportingFee
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.crtGradeintBackground = new HDMS.Windows.Forms.UI.DesingControl.GradientBackground();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnShowConsultantWaiseReport = new System.Windows.Forms.Button();
            this.btnSaveConsultancy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlReportConsultantSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportConsultantSearchControl();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConsultant = new System.Windows.Forms.Label();
            this.txtConsultantSerarch = new System.Windows.Forms.TextBox();
            this.btnShow = new MaterialSkin.Controls.MaterialButton();
            this.dgPathologisFee = new System.Windows.Forms.DataGridView();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtGradeintBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPathologisFee)).BeginInit();
            this.SuspendLayout();
            // 
            // crtGradeintBackground
            // 
            this.crtGradeintBackground.Angle = 90F;
            this.crtGradeintBackground.BottomColor = System.Drawing.Color.Teal;
            this.crtGradeintBackground.Controls.Add(this.label4);
            this.crtGradeintBackground.Controls.Add(this.textBox2);
            this.crtGradeintBackground.Controls.Add(this.lblTotal);
            this.crtGradeintBackground.Controls.Add(this.label5);
            this.crtGradeintBackground.Controls.Add(this.label3);
            this.crtGradeintBackground.Controls.Add(this.textBox1);
            this.crtGradeintBackground.Controls.Add(this.btnShowConsultantWaiseReport);
            this.crtGradeintBackground.Controls.Add(this.btnSaveConsultancy);
            this.crtGradeintBackground.Controls.Add(this.button1);
            this.crtGradeintBackground.Controls.Add(this.ctrlReportConsultantSearchControl);
            this.crtGradeintBackground.Controls.Add(this.dtpTo);
            this.crtGradeintBackground.Controls.Add(this.dtpFrom);
            this.crtGradeintBackground.Controls.Add(this.label2);
            this.crtGradeintBackground.Controls.Add(this.label1);
            this.crtGradeintBackground.Controls.Add(this.lblConsultant);
            this.crtGradeintBackground.Controls.Add(this.txtConsultantSerarch);
            this.crtGradeintBackground.Controls.Add(this.btnShow);
            this.crtGradeintBackground.Controls.Add(this.dgPathologisFee);
            this.crtGradeintBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtGradeintBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crtGradeintBackground.Location = new System.Drawing.Point(0, 0);
            this.crtGradeintBackground.Name = "crtGradeintBackground";
            this.crtGradeintBackground.Size = new System.Drawing.Size(1336, 799);
            this.crtGradeintBackground.TabIndex = 0;
            this.crtGradeintBackground.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.crtGradeintBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.crtGradeintBackground_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "pluse :";
            this.label4.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(525, 674);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(131, 672);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(25, 24);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 672);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 673);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Minus :";
            this.label3.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(312, 674);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 23);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // btnShowConsultantWaiseReport
            // 
            this.btnShowConsultantWaiseReport.Location = new System.Drawing.Point(842, 673);
            this.btnShowConsultantWaiseReport.Name = "btnShowConsultantWaiseReport";
            this.btnShowConsultantWaiseReport.Size = new System.Drawing.Size(174, 37);
            this.btnShowConsultantWaiseReport.TabIndex = 7;
            this.btnShowConsultantWaiseReport.Text = "Pathologis Leger";
            this.btnShowConsultantWaiseReport.UseVisualStyleBackColor = true;
            this.btnShowConsultantWaiseReport.Click += new System.EventHandler(this.btnShowConsultantWaiseReport_Click);
            // 
            // btnSaveConsultancy
            // 
            this.btnSaveConsultancy.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveConsultancy.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnSaveConsultancy.FlatAppearance.BorderSize = 0;
            this.btnSaveConsultancy.Location = new System.Drawing.Point(720, 672);
            this.btnSaveConsultancy.Name = "btnSaveConsultancy";
            this.btnSaveConsultancy.Size = new System.Drawing.Size(116, 38);
            this.btnSaveConsultancy.TabIndex = 6;
            this.btnSaveConsultancy.Text = "Save";
            this.btnSaveConsultancy.UseVisualStyleBackColor = false;
            this.btnSaveConsultancy.Click += new System.EventHandler(this.btnSaveConsultancy_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1033, 672);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close Me";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlReportConsultantSearchControl
            // 
            this.ctrlReportConsultantSearchControl.Location = new System.Drawing.Point(-33, 706);
            this.ctrlReportConsultantSearchControl.Name = "ctrlReportConsultantSearchControl";
            this.ctrlReportConsultantSearchControl.Size = new System.Drawing.Size(548, 574);
            this.ctrlReportConsultantSearchControl.TabIndex = 5;
            this.ctrlReportConsultantSearchControl.Visible = false;
            this.ctrlReportConsultantSearchControl.ItemSelected += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.ItemSelectedEventHandler(this.ctrlReportConsultantSearchControl_ItemSelected);
            this.ctrlReportConsultantSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.SearchEscapeEventHandler(this.ctrlReportConsultantSearchControl_SearchEsacaped);
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(835, 49);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(135, 26);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(598, 53);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(140, 26);
            this.dtpFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(750, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date From";
            // 
            // lblConsultant
            // 
            this.lblConsultant.AutoSize = true;
            this.lblConsultant.BackColor = System.Drawing.Color.Transparent;
            this.lblConsultant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultant.Location = new System.Drawing.Point(61, 54);
            this.lblConsultant.Name = "lblConsultant";
            this.lblConsultant.Size = new System.Drawing.Size(165, 24);
            this.lblConsultant.TabIndex = 3;
            this.lblConsultant.Text = "Select Consultant :";
            // 
            // txtConsultantSerarch
            // 
            this.txtConsultantSerarch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsultantSerarch.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultantSerarch.Location = new System.Drawing.Point(225, 56);
            this.txtConsultantSerarch.Name = "txtConsultantSerarch";
            this.txtConsultantSerarch.Size = new System.Drawing.Size(270, 23);
            this.txtConsultantSerarch.TabIndex = 2;
            this.txtConsultantSerarch.TextChanged += new System.EventHandler(this.txtConsultantSerarch_TextChanged);
            // 
            // btnShow
            // 
            this.btnShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShow.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnShow.Depth = 0;
            this.btnShow.DrawShadows = true;
            this.btnShow.HighEmphasis = true;
            this.btnShow.Icon = null;
            this.btnShow.Location = new System.Drawing.Point(1010, 43);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(64, 36);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShow.UseAccentColor = false;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgPathologisFee
            // 
            this.dgPathologisFee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPathologisFee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPathologisFee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId,
            this.Consultant,
            this.PatientName,
            this.Rete,
            this.TotalFee});
            this.dgPathologisFee.GridColor = System.Drawing.SystemColors.Window;
            this.dgPathologisFee.Location = new System.Drawing.Point(65, 94);
            this.dgPathologisFee.Name = "dgPathologisFee";
            this.dgPathologisFee.Size = new System.Drawing.Size(1087, 572);
            this.dgPathologisFee.TabIndex = 0;
            this.dgPathologisFee.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPathologisFee_CellEnter);
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "PatientId";
            this.PatientId.Name = "PatientId";
            // 
            // Consultant
            // 
            this.Consultant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Consultant.HeaderText = "Consultant ";
            this.Consultant.Name = "Consultant";
            // 
            // PatientName
            // 
            this.PatientName.HeaderText = "Patient Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.Width = 200;
            // 
            // Rete
            // 
            this.Rete.FillWeight = 150F;
            this.Rete.HeaderText = "Test Cost";
            this.Rete.Name = "Rete";
            this.Rete.Width = 130;
            // 
            // TotalFee
            // 
            this.TotalFee.HeaderText = "Total Fee";
            this.TotalFee.Name = "TotalFee";
            this.TotalFee.Width = 130;
            // 
            // frmPathologyConsultantReportingFee
            // 
            this.ClientSize = new System.Drawing.Size(1336, 799);
            this.Controls.Add(this.crtGradeintBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPathologyConsultantReportingFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPathologyConsultantReportingFee_Load);
            this.crtGradeintBackground.ResumeLayout(false);
            this.crtGradeintBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPathologisFee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DesingControl.GradientBackground crtGradeintBackground;
        private System.Windows.Forms.DataGridView dgPathologisFee;
        private MaterialSkin.Controls.MaterialButton btnShow;
        private System.Windows.Forms.Label lblConsultant;
        private System.Windows.Forms.TextBox txtConsultantSerarch;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.ReportConsultantSearchControl ctrlReportConsultantSearchControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowConsultantWaiseReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFee;
        private System.Windows.Forms.Button btnSaveConsultancy;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private Label label3;
        private TextBox textBox1;
        private Label lblTotal;
    }
}