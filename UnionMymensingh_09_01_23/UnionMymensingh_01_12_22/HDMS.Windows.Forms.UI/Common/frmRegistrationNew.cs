using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmRegistrationNew : Form
    {
        public frmRegistrationNew()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistrationNew_Load(object sender, EventArgs e)
        {
            TabPage page1 = new TabPage("Reg. View 1");
            ctrlRegistration control1 = new ctrlRegistration();
          
            page1.Controls.Add(control1);
            tabControl1.TabPages.Add(page1);
            control1.Dock = DockStyle.Fill;
            FillRegPage(page1, control1);

            TabPage page2 = new TabPage("Reg. View 2");
            ctrlRegistration control2 = new ctrlRegistration();

            page2.Controls.Add(control2);
            tabControl1.TabPages.Add(page2);
            control2.Dock = DockStyle.Fill;
            FillRegPage(page2, control2);


            TabPage page3 = new TabPage("Reg. View 3");
            ctrlRegistration control3 = new ctrlRegistration();

            page3.Controls.Add(control3);
            tabControl1.TabPages.Add(page3);
            control3.Dock = DockStyle.Fill;
            FillRegPage(page3, control3);

            /*
            TabPage page4 = new TabPage("Registration  Window Four");
            ctrlRegistration control4 = new ctrlRegistration();

            page4.Controls.Add(control4);
            tabControl1.TabPages.Add(page4);
            control4.Dock = DockStyle.Fill;
            FillRegPage(page4, control4);


            TabPage page5 = new TabPage("Registration  Window Five");
            ctrlRegistration control5 = new ctrlRegistration();

            page5.Controls.Add(control5);
            tabControl1.TabPages.Add(page5);
            control5.Dock = DockStyle.Fill;
            FillRegPage(page5, control5);


            TabPage page6 = new TabPage("Registration  Window Six");
            ctrlRegistration control6 = new ctrlRegistration();

            page6.Controls.Add(control6);
            tabControl1.TabPages.Add(page6);
            control6.Dock = DockStyle.Fill;
            FillRegPage(page6, control6);


            TabPage page7 = new TabPage("Registration  Window Seven");
            ctrlRegistration control7 = new ctrlRegistration();

            page7.Controls.Add(control7);
            tabControl1.TabPages.Add(page7);
            control7.Dock = DockStyle.Fill;
            FillRegPage(page7, control7);



            //TabPage page2 = new TabPage("View 2");
            //PatientEntryControl control2 = new PatientEntryControl();
            //control2.EntryCompleted += control_EntryCompleted;
            //page2.Controls.Add(control2);
            //tabControl1.TabPages.Add(page2);
            //control2.Dock = DockStyle.Fill;
            //FillPatientPage(page2, control2);

            ////control.txtCellPhone.Focus();

            //TabPage page3 = new TabPage("View 3");
            //PatientEntryControl control3 = new PatientEntryControl();
            //control3.EntryCompleted += control_EntryCompleted;
            //page3.Controls.Add(control3);
            //tabControl1.TabPages.Add(page3);
            //control3.Dock = DockStyle.Fill;
            //FillPatientPage(page3, control3);  */
        }

        private void FillRegPage(TabPage page, ctrlRegistration control)
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
