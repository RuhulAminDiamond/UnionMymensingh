using CrystalDecisions.Windows.Forms;
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

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmPharmacyDailyTransectionReports : Form
    {
        public frmPharmacyDailyTransectionReports()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

           // MessageBox.Show("we are working now ");

          //  return;

            DataSet ds = new ReportingService().GetPharmacyDailyTransectionReport(dtpFrom.Value, dtpTo.Value);

            ReportViewer rv = new ReportViewer();
            rptPharmacyDailyTransectionReports _rpt = new rptPharmacyDailyTransectionReports();


            DateTime Fromdate = dtpFrom.Value;
            DateTime Todate = dtpTo.Value;

          
            _rpt.SetDataSource(ds.Tables[0]);

            //_rpt.SetParameterValue("datefrm", Fromdate.ToString("dd/MM/yyy"));
            //_rpt.SetParameterValue("dateto", Todate.ToString("dd/MM/yyy"));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
