namespace HDMS.Windows.Forms.UI.Pharmacy
{
    partial class frmViewMedicineBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewMedicineBill));
            this.dgBill = new System.Windows.Forms.DataGridView();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintLedger = new System.Windows.Forms.Button();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.txtSearchByName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBill)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBill
            // 
            this.dgBill.AllowUserToAddRows = false;
            this.dgBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNo,
            this.FullName,
            this.CabinNo,
            this.MedicineBill});
            this.dgBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBill.Location = new System.Drawing.Point(0, 44);
            this.dgBill.MultiSelect = false;
            this.dgBill.Name = "dgBill";
            this.dgBill.Size = new System.Drawing.Size(1095, 492);
            this.dgBill.TabIndex = 0;
            this.dgBill.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBill_RowHeaderMouseDoubleClick);
            // 
            // BillNo
            // 
            this.BillNo.DataPropertyName = "BillNo";
            this.BillNo.HeaderText = "Bill No";
            this.BillNo.Name = "BillNo";
            this.BillNo.Width = 120;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Name";
            this.FullName.Name = "FullName";
            this.FullName.Width = 350;
            // 
            // CabinNo
            // 
            this.CabinNo.DataPropertyName = "CabinNo";
            this.CabinNo.HeaderText = "CabinNo";
            this.CabinNo.Name = "CabinNo";
            this.CabinNo.Width = 120;
            // 
            // MedicineBill
            // 
            this.MedicineBill.DataPropertyName = "MedicineBill";
            this.MedicineBill.HeaderText = "Medicine Bill";
            this.MedicineBill.Name = "MedicineBill";
            this.MedicineBill.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrintLedger);
            this.panel1.Controls.Add(this.lblTotalBill);
            this.panel1.Controls.Add(this.lblTotalPatient);
            this.panel1.Controls.Add(this.btnRefreshList);
            this.panel1.Controls.Add(this.btnViewDetails);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 536);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 62);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnPrintLedger
            // 
            this.btnPrintLedger.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintLedger.Location = new System.Drawing.Point(333, 7);
            this.btnPrintLedger.Name = "btnPrintLedger";
            this.btnPrintLedger.Size = new System.Drawing.Size(165, 31);
            this.btnPrintLedger.TabIndex = 10037;
            this.btnPrintLedger.Text = "Print Ledger";
            this.btnPrintLedger.UseVisualStyleBackColor = true;
            this.btnPrintLedger.Click += new System.EventHandler(this.btnPrintLedger_Click);
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Red;
            this.lblTotalBill.Location = new System.Drawing.Point(668, 13);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(46, 18);
            this.lblTotalBill.TabIndex = 4;
            this.lblTotalBill.Text = "label1";
            // 
            // lblTotalPatient
            // 
            this.lblTotalPatient.AutoSize = true;
            this.lblTotalPatient.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatient.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPatient.Location = new System.Drawing.Point(520, 13);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(46, 18);
            this.lblTotalPatient.TabIndex = 3;
            this.lblTotalPatient.Text = "label1";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(162, 6);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(153, 31);
            this.btnRefreshList.TabIndex = 2;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Location = new System.Drawing.Point(739, 7);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(153, 31);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "Print Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Visible = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbDept);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBillNo);
            this.panel2.Controls.Add(this.cmdShow);
            this.panel2.Controls.Add(this.txtSearchByName);
            this.panel2.Controls.Add(this.txtSearchByCabin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1095, 44);
            this.panel2.TabIndex = 2;
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(495, 10);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(219, 26);
            this.cmbDept.TabIndex = 10022;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Select Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(722, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Admission/Bill No";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(848, 10);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(139, 26);
            this.txtBillNo.TabIndex = 22;
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(993, 10);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(79, 29);
            this.cmdShow.TabIndex = 21;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByName.Location = new System.Drawing.Point(12, 12);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PlaceHolderText = "Search by name";
            this.txtSearchByName.Size = new System.Drawing.Size(221, 26);
            this.txtSearchByName.TabIndex = 6;
            this.txtSearchByName.Text = "Search by name";
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(239, 10);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(129, 26);
            this.txtSearchByCabin.TabIndex = 5;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // frmViewMedicineBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 598);
            this.Controls.Add(this.dgBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewMedicineBill";
            this.Text = "Medicine Bill";
            this.Load += new System.EventHandler(this.frmViewMedicineBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineBill;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.Label lblTotalBill;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Panel panel2;
        private Controls.PlaceHolderTextBox txtSearchByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Button btnPrintLedger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDept;
    }
}