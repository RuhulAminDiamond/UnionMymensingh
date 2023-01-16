using CrystalDecisions.Windows.Forms;
using HDMS.Service.ShareHolder;
using HDMS.Windows.Forms.UI.Reports.ShareHolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.MIS.ShareHolder
{
    public partial class frmFinalShareStatement : Form
    {
        public frmFinalShareStatement()
        {
            InitializeComponent();
        }

        private void btnShowStatement_Click(object sender, EventArgs e)
        {
            int _fiscalYear = 0;
            int.TryParse(cmbFiscalYear.Text, out _fiscalYear);
            
            int _status = 2;
            if (cmbReportType.Text == "Inactive") _status = 0;
            else if (cmbReportType.Text == "Active") _status = 1;
            
            DataSet ds = new ShareHolderService().GetFinalShareStatement(_fiscalYear, _status);

            rptFinalShare _rpt = new rptFinalShare();

            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("ReportTitle", "Final Share Statement (" + cmbReportType.Text + ") - " + _fiscalYear);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //  rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmFinalShareStatement_Load(object sender, EventArgs e)
        {
            List<int> yearList = new List<int>();

            //int yrIndex = -10;
            //for (int count=0; count<50; count++)
            //{
            //    yrIndex = count + yrIndex;
            //    int year = DateTime.Now.AddYears(yrIndex).Year;
            //    yearList.Add(year);
            //}

            for (int count = -10; count < 50; count++)
            {
                int year = DateTime.Now.AddYears(count).Year;
                yearList.Add(year);
                
            }

            cmbFiscalYear.DataSource = yearList;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
