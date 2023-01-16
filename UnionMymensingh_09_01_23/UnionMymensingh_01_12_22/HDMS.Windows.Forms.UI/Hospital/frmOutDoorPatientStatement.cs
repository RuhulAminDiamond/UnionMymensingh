using CrystalDecisions.Windows.Forms;
using HDMS.Service.Diagonstics;
using HDMS.Service.Hospital;
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
    public partial class frmOutDoorPatientStatement : Form
    {
        SqlDataAdapter da;
        public frmOutDoorPatientStatement()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter();
            da = new HospitalReportService().GetOutDoorPatients(dtpfrm.Value, dtpto.Value,cmbServiceFor.Text);
            DataSet dsReports = new DataSet();
            da.Fill(dsReports, "dtOutDoorPatientStatement");
            int c = dsReports.Tables[0].Rows.Count;

            RptOutDoorPatient _pstatement = new RptOutDoorPatient();

            _pstatement.SetDataSource(dsReports.Tables[0]);
            ReportViewer rv = new ReportViewer();
            string customFmts = "d MMM yyyy";
            _pstatement.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
            _pstatement.DataDefinition.FormulaFields[2].Text = "'" + cmbServiceFor.Text + "'";
            _pstatement.DataDefinition.FormulaFields[3].Text = "'" + new OutDoorPatientService().GetTotalPatient(dtpfrm.Value, dtpto.Value, cmbServiceFor.Text).ToString() + "'";
            //_cashmemo.DataDefinition.FormulaFields[4].Text = txtDue.Text;
            rv.crviewer.ReportSource = _pstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

       
        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
