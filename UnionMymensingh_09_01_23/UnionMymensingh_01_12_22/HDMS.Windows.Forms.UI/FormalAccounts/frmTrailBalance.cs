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

using HDMS.Service.Accounting;
using Models.Accounting;
using POS;

using HDMS.Windows.Forms.UI.Reports.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmTrailBalance : Form
    {
        public frmTrailBalance()
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
            rptACC_Trial_Balance _rpt = new rptACC_Trial_Balance();
          
            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            int IswithOpening = 0; // 0 for with opening 1 for without opening

            if (radWithoutOpening.Checked)
            {
                IswithOpening = 1;
            }

            string _customfrmt = "dd/MM/yyyy";

            DataSet ds = new AccountService().GetTrialBalance(dtpFromdate.Value, dtpTodate.Value, IswithOpening);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("ReportTitle", "Trial Balance");
            _rpt.SetParameterValue("datefrm", dtpFromdate.Value.ToString(_customfrmt));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(_customfrmt));
            
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowTrialSummary_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Trial_Balance _rpt = new rptACC_Trial_Balance();

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            int IswithOpening = 0; // 0 for with opening 1 for without opening

            if (radWithoutOpening.Checked)
            {
                IswithOpening = 1;
            }

            string _customfrmt = "dd/MM/yyyy";

            DataSet ds = new AccountService().GetTrialBalanceBasedOnSummaryHead(dtpFromdate.Value, dtpTodate.Value, IswithOpening);
            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("ReportTitle", "Trial Balance (Summary)");
            _rpt.SetParameterValue("datefrm", dtpFromdate.Value.ToString(_customfrmt));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(_customfrmt));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
