namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmDischargedPatients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDischargedPatients));
            this.ctrlDischargedPatient1 = new HDMS.Windows.Forms.UI.Hospital.ctrlDischargedPatient();
            this.SuspendLayout();
            // 
            // ctrlDischargedPatient1
            // 
            this.ctrlDischargedPatient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDischargedPatient1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDischargedPatient1.Name = "ctrlDischargedPatient1";
            this.ctrlDischargedPatient1.Size = new System.Drawing.Size(1244, 628);
            this.ctrlDischargedPatient1.TabIndex = 0;
            this.ctrlDischargedPatient1.Load += new System.EventHandler(this.ctrlDischargedPatient1_Load);
            // 
            // frmDischargedPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 628);
            this.Controls.Add(this.ctrlDischargedPatient1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDischargedPatients";
            this.Text = "Discharged Patients";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDischargedPatient ctrlDischargedPatient1;
    }
}