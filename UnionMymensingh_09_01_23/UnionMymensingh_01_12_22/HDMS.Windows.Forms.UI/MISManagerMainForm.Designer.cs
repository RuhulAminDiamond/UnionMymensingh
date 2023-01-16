namespace HDMS.Windows.Forms.UI
{
    partial class MISManagerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MISManagerMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMasterTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnugroupEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.grantMenuPermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chamberPractitionerEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientSerialEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newReferralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPatinetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUXReportConsultantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatientStatement = new System.Windows.Forms.ToolStripMenuItem();
            this.summarySheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userwisePatientReceiptStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dueListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referredCasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dueCollectionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultancyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refundStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depriciationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headwiseExpenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseByChequeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.receiptionToolStripMenuItem1,
            this.reportsToolStripMenuItem,
            this.accountsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturePhotoToolStripMenuItem,
            this.registrationToolStripMenuItem,
            this.changePasswordToolStripMenuItem1,
            this.createNewUserToolStripMenuItem,
            this.AddMasterTemplateToolStripMenuItem,
            this.testSettingsToolStripMenuItem,
            this.grantMenuPermissionToolStripMenuItem,
            this.chamberPractitionerEntryToolStripMenuItem});
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
            // createNewUserToolStripMenuItem
            // 
            this.createNewUserToolStripMenuItem.Name = "createNewUserToolStripMenuItem";
            this.createNewUserToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.createNewUserToolStripMenuItem.Tag = "NewUserUnderSettings";
            this.createNewUserToolStripMenuItem.Text = "Create New User";
            this.createNewUserToolStripMenuItem.Click += new System.EventHandler(this.createNewUserToolStripMenuItem_Click);
            // 
            // AddMasterTemplateToolStripMenuItem
            // 
            this.AddMasterTemplateToolStripMenuItem.Name = "AddMasterTemplateToolStripMenuItem";
            this.AddMasterTemplateToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.AddMasterTemplateToolStripMenuItem.Tag = "AddMasterTemplateUnderSettings";
            this.AddMasterTemplateToolStripMenuItem.Text = "Add Master Template";
            this.AddMasterTemplateToolStripMenuItem.Click += new System.EventHandler(this.AddMasterTemplateToolStripMenuItem_Click);
            // 
            // testSettingsToolStripMenuItem
            // 
            this.testSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testEntryToolStripMenuItem,
            this.mnugroupEntry});
            this.testSettingsToolStripMenuItem.Name = "testSettingsToolStripMenuItem";
            this.testSettingsToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.testSettingsToolStripMenuItem.Tag = "TestSettingsUnderSettings";
            this.testSettingsToolStripMenuItem.Text = "Test Settings";
            // 
            // testEntryToolStripMenuItem
            // 
            this.testEntryToolStripMenuItem.Name = "testEntryToolStripMenuItem";
            this.testEntryToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.testEntryToolStripMenuItem.Tag = "TestEntryUnderSettings";
            this.testEntryToolStripMenuItem.Text = "Test Entry";
            this.testEntryToolStripMenuItem.Click += new System.EventHandler(this.testEntryToolStripMenuItem_Click);
            // 
            // mnugroupEntry
            // 
            this.mnugroupEntry.Name = "mnugroupEntry";
            this.mnugroupEntry.Size = new System.Drawing.Size(156, 24);
            this.mnugroupEntry.Tag = "TestGroupEntryUnderSettings";
            this.mnugroupEntry.Text = "Group Entry";
            this.mnugroupEntry.Click += new System.EventHandler(this.mnugroupEntry_Click);
            // 
            // grantMenuPermissionToolStripMenuItem
            // 
            this.grantMenuPermissionToolStripMenuItem.Name = "grantMenuPermissionToolStripMenuItem";
            this.grantMenuPermissionToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.grantMenuPermissionToolStripMenuItem.Tag = "GrantMenuPermission";
            this.grantMenuPermissionToolStripMenuItem.Text = "Grant Menu Permission";
            this.grantMenuPermissionToolStripMenuItem.Click += new System.EventHandler(this.grantMenuPermissionToolStripMenuItem_Click);
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
            this.patientSerialEntryToolStripMenuItem,
            this.newReferralToolStripMenuItem,
            this.editPatinetToolStripMenuItem,
            this.changeUXReportConsultantToolStripMenuItem});
            this.receiptionToolStripMenuItem1.Enabled = false;
            this.receiptionToolStripMenuItem1.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.test;
            this.receiptionToolStripMenuItem1.Name = "receiptionToolStripMenuItem1";
            this.receiptionToolStripMenuItem1.Size = new System.Drawing.Size(124, 36);
            this.receiptionToolStripMenuItem1.Tag = "Receiption";
            this.receiptionToolStripMenuItem1.Text = "Receiption";
            // 
            // newPatientToolStripMenuItem
            // 
            this.newPatientToolStripMenuItem.Name = "newPatientToolStripMenuItem";
            this.newPatientToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.newPatientToolStripMenuItem.Tag = "DiagNewPatientEntryUnderReceiption";
            this.newPatientToolStripMenuItem.Text = "New Patient";
            this.newPatientToolStripMenuItem.Click += new System.EventHandler(this.newPatientToolStripMenuItem_Click);
            // 
            // patientSerialEntryToolStripMenuItem
            // 
            this.patientSerialEntryToolStripMenuItem.Name = "patientSerialEntryToolStripMenuItem";
            this.patientSerialEntryToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.patientSerialEntryToolStripMenuItem.Tag = "PatientSerialEntry";
            this.patientSerialEntryToolStripMenuItem.Text = "Patient Serial Entry";
            this.patientSerialEntryToolStripMenuItem.Visible = false;
            this.patientSerialEntryToolStripMenuItem.Click += new System.EventHandler(this.patientSerialEntryToolStripMenuItem_Click);
            // 
            // newReferralToolStripMenuItem
            // 
            this.newReferralToolStripMenuItem.Name = "newReferralToolStripMenuItem";
            this.newReferralToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.newReferralToolStripMenuItem.Tag = "DiagNewReferralEntryUnderReceiption";
            this.newReferralToolStripMenuItem.Text = "New Referral";
            this.newReferralToolStripMenuItem.Click += new System.EventHandler(this.newPatientToolStripMenuItem_Click);
            // 
            // editPatinetToolStripMenuItem
            // 
            this.editPatinetToolStripMenuItem.Name = "editPatinetToolStripMenuItem";
            this.editPatinetToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.editPatinetToolStripMenuItem.Tag = "DiagEditPatientUnderReceiption";
            this.editPatinetToolStripMenuItem.Text = "Edit Patinet";
            this.editPatinetToolStripMenuItem.Click += new System.EventHandler(this.editPatinetToolStripMenuItem_Click);
            // 
            // changeUXReportConsultantToolStripMenuItem
            // 
            this.changeUXReportConsultantToolStripMenuItem.Name = "changeUXReportConsultantToolStripMenuItem";
            this.changeUXReportConsultantToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.changeUXReportConsultantToolStripMenuItem.Tag = "ChangeReportConsultant";
            this.changeUXReportConsultantToolStripMenuItem.Text = "Change U/X Report Consultant";
            this.changeUXReportConsultantToolStripMenuItem.Click += new System.EventHandler(this.changeUXReportConsultantToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cashBookToolStripMenuItem,
            this.patientStatementToolStripMenuItem,
            this.monthlyStatementToolStripMenuItem,
            this.mnuPatientStatement,
            this.summarySheetToolStripMenuItem,
            this.userwisePatientReceiptStatementToolStripMenuItem,
            this.dueListToolStripMenuItem,
            this.referredCasesToolStripMenuItem,
            this.dueCollectionListToolStripMenuItem,
            this.consultancyReportToolStripMenuItem,
            this.refundStatementToolStripMenuItem,
            this.depriciationListToolStripMenuItem,
            this.testsSummaryToolStripMenuItem,
            this.discountToolStripMenuItem});
            this.reportsToolStripMenuItem.Enabled = false;
            this.reportsToolStripMenuItem.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.download;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(104, 36);
            this.reportsToolStripMenuItem.Tag = "Reports";
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // cashBookToolStripMenuItem
            // 
            this.cashBookToolStripMenuItem.Name = "cashBookToolStripMenuItem";
            this.cashBookToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.cashBookToolStripMenuItem.Tag = "CashBookUnderAccounts";
            this.cashBookToolStripMenuItem.Text = "Cash Book";
            this.cashBookToolStripMenuItem.Click += new System.EventHandler(this.cashBookToolStripMenuItem_Click);
            // 
            // patientStatementToolStripMenuItem
            // 
            this.patientStatementToolStripMenuItem.Name = "patientStatementToolStripMenuItem";
            this.patientStatementToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.patientStatementToolStripMenuItem.Tag = "PatientStatementLong";
            this.patientStatementToolStripMenuItem.Text = "Patient Statement";
            this.patientStatementToolStripMenuItem.Visible = false;
            this.patientStatementToolStripMenuItem.Click += new System.EventHandler(this.patientStatementToolStripMenuItem_Click);
            // 
            // monthlyStatementToolStripMenuItem
            // 
            this.monthlyStatementToolStripMenuItem.Name = "monthlyStatementToolStripMenuItem";
            this.monthlyStatementToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.monthlyStatementToolStripMenuItem.Tag = "MonthlyLedger";
            this.monthlyStatementToolStripMenuItem.Text = "Monthly Statement";
            this.monthlyStatementToolStripMenuItem.Visible = false;
            this.monthlyStatementToolStripMenuItem.Click += new System.EventHandler(this.monthlyStatementToolStripMenuItem_Click);
            // 
            // mnuPatientStatement
            // 
            this.mnuPatientStatement.Name = "mnuPatientStatement";
            this.mnuPatientStatement.Size = new System.Drawing.Size(315, 24);
            this.mnuPatientStatement.Tag = "DiagPatientStatementUnderRepots";
            this.mnuPatientStatement.Text = "Patient Statement";
            this.mnuPatientStatement.Click += new System.EventHandler(this.mnuPatientStatement_Click);
            // 
            // summarySheetToolStripMenuItem
            // 
            this.summarySheetToolStripMenuItem.Name = "summarySheetToolStripMenuItem";
            this.summarySheetToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.summarySheetToolStripMenuItem.Tag = "SummarySheetUnderReports";
            this.summarySheetToolStripMenuItem.Text = "Summary Sheet";
            this.summarySheetToolStripMenuItem.Visible = false;
            this.summarySheetToolStripMenuItem.Click += new System.EventHandler(this.summarySheetToolStripMenuItem_Click);
            // 
            // userwisePatientReceiptStatementToolStripMenuItem
            // 
            this.userwisePatientReceiptStatementToolStripMenuItem.Name = "userwisePatientReceiptStatementToolStripMenuItem";
            this.userwisePatientReceiptStatementToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.userwisePatientReceiptStatementToolStripMenuItem.Tag = "UserwisePatientReceiptStatementUnderReports";
            this.userwisePatientReceiptStatementToolStripMenuItem.Text = "Userwise Patient Receipt Statement ";
            this.userwisePatientReceiptStatementToolStripMenuItem.Click += new System.EventHandler(this.userwisePatientReceiptStatementToolStripMenuItem_Click);
            // 
            // dueListToolStripMenuItem
            // 
            this.dueListToolStripMenuItem.Name = "dueListToolStripMenuItem";
            this.dueListToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.dueListToolStripMenuItem.Tag = "DueListUnderReports";
            this.dueListToolStripMenuItem.Text = "Due List";
            this.dueListToolStripMenuItem.Click += new System.EventHandler(this.dueListToolStripMenuItem_Click);
            // 
            // referredCasesToolStripMenuItem
            // 
            this.referredCasesToolStripMenuItem.Name = "referredCasesToolStripMenuItem";
            this.referredCasesToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.referredCasesToolStripMenuItem.Tag = "ReferredCasesUnderReports";
            this.referredCasesToolStripMenuItem.Text = "Referred Cases";
            this.referredCasesToolStripMenuItem.Click += new System.EventHandler(this.referredCasesToolStripMenuItem_Click);
            // 
            // dueCollectionListToolStripMenuItem
            // 
            this.dueCollectionListToolStripMenuItem.Name = "dueCollectionListToolStripMenuItem";
            this.dueCollectionListToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.dueCollectionListToolStripMenuItem.Tag = "DueCollectionListUnderReports";
            this.dueCollectionListToolStripMenuItem.Text = "Due Collection List";
            this.dueCollectionListToolStripMenuItem.Click += new System.EventHandler(this.dueCollectionListToolStripMenuItem_Click);
            // 
            // consultancyReportToolStripMenuItem
            // 
            this.consultancyReportToolStripMenuItem.Name = "consultancyReportToolStripMenuItem";
            this.consultancyReportToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.consultancyReportToolStripMenuItem.Tag = "ConsultancyUnderReports";
            this.consultancyReportToolStripMenuItem.Text = "Consultancy Report";
            this.consultancyReportToolStripMenuItem.Visible = false;
            this.consultancyReportToolStripMenuItem.Click += new System.EventHandler(this.consultancyReportToolStripMenuItem_Click);
            // 
            // refundStatementToolStripMenuItem
            // 
            this.refundStatementToolStripMenuItem.Name = "refundStatementToolStripMenuItem";
            this.refundStatementToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.refundStatementToolStripMenuItem.Tag = "RefundStatement";
            this.refundStatementToolStripMenuItem.Text = "Refund Statement";
            this.refundStatementToolStripMenuItem.Click += new System.EventHandler(this.refundStatementToolStripMenuItem_Click);
            // 
            // depriciationListToolStripMenuItem
            // 
            this.depriciationListToolStripMenuItem.Name = "depriciationListToolStripMenuItem";
            this.depriciationListToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.depriciationListToolStripMenuItem.Tag = "DepriciationList";
            this.depriciationListToolStripMenuItem.Text = "Depriciation List";
            this.depriciationListToolStripMenuItem.Visible = false;
            this.depriciationListToolStripMenuItem.Click += new System.EventHandler(this.depriciationListToolStripMenuItem_Click);
            // 
            // testsSummaryToolStripMenuItem
            // 
            this.testsSummaryToolStripMenuItem.Name = "testsSummaryToolStripMenuItem";
            this.testsSummaryToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.testsSummaryToolStripMenuItem.Tag = "TestsSummary";
            this.testsSummaryToolStripMenuItem.Text = "Tests Summary";
            this.testsSummaryToolStripMenuItem.Click += new System.EventHandler(this.testsSummaryToolStripMenuItem_Click);
            // 
            // discountToolStripMenuItem
            // 
            this.discountToolStripMenuItem.Name = "discountToolStripMenuItem";
            this.discountToolStripMenuItem.Size = new System.Drawing.Size(315, 24);
            this.discountToolStripMenuItem.Tag = "DiscountList";
            this.discountToolStripMenuItem.Text = "Discount List";
            this.discountToolStripMenuItem.Click += new System.EventHandler(this.discountToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expenseEntryToolStripMenuItem,
            this.accountsSetupToolStripMenuItem,
            this.headwiseExpenseToolStripMenuItem1,
            this.expenseByChequeToolStripMenuItem});
            this.accountsToolStripMenuItem.Enabled = false;
            this.accountsToolStripMenuItem.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.download__1_;
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(113, 36);
            this.accountsToolStripMenuItem.Tag = "Accounts";
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // expenseEntryToolStripMenuItem
            // 
            this.expenseEntryToolStripMenuItem.Name = "expenseEntryToolStripMenuItem";
            this.expenseEntryToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.expenseEntryToolStripMenuItem.Tag = "ExpenseEntryUnderAccounts";
            this.expenseEntryToolStripMenuItem.Text = "Income/Expense Entry";
            this.expenseEntryToolStripMenuItem.Click += new System.EventHandler(this.expenseEntryToolStripMenuItem_Click);
            // 
            // accountsSetupToolStripMenuItem
            // 
            this.accountsSetupToolStripMenuItem.Name = "accountsSetupToolStripMenuItem";
            this.accountsSetupToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.accountsSetupToolStripMenuItem.Tag = "AccountSetupUnderAccounts";
            this.accountsSetupToolStripMenuItem.Text = "Accounts Setup";
            this.accountsSetupToolStripMenuItem.Click += new System.EventHandler(this.accountsSetupToolStripMenuItem_Click);
            // 
            // headwiseExpenseToolStripMenuItem1
            // 
            this.headwiseExpenseToolStripMenuItem1.Name = "headwiseExpenseToolStripMenuItem1";
            this.headwiseExpenseToolStripMenuItem1.Size = new System.Drawing.Size(224, 24);
            this.headwiseExpenseToolStripMenuItem1.Tag = "HeadwiseExpense";
            this.headwiseExpenseToolStripMenuItem1.Text = "Headwise Expense";
            this.headwiseExpenseToolStripMenuItem1.Click += new System.EventHandler(this.headwiseExpenseToolStripMenuItem1_Click);
            // 
            // expenseByChequeToolStripMenuItem
            // 
            this.expenseByChequeToolStripMenuItem.Name = "expenseByChequeToolStripMenuItem";
            this.expenseByChequeToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.expenseByChequeToolStripMenuItem.Tag = "ExpenseByCheque";
            this.expenseByChequeToolStripMenuItem.Text = "Expense By Cheque";
            this.expenseByChequeToolStripMenuItem.Click += new System.EventHandler(this.expenseByChequeToolStripMenuItem_Click);
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
            // MISManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources._920x12401;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MISManagerMainForm";
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
        private System.Windows.Forms.ToolStripMenuItem AddMasterTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ImageList imgListLage;
        private System.Windows.Forms.ToolStripMenuItem receiptionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnugroupEntry;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newReferralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPatinetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPatientStatement;
        private System.Windows.Forms.ToolStripMenuItem cashBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summarySheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userwisePatientReceiptStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dueListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referredCasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dueCollectionListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultancyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grantMenuPermissionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refundStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depriciationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUXReportConsultantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chamberPractitionerEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientSerialEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headwiseExpenseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem expenseByChequeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturePhotoToolStripMenuItem;
    }
}