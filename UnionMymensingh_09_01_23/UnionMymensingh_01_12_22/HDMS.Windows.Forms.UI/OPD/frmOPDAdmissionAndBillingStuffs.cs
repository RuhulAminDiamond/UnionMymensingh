using HDMS.Windows.Forms.UI.Hospital;
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
    public partial class frmOPDAdmissionAndBillingStuffs : Form
    {
        public frmOPDAdmissionAndBillingStuffs()
        {
            InitializeComponent();
        }

        private void frmOPDStuffs_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("OPD Admission");
            ctrlOPDAdmission control1 = new ctrlOPDAdmission();

            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillSaleViewPage(page1, control1);

            TabPage page2 = new TabPage("Advance Collection");
            ctrlOPDAdvance control2 = new ctrlOPDAdvance();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillConsultacyFeeViewPage(page2, control2);

            TabPage page3 = new TabPage("OPD Billing");
            ctrlOPDMR control3 = new ctrlOPDMR();

            page3.Controls.Add(control3);
            tabControl1.TabPages.Add(page3);
            control3.Dock = DockStyle.Fill;
            FillOPDBillingViewPage(page3, control3);
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

        private void FillConsultacyFeeViewPage(TabPage page2, ctrlOPDAdvance control2)
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

        private void FillSaleViewPage(TabPage page1, ctrlOPDAdmission control1)
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
    }
}
