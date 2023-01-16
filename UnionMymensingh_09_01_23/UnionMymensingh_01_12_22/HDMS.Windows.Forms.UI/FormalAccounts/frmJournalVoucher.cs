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
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Windows.Forms.UI.Accounting
{
    public partial class frmJournalVoucher : Form
    {

        private IList<SelectedAccountHeadToVoucher> _SelectedDebitItems;
        private IList<SelectedAccountHeadToVoucher> _SelectedCreditItems;
        private AccountHead accountDebitHeadInfo;
        private AccountHead accountCreditHeadInfo;

        bool unlocked = true;

        public frmJournalVoucher()
        {
            InitializeComponent();
            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgDebitItems.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgDebitItems.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            foreach (DataGridViewColumn c in dgCreditItems.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

            dgCreditItems.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButtonSupplier_Click(object sender, EventArgs e)
        {
            AccountHead AccountHeads = new AccountHead();


            AccountHeads.CompanyId = 1;
            AccountHeads.ParentAccountHeadId = 0;  //null; //Convert.ToInt32(ddlCreditAccountNo.SelectedValue);

            AccountHeads.Description = txtDescription.Text;



            if (new AccountService().AddNewAccountHead(AccountHeads))
            {
                MessageBox.Show("New Account Head added successfully.");
                ClearForm();
            }
        }

        private void ClearForm()
        {

            txtDescription.Text = "";

            dtpVoucher.Value = Utils.GetServerDateAndTime();

            txtCreditTotal.Text = "0";
            txtDebitTotal.Text = "0";
            txtPreviousVoucherNo.Tag = null;
            txtDebitAmount.Tag = null;

            _SelectedDebitItems.Clear();
            _SelectedCreditItems.Clear();

            dgDebitItems.Rows.Clear();
            dgCreditItems.Rows.Clear();

            txtVoucherNo.Text = "";
            txtPreviousVoucherNo.Text = "";
            txtPreviousVoucherNo.PlaceHolderText = "Enter previous voucher no.";

            btnPrint.Visible = false;
            btnClear.Visible = false;
            btnSaveJournal.Visible = true;

            lblDebit1.Visible = true;
            lblDebit2.Visible = true;
            lblDebit3.Visible = true;
            lblCredit1.Visible = true;
            lblCredit2.Visible = true;
            lblCredit3.Visible = true;
            txtDebitHead.Visible = true;
            txtRemarks.Visible = true;
            txtDebitAmount.Visible = true;
            txtCreditHead.Visible = true;
            txtCreditRemarks.Visible = true;
            txtCreditAmount.Visible = true;

            txtPreviousVoucherNo.Tag = null;
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
                btnSaveJournal.Focus();
            }
        }

        private void ctrlAccHeadSearchCredit_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtCreditHead.Text = item.AccountHeadName;
            txtCreditHead.Tag = item;
            txtCreditRemarks.Focus();
            sender.Visible = false;
        }

        private void CtrlAccHeadSearch_ItemSelected(SearchResultListControl<VMAccountHeads> sender, VMAccountHeads item)
        {
            txtDebitHead.Text = item.AccountHeadName;
            txtDebitHead.Tag = item;
            txtRemarks.Focus();
            sender.Visible = false;
        }

        private void ctrl_LostFocus(object sender, EventArgs e)
        {
            if (!(sender is Button))
            {
                var ctrl = sender as Control;
                ctrl.BackColor = Color.White;
            }
        }

        private void ctrl_GotFocus(object sender, EventArgs e)
        {
            if (!(sender is Button))
            {
                var ctrl = sender as Control;
                ctrl.BackColor = Color.Lavender;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void FillDebitItemGrid()
        {


            dgDebitItems.SuspendLayout();
            dgDebitItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedDebitItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgDebitItems, item.AccountHeadName, item.Amount, item.Remarks);

                dgDebitItems.Rows.Add(row);
            }



            CalculateDebitAmount();

        }

        private void CalculateDebitAmount()
        {
            txtDebitTotal.Text = dgDebitItems.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToDouble(t.Cells[1].Value.ToString())).ToString();
        }

        private void FillCreditItemGrid()
        {

            dgCreditItems.SuspendLayout();
            dgCreditItems.Rows.Clear();
            foreach (SelectedAccountHeadToVoucher item in _SelectedCreditItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgCreditItems, item.AccountHeadName, item.Amount, item.Remarks);
                dgCreditItems.Rows.Add(row);
            }

            CalculateCreditTotal();

        }

        private void CalculateCreditTotal()
        {
            txtCreditTotal.Text = dgCreditItems.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToDouble(t.Cells[1].Value.ToString())).ToString();
        }



        private void btnSaveDebitVoucher_Click(object sender, EventArgs e)
        {

        }

        private void btnDebit_Click(object sender, EventArgs e)
        {

        }

        private void btnCredit_Click(object sender, EventArgs e)
        {

        }

        private void btnDebitAdd_Click(object sender, EventArgs e)
        {


        }

        private void btnCreditAdd_Click(object sender, EventArgs e)
        {


        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDebitItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedAccountHeadToVoucher _SelectedItem = (SelectedAccountHeadToVoucher)e.Row.Tag;


            _SelectedDebitItems.Remove(e.Row.Tag as SelectedAccountHeadToVoucher);
        }

        private void dgCreditItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedAccountHeadToVoucher _SelectedItem = (SelectedAccountHeadToVoucher)e.Row.Tag;


            _SelectedCreditItems.Remove(e.Row.Tag as SelectedAccountHeadToVoucher);
        }

        private void txtDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtDebitAmount.Tag == null)
                {

                    double _amount = 0;
                    double _tamount = 0;
                    double _total = 0;
                    double.TryParse(txtDebitAmount.Text, out _amount);
                    double.TryParse(txtCreditTotal.Text, out _tamount);

                    VMAccountHeads _accHead = txtDebitHead.Tag as VMAccountHeads; // (AccountHead)ddlDebitAccountNo.SelectedItem;

                    if (_accHead.AccId == 0)
                    {
                        MessageBox.Show("Account not selected. Plz. check and try again.");
                    }

                    new AccountService().PopulateSelectedItemData(_SelectedDebitItems, _accHead, _amount, txtRemarks.Text);

                    FillDebitItemGrid();



                  
                }
                else
                {

                    double _amount = 0;
                    double _tamount = 0;
                    double _total = 0;
                    double.TryParse(txtDebitAmount.Text, out _amount);
                    SelectedAccountHeadToVoucher sv = txtDebitAmount.Tag as SelectedAccountHeadToVoucher;
                    if (sv != null)
                    {
                        _SelectedDebitItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Amount = _amount);

                        _SelectedDebitItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Remarks = txtRemarks.Text);

                        FillDebitItemGrid();

                    }


                }

                txtDebitAmount.Text = "";
                txtDebitAmount.Tag = null;
                txtRemarks.Text = "";
                txtDebitHead.Text = "";
                txtDebitHead.Tag = null;
            }
        }

        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtCreditAmount.Tag == null)
                {

                    double _amount = 0;
                    double _tamount = 0;
                    double _total = 0;
                    double.TryParse(txtCreditAmount.Text, out _amount);
                    double.TryParse(txtCreditTotal.Text, out _tamount);

                    if (txtCreditHead.Tag != null)
                    {

                        VMAccountHeads _accHead = txtCreditHead.Tag as VMAccountHeads;

                        new AccountService().PopulateSelectedItemData(_SelectedCreditItems, _accHead, _amount, txtCreditRemarks.Text);

                        FillCreditItemGrid();

                       
                    }
                    else
                    {
                        MessageBox.Show("Account not selected. Plz. check and try again.");
                        txtCreditHead.Focus();
                    }
                }
                else
                {
                    double _amount = 0;
                    double _tamount = 0;
                    double _total = 0;
                    double.TryParse(txtCreditAmount.Text, out _amount);
                    SelectedAccountHeadToVoucher sv = txtCreditAmount.Tag as SelectedAccountHeadToVoucher;
                    if (sv != null)
                    {
                        _SelectedCreditItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Amount = _amount);

                        _SelectedCreditItems.Where(w => w.AccountHeadID == sv.AccountHeadID).ToList().ForEach(s => s.Remarks = txtCreditRemarks.Text);

                        FillCreditItemGrid();

                    }
                }

                txtCreditAmount.Text = "";
                txtCreditAmount.Tag = null;
                txtCreditRemarks.Text = "";
                txtCreditHead.Text = "";
                txtCreditHead.Tag = null;
                txtCreditHead.Focus();
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
            ctrlAccHeadSearchCredit.Visible = false;
        }

        private void txtCreditHead_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditHead.Text.Length > 1)
            {
                if (unlocked)
                {
                    string _txt = txtCreditHead.Text;
                    HideAllDefaultHidden();
                    ctrlAccHeadSearchCredit.Visible = true;
                    ctrlAccHeadSearchCredit.txtSearch.Text = _txt;
                    ctrlAccHeadSearchCredit.txtSearch.SelectionStart = ctrlAccHeadSearchCredit.txtSearch.Text.Length;

                    ctrlAccHeadSearchCredit.LoadData();
                }
            }
        }

        private void txtCreditRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCreditAmount.Focus();
            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDebitAmount.Focus();
            }
        }

        private void btnSaveJournal_Click(object sender, EventArgs e)
        {
            try
            {
                double _totalDebit = 0;
                double _totalCredit = 0;

                double.TryParse(txtDebitTotal.Text, out _totalDebit);
                double.TryParse(txtCreditTotal.Text, out _totalCredit);

                if (dgDebitItems.Rows.Count > 0 && dgCreditItems.Rows.Count > 0)
                {
                    if (_totalDebit == _totalCredit)
                    {

                        long mvId = 0;

                        if (txtPreviousVoucherNo.Tag != null)
                        {
                            Voucher mVoucher = txtPreviousVoucherNo.Tag as Voucher;
                            mVoucher.VoucherDate = dtpVoucher.Value;
                            mVoucher.Description = txtDescription.Text;
                            mVoucher.VoucherId = "";
                            new VoucherService().UpdateMasterVoucher(mVoucher);
                            mvId = mVoucher.VMId;
                        }
                        else
                        {
                            Voucher masterVoucher = new Voucher();
                            masterVoucher.CompanyId = 1;
                            masterVoucher.VoucherDate = dtpVoucher.Value;
                            masterVoucher.VoucherId = "";
                            masterVoucher.VoucherType = "Journal";
                            masterVoucher.Description = txtDescription.Text;
                            masterVoucher.AILogId = 0; // Auto Import Log Id
                            new VoucherService().AddMasterVoucher(masterVoucher);

                            mvId = masterVoucher.VMId;
                        }

                        VoucherDetail detailsVoucher = new VoucherDetail();

                        List<VoucherDetail> _rDebitVoucherDetailList = new List<VoucherDetail>();

                        foreach (DataGridViewRow row in dgDebitItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = mvId;
                            detailsVoucher.DRCR = "D";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        }


                        foreach (DataGridViewRow row in dgCreditItems.Rows)
                        {
                            SelectedAccountHeadToVoucher selectedTests = row.Tag as SelectedAccountHeadToVoucher;

                            detailsVoucher = new VoucherDetail();
                            detailsVoucher.VMId = mvId;
                            detailsVoucher.DRCR = "C";
                            detailsVoucher.Amount = Convert.ToDouble(selectedTests.Amount);
                            detailsVoucher.AccId = Convert.ToInt32(selectedTests.AccountHeadID);
                            detailsVoucher.reamrks = selectedTests.Remarks;

                            new VoucherService().AddOrEditDetailsVoucher(detailsVoucher);

                        }

                        MessageBox.Show("Voucher Saved Successfully");
                        AccUtility.VoucherPrint(mvId, "Journal Voucher");
                        ClearForm();
                        
                    }
                    else
                    {
                        MessageBox.Show("Debit and Credit total is not equal.");
                    }
                }
                else
                {
                    MessageBox.Show("Debit or Credit Account Head Not Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generate For :" + ex.Message.ToString());
            }
        }

        private void ctrlAccHeadSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtDebitHead.Focus();
            }
        }

        private void txtPreviousVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long.TryParse(txtPreviousVoucherNo.Text, out long voucherNo);
                Voucher masterVoucher = new AccountService().GetVoucherById(voucherNo);

                if (masterVoucher != null && masterVoucher.VoucherType == "Journal")
                {
                    txtDescription.Text = masterVoucher.Description;
                    dtpVoucher.Value = masterVoucher.VoucherDate;
                    txtVoucherNo.Text = masterVoucher.VMId.ToString();
                    txtPreviousVoucherNo.Text = "";
                    txtPreviousVoucherNo.PlaceHolderText = "Enter previous voucher no.";
                    btnPrint.Visible = true;
                    btnClear.Visible = true;
                    //btnSaveJournal.Visible = false;

                    //lblDebit1.Visible = false;
                    //lblDebit2.Visible = false;
                    //lblDebit3.Visible = false;
                    //lblCredit1.Visible = false;
                    //lblCredit2.Visible = false;
                    //lblCredit3.Visible = false;
                    //txtDebitHead.Visible = false;
                    //txtRemarks.Visible = false;
                    //txtDebitAmount.Visible = false;
                    //txtCreditHead.Visible = false;
                    //txtCreditRemarks.Visible = false;
                    //txtCreditAmount.Visible = false;
                    
                    txtPreviousVoucherNo.Tag = masterVoucher;

                    _SelectedDebitItems = new AccountService().GetDebitHeadList(masterVoucher.VMId);
                    FillDebitItemGrid();

                    _SelectedCreditItems = new AccountService().GetCreditHeadList(masterVoucher.VMId);
                    FillCreditItemGrid();
                }
                else
                {
                    MessageBox.Show("Journal voucher not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void LoadPreviousVoucher(long _VMId)
        //{
        //    Voucher _voucher = new AccountService().GetVoucherById(_VMId);


        //    if (_voucher != null && _voucher.VoucherType == "Debit")
        //    {
        //        txtPreviousVoucherNo.Tag = _voucher;

        //        btnSaveDebitVoucher.Enabled = false;
        //        btnEdit.Enabled = true;

        //        txtVoucherId.Text = _voucher.VoucherId;
        //        dtpVoucher.Value = _voucher.VoucherDate;
        //        txtPrevVoucher.Text = _voucher.VMId.ToString();
        //        txtDescription.Text = _voucher.Description;
        //        txtName.Text = _voucher.Name;

        //        VoucherDetail vdetail = new AccountService().GetCreditHeadAgainstDebits(_voucher.VMId);

        //        LoadCreditHeads(vdetail.AccId);

        //        _SelectedItems = new AccountService().GetDebitHeadList(_voucher.VMId).ToList();

        //        FillItemGrid();
        //    }
        //    else
        //    {
        //        MessageBox.Show("This is not a debit voucher.");
        //        return;
        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Voucher voucher = txtPreviousVoucherNo.Tag as Voucher;
            AccUtility.VoucherPrint(voucher.VMId, "Journal Voucher");

            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void frmJournalVoucher_Load(object sender, EventArgs e)
        {
            _SelectedDebitItems = new List<SelectedAccountHeadToVoucher>();
            _SelectedCreditItems = new List<SelectedAccountHeadToVoucher>();
            accountDebitHeadInfo = new AccountHead();
            accountCreditHeadInfo = new AccountHead();

            ctrlAccHeadSearch.Location = new Point(txtDebitHead.Location.X, txtDebitHead.Location.Y);
            ctrlAccHeadSearch.ItemSelected += CtrlAccHeadSearch_ItemSelected;

            ctrlAccHeadSearchCredit.Location = new Point(txtCreditHead.Location.X, txtCreditHead.Location.Y);
            ctrlAccHeadSearchCredit.ItemSelected += ctrlAccHeadSearchCredit_ItemSelected;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }
        }

        private void ctrlAccHeadSearchCredit_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAccHeadSearchCredit_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCreditHead.Focus();
            }
        }

        private void dgDebitItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgDebitItems.Rows.Count > 0)
            {
                SelectedAccountHeadToVoucher _selectedVoucherItem = dgDebitItems.SelectedRows[0].Tag as SelectedAccountHeadToVoucher;

                if (_selectedVoucherItem != null)
                {
                    txtRemarks.Text = _selectedVoucherItem.Remarks;
                    txtDebitAmount.Text = _selectedVoucherItem.Amount.ToString();
                    txtDebitAmount.Tag = _selectedVoucherItem;
                }
            }
            
        }

        private void dgCreditItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgCreditItems.Rows.Count > 0)
            {
                SelectedAccountHeadToVoucher _selectedVoucherItem = dgCreditItems.SelectedRows[0].Tag as SelectedAccountHeadToVoucher;

                if (_selectedVoucherItem != null)
                {
                    txtCreditRemarks.Text = _selectedVoucherItem.Remarks;
                    txtCreditAmount.Text = _selectedVoucherItem.Amount.ToString();
                    txtCreditAmount.Tag = _selectedVoucherItem;
                }
            }
        }
    }
}
