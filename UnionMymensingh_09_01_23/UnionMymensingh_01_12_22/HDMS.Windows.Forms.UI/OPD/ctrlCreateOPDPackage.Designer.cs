
namespace HDMS.Windows.Forms.UI.OPD
{
    partial class ctrlCreateOPDPackage
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
            this.txtProcedureName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgLedger = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServiceHead = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProcedureName
            // 
            this.txtProcedureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedureName.Location = new System.Drawing.Point(209, 66);
            this.txtProcedureName.Name = "txtProcedureName";
            this.txtProcedureName.Size = new System.Drawing.Size(276, 26);
            this.txtProcedureName.TabIndex = 10047;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 18);
            this.label12.TabIndex = 10048;
            this.label12.Text = "Procedure/Package Name";
            // 
            // dgLedger
            // 
            this.dgLedger.AllowUserToAddRows = false;
            this.dgLedger.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrlNo,
            this.Amount});
            this.dgLedger.Location = new System.Drawing.Point(209, 141);
            this.dgLedger.MultiSelect = false;
            this.dgLedger.Name = "dgLedger";
            this.dgLedger.Size = new System.Drawing.Size(583, 372);
            this.dgLedger.TabIndex = 10049;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 10051;
            this.label1.Text = "Select Head";
            // 
            // SrlNo
            // 
            this.SrlNo.HeaderText = "Billing Head";
            this.SrlNo.Name = "SrlNo";
            this.SrlNo.Width = 420;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 120;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(642, 109);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 26);
            this.txtAmount.TabIndex = 10052;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(577, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 10053;
            this.label2.Text = "Amount";
            // 
            // cmbServiceHead
            // 
            this.cmbServiceHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServiceHead.FormattingEnabled = true;
            this.cmbServiceHead.Location = new System.Drawing.Point(209, 109);
            this.cmbServiceHead.Name = "cmbServiceHead";
            this.cmbServiceHead.Size = new System.Drawing.Size(332, 28);
            this.cmbServiceHead.TabIndex = 11210;
            // 
            // ctrlCreateOPDPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbServiceHead);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgLedger);
            this.Controls.Add(this.txtProcedureName);
            this.Controls.Add(this.label12);
            this.Name = "ctrlCreateOPDPackage";
            this.Size = new System.Drawing.Size(1193, 658);
            this.Load += new System.EventHandler(this.ctrlCreateOPDPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProcedureName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServiceHead;
    }
}
