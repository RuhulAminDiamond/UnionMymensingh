namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmPhStockReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhStockReport));
            this.dgStock = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StckAvail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtfrm = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrintPreviewOpClosing = new System.Windows.Forms.Button();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchByName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgStock
            // 
            this.dgStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.PPrice,
            this.SPrice,
            this.StckAvail,
            this.TPValue,
            this.TSValue});
            this.dgStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStock.Location = new System.Drawing.Point(3, 44);
            this.dgStock.Name = "dgStock";
            this.dgStock.Size = new System.Drawing.Size(1282, 554);
            this.dgStock.TabIndex = 0;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            // 
            // BrandName
            // 
            this.BrandName.DataPropertyName = "BrandName";
            this.BrandName.HeaderText = "Brand Name";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 350;
            // 
            // PPrice
            // 
            this.PPrice.DataPropertyName = "PPrice";
            this.PPrice.HeaderText = "P.Price";
            this.PPrice.Name = "PPrice";
            this.PPrice.Width = 80;
            // 
            // SPrice
            // 
            this.SPrice.DataPropertyName = "SPrice";
            this.SPrice.HeaderText = "S.Price";
            this.SPrice.Name = "SPrice";
            this.SPrice.Width = 80;
            // 
            // StckAvail
            // 
            this.StckAvail.DataPropertyName = "StockAvail";
            this.StckAvail.HeaderText = "Stck. Avail";
            this.StckAvail.Name = "StckAvail";
            // 
            // TPValue
            // 
            this.TPValue.DataPropertyName = "TPValue";
            this.TPValue.HeaderText = "T.P.Value";
            this.TPValue.Name = "TPValue";
            // 
            // TSValue
            // 
            this.TSValue.DataPropertyName = "TSValue";
            this.TSValue.HeaderText = "T.S.Value";
            this.TSValue.Name = "TSValue";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgStock, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.821963F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.17804F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1288, 647);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel3.ColumnCount = 12;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.54386F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.45614F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTotalItems, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtStock, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPrintPreview, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtfrm, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPrintPreviewOpClosing, 10, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtto, 9, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 605);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1282, 38);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Items";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.Location = new System.Drawing.Point(83, 10);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(0, 18);
            this.lblTotalItems.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Where Stock >=";
            // 
            // txtStock
            // 
            this.txtStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(329, 7);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(70, 23);
            this.txtStock.TabIndex = 4;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(405, 3);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(196, 32);
            this.btnPrintPreview.TabIndex = 2;
            this.btnPrintPreview.Text = "Print Preview Current Stock";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(611, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date from";
            // 
            // dtfrm
            // 
            this.dtfrm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrm.Location = new System.Drawing.Point(696, 9);
            this.dtfrm.Name = "dtfrm";
            this.dtfrm.Size = new System.Drawing.Size(112, 20);
            this.dtfrm.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(833, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date to";
            // 
            // btnPrintPreviewOpClosing
            // 
            this.btnPrintPreviewOpClosing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintPreviewOpClosing.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreviewOpClosing.Location = new System.Drawing.Point(1034, 3);
            this.btnPrintPreviewOpClosing.Name = "btnPrintPreviewOpClosing";
            this.btnPrintPreviewOpClosing.Size = new System.Drawing.Size(190, 32);
            this.btnPrintPreviewOpClosing.TabIndex = 5;
            this.btnPrintPreviewOpClosing.Text = "Print Preview Opening Closing";
            this.btnPrintPreviewOpClosing.UseVisualStyleBackColor = true;
            this.btnPrintPreviewOpClosing.Click += new System.EventHandler(this.btnPrintPreviewOpClosing_Click);
            // 
            // dtto
            // 
            this.dtto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(896, 9);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(125, 20);
            this.dtto.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.tableLayoutPanel2.Controls.Add(this.cmbOutlet, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSearchByName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbManufacturer, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1288, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbOutlet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(353, 8);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(115, 28);
            this.cmbOutlet.TabIndex = 20;
            this.cmbOutlet.SelectedIndexChanged += new System.EventHandler(this.cmbOutlet_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(474, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 30);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(258, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select Outlet";
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchByName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByName.Location = new System.Drawing.Point(573, 9);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PlaceHolderText = "Search by name";
            this.txtSearchByName.Size = new System.Drawing.Size(240, 26);
            this.txtSearchByName.TabIndex = 22;
            this.txtSearchByName.Text = "Search by name";
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbManufacturer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(982, 9);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(303, 26);
            this.cmbManufacturer.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(831, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Select Manufacturer";
            // 
            // frmPhStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 647);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhStockReport";
            this.Text = "Pharmacy Stock Report";
            this.Load += new System.EventHandler(this.frmPhStockReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStock)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalItems;
        private Controls.PlaceHolderTextBox txtSearchByName;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StckAvail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TPValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TSValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnPrintPreviewOpClosing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtfrm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label7;
    }
}