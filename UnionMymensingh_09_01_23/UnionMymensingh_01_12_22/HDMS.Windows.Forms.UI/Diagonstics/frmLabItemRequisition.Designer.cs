﻿namespace HDMS.Windows.Forms.UI.Hospital
{
    partial class frmLabItemRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabItemRequisition));
            this.btnPrint = new System.Windows.Forms.Button();
            this.ItemDrescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRequisitionby = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEntryDateValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDrescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRequisition = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblInchargeName = new System.Windows.Forms.Label();
            this.lvLabs = new System.Windows.Forms.ListView();
            this.imgListLab = new System.Windows.Forms.ImageList(this.components);
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.lblLoggedInInfo = new System.Windows.Forms.Label();
            this.lblRequisitionPanel = new System.Windows.Forms.Panel();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgServed = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgRequisitionList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRequistions = new System.Windows.Forms.DataGridView();
            this.RequisitionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CabinNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlProductSearch = new HDMS.Windows.Forms.UI.Controls.StoreProductSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisition)).BeginInit();
            this.lblRequisitionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisitionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequistions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnPrint.Location = new System.Drawing.Point(737, 548);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 34);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // ItemDrescription
            // 
            this.ItemDrescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemDrescription.HeaderText = "Item Drescription";
            this.ItemDrescription.Name = "ItemDrescription";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(905, 593);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 20);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(833, 593);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 20);
            this.btnPrev.TabIndex = 45;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Enabled = false;
            this.txtTotalItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.Location = new System.Drawing.Point(460, 553);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.Size = new System.Drawing.Size(80, 29);
            this.txtTotalItem.TabIndex = 11;
            this.txtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(345, 553);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 21);
            this.label20.TabIndex = 12;
            this.label20.Text = "Total Items :";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // txtRequisitionby
            // 
            this.txtRequisitionby.Enabled = false;
            this.txtRequisitionby.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequisitionby.Location = new System.Drawing.Point(460, 588);
            this.txtRequisitionby.Name = "txtRequisitionby";
            this.txtRequisitionby.Size = new System.Drawing.Size(124, 25);
            this.txtRequisitionby.TabIndex = 10;
            this.txtRequisitionby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(345, 585);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Requisition by";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(807, 50);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 20);
            this.lblTime.TabIndex = 10023;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(723, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date Time :";
            // 
            // lblEntryDateValue
            // 
            this.lblEntryDateValue.AutoSize = true;
            this.lblEntryDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryDateValue.ForeColor = System.Drawing.Color.Red;
            this.lblEntryDateValue.Location = new System.Drawing.Point(807, 25);
            this.lblEntryDateValue.Name = "lblEntryDateValue";
            this.lblEntryDateValue.Size = new System.Drawing.Size(0, 18);
            this.lblEntryDateValue.TabIndex = 10022;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Lab From Below List";
            // 
            // txtDrescription
            // 
            this.txtDrescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrescription.Location = new System.Drawing.Point(572, 126);
            this.txtDrescription.Name = "txtDrescription";
            this.txtDrescription.Size = new System.Drawing.Size(303, 29);
            this.txtDrescription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(568, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Item Description";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(881, 126);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 29);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(349, 126);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(173, 29);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(344, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Product Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(891, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "Quantity";
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.Width = 150;
            // 
            // dgRequisition
            // 
            this.dgRequisition.AllowUserToAddRows = false;
            this.dgRequisition.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgRequisition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequisition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemDrescription,
            this.Quantity,
            this.Unit});
            this.dgRequisition.Location = new System.Drawing.Point(349, 161);
            this.dgRequisition.Name = "dgRequisition";
            this.dgRequisition.Size = new System.Drawing.Size(612, 384);
            this.dgRequisition.TabIndex = 18;
            this.dgRequisition.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgRequisition_UserDeletedRow);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Location = new System.Drawing.Point(857, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 34);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Location = new System.Drawing.Point(647, 548);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 34);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(488, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 18);
            this.lblName.TabIndex = 10028;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(429, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 19);
            this.label8.TabIndex = 10029;
            this.label8.Text = "Name :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(369, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 19);
            this.label11.TabIndex = 10030;
            this.label11.Text = "Incharge Name :";
            // 
            // lblInchargeName
            // 
            this.lblInchargeName.AutoSize = true;
            this.lblInchargeName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInchargeName.ForeColor = System.Drawing.Color.Red;
            this.lblInchargeName.Location = new System.Drawing.Point(490, 53);
            this.lblInchargeName.Name = "lblInchargeName";
            this.lblInchargeName.Size = new System.Drawing.Size(0, 18);
            this.lblInchargeName.TabIndex = 10031;
            // 
            // lvLabs
            // 
            this.lvLabs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLabs.HideSelection = false;
            this.lvLabs.LargeImageList = this.imgListLab;
            this.lvLabs.Location = new System.Drawing.Point(4, 45);
            this.lvLabs.Name = "lvLabs";
            this.lvLabs.Size = new System.Drawing.Size(334, 579);
            this.lvLabs.SmallImageList = this.imgListLab;
            this.lvLabs.TabIndex = 10032;
            this.lvLabs.UseCompatibleStateImageBehavior = false;
            this.lvLabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvLabs_MouseClick);
            // 
            // imgListLab
            // 
            this.imgListLab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLab.ImageStream")));
            this.imgListLab.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLab.Images.SetKeyName(0, "lab.jpg");
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "BedImageIcon.BMP");
            this.imgListLarge.Images.SetKeyName(1, "cabin.bmp");
            this.imgListLarge.Images.SetKeyName(2, "images.jpg");
            // 
            // lblLoggedInInfo
            // 
            this.lblLoggedInInfo.AutoSize = true;
            this.lblLoggedInInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInInfo.ForeColor = System.Drawing.Color.Red;
            this.lblLoggedInInfo.Location = new System.Drawing.Point(5, 2);
            this.lblLoggedInInfo.Name = "lblLoggedInInfo";
            this.lblLoggedInInfo.Size = new System.Drawing.Size(0, 15);
            this.lblLoggedInInfo.TabIndex = 10033;
            // 
            // lblRequisitionPanel
            // 
            this.lblRequisitionPanel.BackColor = System.Drawing.SystemColors.Info;
            this.lblRequisitionPanel.Controls.Add(this.dtp1);
            this.lblRequisitionPanel.Controls.Add(this.label12);
            this.lblRequisitionPanel.Controls.Add(this.label10);
            this.lblRequisitionPanel.Controls.Add(this.dgServed);
            this.lblRequisitionPanel.Controls.Add(this.button1);
            this.lblRequisitionPanel.Controls.Add(this.btnRefresh);
            this.lblRequisitionPanel.Controls.Add(this.dgRequisitionList);
            this.lblRequisitionPanel.Controls.Add(this.dgRequistions);
            this.lblRequisitionPanel.Location = new System.Drawing.Point(24, 23);
            this.lblRequisitionPanel.Name = "lblRequisitionPanel";
            this.lblRequisitionPanel.Size = new System.Drawing.Size(1197, 556);
            this.lblRequisitionPanel.TabIndex = 10035;
            this.lblRequisitionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lblRequisitionPanel_Paint);
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(238, 17);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(127, 26);
            this.dtp1.TabIndex = 10026;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(793, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 18);
            this.label12.TabIndex = 10025;
            this.label12.Text = "Delivered Qty";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(396, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 18);
            this.label10.TabIndex = 10024;
            this.label10.Text = "Requisition";
            // 
            // dgServed
            // 
            this.dgServed.AllowUserToAddRows = false;
            this.dgServed.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgServed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgServed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgServed.Location = new System.Drawing.Point(790, 88);
            this.dgServed.Name = "dgServed";
            this.dgServed.Size = new System.Drawing.Size(392, 423);
            this.dgServed.TabIndex = 10023;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RequisitionNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RequisitionBy";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 180;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn6.HeaderText = "Del. Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(557, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 10021;
            this.button1.Text = ">>  >>  >> ------>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(382, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 31);
            this.btnRefresh.TabIndex = 10022;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgRequisitionList
            // 
            this.dgRequisitionList.AllowUserToAddRows = false;
            this.dgRequisitionList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgRequisitionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequisitionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgRequisitionList.Location = new System.Drawing.Point(399, 88);
            this.dgRequisitionList.Name = "dgRequisitionList";
            this.dgRequisitionList.Size = new System.Drawing.Size(385, 423);
            this.dgRequisitionList.TabIndex = 10018;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RequisitionNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RequisitionBy";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn3.HeaderText = "Req. Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dgRequistions
            // 
            this.dgRequistions.AllowUserToAddRows = false;
            this.dgRequistions.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgRequistions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequistions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequisitionId,
            this.CabinNo,
            this.Status});
            this.dgRequistions.Location = new System.Drawing.Point(9, 67);
            this.dgRequistions.Name = "dgRequistions";
            this.dgRequistions.Size = new System.Drawing.Size(372, 444);
            this.dgRequistions.TabIndex = 10016;
            this.dgRequistions.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRequistions_RowHeaderMouseClick);
            // 
            // RequisitionId
            // 
            this.RequisitionId.DataPropertyName = "RequisitionId";
            this.RequisitionId.HeaderText = "RequisitionNo";
            this.RequisitionId.Name = "RequisitionId";
            this.RequisitionId.Width = 120;
            // 
            // CabinNo
            // 
            this.CabinNo.DataPropertyName = "CabinNo";
            this.CabinNo.HeaderText = "Date";
            this.CabinNo.Name = "CabinNo";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // ctrlProductSearch
            // 
            this.ctrlProductSearch.Location = new System.Drawing.Point(202, 251);
            this.ctrlProductSearch.Name = "ctrlProductSearch";
            this.ctrlProductSearch.Size = new System.Drawing.Size(585, 529);
            this.ctrlProductSearch.TabIndex = 10036;
            // 
            // frmLabItemRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 749);
            this.Controls.Add(this.ctrlProductSearch);
            this.Controls.Add(this.lblRequisitionPanel);
            this.Controls.Add(this.lblLoggedInInfo);
            this.Controls.Add(this.lvLabs);
            this.Controls.Add(this.lblInchargeName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgRequisition);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDrescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEntryDateValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.txtRequisitionby);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLabItemRequisition";
            this.Text = "Lab Requisition Form";
            this.Load += new System.EventHandler(this.frmIndoorMedicineRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisition)).EndInit();
            this.lblRequisitionPanel.ResumeLayout(false);
            this.lblRequisitionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisitionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequistions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDrescription;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.TextBox txtRequisitionby;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDrescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridView dgRequisition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblEntryDateValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblInchargeName;
        private System.Windows.Forms.ListView lvLabs;
        private System.Windows.Forms.Label lblLoggedInInfo;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.Panel lblRequisitionPanel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgServed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgRequisitionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView dgRequistions;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.ImageList imgListLab;
        private Controls.StoreProductSearchControl ctrlProductSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CabinNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}