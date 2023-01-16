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

namespace POS
{
    public partial class frmCantProductEntry : Form
    {
       
        public frmCantProductEntry()
        {
            InitializeComponent();
          
        }

        private void FillProductEntryPage(TabPage page, ProductEntryControl control)
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


        private void FillProductSaleEntryPage(TabPage page, ProductSalesControl control)
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


        private void frmStuffs_Load(object sender, EventArgs e)
        {

            TabPage page1 = new TabPage("Product Entry");
            ProductEntryControl control1 = new ProductEntryControl();
            //control.EntryCompleted += control_EntryCompleted;
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillProductEntryPage(page1, control1);
            
            //TabPage page2 = new TabPage("Product Receive");
            //ProductReceiveControl control2 = new ProductReceiveControl();
            ////control1.EntryCompleted += control_EntryCompleted;
            //page2.Controls.Add(control2);
            //tabControl1.TabPages.Add(page2);
            //control2.Dock = DockStyle.Fill;
            //FillProductReceivePage(page2, control2);

            //TabPage page3 = new TabPage("Retail Sales");
            //ProductSalesControl control3 = new ProductSalesControl();
            ////control.EntryCompleted += control_EntryCompleted;
            //page3.Controls.Add(control3);
            //tabControl1.TabPages.Add(page3);
            //control3.Dock = DockStyle.Fill;
            //FillProductSaleEntryPage(page3, control3);

            //TabPage page4 = new TabPage("Whole Sales");
            //ProductWholeSalesControl control4 = new ProductWholeSalesControl();
            ////control.EntryCompleted += control_EntryCompleted;
            //page4.Controls.Add(control4);
            //tabControl1.TabPages.Add(page4);
            //control4.Dock = DockStyle.Fill;
            //FillHoleProductEntryPage(page4, control4);

            
            //TabPage page5 = new TabPage("Sales Return");
            //ProductReturnControl control5 = new ProductReturnControl();
            ////control.EntryCompleted += control_EntryCompleted;
            //page5.Controls.Add(control5);
            //tabControl1.TabPages.Add(page5);
            //control5.Dock = DockStyle.Fill;
            //FillProductReturnEntryPage(page5, control5);





            //TabPage page6 = new TabPage("Return to Supplier");
            //ProductReturntoSupplier control6 = new ProductReturntoSupplier();
            ////control.EntryCompleted += control_EntryCompleted;
            //page6.Controls.Add(control6);
            //tabControl1.TabPages.Add(page6);
            //control6.Dock = DockStyle.Fill;
            //FillProductReturntoSupplierEntryPage(page6, control6);



          

        }

      
        private void FillProductReturnEntryPage(TabPage page, ProductReturnControl control)
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

        

        private void FillProductReceivePage(TabPage page, ProductReceiveControl control)
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

        void control_EntryCompleted(object sender)
        {
            if (tabControl1.TabPages.Count > 5)
            {
                tabControl1.TabPages.Remove(((Control)sender).Parent as TabPage);
            }
        }

        
    }
}
