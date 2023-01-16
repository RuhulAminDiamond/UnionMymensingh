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
    public partial class frmEmergencyServiceEntry : Form
    {
        public frmEmergencyServiceEntry()
        {
            InitializeComponent();
        }

        private void frmEmergencyServiceEntry_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Service Entry");
            ctrlEmergencyServices control = new ctrlEmergencyServices();

            page1.Controls.Add(control);
            tabControl1.TabPages.Add(page1);
            control.Dock = DockStyle.Fill;
            FillServicePage(page1, control);

            //control.txtCellPhone.Focus();

            TabPage page2 = new TabPage("Consultant Service Entry");
            ctrlEmergencyDoctors control1 = new ctrlEmergencyDoctors();
            page2.Controls.Add(control1);
            tabControl1.TabPages.Add(page2);
            control1.Dock = DockStyle.Fill;
            FillDoctorServicePage(page2, control1);
        }

        private void FillDoctorServicePage(TabPage page, ctrlEmergencyDoctors control)
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

        private void FillServicePage(TabPage page, ctrlEmergencyServices control)
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
