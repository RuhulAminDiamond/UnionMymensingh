 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Hospital;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Accounting;

namespace HDMS.Windows.Forms.UI.FormalAccounts
{
    public partial class frmConsultancyStatement : Form
    {
        public frmConsultancyStatement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new HpFinancialService().GetConsultancyStatement(dtpFrom.Value, dtpTo.Value);

            rptConsultancyStatement rpt = new rptConsultancyStatement();
            string header = "Consultancy Statement (" + dtpFrom.Value.Date.ToString("dd/MM/yyyy") + " - " + dtpTo.Value.Date.ToString("dd/MM/yyyy") + ")";
            rpt.SetDataSource(ds.Tables[0]);
            rpt.SetParameterValue("header", header);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnFixLedger_Click(object sender, EventArgs e)
        {
            List<HpConsultantLedger> _ledgerList = new HpFinancialService().GetAllConsultantLedger();

            foreach (var _ledger in _ledgerList)
            {
                string[] larr = _ledger.Particulars.Split(',');
                string[] larr2 = larr[0].Split(':');
                long billNo = 0;
                long.TryParse(larr2[1].Trim(), out billNo);

                HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(billNo);

                if (_pInfo == null)
                {
                    _pInfo = new HospitalService().GetHospitalPatientByBillNoAny(billNo);
                }

                if (_pInfo != null)
                {

                    _ledger.PatientAdmissionId = _pInfo.AdmissionId;

                    new HpFinancialService().UpdateConsultantLedger(_ledger);
                }

            }
            MessageBox.Show("Fixed successfully!");
        }
    }
}
