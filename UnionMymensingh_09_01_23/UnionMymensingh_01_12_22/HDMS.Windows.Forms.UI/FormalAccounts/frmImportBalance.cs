using CrystalDecisions.Windows.Forms;
using HDMS.Model.Accounting;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Common.VW;
using HDMS.Model.ViewModel;
using HDMS.Service.Accounting;
using HDMS.Service.Common;
using HDMS.Windows.Forms.UI.Classes;
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
    public partial class frmImportBalance : Form
    {
        public frmImportBalance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmImportBalance_Load(object sender, EventArgs e)
        {
            
        }

        private void AccumulateBalance(DateTime dtpfrm, DateTime dtpto)
        {
             new AccountService().AccumulateBalance(dtpfrm, dtpto);
        }

        private void btnImportBalance_Click(object sender, EventArgs e)
        {
            AccumulateBalance(dtpfrm.Value, dtpto.Value);

            List<VMDeptGroupAccountHeadMapping> accgrpList = new CommonService().GetDeptGroupAccountHeadMappedBalanceList(dtpfrm.Value,dtpto.Value);
            dgDeptsBalance.SuspendLayout();
            dgDeptsBalance.Rows.Clear();

            int count = 1;
            double _totalAmount = 0;
            foreach(var item in accgrpList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                _totalAmount = _totalAmount + item.Amount;
                row.CreateCells(dgDeptsBalance, count, item.DeptName,item.GroupName,item.AccountHeadName,item.Amount);
                dgDeptsBalance.Rows.Add(row);
            }

            lblTotalAmount.Text = Math.Round(_totalAmount).ToString();
        }

        private void btnPostVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDeptsBalance.Rows.Count > 0)
                {
                    btnPostVoucher.Enabled = false;
                    btnPostVoucher.Text = "Loading...";

                    int debitAccountHeadId = 123;
                    double totalAmount = 0;
                    double.TryParse(lblTotalAmount.Text, out totalAmount);


                    DateTime _importDate = Utils.GetServerDateAndTime();


                    bool _IsAlreadyImported = new VoucherService().CheckIsAlreadyImported(dtpfrm.Value,dtpto.Value);

                    if (_IsAlreadyImported)
                    {
                        MessageBox.Show("Data already imported for this date range");

                        btnPostVoucher.Enabled = true;
                        btnPostVoucher.Text = "Post Voucher";


                        return;
                    }

                    AccountsAutoImportLog importLog = new AccountsAutoImportLog();
                    importLog.ImportDate = _importDate;
                    importLog.ImportTime = _importDate.ToString("hh:mm tt");
                    importLog.FromDate = dtpfrm.Value;
                    importLog.ToDate = dtpto.Value;
                    importLog.ImportedBy = MainForm.LoggedinUser.Name;

                    if (new VoucherService().SaveAutoImportLog(importLog))
                    {


                        if (debitAccountHeadId > 0)
                        {

                            Voucher masterVoucher = new Voucher();
                            masterVoucher.CompanyId = 1;
                            masterVoucher.VoucherDate = dtpVoucher.Value;
                            masterVoucher.VoucherId = "";
                            masterVoucher.VoucherType = "Credit";
                            masterVoucher.Description = "Imported amount from departments";
                            masterVoucher.AILogId = importLog.AILogId;
                            masterVoucher.CreateUser = MainForm.LoggedinUser.Name;

                            new VoucherService().AddMasterVoucher(masterVoucher);

                            VoucherDetail detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = masterVoucher.VMId;
                            detailsVoucher.DRCR = "D";
                            detailsVoucher.Amount = totalAmount;
                            detailsVoucher.AccId = debitAccountHeadId;
                            detailsVoucher.reamrks = "Imported amount from departments";

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                            List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                            foreach (DataGridViewRow row in dgDeptsBalance.Rows)
                            {
                                VMDeptGroupAccountHeadMapping selectedItem = row.Tag as VMDeptGroupAccountHeadMapping;

                                detailsVoucher = new VoucherDetail();
                                detailsVoucher.VMId = masterVoucher.VMId;
                                detailsVoucher.DRCR = "C";
                                detailsVoucher.Amount = selectedItem.Amount;
                                detailsVoucher.AccId = selectedItem.AccountHeadId;
                                detailsVoucher.reamrks = selectedItem.DeptName;

                                new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                            }

                            MessageBox.Show("Voucher saved successful ");
                            PrintVoucher(masterVoucher.VMId, "Receive Voucher");
                            ClearForm();

                        }
                        else
                        {
                            MessageBox.Show("Debit Account Head Not Selected.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Credit Account Head Not Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generate For :" + ex.Message.ToString());
            }


            btnPostVoucher.Enabled = true;
            btnPostVoucher.Text = "Post Voucher";
        }


      private void PrintVoucher(long vMId, string v)
      {
            DataSet _dsVoucher = new VoucherService().GetReceiptOrCreditVoucher(vMId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptImportedBalanceVoucher _payVoucher = new rptImportedBalanceVoucher();

            _payVoucher.SetDataSource(_dsVoucher.Tables[0]);

            List<SelectedAccountHeadToVoucher> _accToList = new AccountService().GetCreditAccountListByVoucher(vMId);
            //string _receiveFrom = AccUtility.GetSPayTo(_accToList);
            double _totalCredit = _accToList.Sum(x => x.Amount);

            ReportViewer rv = new ReportViewer();

            _payVoucher.SetParameterValue("description", "Auto imported balance");
            _payVoucher.SetParameterValue("PreparedBy", MainForm.LoggedinUser.Name);
            _payVoucher.SetParameterValue("Inwords", Spell.SpellAmount.InWrods(Convert.ToDecimal(Math.Round(_totalCredit))));

            rv.crviewer.ReportSource = _payVoucher;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }



        private void ClearForm()
        {
            dgDeptsBalance.Rows.Clear();
        }

        private void btnShowImportedLogs_Click(object sender, EventArgs e)
        {

            ViewImportedogs();

        }

        private void ViewImportedogs()
        {
            List<VMAccountAutoImportLogs> impLogs = new AccountService().GetAutoImportLogs(dtpImpFrm.Value, dtpImpTo.Value);

            dgLogs.SuspendLayout();
            dgLogs.Rows.Clear();
            foreach (var item in impLogs)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgLogs, item.AILogId, item.ImportDate.ToString("dd/MM/yyyy"), item.FromDate.ToString("dd/MM/yyyy"), item.ToDate.ToString("dd/MM/yyyy"), item.ImportedBy,item.VMId);

                dgLogs.Rows.Add(row);
            }
        }

        private void dgLogs_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMAccountAutoImportLogs Obj = dgLogs.SelectedRows[0].Tag as VMAccountAutoImportLogs;
            List<VMAutoImportedPostedVoucherDetail> _accList = new AccountService().GetImportedDataDetails(Obj.AILogId);
            dgLogDetails.SuspendLayout();
            dgLogDetails.Rows.Clear();
            int count = 1;
            double _totalAmount = 0;
            foreach(var item in _accList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                _totalAmount = _totalAmount + item.Amount;
                row.CreateCells(dgLogDetails, count, item.AccountHeadName, item.Amount);
                dgLogDetails.Rows.Add(row);
                lblPostedAmount.Text = _totalAmount.ToString();
                count++;
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgLogs_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            VMAccountAutoImportLogs _SelectedItem = (VMAccountAutoImportLogs)e.Row.Tag;
            if (_SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete these imported data?", "Confirm", MessageBoxButtons.YesNo);
            
                if(result== DialogResult.Yes)
                {
                    if(new AccountService().DeleteImportedResults(_SelectedItem.AILogId))
                    {
                        MessageBox.Show("Delete Successful;");
                        ViewImportedogs();
                        dgLogDetails.Rows.Clear();
                    }
                }
            
            }
        }
    }
}
