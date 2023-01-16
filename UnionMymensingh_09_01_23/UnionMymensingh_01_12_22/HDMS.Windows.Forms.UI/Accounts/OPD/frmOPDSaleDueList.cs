using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Accounts.OPD;
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

namespace HDMS.Windows.Forms.UI.Accounts.OPD
{
    public partial class frmOPDSaleDueList : Form
    {
        public frmOPDSaleDueList()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptOPDSaleDueList _rpt = new rptOPDSaleDueList();


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            DataSet ds = new ReportingService().GetOPDSaleDueList(Fromdate, Todate);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString("dd/MM/yyyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
