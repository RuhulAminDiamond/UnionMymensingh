namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmSampleReportDeliverySchedule
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
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtptime = new System.Windows.Forms.DateTimePicker();
            this.radBiochem = new System.Windows.Forms.RadioButton();
            this.radImmu = new System.Windows.Forms.RadioButton();
            this.radCP = new System.Windows.Forms.RadioButton();
            this.radHaema = new System.Windows.Forms.RadioButton();
            this.radSero = new System.Windows.Forms.RadioButton();
            this.radMicro = new System.Windows.Forms.RadioButton();
            this.radStool = new System.Windows.Forms.RadioButton();
            this.radUrine = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgDeliveredReport = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintUndeliveredList = new System.Windows.Forms.Button();
            this.btnPrintDeliveredList = new System.Windows.Forms.Button();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radIPD = new System.Windows.Forms.RadioButton();
            this.radOPD = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveredReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(100, 80);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(122, 26);
            this.dtpEntry.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 148;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 150;
            this.label2.Text = "Time";
            // 
            // dtptime
            // 
            this.dtptime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtptime.Location = new System.Drawing.Point(285, 81);
            this.dtptime.Name = "dtptime";
            this.dtptime.Size = new System.Drawing.Size(113, 26);
            this.dtptime.TabIndex = 151;
            // 
            // radBiochem
            // 
            this.radBiochem.AutoSize = true;
            this.radBiochem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBiochem.Location = new System.Drawing.Point(99, 12);
            this.radBiochem.Name = "radBiochem";
            this.radBiochem.Size = new System.Drawing.Size(157, 24);
            this.radBiochem.TabIndex = 152;
            this.radBiochem.TabStop = true;
            this.radBiochem.Tag = "2";
            this.radBiochem.Text = "Biochemical Report";
            this.radBiochem.UseVisualStyleBackColor = true;
            // 
            // radImmu
            // 
            this.radImmu.AutoSize = true;
            this.radImmu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radImmu.Location = new System.Drawing.Point(99, 42);
            this.radImmu.Name = "radImmu";
            this.radImmu.Size = new System.Drawing.Size(160, 24);
            this.radImmu.TabIndex = 153;
            this.radImmu.TabStop = true;
            this.radImmu.Tag = "10";
            this.radImmu.Text = "Immunology Report";
            this.radImmu.UseVisualStyleBackColor = true;
            // 
            // radCP
            // 
            this.radCP.AutoSize = true;
            this.radCP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCP.Location = new System.Drawing.Point(312, 42);
            this.radCP.Name = "radCP";
            this.radCP.Size = new System.Drawing.Size(194, 24);
            this.radCP.TabIndex = 154;
            this.radCP.TabStop = true;
            this.radCP.Tag = "8";
            this.radCP.Text = "Clinical Pathology Report";
            this.radCP.UseVisualStyleBackColor = true;
            // 
            // radHaema
            // 
            this.radHaema.AutoSize = true;
            this.radHaema.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHaema.Location = new System.Drawing.Point(312, 12);
            this.radHaema.Name = "radHaema";
            this.radHaema.Size = new System.Drawing.Size(167, 24);
            this.radHaema.TabIndex = 155;
            this.radHaema.TabStop = true;
            this.radHaema.Tag = "5";
            this.radHaema.Text = "Haematology Report";
            this.radHaema.UseVisualStyleBackColor = true;
            // 
            // radSero
            // 
            this.radSero.AutoSize = true;
            this.radSero.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSero.Location = new System.Drawing.Point(572, 12);
            this.radSero.Name = "radSero";
            this.radSero.Size = new System.Drawing.Size(135, 24);
            this.radSero.TabIndex = 156;
            this.radSero.TabStop = true;
            this.radSero.Tag = "11";
            this.radSero.Text = "Serology Report";
            this.radSero.UseVisualStyleBackColor = true;
            // 
            // radMicro
            // 
            this.radMicro.AutoSize = true;
            this.radMicro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMicro.Location = new System.Drawing.Point(572, 42);
            this.radMicro.Name = "radMicro";
            this.radMicro.Size = new System.Drawing.Size(165, 24);
            this.radMicro.TabIndex = 157;
            this.radMicro.TabStop = true;
            this.radMicro.Tag = "9";
            this.radMicro.Text = "Microbiology Report";
            this.radMicro.UseVisualStyleBackColor = true;
            // 
            // radStool
            // 
            this.radStool.AutoSize = true;
            this.radStool.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStool.Location = new System.Drawing.Point(794, 42);
            this.radStool.Name = "radStool";
            this.radStool.Size = new System.Drawing.Size(197, 24);
            this.radStool.TabIndex = 159;
            this.radStool.TabStop = true;
            this.radStool.Tag = "12";
            this.radStool.Text = "Stool Examination Report";
            this.radStool.UseVisualStyleBackColor = true;
            // 
            // radUrine
            // 
            this.radUrine.AutoSize = true;
            this.radUrine.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUrine.Location = new System.Drawing.Point(794, 12);
            this.radUrine.Name = "radUrine";
            this.radUrine.Size = new System.Drawing.Size(197, 24);
            this.radUrine.TabIndex = 158;
            this.radUrine.TabStop = true;
            this.radUrine.Tag = "14";
            this.radUrine.Text = "Urine Examination Report";
            this.radUrine.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(617, 80);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(101, 30);
            this.btnShow.TabIndex = 160;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 18);
            this.label3.TabIndex = 163;
            this.label3.Text = "Printed or Delivered Reports";
            // 
            // dgDeliveredReport
            // 
            this.dgDeliveredReport.AllowUserToAddRows = false;
            this.dgDeliveredReport.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgDeliveredReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeliveredReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ReportId2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgDeliveredReport.Location = new System.Drawing.Point(100, 431);
            this.dgDeliveredReport.Name = "dgDeliveredReport";
            this.dgDeliveredReport.RowTemplate.Height = 35;
            this.dgDeliveredReport.Size = new System.Drawing.Size(1009, 267);
            this.dgDeliveredReport.TabIndex = 162;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Bill No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // ReportId2
            // 
            this.ReportId2.HeaderText = "Report ID";
            this.ReportId2.Name = "ReportId2";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Test Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Entry Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Entry Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "D.Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "D.Time";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Status";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 140;
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId,
            this.ReportId,
            this.TestName,
            this.EntryDate,
            this.ETime,
            this.DDate,
            this.DTime,
            this.Status});
            this.dgTests.Location = new System.Drawing.Point(100, 115);
            this.dgTests.Name = "dgTests";
            this.dgTests.RowTemplate.Height = 35;
            this.dgTests.Size = new System.Drawing.Size(1009, 279);
            this.dgTests.TabIndex = 161;
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "Bill No";
            this.PatientId.Name = "PatientId";
            this.PatientId.Width = 150;
            // 
            // ReportId
            // 
            this.ReportId.HeaderText = "Report Id";
            this.ReportId.Name = "ReportId";
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 180;
            // 
            // EntryDate
            // 
            this.EntryDate.HeaderText = "Entry Date";
            this.EntryDate.Name = "EntryDate";
            // 
            // ETime
            // 
            this.ETime.HeaderText = "Entry Time";
            this.ETime.Name = "ETime";
            // 
            // DDate
            // 
            this.DDate.HeaderText = "D.Date";
            this.DDate.Name = "DDate";
            // 
            // DTime
            // 
            this.DTime.HeaderText = "D.Time";
            this.DTime.Name = "DTime";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 140;
            // 
            // btnPrintUndeliveredList
            // 
            this.btnPrintUndeliveredList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintUndeliveredList.Location = new System.Drawing.Point(912, 83);
            this.btnPrintUndeliveredList.Name = "btnPrintUndeliveredList";
            this.btnPrintUndeliveredList.Size = new System.Drawing.Size(197, 27);
            this.btnPrintUndeliveredList.TabIndex = 164;
            this.btnPrintUndeliveredList.Text = "Print Undelivered List";
            this.btnPrintUndeliveredList.UseVisualStyleBackColor = true;
            // 
            // btnPrintDeliveredList
            // 
            this.btnPrintDeliveredList.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDeliveredList.Location = new System.Drawing.Point(955, 401);
            this.btnPrintDeliveredList.Name = "btnPrintDeliveredList";
            this.btnPrintDeliveredList.Size = new System.Drawing.Size(154, 27);
            this.btnPrintDeliveredList.TabIndex = 165;
            this.btnPrintDeliveredList.Text = "Print Delivered List";
            this.btnPrintDeliveredList.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(9, 9);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(43, 22);
            this.radAll.TabIndex = 168;
            this.radAll.TabStop = true;
            this.radAll.Tag = "All";
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // radIPD
            // 
            this.radIPD.AutoSize = true;
            this.radIPD.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIPD.Location = new System.Drawing.Point(68, 9);
            this.radIPD.Name = "radIPD";
            this.radIPD.Size = new System.Drawing.Size(47, 22);
            this.radIPD.TabIndex = 166;
            this.radIPD.TabStop = true;
            this.radIPD.Tag = "IPD";
            this.radIPD.Text = "IPD";
            this.radIPD.UseVisualStyleBackColor = true;
            // 
            // radOPD
            // 
            this.radOPD.AutoSize = true;
            this.radOPD.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOPD.Location = new System.Drawing.Point(130, 9);
            this.radOPD.Name = "radOPD";
            this.radOPD.Size = new System.Drawing.Size(53, 22);
            this.radOPD.TabIndex = 167;
            this.radOPD.TabStop = true;
            this.radOPD.Tag = "OPD";
            this.radOPD.Text = "OPD";
            this.radOPD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radOPD);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Controls.Add(this.radIPD);
            this.groupBox1.Location = new System.Drawing.Point(405, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 35);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            // 
            // frmSampleReportDeliverySchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 749);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrintDeliveredList);
            this.Controls.Add(this.btnPrintUndeliveredList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgDeliveredReport);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.radStool);
            this.Controls.Add(this.radUrine);
            this.Controls.Add(this.radMicro);
            this.Controls.Add(this.radSero);
            this.Controls.Add(this.radHaema);
            this.Controls.Add(this.radCP);
            this.Controls.Add(this.radImmu);
            this.Controls.Add(this.radBiochem);
            this.Controls.Add(this.dtptime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEntry);
            this.Name = "frmSampleReportDeliverySchedule";
            this.Text = "Report Delivery Schedule";
            this.Load += new System.EventHandler(this.frmSampleReportDeliverySchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeliveredReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtptime;
        private System.Windows.Forms.RadioButton radBiochem;
        private System.Windows.Forms.RadioButton radImmu;
        private System.Windows.Forms.RadioButton radCP;
        private System.Windows.Forms.RadioButton radHaema;
        private System.Windows.Forms.RadioButton radSero;
        private System.Windows.Forms.RadioButton radMicro;
        private System.Windows.Forms.RadioButton radStool;
        private System.Windows.Forms.RadioButton radUrine;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgDeliveredReport;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnPrintUndeliveredList;
        private System.Windows.Forms.Button btnPrintDeliveredList;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radIPD;
        private System.Windows.Forms.RadioButton radOPD;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}