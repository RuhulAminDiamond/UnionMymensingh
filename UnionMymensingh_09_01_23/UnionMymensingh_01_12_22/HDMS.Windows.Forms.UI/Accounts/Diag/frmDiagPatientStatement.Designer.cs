namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmDiagPatientStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiagPatientStatement));
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdShow = new System.Windows.Forms.Button();
            this.btnCancelledPatient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radIPD = new System.Windows.Forms.RadioButton();
            this.radOPD = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.btnStatement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(174, 92);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 0;
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(372, 92);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(174, 135);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(145, 37);
            this.cmdShow.TabIndex = 4;
            this.cmdShow.Text = "Collec. Sheet";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // btnCancelledPatient
            // 
            this.btnCancelledPatient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelledPatient.Location = new System.Drawing.Point(-1460, 135);
            this.btnCancelledPatient.Name = "btnCancelledPatient";
            this.btnCancelledPatient.Size = new System.Drawing.Size(152, 37);
            this.btnCancelledPatient.TabIndex = 7;
            this.btnCancelledPatient.Text = "Cancelled Patient";
            this.btnCancelledPatient.UseVisualStyleBackColor = true;
            this.btnCancelledPatient.Click += new System.EventHandler(this.btnCancelledPatient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Select User";
            // 
            // radIPD
            // 
            this.radIPD.AutoSize = true;
            this.radIPD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIPD.Location = new System.Drawing.Point(186, 62);
            this.radIPD.Name = "radIPD";
            this.radIPD.Size = new System.Drawing.Size(50, 24);
            this.radIPD.TabIndex = 10;
            this.radIPD.TabStop = true;
            this.radIPD.Text = "IPD";
            this.radIPD.UseVisualStyleBackColor = true;
            // 
            // radOPD
            // 
            this.radOPD.AutoSize = true;
            this.radOPD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOPD.Location = new System.Drawing.Point(262, 62);
            this.radOPD.Name = "radOPD";
            this.radOPD.Size = new System.Drawing.Size(57, 24);
            this.radOPD.TabIndex = 11;
            this.radOPD.TabStop = true;
            this.radOPD.Text = "OPD";
            this.radOPD.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(340, 62);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(45, 24);
            this.radAll.TabIndex = 12;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Report Option";
            // 
            // cmbUser
            // 
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "J",
            "D",
            "C",
            "Cash"});
            this.cmbUser.Location = new System.Drawing.Point(175, 27);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(265, 29);
            this.cmbUser.TabIndex = 37;
            this.cmbUser.ValueMember = "Id";
            // 
            // btnStatement
            // 
            this.btnStatement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatement.Location = new System.Drawing.Point(372, 135);
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.Size = new System.Drawing.Size(139, 37);
            this.btnStatement.TabIndex = 38;
            this.btnStatement.Text = "Statement";
            this.btnStatement.UseVisualStyleBackColor = true;
            this.btnStatement.Click += new System.EventHandler(this.btnStatement_Click);
            // 
            // frmDiagPatientStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 238);
            this.Controls.Add(this.btnStatement);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.radOPD);
            this.Controls.Add(this.radIPD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelledPatient);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDiagPatientStatement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diag Patient Statement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDiagPatientStatement_FormClosed);
            this.Load += new System.EventHandler(this.frmDiagPatientStatement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Button btnCancelledPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radIPD;
        private System.Windows.Forms.RadioButton radOPD;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Button btnStatement;
    }
}