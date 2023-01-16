using CrystalDecisions.Windows.Forms;
using HDMS.Model.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.Audit;
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
    public partial class frmAuditStockReport : Form
    {
        public frmAuditStockReport()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            PhStockAuditMaster _asm = (PhStockAuditMaster)cmbAuditList.SelectedItem;

            DataSet ds = new PhProductService().GetAuditedStockData(_asm.AMId);

            rptAuditedStockReport _rpt = new rptAuditedStockReport();
            _rpt.SetDataSource(ds.Tables[0]);

            ReportViewer _rv = new ReportViewer();
            _rv.crviewer.ReportSource = _rpt;
            _rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            _rv.crviewer.PrintReport();
            _rv.Show();
        }

        private void frmAuditStockReport_Load(object sender, EventArgs e)
        {
            List<PhStockAuditMaster> _auditMaster = new PhProductService().GetPhStockAuditMasters();
            _auditMaster.Insert(0, new PhStockAuditMaster() { AMId = 0, AMonth = "Select Audit" });

            cmbAuditList.DataSource = _auditMaster;
            cmbAuditList.DisplayMember = "AMonth";
            cmbAuditList.ValueMember = "AMId";

        }
    }
}
