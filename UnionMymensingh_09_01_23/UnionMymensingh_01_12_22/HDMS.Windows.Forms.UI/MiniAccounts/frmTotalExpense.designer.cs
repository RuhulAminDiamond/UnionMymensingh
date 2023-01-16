namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    partial class frmTotalExpense
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
            this.cmdShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrm = new System.Windows.Forms.DateTimePicker();
            this.radValued = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cmdShow
            // 
            this.cmdShow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShow.Location = new System.Drawing.Point(372, 137);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(125, 39);
            this.cmdShow.TabIndex = 24;
            this.cmdShow.Text = "Show";
            this.cmdShow.UseVisualStyleBackColor = true;
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "From";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(358, 48);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(139, 27);
            this.dtpto.TabIndex = 21;
            // 
            // dtpfrm
            // 
            this.dtpfrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrm.Location = new System.Drawing.Point(160, 48);
            this.dtpfrm.Name = "dtpfrm";
            this.dtpfrm.Size = new System.Drawing.Size(145, 27);
            this.dtpfrm.TabIndex = 20;
            // 
            // radValued
            // 
            this.radValued.AutoSize = true;
            this.radValued.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radValued.Location = new System.Drawing.Point(160, 102);
            this.radValued.Name = "radValued";
            this.radValued.Size = new System.Drawing.Size(98, 21);
            this.radValued.TabIndex = 25;
            this.radValued.TabStop = true;
            this.radValued.Text = "Only Valued";
            this.radValued.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(295, 102);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(43, 21);
            this.radAll.TabIndex = 26;
            this.radAll.TabStop = true;
            this.radAll.Text = "All";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // frmTotalExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 229);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.radValued);
            this.Controls.Add(this.cmdShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrm);
            this.Name = "frmTotalExpense";
            this.Text = "Total Expense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrm;
        private System.Windows.Forms.RadioButton radValued;
        private System.Windows.Forms.RadioButton radAll;
    }
}