
namespace HDMS.Windows.Forms.UI.OPD
{
    partial class OPDPatientEntryCtrl
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbVisitType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.dgService = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrevBill = new System.Windows.Forms.TextBox();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountedAmount = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrevId = new System.Windows.Forms.Button();
            this.btnNextId = new System.Windows.Forms.Button();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCareOf = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnEditPatientInfo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscountInPercent = new System.Windows.Forms.TextBox();
            this.cmdCollection = new System.Windows.Forms.Button();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblCareOf = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblTotalPatientsValue = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.txtDeliveryTime = new System.Windows.Forms.TextBox();
            this.lblDeliveryTime = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblEntryDateValue = new System.Windows.Forms.Label();
            this.lblEntrtyDate = new System.Windows.Forms.Label();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtDailyId = new System.Windows.Forms.TextBox();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.lblServiceTitle = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.ctlConsultantSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl2();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.ctlOpdService = new HDMS.Windows.Forms.UI.Controls.ctrlOPDServiceItem();
            this.txtDays = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtMonths = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.txtYears = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Service Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 220;
            // 
            // cmbVisitType
            // 
            this.cmbVisitType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbVisitType.FormattingEnabled = true;
            this.cmbVisitType.Location = new System.Drawing.Point(458, 132);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(148, 29);
            this.cmbVisitType.TabIndex = 11278;
            this.cmbVisitType.Visible = false;
            this.cmbVisitType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVisitType_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(381, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 11277;
            this.label9.Text = "Visit Type";
            this.label9.Visible = false;
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(103, 132);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(193, 29);
            this.cmbServiceType.TabIndex = 11275;
            this.cmbServiceType.SelectedIndexChanged += new System.EventHandler(this.cmbServiceType_SelectedIndexChanged);
            this.cmbServiceType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServiceType_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 18);
            this.label10.TabIndex = 11274;
            this.label10.Text = "Service Type";
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Qty";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(583, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 18);
            this.label13.TabIndex = 11272;
            this.label13.Text = "Qty";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(413, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 18);
            this.label14.TabIndex = 11271;
            this.label14.Text = "Rate";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(626, 170);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(101, 29);
            this.txtQty.TabIndex = 11270;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(458, 170);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(101, 29);
            this.txtRate.TabIndex = 11269;
            // 
            // dgService
            // 
            this.dgService.AllowUserToAddRows = false;
            this.dgService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Rate,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgService.Location = new System.Drawing.Point(91, 209);
            this.dgService.Name = "dgService";
            this.dgService.Size = new System.Drawing.Size(638, 429);
            this.dgService.TabIndex = 11268;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "User";
            this.Column5.Name = "Column5";
            // 
            // txtPrevBill
            // 
            this.txtPrevBill.BackColor = System.Drawing.Color.LightSalmon;
            this.txtPrevBill.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtPrevBill.Location = new System.Drawing.Point(961, 14);
            this.txtPrevBill.Name = "txtPrevBill";
            this.txtPrevBill.Size = new System.Drawing.Size(152, 32);
            this.txtPrevBill.TabIndex = 11266;
            this.txtPrevBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPercent
            // 
            this.txtPercent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercent.Location = new System.Drawing.Point(78, 39);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(61, 29);
            this.txtPercent.TabIndex = 23;
            this.txtPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "%";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(367, 39);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(121, 29);
            this.txtDiscountAmount.TabIndex = 22;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(890, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 11267;
            this.label12.Text = "Prev. Bill";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountedAmount
            // 
            this.txtDiscountedAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountedAmount.Location = new System.Drawing.Point(220, 39);
            this.txtDiscountedAmount.Name = "txtDiscountedAmount";
            this.txtDiscountedAmount.Size = new System.Drawing.Size(121, 29);
            this.txtDiscountedAmount.TabIndex = 21;
            this.txtDiscountedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(678, 136);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 20);
            this.lblTime.TabIndex = 11265;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(893, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 47);
            this.btnPrint.TabIndex = 11263;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrevId
            // 
            this.btnPrevId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevId.Location = new System.Drawing.Point(914, 496);
            this.btnPrevId.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevId.Name = "btnPrevId";
            this.btnPrevId.Size = new System.Drawing.Size(52, 26);
            this.btnPrevId.TabIndex = 11262;
            this.btnPrevId.Text = "<<";
            this.btnPrevId.UseVisualStyleBackColor = true;
            this.btnPrevId.Click += new System.EventHandler(this.btnPrevId_Click);
            // 
            // btnNextId
            // 
            this.btnNextId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextId.Location = new System.Drawing.Point(998, 496);
            this.btnNextId.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextId.Name = "btnNextId";
            this.btnNextId.Size = new System.Drawing.Size(46, 26);
            this.btnNextId.TabIndex = 11261;
            this.btnNextId.Text = ">>";
            this.btnNextId.UseVisualStyleBackColor = true;
            this.btnNextId.Click += new System.EventHandler(this.btnNextId_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.LightSalmon;
            this.txtBillNo.Enabled = false;
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtBillNo.Location = new System.Drawing.Point(363, 15);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(208, 32);
            this.txtBillNo.TabIndex = 11259;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(754, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 11253;
            this.label4.Text = "Remarks";
            // 
            // txtCareOf
            // 
            this.txtCareOf.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCareOf.Location = new System.Drawing.Point(819, 316);
            this.txtCareOf.Name = "txtCareOf";
            this.txtCareOf.Size = new System.Drawing.Size(370, 32);
            this.txtCareOf.TabIndex = 11230;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::HDMS.Windows.Forms.UI.Properties.Resources.patientEntrybg;
            this.groupBox1.Controls.Add(this.txtPercent);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiscountedAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiscountAmount);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(571, -95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 87);
            this.groupBox1.TabIndex = 11252;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caculator";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 58;
            this.label5.Text = "Discout";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(213, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = "Discounted Tk.";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1130, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 34);
            this.btnClear.TabIndex = 11264;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 11260;
            this.label7.Text = "Bill No";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(819, 179);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(113, 32);
            this.txtTotalAmount.TabIndex = 11237;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEditPatientInfo
            // 
            this.btnEditPatientInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPatientInfo.Location = new System.Drawing.Point(831, -102);
            this.btnEditPatientInfo.Name = "btnEditPatientInfo";
            this.btnEditPatientInfo.Size = new System.Drawing.Size(70, 33);
            this.btnEditPatientInfo.TabIndex = 11251;
            this.btnEditPatientInfo.Text = "Edit";
            this.btnEditPatientInfo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(956, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 11250;
            this.label8.Text = "Discount (%)";
            // 
            // txtDiscountInPercent
            // 
            this.txtDiscountInPercent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountInPercent.Location = new System.Drawing.Point(1052, 179);
            this.txtDiscountInPercent.Name = "txtDiscountInPercent";
            this.txtDiscountInPercent.Size = new System.Drawing.Size(69, 32);
            this.txtDiscountInPercent.TabIndex = 11229;
            this.txtDiscountInPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountInPercent.TextChanged += new System.EventHandler(this.txtDiscountInPercent_TextChanged);
            // 
            // cmdCollection
            // 
            this.cmdCollection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCollection.Location = new System.Drawing.Point(781, 415);
            this.cmdCollection.Name = "cmdCollection";
            this.cmdCollection.Size = new System.Drawing.Size(92, 47);
            this.cmdCollection.TabIndex = 11249;
            this.cmdCollection.Text = "Collection";
            this.cmdCollection.UseVisualStyleBackColor = true;
            this.cmdCollection.Click += new System.EventHandler(this.cmdCollection_Click);
            // 
            // txtPaid
            // 
            this.txtPaid.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(1056, 361);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(133, 39);
            this.txtPaid.TabIndex = 11231;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaid.TextChanged += new System.EventHandler(this.txtPaid_TextChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(951, 224);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(99, 20);
            this.lblDiscount.TabIndex = 11227;
            this.lblDiscount.Text = "Discount (Tk.)";
            // 
            // lblCareOf
            // 
            this.lblCareOf.AutoSize = true;
            this.lblCareOf.BackColor = System.Drawing.Color.Transparent;
            this.lblCareOf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCareOf.Location = new System.Drawing.Point(735, 179);
            this.lblCareOf.Name = "lblCareOf";
            this.lblCareOf.Size = new System.Drawing.Size(74, 20);
            this.lblCareOf.TabIndex = 11223;
            this.lblCareOf.Text = "Total (Tk.)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(777, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 11235;
            this.label3.Text = "VAT";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.Location = new System.Drawing.Point(936, 361);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(124, 32);
            this.lblPayment.TabIndex = 11219;
            this.lblPayment.Text = "Paid (Tk.)";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(1052, 224);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(133, 32);
            this.txtDiscount.TabIndex = 11228;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(957, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 11234;
            this.label2.Text = "G. Total (Tk.)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVat
            // 
            this.txtVat.BackColor = System.Drawing.Color.White;
            this.txtVat.Enabled = false;
            this.txtVat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVat.Location = new System.Drawing.Point(819, 224);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(113, 32);
            this.txtVat.TabIndex = 11239;
            this.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.White;
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.Red;
            this.txtGrandTotal.Location = new System.Drawing.Point(1052, 269);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(133, 32);
            this.txtGrandTotal.TabIndex = 11240;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(993, 415);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(66, 47);
            this.btnNext.TabIndex = 11236;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1078, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 47);
            this.btnSave.TabIndex = 11232;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDue
            // 
            this.lblDue.AutoSize = true;
            this.lblDue.BackColor = System.Drawing.Color.Transparent;
            this.lblDue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(777, 269);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(36, 20);
            this.lblDue.TabIndex = 11221;
            this.lblDue.Text = "Due";
            // 
            // lblTotalPatientsValue
            // 
            this.lblTotalPatientsValue.AutoSize = true;
            this.lblTotalPatientsValue.Location = new System.Drawing.Point(625, 20);
            this.lblTotalPatientsValue.Name = "lblTotalPatientsValue";
            this.lblTotalPatientsValue.Size = new System.Drawing.Size(0, 13);
            this.lblTotalPatientsValue.TabIndex = 11248;
            // 
            // txtDue
            // 
            this.txtDue.BackColor = System.Drawing.Color.White;
            this.txtDue.Enabled = false;
            this.txtDue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.Red;
            this.txtDue.Location = new System.Drawing.Point(819, 269);
            this.txtDue.Name = "txtDue";
            this.txtDue.Size = new System.Drawing.Size(113, 32);
            this.txtDue.TabIndex = 11241;
            this.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeliveryTime
            // 
            this.txtDeliveryTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDeliveryTime.Location = new System.Drawing.Point(915, 113);
            this.txtDeliveryTime.Name = "txtDeliveryTime";
            this.txtDeliveryTime.Size = new System.Drawing.Size(107, 29);
            this.txtDeliveryTime.TabIndex = 11258;
            // 
            // lblDeliveryTime
            // 
            this.lblDeliveryTime.AutoSize = true;
            this.lblDeliveryTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveryTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryTime.Location = new System.Drawing.Point(911, 90);
            this.lblDeliveryTime.Name = "lblDeliveryTime";
            this.lblDeliveryTime.Size = new System.Drawing.Size(42, 20);
            this.lblDeliveryTime.TabIndex = 11247;
            this.lblDeliveryTime.Text = "Time";
            this.lblDeliveryTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(794, 113);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(107, 29);
            this.dtpDeliveryDate.TabIndex = 11257;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryDate.Location = new System.Drawing.Point(790, 90);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(59, 20);
            this.lblDeliveryDate.TabIndex = 11246;
            this.lblDeliveryDate.Text = "D. Date";
            // 
            // lblEntryDateValue
            // 
            this.lblEntryDateValue.AutoSize = true;
            this.lblEntryDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryDateValue.ForeColor = System.Drawing.Color.Red;
            this.lblEntryDateValue.Location = new System.Drawing.Point(678, 113);
            this.lblEntryDateValue.Name = "lblEntryDateValue";
            this.lblEntryDateValue.Size = new System.Drawing.Size(0, 18);
            this.lblEntryDateValue.TabIndex = 11245;
            // 
            // lblEntrtyDate
            // 
            this.lblEntrtyDate.AutoSize = true;
            this.lblEntrtyDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrtyDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrtyDate.Location = new System.Drawing.Point(680, 90);
            this.lblEntrtyDate.Name = "lblEntrtyDate";
            this.lblEntrtyDate.Size = new System.Drawing.Size(78, 20);
            this.lblEntrtyDate.TabIndex = 11244;
            this.lblEntrtyDate.Text = "Entry Date";
            this.lblEntrtyDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCellPhone.Location = new System.Drawing.Point(103, 56);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(199, 29);
            this.txtCellPhone.TabIndex = 11213;
            this.txtCellPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCellPhone_KeyPress);
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblCellPhone.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellPhone.Location = new System.Drawing.Point(22, 59);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(80, 20);
            this.lblCellPhone.TabIndex = 11243;
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
            this.cmbGender.Location = new System.Drawing.Point(1016, 55);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(97, 29);
            this.cmbGender.TabIndex = 11218;
            this.cmbGender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGender_KeyDown);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(953, 56);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 20);
            this.lblGender.TabIndex = 11242;
            this.lblGender.Text = "Gender";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(690, 56);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(36, 20);
            this.lblAge.TabIndex = 11238;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDailyId
            // 
            this.txtDailyId.BackColor = System.Drawing.Color.LightSalmon;
            this.txtDailyId.Enabled = false;
            this.txtDailyId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDailyId.Location = new System.Drawing.Point(418, -37);
            this.txtDailyId.Name = "txtDailyId";
            this.txtDailyId.Size = new System.Drawing.Size(97, 29);
            this.txtDailyId.TabIndex = 11256;
            // 
            // txtRegNo
            // 
            this.txtRegNo.BackColor = System.Drawing.Color.LightSalmon;
            this.txtRegNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtRegNo.Location = new System.Drawing.Point(103, 15);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(199, 29);
            this.txtRegNo.TabIndex = 11255;
            this.txtRegNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegNo_KeyPress);
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.BackColor = System.Drawing.Color.Transparent;
            this.lblRegNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(35, 15);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(62, 20);
            this.lblRegNo.TabIndex = 11233;
            this.lblRegNo.Text = "Reg. No";
            this.lblRegNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPatientName.Location = new System.Drawing.Point(363, 56);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(292, 29);
            this.txtPatientName.TabIndex = 11214;
            this.txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientName_KeyPress);
            this.txtPatientName.Leave += new System.EventHandler(this.txtPatientName_Leave);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(308, 56);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(49, 20);
            this.lblPatientName.TabIndex = 11225;
            this.lblPatientName.Text = "Name";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.BackColor = System.Drawing.Color.Transparent;
            this.lblRefBy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefBy.Location = new System.Drawing.Point(39, 91);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(63, 20);
            this.lblRefBy.TabIndex = 11222;
            this.lblRefBy.Text = "Refd. By";
            this.lblRefBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefBy
            // 
            this.txtRefBy.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefBy.Location = new System.Drawing.Point(103, 91);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(552, 29);
            this.txtRefBy.TabIndex = 11224;
            this.txtRefBy.TextChanged += new System.EventHandler(this.txtRefBy_TextChanged);
            // 
            // lblServiceTitle
            // 
            this.lblServiceTitle.AutoSize = true;
            this.lblServiceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceTitle.Location = new System.Drawing.Point(23, 170);
            this.lblServiceTitle.Name = "lblServiceTitle";
            this.lblServiceTitle.Size = new System.Drawing.Size(57, 18);
            this.lblServiceTitle.TabIndex = 11220;
            this.lblServiceTitle.Text = "Service";
            // 
            // txtService
            // 
            this.txtService.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.Location = new System.Drawing.Point(103, 170);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(304, 29);
            this.txtService.TabIndex = 11226;
            this.txtService.TextChanged += new System.EventHandler(this.txtService_TextChanged);
            this.txtService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtService_KeyPress);
            // 
            // ctlConsultantSearch
            // 
            this.ctlConsultantSearch.Location = new System.Drawing.Point(-250, 334);
            this.ctlConsultantSearch.Name = "ctlConsultantSearch";
            this.ctlConsultantSearch.Size = new System.Drawing.Size(1123, 401);
            this.ctlConsultantSearch.TabIndex = 11276;
            this.ctlConsultantSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Doctor>.SearchEscapeEventHandler(this.ctlConsultantSearch_SearchEsacaped);
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(26, 304);
            this.ctlDoctorSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(567, 470);
            this.ctlDoctorSearch.TabIndex = 11254;
            this.ctlDoctorSearch.Visible = false;
            this.ctlDoctorSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Doctor>.SearchEscapeEventHandler(this.ctlDoctorSearch_SearchEsacaped);
            // 
            // ctlOpdService
            // 
            this.ctlOpdService.Location = new System.Drawing.Point(173, 216);
            this.ctlOpdService.Name = "ctlOpdService";
            this.ctlOpdService.Size = new System.Drawing.Size(505, 489);
            this.ctlOpdService.TabIndex = 11273;
            this.ctlOpdService.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.OPD.VM.VMOPDServiceHead>.SearchEscapeEventHandler(this.ctlOpdService_SearchEsacaped);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic);
            this.txtDays.ForeColor = System.Drawing.Color.Gray;
            this.txtDays.Location = new System.Drawing.Point(886, 55);
            this.txtDays.Name = "txtDays";
            this.txtDays.PlaceHolderText = "Days";
            this.txtDays.Size = new System.Drawing.Size(61, 29);
            this.txtDays.TabIndex = 11217;
            this.txtDays.Text = "Days";
            this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // txtMonths
            // 
            this.txtMonths.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic);
            this.txtMonths.ForeColor = System.Drawing.Color.Gray;
            this.txtMonths.Location = new System.Drawing.Point(810, 56);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.PlaceHolderText = "Months";
            this.txtMonths.Size = new System.Drawing.Size(63, 29);
            this.txtMonths.TabIndex = 11216;
            this.txtMonths.Text = "Months";
            this.txtMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonths_KeyPress);
            // 
            // txtYears
            // 
            this.txtYears.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic);
            this.txtYears.ForeColor = System.Drawing.Color.Gray;
            this.txtYears.Location = new System.Drawing.Point(728, 56);
            this.txtYears.Name = "txtYears";
            this.txtYears.PlaceHolderText = "Years";
            this.txtYears.Size = new System.Drawing.Size(67, 29);
            this.txtYears.TabIndex = 11215;
            this.txtYears.Text = "Years";
            this.txtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYears_KeyPress);
            // 
            // OPDPatientEntryCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlConsultantSearch);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.cmbVisitType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ctlOpdService);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.dgService);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.txtPrevBill);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrevId);
            this.Controls.Add(this.btnNextId);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCareOf);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnEditPatientInfo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiscountInPercent);
            this.Controls.Add(this.cmdCollection);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblCareOf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVat);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblTotalPatientsValue);
            this.Controls.Add(this.txtDue);
            this.Controls.Add(this.txtDeliveryTime);
            this.Controls.Add(this.lblDeliveryTime);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.lblEntryDateValue);
            this.Controls.Add(this.lblEntrtyDate);
            this.Controls.Add(this.txtCellPhone);
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtDailyId);
            this.Controls.Add(this.txtRegNo);
            this.Controls.Add(this.lblRegNo);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblRefBy);
            this.Controls.Add(this.txtRefBy);
            this.Controls.Add(this.lblServiceTitle);
            this.Controls.Add(this.txtService);
            this.Name = "OPDPatientEntryCtrl";
            this.Size = new System.Drawing.Size(1270, 663);
            this.Load += new System.EventHandler(this.OPDPatientEntryCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgService)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Controls.DoctorSearchControl2 ctlConsultantSearch;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.ComboBox cmbVisitType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Label label10;
        private Controls.ctrlOPDServiceItem ctlOpdService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.DataGridView dgService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Controls.PlaceHolderTextBox txtDays;
        private Controls.PlaceHolderTextBox txtMonths;
        private Controls.PlaceHolderTextBox txtYears;
        private System.Windows.Forms.TextBox txtPrevBill;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscountedAmount;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrevId;
        private System.Windows.Forms.Button btnNextId;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCareOf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnEditPatientInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiscountInPercent;
        private System.Windows.Forms.Button cmdCollection;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblCareOf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label lblTotalPatientsValue;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.TextBox txtDeliveryTime;
        private System.Windows.Forms.Label lblDeliveryTime;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblEntryDateValue;
        private System.Windows.Forms.Label lblEntrtyDate;
        public System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtDailyId;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label lblServiceTitle;
        private System.Windows.Forms.TextBox txtService;
    }
}
