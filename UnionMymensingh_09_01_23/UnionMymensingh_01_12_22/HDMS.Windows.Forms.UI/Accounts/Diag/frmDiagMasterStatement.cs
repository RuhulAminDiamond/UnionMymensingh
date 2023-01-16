using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Diag
{
    public partial class frmDiagMasterStatement : Form
    {
        public frmDiagMasterStatement()
        {
            InitializeComponent();
        }

        private void frmDiagMasterStatement_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = Utils.GetServerDateAndTime();
            dtpto.Value = Utils.GetServerDateAndTime();
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {

            btnStatement.Text = "Plz. Wait..";
            btnStatement.Enabled = false;


            DataSet ds = new ReportService().GetDiagMasterStatement(dtpfrm.Value, dtpto.Value);

            rptDiagDetailsSaleStatement _pstatement = new rptDiagDetailsSaleStatement();

            _pstatement.SetDataSource(ds.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
          
            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            btnStatement.Text = "Show Statment";
            btnStatement.Enabled = true;

        }
    }
}
