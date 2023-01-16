using CrystalDecisions.Windows.Forms;
using HDMS.Model;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Common;
using HDMS.Model.Enums;
using HDMS.Model.Hospital;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Users;
using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Service;
using HDMS.Service.Accounting;
using HDMS.Service.Common;
using HDMS.Service.Hospital;
using HDMS.Service.Pharmacy;
using HDMS.Windows.Forms.UI;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using Models.Accounting;
using Models.ViewModel;
using POS;
using Services.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HDMS.Windows.Forms.UI.Pharmacy
{
    public partial class frmStockEntry : Form
    {

        bool isPanelMinimized = true;
        bool unlocked = true;
        bool isEditMode = false;

        public frmStockEntry()
        {
            InitializeComponent();

            UpdateFont();
        }

        private void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dgProducts.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.ForeColor = Color.Black;

            }


            foreach (DataGridViewColumn c in dgReturns.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.ForeColor = Color.Black;

            }

            dgProducts.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


            dgReturns.Font = new Font("Segoe UI", 14.5F, GraphicsUnit.Pixel);


        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<VWPhProductList> sender, VWPhProductList item)
        {
            txtProductCode.Text = item.ProductId.ToString();
            txtProductCode.Tag = item;
            lblItemName.Text = "Item Name: " + item.BrandName;
            txtUnitPrice.Text = item.PurchaseRate.ToString();
            txtSRate.Text = item.SaleRate.ToString();
            txtBatchNo.Focus();


            sender.Visible = false;
        }



        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            MedicineOutlet _OutLet = (MedicineOutlet)cmbOutlet.SelectedItem;

            if (_OutLet.OutLetId == 0)
            {
                MessageBox.Show("Outlet not selected");
                cmbOutlet.Focus();
                return;
            }

            if (e.KeyChar == (char)Keys.Space)
            {
                //HideAllDefaultHidden();
                //ctlProductSearchControl.Visible = true;
                //ctlProductSearchControl.LoadDataByType(_OutLet.OutLetId.ToString());


            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBatchNo.Focus();
            }
        }
        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible = false;
            ctrlManufacturerSearchControl.Visible = false;
        }

        private IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems;
        private async void frmStockEntry_Load(object sender, EventArgs e)
        {

            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            ctlProductSearchControl.Location = new Point(txtProductCode.Location.X, txtProductCode.Location.Y);
            ctrlManufacturerSearchControl.Location = new Point(txtSuplier.Location.X, txtSuplier.Location.Y);

            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;
            ctrlManufacturerSearchControl.ItemSelected += ctlSupllierSearchControl_ItemSelected;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }


            LoadOutlets();


            MedicineOutlet _outlet = (MedicineOutlet)cmbOutlet.SelectedItem;


            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");



            LoadReturnRequestList("0", _outlet.OutLetId);

            LoadFloors();

            txtStaffName.Text = MainForm.LoggedinUser.Name;

            if (!new PhProductService().IsOpeningStockSet(Utils.GetServerDateAndTime()))
            {
                await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());
            }
        }

        private void LoadFloors()
        {
            List<FloorInfo> _floor = new HospitalCabinBedService().GetFloorList();
            _floor.Insert(0, new FloorInfo() { FloorId = 0, Name = "Select Floor" });
            cmbFloor.DataSource = _floor;
            cmbFloor.DisplayMember = "Name";
            cmbFloor.ValueMember = "FloorId";
        }


        private void LoadReturnRequestList(string floorId, int _outletId)
        {
            int _floorId = 0;
            int.TryParse(floorId, out _floorId);

            List<VMHpReturnRequest> _hpRetList = new HospitalService().GetHpPendingReturnRequestList(_floorId, _outletId);

            FillReturnIndentGrid(_hpRetList);
            // dgReturns.DataSource = _hpRetList;
        }

        private void FillReturnIndentGrid(List<VMHpReturnRequest> hpRetList)
        {
            dgReturns.SuspendLayout();
            dgReturns.Rows.Clear();
            foreach (var item in hpRetList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 25;
                row.Tag = item;
                row.CreateCells(dgReturns, item.RturnId, item.CabinNo, item.ReturnBy, item.Status);
                dgReturns.Rows.Add(row);
            }
        }

        private void LoadOutlets()
        {
            List<MedicineOutlet> _outletLists = new PhProductService().GetAllMedicineOutlets();
            _outletLists.Insert(0, new MedicineOutlet() { OutLetId = 0, Name = "Select Outlet", Description = "Outlet" });


            cmbOutlet.DataSource = _outletLists;
            cmbOutlet.DisplayMember = "Name";
            cmbOutlet.ValueMember = "OutletId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            cmbOutlet.SelectedItem = _outletLists.Find(q => q.OutLetId == _user.AssignedOutLet);

            if (_user.AssignedOutLet == 0)
            {
                cmbOutlet.Enabled = true;
            }
            else
            {
                cmbOutlet.Enabled = false;
            }

            if (_user.IsIndoorSaleAllowed)
            {
                lblRequisitionPanel.Visible = true;
            }
            else
            {
                lblRequisitionPanel.Visible = false;
            }
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
            //ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.NavajoWhite;
        }
        private async void ctlSupllierSearchControl_ItemSelected(SearchResultListControl<Manufacturer> sender, Manufacturer item)
        {
            txtSuplier.Text = item.Name;
            txtSuplier.Tag = item;
            txtSupInvoicNo.Focus();

            await new PhProductService().SetOpeningStock(Utils.GetServerDateAndTime());

            sender.Visible = false;



        }

        private void txtSuplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlManufacturerSearchControl.Visible = true;
                ctrlManufacturerSearchControl.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSupInvoicNo.Focus();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _qty = 0;
                double _rate = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _rate);
                txtTotal.Text = (_qty * _rate).ToString();
                txtDiscInPercent.Focus();
            }
        }

        private void FillItemGrid()
        {
            int count = 0;
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _SelectedItems)
            {
                count++;
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgProducts, count, item.Name, item.BatchNo, item.ExpireDate.ToString("dd/MM/yyyy"), item.PRate, item.Qty, item.Total, item.DiscInPercentPerProduct, item.Discount, item.VatInPercentPerProduct, item.Vat, item.Gtotal);
                dgProducts.Rows.Add(row);
            }

            CalculateAmount();
        }



        private void CalculateAmount()
        {
            txtTotalItem.Text = dgProducts.Rows.Cast<DataGridViewRow>()
                 .Sum(t => Convert.ToDouble(t.Cells[5].Value)).ToString();
            txtInvoiceTotal.Text = dgProducts.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[6].Value)).ToString();
            txtInvDiscount.Text = dgProducts.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[8].Value)).ToString();
            txtInvVat.Text = dgProducts.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDouble(t.Cells[10].Value)).ToString();

            txtInvGTotal.Text = dgProducts.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells[11].Value)).ToString();

            txtDueAmount.Text = dgProducts.Rows.Cast<DataGridViewRow>()
               .Sum(t => Convert.ToDouble(t.Cells[11].Value)).ToString();

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (dgProducts.Rows.Count > 0)
            {

                long _admissionNo = 0;
                long invocieId = 0;



                if (txtSuplier.Tag != null)
                {
                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    if (_outLet.OutLetId == 0)
                    {
                        MessageBox.Show("Select outlet");
                        cmbOutlet.Focus();
                        return;
                    }


                    VMPhEndPointDataCarrierForStockEntry voucherObj = new VMPhEndPointDataCarrierForStockEntry();
                    voucherObj.StockAccId = 0;
                    voucherObj.OutletId = _outLet.OutLetId;
                    //voucherObj.TransactionDateTime =Utils.GetServerDateAndTime();
                    voucherObj.TransactionDateTime = dtpSInvDate.Value;
                    voucherObj.TransactionBy = MainForm.LoggedinUser.Name;

                    Manufacturer _sInfo = (Manufacturer)txtSuplier.Tag;

                    HpMedicineReturnInednt _RetIndent = (HpMedicineReturnInednt)btnCancel.Tag;

                    if (btnCancel.Tag != null && _sInfo.ManufacturerId == 110)    // If supplier is Nurse station, Patient ledger must be adjusted
                    {
                        long _billNo = 0;
                        //  long.TryParse(GetNewBillNo(), out _billNo);

                        long __retIndentNo = 0;
                        long.TryParse(txtOrderNo.Tag.ToString(), out __retIndentNo);

                        HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_RetIndent.AdmissionId);

                        _admissionNo = _pInfo.BillNo;

                        double _returnAmount = GetTotalReturnAmount();

                        DateTime _dateTime = Utils.GetServerDateAndTime();

                        PhInvoice pi = new PhInvoice();
                        pi.BillNo = _billNo;
                        pi.AdmissionNo = _pInfo.BillNo;
                        pi.InvoiceType = "RRN";   // Return Receive
                        pi.TotalTK = 0 - _returnAmount;
                        pi.Invdate = _dateTime;
                        pi.InvTime = _dateTime.ToString("hh:mm tt");
                        pi.GrandTK = 0 - _returnAmount;
                        pi.ReceivedTK = 0;
                        pi.ChangeTK = 0;
                        pi.CustomerID = 0;
                        pi.DueTK = 0 - _returnAmount;
                        pi.DiscountTK = 0;
                        pi.UserId = MainForm.LoggedinUser.UserId;
                        pi.OutLetId = Convert.ToInt32(cmbOutlet.SelectedValue);
                        pi.RequisitionNo = _RetIndent.ReturnIndentId;


                        invocieId = new PhProductService().AddNewInvoice(pi);
                        if (invocieId > 0)
                        {
                            List<PhInvoiceDetail> _invDetailsList = new List<PhInvoiceDetail>();
                            foreach (DataGridViewRow row in dgProducts.Rows)
                            {
                                PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                                PhInvoiceDetail pid = new PhInvoiceDetail();
                                pid.InvoiceId = invocieId;
                                pid.ProductId = selectedTests.Id;
                                pid.LotNo = selectedTests.LotNo;
                                pid.Qty = (0 - selectedTests.Qty);
                                pid.SaleRate = selectedTests.SRate;
                                pid.TotalPrice = (0 - selectedTests.Qty) * selectedTests.SRate;
                                pid.Discount = selectedTests.Discount;
                                pid.PurchaseRate = selectedTests.PRate;
                                _invDetailsList.Add(pid);


                                //Update RetQty for Returned PhInvoiceDetail

                                new PhProductService().UpdatePhRefundedInvoiceDetail(selectedTests.InvoiceId, selectedTests.Id, selectedTests.LotNo, selectedTests.Qty);

                                //End of Update RetQty for Returned PhInvoiceDetail

                            }
                            if (new PhProductService().AddNewInvDetails(_invDetailsList))
                            {


                                // new PhProductService().UpdateStockInfoOnReturn(_invDetailsList, Convert.ToInt32(cmbOutlet.SelectedValue));


                                //Adjust Sale Ledger for this Invoice

                                double balance = _returnAmount;

                                //Save On Entry Payment Information

                                PhSaleLedger pLedger = new PhSaleLedger();
                                pLedger.InvoiceId = invocieId;
                                pLedger.TranDate = DateTime.Now;
                                pLedger.Particulars = "Return Indent No: " + _RetIndent.ReturnIndentId.ToString();
                                pLedger.Debit = 0;
                                pLedger.Credit = _returnAmount;
                                pLedger.Balance = _returnAmount;
                                pLedger.TransactionType = TransactionTypeEnum.RPC.ToString();
                                pLedger.OperateBy = MainForm.LoggedinUser.Name;

                                new PhFinancialService().SavePhSaleLedger(pLedger);

                                //Update Retun Indent

                                _RetIndent.Status = HpIndoorReturnStatusEnum.Accepted.ToString();
                                new PhProductService().UpdateReturnIndent(_RetIndent);

                                AdjsustIPDLedger(_RetIndent);

                                LoadReturnRequestList("0", _outLet.OutLetId);
                            }

                        }

                    }

                    double _totalTK = 0;
                    double _discountTk = 0;
                    double _VatTk = 0;
                    int _totalStockCount = 0;
                    double _avgVat = 0;
                    double _avgDiscount = 0;

                    double.TryParse(txtInvGTotal.Text, out _totalTK);
                    double.TryParse(txtInvDiscount.Text, out _discountTk);
                    double.TryParse(txtInvVat.Text, out _VatTk);
                    int.TryParse(lblStockCount.Text, out _totalStockCount);

                    /* ====================* Avarage Vat calculate On Total Product Count *====================== */
                  
                    //if (_VatTk > 0)
                    //{
                    //    _avgVat = _VatTk / _totalStockCount;
                    //}

                    //if (_discountTk > 0)
                    //{
                    //    _avgDiscount = _discountTk / _totalStockCount;
                    //}



                    long _orderId = 0;
                    if (String.IsNullOrEmpty(txtOrderNo.Text))
                    {
                        PhOrder _phOrder = new PhProductService().GetPhOrderByOrderNo(txtOrderNo.Text);
                        if (_phOrder != null) _orderId = _phOrder.OrderId;
                    }


                    PhReceive rcv = new PhReceive();
                    //rcv.RDate = Utils.GetServerDateAndTime();
                    rcv.RDate = dtpSInvDate.Value;
                    rcv.OrderId = _orderId;
                    rcv.Particulars = "NR";
                    rcv.SupChalanNo = txtSupChalanNo.Text;
                    rcv.SupInvNo = txtSupInvoicNo.Text;
                    rcv.TotalTk = _totalTK;
                    rcv.DiscountTk = _discountTk;
                    rcv.VatTk = _VatTk;
                    rcv.SupInvDate = dtpSInvDate.Value;
                    rcv.SupplerId = ((Manufacturer)txtSuplier.Tag).ManufacturerId;
                    rcv.OutLetId = _outLet.OutLetId;
                    rcv.IPDReturnBy = _admissionNo;
                    rcv.OPDReturnInvoice = 0;

                    rcv.Receivedby = MainForm.LoggedinUser.Name;

                    //long _ReceiveId = new PhProductService().SaveReceivedInvoice(rcv);
                    //if (_ReceiveId > 0)
                    //{


                    double totalPrice = 0;
                    double.TryParse(txtInvoiceTotal.Text, out totalPrice);
                    double vat = 0;
                    double.TryParse(txtInvVat.Text, out vat);
                    double _vatInPercents  = Convert.ToDouble(((vat * 100) / totalPrice).ToString("0.000000"));

                    double.TryParse(txtInvDiscount.Text, out double dis);
                    double _discountInPercent = Convert.ToDouble(((dis * 100) / totalPrice).ToString("0.0000"));



                    List<PhReceiveDetail> _rDeatailsList = new List<PhReceiveDetail>();
                    foreach (DataGridViewRow row in dgProducts.Rows)
                    {
                        PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
                        PhReceiveDetail _rDetails = new PhReceiveDetail();
                        _rDetails.ReceivedId = 0;
                        _rDetails.LotNo = selectedTests.LotNo;
                        _rDetails.ProductId = selectedTests.Id;
                        _rDetails.Qty = selectedTests.Qty;
                        _rDetails.PurchaseRate = selectedTests.PRate;
                        _rDetails.Total = selectedTests.Total;
                        _rDetails.disCountInpercent = selectedTests.DiscInPercentPerProduct;

                        
                        //_rDetails.grossDiscount = selectedTests.Discount + Math.Round(_avgDiscount, 2);
                        _rDetails.grossDiscount = selectedTests.Discount + (selectedTests.Total * _discountInPercent/100);

                        _rDetails.vatInpercent = selectedTests.VatInPercentPerProduct;
                        //_rDetails.vatInTk = selectedTests.Vat + Math.Round(_avgVat, 2);
                        _rDetails.vatInTk = selectedTests.Vat + (selectedTests.Total * _vatInPercents / 100);
                        // _rDeatailsList.Add(_rDetails);

                        _rDeatailsList.Add(_rDetails);
                    }


                    PhReceive _phReceive = await new PhFinancialService().SaveNewPurchase(rcv, _SelectedItems.ToList(), voucherObj, MainForm.orgSetting.IsIntegratedAccountInAction, _discountInPercent, _vatInPercents);

                    if (_phReceive.ReceiveId > 0)
                    {

                        ShowPurchaseInvoice(_phReceive.ReceiveId);
                        MessageBox.Show("Receive successful");

                        //  this.AdJustSupplierLedger(((Manufacturer)txtSuplier.Tag).ManufacturerId, _totalTK, _discountTk, _paidTk, _ReceiveId);


                    }
                    Thread.Sleep(100);

                    ClearFields();

                }
                else
                {
                    MessageBox.Show("Supplier required.");
                }
            }



        }

        private void GenerateAccountsVoucher(Manufacturer sInfo, long ReceivedId)
        {

            double _totalAmount = 0;
            double.TryParse(txtInvGTotal.Text, out _totalAmount);

            Voucher masterVoucher = new Voucher();
            masterVoucher.CompanyId = 1;
            masterVoucher.VoucherDate = Utils.GetServerDateAndTime();
            masterVoucher.VoucherId = "";
            masterVoucher.VoucherType = "Journal";
            masterVoucher.Description = "Purchase Invoice: " + ReceivedId.ToString() + ", Supplier Name: " + sInfo.Name;
            new VoucherService().AddMasterVoucher(masterVoucher);



            List<VoucherDetail> _rDebitVoucherDetailList = new List<VoucherDetail>();


            VoucherDetail detailsVoucher = new VoucherDetail();


            detailsVoucher.VMId = masterVoucher.VMId;
            detailsVoucher.DRCR = "D";
            detailsVoucher.Amount = _totalAmount;
            detailsVoucher.AccId = 128;
            detailsVoucher.reamrks = "Pharmacy Purchase";

            new VoucherService().AddDetailsVoucher(detailsVoucher);

            detailsVoucher = new VoucherDetail();
            detailsVoucher.VMId = masterVoucher.VMId;
            detailsVoucher.DRCR = "C";
            detailsVoucher.Amount = _totalAmount;
            detailsVoucher.AccId = sInfo.ManufacturerAccId;
            detailsVoucher.reamrks = "Product delivery";

            new VoucherService().AddDetailsVoucher(detailsVoucher);



        }

        public void AdjsustIPDLedger(HpMedicineReturnInednt _retIndent)
        {
            long invocieId = 0;

            PhTemIPDReturnLadger _tempIPDLedger = new PhFinancialService().GetTempIPDLedger(_retIndent.ReturnIndentId);

            double ebalance = new PhFinancialService().GetPhIPDLedgerBalance(_retIndent.AdmissionId);

            double _primaryBalance = ebalance;

            if (ebalance > -1 && ebalance < 0.5) { ebalance = 0; }

            ebalance = ebalance + _tempIPDLedger.ReturnAmount;
            //Save On Entry Payment Information
            List<PhIPDSaleLedger> _ipdtransactionList = new List<PhIPDSaleLedger>();
            PhIPDSaleLedger ipdLedger = new PhIPDSaleLedger();
            ipdLedger.AdmissionId = _retIndent.AdmissionId;
            ipdLedger.TranDate = Utils.GetServerDateAndTime();
            ipdLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
            ipdLedger.Particulars = "Return Medicine";
            ipdLedger.Debit = 0;
            ipdLedger.Credit = _tempIPDLedger.ReturnAmount;
            ipdLedger.Balance = ebalance;
            ipdLedger.TransactionType = TransactionTypeEnum.PhProductReturn.ToString();
            ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
            ipdLedger.InvoiceIdGeneratedOnReturn = invocieId;
            _ipdtransactionList.Add(ipdLedger);


            if (_tempIPDLedger.DiscountAdjusted > 0)
            {
                ebalance = ebalance - _tempIPDLedger.DiscountAdjusted;

                ipdLedger = new PhIPDSaleLedger();
                ipdLedger.AdmissionId = _retIndent.AdmissionId;
                ipdLedger.TranDate = Utils.GetServerDateAndTime();
                ipdLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                ipdLedger.Particulars = "Discount Adjusted";
                ipdLedger.Debit = _tempIPDLedger.DiscountAdjusted;
                ipdLedger.Credit = 0;
                ipdLedger.Balance = ebalance;
                ipdLedger.TransactionType = TransactionTypeEnum.PhDiscountDiscountRefunded.ToString();

                ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
                ipdLedger.InvoiceIdGeneratedOnReturn = invocieId;
                _ipdtransactionList.Add(ipdLedger);
            }

            //if (_primaryBalance<0 && ebalance > 0)
            //{

            //    _returnAmount = _returnAmount - discountAdjusted;
            //    ebalance = ebalance - _returnAmount;

            //    ipdLedger = new PhIPDSaleLedger();
            //    ipdLedger.AdmissionId = _pInfo.AdmissionId;
            //    ipdLedger.TranDate = Utils.GetServerDateAndTime();
            //    ipdLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
            //    ipdLedger.Particulars = "Return Tk";
            //    ipdLedger.Debit = _returnAmount;
            //    ipdLedger.Credit = 0;
            //    ipdLedger.Balance = ebalance;
            //    ipdLedger.TransactionType = TransactionTypeEnum.PhRefund.ToString();
            //    ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
            //    ipdLedger.InvoiceIdGeneratedOnReturn = invocieId;
            //    _ipdtransactionList.Add(ipdLedger);

            //}


            if (_ipdtransactionList.Count > 0)
            {
                new PhFinancialService().SavePhIPDSaleTransactionLedger(_ipdtransactionList);
            }

            _tempIPDLedger.Status = "Accepeted";
            new PhFinancialService().UpdatePhtemIPDReturnLadger(_tempIPDLedger);

        }


        private void ShowPurchaseInvoice(long _ReceiveId)
        {
            rptPurchaseInvoice _rpt = new rptPurchaseInvoice();


            DataSet ds = new PhFinancialService().GetPurchaseInvoice(_ReceiveId);

            _rpt.SetDataSource(ds.Tables[0]);


            _rpt.SetParameterValue("discount", txtInvDiscount.Text);
            _rpt.SetParameterValue("vat", "0");
            _rpt.SetParameterValue("gtotal", txtInvGTotal.Text);


            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
            // rv.Show();
        }


        private void PrintIndoorReturnInvoice(long invocieId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;

            PhInvoice _Invoice = new PhProductService().GetPhInvoiceByInvoiceId(invocieId);

            DataSet ds = new PhReportingService().GetIndoorInvoiceDataByinvocieId(invocieId);

            IndoorPhInvoivce _rpt = new IndoorPhInvoivce();

            _rpt.SetDataSource(ds.Tables[0]);


            _rpt.SetParameterValue("PayStatus", "DUE");
            _rpt.SetParameterValue("BillNo", _Invoice.BillNo.ToString());
            _rpt.SetParameterValue("RequisitionNo", _Invoice.RequisitionNo.ToString());
            _rpt.SetParameterValue("CabinNo", "");
            _rpt.SetParameterValue("InvoiceHeaderText", "IPD RETURN INVOICE");

            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

        private double GetTotalReturnAmount()
        {
            string retAmount = dgReturnList.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToInt32(t.Cells[6].Value)).ToString();

            double _retTk = 0;
            double.TryParse(retAmount, out _retTk);

            return _retTk;
        }

        private string GetNewBillNo()  //Invoice for return sale as negative 
        {
            string _billPart1 = Utils.GetBillNo();
            long _billNo = new Random().Next(10000, 99999);
            string _billPart2 = _billNo.ToString() + "1";

            string _BillNo = _billPart1 + _billPart2;

            if (!new PhProductService().IsPhBillNoAlloted(Convert.ToInt64(_BillNo)))
            {
                return _BillNo.ToString();
            }

            GetNewBillNo();

            return "";
        }

        private void ClearFields()
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            dgProducts.Rows.Clear();
            txtTotalItem.Text = "";
            txtGTotal.Text = "";
            txtInvoiceTotal.Text = "";
            txtInvDiscount.Text = "";
            txtInvGTotal.Text = "";
            txtInvVat.Text = "";
            txtDueAmount.Text = "";
            lblStockCount.Text = 0.ToString();
        }

        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrWhiteSpace(txtOrderNo.Text))
                {
                    PhOrder _PrevOrder = new PhProductService().GetOrderByOrderNo(txtOrderNo.Text);
                    if (_PrevOrder != null)
                    {
                        txtOrderNo.Tag = _PrevOrder;
                        Manufacturer _phs = new SupplierService().GetManufacturerById(_PrevOrder.OrderTo);
                        txtSuplier.Text = _phs.Name;
                        txtSuplier.Tag = _phs;
                        txtProductCode.Focus();
                        _SelectedItems = new PhProductService().GetOrderedProductListByOrderId(_PrevOrder.OrderId);
                        FillItemGrid();
                        CalculateAmount();
                    }
                    else
                    {
                        MessageBox.Show("Order not found.Plz check order no and try again.");
                    }
                }

                txtSuplier.Focus();
            }
        }

        private void dgProducts_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)e.Row.Tag;
            _SelectedItems.Remove(e.Row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);
            CalculateAmount();

        }

        private void txtSupInvoicNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {

                PhReceive pr = new PhProductService().GetPhReceiveBySupInvoice(txtSupInvoicNo.Text, ((Manufacturer)txtSuplier.Tag).ManufacturerId);


                if (pr != null)
                {
                    MessageBox.Show("This Supplier Invoice Already Exists");
                    txtSupInvoicNo.Text = "";
                    txtSupInvoicNo.Focus();
                }
                else
                {
                    txtSupChalanNo.Focus();
                }


            }
        }

        private void txtSupChalanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpSInvDate.Focus();
            }
        }

        private void dtpSInvDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtProductCode.Focus();
            }
        }

        private void txtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtBatchNo.Text))
                {
                    MessageBox.Show("Batch No. Required."); txtBatchNo.Focus();
                }
                else
                {
                    //txtExpDate.Focus();
                    dtpExpireDate.Focus();
                }


            }
        }

        private void dtpExpDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQuantity.Focus();
            }
        }

        private void txtGTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _qty = 0, _prate = 0, _sRate = 0, _total = 0, discInPercent = 0, vatInPercent = 0, _grossTotal;
                int outletId = 0;
                double.TryParse(txtQuantity.Text, out _qty);
                double.TryParse(txtUnitPrice.Text, out _prate);
                double.TryParse(txtSRate.Text, out _sRate);
                double.TryParse(txtTotal.Text, out _total);
                double.TryParse(txtDiscInPercent.Text, out discInPercent);
                double.TryParse(txtVatInPercent.Text, out vatInPercent);
                double.TryParse(txtGTotal.Text, out _grossTotal);

                if (_prate > _sRate)
                {
                    MessageBox.Show("Invalid unit price");
                    txtUnitPrice.Text = "";
                    txtUnitPrice.Focus();
                    return;
                }

                //string _expDate = GetFormattedExpireDate(txtExpDate.Text);
                string _expDate = GetFormattedExpireDate(dtpExpireDate.Text);

                //if (String.IsNullOrEmpty(_expDate))
                //{
                //    MessageBox.Show("Expire date missing or not properly formatted."); return;
                //}


                new PhProductService().PopulateSelectedItemDataForStockEntry(_SelectedItems, txtProductCode.Tag as VWPhProductList, _prate, _sRate, _qty, txtBatchNo.Text, Convert.ToDateTime(_expDate), _total, discInPercent, vatInPercent, _grossTotal, MainForm.LoggedinUser.UserId, Utils.GetServerDateAndTime(), outletId);
                FillItemGrid();

                new PhProductService().UpdatePurchaseAndSalerate(txtProductCode.Tag as VWPhProductList, _prate, _sRate);

                FillItemGrid();
                lblStockCount.Text = dgProducts.Rows.Count.ToString();

                txtUnitPrice.Text = "";
                txtQuantity.Text = "";
                lblItemName.Text = "";
                txtProductCode.Text = "";
                txtDiscInPercent.Text = "";
                txtQtyBox.Text = "";
                txtTotal.Text = "";
                txtGTotal.Text = "";
                txtExpDate.Text = "";
                dtpExpireDate.Value = DateTime.Today;
                txtBatchNo.Text = "";
                txtSRate.Text = "";
                txtVatInPercent.Text = "";

                // txtBatchNo.Text = "";
                txtProductCode.Focus();
            }
        }

        private string GetFormattedExpireDate(string text)
        {
            try
            {
                //string _expDate = DateTime.ParseExact(txtExpDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                //       .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);




                return dtpExpireDate.Value.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void txtDiscInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _total = 0;
                double _discInPercent = 0;
                double.TryParse(txtTotal.Text, out _total);
                double.TryParse(txtDiscInPercent.Text, out _discInPercent);
                double totalDisc = (_total * _discInPercent) / 100;
                txtGTotal.Text = (_total - totalDisc).ToString();
                txtDiscInPercent.Tag = totalDisc;
                txtVatInPercent.Focus();
            }
        }

        private void ctlProductSearchControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTogglePositionForPanel(isPanelMinimized);
        }

        private void SetTogglePositionForPanel(bool _IspanleMinimized)
        {
            if (_IspanleMinimized)
            {
                lblRequisitionPanel.Location = new Point(1200, 66);

                button1.Location = new Point(20, 20);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(150, 66);

                button1.Location = new Point(20, 20);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProductCode.Text = "";
                txtProductCode.Focus();
            }
        }

        private void dgReturns_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            VMHpReturnRequest retObj = dgReturns.SelectedRows[0].Tag as VMHpReturnRequest;
            if (retObj != null)
            {
                txtOrderNo.Tag = retObj.RturnId;
                //btnCancel.Tag = dgReturns.Rows[e.RowIndex].Cells["RturnId"].Value.ToString();
                LoadRetIndentDetails();
            }
        }

        private void LoadRetIndentDetails()
        {
            if (txtOrderNo.Tag != null)
            {
                long __retIndentNo = 0;
                long.TryParse(txtOrderNo.Tag.ToString(), out __retIndentNo);

                HpMedicineReturnInednt _retIndent = new PhProductService().GetReturnIndentById(__retIndentNo);

                btnCancel.Tag = _retIndent;

                if (_retIndent != null)
                {
                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientInfoById(_retIndent.AdmissionId);
                    if (_pInfo != null)
                    {
                        RegRecord _record = new RegRecordService().GetRegRecordByRegNo(_pInfo.RegNo);
                        lblName.Text = _record.FullName;

                        HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedService().GetOccupiedCabinByPatient(_pInfo.AdmissionId);

                        CabinInfo _Cabin = new HospitalCabinBedService().GetCabinInfoId(_accomInfo.CabinId);
                        lblCabin.Text = _Cabin.CabinNo;

                    }


                    List<VMReturnRequestList> _mRetDetail = new PhProductService().GetHpMedicineReturnDetail(_retIndent.ReturnIndentId);
                    dgReturnList.Visible = true;
                    FillRetProductGrid(_mRetDetail);

                }

            }


        }

        private void FillRetProductGrid(List<VMReturnRequestList> _mRetDetail)
        {
            dgReturnList.SuspendLayout();
            dgReturnList.Rows.Clear();

            if (_mRetDetail == null) return;


            foreach (VMReturnRequestList item in _mRetDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgReturnList, item.ProductId, item.BrandName, item.RetQty, item.LotNo, item.OutLetId, item.SalePrice, item.TotalPrice);
                dgReturnList.Rows.Add(row);
            }
        }

        private void dgReturnList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _SelectedItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            foreach (DataGridViewRow row in dgReturnList.Rows)
            {
                VMReturnRequestList selectedItem = row.Tag as VMReturnRequestList;

                new PhProductService().PopulateSelectedItemDataForReceiceveAgainstReturn(_SelectedItems, selectedItem);

            }


            // if (dgReturnList.Rows.Count > 0) {

            FillItemGrid();

            isPanelMinimized = true;
            SetTogglePositionForPanel(isPanelMinimized);

            Manufacturer supInfo = new SupplierService().GetManufacturerById(110); // Nurse station
            txtSuplier.Tag = supInfo;
            txtSuplier.Text = supInfo.Name;

            //  }
        }

        private void lblRequisitionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtOrderNo.Tag != null)
            {

                MedicineOutlet _outlet = (MedicineOutlet)cmbOutlet.SelectedItem;

                DialogResult result = MessageBox.Show("Are you sure to cancel this return indent?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    long _retId = 0;
                    long.TryParse(txtOrderNo.Tag.ToString(), out _retId);


                    new PhProductService().CancelMedicineReturnId(_retId);

                    PhTemIPDReturnLadger _tempLedger = new PhFinancialService().GetTempIPDLedger(_retId);
                    _tempLedger.Status = "RetRejected";

                    new PhFinancialService().UpdatePhtemIPDReturnLadger(_tempLedger);

                    LoadReturnRequestList(cmbFloor.SelectedValue.ToString(), _outlet.OutLetId);
                }

            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (unlocked)
            {
                string _txt = txtProductCode.Text.Trim();
                if (_txt.Length >= 2)
                {
                    HideAllDefaultHidden();

                    MedicineOutlet _outLet = (MedicineOutlet)cmbOutlet.SelectedItem;

                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadDataByType(_txt + ">" + _outLet.OutLetId.ToString()); // Out let Id appended for outlet specific product loading
                }

            }

        }

        private void dgProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = dgProducts.SelectedRows[0].Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
            // btnSave.Text = "Update";
            if (_SelectedItem != null)
            {
                VWPhProductList _phPlist = new VWPhProductList(); //new PhProductService().GetStockByProductId(_SelectedItem.Id, _SelectedItem.OutLetId, _SelectedItem.LotNo);


                _phPlist.ProductId = _SelectedItem.Id;
                _phPlist.ProductCode = _SelectedItem.Code;
                _phPlist.BarCode = _SelectedItem.BarCode;
                _phPlist.BrandName = _SelectedItem.Name;
                _phPlist.BatchNo = _SelectedItem.BatchNo;
                _phPlist.StockAvailable = _phPlist.StockAvailable;
                _phPlist.ExpireDate = _SelectedItem.ExpireDate;
                _phPlist.OutLetId = _SelectedItem.OutLetId;
                _phPlist.LotNo = _SelectedItem.LotNo;
                _phPlist.SaleRate = _SelectedItem.SRate;
                _phPlist.PurchaseRate = _SelectedItem.PRate;

                txtProductCode.Tag = _phPlist;
                isEditMode = true;
                unlocked = false;
                txtProductCode.Text = _SelectedItem.Id.ToString();
                txtBatchNo.Text = _SelectedItem.BatchNo;
                //txtExpDate.Text = _SelectedItem.ExpireDate.ToString("dd/MM/yyyy");
                //dtpExpireDate.Text = _SelectedItem.ExpireDate.ToString("dd/MM/yyyy");
                txtTotal.Text = _SelectedItem.Total.ToString();
                txtQuantity.Text = _SelectedItem.Qty.ToString();
                txtQtyBox.Text = "";
                txtUnitPrice.Text = _SelectedItem.PRate.ToString();
                txtSRate.Text = _SelectedItem.SRate.ToString();
                txtDiscInPercent.Text = _SelectedItem.DiscInPercentPerProduct.ToString();
                txtVatInPercent.Text = _SelectedItem.VatInPercentPerProduct.ToString();
                txtGTotal.Text = _SelectedItem.Gtotal.ToString();
                lblItemName.Text = "Item Name: " + _SelectedItem.Name;

                unlocked = true;
            }
        }

        private void txtInvDiscount_TextChanged(object sender, EventArgs e)
        {
            double _discount = 0;
            double _total = _SelectedItems.Sum(x => x.Gtotal);

            double.TryParse(txtInvDiscount.Text, out _discount);
            double.TryParse(txtInvVat.Text, out double _vat);

            txtInvGTotal.Text = (_total - _discount + _vat).ToString();
            txtDueAmount.Text = (_total - _discount + _vat).ToString();




        }

        private void txtInvGTotal_TextChanged(object sender, EventArgs e)
        {

        }





        private void txtQtyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _boxqty = 0;
                int.TryParse(txtQtyBox.Text, out _boxqty);

                if (_boxqty > 0)
                {
                    VWPhProductList _phpl = (VWPhProductList)txtProductCode.Tag;
                    if (_phpl != null)
                    {
                        int _totalQty = _boxqty * _phpl.QtyPerBox;
                        txtQuantity.Text = _totalQty.ToString();

                        double _totalPurchasePrice = _totalQty * _phpl.PurchaseRate;

                        txtTotal.Text = _totalPurchasePrice.ToString();
                        txtDiscInPercent.Focus();
                    }
                }
            }
        }

        private void txtExpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    if (String.IsNullOrEmpty(txtExpDate.Text))
            //    {
            //        MessageBox.Show("Expire date required.");
            //        txtExpDate.Focus();
            //    }
            //    else
            //    {
            //        try
            //        {

            //            string _expDate =   DateTime.ParseExact(txtExpDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            //           .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            //            if (txtProductCode.Tag != null)
            //            {
            //                VWPhProductList item = (VWPhProductList)txtProductCode.Tag;

            //                if (!String.IsNullOrEmpty(item.PkgUnit) && item.PkgUnit.ToLower() == "box")
            //                {
            //                    txtQtyBox.Focus();
            //                }
            //                else
            //                {
            //                    txtQuantity.Focus();
            //                }
            //            }

            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show("Date format did not match");
            //            txtExpDate.Focus();
            //        }

            //    }
            //}








        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            double _qty = 0;

            double.TryParse(txtQuantity.Text, out _qty);

            if (_qty < 0)
            {
                MessageBox.Show("Negative quantity not allowed.");
                txtTotal.Text = "";
                txtQuantity.Text = "";
                txtQuantity.Focus();
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            frmPhProductEntry _frm = new frmPhProductEntry();
            _frm.Show();
        }

        private void txtVatInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double _total = 0;
                double _gtotal = 0;
                double _VatcInPercent = 0;
                double.TryParse(txtTotal.Text, out _total);
                double.TryParse(txtGTotal.Text, out _gtotal);
                double.TryParse(txtVatInPercent.Text, out _VatcInPercent);
                double totalVat = (_total * _VatcInPercent) / 100;
                txtGTotal.Text = (_gtotal + totalVat).ToString();
                txtVatInPercent.Tag = totalVat;
                txtGTotal.Focus();
            }
        }

        private void dtpExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtUnitPrice.Focus();
            }
        }

        private void txtInvVat_TextChanged(object sender, EventArgs e)
        {
            double _discount = 0;
            double _total = _SelectedItems.Sum(x => x.Gtotal);

            double.TryParse(txtInvDiscount.Text, out _discount);
            double.TryParse(txtInvVat.Text, out double _vat);

            txtInvGTotal.Text = (_total - _discount + _vat).ToString();
            txtDueAmount.Text = (_total - _discount + _vat).ToString();
        }


        private void FillItemGridIts(List<PhSelectedProductsToSaleOrReceiveOrOrder> items)
        {
            int count = 0;
            dgProducts.SuspendLayout();
            dgProducts.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in items)
            {
                count++;
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Tag = item;
                row.CreateCells(dgProducts, count, item.Name, item.BatchNo, item.ExpireDate.ToString("dd/MM/yyyy"), item.PRate, item.Qty, item.Total, item.DiscInPercentPerProduct, item.Discount, item.VatInPercentPerProduct, item.Vat, item.Gtotal);
                dgProducts.Rows.Add(row);
            }



            CalculateAmount();
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                long invoice = 0;

                List<PhSelectedProductsToSaleOrReceiveOrOrder> _invoice;

                long.TryParse(txtInvoiceNo.Text, out invoice);

                if (invoice > 0)
                {
                    _invoice = new PhFinancialService().GetSockEntryInvoiceNo(invoice);

                    if (_invoice != null && _invoice.Count > 0)
                    {
                        FillItemGridIts(_invoice);
                    }
                    else
                    {
                        MessageBox.Show("Invocie Id not found");

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Place Valid Inovice No");

                    return;
                }
            }





        }
        /******************* Update Grid  Product Price Devend On Vat or Discount ********************/
        private void txtInvVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataGridViewRow dataGridViewRow = _SelectedItems as DataGridViewRow;

                double totalVat = 0;
                int qty = 0;
                double vat = 0;
                double price = 0;


                double.TryParse(txtInvVat.Text, out vat);
                //  int countProduct = 0;
                //int.TryParse(lblStockCount.Text, out countProduct);
                // totalVat = vat / countProduct;

                double.TryParse(txtInvDiscount.Text, out double dis);

                double totalPrice = 0;
                double.TryParse(txtInvoiceTotal.Text, out totalPrice);

                double getAllTotalPercentConvert = Convert.ToDouble(((vat * 100) / totalPrice).ToString("0.0000"));
                // double getAllTotalPercentConvert =  Math.Round(((vat * 100) / totalPrice));

                // Variable
                string MessageBoxTitle = "Vat Add";
                string MessageBoxContent = "Are you Sure  to Applay  Vat ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);


                if (vat > 0)
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        // If Vat and Discount Same 
                        if (Math.Ceiling(vat) == Math.Ceiling(dis))
                        {
                            int i = 0; 
                            foreach (var sitem in _SelectedItems)
                            {
                                dgProducts[4, i].Value = sitem.PRate.ToString();
                                dgProducts[6, i].Value = sitem.Total.ToString();
                                dgProducts[11, i].Value = sitem.Gtotal.ToString();
                                i++;
                            }
                        }
                        else
                        {

                            foreach (DataGridViewRow item in dgProducts.Rows)
                            {
                                if (item != null)
                                {
                                    int.TryParse(item.Cells[5].Value.ToString(), out qty);
                                    double.TryParse(item.Cells[4].Value.ToString(), out price);
                                    totalVat = Convert.ToDouble(((getAllTotalPercentConvert * (price * qty)) / 100).ToString("0.0000"));
                                    //  totalVat = Math.Round(((getAllTotalPercentConvert * (price * qty)) / 100));

                                    item.Cells[4].Value = (price + (totalVat / qty)).ToString("0.0000");
                                    item.Cells[6].Value = ((price * qty) + totalVat).ToString("0.0000");
                                    item.Cells[11].Value = ((price * qty) + totalVat).ToString("0.0000");
                                }


                            }
                        }
                    }

                }

            }
        }

        private void txtInvDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {



                DataGridViewRow dataGridViewRow = _SelectedItems as DataGridViewRow;

                double discount = 0;
                int qty = 0;
                double price = 0;

               
                //  int countProduct = 0;
                // int.TryParse(lblStockCount.Text, out countProduct);
                //discount = dis / countProduct;

                double totalPrice = 0;
                double.TryParse(txtInvoiceTotal.Text, out totalPrice);

                double vat = 0;
                double.TryParse(txtInvVat.Text, out vat);

                double.TryParse(txtInvDiscount.Text, out double dis);
                double getAllTotalPercentConvert = Convert.ToDouble(((dis * 100) / totalPrice).ToString("0.0000"));
                // double getAllTotalPercentConvert = Math.Round(((dis * 100) / totalPrice));

                // Variable
                string MessageBoxTitle = "Discount  Minius";
                string MessageBoxContent = "Are you Sure  to Applay  Discount ";

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);

                if (dis > 0)
                {
                    if (dialogResult == DialogResult.Yes)
                    {


                        // If Vat and Discount Same 
                        if (Math.Ceiling(vat) == Math.Ceiling(dis))
                        {
                            int i = 0; 
                            foreach (var sitem in _SelectedItems)
                            {

                                dgProducts[4, i].Value = sitem.PRate.ToString();
                                dgProducts[6, i].Value = sitem.Total.ToString();
                                dgProducts[11, i].Value = sitem.Gtotal.ToString();
                                i++;
                            }
                        }
                        else
                        {


                            foreach (DataGridViewRow item in dgProducts.Rows)
                            {

                                if (item != null)
                                {
                                    int.TryParse(item.Cells[5].Value.ToString(), out qty);
                                    double.TryParse(item.Cells[4].Value.ToString(), out price);

                                    discount = Convert.ToDouble(((getAllTotalPercentConvert * (price * qty)) / 100).ToString("0.0000"));
                                    //  discount = Math.Round((getAllTotalPercentConvert * (price * qty) / 100));

                                    item.Cells[4].Value = (price - (discount / qty)).ToString("0.0000");
                                    item.Cells[6].Value = ((price * qty) - discount).ToString("0.0000");
                                    item.Cells[11].Value = ((price * qty) - discount).ToString("0.0000");
                                }


                            }
                        }


                    }

                }

            }
        }
    }
}
