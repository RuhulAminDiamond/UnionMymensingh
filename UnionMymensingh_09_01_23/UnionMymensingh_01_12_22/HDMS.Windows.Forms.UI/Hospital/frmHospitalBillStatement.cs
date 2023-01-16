using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Windows.Forms.UI.Reports.Hospital;
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

namespace HDMS.Windows.Forms.UI.Hospital
{
    public partial class frmHospitalBillStatement : Form
    {

        SqlDataAdapter da;
        public frmHospitalBillStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            da = new ReportService().GetIndoorPatientBillStatement(dtpfrm.Value, dtpto.Value);
            DataSet dsReports = new DataSet();
            da.Fill(dsReports, "dtHospitalStatement");
            int c = dsReports.Tables[0].Rows.Count;

            RptHospitalBillStatement _hbtatement = new RptHospitalBillStatement();

            _hbtatement.SetDataSource(dsReports.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "d MMM yyyy";
            _hbtatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _hbtatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
           
           
            //_cashmemo.DataDefinition.FormulaFields[4].Text = txtDue.Text;
            rv.crviewer.ReportSource = _hbtatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
