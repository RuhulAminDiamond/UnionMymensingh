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
using HDMS.Common.Utils;


namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmDebitVoucher : Form
    {

        private IList<SelectedAccountHeadToVoucher> _SelectedItems;
        private AccountHead accountHeadInfo;
        private bool IsDropDownLoaded = false;

        public frmDebitVoucher()
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
            AccountHeads.ParentAccountHeadID = Convert.ToInt32(ddlUpperAccountHead.SelectedValue);

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

            ddlUpperAccountHead.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsCashHead == 1 || x.IsBankHead == 1).ToList();
            ddlUpperAccountHead.DisplayMember = "AccountHeadName";
            ddlUpperAccountHead.ValueMember = "AccId";


            ddlCreditAccountNo.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsPostingHead == 1).ToList();
            ddlCreditAccountNo.DisplayMember = "AccountHeadName";
            ddlCreditAccountNo.ValueMember = "AccId";
            txtVoucherDate.Text = DateTime.Now.ToShortDateString();

            txtTotalAmount.Text = "0";
            _SelectedItems.Clear();
            dgItems.Rows.Clear();

            IsDropDownLoaded = true;

            Int32 i = Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

            AccountHead acc = new AccountService().GetAllHeadById(i);
            ddlCreditAccountNo.Tag = acc;
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
            _SelectedItems = new List<SelectedAccountHeadToVoucher>();
            accountHeadInfo = new AccountHead();
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

        private void FillItemGrid()
        {

            if (ddlCreditAccountNo.Tag != null)
            {
                AccountHead ach = (AccountHead)ddlCreditAccountNo.Tag;

                accountHeadInfo.AccId = ach.AccId;
                accountHeadInfo.AccountHeadName = ach.AccountHeadName;
            }
            else
            {
                MessageBox.Show("Please select an account head.");
                return;
            }


            //123456
            //accountHeadInfo.AccId = Convert.ToInt32(ddlCreditAccountNo.SelectedValue.ToString());
            //accountHeadInfo.AccountHeadName = ddlCreditAccountNo.SelectedItem.ToString();
            new AccountService().PopulateSelectedItemData(_SelectedItems, accountHeadInfo, Convert.ToDouble(txtRate.Text), txtRemarks.Text);


            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgItems.Rows.Add(row);
            }



            //////CalculateAmount();
            //dgTests.ResumeLayout();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
           

            FillItemGrid();
            txtTotalAmount.Text = (Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(txtRate.Text)).ToString();
            ddlCreditAccountNo.Focus();
            ddlCreditAccountNo.SelectedIndex = 0;
            txtRate.Text = "";
            txtDescription.Text = "";

            

        }

        private void btnSaveDebitVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgItems.Rows.Count > 0)
                {
                    if (ddlUpperAccountHead.SelectedIndex >=0)
                    {
                   
                        Voucher masterVoucher = new Voucher();
                        masterVoucher.CompanyId = 1;
                        masterVoucher.VoucherDate = Convert.ToDateTime(txtVoucherDate.Text);
                        masterVoucher.VoucherID = "";
                        masterVoucher.VoucherType = "Debit";
                        masterVoucher.Desccription = txtDescription.Text;
                        new VoucherService().AddMasterVoucher(masterVoucher);

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        detailsVoucher.VMId = masterVoucher.VMId;
                        detailsVoucher.DRCR = "D";
                        detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        detailsVoucher.AccId = Convert.ToInt32(ddlUpperAccountHead.SelectedValue.ToString());
                        detailsVoucher.reamrks = txtDescription.Text;

                        new VoucherService().AddDetailsVoucher(detailsVoucher);

                        List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
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

                        MessageBox.Show("Voucher saved ID no " + masterVoucher.VMId);
                        
                        Utils.VoucherPrint(masterVoucher.VMId);
                        ClearForm();

                        

                    }
                    else
                    {
                        MessageBox.Show("Debit account head not selected.");
                    }
                }
                else
                {
                    MessageBox.Show("Credit account Head Not Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generate for :"+ex.Message.ToString());
            }
        }

        private void TVAccountList_DoubleClick(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetPostingAccountHeadById(accountHeadID);   //GetAllAccountHead().Where(x => x.Id == accountHeadID && x.IsPostingHead ==1).FirstOrDefault();
                if (accountHead != null)
                {
                    ddlCreditAccountNo.SelectedValue = accountHead.AccId;
                }else
                {
                    MessageBox.Show("This one is not a posting head. Please select posting head and try again.");
                }
              
            }

        }

        private void ddlCreditAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDropDownLoaded)
            {
                Int32 i = Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

                AccountHead acc = new AccountService().GetAllHeadById(i);
                ddlCreditAccountNo.Tag = acc;
            }
        }
    }
}
