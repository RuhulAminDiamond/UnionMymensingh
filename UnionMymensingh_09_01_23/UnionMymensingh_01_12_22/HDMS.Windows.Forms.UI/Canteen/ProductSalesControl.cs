using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Services.POS;
using Models.ViewModel;
using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI.Classes;
using Models.Canteen;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.Canteen;
using HDMS.Model.Canteen;

namespace POS.Forms
{
    public partial class ProductSalesControl : UserControl
    {
        double _subtotalTk = 0;
        double _discountTk = 0;
        double _receivedTk = 0;
        double _dueTk = 0;
        double _retunedAdjustedTk = 0;
        double _changeTk = 0;
        double _grandtotal = 0;
        bool unlocked = true;

        public ProductSalesControl()
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


        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearch.Visible = true;
                ctlProductSearch.LoadData();

            }

            if (e.KeyChar == (char)Keys.Enter)
             {
                 CantProductInfo _PInfo = new CantItemService().GetProductByCode(txtProduct.Text);
                 if (_PInfo != null)
                 {
                     txtProduct.Text = _PInfo.ProductCode;
                     txtProduct.Tag = _PInfo;
                     txtRate.Text = _PInfo.SaleRate.ToString();
                     txtProductName.Text = _PInfo.Name.ToString();
                     txtRate.Focus();
                 }
             }

            if (e.KeyChar == (char)Keys.Escape)
            {
                txtDiscountInPercent.Focus();
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearch.Visible = false;
            CtlCustomerSearch.Visible = false;
            // ctlOrderSearch.Visible = false;

        }

        private IList<CantSelectedProductsToSaleOrReceive> _SelectedItems;

        private void ProductSalesControl_Load(object sender, EventArgs e)
        {
            _SelectedItems = new List<CantSelectedProductsToSaleOrReceive>();

            ctlProductSearch.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctlProductSearch.ItemSelected += CtlProductSearch_ItemSelected;
            CtlCustomerSearch.Location = new Point(txtCustomer.Location.X, txtCustomer.Location.Y + txtCustomer.Height);
            CtlCustomerSearch.ItemSelected += CtlCustomerSearch_ItemSelected;

            //ctlOrderSearch.Location = new Point(txtTableInfo.Location.X, txtTableInfo.Location.Y + txtTableInfo.Height);
            //ctlOrderSearch.ItemSelected += ctlOrderSearch_ItemSelected;


            //txtProduct.GotFocus += new System.EventHandler(this.txtGotFocus);
            //dtpInvData.Focus();
            AddNewSale();
         

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

        }

        private void ctlOrderSearch_ItemSelected(SearchResultListControl<OrderSource> sender, OrderSource item)
        {
            
            sender.Visible = false;
            txtProduct.Focus();
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

        private void CtlProductSearch_ItemSelected(SearchResultListControl<CantProductInfo> sender, CantProductInfo item)
        {
            txtProduct.Text = item.ProductCode;
            txtProduct.Tag = item;
            txtProductName.Text = item.Name;
            txtRate.Text = item.SaleRate.ToString();
            txtRate.Focus();
            sender.Visible = false;
        }

        private void txtGotFocus(object sender, EventArgs e)
        {
            HideAllDefaultHidden();
            //ctlProductSearch.Visible = true;
            //ctlProductSearch.LoadData("Retail");
        }

       
        private void CtlCustomerSearch_ItemSelected(SearchResultListControl<CantMemberInfo> sender, CantMemberInfo item)
        {
            txtCustomer.Text = item.Name;
            txtCustomer.Tag = item.MemberId;
         
            sender.Visible = false;
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                CtlCustomerSearch.Visible = true;

                CtlCustomerSearch.LoadData();
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtProduct.Focus();
            }

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtInvoiceNo.Tag != null)
                {
                    int _prodId = 0;
                    int.TryParse(txtProduct.Text, out _prodId);
                    if (_SelectedItems.Any(q=>q.Id== _prodId))
                    {
                        double _qty = 0;
                        double.TryParse(txtQty.Text, out _qty);
                        double _rate = 0;
                        double.TryParse(txtRate.Text, out _rate);
                        _SelectedItems.Where(w => w.Id == _prodId).ToList().ForEach(s => s.Qty = _qty);
                        _SelectedItems.Where(w => w.Id == _prodId).ToList().ForEach(s => s.Rate = _rate);
                        _SelectedItems.Where(w => w.Id == _prodId).ToList().ForEach(s => s.Total = _qty*_rate);

                        unlocked = false;
                          txtProduct.Text = "";
                        unlocked = true;

                        txtProductName.Text = "";
                        txtQty.Text = "";
                        txtRate.Text = "";
                        txtProduct.Focus();

                    }
                    else
                    {
                        new CantItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as CantProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));

