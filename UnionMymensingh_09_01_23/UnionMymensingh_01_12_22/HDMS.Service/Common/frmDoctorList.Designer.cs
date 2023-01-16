namespace HDMS.Windows.Forms.UI.Common
{
    partial class frmDoctorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorList));
            this.dvList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDoctor = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalDoc = new System.Windows.Forms.Label();
            this.DoctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPDConsultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultantType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultancyFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CpPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HpPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dvList
            // 
            this.dvList.AllowUserToAddRows = false;
            this.dvList.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.dvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DoctorId,
            this.DName,
            this.OPDConsultant,
            this.Dept,
            this.ConsultantType,
            this.ConsultancyFee,
            this.CpPercent,
            this.HpPercent});
            this.dvList.Location = new System.Drawing.Point(-4, 76);
            this.dvList.Name = "dvList";
            this.dvList.Size = new System.Drawing.Size(1126, 510);
            this.dvList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "Search Doctor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(10, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.txtDoctor.ForeColor = System.Drawing.Color.Gray;
            this.txtDoctor.Location = new System.Drawing.Point(130, 22);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.PlaceHolderText = "Search by name";
            this.txtDoctor.Size = new System.Drawing.Size(331, 29);
            this.txtDoctor.TabIndex = 90;
            this.txtDoctor.Text = "Search by name";
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 91;
            this.label2.Text = "Total Doctor :";
            // 
            // lblTotalDoc
            // 
            this.lblTotalDoc.AutoSize = true;
            this.lblTotalDoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDoc.Location = new System.Drawing.Point(248, 610);
            this.lblTotalDoc.Name = "lblTotalDoc";
            this.lblTotalDoc.Size = new System.Drawing.Size(0, 14);
            this.lblTotalDoc.TabIndex = 92;
            // 
            // DoctorId
            // 
            this.DoctorId.DataPropertyName = "DoctorId";
            this.DoctorId.HeaderText = "DoctorId";
            this.DoctorId.Name = "DoctorId";
            // 
            // DName
            // 
            this.DName.DataPropertyName = "Name";
            this.DName.HeaderText = "Name";
            this.DName.Name = "DName";
            this.DName.Width = 375;
            // 
            // OPDConsultant
            // 
            this.OPDConsultant.DataPropertyName = "OPDConsultant";
            this.OPDConsultant.HeaderText = "OPD. Consul.";
            this.OPDConsultant.Name = "OPDConsultant";
            // 
            // Dept
            // 
            this.Dept.DataPropertyName = "DeptName";
            this.Dept.HeaderText = "Dept.";
            this.Dept.Name = "Dept";
            // 
            // ConsultantType
            // 
            this.ConsultantType.DataPropertyName = "ConsultantType";
            this.ConsultantType.HeaderText = "Consult. Type";
            this.ConsultantType.Name = "ConsultantType";
            // 
            // ConsultancyFee
            // 
            this.ConsultancyFee.DataPropertyName = "ConsultancyFee";
            this.ConsultancyFee.HeaderText = "Consult. Fee";
            this.ConsultancyFee.Name = "ConsultancyFee";
            // 
            // CpPercent
            // 
            this.CpPercent.DataPropertyName = "CpPercent";
            this.CpPercent.HeaderText = "Cp.(%)";
            this.CpPercent.Name = "CpPercent";
            // 
            // HpPercent
            // 
            this.HpPercent.DataPropertyName = "HpPercent";
            this.HpPercent.HeaderText = "Hp.(%)";
            this.HpPercent.Name = "HpPercent";
            // 
            // frmDoctorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 660);
            this.Controls.Add(this.lblTotalDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoctorList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor List";
            this.Load += new System.EventHandler(this.frmDoctorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private Controls.PlaceHolderTextBox txtDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPDConsultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsultantType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsultancyFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn CpPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn HpPercent;
    }
}