using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Canteen;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
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
    public partial class frmPhDueList : Form
    {
        public frmPhDueList()
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
            rptPhOPDDueList _rpt = new rptPhOPDDueList();


            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            DataSet ds = new ReportingService().GetPhOPDDueList(Fromdate, Todate);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString("dd/MM/yyyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
