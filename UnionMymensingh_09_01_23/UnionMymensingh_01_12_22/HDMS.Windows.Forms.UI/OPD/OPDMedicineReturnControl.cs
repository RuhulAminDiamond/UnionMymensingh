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
using HDMS.Model.ViewModel;
using HDMS.Models.Pharmacy;
using HDMS.Service.Pharmacy;
using HDMS.Model;
using HDMS.Service.Hospital;
using HDMS.Model.Pharmacy;
using HDMS.Model.Enums;
using HDMS.Windows.Forms.UI;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Model.Users;
using HDMS.Service;
using HDMS.Model.Hospital;
using HDMS.Windows.Forms.UI.Reports.Pharmacy;
using HDMS.Common.Utils;
using CrystalDecisions.Windows.Forms;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Windows.Forms.UI.Controls;

namespace Hospital.UI.Forms.OPD
{
    public partial class OPDMedicineReturnControl : UserControl
    {
        List<PhSelectedProductsToSaleOrReceiveOrOrder> _ReturnItems;
        List<PhSelectedProductsToSaleOrReceiveOrOrder> _SoldItems;

        bool isLoaded = false;
        public OPDMedicineReturnControl()
        {
            InitializeComponent();
        }

        private void txtInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                long _InvoiceNo = 0;
                long.TryParse(txtInvoice.Text, out _InvoiceNo);

              

                PhInvoice _Invoice = new PhProductService().GetPhInvoiceByBillNo(_InvoiceNo);

                if (_InvoiceNo == 0 || _Invoice==null)
                {
                    MessageBox.Show("Invoice not found. Please check it and try again.");
                    return;
                }

                //if (_Invoice.AdmissionNo > 0)
                //{
                //    MessageBox.Show("It's a indoor invoice. Only sisters are allowed to return this invoice.");
                //    return;
                //}

                txtInvoiceTo.Text = _Invoice.InvoiceId.ToString();
                txtInvoice.Tag = _Invoice;

         


                List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(_Invoice.InvoiceId).ToList();

                 _SoldItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
                foreach (var lineitem in _Invoicedetails)
                {
                    PhSelectedProductsToSaleOrReceiveOrOrder _sItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
                    PhProductInfo _pInfo= new PhProductService().GetProductById(lineitem.ProductId);
                    _sItem.InvoiceId = lineitem.InvoiceId;
                    _sItem.LotNo = lineitem.LotNo;
                    _sItem.OutLetId = _Invoice.OutLetId;
                    _sItem.Id = lineitem.ProductId;
                    _sItem.Code = lineitem.ProductId.ToString();
                    _sItem.Name = _pInfo.BrandName;
                    _sItem.Qty = lineitem.Qty;
                    _sItem.RetQty = lineitem.RetQty;
                    _sItem.Unit = _pInfo.Unit;
                    _sItem.SRate = lineitem.SaleRate;
                    _sItem.Total = lineitem.TotalPrice;
                 
                    _SoldItems.Add(_sItem);
                }

                FillItemGrid(_SoldItems);

