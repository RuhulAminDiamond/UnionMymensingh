namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    partial class frmOpeningClosingNewEdition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpeningClosingNewEdition));
            this.cmdViewStatement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cmdViewStatement
            // 
            this.cmdViewStatement.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdViewStatement.Location = new System.Drawing.Point(388, 87);
            this.cmdViewStatement.Name = "cmdViewStatement";
            this.cmdViewStatement.Size = new System.Drawing.Size(125, 31);
            this.cmdViewStatement.TabIndex = 28;
            this.cmdViewStatement.Text = "View Statement";
            this.cmdViewStatement.UseVisualStyleBackColor = true;
            this.cmdViewStatement.Click += new System.EventHandler(this.cmdViewStatement_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Date";
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(216, 89);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 26;
            // 
            // frmOpeningClosingNewEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 275);
            this.Controls.Add(this.cmdViewStatement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOpeningClosingNewEdition";
            this.Text = "Opening Closing Statement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdViewStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfrm;
    }
}