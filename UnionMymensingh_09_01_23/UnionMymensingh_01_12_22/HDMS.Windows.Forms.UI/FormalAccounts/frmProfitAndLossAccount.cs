using CrystalDecisions.Windows.Forms;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using Models.Accounting.VModel;
using POS;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmProfitAndLossAccount : Form
    {
        public frmProfitAndLossAccount()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            double _daysWithinDate = GetDaysWithinDate();

            DateTime _prevStartDate;
            DateTime _prevEndDate;

            int _statementType = 1; 

            

            if (radSummary.Checked)
            {
                rptProfitLossV2Summary _rpt = new rptProfitLossV2Summary();
                ReportViewer rv = new ReportViewer();

                DataSet ds = new AccountService().GetProfitAndLossSummary(dtpFromdate.Value, dtpTodate.Value, dtpprevFromdate.Value, dtpprevtodate.Value, _statementType);

                string _currentDateRange = dtpFromdate.Value.ToString("dd/MM/yyyy") + " To " + dtpTodate.Value.ToString("dd/MM/yyyy");
                string _prevDateRange = dtpprevFromdate.Value.ToString("dd/MM/yyyy") + " To " + dtpprevtodate.Value.ToString("dd/MM/yyyy");

                VMPLBalance _PLnetInc = new AccountService().GetPLNetInc();


                _rpt.SetDataSource(ds.Tables[0]);

                _rpt.SetParameterValue("datefrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
                _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString("dd/MM/yyyy"));
                _rpt.SetParameterValue("CurrentDateRange", _currentDateRange);
                _rpt.SetParameterValue("PrevDateRange", _prevDateRange);
                

                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
            else
            {

                rptProfitLossVer2Details _rpt = new rptProfitLossVer2Details();
                ReportViewer rv = new ReportViewer();

                DataSet ds = new AccountService().GetProfitAndLoss(dtpFromdate.Value, dtpTodate.Value, dtpprevFromdate.Value, dtpprevtodate.Value, _statementType);

                string _currentDateRange = dtpFromdate.Value.ToString("dd/MM/yyyy") + " To " + dtpTodate.Value.ToString("dd/MM/yyyy");
                string _prevDateRange = dtpprevFromdate.Value.ToString("dd/MM/yyyy") + " To " + dtpprevtodate.Value.ToString("dd/MM/yyyy");

                VMPLBalance _PLnetInc = new AccountService().GetPLNetInc();


                _rpt.SetDataSource(ds.Tables[0]);

                _rpt.SetParameterValue("datefrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
                _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString("dd/MM/yyyy"));
                _rpt.SetParameterValue("CurrentDateRange", _currentDateRange);
                _rpt.SetParameterValue("PrevDateRange", _prevDateRange);
                // _rpt.SetParameterValue("NetIncCurrent", _PLnetInc.NetIncCurrent);
                // _rpt.SetParameterValue("NetIncPrev", _PLnetInc.NetIncPrev);
                //if (_PLnetInc.NetIncCurrent > 0)
                //{
                //    _rpt.SetParameterValue("NetProfitLossLabel", "Net Income");

                //}else
                //{
                //    _rpt.SetParameterValue("NetProfitLossLabel", "Net Loss");
                //}


                rv.crviewer.ReportSource = _rpt;
                rv.crviewer.ToolPanelView = ToolPanelViewType.None;
                rv.crviewer.PrintReport();
                rv.Show();
            }
        }

        private double GetDaysWithinDate()
        {

            return 0;
        }

        private void frmProfitAndLossAccount_Load(object sender, EventArgs e)
        {
            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;

            dtpprevFromdate.Value = DateTime.Now;
            dtpprevtodate.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
