
namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    partial class frmCategoryIdWtihReportTyeIdWithCommission
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtReportType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommissionTK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommissionPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.dgMediaCommission = new System.Windows.Forms.DataGridView();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommissionPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryRepotTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.ctrlReportTypeSearchControl = new HDMS.Windows.Forms.UI.Controls.ReportTypeSearchControl();
            this.ctrlMeidaCategoryController = new HDMS.Windows.Forms.UI.Controls.MeidaCategoryController();
            ((System.ComponentModel.ISupportInitialize)(this.dgMediaCommission)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Category Name :";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(490, 188);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close Me ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(178, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReportType
            // 
            this.txtReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportType.Location = new System.Drawing.Point(178, 73);
            this.txtReportType.Name = "txtReportType";
            this.txtReportType.Size = new System.Drawing.Size(334, 29);
            this.txtReportType.TabIndex = 3;
            this.txtReportType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportType_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Report Type :";
            // 
            // txtCommissionTK
            // 
            this.txtCommissionTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommissionTK.Location = new System.Drawing.Point(178, 108);
            this.txtCommissionTK.Name = "txtCommissionTK";
            this.txtCommissionTK.Size = new System.Drawing.Size(150, 29);
            this.txtCommissionTK.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Commission (TK) :";
            // 
            // txtCommissionPercent
            // 
            this.txtCommissionPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommissionPercent.Location = new System.Drawing.Point(178, 143);
            this.txtCommissionPercent.Name = "txtCommissionPercent";
            this.txtCommissionPercent.Size = new System.Drawing.Size(150, 29);
            this.txtCommissionPercent.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Commission (%) :";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(178, 39);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(334, 29);
            this.txtCategoryName.TabIndex = 3;
            this.txtCategoryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // dgMediaCommission
            // 
            this.dgMediaCommission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMediaCommission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryName,
            this.ReportTypeName,
            this.ReportId,
            this.Commission,
            this.CommissionPercent,
            this.CategoryRepotTypeId,
            this.CategoryId});
            this.dgMediaCommission.Location = new System.Drawing.Point(178, 238);
            this.dgMediaCommission.Name = "dgMediaCommission";
            this.dgMediaCommission.Size = new System.Drawing.Size(794, 429);
            this.dgMediaCommission.TabIndex = 10;
            this.dgMediaCommission.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgMediaCommission_RowHeaderMouseClick);
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Width = 200;
            // 
            // ReportTypeName
            // 
            this.ReportTypeName.HeaderText = "ReportType Name";
            this.ReportTypeName.Name = "ReportTypeName";
            this.ReportTypeName.Width = 250;
            // 
            // ReportId
            // 
            this.ReportId.HeaderText = "Retprot Id";
            this.ReportId.Name = "ReportId";
            // 
            // Commission
            // 
            this.Commission.HeaderText = "Com TK";
            this.Commission.Name = "Commission";
            // 
            // CommissionPercent
            // 
            this.CommissionPercent.HeaderText = "Com Percent";
            this.CommissionPercent.Name = "CommissionPercent";
            // 
            // CategoryRepotTypeId
            // 
            this.CategoryRepotTypeId.HeaderText = "Report Category";
            this.CategoryRepotTypeId.Name = "CategoryRepotTypeId";
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "CategoryI d";
            this.CategoryId.Name = "CategoryId";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnUpdate.Location = new System.Drawing.Point(334, 188);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 42);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update Data";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ctrlReportTypeSearchControl
            // 
            this.ctrlReportTypeSearchControl.Location = new System.Drawing.Point(204, 459);
            this.ctrlReportTypeSearchControl.Name = "ctrlReportTypeSearchControl";
            this.ctrlReportTypeSearchControl.Size = new System.Drawing.Size(698, 644);
            this.ctrlReportTypeSearchControl.TabIndex = 8;
            this.ctrlReportTypeSearchControl.ItemSelected += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportType>.ItemSelectedEventHandler(this.ctrlReportTypeSearchControl_ItemSelected);
            this.ctrlReportTypeSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.ReportType>.SearchEscapeEventHandler(this.ctrlReportTypeSearchControl_SearchEsacaped);
            // 
            // ctrlMeidaCategoryController
            // 
            this.ctrlMeidaCategoryController.Location = new System.Drawing.Point(204, 319);
            this.ctrlMeidaCategoryController.Name = "ctrlMeidaCategoryController";
            this.ctrlMeidaCategoryController.Size = new System.Drawing.Size(715, 650);
            this.ctrlMeidaCategoryController.TabIndex = 9;
            this.ctrlMeidaCategoryController.ItemSelected += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Diagnostic.MediaCategory>.ItemSelectedEventHandler(this.ctrlMeidaCategoryController_ItemSelected);
            this.ctrlMeidaCategoryController.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Diagnostic.MediaCategory>.SearchEscapeEventHandler(this.ctrlMeidaCategoryController_SearchEsacaped);
            // 
            // frmCategoryIdWtihReportTyeIdWithCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1088, 668);
            this.Controls.Add(this.ctrlReportTypeSearchControl);
            this.Controls.Add(this.ctrlMeidaCategoryController);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCommissionPercent);
            this.Controls.Add(this.txtCommissionTK);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.txtReportType);
            this.Controls.Add(this.dgMediaCommission);
            this.Name = "frmCategoryIdWtihReportTyeIdWithCommission";
            this.Text = "frmCategoryIdWtihReportTyeIdWithCommission";
            this.Load += new System.EventHandler(this.frmCategoryIdWtihReportTyeIdWithCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMediaCommission)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReportType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCommissionTK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCommissionPercent;
        private System.Windows.Forms.Label label4;
        private Controls.ReportTypeSearchControl ctrlReportTypeSearchControl;
        private System.Windows.Forms.TextBox txtCategoryName;
        private Controls.MeidaCategoryController ctrlMeidaCategoryController;
        private System.Windows.Forms.DataGridView dgMediaCommission;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commission;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommissionPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryRepotTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
    }
}