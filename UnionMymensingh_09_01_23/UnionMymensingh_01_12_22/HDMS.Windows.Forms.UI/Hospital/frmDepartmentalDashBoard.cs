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
    public partial class frmDepartmentalDashBoard : Form
    {
        public frmDepartmentalDashBoard()
        {
            InitializeComponent();
        }

        private void frmDepartmentalDashBoard_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Admitted Patient List");
            ctrlAdmittedPatientList control1 = new ctrlAdmittedPatientList();
            
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillAdmittedPage(page1, control1);


            TabPage page2 = new TabPage("Discharged Patient List");
            ctrlDepartmentalDischargedPatientList control2 = new ctrlDepartmentalDischargedPatientList();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillDischrageList(page2, control2);

        }

        private void FillDischrageList(TabPage page, ctrlDepartmentalDischargedPatientList control)
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

        private void FillAdmittedPage(TabPage page, ctrlAdmittedPatientList control)
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
