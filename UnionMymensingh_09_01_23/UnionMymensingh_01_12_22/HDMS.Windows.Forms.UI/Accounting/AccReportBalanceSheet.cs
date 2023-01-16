using CrystalDecisions.Windows.Forms;
using Models;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using HDMS.Service.Accounting;
using Models.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class AccReportBalanceSheet : Form
    {
        public AccReportBalanceSheet()
        {
            InitializeComponent();
        }

        private void ReportSupplierLedger_Load(object sender, EventArgs e)
        {
            ddlAccountHead.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsPostingHead == 1).ToList();
            ddlAccountHead.DisplayMember = "AccountHeadName";
            ddlAccountHead.ValueMember = "AccId";


            dtpFromdate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
            dtpTodate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
            FillAccountTree();
        }

        private void FillAccountTree()
        {
            TVAccountList.Nodes.Clear();
            List<AccountHead> AccountHeadList = new AccountService().GetAllBaseHead().ToList();

            foreach (AccountHead accountHead in AccountHeadList)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = accountHead.AccountHeadName;
                treeNode.Tag = accountHead.AccId;

                TVAccountList.Nodes.Add(treeNode);
                FillChild(treeNode, accountHead.AccId);

            }
        }

        private void FillChild(TreeNode parent, int UpperAccountHeadID)
        {
            IList<AccountHead> AccountHeadList = new AccountService().GetAllAccountHead().Where(x => x.ParentAccountHeadID == UpperAccountHeadID).ToList();

            foreach (AccountHead accountHead in AccountHeadList)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = accountHead.AccountHeadName;
                childTreeNode.Tag = accountHead.AccId;
                parent.Nodes.Add(childTreeNode);
                FillChild(childTreeNode, accountHead.AccId);
            }
            //return new AccountHeadService().GetAllAccountHead().Where(x => x.UpperAccountHeadID == UpperAccountHeadID && x.Id > MaxID).FirstOrDefault();
        }

        
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_BalanceSheet _rpt = new rptACC_BalanceSheet();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);
            _rpt.SetDatabaseLogon("emsl", "emsl@2018", "SERVER", "EMDIAG", true);

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;

            string strStart = Convert.ToDateTime(dtpFromdate.Value.ToString()).ToShortDateString();
            string strEnd   = Convert.ToDateTime(dtpTodate.Value.ToString()).ToShortDateString();
            int AccountHeadID = 0;
            if (ddlAccountHead.SelectedIndex > -1)
                AccountHeadID = Convert.ToInt32(ddlAccountHead.SelectedValue.ToString());

            _rpt.SetParameterValue("@StartDate", strStart);
            _rpt.SetParameterValue("@EndDate", strEnd);
           









            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void TVAccountList_Click_1(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == accountHeadID).FirstOrDefault();
                ddlAccountHead.SelectedValue = accountHead.AccId;
            }
        }
    }
}
