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
    public partial class frmTemplateBasedDischargeFinal : Form
    {
        public frmTemplateBasedDischargeFinal()
        {
            InitializeComponent();
        }

        private void frmTemplateBasedDischargeFinal_Load(object sender, EventArgs e)
        {

            TabPage page2 = new TabPage("Discharge Part1");
            ctrlTemplateDischargePart1 control2 = new ctrlTemplateDischargePart1();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillDischargeReportViewPage1(page2, control2);


            TabPage page1 = new TabPage("Discharge Part2");
            ctrlTemplateDischargePart2 control1 = new ctrlTemplateDischargePart2();

            
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillDischargeReportViewPage2(page1, control1);


            TabPage page3 = new TabPage("Investigation Results");
            ctrlTemplateIPDTestResult controlipd = new ctrlTemplateIPDTestResult();


            page3.Controls.Add(controlipd);
            tabControl1.TabPages.Add(page3);
            control1.Dock = DockStyle.Fill;
            FillDischargeReportViewPage3(page3, controlipd);


        }

        private void FillDischargeReportViewPage3(TabPage page, ctrlTemplateIPDTestResult controlipd)
        {
            page.Location = new System.Drawing.Point(4, 22);
            page.Padding = new System.Windows.Forms.Padding(3);
            page.Size = new System.Drawing.Size(892, 467);
            page.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            controlipd.AutoSize = true;
            controlipd.Dock = System.Windows.Forms.DockStyle.Fill;
            controlipd.Location = new System.Drawing.Point(3, 3);
            controlipd.Size = new System.Drawing.Size(886, 461);
        }

        private void FillDischargeReportViewPage2(TabPage page, ctrlTemplateDischargePart2 control)
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

        private void FillDischargeReportViewPage1(TabPage page, ctrlTemplateDischargePart1 control)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
