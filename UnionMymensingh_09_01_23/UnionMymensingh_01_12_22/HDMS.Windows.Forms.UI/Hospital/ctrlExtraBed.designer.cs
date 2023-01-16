namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlExtraBed
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssignedDoctor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCabinNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCabinfrm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAllotmentTime = new System.Windows.Forms.TextBox();
            this.dtpAllotmentDate = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtCabinRent = new System.Windows.Forms.TextBox();
            this.btnAllot = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAllotedExtraCabinCharge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAllotCabin = new System.Windows.Forms.TextBox();
            this.ctlPatientList = new HDMS.Windows.Forms.UI.Controls.HospitalPatientSearch();
            this.ctrlCabinSearchAllot = new HDMS.Windows.Forms.UI.Controls.CabinSearchControl();
            this.ctlCabinSearchFrom = new HDMS.Windows.Forms.UI.Controls.ExtraCabinSearchControl();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(97, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 18);
            this.label9.TabIndex = 53;
            this.label9.Text = "Assigned Doctor";
            // 
            // txtAssignedDoctor
            // 
            this.txtAssignedDoctor.Enabled = false;
            this.txtAssignedDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedDoctor.Location = new System.Drawing.Point(222, 143);
            this.txtAssignedDoctor.Name = "txtAssignedDoctor";
            this.txtAssignedDoctor.Size = new System.Drawing.Size(359, 26);
            this.txtAssignedDoctor.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(145, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 51;
            this.label8.Text = "Cabin No";
            // 
            // txtCabinNo
            // 
            this.txtCabinNo.Enabled = false;
            this.txtCabinNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinNo.Location = new System.Drawing.Point(222, 108);
            this.txtCabinNo.Name = "txtCabinNo";
            this.txtCabinNo.Size = new System.Drawing.Size(359, 26);
            this.txtCabinNo.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(167, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 49;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(222, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 26);
            this.txtName.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Search Patient";
            // 
            // txtPatient
            // 
            this.txtPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatient.Location = new System.Drawing.Point(222, 43);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(251, 26);
            this.txtPatient.TabIndex = 46;
            this.txtPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatient_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "Select Extra Cabin To Release";
            // 
            // txtCabinfrm
            // 
            this.txtCabinfrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinfrm.Location = new System.Drawing.Point(222, 211);
            this.txtCabinfrm.Name = "txtCabinfrm";
            this.txtCabinfrm.Size = new System.Drawing.Size(251, 26);
            this.txtCabinfrm.TabIndex = 56;
            this.txtCabinfrm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCabinfrm_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(541, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 20);
            this.label11.TabIndex = 85;
            this.label11.Text = "Allotment Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAllotmentTime
            // 
            this.txtAllotmentTime.Enabled = false;
            this.txtAllotmentTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAllotmentTime.Location = new System.Drawing.Point(789, 38);
            this.txtAllotmentTime.Name = "txtAllotmentTime";
            this.txtAllotmentTime.Size = new System.Drawing.Size(141, 29);
            this.txtAllotmentTime.TabIndex = 84;
            this.txtAllotmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpAllotmentDate
            // 
            this.dtpAllotmentDate.CustomFormat = "dd-MM-yyyy";
            this.dtpAllotmentDate.Enabled = false;
            this.dtpAllotmentDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpAllotmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAllotmentDate.Location = new System.Drawing.Point(658, 38);
            this.dtpAllotmentDate.Name = "dtpAllotmentDate";
            this.dtpAllotmentDate.Size = new System.Drawing.Size(125, 29);
            this.dtpAllotmentDate.TabIndex = 83;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(134, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 87;
            this.label4.Text = "Cabin Rent";
            // 
            // txtCabinRent
            // 
            this.txtCabinRent.Enabled = false;
            this.txtCabinRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinRent.Location = new System.Drawing.Point(222, 250);
            this.txtCabinRent.Name = "txtCabinRent";
            this.txtCabinRent.Size = new System.Drawing.Size(107, 26);
            this.txtCabinRent.TabIndex = 86;
            // 
            // btnAllot
            // 
            this.btnAllot.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllot.Location = new System.Drawing.Point(222, 338);
            this.btnAllot.Name = "btnAllot";
            this.btnAllot.Size = new System.Drawing.Size(128, 31);
            this.btnAllot.TabIndex = 88;
            this.btnAllot.Text = "Allot Exra Cabin";
            this.btnAllot.UseVisualStyleBackColor = true;
            this.btnAllot.Click += new System.EventHandler(this.btnAllot_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Location = new System.Drawing.Point(372, 338);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(151, 31);
            this.btnRelease.TabIndex = 89;
            this.btnRelease.Text = "Release Extra Cabin";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 91;
            this.label5.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(222, 282);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(317, 39);
            this.txtRemarks.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(599, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 18);
            this.label6.TabIndex = 93;
            this.label6.Text = "Alloted Extra Cabin Charge";
            // 
            // txtAllotedExtraCabinCharge
            // 
            this.txtAllotedExtraCabinCharge.Enabled = false;
            this.txtAllotedExtraCabinCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllotedExtraCabinCharge.Location = new System.Drawing.Point(789, 108);
            this.txtAllotedExtraCabinCharge.Name = "txtAllotedExtraCabinCharge";
            this.txtAllotedExtraCabinCharge.Size = new System.Drawing.Size(141, 26);
            this.txtAllotedExtraCabinCharge.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 18);
            this.label7.TabIndex = 96;
            this.label7.Text = "Select Cabin To Allot";
            // 
            // txtAllotCabin
            // 
            this.txtAllotCabin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllotCabin.Location = new System.Drawing.Point(222, 179);
            this.txtAllotCabin.Name = "txtAllotCabin";
            this.txtAllotCabin.Size = new System.Drawing.Size(251, 26);
            this.txtAllotCabin.TabIndex = 95;
            this.txtAllotCabin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllotCabin_KeyPress);
            // 
            // ctlPatientList
            // 
            this.ctlPatientList.Location = new System.Drawing.Point(636, 99);
            this.ctlPatientList.Name = "ctlPatientList";
            this.ctlPatientList.Size = new System.Drawing.Size(649, 443);
            this.ctlPatientList.TabIndex = 54;
            this.ctlPatientList.Visible = false;
            this.ctlPatientList.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMIPDInfo>.SearchEscapeEventHandler(this.ctlPatientList_SearchEsacaped);
            // 
            // ctrlCabinSearchAllot
            // 
            this.ctrlCabinSearchAllot.Location = new System.Drawing.Point(713, 73);
            this.ctrlCabinSearchAllot.Name = "ctrlCabinSearchAllot";
            this.ctrlCabinSearchAllot.Size = new System.Drawing.Size(527, 536);
            this.ctrlCabinSearchAllot.TabIndex = 97;
            this.ctrlCabinSearchAllot.Visible = false;
            this.ctrlCabinSearchAllot.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMCabinInfo>.SearchEscapeEventHandler(this.ctrlCabinSearchAllot_SearchEsacaped);
            // 
            // ctlCabinSearchFrom
            // 
            this.ctlCabinSearchFrom.Location = new System.Drawing.Point(602, 61);
            this.ctlCabinSearchFrom.Name = "ctlCabinSearchFrom";
            this.ctlCabinSearchFrom.Size = new System.Drawing.Size(529, 532);
            this.ctlCabinSearchFrom.TabIndex = 94;
            this.ctlCabinSearchFrom.Visible = false;
            this.ctlCabinSearchFrom.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMCabinInfo>.SearchEscapeEventHandler(this.ctlCabinSearchFrom_SearchEsacaped);
            // 
            // ctrlExtraBed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlPatientList);
            this.Controls.Add(this.ctrlCabinSearchAllot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAllotCabin);
            this.Controls.Add(this.ctlCabinSearchFrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAllotedExtraCabinCharge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnAllot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCabinRent);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAllotmentTime);
            this.Controls.Add(this.dtpAllotmentDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCabinfrm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAssignedDoctor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCabinNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatient);
            this.Name = "ctrlExtraBed";
            this.Size = new System.Drawing.Size(1095, 694);
            this.Load += new System.EventHandler(this.ctrlExtraBed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAssignedDoctor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCabinNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatient;
        private Controls.HospitalPatientSearch ctlPatientList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCabinfrm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAllotmentTime;
        private System.Windows.Forms.DateTimePicker dtpAllotmentDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCabinRent;
        private System.Windows.Forms.Button btnAllot;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAllotedExtraCabinCharge;
        private Controls.ExtraCabinSearchControl ctlCabinSearchFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAllotCabin;
        private Controls.CabinSearchControl ctrlCabinSearchAllot;
    }
}
