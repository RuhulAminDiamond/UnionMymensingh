namespace HDMS.Windows.Forms.UI.ShareHolder
{
    partial class frmShareTransferInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShareTransferInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTransferFrom = new System.Windows.Forms.TextBox();
            this.txtSellingAmount = new System.Windows.Forms.TextBox();
            this.txtTransferTo = new System.Windows.Forms.TextBox();
            this.dtptfDob = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvShareTransfer = new System.Windows.Forms.DataGridView();
            this.TDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellShareAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransferrerShareNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiverShareNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransferrerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShareCountStart = new System.Windows.Forms.TextBox();
            this.txtShareCountEnd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlShareHolderFrom = new HDMS.Windows.Forms.UI.Controls.ShareHolderSearchControl();
            this.ctrlShareHolderTo = new HDMS.Windows.Forms.UI.Controls.ShareHolderSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transfer From (Share)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Share Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transfer To (Share)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.ForeColor = System.Drawing.Color.Green;
            this.btnTransfer.Location = new System.Drawing.Point(169, 338);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 39);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtTransferFrom
            // 
            this.txtTransferFrom.Location = new System.Drawing.Point(169, 58);
            this.txtTransferFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransferFrom.Name = "txtTransferFrom";
            this.txtTransferFrom.Size = new System.Drawing.Size(362, 27);
            this.txtTransferFrom.TabIndex = 5;
            this.txtTransferFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransferFrom_KeyPress);
            // 
            // txtSellingAmount
            // 
            this.txtSellingAmount.Location = new System.Drawing.Point(169, 93);
            this.txtSellingAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtSellingAmount.Name = "txtSellingAmount";
            this.txtSellingAmount.Size = new System.Drawing.Size(132, 27);
            this.txtSellingAmount.TabIndex = 6;
            this.txtSellingAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingAmount_KeyPress);
            // 
            // txtTransferTo
            // 
            this.txtTransferTo.Location = new System.Drawing.Point(169, 139);
            this.txtTransferTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransferTo.Name = "txtTransferTo";
            this.txtTransferTo.Size = new System.Drawing.Size(362, 27);
            this.txtTransferTo.TabIndex = 7;
            this.txtTransferTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransferTo_KeyPress);
            // 
            // dtptfDob
            // 
            this.dtptfDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptfDob.Location = new System.Drawing.Point(169, 229);
            this.dtptfDob.Margin = new System.Windows.Forms.Padding(4);
            this.dtptfDob.Name = "dtptfDob";
            this.dtptfDob.Size = new System.Drawing.Size(132, 27);
            this.dtptfDob.TabIndex = 8;
            this.dtptfDob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtptfDob_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(299, 338);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(169, 183);
            this.txtReceiptNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(132, 27);
            this.txtReceiptNo.TabIndex = 6;
            this.txtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Receipt Number";
            // 
            // dgvShareTransfer
            // 
            this.dgvShareTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShareTransfer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShareTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TDate,
            this.ReceiptNo,
            this.SellShareAmount,
            this.TransferrerShareNo,
            this.ReceiverShareNo,
            this.TransferrerName,
            this.ReceiverName});
            this.dgvShareTransfer.Location = new System.Drawing.Point(552, 58);
            this.dgvShareTransfer.Name = "dgvShareTransfer";
            this.dgvShareTransfer.Size = new System.Drawing.Size(806, 616);
            this.dgvShareTransfer.TabIndex = 11;
            this.dgvShareTransfer.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShareTransfer_RowHeaderMouseClick);
            // 
            // TDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.TDate.HeaderText = "Date";
            this.TDate.Name = "TDate";
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.HeaderText = "Receipt no.";
            this.ReceiptNo.Name = "ReceiptNo";
            // 
            // SellShareAmount
            // 
            this.SellShareAmount.HeaderText = "Share Quantity";
            this.SellShareAmount.Name = "SellShareAmount";
            // 
            // TransferrerShareNo
            // 
            this.TransferrerShareNo.HeaderText = "Transferrer\'s ShareNo.";
            this.TransferrerShareNo.Name = "TransferrerShareNo";
            // 
            // ReceiverShareNo
            // 
            this.ReceiverShareNo.HeaderText = "Receiver\'s ShareNo.";
            this.ReceiverShareNo.Name = "ReceiverShareNo";
            // 
            // TransferrerName
            // 
            this.TransferrerName.HeaderText = "Transferrer\'s Name";
            this.TransferrerName.Name = "TransferrerName";
            // 
            // ReceiverName
            // 
            this.ReceiverName.HeaderText = "Receiver\'s Name";
            this.ReceiverName.Name = "ReceiverName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 293);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Share Count";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 269);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 267);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "To";
            // 
            // txtShareCountStart
            // 
            this.txtShareCountStart.Location = new System.Drawing.Point(169, 290);
            this.txtShareCountStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtShareCountStart.Name = "txtShareCountStart";
            this.txtShareCountStart.Size = new System.Drawing.Size(132, 27);
            this.txtShareCountStart.TabIndex = 6;
            this.txtShareCountStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingAmount_KeyPress);
            // 
            // txtShareCountEnd
            // 
            this.txtShareCountEnd.Location = new System.Drawing.Point(331, 290);
            this.txtShareCountEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txtShareCountEnd.Name = "txtShareCountEnd";
            this.txtShareCountEnd.Size = new System.Drawing.Size(132, 27);
            this.txtShareCountEnd.TabIndex = 6;
            this.txtShareCountEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingAmount_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 293);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "-";
            // 
            // ctrlShareHolderFrom
            // 
            this.ctrlShareHolderFrom.Location = new System.Drawing.Point(229, 521);
            this.ctrlShareHolderFrom.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShareHolderFrom.Name = "ctrlShareHolderFrom";
            this.ctrlShareHolderFrom.Size = new System.Drawing.Size(527, 573);
            this.ctrlShareHolderFrom.TabIndex = 10;
            this.ctrlShareHolderFrom.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ShareHolder.VMshareTransfer>.SearchEscapeEventHandler(this.ctrlShareHolderFrom_SearchEsacaped);
            // 
            // ctrlShareHolderTo
            // 
            this.ctrlShareHolderTo.Location = new System.Drawing.Point(229, 521);
            this.ctrlShareHolderTo.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShareHolderTo.Name = "ctrlShareHolderTo";
            this.ctrlShareHolderTo.Size = new System.Drawing.Size(527, 459);
            this.ctrlShareHolderTo.TabIndex = 9;
            this.ctrlShareHolderTo.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ShareHolder.VMshareTransfer>.SearchEscapeEventHandler(this.ctrlShareHolderTo_SearchEsacaped);
            // 
            // frmShareTransferInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.dgvShareTransfer);
            this.Controls.Add(this.ctrlShareHolderFrom);
            this.Controls.Add(this.ctrlShareHolderTo);
            this.Controls.Add(this.dtptfDob);
            this.Controls.Add(this.txtTransferTo);
            this.Controls.Add(this.txtShareCountEnd);
            this.Controls.Add(this.txtShareCountStart);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.txtSellingAmount);
            this.Controls.Add(this.txtTransferFrom);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShareTransferInfo";
            this.Text = "Share Transfer  Window";
            this.Load += new System.EventHandler(this.frmShareTransferInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtTransferFrom;
        private System.Windows.Forms.TextBox txtSellingAmount;
        private System.Windows.Forms.TextBox txtTransferTo;
        private System.Windows.Forms.DateTimePicker dtptfDob;
        private Controls.ShareHolderSearchControl ctrlShareHolderTo;
        private Controls.ShareHolderSearchControl ctrlShareHolderFrom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvShareTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellShareAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransferrerShareNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiverShareNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransferrerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiverName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShareCountStart;
        private System.Windows.Forms.TextBox txtShareCountEnd;
        private System.Windows.Forms.Label label9;
    }
}