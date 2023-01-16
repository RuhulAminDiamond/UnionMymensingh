using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Canteen;
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

namespace POS.Forms.ReportForm
{
    public partial class frmCantDueList : Form
    {
        public frmCantDueList()
        {
            InitializeComponent();
        }

        private void frmDueList_Load(object sender, EventArgs e)
        {
            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
           

            ReportViewer rv = new ReportViewer();
            rptCantDueList _rpt = new rptCantDueList();


            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            DataSet ds = new ReportingService().GetDueList(Fromdate, Todate);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", Todate.ToString("dd/MM/yyyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
