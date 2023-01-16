using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Service.Hospital;
using HDMS.Common.Utils;
using HDMS.Common.Utils.ComapnyDetail;
using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using HDMS.Model.Hospital;

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class ctrlDischargedPatient : UserControl
    {
        public ctrlDischargedPatient()
        {
            InitializeComponent();
        }

        private void ctrlDischargedPatient_Load(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now;

            LoadPatients();
        }

        private void LoadPatients()
        {

            List<VMIPDInfo> _lisPatientInfo = new HospitalService().GetDischargedIPDInfo(dtp1.Value,dtp1.Value).ToList();

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
                row.CreateCells(dgPatient, item.BillNo, item.Name, item.DischargeDate.ToString("dd/MM/yyyy"));
                dgPatient.Rows.Add(row);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void dgPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPatient.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgPatient.SelectedRows[0];
                VMIPDInfo _pInfo = ((VMIPDInfo)row.Tag);

                btnPrintGatePass.Tag = _pInfo;

                lblName.Text = _pInfo.Name;
                lblCabin.Text = _pInfo.BedCabinNo;

              

            }

        }

        private void btnPrintGatePass_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnPrintGatePass.Tag);

            if (_pInfo != null)
            {
                ViewGatePass("Nursing Staff Copy");

                ViewGatePass("Security Staff Copy");
            }
        }
        private void ViewGatePass(string _copyfor)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnPrintGatePass.Tag);

            if (_pInfo != null)
            {

                HospitalBill _hBill = new HpFinancialService().GetHospitalBillByAdmissionId(_pInfo.AdmissionId);

                if (_hBill != null)
                {

                    List<HpPatientLedgerFinal> _pLedger = new HpFinancialService().GetPatientLedgerFinalById(_hBill.HospitalBillId);

                    double _serviceAmount = _pLedger.Sum(x => x.Debit);
                    double _paidAmount = _pLedger.Sum(x => x.Credit);

                    DataSet ds = new HpFinancialService().GetHpCashMemo(_hBill.HospitalBillId);

                     rptGatePass _rpt = new rptGatePass();

                    _rpt.SetDataSource(ds);


                    _rpt.SetParameterValue("CabinNo", lblCabin.Text);
                    _rpt.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
                    _rpt.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());

                


                    // Header and Footer Settings
                    _rpt.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
                    if (Configuration.ORG_CODE == "1")
                    {
                        _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                        _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_ContactNo + ", " + ComapnyDetail.EmailAddress);
                        _rpt.SetParameterValue("footnote", ComapnyDetail.footNote1);
                    }
                    else
                    {
                        _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                        _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                        _rpt.SetParameterValue("footnote", ComapnyDetail.footNote2);
                    }

                    _rpt.SetParameterValue("CopyFor", _copyfor);

                    if ((_serviceAmount - _paidAmount) <= 0)
                    {
                        _rpt.SetParameterValue("PayStatus", "PAID");
                    }
                    else
                    {
                        _rpt.SetParameterValue("PayStatus", "DUE");
                    }
                         

                    ReportViewer rv = new ReportViewer();
                    rv.crviewer.ReportSource = _rpt;
                    rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                    rv.crviewer.PrintReport();
                    rv.Show();
                }

            }
        }

        private void btnDischargeCertificate_Click(object sender, EventArgs e)
        {
            VMIPDInfo _pInfo = ((VMIPDInfo)btnPrintGatePass.Tag);
            ViewDischargeCertificate(_pInfo);
        }

        private void ViewDischargeCertificate(VMIPDInfo _pInfo)
        {
            HospitalBill _hBill = new HpFinancialService().GetHospitalBillByAdmissionId(_pInfo.AdmissionId);

            if (_hBill != null)
            {

                List<HpPatientLedgerFinal> _pLedger = new HpFinancialService().GetPatientLedgerFinalById(_hBill.HospitalBillId);

                double _serviceAmount = _pLedger.Sum(x => x.Debit);
                double _paidAmount = _pLedger.Sum(x => x.Credit);

                DataSet ds = new HpFinancialService().GetHpCashMemo(_hBill.HospitalBillId);

                rptDischargeCertificate _rpt = new rptDischargeCertificate();

                _rpt.SetDataSource(ds);

                _rpt.SetParameterValue("CabinNo", lblCabin.Text);
                _rpt.SetParameterValue("BillNoString", _pInfo.BillNo.ToString());
              //  _rpt.SetParameterValue("RegNoString", _pInfo.RegNo.ToString());




                // Header and Footer Settings
                _rpt.SetParameterValue("CompanyName", ComapnyDetail.CompanyName);
                if (Configuration.ORG_CODE == "1")
                {
                    _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress1);
                    _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress1_ContactNo + ", " + ComapnyDetail.EmailAddress);
                    _rpt.SetParameterValue("footnote", ComapnyDetail.footNote1);
                }
                else
                {
                    _rpt.SetParameterValue("Address", ComapnyDetail.BranchAddress2);
                    _rpt.SetParameterValue("ContactNo", ComapnyDetail.BranchAddress2_ContactNo + ", " + ComapnyDetail.EmailAddress);
                    _rpt.SetParameterValue("footnote", ComapnyDetail.footNote2);
                }

                ReportViewer rv = new ReportViewer();
                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }

        }
}
