using CrystalDecisions.Windows.Forms;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.FormalAccounts
{
    public partial class frmReceivePaymentStatement : Form
    {
        public frmReceivePaymentStatement()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptReceivePayment _rpt = new rptReceivePayment();

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;
            string customFmts = "dd/MM/yyyy";
          
            DataSet ds = new AccountService().GetReceivePaymentStatement(Fromdate, Todate, dtpprevFromdate.Value,dtpprevtodate.Value);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(customFmts));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
