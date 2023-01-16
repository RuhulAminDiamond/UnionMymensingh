using CrystalDecisions.Windows.Forms;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Hospital
{
    public partial class frmHpSummaryStatement : Form
    {
        public frmHpSummaryStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new HpFinancialService().GetHpSummaryStatement(dtpfrm.Value,dtpto.Value);

            rptHPSummerySheet rpt = new rptHPSummerySheet();
            rpt.SetDataSource(ds.Tables[0]);

            rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString("dd/MM/yyyy"));
            rpt.SetParameterValue("dtto", dtpto.Value.ToString("dd/MM/yyyy"));
            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpfrm_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
