using HDMS.Model;
using HDMS.Model.Common.VW;
using HDMS.Service.Doctors;
using HDMS.Service.Hospital;
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
            List<VWDoctor> _dList = new DoctorService().GetDoctorDetailList().ToList();
            FillListGrid(_dList);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

           

      
        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDoctor.Text) || txtDoctor.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadDoctorsDatabyName(txtDoctor.Text);
            }
        }

        private void LoadDoctorsDatabyName(string _name)
        {
            List<VWDoctor> _lisOfDoc = new HospitalService().GetDoctorListByName(_name).ToList();

            if (_lisOfDoc.Count() == 0) return;

            lblTotalDoc.Text = _lisOfDoc.Count().ToString();

            FillListGrid(_lisOfDoc);
        }

        private void FillListGrid(List<VWDoctor> _lisOfDoc)
        {
            dvList.SuspendLayout();
            dvList.Rows.Clear();
            foreach (VWDoctor item in _lisOfDoc)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dvList, item.DoctorId, item.Name, item.OPDConsultant, item.DeptName, item.ConsultantType, item.ConsultancyFee, item.CpPercent, item.HpPercent);
                dvList.Rows.Add(row);
            }
        }
    }
}
