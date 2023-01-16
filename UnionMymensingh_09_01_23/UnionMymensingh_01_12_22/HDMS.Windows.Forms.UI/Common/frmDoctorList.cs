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

namespace HDMS.Windows.Forms.UI.Common
{
    public partial class frmDoctorList : Form
    {
        public frmDoctorList()
        {
            InitializeComponent();
        }

        private void frmDoctorList_Load(object sender, EventArgs e)
        {
            List<Doctor> _dList = new DoctorService().GetAllDoctors().ToList();


            dvList.DataSource = _dList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
