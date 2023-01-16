namespace HDMS.Windows.Forms.UI
{
    partial class PathologyMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathologyMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonsticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathologicalReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConsultantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDetailsEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testReportOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.imgListLage = new System.Windows.Forms.ImageList(this.components);
            this.testEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnugroupEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.diagonsticsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem1});
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.settingsToolStripMenuItem.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.images33;
            this.settingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.settingsToolStripMenuItem.Tag = "File";
            this.settingsToolStripMenuItem.Text = "&File";
            // 
            // changePasswordToolStripMenuItem1
            // 
            this.changePasswordToolStripMenuItem1.Name = "changePasswordToolStripMenuItem1";
            this.changePasswordToolStripMenuItem1.Size = new System.Drawing.Size(193, 24);
            this.changePasswordToolStripMenuItem1.Tag = "ChangePasswordUnderSettings";
            this.changePasswordToolStripMenuItem1.Text = "Change Password";
            this.changePasswordToolStripMenuItem1.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // diagonsticsToolStripMenuItem
            // 
            this.diagonsticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathologicalReportToolStripMenuItem,
            this.newConsultantToolStripMenuItem,
            this.testDetailsEntryToolStripMenuItem,
            this.addNewTemplateToolStripMenuItem,
            this.testReportOrderToolStripMenuItem});
            this.diagonsticsToolStripMenuItem.Enabled = false;
            this.diagonsticsToolStripMenuItem.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.images__2_;
            this.diagonsticsToolStripMenuItem.Name = "diagonsticsToolStripMenuItem";
            this.diagonsticsToolStripMenuItem.Size = new System.Drawing.Size(126, 36);
            this.diagonsticsToolStripMenuItem.Tag = "LabReport";
            this.diagonsticsToolStripMenuItem.Text = "Lab Report";
            // 
            // pathologicalReportToolStripMenuItem
            // 
            this.pathologicalReportToolStripMenuItem.Name = "pathologicalReportToolStripMenuItem";
            this.pathologicalReportToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.pathologicalReportToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.pathologicalReportToolStripMenuItem.Tag = "PathologicalReport";
            this.pathologicalReportToolStripMenuItem.Text = "Pathological Report";
            this.pathologicalReportToolStripMenuItem.Click += new System.EventHandler(this.pathologicalReportToolStripMenuItem_Click);
            // 
            // newConsultantToolStripMenuItem
            // 
            this.newConsultantToolStripMenuItem.Name = "newConsultantToolStripMenuItem";
            this.newConsultantToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.newConsultantToolStripMenuItem.Tag = "NewConsultantUnderLabReports";
            this.newConsultantToolStripMenuItem.Text = "New Consultant";
            this.newConsultantToolStripMenuItem.Click += new System.EventHandler(this.newConsultantToolStripMenuItem_Click);
            // 
            // testDetailsEntryToolStripMenuItem
            // 
            this.testDetailsEntryToolStripMenuItem.Name = "testDetailsEntryToolStripMenuItem";
            this.testDetailsEntryToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.testDetailsEntryToolStripMenuItem.Tag = "TestCriteriaEntry";
            this.testDetailsEntryToolStripMenuItem.Text = "Test Details Entry";
            this.testDetailsEntryToolStripMenuItem.Click += new System.EventHandler(this.testDetailsEntryToolStripMenuItem_Click);
            // 
            // addNewTemplateToolStripMenuItem
            // 
            this.addNewTemplateToolStripMenuItem.Name = "addNewTemplateToolStripMenuItem";
            this.addNewTemplateToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.addNewTemplateToolStripMenuItem.Tag = "tagAddNewTemplate";
            this.addNewTemplateToolStripMenuItem.Text = "&Add New Template";
            this.addNewTemplateToolStripMenuItem.Click += new System.EventHandler(this.addNewTemplateToolStripMenuItem_Click);
            // 
            // testReportOrderToolStripMenuItem
            // 
            this.testReportOrderToolStripMenuItem.Name = "testReportOrderToolStripMenuItem";
            this.testReportOrderToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.testReportOrderToolStripMenuItem.Tag = "tagTestReportOrder";
            this.testReportOrderToolStripMenuItem.Text = "Test Report Order";
            this.testReportOrderToolStripMenuItem.Click += new System.EventHandler(this.testReportOrderToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // imgListLage
            // 
            this.imgListLage.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imgListLage.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListLage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // testEntryToolStripMenuItem
            // 
            this.testEntryToolStripMenuItem.Name = "testEntryToolStripMenuItem";
            this.testEntryToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.testEntryToolStripMenuItem.Tag = "TestEntryUnderSettings";
            this.testEntryToolStripMenuItem.Text = "Test Entry";
            this.testEntryToolStripMenuItem.Click += new System.EventHandler(this.testEntryToolStripMenuItem_Click);
            // 
            // mnugroupEntry
            // 
            this.mnugroupEntry.Name = "mnugroupEntry";
            this.mnugroupEntry.Size = new System.Drawing.Size(162, 26);
            this.mnugroupEntry.Tag = "TestGroupEntryUnderSettings";
            this.mnugroupEntry.Text = "Group Entry";
            this.mnugroupEntry.Click += new System.EventHandler(this.mnugroupEntry_Click);
            // 
            // PathologyMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources._2b25746cd9153f6b8411751d2f7b2e051;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PathologyMainForm";
            this.Text = "Mount Adora Hospital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonsticsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imgListLage;
        private System.Windows.Forms.ToolStripMenuItem pathologicalReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConsultantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testDetailsEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnugroupEntry;
        private System.Windows.Forms.ToolStripMenuItem testReportOrderToolStripMenuItem;
    }
}