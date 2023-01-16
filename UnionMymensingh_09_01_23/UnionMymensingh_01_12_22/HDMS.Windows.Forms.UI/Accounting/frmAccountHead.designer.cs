namespace HDMS.Windows.Forms.UI.Accounting
{
    partial class frmAccountHead
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountHeadID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountHead = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveSupplier = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkPostingAccount = new System.Windows.Forms.CheckBox();
            this.chkCashAccount = new System.Windows.Forms.CheckBox();
            this.chkBankAccount = new System.Windows.Forms.CheckBox();
            this.ChkBalanceSheet = new System.Windows.Forms.CheckBox();
            this.ChkReceivedPayment = new System.Windows.Forms.CheckBox();
            this.ChkIncomeExpense = new System.Windows.Forms.CheckBox();
            this.ddlUpperAccountHead = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.TVAccountList = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(375, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Head ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtAccountHeadID
            // 
            this.txtAccountHeadID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAccountHeadID.Enabled = false;
            this.txtAccountHeadID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountHeadID.Location = new System.Drawing.Point(504, 74);
            this.txtAccountHeadID.Name = "txtAccountHeadID";
            this.txtAccountHeadID.Size = new System.Drawing.Size(328, 29);
            this.txtAccountHeadID.TabIndex = 1;
            this.txtAccountHeadID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.suppplierNameTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(350, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Account Head";
            // 
            // txtAdress
            // 
            this.txtAdress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAdress.Location = new System.Drawing.Point(31, 427);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(82, 29);
            this.txtAdress.TabIndex = 3;
            this.txtAdress.Visible = false;
            this.txtAdress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierAdressTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(350, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Account Head Name";
            // 
            // txtAccountHead
            // 
            this.txtAccountHead.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountHead.Location = new System.Drawing.Point(504, 200);
            this.txtAccountHead.Name = "txtAccountHead";
            this.txtAccountHead.Size = new System.Drawing.Size(328, 29);
            this.txtAccountHead.TabIndex = 5;
            this.txtAccountHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierPhoneTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(412, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // btnSaveSupplier
            // 
            this.btnSaveSupplier.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSupplier.Location = new System.Drawing.Point(515, 350);
            this.btnSaveSupplier.Name = "btnSaveSupplier";
            this.btnSaveSupplier.Size = new System.Drawing.Size(116, 41);
            this.btnSaveSupplier.TabIndex = 8;
            this.btnSaveSupplier.Text = "Save";
            this.btnSaveSupplier.UseVisualStyleBackColor = true;
            this.btnSaveSupplier.Click += new System.EventHandler(this.saveButtonSupplier_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(504, 240);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(328, 29);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierEmailTextBox_KeyPress);
            // 
            // chkPostingAccount
            // 
            this.chkPostingAccount.AutoSize = true;
            this.chkPostingAccount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkPostingAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPostingAccount.Location = new System.Drawing.Point(501, 278);
            this.chkPostingAccount.Name = "chkPostingAccount";
            this.chkPostingAccount.Size = new System.Drawing.Size(123, 21);
            this.chkPostingAccount.TabIndex = 9;
            this.chkPostingAccount.Text = "Posing Accounnt";
            this.chkPostingAccount.UseVisualStyleBackColor = false;
            // 
            // chkCashAccount
            // 
            this.chkCashAccount.AutoSize = true;
            this.chkCashAccount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkCashAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCashAccount.Location = new System.Drawing.Point(625, 278);
            this.chkCashAccount.Name = "chkCashAccount";
            this.chkCashAccount.Size = new System.Drawing.Size(112, 21);
            this.chkCashAccount.TabIndex = 10;
            this.chkCashAccount.Text = "Cash Accounnt";
            this.chkCashAccount.UseVisualStyleBackColor = false;
            // 
            // chkBankAccount
            // 
            this.chkBankAccount.AutoSize = true;
            this.chkBankAccount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkBankAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBankAccount.Location = new System.Drawing.Point(756, 278);
            this.chkBankAccount.Name = "chkBankAccount";
            this.chkBankAccount.Size = new System.Drawing.Size(111, 21);
            this.chkBankAccount.TabIndex = 11;
            this.chkBankAccount.Text = "Bank Accounnt";
            this.chkBankAccount.UseVisualStyleBackColor = false;
            // 
            // ChkBalanceSheet
            // 
            this.ChkBalanceSheet.AutoSize = true;
            this.ChkBalanceSheet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ChkBalanceSheet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBalanceSheet.Location = new System.Drawing.Point(501, 316);
            this.ChkBalanceSheet.Name = "ChkBalanceSheet";
            this.ChkBalanceSheet.Size = new System.Drawing.Size(111, 21);
            this.ChkBalanceSheet.TabIndex = 12;
            this.ChkBalanceSheet.Text = "Balance Sheet ";
            this.ChkBalanceSheet.UseVisualStyleBackColor = false;
            // 
            // ChkReceivedPayment
            // 
            this.ChkReceivedPayment.AutoSize = true;
            this.ChkReceivedPayment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ChkReceivedPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkReceivedPayment.Location = new System.Drawing.Point(625, 316);
            this.ChkReceivedPayment.Name = "ChkReceivedPayment";
            this.ChkReceivedPayment.Size = new System.Drawing.Size(132, 21);
            this.ChkReceivedPayment.TabIndex = 13;
            this.ChkReceivedPayment.Text = "Received Payment";
            this.ChkReceivedPayment.UseVisualStyleBackColor = false;
            // 
            // ChkIncomeExpense
            // 
            this.ChkIncomeExpense.AutoSize = true;
            this.ChkIncomeExpense.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ChkIncomeExpense.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkIncomeExpense.Location = new System.Drawing.Point(756, 316);
            this.ChkIncomeExpense.Name = "ChkIncomeExpense";
            this.ChkIncomeExpense.Size = new System.Drawing.Size(121, 21);
            this.ChkIncomeExpense.TabIndex = 14;
            this.ChkIncomeExpense.Text = "Income Expense";
            this.ChkIncomeExpense.UseVisualStyleBackColor = false;
            // 
            // ddlUpperAccountHead
            // 
            this.ddlUpperAccountHead.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUpperAccountHead.FormattingEnabled = true;
            this.ddlUpperAccountHead.Location = new System.Drawing.Point(504, 115);
            this.ddlUpperAccountHead.Name = "ddlUpperAccountHead";
            this.ddlUpperAccountHead.Size = new System.Drawing.Size(328, 29);
            this.ddlUpperAccountHead.TabIndex = 15;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(662, 350);
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
            this.TVAccountList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVAccountList.Location = new System.Drawing.Point(0, 0);
            this.TVAccountList.Name = "TVAccountList";
            this.TVAccountList.Size = new System.Drawing.Size(344, 528);
            this.TVAccountList.TabIndex = 17;
            this.TVAccountList.Click += new System.EventHandler(this.TVAccountList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(396, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Account Code";
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccCode.Location = new System.Drawing.Point(504, 156);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.Size = new System.Drawing.Size(160, 29);
            this.txtAccCode.TabIndex = 19;
            // 
            // frmAccountHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources.patientEntrybg;
            this.ClientSize = new System.Drawing.Size(1193, 528);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAccCode);
            this.Controls.Add(this.TVAccountList);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.ddlUpperAccountHead);
            this.Controls.Add(this.ChkIncomeExpense);
            this.Controls.Add(this.ChkReceivedPayment);
            this.Controls.Add(this.ChkBalanceSheet);
            this.Controls.Add(this.chkBankAccount);
            this.Controls.Add(this.chkCashAccount);
            this.Controls.Add(this.chkPostingAccount);
            this.Controls.Add(this.btnSaveSupplier);
            this.Controls.Add(this.txtAccountHeadID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountHead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label4);
            this.Name = "frmAccountHead";
            this.Text = "Account Setup";
            this.Load += new System.EventHandler(this.frmAccountHead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountHeadID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveSupplier;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkPostingAccount;
        private System.Windows.Forms.CheckBox chkCashAccount;
        private System.Windows.Forms.CheckBox chkBankAccount;
        private System.Windows.Forms.CheckBox ChkBalanceSheet;
        private System.Windows.Forms.CheckBox ChkReceivedPayment;
        private System.Windows.Forms.CheckBox ChkIncomeExpense;
        private System.Windows.Forms.ComboBox ddlUpperAccountHead;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TreeView TVAccountList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccCode;
    }
}