using CrystalDecisions.Windows.Forms;
using HDMS.Service.Hospital;
using HDMS.Windows.Forms.UI.Reports.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Hospital
{
    public partial class frmAdmittedPatientList : Form
    {
        public frmAdmittedPatientList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new HpFinancialService().GetHpAdmittedAllPatientList(dtpfrm.Value, dtpto.Value);

            rptAdmittedPatientListDateWise rpt = new rptAdmittedPatientListDateWise();
            rpt.SetDataSource(ds.Tables[0]);

            rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString("dd/MM/yyyy"));
            rpt.SetParameterValue("dtto", dtpto.Value.ToString("dd/MM/yyyy"));
            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void frmAdmittedPatientList_Load(object sender, EventArgs e)
        {

        }

        private void btnOPDPatient_Click(object sender, EventArgs e)
        {
            DataSet ds = new HpFinancialService().GetHpAdmittedOPDPatientList(dtpfrm.Value, dtpto.Value);

            rptAdmittedPatientListDateWise rpt = new rptAdmittedPatientListDateWise();
            rpt.SetDataSource(ds.Tables[0]);

            rpt.SetParameterValue("dtfrm", dtpfrm.Value.ToString("dd/MM/yyyy"));
            rpt.SetParameterValue("dtto", dtpto.Value.ToString("dd/MM/yyyy"));
            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