                        unlocked = false;
                          txtProduct.Text = "";
                        unlocked = true;
                        txtProductName.Text = "";
                        txtQty.Text = "";
                        txtRate.Text = "";
                        txtProduct.Focus();
                    }


                    FillItemGrid();

                }
                else
                {

                    if (!String.IsNullOrEmpty(txtQty.Text) && txtProduct.Tag != null)
                    {
                        double _Qty = 0;
                        double.TryParse(txtQty.Text, out _Qty);
                        CantProductInfo _PInfo = (CantProductInfo)txtProduct.Tag;
                        double _CurrentStock = new CantItemService().GetCurrentStockByProductId(_PInfo.Id);
                        if (_Qty <= _CurrentStock)
                        {

                            if (_SelectedItems.Any(q => q.Id == _PInfo.Id))
                            {
                                double _qty = 0;
                                double.TryParse(txtQty.Text, out _qty);
                                double _rate = 0;
                                double.TryParse(txtRate.Text, out _rate);
                                _SelectedItems.Where(w => w.Id == _PInfo.Id).ToList().ForEach(s => s.Qty = _qty);
                                _SelectedItems.Where(w => w.Id == _PInfo.Id).ToList().ForEach(s => s.Rate = _rate);
                                _SelectedItems.Where(w => w.Id == _PInfo.Id).ToList().ForEach(s => s.Total = _qty * _rate);

                                unlocked = false;
                                txtProduct.Text = "";
                                unlocked = true;

                                txtProductName.Text = "";
                                txtQty.Text = "";
                                txtRate.Text = "";
                                txtProduct.Focus();

                            }
                            else
                            {

                                new CantItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as CantProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));
                              
                                unlocked = false;
                                txtProduct.Text = "";
                                unlocked = true;
                                txtProductName.Text = "";
                                txtQty.Text = "";
                                txtRate.Text = "";
                                txtProduct.Focus();
                            }

                            FillItemGrid();
                        }
                        else
                        {
                            MessageBox.Show("Stock not available/Insufficient.");
                            unlocked = false;
                            txtProduct.Text = "";
                            unlocked = true;
                            txtProductName.Text = "";
                            txtQty.Text = "";
                            txtRate.Text = "";
                            txtProduct.Focus();
                        }

                    }
                }
            }
        }


        private void FillItemGrid()
        {

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (CantSelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.Code, item.Name,item.Qty,item.Unit,item.Rate,item.Total);
                dgItems.Rows.Add(row);
            }

           
            CalculateAmount();
            //dgTests.ResumeLayout();
        }



        private void CalculateAmount()
        {

            double _totalAmount = 0;

            _totalAmount = dgItems.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToDouble(t.Cells[5].Value));

            txtTotalAmount.Text = _totalAmount.ToString();



            txtGrandTotal.Text = _totalAmount.ToString();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(txtProduct.Text, out itemId))
            {

            }
            else
            {
                unlocked = false;

                if (unlocked)
                {
                    string _txt = txtProduct.Text;
                    HideAllDefaultHidden();
                    ctlProductSearch.Visible = true;
                    ctlProductSearch.txtSearch.Text = _txt;
                    ctlProductSearch.txtSearch.SelectionStart = ctlProductSearch.txtSearch.Text.Length;

                    ctlProductSearch.LoadData();
                }
            }
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double _due = CalculateDueAndChange();
        }


        private double CalculateDueAndChange()
        {
            double totalAmount = 0;
            double totalDiscount = 0;
            double totalReceived = 0;
            double totalRefundTk = 0;
            double totaldue = 0;
            double gTotal=0; 
            double _totalChange=0;


            double.TryParse(txtTotalAmount.Text, out totalAmount);
            double.TryParse(txtDiscount.Text, out totalDiscount);
            double.TryParse(txtReceived.Text, out totalReceived);
          

            gTotal = totalAmount - totalDiscount;

            txtGrandTotal.Text = gTotal.ToString();

            //totaldue = totalAmount - totalDiscount - totalReceived;
            if (totalReceived > gTotal)
            {
                txtChange.Text = (totalReceived - gTotal).ToString();

                _totalChange = totalReceived - gTotal;

                totaldue = 0;
            }
            else
            {
                totaldue = gTotal - totalReceived;
                txtChange.Text = "0";
            }

            return totaldue;

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           double _due =  CalculateDueAndChange();
        }

     
        private void btnSave_Click(object sender, EventArgs e)
        {

            

            try
            {

                if (dgItems.Rows.Count > 0)
                {

              
                    if (txtInvoiceNo.Tag != null)  // Update existing Invoice
                    {
                        UpdateExistingInvoice(Convert.ToInt64(txtInvoiceNo.Tag));
                    }
                    else  // New Invoice
                    {
                        AddNewInvoice();
                    }


                   
                }
                else
                {
                    MessageBox.Show("Product/Customer not selected.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Invoice not save as "+ex.Message.ToString());
            }

        }

        private void UpdateExistingInvoice(long _InvoiceId)
        {
            int _returnedInvoice = 0;
            int _customerId = 0;

            if (txtCustomer.Tag != null)
            {
                _customerId = Convert.ToInt32(txtCustomer.Tag);
            }

            double.TryParse(txtTotalAmount.Text, out _subtotalTk);
            double.TryParse(txtDiscount.Text, out _discountTk);
            double.TryParse(txtReceived.Text, out _receivedTk);
            double.TryParse(txtGrandTotal.Text, out _grandtotal);
            //int.TryParse(txtAdjustInv.Text, out _returnedInvoice);
            //double.TryParse(txtAdjustedTk.Text, out _retunedAdjustedTk);
            double.TryParse(txtChange.Text, out _changeTk);

            if (_receivedTk >= _subtotalTk)
            {
                _dueTk = 0;
            }
            else
            {
                _dueTk = _subtotalTk - (_discountTk + _receivedTk);
            }

            if(_dueTk>0 && _customerId == 0)
            {
                MessageBox.Show("It's due sale.Plz. Select customer then try again.");return;
            }

            CantInvoice _invoice = new CantItemService().GetInvoiceByInvoiceNo(_InvoiceId);

            if(_invoice != null)
            {
                _invoice.MobileNo = "";

                _invoice.TotalTK = _subtotalTk + _retunedAdjustedTk;
                _invoice.DiscountTK = _discountTk;
                _invoice.GrandTK = (_subtotalTk + _retunedAdjustedTk) - _discountTk;
                _invoice.ReceivedTK = _receivedTk;
                _invoice.ChangeTK = _changeTk;
                _invoice.DueTK = _dueTk;
                _invoice.ReturnAdjustedTK = _retunedAdjustedTk;
                _invoice.InvoiceNumber = 0;
                _invoice.ChallanNumber = "";
                _invoice.ChallanAddress = "";
                _invoice.InvoiceType = "RS"; // RS-> Retail Sales
                _invoice.ReturnedInvoiceNo = _returnedInvoice;
                _invoice.CustomerId = _customerId;

                new CantItemService().UpdateInvoice(_invoice);

                List<CantInvoiceDetail> _invdetailList = new ReportingService().GetInvoiceDetails(_InvoiceId);
                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    CantSelectedProductsToSaleOrReceive selectedItems = row.Tag as CantSelectedProductsToSaleOrReceive;
                    _invdetailList.Where(w => w.ProductId == selectedItems.Id).ToList().ForEach(s => s.Qty = selectedItems.Qty);
                    _invdetailList.Where(w => w.ProductId == selectedItems.Id).ToList().ForEach(s => s.SaleRate = selectedItems.Rate);
                    _invdetailList.Where(w => w.ProductId == selectedItems.Id).ToList().ForEach(s => s.TotalPrice = selectedItems.Total);
                }

                new ReportingService().UpdateInvoiceDetails(_invdetailList);  // Previously added item will be updated.


                List<CantInvoiceDetail> _newItems = new List<CantInvoiceDetail>();
                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    CantSelectedProductsToSaleOrReceive _selectedItems = row.Tag as CantSelectedProductsToSaleOrReceive;
                    if (!_invdetailList.Any(q => q.ProductId == _selectedItems.Id))
                    {
                        CantInvoiceDetail invd = new CantInvoiceDetail();
                        invd.InvoiceId = _InvoiceId;
                        invd.ProductId = Convert.ToInt16(_selectedItems.Id);
                        invd.Qty = Convert.ToDouble(_selectedItems.Qty);
                        invd.SaleRate = Convert.ToDouble(_selectedItems.Rate);
                        invd.TotalPrice = Convert.ToDouble(_selectedItems.Qty) *
                                                 Convert.ToDouble(_selectedItems.Rate);
                        invd.Discount = 0;
                        invd.PurchaseRate = 0;

                        _newItems.Add(invd);
                    }

                }


                if (_newItems.Count > 0)
                {
                    new CantItemService().AddNewInvDetails(_newItems);
                }


                new CantItemService().DeleteExistingLedger(_InvoiceId);

                MessageBox.Show("Invoice save successfully.");

                double balance = 0;
                balance = 0 - _subtotalTk;
                //Save On Entry Payment Information
                List<CantSaleLedger> transactionList = new List<CantSaleLedger>();
                CantSaleLedger pLedger = new CantSaleLedger();
                pLedger.InvoiceId = _InvoiceId;
                pLedger.TranDate = DateTime.Now;
                pLedger.Particulars = "Product/s Price";
                pLedger.Debit = _subtotalTk;
                pLedger.Credit = 0;
                pLedger.Balance = balance;
                pLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                transactionList.Add(pLedger);

                if (_discountTk > 0)
                {

                    balance = balance + _discountTk;
                    pLedger = new CantSaleLedger();
                    pLedger.InvoiceId = _InvoiceId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = _discountTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }



                double paidTk = _receivedTk - _changeTk;
                if (paidTk > 0)
                {

                    balance = balance + paidTk;
                    pLedger = new CantSaleLedger();
                    pLedger.InvoiceId = _InvoiceId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Paid as Recive Tk. " + _receivedTk.ToString() + "Change Tk. " + _changeTk.ToString();
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                if (transactionList.Count > 0)
                {
                    new LedgerService().SaveSaleLedger(transactionList);
                }



                ShowInvoice(_InvoiceId);
                ShowInvoice(_InvoiceId);
                ShowInvoice(_InvoiceId);
                // this.AdJustCustomerLedger(Convert.ToInt32(txtCustomer.Tag), _totalTk, _discountTk, _receivedTk);


                ClearForm();
                AddNewSale();
            }
        }

        private void AddNewInvoice()
        {

            int _returnedInvoice = 0;
            int _customerId = 0;

            if (txtCustomer.Tag != null)
            {
                _customerId = Convert.ToInt32(txtCustomer.Tag);
            }

            double.TryParse(txtTotalAmount.Text, out _subtotalTk);
            double.TryParse(txtDiscount.Text, out _discountTk);
            double.TryParse(txtReceived.Text, out _receivedTk);
            double.TryParse(txtGrandTotal.Text, out _grandtotal);
            //int.TryParse(txtAdjustInv.Text, out _returnedInvoice);
            //double.TryParse(txtAdjustedTk.Text, out _retunedAdjustedTk);
            double.TryParse(txtChange.Text, out _changeTk);

            if (_receivedTk >= _subtotalTk)
            {
                _dueTk = 0;
            }
            else
            {
                _dueTk = _subtotalTk - (_discountTk + _receivedTk);
            }


            if (_dueTk > 0 && _customerId == 0)
            {
                MessageBox.Show("It's due sale.Plz. Select customer then try again."); return;
            }


            CantInvoice _invoice = new CantInvoice();
            _invoice.Invdate = Convert.ToDateTime(dtpInvData.Text);
            _invoice.MobileNo ="";

            _invoice.TotalTK = _subtotalTk + _retunedAdjustedTk;
            _invoice.DiscountTK = _discountTk;
            _invoice.GrandTK = (_subtotalTk + _retunedAdjustedTk) - _discountTk;
            _invoice.ReceivedTK = _receivedTk;
            _invoice.ChangeTK = _changeTk;
            _invoice.DueTK = _dueTk;
            _invoice.ReturnAdjustedTK = _retunedAdjustedTk;
            _invoice.InvoiceNumber = 0;
            _invoice.ChallanNumber = "";
            _invoice.ChallanAddress = "";
            _invoice.InvoiceType = "RS"; // RS-> Retail Sales
            _invoice.ReturnedInvoiceNo = _returnedInvoice;
            _invoice.CustomerId = _customerId;


            long _InvoiceId = new CantItemService().AddNewInvoice(_invoice);

            if (_InvoiceId > 0)
            {

                CantInvoice _invce = new CantItemService().GetInvoiceByInvoiceNo(_InvoiceId);

                if (_invce != null)
                {
                    txtInvoiceNo.Text = _invce.InvoiceNumber.ToString();
                    txtInvoiceNo.Tag = _InvoiceId.ToString();
                }
                else
                {
                    txtInvoiceNo.Text = "";
                }

                List<CantInvoiceDetail> _invDetailsList = new List<CantInvoiceDetail>();

                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    CantSelectedProductsToSaleOrReceive selectedTests = row.Tag as CantSelectedProductsToSaleOrReceive;
                    CantInvoiceDetail _invDetails = new CantInvoiceDetail();
                    _invDetails.InvoiceId = _InvoiceId;
                    _invDetails.ProductId = Convert.ToInt16(selectedTests.Id);
                    _invDetails.Qty = Convert.ToDouble(selectedTests.Qty);
                    _invDetails.SaleRate = Convert.ToDouble(selectedTests.Rate);
                    _invDetails.TotalPrice = Convert.ToDouble(selectedTests.Qty) *
                                             Convert.ToDouble(selectedTests.Rate);
                    _invDetails.Discount = 0;
                    _invDetails.PurchaseRate = 0;

                    _invDetailsList.Add(_invDetails);
                }

                new CantItemService().AddNewInvDetails(_invDetailsList);
                MessageBox.Show("Invoice save successfully.");

                double balance = 0;
                balance = 0 - _subtotalTk;
                //Save On Entry Payment Information
                List<CantSaleLedger> transactionList = new List<CantSaleLedger>();
                CantSaleLedger pLedger = new CantSaleLedger();
                pLedger.InvoiceId = _InvoiceId;
                pLedger.TranDate = DateTime.Now;
                pLedger.Particulars = "Product/s Price";
                pLedger.Debit = _subtotalTk;
                pLedger.Credit = 0;
                pLedger.Balance = balance;
                pLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                pLedger.OperateBy = MainForm.LoggedinUser.Name;
                transactionList.Add(pLedger);

                if (_discountTk > 0)
                {

                    balance = balance + _discountTk;
                    pLedger = new CantSaleLedger();
                    pLedger.InvoiceId = _InvoiceId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Discount";
                    pLedger.Debit = 0;
                    pLedger.Credit = _discountTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }



                double paidTk = _receivedTk - _changeTk;
                if (paidTk > 0)
                {

                    balance = balance + paidTk;
                    pLedger = new CantSaleLedger();
                    pLedger.InvoiceId = _InvoiceId;
                    pLedger.TranDate = DateTime.Now;
                    pLedger.Particulars = "Paid as Recive Tk. " + _receivedTk.ToString() + "Change Tk. " + _changeTk.ToString();
                    pLedger.Debit = 0;
                    pLedger.Credit = paidTk;
                    pLedger.Balance = balance;
                    pLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                    pLedger.OperateBy = MainForm.LoggedinUser.Name;
                    transactionList.Add(pLedger);
                }

                if (transactionList.Count > 0)
                {
                    new LedgerService().SaveSaleLedger(transactionList);
                }


                if (_customerId > 0)
                {
                    balance = new LedgerService().GetBanalce(_customerId);
                    balance = balance - _subtotalTk;
                    //Save On Entry Payment Information
                    List<CantMemberLedger> _custTransaction = new List<CantMemberLedger>();
                    CantMemberLedger cLedger = new CantMemberLedger();
                    cLedger.CustomerId = _customerId;
                    cLedger.Trandate = DateTime.Now;
                    cLedger.Particulars = "Product/s Price (Invoice No: "+ _InvoiceId.ToString() + ")";
                    cLedger.Debit = _subtotalTk;
                    cLedger.Credit = 0;
                    cLedger.Balance = balance;
                    cLedger.TransactionType = TransactionTypeEnum.PhProductCost.ToString();
                    cLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _custTransaction.Add(cLedger);

                    if (_discountTk > 0)
                    {

                        balance = balance + _discountTk;
                        cLedger = new CantMemberLedger();
                        cLedger.CustomerId = _customerId;
                        cLedger.Trandate = DateTime.Now;
                        cLedger.Particulars = "Discount on (Invoice No: " + _InvoiceId.ToString() + ")";
                        cLedger.Debit = 0;
                        cLedger.Credit = _discountTk;
                        cLedger.Balance = balance;
                        cLedger.TransactionType = TransactionTypeEnum.PhDiscount.ToString();
                        cLedger.OperateBy = MainForm.LoggedinUser.Name;
                        _custTransaction.Add(cLedger);
                    }



                    paidTk = _receivedTk - _changeTk;
                    if (paidTk > 0)
                    {

                        balance = balance + paidTk;
                        cLedger = new CantMemberLedger();
                        cLedger.CustomerId = _customerId;
                        cLedger.Trandate = DateTime.Now;
                        cLedger.Particulars = "Paid on Invoice ( " + _InvoiceId.ToString() + ")"; 
                        cLedger.Debit = 0;
                        cLedger.Credit = paidTk;
                        cLedger.Balance = balance;
                        cLedger.TransactionType = TransactionTypeEnum.PhPaidAmount.ToString();
                        cLedger.OperateBy = MainForm.LoggedinUser.Name;
                        _custTransaction.Add(cLedger);
                    }

                    if (_custTransaction.Count > 0)
                    {
                        new LedgerService().SaveCustomerLedger(_custTransaction);
                    }
                }


                ShowInvoice(_InvoiceId);
                //ShowInvoice(_InvoiceId);
               // ShowInvoice(_InvoiceId);

                // this.AdJustCustomerLedger(Convert.ToInt32(txtCustomer.Tag), _totalTk, _discountTk, _receivedTk);


                ClearForm();
                AddNewSale();
            }
        }

        private void AdJustCustomerLedger(int _CustomerId, double _ttlTk, double _discoutTk, double _receiveTk)
        {
            double _balance = new LedgerService().GetBanalce(_CustomerId);

            List<CantMemberLedger> _cLedgerList = new List<CantMemberLedger>();

            _balance = _balance + _ttlTk;
            CantMemberLedger _Ledger = new CantMemberLedger();
            _Ledger.CustomerId = _CustomerId;
            _Ledger.Trandate = DateTime.Now;
            _Ledger.Particulars = "Purchase Invoice ";
            _Ledger.Debit = _ttlTk;
            _Ledger.Credit = 0;
            _Ledger.Balance = _balance;

            _cLedgerList.Add(_Ledger);

            if (_discoutTk > 0)
            {
                _balance = _balance - _discoutTk;
                _Ledger = new CantMemberLedger();
                _Ledger.CustomerId = _CustomerId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = "Discount on Invoice ";
                _Ledger.Debit = 0;
                _Ledger.Credit = _discoutTk; ;
                _Ledger.Balance = _balance;
                _cLedgerList.Add(_Ledger);
            }

            if (_receiveTk > 0)
            {
                _balance = _balance - _receiveTk;
                _Ledger = new CantMemberLedger();
                _Ledger.CustomerId = _CustomerId;
                _Ledger.Trandate = DateTime.Now;
                _Ledger.Particulars = "Payment By Cash on Purchase Invoice ";
                _Ledger.Debit = 0;
                _Ledger.Credit = _receiveTk; ;
                _Ledger.Balance = _balance;
                _cLedgerList.Add(_Ledger);
            }


            new LedgerService().SaveCustomerLedgerTransactions(_cLedgerList);

        }

        private void ShowInvoice(long invocieId)
        {

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            DataSet ds = new ReportingService().GetCanteenSaleDataByinvocieId(invocieId);

            rptPosSaleInvoice _rpt = new rptPosSaleInvoice();

            _rpt.SetDataSource(ds.Tables[0]);

            CantInvoice _pInvoice = new ReportingService().GetInvoiceById(invocieId);
            List<VMCanteenCashMemoTranactionList> _cashtranList = Helper.GetCanteenCashMemoTransactionList(_pInvoice);

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


            _rpt.SetParameterValue("CompanyName", "Adora Snacks");
            
            _rpt.SetParameterValue("CAddress", "Akhalia, Sylhet");
            
            _rpt.SetParameterValue("CMobile", "");

            _rpt.SetParameterValue("Table", "");

            _rpt.SetParameterValue("Mobile", "");



            _rpt.SetParameterValue("serveby", MainForm.LoggedinUser.Name);

            //RptSaleProduct _rpt = new RptSaleProduct();


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.ShowDialog();
        }

       

        private void ClearForm()
        {
            unlocked = false;
            txtProduct.Text = "";
            unlocked = true;
            txtProductName.Text = "";
            txtRate.Text = "";
            txtQty.Text = "";
            txtTotalAmount.Text = "";
            txtDiscount.Text = "";
            txtReceived.Text = "";
            txtChange.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceNo.Tag = null;
          

            txtCustomer.Text = "";
            txtCustomer.Tag = null;

           

            dgItems.Rows.Clear();
            _SelectedItems = new List<CantSelectedProductsToSaleOrReceive>();
        }

    
        private void AddNewSale()
        {
            ClearForm();
           
          
        }

      
      
        private void btnClear_Click(object sender, EventArgs e)
        {
            AddNewSale();
        }

     
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if(txtInvoiceNo.Tag != null)
            {
                ShowInvoice(Convert.ToInt64(txtInvoiceNo.Tag));
            }
          
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtReceived.Focus();
            }
        }

     
      
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtProduct.Focus();
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (String.IsNullOrEmpty(txtInvoiceNo.Text)) return;


                long _inv = 0;
                long.TryParse(txtInvoiceNo.Text, out _inv);
                CantInvoice _invce = new CantItemService().GetInvoiceByInvoiceNumber(_inv);

                if (_invce != null)
                {
                    txtInvoiceNo.Tag = _invce.InvoiceId;
                    LoadItems(_invce.InvoiceId);
                }else
                {
                    MessageBox.Show("Invalid Invoice No.");
                    txtInvoiceNo.Tag = null;
                }
            }
        }

        private void LoadItems(long invoiceId)
        {
            _SelectedItems = new CantItemService().GetSoldItems(invoiceId);

            CantInvoice _invoice = new CantItemService().GetInvoiceByInvoiceNo(invoiceId);

           
               

          //  OrderSource _orders = new ItemService().GetOrderSourceById(_invoice.OrderFrom);

           

            txtTotalAmount.Text = _invoice.TotalTK.ToString();
            txtDiscount.Text = _invoice.DiscountTK.ToString();
            txtReceived.Text = _invoice.ReceivedTK.ToString();

            FillItemGrid();
        }

        private void dgItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgItems.SelectedRows.Count > 0)
            {
                CantSelectedProductsToSaleOrReceive sr = dgItems.SelectedRows[0].Tag as CantSelectedProductsToSaleOrReceive;
                unlocked = false;
                
               
                txtProduct.Text = sr.Id.ToString();
                txtProductName.Text = sr.Name;
                txtRate.Text = sr.Rate.ToString();
                txtQty.Text = sr.Qty.ToString();

                unlocked = true;
            }
        }

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

            if (txtInvoiceNo.Tag != null)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this item?", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {

                    CantSelectedProductsToSaleOrReceive _dItem = e.Row.Tag as CantSelectedProductsToSaleOrReceive;
                    _SelectedItems.Remove(_dItem);

                    new CantItemService().DeleteInvoiceItem(Convert.ToInt64(txtInvoiceNo.Tag), _dItem.Id);
                }

            }
            else
            {

                CantSelectedProductsToSaleOrReceive _dItem = e.Row.Tag as CantSelectedProductsToSaleOrReceive;
                _SelectedItems.Remove(_dItem);

            }

           
             
            CalculateAmount();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTableInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();

               // ctlOrderSearch.Visible = true;
               // ctlOrderSearch.LoadData("");
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtProduct.Focus();
            }
        }

     

      

        private void txtDiscountInPercent_TextChanged(object sender, EventArgs e)
        {

            double totalAmount = 0;
            double totalDiscount = 0;
            double totalReceived = 0;
            double totalRefundTk = 0;
            double totaldue = 0;
            double gTotal = 0;
            double _totalChange = 0;


            double.TryParse(txtTotalAmount.Text, out totalAmount);

            double _discPercent = 0;
            double.TryParse(txtDiscountInPercent.Text, out _discPercent);

            if (_discPercent > 0)
            {
                totalDiscount = Math.Round((totalAmount * _discPercent) / 100);
                txtDiscount.Text = totalDiscount.ToString();
            }else
            {
                txtDiscount.Text = "";
            }


        }

        private void txtDiscountInPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDiscount.Focus();
            }
        }

        private void ctlProductSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void CtlCustomerSearch_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtCustomer.Focus();
            }
        }
    }
}
