namespace HDMS.Windows.Forms.UI.ShareHolder
{
    partial class frmDividentWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDividentWithdraw));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSh = new System.Windows.Forms.TextBox();
            this.txtWithdraw = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.CtrlshareHolderSearch = new HDMS.Windows.Forms.UI.Controls.ShareHolderSearchControl();
            this.lbldivident = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Share Holder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(96, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Divident Amount :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Withdraw Amount";
            // 
            // txtSh
            // 
            this.txtSh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSh.Location = new System.Drawing.Point(226, 63);
            this.txtSh.Name = "txtSh";
            this.txtSh.Size = new System.Drawing.Size(227, 26);
            this.txtSh.TabIndex = 3;
            this.txtSh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSh_KeyPress);
            // 
            // txtWithdraw
            // 
            this.txtWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWithdraw.Location = new System.Drawing.Point(226, 145);
            this.txtWithdraw.Name = "txtWithdraw";
            this.txtWithdraw.Size = new System.Drawing.Size(148, 26);
            this.txtWithdraw.TabIndex = 4;
            this.txtWithdraw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWithdraw_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(226, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 41);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CtrlshareHolderSearch
            // 
            this.CtrlshareHolderSearch.Location = new System.Drawing.Point(33, 263);
            this.CtrlshareHolderSearch.Name = "CtrlshareHolderSearch";
            this.CtrlshareHolderSearch.Size = new System.Drawing.Size(737, 650);
            this.CtrlshareHolderSearch.TabIndex = 6;
            // 
            // lbldivident
            // 
            this.lbldivident.AutoSize = true;
            this.lbldivident.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldivident.ForeColor = System.Drawing.Color.Red;
            this.lbldivident.Location = new System.Drawing.Point(224, 108);
            this.lbldivident.Name = "lbldivident";
            this.lbldivident.Size = new System.Drawing.Size(118, 19);
            this.lbldivident.TabIndex = 8;
            this.lbldivident.Text = " divident amount";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(362, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 41);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDividentWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.CtrlshareHolderSearch);
            this.Controls.Add(this.lbldivident);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWithdraw);
            this.Controls.Add(this.txtSh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDividentWithdraw";
            this.Text = "Divident Withdraw";
            this.Load += new System.EventHandler(this.frmDividentWithdraw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSh;
        private System.Windows.Forms.TextBox txtWithdraw;
        private Controls.ShareHolderSearchControl CtrlshareHolderSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbldivident;
        private System.Windows.Forms.Button btnClose;
    }
}