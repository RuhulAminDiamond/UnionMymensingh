using POS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmCustomerReturn : Form
    {
        public frmCustomerReturn()
        {
            InitializeComponent();
        }

        private void frmCustomerReturn_Load(object sender, EventArgs e)
        {
            TabPage page = new TabPage("View 1");
            ProductReturnControl control = new ProductReturnControl();
            //control.EntryCompleted += control_EntryCompleted;
            page.Controls.Add(control);
            tabControl1.TabPages.Add(page);
            control.Dock = DockStyle.Fill;
            FillReturnPage(page, control);
        }

        private void FillReturnPage(TabPage page, ProductReturnControl control)
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
