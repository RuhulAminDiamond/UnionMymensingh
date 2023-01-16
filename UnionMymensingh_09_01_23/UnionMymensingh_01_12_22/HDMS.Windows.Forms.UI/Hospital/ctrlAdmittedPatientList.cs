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
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using HDMS.Service.Pharmacy;
using HDMS.Repository.ServiceObjects;
using HDMS.Model.Users;
using HDMS.Service;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlAdmittedPatientList : UserControl
    {
        bool isLoaded = false;

        public ctrlAdmittedPatientList()
        {
            InitializeComponent();
        }

        private void ctrlAdmittedPatientList_Load(object sender, EventArgs e)
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

            LoadPatientList();
        }


        private void LoadPatientList()
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoByDept(Convert.ToInt32(cmbDept.SelectedValue)).ToList();

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);

        }

        private void FillListGrid(List<VMIPDInfo> _lisPatientInfo)
        {
            dgPatient.SuspendLayout();
            dgPatient.Rows.Clear();
            foreach (VMIPDInfo item in _lisPatientInfo)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 35;
                row.CreateCells(dgPatient, item.AdmissionId, item.AddmissionDate.ToString("dd/MM/yyyy"), item.AdmTime, item.Name, item.BedCabinNo, item.AssignedDoctor, item.MobileNo, item.CPAddress, item.Status);
                dgPatient.Rows.Add(row);
            }

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

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoByFloor(Convert.ToInt32(cmbDept.SelectedValue)).ToList();

                lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

                FillListGrid(_lisPatientInfo);
            }
        }

        private void txtAdmId_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "By Adm. Id")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
        }

        private void LoadPatientsDatabyName(string _prefix, string type)
        {
            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetCurrentIPDInfoBySearchParameter(_prefix, type).ToList();

            if (_lisPatientInfo.Count() == 0) return;

            lblTotalPatient.Text = _lisPatientInfo.Count().ToString();

            FillListGrid(_lisPatientInfo);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtAdmId.Text.Trim() == "Search by name")
            {
                //LoadPatientsDatabyName("", "PName");
            }
            else
            {

                LoadPatientsDatabyName(txtName.Text, "PName");
            }
        }

        private void txtSearchByAssignDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAssignDoc.Text.Trim() == "Search by Assign Doc")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByAssignDoc.Text, "assigndoc");
            }
        }

        private void txtSearchByMobile_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByMobile.Text.Trim() == "Search by Mobile No")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByMobile.Text, "MobileNo");
            }
        }

        private void txtSearchByAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByAddress.Text.Trim() == "Search by Address")
            {
                // LoadPatientsDatabyName(txtAdmId.Text, "admid");
            }
            else
            {

                LoadPatientsDatabyName(txtSearchByAddress.Text, "Address");
            }
        }

        private void pnlPatient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgPatient.SelectedRows[0];

            btnInvestigationdetails.Tag = row.Cells[0].Value;

            btnMedicidetails.Tag = row.Cells[0].Value;

            btnConsultancyDetails.Tag = row.Cells[0].Value;

            btnInvestigationdetails.BackColor = Color.Green;
            btnInvestigationdetails.ForeColor = Color.White;


            btnMedicidetails.BackColor = Color.Green;
            btnMedicidetails.ForeColor = Color.White;


            btnConsultancyDetails.BackColor = Color.Green;
            btnConsultancyDetails.ForeColor = Color.White;
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
