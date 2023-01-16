namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmAddReferral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddReferral));
            this.txtReferral = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelfDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequestAdjustment = new System.Windows.Forms.TextBox();
            this.cmbRefType = new System.Windows.Forms.ComboBox();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCFIDP = new System.Windows.Forms.TextBox();
            this.rdIsOPDNo = new System.Windows.Forms.RadioButton();
            this.rdIsOPDYes = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbConsultancyType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCFBrandNew = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCpPercent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHpPercent = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDoctorSearch = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCFNew = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCFReportOpinion = new System.Windows.Forms.TextBox();
            this.ctlDoctorSearch = new HDMS.Windows.Forms.UI.Controls.DoctorSearchControl();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCFGuestOrStaff = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCFOld = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtReferral
            // 
            this.txtReferral.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferral.Location = new System.Drawing.Point(217, 62);
            this.txtReferral.Name = "txtReferral";
            this.txtReferral.Size = new System.Drawing.Size(289, 27);
            this.txtReferral.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Name";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(218, 352);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(114, 38);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Referral Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Self Discount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSelfDiscount
            // 
            this.txtSelfDiscount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelfDiscount.Location = new System.Drawing.Point(217, 151);
            this.txtSelfDiscount.Name = "txtSelfDiscount";
            this.txtSelfDiscount.Size = new System.Drawing.Size(134, 27);
            this.txtSelfDiscount.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Is Full Free";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Request Adjustment";
            // 
            // txtRequestAdjustment
            // 
            this.txtRequestAdjustment.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestAdjustment.Location = new System.Drawing.Point(217, 243);
            this.txtRequestAdjustment.Name = "txtRequestAdjustment";
            this.txtRequestAdjustment.Size = new System.Drawing.Size(107, 27);
            this.txtRequestAdjustment.TabIndex = 9;
            // 
            // cmbRefType
            // 
            this.cmbRefType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefType.FormattingEnabled = true;
            this.cmbRefType.Location = new System.Drawing.Point(217, 109);
            this.cmbRefType.Name = "cmbRefType";
            this.cmbRefType.Size = new System.Drawing.Size(251, 28);
            this.cmbRefType.TabIndex = 11;
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Location = new System.Drawing.Point(217, 200);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(43, 17);
            this.rdYes.TabIndex = 12;
            this.rdYes.Text = "Yes";
            this.rdYes.UseVisualStyleBackColor = true;
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(285, 200);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 13;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(602, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "C. Fee (IPD)";
            // 
            // txtCFIDP
            // 
            this.txtCFIDP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFIDP.Location = new System.Drawing.Point(693, 301);
            this.txtCFIDP.Name = "txtCFIDP";
            this.txtCFIDP.Size = new System.Drawing.Size(134, 27);
            this.txtCFIDP.TabIndex = 15;
            // 
            // rdIsOPDNo
            // 
            this.rdIsOPDNo.AutoSize = true;
            this.rdIsOPDNo.Location = new System.Drawing.Point(761, 65);
            this.rdIsOPDNo.Name = "rdIsOPDNo";
            this.rdIsOPDNo.Size = new System.Drawing.Size(39, 17);
            this.rdIsOPDNo.TabIndex = 19;
            this.rdIsOPDNo.Text = "No";
            this.rdIsOPDNo.UseVisualStyleBackColor = true;
            this.rdIsOPDNo.Click += new System.EventHandler(this.rdIsOPDNo_Click);
            // 
            // rdIsOPDYes
            // 
            this.rdIsOPDYes.AutoSize = true;
            this.rdIsOPDYes.Checked = true;
            this.rdIsOPDYes.Location = new System.Drawing.Point(693, 65);
            this.rdIsOPDYes.Name = "rdIsOPDYes";
            this.rdIsOPDYes.Size = new System.Drawing.Size(43, 17);
            this.rdIsOPDYes.TabIndex = 18;
            this.rdIsOPDYes.TabStop = true;
            this.rdIsOPDYes.Text = "Yes";
            this.rdIsOPDYes.UseVisualStyleBackColor = true;
            this.rdIsOPDYes.Click += new System.EventHandler(this.rdIsOPDYes_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(550, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Is OPD Consultant ?";
            // 
            // cmbDept
            // 
            this.cmbDept.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(693, 101);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(206, 28);
            this.cmbDept.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(550, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Select Department";
            // 
            // cmbConsultancyType
            // 
            this.cmbConsultancyType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsultancyType.FormattingEnabled = true;
            this.cmbConsultancyType.Location = new System.Drawing.Point(693, 135);
            this.cmbConsultancyType.Name = "cmbConsultancyType";
            this.cmbConsultancyType.Size = new System.Drawing.Size(259, 28);
            this.cmbConsultancyType.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(539, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Consultantancy Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(553, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "C. Fee (Brand New)";
            // 
            // txtCFBrandNew
            // 
            this.txtCFBrandNew.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFBrandNew.Location = new System.Drawing.Point(693, 169);
            this.txtCFBrandNew.Name = "txtCFBrandNew";
            this.txtCFBrandNew.Size = new System.Drawing.Size(134, 27);
            this.txtCFBrandNew.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(631, 370);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Cp.(%)";
            // 
            // txtCpPercent
            // 
            this.txtCpPercent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpPercent.Location = new System.Drawing.Point(693, 370);
            this.txtCpPercent.Name = "txtCpPercent";
            this.txtCpPercent.Size = new System.Drawing.Size(134, 27);
            this.txtCpPercent.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(631, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 29;
            this.label13.Text = "Hp.(%)";
            // 
            // txtHpPercent
            // 
            this.txtHpPercent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHpPercent.Location = new System.Drawing.Point(693, 403);
            this.txtHpPercent.Name = "txtHpPercent";
            this.txtHpPercent.Size = new System.Drawing.Size(134, 27);
            this.txtHpPercent.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(106, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Search Doctor";
            // 
            // txtDoctorSearch
            // 
            this.txtDoctorSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorSearch.Location = new System.Drawing.Point(217, 20);
            this.txtDoctorSearch.Name = "txtDoctorSearch";
            this.txtDoctorSearch.Size = new System.Drawing.Size(471, 27);
            this.txtDoctorSearch.TabIndex = 30;
            this.txtDoctorSearch.TextChanged += new System.EventHandler(this.txtDoctorSearch_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(347, 352);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 38);
            this.btnClose.TabIndex = 10021;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(596, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 20);
            this.label15.TabIndex = 10023;
            this.label15.Text = "C. Fee (New)";
            // 
            // txtCFNew
            // 
            this.txtCFNew.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFNew.Location = new System.Drawing.Point(693, 202);
            this.txtCFNew.Name = "txtCFNew";
            this.txtCFNew.Size = new System.Drawing.Size(134, 27);
            this.txtCFNew.TabIndex = 10022;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(524, 337);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 20);
            this.label16.TabIndex = 10025;
            this.label16.Text = "C. Fee (Report Opinion)";
            // 
            // txtCFReportOpinion
            // 
            this.txtCFReportOpinion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFReportOpinion.Location = new System.Drawing.Point(693, 337);
            this.txtCFReportOpinion.Name = "txtCFReportOpinion";
            this.txtCFReportOpinion.Size = new System.Drawing.Size(134, 27);
            this.txtCFReportOpinion.TabIndex = 10024;
            // 
            // ctlDoctorSearch
            // 
            this.ctlDoctorSearch.Location = new System.Drawing.Point(57, 413);
            this.ctlDoctorSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlDoctorSearch.Name = "ctlDoctorSearch";
            this.ctlDoctorSearch.Size = new System.Drawing.Size(567, 415);
            this.ctlDoctorSearch.TabIndex = 10020;
            this.ctlDoctorSearch.Visible = false;
            this.ctlDoctorSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Doctor>.SearchEscapeEventHandler(this.ctlDoctorSearch_SearchEsacaped);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(552, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 20);
            this.label17.TabIndex = 10029;
            this.label17.Text = "C. Fee (Guest/Staff)";
            // 
            // txtCFGuestOrStaff
            // 
            this.txtCFGuestOrStaff.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFGuestOrStaff.Location = new System.Drawing.Point(693, 268);
            this.txtCFGuestOrStaff.Name = "txtCFGuestOrStaff";
            this.txtCFGuestOrStaff.Size = new System.Drawing.Size(134, 27);
            this.txtCFGuestOrStaff.TabIndex = 10028;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(602, 235);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 20);
            this.label18.TabIndex = 10027;
            this.label18.Text = "C. Fee (Old)";
            // 
            // txtCFOld
            // 
            this.txtCFOld.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCFOld.Location = new System.Drawing.Point(693, 235);
            this.txtCFOld.Name = "txtCFOld";
            this.txtCFOld.Size = new System.Drawing.Size(134, 27);
            this.txtCFOld.TabIndex = 10026;
            // 
            // frmAddReferral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 493);
            this.Controls.Add(this.ctlDoctorSearch);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCFGuestOrStaff);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCFOld);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCFReportOpinion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCFNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDoctorSearch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtHpPercent);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCpPercent);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCFBrandNew);
            this.Controls.Add(this.cmbConsultancyType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rdIsOPDNo);
            this.Controls.Add(this.rdIsOPDYes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCFIDP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdYes);
            this.Controls.Add(this.cmbRefType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRequestAdjustment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSelfDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReferral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddReferral";
            this.Text = "Add Referral";
            this.Load += new System.EventHandler(this.frmAddReferral_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReferral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelfDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRequestAdjustment;
        private System.Windows.Forms.ComboBox cmbRefType;
        private System.Windows.Forms.RadioButton rdYes;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCFIDP;
        private System.Windows.Forms.RadioButton rdIsOPDNo;
        private System.Windows.Forms.RadioButton rdIsOPDYes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbConsultancyType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCFBrandNew;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCpPercent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtHpPercent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDoctorSearch;
        private Controls.DoctorSearchControl ctlDoctorSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCFNew;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCFReportOpinion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCFGuestOrStaff;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCFOld;
    }
}