namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmEditHpPatientAccomationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditHpPatientAccomationInfo));
            this.dgAccomInfo = new System.Windows.Forms.DataGridView();
            this.SrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllotType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHBillNo = new System.Windows.Forms.TextBox();
            this.dgLedger = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccomdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccomTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReleaseTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReleasedate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAllotType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccomInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAccomInfo
            // 
            this.dgAccomInfo.AllowUserToAddRows = false;
            this.dgAccomInfo.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgAccomInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccomInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrlNo,
            this.ServiceName,
            this.Qty,
            this.Rate,
            this.Total,
            this.ReleaseTime,
            this.AllotType,
            this.OperateBy,
            this.Status});
            this.dgAccomInfo.Location = new System.Drawing.Point(22, 125);
            this.dgAccomInfo.Name = "dgAccomInfo";
            this.dgAccomInfo.Size = new System.Drawing.Size(1024, 241);
            this.dgAccomInfo.TabIndex = 118;
            this.dgAccomInfo.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAccomInfo_RowHeaderMouseDoubleClick);
            // 
            // SrlNo
            // 
            this.SrlNo.HeaderText = "SrlNo";
            this.SrlNo.Name = "SrlNo";
            // 
            // ServiceName
            // 
            this.ServiceName.HeaderText = "Accom. Date";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Width = 120;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Accom.Time";
            this.Qty.Name = "Qty";
            this.Qty.Width = 120;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Cabin No";
            this.Rate.Name = "Rate";
            this.Rate.Width = 120;
            // 
            // Total
            // 
            this.Total.HeaderText = "Release Date";
            this.Total.Name = "Total";
            this.Total.Width = 120;
            // 
            // ReleaseTime
            // 
            this.ReleaseTime.HeaderText = "Time";
            this.ReleaseTime.Name = "ReleaseTime";
            // 
            // AllotType
            // 
            this.AllotType.HeaderText = "Allot. Type";
            this.AllotType.Name = "AllotType";
            // 
            // OperateBy
            // 
            this.OperateBy.HeaderText = "Operator";
            this.OperateBy.Name = "OperateBy";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 117;
            this.label1.Text = "Bill No";
            // 
            // txtHBillNo
            // 
            this.txtHBillNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHBillNo.Location = new System.Drawing.Point(83, 23);
            this.txtHBillNo.Name = "txtHBillNo";
            this.txtHBillNo.Size = new System.Drawing.Size(222, 27);
            this.txtHBillNo.TabIndex = 116;
            this.txtHBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHBillNo_KeyPress);
            // 
            // dgLedger
            // 
            this.dgLedger.AllowUserToAddRows = false;
            this.dgLedger.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgLedger.Location = new System.Drawing.Point(22, 401);
            this.dgLedger.MultiSelect = false;
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.Size = new System.Drawing.Size(695, 179);
            this.dgLedger.TabIndex = 119;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SrlNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Service Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 120;
            this.label2.Text = "Billing Chart";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "Accom date";
            // 
            // txtAccomdate
            // 
            this.txtAccomdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccomdate.Location = new System.Drawing.Point(163, 93);
            this.txtAccomdate.Name = "txtAccomdate";
            this.txtAccomdate.Size = new System.Drawing.Size(102, 27);
            this.txtAccomdate.TabIndex = 121;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(271, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 124;
            this.label4.Text = "Accom time";
            // 
            // txtAccomTime
            // 
            this.txtAccomTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccomTime.Location = new System.Drawing.Point(275, 93);
            this.txtAccomTime.Name = "txtAccomTime";
            this.txtAccomTime.Size = new System.Drawing.Size(89, 27);
            this.txtAccomTime.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(523, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Release Time";
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReleaseTime.Location = new System.Drawing.Point(523, 93);
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.Size = new System.Drawing.Size(97, 27);
            this.txtReleaseTime.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(406, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 126;
            this.label6.Text = "Release date";
            // 
            // txtReleasedate
            // 
            this.txtReleasedate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReleasedate.Location = new System.Drawing.Point(410, 93);
            this.txtReleasedate.Name = "txtReleasedate";
            this.txtReleasedate.Size = new System.Drawing.Size(107, 27);
            this.txtReleasedate.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(626, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 130;
            this.label7.Text = "Allot Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(743, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 132;
            this.label8.Text = "Status";
            // 
            // cmbAllotType
            // 
            this.cmbAllotType.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAllotType.FormattingEnabled = true;
            this.cmbAllotType.Items.AddRange(new object[] {
            "PatientBed",
            "ExtraBed",
            "ReleasedAsPB",
            "ReleasedAsEB",
            "ReleasedAsTB"});
            this.cmbAllotType.Location = new System.Drawing.Point(626, 93);
            this.cmbAllotType.Name = "cmbAllotType";
            this.cmbAllotType.Size = new System.Drawing.Size(115, 26);
            this.cmbAllotType.TabIndex = 133;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Occupied",
            "Vacant"});
            this.cmbStatus.Location = new System.Drawing.Point(747, 93);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(110, 26);
            this.cmbStatus.TabIndex = 134;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(863, 89);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 31);
            this.btnUpdate.TabIndex = 135;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseWindow.Location = new System.Drawing.Point(948, 88);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(98, 31);
            this.btnCloseWindow.TabIndex = 136;
            this.btnCloseWindow.Text = "Close Window";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // frmEditHpPatientAccomationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 651);
            this.Controls.Add(this.btnCloseWindow);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbAllotType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReleaseTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReleasedate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccomTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccomdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgLedger);
            this.Controls.Add(this.dgAccomInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHBillNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditHpPatientAccomationInfo";
            this.Text = "Hp. Patient Accomodation Details";
            this.Load += new System.EventHandler(this.frmEditHpPatientAccomationInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccomInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAccomInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHBillNo;
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllotType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccomdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccomTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReleaseTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReleasedate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAllotType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCloseWindow;
    }
}