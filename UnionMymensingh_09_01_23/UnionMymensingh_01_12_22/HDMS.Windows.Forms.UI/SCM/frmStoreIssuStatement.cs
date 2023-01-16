using CrystalDecisions.Windows.Forms;
using HDMS.Model.Store;
using HDMS.Windows.Forms.UI.Reports.SCM;
using Services.POS;
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Store
{
    public partial class frmStoreIssuStatement : Form
    {
        public frmStoreIssuStatement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStoreIssuStatement_Load(object sender, EventArgs e)
        {
            List<StoreDept> _sm = new StoreItemService().GetStoreDepartment();
            _sm.Insert(0, new StoreDept() { DeptId = 0, Name = "Select Parent" });
            cmbDepartment.DataSource = _sm;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptStoreIssuStatement _rpt = new rptStoreIssuStatement();

            StoreDept dept = cmbDepartment.SelectedItem as StoreDept;

            DataSet ds = new ReportingService().GetStoreIssueStatement(dtpFromdate.Value, dtpTodate.Value,dept.DeptId);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("dtfrm", dtpFromdate.Value.ToString("dd/MM/yyyy"));
            _rpt.SetParameterValue("dtto", dtpTodate.Value.ToString("dd/MM/yyyy"));
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();


        }
    }
}
