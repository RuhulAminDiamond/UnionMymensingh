namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmEditPatientInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPatientInfo));
            this.lblEntrtyDate = new System.Windows.Forms.Label();
            this.txtCabin = new System.Windows.Forms.TextBox();
            this.lblCabin = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.dgTests = new System.Windows.Forms.DataGridView();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.btnCancelPatient = new System.Windows.Forms.Button();
            this.btnCancelSelectedTest = new System.Windows.Forms.Button();
            this.txtCancelledTk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReturnableTk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefund = new System.Windows.Forms.Button();
            this.txtTestCostTk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblYears = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDueTk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaidTk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscountTk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdPrintReceipt = new System.Windows.Forms.Button();
            this.txtCountryCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountInPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCancelApproves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntrtyDate
            // 
            this.lblEntrtyDate.AutoSize = true;
            this.lblEntrtyDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrtyDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrtyDate.Location = new System.Drawing.Point(283, 145);
            this.lblEntrtyDate.Name = "lblEntrtyDate";
            this.lblEntrtyDate.Size = new System.Drawing.Size(78, 20);
            this.lblEntrtyDate.TabIndex = 55;
            this.lblEntrtyDate.Text = "Entry Date";
            this.lblEntrtyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCabin
            // 
            this.txtCabin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCabin.Location = new System.Drawing.Point(572, 101);
            this.txtCabin.Name = "txtCabin";
            this.txtCabin.Size = new System.Drawing.Size(186, 29);
            this.txtCabin.TabIndex = 6;
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.BackColor = System.Drawing.Color.Transparent;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.Location = new System.Drawing.Point(520, 106);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(47, 20);
            this.lblCabin.TabIndex = 54;
            this.lblCabin.Text = "Cabin";
            this.lblCabin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCellPhone.Location = new System.Drawing.Point(629, 67);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(129, 29);
            this.txtCellPhone.TabIndex = 4;
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblCellPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellPhone.Location = new System.Drawing.Point(486, 69);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(80, 20);
            this.lblCellPhone.TabIndex = 53;
            this.lblCellPhone.Text = "Mobile No";
            this.lblCellPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "None"});
            this.cmbGender.Location = new System.Drawing.Point(106, 141);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(97, 29);
            this.cmbGender.TabIndex = 3;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(45, 141);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 20);
            this.lblGender.TabIndex = 52;
            this.lblGender.Text = "Gender";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGender.Click += new System.EventHandler(this.lblGender_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.LightSalmon;
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtBillNo.Location = new System.Drawing.Point(106, 23);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(186, 32);
            this.txtBillNo.TabIndex = 0;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNo_KeyPress);
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.BackColor = System.Drawing.Color.Transparent;
            this.lblRegNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(55, 23);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(54, 20);
            this.lblRegNo.TabIndex = 44;
            this.lblRegNo.Text = "Bill No";
            this.lblRegNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPatientName.Location = new System.Drawing.Point(373, 23);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(385, 29);
            this.txtPatientName.TabIndex = 1;
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(312, 23);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(49, 20);
            this.lblPatientName.TabIndex = 43;
            this.lblPatientName.Text = "Name";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(42, 105);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(63, 20);
            this.lblRefBy.TabIndex = 39;
            this.lblRefBy.Text = "Refd. By";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefBy
            // 
            this.txtRefBy.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefBy.Location = new System.Drawing.Point(106, 105);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(408, 29);
            this.txtRefBy.TabIndex = 5;
            this.txtRefBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefBy_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(532, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "D. Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(801, -100);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(137, 37);
            this.cmdUpdate.TabIndex = 57;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // dgTests
            // 
            this.dgTests.AllowUserToAddRows = false;
            this.dgTests.BackgroundColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.tName,
            this.Rate,
            this.DiscountInPercent,
            this.Discount,
            this.Column1,
            this.Column2,
            this.IsCancelApproves});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTests.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgTests.GridColor = System.Drawing.Color.LemonChiffon;
            this.dgTests.Location = new System.Drawing.Point(79, 176);
            this.dgTests.Name = "dgTests";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTests.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgTests.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTests.Size = new System.Drawing.Size(866, 316);
            this.dgTests.TabIndex = 58;
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntry.Location = new System.Drawing.Point(373, 144);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(127, 29);
            this.dtpEntry.TabIndex = 59;
            // 
            // dtpDelivery
            // 
            this.dtpDelivery.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelivery.Location = new System.Drawing.Point(597, 145);
            this.dtpDelivery.Name = "dtpDelivery";
            this.dtpDelivery.Size = new System.Drawing.Size(139, 29);
            this.dtpDelivery.TabIndex = 60;
            // 
            // btnCancelPatient
            // 
            this.btnCancelPatient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPatient.Location = new System.Drawing.Point(286, 609);
            this.btnCancelPatient.Name = "btnCancelPatient";
            this.btnCancelPatient.Size = new System.Drawing.Size(157, 37);
            this.btnCancelPatient.TabIndex = 61;
            this.btnCancelPatient.Text = "Cancel patient";
            this.btnCancelPatient.UseVisualStyleBackColor = true;
            this.btnCancelPatient.Click += new System.EventHandler(this.btnCancelPatient_Click);
            // 
            // btnCancelSelectedTest
            // 
            this.btnCancelSelectedTest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSelectedTest.Location = new System.Drawing.Point(103, 609);
            this.btnCancelSelectedTest.Name = "btnCancelSelectedTest";
            this.btnCancelSelectedTest.Size = new System.Drawing.Size(161, 37);
            this.btnCancelSelectedTest.TabIndex = 62;
            this.btnCancelSelectedTest.Text = "Cancel selected test";
            this.btnCancelSelectedTest.UseVisualStyleBackColor = true;
            this.btnCancelSelectedTest.Click += new System.EventHandler(this.btnCancelSelectedTest_Click);
            // 
            // txtCancelledTk
            // 
            this.txtCancelledTk.Enabled = false;
            this.txtCancelledTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCancelledTk.Location = new System.Drawing.Point(852, 544);
            this.txtCancelledTk.Name = "txtCancelledTk";
            this.txtCancelledTk.Size = new System.Drawing.Size(117, 29);
            this.txtCancelledTk.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(744, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Cancelled (Tk.)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReturnableTk
            // 
            this.txtReturnableTk.Enabled = false;
            this.txtReturnableTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReturnableTk.Location = new System.Drawing.Point(853, 578);
            this.txtReturnableTk.Name = "txtReturnableTk";
            this.txtReturnableTk.Size = new System.Drawing.Size(117, 29);
            this.txtReturnableTk.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(730, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Returnable (Tk.)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRefund
            // 
            this.btnRefund.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.Location = new System.Drawing.Point(838, 623);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(133, 37);
            this.btnRefund.TabIndex = 67;
            this.btnRefund.Text = "Refund Now";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // txtTestCostTk
            // 
            this.txtTestCostTk.Enabled = false;
            this.txtTestCostTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTestCostTk.Location = new System.Drawing.Point(109, 569);
            this.txtTestCostTk.Name = "txtTestCostTk";
            this.txtTestCostTk.Size = new System.Drawing.Size(104, 29);
            this.txtTestCostTk.TabIndex = 68;
            this.txtTestCostTk.TextChanged += new System.EventHandler(this.txtTestCostTk_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "Test Cost(Tk.)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.BackColor = System.Drawing.Color.Transparent;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(419, 69);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(41, 20);
            this.lblDays.TabIndex = 77;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.BackColor = System.Drawing.Color.Transparent;
            this.lblMonths.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(293, 69);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(58, 20);
            this.lblMonths.TabIndex = 76;
            this.lblMonths.Text = "Months";
            this.lblMonths.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYears
            // 
            this.lblYears.AutoSize = true;
            this.lblYears.BackColor = System.Drawing.Color.Transparent;
            this.lblYears.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYears.Location = new System.Drawing.Point(173, 69);
            this.lblYears.Name = "lblYears";
            this.lblYears.Size = new System.Drawing.Size(43, 20);
            this.lblYears.TabIndex = 75;
            this.lblYears.Text = "Years";
            this.lblYears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDays.Location = new System.Drawing.Point(356, 69);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(58, 29);
            this.txtDays.TabIndex = 73;
            // 
            // txtMonths
            // 
            this.txtMonths.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMonths.Location = new System.Drawing.Point(221, 67);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(67, 29);
            this.txtMonths.TabIndex = 72;
            // 
            // txtYears
            // 
            this.txtYears.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtYears.Location = new System.Drawing.Point(104, 67);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(64, 29);
            this.txtYears.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "Age";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDueTk
            // 
            this.txtDueTk.Enabled = false;
            this.txtDueTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDueTk.Location = new System.Drawing.Point(506, 569);
            this.txtDueTk.Name = "txtDueTk";
            this.txtDueTk.Size = new System.Drawing.Size(104, 29);
            this.txtDueTk.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(509, 546);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 81;
            this.label6.Text = "Due (Tk.)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaidTk
            // 
            this.txtPaidTk.Enabled = false;
            this.txtPaidTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPaidTk.Location = new System.Drawing.Point(257, 569);
            this.txtPaidTk.Name = "txtPaidTk";
            this.txtPaidTk.Size = new System.Drawing.Size(104, 29);
            this.txtPaidTk.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(255, 547);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "Paid (Tk.)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtDiscountTk
            // 
            this.txtDiscountTk.Enabled = false;
            this.txtDiscountTk.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDiscountTk.Location = new System.Drawing.Point(381, 569);
            this.txtDiscountTk.Name = "txtDiscountTk";
            this.txtDiscountTk.Size = new System.Drawing.Size(104, 29);
            this.txtDiscountTk.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(379, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 83;
            this.label8.Text = "Discount (Tk.)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdPrintReceipt
            // 
            this.cmdPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintReceipt.Location = new System.Drawing.Point(467, 607);
            this.cmdPrintReceipt.Name = "cmdPrintReceipt";
            this.cmdPrintReceipt.Size = new System.Drawing.Size(156, 39);
            this.cmdPrintReceipt.TabIndex = 84;
            this.cmdPrintReceipt.Text = "Print Receipt";
            this.cmdPrintReceipt.UseVisualStyleBackColor = true;
            this.cmdPrintReceipt.Click += new System.EventHandler(this.cmdPrintReceipt_Click);
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCountryCode.Location = new System.Drawing.Point(572, 67);
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.Size = new System.Drawing.Size(51, 29);
            this.txtCountryCode.TabIndex = 85;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(696, 624);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 37);
            this.btnClose.TabIndex = 98;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRemark.Location = new System.Drawing.Point(104, 502);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(866, 37);
            this.txtRemark.TabIndex = 101;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(33, 506);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 102;
            this.label9.Text = "Remarks";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlDoctorSearch
            // 
            this.ctrlDoctorSearch.Location = new System.Drawing.Point(79, 225);
            this.ctrlDoctorSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDoctorSearch.Name = "ctrlDoctorSearch";
            this.ctrlDoctorSearch.Size = new System.Drawing.Size(613, 382);
            this.ctrlDoctorSearch.TabIndex = 70;
            this.ctrlDoctorSearch.Visible = false;
            // 
            // Code
            // 
            this.Code.HeaderText = "Test Code";
            this.Code.Name = "Code";
            this.Code.Width = 120;
            // 
            // tName
            // 
            this.tName.HeaderText = "Test Name";
            this.tName.Name = "tName";
            this.tName.Width = 300;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.Width = 120;
            // 
            // DiscountInPercent
            // 
            this.DiscountInPercent.DataPropertyName = "discountInPercent";
            this.DiscountInPercent.HeaderText = "Disc(%)";
            this.DiscountInPercent.Name = "DiscountInPercent";
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "discount";
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Status";
            this.Column1.HeaderText = "Status";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CancelledBy";
            this.Column2.HeaderText = "UserName";
            this.Column2.Name = "Column2";
            // 
            // IsCancelApproves
            // 
            this.IsCancelApproves.HeaderText = "Cancel Approve";
            this.IsCancelApproves.Name = "IsCancelApproves";
            // 
            // frmEditPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 694);
            this.Controls.Add(this.ctrlDoctorSearch);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmdPrintReceipt);
            this.Controls.Add(this.txtDiscountTk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDueTk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPaidTk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lblYears);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTestCostTk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.txtReturnableTk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCancelledTk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelSelectedTest);
            this.Controls.Add(this.btnCancelPatient);
            this.Controls.Add(this.dtpDelivery);
            this.Controls.Add(this.dtpEntry);
            this.Controls.Add(this.dgTests);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEntrtyDate);
            this.Controls.Add(this.txtCabin);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.txtCellPhone);
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.lblRegNo);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtRefBy);
            this.Controls.Add(this.txtCountryCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditPatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Patient Info";
            this.Load += new System.EventHandler(this.frmEditPatientInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntrtyDate;
        private System.Windows.Forms.TextBox txtCabin;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.DataGridView dgTests;
        private System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.DateTimePicker dtpDelivery;
        private System.Windows.Forms.Button btnCancelPatient;
        private System.Windows.Forms.Button btnCancelSelectedTest;
        private System.Windows.Forms.TextBox txtCancelledTk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReturnableTk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.TextBox txtTestCostTk;
        private System.Windows.Forms.Label label4;
        private Controls.DoctorSearchControl ctrlDoctorSearch;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblYears;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDueTk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaidTk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscountTk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdPrintReceipt;
        private System.Windows.Forms.TextBox txtCountryCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountInPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCancelApproves;
    }
}