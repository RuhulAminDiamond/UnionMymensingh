using Hospital.UI.Forms.OPD;
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
    public partial class frmOPDMedicineReturn : Form
    {
        public frmOPDMedicineReturn()
        {
            InitializeComponent();
        }

        private void frmOPDMedicineReturn_Load(object sender, EventArgs e)
        {
            TabPage page2 = new TabPage("OPD Services");
            OPDMedicineReturnControl control2 = new OPDMedicineReturnControl();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillOPDMedicineReturnPage1(page2, control2);

        }

        private void FillOPDMedicineReturnPage1(TabPage page, OPDMedicineReturnControl control)
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
