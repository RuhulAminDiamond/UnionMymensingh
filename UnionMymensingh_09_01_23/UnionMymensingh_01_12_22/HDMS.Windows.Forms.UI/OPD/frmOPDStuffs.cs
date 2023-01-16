using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.OPD
{
    public partial class frmOPDStuffs : Form
    {
        public frmOPDStuffs()
        {
            InitializeComponent();
        }

        private void frmOPDStuffs_Load(object sender, EventArgs e)
        {
            TabPage page2 = new TabPage("Consultancy Fee Collection");
            OPDConsultancyFeeCollectionControl control2 = new OPDConsultancyFeeCollectionControl();
            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillConsultacyFeeViewPage(page2, control2);

            TabPage tpPatientEntry = new TabPage("Patient Entry");
            OPDPatientEntryCtrl ctrlOPDPatientEntryCtrl = new OPDPatientEntryCtrl();
            tpPatientEntry.Controls.Add(ctrlOPDPatientEntryCtrl);
            tabControl1.TabPages.Add(tpPatientEntry);
            ctrlOPDPatientEntryCtrl.Dock = DockStyle.Fill;
            FillPatientEntryViewPage(tpPatientEntry, ctrlOPDPatientEntryCtrl);

            //TabPage page3 = new TabPage("OPD Billing");
            //ctrlOPDMR control3 = new ctrlOPDMR();
            //page3.Controls.Add(control3);
            //tabControl1.TabPages.Add(page3);
            //control3.Dock = DockStyle.Fill;
            //FillOPDBillingViewPage(page3, control3);

            //TabPage page4 = new TabPage("Procedure Billing");
            //ctrlOPDProcedureBill control4 = new ctrlOPDProcedureBill();
            //page4.Controls.Add(control4);
            //tabControl1.TabPages.Add(page4);
            //control4.Dock = DockStyle.Fill;
            //FillProcedureBillingViewPage(page4, control4);
        }

        private void FillPatientEntryViewPage(TabPage tpPatientEntry, OPDPatientEntryCtrl ctrlOPDPatientEntryCtrl)
        {
            tpPatientEntry.Location = new System.Drawing.Point(4, 22);
            tpPatientEntry.Padding = new System.Windows.Forms.Padding(3);
            tpPatientEntry.Size = new System.Drawing.Size(892, 467);
            tpPatientEntry.UseVisualStyleBackColor = true;

            ctrlOPDPatientEntryCtrl.AutoSize = true;
            ctrlOPDPatientEntryCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            ctrlOPDPatientEntryCtrl.Location = new System.Drawing.Point(3, 3);
            ctrlOPDPatientEntryCtrl.Size = new System.Drawing.Size(886, 461);
        }

        private void FillProcedureBillingViewPage(TabPage page4, ctrlOPDProcedureBill control4)
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

        private void FillOPDBillingViewPage(TabPage page3, ctrlOPDMR control3)
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

        private void FillConsultacyFeeViewPage(TabPage page2, OPDConsultancyFeeCollectionControl control2)
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

        private void FillSaleViewPage(TabPage page1, OPDPatientEntryCtrl control1)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
