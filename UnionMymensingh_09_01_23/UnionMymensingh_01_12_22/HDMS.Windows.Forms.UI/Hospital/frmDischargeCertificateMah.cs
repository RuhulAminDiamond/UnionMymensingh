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
    public partial class frmDischargeCertificateMah : Form
    {
        private int control_EntryCompleted;

        public frmDischargeCertificateMah()
        {
            InitializeComponent();
        }

        private void frmDischargeCertificateMah_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Dischage Certificate");
            ctrlDischargeCertificate control1 = new ctrlDischargeCertificate();
            control1.EntryCompleted += control_EntryCompleted;
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillCertificatePage(page1, control1);

        }

        private void FillCertificatePage(TabPage page, ctrlDischargeCertificate control)
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
