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
    public partial class frmAccCashBook : Form
    {
        public frmAccCashBook()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptAccCashBook _rpt = new rptAccCashBook();

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            string _customfrmt = "dd/MM/yyyy";

            DataSet ds = new AccountService().GetAccCashBook(dtpFromdate.Value, dtpTodate.Value);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString(_customfrmt));
            _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString(_customfrmt));
            _rpt.SetParameterValue("ReportTitle", "Cash Book");

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmAccCashBook_Load(object sender, EventArgs e)
        {
            dtpFromdate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
        }
    }
}
