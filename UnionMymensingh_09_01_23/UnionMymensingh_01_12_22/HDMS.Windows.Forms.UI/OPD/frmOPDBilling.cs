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
    public partial class frmOPDBilling : Form
    {
        public frmOPDBilling()
        {
            InitializeComponent();
        }

        private void frmOPDBilling_Load(object sender, EventArgs e)
        {
            //TabPage page1 = new TabPage("Billing window");
            //ctrlOPDMR control = new ctrlOPDMR();

            //page1.Controls.Add(control);
            //tabControl1.TabPages.Add(page1);
            //control.Dock = DockStyle.Fill;
            //FillBillingPage(page1, control);
        }

        private void FillBillingPage(TabPage page1, ctrlOPDMR control)
        {
            page1.Location = new System.Drawing.Point(4, 22);
            page1.Padding = new System.Windows.Forms.Padding(3);
            page1.Size = new System.Drawing.Size(892, 467);
            page1.UseVisualStyleBackColor = true;
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
