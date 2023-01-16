using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
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
    public partial class frmDiagDeailySummary : Form
    {
        public frmDiagDeailySummary()
        {
            InitializeComponent();
        }

        private void btnShowStatement_Click(object sender, EventArgs e)
        {
            DataSet ds = new ReportService().GetAllDiagDeailySaleSummary(dtpFrom.Value, dtpTo.Value);

            rptDiagDeailySummary rpt = new rptDiagDeailySummary();

            rpt.SetDataSource(ds.Tables[0]);
            rpt.SetParameterValue("From", dtpFrom.Value);
            rpt.SetParameterValue("To", dtpTo.Value);
            

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }
    }
}
