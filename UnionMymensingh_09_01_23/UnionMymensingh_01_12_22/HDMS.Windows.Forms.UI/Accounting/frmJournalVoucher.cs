using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

using Models.ViewModel;
using HDMS.Model.ViewModel;
using Models.Accounting;
using HDMS.Service.Accounting;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmJournalVoucher : Form
    {

        private IList<SelectedAccountHeadToVoucher> _SelectedDebitItems;
        private IList<SelectedAccountHeadToVoucher> _SelectedCreditItems;
        private AccountHead accountDebitHeadInfo;
        private AccountHead accountCreditHeadInfo;
        private bool IsDropDownDebitInfoLoaded = false;
        private bool IsDropDownCreditInfoLoaded = false;
        public frmJournalVoucher()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButtonSupplier_Click(object sender, EventArgs e)
        {
            AccountHead AccountHeads = new AccountHead();


            AccountHeads.CompanyId = 1;
            AccountHeads.ParentAccountHeadID = Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

            AccountHeads.Description = txtDescription.Text;



            if (new AccountService().AddNewAccountHead(AccountHeads))
            {
                MessageBox.Show("New Account Head added successfully.");
                ClearForm();
            }
        }

        private void ClearForm()
        {
            //throw new NotImplementedException();

            txtDescription.Text = "";

            ddlCreditAccountNo.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsPostingHead == 1 ).ToList();
            ddlCreditAccountNo.DisplayMember = "AccountHeadName";
            ddlCreditAccountNo.ValueMember = "AccId";

            

            ddlDebitAccountNo.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsPostingHead == 1).ToList();
            ddlDebitAccountNo.DisplayMember = "AccountHeadName";
            ddlDebitAccountNo.ValueMember = "AccId";
            txtVoucherDate.Text = DateTime.Now.ToShortDateString();

            txtTotalAmount.Text = "0";
            _SelectedDebitItems.Clear();
            _SelectedCreditItems.Clear();
            dgDebitItems.Rows.Clear();

            IsDropDownDebitInfoLoaded = true;

            Int32 i = Convert.ToInt32(ddlDebitAccountNo.SelectedValue);

            AccountHead acc = new AccountService().GetAllHeadById(i);
            ddlDebitAccountNo.Tag = acc;


            IsDropDownCreditInfoLoaded = true;

            Int32 iCradit = Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

            AccountHead accCredit = new AccountService().GetAllHeadById(iCradit);
            ddlCreditAccountNo.Tag = accCredit;


            

        }



        private void supplierPhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void supplierEmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSaveDebitVoucher.Focus();
            }
        }

        private void SupplierControl_Load(object sender, EventArgs e)
        {
            _SelectedDebitItems = new List<SelectedAccountHeadToVoucher>();
            _SelectedCreditItems = new List<SelectedAccountHeadToVoucher>();
            accountDebitHeadInfo = new AccountHead();
            accountCreditHeadInfo = new AccountHead();
            ClearForm();

            int UpperAccountHeadID = 0;
            IList<AccountHead> AccountHeadList = new AccountService().GetAllAccountHead().Where(x => x.ParentAccountHeadID == UpperAccountHeadID).ToList();



            foreach (AccountHead accountHead in AccountHeadList)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = accountHead.AccountHeadName;
                treeNode.Tag = accountHead.AccId;

                TVAccountList.Nodes.Add(treeNode);
                FillChild(treeNode, accountHead.AccId);
                //AccountHead AccountHead = GetChildAccountHead(0, 0);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
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
            //return new AccountService().GetAllAccountHead().Where(x => x.UpperAccountHeadID == UpperAccountHeadID && x.Id > MaxID).FirstOrDefault();
        }

        private void TVAccountList_Click(object sender, EventArgs e)
        {

        }

        private void FillDebitItemGrid()
        {
            //123456
            //accountDebitHeadInfo.AccId = Convert.ToInt32(ddlDebitAccountNo.SelectedValue.ToString());
            //accountDebitHeadInfo.AccountHeadName = ddlDebitAccountNo.SelectedItem.ToString();

            //123456
            if (ddlDebitAccountNo.Tag != null)
            {
                AccountHead ach = (AccountHead)ddlDebitAccountNo.Tag;

                accountDebitHeadInfo.AccId = ach.AccId;
                accountDebitHeadInfo.AccountHeadName = ach.AccountHeadName;
            }
            else
            {
                return;
            }

            new AccountService().PopulateSelectedItemData(_SelectedDebitItems, accountDebitHeadInfo, Convert.ToDouble(txtRate.Text), txtRemarks.Text);
            dgDebitItems.SuspendLayout();
            dgDebitItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedDebitItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgDebitItems, item.AccountHeadName, item.Amount, item.Remarks);
                
                dgDebitItems.Rows.Add(row);
            }



            //////CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void FillCreditItemGrid()
        {
            //123456
            //accountCreditHeadInfo.AccId = Convert.ToInt32(ddlDebitAccountNo.SelectedValue.ToString());
            //accountCreditHeadInfo.AccountHeadName = ddlDebitAccountNo.SelectedItem.ToString();


            if (ddlCreditAccountNo.Tag != null)
            {
                AccountHead ach = (AccountHead)ddlCreditAccountNo.Tag;

                accountCreditHeadInfo.AccId = ach.AccId;
                accountCreditHeadInfo.AccountHeadName = ach.AccountHeadName;
            }
            else
            {
                return;
            }

            new AccountService().PopulateSelectedItemData(_SelectedCreditItems, accountCreditHeadInfo, Convert.ToDouble(txtCreditAmount.Text), txtCreditRemarks.Text);

            dgCreditItems.SuspendLayout();
            dgCreditItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedCreditItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgDebitItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgCreditItems.Rows.Add(row);
            }



            //////CalculateAmount();
            //dgTests.ResumeLayout();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
          

            

        }

        private void btnSaveDebitVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDebitItems.Rows.Count > 0)
                {
                    if (ddlCreditAccountNo.SelectedIndex >=0)
                    {

                        Voucher masterVoucher = new Voucher();
                        masterVoucher.CompanyId = 1;
                        masterVoucher.VoucherDate = Convert.ToDateTime(txtVoucherDate.Text);
                        masterVoucher.VoucherID = "";
                        masterVoucher.VoucherType = "Journal";
                        masterVoucher.Desccription = txtDescription.Text;
                        new VoucherService().AddMasterVoucher(masterVoucher);

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        //detailsVoucher.VoucherMasterId = masterVoucher.Id;
                        //detailsVoucher.DRCR = "C";
                        //detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        //detailsVoucher.PostingAccountHead = Convert.ToInt32(ddlCreditAccountNo.SelectedValue.ToString());
                        //detailsVoucher.reamrks = txtDescription.Text;

                        //new VoucherService().AddVoucherDetail(detailsVoucher);

                        List<VoucherDetail> _rDebitVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgDebitItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = masterVoucher.VMId;
                            detailsVoucher.DRCR = "D";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddDetailsVoucher(detailsVoucher);

                        }


                        foreach (DataGridViewRow row in dgCreditItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = masterVoucher.VMId;
                            detailsVoucher.DRCR = "C";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddDetailsVoucher(detailsVoucher);

                        }

                        MessageBox.Show("Voucher Saved. ID no " + masterVoucher.VMId);
                        Utils.VoucherPrint(masterVoucher.VMId);
                        ClearForm();

                    }
                    else
                    {
                        MessageBox.Show("Debit Account Head Not Selected.");
                    }
                }
                else
                {
                    MessageBox.Show("Credit Account Head Not Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generate For :"+ex.Message.ToString());
            }
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == accountHeadID && x.IsPostingHead == 1).FirstOrDefault();

                if(accountHead!=null)
                    ddlDebitAccountNo.SelectedValue = accountHead.AccId;

            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == accountHeadID && x.IsPostingHead == 1).FirstOrDefault();

                if (accountHead != null)
                    ddlCreditAccountNo.SelectedValue = accountHead.AccId;


            }
        }

        private void btnDebitAdd_Click(object sender, EventArgs e)
        {
            FillDebitItemGrid();
            txtTotalAmount.Text = (Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(txtRate.Text)).ToString();
            ddlDebitAccountNo.Focus();
            ddlDebitAccountNo.SelectedIndex = 0;
            txtRate.Text = "";
            txtDescription.Text = "";
        }

        private void btnCreditAdd_Click(object sender, EventArgs e)
        {
            FillCreditItemGrid();
            txtTotalAmount.Text = (Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(txtCreditAmount.Text)).ToString();
            ddlCreditAccountNo.Focus();
            ddlCreditAccountNo.SelectedIndex = 0;
            txtCreditAmount.Text = "";
            txtCreditRemarks.Text = "";
        }

        private void ddlDebitAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDropDownDebitInfoLoaded)
            {
                Int32 i = Convert.ToInt32(ddlDebitAccountNo.SelectedValue);

                AccountHead acc = new AccountService().GetAllHeadById(i);
                ddlDebitAccountNo.Tag = acc;
            }
        }

        private void ddlCreditAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDropDownCreditInfoLoaded)
            {
                Int32 i = Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

                AccountHead acc = new AccountService().GetAllHeadById(i);
                ddlCreditAccountNo.Tag = acc;
            }
        }
    }
}
