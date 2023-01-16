using HDMS.Model;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Diagonstics
{
    public partial class frmChamberPractitionerEntry : Form
    {
        public frmChamberPractitionerEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(cmbstatus.Text))
            {
                ChamberPractitioner _practitioner = new ChamberPractitioner();
                _practitioner.Name = txtName.Text;
                _practitioner.Identity1 = txtIdentityLine1.Text;
                _practitioner.Identity2 = txtIdentityLine2.Text;
                _practitioner.Identity3 = txtIdentityLine3.Text;
                _practitioner.Identity4 = txtIdentityLine4.Text;
                _practitioner.Identity5 = txtIdentityLine5.Text;
                _practitioner.Status = cmbstatus.Text;

                if (new ChamberPractitionerService().AddPractitioner(_practitioner))
                {
                    MessageBox.Show("Practioner Added Successfully.");
                    txtName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Name and Status required.");
            }
        }
    }
}
