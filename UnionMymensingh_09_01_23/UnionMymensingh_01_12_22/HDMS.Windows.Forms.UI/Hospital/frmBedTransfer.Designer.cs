namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmBedTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBedTransfer));
            this.ctrlTransfer1 = new HDMS.Windows.Forms.UI.Hospital.ctrlTransfer();
            this.SuspendLayout();
            // 
            // ctrlTransfer1
            // 
            this.ctrlTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTransfer1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTransfer1.Name = "ctrlTransfer1";
            this.ctrlTransfer1.Size = new System.Drawing.Size(1284, 723);
            this.ctrlTransfer1.TabIndex = 0;
            this.ctrlTransfer1.Load += new System.EventHandler(this.ctrlTransfer1_Load);
            // 
            // frmBedTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 723);
            this.Controls.Add(this.ctrlTransfer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBedTransfer";
            this.Text = "Bed Transfer";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTransfer ctrlTransfer1;
    }
}