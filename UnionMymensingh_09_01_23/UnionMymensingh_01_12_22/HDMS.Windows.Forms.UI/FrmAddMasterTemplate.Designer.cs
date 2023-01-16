namespace HDMS.Windows.Forms.UI
{
    partial class FrmAddMasterTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddMasterTemplate));
            this.btnBrowseMasterTemplate = new System.Windows.Forms.PictureBox();
            this.btnSaveMasterTemplate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.txtSecurityCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseMasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseMasterTemplate
            // 
            this.btnBrowseMasterTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowseMasterTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBrowseMasterTemplate.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnBrowseMasterTemplate.Image = global::HDMS.Windows.Forms.UI.Properties.Resources.browseiconbmp;
            this.btnBrowseMasterTemplate.Location = new System.Drawing.Point(507, 114);
            this.btnBrowseMasterTemplate.Name = "btnBrowseMasterTemplate";
            this.btnBrowseMasterTemplate.Size = new System.Drawing.Size(34, 34);
            this.btnBrowseMasterTemplate.TabIndex = 21;
            this.btnBrowseMasterTemplate.TabStop = false;
            this.btnBrowseMasterTemplate.Click += new System.EventHandler(this.btnBrowseMasterTemplate_Click);
            // 
            // btnSaveMasterTemplate
            // 
            this.btnSaveMasterTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMasterTemplate.Location = new System.Drawing.Point(353, 199);
            this.btnSaveMasterTemplate.Name = "btnSaveMasterTemplate";
            this.btnSaveMasterTemplate.Size = new System.Drawing.Size(148, 34);
            this.btnSaveMasterTemplate.TabIndex = 20;
            this.btnSaveMasterTemplate.Text = "Save";
            this.btnSaveMasterTemplate.UseVisualStyleBackColor = true;
            this.btnSaveMasterTemplate.Click += new System.EventHandler(this.btnSaveMasterTemplate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(142, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Select File";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTemplate
            // 
            this.txtTemplate.BackColor = System.Drawing.Color.White;
            this.txtTemplate.Enabled = false;
            this.txtTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtTemplate.Location = new System.Drawing.Point(224, 118);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(277, 24);
            this.txtTemplate.TabIndex = 18;
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurityCode.Location = new System.Drawing.Point(224, 155);
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.Size = new System.Drawing.Size(176, 24);
            this.txtSecurityCode.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(86, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Enter Ecurity Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(133, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "Select Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(224, 76);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(276, 26);
            this.cmbType.TabIndex = 29;
            // 
            // FrmAddMasterTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 394);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSecurityCode);
            this.Controls.Add(this.btnBrowseMasterTemplate);
            this.Controls.Add(this.btnSaveMasterTemplate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddMasterTemplate";
            this.Text = "Add Master Template";
            this.Load += new System.EventHandler(this.FrmAddMasterTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseMasterTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnBrowseMasterTemplate;
        private System.Windows.Forms.Button btnSaveMasterTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.TextBox txtSecurityCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
    }
}