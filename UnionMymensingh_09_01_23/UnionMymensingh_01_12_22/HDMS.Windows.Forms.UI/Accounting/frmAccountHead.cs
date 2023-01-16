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
using Services.POS;


using Models.Accounting;
using HDMS.Service.Accounting;
using HDMS.Common.Utils;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmAccountHead : Form
    {
        public frmAccountHead()
        {
            InitializeComponent();
            ClearForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButtonSupplier_Click(object sender, EventArgs e)
        {

            try
            {
                long AccountCode = 0;

                long.TryParse(txtAccCode.Text, out AccountCode);


                if (AccountCode == 0)
                {
                    MessageBox.Show("Account code blank not allow.");
                    ddlUpperAccountHead.Focus();
                    return;
                }
                else if (ddlUpperAccountHead.Text.ToString() == txtAccountHead.ToString())
                {
                    MessageBox.Show("Account head A/C  and Account head same not allow.");
                    txtAccountHead.Focus();
                    return;
                }

                AccountHead AccountHeads = new AccountHead();

                if(txtAccountHeadID.Text!="")
                    AccountHeads = new AccountService().GetAllAccountHead().Where(x => x.AccId == Convert.ToInt32(txtAccountHeadID.Text)).FirstOrDefault();
           


               

                AccountHeads.CompanyId = 1;
                AccountHeads.ParentAccountHeadID = Convert.ToInt32(ddlUpperAccountHead.SelectedValue);

                AccountHead UpperAccountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == AccountHeads.ParentAccountHeadID).FirstOrDefault();

                AccountHeads.AccCode = AccountCode;
                AccountHeads.AccountHeadName = txtAccountHead.Text;
                AccountHeads.Description = txtDescription.Text;
                AccountHeads.TopAccountHead = UpperAccountHead.TopAccountHead;
                if (chkPostingAccount.Checked)
                    AccountHeads.IsPostingHead = 1;
                else
                    AccountHeads.IsPostingHead = 0;

                if (chkCashAccount.Checked)
                    AccountHeads.IsCashHead = 1;
                else
                    AccountHeads.IsCashHead = 0;

                if (chkBankAccount.Checked)
                    AccountHeads.IsBankHead = 1;
                else
                    AccountHeads.IsBankHead = 0;

                if (ChkBalanceSheet.Checked)
                    AccountHeads.IsBalanceSheet = 1;
                else
                    AccountHeads.IsBalanceSheet = 0;

                if (ChkIncomeExpense.Checked)
                    AccountHeads.IsIncomeExpense = 1;
                else
                    AccountHeads.IsIncomeExpense = 0;

                if (ChkReceivedPayment.Checked)
                    AccountHeads.IsReceivedPayment = 1;
                else
                    AccountHeads.IsReceivedPayment = 0;

                if (txtAccountHeadID.Text != "")
                {
                    //Update 
                    new AccountService().UpdateAccountHead(AccountHeads);

                        ClearForm();
                        FillAccountTree();

                }else 
                {
                    //insert
                    new AccountService().AddNewAccountHead(AccountHeads);
                    double isExecuite = Utils.ExecuteAccountHeadIDReorder(AccountHeads.TopAccountHead);
                    if (isExecuite == 1)
                        MessageBox.Show("New Account Head added successfully.");

                    ClearForm();


                    FillAccountTree();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generate For :"+ex.Message.ToString());
            }


        }

        private void ClearForm()
        {
            //throw new NotImplementedException();
            txtAccountHead.Text = "";
            txtDescription.Text = "";
            chkPostingAccount.Checked = false;
            chkBankAccount.Checked = false;
            chkCashAccount.Checked = false;
            ChkBalanceSheet.Checked = false;
            ChkIncomeExpense.Checked = false;
            ChkReceivedPayment.Checked = false;

            string currentSelectedValue = "1";
            if(ddlUpperAccountHead.SelectedIndex > 0)
            currentSelectedValue = ddlUpperAccountHead.SelectedIndex.ToString();

            List<AccountHead> _accHeadlist = new AccountService().GetAllAccountHead().ToList();

            _accHeadlist.Insert(0, new AccountHead() { AccId = 0, AccountHeadName = "Select Head" });
            ddlUpperAccountHead.DataSource = _accHeadlist;
            ddlUpperAccountHead.DisplayMember = "AccountHeadName";
            ddlUpperAccountHead.ValueMember = "AccId";

            txtAccountHeadID.Text = "";
            txtAccCode.Text = "";
            ddlUpperAccountHead.SelectedIndex = Convert.ToInt32( currentSelectedValue);

        }

        private void suppplierNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtAdress.Focus();
            }
        }

        private void supplierAdressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtAccountHead.Focus();
            }
        }

        private void supplierPhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void supplierEmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnSaveSupplier.Focus();
            }
        }

       

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();

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

        private void TVAccountList_Click(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == accountHeadID).FirstOrDefault();
                txtAccountHeadID.Text = accountHead.AccId.ToString();
                ddlUpperAccountHead.SelectedValue = accountHead.ParentAccountHeadID;
                txtAccountHead.Text = accountHead.AccountHeadName;
                txtDescription.Text = accountHead.Description;
                txtAccCode.Text = accountHead.AccCode.ToString();
                if (accountHead.IsPostingHead == 1)
                {
                    chkPostingAccount.Checked = true;
                }
                else
                {
                    chkPostingAccount.Checked = false;
                }
            }



        }

        private void frmAccountHead_Load(object sender, EventArgs e)
        {
            FillAccountTree();
        }
    }
}
