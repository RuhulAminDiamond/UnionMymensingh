using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmDailyStatement : Form
    {
        public frmDailyStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Enabled = false;
            cmdShow.Text = "Please wait..";
            ReportViewer rv = new ReportViewer();
            rptDailyStatement _rpt = new rptDailyStatement();
            _rpt.SetDatabaseLogon("Syscom", "fm#s21928", "Server", "Diag", true);


            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;


            _rpt.SetParameterValue("@startpDate", Fromdate.ToShortDateString());
            _rpt.SetParameterValue("@enddate", Todate.ToShortDateString());

            string customFmts = "dd/MM/yyyy";
            _rpt.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _rpt.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            //Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            //_rpt.SetParameterValue("companyName", _company.Name);
            //_rpt.SetParameterValue("companyAddress", _company.Address);
            //_rpt.SetParameterValue("companyPhoneNo", _company.PhoneNo);

          

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";
        }
    }
}
