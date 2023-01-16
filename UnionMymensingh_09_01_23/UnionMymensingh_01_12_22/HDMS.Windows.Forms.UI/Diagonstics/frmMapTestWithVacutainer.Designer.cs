namespace HDMS.Windows.Forms.UI.Diagonstics
{
    partial class frmMapTestWithVacutainer
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
            this.cmbVacuTypes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchTest = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.Specimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSelectedTest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvTestlist = new System.Windows.Forms.DataGridView();
            this.txtSelectedVacu = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgBL = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Short_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBL)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbVacuTypes
            // 
            this.cmbVacuTypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVacuTypes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVacuTypes.FormattingEnabled = true;
            this.cmbVacuTypes.Location = new System.Drawing.Point(351, 29);
            this.cmbVacuTypes.Name = "cmbVacuTypes";
            this.cmbVacuTypes.Size = new System.Drawing.Size(257, 28);
            this.cmbVacuTypes.TabIndex = 1;
            this.cmbVacuTypes.SelectedIndexChanged += new System.EventHandler(this.cmbVacuTypes_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtSearchTest, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbVacuTypes, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(640, 87);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // txtSearchTest
            // 
            this.txtSearchTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchTest.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic);
            this.txtSearchTest.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchTest.Location = new System.Drawing.Point(18, 30);
            this.txtSearchTest.Name = "txtSearchTest";
            this.txtSearchTest.PlaceHolderText = "Search Test";
            this.txtSearchTest.Size = new System.Drawing.Size(283, 27);
            this.txtSearchTest.TabIndex = 21;
            this.txtSearchTest.Text = "Search Test";
            this.txtSearchTest.TextChanged += new System.EventHandler(this.txtSearchTest_TextChanged);
            // 
            // Specimen
            // 
            this.Specimen.HeaderText = "Specimen";
            this.Specimen.Name = "Specimen";
            // 
            // ShortName
            // 
            this.ShortName.HeaderText = "ShortName";
            this.ShortName.Name = "ShortName";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 220;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Test Code";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // txtSelectedTest
            // 
            this.txtSelectedTest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSelectedTest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedTest.Location = new System.Drawing.Point(171, 63);
            this.txtSelectedTest.Name = "txtSelectedTest";
            this.txtSelectedTest.Size = new System.Drawing.Size(190, 26);
            this.txtSelectedTest.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Test";
            // 
            // gvTestlist
            // 
            this.gvTestlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTestlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.ShortName,
            this.Specimen});
            this.gvTestlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTestlist.Location = new System.Drawing.Point(3, 96);
            this.gvTestlist.Name = "gvTestlist";
            this.gvTestlist.Size = new System.Drawing.Size(640, 644);
            this.gvTestlist.TabIndex = 3;
            this.gvTestlist.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvTestlist_RowHeaderMouseDoubleClick);
            // 
            // txtSelectedVacu
            // 
            this.txtSelectedVacu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSelectedVacu.Enabled = false;
            this.txtSelectedVacu.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedVacu.Location = new System.Drawing.Point(171, 12);
            this.txtSelectedVacu.Name = "txtSelectedVacu";
            this.txtSelectedVacu.Size = new System.Drawing.Size(244, 26);
            this.txtSelectedVacu.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.39568F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.60432F));
            this.tableLayoutPanel5.Controls.Add(this.txtSelectedTest, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtSelectedVacu, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(556, 102);
            this.tableLayoutPanel5.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected Vacutainer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgBL
            // 
            this.dgBL.AllowUserToAddRows = false;
            this.dgBL.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.TestName,
            this.Short_Name});
            this.dgBL.Location = new System.Drawing.Point(3, 111);
            this.dgBL.Name = "dgBL";
            this.dgBL.RowTemplate.Height = 35;
            this.dgBL.Size = new System.Drawing.Size(556, 420);
            this.dgBL.TabIndex = 21;
            this.dgBL.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgBL_UserDeletedRow);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.dgBL, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(655, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.22472F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.77528F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(562, 534);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gvTestlist, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.944752F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 650F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(646, 743);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.59932F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.40068F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1290, 749);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TestCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "TestId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // TestName
            // 
            this.TestName.HeaderText = "TestName";
            this.TestName.Name = "TestName";
            this.TestName.Width = 300;
            // 
            // Short_Name
            // 
            this.Short_Name.HeaderText = "ShortName";
            this.Short_Name.Name = "Short_Name";
            // 
            // frmMapTestWithVacutainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMapTestWithVacutainer";
            this.Text = "Map Test With Vacutainer";
            this.Load += new System.EventHandler(this.frmMapTestWithVacutainer_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTestlist)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBL)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVacuTypes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Controls.PlaceHolderTextBox txtSearchTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox txtSelectedTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvTestlist;
        private System.Windows.Forms.TextBox txtSelectedVacu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgBL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Short_Name;
    }
}