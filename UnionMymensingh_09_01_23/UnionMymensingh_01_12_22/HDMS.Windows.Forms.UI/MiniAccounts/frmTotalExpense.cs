using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDMS.Service.MiniAccounts;
using HDMS.Windows.Forms.UI.Reports.MiniAccounts;

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmTotalExpense : Form
    {

        SqlDataAdapter da;
        public frmTotalExpense()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            int _mode = 0;
            da = new SqlDataAdapter();

            if (radValued.Checked) _mode = 1;

            DataSet _ds = new MiniAccountService().GetTotalExpense(dtpfrm.Value, dtpto.Value, _mode);
            rptTotalExpense _expList = new rptTotalExpense();

            _expList.SetDataSource(_ds.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _expList.SetParameterValue("dtpfrm", dtpfrm.Value.ToString(customFmts));
            _expList.SetParameterValue("dtpto", dtpto.Value.ToString(customFmts));

           
            rv.crviewer.ReportSource = _expList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
