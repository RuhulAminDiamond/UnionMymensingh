using HDMS.Model;
using HDMS.Service.Doctors;
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
    public partial class frmSelectConsultant : Form
    {
        public static ReportConsultant _ReportConsultant { get; set; }

        public frmSelectConsultant()
        {
            InitializeComponent();
        }

        private void frmSelectConsultant_Load(object sender, EventArgs e)
        {
            List<ReportConsultant> ReportDoctors = new DoctorService().GetAllConsultants().ToList(); //new DoctorService().GetlAlReportDoctorOtherThanPathologyLegay().ToList();
            if (ReportDoctors != null)
            {
                ReportDoctors.Insert(0, new ReportConsultant()
                {
                    RCId = 0,
                    Name = "Select Consulatnt"
                });
            }

            cmbConsultant.DataSource = ReportDoctors;
            cmbConsultant.DisplayMember = "Name";
            cmbConsultant.ValueMember = "RCId";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbConsultant.SelectedValue)>0)
            {
                FromUXEReport _uxReport = new FromUXEReport((ReportConsultant)cmbConsultant.SelectedItem);
                _uxReport.Show();
             
            }

            new frmSelectConsultant().Hide();
        }
    }
}
