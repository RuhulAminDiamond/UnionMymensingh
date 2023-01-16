using CrystalDecisions.Windows.Forms;
using Models;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using HDMS.Windows.Forms.UI;
using POS;

using HDMS.Windows.Forms.UI.Reports.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class AccReportVoucherReport : Form
    {
        public AccReportVoucherReport()
        {
            InitializeComponent();
        }

        private void ReportSupplierLedger_Load(object sender, EventArgs e)
        {

            dtpFromdate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
            dtpTodate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Voucher_Report _rpt = new rptACC_Voucher_Report();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);
            _rpt.SetDatabaseLogon("emsl", "emsl@2018", "SERVER", "EMDIAG", true);

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            string strStart = Convert.ToDateTime(dtpFromdate.Value.ToString()).ToShortDateString();
            string strEnd   = Convert.ToDateTime(dtpTodate.Value.ToString()).ToShortDateString();

            int VoucherID = 0;
            if (txtVoucherID.Text != "")
                VoucherID = Convert.ToInt32(txtVoucherID.Text);

            _rpt.SetParameterValue("@StartDate", strStart);
            _rpt.SetParameterValue("@EndDate", strEnd);
            _rpt.SetParameterValue("@VoucherID", VoucherID.ToString());
            _rpt.SetParameterValue("@VoucherType", ddlVoucherType.SelectedText.ToString());









            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
