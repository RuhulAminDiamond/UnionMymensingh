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
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmCreditVoucher : Form
    {

        private IList<SelectedAccountHeadToVoucher> _SelectedItems;
        bool unlocked = true;

        private bool IsDropDownLoaded = false; 

        public frmCreditVoucher()
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
            AccountHeads.ParentAccountHeadId = Convert.ToInt32(ddlUpperAccountHead.SelectedValue);

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
            txtPrevVoucher.Text = "";
            txtPrevVoucher.Tag = null;
            txtVoucherId.Text = "";
            txtAmount.Text = "";
            txtAmount.Tag = null;
            btnSaveDebitVoucher.Enabled = true;
            btnEdit.Enabled = false;
          

            ddlUpperAccountHead.DataSource = new AccountService().GetAllAccountHead().Where(x =>x.IsPostingHead==true && (x.IsCashHead == true || x.IsBankHead == true)).ToList();
            ddlUpperAccountHead.DisplayMember = "AccountHeadName";
            ddlUpperAccountHead.ValueMember = "AccId";

          

            IsDropDownLoaded = true;


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
          

            LoadDebitHeads(0);

            ctrlAccHeadSearch.Location = new Point(txtCreditHead.Location.X, txtCreditHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }
        }

        private void CtrlAccHeadSearch_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtCreditHead.Text = item.AccountHeadName;
            txtCreditHead.Tag = item;
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
            //return new AccountService().GetAllAccountHead().Where(x => x.ParentAccountHeadId == UpperAccountHeadID && x.Id > MaxID).FirstOrDefault();
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
                row.CreateCells(dgItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgItems.Rows.Add(row);
            }

            CalculateTotal();

            //////CalculateAmount();
            //dgTests.ResumeLayout();
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


                    if (ddlUpperAccountHead.SelectedIndex >=0)
                    {
                   
                        Voucher masterVoucher = new Voucher();
                        masterVoucher.CompanyId = 1;
                        masterVoucher.VoucherDate = dtpVoucher.Value;
                        masterVoucher.VoucherId = txtVoucherId.Text;
                        masterVoucher.VoucherType = "Credit";
                        masterVoucher.Description = txtDescription.Text;
                        masterVoucher.CreateUser = MainForm.LoggedinUser.Name;
                        masterVoucher.AILogId = 0; // Auto Import Log Id
                        new VoucherService().AddMasterVoucher(masterVoucher);

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        detailsVoucher.VMId = masterVoucher.VMId;
                        detailsVoucher.DRCR = "D";
                        detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        detailsVoucher.AccId = Convert.ToInt32(ddlUpperAccountHead.SelectedValue.ToString());
                        detailsVoucher.reamrks = txtDescription.Text;

                        new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

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

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        }

                        MessageBox.Show("Voucher saved successful ");
                        PrintVoucher(masterVoucher, "Receive Voucher");
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

            btnSaveDebitVoucher.Enabled = true;
        }

        private void PrintVoucher(Voucher voucher, string v)
        {
            DataSet _dsVoucher = new VoucherService().GetReceiptOrCreditVoucher(voucher.VMId);

            //int c = dsReports.Tables[0].Rows.Count;

            rptReceiptOrCreditVoucher _payVoucher = new rptReceiptOrCreditVoucher();

            _payVoucher.SetDataSource(_dsVoucher.Tables[0]);

            List<SelectedAccountHeadToVoucher> _accToList = new AccountService().GetCreditAccountListByVoucher(voucher.VMId);
           // string _receiveFrom = AccUtility.GetSPayTo(_accToList);
            double _totalCredit = _accToList.Sum(x => x.Amount);

            ReportViewer rv = new ReportViewer();

            _payVoucher.SetParameterValue("description", voucher.Description);
            _payVoucher.SetParameterValue("PreparedBy", MainForm.LoggedinUser.Name);
            _payVoucher.SetParameterValue("Inwords", Spell.SpellAmount.InWrods(Convert.ToDecimal(Math.Round(_totalCredit))));

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
            
        }

        private void txtAccountHeadID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _voucherId = 0;
                int.TryParse(txtVoucherId.Text, out _voucherId);

                Voucher _v = new AccountService().GetVocherById(_voucherId);

                if (_v != null)
                {
                    if (_v.VoucherType.ToLower() == "credit") {
                        LoadVoucherDetails(_v.VMId);
                    }else
                    {
                        MessageBox.Show("It's not a credit voucher");
                    }
                }


            }
        }

        private void LoadVoucherDetails(long vMId)
        {
            IList<VoucherDetail> _vDetail = new AccountService().GetVoucherDetails(vMId);
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            long _VMId = 0;
            long.TryParse(txtPrevVoucher.Text, out _VMId);
            if (_VMId > 0) _VMId = _VMId - 1;
            LoadPreviousVoucher(_VMId);
        }

        private void LoadPreviousVoucher(long _VMId)
        {
            Voucher _voucher = null;

            if (_VMId == 0)
            {
                _voucher = new AccountService().GetLatestReceiptVoucher();

            }
            else
            {
                _voucher = new AccountService().GetVoucherById(_VMId);
            }

            if (_voucher != null && _voucher.VoucherType == "Credit")
            {

                txtPrevVoucher.Tag = _voucher;

                btnSaveDebitVoucher.Enabled = false;
                btnEdit.Enabled = true;

                txtVoucherId.Text = _voucher.VoucherId;
                dtpVoucher.Value = _voucher.VoucherDate;
                txtPrevVoucher.Text = _voucher.VMId.ToString();
                txtDescription.Text = _voucher.Description;

                VoucherDetail vdetail = new AccountService().GetDebitHeadAgainstCredits(_voucher.VMId);

                LoadDebitHeads(vdetail.AccId);

                _SelectedItems = new AccountService().GetCreditHeadList(_voucher.VMId).ToList();

                FillItemGrid();

                //  FillAccListGrid(_SelectedItems);

            }
            else
            {

                MessageBox.Show("This is not a recceipt/credit voucher.");

                //txtPrevVoucher.Text = (_VMId-1).ToString();
                return;
            }
        }

        private void LoadDebitHeads(int accId)
        {
            

            List<AccountHead> _accHeads = new AccountService().GetAllAccountHead().Where(x =>x.IsPostingHead==true && (x.IsCashHead == true || x.IsBankHead == true)).ToList();

            ddlUpperAccountHead.DataSource = _accHeads;
            ddlUpperAccountHead.DisplayMember = "AccountHeadName";
            ddlUpperAccountHead.ValueMember = "AccId";

            ddlUpperAccountHead.SelectedItem = _accHeads.Find(q => q.AccId == accId);

        }

        private void btnNextId_Click(object sender, EventArgs e)
        {

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
                _voucher.VoucherType = "Credit";
                _voucher.Description = txtDescription.Text;


                if (new VoucherService().UpdateMasterVoucher(_voucher))
                {

                    //if (new AccountService().DeleteExistingVoucherDetails(_voucher.VMId))
                    //{

                        VoucherDetail detailsVoucher = new VoucherDetail();
                        detailsVoucher.VMId = _voucher.VMId;
                        detailsVoucher.DRCR = "D";
                        detailsVoucher.Amount = Convert.ToDouble(txtTotalAmount.Text);
                        detailsVoucher.AccId = Convert.ToInt32(ddlUpperAccountHead.SelectedValue.ToString());
                        detailsVoucher.reamrks = txtDescription.Text;

                        new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);


                        List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = _voucher.VMId;
                            detailsVoucher.DRCR = "C";
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

        private void txtPrevVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _vmId = 0;
                long.TryParse(txtPrevVoucher.Text, out _vmId);

                LoadPreviousVoucher(_vmId);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtAmount.Tag == null)
                {

                    double _amount = 0;
                    double _tamount = 0;
                    double _total = 0;
                    double.TryParse(txtAmount.Text, out _amount);
                    double.TryParse(txtTotalAmount.Text, out _tamount);


                    if (txtCreditHead.Tag != null)
                    {

                        VMAccountHeads _accHead = txtCreditHead.Tag as VMAccountHeads;

                        new AccountService().PopulateSelectedItemData(_SelectedItems, _accHead, _amount, txtRemarks.Text);


                        FillItemGrid();

                       
                    }
                    else
                    {
                        MessageBox.Show("Account not selected. Plz. check and try again.");
                        txtCreditHead.Focus();
                    }

                    txtAmount.Text = "";
                    txtAmount.Tag = null;
                    txtRemarks.Text = "";
                    txtCreditHead.Text = "";
                    txtCreditHead.Tag = null;
                    txtCreditHead.Focus();
                }
                else
                {
                    double _amount = 0;
                   
                    double.TryParse(txtAmount.Text, out _amount);
                    SelectedAccountHeadToVoucher sv = txtAmount.Tag as SelectedAccountHeadToVoucher;
                    if (sv != null)
                    {
                        _SelectedItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Amount = _amount);

                        _SelectedItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Remarks = txtRemarks.Text);

                        FillItemGrid();

                    }


                    txtAmount.Text = "";
                    txtAmount.Tag = null;
                    txtRemarks.Text = "";
                    txtCreditHead.Text = "";
                    txtCreditHead.Tag = null;
                    txtCreditHead.Focus();
                }

            }
        }

        private void txtCreditHead_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtCreditHead.Text;
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
                ddlUpperAccountHead.Focus();
            }
        }

        private void ddlUpperAccountHead_KeyPress(object sender, KeyPressEventArgs e)
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
                txtCreditHead.Focus();
            }
        }

        private void txtCreditHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAmount.Focus();
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
    }
}
