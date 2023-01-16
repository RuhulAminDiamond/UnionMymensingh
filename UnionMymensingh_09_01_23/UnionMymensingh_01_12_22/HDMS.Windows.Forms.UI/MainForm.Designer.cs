namespace HDMS.Windows.Forms.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chamberPractitionerEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDepositSlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientSerialEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imgListLage = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.lblWorkStationId = new System.Windows.Forms.Label();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.receiptionToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturePhotoToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.changePasswordToolStripMenuItem1,
            this.testEntryToolStripMenuItem,
            this.chamberPractitionerEntryToolStripMenuItem});
            this.settingsToolStripMenuItem.Enabled = false;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.settingsToolStripMenuItem.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.images__1_;
            this.settingsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.settingsToolStripMenuItem.Tag = "File";
            this.settingsToolStripMenuItem.Text = "&File";
            this.settingsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // capturePhotoToolStripMenuItem
            // 
            this.capturePhotoToolStripMenuItem.Name = "capturePhotoToolStripMenuItem";
            this.capturePhotoToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.capturePhotoToolStripMenuItem.Tag = "CapturePhoto";
            this.capturePhotoToolStripMenuItem.Text = "Capture Photo";
            this.capturePhotoToolStripMenuItem.Click += new System.EventHandler(this.capturePhotoToolStripMenuItem_Click);
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.registrationToolStripMenuItem.Tag = "Registration";
            this.registrationToolStripMenuItem.Text = "Registration";
            this.registrationToolStripMenuItem.Click += new System.EventHandler(this.registrationToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem1
            // 
            this.changePasswordToolStripMenuItem1.Name = "changePasswordToolStripMenuItem1";
            this.changePasswordToolStripMenuItem1.Size = new System.Drawing.Size(255, 24);
            this.changePasswordToolStripMenuItem1.Tag = "ChangePasswordUnderSettings";
            this.changePasswordToolStripMenuItem1.Text = "Change Password";
            this.changePasswordToolStripMenuItem1.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // testEntryToolStripMenuItem
            // 
            this.testEntryToolStripMenuItem.Name = "testEntryToolStripMenuItem";
            this.testEntryToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.testEntryToolStripMenuItem.Tag = "TestEntryUnderSettings";
            this.testEntryToolStripMenuItem.Text = "Test Entry";
            this.testEntryToolStripMenuItem.Click += new System.EventHandler(this.testEntryToolStripMenuItem_Click);
            // 
            // chamberPractitionerEntryToolStripMenuItem
            // 
            this.chamberPractitionerEntryToolStripMenuItem.Name = "chamberPractitionerEntryToolStripMenuItem";
            this.chamberPractitionerEntryToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.chamberPractitionerEntryToolStripMenuItem.Tag = "ChamberPractitionerEntry";
            this.chamberPractitionerEntryToolStripMenuItem.Text = "Chamber Practitioner Entry";
            this.chamberPractitionerEntryToolStripMenuItem.Visible = false;
            this.chamberPractitionerEntryToolStripMenuItem.Click += new System.EventHandler(this.chamberPractitionerEntryToolStripMenuItem_Click);
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
            this.receiptionToolStripMenuItem1.Tag = "Receiption";
            this.receiptionToolStripMenuItem1.Text = "Receiption";
            this.receiptionToolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.receiptionToolStripMenuItem1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
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
            // imgListLage
            // 
            this.imgListLage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLage.ImageStream")));
            this.imgListLage.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLage.Images.SetKeyName(0, "images.jpg");
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Location = new System.Drawing.Point(687, -11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // treeMenu
            // 
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMenu.Location = new System.Drawing.Point(0, 25);
            this.treeMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(278, 537);
            this.treeMenu.TabIndex = 10;
            this.treeMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeMenu_NodeMouseClick);
            // 
            // lblWorkStationId
            // 
            this.lblWorkStationId.AutoSize = true;
            this.lblWorkStationId.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkStationId.ForeColor = System.Drawing.Color.Red;
            this.lblWorkStationId.Location = new System.Drawing.Point(12, 2);
            this.lblWorkStationId.Name = "lblWorkStationId";
            this.lblWorkStationId.Size = new System.Drawing.Size(42, 14);
            this.lblWorkStationId.TabIndex = 12;
            this.lblWorkStationId.Text = "label1";
            // 
            // treeImageList
            // 
            this.treeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.treeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources.Software_Back1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 562);
            this.Controls.Add(this.lblWorkStationId);
            this.Controls.Add(this.treeMenu);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Mymensingh Union Specialized Hospital Ltd.";
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
        private System.Windows.Forms.ImageList imgListLage;
        private System.Windows.Forms.ToolStripMenuItem receiptionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chamberPractitionerEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientSerialEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturePhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDepositSlipToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView treeMenu;
        public System.Windows.Forms.Label lblWorkStationId;
        private System.Windows.Forms.ImageList treeImageList;
    }
}