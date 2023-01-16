using CrystalDecisions.Windows.Forms;
using HDMS.Model.ViewModel;
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

namespace HDMS.Windows.Forms.UI.Accounts
{
    public partial class frmSummarySheet : Form
    {
        SqlDataAdapter da;
        public frmSummarySheet()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Text = "Please wait...";
            cmdShow.Enabled = false;

            DataSet dsSummarySheet = new ReportService().GetSummarySheetData(dtpfrm.Value, dtpto.Value);
           
            //int c = dsReports.Tables[0].Rows.Count;

            rptSummarySheet _pstatement = new rptSummarySheet();

            _pstatement.SetDataSource(dsSummarySheet.Tables[0]);

            VWSummarySheetSumAndBalance _ssb = new ReportService().GetSummarySheetSumAndBalance();

            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + _ssb.Debit.ToString() + "'";
            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + _ssb.Credit.ToString() + "'";
            _pstatement.DataDefinition.FormulaFields[4].Text = "'" + _ssb.Balance.ToString() + "'";
            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Text = "Show";
            cmdShow.Enabled = true;
        }
    }
}
