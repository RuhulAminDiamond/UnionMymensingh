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

using Services.Store;
using Models.Accounting;
using HDMS.Service.Accounting;
using HDMS.Model.Common;
using Models.Store;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Model.ViewModel;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI.Reports.SCM;
using HDMS.Windows.Forms.UI;
using HDMS.Service.Pharmacy;

namespace HDMS.Store
{
    public partial class frmStoreStockEntry : Form
    {
        bool unlocked = true;
        public frmStoreStockEntry()
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

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtProduct.Text, out itemId))
            {

            }
            else
            {
                if (unlocked)
                {
                    string _txt = txtProduct.Text;
                    HideAllDefaultHidden();
                    ctrlProductSearchControl.Visible = true;
                    ctrlProductSearchControl.txtSearch.Text = _txt;
                    ctrlProductSearchControl.txtSearch.SelectionStart = ctrlProductSearchControl.txtSearch.Text.Length;

                    ctrlProductSearchControl.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctrlProductSearchControl.Visible = false;
            ctlSupplierSearch.Visible = false;
            ctrlProductSearchControl.Visible = false;
        }

        private IList<SelectedProductsToSaleOrReceive> _SelectedItems;

        private void frmStockEntry_Load(object sender, EventArgs e)
        {
            ClearForm();

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();


            ctrlProductSearchControl.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctrlProductSearchControl.ItemSelected += ctrlProductSearchControl_ItemSelected;
            ctlSupplierSearch.Location = new Point(txtSupplier.Location.X, txtSupplier.Location.Y + txtSupplier.Height);
            ctlSupplierSearch.ItemSelected += CtlSupplierSearch_ItemSelected;

            // txtProduct.GotFocus += new System.EventHandler(this.txtGotFocus);

            dtpRDate.Value = DateTime.Now;
            dtpSInvDate.Value = DateTime.Now;

           
        }

        private void ClearForm()
        {
            dgItems.Rows.Clear();
            txtTotalTk.Text = "";
            txtDiscount.Text = "";

            txtReceiveNo.Text = "";
            txtTotalQty.Text = "";

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();

        //    Company _company = new ItemService().GetAllCompany().FirstOrDefault();
        //int nextInvoicenumber = new ItemService().GetAllReceivedCount(_company.ShortName) + 1;


            // txtSupInvoice.Text = "" + _company.ShortName + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + "INV_" + nextInvoicenumber.ToString();

        }

        private void CtlSupplierSearch_ItemSelected(SearchResultListControl<SupplierInfo> sender, SupplierInfo item)
        {
            txtSupplier.Text = item.Name;
            txtSupplier.Tag = item;
            txtProduct.Focus();
            sender.Visible = false;
        }

        private void ctrlProductSearchControl_ItemSelected(SearchResultListControl<StoreProductInfo> sender, StoreProductInfo item)
        {
            txtProduct.Text = item.ProductId.ToString();
            txtProductName.Text = item.Name.ToString();
            txtProduct.Tag = item;
            txtRate.Text = item.PurchaseRate.ToString();
            txtRate.Focus();
            sender.Visible = false;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                double _qty = 0;
                double.TryParse(txtQty.Text, out _qty);

                if (_qty == 0)
                {
                    MessageBox.Show("Quantity required."); return;
                }

                new StoreItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as StoreProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));
                FillItemGrid();

                txtRate.Text = "";
                txtQty.Text = "";
                txtProductName.Text = "";
                //txtProduct.Text = "";
                txtProduct.Focus();
            }


        }

        private void FillItemGrid()
        {

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.Code, item.Name, item.Qty, item.Unit, item.Rate, item.Total);
                dgItems.Rows.Add(row);
            }


            CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void CalculateAmount()
        {
            txtTotalTk.Text = dgItems.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();

            txtDue.Text= dgItems.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();

            //txtPaid.Text= dgItems.Rows.Cast<DataGridViewRow>()
            //.Sum(t => Convert.ToInt32(t.Cells[5].Value)).ToString();

            txtTotalQty.Text= dgItems.Rows.Cast<DataGridViewRow>()
            .Sum(t => Convert.ToDouble(t.Cells[2].Value)).ToString();


            txtDiscount.Text = "";
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlProductSearchControl.Visible = true;
                ctrlProductSearchControl.LoadData();

            }


            else if (e.KeyChar == (char)Keys.Enter)
            {
                StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProduct.Text);
                if (_PInfo != null)
                {
                    txtProduct.Text = _PInfo.ProductCode;
                    txtProduct.Tag = _PInfo;
                    txtRate.Text = _PInfo.PurchaseRate.ToString();
                    txtRate.Focus();
                    txtProductName.Text = _PInfo.Name.ToString();

                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            else
            {
                DisplayProductInformation();
            }
        }

        private void DisplayProductInformation()
        {
            StoreProductInfo _PInfo = new StoreItemService().GetProductByCode(txtProduct.Text);
            if (_PInfo != null)
            {
                txtProduct.Text = _PInfo.ProductCode;
                txtProduct.Tag = _PInfo;
                ////txtRate.Text = _PInfo.PurchaseRate.ToString();
                ////txtRate.Focus();
                txtProductName.Text = _PInfo.Name.ToString();

            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {
                if (txtSupplier.Tag != null)
                {
                    double _totalTK = 0;
                    double _discountTk = 0;
                    double _paidTk = 0;

                    double.TryParse(txtTotalTk.Text, out _totalTK);
                    double.TryParse(txtDiscount.Text, out _discountTk);
                    double.TryParse(txtPaid.Text, out _paidTk);

                    //Company _company = new ItemService().GetAllCompany().FirstOrDefault();
                    //int nextInvoicenumber = new ItemService().GetAllReceivedCount(_company.ShortName) + 1;

                    // txtSupInvoice.Text = "" + _company.ShortName + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + "INV_" + nextInvoicenumber.ToString();


                    SupplierInfo _supplier = (SupplierInfo)txtSupplier.Tag;

                    StoreReceive _receive = new StoreReceive();
                    _receive.RDate = dtpRDate.Value;
                    _receive.Particulars = "NR"; //NR-> New Receive
                    _receive.TotalTk = _totalTK;
                    _receive.DiscountTk = _discountTk;
                    _receive.PaidTk = _paidTk;
                    _receive.SInvoiceDate = dtpSInvDate.Value;
                    _receive.SInvoiceNo = txtSupInvoice.Text;

                    _receive.SupplerId = _supplier.SupplierId;

                    Int64 _ReceiveId = new StoreItemService().SaveReceivedInvoice(_receive);

                    if (_ReceiveId > 0)
                    {

                        txtReceiveNo.Text = _ReceiveId.ToString();

                        //Voucher masterVoucher = new Voucher();
                        //masterVoucher.CompanyId = 1;
                        //masterVoucher.VoucherDate = dtpRDate.Value;
                        //masterVoucher.VoucherID = "";
                        //masterVoucher.VoucherType = "Debit";
                        //masterVoucher.Desccription = "Inventory Purchase";
                        //new VoucherService().AddMasterVoucher(masterVoucher);

                        //VoucherDetail detailsVoucher = new VoucherDetail();
                        //detailsVoucher.VMId = masterVoucher.VMId;
                        //detailsVoucher.DRCR = "C";
                        //detailsVoucher.Amount = _paidTk;
                        //detailsVoucher.AccId = 123;
                        //detailsVoucher.reamrks = "Inventory Purchase";

                        //new VoucherService().AddDetailsVoucher(detailsVoucher);


                       

                        List<StoreReceiveDetail> _rDeatailsList = new List<StoreReceiveDetail>();
                        //List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            SelectedProductsToSaleOrReceive selectedTests = row.Tag as SelectedProductsToSaleOrReceive;
                            StoreReceiveDetail _rDetails = new StoreReceiveDetail();
                            _rDetails.ReceiveId = _ReceiveId;
                            _rDetails.ProductId = Convert.ToInt16(selectedTests.ProductId);
                            _rDetails.Qty = Convert.ToDouble(selectedTests.Qty);
                            _rDetails.PurchaseRate = Convert.ToDouble(selectedTests.Rate);
                            _rDetails.Total = Convert.ToDouble(selectedTests.Qty) *
                                              Convert.ToDouble(selectedTests.Rate);

                            _rDeatailsList.Add(_rDetails);

                            double _currentStock = new StoreItemService().GetCurrentStockByProductId(selectedTests.ProductId);
                            double _currentpurchaseRate= new StoreItemService().GetCurrentPurchaseRateByProductId(selectedTests.ProductId);

                            double _currentTotalAmount = _currentStock * _currentpurchaseRate;

                            double newStock = _currentStock + Convert.ToDouble(selectedTests.Qty);
                            double newStockVal = _currentTotalAmount + Convert.ToDouble(selectedTests.Qty) * Convert.ToDouble(selectedTests.Rate);

                            double _newPRate = Math.Round(newStockVal / newStock);

                            StoreProductInfo _pInfo = new StoreItemService().GetProductById(selectedTests.ProductId);
                            _pInfo.PurchaseRate = _newPRate;
                            new StoreItemService().UpdateProductInfo(_pInfo);



                            //detailsVoucher = new VoucherDetail();
                            //detailsVoucher.VMId = masterVoucher.VMId;
                            //detailsVoucher.DRCR = "D";
                            //detailsVoucher.Amount = Convert.ToDouble(selectedTests.Qty) *
                            //                  Convert.ToDouble(selectedTests.Rate);
                            //detailsVoucher.AccId = selectedTests.DebitAccId ;
                            //detailsVoucher.reamrks = "Inventory Purchase";

                            //_rVoucherDetailList.Add(detailsVoucher);

                        }

                        if (new StoreItemService().SaveReceiveDetails(_rDeatailsList))
                        {
                            MessageBox.Show("Receive Successfull");
                            //masterVoucher = new Voucher();
                            //masterVoucher.CompanyId = 1;
                            //masterVoucher.VoucherDate = dtpRDate.Value;
                            //masterVoucher.VoucherID = "";
                            //masterVoucher.VoucherType = "Credit";
                            //masterVoucher.Desccription = "Invoice No: " + txtSupInvoice.Text;
                            //new VoucherService().AddMasterVoucher(masterVoucher);

                            //detailsVoucher = new VoucherDetail();
                            //detailsVoucher.VMId = masterVoucher.VMId;
                            //detailsVoucher.DRCR = "C";
                            //detailsVoucher.Amount = _totalTK;
                            //detailsVoucher.AccId = _supplier.SupAccId;
                            //detailsVoucher.reamrks = "Supply Invoice: " + txtSupInvoice.Text;
                            //new VoucherService().AddDetailsVoucher(detailsVoucher);

                            //if (_paidTk > 0)
                            //{
                            //    detailsVoucher = new VoucherDetail();
                            //    detailsVoucher.VMId = masterVoucher.VMId;
                            //    detailsVoucher.DRCR = "D";
                            //    detailsVoucher.Amount = _paidTk;
                            //    detailsVoucher.AccId = _supplier.SupAccId;
                            //    detailsVoucher.reamrks = "Supply Invoice: " + txtSupInvoice.Text;
                            //    new VoucherService().AddDetailsVoucher(detailsVoucher);

                            //}


                            this.AdJustSupplierLedger(_supplier.SupplierId, _totalTK, _discountTk);

                            ShowPurchaseInvoice(_ReceiveId);

                            ClearForm();
                        }

                        //if (_rVoucherDetailList.Count > 0)
                        //{
                        //    new AccountService().SaveVoucherDetails(_rVoucherDetailList);
                        //}
                    }

                }

                

                else
                {
                    MessageBox.Show("Supplier not selected.");
                }

            }
            else
            {
                MessageBox.Show("Product not selected.");
            }
        }

        private void ShowPurchaseInvoice(long _ReceiveId)
        {
            double _total = 0;
            double _discount = 0;
            double _gtotal = 0;

            double.TryParse(txtTotalTk.Text, out _total);
            double.TryParse(txtDiscount.Text, out _discount);
            
            _gtotal = _total - _discount;


            rptStockProductReceive _rpt = new rptStockProductReceive();


            DataSet ds = new PhFinancialService().GetStorePurchaseInvoice(_ReceiveId);

            _rpt.SetDataSource(ds.Tables[0]);




            _rpt.SetParameterValue("discount", txtDiscount.Text);
            _rpt.SetParameterValue("vat", "0");
            _rpt.SetParameterValue("gtotal", _gtotal.ToString());

            ReportViewer rv = new ReportViewer();

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();
             rv.Show();
        }

        private void AdJustSupplierLedger(int _SupplierId, double _totalTK, double _discountTk)
        {
            double _balance = new LedgerService().GetSupplierBanalce(_SupplierId);

            List<SupplierLedger> _sLedgerList = new List<SupplierLedger>();

            _balance = _balance + _totalTK;
            SupplierLedger _Ledger = new SupplierLedger();
            _Ledger.SupplierId = _SupplierId;
            _Ledger.Trandate = DateTime.Now;
            _Ledger.Particulars = "Receive Invoice ";
            _Ledger.Debit = 0;
            _Ledger.Credit = _totalTK;
            _Ledger.Balance = _balance;

            _sLedgerList.Add(_Ledger);

            if (_discountTk > 0)
            {
                _balance = _balance - _discountTk;
                _Ledger = new SupplierLedger();
                _Ledger.SupplierId = _SupplierId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = "Discount on Invoice ";
                _Ledger.Debit = _discountTk;
                _Ledger.Credit = 0;
                _Ledger.Balance = _balance;
                _sLedgerList.Add(_Ledger);
            }




            new LedgerService().SaveSupplierLedgerTransactions(_sLedgerList);
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            double _paidTk = 0;
            double.TryParse(txtPaid.Text, out _paidTk);

            double _discTk = 0;
            double.TryParse(txtDiscount.Text, out _discTk);

            double _dueTk = dgItems.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToDouble(t.Cells[5].Value));



            _dueTk = _dueTk - (_paidTk + _discTk);

            txtDue.Text = _dueTk.ToString();

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double _paidTk = 0;
            double.TryParse(txtPaid.Text, out _paidTk);

            double _discTk = 0;
            double.TryParse(txtDiscount.Text, out _discTk);

            double _dueTk = dgItems.Rows.Cast<DataGridViewRow>()
           .Sum(t => Convert.ToDouble(t.Cells[5].Value));

            _dueTk = _dueTk - (_paidTk+ _discTk);

            txtDue.Text = _dueTk.ToString();
        }

        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                ctlSupplierSearch.Visible = true;
                ctlSupplierSearch.LoadDataByType("Store");
            }
        }

        private void ctrlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void ctlSupplierSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void ctrlProductSearchControl_SearchEsacaped_1(bool IsEscaped)
        {
            if (IsEscaped) txtProduct.Focus();
        }

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedProductsToSaleOrReceive _SelectedItem = (SelectedProductsToSaleOrReceive)e.Row.Tag;
            _SelectedItems.Remove(e.Row.Tag as SelectedProductsToSaleOrReceive);
            CalculateAmount();

        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            StoreReceive _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtReceiveNo.Text))
            {
                _Invoice = new StoreItemService().GetStoreLastestReceiveInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtReceiveNo.Text, out _billNo);
                _Invoice = new StoreItemService().GetStoreReceiveInvoiceById(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new StoreItemService().GetStoreLastestReceiveInvoice();
                }
                else
                {
                    _Invoice = new StoreItemService().GetStoreReceiveInvoiceById(_Invoice.ReceiveId - 1);
                    if (_Invoice == null)
                    {
                        txtReceiveNo.Text = "";
                    }
                }

            }

            if (_Invoice != null)
            {
                txtReceiveNo.Text = _Invoice.ReceiveId.ToString();
                
                LoadPrevoiusReceiveInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invalid receive number.");
                _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
                ClearForm();

                btnSave.Enabled = true;
            }
        }

        private void LoadPrevoiusReceiveInfo(StoreReceive _Invoice)
        {
            if (_Invoice == null) return;

            txtTotalTk.Text = _Invoice.TotalTk.ToString();
            txtDiscount.Text = _Invoice.DiscountTk.ToString();
            txtPaid.Text = _Invoice.PaidTk.ToString();
            txtDue.Text = (_Invoice.TotalTk - _Invoice.DiscountTk- _Invoice.PaidTk).ToString();

            List<StoreReceiveDetail> _Invoicedetails = new StoreItemService().GetStoreReceiveDetails(_Invoice.ReceiveId).ToList();
            // List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(_InvoiceNo).ToList();
            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
            foreach (var lineitem in _Invoicedetails)
            {
                SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
                StoreProductInfo _pInfo = new StoreItemService().GetProductById(lineitem.ProductId);
                if (_pInfo != null)
                {

                    _sItem.ProductId = _pInfo.ProductId;
                    _sItem.Code = _pInfo.ProductCode;
                    _sItem.Name = _pInfo.Name;
                    _sItem.Qty = lineitem.Qty;
                    _sItem.Unit = _pInfo.Unit;
                    _sItem.DebitAccId = _pInfo.DebitAccId;
                    _sItem.CreditAccId = _pInfo.CreditAccId;
                    _sItem.Rate = _pInfo.SaleRate;
                    _sItem.Total = _pInfo.SaleRate * lineitem.Qty;

                    _SelectedItems.Add(_sItem);
                }
            }

            FillItemGridForPreviousReceive();
        }

        private void FillItemGridForPreviousReceive()
        {
            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (SelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.Code, item.Name, item.Qty, item.Unit, item.Rate, item.Total);
                dgItems.Rows.Add(row);
            }


            //CalculateAmount();
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            StoreReceive _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtReceiveNo.Text))
            {
                _Invoice = new StoreItemService().GetStoreFirstReceiveInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtReceiveNo.Text, out _billNo);
                _Invoice = new StoreItemService().GetStoreReceiveInvoiceById(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new StoreItemService().GetStoreLastestReceiveInvoice();
                }
                else
                {
                    _Invoice = new StoreItemService().GetStoreReceiveInvoiceById(_Invoice.ReceiveId + 1);
                }

            }

            if (_Invoice != null)
            {
                txtReceiveNo.Text = _Invoice.ReceiveId.ToString();
               
                LoadPrevoiusReceiveInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invalid receive number.");
                _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
                ClearForm();

                btnSave.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            long _ReceiveId = 0;
            long.TryParse(txtReceiveNo.Text, out _ReceiveId);
            ShowPurchaseInvoice(_ReceiveId);
        }

        private void btnNextReceive_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnSave.Enabled = true;
        }

        private void ctlSupplierSearch_Load(object sender, EventArgs e)
        {

        }
    }
    }

