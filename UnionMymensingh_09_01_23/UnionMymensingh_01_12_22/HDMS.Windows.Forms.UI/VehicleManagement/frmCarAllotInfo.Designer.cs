namespace HDMS.Windows.Forms.UI.Vehicle
{
    partial class frmCarAllotInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarAllotInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3A = new System.Windows.Forms.Label();
            this.txtCar = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRent = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.ctrlRouteSearch = new HDMS.Windows.Forms.UI.Controls.RouteSearchControl();
            this.ctrlDriverSearch2 = new HDMS.Windows.Forms.UI.Controls.DriverSearchControl();
            this.ctrlCarSearch = new HDMS.Windows.Forms.UI.Controls.CarSearchControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Car";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Driver";
            // 
            // label3A
            // 
            this.label3A.AutoSize = true;
            this.label3A.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3A.Location = new System.Drawing.Point(12, 142);
            this.label3A.Name = "label3A";
            this.label3A.Size = new System.Drawing.Size(143, 21);
            this.label3A.TabIndex = 5;
            this.label3A.Text = "Select Destination";
            // 
            // txtCar
            // 
            this.txtCar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCar.Location = new System.Drawing.Point(157, 44);
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(346, 27);
            this.txtCar.TabIndex = 6;
            this.txtCar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCar_KeyPress);
            // 
            // txtDriver
            // 
            this.txtDriver.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriver.Location = new System.Drawing.Point(157, 94);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(346, 27);
            this.txtDriver.TabIndex = 7;
            this.txtDriver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDriver_KeyPress);
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(157, 140);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(346, 27);
            this.txtDestination.TabIndex = 8;
            this.txtDestination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDestination_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rent :";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = true;
            this.lblRent.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRent.ForeColor = System.Drawing.Color.Red;
            this.lblRent.Location = new System.Drawing.Point(157, 186);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(45, 23);
            this.lblRent.TabIndex = 10;
            this.lblRent.Text = "Rent";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(145, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(282, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(420, 285);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 40);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(157, 230);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(131, 27);
            this.dtpDate.TabIndex = 18;
            // 
            // ctrlRouteSearch
            // 
            this.ctrlRouteSearch.Location = new System.Drawing.Point(12, 386);
            this.ctrlRouteSearch.Name = "ctrlRouteSearch";
            this.ctrlRouteSearch.Size = new System.Drawing.Size(927, 650);
            this.ctrlRouteSearch.TabIndex = 21;
            this.ctrlRouteSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Vehicle.RoutingOrTripInfo>.SearchEscapeEventHandler(this.ctrlRouteSearch_SearchEsacaped);
            // 
            // ctrlDriverSearch2
            // 
            this.ctrlDriverSearch2.Location = new System.Drawing.Point(445, 331);
            this.ctrlDriverSearch2.Name = "ctrlDriverSearch2";
            this.ctrlDriverSearch2.Size = new System.Drawing.Size(927, 650);
            this.ctrlDriverSearch2.TabIndex = 20;
            this.ctrlDriverSearch2.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Vehicle.DriverInfo>.SearchEscapeEventHandler(this.ctrlDriverSearch2_SearchEsacaped);
            // 
            // ctrlCarSearch
            // 
            this.ctrlCarSearch.Location = new System.Drawing.Point(34, 331);
            this.ctrlCarSearch.Name = "ctrlCarSearch";
            this.ctrlCarSearch.Size = new System.Drawing.Size(583, 650);
            this.ctrlCarSearch.TabIndex = 19;
            this.ctrlCarSearch.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Vehicle.CarInfo>.SearchEscapeEventHandler(this.ctrlCarSearch_SearchEsacaped);
            // 
            // frmCarAllotInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 553);
            this.Controls.Add(this.ctrlRouteSearch);
            this.Controls.Add(this.ctrlDriverSearch2);
            this.Controls.Add(this.ctrlCarSearch);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblRent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.txtCar);
            this.Controls.Add(this.label3A);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCarAllotInfo";
            this.Text = "Car Allotment Info";
            this.Load += new System.EventHandler(this.frmCarAllotInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3A;
        private System.Windows.Forms.TextBox txtCar;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private Controls.CarSearchControl ctrlCarSearch;
        private Controls.DriverSearchControl ctrlDriverSearch2;
        private Controls.RouteSearchControl ctrlRouteSearch;
    }
}