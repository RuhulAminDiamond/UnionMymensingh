namespace HDMS.Windows.Forms.UI.Common
{
    partial class frmGrantAccessToMenus
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
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbMenuGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgMenu = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkParent = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRole
            // 
            this.cmbRole.DisplayMember = "Name";
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "J",
            "D",
            "C",
            "Cash"});
            this.cmbRole.Location = new System.Drawing.Point(248, 52);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(211, 29);
            this.cmbRole.TabIndex = 29;
            this.cmbRole.ValueMember = "Id";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(159, 52);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(82, 20);
            this.lblGender.TabIndex = 30;
            this.lblGender.Text = "Select User";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMenuGroup
            // 
            this.cmbMenuGroup.DisplayMember = "Name";
            this.cmbMenuGroup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbMenuGroup.FormattingEnabled = true;
            this.cmbMenuGroup.Location = new System.Drawing.Point(248, 95);
            this.cmbMenuGroup.Name = "cmbMenuGroup";
            this.cmbMenuGroup.Size = new System.Drawing.Size(211, 29);
            this.cmbMenuGroup.TabIndex = 31;
            this.cmbMenuGroup.ValueMember = "Id";
            this.cmbMenuGroup.SelectedIndexChanged += new System.EventHandler(this.cmbMenuGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Select Menu Group";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgMenu
            // 
            this.dgMenu.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ModuleName});
            this.dgMenu.Location = new System.Drawing.Point(248, 141);
            this.dgMenu.Name = "dgMenu";
            this.dgMenu.Size = new System.Drawing.Size(525, 338);
            this.dgMenu.TabIndex = 33;
            this.dgMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMenu_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ModuleId";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "Description";
            this.ModuleName.HeaderText = "Menu Description";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Width = 280;
            // 
            // chkParent
            // 
            this.chkParent.AutoSize = true;
            this.chkParent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkParent.Location = new System.Drawing.Point(468, 99);
            this.chkParent.Name = "chkParent";
            this.chkParent.Size = new System.Drawing.Size(142, 24);
            this.chkParent.TabIndex = 34;
            this.chkParent.Text = "Is Parent Allowed";
            this.chkParent.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(252, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 45);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "J",
            "D",
            "C",
            "Cash"});
            this.comboBox1.Location = new System.Drawing.Point(248, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 29);
            this.comboBox1.TabIndex = 36;
            this.comboBox1.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Select Role";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGrantAccessToMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 569);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkParent);
            this.Controls.Add(this.dgMenu);
            this.Controls.Add(this.cmbMenuGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblGender);
            this.Name = "frmGrantAccessToMenus";
            this.Text = "Assign Menu To Role";
            this.Load += new System.EventHandler(this.frmGrantAccessToMenus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbMenuGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgMenu;
        private System.Windows.Forms.CheckBox chkParent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}