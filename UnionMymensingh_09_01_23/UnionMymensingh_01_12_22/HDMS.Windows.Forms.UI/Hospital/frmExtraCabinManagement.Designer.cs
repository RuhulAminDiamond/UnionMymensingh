namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmExtraCabinManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtraCabinManagement));
            this.ctrlExtraBed1 = new HDMS.Windows.Forms.UI.Hospital.ctrlExtraBed();
            this.SuspendLayout();
            // 
            // ctrlExtraBed1
            // 
            this.ctrlExtraBed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlExtraBed1.Location = new System.Drawing.Point(0, 0);
            this.ctrlExtraBed1.Name = "ctrlExtraBed1";
            this.ctrlExtraBed1.Size = new System.Drawing.Size(872, 537);
            this.ctrlExtraBed1.TabIndex = 0;
            // 
            // frmExtraCabinManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 537);
            this.Controls.Add(this.ctrlExtraBed1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtraCabinManagement";
            this.Text = "Extra Cabin Management";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlExtraBed ctrlExtraBed1;
    }
}