using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Service.Hospital;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmViewMedicineBill : Form
    {
        public frmViewMedicineBill()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgBill.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 12.5F, GraphicsUnit.Pixel);

            }

            dgBill.Font = new Font("Segoe UI", 12.5F, GraphicsUnit.Pixel);


        }

        private async void frmViewMedicineBill_Load(object sender, EventArgs e)
        {

            LoadDepartments();


           await   LoadMedicineBill();

          
        }

        private void LoadDepartments()
        {
            List<HpDepartment> _deptList = new HospitalCabinBedService().GetDeptList();
            _deptList.Insert(0, new HpDepartment() { DeptId = 0, Name = "Select Department" });


            cmbDept.DataSource = _deptList;
            cmbDept.DisplayMember = "Name";
            cmbDept.ValueMember = "DeptId";
        }

        private async Task<bool> LoadMedicineBill()
        {
            HpDepartment _dept = (HpDepartment)cmbDept.SelectedItem;

            List<VMIndoorMedicineBill> _mBillList = await new PhFinancialService().GetIndoorMedicineBillOfUndertreatedPatient(_dept.DeptId);
            dgBill.AutoGenerateColumns = false;
            dgBill.DataSource = _mBillList;

            lblTotalPatient.Text ="Total Patient: "+ _mBillList.Count().ToString();

            double _total = _mBillList.Sum(q => q.MedicineBill);

            lblTotalBill.Text = "Total Bill: "+_total.ToString();

            return await Task.FromResult(true);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgBill_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string _billNo = dgBill.Rows[e.RowIndex].Cells["BillNo"].Value.ToString();
            string _CabinNo= dgBill.Rows[e.RowIndex].Cells["CabinNo"].Value.ToString();

            btnPrintLedger.Tag = _billNo;

            long _billNum = 0;
            long.TryParse(_billNo, out _billNum);
            ViewMedicineDetail(_billNum, _CabinNo);
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            string _billNo = dgBill.SelectedRows[0].Cells["BillNo"].ToString();
            string _CabinNo = dgBill.SelectedRows[0].Cells["CabinNo"].ToString();
            long _billNum = 0;
            long.TryParse(_billNo, out _billNum);

            ViewMedicineDetail(_billNum, _CabinNo);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadMedicineBill();
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadMedicineBillBySearchPrefix(txtSearchByCabin.Text, "Cabin");
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadMedicineBillBySearchPrefix(txtSearchByName.Text, "Name");
            }
        }

        private void LoadMedicineBillBySearchPrefix(string strSearch,string _type)
        {
            List<VMIndoorMedicineBill> _mBillList = new PhFinancialService().GetIndoorMedicineBillOfUndertreatedPatientBySearchPrefix(strSearch, _type);
            dgBill.AutoGenerateColumns = false;
            dgBill.DataSource = _mBillList;

            lblTotalPatient.Text = "Total Patient: " + _mBillList.Count().ToString();

            double _total = _mBillList.Sum(q => q.MedicineBill);

            lblTotalBill.Text = "Total Bill: " + _total.ToString();

        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            ViewMedicineDetail(_billNo, "");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintLedger_Click(object sender, EventArgs e)
        {

            if (btnPrintLedger.Tag != null)
            {
                long _billNo = 0;
                long.TryParse(btnPrintLedger.Tag.ToString(), out _billNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_billNo);

                if (_pInfo != null)
                {

                    VMIPDInfo _ipdPatient = new HospitalService().GetIPDInfoById(_pInfo.AdmissionId);

                    DataSet _ds = new PhFinancialService().GetIndoorSaleLedger(_pInfo.AdmissionId);
                    IndoorPatientMedicineLadger _rpt = new IndoorPatientMedicineLadger();

                    _rpt.SetDataSource(_ds.Tables[0]);

                    ReportViewer rv = new ReportViewer();
                    string customFmts = "dd/MM/yyyy";
                    _rpt.SetParameterValue("BillNo", _pInfo.BillNo.ToString());
                    _rpt.SetParameterValue("Name", _ipdPatient.Name);
                    _rpt.SetParameterValue("Addate", _pInfo.AddmissionDate.ToString(customFmts));


                    rv.crviewer.ReportSource = _rpt;
                    rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }

            }
            else
            {
                return;
            }

         

           
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicineBill();
        }
    }
}
