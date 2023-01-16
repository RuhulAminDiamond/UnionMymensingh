using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Accounts;
using HDMS.Windows.Forms.UI.Reports.Accounts.Diag;
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
    public partial class frmRefundReport : Form
    {
        SqlDataAdapter da;
        public frmRefundReport()
        {
            InitializeComponent();
        }

        private void cmdRefundDateWise_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet dsRefund = new ReportService().GetRefundDateWise(dtpfrm.Value, dtpto.Value);
           
            //int c = dsReports.Tables[0].Rows.Count;

            RptRefundDateWise _refundList = new RptRefundDateWise();

            _refundList.SetDataSource(dsRefund.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _refundList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _refundList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            rv.crviewer.ReportSource = _refundList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void cmdRefundPatientWise_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            DataSet dsRefundPatientWise = new ReportService().GetRefundPatientWise(dtpfrm.Value, dtpto.Value);
            
            //int c = dsReports.Tables[0].Rows.Count;

            RptRefundPatientWise _refundList = new RptRefundPatientWise();

            _refundList.SetDataSource(dsRefundPatientWise.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _refundList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _refundList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            rv.crviewer.ReportSource = _refundList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        /*==================== Show Return All Data By Patients ======================= */

        private void btnDetails_Click(object sender, EventArgs e)
        {




            da = new SqlDataAdapter();
            DataSet dsRefundPatientWise = new ReportService().GetRefundPatientWiseData(dtpfrm.Value, dtpto.Value);

            //int c = dsReports.Tables[0].Rows.Count;

            rptPatientWiseTestRefund _refundList = new rptPatientWiseTestRefund();

            _refundList.SetDataSource(dsRefundPatientWise.Tables[0]);



            ReportViewer rv = new ReportViewer();
            //string customFmts = "dd/MM/yyyy";
            //_refundList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            //_refundList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            rv.crviewer.ReportSource = _refundList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

        }
    }
}
