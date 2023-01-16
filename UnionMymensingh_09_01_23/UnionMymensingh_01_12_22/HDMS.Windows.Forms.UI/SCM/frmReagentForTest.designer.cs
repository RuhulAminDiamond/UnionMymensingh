namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    partial class frmReagentForTest
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
            this.lblTest = new System.Windows.Forms.Label();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblServiceTitle = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgTestItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchTest = new HDMS.Windows.Forms.UI.Controls.PlaceHolderTextBox();
            this.ctlProductSearchControl = new HDMS.Windows.Forms.UI.Controls.StoreProductSearchControl();
            this.ctlTestSearch = new HDMS.Windows.Forms.UI.Diagonstics.TestSearchControl();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(446, 33);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(80, 18);
            this.lblTest.TabIndex = 11144;
            this.lblTest.Text = "Serch Test";
            // 
            // txtTestCode
            // 
            this.txtTestCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCode.Location = new System.Drawing.Point(532, 30);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(398, 29);
            this.txtTestCode.TabIndex = 11145;
            this.txtTestCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestCode_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(532, 65);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(619, 29);
            this.txtName.TabIndex = 11147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(429, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 11148;
            this.label1.Text = "Selected Test";
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProductName,
            this.Qty});
            this.dgItems.Location = new System.Drawing.Point(532, 142);
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(619, 330);
            this.dgItems.TabIndex = 11149;
            this.dgItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgItems_UserDeletedRow);
            // 
            // Id
            // 
            this.Id.HeaderText = "ProductId";
            this.Id.Name = "Id";
            this.Id.Width = 120;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 350;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 110;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(997, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 18);
            this.label13.TabIndex = 11210;
            this.label13.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(1050, 100);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(101, 29);
            this.txtQty.TabIndex = 11209;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblServiceTitle
            // 
            this.lblServiceTitle.AutoSize = true;
            this.lblServiceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblServiceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceTitle.Location = new System.Drawing.Point(413, 105);
            this.lblServiceTitle.Name = "lblServiceTitle";
            this.lblServiceTitle.Size = new System.Drawing.Size(114, 18);
            this.lblServiceTitle.TabIndex = 11207;
            this.lblServiceTitle.Text = "Select Re-Agent";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(532, 100);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(112, 29);
            this.txtProduct.TabIndex = 11208;
            this.txtProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(650, 100);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(341, 29);
            this.txtProductName.TabIndex = 11212;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(532, 493);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 40);
            this.btnSave.TabIndex = 11213;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(788, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 40);
            this.btnClose.TabIndex = 11214;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgTestItems
            // 
            this.dgTestItems.AllowUserToAddRows = false;
            this.dgTestItems.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgTestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTestItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.TestName});
            this.dgTestItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTestItems.Location = new System.Drawing.Point(3, 55);
            this.dgTestItems.Name = "dgTestItems";
            this.dgTestItems.RowTemplate.Height = 35;
            this.dgTestItems.Size = new System.Drawing.Size(386, 660);
            this.dgTestItems.TabIndex = 11215;
            this.dgTestItems.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTestItems_RowHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TestId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Test Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "Name";
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.Width = 300;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtSearchTest, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgTestItems, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(392, 718);
            this.tableLayoutPanel1.TabIndex = 11216;
            // 
            // txtSearchTest
            // 
            this.txtSearchTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchTest.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Italic);
            this.txtSearchTest.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchTest.Location = new System.Drawing.Point(26, 13);
            this.txtSearchTest.Name = "txtSearchTest";
            this.txtSearchTest.PlaceHolderText = "Search test";
            this.txtSearchTest.Size = new System.Drawing.Size(340, 25);
            this.txtSearchTest.TabIndex = 11216;
            this.txtSearchTest.Text = "Search test";
            this.txtSearchTest.TextChanged += new System.EventHandler(this.txtSearchTest_TextChanged);
            // 
            // ctlProductSearchControl
            // 
            this.ctlProductSearchControl.Location = new System.Drawing.Point(997, 121);
            this.ctlProductSearchControl.Name = "ctlProductSearchControl";
            this.ctlProductSearchControl.Size = new System.Drawing.Size(764, 650);
            this.ctlProductSearchControl.TabIndex = 11211;
            this.ctlProductSearchControl.Visible = false;
            // 
            // ctlTestSearch
            // 
            this.ctlTestSearch.Location = new System.Drawing.Point(1029, 209);
            this.ctlTestSearch.Margin = new System.Windows.Forms.Padding(4);
            this.ctlTestSearch.Name = "ctlTestSearch";
            this.ctlTestSearch.Size = new System.Drawing.Size(532, 496);
            this.ctlTestSearch.TabIndex = 11146;
            this.ctlTestSearch.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(674, 493);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 40);
            this.btnClear.TabIndex = 11217;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmReagentForTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 718);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ctlProductSearchControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlTestSearch);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtTestCode);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblServiceTitle);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmReagentForTest";
            this.Text = "Reagent For Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReagentForTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtTestCode;
        private Diagonstics.TestSearchControl ctlTestSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblServiceTitle;
        private System.Windows.Forms.TextBox txtProduct;
        private Controls.StoreProductSearchControl ctlProductSearchControl;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgTestItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.PlaceHolderTextBox txtSearchTest;
        private System.Windows.Forms.Button btnClear;
    }
}