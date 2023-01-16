using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.DataSets;
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
    public partial class frmDepriciationList : Form
    {
        SqlDataAdapter da;
        public frmDepriciationList()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            da = new ReportService().GetIrregularPaymentList();
            DataSet dsDepriciation = new dsDepriciation();
            da.Fill(dsDepriciation, "dtDepriciation");
            //int c = dsReports.Tables[0].Rows.Count;

            RptDepriciation _depList = new RptDepriciation();

            _depList.SetDataSource(dsDepriciation.Tables[0]);



            ReportViewer rv = new ReportViewer();
            //string customFmts = "dd/MM/yyyy";
            //_irpList.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            //_irpList.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";

            rv.crviewer.ReportSource = _depList;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
