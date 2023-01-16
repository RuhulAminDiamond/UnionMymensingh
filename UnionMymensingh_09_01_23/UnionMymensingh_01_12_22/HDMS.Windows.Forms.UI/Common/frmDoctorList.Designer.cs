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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISOPDConsultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPDConsultancyFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndoorConsultancyFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dvList
            // 
            this.dvList.AllowUserToAddRows = false;
            this.dvList.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.dvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DName,
            this.ISOPDConsultant,
            this.OPDConsultancyFee,
            this.IndoorConsultancyFee});
            this.dvList.Location = new System.Drawing.Point(-4, 76);
            this.dvList.Name = "dvList";
            this.dvList.Size = new System.Drawing.Size(1077, 510);
            this.dvList.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // DName
            // 
            this.DName.DataPropertyName = "Name";
            this.DName.HeaderText = "Name";
            this.DName.Name = "DName";
            this.DName.Width = 375;
            // 
            // ISOPDConsultant
            // 
            this.ISOPDConsultant.DataPropertyName = "IsOPDConsultant";
            this.ISOPDConsultant.HeaderText = "OPD Practitioner";
            this.ISOPDConsultant.Name = "ISOPDConsultant";
            this.ISOPDConsultant.Width = 150;
            // 
            // OPDConsultancyFee
            // 
            this.OPDConsultancyFee.DataPropertyName = "ConsultancyFee";
            this.OPDConsultancyFee.HeaderText = "OPDConsultancyFee";
            this.OPDConsultancyFee.Name = "OPDConsultancyFee";
            this.OPDConsultancyFee.Width = 200;
            // 
            // IndoorConsultancyFee
            // 
            this.IndoorConsultancyFee.DataPropertyName = "VisitFee";
            this.IndoorConsultancyFee.HeaderText = "IndoorConsultancyFee";
            this.IndoorConsultancyFee.Name = "IndoorConsultancyFee";
            this.IndoorConsultancyFee.Width = 200;
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.Color.White;
            this.txtDoctor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDoctor.Location = new System.Drawing.Point(129, 24);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(374, 29);
            this.txtDoctor.TabIndex = 87;
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
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(13, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 35);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDoctorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 703);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDoctor);
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
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISOPDConsultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPDConsultancyFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndoorConsultancyFee;
    }
}