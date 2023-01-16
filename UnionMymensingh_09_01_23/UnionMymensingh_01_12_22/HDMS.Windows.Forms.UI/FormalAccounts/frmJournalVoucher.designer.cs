namespace HDMS.Windows.Forms.UI.Accounting
{
    partial class frmJournalVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblCredit1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveJournal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDebit3 = new System.Windows.Forms.Label();
            this.txtDebitAmount = new System.Windows.Forms.TextBox();
            this.lblDebit1 = new System.Windows.Forms.Label();
            this.lblDebit2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgDebitItems = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreditTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCredit3 = new System.Windows.Forms.Label();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            this.dgCreditItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreditRemarks = new System.Windows.Forms.TextBox();
            this.lblCredit2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDebitTotal = new System.Windows.Forms.TextBox();
            this.txtDebitHead = new System.Windows.Forms.TextBox();
            this.txtCreditHead = new System.Windows.Forms.TextBox();
            this.dtpVoucher = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ctrlAccHeadSearch = new HDMS.Windows.Forms.UI.Accounts.CtrlAccountGLSearchControl();
            this.ctrlAccHeadSearchCredit = new HDMS.Windows.Forms.UI.Accounts.CtrlAccountGLSearchControl();
            this.txtPreviousVoucherNo = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreditItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher No";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtVoucherNo.Enabled = false;
            this.txtVoucherNo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVoucherNo.Location = new System.Drawing.Point(152, 32);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(130, 29);
            this.txtVoucherNo.TabIndex = 1;
            // 
            // lblCredit1
            // 
            this.lblCredit1.AutoSize = true;
            this.lblCredit1.BackColor = System.Drawing.Color.Transparent;
            this.lblCredit1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit1.Location = new System.Drawing.Point(595, 137);
            this.lblCredit1.Name = "lblCredit1";
            this.lblCredit1.Size = new System.Drawing.Size(120, 19);
            this.lblCredit1.TabIndex = 2;
            this.lblCredit1.Text = "Credit A/C Head";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // btnSaveJournal
            // 
            this.btnSaveJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnSaveJournal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveJournal.ForeColor = System.Drawing.Color.White;
            this.btnSaveJournal.Location = new System.Drawing.Point(449, 542);
            this.btnSaveJournal.Name = "btnSaveJournal";
            this.btnSaveJournal.Size = new System.Drawing.Size(130, 41);
            this.btnSaveJournal.TabIndex = 8;
            this.btnSaveJournal.Text = "Save";
            this.btnSaveJournal.UseVisualStyleBackColor = false;
            this.btnSaveJournal.Click += new System.EventHandler(this.btnSaveJournal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(348, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Date";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(152, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(358, 29);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierEmailTextBox_KeyPress);
            // 
            // lblDebit3
            // 
            this.lblDebit3.AutoSize = true;
            this.lblDebit3.BackColor = System.Drawing.Color.Transparent;
            this.lblDebit3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit3.Location = new System.Drawing.Point(32, 209);
            this.lblDebit3.Name = "lblDebit3";
            this.lblDebit3.Size = new System.Drawing.Size(61, 19);
            this.lblDebit3.TabIndex = 38;
            this.lblDebit3.Text = "Amount";
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.Location = new System.Drawing.Point(153, 205);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.Size = new System.Drawing.Size(139, 29);
            this.txtDebitAmount.TabIndex = 37;
            this.txtDebitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebitAmount_KeyPress);
            // 
            // lblDebit1
            // 
            this.lblDebit1.AutoSize = true;
            this.lblDebit1.BackColor = System.Drawing.Color.Transparent;
            this.lblDebit1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit1.Location = new System.Drawing.Point(32, 137);
            this.lblDebit1.Name = "lblDebit1";
            this.lblDebit1.Size = new System.Drawing.Size(115, 19);
            this.lblDebit1.TabIndex = 39;
            this.lblDebit1.Text = "Debit A/C Head";
            // 
            // lblDebit2
            // 
            this.lblDebit2.AutoSize = true;
            this.lblDebit2.BackColor = System.Drawing.Color.Transparent;
            this.lblDebit2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit2.Location = new System.Drawing.Point(32, 174);
            this.lblDebit2.Name = "lblDebit2";
            this.lblDebit2.Size = new System.Drawing.Size(71, 19);
            this.lblDebit2.TabIndex = 40;
            this.lblDebit2.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(153, 169);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(358, 29);
            this.txtRemarks.TabIndex = 41;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // dgDebitItems
            // 
            this.dgDebitItems.AllowUserToAddRows = false;
            this.dgDebitItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(227)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDebitItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDebitItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDebitItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tName,
            this.Amount,
            this.Remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDebitItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDebitItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDebitItems.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgDebitItems.Location = new System.Drawing.Point(36, 240);
            this.dgDebitItems.Name = "dgDebitItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDebitItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgDebitItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDebitItems.Size = new System.Drawing.Size(543, 230);
            this.dgDebitItems.TabIndex = 43;
            this.dgDebitItems.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDebitItems_RowHeaderMouseDoubleClick);
            this.dgDebitItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgDebitItems_UserDeletedRow);
            // 
            // tName
            // 
            this.tName.DataPropertyName = "AccountHeadName";
            this.tName.HeaderText = "Name";
            this.tName.Name = "tName";
            this.tName.Width = 230;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 80;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 240;
            // 
            // txtCreditTotal
            // 
            this.txtCreditTotal.Enabled = false;
            this.txtCreditTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditTotal.Location = new System.Drawing.Point(719, 476);
            this.txtCreditTotal.Name = "txtCreditTotal";
            this.txtCreditTotal.Size = new System.Drawing.Size(106, 29);
            this.txtCreditTotal.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(593, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 19);
            this.label8.TabIndex = 45;
            this.label8.Text = "Total Amount";
            // 
            // lblCredit3
            // 
            this.lblCredit3.AutoSize = true;
            this.lblCredit3.BackColor = System.Drawing.Color.Transparent;
            this.lblCredit3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit3.Location = new System.Drawing.Point(595, 205);
            this.lblCredit3.Name = "lblCredit3";
            this.lblCredit3.Size = new System.Drawing.Size(61, 19);
            this.lblCredit3.TabIndex = 47;
            this.lblCredit3.Text = "Amount";
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.Location = new System.Drawing.Point(719, 201);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(139, 29);
            this.txtCreditAmount.TabIndex = 46;
            this.txtCreditAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditAmount_KeyPress);
            // 
            // dgCreditItems
            // 
            this.dgCreditItems.AllowUserToAddRows = false;
            this.dgCreditItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(227)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCreditItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgCreditItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCreditItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCreditItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgCreditItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCreditItems.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgCreditItems.Location = new System.Drawing.Point(596, 240);
            this.dgCreditItems.Name = "dgCreditItems";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCreditItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgCreditItems.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgCreditItems.Size = new System.Drawing.Size(543, 230);
            this.dgCreditItems.TabIndex = 51;
            this.dgCreditItems.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgCreditItems_RowHeaderMouseDoubleClick);
            this.dgCreditItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgCreditItems_UserDeletedRow);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AccountHeadName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 230;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 240;
            // 
            // txtCreditRemarks
            // 
            this.txtCreditRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditRemarks.Location = new System.Drawing.Point(719, 169);
            this.txtCreditRemarks.Name = "txtCreditRemarks";
            this.txtCreditRemarks.Size = new System.Drawing.Size(358, 26);
            this.txtCreditRemarks.TabIndex = 49;
            this.txtCreditRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditRemarks_KeyPress);
            // 
            // lblCredit2
            // 
            this.lblCredit2.AutoSize = true;
            this.lblCredit2.BackColor = System.Drawing.Color.Transparent;
            this.lblCredit2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit2.Location = new System.Drawing.Point(595, 172);
            this.lblCredit2.Name = "lblCredit2";
            this.lblCredit2.Size = new System.Drawing.Size(71, 19);
            this.lblCredit2.TabIndex = 48;
            this.lblCredit2.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(596, 542);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 41);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 482);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 19);
            this.label11.TabIndex = 56;
            this.label11.Text = "Total Amount";
            // 
            // txtDebitTotal
            // 
            this.txtDebitTotal.Enabled = false;
            this.txtDebitTotal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitTotal.Location = new System.Drawing.Point(153, 476);
            this.txtDebitTotal.Name = "txtDebitTotal";
            this.txtDebitTotal.Size = new System.Drawing.Size(106, 29);
            this.txtDebitTotal.TabIndex = 55;
            // 
            // txtDebitHead
            // 
            this.txtDebitHead.BackColor = System.Drawing.Color.White;
            this.txtDebitHead.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDebitHead.Location = new System.Drawing.Point(153, 133);
            this.txtDebitHead.Name = "txtDebitHead";
            this.txtDebitHead.Size = new System.Drawing.Size(358, 29);
            this.txtDebitHead.TabIndex = 58;
            this.txtDebitHead.TextChanged += new System.EventHandler(this.txtDebitHead_TextChanged);
            // 
            // txtCreditHead
            // 
            this.txtCreditHead.BackColor = System.Drawing.Color.White;
            this.txtCreditHead.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCreditHead.Location = new System.Drawing.Point(719, 133);
            this.txtCreditHead.Name = "txtCreditHead";
            this.txtCreditHead.Size = new System.Drawing.Size(358, 29);
            this.txtCreditHead.TabIndex = 60;
            this.txtCreditHead.TextChanged += new System.EventHandler(this.txtCreditHead_TextChanged);
            // 
            // dtpVoucher
            // 
            this.dtpVoucher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVoucher.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVoucher.Location = new System.Drawing.Point(395, 33);
            this.dtpVoucher.Name = "dtpVoucher";
            this.dtpVoucher.Size = new System.Drawing.Size(115, 27);
            this.dtpVoucher.TabIndex = 10016;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(595, 66);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 32);
            this.btnPrint.TabIndex = 10018;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(716, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 32);
            this.btnClear.TabIndex = 10018;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ctrlAccHeadSearch
            // 
            this.ctrlAccHeadSearch.Location = new System.Drawing.Point(1154, 402);
            this.ctrlAccHeadSearch.Name = "ctrlAccHeadSearch";
            this.ctrlAccHeadSearch.Size = new System.Drawing.Size(797, 468);
            this.ctrlAccHeadSearch.TabIndex = 59;
            this.ctrlAccHeadSearch.Visible = false;
            this.ctrlAccHeadSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Accounting.VModel.VMAccountHeads>.SearchEscapeEventHandler(this.ctrlAccHeadSearch_SearchEsacaped);
            // 
            // ctrlAccHeadSearchCredit
            // 
            this.ctrlAccHeadSearchCredit.Location = new System.Drawing.Point(1180, 341);
            this.ctrlAccHeadSearchCredit.Name = "ctrlAccHeadSearchCredit";
            this.ctrlAccHeadSearchCredit.Size = new System.Drawing.Size(797, 413);
            this.ctrlAccHeadSearchCredit.TabIndex = 61;
            this.ctrlAccHeadSearchCredit.Visible = false;
            this.ctrlAccHeadSearchCredit.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Accounting.VModel.VMAccountHeads>.SearchEscapeEventHandler(this.ctrlAccHeadSearchCredit_SearchEsacaped);
            this.ctrlAccHeadSearchCredit.Load += new System.EventHandler(this.ctrlAccHeadSearchCredit_Load);
            // 
            // txtPreviousVoucherNo
            // 
            this.txtPreviousVoucherNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.txtPreviousVoucherNo.ForeColor = System.Drawing.Color.Gray;
            this.txtPreviousVoucherNo.Location = new System.Drawing.Point(596, 33);
            this.txtPreviousVoucherNo.Name = "txtPreviousVoucherNo";
            this.txtPreviousVoucherNo.PlaceHolderText = "Enter previous voucher no.";
            this.txtPreviousVoucherNo.Size = new System.Drawing.Size(229, 29);
            this.txtPreviousVoucherNo.TabIndex = 10017;
            this.txtPreviousVoucherNo.Text = "Enter previous voucher no.";
            this.txtPreviousVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreviousVoucherNo_KeyPress);
            // 
            // frmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(157)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(1290, 749);
            this.Controls.Add(this.ctrlAccHeadSearch);
            this.Controls.Add(this.ctrlAccHeadSearchCredit);
            this.Controls.Add(this.txtCreditHead);
            this.Controls.Add(this.txtDebitHead);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDebitTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgCreditItems);
            this.Controls.Add(this.txtCreditRemarks);
            this.Controls.Add(this.lblCredit2);
            this.Controls.Add(this.lblCredit3);
            this.Controls.Add(this.txtCreditAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCreditTotal);
            this.Controls.Add(this.dgDebitItems);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblDebit2);
            this.Controls.Add(this.lblDebit1);
            this.Controls.Add(this.lblDebit3);
            this.Controls.Add(this.txtDebitAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveJournal);
            this.Controls.Add(this.txtVoucherNo);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCredit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPreviousVoucherNo);
            this.Controls.Add(this.dtpVoucher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJournalVoucher";
            this.Tag = "JournalVoucher";
            this.Text = "Journal Voucher";
            this.Load += new System.EventHandler(this.frmJournalVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreditItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label lblCredit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveJournal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDebit3;
        private System.Windows.Forms.TextBox txtDebitAmount;
        private System.Windows.Forms.Label lblDebit1;
        private System.Windows.Forms.Label lblDebit2;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgDebitItems;
        private System.Windows.Forms.TextBox txtCreditTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCredit3;
        private System.Windows.Forms.TextBox txtCreditAmount;
        private System.Windows.Forms.DataGridView dgCreditItems;
        private System.Windows.Forms.TextBox txtCreditRemarks;
        private System.Windows.Forms.Label lblCredit2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDebitTotal;
        private Accounts.CtrlAccountGLSearchControl ctrlAccHeadSearch;
        private System.Windows.Forms.TextBox txtDebitHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox txtCreditHead;
        private Accounts.CtrlAccountGLSearchControl ctrlAccHeadSearchCredit;
        private System.Windows.Forms.DateTimePicker dtpVoucher;
        private Controls.PlaceHolderTextBox txtPreviousVoucherNo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClear;
    }
}