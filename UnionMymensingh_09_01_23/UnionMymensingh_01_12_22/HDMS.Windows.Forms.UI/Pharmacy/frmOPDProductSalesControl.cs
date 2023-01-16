using HDMS.Windows.Forms.UI.Pharmacy;
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
    public partial class frmOPDProductSalesControl : Form
    {
        public frmOPDProductSalesControl()
        {
            InitializeComponent();
        }



        private void frmProductSalesControl_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Sale View");
            PhOPDProductSalesControl control1 = new PhOPDProductSalesControl();

            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillSaleViewPage(page1, control1);  


            TabPage page2 = new TabPage("Sale View 2");
            PhOPDProductSalesControl control2 = new PhOPDProductSalesControl();
            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillSaleViewPage(page2, control2);

            TabPage page3 = new TabPage("Sale View 3");
            PhOPDProductSalesControl control3 = new PhOPDProductSalesControl();
            page3.Controls.Add(control3);
            tabControl1.TabPages.Add(page3);
            control2.Dock = DockStyle.Fill;
            FillSaleViewPage(page3, control3);

            TabPage page4 = new TabPage("Sale View 4");
            PhOPDProductSalesControl control4 = new PhOPDProductSalesControl();
            page4.Controls.Add(control4);
            tabControl1.TabPages.Add(page4);
            control4.Dock = DockStyle.Fill;
            FillSaleViewPage(page4, control4);


        }

        private void FillSaleViewPage(TabPage page1, PhOPDProductSalesControl control1)
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
