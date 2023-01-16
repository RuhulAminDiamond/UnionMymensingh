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
    public partial class frmServiceEntry : Form
    {
        public frmServiceEntry()
        {
            InitializeComponent();
        }

        private void frmServiceEntry_Load(object sender, EventArgs e)
        {
            TabPage page = new TabPage("Floor Service");
            ctrlServices control = new ctrlServices();
           // control.EntryCompleted += control_EntryCompleted;
            page.Controls.Add(control);
            tabControl1.TabPages.Add(page);
            control.Dock = DockStyle.Fill;
            FillServicePage(page, control);

            //control.txtCellPhone.Focus();

            TabPage page3 = new TabPage("Discharge Request");
            ctrlDischargeRequest control1 = new ctrlDischargeRequest();
            // control1.EntryCompleted += control_EntryCompleted;
            page3.Controls.Add(control1);
            tabControl1.TabPages.Add(page3);
            control1.Dock = DockStyle.Fill;
            FillDischargeRequestPage(page3, control1);
        }

        private void FillDischargeRequestPage(TabPage page, ctrlDischargeRequest control)
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

        private void FillServicePage(TabPage page, ctrlServices control)
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
