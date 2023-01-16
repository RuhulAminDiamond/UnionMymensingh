using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Service.Diagonstics;
using HDMS.Service.Doctors;
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
    public partial class frmConsultancy : Form
    {
        SqlDataAdapter da;
        public frmConsultancy()
        {
            InitializeComponent();
        }

        private async void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Enabled = false;
            cmdShow.Text = "Plz. Wait..";

            da = new SqlDataAdapter();
            DataSet dsConsultancy = await new ReportService().GetConsultancyStatement(Convert.ToInt32(cmbType.SelectedValue), dtpfrm.Value, dtpto.Value);
           
            //int c = dsReports.Tables[0].Rows.Count;

            RptConsultancy _consultancy = new RptConsultancy();

            _consultancy.SetDataSource(dsConsultancy.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _consultancy.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _consultancy.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";
          

            rv.crviewer.ReportSource = _consultancy;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;
            cmdShow.Text = "Show";
        }

        private void frmConsultancy_Load(object sender, EventArgs e)
        {
            List<ReportConsultant> ReportDoctors = new DoctorService().GetAllConsultants().ToList();
            ReportDoctors.Insert(0, new ReportConsultant() { RCId = 0, Name = "All" });
            cmbType.DataSource = ReportDoctors;
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "RCId";
        }

        private async void btnShowDetail_Click(object sender, EventArgs e)
        {
            btnShowDetail.Enabled = false;
            btnShowDetail.Text = "Plz. Wait..";

            da = new SqlDataAdapter();
            DataSet dsConsultancy = await new ReportService().GetDetailConsultancyStatement(Convert.ToInt32(cmbType.SelectedValue), dtpfrm.Value, dtpto.Value);

            //int c = dsReports.Tables[0].Rows.Count;

            RptConsultancyDetail _consultancy = new RptConsultancyDetail();

            _consultancy.SetDataSource(dsConsultancy.Tables[0]);



            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _consultancy.DataDefinition.FormulaFields[0].Text = "'" + dtpfrm.Value.ToString(customFmts) + "'";
            _consultancy.DataDefinition.FormulaFields[1].Text = "'" + dtpto.Value.ToString(customFmts) + "'";


            rv.crviewer.ReportSource = _consultancy;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            btnShowDetail.Enabled = true;
            btnShowDetail.Text = "Show";
        }
    }
}
