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

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmReagentManagement : Form
    {
        public frmReagentManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new ReportService().GetDiagReagentUse(dtpfrm.Value, dtpto.Value);

            ReportViewer rv = new ReportViewer();
            rptReagentManagment _rpt = new rptReagentManagment();

            _rpt.SetDataSource(ds.Tables[0]);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;

            string customFmts = "dd/MM/yyyy";
            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
