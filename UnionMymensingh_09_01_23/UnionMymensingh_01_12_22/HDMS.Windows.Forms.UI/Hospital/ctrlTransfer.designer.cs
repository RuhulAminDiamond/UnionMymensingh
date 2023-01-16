namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class ctrlTransfer
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtCabinTo = new System.Windows.Forms.TextBox();
            this.ctlCabinSearchFrom = new HDMS.Windows.Forms.UI.Controls.CabinSearchControl();
            this.ctlCabinSearchto = new HDMS.Windows.Forms.UI.Controls.CabinSearchControl();
            this.ctlPatientList = new HDMS.Windows.Forms.UI.Controls.HospitalPatientSearch();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTransferTime = new System.Windows.Forms.TextBox();
            this.dtpTransfer = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtCabinCharge = new System.Windows.Forms.TextBox();
            this.radioFree = new System.Windows.Forms.RadioButton();
            this.radioBooked = new System.Windows.Forms.RadioButton();
            this.btnTransferToExtraCabin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Assigned Doctor";
            // 
            // txtAssignedDoctor
            // 
            this.txtAssignedDoctor.Enabled = false;
            this.txtAssignedDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignedDoctor.Location = new System.Drawing.Point(231, 120);
            this.txtAssignedDoctor.Name = "txtAssignedDoctor";
            this.txtAssignedDoctor.Size = new System.Drawing.Size(359, 26);
            this.txtAssignedDoctor.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(154, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 43;
            this.label8.Text = "Cabin No";
            // 
            // txtCabinNo
            // 
            this.txtCabinNo.Enabled = false;
            this.txtCabinNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinNo.Location = new System.Drawing.Point(231, 85);
            this.txtCabinNo.Name = "txtCabinNo";
            this.txtCabinNo.Size = new System.Drawing.Size(359, 26);
            this.txtCabinNo.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(231, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 26);
            this.txtName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "Search Patient";
            // 
            // txtPatient
            // 
            this.txtPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatient.Location = new System.Drawing.Point(231, 20);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(251, 26);
            this.txtPatient.TabIndex = 38;
            this.txtPatient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatient_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "From Cabin ";
            // 
            // txtCabinfrm
            // 
            this.txtCabinfrm.Enabled = false;
            this.txtCabinfrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinfrm.Location = new System.Drawing.Point(231, 243);
            this.txtCabinfrm.Name = "txtCabinfrm";
            this.txtCabinfrm.Size = new System.Drawing.Size(251, 26);
            this.txtCabinfrm.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(509, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "To";
            // 
            // txtCabinTo
            // 
            this.txtCabinTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinTo.Location = new System.Drawing.Point(569, 243);
            this.txtCabinTo.Name = "txtCabinTo";
            this.txtCabinTo.Size = new System.Drawing.Size(251, 26);
            this.txtCabinTo.TabIndex = 48;
            this.txtCabinTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCabinTo_KeyPress);
            // 
            // ctlCabinSearchFrom
            // 
            this.ctlCabinSearchFrom.Location = new System.Drawing.Point(569, 288);
            this.ctlCabinSearchFrom.Name = "ctlCabinSearchFrom";
            this.ctlCabinSearchFrom.Size = new System.Drawing.Size(524, 483);
            this.ctlCabinSearchFrom.TabIndex = 50;
            this.ctlCabinSearchFrom.Visible = false;
            this.ctlCabinSearchFrom.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMCabinInfo>.SearchEscapeEventHandler(this.ctlCabinSearchFrom_SearchEsacaped);
            // 
            // ctlCabinSearchto
            // 
            this.ctlCabinSearchto.Location = new System.Drawing.Point(826, 85);
            this.ctlCabinSearchto.Name = "ctlCabinSearchto";
            this.ctlCabinSearchto.Size = new System.Drawing.Size(520, 412);
            this.ctlCabinSearchto.TabIndex = 51;
            this.ctlCabinSearchto.Visible = false;
            this.ctlCabinSearchto.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMCabinInfo>.SearchEscapeEventHandler(this.ctlCabinSearchto_SearchEsacaped);
            // 
            // ctlPatientList
            // 
            this.ctlPatientList.Location = new System.Drawing.Point(815, 197);
            this.ctlPatientList.Name = "ctlPatientList";
            this.ctlPatientList.Size = new System.Drawing.Size(649, 355);
            this.ctlPatientList.TabIndex = 52;
            this.ctlPatientList.Visible = false;
            this.ctlPatientList.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.ViewModel.VMIPDInfo>.SearchEscapeEventHandler(this.ctlPatientList_SearchEsacaped);
            this.ctlPatientList.Load += new System.EventHandler(this.ctlPatientList_Load);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(231, 323);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(119, 36);
            this.btnTransfer.TabIndex = 53;
            this.btnTransfer.Text = "Transfer Now";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(231, 152);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(359, 39);
            this.txtRemarks.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(154, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 55;
            this.label5.Text = "Remarks";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(582, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 82;
            this.label11.Text = "Transfer on";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransferTime
            // 
            this.txtTransferTime.Enabled = false;
            this.txtTransferTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTransferTime.Location = new System.Drawing.Point(806, 17);
            this.txtTransferTime.Name = "txtTransferTime";
            this.txtTransferTime.Size = new System.Drawing.Size(159, 29);
            this.txtTransferTime.TabIndex = 81;
            this.txtTransferTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpTransfer
            // 
            this.dtpTransfer.CustomFormat = "dd-MM-yyyy";
            this.dtpTransfer.Enabled = false;
            this.dtpTransfer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransfer.Location = new System.Drawing.Point(693, 17);
            this.dtpTransfer.Name = "dtpTransfer";
            this.dtpTransfer.Size = new System.Drawing.Size(107, 29);
            this.dtpTransfer.TabIndex = 80;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 84;
            this.label6.Text = "Cabin charge";
            // 
            // txtCabinCharge
            // 
            this.txtCabinCharge.Enabled = false;
            this.txtCabinCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCabinCharge.Location = new System.Drawing.Point(231, 197);
            this.txtCabinCharge.Name = "txtCabinCharge";
            this.txtCabinCharge.Size = new System.Drawing.Size(163, 26);
            this.txtCabinCharge.TabIndex = 83;
            // 
            // radioFree
            // 
            this.radioFree.AutoSize = true;
            this.radioFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFree.Location = new System.Drawing.Point(231, 288);
            this.radioFree.Name = "radioFree";
            this.radioFree.Size = new System.Drawing.Size(149, 19);
            this.radioFree.TabIndex = 85;
            this.radioFree.TabStop = true;
            this.radioFree.Text = "Release Current Cabin";
            this.radioFree.UseVisualStyleBackColor = true;
            // 
            // radioBooked
            // 
            this.radioBooked.AutoSize = true;
            this.radioBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBooked.Location = new System.Drawing.Point(403, 288);
            this.radioBooked.Name = "radioBooked";
            this.radioBooked.Size = new System.Drawing.Size(132, 19);
            this.radioBooked.TabIndex = 86;
            this.radioBooked.TabStop = true;
            this.radioBooked.Text = "Keep Current Cabin";
            this.radioBooked.UseVisualStyleBackColor = true;
            // 
            // btnTransferToExtraCabin
            // 
            this.btnTransferToExtraCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferToExtraCabin.Location = new System.Drawing.Point(363, 323);
            this.btnTransferToExtraCabin.Name = "btnTransferToExtraCabin";
            this.btnTransferToExtraCabin.Size = new System.Drawing.Size(189, 36);
            this.btnTransferToExtraCabin.TabIndex = 87;
            this.btnTransferToExtraCabin.Text = "Transfer to Extra Cabin";
            this.btnTransferToExtraCabin.UseVisualStyleBackColor = true;
            this.btnTransferToExtraCabin.Click += new System.EventHandler(this.btnTransferToExtraCabin_Click);
            // 
            // ctrlTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlCabinSearchFrom);
            this.Controls.Add(this.ctlPatientList);
            this.Controls.Add(this.ctlCabinSearchto);
            this.Controls.Add(this.btnTransferToExtraCabin);
            this.Controls.Add(this.radioBooked);
            this.Controls.Add(this.radioFree);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCabinCharge);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTransferTime);
            this.Controls.Add(this.dtpTransfer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCabinTo);
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
            this.Name = "ctrlTransfer";
            this.Size = new System.Drawing.Size(1144, 547);
            this.Load += new System.EventHandler(this.ctrlTransfer_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCabinfrm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCabinTo;
        private Controls.CabinSearchControl ctlCabinSearchFrom;
        private Controls.CabinSearchControl ctlCabinSearchto;
        private Controls.HospitalPatientSearch ctlPatientList;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTransferTime;
        private System.Windows.Forms.DateTimePicker dtpTransfer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCabinCharge;
        private System.Windows.Forms.RadioButton radioFree;
        private System.Windows.Forms.RadioButton radioBooked;
        private System.Windows.Forms.Button btnTransferToExtraCabin;
    }
}
