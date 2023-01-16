using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Service.Diagonstics;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Diagnostic.IPD;
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
    public partial class frmIPDInvestigations : Form
    {
        public frmIPDInvestigations()
        {
            InitializeComponent();
        }

        private void frmIPDInvestigations_Load(object sender, EventArgs e)
        {
            if (radCurrent.Checked)
            {
                LoadInvestigationBill();
            }
        }

     

        private void LoadInvestigationBill()
        {
            List<VWIndoorInvestigationBill> _iBillList = new DiagFinancialService().GetIndoorInvestigationBillOfUndertreatedPatient();
            dgBill.AutoGenerateColumns = false;
            dgBill.DataSource = _iBillList;

            lblTotalPatient.Text = "Total Patient: " + _iBillList.Count().ToString();

            double _total = _iBillList.Sum(q => q.InvestigationBill);

            lblTotalBill.Text = "Total Bill: " + _total.ToString();

        }

        private void dgBill_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string _billNo = dgBill.Rows[e.RowIndex].Cells["BillNo"].Value.ToString();
            string _CabinNo = dgBill.Rows[e.RowIndex].Cells["CabinNo"].Value.ToString();
            long _billNum = 0;
            long.TryParse(_billNo, out _billNum);
            ViewInvestigationDetail(_billNum, _CabinNo);
        }

        private void ViewInvestigationDetail(long _billNum, string _CabinNo)
        {
            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(_billNum);

            if (_pInfo == null)
            {
                MessageBox.Show("Invalid Bill No. Plz. verify and try again.");
                return;
            }

            DataSet ds = new DiagFinancialService().GetInvestigationDetailsByPatientId(_pInfo.AdmissionId);


            rptIPDInvestigationList _invDetail = new rptIPDInvestigationList();
            _invDetail.SetDataSource(ds.Tables[0]);


            ReportViewer rv = new ReportViewer();

            _invDetail.SetParameterValue("CabinNo", _CabinNo);

            rv.crviewer.ReportSource = _invDetail;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadInvestigationBill();
        }

        private void radCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (radCurrent.Checked)
            {
                LoadInvestigationBill();
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtBillNo.Text, out _billNo);

            ViewInvestigationDetail(_billNo, "");
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadInvestigationBillBySearchPrefix(txtSearchByName.Text, "Name");
            }
        }

        private void txtSearchByCabin_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByCabin.Text.Trim() == "Search by cabin")
            {
                // LoadPatientsDatabyName(txtCabin.Text, "cabin");
            }
            else
            {

                LoadInvestigationBillBySearchPrefix(txtSearchByCabin.Text, "Cabin");
            }
        }

        private void LoadInvestigationBillBySearchPrefix(string strSearch, string _type)
        {
            List<VWIndoorInvestigationBill> _mBillList = new DiagFinancialService().GetIndoorInvestigationBillOfUndertreatedPatientBySearchPrefix(strSearch, _type);
            dgBill.AutoGenerateColumns = false;
            dgBill.DataSource = _mBillList;

            lblTotalPatient.Text = "Total Patient: " + _mBillList.Count().ToString();

            double _total = _mBillList.Sum(q => q.InvestigationBill);

            lblTotalBill.Text = "Total Bill: " + _total.ToString();
        }
    }
}
