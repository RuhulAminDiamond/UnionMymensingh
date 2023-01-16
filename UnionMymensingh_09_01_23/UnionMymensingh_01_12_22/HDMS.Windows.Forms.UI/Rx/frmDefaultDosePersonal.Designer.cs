namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmDefaultDosePersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefaultDosePersonal));
            this.btnSetDose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtshortkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShortDoseEn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortDoseBn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLongDoseEn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLongDoseBn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGeneric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeGGBrand = new System.Windows.Forms.TreeView();
            this.imgListLage = new System.Windows.Forms.ImageList(this.components);
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDefaultDuration = new System.Windows.Forms.TextBox();
            this.cmbDurationUnit = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.ctrlDosageSearch = new HDMS.Windows.Forms.UI.Controls.RxCpDosageSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetDose
            // 
            this.btnSetDose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDose.Location = new System.Drawing.Point(495, 234);
            this.btnSetDose.Name = "btnSetDose";
            this.btnSetDose.Size = new System.Drawing.Size(160, 38);
            this.btnSetDose.TabIndex = 10205;
            this.btnSetDose.Text = "Set as Default Dose";
            this.btnSetDose.UseVisualStyleBackColor = true;
            this.btnSetDose.Click += new System.EventHandler(this.btnSetDose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(421, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 10203;
            this.label7.Text = "Short Key";
            // 
            // txtshortkey
            // 
            this.txtshortkey.Enabled = false;
            this.txtshortkey.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshortkey.Location = new System.Drawing.Point(495, 183);
            this.txtshortkey.Multiline = true;
            this.txtshortkey.Name = "txtshortkey";
            this.txtshortkey.Size = new System.Drawing.Size(179, 30);
            this.txtshortkey.TabIndex = 10198;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(909, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 10202;
            this.label4.Text = "Short  Dose (English)";
            // 
            // txtShortDoseEn
            // 
            this.txtShortDoseEn.Enabled = false;
            this.txtShortDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseEn.Location = new System.Drawing.Point(1050, 106);
            this.txtShortDoseEn.Multiline = true;
            this.txtShortDoseEn.Name = "txtShortDoseEn";
            this.txtShortDoseEn.Size = new System.Drawing.Size(179, 30);
            this.txtShortDoseEn.TabIndex = 10197;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(912, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 18);
            this.label5.TabIndex = 10201;
            this.label5.Text = "Short  Dose (Bangla)";
            // 
            // txtShortDoseBn
            // 
            this.txtShortDoseBn.Enabled = false;
            this.txtShortDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseBn.Location = new System.Drawing.Point(1050, 145);
            this.txtShortDoseBn.Multiline = true;
            this.txtShortDoseBn.Name = "txtShortDoseBn";
            this.txtShortDoseBn.Size = new System.Drawing.Size(179, 30);
            this.txtShortDoseBn.TabIndex = 10195;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 10200;
            this.label2.Text = "Long Dose (English)";
            // 
            // txtLongDoseEn
            // 
            this.txtLongDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseEn.Location = new System.Drawing.Point(494, 106);
            this.txtLongDoseEn.Multiline = true;
            this.txtLongDoseEn.Name = "txtLongDoseEn";
            this.txtLongDoseEn.Size = new System.Drawing.Size(391, 30);
            this.txtLongDoseEn.TabIndex = 10196;
            this.txtLongDoseEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLongDoseEn_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 10199;
            this.label1.Text = "Long Dose (Bangla)";
            // 
            // txtLongDoseBn
            // 
            this.txtLongDoseBn.Enabled = false;
            this.txtLongDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseBn.Location = new System.Drawing.Point(495, 145);
            this.txtLongDoseBn.Multiline = true;
            this.txtLongDoseBn.Name = "txtLongDoseBn";
            this.txtLongDoseBn.Size = new System.Drawing.Size(390, 30);
            this.txtLongDoseBn.TabIndex = 10194;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 10193;
            this.label6.Text = "Select Formulation";
            // 
            // cmbGeneric
            // 
            this.cmbGeneric.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneric.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneric.FormattingEnabled = true;
            this.cmbGeneric.Location = new System.Drawing.Point(494, 22);
            this.cmbGeneric.Name = "cmbGeneric";
            this.cmbGeneric.Size = new System.Drawing.Size(302, 29);
            this.cmbGeneric.TabIndex = 10190;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(380, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 10191;
            this.label3.Text = "Select Generic";
            // 
            // treeGGBrand
            // 
            this.treeGGBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeGGBrand.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeGGBrand.Location = new System.Drawing.Point(0, 0);
            this.treeGGBrand.Name = "treeGGBrand";
            this.treeGGBrand.Size = new System.Drawing.Size(342, 741);
            this.treeGGBrand.TabIndex = 10208;
            this.treeGGBrand.DoubleClick += new System.EventHandler(this.treeGGBrand_DoubleClick);
            // 
            // imgListLage
            // 
            this.imgListLage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLage.ImageStream")));
            this.imgListLage.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLage.Images.SetKeyName(0, "capsul.png");
            // 
            // treeImageList
            // 
            this.treeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.treeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(677, 234);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 38);
            this.btnClose.TabIndex = 10206;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Group,
            this.Generic,
            this.Manufacturer,
            this.Duration,
            this.Unit,
            this.Qty});
            this.dgProducts.Location = new System.Drawing.Point(363, 290);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(866, 413);
            this.dgProducts.TabIndex = 10209;
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Gen. Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 80;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.Width = 220;
            // 
            // Generic
            // 
            this.Generic.HeaderText = "Generic";
            this.Generic.Name = "Generic";
            this.Generic.Width = 190;
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Dose";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Width = 180;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 80;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Width = 70;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(680, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 10211;
            this.label8.Text = "Default Duration";
            // 
            // txtDefaultDuration
            // 
            this.txtDefaultDuration.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultDuration.Location = new System.Drawing.Point(796, 186);
            this.txtDefaultDuration.Multiline = true;
            this.txtDefaultDuration.Name = "txtDefaultDuration";
            this.txtDefaultDuration.Size = new System.Drawing.Size(54, 30);
            this.txtDefaultDuration.TabIndex = 10210;
            // 
            // cmbDurationUnit
            // 
            this.cmbDurationUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDurationUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDurationUnit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDurationUnit.FormattingEnabled = true;
            this.cmbDurationUnit.Location = new System.Drawing.Point(856, 187);
            this.cmbDurationUnit.Name = "cmbDurationUnit";
            this.cmbDurationUnit.Size = new System.Drawing.Size(98, 26);
            this.cmbDurationUnit.TabIndex = 10212;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(1005, 190);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(57, 26);
            this.txtQty.TabIndex = 10213;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(973, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 18);
            this.label9.TabIndex = 10214;
            this.label9.Text = "Qty";
            // 
            // cmbFormation
            // 
            this.cmbFormation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(497, 65);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(200, 27);
            this.cmbFormation.TabIndex = 10215;
            this.cmbFormation.SelectedIndexChanged += new System.EventHandler(this.cmbFormation_SelectedIndexChanged);
            // 
            // ctrlDosageSearch
            // 
            this.ctrlDosageSearch.Location = new System.Drawing.Point(363, 323);
            this.ctrlDosageSearch.Name = "ctrlDosageSearch";
            this.ctrlDosageSearch.Size = new System.Drawing.Size(699, 535);
            this.ctrlDosageSearch.TabIndex = 10207;
            this.ctrlDosageSearch.Visible = false;
            // 
            // frmDefaultDosePersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 741);
            this.Controls.Add(this.cmbFormation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDurationUnit);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.ctrlDosageSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDefaultDuration);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.treeGGBrand);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSetDose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtshortkey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShortDoseEn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtShortDoseBn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLongDoseEn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLongDoseBn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGeneric);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefaultDosePersonal";
            this.Text = "Default Dose Personal";
            this.Load += new System.EventHandler(this.frmDefaultDosePersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetDose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtshortkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShortDoseEn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShortDoseBn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLongDoseEn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLongDoseBn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGeneric;
        private System.Windows.Forms.Label label3;
        private Controls.RxCpDosageSearchControl ctrlDosageSearch;
        private System.Windows.Forms.TreeView treeGGBrand;
        private System.Windows.Forms.ImageList imgListLage;
        private System.Windows.Forms.ImageList treeImageList;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDefaultDuration;
        private System.Windows.Forms.ComboBox cmbDurationUnit;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.ComboBox cmbFormation;
    }
}