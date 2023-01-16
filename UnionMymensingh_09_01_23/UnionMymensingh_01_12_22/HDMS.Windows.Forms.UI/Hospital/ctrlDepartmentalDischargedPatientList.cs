using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Model;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Repository.ServiceObjects;
using HDMS.Service;
using HDMS.Model.Users;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDepartmentalDischargedPatientList : UserControl
    {
        bool isLoaded = false;

        public ctrlDepartmentalDischargedPatientList()
        {
            InitializeComponent();
        }

        private void ctrlDepartmentalDischargedPatientList_Load(object sender, EventArgs e)
        {
            

            LoginUser _user = MainForm.LoggedinUser;

            User _userd = new UserService().GetUserById(_user.UserId);

            if (_userd.RoleId == 39)
            {
                LoadDepartments(_userd.DeptId);
            }
            else
            {
                LoadDepartments(0);
            }


            LoadDischargedPatients();


            

        }

       

        private void LoadDischargedPatients()
        {
            string _deptName = string.Empty;

            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;


            if (_dept.DeptId == 0)
            {
                _deptName = "All";
            }
            else
            {
                _deptName = _dept.Name;
            }

               DataSet dsReports = new HpFinancialService().GetDischargedPatient(dtpfrm.Value, dtpto.Value, _dept.DeptId);

             dgPatient.AutoGenerateColumns = true;
             dgPatient.DataSource = dsReports.Tables[0];

            lblTotalPatient.Text = dsReports.Tables[0].Rows.Count.ToString();

            // dataset
            //  dgPatient.DataBind(); // table nam

        }

        private void LoadDepartments(int _deptId)
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";

            if (_deptId > 0)
            {
                cmbDept.SelectedItem = _deptList.Find(q => q.DeptId == _deptId);
                cmbDept.Enabled = false;
            }
            else
            {
                cmbDept.Enabled = true;
            }


            isLoaded = true;
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            LoadDischargedPatients();
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgPatient.SelectedRows[0];

            btnInvestigationdetails.Tag = row.Cells[0].Value;

            btnMedicidetails.Tag= row.Cells[0].Value;

            btnConsultancyDetails.Tag= row.Cells[0].Value;

            btnInvestigationdetails.BackColor = Color.Green;
            btnInvestigationdetails.ForeColor = Color.White;


            btnMedicidetails.BackColor = Color.Green;
            btnMedicidetails.ForeColor = Color.White;


            btnConsultancyDetails.BackColor = Color.Green;
            btnConsultancyDetails.ForeColor = Color.White;

        }

        private void btnMedicidetails_Click(object sender, EventArgs e)
        {
            if (btnMedicidetails.Tag != null)
            {
                long _billNo = 0;
                long.TryParse(btnMedicidetails.Tag.ToString(), out _billNo);

                ViewMedicineDetail(_billNo, "");
            }
        }

        private void ViewMedicineDetail(long _billNum, string _Cabin)
        {

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new PhReportingService().GetMedicineDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDPatientMedicineDetail _medicineDetail = new rptIPDPatientMedicineDetail();
            _medicineDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _medicineDetail.SetParameterValue("CabinNo", _Cabin);

            rv.crviewer.ReportSource = _medicineDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnInvestigationdetails_Click(object sender, EventArgs e)
        {
            if (btnInvestigationdetails.Tag != null)
            {
                long _billNo = 0;
                long.TryParse(btnInvestigationdetails.Tag.ToString(), out _billNo);


                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNo);



                if (_pInfo == null)
                {
                    MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                    return;
                }

                DataSet ds = new DiagFinancialService().GetInvestigationDetailsByPatientId(_pInfo.AdmissionId);


                rptIPDInvestigationList _invDetail = new rptIPDInvestigationList();
                _invDetail.SetDataSource(ds.Tables[0]);


                ReportViewer rv = new ReportViewer();

                _invDetail.SetParameterValue("CabinNo", "");

                rv.crviewer.ReportSource = _invDetail;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }

        private void btnConsultancyDetails_Click(object sender, EventArgs e)
        {
            if (btnConsultancyDetails.Tag != null)
            {
                long _billNo = 0;
                long.TryParse(btnConsultancyDetails.Tag.ToString(), out _billNo);

                ViewConsultancyList(_billNo, "");
            }
        }

        private void ViewConsultancyList(long billNo, string CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new HpFinancialService().GetConsultancyDetailsByPatientId(_pInfo.AdmissionId);


            rptConsultancyByPatient _rpt = new rptConsultancyByPatient();
            _rpt.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            // _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

    }
}
