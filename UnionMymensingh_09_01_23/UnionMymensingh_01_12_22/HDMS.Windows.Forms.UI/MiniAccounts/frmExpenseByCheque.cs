using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
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

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmExpenseByCheque : Form
    {

        SqlDataAdapter da;
        public frmExpenseByCheque()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet dsExpenseByCheck = new ReportService().GetExpenseByChecqueList(dtpfrm.Value, dtpto.Value);
           
            //int c = dsReports.Tables[0].Rows.Count;

            RptExpenseByCheck _expList = new RptExpenseByCheck();

            _expList.SetDataSource(dsExpenseByCheck.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _expList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _expList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            rv.crviewer.ReportSource = _expList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
