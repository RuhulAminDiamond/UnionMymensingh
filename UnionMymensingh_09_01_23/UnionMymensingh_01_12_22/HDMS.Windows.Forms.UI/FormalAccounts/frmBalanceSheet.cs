using CrystalDecisions.Windows.Forms;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using Models.Accounting.VModel;
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
    public partial class frmBalanceSheet : Form
    {
        public frmBalanceSheet()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {


            int _statementType = 0;

            if (radDateails.Checked)
            {
                _statementType = 1;
            }

                rpt_Balance_Sheet _rpt = new rpt_Balance_Sheet();
                ReportViewer rv = new ReportViewer();

                DataSet ds = new AccountService().GetBalanceSheet(dtpFromdate.Value, dtpTodate.Value, dtpprevFromdate.Value, dtpprevtodate.Value, _statementType);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
