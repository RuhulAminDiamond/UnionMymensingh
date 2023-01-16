namespace HDMS.Windows.Forms.UI.Accounting
{
    partial class frmCreditVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoucherId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveDebitVoucher = new System.Windows.Forms.Button();
            this.ddlUpperAccountHead = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrevId = new System.Windows.Forms.Button();
            this.btnNextId = new System.Windows.Forms.Button();
            this.dtpVoucher = new System.Windows.Forms.DateTimePicker();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtPrevVoucher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCreditHead = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ctrlAccHeadSearch = new HDMS.Windows.Forms.UI.Accounts.CtrlAccountGLSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(45, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher No";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtVoucherId
            // 
            this.txtVoucherId.BackColor = System.Drawing.Color.White;
            this.txtVoucherId.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVoucherId.Location = new System.Drawing.Point(137, 12);
            this.txtVoucherId.Name = "txtVoucherId";
            this.txtVoucherId.Size = new System.Drawing.Size(143, 29);
            this.txtVoucherId.TabIndex = 1;
            this.txtVoucherId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucherId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(37, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cash or Bank";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label4.Location = new System.Drawing.Point(47, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // btnSaveDebitVoucher
            // 
            this.btnSaveDebitVoucher.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDebitVoucher.Location = new System.Drawing.Point(135, 551);
            this.btnSaveDebitVoucher.Name = "btnSaveDebitVoucher";
            this.btnSaveDebitVoucher.Size = new System.Drawing.Size(116, 41);
            this.btnSaveDebitVoucher.TabIndex = 8;
            this.btnSaveDebitVoucher.Text = "Save";
            this.btnSaveDebitVoucher.UseVisualStyleBackColor = true;
            this.btnSaveDebitVoucher.Click += new System.EventHandler(this.btnSaveDebitVoucher_Click);
            // 
            // ddlUpperAccountHead
            // 
            this.ddlUpperAccountHead.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUpperAccountHead.FormattingEnabled = true;
            this.ddlUpperAccountHead.Location = new System.Drawing.Point(137, 49);
            this.ddlUpperAccountHead.Name = "ddlUpperAccountHead";
            this.ddlUpperAccountHead.Size = new System.Drawing.Size(143, 27);
            this.ddlUpperAccountHead.TabIndex = 15;
            this.ddlUpperAccountHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlUpperAccountHead_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(555, 551);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 41);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Next";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(286, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Voucher Date";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.Location = new System.Drawing.Point(137, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(595, 31);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 38;
            this.label6.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(137, 150);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(152, 29);
            this.txtAmount.TabIndex = 37;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label7.Location = new System.Drawing.Point(286, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Account Head";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(138, 118);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(594, 26);
            this.txtRemarks.TabIndex = 41;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.BackgroundColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgItems.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgItems.Location = new System.Drawing.Point(137, 185);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgItems.Size = new System.Drawing.Size(595, 326);
            this.dgItems.TabIndex = 43;
            this.dgItems.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgItems_RowHeaderMouseDoubleClick);
            this.dgItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgItems_UserDeletedRow);
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
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(623, 517);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(109, 29);
            this.txtTotalAmount.TabIndex = 44;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(521, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Total Amount";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(640, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 41);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrevId
            // 
            this.btnPrevId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevId.Location = new System.Drawing.Point(256, 552);
            this.btnPrevId.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevId.Name = "btnPrevId";
            this.btnPrevId.Size = new System.Drawing.Size(40, 40);
            this.btnPrevId.TabIndex = 10012;
            this.btnPrevId.Text = "<<";
            this.btnPrevId.UseVisualStyleBackColor = true;
            this.btnPrevId.Click += new System.EventHandler(this.btnPrevId_Click);
            // 
            // btnNextId
            // 
            this.btnNextId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextId.Location = new System.Drawing.Point(300, 551);
            this.btnNextId.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextId.Name = "btnNextId";
            this.btnNextId.Size = new System.Drawing.Size(40, 40);
            this.btnNextId.TabIndex = 10011;
            this.btnNextId.Text = ">>";
            this.btnNextId.UseVisualStyleBackColor = true;
            this.btnNextId.Click += new System.EventHandler(this.btnNextId_Click);
            // 
            // dtpVoucher
            // 
            this.dtpVoucher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVoucher.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVoucher.Location = new System.Drawing.Point(390, 11);
            this.dtpVoucher.Name = "dtpVoucher";
            this.dtpVoucher.Size = new System.Drawing.Size(124, 27);
            this.dtpVoucher.TabIndex = 10013;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(345, 551);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 41);
            this.btnEdit.TabIndex = 10019;
            this.btnEdit.Text = "Edit ";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtPrevVoucher
            // 
            this.txtPrevVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPrevVoucher.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrevVoucher.Location = new System.Drawing.Point(623, 12);
            this.txtPrevVoucher.Name = "txtPrevVoucher";
            this.txtPrevVoucher.Size = new System.Drawing.Size(109, 29);
            this.txtPrevVoucher.TabIndex = 10021;
            this.txtPrevVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrevVoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrevVoucher_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label9.Location = new System.Drawing.Point(520, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 10020;
            this.label9.Text = "Prev. Voucher";
            // 
            // txtCreditHead
            // 
            this.txtCreditHead.BackColor = System.Drawing.Color.White;
            this.txtCreditHead.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCreditHead.Location = new System.Drawing.Point(390, 47);
            this.txtCreditHead.Name = "txtCreditHead";
            this.txtCreditHead.Size = new System.Drawing.Size(342, 29);
            this.txtCreditHead.TabIndex = 10022;
            this.txtCreditHead.TextChanged += new System.EventHandler(this.txtCreditHead_TextChanged);
            this.txtCreditHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditHead_KeyPress);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(454, 551);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 41);
            this.btnPrint.TabIndex = 10024;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ctrlAccHeadSearch
            // 
            this.ctrlAccHeadSearch.Location = new System.Drawing.Point(809, 429);
            this.ctrlAccHeadSearch.Name = "ctrlAccHeadSearch";
            this.ctrlAccHeadSearch.Size = new System.Drawing.Size(1003, 502);
            this.ctrlAccHeadSearch.TabIndex = 10023;
            this.ctrlAccHeadSearch.Visible = false;
            // 
            // frmCreditVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1153, 649);
            this.Controls.Add(this.ctrlAccHeadSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtCreditHead);
            this.Controls.Add(this.txtPrevVoucher);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dtpVoucher);
            this.Controls.Add(this.btnPrevId);
            this.Controls.Add(this.btnNextId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.ddlUpperAccountHead);
            this.Controls.Add(this.btnSaveDebitVoucher);
            this.Controls.Add(this.txtVoucherId);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreditVoucher";
            this.Tag = "CreditVoucher";
            this.Text = "Receipt/Credit Voucher";
            this.Load += new System.EventHandler(this.SupplierControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVoucherId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveDebitVoucher;
        private System.Windows.Forms.ComboBox ddlUpperAccountHead;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrevId;
        private System.Windows.Forms.Button btnNextId;
        private System.Windows.Forms.DateTimePicker dtpVoucher;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtPrevVoucher;
        private System.Windows.Forms.Label label9;
        private Accounts.CtrlAccountGLSearchControl ctrlAccHeadSearch;
        private System.Windows.Forms.TextBox txtCreditHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button btnPrint;
    }
}