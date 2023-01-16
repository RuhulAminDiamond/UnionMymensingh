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

using CrystalDecisions.Windows.Forms;

using POS;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmDebitVoucher : Form
    {

        private IList<SelectedAccountHeadToVoucher> _SelectedItems;
        private AccountHead accountHeadInfo;
      
        bool unlocked = true;

        public frmDebitVoucher()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgItems.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgItems.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButtonSupplier_Click(object sender, EventArgs e)
        {
            AccountHead AccountHeads = new AccountHead();


            AccountHeads.CompanyId = 1;
            AccountHeads.ParentAccountHeadId = Convert.ToInt32(cmbDebitAccount.SelectedValue);

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
            txtName.Text = "";
            txtPrevVoucher.Text = "";
            txtPrevVoucher.Tag = null;
            txtVoucherId.Text = "";
            btnSaveDebitVoucher.Enabled = true;
            btnEdit.Enabled = false;

            cmbDebitAccount.DataSource = new AccountService().GetAllAccountHead().Where(x => x.IsPostingHead == true && (x.IsCashHead == true || x.IsBankHead == true)).ToList();
            cmbDebitAccount.DisplayMember = "AccountHeadName";
            cmbDebitAccount.ValueMember = "AccId";

          
            dtpVoucher.Value = DateTime.Now;

            txtTotalAmount.Text = "0";
            _SelectedItems.Clear();
            dgItems.Rows.Clear();

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
           

            ctrlAccHeadSearch.Location = new Point(txtDebitHead.Location.X, txtDebitHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected; 

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            cmbDebitAccount.DataSource = new AccountService().GetAllAccountHead().Where(x=>x.IsPostingHead==true && (x.IsCashHead == true || x.IsBankHead == true)).ToList();
            cmbDebitAccount.DisplayMember = "AccountHeadName";
            cmbDebitAccount.ValueMember = "AccId";


        }

        private void CtrlAccHeadSearch_ItemSelected(Controls.SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtDebitHead.Text = item.AccountHeadName;
            txtDebitHead.Tag = item;
            txtRemarks.Focus();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
          
        }

        private void FillChild(TreeNode parent, int UpperAccountHeadID)
        {
            IList<AccountHead> AccountHeadList = new AccountService().GetAllAccountHead().Where(x => x.ParentAccountHeadId == UpperAccountHeadID).ToList();

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
            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.Height = 25;
                row.CreateCells(dgItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgItems.Rows.Add(row);
            }

            CalculateTotal();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void CalculateTotal()
        {
            txtTotalAmount.Text = dgItems.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToDouble(t.Cells[1].Value)).ToString();
        }

        private void btnSaveDebitVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgItems.Rows.Count > 0)
                {
                    btnSaveDebitVoucher.Enabled = false;


                    if (cmbDebitAccount.SelectedIndex >=0)
                    {
                   
                        Voucher masterVoucher = new Voucher();
                        masterVoucher.CompanyId = 1;
                        masterVoucher.VoucherDate = dtpVoucher.Value;
                        masterVoucher.VoucherId = txtVoucherId.Text;
                        masterVoucher.VoucherType = "Debit";
                        masterVoucher.Description = txtDescription.Text;
                        masterVoucher.Name = txtName.Text;
                        masterVoucher.CreateUser = MainForm.LoggedinUser.Name;
                        masterVoucher.AILogId = 0; // Auto Import Log Id
                        new VoucherService().AddMasterVoucher(masterVoucher);

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        detailsVoucher.VMId = masterVoucher.VMId;
                        detailsVoucher.DRCR = "C";
                        detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        detailsVoucher.AccId = Convert.ToInt32(cmbDebitAccount.SelectedValue.ToString());
                        detailsVoucher.reamrks = txtDescription.Text;

                        new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = masterVoucher.VMId;
                            detailsVoucher.DRCR = "D";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        }

                        MessageBox.Show("Voucher saved successfully.");
                        
                        PrintVoucher(masterVoucher,"Payment Voucher");
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

            btnSaveDebitVoucher.Enabled = true;
        }

        private void PrintVoucher(Voucher voucher, string v)
        {
            double _totalDebit = 0;

            DataSet _dsVoucher = new VoucherService().GetPaymentOrDebitVoucher(voucher.VMId);

            rptPaymentOrDebitVoucher _payVoucher = new rptPaymentOrDebitVoucher();

            _payVoucher.SetDataSource(_dsVoucher.Tables[0]);


            List<SelectedAccountHeadToVoucher> _accToList = new AccountService().GetAccountListByVoucher(voucher.VMId);
            _totalDebit = _accToList.Sum(x => x.Amount);


           // string _payTo = AccUtility.GetSPayTo(_accToList);

            ReportViewer rv = new ReportViewer();

            _payVoucher.SetParameterValue("description", voucher.Description);
            //_payVoucher.SetParameterValue("PayTo", voucher.Name);
            _payVoucher.SetParameterValue("Name", voucher.Name);
            _payVoucher.SetParameterValue("PreparedBy", MainForm.LoggedinUser.Name);
            _payVoucher.SetParameterValue("Inwords", Spell.SpellAmount.InWrods(Convert.ToDecimal(_totalDebit)));


            rv.crviewer.ReportSource = _payVoucher;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            rv.Show();
        }

       

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedAccountHeadToVoucher _SelectedItem = (SelectedAccountHeadToVoucher)e.Row.Tag;
           _SelectedItems.Remove(e.Row.Tag as SelectedAccountHeadToVoucher);
            CalculateTotal();
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            long _VMId = 0;
            long.TryParse(txtPrevVoucher.Text, out _VMId);
            if(_VMId>0) _VMId = _VMId - 1;
            LoadPreviousVoucher(_VMId);
        }

        private void LoadPreviousVoucher(long _VMId)
        {
            Voucher _voucher = null;

            if (_VMId == 0)
            {
                _voucher = new AccountService().GetLatestPaymentVoucher();

            }else
            {
                _voucher = new AccountService().GetVoucherById(_VMId);
            }

            if (_voucher != null && _voucher.VoucherType == "Debit")
            {

                txtPrevVoucher.Tag = _voucher;

                btnSaveDebitVoucher.Enabled = false;
                btnEdit.Enabled = true;

                txtVoucherId.Text = _voucher.VoucherId;
                dtpVoucher.Value = _voucher.VoucherDate;
                txtPrevVoucher.Text = _voucher.VMId.ToString();
                txtDescription.Text = _voucher.Description;
                txtName.Text = _voucher.Name;

                VoucherDetail vdetail= new AccountService().GetCreditHeadAgainstDebits(_voucher.VMId);

                LoadCreditHeads(vdetail.AccId);

                _SelectedItems = new AccountService().GetDebitHeadList(_voucher.VMId).ToList();

                FillItemGrid();

              //  FillAccListGrid(_SelectedItems);

            }
            else
            {

                MessageBox.Show("This is not a debit voucher.");

                //txtPrevVoucher.Text = (_VMId-1).ToString();
                return;
            }
        }

        private void FillAccListGrid(List<SelectedAccountHeadToVoucher> _vdetailList)
        {

            double _amount = 0;

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _vdetailList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                _amount = _amount + item.Amount;
                row.CreateCells(dgItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgItems.Rows.Add(row);
            }

            txtTotalAmount.Text = _amount.ToString();
        }

        public void LoadCreditHeads(int _accId)
        {
            

            List<AccountHead> _accHeads= new AccountService().GetAllAccountHead().Where(x =>x.IsPostingHead==true && ( x.IsCashHead == true || x.IsBankHead == true)).ToList();

            cmbDebitAccount.DataSource = _accHeads;
            cmbDebitAccount.DisplayMember = "AccountHeadName";
            cmbDebitAccount.ValueMember = "AccId";

            cmbDebitAccount.SelectedItem = _accHeads.Find(q => q.AccId == _accId);
        }

        private void txtPrevVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _vmId = 0;
                long.TryParse(txtPrevVoucher.Text, out _vmId);

                LoadPreviousVoucher(_vmId);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtPrevVoucher.Tag == null) { MessageBox.Show("No voucher found for edit."); return; }

            DialogResult result = MessageBox.Show("Are you sure to edit this voucher?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Voucher _voucher = (Voucher)txtPrevVoucher.Tag;
                
                _voucher.VoucherDate = dtpVoucher.Value;
                _voucher.VoucherId = txtVoucherId.Text;
                _voucher.VoucherType = "Debit";
                _voucher.Description = txtDescription.Text;
                _voucher.Name = txtName.Text;
                _voucher.CreateUser = MainForm.LoggedinUser.Name;
               

                if (new VoucherService().UpdateMasterVoucher(_voucher))
                {

                    //if (new AccountService().DeleteExistingVoucherDetails(_voucher.VMId))
                    //{

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        detailsVoucher.VMId = _voucher.VMId;
                        detailsVoucher.DRCR = "C";
                        detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        detailsVoucher.AccId = Convert.ToInt32(cmbDebitAccount.SelectedValue.ToString());
                        detailsVoucher.reamrks = txtDescription.Text;

                        new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);


                        List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = _voucher.VMId;
                            detailsVoucher.DRCR = "D";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        }

                        MessageBox.Show("Voucher edited successfully.");

                        PrintVoucher(_voucher, "Payment Voucher");
                        ClearForm();
                    //}
                }

            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _amount = 0;
                double _tamount = 0;
                double _total = 0;
                double.TryParse(txtAmount.Text, out _amount);
                double.TryParse(txtTotalAmount.Text, out _tamount);


                if (txtAmount.Tag == null)
                {

                    if (txtDebitHead.Tag != null)
                    {

                        VMAccountHeads _accHead = txtDebitHead.Tag as VMAccountHeads;

                        new AccountService().PopulateSelectedItemData(_SelectedItems, _accHead, _amount, txtRemarks.Text);

                        FillItemGrid();

                    }
                    else
                    {
                        MessageBox.Show("Account not selected. Plz. check and try again.");
                        txtDebitHead.Focus();
                    }


                    txtRemarks.Text = "";
                    txtAmount.Text = "";
                    txtAmount.Tag = null;
                    txtDebitHead.Text = "";
                    txtDebitHead.Tag = null;

                    txtDebitHead.Focus();
                }
                else
                {
                  SelectedAccountHeadToVoucher sv = txtAmount.Tag as SelectedAccountHeadToVoucher;
                  if (sv != null)
                  {
                            _SelectedItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Amount = _amount);

                            _SelectedItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Remarks = txtRemarks.Text);

                            FillItemGrid();


                        txtRemarks.Text = "";
                        txtAmount.Text = "";
                        txtAmount.Tag = null;
                        txtDebitHead.Text = "";
                        txtDebitHead.Tag = null;

                        txtDebitHead.Focus();

                    }
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

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDebitHead.Focus();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtPrevVoucher.Tag == null) { MessageBox.Show("No voucher found for edit."); return; }

            Voucher _voucher = (Voucher)txtPrevVoucher.Tag;

            PrintVoucher(_voucher, "Payment Voucher");

            ClearForm();
        }

        private void txtVoucherId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                cmbDebitAccount.Focus();
            }
        }

        private void cmbDebitAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtDebitHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void dgItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {
                SelectedAccountHeadToVoucher selectedItem = dgItems.SelectedRows[0].Tag as SelectedAccountHeadToVoucher;

                if (selectedItem != null)
                {
                    txtRemarks.Text = selectedItem.Remarks;
                    txtAmount.Text = selectedItem.Amount.ToString();
                    txtAmount.Tag = selectedItem;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
