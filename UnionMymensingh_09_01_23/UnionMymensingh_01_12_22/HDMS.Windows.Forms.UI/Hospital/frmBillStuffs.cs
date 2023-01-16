using HDMS.Windows.Forms.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmBillStuffs : Form
    {
        public frmBillStuffs()
        {
            InitializeComponent();
        }

        private void frmBillStuffs_Load(object sender, EventArgs e)
        {

            TabPage page1 = new TabPage("Rough Billing");
            ctrlHpRoughBilling control1 = new ctrlHpRoughBilling();
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillRoughBillingViewPage(page1, control1);


            TabPage page2 = new TabPage("Discharge Patient");
            ctrlMR control2 = new ctrlMR();
            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillDischargeViewPage(page2, control2);


            TabPage page3 = new TabPage("Service");
            ctrlServices control3 = new ctrlServices();
            page3.Controls.Add(control3);
            tabControl1.TabPages.Add(page3);
            control3.Dock = DockStyle.Fill;
            FillServiceViewPage(page3, control3);


            TabPage page4 = new TabPage("Doctor");
            ctrlDoctors control4 = new ctrlDoctors();
            page4.Controls.Add(control4);
            tabControl1.TabPages.Add(page4);
            control4.Dock = DockStyle.Fill;
            FillDoctorViewPage(page4, control4);


            TabPage page5= new TabPage("OT");
            ctrlOT control5 = new ctrlOT();
            page5.Controls.Add(control5);
            tabControl1.TabPages.Add(page5);
            control5.Dock = DockStyle.Fill;
            FillOTViewPage(page5, control5);


            TabPage page6 = new TabPage("Extra Bed");
            ctrlExtraBed control6 = new ctrlExtraBed();
            page6.Controls.Add(control6);
            tabControl1.TabPages.Add(page6);
            control6.Dock = DockStyle.Fill;
            FillExtraBedViewPage(page6, control6);


            TabPage page7 = new TabPage("Transfer");
            ctrlTransfer control7 = new ctrlTransfer();
            page7.Controls.Add(control7);
            tabControl1.TabPages.Add(page7);
            control7.Dock = DockStyle.Fill;
            FillTransferViewPage(page7, control7);

        }

        private void FillTransferViewPage(TabPage page7, ctrlTransfer control7)
        {
            page7.Location = new System.Drawing.Point(4, 22);
            page7.Padding = new System.Windows.Forms.Padding(3);
            page7.Size = new System.Drawing.Size(892, 467);
            page7.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control7.AutoSize = true;
            control7.Dock = System.Windows.Forms.DockStyle.Fill;
            control7.Location = new System.Drawing.Point(3, 3);
            control7.Size = new System.Drawing.Size(886, 461);
        }

        private void FillExtraBedViewPage(TabPage page6, ctrlExtraBed control6)
        {
            page6.Location = new System.Drawing.Point(4, 22);
            page6.Padding = new System.Windows.Forms.Padding(3);
            page6.Size = new System.Drawing.Size(892, 467);
            page6.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control6.AutoSize = true;
            control6.Dock = System.Windows.Forms.DockStyle.Fill;
            control6.Location = new System.Drawing.Point(3, 3);
            control6.Size = new System.Drawing.Size(886, 461);
        }

        private void FillOTViewPage(TabPage page5, ctrlOT control5)
        {
            page5.Location = new System.Drawing.Point(4, 22);
            page5.Padding = new System.Windows.Forms.Padding(3);
            page5.Size = new System.Drawing.Size(892, 467);
            page5.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control5.AutoSize = true;
            control5.Dock = System.Windows.Forms.DockStyle.Fill;
            control5.Location = new System.Drawing.Point(3, 3);
            control5.Size = new System.Drawing.Size(886, 461);
        }

        private void FillDoctorViewPage(TabPage page4, ctrlDoctors control4)
        {
            page4.Location = new System.Drawing.Point(4, 22);
            page4.Padding = new System.Windows.Forms.Padding(3);
            page4.Size = new System.Drawing.Size(892, 467);
            page4.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control4.AutoSize = true;
            control4.Dock = System.Windows.Forms.DockStyle.Fill;
            control4.Location = new System.Drawing.Point(3, 3);
            control4.Size = new System.Drawing.Size(886, 461);
        }

        private void FillServiceViewPage(TabPage page3, ctrlServices control3)
        {
            page3.Location = new System.Drawing.Point(4, 22);
            page3.Padding = new System.Windows.Forms.Padding(3);
            page3.Size = new System.Drawing.Size(892, 467);
            page3.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control3.AutoSize = true;
            control3.Dock = System.Windows.Forms.DockStyle.Fill;
            control3.Location = new System.Drawing.Point(3, 3);
            control3.Size = new System.Drawing.Size(886, 461);
        }

        private void FillDischargeViewPage(TabPage page2, ctrlMR control2)
        {
            page2.Location = new System.Drawing.Point(4, 22);
            page2.Padding = new System.Windows.Forms.Padding(3);
            page2.Size = new System.Drawing.Size(892, 467);
            page2.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control2.AutoSize = true;
            control2.Dock = System.Windows.Forms.DockStyle.Fill;
            control2.Location = new System.Drawing.Point(3, 3);
            control2.Size = new System.Drawing.Size(886, 461);
        }

        private void FillRoughBillingViewPage(TabPage page1, ctrlHpRoughBilling control1)
        {
            page1.Location = new System.Drawing.Point(4, 22);
            page1.Padding = new System.Windows.Forms.Padding(3);
            page1.Size = new System.Drawing.Size(892, 467);
            page1.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control1.AutoSize = true;
            control1.Dock = System.Windows.Forms.DockStyle.Fill;
            control1.Location = new System.Drawing.Point(3, 3);
            control1.Size = new System.Drawing.Size(886, 461);
        }

        private void FillBillStuffServicesViewPage(TabPage page, ctrlServices control)
        {
            page.Location = new System.Drawing.Point(4, 22);
            page.Padding = new System.Windows.Forms.Padding(3);
            page.Size = new System.Drawing.Size(892, 467);
            page.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control.AutoSize = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Location = new System.Drawing.Point(3, 3);
            control.Size = new System.Drawing.Size(886, 461);
        }

        private void FillBillStuffMRViewPage(TabPage page, ctrlMR control)
        {
            page.Location = new System.Drawing.Point(4, 22);
            page.Padding = new System.Windows.Forms.Padding(3);
            page.Size = new System.Drawing.Size(892, 467);
            page.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control.AutoSize = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Location = new System.Drawing.Point(3, 3);
            control.Size = new System.Drawing.Size(886, 461);
        }

        private void FillBillStuffViewPage(TabPage page, ctrlPatientBill control)
        {
            page.Location = new System.Drawing.Point(4, 22);
            page.Padding = new System.Windows.Forms.Padding(3);
            page.Size = new System.Drawing.Size(892, 467);
            page.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control.AutoSize = true;
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.Location = new System.Drawing.Point(3, 3);
            control.Size = new System.Drawing.Size(886, 461);
        }     
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
