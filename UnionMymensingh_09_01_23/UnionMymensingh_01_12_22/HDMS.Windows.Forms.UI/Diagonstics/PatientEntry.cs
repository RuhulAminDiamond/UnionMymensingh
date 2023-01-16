using HDMS.Repository.ServiceObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HDMS.Windows.Forms.UI.Utils;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class PatientEntry : Form
    {
        public static LoginUser LoggedinUser { get; set; }

        
        public PatientEntry()
        {
           

            InitializeComponent();

            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);

            LoggedinUser = MainForm.LoggedinUser;

        }

       

        private void FillPatientPage(TabPage page, PatientEntryControl02032019 control)
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

        private void PatientEntry_Load(object sender, EventArgs e)
        {
            //TabPage page1 = new TabPage("View 1");
            //PatientEntryControl control1 = new PatientEntryControl();
            //control1.EntryCompleted += control_EntryCompleted;
            //page1.Controls.Add(control1);
            //tabControl1.TabPages.Add(page1);
            //control1.Dock = DockStyle.Fill;
            //FillPatientPage(page1, control1);


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
            //FillPatientPage(page3, control3);

            ////patientEntryControl1.txtCellPhone.Focus();

            //TabPage page4 = new TabPage("Siblings Service");
            //PatientSiblingsEntryControl control4 = new PatientSiblingsEntryControl();
            //control4.EntryCompleted += control_EntryCompleted;
            //page4.Controls.Add(control4);
            //tabControl1.TabPages.Add(page4);
            //control4.Dock = DockStyle.Fill;
            //FillPatientSiblingsPage(page4, control4);




        }

        private void FillPatientSiblingsPage(TabPage page4, PatientSiblingsEntryControl control4)
        {
            page4.Location = new System.Drawing.Point(4, 22);
            page4.Padding = new System.Windows.Forms.Padding(3);
            page4.Size = new System.Drawing.Size(892, 467);
            page4.UseVisualStyleBackColor = true;
            // 
            // patientEntryControl1
            // 
            control4.AutoSize = true;
            control4.Dock = System.Windows.Forms.DockStyle.Fill;
            control4.Location = new System.Drawing.Point(3, 3);
            control4.Size = new System.Drawing.Size(886, 461);
        }

        void control_EntryCompleted(object sender)
        {
            if (tabControl1.TabPages.Count > 2)
            {
                tabControl1.TabPages.Remove(((Control)sender).Parent as TabPage);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
