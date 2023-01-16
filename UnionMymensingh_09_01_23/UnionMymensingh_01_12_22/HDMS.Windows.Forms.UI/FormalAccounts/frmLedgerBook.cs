using CrystalDecisions.Windows.Forms;
using HDMS.Model.Accounting.VModel;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.FormalAccounts
{
    public partial class frmLedgerBook : Form
    {
        bool unlocked = true;


        public frmLedgerBook()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptLedger _rpt = new rptLedger();

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpFromdate.Value;
            DateTime Todate = dtpTodate.Value;
            string customFmts = "dd/MM/yyyy";
            string strStart = Convert.ToDateTime(dtpFromdate.Value.ToString()).ToShortDateString();
            string strEnd = Convert.ToDateTime(dtpTodate.Value.ToString()).ToShortDateString();


            VMAccountHeads accHead = txtPostingHead.Tag as VMAccountHeads;

            if (accHead == null)
            {
                MessageBox.Show("Plz. select an account head and try again."); return;
            }

            //if (ddlAccountHead.SelectedIndex > -1)
            //    AccountHeadID = Convert.ToInt32(ddlAccountHead.SelectedValue.ToString());

            DataSet ds = new AccountService().GetLedger(Fromdate, Todate, accHead.AccId);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("datefrm", Fromdate.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(customFmts));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLedgerBook_Load(object sender, EventArgs e)
        {
            ctrlAccHeadSearch.Location = new Point(txtPostingHead.Location.X, txtPostingHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected;

            ctrlAccountGroupSearchControl1.Location = new Point(txtPostingHead.Location.X, txtPostingHead.Location.Y);
            ctrlAccountGroupSearchControl1.ItemSelected += ctrlAccountGroupSearchControl1_ItemSelected;

            dtpFromdate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();
            dtpTodate.Text = Convert.ToDateTime(DateTime.Now).ToShortTimeString();

        }

        private void ctrlAccountGroupSearchControl1_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtAccountGroup.Text = item.AccountHeadName;
            txtAccountGroup.Tag = item;
            sender.Visible = false;
            txtAccountGroup.Focus();
        }

        private void CtrlAccHeadSearch_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtPostingHead.Text = item.AccountHeadName;
            txtPostingHead.Tag = item;
            sender.Visible = false;
            txtPostingHead.Focus();
        }

        private void txtPostingHead_TextChanged(object sender, EventArgs e)
        {
            if (txtPostingHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtPostingHead.Text;
                    HideAllDefaultHidden();
                    ctrlAccHeadSearch.Visible = true;
                    ctrlAccHeadSearch.txtSearch.Text = _txt;
                    ctrlAccHeadSearch.txtSearch.SelectionStart = ctrlAccHeadSearch.txtSearch.Text.Length;

                    ctrlAccHeadSearch.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlAccHeadSearch.Visible = false;
            ctrlAccountGroupSearchControl1.Visible = false;
        }

        private void ctrlAccHeadSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtPostingHead.Focus();
            }
        }

        private void txtAccountGroup_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountGroup.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtAccountGroup.Text;
                    HideAllDefaultHidden();
                    ctrlAccountGroupSearchControl1.Visible = true;
                    ctrlAccountGroupSearchControl1.txtSearch.Text = _txt;
                    ctrlAccountGroupSearchControl1.txtSearch.SelectionStart = ctrlAccountGroupSearchControl1.txtSearch.Text.Length;

                    ctrlAccountGroupSearchControl1.LoadData();
                }

                if (string.IsNullOrEmpty(txtAccountGroup.Text))
                {
                    unlocked = true;
                }
            }

            if (string.IsNullOrEmpty(txtAccountGroup.Text))
            {
                unlocked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowLedgerSummary_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rptLedgerSummary _rpt = new rptLedgerSummary();

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            DateTime Fromdate = dtpfrm.Value;
            DateTime Todate = dtpto.Value;
            string customFmts = "dd/MM/yyyy";
            string strStart = Convert.ToDateTime(dtpfrm.Value.ToString()).ToShortDateString();
            string strEnd = Convert.ToDateTime(dtpto.Value.ToString()).ToShortDateString();


            VMAccountHeads accHead = txtAccountGroup.Tag as VMAccountHeads;

            if (accHead == null)
            {
                MessageBox.Show("Plz. select an account head and try again."); return;
            }

            //if (ddlAccountHead.SelectedIndex > -1)
            //    AccountHeadID = Convert.ToInt32(ddlAccountHead.SelectedValue.ToString());

            DataSet ds = new AccountService().GetLedgerSummary(Fromdate, Todate, accHead.AccId);
            _rpt.SetDataSource(ds.Tables[0]);

            _rpt.SetParameterValue("AccGroup", txtAccountGroup.Text);
            _rpt.SetParameterValue("datefrm", Fromdate.ToString(customFmts));
            _rpt.SetParameterValue("dateto", dtpTodate.Value.ToString(customFmts));

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }
    }
}
