namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmHpPackageSubItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHpPackageSubItem));
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgPkgSubItems = new System.Windows.Forms.DataGridView();
            this.SubGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PkgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPackages = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPkgAmount = new System.Windows.Forms.TextBox();
            this.ctrlServicetem = new HDMS.Windows.Forms.UI.Controls.HospitalBillItemSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgPkgSubItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(154, 54);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(499, 25);
            this.txtName.TabIndex = 27;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(248, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Amount";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(339, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(430, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // dgPkgSubItems
            // 
            this.dgPkgSubItems.AllowUserToAddRows = false;
            this.dgPkgSubItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgPkgSubItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPkgSubItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubGroupId,
            this.SGName,
            this.PkgTotal});
            this.dgPkgSubItems.Location = new System.Drawing.Point(87, 170);
            this.dgPkgSubItems.Name = "dgPkgSubItems";
            this.dgPkgSubItems.Size = new System.Drawing.Size(780, 327);
            this.dgPkgSubItems.TabIndex = 22;
            this.dgPkgSubItems.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPkgSubItems_RowHeaderMouseClick);
            // 
            // SubGroupId
            // 
            this.SubGroupId.DataPropertyName = "SubGroupId";
            this.SubGroupId.HeaderText = "Id";
            this.SubGroupId.Name = "SubGroupId";
            // 
            // SGName
            // 
            this.SGName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SGName.DataPropertyName = "Name";
            this.SGName.HeaderText = "Sub. Item Name";
            this.SGName.Name = "SGName";
            // 
            // PkgTotal
            // 
            this.PkgTotal.HeaderText = "Amount";
            this.PkgTotal.Name = "PkgTotal";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(154, 122);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(153, 87);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(170, 25);
            this.txtAmount.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Service Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select Package";
            // 
            // cmbPackages
            // 
            this.cmbPackages.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPackages.FormattingEnabled = true;
            this.cmbPackages.Location = new System.Drawing.Point(154, 19);
            this.cmbPackages.Name = "cmbPackages";
            this.cmbPackages.Size = new System.Drawing.Size(332, 27);
            this.cmbPackages.TabIndex = 28;
            this.cmbPackages.SelectedIndexChanged += new System.EventHandler(this.cmbPackages_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "Package Amount";
            // 
            // txtPkgAmount
            // 
            this.txtPkgAmount.Enabled = false;
            this.txtPkgAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgAmount.Location = new System.Drawing.Point(697, 510);
            this.txtPkgAmount.Name = "txtPkgAmount";
            this.txtPkgAmount.Size = new System.Drawing.Size(170, 25);
            this.txtPkgAmount.TabIndex = 38;
            // 
            // ctrlServicetem
            // 
            this.ctrlServicetem.Location = new System.Drawing.Point(121, 12);
            this.ctrlServicetem.Name = "ctrlServicetem";
            this.ctrlServicetem.Size = new System.Drawing.Size(505, 500);
            this.ctrlServicetem.TabIndex = 37;
            this.ctrlServicetem.Visible = false;
            this.ctrlServicetem.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ServiceHead>.SearchEscapeEventHandler(this.ctrlServicetem_SearchEsacaped);
            // 
            // frmHpPackageSubItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 647);
            this.Controls.Add(this.ctrlServicetem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPkgAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPackages);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgPkgSubItems);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHpPackageSubItem";
            this.Text = "Hp. Package Cost Distribution";
            this.Load += new System.EventHandler(this.frmHpPackageSubItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPkgSubItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgPkgSubItems;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPackages;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PkgTotal;
        private Controls.HospitalBillItemSearchControl ctrlServicetem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPkgAmount;
    }
}