namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmServiceEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceEntry));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlDoctors1 = new HDMS.Windows.Forms.UI.Hospital.ctrlDoctors();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1255, 680);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlDoctors1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1247, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Doctor Service";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlDoctors1
            // 
            this.ctrlDoctors1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ctrlDoctors1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDoctors1.Location = new System.Drawing.Point(3, 3);
            this.ctrlDoctors1.Name = "ctrlDoctors1";
            this.ctrlDoctors1.Size = new System.Drawing.Size(1241, 648);
            this.ctrlDoctors1.TabIndex = 0;
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "BedImageIcon.BMP");
            this.imgListLarge.Images.SetKeyName(1, "cabin.bmp");
            this.imgListLarge.Images.SetKeyName(2, "images.jpg");
            // 
            // frmServiceEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 680);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServiceEntry";
            this.Text = "Service Entry";
            this.Load += new System.EventHandler(this.frmServiceEntry_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ctrlDoctors ctrlDoctors1;
        private System.Windows.Forms.ImageList imgListLarge;
    }
}