namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class PatientEntry
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.patientEntryControl020320191 = new HDMS.Windows.Forms.UI.Diagonstics.PatientEntryControl02032019();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.patientEntryControl020320192 = new HDMS.Windows.Forms.UI.Diagonstics.PatientEntryControl02032019();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.patientEntryControl020320193 = new HDMS.Windows.Forms.UI.Diagonstics.PatientEntryControl02032019();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 749);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.patientEntryControl020320191);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1258, 723);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl020320191
            // 
            this.patientEntryControl020320191.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientEntryControl020320191.Location = new System.Drawing.Point(3, 3);
            this.patientEntryControl020320191.Name = "patientEntryControl020320191";
            this.patientEntryControl020320191.Size = new System.Drawing.Size(1252, 717);
            this.patientEntryControl020320191.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.patientEntryControl020320192);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1258, 723);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl020320192
            // 
            this.patientEntryControl020320192.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientEntryControl020320192.Location = new System.Drawing.Point(3, 3);
            this.patientEntryControl020320192.Name = "patientEntryControl020320192";
            this.patientEntryControl020320192.Size = new System.Drawing.Size(1252, 717);
            this.patientEntryControl020320192.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.patientEntryControl020320193);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1258, 723);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl020320193
            // 
            this.patientEntryControl020320193.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientEntryControl020320193.Location = new System.Drawing.Point(3, 3);
            this.patientEntryControl020320193.Name = "patientEntryControl020320193";
            this.patientEntryControl020320193.Size = new System.Drawing.Size(1252, 717);
            this.patientEntryControl020320193.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1258, 723);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sibling Service";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // PatientEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 749);
            this.Controls.Add(this.tabControl1);
            this.Name = "PatientEntry";
            this.ShowIcon = false;
            this.Text = "New PatientEntry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PatientEntry_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private PatientEntryControl02032019 patientEntryControl020320191;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private PatientEntryControl02032019 patientEntryControl020320192;
        private PatientEntryControl02032019 patientEntryControl020320193;
    }
}