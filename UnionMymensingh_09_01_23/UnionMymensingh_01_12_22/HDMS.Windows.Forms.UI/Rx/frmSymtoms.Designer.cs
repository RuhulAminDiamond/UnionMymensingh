namespace HDMS.Windows.Forms.UI.Rx
{
    partial class frmCC
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
            this.dgSymtoms = new System.Windows.Forms.DataGridView();
            this.Srl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSymtoms)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSymtoms
            // 
            this.dgSymtoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSymtoms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Srl,
            this.SName});
            this.dgSymtoms.Location = new System.Drawing.Point(1, 2);
            this.dgSymtoms.Name = "dgSymtoms";
            this.dgSymtoms.Size = new System.Drawing.Size(398, 488);
            this.dgSymtoms.TabIndex = 0;
            // 
            // Srl
            // 
            this.Srl.HeaderText = "Srl";
            this.Srl.Name = "Srl";
            // 
            // SName
            // 
            this.SName.HeaderText = "Name";
            this.SName.Name = "SName";
            this.SName.Width = 270;
            // 
            // frmCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 494);
            this.Controls.Add(this.dgSymtoms);
            this.MaximizeBox = false;
            this.Name = "frmCC";
            this.Text = "C/C";
            this.Load += new System.EventHandler(this.frmSymtoms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSymtoms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSymtoms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Srl;
        private System.Windows.Forms.DataGridViewTextBoxColumn SName;
    }
}