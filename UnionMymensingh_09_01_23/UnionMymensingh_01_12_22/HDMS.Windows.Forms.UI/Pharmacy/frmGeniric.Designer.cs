namespace Store.Forms
{
    partial class frmGeniric
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgGeneric = new System.Windows.Forms.DataGridView();
            this.GenericId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearchGeneric = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generic Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(136, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(507, 27);
            this.txtName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(136, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgGeneric
            // 
            this.dgGeneric.AllowUserToAddRows = false;
            this.dgGeneric.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgGeneric.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGeneric.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GenericId,
            this.GenName,
            this.GroupN});
            this.dgGeneric.Location = new System.Drawing.Point(136, 204);
            this.dgGeneric.Name = "dgGeneric";
            this.dgGeneric.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGeneric.Size = new System.Drawing.Size(774, 440);
            this.dgGeneric.TabIndex = 3;
            this.dgGeneric.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgGeneric_RowHeaderMouseClick);
            // 
            // GenericId
            // 
            this.GenericId.DataPropertyName = "GenericId";
            this.GenericId.HeaderText = "Gen.  Id";
            this.GenericId.Name = "GenericId";
            // 
            // GenName
            // 
            this.GenName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GenName.DataPropertyName = "Generic Name";
            this.GenName.HeaderText = "Generic Name";
            this.GenName.Name = "GenName";
            // 
            // GroupN
            // 
            this.GroupN.HeaderText = "Group Name";
            this.GroupN.Name = "GroupN";
            this.GroupN.Width = 250;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(323, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(413, 116);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(231, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearchGeneric
            // 
            this.txtSearchGeneric.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchGeneric.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchGeneric.Location = new System.Drawing.Point(136, 160);
            this.txtSearchGeneric.Name = "txtSearchGeneric";
            this.txtSearchGeneric.PlaceHolderText = "Search Generic";
            this.txtSearchGeneric.Size = new System.Drawing.Size(413, 26);
            this.txtSearchGeneric.TabIndex = 343;
            this.txtSearchGeneric.Text = "Search Generic";
            this.txtSearchGeneric.TextChanged += new System.EventHandler(this.txtSearchGeneric_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 345;
            this.label2.Text = "Select Group";
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(136, 37);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(311, 29);
            this.cmbGroup.TabIndex = 344;
            // 
            // frmGeniric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 700);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.txtSearchGeneric);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgGeneric);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmGeniric";
            this.Text = "Geniric";
            this.Load += new System.EventHandler(this.frmGeniric_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGeneric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgGeneric;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox txtSearchGeneric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenericId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupN;
    }
}