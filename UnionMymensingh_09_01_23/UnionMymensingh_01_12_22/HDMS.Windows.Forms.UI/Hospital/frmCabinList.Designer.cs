namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmCabinList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCabinList));
            this.dgCabin = new System.Windows.Forms.DataGridView();
            this.CabinId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Booked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCabin = new System.Windows.Forms.TextBox();
            this.dgFreeCabins = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFreeCabins)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCabin
            // 
            this.dgCabin.AllowUserToAddRows = false;
            this.dgCabin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCabin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CabinId,
            this.CabinNo,
            this.Description,
            this.Rent,
            this.Location,
            this.Booked});
            this.dgCabin.Location = new System.Drawing.Point(23, 47);
            this.dgCabin.Name = "dgCabin";
            this.dgCabin.RowTemplate.Height = 35;
            this.dgCabin.Size = new System.Drawing.Size(742, 568);
            this.dgCabin.TabIndex = 0;
            this.dgCabin.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgCabin_RowHeaderMouseClick);
            // 
            // CabinId
            // 
            this.CabinId.DataPropertyName = "CabinId";
            this.CabinId.HeaderText = "Id";
            this.CabinId.Name = "CabinId";
            this.CabinId.Width = 50;
            // 
            // CabinNo
            // 
            this.CabinNo.DataPropertyName = "CabinNo";
            this.CabinNo.HeaderText = "CabinNo";
            this.CabinNo.Name = "CabinNo";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 250;
            // 
            // Rent
            // 
            this.Rent.DataPropertyName = "Rent";
            this.Rent.HeaderText = "Rent";
            this.Rent.Name = "Rent";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Floor";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Booked
            // 
            this.Booked.DataPropertyName = "Booked";
            this.Booked.HeaderText = "Status";
            this.Booked.Name = "Booked";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "--Select----",
            "Booked",
            "Free"});
            this.cmbStatus.Location = new System.Drawing.Point(358, -100);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(161, 28);
            this.cmbStatus.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(538, -100);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(218, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Change Book State";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selected Cabin";
            // 
            // txtCabin
            // 
            this.txtCabin.Enabled = false;
            this.txtCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabin.Location = new System.Drawing.Point(184, 11);
            this.txtCabin.Name = "txtCabin";
            this.txtCabin.Size = new System.Drawing.Size(150, 27);
            this.txtCabin.TabIndex = 5;
            // 
            // dgFreeCabins
            // 
            this.dgFreeCabins.AllowUserToAddRows = false;
            this.dgFreeCabins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFreeCabins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgFreeCabins.Location = new System.Drawing.Point(781, 91);
            this.dgFreeCabins.Name = "dgFreeCabins";
            this.dgFreeCabins.RowTemplate.Height = 35;
            this.dgFreeCabins.Size = new System.Drawing.Size(459, 532);
            this.dgFreeCabins.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Floor no";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CabinNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Free list";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Total free cabin";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Free cabin list by floor.";
            // 
            // frmCabinList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 678);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgFreeCabins);
            this.Controls.Add(this.txtCabin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dgCabin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCabinList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabin List";
            this.Load += new System.EventHandler(this.frmCabinList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCabin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFreeCabins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCabin;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCabin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Booked;
        private System.Windows.Forms.DataGridView dgFreeCabins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}