namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmReportDeliveryTimeSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportDeliveryTimeSetting));
            this.dgDTM = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsWeekEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalSlot = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.cmbDSlot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpentrytime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdeliveryTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveTiming = new System.Windows.Forms.Button();
            this.dgRDTD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.radIsWeekEndNo = new System.Windows.Forms.RadioButton();
            this.radIsWeekEndYes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpWST = new System.Windows.Forms.DateTimePicker();
            this.lblWST = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRDTD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDTM
            // 
            this.dgDTM.AllowUserToAddRows = false;
            this.dgDTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDTM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.BrandName,
            this.IsActive,
            this.IsWeekEnd,
            this.WST});
            this.dgDTM.Location = new System.Drawing.Point(39, 136);
            this.dgDTM.Name = "dgDTM";
            this.dgDTM.Size = new System.Drawing.Size(481, 331);
            this.dgDTM.TabIndex = 34;
            this.dgDTM.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDTM_RowHeaderMouseDoubleClick);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Id No";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 60;
            // 
            // BrandName
            // 
            this.BrandName.HeaderText = "T.D.S";
            this.BrandName.Name = "BrandName";
            this.BrandName.Width = 70;
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            // 
            // IsWeekEnd
            // 
            this.IsWeekEnd.HeaderText = "IsWeekEnd";
            this.IsWeekEnd.Name = "IsWeekEnd";
            // 
            // WST
            // 
            this.WST.HeaderText = "W.S.T>=";
            this.WST.Name = "WST";
            this.WST.Width = 110;
            // 
            // txtTotalSlot
            // 
            this.txtTotalSlot.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSlot.Location = new System.Drawing.Point(123, 30);
            this.txtTotalSlot.Name = "txtTotalSlot";
            this.txtTotalSlot.Size = new System.Drawing.Size(98, 27);
            this.txtTotalSlot.TabIndex = 35;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(257, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Total D. Slot";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(48, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 18);
            this.label12.TabIndex = 348;
            this.label12.Text = "Is Active ?";
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNo.Location = new System.Drawing.Point(68, 12);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(44, 22);
            this.radNo.TabIndex = 347;
            this.radNo.Text = "No";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYes.Location = new System.Drawing.Point(14, 12);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(46, 22);
            this.radYes.TabIndex = 346;
            this.radYes.Text = "Yes";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // cmbDSlot
            // 
            this.cmbDSlot.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDSlot.FormattingEnabled = true;
            this.cmbDSlot.Location = new System.Drawing.Point(591, 52);
            this.cmbDSlot.Name = "cmbDSlot";
            this.cmbDSlot.Size = new System.Drawing.Size(113, 26);
            this.cmbDSlot.TabIndex = 349;
            this.cmbDSlot.SelectedIndexChanged += new System.EventHandler(this.cmbDSlot_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(486, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 350;
            this.label2.Text = "Select D. Slot";
            // 
            // dtpentrytime
            // 
            this.dtpentrytime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpentrytime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpentrytime.Location = new System.Drawing.Point(591, 90);
            this.dtpentrytime.Name = "dtpentrytime";
            this.dtpentrytime.Size = new System.Drawing.Size(113, 26);
            this.dtpentrytime.TabIndex = 352;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(494, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 351;
            this.label3.Text = "Entry Time <=";
            // 
            // dtpdeliveryTime
            // 
            this.dtpdeliveryTime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdeliveryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpdeliveryTime.Location = new System.Drawing.Point(835, 90);
            this.dtpdeliveryTime.Name = "dtpdeliveryTime";
            this.dtpdeliveryTime.Size = new System.Drawing.Size(113, 26);
            this.dtpdeliveryTime.TabIndex = 354;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(718, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 353;
            this.label4.Text = "Delivery Time >=";
            // 
            // btnSaveTiming
            // 
            this.btnSaveTiming.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTiming.Location = new System.Drawing.Point(958, 87);
            this.btnSaveTiming.Name = "btnSaveTiming";
            this.btnSaveTiming.Size = new System.Drawing.Size(101, 32);
            this.btnSaveTiming.TabIndex = 355;
            this.btnSaveTiming.Text = "Save";
            this.btnSaveTiming.UseVisualStyleBackColor = true;
            this.btnSaveTiming.Click += new System.EventHandler(this.btnSaveTiming_Click);
            // 
            // dgRDTD
            // 
            this.dgRDTD.AllowUserToAddRows = false;
            this.dgRDTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRDTD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgRDTD.Location = new System.Drawing.Point(534, 122);
            this.dgRDTD.Name = "dgRDTD";
            this.dgRDTD.Size = new System.Drawing.Size(525, 359);
            this.dgRDTD.TabIndex = 356;
            this.dgRDTD.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRDTD_RowHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Entry Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Delivery Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(27, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 359;
            this.label5.Text = "Is Weekend ?";
            // 
            // radIsWeekEndNo
            // 
            this.radIsWeekEndNo.AutoSize = true;
            this.radIsWeekEndNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIsWeekEndNo.Location = new System.Drawing.Point(177, 108);
            this.radIsWeekEndNo.Name = "radIsWeekEndNo";
            this.radIsWeekEndNo.Size = new System.Drawing.Size(44, 22);
            this.radIsWeekEndNo.TabIndex = 358;
            this.radIsWeekEndNo.Text = "No";
            this.radIsWeekEndNo.UseVisualStyleBackColor = true;
            this.radIsWeekEndNo.Click += new System.EventHandler(this.radIsWeekEndNo_Click);
            // 
            // radIsWeekEndYes
            // 
            this.radIsWeekEndYes.AutoSize = true;
            this.radIsWeekEndYes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIsWeekEndYes.Location = new System.Drawing.Point(126, 108);
            this.radIsWeekEndYes.Name = "radIsWeekEndYes";
            this.radIsWeekEndYes.Size = new System.Drawing.Size(46, 22);
            this.radIsWeekEndYes.TabIndex = 357;
            this.radIsWeekEndYes.Text = "Yes";
            this.radIsWeekEndYes.UseVisualStyleBackColor = true;
            this.radIsWeekEndYes.CheckedChanged += new System.EventHandler(this.radIsWeekEndYes_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNo);
            this.groupBox1.Controls.Add(this.radYes);
            this.groupBox1.Location = new System.Drawing.Point(123, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 38);
            this.groupBox1.TabIndex = 360;
            this.groupBox1.TabStop = false;
            // 
            // dtpWST
            // 
            this.dtpWST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWST.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpWST.Location = new System.Drawing.Point(256, 30);
            this.dtpWST.Name = "dtpWST";
            this.dtpWST.Size = new System.Drawing.Size(113, 26);
            this.dtpWST.TabIndex = 362;
            this.dtpWST.Visible = false;
            // 
            // lblWST
            // 
            this.lblWST.AutoSize = true;
            this.lblWST.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWST.Location = new System.Drawing.Point(253, 9);
            this.lblWST.Name = "lblWST";
            this.lblWST.Size = new System.Drawing.Size(135, 18);
            this.lblWST.TabIndex = 361;
            this.lblWST.Text = "Week End Start Time";
            this.lblWST.Visible = false;
            // 
            // frmReportDeliveryTimeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 511);
            this.Controls.Add(this.dtpWST);
            this.Controls.Add(this.lblWST);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radIsWeekEndNo);
            this.Controls.Add(this.radIsWeekEndYes);
            this.Controls.Add(this.dgRDTD);
            this.Controls.Add(this.btnSaveTiming);
            this.Controls.Add(this.dtpdeliveryTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpentrytime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDSlot);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTotalSlot);
            this.Controls.Add(this.dgDTM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReportDeliveryTimeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Delivery Time Setting";
            this.Load += new System.EventHandler(this.frmReportDeliveryTimeSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRDTD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDTM;
        private System.Windows.Forms.TextBox txtTotalSlot;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radNo;
        private System.Windows.Forms.RadioButton radYes;
        private System.Windows.Forms.ComboBox cmbDSlot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpentrytime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpdeliveryTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveTiming;
        private System.Windows.Forms.DataGridView dgRDTD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radIsWeekEndNo;
        private System.Windows.Forms.RadioButton radIsWeekEndYes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpWST;
        private System.Windows.Forms.Label lblWST;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsWeekEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn WST;
    }
}