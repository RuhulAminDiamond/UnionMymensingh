namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmAddAdvices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddAdvices));
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdviceBn = new System.Windows.Forms.TextBox();
            this.dgAdvices = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdviceEn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortKey = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdviceEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAdvices)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Advice (Bangla)";
            // 
            // txtAdviceBn
            // 
            this.txtAdviceBn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdviceBn.Location = new System.Drawing.Point(159, 30);
            this.txtAdviceBn.Multiline = true;
            this.txtAdviceBn.Name = "txtAdviceBn";
            this.txtAdviceBn.Size = new System.Drawing.Size(430, 32);
            this.txtAdviceBn.TabIndex = 18;
            // 
            // dgAdvices
            // 
            this.dgAdvices.AllowUserToAddRows = false;
            this.dgAdvices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAdvices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Advices,
            this.AdviceEn,
            this.ShortKey});
            this.dgAdvices.Location = new System.Drawing.Point(159, 200);
            this.dgAdvices.Name = "dgAdvices";
            this.dgAdvices.Size = new System.Drawing.Size(676, 302);
            this.dgAdvices.TabIndex = 17;
            this.dgAdvices.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAdvices_RowHeaderMouseDoubleClick);
            this.dgAdvices.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgAdvices_UserDeletedRow);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(159, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 40);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Advice (English)";
            // 
            // txtAdviceEn
            // 
            this.txtAdviceEn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdviceEn.Location = new System.Drawing.Point(159, 67);
            this.txtAdviceEn.Multiline = true;
            this.txtAdviceEn.Name = "txtAdviceEn";
            this.txtAdviceEn.Size = new System.Drawing.Size(430, 32);
            this.txtAdviceEn.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Short Key";
            // 
            // txtShortKey
            // 
            this.txtShortKey.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortKey.Location = new System.Drawing.Point(159, 105);
            this.txtShortKey.Multiline = true;
            this.txtShortKey.Name = "txtShortKey";
            this.txtShortKey.Size = new System.Drawing.Size(212, 32);
            this.txtShortKey.TabIndex = 22;
            // 
            // Id
            // 
            this.Id.HeaderText = "IdNo";
            this.Id.Name = "Id";
            // 
            // Advices
            // 
            this.Advices.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Advices.HeaderText = "Advice(Bn)";
            this.Advices.Name = "Advices";
            // 
            // AdviceEn
            // 
            this.AdviceEn.HeaderText = "Advice (En)";
            this.AdviceEn.Name = "AdviceEn";
            this.AdviceEn.Width = 180;
            // 
            // ShortKey
            // 
            this.ShortKey.HeaderText = "Short Key";
            this.ShortKey.Name = "ShortKey";
            // 
            // frmAddAdvices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 576);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShortKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdviceEn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdviceBn);
            this.Controls.Add(this.dgAdvices);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAddAdvices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Advices";
            this.Load += new System.EventHandler(this.frmAddAdvices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAdvices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdviceBn;
        private System.Windows.Forms.DataGridView dgAdvices;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdviceEn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShortKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Advices;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdviceEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortKey;
    }
}