namespace HDMS.Windows.Forms.UI.FoodAndBeverage
{
    partial class frmAddFBDept
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIndentUser = new System.Windows.Forms.TextBox();
            this.dgDepts = new System.Windows.Forms.DataGridView();
            this.DeptId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IUName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlUserSearchControl = new HDMS.Windows.Forms.UI.Controls.UserSearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(286, 115);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 37);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(163, 115);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 37);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(163, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(647, 29);
            this.txtName.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 21);
            this.label1.TabIndex = 60;
            this.label1.Text = "Select Indent User";
            // 
            // txtIndentUser
            // 
            this.txtIndentUser.BackColor = System.Drawing.Color.White;
            this.txtIndentUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndentUser.Location = new System.Drawing.Point(163, 69);
            this.txtIndentUser.Name = "txtIndentUser";
            this.txtIndentUser.Size = new System.Drawing.Size(288, 29);
            this.txtIndentUser.TabIndex = 61;
            this.txtIndentUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndentUser_KeyPress);
            // 
            // dgDepts
            // 
            this.dgDepts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptId,
            this.DeptName,
            this.IUName,
            this.FullName});
            this.dgDepts.Location = new System.Drawing.Point(159, 181);
            this.dgDepts.Name = "dgDepts";
            this.dgDepts.Size = new System.Drawing.Size(674, 286);
            this.dgDepts.TabIndex = 63;
            this.dgDepts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDepts_RowHeaderMouseClick);
            // 
            // DeptId
            // 
            this.DeptId.HeaderText = "DeptId";
            this.DeptId.Name = "DeptId";
            // 
            // DeptName
            // 
            this.DeptName.HeaderText = "Dept.Name";
            this.DeptName.Name = "DeptName";
            this.DeptName.Width = 150;
            // 
            // IUName
            // 
            this.IUName.HeaderText = "I.U.Name";
            this.IUName.Name = "IUName";
            this.IUName.Width = 160;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Width = 220;
            // 
            // ctrlUserSearchControl
            // 
            this.ctrlUserSearchControl.Location = new System.Drawing.Point(94, 24);
            this.ctrlUserSearchControl.Name = "ctrlUserSearchControl";
            this.ctrlUserSearchControl.Size = new System.Drawing.Size(529, 477);
            this.ctrlUserSearchControl.TabIndex = 62;
            this.ctrlUserSearchControl.Visible = false;
            // 
            // frmAddFBDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 605);
            this.Controls.Add(this.ctrlUserSearchControl);
            this.Controls.Add(this.dgDepts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIndentUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Name = "frmAddFBDept";
            this.Text = "Add Food And Beverage Dept";
            this.Load += new System.EventHandler(this.frmAddStoreDept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIndentUser;
        private Controls.UserSearchControl ctrlUserSearchControl;
        private System.Windows.Forms.DataGridView dgDepts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IUName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
    }
}