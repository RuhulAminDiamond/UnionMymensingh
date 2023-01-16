using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
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
    public partial class frmHPDueList : Form
    {
        public frmHPDueList()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            cmdShow.Text = "Please wait...";
            cmdShow.Enabled = false;

         
            DataSet ds = new ReportService().GetHpDueList(dtpfrm.Value, dtpto.Value);

            rptHPDueList _rpt = new rptHPDueList();
            //int c = dsReports.Tables[0].Rows.Count;
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            //  _rpt.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            //   _rpt.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            _rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString(customFmts));
            _rpt.SetParameterValue("dtto", dtpto.Value.ToString(customFmts));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Text = "Show";
            cmdShow.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
