namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmIPDInvestigations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIPDInvestigations));
            this.dgBill = new System.Windows.Forms.DataGridView();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvestigationBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.radCurrent = new System.Windows.Forms.RadioButton();
            this.txtSearchByName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
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
            this.InvestigationBill});
            this.dgBill.Location = new System.Drawing.Point(0, 44);
            this.dgBill.MultiSelect = false;
            this.dgBill.Name = "dgBill";
            this.dgBill.Size = new System.Drawing.Size(1144, 573);
            this.dgBill.TabIndex = 3;
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
            // InvestigationBill
            // 
            this.InvestigationBill.DataPropertyName = "InvestigationBill";
            this.InvestigationBill.HeaderText = "Investigation Bill";
            this.InvestigationBill.Name = "InvestigationBill";
            this.InvestigationBill.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalBill);
            this.panel1.Controls.Add(this.lblTotalPatient);
            this.panel1.Controls.Add(this.btnRefreshList);
            this.panel1.Controls.Add(this.btnViewDetails);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 62);
            this.panel1.TabIndex = 4;
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Red;
            this.lblTotalBill.Location = new System.Drawing.Point(668, 23);
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
            this.lblTotalPatient.Location = new System.Drawing.Point(520, 23);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(46, 18);
            this.lblTotalPatient.TabIndex = 3;
            this.lblTotalPatient.Text = "label1";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.Location = new System.Drawing.Point(162, 16);
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
            this.btnViewDetails.Location = new System.Drawing.Point(342, -10000);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(153, 10);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "Print Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close Me";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(373, 12);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(135, 26);
            this.txtSearchByCabin.TabIndex = 5;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBillNo);
            this.panel2.Controls.Add(this.cmdShow);
            this.panel2.Controls.Add(this.radCurrent);
            this.panel2.Controls.Add(this.txtSearchByName);
            this.panel2.Controls.Add(this.txtSearchByCabin);
            this.panel2.Location = new System.Drawing.Point(0, -6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1144, 44);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Admission/Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(644, 12);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(188, 26);
            this.txtBillNo.TabIndex = 19;
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(842, 11);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(105, 29);
            this.cmdShow.TabIndex = 18;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // radCurrent
            // 
            this.radCurrent.AutoSize = true;
            this.radCurrent.Checked = true;
            this.radCurrent.Location = new System.Drawing.Point(12, 16);
            this.radCurrent.Name = "radCurrent";
            this.radCurrent.Size = new System.Drawing.Size(95, 17);
            this.radCurrent.TabIndex = 7;
            this.radCurrent.TabStop = true;
            this.radCurrent.Text = "Current Patient";
            this.radCurrent.UseVisualStyleBackColor = true;
            this.radCurrent.CheckedChanged += new System.EventHandler(this.radCurrent_CheckedChanged);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchByName.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByName.Location = new System.Drawing.Point(113, 12);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.PlaceHolderText = "Search by name";
            this.txtSearchByName.Size = new System.Drawing.Size(245, 26);
            this.txtSearchByName.TabIndex = 6;
            this.txtSearchByName.Text = "Search by name";
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // frmIPDInvestigations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 699);
            this.Controls.Add(this.dgBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIPDInvestigations";
            this.Text = "IPD Investigations";
            this.Load += new System.EventHandler(this.frmIPDInvestigations_Load);
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
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnClose;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Panel panel2;
        private Controls.PlaceHolderTextBox txtSearchByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvestigationBill;
        private System.Windows.Forms.RadioButton radCurrent;
        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillNo;
    }
}