
namespace HDMS.Windows.Forms.UI.Media
{
    partial class frmMediaCommissionStatement
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnShowStatement = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUnpaid = new System.Windows.Forms.CheckBox();
            this.ctlMediaSearchControl = new HDMS.Windows.Forms.UI.Controls.MediaSearchControl();
            this.btnMediaWaise = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 10048;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 10049;
            this.label2.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(360, 84);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(139, 27);
            this.dtpTo.TabIndex = 10047;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(118, 84);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(145, 27);
            this.dtpFrom.TabIndex = 10046;
            // 
            // btnShowStatement
            // 
            this.btnShowStatement.BackColor = System.Drawing.Color.Teal;
            this.btnShowStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowStatement.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStatement.ForeColor = System.Drawing.SystemColors.Control;
            this.btnShowStatement.Location = new System.Drawing.Point(115, 147);
            this.btnShowStatement.Name = "btnShowStatement";
            this.btnShowStatement.Size = new System.Drawing.Size(131, 32);
            this.btnShowStatement.TabIndex = 10050;
            this.btnShowStatement.Text = "Show Statement";
            this.btnShowStatement.UseVisualStyleBackColor = false;
            this.btnShowStatement.Click += new System.EventHandler(this.btnShowStatement_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(-47, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 11217;
            this.label15.Text = "Media :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMedia
            // 
            this.txtMedia.BackColor = System.Drawing.SystemColors.Window;
            this.txtMedia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedia.Location = new System.Drawing.Point(119, 42);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(426, 29);
            this.txtMedia.TabIndex = 11218;
            this.txtMedia.TextChanged += new System.EventHandler(this.txtMedia_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11219;
            this.label3.Text = "Media";
            // 
            // cbUnpaid
            // 
            this.cbUnpaid.AutoSize = true;
            this.cbUnpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUnpaid.Location = new System.Drawing.Point(118, 120);
            this.cbUnpaid.Name = "cbUnpaid";
            this.cbUnpaid.Size = new System.Drawing.Size(73, 22);
            this.cbUnpaid.TabIndex = 11224;
            this.cbUnpaid.Text = "Unpaid";
            this.cbUnpaid.UseVisualStyleBackColor = true;
            // 
            // ctlMediaSearchControl
            // 
            this.ctlMediaSearchControl.Location = new System.Drawing.Point(66, 186);
            this.ctlMediaSearchControl.Margin = new System.Windows.Forms.Padding(4);
            this.ctlMediaSearchControl.Name = "ctlMediaSearchControl";
            this.ctlMediaSearchControl.Size = new System.Drawing.Size(483, 519);
            this.ctlMediaSearchControl.TabIndex = 11223;
            this.ctlMediaSearchControl.Visible = false;
            this.ctlMediaSearchControl.SearchEsacaped += new HDMS.Windows.Forms.UI.Controls.SearchResultListControl<HDMS.Model.Common.BusinessMedia>.SearchEscapeEventHandler(this.ctlMediaSearchControl_SearchEsacaped);
            // 
            // btnMediaWaise
            // 
            this.btnMediaWaise.BackColor = System.Drawing.Color.Teal;
            this.btnMediaWaise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMediaWaise.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMediaWaise.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMediaWaise.Location = new System.Drawing.Point(280, 147);
            this.btnMediaWaise.Name = "btnMediaWaise";
            this.btnMediaWaise.Size = new System.Drawing.Size(237, 32);
            this.btnMediaWaise.TabIndex = 10050;
            this.btnMediaWaise.Text = "Show  Medis Statement";
            this.btnMediaWaise.UseVisualStyleBackColor = false;
            this.btnMediaWaise.Click += new System.EventHandler(this.btnMediaWaise_Click);
            // 
            // frmMediaCommissionStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.ctlMediaSearchControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMedia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnMediaWaise);
            this.Controls.Add(this.btnShowStatement);
            this.Controls.Add(this.cbUnpaid);
            this.Name = "frmMediaCommissionStatement";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Commission Statement (Media Wise)";
            this.Load += new System.EventHandler(this.frmMediaCommissionStatement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnShowStatement;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMedia;
        private System.Windows.Forms.Label label3;
        private Controls.MediaSearchControl ctlMediaSearchControl;
        private System.Windows.Forms.CheckBox cbUnpaid;
        private System.Windows.Forms.Button btnMediaWaise;
    }
}