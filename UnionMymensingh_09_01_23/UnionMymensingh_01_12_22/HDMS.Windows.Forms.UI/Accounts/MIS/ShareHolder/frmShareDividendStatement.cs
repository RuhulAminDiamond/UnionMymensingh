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
    public partial class frmShareDividendStatement : Form
    {
        public frmShareDividendStatement()
        {
            InitializeComponent();
        }

        private void btnShowStatement_Click(object sender, EventArgs e)
        {
            int _fiscalYear = 0;
            int.TryParse(cmbFiscalYear.Text, out _fiscalYear);

            DataSet ds = new ShareHolderService().GetShareDividendStatement(_fiscalYear);

            rptShareDividend _rpt = new rptShareDividend();

            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("ReportTitle", "Share Dividend - " + _fiscalYear);

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            //  rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmShareDividendStatement_Load(object sender, EventArgs e)
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
    }
}
