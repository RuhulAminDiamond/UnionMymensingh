namespace HDMS.Windows.Forms.UI.OPD
{
    partial class frmOPDBilling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPDBilling));
            this.ctrlOPDMR2 = new HDMS.Windows.Forms.UI.OPD.ctrlOPDMR();
            this.SuspendLayout();
            // 
            // ctrlOPDMR2
            // 
            this.ctrlOPDMR2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlOPDMR2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlOPDMR2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOPDMR2.Location = new System.Drawing.Point(0, 0);
            this.ctrlOPDMR2.Name = "ctrlOPDMR2";
            this.ctrlOPDMR2.Size = new System.Drawing.Size(1291, 707);
            this.ctrlOPDMR2.TabIndex = 0;
            // 
            // frmOPDBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 707);
            this.Controls.Add(this.ctrlOPDMR2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPDBilling";
            this.Text = "OPD Billing";
            this.Load += new System.EventHandler(this.frmOPDBilling_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlOPDMR ctrlOPDMR1;
        private ctrlOPDMR ctrlOPDMR2;
    }
}