                LoadPaymentHistory(_InvoiceNo);
            }
        }


        private void LoadPaymentHistory(long _InvoiceNo)
        {
           

                PhInvoice _invoice = new PhProductService().GetPhInvoiceByBillNo(_InvoiceNo);

                if (_invoice == null)
                {
                    MessageBox.Show("Invoce not found. Please check and try again.");
                    return;
                }

            

                List<PhSaleLedger> _pLedgerItesms = new PhProductService().GetPhLedgerByInvoice(_invoice.InvoiceId);

                gvLedger.AutoGenerateColumns = false;
                gvLedger.DataSource = _pLedgerItesms;

                double totalTestAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells["Debit"].Value));

                double totalPaidAmount = gvLedger.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDouble(t.Cells["Credit"].Value));

                double due = totalTestAmount - totalPaidAmount;

               txtDue.Text = due.ToString();


        }

        private double GetReutrnedAmount()
        {
            return _ReturnItems.Sum(q => q.Total);
        }

        private void FillItemGrid(List<PhSelectedProductsToSaleOrReceiveOrOrder> _soldItems)
        {

            dgItems.SuspendLayout();
            dgItems.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _soldItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.InvoiceId, item.LotNo, item.Code, item.Name, item.Qty,item.RetQty, item.Unit, item.SRate, item.Total);
                dgItems.Rows.Add(row);
            }


           // CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void btnRightSingle_Click(object sender, EventArgs e)
        {

            double _discountAdjustment = 0;

            foreach (DataGridViewRow r in dgItems.SelectedRows)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _spsr = (PhSelectedProductsToSaleOrReceiveOrOrder)r.Tag;

               double _retQty = _spsr.Qty - _spsr.RetQty;

                if (_ReturnItems.Any(x => x.Code == _spsr.Code)) return;

                if (_retQty > 0)
                {
                    _ReturnItems.Add(_spsr);
                    if (!String.IsNullOrEmpty(txtAdmissionNo.Text))
                    {
                        _ReturnItems.Where(w => w.Id == _spsr.Id && w.LotNo == _spsr.LotNo && w.OutLetId == _spsr.OutLetId).ToList().ForEach(s => s.Qty = _retQty);
                    }else
                    {
                        _ReturnItems.Where(w => w.Id == _spsr.Id).ToList().ForEach(s => s.Qty = _retQty);

                    }
                }
                else
                {
                    MessageBox.Show("Qty not available for return.");
                }

               
            }


               FillReturnItemGrid(_ReturnItems);


               CalculateReturnAmount();

               CalculateDiscountAdjustment(txtReturnTk.Text);


         
        }

        private void CalculateDiscountAdjustment(string _returnAmount)
        {

            double _discountAdjustment = 0;

            foreach (DataGridViewRow r in dgReturnItem.Rows)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _spsr = (PhSelectedProductsToSaleOrReceiveOrOrder)r.Tag;


                PhInvoice _Invoice = new PhProductService().GetPhInvoiceByInvoiceId(_spsr.InvoiceId);

                _discountAdjustment =  _discountAdjustment + Math.Round(((_spsr.Qty * _spsr.SRate) * _Invoice.DiscountTK) / _Invoice.TotalTK,2);
            }

            double _return = 0;
            double netReturn = 0;
            double.TryParse(_returnAmount, out _return);
            double _due = 0;
            double.TryParse(txtDue.Text, out _due);

            netReturn = _return - _discountAdjustment;

            txtDiscountAdjusted.Text = _discountAdjustment.ToString();

            if (netReturn > _due)
            {
                txtNetReturn.Text = (netReturn- _due).ToString();

            }
            else
            {
                txtNetReturn.Text ="0";
            }

           
        }

        private void CalculateReturnAmount()
        {
            double _ReturnedTk = GetReutrnedAmount();

            txtReturnTk.Text =  Math.Round(_ReturnedTk, 0).ToString();

           
        }

        private void FillReturnItemGrid(List<PhSelectedProductsToSaleOrReceiveOrOrder> _returnItems)
        {

            dgReturnItem.SuspendLayout();
            dgReturnItem.Rows.Clear();
            foreach (PhSelectedProductsToSaleOrReceiveOrOrder item in _returnItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgReturnItem, item.Code, item.LotNo, item.Name, item.Qty, item.Unit, item.SRate, item.Total, item.PRate);
                dgReturnItem.Rows.Add(row);
            }


            // CalculateAmount();
            //dgTests.ResumeLayout();
        }

        private void ProductReturnControl_Load(object sender, EventArgs e)
        {
            _ReturnItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            _SoldItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();



            ctrlPatientList.Location = new Point(txtAdmissionNo.Location.X, txtAdmissionNo.Location.Y + txtAdmissionNo.Height);

            ctrlPatientList.ItemSelected += ctrlPatientList_ItemSelected;



            isLoaded = false;
               LoadInvoiceType();
            isLoaded = true;

          


            //txtInvoice.Enabled = false;
            //txtAdmissionNo.Enabled = false;
          
        }

        private void ctrlPatientList_ItemSelected(SearchResultListControl<VMIPDInfo> sender, VMIPDInfo item)
        {
            txtAdmissionNo.Text = item.BillNo.ToString();
            lblPatientInfo.Text = item.Name + ", " + item.BedCabinNo;
            LoadSuppliedMedicineList(item.BillNo.ToString());
            txtAdmissionNo.Focus();
            sender.Visible = false;
        }

        private void LoadInvoiceType()
        {
            List<PhInvoiceType> ItList = new PhProductService().GetInvoiceType().ToList();
            ItList.Insert(0, new PhInvoiceType() { InvoceTypeId = 0, InvoiceType = "---Select----" });
            cbInvoiceType.DataSource = ItList;
            cbInvoiceType.DisplayMember = "InvoiceType";
            cbInvoiceType.ValueMember = "InvoceTypeId";

            User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            if (_user.RoleId == 21 || _user.RoleId == 22 || _user.RoleId == 37 || _user.RoleId >= 26 && _user.RoleId <= 34)
            {
                cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == _user.AssignedOutLet);
                cbInvoiceType.Enabled = false;
                txtInvoice.Enabled = true;
                txtAdmissionNo.Enabled = true;
                txtAdmissionNo.Focus();

            }else
            {
                cbInvoiceType.SelectedItem = ItList.Find(q => q.InvoceTypeId == 1);
                txtInvoice.Enabled = true;
                txtAdmissionNo.Enabled = true;
                txtInvoice.Focus();
            }

        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            _ReturnItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
             dgReturnItem.Rows.Clear();
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgReturnItem.SelectedRows)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)r.Tag;

                _ReturnItems.Remove(r.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);
                CalculateReturnAmount();

                dgReturnItem.Rows.Remove(r);
            }

        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgItems.Rows)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _spsr = (PhSelectedProductsToSaleOrReceiveOrOrder)r.Tag;
                if (_ReturnItems.Any(x => x.Code == _spsr.Code)) return;
                _ReturnItems.Add(_spsr);

            }

            FillReturnItemGrid(_ReturnItems);

            CalculateReturnAmount();

            CalculateDiscountAdjustment(txtReturnTk.Text);
        }

        private void dgReturnItem_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _spsr = (PhSelectedProductsToSaleOrReceiveOrOrder)dgReturnItem.SelectedRows[0].Tag;
            if (_spsr != null)
            {
                txtProductCode.Text = _spsr.Id.ToString();
                txtQty.Text = _spsr.Qty.ToString();

                txtProductCode.Tag = _spsr;
            }
           
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int _retQty = 0;
                int.TryParse(txtQty.Text, out _retQty);

                PhSelectedProductsToSaleOrReceiveOrOrder _spsr = (PhSelectedProductsToSaleOrReceiveOrOrder)txtProductCode.Tag;

                if(_retQty> _spsr.Qty)
                {
                    MessageBox.Show("Return qty exceeds the limit. Plz. check and try again.");
                    return;
                }

                if (_retQty > 0)
                {
                    double _Rate = Convert.ToDouble(dgReturnItem.SelectedRows[0].Cells[5].Value);
                    dgReturnItem.SelectedRows[0].Cells[3].Value = txtQty.Text;
                    dgReturnItem.SelectedRows[0].Cells[6].Value = _retQty * _Rate;

                   

                    _ReturnItems.Where(w => w.InvoiceId == _spsr.InvoiceId && w.Id== _spsr.Id).ToList().ForEach(s => s.Qty = _retQty);
                    _ReturnItems.Where(w => w.InvoiceId == _spsr.InvoiceId && w.Id == _spsr.Id).ToList().ForEach(s => s.Total = _retQty * _Rate);

                    CalculateReturnAmount();

                    CalculateDiscountAdjustment(txtReturnTk.Text);
                }
                else
                {
                    MessageBox.Show("Qunatity required!");
                }


            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

            //if (_user.AssignedOutLet == 0)
            //{
            //    MessageBox.Show("You are not authorized to return"); return;
            //}

            int _outletId = 0;
            long _InvoiceNo = 0;

            if (dgReturnItem.Rows.Count > 0)
            {

                if (!String.IsNullOrEmpty(txtAdmissionNo.Text))
                {
                    long _admissionNo = 0;
                    long.TryParse(txtAdmissionNo.Text, out _admissionNo);

                    double _returnAmount = 0, discountAdjusted = 0;
                    double.TryParse(txtReturnTk.Text, out _returnAmount);
                    double.TryParse(txtDiscountAdjusted.Text, out discountAdjusted);

                    User _user = new UserService().GetUserById(MainForm.LoggedinUser.UserId);

                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionNo);

                    if (_pInfo == null)
                    {
                        MessageBox.Show("Invalid admission no"); return;
                    }

                    HpMedicineReturnInednt _ReturnIndent = new HpMedicineReturnInednt();

                    _ReturnIndent.ReturnDate = Utils.GetServerDateAndTime();
                    _ReturnIndent.AdmissionId = _pInfo.AdmissionId;
                    _ReturnIndent.ReturnTime = txtReturnTime.Text;
                    _ReturnIndent.OutletId = _user.AssignedOutLet;
                    _ReturnIndent.Status = HpIndoorReturnStatusEnum.Pending.ToString();
                    _ReturnIndent.ReturnIndentBy = MainForm.LoggedinUser.Name;
                    _ReturnIndent.ReturnType = "CR"; //Customer Return 

                    long _RId = new PhProductService().SaveReturnIndent(_ReturnIndent);

                    if(_RId>0)
                    {
                            List<HpMedicineReturnIndentDetail> _rDeatailsList = new List<HpMedicineReturnIndentDetail>();
                            foreach (DataGridViewRow row in dgReturnItem.Rows)
                            {
                                PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
                                 HpMedicineReturnIndentDetail _rDetails = new HpMedicineReturnIndentDetail();
                                _rDetails.InvoiceId = selectedTests.InvoiceId;
                                _rDetails.ReturnIndentId = _RId;
                                _rDetails.LotNo = selectedTests.LotNo;
                                _rDetails.OutLetId = selectedTests.OutLetId;
                                _rDetails.ProductId = selectedTests.Id;
                                _rDetails.Qty = selectedTests.Qty;
                                _rDetails.SRate = selectedTests.SRate;
                                _rDetails.PRate = selectedTests.PRate;
                                _rDetails.TSaleAmount = selectedTests.Total;
                                _rDeatailsList.Add(_rDetails);
                            }

                        if (_rDeatailsList.Count() > 0)
                        {
                            new PhProductService().SaveReturnIndentDetail(_rDeatailsList);
                            MessageBox.Show("Return indent generated successfully.");
                            dgReturnItem.Rows.Clear();
                            _ReturnItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
                            ClearReturnFields();

                        }
                    }


                    double ebalance = new PhFinancialService().GetPhIPDLedgerBalance(_pInfo.AdmissionId);
                    ebalance = ebalance + _returnAmount;
                    //Save On Entry Payment Information
                    List<PhIPDSaleLedger> _ipdtransactionList = new List<PhIPDSaleLedger>();
                    PhIPDSaleLedger ipdLedger = new PhIPDSaleLedger();
                    ipdLedger.AdmissionId = _pInfo.AdmissionId;
                    ipdLedger.TranDate = Utils.GetServerDateAndTime();
                    ipdLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                    ipdLedger.Particulars = "Return Medicine";
                    ipdLedger.Debit = 0;
                    ipdLedger.Credit = _returnAmount;
                    ipdLedger.Balance = ebalance;
                    ipdLedger.TransactionType = TransactionTypeEnum.PhRefund.ToString();
                    ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
                    _ipdtransactionList.Add(ipdLedger);


                    if (discountAdjusted > 0)
                    {
                        ebalance = ebalance - discountAdjusted;

                        ipdLedger = new PhIPDSaleLedger();
                        ipdLedger.AdmissionId = _pInfo.AdmissionId;
                        ipdLedger.TranDate = Utils.GetServerDateAndTime();
                        ipdLedger.TransactionTime = Utils.GetServerDateAndTime().ToString("hh:mm tt");
                        ipdLedger.Particulars = "Discount Adjusted";
                        ipdLedger.Debit = discountAdjusted;
                        ipdLedger.Credit = 0;
                        ipdLedger.Balance = ebalance;
                        ipdLedger.TransactionType = TransactionTypeEnum.PhDiscountDiscountRefunded.ToString();
                        ipdLedger.OperateBy = MainForm.LoggedinUser.Name;
                        _ipdtransactionList.Add(ipdLedger);
                    }

                    if (_ipdtransactionList.Count > 0)
                    {
                        new PhFinancialService().SavePhIPDSaleTransactionLedger(_ipdtransactionList);
                    }


                    // LoadPaymentHistory(_invoice);

                }
                else
                {

                    List<PhInvoice> invList = new List<PhInvoice>();

                    foreach (DataGridViewRow row in dgReturnItem.Rows)
                    {

                        PhSelectedProductsToSaleOrReceiveOrOrder selectedItem = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;

                        if (!invList.Any(x => x.InvoiceId == selectedItem.InvoiceId))  // Pick individual invoiceId & respective totalReturnAmount from return list
                        {
                            PhInvoice phinv = new PhInvoice();

                            double _totalReturn = _ReturnItems.Where(q => q.InvoiceId == selectedItem.InvoiceId).Sum(x => x.Total);

                            phinv.InvoiceId = selectedItem.InvoiceId;
                            phinv.TotalTK = _totalReturn;
                            phinv.OutLetId = selectedItem.OutLetId;

                            invList.Add(phinv);
                        }
                    }


                    foreach (PhInvoice invItem in invList)
                    {
                        _InvoiceNo = invItem.InvoiceId;

                        double balance = new PhProductService().GetPhInvoiceBalance(invItem.InvoiceId);

                        double _discount = new PhProductService().getPhDiscountByInvoiceId(invItem.InvoiceId);
                        double _InvoiceTotal = _SoldItems.Where(q => q.InvoiceId == invItem.InvoiceId).Sum(y => y.Total);
                        double _discountAdjusted = Math.Round((invItem.TotalTK * _discount) / _InvoiceTotal,2);

                        List<PhSaleLedger> transactionList = new List<PhSaleLedger>();

                        PhSaleLedger pLedger = new PhSaleLedger();

                      


                        if (invItem.TotalTK > 0)
                        {
                            balance = balance + Math.Round(invItem.TotalTK);
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = invItem.InvoiceId;
                            pLedger.TranDate = DateTime.Now;
                            pLedger.Particulars = "Return";
                            pLedger.Debit = 0;
                            pLedger.Credit = Math.Round(invItem.TotalTK);
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhProductRefund.ToString();
                            pLedger.OperateBy = MainForm.LoggedinUser.Name;
                            transactionList.Add(pLedger);
                        }



                        if (_discountAdjusted > 0)
                        {
                            balance = balance - _discountAdjusted;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = invItem.InvoiceId;
                            pLedger.TranDate = DateTime.Now;
                            pLedger.Particulars = "Discount Adjusted";
                            pLedger.Debit = _discountAdjusted;
                            pLedger.Credit = 0;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhDiscountDiscountRefunded.ToString();
                            pLedger.OperateBy = MainForm.LoggedinUser.Name;
                            transactionList.Add(pLedger);
                        }

                         double _returnedAmount = invItem.TotalTK - _discountAdjusted;

                        if (balance > 0)
                        {
                            _returnedAmount = balance;
                        }else
                        {
                            _returnedAmount = _returnedAmount + balance;

                        }


                        if (_returnedAmount > 0)
                        {
                            balance = balance - _returnedAmount;
                            pLedger = new PhSaleLedger();
                            pLedger.InvoiceId = invItem.InvoiceId;
                            pLedger.TranDate = DateTime.Now;
                            pLedger.Particulars = "Returned Tk.";
                            pLedger.Debit = Math.Round(_returnedAmount);
                            pLedger.Credit = 0;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PhRefund.ToString();
                            pLedger.OperateBy = MainForm.LoggedinUser.Name;
                            transactionList.Add(pLedger);
                        }

                        if (transactionList.Count > 0)
                        {

                            new PhProductService().SavePhSaleLedger(transactionList);
                        }



                        PhReceive rcv = new PhReceive();
                        rcv.RDate = DateTime.Now;
                        rcv.Particulars = "Return Receive from Inv: " + invItem.ToString();
                        rcv.SupChalanNo = "N/A";
                        rcv.SupInvNo = "N/A";
                        rcv.TotalTk = invItem.TotalTK;
                        rcv.DiscountTk = _discount;
                        rcv.SupInvDate = DateTime.Now;
                        rcv.SupplerId = 0;
                        rcv.OutLetId = invItem.OutLetId;   //Convert.ToInt32(cbInvoiceType.SelectedValue);  // OutLet Needed to Dynamic
                        rcv.IPDReturnBy = 0;
                        rcv.OPDReturnInvoice = _InvoiceNo;
                        long _ReceiveId = new PhProductService().SaveReceivedInvoice(rcv);


                        if (_ReceiveId > 0)
                        {
                            List<PhReceiveDetail> _rDeatailsList = new List<PhReceiveDetail>();
                            foreach (DataGridViewRow row in dgReturnItem.Rows)
                            {
                                PhSelectedProductsToSaleOrReceiveOrOrder selectedTests = row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder;
                                PhReceiveDetail _rDetails = new PhReceiveDetail();
                                _rDetails.ReceivedId = _ReceiveId;
                                _rDetails.LotNo = selectedTests.LotNo;
                            
                                _rDetails.ProductId = selectedTests.Id;
                                _rDetails.Qty = selectedTests.Qty;
                                _rDetails.PurchaseRate = selectedTests.PRate;
                                _rDetails.Total = selectedTests.Total;
                                _rDetails.disCountInpercent = selectedTests.DiscInPercentPerProduct;
                                _rDetails.grossDiscount = selectedTests.Discount;

                                new PhProductService().UpdatePhRefundedInvoiceDetail(selectedTests.InvoiceId, selectedTests.Id, selectedTests.LotNo, selectedTests.Qty);

                                _rDeatailsList.Add(_rDetails);
                            }
                            if (new PhProductService().SaveReceiveDetails(_rDeatailsList))
                            {

                                new PhProductService().UpdateOrAddToStockInfo(_ReturnItems, invItem.OutLetId);
                                MessageBox.Show("Return Successfull.");

                                GenerateReturnInvoice(_ReceiveId);

                                ClearReturnFields();
                            }
                        }

                    }

                    long _invoice = 0;
                    long.TryParse(txtInvoice.Text, out _invoice);

                    LoadPaymentHistory(_invoice);
                }
            }
            else
            {
                MessageBox.Show("Product not selected.");
            }
        }

        private void GenerateReturnInvoice(long _ReceiveId)
        {
          

            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;

            double _discountAdjust = 0;
            double _netReturnable = 0;

            double.TryParse(txtDiscountAdjusted.Text,out _discountAdjust);
            double.TryParse(txtNetReturn.Text, out _netReturnable);

            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;
            string _tempLabel = string.Empty;
            string _tempDivider = string.Empty;
            string _tempValue = string.Empty;


            DataSet ds = new PhReportingService().GetSaleEntryDataSetByReturnReceiveId(_ReceiveId);

            rptPosSaleInvoice _rpt = new rptPosSaleInvoice();

            _rpt.SetDataSource(ds.Tables[0]);

             PhReceive _pInvoice = new PhFinancialService().GetPhReceiveById(_ReceiveId);
            _rpt.SetParameterValue("pLabel1", "Return Amount");
            _rpt.SetParameterValue("pDivider1", ":");
            _rpt.SetParameterValue("pValue1", _pInvoice.TotalTk.ToString());
            _index++;

            _tempLabel = "pLabel2";
            _tempDivider = "pDivider2";
            _tempValue = "pValue2";

            if (_discountAdjust > 0)
            {
                _rpt.SetParameterValue(_tempLabel, "Disc. Adjust");
                _rpt.SetParameterValue(_tempDivider, ":");
                _rpt.SetParameterValue(_tempValue, _discountAdjust.ToString());

                _tempLabel = "pLabel3";
                _tempDivider = "pDivider3";
                _tempValue = "pValue3";

                _index++;
            }

            if (_netReturnable > 0)
            {
                _rpt.SetParameterValue(_tempLabel, "Net Return");
                _rpt.SetParameterValue(_tempDivider, ":");
                _rpt.SetParameterValue(_tempValue, _netReturnable.ToString());
                _index++;
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



            _rpt.SetParameterValue("CompanyName", "Mount Adora Pharmacy");
            if (Configuration.ORG_CODE == "1")
            {
                _rpt.SetParameterValue("CAddress", "Nayasarak, Mirboxtula, Sylhet.");
                _rpt.SetParameterValue("CMobile", "Return Invoice");
            }
            else
            {
                _rpt.SetParameterValue("CAddress", "Akhalia, Sylhet");
                _rpt.SetParameterValue("CMobile", "Return Invoice");
            }

            _rpt.SetParameterValue("CustomerName", "");
            _rpt.SetParameterValue("CustMobile", "");
         


            //RptSaleProduct _rpt = new RptSaleProduct();


            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.Show();
        }

        private void ClearReturnFields()
        {
            dgReturnItem.Rows.Clear();
            txtReturnTk.Text = "";
            txtProductCode.Text = "";
            txtQty.Text = "";
        }

        private void cbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isLoaded)
            //{
               

            //    if (((PhInvoiceType)cbInvoiceType.SelectedItem).InvoiceTypeShortName.ToLower() == "is")
            //    {
            //        txtInvoice.Enabled = false;
            //        txtAdmissionNo.Enabled = true;
            //        txtAdmissionNo.Focus();
            //    }else
            //    {
            //        txtInvoice.Enabled = true;
            //        txtAdmissionNo.Enabled = false;
            //        txtInvoice.Focus();
            //    }

                
            //}
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtAdmissionNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctrlPatientList.Visible = true;
                ctrlPatientList.LoadData();
            }


            if (e.KeyChar == (char)Keys.Enter)
            {

                LoadSuppliedMedicineList(txtAdmissionNo.Text);
            }
        }

        private void LoadSuppliedMedicineList(string _admissionNo)
        {


            long _admissionId = 0; // AdmissionId treated as billNo
            long.TryParse(_admissionNo, out _admissionId);

            HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionId);

            if (_pInfo == null)
            {
                MessageBox.Show("Patient record not found.");
                return;
            }

            if (_pInfo.Status.ToLower() == "discharged")
            {

                MessageBox.Show("It's a discharged patient.");
                return;
            }

            txtAdmissionNo.Tag = _pInfo;



            List<PhInvoice> _invList = new PhProductService().GetInvoiceListByAdmissionNo(_admissionId);

            _SoldItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

            foreach (PhInvoice invItem in _invList)
            {
                List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(invItem.InvoiceId).ToList();

                foreach (var lineitem in _Invoicedetails)
                {
                    PhSelectedProductsToSaleOrReceiveOrOrder _sItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
                    PhProductInfo _prdInfo = new PhProductService().GetProductById(lineitem.ProductId);
                    if (_prdInfo != null)
                    {
                        _sItem.InvoiceId = lineitem.InvoiceId;
                        _sItem.Id = lineitem.ProductId;
                        _sItem.Code = lineitem.ProductId.ToString();
                        _sItem.Name = _prdInfo.BrandName;
                        _sItem.Qty = lineitem.Qty;
                        _sItem.RetQty = lineitem.RetQty;
                        _sItem.Unit = _prdInfo.Unit;
                        _sItem.SRate = lineitem.SaleRate;
                        _sItem.PRate = lineitem.PurchaseRate;
                        _sItem.LotNo = lineitem.LotNo;
                        _sItem.OutLetId = invItem.OutLetId;
                        _sItem.Total = lineitem.TotalPrice;
                        _SoldItems.Add(_sItem);
                    }
                }
            }


            FillItemGrid(_SoldItems);
        }

        private void HideAllDefaultHidden()
        {
            ctrlPatientList.Visible=false;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            dgItems.Rows.Clear();
            dgReturnItem.Rows.Clear();
           _ReturnItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            dgReturnItem.Rows.Clear();
            txtProductCode.Tag = null;
            txtInvoice.Text = "";
            txtAdmissionNo.Text = null;
            txtInvoice.Enabled = false;
            txtAdmissionNo.Enabled = true;
            isLoaded = false;
            LoadInvoiceType();
            isLoaded = true;
        }

        private void dgReturnItem_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _SelectedItem = (PhSelectedProductsToSaleOrReceiveOrOrder)e.Row.Tag;

            _ReturnItems.Remove(e.Row.Tag as PhSelectedProductsToSaleOrReceiveOrOrder);
            CalculateReturnAmount();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtReturnTime.Text = DateTime.Now.ToString("HH:mm:ss tt");
        }

        private void txtAdmissionNo_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                if (txtAdmissionNo.Tag == null)
                {
                    long _admissionId = 0; // AdmissionId treated as billNo
                    long.TryParse(txtAdmissionNo.Text, out _admissionId);

                    HospitalPatientInfo _pInfo = new HospitalService().GetHospitalPatientByBillNo(_admissionId);

                    if (_pInfo == null)
                    {
                        MessageBox.Show("Patient record not found.");
                        return;
                    }

                    txtAdmissionNo.Tag = _pInfo;



                    List<PhInvoice> _invList = new PhProductService().GetInvoiceListByAdmissionNo(_admissionId);

                    _SoldItems = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();

                    foreach (PhInvoice invItem in _invList)
                    {
                        List<PhInvoiceDetail> _Invoicedetails = new PhProductService().GetPhInvoiceDetails(invItem.InvoiceId).ToList();

                        foreach (var lineitem in _Invoicedetails)
                        {
                            PhSelectedProductsToSaleOrReceiveOrOrder _sItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
                            PhProductInfo _prdInfo = new PhProductService().GetProductById(lineitem.ProductId);
                            _sItem.InvoiceId = lineitem.InvoiceId;
                            _sItem.Id = lineitem.ProductId;
                            _sItem.Code = lineitem.ProductId.ToString();
                            _sItem.Name = _prdInfo.BrandName;
                            _sItem.Qty = lineitem.Qty;
                            _sItem.Unit = _prdInfo.Unit;
                            _sItem.SRate = lineitem.SaleRate;
                            _sItem.PRate = lineitem.PurchaseRate;
                            _sItem.Total = lineitem.TotalPrice;
                            _SoldItems.Add(_sItem);
                        }
                    }


                    FillItemGrid(_SoldItems);
                }
            }
        }

        private void ctrlPatientList_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtAdmissionNo.Focus();
            }
        }
    }
}
