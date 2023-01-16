namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmUpdateSaleRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateSaleRate));
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgStocks = new System.Windows.Forms.DataGridView();
            this.GenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.txtSaleRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlProductSearch = new HDMS.Windows.Forms.UI.Controls.PhProductInfoSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(172, 29);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(736, 29);
            this.txtProductCode.TabIndex = 10035;
            this.txtProductCode.Text = " ";
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 10034;
            this.label3.Text = "Product Name";
            // 
            // dgStocks
            // 
            this.dgStocks.AllowUserToAddRows = false;
            this.dgStocks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GenName,
            this.BoxNo,
            this.PRate,
            this.SRate,
            this.BatchNo,
            this.ExpDate});
            this.dgStocks.Location = new System.Drawing.Point(172, 75);
            this.dgStocks.Name = "dgStocks";
            this.dgStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStocks.Size = new System.Drawing.Size(736, 337);
            this.dgStocks.TabIndex = 10037;
            this.dgStocks.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgStocks_RowHeaderMouseClick);
            // 
            // GenName
            // 
            this.GenName.DataPropertyName = "Name";
            this.GenName.HeaderText = "LotNo";
            this.GenName.Name = "GenName";
            this.GenName.Width = 150;
            // 
            // BoxNo
            // 
            this.BoxNo.DataPropertyName = "BoxNo";
            this.BoxNo.HeaderText = "Stock";
            this.BoxNo.Name = "BoxNo";
            // 
            // PRate
            // 
            this.PRate.HeaderText = "PRate";
            this.PRate.Name = "PRate";
            this.PRate.Width = 120;
            // 
            // SRate
            // 
            this.SRate.HeaderText = "S. Rate";
            this.SRate.Name = "SRate";
            this.SRate.Width = 120;
            // 
            // BatchNo
            // 
            this.BatchNo.HeaderText = "Batch No";
            this.BatchNo.Name = "BatchNo";
            // 
            // ExpDate
            // 
            this.ExpDate.HeaderText = "Expire Date";
            this.ExpDate.Name = "ExpDate";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(785, 476);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 35);
            this.btnUpdate.TabIndex = 10038;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 10039;
            this.label1.Text = "Lot No";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Enabled = false;
            this.txtLotNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotNo.Location = new System.Drawing.Point(223, 430);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(93, 26);
            this.txtLotNo.TabIndex = 10040;
            // 
            // txtSaleRate
            // 
            this.txtSaleRate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleRate.Location = new System.Drawing.Point(512, 430);
            this.txtSaleRate.Name = "txtSaleRate";
            this.txtSaleRate.Size = new System.Drawing.Size(73, 26);
            this.txtSaleRate.TabIndex = 10042;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 10041;
            this.label2.Text = "Sale Rate";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(642, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 35);
            this.btnClose.TabIndex = 10043;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPRate
            // 
            this.txtPRate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRate.Location = new System.Drawing.Point(376, 430);
            this.txtPRate.Name = "txtPRate";
            this.txtPRate.Size = new System.Drawing.Size(66, 26);
            this.txtPRate.TabIndex = 10045;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(325, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 10044;
            this.label4.Text = "P. Rate";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchNo.Location = new System.Drawing.Point(655, 430);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(85, 26);
            this.txtBatchNo.TabIndex = 10047;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(591, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 10046;
            this.label5.Text = "Batch No";
            // 
            // txtExpDate
            // 
            this.txtExpDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpDate.Location = new System.Drawing.Point(815, 430);
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(93, 26);
            this.txtExpDate.TabIndex = 10049;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(748, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 10048;
            this.label6.Text = "Exp. Date";
            // 
            // ctrlProductSearch
            // 
            this.ctrlProductSearch.Location = new System.Drawing.Point(172, 527);
            this.ctrlProductSearch.Name = "ctrlProductSearch";
            this.ctrlProductSearch.Size = new System.Drawing.Size(736, 434);
            this.ctrlProductSearch.TabIndex = 10036;
            this.ctrlProductSearch.Visible = false;
            this.ctrlProductSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Pharmacy.ViewModels.VWPhProductInfo>.SearchEscapeEventHandler(this.ctrlProductSearch_SearchEsacaped);
            // 
            // frmUpdateSaleRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 608);
            this.Controls.Add(this.ctrlProductSearch);
            this.Controls.Add(this.txtExpDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSaleRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgStocks);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpdateSaleRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Sale Rate";
            this.Load += new System.EventHandler(this.frmUpdateSaleRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PhProductInfoSearchControl ctrlProductSearch;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgStocks;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.TextBox txtSaleRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpDate;
        private System.Windows.Forms.TextBox txtPRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExpDate;
        private System.Windows.Forms.Label label6;
    }
}