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
    public partial class frmOPDServices : Form
    {
        public frmOPDServices()
        {
            InitializeComponent();
        }

        private void frmOPDServices_Load(object sender, EventArgs e)
        {
            TabPage page2 = new TabPage("OPD Services");
            ctrlOPDServices control2 = new ctrlOPDServices();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillOPDServicePage1(page2, control2);


            TabPage page1 = new TabPage("OT Services");
            ctrlOPDOT control1 = new ctrlOPDOT();


            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillOPDOTService(page1, control1);

        }

        private void FillOPDOTService(TabPage page, ctrlOPDOT control)
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

        private void FillOPDServicePage1(TabPage page, ctrlOPDServices control)
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

    }
}
