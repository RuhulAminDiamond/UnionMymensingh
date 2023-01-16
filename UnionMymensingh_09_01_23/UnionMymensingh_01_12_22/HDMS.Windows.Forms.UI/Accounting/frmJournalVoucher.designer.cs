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
            this.txtAccountHeadID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveDebitVoucher = new System.Windows.Forms.Button();
            this.ddlCreditAccountNo = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.TVAccountList = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVoucherDate = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.ddlDebitAccountNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnDebitAdd = new System.Windows.Forms.Button();
            this.dgDebitItems = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            this.dgCreditItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreditAdd = new System.Windows.Forms.Button();
            this.txtCreditRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDebit = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreditItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(302, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Journal Voucher ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtAccountHeadID
            // 
            this.txtAccountHeadID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAccountHeadID.Enabled = false;
            this.txtAccountHeadID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountHeadID.Location = new System.Drawing.Point(430, 5);
            this.txtAccountHeadID.Name = "txtAccountHeadID";
            this.txtAccountHeadID.Size = new System.Drawing.Size(130, 29);
            this.txtAccountHeadID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(302, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Credit A/C Head";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(313, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // btnSaveDebitVoucher
            // 
            this.btnSaveDebitVoucher.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDebitVoucher.Location = new System.Drawing.Point(430, 472);
            this.btnSaveDebitVoucher.Name = "btnSaveDebitVoucher";
            this.btnSaveDebitVoucher.Size = new System.Drawing.Size(116, 41);
            this.btnSaveDebitVoucher.TabIndex = 8;
            this.btnSaveDebitVoucher.Text = "Save";
            this.btnSaveDebitVoucher.UseVisualStyleBackColor = true;
            this.btnSaveDebitVoucher.Click += new System.EventHandler(this.btnSaveDebitVoucher_Click);
            // 
            // ddlCreditAccountNo
            // 
            this.ddlCreditAccountNo.FormattingEnabled = true;
            this.ddlCreditAccountNo.Location = new System.Drawing.Point(430, 239);
            this.ddlCreditAccountNo.Name = "ddlCreditAccountNo";
            this.ddlCreditAccountNo.Size = new System.Drawing.Size(297, 21);
            this.ddlCreditAccountNo.TabIndex = 15;
            this.ddlCreditAccountNo.SelectedIndexChanged += new System.EventHandler(this.ddlCreditAccountNo_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(563, 472);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 41);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // TVAccountList
            // 
            this.TVAccountList.CheckBoxes = true;
            this.TVAccountList.Dock = System.Windows.Forms.DockStyle.Left;
            this.TVAccountList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVAccountList.Location = new System.Drawing.Point(0, 0);
            this.TVAccountList.Name = "TVAccountList";
            this.TVAccountList.Size = new System.Drawing.Size(221, 528);
            this.TVAccountList.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(740, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Voucher Date";
            // 
            // txtVoucherDate
            // 
            this.txtVoucherDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtVoucherDate.Enabled = false;
            this.txtVoucherDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVoucherDate.Location = new System.Drawing.Point(845, 9);
            this.txtVoucherDate.Name = "txtVoucherDate";
            this.txtVoucherDate.Size = new System.Drawing.Size(180, 29);
            this.txtVoucherDate.TabIndex = 19;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(429, 418);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(596, 31);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierEmailTextBox_KeyPress);
            // 
            // ddlDebitAccountNo
            // 
            this.ddlDebitAccountNo.FormattingEnabled = true;
            this.ddlDebitAccountNo.Location = new System.Drawing.Point(430, 51);
            this.ddlDebitAccountNo.Name = "ddlDebitAccountNo";
            this.ddlDebitAccountNo.Size = new System.Drawing.Size(297, 21);
            this.ddlDebitAccountNo.TabIndex = 20;
            this.ddlDebitAccountNo.SelectedIndexChanged += new System.EventHandler(this.ddlDebitAccountNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(771, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 38;
            this.label6.Text = "Amount";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(845, 51);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(80, 26);
            this.txtRate.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label7.Location = new System.Drawing.Point(302, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Debit A/C Head";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(430, 81);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(492, 26);
            this.txtRemarks.TabIndex = 41;
            // 
            // btnDebitAdd
            // 
            this.btnDebitAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebitAdd.Location = new System.Drawing.Point(931, 49);
            this.btnDebitAdd.Name = "btnDebitAdd";
            this.btnDebitAdd.Size = new System.Drawing.Size(94, 58);
            this.btnDebitAdd.TabIndex = 42;
            this.btnDebitAdd.Text = "ADD";
            this.btnDebitAdd.UseVisualStyleBackColor = true;
            this.btnDebitAdd.Click += new System.EventHandler(this.btnDebitAdd_Click);
            // 
            // dgDebitItems
            // 
            this.dgDebitItems.AllowUserToAddRows = false;
            this.dgDebitItems.BackgroundColor = System.Drawing.Color.Moccasin;
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
            this.dgDebitItems.Location = new System.Drawing.Point(430, 117);
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
            this.dgDebitItems.Size = new System.Drawing.Size(595, 107);
            this.dgDebitItems.TabIndex = 43;
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
            this.Remarks.Width = 230;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(945, 461);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(80, 26);
            this.txtTotalAmount.TabIndex = 44;
            this.txtTotalAmount.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(829, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Total Amount";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(771, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 18);
            this.label9.TabIndex = 47;
            this.label9.Text = "Amount";
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.Location = new System.Drawing.Point(845, 239);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.Size = new System.Drawing.Size(80, 26);
            this.txtCreditAmount.TabIndex = 46;
            // 
            // dgCreditItems
            // 
            this.dgCreditItems.AllowUserToAddRows = false;
            this.dgCreditItems.BackgroundColor = System.Drawing.Color.Moccasin;
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
            this.dgCreditItems.Location = new System.Drawing.Point(430, 307);
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
            this.dgCreditItems.Size = new System.Drawing.Size(595, 107);
            this.dgCreditItems.TabIndex = 51;
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
            this.dataGridViewTextBoxColumn3.Width = 230;
            // 
            // btnCreditAdd
            // 
            this.btnCreditAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditAdd.Location = new System.Drawing.Point(931, 239);
            this.btnCreditAdd.Name = "btnCreditAdd";
            this.btnCreditAdd.Size = new System.Drawing.Size(94, 58);
            this.btnCreditAdd.TabIndex = 50;
            this.btnCreditAdd.Text = "ADD";
            this.btnCreditAdd.UseVisualStyleBackColor = true;
            this.btnCreditAdd.Click += new System.EventHandler(this.btnCreditAdd_Click);
            // 
            // txtCreditRemarks
            // 
            this.txtCreditRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditRemarks.Location = new System.Drawing.Point(430, 271);
            this.txtCreditRemarks.Name = "txtCreditRemarks";
            this.txtCreditRemarks.Size = new System.Drawing.Size(492, 26);
            this.txtCreditRemarks.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(348, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = "Remarks";
            // 
            // btnDebit
            // 
            this.btnDebit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebit.Location = new System.Drawing.Point(218, 72);
            this.btnDebit.Name = "btnDebit";
            this.btnDebit.Size = new System.Drawing.Size(87, 88);
            this.btnDebit.TabIndex = 52;
            this.btnDebit.Text = "Debit >>";
            this.btnDebit.UseVisualStyleBackColor = true;
            this.btnDebit.Click += new System.EventHandler(this.btnDebit_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredit.Location = new System.Drawing.Point(218, 282);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(87, 88);
            this.btnCredit.TabIndex = 53;
            this.btnCredit.Text = "Credit >>";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // frmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1153, 528);
            this.Controls.Add(this.dgCreditItems);
            this.Controls.Add(this.btnCreditAdd);
            this.Controls.Add(this.txtCreditRemarks);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCreditAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.dgDebitItems);
            this.Controls.Add(this.btnDebitAdd);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.ddlDebitAccountNo);
            this.Controls.Add(this.txtVoucherDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TVAccountList);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.ddlCreditAccountNo);
            this.Controls.Add(this.btnSaveDebitVoucher);
            this.Controls.Add(this.txtAccountHeadID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDebit);
            this.Controls.Add(this.btnCredit);
            this.Name = "frmJournalVoucher";
            this.Tag = "JournalVoucher";
            this.Text = "Journal Voucher";
            this.Load += new System.EventHandler(this.SupplierControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCreditItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountHeadID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveDebitVoucher;
        private System.Windows.Forms.ComboBox ddlCreditAccountNo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TreeView TVAccountList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVoucherDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox ddlDebitAccountNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnDebitAdd;
        private System.Windows.Forms.DataGridView dgDebitItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCreditAmount;
        private System.Windows.Forms.DataGridView dgCreditItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnCreditAdd;
        private System.Windows.Forms.TextBox txtCreditRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDebit;
        private System.Windows.Forms.Button btnCredit;
    }
}