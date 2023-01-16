namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlPatientBill
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTotalPatient = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.txtCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtAdmId = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtAssignDoc = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHospitalBill = new System.Windows.Forms.TextBox();
            this.txtPathologyBill = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDueBill = new System.Windows.Forms.TextBox();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaidBill = new System.Windows.Forms.TextBox();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.txtMedicineBill = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDoctorBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTotalPatient
            // 
            this.lblTotalPatient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalPatient.AutoSize = true;
            this.lblTotalPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatient.Location = new System.Drawing.Point(459, 6);
            this.lblTotalPatient.Name = "lblTotalPatient";
            this.lblTotalPatient.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPatient.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(335, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Patient : ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1167, 574);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.82096F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.17904F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.Controls.Add(this.dgPatient, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.353809F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.64619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dgPatient
            // 
            this.dgPatient.AllowUserToAddRows = false;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Time,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgPatient.Location = new System.Drawing.Point(3, 35);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.RowHeadersWidth = 51;
            this.dgPatient.Size = new System.Drawing.Size(727, 348);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatient_CellContentClick);
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel4.Controls.Add(this.btnRefresh, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTotalPatient, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 389);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(710, 31);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.98305F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.01695F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtp, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCabin, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtAdmId, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtAssignDoc, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(790, 25);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.Location = new System.Drawing.Point(197, 3);
            this.txtName.Name = "txtName";
            this.txtName.PlaceHolderText = "Search by name";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 47;
            this.txtName.Text = "Search by name";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // dtp
            // 
            this.dtp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(79, 3);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(112, 23);
            this.dtp.TabIndex = 46;
            // 
            // txtCabin
            // 
            this.txtCabin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtCabin.Location = new System.Drawing.Point(417, 3);
            this.txtCabin.Name = "txtCabin";
            this.txtCabin.PlaceHolderText = "Search by cabin";
            this.txtCabin.Size = new System.Drawing.Size(143, 23);
            this.txtCabin.TabIndex = 48;
            this.txtCabin.Text = "Search by cabin";
            this.txtCabin.TextChanged += new System.EventHandler(this.txtCabin_TextChanged);
            // 
            // txtAdmId
            // 
            this.txtAdmId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtAdmId.ForeColor = System.Drawing.Color.Gray;
            this.txtAdmId.Location = new System.Drawing.Point(3, 3);
            this.txtAdmId.Name = "txtAdmId";
            this.txtAdmId.PlaceHolderText = "By Adm. Id";
            this.txtAdmId.Size = new System.Drawing.Size(68, 23);
            this.txtAdmId.TabIndex = 49;
            this.txtAdmId.Text = "By Adm. Id";
            this.txtAdmId.TextChanged += new System.EventHandler(this.txtAdmId_TextChanged);
            // 
            // txtAssignDoc
            // 
            this.txtAssignDoc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtAssignDoc.ForeColor = System.Drawing.Color.Gray;
            this.txtAssignDoc.Location = new System.Drawing.Point(566, 3);
            this.txtAssignDoc.Name = "txtAssignDoc";
            this.txtAssignDoc.PlaceHolderText = "Search by Assign Doc";
            this.txtAssignDoc.Size = new System.Drawing.Size(196, 23);
            this.txtAssignDoc.TabIndex = 50;
            this.txtAssignDoc.Text = "Search by Assign Doc";
            this.txtAssignDoc.TextChanged += new System.EventHandler(this.txtAssignDoc_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80214F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19786F));
            this.tableLayoutPanel3.Controls.Add(this.txtHospitalBill, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtPathologyBill, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.txtDueBill, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.txtTotalBill, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtPaidBill, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtServiceCharge, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtMedicineBill, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtDoctorBill, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(799, 35);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(187, 277);
            this.tableLayoutPanel3.TabIndex = 48;
            // 
            // txtHospitalBill
            // 
            this.txtHospitalBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHospitalBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtHospitalBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHospitalBill.Location = new System.Drawing.Point(98, 4);
            this.txtHospitalBill.Name = "txtHospitalBill";
            this.txtHospitalBill.Size = new System.Drawing.Size(86, 23);
            this.txtHospitalBill.TabIndex = 2;
            this.txtHospitalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPathologyBill
            // 
            this.txtPathologyBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPathologyBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPathologyBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathologyBill.Location = new System.Drawing.Point(98, 37);
            this.txtPathologyBill.Name = "txtPathologyBill";
            this.txtPathologyBill.Size = new System.Drawing.Size(86, 23);
            this.txtPathologyBill.TabIndex = 4;
            this.txtPathologyBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Due Bill";
            // 
            // txtDueBill
            // 
            this.txtDueBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDueBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDueBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueBill.Location = new System.Drawing.Point(98, 240);
            this.txtDueBill.Name = "txtDueBill";
            this.txtDueBill.Size = new System.Drawing.Size(86, 23);
            this.txtDueBill.TabIndex = 14;
            this.txtDueBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTotalBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(98, 167);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(86, 23);
            this.txtTotalBill.TabIndex = 10;
            this.txtTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Paid Bill";
            // 
            // txtPaidBill
            // 
            this.txtPaidBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPaidBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPaidBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidBill.Location = new System.Drawing.Point(98, 199);
            this.txtPaidBill.Name = "txtPaidBill";
            this.txtPaidBill.Size = new System.Drawing.Size(86, 23);
            this.txtPaidBill.TabIndex = 12;
            this.txtPaidBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtServiceCharge.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtServiceCharge.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceCharge.Location = new System.Drawing.Point(98, 135);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Size = new System.Drawing.Size(86, 23);
            this.txtServiceCharge.TabIndex = 37;
            this.txtServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMedicineBill
            // 
            this.txtMedicineBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMedicineBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtMedicineBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicineBill.Location = new System.Drawing.Point(98, 70);
            this.txtMedicineBill.Name = "txtMedicineBill";
            this.txtMedicineBill.Size = new System.Drawing.Size(86, 23);
            this.txtMedicineBill.TabIndex = 6;
            this.txtMedicineBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medicine Bill";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Service Charge";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDoctorBill
            // 
            this.txtDoctorBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDoctorBill.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDoctorBill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorBill.Location = new System.Drawing.Point(98, 102);
            this.txtDoctorBill.Name = "txtDoctorBill";
            this.txtDoctorBill.Size = new System.Drawing.Size(86, 23);
            this.txtDoctorBill.TabIndex = 8;
            this.txtDoctorBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hospital Bill";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pathology Bill";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Doctor Bill";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Bill";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Adm. Id";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "AdmTime";
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Name";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Bed/Cabin";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Assigned Doctor";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 350;
            // 
            // ctrlPatientBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctrlPatientBill";
            this.Size = new System.Drawing.Size(1167, 574);
            this.Load += new System.EventHandler(this.ctrlPatientBill_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTotalPatient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtp;
        private Controls.PlaceHolderTextBox txtName;
        private Controls.PlaceHolderTextBox txtCabin;
        private Controls.PlaceHolderTextBox txtAdmId;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtHospitalBill;
        private System.Windows.Forms.TextBox txtPathologyBill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDueBill;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaidBill;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.TextBox txtMedicineBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDoctorBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Controls.PlaceHolderTextBox txtAssignDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
