namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmTemplateBasedDischarge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateBasedDischarge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchByCabin = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.dtpDischarge = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCabin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.lvReports = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMedicalOfficer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ctrlMedicalOfficerSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportConsultantSearchControl();
            this.ctrlDischareTemplateSearchControl = new HDMS.Windows.Forms.UI.Controls.DischargeTemplateSearchControl();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 749);
            this.panel1.TabIndex = 10067;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgPatient, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchByCabin, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.484407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.51559F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 749);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgPatient
            // 
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatient.Location = new System.Drawing.Point(3, 59);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.Size = new System.Drawing.Size(379, 687);
            this.dgPatient.TabIndex = 0;
            this.dgPatient.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatient_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cabin No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Patinet Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Adm. Date";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // txtSearchByCabin
            // 
            this.txtSearchByCabin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchByCabin.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchByCabin.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchByCabin.Location = new System.Drawing.Point(56, 15);
            this.txtSearchByCabin.Name = "txtSearchByCabin";
            this.txtSearchByCabin.PlaceHolderText = "Search by cabin";
            this.txtSearchByCabin.Size = new System.Drawing.Size(272, 25);
            this.txtSearchByCabin.TabIndex = 1;
            this.txtSearchByCabin.Text = "Search by cabin";
            this.txtSearchByCabin.TextChanged += new System.EventHandler(this.txtSearchByCabin_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(422, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 20);
            this.label11.TabIndex = 10060;
            this.label11.Text = "Billing Date_Time";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTime.Location = new System.Drawing.Point(667, 10);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(159, 29);
            this.txtTime.TabIndex = 10059;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDischarge
            // 
            this.dtpDischarge.CustomFormat = "dd-MM-yyyy";
            this.dtpDischarge.Enabled = false;
            this.dtpDischarge.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDischarge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDischarge.Location = new System.Drawing.Point(554, 10);
            this.dtpDischarge.Name = "dtpDischarge";
            this.dtpDischarge.Size = new System.Drawing.Size(107, 29);
            this.dtpDischarge.TabIndex = 10058;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCabin
            // 
            this.lblCabin.AutoSize = true;
            this.lblCabin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabin.ForeColor = System.Drawing.Color.Red;
            this.lblCabin.Location = new System.Drawing.Point(965, 55);
            this.lblCabin.Name = "lblCabin";
            this.lblCabin.Size = new System.Drawing.Size(0, 20);
            this.lblCabin.TabIndex = 10071;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(909, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 21);
            this.label8.TabIndex = 10070;
            this.label8.Text = "Cabin :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(500, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 10069;
            this.label9.Text = "Name :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(559, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10068;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 10073;
            this.label1.Text = "Select Template";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.Location = new System.Drawing.Point(554, 98);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(476, 29);
            this.txtTemplate.TabIndex = 10072;
            this.txtTemplate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemplate_KeyPress);
            // 
            // lvReports
            // 
            this.lvReports.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvReports.BackColor = System.Drawing.Color.Lavender;
            this.lvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvReports.GridLines = true;
            this.lvReports.HideSelection = false;
            this.lvReports.HoverSelection = true;
            this.lvReports.Location = new System.Drawing.Point(9, 10);
            this.lvReports.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.lvReports.Name = "lvReports";
            this.lvReports.ShowItemToolTips = true;
            this.lvReports.Size = new System.Drawing.Size(753, 438);
            this.lvReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lvReports);
            this.panel2.Location = new System.Drawing.Point(426, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 462);
            this.panel2.TabIndex = 10074;
            // 
            // txtMedicalOfficer
            // 
            this.txtMedicalOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicalOfficer.Location = new System.Drawing.Point(554, 131);
            this.txtMedicalOfficer.Name = "txtMedicalOfficer";
            this.txtMedicalOfficer.Size = new System.Drawing.Size(638, 22);
            this.txtMedicalOfficer.TabIndex = 10140;
            this.txtMedicalOfficer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedicalOfficer_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(456, 131);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 15);
            this.label15.TabIndex = 10139;
            this.label15.Text = "Medical Officer";
            // 
            // ctrlMedicalOfficerSearchControl
            // 
            this.ctrlMedicalOfficerSearchControl.Location = new System.Drawing.Point(1170, 4);
            this.ctrlMedicalOfficerSearchControl.Name = "ctrlMedicalOfficerSearchControl";
            this.ctrlMedicalOfficerSearchControl.Size = new System.Drawing.Size(1066, 519);
            this.ctrlMedicalOfficerSearchControl.TabIndex = 10141;
            this.ctrlMedicalOfficerSearchControl.Visible = false;
            this.ctrlMedicalOfficerSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportConsultant>.SearchEscapeEventHandler(this.ctrlMedicalOfficerSearchControl_SearchEsacaped);
            // 
            // ctrlDischareTemplateSearchControl
            // 
            this.ctrlDischareTemplateSearchControl.Location = new System.Drawing.Point(-154, 0);
            this.ctrlDischareTemplateSearchControl.Name = "ctrlDischareTemplateSearchControl";
            this.ctrlDischareTemplateSearchControl.Size = new System.Drawing.Size(606, 523);
            this.ctrlDischareTemplateSearchControl.TabIndex = 10075;
            this.ctrlDischareTemplateSearchControl.Visible = false;
            this.ctrlDischareTemplateSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Hospital.DischargeTemplate>.SearchEscapeEventHandler(this.ctrlDischareTemplateSearchControl_SearchEsacaped);
            // 
            // frmTemplateBasedDischarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 749);
            this.Controls.Add(this.ctrlMedicalOfficerSearchControl);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ctrlDischareTemplateSearchControl);
            this.Controls.Add(this.txtMedicalOfficer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.lblCabin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.dtpDischarge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTemplateBasedDischarge";
            this.Text = "Discharge";
            this.Load += new System.EventHandler(this.frmTemplateBasedDischarge_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Controls.PlaceHolderTextBox txtSearchByCabin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.DateTimePicker dtpDischarge;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCabin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.Panel panel2;
        private Controls.DischargeTemplateSearchControl ctrlDischareTemplateSearchControl;
        private Controls.ReportConsultantSearchControl ctrlMedicalOfficerSearchControl;
        private System.Windows.Forms.TextBox txtMedicalOfficer;
        private System.Windows.Forms.Label label15;
    }
}