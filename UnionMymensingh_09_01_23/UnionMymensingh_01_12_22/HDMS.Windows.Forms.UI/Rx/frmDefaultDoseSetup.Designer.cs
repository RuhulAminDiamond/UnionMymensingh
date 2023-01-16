namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmDefaultDoseSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefaultDoseSetup));
            this.cmbFormation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGeneric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtshortkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShortDoseEn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortDoseBn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLongDoseEn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLongDoseBn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetDose = new System.Windows.Forms.Button();
            this.ctrlDosageSearch = new HDMS.Windows.Forms.UI.Controls.RxDosageSearchControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbFormation
            // 
            this.cmbFormation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormation.FormattingEnabled = true;
            this.cmbFormation.Location = new System.Drawing.Point(206, 89);
            this.cmbFormation.Name = "cmbFormation";
            this.cmbFormation.Size = new System.Drawing.Size(166, 29);
            this.cmbFormation.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Select Formulation";
            // 
            // cmbGeneric
            // 
            this.cmbGeneric.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGeneric.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGeneric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneric.FormattingEnabled = true;
            this.cmbGeneric.Location = new System.Drawing.Point(206, 49);
            this.cmbGeneric.Name = "cmbGeneric";
            this.cmbGeneric.Size = new System.Drawing.Size(302, 29);
            this.cmbGeneric.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select Generic";
            // 
            // txtshortkey
            // 
            this.txtshortkey.Enabled = false;
            this.txtshortkey.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshortkey.Location = new System.Drawing.Point(207, 210);
            this.txtshortkey.Multiline = true;
            this.txtshortkey.Name = "txtshortkey";
            this.txtshortkey.Size = new System.Drawing.Size(179, 30);
            this.txtshortkey.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(621, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Short  Dose (English)";
            // 
            // txtShortDoseEn
            // 
            this.txtShortDoseEn.Enabled = false;
            this.txtShortDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseEn.Location = new System.Drawing.Point(762, 133);
            this.txtShortDoseEn.Multiline = true;
            this.txtShortDoseEn.Name = "txtShortDoseEn";
            this.txtShortDoseEn.Size = new System.Drawing.Size(179, 30);
            this.txtShortDoseEn.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(624, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Short  Dose (Bangla)";
            // 
            // txtShortDoseBn
            // 
            this.txtShortDoseBn.Enabled = false;
            this.txtShortDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortDoseBn.Location = new System.Drawing.Point(762, 172);
            this.txtShortDoseBn.Multiline = true;
            this.txtShortDoseBn.Name = "txtShortDoseBn";
            this.txtShortDoseBn.Size = new System.Drawing.Size(179, 30);
            this.txtShortDoseBn.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Long Dose (English)";
            // 
            // txtLongDoseEn
            // 
            this.txtLongDoseEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseEn.Location = new System.Drawing.Point(206, 133);
            this.txtLongDoseEn.Multiline = true;
            this.txtLongDoseEn.Name = "txtLongDoseEn";
            this.txtLongDoseEn.Size = new System.Drawing.Size(391, 30);
            this.txtLongDoseEn.TabIndex = 20;
            this.txtLongDoseEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLongDoseEn_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Long Dose (Bangla)";
            // 
            // txtLongDoseBn
            // 
            this.txtLongDoseBn.Enabled = false;
            this.txtLongDoseBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDoseBn.Location = new System.Drawing.Point(207, 172);
            this.txtLongDoseBn.Multiline = true;
            this.txtLongDoseBn.Name = "txtLongDoseBn";
            this.txtLongDoseBn.Size = new System.Drawing.Size(390, 30);
            this.txtLongDoseBn.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(133, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Short Key";
            // 
            // btnSetDose
            // 
            this.btnSetDose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDose.Location = new System.Drawing.Point(207, 261);
            this.btnSetDose.Name = "btnSetDose";
            this.btnSetDose.Size = new System.Drawing.Size(160, 38);
            this.btnSetDose.TabIndex = 10188;
            this.btnSetDose.Text = "Set as Default Dose";
            this.btnSetDose.UseVisualStyleBackColor = true;
            this.btnSetDose.Click += new System.EventHandler(this.btnSetDose_Click);
            // 
            // ctrlDosageSearch
            // 
            this.ctrlDosageSearch.Location = new System.Drawing.Point(374, 247);
            this.ctrlDosageSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDosageSearch.Name = "ctrlDosageSearch";
            this.ctrlDosageSearch.Size = new System.Drawing.Size(704, 520);
            this.ctrlDosageSearch.TabIndex = 10187;
            this.ctrlDosageSearch.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(389, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 38);
            this.btnClose.TabIndex = 10189;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDefaultDoseSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 618);
            this.Controls.Add(this.ctrlDosageSearch);
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
            this.Controls.Add(this.cmbFormation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbGeneric);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefaultDoseSetup";
            this.Text = "Default Dose Setup";
            this.Load += new System.EventHandler(this.frmDefaultDoseSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGeneric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtshortkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShortDoseEn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShortDoseBn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLongDoseEn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLongDoseBn;
        private System.Windows.Forms.Label label7;
        private Controls.RxDosageSearchControl ctrlDosageSearch;
        private System.Windows.Forms.Button btnSetDose;
        private System.Windows.Forms.Button btnClose;
    }
}