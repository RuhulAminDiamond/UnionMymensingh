using CrystalDecisions.Windows.Forms;
using HDMS.Model.MiniAccount;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Accounts.MIS;
using HDMS.Windows.Forms.UI.Accounts.OPD;
using HDMS.Windows.Forms.UI.Diagonstics;
using HDMS.Windows.Forms.UI.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.MiniAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.MiniAccounts
{
    public partial class frmCashCollectionStatement : Form
    {
        public frmCashCollectionStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            string CheckPaymentState = string.Empty;

            DataTable table = new DataTable();


            DataSet ds = new ReportService().GetCashBookGroupByUser(dtpfrm.Value,dtpto.Value);

            CashBookDto _cashdto = new ReportService().GetCashBookSummary();


            rptCashBookGroupByUserCollection _rptCashBook = new rptCashBookGroupByUserCollection();

            _rptCashBook.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _rptCashBook.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _rptCashBook.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
            _rptCashBook.DataDefinition.FormulaFields[2].Text = "'" + _cashdto.CashBookTotal + "'";
            _rptCashBook.DataDefinition.FormulaFields[3].Text = "'" + _cashdto.CreditTotal + "'";
            _rptCashBook.DataDefinition.FormulaFields[4].Text = "'" + _cashdto.DebitTotal + "'";
           // _rptCashBook.DataDefinition.FormulaFields[5].Text = "'" + cmbUser.Text + "'";
            //_cashmemo.DataDefinition.FormulaFields[4].Text = txtDue.Text;
            rv.crviewer.ReportSource = _rptCashBook;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnHCS_Click(object sender, EventArgs e)
        {
            frmhpdialycollection frmar = new frmhpdialycollection();
            frmar.Show();
        }

        private void btnDPS_Click(object sender, EventArgs e)
        {
            frmDiagPatientStatement frmar = new frmDiagPatientStatement();
            frmar.Show();
        }

        private void btnPIS_Click(object sender, EventArgs e)
        {
            frmPhramacySaleStatement frmar = new frmPhramacySaleStatement();
            frmar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOPDIncomeStatement frmar = new frmOPDIncomeStatement();
            frmar.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlUserSearchControl_SearchEsacaped(bool IsEscaped)
        {

        }
    }
}
