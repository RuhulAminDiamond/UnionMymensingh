using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Forms
{
    public partial class frmProductSalesControl : Form
    {
        public frmProductSalesControl()
        {
            InitializeComponent();
        }



        private void frmProductSalesControl_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Sale View");
            PhIPDProductSalesControl control1 = new PhIPDProductSalesControl();

            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillSaleViewPage(page1, control1);
        }

        private void FillSaleViewPage(TabPage page1, PhIPDProductSalesControl control1)
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
