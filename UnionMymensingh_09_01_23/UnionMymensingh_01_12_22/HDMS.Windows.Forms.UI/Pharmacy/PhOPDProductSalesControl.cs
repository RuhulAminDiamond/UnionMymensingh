using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.POS;
using HDMS.Service.Pharmacy;
using POS;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using HDMS.Windows.Forms.UI.Reports.Rx;
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Common;
using HDMS.Service.Common;
using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Model.Pharmacy;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI.Pharmacy;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Model.Hospital;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Windows.Forms.UI.Reports.Pharmacy.IPD;
using HDMS.Common.Utils;
using HDMS.Model.HR;
using HDMS.Service.HR;
using HDMS.Service.Doctors;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Rx;
using HDMS.Service.Rx;
using System.Globalization;
using HDMS.Service.Accounting;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class PhOPDProductSalesControl : UserControl
    {
        bool unlocked = true;
        bool IsInddorSale = false;
        bool isLoaded = false;
        bool isPanelMinimized = true;
        bool IsIndoorCashSale = false;
        bool IsIPDSale = false;
        string IPDRequisitionDeliveryStatus= RequisitionStatusEnum.Served.ToString();
        bool isEditMode = false;
        string _accparticulars = string.Empty;
        public PhOPDProductSalesControl()
        {
            InitializeComponent();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgSales.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);

            }

           

            dgSales.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
           
        }

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;
            //if (e.KeyChar == (char)Keys.Space)
            //{
            //    HideAllDefaultHidden();
            //    ctlProductSearchControl.Visible = true;
            //    ctlProductSearchControl.LoadDataByType(txtProductCode.Text + ">" + _outLet.OutLetId.ToString());
            //}

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(txtProductCode.Text))
                {
                    txtReceiveTk.Focus();
                }else
                {
                    HideAllDefaultHidden();
                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.LoadDataByType(txtProductCode.Text + ">" + _outLet.OutLetId.ToString());
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
            ctlEmployeeSearchControl.Visible = false;
            ctlMemberSearchControl.Visible = false;
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;

        public Action<object> EntryCompleted { get; internal set; }

        private async void PhProductSalesControl_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

            isLoaded = false;

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();


            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctlEmployeeSearchControl.Location = new Point(txtEmployeeNo.Location.X, txtEmployeeNo.Location.Y);
            ctlPhMemberSearch.Location = new Point(txtMember.Location.X, txtMember.Location.Y);

            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;
            ctlEmployeeSearchControl.ItemSelected += ctlEmployeeSearchControl_ItemSelected;
            ctlPhMemberSearch.ItemSelected += ctlPhMemberSearch_ItemSelected;

          

            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStaffName.Text = MainForm.LoggedinUser.Name;
            LoadInvoiceType();

            txtInvoiceNo.Text = ""; //GetNewBillNo();

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

           
            IsInddorSale = false;

            LoadOutlets(2);

            MedicineOutlet _moutLet =   (MedicineOutlet)cmbOutlet.SelectedItem;

            

            LoadPaymentModes();

           InitializeControlTagValue();

            isLoaded = true;

            
            await LoadMedicineStocks();

            if (!new PhProductService().IsOpeningStockSet(Utils.GetServerDateAndTime()))
            {
                await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());
            }
        }

        private void LoadPaymentModes()
        {
            List<PaymentMode> _paymodes = new CommonService().GetPaymentModes();
            _paymodes.Insert(0, new PaymentMode() { PMId = 0, Name = "Select Mode" });
            cmbPaymentMode.DataSource = _paymodes;
            cmbPaymentMode.DisplayMember = "Name";
            cmbPaymentMode.ValueMember = "PMId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);
            if (_user != null)
            {
                if(_user.RoleId==20 || _user.RoleId == 21)
                {
                    if (_user.AssignedOutLet == 2)
                    {
                        cmbPaymentMode.SelectedItem = _paymodes.Find(q => q.PMId == 1);

                    }
                    else if(_user.AssignedOutLet == 1)
                    {
                        cmbPaymentMode.SelectedItem = _paymodes.Find(q => q.PMId == 4);
                    }
                    
                }
            }

        }

       

        private async Task<bool> LoadMedicineStocks()
        {
            string brandName = "";
            MedicineOutlet _outLet = cmbOutlet.SelectedItem as MedicineOutlet;
            if (_outLet.OutLetId > 0)
            {
                List<VWPhProductListForSale> _ItemList = new PhProductService().GetPhItemForSale(brandName + ">" + _outLet.OutLetId.ToString()).ToList();
                lblOutletItems.Tag = _ItemList;
            }

            return await Task.FromResult(true);
        }

     

        

        private void InitializeControlTagValue()
        {
           
            txtMember.Tag = null;
            txtEmployeeNo.Tag = null;
        }

       

        private void ctlPhMemberSearch_ItemSelected(SearchResultListControl<PhMemberInfo> sender, PhMemberInfo item)
        {
            txtMember.Text = item.Name;
            txtCustomerName.Text = item.Name;
            txtMember.Tag = item;
            txtProductCode.Focus();
            sender.Visible = false;
        }

        private void ctlEmployeeSearchControl_ItemSelected(SearchResultListControl<VMEmployeeInfo> sender, VMEmployeeInfo item)
        {
            txtEmployeeNo.Text = item.EmployeeName;
            txtEmployeeNo.Tag = item;
            PhMemberInfo _memberInfo = new PhFinancialService().GetPhMemberByEmployeeId(item.EmployeeId);
            if (_memberInfo != null)
            {
                txtMember.Text = _memberInfo.Name;
                txtCustomerName.Text = _memberInfo.Name;
                txtMember.Tag = _memberInfo;
                txtProductCode.Focus();
                sender.Visible = false;
            }
            else
            {
                MessageBox.Show("Member entry not found against this employee.");
                txtMember.Text = "";
                txtMember.Tag = null;
                txtEmployeeNo.Focus();
                sender.Visible = false;
                return;
            }

          
        }

        
        private void LoadOutlets(int outletId)
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });

            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

           // User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            cmbOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == outletId);
            cmbOutlet.Enabled = false;


            //if (_user.AssignedOutLet == 0)
            //{
            //    cmbOutlet.Enabled = true;
            //}
            //else
            //{
            //    cmbOutlet.Enabled = false;
            //}

            //if(_user.AssignedOutLet == 2 || _user.AssignedOutLet == 3)
            //{
            //    IsInddorSale = false;
            //}

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

        private string GetNewBillNo()
        {
            string _billPart1 = Utils.GetBillNo();
            long _billNo = new Random().Next(10000, 99999);
            string _billPart2 = _billNo.ToString() + Configuration.ORG_CODE;

            string _BillNo = _billPart1 + _billPart2;

            if (!new PhProductService().IsPhBillNoAlloted(Convert.ToInt64(_BillNo)))
            {
                return _BillNo.ToString();
            }

            GetNewBillNo();

            return "";
        }

        private void LoadInvoiceType()
        {
            List<PhInvoiceType> ItList = new PhProductService().GetInvoiceType().ToList();
            ItList.Insert(0, new PhInvoiceType() { InvoceTypeId = 0, InvoiceType = "Select Type" });
            cbInvoiceType.DataSource = ItList;
            cbInvoiceType.DisplayMember = "InvoiceType";
            cbInvoiceType.ValueMember = "InvoceTypeId";

            cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == 1);
            cbInvoiceType.Enabled = false;
            cbInvoiceType.Tag = 0;

            //User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            //if (_user.AssignedOutLet == 2 || _user.AssignedOutLet==3)
            //{

            //    cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == 2);
            //    cbInvoiceType.Enabled = false;
            //}
            //else
            //{
            //    cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == 1);
            //    cbInvoiceType.Enabled = true;
            //}



        }

        private void ctlProductSearchControl_ItemSelected(SearchResultListControlForPharmacy<VWPhProductListForSale> sender, VWPhProductListForSale item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            txtDrescription.Text = item.BrandName;
            txtUnitPrice.Text = item.SalePrice.ToString();
            txtQuantity.Focus();

            UpdateStockOnUILabel(item);

            sender.Visible = false;
        }

        private void UpdateStockOnUILabel(VWPhProductListForSale item)
        {
            PhStockInfo _st = new PhProductService().GetPhStockByStckId(item.StckId);
            lblStockAvailable.Text = _st.CurrentStock.ToString();
            lblPurchaseRate.Text = _st.PurchaseRate.ToString();

            List<VWPhProductListForSale> pList = lblOutletItems.Tag as List<VWPhProductListForSale>;

            pList.Where(w => w.StckId == item.StckId).ToList().ForEach(s => s.StockAvailable = _st.CurrentStock);

            lblOutletItems.Tag = pList;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtProductCode.Tag == null) return;

                VWPhProductListForSale _PL = (VWPhProductListForSale)txtProductCode.Tag;

                double _qty = 0, _rate = 0, _total = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _rate);

                if (isEditMode)
                {
                    List<PhSelectedProductsToSaleOrReceiveOrOrder> _removeList = _SelectedItems.Where(x => x.Id == _PL.ProductId).ToList();
                    foreach (var item in _removeList)
                    {
                        if (item.Id == _PL.ProductId)
                        {
                            _SelectedItems.Remove(item);
                        }
                    }

                    isEditMode = false;
                }


                if (_qty == 0)
                {
                    MessageBox.Show("Quantity Blank.");
                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";
                    txtDrescription.Text = "";
                    unlocked = false;
                    txtProductCode.Text = "";
                    unlocked = true;
                    txtProductCode.Focus();
                    return;
                }

                if (_PL.StockAvailable < _qty)
                {


                    new PhProductService().PopulateSelectedItemDataForSaleFromMultipleLot(_SelectedItems, txtProductCode.Tag as VWPhProductListForSale, _rate, _qty);

                    FillItemGrid();

                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";
                    txtDrescription.Text = "";
                    txtProductCode.Text = "";
                    txtProductCode.Focus();

                    txtProductCode.Tag = null;

                    unlocked = true;

                    return;
                }



                new PhProductService().PopulateSelectedItemDataForSale(_SelectedItems, txtProductCode.Tag as VWPhProductListForSale, _rate, _qty);
                FillItemGrid();

                unlocked = false;

                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
                txtDrescription.Text = "";
                txtProductCode.Text = "";
                txtProductCode.Focus();

                txtProductCode.Tag = null;

                unlocked = true;
            }
        }

        private void FillItemGrid()
        {
            dgSales.SuspendLayout();
            dgSales.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                if (item.Qty > 0)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.Tag = item;
                    row.CreateCells(dgSales, item.Id, item.Name,  item.ExpireDate.ToString("dd/MM/yyyy"), item.SRate, item.Qty, item.Total, item.BatchNo, item.PTotal);
                    dgSales.Rows.Add(row);
                }
            }

            CalculateAmount();
        }

        private void CalculateAmount()
        {

            txtTotalItem.Text = _SelectedItems.Count().ToString();

            double _total = 0,_purchaseTotal=0;

            _total=Math.Round(dgSales.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[5].Value)),2);
            
            _purchaseTotal= Math.Round(dgSales.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[7].Value)), 2);

            double x = _total - Math.Truncate(_total);

            if (x < 0.5)
            {
                _total = _total - x;

            }else
            {
                _total = _total - x + 1;
            }

            txtSubTotal.Text = _total.ToString();

            txtSubTotal.Tag = Math.Round(_purchaseTotal, 2);  // Invoice cost price anchored here.

            txtGrandTotal.Text = _total.ToString();

            txtDueTk.Text = _total.ToString();
            txtPurchaseTotal.Text = Math.Round(_purchaseTotal, 3).ToString();


           //if (!IsInddorSale)
           //    txtReceiveTk.Text = _total.ToString();


            // txtDiscount.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                //if (dgSalesControl.Rows.Count > 0 && txtCustomer.Tag != null)
                //{

                //}

                if (dgSales.Rows.Count > 0)
                {

                    DialogResult result = MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {

                        btnSave.Enabled = false;
                        btnSave.Text = "Wait Please...";

                        //SetInvoiceType();

                        long _billNo = 0;
                        long _admissionNo = 0;
                        long _requisitionNo = 0;
                        
                        double _subtotalTk = 0;
                        double _discountTk = 0;
                        double _cashreceivedTk = 0;
                        double _cardormobreceiveTk = 0;
                        double _cardormobileServiceChargeTk = 0;
                        double _dueTk = 0;
                       
                        double _changeTk = 0;
                        double _grandtotal = 0;
                        int _memberId = 0;

                      

                        PhInvoiceType _invType = (PhInvoiceType)cbInvoiceType.SelectedItem;




                        if (_invType.InvoceTypeId == 0)
                        {

                            MessageBox.Show("Please select invoice type.");
                            cbInvoiceType.Focus();
                            btnSave.Enabled = true;
                            btnSave.Text = "Save";
                            return;
                        }


                     
                        MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                        if (_outLet.OutLetId == 0)
                        {
                            MessageBox.Show("Select outlet");
                            btnSave.Enabled = true;
                            btnSave.Text = "Save";
                            cmbOutlet.Focus();
                            return;
                        }

                       
                            double.TryParse(txtDueTk.Text, out _dueTk);

                            if (_dueTk > 0)
                            {
                                if( txtMember.Tag==null) {
                                    MessageBox.Show("It's due sale.Member No. Required.");
                                     btnSave.Enabled = true;
                                     btnSave.Text = "Save";
                                     return;
                                }
                            }

                        string _opdCustomer = string.Empty;
                        if(txtMember.Tag==null && txtEmployeeNo.Tag == null)
                        {
                            _opdCustomer = txtCustomerName.Text;
                        }

                        double.TryParse(txtSubTotal.Text, out _subtotalTk);
                        double.TryParse(txtDiscount.Text, out _discountTk);
                        double.TryParse(txtReceiveTk.Text, out _cashreceivedTk);
                        double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardormobreceiveTk);
                        double.TryParse(txtCardOrMobileCharge.Text, out _cardormobileServiceChargeTk);
                        double.TryParse(txtGrandTotal.Text, out _grandtotal);
                        //int.TryParse(txtAdjustInv.Text, out _returnedInvoice);
                        //double.TryParse(txtAdjustedTk.Text, out _retunedAdjustedTk);
                        double.TryParse(txtChangeTk.Text, out _changeTk);
                        double.TryParse(txtDueTk.Text, out _dueTk);

                        long.TryParse(txtInvoiceNo.Text, out _billNo);
                       

                        PhMemberInfo _member = new PhMemberInfo();
                        if (txtMember.Tag != null)
                        {
                            _member = (PhMemberInfo)txtMember.Tag;
                            _memberId = _member.MemberId;
                            _opdCustomer = _member.Name;
                        }

                        if (_admissionNo > 0 && _dueTk == 0)
                        {
                            MessageBox.Show("It's an Indoor sale. Plz. do not make any payment against this sale.");
                            btnSave.Enabled = true;
                            btnSave.Text = "Save";
                            return;
                        }


                        if (_memberId > 0)
                        {
                            IsInddorSale = false;
                        }

                        if (_outLet.OutLetId == 1 || _outLet.OutLetId == 3 || _outLet.OutLetId == 9) // Indoor Admitted Patient
                        {
                            IsIndoorCashSale = false;

                            //if (Convert.ToInt32(cbInvoiceType.Tag) == 0 && _admissionNo == 0 && _dueTk > 0)
                            //{
                            //    MessageBox.Show("Valid admission no required for indoor patient.");
                            //    btnSave.Enabled = true;
                            //    btnSave.Text = "Save";
                            //    return;
                            //}

                            if (_dueTk == 0 && _memberId==0)
                            {
                                IsIndoorCashSale = true;
                            }

                        }

                        int _invoiceTypeTagVal = 0;
                        if (cbInvoiceType.Tag != null) {

                            int.TryParse(cbInvoiceType.Tag.ToString(), out _invoiceTypeTagVal);
                        
                        }

                       
                        double _costAmount = 0;
                        double.TryParse(txtSubTotal.Tag.ToString(), out _costAmount);


                        _dueTk = CalculateDueAndChange();

                        double CashpaidTk = 0;
                        if (_cashreceivedTk > 0)
                        {
                            if (_cashreceivedTk >= _grandtotal)
                            {
                                CashpaidTk = _grandtotal;
                            }
                            else
                            {
                                CashpaidTk = _cashreceivedTk;
                            }
                        }
                        
                       

                       

                        int _PCId = 0;
                        PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
                        if (_pChannel != null)
                        {
                            _PCId = _pChannel.PCId;
                        }

                        // Initialize voucher object
                        VMPhEndpointDataCarrier voucherObj = new VMPhEndpointDataCarrier(); // For Accounts
                       
                        voucherObj.ReceivableAccId = 0;
                        voucherObj.StockAccId = 128;
                        voucherObj.StockExpAccId = 1973;
                        voucherObj.CashAccId = 1969;
                        voucherObj.DiscountAccId = 1968;
                        voucherObj.IPDSaleAccountId = 100;
                        voucherObj.OPDSaleAccountId = 101;
                        voucherObj.OutletId = _outLet.OutLetId;
                        voucherObj.SaleAmount = _subtotalTk;
                        voucherObj.CashReceiveAmount = _cashreceivedTk;
                        voucherObj.CardOrMobileReceiveAmount = _cardormobreceiveTk;
                        voucherObj.CardOrMobileServiceCharge = _cardormobileServiceChargeTk;
                        voucherObj.ChangeCashAmount = _changeTk;
                        voucherObj.CashPaidAmount = CashpaidTk;
                        voucherObj.CashPayChannelId = 1;
                        voucherObj.OthersPayChannelId = 12;
                        voucherObj.CardOrMobilePaidAmount = _cardormobreceiveTk;
                        voucherObj.DueAmount = _dueTk;
                        voucherObj.DiscountAmount = _discountTk;
                        voucherObj.CostAmount = _costAmount;
                        voucherObj.SaleOrIssueRemarks = "Pharmacy Sales";
                        voucherObj.SaleOrReceiveNo = "";
                        voucherObj.PhIPDRemarks = "";
                        voucherObj.PhOPDRemarks = "";
                        voucherObj.BillingDept = BillingDeptEnum.Pharmacy.ToString();
                        voucherObj.IsIpdSale = false;
                        voucherObj.IsStaffSale = false;
                        voucherObj.TransactionDateTime = Utils.GetServerDateAndTime();
                        voucherObj.TransactionBy = MainForm.LoggedinUser.Name;
                        voucherObj.InvoiceType = _invType;
                        voucherObj.InvoiceTypeTagVal = _invoiceTypeTagVal;
                        voucherObj.PCId = _PCId;
                        voucherObj.TransactionNo = txtTransactionNo.Text;
                        //Start of Sale 

                        PhInvoice pi = new PhInvoice();
                        pi.BillNo = 0;
                        pi.AdmissionNo = _admissionNo;
                        pi.InvoiceType = ((PhInvoiceType)cbInvoiceType.SelectedItem).InvoiceTypeShortName;
                        pi.TotalTK = _subtotalTk;
                        pi.Invdate = Utils.GetServerDateAndTime();
                        pi.InvTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        pi.GrandTK = _grandtotal;
                        pi.ReceivedTK = _cashreceivedTk;
                        pi.CardOrMobileReceiveTk = _cardormobreceiveTk;
                        pi.CardOrMobileServiceChargeTk = _cardormobileServiceChargeTk;
                        pi.ChangeTK = _changeTk;
                        pi.CustomerID = _memberId;
                        pi.OPDCustomerName = _opdCustomer;
                        pi.DueTK = _dueTk;
                        pi.DiscountTK = _discountTk;
                        pi.UserId = MainForm.LoggedinUser.UserId;
                        pi.OutLetId = _outLet.OutLetId;
                        pi.RequisitionNo = _requisitionNo;
                      
                        

                        //long invocieId = new PhProductService().AddNewInvoice(pi);
                        //if (invocieId > 0)
                        //{
                            
                            //PhInvoice _invce = new PhProductService().GetPhInvoiceByInvoiceId(invocieId);
                            //txtInvoiceNo.Text = _invce.BillNo.ToString();

                            List<PhInvoiceDetail> _invDetailsList = new List<PhInvoiceDetail>();
                            foreach (DataGridViewRow row in dgSales.Rows)
                            {
                                PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
                             
                                PhInvoiceDetail pid = new PhInvoiceDetail();
                                pid.InvoiceId = 0;
                                pid.ProductId = selectedTests.Id;
                                pid.LotNo = selectedTests.LotNo;
                                pid.Qty = selectedTests.Qty;
                                pid.SaleRate = selectedTests.SRate;
                                pid.TotalPrice = selectedTests.Qty * selectedTests.SRate;
                                pid.Discount = selectedTests.Discount;
                                pid.PurchaseRate = selectedTests.PRate;
                               
                                _invDetailsList.Add(pid);

                               

                            }
                            

                          


                                if (_memberId > 0)
                                {

                                    voucherObj.PhMemberInfo = _member;


                                    if (_dueTk > 0 && MainForm.orgSetting.IsIntegratedAccountInAction)
                                    {
                                        voucherObj.ReceivableAccId = 1964;
                                       
                                    }

                                    voucherObj.IsStaffSale = true;

                                }


                        if (chkStockAvailability(_invDetailsList, voucherObj, out string msg))
                        {
                            PhInvoice _Invoice = await new PhFinancialService().SaveAndCommitOPDNewSale(pi, _invDetailsList, voucherObj, MainForm.orgSetting.IsIntegratedAccountInAction);




                            if (_Invoice.InvoiceId > 0)
                            {
                                long invocieId = _Invoice.InvoiceId;

                                
                                    if (Configuration.ORG_CODE == "1")
                                    {
                                        PrintSaleInvoiceToshiba(invocieId);

                                    }
                                    else if (Configuration.ORG_CODE == "2")
                                    {
                                        PrintSaleInvoiceRongta(invocieId);
                                    }

                            }

                            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                            IsCachedStockUpdated = false;  // For Stock Cached in UI lbloutlet tag


                            ClearFields();


                            unlocked = true;

                            if (!new PhProductService().IsOpeningStockSet(Utils.GetServerDateAndTime()))
                            {
                                await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());
                            }


                        }
                        else
                        {
                            MessageBox.Show(msg);
                        }

                        btnSave.Enabled = true;
                        btnSave.Text = "Save";

                       
                    }

                }else
                {
                    MessageBox.Show("No item selected for sale.");
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                }
            }
            catch(Exception ex) 
            {
                //MessageBox.Show(" Invoice not save as " + ex.Message.ToString());
            }
        }

        private bool chkStockAvailability(List<PhInvoiceDetail> invDetails, VMPhEndpointDataCarrier voucherObj, out string msg)
        {
            string getmsgStr = new PhProductService().CheckStockAvailability(invDetails, voucherObj);

            msg = getmsgStr;

            if(string.IsNullOrEmpty(getmsgStr))
               return true;

            return false;
        }

        private void SetInvoiceType()
        {

            List<PhInvoiceType> ItList = new PhProductService().GetInvoiceType().ToList();
            ItList.Insert(0, new PhInvoiceType() { InvoceTypeId = 0, InvoiceType = "Select Type" });
            cbInvoiceType.DataSource = ItList;
            cbInvoiceType.DisplayMember = "InvoiceType";
            cbInvoiceType.ValueMember = "InvoceTypeId";

           
            cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == 1);
            cbInvoiceType.Enabled = false;
        }

       

       

        private void SaveThisSaleAsOTStock()
        {
            double _totalTk = 0;
            double.TryParse(txtDueTk.Text, out _totalTk);

            PhReceive rcv = new PhReceive();
            rcv.RDate = Utils.GetServerDateAndTime();
            rcv.Particulars = "NR";
            rcv.SupChalanNo = "N/A";
            rcv.SupInvNo ="N/A";
            rcv.TotalTk = _totalTk;
            rcv.DiscountTk = 0;
            rcv.SupInvDate = Utils.GetServerDateAndTime();
            rcv.SupplerId = 4; //Inddor outlet
            rcv.OutLetId = 3;
            rcv.Receivedby = MainForm.LoggedinUser.Name;

            long _ReceiveId = new PhProductService().SaveReceivedInvoice(rcv);
            if (_ReceiveId > 0)
            {
                List<PhReceiveDetail> _rDeatailsList = new List<PhReceiveDetail>();
                foreach (DataGridViewRow row in dgSales.Rows)
                {
                    PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
                    PhReceiveDetail _rDetails = new PhReceiveDetail();
                    _rDetails.ReceivedId = _ReceiveId;
                    _rDetails.LotNo = selectedTests.LotNo; ;
                    _rDetails.ProductId = selectedTests.Id;
                    _rDetails.Qty = selectedTests.Qty;
                    _rDetails.PurchaseRate = selectedTests.PRate;
                    _rDetails.Total = selectedTests.Total;
                    _rDetails.disCountInpercent = selectedTests.DiscInPercentPerProduct;
                    _rDetails.grossDiscount = selectedTests.Discount;
                  
                    _rDeatailsList.Add(_rDetails);
                }
                if (new PhProductService().SaveReceiveDetails(_rDeatailsList))
                {

                    new PhProductService().UpdateOrAddToStockInfo(_SelectedItems.ToList(), 3);
                    // MessageBox.Show("Receive Successfull.");
                    //ClearFields();
                }
            }
        }

       

        private void PrintSaleInvoiceToshiba(long invocieId)
        {

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            DataSet ds = new PhReportingService().GetSaleEntryDataSetByinvocieId(invocieId);

            rptPosSaleInvoiceTosiba _rpt = new rptPosSaleInvoiceTosiba();

            _rpt.SetDataSource(ds.Tables[0]);

            PhInvoice _pInvoice = new PhReportingService().GetPhInvoiceById(invocieId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetPhCashMemoTransactionList(_pInvoice,txtDiscInPercent.Text);

            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rpt.SetParameterValue(p1, litem.Label);
                _rpt.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rpt.SetParameterValue(p3, litem.Value.ToString()+".00");
                }
                else
                {
                    _rpt.SetParameterValue(p3, litem.Value.ToString() + ".00");
                }

                if (litem.IsDue)
                {
                    isDue = true;
                }

                if (litem.IsDicounted)
                {
                    isDiscounted = true;
                }



            }

            for (int _count = _index + 1; _count <= 5; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rpt.SetParameterValue(p1, "");
                _rpt.SetParameterValue(p2, "");
                _rpt.SetParameterValue(p3, "");
            }


          
            _rpt.SetParameterValue("CompanyName", "KhandakerAlkas - Amina Hospital");
            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("CAddress", "Nabinagar, SunamganjSadar, Sunamganj.");
                _rpt.SetParameterValue("CMobile", "01323-593419");
            }
            else
            {
                _rpt.SetParameterValue("CAddress", "Nabinagar, SunamganjSadar, Sunamganj.");
                _rpt.SetParameterValue("CMobile", "01323-593419");
            }
          
            _rpt.SetParameterValue("CustomerName", txtCustomerName.Text);
            if(txtCustomerName.Tag != null)
            {
                _rpt.SetParameterValue("CustMobile", txtCustomerName.Tag.ToString());
            }
            else
            {
                _rpt.SetParameterValue("CustMobile", "");
            }
           

            //RptSaleProduct _rpt = new RptSaleProduct();


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

       
        private double CalculateDueAndChange()
        {
            double subtotalAmount = 0;
            double totalDiscount = 0;
            double totalReceived = 0;
            double totalCardOrMobileReceive = 0;
            //double totalRefundTk = 0;
            double totaldue = 0;
            double grandTotal = 0;
            double _totalChange = 0;


            double.TryParse(txtSubTotal.Text, out subtotalAmount);
            double.TryParse(txtDiscount.Text, out totalDiscount);
            double.TryParse(txtReceiveTk.Text, out totalReceived);
            double.TryParse(txtCardOrMobileReceiveTk.Text, out totalCardOrMobileReceive);
            //double.TryParse(txtAdjustedTk.Text, out totalRefundTk);

            grandTotal = subtotalAmount - totalDiscount;

            //totaldue = totalAmount - totalDiscount - totalReceived;
            if (totalReceived > grandTotal)
            {
                txtChangeTk.Text = ((totalReceived + totalCardOrMobileReceive) - grandTotal).ToString();

                _totalChange = (totalReceived + totalCardOrMobileReceive) - grandTotal;

                totaldue = 0;
            }
            else
            {
                totaldue = grandTotal - (totalReceived + totalCardOrMobileReceive);
            }

            return totaldue;

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            calculateDAndC();

        }

        private void calculateDAndC()
        {
            double totalAmount = 0;
            double totalDiscount = 0;
            double received = 0;
            double _discInPercent = 0;

            double.TryParse(txtSubTotal.Text, out totalAmount);
            double.TryParse(txtDiscount.Text, out totalDiscount);

             _discInPercent = Math.Round((totalDiscount * 100) / totalAmount, 2);

            //if (_discInPercent > 10)
            //{
            //    MessageBox.Show("Exceeds the discount limit of maximum 10%");
            //    txtDiscount.Text = "";
            //    return;
            //}

            double total = Math.Round(totalAmount - totalDiscount,2);

            if (!IsIPDSale)
            {
                txtReceiveTk.Text = total.ToString();
            }
          
            double.TryParse(txtReceiveTk.Text, out received);
            txtGrandTotal.Text = Convert.ToString(total);
            if (received > total)
            {
                txtChangeTk.Text = Convert.ToString(received - total);
                txtDueTk.Text = "0";
            }
            
            else 
            {
                txtDueTk.Text = Convert.ToString(total-received);
                txtChangeTk.Text = "0";
            }
        }

        private void txtReceiveTk_TextChanged(object sender, EventArgs e)
        {
            calculateDAndR();
        }

        private void calculateDAndR()
        {
            double totalAmount = 0;
            double totalDiscount = 0;
            double received = 0;
            double cardormobreceive = 0;
            double totalReceived = 0;

            double.TryParse(txtSubTotal.Text, out totalAmount);
            double.TryParse(txtDiscount.Text, out totalDiscount);
            double.TryParse(txtReceiveTk.Text, out received);
            double.TryParse(txtCardOrMobileReceiveTk.Text, out cardormobreceive);

            double total = Math.Round(totalAmount - totalDiscount,2);
         
            txtGrandTotal.Text = total.ToString();

            totalReceived = Math.Round(received + cardormobreceive,2);

            if (totalReceived > total)
            {
                txtChangeTk.Text = Convert.ToString(received - total);
                txtDueTk.Text = "0";
            }

            else
            {
                txtDueTk.Text = Convert.ToString(total - totalReceived);
                txtChangeTk.Text = "0";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCustomerAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbInvoiceType_TextChanged(object sender, EventArgs e)
        {
            if (cbInvoiceType.SelectedIndex == 1)
            {
                txtProductCode.Focus();
            }         
           
            else
            {
                txtEmployeeNo.Focus();
            }
        }

        

        private string GetAddress(HospitalPatientInfo _pInfo)
        {
           
                return "Ward/" + new HospitalCabinBedService().GetWardBedInfo(_pInfo.WardOrCabinId).Description ;
            
        }

        bool IsCachedStockUpdated = false;
        private async void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {

                //if (!IsCachedStockUpdated)
                //{
                //    await LoadMedicineStocks();
                //    IsCachedStockUpdated = true;
                //}

                if (lblOutletItems.Tag == null)
                {
                    MessageBox.Show("Plz. select outlet and try again."); return;
                }
                
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();
                    await LoadMedicineStocks();
                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByTypeFromSuppliedList(_txt+">"+ _outLet.OutLetId.ToString(), lblOutletItems.Tag as List<VWPhProductListForSale>); // Out let Id appended for outlet specific product loading
                    //this.Refresh();
                }
            }
        }

        private void txtReceiveTk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            PhInvoice _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                _Invoice = new PhProductService().GetPhOPDLastestInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtInvoiceNo.Text, out _billNo);
                _Invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new PhProductService().GetPhOPDLastestInvoice();
                }
                else
                {
                    _Invoice = new PhProductService().GetPhInvoiceByInvoiceId(_Invoice.InvoiceId - 1);
                }

            }

            if (_Invoice != null)
            {
                txtInvoiceNo.Text = _Invoice.BillNo.ToString();
                txtCustomerInvoiceNo.Text = _Invoice.InvoiceId.ToString();
                txtCustomerName.Text = _Invoice.OPDCustomerName;
               
                LoadPrevoiusBillInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invoice not found.");
                _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
                ClearFields();

                btnSave.Enabled = true;
            }
        }

        private void LoadPrevoiusBillInfo(PhInvoice _phInvoice)
        {
            if (_phInvoice == null) return;

            List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(_phInvoice.InvoiceId).ToList();
            // List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(_InvoiceNo).ToList();
            _SelectedItems  = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            foreach (var lineitem in _Invoicedetails)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _sItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
                PhProductInfo _pInfo = new PhProductService().GetProductById(lineitem.ProductId);
                if (_pInfo != null)
                {
                    _sItem.Id = lineitem.ProductId;
                    _sItem.LotNo = 1;
                  
                    _sItem.Code = lineitem.ProductId.ToString();
                    _sItem.Name = _pInfo.BrandName;
                    _sItem.Qty = lineitem.Qty;
                    _sItem.Unit = _pInfo.Unit;
                    _sItem.SRate = lineitem.SaleRate;
                    _sItem.Total = lineitem.TotalPrice;
                    _SelectedItems.Add(_sItem);
                }
            }

            FillItemGrid();


        }

        private void ClearFields()
        {
            unlocked = false;
            txtMember.Text = "";
            txtInvoiceNo.Text = "";

            txtEmployeeNo.Text = "";
            txtEmployeeNo.Tag = null;
           
            txtGrandTotal.Text = "";

            dgSales.Rows.Clear();
            txtReceiveTk.Text = "";
            txtDueTk.Text = "";
            txtSubTotal.Text = "";
            txtGrandTotal.Text = "";
            txtDiscInPercent.Text = "";
            txtDiscount.Text = "";
            unlocked = false;
            txtProductCode.Text = "";
            txtProductCode.Focus();
            txtInvoiceNo.Text = "";//GetNewBillNo();
            
            IsIPDSale = false;
            txtEmployeeNo.Text = "";
            txtDiscInPercent.Text = "";
            txtMember.Text = "";
            txtMember.Tag = null;
            txtTransactionNo.Text = "";

            txtCardOrMobileCharge.Text = "";
            txtCardOrMobileReceiveTk.Text = "";
            LoadPaymentModes();

            btnSave.Enabled = true;
            btnSave.Text = "Save";

            
           
            unlocked = true;
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            PhInvoice _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                _Invoice = new PhProductService().GetPhFirstInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtInvoiceNo.Text, out _billNo);
                _Invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new PhProductService().GetPhOPDLastestInvoice();
                }
                else
                {
                    _Invoice = new PhProductService().GetPhInvoiceByInvoiceId(_Invoice.InvoiceId + 1);
                }
            }

            if (_Invoice != null)
            {
                txtInvoiceNo.Text = _Invoice.BillNo.ToString();
                txtCustomerInvoiceNo.Text = _Invoice.InvoiceId.ToString();
                txtCustomerName.Text = _Invoice.OPDCustomerName;
                LoadPrevoiusBillInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invoice not found.");
                _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
                ClearFields();

                btnSave.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PhInvoice _Invoice = null;

                long _billNo = 0;
                long.TryParse(txtInvoiceNo.Text, out _billNo);
                _Invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);
                if (_Invoice == null)
                {
                      MessageBox.Show("Invoice not found. Plz. check Invoice No and try again."); return;
                }

           
                if (Configuration.ORG_CODE == "1")
                {
                    PrintSaleInvoiceToshiba(_Invoice.InvoiceId);

                }else if(Configuration.ORG_CODE == "2")
                {
                    PrintSaleInvoiceRongta(_Invoice.InvoiceId);
                }
            
          
        }

        private void PrintSaleInvoiceRongta(long invoiceId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            DataSet ds = new PhReportingService().GetSaleEntryDataSetByinvocieId(invoiceId);

            rptPosSaleInvoice _rpt = new rptPosSaleInvoice();

            _rpt.SetDataSource(ds.Tables[0]);

            PhInvoice _pInvoice = new PhReportingService().GetPhInvoiceById(invoiceId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetPhCashMemoTransactionList(_pInvoice, txtDiscInPercent.Text);

            foreach (var litem in _cashtranList)
            {

                _index++;
                p1 = pLabel + _index.ToString();
                p2 = pDivider + _index.ToString();
                p3 = pValue + _index.ToString();



                _rpt.SetParameterValue(p1, litem.Label);
                _rpt.SetParameterValue(p2, ":");
                if (_index == 1)
                { // for test cost value not taking from this parameter
                    _rpt.SetParameterValue(p3, litem.Value.ToString() + ".00");
                }
                else
                {
                    _rpt.SetParameterValue(p3, litem.Value.ToString() + ".00");
                }

                if (litem.IsDue)
                {
                    isDue = true;
                }

                if (litem.IsDicounted)
                {
                    isDiscounted = true;
                }



            }

            for (int _count = _index + 1; _count <= 5; _count++)
            {
                p1 = pLabel + _count.ToString();
                p2 = pDivider + _count.ToString();
                p3 = pValue + _count.ToString();

                _rpt.SetParameterValue(p1, "");
                _rpt.SetParameterValue(p2, "");
                _rpt.SetParameterValue(p3, "");
            }



            _rpt.SetParameterValue("CompanyName", "KhandakerAlkas - Amina Hospital");
            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("CAddress", "Nabinagar, SunamganjSadar, Sunamganj.");
                _rpt.SetParameterValue("CMobile", "01323-593419");
            }
            else
            {
                _rpt.SetParameterValue("CAddress", "Nabinagar, SunamganjSadar, Sunamganj.");
                _rpt.SetParameterValue("CMobile", "01323-593419");
            }

            _rpt.SetParameterValue("CustomerName", txtCustomerName.Text);
            if (txtCustomerName.Tag != null)
            {
                _rpt.SetParameterValue("CustMobile", txtCustomerName.Tag.ToString());
            }
            else
            {
                _rpt.SetParameterValue("CustMobile", "");
            }


            //RptSaleProduct _rpt = new RptSaleProduct();


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgSales.Rows.Clear();
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            btnSave.Enabled = true;
          
            txtDiscount.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtDrescription.Text = "";
           
            lblAssignedDoc.Text = "";
           
            txtCustomerName.Text = "";
            txtEmployeeNo.Text = "";
            txtEmployeeNo.Tag = null;
           
            txtDueTk.Text = "";
            txtSubTotal.Text = "";
            txtDiscInPercent.Text = "";
            txtReceiveTk.Text = "";
            // dgRequistions.Visible = false;
            //  dgRequisitionList.Visible = false;

            unlocked = false;
            txtProductCode.Text = "";
            unlocked = true;
            txtProductCode.Focus();

            txtInvoiceNo.Text = ""; //GetNewBillNo();

            unlocked = false;
            txtMember.Text = "";
            txtInvoiceNo.Text = "";

            txtEmployeeNo.Text = "";
            txtEmployeeNo.Tag = null;
           

            txtGrandTotal.Text = "";

            btnSave.Text = "Save";

            IsIPDSale = false;

            LoadPaymentModes();

            unlocked = true;
        }

        private void btnDueCollection_Click(object sender, EventArgs e)
        {
            frmDueCollection _frm = new frmDueCollection();
            _frm.Show();
        }

        private void dgSales_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)e.Row.Tag;

            _SelectedItems.Remove(e.Row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);
            CalculateAmount();

        }

        private void dgSales_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = dgSales.SelectedRows[0].Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
            // btnSave.Text = "Update";
            if (_SelectedItem != null)
            {
                VWPhProductListForSale _phPlist = new PhProductService().GetStockByProductId(_SelectedItem.Id, _SelectedItem.OutLetId, _SelectedItem.LotNo);


                _phPlist.ProductId = _SelectedItem.Id;
                _phPlist.ProductCode = _SelectedItem.Code;
                _phPlist.BarCode = _SelectedItem.BarCode;
                _phPlist.BrandName = _SelectedItem.Name;
                _phPlist.BatchNo = _SelectedItem.BatchNo;
                _phPlist.StockAvailable = _phPlist.StockAvailable;
                _phPlist.ExpireDate = _SelectedItem.ExpireDate;
                _phPlist.OutLetId = _SelectedItem.OutLetId;
                _phPlist.LotNo = _SelectedItem.LotNo;
                _phPlist.SalePrice = _phPlist.SalePrice;
                _phPlist.PurchasePrice = _phPlist.PurchasePrice;

                txtProductCode.Tag = _phPlist;
                isEditMode = true;
                unlocked = false;
                txtProductCode.Text = _SelectedItem.Id.ToString();
                txtDrescription.Text = _SelectedItem.Name;
                txtUnitPrice.Text = _SelectedItem.SRate.ToString();
                txtQuantity.Text = _SelectedItem.Qty.ToString();
                unlocked = true;
            }
        }

        private void dgSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //_SelectedTests.Where(w => w.Id == testId).ToList().ForEach(s => s.discountInPercent = disInPercent.ToString());
        }

       

        private void ctlProductSearchControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                txtProductCode.Focus();
            }
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                unlocked = false;
                  txtProductCode.Text = "";
                unlocked = true;

                txtProductCode.Focus();
            }
        }

     
        

        

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            frmStockEntry frm = new frmStockEntry();
            frm.Show();
        }

        

        private void dgRequistions_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
          
        }

        
        private void cbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTotalItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlEmployeeSearchControl.Visible = true;
                ctlEmployeeSearchControl.LoadData();
            }

        }

        private void ctlProductSearchControl_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Text = "";
                txtProductCode.Focus();
            }
        }

        private void ctlEmployeeSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtEmployeeNo.Focus();
            }
        }

        private void ctlProductSearchControl_Load(object sender, EventArgs e)
        {

        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            long _billNo = 0;
            long.TryParse(txtInvoiceNo.Text, out _billNo);
            PhInvoice _Invoice = new PhProductService().GetPhInvoiceByBillNo(_billNo);
            if (_Invoice == null)
            {
                return;
            }
               
                LoadPrevoiusBillInfo(_Invoice);
            txtCustomerInvoiceNo.Text = _Invoice.InvoiceId.ToString();
            
        }

        private void txtMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlPhMemberSearch.Visible = true;
                ctlPhMemberSearch.LoadData();
            }
        }

        private void txtDiscInPercent_TextChanged(object sender, EventArgs e)
        {
            double _discInPercent = 0, _tamout = 0; ;
            double.TryParse(txtDiscInPercent.Text, out _discInPercent);
            double.TryParse(txtSubTotal.Text, out _tamout);

            //if (_discInPercent > 10)
            //{
            //    MessageBox.Show("Discount Limit Exceeds.");
            //    txtDiscInPercent.Text = "";
            //    return;
            //}

            double _discount = Math.Round((_tamout * _discInPercent) / 100, 2);

            txtDiscount.Text = _discount.ToString();
            if (!IsIPDSale)
            {
                txtReceiveTk.Text = (_tamout - _discount).ToString();
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            calculateDAndC();
        }

        
        private async void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                await LoadMedicineStocks();
            }
        }

        private  void txtRxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _RxIN = 0;
                long.TryParse(txtRxId.Text, out _RxIN);

              

                RxVisitHistory rxVisitHistory = new RxService().GetRxVisitHistory(_RxIN);
                if (rxVisitHistory != null)
                {
                    txtRxId.Tag = rxVisitHistory;

                    List<RxDrug> _listAdvicedDrugs = new RxService().GetRxDrugByRxId(rxVisitHistory.RxVisitId);

                     _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                    List<VWPhProductListForSale> prodList =  lblOutletItems.Tag as List<VWPhProductListForSale>;

                    foreach (var item in _listAdvicedDrugs)
                    {
                          VWPhProductListForSale prodObj = prodList.Where(x=>x.ProductId== item.ProductId).OrderBy(y=>y.ExpireDate).FirstOrDefault();

                        if (prodObj.StockAvailable < item.Qty)
                        {

                            new PhProductService().PopulateSelectedItemDataForSaleFromMultipleLot(_SelectedItems, prodObj, prodObj.SalePrice, item.Qty);

                            FillItemGrid();
                        }
                        else
                        {
                            new PhProductService().PopulateSelectedItemDataForSale(_SelectedItems, prodObj, prodObj.SalePrice, item.Qty);
                            FillItemGrid();

                        }



                    }

                }
            }
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            List<PhProductInfo> _pList = new PhProductService().GetAllProduct().ToList();
            List<string> strList = new List<string>();
            foreach(var item in _pList)
            {
                string[] arr = item.BrandName.Split(' ');
                string lastItem = arr[arr.Length - 1];
                if(lastItem.Trim().ToLower().Equals("cap") || lastItem.Trim().ToLower().Equals("cap."))
                {
                    var _brandName = arr.Take(arr.Length - 1);
                    strList.Add(_brandName.ToString()+"--->"+ lastItem);

                    item.BrandName = string.Join(" ", _brandName);
                    new PhProductClassificationService().UpdateProduct(item);

                }



            }

            

            MessageBox.Show("Completed");
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentMode _pmode = cmbPaymentMode.SelectedItem as PaymentMode;
            if (_pmode != null)
            {
                List<PaymentChannel> _pChannelList = new CommonService().GetPaymentChannels(_pmode.PMId);
                _pChannelList.Insert(0, new PaymentChannel() { PCId = 0, Name = "Select Channel" });
                cmbPaymentChannel.DataSource = _pChannelList;
                cmbPaymentChannel.DisplayMember = "Name";
                cmbPaymentChannel.ValueMember = "PCId";

                if (_pmode.PMId==1 || _pmode.PMId == 4 || _pmode.PMId == 5) {

                    cmbPaymentChannel.SelectedItem = _pChannelList.Find(q => q.PMId == _pmode.PMId);
                    txtTransactionNo.Enabled = false;
                    txtCardOrMobileReceiveTk.Enabled = false;
                }
                else
                {
                    txtTransactionNo.Enabled = true;
                    txtCardOrMobileReceiveTk.Enabled = true;
                }
            }
        }

        private void txtDiscInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbPaymentMode.Focus();
            }
        }

        private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPaymentChannel.Focus();
            }
        }

        private void cmbPaymentChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTransactionNo.Enabled)
                {
                    txtTransactionNo.Focus();
                }
                else
                {
                    txtReceiveTk.Focus();
                }
            }
        }

        private void txtTransactionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtReceiveTk.Focus();
            }
        }

        private void txtCardOrMobileReceiveTk_TextChanged(object sender, EventArgs e)
        {
            PaymentChannel _pChannel = cmbPaymentChannel.SelectedItem as PaymentChannel;
            if (_pChannel.PCId > 0)
            {
                double _cardormobileAmount = 0;
                double.TryParse(txtCardOrMobileReceiveTk.Text, out _cardormobileAmount);

                double _serviceCharge = 0;
                if (_pChannel.PMId == 2)
                {
                    _serviceCharge = Math.Round((_cardormobileAmount * _pChannel.ServiceCharge)/1000,2);
                }
                else
                {
                    _serviceCharge = Math.Round((_cardormobileAmount * _pChannel.ServiceCharge) / 100, 2);
                }

                txtCardOrMobileCharge.Text = _serviceCharge.ToString();


                calculateDAndR();
            }
        }

        private void txtCardOrMobileReceiveTk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTransactionNo.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStockEntry _frm = new frmStockEntry();
            _frm.Show();
        }

        private void txtCustomerInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            long invoiceNo = 0;
            long.TryParse(txtCustomerInvoiceNo.Text, out invoiceNo);
            PhInvoice _Invoice = new PhProductService().GetPhInvoiceByInvoiceNo(invoiceNo);
            if (_Invoice == null)
            {
                return;
            }
            txtInvoiceNo.Text = _Invoice.BillNo.ToString();
            LoadPrevoiusBillInfo(_Invoice);
           

        }
    }
}
