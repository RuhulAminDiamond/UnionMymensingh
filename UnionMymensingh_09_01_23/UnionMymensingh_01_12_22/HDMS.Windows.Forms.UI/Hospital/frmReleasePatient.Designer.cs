namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmReleasePatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleasePatient));
            this.ctrlRelease1 = new HDMS.Windows.Forms.UI.Hospital.ctrlRelease();
            this.SuspendLayout();
            // 
            // ctrlRelease1
            // 
            this.ctrlRelease1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRelease1.Location = new System.Drawing.Point(0, 0);
            this.ctrlRelease1.Name = "ctrlRelease1";
            this.ctrlRelease1.Size = new System.Drawing.Size(1084, 608);
            this.ctrlRelease1.TabIndex = 0;
            // 
            // frmReleasePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 608);
            this.Controls.Add(this.ctrlRelease1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReleasePatient";
            this.Text = "Release Patient";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlRelease ctrlRelease1;
    }
}