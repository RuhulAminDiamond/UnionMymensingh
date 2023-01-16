
namespace HDMS.Windows.Forms.UI.Accounts.MIS
{
    partial class frmSingleMediaPaymentByPatientId
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTest = new System.Windows.Forms.DataGridView();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.PatientId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegularDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTest
            // 
            this.dgTest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId,
            this.PatientName,
            this.TestName,
            this.Commission});
            this.dgTest.EnableHeadersVisualStyles = false;
            this.dgTest.Location = new System.Drawing.Point(58, 13);
            this.dgTest.Name = "dgTest";
            this.dgTest.Size = new System.Drawing.Size(990, 269);
            this.dgTest.TabIndex = 1;
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "Patient Id";
            this.PatientId.Name = "PatientId";
            // 
            // PatientName
            // 
            this.PatientName.HeaderText = "Patient Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.Width = 210;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 300;
            // 
            // Commission
            // 
            this.Commission.HeaderText = "Commission";
            this.Commission.Name = "Commission";
            this.Commission.Width = 150;
            // 
            // dgPatient
            // 
            this.dgPatient.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId2,
            this.PatientName2,
            this.RegularDiscount,
            this.DueDiscount,
            this.TotalDiscount});
            this.dgPatient.EnableHeadersVisualStyles = false;
            this.dgPatient.Location = new System.Drawing.Point(58, 289);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(990, 269);
            this.dgPatient.TabIndex = 2;
            // 
            // PatientId2
            // 
            this.PatientId2.HeaderText = "Patient Id";
            this.PatientId2.Name = "PatientId2";
            // 
            // PatientName2
            // 
            this.PatientName2.HeaderText = "Patient Name";
            this.PatientName2.Name = "PatientName2";
            this.PatientName2.Width = 200;
            // 
            // RegularDiscount
            // 
            this.RegularDiscount.HeaderText = "Regular Discount";
            this.RegularDiscount.Name = "RegularDiscount";
            this.RegularDiscount.Width = 160;
            // 
            // DueDiscount
            // 
            this.DueDiscount.HeaderText = "Due Discount";
            this.DueDiscount.Name = "DueDiscount";
            this.DueDiscount.Width = 150;
            // 
            // TotalDiscount
            // 
            this.TotalDiscount.HeaderText = "Total Discount";
            this.TotalDiscount.Name = "TotalDiscount";
            this.TotalDiscount.Width = 150;
            // 
            // frmSingleMediaPaymentByPatientId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 702);
            this.Controls.Add(this.dgPatient);
            this.Controls.Add(this.dgTest);
            this.Name = "frmSingleMediaPaymentByPatientId";
            this.Text = "frmSingleMediaPaymentByPatientId";
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commission;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegularDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDiscount;
    }
}