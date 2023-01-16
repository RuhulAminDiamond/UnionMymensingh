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
    public partial class frmConsultentAndSergeonTeamCharge : Form
    {
        public frmConsultentAndSergeonTeamCharge()
        {
            InitializeComponent();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            cmdShow.Enabled = false;

            DataSet ds= new HpFinancialService().GetConsultentAndSergeonTeamCharge(dtpfrm.Value, dtpto.Value);

            rptConsultentAndSergeonTeamCharge rpt = new rptConsultentAndSergeonTeamCharge();

            rpt.SetDataSource(ds.Tables[0]);

            rpt.SetParameterValue("dtpfrom", dtpfrm.Value);
            rpt.SetParameterValue("dtpto", dtpto.Value);
            rpt.SetParameterValue("printedby", MainForm.LoggedinUser.Name);

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();

            cmdShow.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultentAndSergeonTeamCharge_Load(object sender, EventArgs e)
        {

        }
    }
}
