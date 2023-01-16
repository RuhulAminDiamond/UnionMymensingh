namespace HDMS.Windows.Forms.UI
{
    partial class MainPharmacy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPharmacy));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDepositSlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientSerialEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.imgListLage = new System.Windows.Forms.ImageList(this.components);
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
            this.receiptionToolStripMenuItem1});
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
            // receiptionToolStripMenuItem1
            // 
            this.receiptionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPatientToolStripMenuItem,
            this.receiptStatementToolStripMenuItem,
            this.printDepositSlipToolStripMenuItem,
            this.patientSerialEntryToolStripMenuItem});
            this.receiptionToolStripMenuItem1.Enabled = false;
            this.receiptionToolStripMenuItem1.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.test;
            this.receiptionToolStripMenuItem1.Name = "receiptionToolStripMenuItem1";
            this.receiptionToolStripMenuItem1.Size = new System.Drawing.Size(124, 36);
            this.receiptionToolStripMenuItem1.Tag = "In";
            this.receiptionToolStripMenuItem1.Text = "Receiption";
            // 
            // newPatientToolStripMenuItem
            // 
            this.newPatientToolStripMenuItem.Name = "newPatientToolStripMenuItem";
            this.newPatientToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newPatientToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.newPatientToolStripMenuItem.Tag = "DiagNewPatientEntryUnderReceiption";
            this.newPatientToolStripMenuItem.Text = "New Patient";
            this.newPatientToolStripMenuItem.Click += new System.EventHandler(this.newPatientToolStripMenuItem_Click);
            // 
            // receiptStatementToolStripMenuItem
            // 
            this.receiptStatementToolStripMenuItem.Name = "receiptStatementToolStripMenuItem";
            this.receiptStatementToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.receiptStatementToolStripMenuItem.Tag = "ReceiptStatement";
            this.receiptStatementToolStripMenuItem.Text = "Receipt Statement";
            this.receiptStatementToolStripMenuItem.Click += new System.EventHandler(this.receiptStatementToolStripMenuItem_Click);
            // 
            // printDepositSlipToolStripMenuItem
            // 
            this.printDepositSlipToolStripMenuItem.Name = "printDepositSlipToolStripMenuItem";
            this.printDepositSlipToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.printDepositSlipToolStripMenuItem.Tag = "PrintDepositSlip";
            this.printDepositSlipToolStripMenuItem.Text = "Print Deposit Slip";
            this.printDepositSlipToolStripMenuItem.Click += new System.EventHandler(this.printDepositSlipToolStripMenuItem_Click);
            // 
            // patientSerialEntryToolStripMenuItem
            // 
            this.patientSerialEntryToolStripMenuItem.Name = "patientSerialEntryToolStripMenuItem";
            this.patientSerialEntryToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.patientSerialEntryToolStripMenuItem.Tag = "PatientSerialEntry";
            this.patientSerialEntryToolStripMenuItem.Text = "Patient Serial Entry";
            this.patientSerialEntryToolStripMenuItem.Visible = false;
            this.patientSerialEntryToolStripMenuItem.Click += new System.EventHandler(this.patientSerialEntryToolStripMenuItem_Click);
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
            // MainPharmacy
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
            this.Name = "MainPharmacy";
            this.Text = "Mount Adora Hospital-Pharmacy";
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imgListLage;
        private System.Windows.Forms.ToolStripMenuItem receiptionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientSerialEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem receiptStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDepositSlipToolStripMenuItem;
    }
}