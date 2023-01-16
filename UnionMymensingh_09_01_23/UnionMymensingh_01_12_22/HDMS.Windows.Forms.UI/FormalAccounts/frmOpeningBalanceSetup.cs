using HDMS.Model.Accounting;
using HDMS.Model.Accounting.VModel;
using HDMS.Service.Accounting;
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
    public partial class frmOpeningBalanceSetup : Form
    {
        bool unlocked = true;

        public frmOpeningBalanceSetup()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgBalances.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgBalances.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOpeningBalanceSetup_Load(object sender, EventArgs e)
        {

            FiscalYear _fiscalYear = new AccountService().GetCurrentFiscalYear();
            if (_fiscalYear != null)
            {
                txtFiscalYear.Text = _fiscalYear.FYStrat.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Plase Entry Fiscal Year");
            }
                txtFiscalYear.Tag = _fiscalYear;

            txtFiscalYear.Enabled = false;

            ctrlAccHeadSearch.Location = new Point(txtDebitHead.Location.X, txtDebitHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            LoadBalancesForCurrentFiscalYear(_fiscalYear);
        }

        private void CtrlAccHeadSearch_ItemSelected(Controls.SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtDebitHead.Text = item.AccountHeadName;
            txtDebitHead.Tag = item;
            txtOpeningBalance.Focus();
            sender.Visible = false;
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            //if (ctrl.Tag is Color)
            ctrl.BackColor = Color.White;
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;

            ctrl.BackColor = Color.NavajoWhite;
        }

        private void LoadBalancesForCurrentFiscalYear(FiscalYear fY)
        {
            List<AccOpeningBalance> _accOpBalance = new AccountService().GetOpeningBalances(fY.FYId);
            dgBalances.SuspendLayout();
            dgBalances.Rows.Clear();
            foreach(var item in _accOpBalance)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 25;
                AccountHead accHead = new AccountService().GetPostingAccountHeadById(item.AccId);
                if (accHead != null)
                {
                    row.CreateCells(dgBalances, item.Id, accHead.AccountHeadName, item.OPAmount);
                    dgBalances.Rows.Add(row);
                }
            }
        }

        private void txtDebitHead_TextChanged(object sender, EventArgs e)
        {
            if (txtDebitHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtDebitHead.Text;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDebitHead.Tag != null)
            {
                VMAccountHeads _accHead = txtDebitHead.Tag as VMAccountHeads;
                double opAmount = 0;
                FiscalYear fy = txtFiscalYear.Tag as FiscalYear;
                double.TryParse(txtOpeningBalance.Text, out opAmount);
                if (opAmount > 0 && fy != null)
                {
                    if (btnSave.Tag != null)
                    {
                        AccOpeningBalance _opBalance = btnSave.Tag as AccOpeningBalance;
                        _opBalance.FYId = fy.FYId;
                        _opBalance.AccId = _accHead.AccId;
                        _opBalance.OPAmount = opAmount;

                        if (new AccountService().UpdateOpeningBalance(_opBalance))
                        {
                            MessageBox.Show("Opening Balance Setup Updated Successful.");
                            txtOpeningBalance.Text = "";
                            txtDebitHead.Text = "";
                            txtDebitHead.Tag = null;
                            btnSave.Tag = null;
                            txtDebitHead.Focus();
                        }
                    }
                    else
                    {
                        AccOpeningBalance _opBalance = new AccOpeningBalance();
                        _opBalance.FYId = fy.FYId;
                        _opBalance.AccId = _accHead.AccId;
                        _opBalance.OPAmount = opAmount;

                        if (new AccountService().SaveOpeningBalance(_opBalance))
                        {
                            MessageBox.Show("Opening Balance Setup Successful.");
                            txtOpeningBalance.Text = "";
                            txtDebitHead.Text = "";
                            txtDebitHead.Tag = null;
                            btnSave.Tag = null;
                            txtDebitHead.Focus();
                        }
                    }

                    LoadBalancesForCurrentFiscalYear(fy);
                }
                else
                {
                    MessageBox.Show("Some reuired parameter like account head or opening balance not provided.Plz. check and try again.");
                }
            }
        }

        private void dgBalances_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AccOpeningBalance opbalance = dgBalances.SelectedRows[0].Tag as AccOpeningBalance;
            if (opbalance != null)
            {
                unlocked = false;
                
                AccountHead accHead = new AccountService().GetPostingAccountHeadById(opbalance.AccId);

                txtDebitHead.Text = accHead.AccountHeadName;
                txtDebitHead.Tag = accHead;
                txtOpeningBalance.Text = opbalance.OPAmount.ToString();

                btnSave.Tag = opbalance;

                unlocked = true;
            }
        }

        private void ctrlAccHeadSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDebitHead.Focus();
            }
        }
    }
}
