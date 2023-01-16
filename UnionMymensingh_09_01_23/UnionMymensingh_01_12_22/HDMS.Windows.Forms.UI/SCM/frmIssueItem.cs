
using Services.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.Windows.Forms;
using HDMS.Windows.Forms.UI;
using Services.POS;

using HDMS.Model.ViewModel;
using HDMS.Windows.Forms.UI.Classes;
using HDMS.Model.Enums;

using Models.Accounting;
using HDMS.Service.Accounting;
using Models.Store;
using HDMS.Windows.Forms.UI.Controls;
using HDMS.Windows.Forms.UI.Reports.SCM;
using HDMS.Model.Store;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Service;
using HDMS.Model.Users;

namespace HDMS.Store
{
    public partial class frmIssueItem : Form
    {
        double _subtotalTk = 0;
        double _discountTk = 0;
        double _receivedTk = 0;
        double _dueTk = 0;
        double _retunedAdjustedTk = 0;
        double _changeTk = 0;
        double _grandtotal = 0;
        bool unlocked = true;
       
        bool isPanelMinimized = true;

        public frmIssueItem()
        {
            InitializeComponent();
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
                    ctlProductSearchControl.Visible = true;
                    ctlProductSearchControl.txtSearch.Text = _txt;
                    ctlProductSearchControl.txtSearch.SelectionStart = ctlProductSearchControl.txtSearch.Text.Length;

                    ctlProductSearchControl.LoadData();
                }
            }
        }

        private void HideAllDefaultHidden()
        {
            ctlProductSearchControl.Visible=false;
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                HideAllDefaultHidden();
                ctlProductSearchControl.Visible = true;
                ctlProductSearchControl.LoadData();

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

        private IList<SelectedProductsToSaleOrReceive> _SelectedItems;
        private void frmIssueItem_Load(object sender, EventArgs e)
        {

            HideAllDefaultHidden();

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();

            ctlProductSearchControl.Location = new Point(txtProduct.Location.X, txtProduct.Location.Y);
            ctlProductSearchControl.ItemSelected += ctlProductSearchControl_ItemSelected;

            List<StoreDept> _sm = new StoreItemService().GetStoreDepartment();
            _sm.Insert(0, new StoreDept() { DeptId = 0, Name = "Select Parent" });
            cmbDepartment.DataSource = _sm;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "DeptId";



            //txtProduct.GotFocus += new System.EventHandler(this.txtGotFocus);
            //dtpInvData.Focus();
            AddNewSale();
          

            foreach (Control ctrl in this.Controls)
            {
                ctrl.GotFocus += ctrl_GotFocus;
                ctrl.LostFocus += ctrl_LostFocus;
            }

            SetTogglePositionForPanel(true);

            LoadRequisitionByDateByUser();
        }

        private void LoadRequisitionByDateByUser()
        {
           
                List<VMStoreRequisition> _reqList = new StoreItemService().GetRequisitionListByDate(Utils.GetServerDateAndTime().Date);
                FillIndentGrid(_reqList);
            
        }

        private void FillIndentGrid(List<VMStoreRequisition> _reqList)
        {
            dgRequistions.SuspendLayout();
            dgRequistions.Rows.Clear();
            foreach (VMStoreRequisition item in _reqList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 32;
                row.Tag = item;
                row.CreateCells(dgRequistions, item.RequisitionId, item.RDate.ToString("dd/MM/yyyy"),item.LabName, item.Status);
                dgRequistions.Rows.Add(row);

            }
        }

        private void AddNewSale()
        {
            ClearForm();

           
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
            txtTotalQty.Text = "";

            dgItems.Rows.Clear();
            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
        }


        private void ctlProductSearchControl_ItemSelected(SearchResultListControl<StoreProductInfo> sender, StoreProductInfo item)
        {
            txtProduct.Text = item.ProductCode;
            txtProduct.Tag = item;
            txtProductName.Text = item.Name;
            txtRate.Text = item.PurchaseRate.ToString();
            txtRate.Focus();
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
                    if (_SelectedItems.Any(q => q.ProductId == _prodId))
                    {
                        double _qty = 0;
                        double.TryParse(txtQty.Text, out _qty);
                        double _rate = 0;
                        double.TryParse(txtRate.Text, out _rate);
                        _SelectedItems.Where(w => w.ProductId == _prodId).ToList().ForEach(s => s.Qty = _qty);
                        _SelectedItems.Where(w => w.ProductId == _prodId).ToList().ForEach(s => s.Rate = _rate);
                        _SelectedItems.Where(w => w.ProductId == _prodId).ToList().ForEach(s => s.Total = _qty * _rate);

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
                        new StoreItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as StoreProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));

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
                        StoreProductInfo _PInfo = (StoreProductInfo)txtProduct.Tag;
                        double _CurrentStock = new StoreItemService().GetCurrentStockByProductId(_PInfo.ProductId);
                        if (_Qty <= _CurrentStock)
                        {

                            if (_SelectedItems.Any(q => q.ProductId == _PInfo.ProductId))
                            {
                                double _qty = 0;
                                double.TryParse(txtQty.Text, out _qty);
                                double _rate = 0;
                                double.TryParse(txtRate.Text, out _rate);
                                _SelectedItems.Where(w => w.ProductId == _PInfo.ProductId).ToList().ForEach(s => s.Qty = _qty);
                                _SelectedItems.Where(w => w.ProductId == _PInfo.ProductId).ToList().ForEach(s => s.Rate = _rate);
                                _SelectedItems.Where(w => w.ProductId == _PInfo.ProductId).ToList().ForEach(s => s.Total = _qty * _rate);

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

                                new StoreItemService().PopulateSelectedItemData(_SelectedItems, txtProduct.Tag as StoreProductInfo, Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtQty.Text));

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
            foreach (SelectedProductsToSaleOrReceive item in _SelectedItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = item;
                row.CreateCells(dgItems, item.ProductId, item.Name, item.Qty, item.Unit, item.Rate, item.Total);
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

            txtTotalQty.Text= dgItems.Rows.Cast<DataGridViewRow>()
              .Sum(t => Convert.ToDouble(t.Cells[2].Value)).ToString();



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show(" Invoice not save as " + ex.Message.ToString());
            }
        }

        private void UpdateExistingInvoice(long v)
        {
            throw new NotImplementedException();
        }

        private void AddNewInvoice()
        {
            int _returnedInvoice = 0;
            int _customerId = 0;

          
            double.TryParse(txtTotalAmount.Text, out _subtotalTk);

            long _reqId = 0;
            int _deptId = 0;
            if (txtRequisitionNo.Tag != null)
            {
                VMStoreRequisition _req = (VMStoreRequisition)txtRequisitionNo.Tag;
                _reqId = _req.RequisitionId;
                _deptId = _req.LabId;
            }

            StoreDept _smg = (StoreDept)cmbDepartment.SelectedItem;
            if (_smg.DeptId == 0)
            {
                MessageBox.Show("Plz. select Department and try again."); return;
            }



            StoreInvoice _invoice = new StoreInvoice();
            _invoice.Invdate = Convert.ToDateTime(dtpInvData.Text);
            _invoice.MobileNo = "";

            _invoice.TotalTK = _subtotalTk + _retunedAdjustedTk;
            _invoice.DiscountTK = _discountTk;
            _invoice.GrandTK = (_subtotalTk + _retunedAdjustedTk) - _discountTk;
            _invoice.ReceivedTK = _receivedTk;
            _invoice.ChangeTK = _changeTk;
            _invoice.DueTK = _dueTk;
            _invoice.ReturnAdjustedTK = _retunedAdjustedTk;
            _invoice.InvoiceNumber = txtInvoiceNo.Text;
            _invoice.ChallanNumber = "";
            _invoice.ChallanAddress = "";
            _invoice.InvoiceType = "RS"; // RS-> Retail Sales
            _invoice.ReturnedInvoiceNo = _returnedInvoice;
            _invoice.CustomerId = _customerId;
            _invoice.RequisitionId = _reqId;
            _invoice.DeptId = _smg.DeptId;

            long _InvoiceId = new StoreItemService().AddNewInvoice(_invoice);

            if (_InvoiceId > 0)
            {


 
                StoreInvoice _invce = new StoreItemService().GetInvoiceByInvoiceNo(_InvoiceId);

                if (_invce != null)
                {
                    txtInvoiceNo.Text = _invce.InvoiceId.ToString();
                    txtInvoiceNo.Tag = _InvoiceId.ToString();
                }
                else
                {
                    txtInvoiceNo.Text = "";
                    txtInvoiceNo.Tag = null;
                }

                List<StoreInvoiceDetail> _invDetailsList = new List<StoreInvoiceDetail>();
                List<VoucherDetail> _rVoucherDetailList = new List<VoucherDetail>();
                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    SelectedProductsToSaleOrReceive selectedTests = row.Tag as SelectedProductsToSaleOrReceive;
                    StoreInvoiceDetail _invDetails = new StoreInvoiceDetail();
                    _invDetails.InvoiceId = _InvoiceId;
                    _invDetails.ProductId = Convert.ToInt16(selectedTests.ProductId);
                    _invDetails.Qty = Convert.ToDouble(selectedTests.Qty);
                    _invDetails.SaleRate = Convert.ToDouble(selectedTests.Rate);
                    _invDetails.TotalPrice = Convert.ToDouble(selectedTests.Qty) *
                                             Convert.ToDouble(selectedTests.Rate);
                    _invDetails.Discount = 0;
                    _invDetails.PurchaseRate = 0;

                    _invDetailsList.Add(_invDetails);

                }

                new StoreItemService().AddNewInvDetails(_invDetailsList);
                MessageBox.Show("Invoice save successfully.");

                long _requisitionNo = 0;
                long.TryParse(txtRequisitionNo.Text, out _requisitionNo);

                if (_requisitionNo > 0)
                {
                    new StoreItemService().UpdateRequisition(_requisitionNo);

                    LoadRequisitionByDateByUser();
                }


              
                ShowInvoice(_InvoiceId);
             

                ClearForm();
                AddNewSale();
            }
        }

        private void ShowInvoice(long _InvoiceId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            string _issueDept = string.Empty;
            string _requisitionBy = string.Empty;

            if (txtRequisitionNo.Tag != null)
            {
                VMStoreRequisition _stReq = (VMStoreRequisition)txtRequisitionNo.Tag;
                _issueDept = _stReq.LabName;

                User _u = new UserService().GetUserById(_stReq.RequisitionbyId);

                _requisitionBy = _u.LoginName;
            }


            DataSet ds = new ReportingService().GetSTIssueDataByinvocieId(_InvoiceId);

            rptPosIssueInvoice _rpt = new rptPosIssueInvoice();

            _rpt.SetDataSource(ds.Tables[0]);

            StoreInvoice _pInvoice = new ReportingService().GetStoreInvoiceById(_InvoiceId);
            List<VMCashMemoTranactionList> _cashtranList = Helper.GetIssueCashMemoTransactionList(_pInvoice);

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

            _rpt.SetParameterValue("IssueDept", cmbDepartment.Text);

            _rpt.SetParameterValue("Requisitionby", _requisitionBy);


            _rpt.SetParameterValue("CompanyName", "BSOH CANTEEN");

            _rpt.SetParameterValue("CAddress", "Akhalia, Sylhet");

            _rpt.SetParameterValue("CMobile", "01318210001");

            _rpt.SetParameterValue("Table","");

            _rpt.SetParameterValue("Mobile", "");


            _rpt.SetParameterValue("serveby", MainForm.LoggedinUser.Name);

            //RptSaleProduct _rpt = new RptSaleProduct();
            ReportViewer rv = new ReportViewer();
            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = ToolPanelViewType.None;
            rv.crviewer.PrintReport();


            rv.ShowDialog();
        }

        private void ctlProductSearchControl_SearchEsacaped(bool IsEscaped)
        {
            if (IsEscaped)
            {
                txtProduct.Focus();
            }
        }

        private void btnPrevId_Click(object sender, EventArgs e)
        {
            StoreInvoice _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                _Invoice = new StoreItemService().GetStoreLastestIssueInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtInvoiceNo.Text, out _billNo);
                _Invoice = new StoreItemService().GetStoreIssueInvoiceById(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new StoreItemService().GetStoreLastestIssueInvoice();
                }
                else
                {
                    _Invoice = new StoreItemService().GetStoreIssueInvoiceById(_Invoice.InvoiceId - 1);
                    if (_Invoice == null)
                    {
                        txtInvoiceNo.Text = "";
                    }
                }

            }

            if (_Invoice != null)
            {
                txtInvoiceNo.Text = _Invoice.InvoiceId.ToString();

                LoadPrevoiusIssueInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invalid issue number.");
                _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
                ClearForm();

                btnSave.Enabled = true;
            }
        }

        private void LoadPrevoiusIssueInfo(StoreInvoice _Invoice)
        {
            if (_Invoice == null) return;

            List<StoreInvoiceDetail> _Invoicedetails = new StoreItemService().GetStoreInvoiceDetails(_Invoice.InvoiceId).ToList();
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
                    _sItem.Rate = lineitem.SaleRate;
                    _sItem.Total = lineitem.SaleRate * lineitem.Qty;

                    _SelectedItems.Add(_sItem);
                }
            }

            FillItemGridForPreviousIssueInvoice();
        }

        private void FillItemGridForPreviousIssueInvoice()
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
        }

        private void btnNextId_Click(object sender, EventArgs e)
        {
            StoreInvoice _Invoice = null;

            btnSave.Enabled = false;

            if (String.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                _Invoice = new StoreItemService().GetStoreFirstIssueInvoice();
            }
            else
            {
                long _billNo = 0;
                long.TryParse(txtInvoiceNo.Text, out _billNo);
                _Invoice = new StoreItemService().GetStoreIssueInvoiceById(_billNo);
                if (_Invoice == null)
                {
                    _Invoice = new StoreItemService().GetStoreLastestIssueInvoice();
                }
                else
                {
                    _Invoice = new StoreItemService().GetStoreIssueInvoiceById(_Invoice.InvoiceId + 1);
                }

            }

            if (_Invoice != null)
            {
                txtInvoiceNo.Text = _Invoice.InvoiceId.ToString();

                LoadPrevoiusIssueInfo(_Invoice);
            }
            else
            {
                MessageBox.Show("Invalid issue number.");
                _SelectedItems = new List<SelectedProductsToSaleOrReceive>();
                ClearForm();

                btnSave.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtInvoiceNo.Text = "";
            txtRequisitionNo.Text = "";
            btnSave.Enabled = true;
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            long _invoiceId = 0;
            long.TryParse(txtInvoiceNo.Text,out _invoiceId);
            ShowInvoice(_invoiceId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTogglePositionForPanel(isPanelMinimized);
        }

        private void SetTogglePositionForPanel(bool _IspanleMinimized)
        {
            if (_IspanleMinimized)
            {
                lblRequisitionPanel.Location = new Point(930, 54);

                button1.Location = new Point(20, 14);
                button1.Text = "<-----<< << <<";

                isPanelMinimized = false;

            }
            else
            {
                lblRequisitionPanel.Location = new Point(10, 54);

                button1.Location = new Point(20, 14);
                button1.Text = ">> >> >> ----->";

                isPanelMinimized = true;

            }
        }

        private void dgRequistions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            VMStoreRequisition _req = dgRequistions.SelectedRows[0].Tag as VMStoreRequisition;
            txtRequisitionNo.Text = dgRequistions.Rows[e.RowIndex].Cells["RequisitionId"].Value.ToString();
            // txtRequisitionNo.Tag = _mreq.RequisitionBy;

            txtRequisitionNo.Tag = _req;

            btnCancel.Tag = txtRequisitionNo.Text;

            //dgRequistions.Visible = false;
            LoadRequitedProducts(txtRequisitionNo.Text);
        }

        private void LoadRequitedProducts(string _reqNo)
        {
            long _requisitionNo = 0;
            long.TryParse(_reqNo, out _requisitionNo);

            StoreRequisition _Req = new StoreItemService().GetStoreRequisitionByReqId(_requisitionNo);
            //txtRequisitionNo.Tag = _Req;

            if (_Req == null) return;
            
            List<VMRequisitionList> _ReqDetail = new StoreItemService().GetStoreRequisitionDetailByReqId(_Req.RequisitionId);
            dgRequisitionList.Visible = true;
            FillReqProductGrid(_ReqDetail);
            
        }

        private void FillReqProductGrid(List<VMRequisitionList> _ReqDetail)
        {
            dgRequisitionList.SuspendLayout();
            dgRequisitionList.Rows.Clear();

            foreach(var item in _ReqDetail)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 30;
                row.Tag = item;
                row.CreateCells(dgRequisitionList, item.ProductId,item.BrandName,item.ReqQty,item.StockAvailable, item.IsStockShort,item.ItemDeliveryStatus);

                dgRequisitionList.Rows.Add(row);
            }

        }

        private void dgRequisitionList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string IPDRequisitionDeliveryStatus = string.Empty;

            _SelectedItems = new List<SelectedProductsToSaleOrReceive>();

            foreach (DataGridViewRow row in dgRequisitionList.Rows)
            {
                VMRequisitionList selectedItem = row.Tag as VMRequisitionList;

                new StoreItemService().PopulateSelectedItemDataForIssueAgainstRequisition(_SelectedItems, selectedItem);

            }

            IPDRequisitionDeliveryStatus = RequisitionStatusEnum.Served.ToString();

            FillItemGrid();

            isPanelMinimized = true;
            SetTogglePositionForPanel(isPanelMinimized);



            LoadRequisitionByDateByUser();

            btnSave.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequisitionByDateByUser();
        }

        private void dgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgItems.Rows.Count > 0)
            {

                if (e.ColumnIndex == 2)  //example-'Column index=4'
                {

                    double qty = 0;

                    double.TryParse(dgItems.CurrentRow.Cells[2].Value.ToString(), out qty);

                    if (qty == 0) return;

                    SelectedProductsToSaleOrReceive _selectedItem = (SelectedProductsToSaleOrReceive)dgItems.CurrentRow.Tag;
                    _SelectedItems.Where(w => w.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.Qty = qty);

                    if (qty > 0)
                    {
                        double _rate = _selectedItem.Rate;

                        double _total = qty * _rate;


                        _SelectedItems.Where(x => x.ProductId == _selectedItem.ProductId).ToList().ForEach(s => s.Total = _total);


                        CalculateAmount();

                    }


                }
            }
         }

        private void dgItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SelectedProductsToSaleOrReceive _SelectedItem = (SelectedProductsToSaleOrReceive)e.Row.Tag;
           

                _SelectedItems.Remove(e.Row.Tag as SelectedProductsToSaleOrReceive);
                CalculateAmount();

            
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            long _invoiceId = 0;
            long.TryParse(txtInvoiceNo.Text, out _invoiceId);
            ShowInvoiceWithoutPrice(_invoiceId);
        }

        private void ShowInvoiceWithoutPrice(long _InvoiceId)
        {
            int _index = 0;
            bool isDue = false;
            bool isDiscounted = false;
            string pLabel = "pLabel", pDivider = "pDivider", pValue = "pValue";
            string p1 = string.Empty, p2 = string.Empty, p3 = string.Empty;

            string _issueDept = string.Empty;
            string _requisitionBy = string.Empty;

            if (txtRequisitionNo.Tag != null)
            {
                VMStoreRequisition _stReq = (VMStoreRequisition)txtRequisitionNo.Tag;
                _issueDept = _stReq.LabName;

                User _u = new UserService().GetUserById(_stReq.RequisitionbyId);

                _requisitionBy = _u.LoginName;
            }


            DataSet ds = new ReportingService().GetSTIssueDataByinvocieId(_InvoiceId);

            
        }
    }
}
