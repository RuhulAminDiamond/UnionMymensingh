namespace HDMS.Windows.Forms.UI.Accounting
{
    partial class frmBalanceSheet
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
            this.btnClose = new System.Windows.Forms.Button();
            this.radDetails = new System.Windows.Forms.RadioButton();
            this.Summary = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpprevFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtpprevtodate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.radSummary = new System.Windows.Forms.RadioButton();
            this.radDateails = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(298, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 38);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radDetails
            // 
            this.radDetails.AutoSize = true;
            this.radDetails.Checked = true;
            this.radDetails.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDetails.Location = new System.Drawing.Point(-500, 113);
            this.radDetails.Name = "radDetails";
            this.radDetails.Size = new System.Drawing.Size(137, 22);
            this.radDetails.TabIndex = 45;
            this.radDetails.TabStop = true;
            this.radDetails.Text = "Details Statement";
            this.radDetails.UseVisualStyleBackColor = true;
            // 
            // Summary
            // 
            this.Summary.AutoSize = true;
            this.Summary.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Summary.Location = new System.Drawing.Point(-500, 113);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(152, 22);
            this.Summary.TabIndex = 44;
            this.Summary.Text = "Summary Statement";
            this.Summary.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Prev. From Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Prev. To Date";
            // 
            // dtpprevFromdate
            // 
            this.dtpprevFromdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprevFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpprevFromdate.Location = new System.Drawing.Point(155, 71);
            this.dtpprevFromdate.Name = "dtpprevFromdate";
            this.dtpprevFromdate.Size = new System.Drawing.Size(151, 27);
            this.dtpprevFromdate.TabIndex = 40;
            // 
            // dtpprevtodate
            // 
            this.dtpprevtodate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpprevtodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpprevtodate.Location = new System.Drawing.Point(414, 71);
            this.dtpprevtodate.Name = "dtpprevtodate";
            this.dtpprevtodate.Size = new System.Drawing.Size(151, 27);
            this.dtpprevtodate.TabIndex = 41;
            this.dtpprevtodate.Value = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(155, 131);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(121, 38);
            this.btnShow.TabIndex = 39;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "To Date";
            // 
            // dtpFromdate
            // 
            this.dtpFromdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromdate.Location = new System.Drawing.Point(155, 33);
            this.dtpFromdate.Name = "dtpFromdate";
            this.dtpFromdate.Size = new System.Drawing.Size(151, 27);
            this.dtpFromdate.TabIndex = 35;
            // 
            // dtpTodate
            // 
            this.dtpTodate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(414, 33);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(151, 27);
            this.dtpTodate.TabIndex = 36;
            this.dtpTodate.Value = new System.DateTime(2021, 4, 3, 0, 0, 0, 0);
            // 
            // radSummary
            // 
            this.radSummary.AutoSize = true;
            this.radSummary.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSummary.Location = new System.Drawing.Point(302, 104);
            this.radSummary.Name = "radSummary";
            this.radSummary.Size = new System.Drawing.Size(82, 21);
            this.radSummary.TabIndex = 52;
            this.radSummary.Text = "Summary";
            this.radSummary.UseVisualStyleBackColor = true;
            // 
            // radDateails
            // 
            this.radDateails.AutoSize = true;
            this.radDateails.Checked = true;
            this.radDateails.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDateails.Location = new System.Drawing.Point(156, 104);
            this.radDateails.Name = "radDateails";
            this.radDateails.Size = new System.Drawing.Size(67, 21);
            this.radDateails.TabIndex = 51;
            this.radDateails.TabStop = true;
            this.radDateails.Text = "Details";
            this.radDateails.UseVisualStyleBackColor = true;
            // 
            // frmBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 250);
            this.Controls.Add(this.radSummary);
            this.Controls.Add(this.radDateails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radDetails);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpprevFromdate);
            this.Controls.Add(this.dtpprevtodate);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromdate);
            this.Controls.Add(this.dtpTodate);
            this.Name = "frmBalanceSheet";
            this.Text = "Balance Sheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radDetails;
        private System.Windows.Forms.RadioButton Summary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpprevFromdate;
        private System.Windows.Forms.DateTimePicker dtpprevtodate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromdate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.RadioButton radSummary;
        private System.Windows.Forms.RadioButton radDateails;
    }
}