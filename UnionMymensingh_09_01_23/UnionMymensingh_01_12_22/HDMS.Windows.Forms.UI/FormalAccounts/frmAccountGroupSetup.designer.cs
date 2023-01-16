using HDMS.Model.Accounting.VModel;
using Models.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    partial class frmAccountGroupSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountGroupSetup));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountHeadName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.TVAccountList = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlAccHeadSearch = new HDMS.Windows.Forms.UI.Accounts.ctrlAccountGroupSearchControl();
            this.chkSummaryForTrialBalance = new System.Windows.Forms.CheckBox();
            this.chkIsSummaryForLedger = new System.Windows.Forms.CheckBox();
            this.txtParentHead = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(30, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Parent Head";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(42, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sub Group Name";
            // 
            // txtAccountHeadName
            // 
            this.txtAccountHeadName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountHeadName.Location = new System.Drawing.Point(171, 205);
            this.txtAccountHeadName.Name = "txtAccountHeadName";
            this.txtAccountHeadName.Size = new System.Drawing.Size(515, 29);
            this.txtAccountHeadName.TabIndex = 5;
            this.txtAccountHeadName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierPhoneTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(79, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(169, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 41);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(171, 245);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(515, 29);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplierEmailTextBox_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(439, 323);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(231, 41);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update Current Selection";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TVAccountList
            // 
            this.TVAccountList.CheckBoxes = true;
            this.TVAccountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TVAccountList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVAccountList.Location = new System.Drawing.Point(3, 64);
            this.TVAccountList.Name = "TVAccountList";
            this.TVAccountList.Size = new System.Drawing.Size(374, 548);
            this.TVAccountList.TabIndex = 17;
            this.TVAccountList.DoubleClick += new System.EventHandler(this.TVAccountList_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(75, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Group Code";
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccCode.Location = new System.Drawing.Point(171, 161);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.Size = new System.Drawing.Size(160, 29);
            this.txtAccCode.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(306, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 41);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.92456F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.07544F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1290, 621);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TVAccountList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.06036F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.93964F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 615);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(109, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Charts Of Accounts";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ctrlAccHeadSearch);
            this.panel1.Controls.Add(this.chkSummaryForTrialBalance);
            this.panel1.Controls.Add(this.chkIsSummaryForLedger);
            this.panel1.Controls.Add(this.txtAccountHeadName);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAccCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtParentHead);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(389, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 615);
            this.panel1.TabIndex = 19;
            // 
            // ctrlAccHeadSearch
            // 
            this.ctrlAccHeadSearch.Location = new System.Drawing.Point(97, 93);
            this.ctrlAccHeadSearch.Name = "ctrlAccHeadSearch";
            this.ctrlAccHeadSearch.Size = new System.Drawing.Size(589, 587);
            this.ctrlAccHeadSearch.TabIndex = 21;
            this.ctrlAccHeadSearch.Visible = false;
            this.ctrlAccHeadSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<VMAccountHeads>.SearchEscapeEventHandler(this.ctrlAccHeadSearch_SearchEsacaped);
            // 
            // chkSummaryForTrialBalance
            // 
            this.chkSummaryForTrialBalance.AutoSize = true;
            this.chkSummaryForTrialBalance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSummaryForTrialBalance.Location = new System.Drawing.Point(356, 289);
            this.chkSummaryForTrialBalance.Name = "chkSummaryForTrialBalance";
            this.chkSummaryForTrialBalance.Size = new System.Drawing.Size(204, 19);
            this.chkSummaryForTrialBalance.TabIndex = 23;
            this.chkSummaryForTrialBalance.Text = "Summary Head For Trial Balance";
            this.chkSummaryForTrialBalance.UseVisualStyleBackColor = true;
            // 
            // chkIsSummaryForLedger
            // 
            this.chkIsSummaryForLedger.AutoSize = true;
            this.chkIsSummaryForLedger.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsSummaryForLedger.Location = new System.Drawing.Point(171, 289);
            this.chkIsSummaryForLedger.Name = "chkIsSummaryForLedger";
            this.chkIsSummaryForLedger.Size = new System.Drawing.Size(167, 19);
            this.chkIsSummaryForLedger.TabIndex = 22;
            this.chkIsSummaryForLedger.Text = "Summary Head For Ledger";
            this.chkIsSummaryForLedger.UseVisualStyleBackColor = true;
            // 
            // txtParentHead
            // 
            this.txtParentHead.BackColor = System.Drawing.Color.White;
            this.txtParentHead.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtParentHead.Location = new System.Drawing.Point(171, 119);
            this.txtParentHead.Name = "txtParentHead";
            this.txtParentHead.Size = new System.Drawing.Size(515, 29);
            this.txtParentHead.TabIndex = 1;
            this.txtParentHead.TextChanged += new System.EventHandler(this.txtParentHead_TextChanged);
            // 
            // frmAccountGroupSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1290, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountGroupSetup";
            this.Text = "Account Setup";
            this.Load += new System.EventHandler(this.frmAccountHead_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccountHeadName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TreeView TVAccountList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParentHead;
        private Accounts.ctrlAccountGroupSearchControl ctrlAccHeadSearch;
        private System.Windows.Forms.CheckBox chkSummaryForTrialBalance;
        private System.Windows.Forms.CheckBox chkIsSummaryForLedger;
    }
}