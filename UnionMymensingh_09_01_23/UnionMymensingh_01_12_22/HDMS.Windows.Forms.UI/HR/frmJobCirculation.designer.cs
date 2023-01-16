namespace HDMS.Windows.Forms.UI.HR
{
    partial class frmJobCirculation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobCirculation));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgJobCirculations = new System.Windows.Forms.DataGridView();
            this.txtCirculationTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCirculationNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.JCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CirculationTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobCirculations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(223, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(318, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(417, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgJobCirculations
            // 
            this.dgJobCirculations.BackgroundColor = System.Drawing.Color.SandyBrown;
            this.dgJobCirculations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobCirculations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JCId,
            this.ManuName,
            this.CirculationTitle});
            this.dgJobCirculations.Location = new System.Drawing.Point(132, 145);
            this.dgJobCirculations.Name = "dgJobCirculations";
            this.dgJobCirculations.Size = new System.Drawing.Size(803, 333);
            this.dgJobCirculations.TabIndex = 10;
            this.dgJobCirculations.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDept_RowHeaderMouseClick);
            // 
            // txtCirculationTitle
            // 
            this.txtCirculationTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCirculationTitle.Location = new System.Drawing.Point(132, 55);
            this.txtCirculationTitle.Name = "txtCirculationTitle";
            this.txtCirculationTitle.Size = new System.Drawing.Size(548, 29);
            this.txtCirculationTitle.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Circulation Title";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(133, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCirculationNo
            // 
            this.txtCirculationNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCirculationNo.Location = new System.Drawing.Point(133, 20);
            this.txtCirculationNo.Name = "txtCirculationNo";
            this.txtCirculationNo.Size = new System.Drawing.Size(186, 29);
            this.txtCirculationNo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Circulation No";
            // 
            // JCId
            // 
            this.JCId.DataPropertyName = "JCId";
            this.JCId.HeaderText = "Id";
            this.JCId.Name = "JCId";
            // 
            // ManuName
            // 
            this.ManuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ManuName.DataPropertyName = "CirculationNo";
            this.ManuName.HeaderText = "Circulation No";
            this.ManuName.Name = "ManuName";
            // 
            // CirculationTitle
            // 
            this.CirculationTitle.DataPropertyName = "CirculationTitle";
            this.CirculationTitle.HeaderText = "Circulation Title";
            this.CirculationTitle.Name = "CirculationTitle";
            this.CirculationTitle.Width = 350;
            // 
            // frmJobCirculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 533);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCirculationNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgJobCirculations);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCirculationTitle);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJobCirculation";
            this.Text = "Job Circulation";
            this.Load += new System.EventHandler(this.frmDeptEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJobCirculations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgJobCirculations;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCirculationTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCirculationNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CirculationTitle;
    }
}