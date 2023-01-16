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
using HDMS.Windows.Forms.UI.Reports.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class AccReportCashBook : Form
    {
        public AccReportCashBook()
        {
            InitializeComponent();
        }

        private void ReportSupplierLedger_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Cash_Book _rpt = new rptACC_Cash_Book();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);
            _rpt.SetDatabaseLogon("emsl", "emsl@2018", "SERVER", "EMDIAG", true);


            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            string strStart = Convert.ToDateTime(dtpFromdate.Value.ToString()).ToShortDateString();
            string strEnd = Convert.ToDateTime(dtpTodate.Value.ToString()).ToShortDateString();
           

            _rpt.SetParameterValue("@StartDate", strStart);
            _rpt.SetParameterValue("@EndDate", strEnd);
            


            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
