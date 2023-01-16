namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmSampleReceived
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSampleReceived));
            this.lblDays = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblYears = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEntrtyDate = new System.Windows.Forms.Label();
            this.txtCabin = new System.Windows.Forms.TextBox();
            this.lblCabin = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.txtReceiveTime = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.BackColor = System.Drawing.Color.Transparent;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(299, 65);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(41, 20);
            this.lblDays.TabIndex = 118;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.BackColor = System.Drawing.Color.Transparent;
            this.lblMonths.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(223, 65);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(58, 20);
            this.lblMonths.TabIndex = 117;
            this.lblMonths.Text = "Months";
            this.lblMonths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYears
            // 
            this.lblYears.AutoSize = true;
            this.lblYears.BackColor = System.Drawing.Color.Transparent;
            this.lblYears.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYears.Location = new System.Drawing.Point(156, 65);
            this.lblYears.Name = "lblYears";
            this.lblYears.Size = new System.Drawing.Size(43, 20);
            this.lblYears.TabIndex = 116;
            this.lblYears.Text = "Years";
            this.lblYears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDays.Location = new System.Drawing.Point(292, 89);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(58, 29);
            this.txtDays.TabIndex = 114;
            // 
            // txtMonths
            // 
            this.txtMonths.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMonths.Location = new System.Drawing.Point(214, 89);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(67, 29);
            this.txtMonths.TabIndex = 113;
            // 
            // txtYears
            // 
            this.txtYears.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtYears.Location = new System.Drawing.Point(145, 89);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(64, 29);
            this.txtYears.TabIndex = 112;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 115;
            this.label5.Text = "Age";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEntry
            // 
            this.dtpEntry.Enabled = false;
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(143, 162);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(127, 29);
            this.dtpEntry.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 97;
            this.label1.Text = "Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntrtyDate
            // 
            this.lblEntrtyDate.AutoSize = true;
            this.lblEntrtyDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrtyDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrtyDate.Location = new System.Drawing.Point(45, 162);
            this.lblEntrtyDate.Name = "lblEntrtyDate";
            this.lblEntrtyDate.Size = new System.Drawing.Size(96, 20);
            this.lblEntrtyDate.TabIndex = 96;
            this.lblEntrtyDate.Text = "Receive Date";
            this.lblEntrtyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCabin
            // 
            this.txtCabin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCabin.Location = new System.Drawing.Point(696, 123);
            this.txtCabin.Name = "txtCabin";
            this.txtCabin.Size = new System.Drawing.Size(113, 29);
            this.txtCabin.TabIndex = 89;
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.BackColor = System.Drawing.Color.Transparent;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.Location = new System.Drawing.Point(643, 123);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(47, 20);
            this.lblCabin.TabIndex = 95;
            this.lblCabin.Text = "Cabin";
            this.lblCabin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "None"});
            this.cmbGender.Location = new System.Drawing.Point(409, 87);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(94, 29);
            this.cmbGender.TabIndex = 86;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(405, 65);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 20);
            this.lblGender.TabIndex = 93;
            this.lblGender.Text = "Gender";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGender.Click += new System.EventHandler(this.lblGender_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.LightSalmon;
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtBillNo.Location = new System.Drawing.Point(142, 27);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(186, 32);
            this.txtBillNo.TabIndex = 84;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNo_KeyPress);
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.BackColor = System.Drawing.Color.Transparent;
            this.lblRegNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(83, 31);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(54, 20);
            this.lblRegNo.TabIndex = 92;
            this.lblRegNo.Text = "Bill No";
            this.lblRegNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPatientName.Location = new System.Drawing.Point(409, 27);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(400, 29);
            this.txtPatientName.TabIndex = 85;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(354, 27);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(49, 20);
            this.lblPatientName.TabIndex = 91;
            this.lblPatientName.Text = "Name";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefBy
            // 
            this.txtRefBy.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefBy.Location = new System.Drawing.Point(145, 123);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(482, 29);
            this.txtRefBy.TabIndex = 88;
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(80, 123);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(63, 20);
            this.lblRefBy.TabIndex = 90;
            this.lblRefBy.Text = "Refd. By";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientId,
            this.Id,
            this.TestName});
            this.dgTests.Location = new System.Drawing.Point(142, 197);
            this.dgTests.Name = "dgTests";
            this.dgTests.RowTemplate.Height = 35;
            this.dgTests.Size = new System.Drawing.Size(873, 423);
            this.dgTests.TabIndex = 119;
            // 
            // PatientId
            // 
            this.PatientId.HeaderText = "Bill No";
            this.PatientId.Name = "PatientId";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Test Code";
            this.Id.Name = "Id";
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 280;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(809, 271);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 21);
            this.lblTotal.TabIndex = 120;
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.Location = new System.Drawing.Point(142, 636);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(220, 37);
            this.btnSavePrint.TabIndex = 121;
            this.btnSavePrint.Text = "Save Sample Receive Info";
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btn2SavePrint_Click);
            // 
            // txtReceiveTime
            // 
            this.txtReceiveTime.Enabled = false;
            this.txtReceiveTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReceiveTime.Location = new System.Drawing.Point(339, 162);
            this.txtReceiveTime.Name = "txtReceiveTime";
            this.txtReceiveTime.Size = new System.Drawing.Size(185, 29);
            this.txtReceiveTime.TabIndex = 122;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSampleReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1170, 733);
            this.Controls.Add(this.txtReceiveTime);
            this.Controls.Add(this.btnSavePrint);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lblYears);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEntrtyDate);
            this.Controls.Add(this.txtCabin);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.lblRegNo);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.txtRefBy);
            this.Controls.Add(this.lblRefBy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSampleReceived";
            this.Text = "Sample Receive Window";
            this.Load += new System.EventHandler(this.frmSampleCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblYears;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEntrtyDate;
        private System.Windows.Forms.TextBox txtCabin;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.TextBox txtReceiveTime;
        private System.Windows.Forms.Timer timer1;
    }
}