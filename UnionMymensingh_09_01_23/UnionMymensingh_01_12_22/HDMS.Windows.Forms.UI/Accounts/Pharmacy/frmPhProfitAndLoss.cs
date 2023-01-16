using CrystalDecisions.Windows.Forms;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Accounts.Pharmacy
{
    public partial class frmPhProfitAndLoss : Form
    {
        public frmPhProfitAndLoss()
        {
            InitializeComponent();
        }

        private void frmPhProfitAndLoss_Load(object sender, EventArgs e)
        {
            dtpfrm.Value = Utils.GetServerDateAndTime();
            dtpto.Value = Utils.GetServerDateAndTime();
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {

            DataSet dsSales = new PhReportingService().GetPhProfitAndLoss(dtpfrm.Value, dtpto.Value);

            rptPhProfitAndLoss _phstatement = new rptPhProfitAndLoss();

            _phstatement.SetDataSource(dsSales.Tables[0]);


            ReportViewer rv = new ReportViewer();
            string customFmts = "dd/MM/yyyy";
            _phstatement.SetParameterValue("datefrm", dtpfrm.Value.ToString(customFmts));
            _phstatement.SetParameterValue("dateto", dtpto.Value.ToString(customFmts));
        
            rv.crviewer.ReportSource = _phstatement;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
