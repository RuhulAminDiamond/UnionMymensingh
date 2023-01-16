using HDMS.Model;
using HDMS.Service.Doctors;
using HDMS.Windows.Forms.UI.Rx;
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
    public partial class frmSelectChamberPractitiner : Form
    {
        public frmSelectChamberPractitiner()
        {
            InitializeComponent();
        }

        private void frmSelectChamberPractitiner_Load(object sender, EventArgs e)
        {
            List<Doctor> ReportDoctors = new DoctorService().GetAllDoctors().ToList(); //new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay().ToList();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new Doctor()
                {
                    DoctorId = 0,
                    Name = "Select Yourself"
                });
            }

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "DoctorId";

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbConsultant.SelectedValue) > 0)
            {
                //frmRxViewer _uxReport = new frmRxViewer((Doctor)cmbConsultant.SelectedItem);
                //_uxReport.Show();

            }

            new frmSelectConsultant().Hide();
        }
    }
}
