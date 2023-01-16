using CrystalDecisions.Windows.Forms;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmPhDailySaleSummary : Form
    {
        public frmPhDailySaleSummary()
        {
            InitializeComponent();
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {

            cmdViewStatement.Text = "Plz. Wait..";
            cmdViewStatement.Enabled = false;

            DataSet ds = new PhProductService().GetPhCompanyWiseDailySaleSummary(dtpfrm.Value);

            //int c = dsReports.Tables[0].Rows.Count;

            rptPhDailySaleSummary rpt = new rptPhDailySaleSummary();

            rpt.SetDataSource(ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";

            rpt.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(customFmts));
            //_collecList.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));
            //_collecList.SetParameterValue("Collectionby", "");

            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            // rv.crviewer.PrintReport();
            rv.Show();

            cmdViewStatement.Text = "View Statement";
            cmdViewStatement.Enabled = true;
        }

        private void frmPhDailySaleSummary_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = Utils.GetServerDateAndTime();
        }
    }
}
