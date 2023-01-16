using HDMS.Model.Accounting.VModel;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Controls;
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
    public partial class frmLedgerSetup : Form
    {

        bool unlocked = true;
        
        public frmLedgerSetup()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                long AccountCode = 0;

                long.TryParse(txtAccCode.Text, out AccountCode);



                AccountHead accHead = new AccountHead();

                if (txtParentHead.Tag != null)
                {

                    AccountHead parentHead = txtParentHead.Tag as AccountHead;

                    accHead.CompanyId = 1;
                    accHead.ParentAccountHeadId = parentHead.AccId;
                    accHead.AccCode = AccountCode;
                    accHead.AccountHeadName = txtAccountHeadName.Text;
                    accHead.Description = txtDescription.Text;
                    accHead.TopAccountHead = parentHead.TopAccountHead;
                    accHead.IsPostingHead = true;
                    accHead.isSummeryFieldforLedger = false;
                    accHead.isSummeryFieldforTrailBalance = false;
                    new AccountService().AddNewAccountHead(accHead);

                    if (AccUtility.ExecuteAccountHeadIDReorder(accHead.TopAccountHead))
                    {
                        MessageBox.Show("New Account Head added successfully.");
                    }

                    ClearForm();


                    accHeadList = new AccountService().GetAllAccountHead().ToList();

                    await FillAccountTree();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generate For :" + ex.Message.ToString());
            }

        }

        private void ClearForm()
        {
            txtAccountHeadName.Text = "";
            txtDescription.Text = "";
        }

        List<AccountHead> accHeadList = new List<AccountHead>();
        private async void frmLedgerSetup_Load(object sender, EventArgs e)
        {
            ctrlAccHeadSearch.Location = new Point(txtParentHead.Location.X, txtParentHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected; ;

            accHeadList = new AccountService().GetAllAccountHead().ToList();

            await FillAccountTree();
        }

        private async Task<bool> FillAccountTree()
        {
            TVAccountList.Nodes.Clear();
            List<AccountHead> AccountHeadList = new AccountService().GetAllBaseHead().ToList();

            foreach (AccountHead accountHead in AccountHeadList)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Text = accountHead.AccountHeadName;
                treeNode.Tag = accountHead.AccId;

                TVAccountList.Nodes.Add(treeNode);
                await FillChild(treeNode, accountHead.AccId);

            }

            return await Task.FromResult(true);
        }


        private async Task<bool> FillChild(TreeNode parent, int UpperAccountHeadID)
        {
            IList<AccountHead> AccountHeadList = accHeadList.Where(x => x.ParentAccountHeadId == UpperAccountHeadID).ToList();

            foreach (AccountHead accountHead in AccountHeadList)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = accountHead.AccId.ToString() + "-" + accountHead.AccountHeadName;
                childTreeNode.Tag = accountHead.AccId;
                parent.Nodes.Add(childTreeNode);
                await FillChild(childTreeNode, accountHead.AccId);
            }

            return await Task.FromResult(true);
            //return new AccountHeadService().GetAllAccountHead().Where(x => x.UpperAccountHeadID == UpperAccountHeadID && x.Id > MaxID).FirstOrDefault();
        }


        private void CtrlAccHeadSearch_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtParentHead.Text = item.AccountHeadName;
            txtParentHead.Tag = item;
            txtAccCode.Focus();
            sender.Visible = false;
        }

        private void TVAccountList_DoubleClick(object sender, EventArgs e)
        {
            if (TVAccountList.SelectedNode != null)
            {
                unlocked = false;

                int accountHeadID = Convert.ToInt32(TVAccountList.SelectedNode.Tag.ToString());
                AccountHead accountHead = new AccountService().GetAllAccountHead().Where(x => x.AccId == accountHeadID).FirstOrDefault();
                txtParentHead.Text = accountHead.AccountHeadName.ToString();
                txtParentHead.Tag = accountHead;

                if (accountHead.IsPostingHead == false)
                {
                    txtAccountHeadName.Text = accountHead.AccountHeadName;
                    txtDescription.Text = accountHead.Description;
                    txtAccCode.Text = accountHead.AccCode.ToString();
                }
                else
                {
                    MessageBox.Show("It's a ledger. Plz. select a group and try again."); return;
                }


                // unlocked = true;
            }
        }

        private void ctrlAccHeadSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtParentHead.Focus();
            }
        }

        private void txtParentHead_TextChanged(object sender, EventArgs e)
        {
            if (txtParentHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtParentHead.Text;
                    HideAllDefaultHidden();
                    ctrlAccHeadSearch.Visible = true;
                    ctrlAccHeadSearch.txtSearch.Text = _txt;
                    ctrlAccHeadSearch.txtSearch.SelectionStart = ctrlAccHeadSearch.txtSearch.Text.Length;

                    ctrlAccHeadSearch.LoadData();
                }

                if (string.IsNullOrEmpty(txtParentHead.Text))
                {
                    unlocked = true;
                }
            }

            if (string.IsNullOrEmpty(txtParentHead.Text))
            {
                unlocked = true;
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlAccHeadSearch.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
