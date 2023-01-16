namespace HDMS.Windows.Forms.UI
{
    partial class ReportViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
            this.crviewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crviewer
            // 
            this.crviewer.ActiveViewIndex = -1;
            this.crviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crviewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crviewer.Location = new System.Drawing.Point(0, 0);
            this.crviewer.Name = "crviewer";
            this.crviewer.Size = new System.Drawing.Size(1145, 618);
            this.crviewer.TabIndex = 0;
            this.crviewer.ClickPage += new CrystalDecisions.Windows.Forms.PageMouseEventHandler(this.crviewer_ClickPage);
            this.crviewer.DoubleClickPage += new CrystalDecisions.Windows.Forms.PageMouseEventHandler(this.crviewer_DoubleClickPage);
            this.crviewer.Click += new System.EventHandler(this.crviewer_Click);
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 618);
            this.Controls.Add(this.crviewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportViewer";
            this.Text = "ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crviewer;
    }
}