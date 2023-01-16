using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositories.Store;

using Models;
using Models.Store;
using HDMS.Model.Store;
using HDMS.Model.ViewModel;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Model;
using System.Data;
using HDMS.Model.SCM.VWModel;
using HDMS.Model.SCM;
using HDMS.Model.Diagnostic;

namespace Services.Store
{
    public class StoreItemService
    {
        public void SaveGroup(StoreGroup _stgroup)
        {
            new StoreItemRepository().SaveGroup(_stgroup);
        }

        public List<StoreGroup> GetAllGroups()
        {
            return new StoreItemRepository().GetAllGroups();
        }

        
        public IList<VMStoreItemInfo> GetBasicItemInfoList(string name, string _type)
        {
            return new StoreItemRepository().GetBasicItemInfoList(name, _type);
        }

        public List<StoreDept> GetStoreDepts()
        {
            return new StoreItemRepository().GetStoreDepts();
        }

        public DataSet GetROL(DateTime fromdate, DateTime todate, int ProdiuctId, int GroupId)
        {
            return new StoreItemRepository().GetROL(fromdate, todate, ProdiuctId, GroupId);
        }

        public List<StoreDept> GetStoreDepartment()
        {
            return new StoreItemRepository().GetStoreDepartment();
        }

        public bool SaveStoreMasterGroup(StoreMasterGroup _stgroup)
        {
            return new StoreItemRepository().SaveStoreMasterGroup(_stgroup);
        }

        public List<VMStoreDept> GetStoreDeptUserList()
        {
            return new StoreItemRepository().GetStoreDeptUserList();
        }

        public DataSet GetStoreItemUsesStatement(DateTime fromdate, DateTime todate, int _deptId)
        {
            return new StoreItemRepository().GetStoreItemUsesStatement(fromdate, todate, _deptId);
        }

        public StoreDeptUser GetIndentUser(int userId)
        {
            return new StoreItemRepository().GetIndentUser(userId);
        }

        public List<VMStoreRequisition> GetRequisitionListByUserByDate2(int deptId, DateTime _date)
        {
            return new StoreItemRepository().GetRequisitionListByUserByDate2(deptId, _date);
        }

        public DataSet GetSupplierLedger(int memberId, DateTime dtfrm, DateTime dtto)
        {
            return new StoreItemRepository().GetSupplierLedger(memberId, dtfrm, dtto);
        }

        public DataSet GetStoreIssueStatement(DateTime fromdate, DateTime todate, int _deptId)
        {
            return new StoreItemRepository().GetStoreIssueStatement(fromdate, todate, _deptId);
        }

        public List<StoreDeptUser> GetStoreDeptIndentUserList(int userId)
        {
            return new StoreItemRepository().GetStoreDeptIndentUserList(userId);
        }

        public StoreProductInfo GetProductById(int productId)
        {
            return new StoreItemRepository().GetProductById(productId);
        }

        public bool UpdateProductInfo(StoreProductInfo _P)
        {
            return new StoreItemRepository().UpdateProductInfo(_P);
        }

        public List<StoreDept> GetStoreDeptList()
        {
            return new StoreItemRepository().GetStoreDeptList();
        }

        public List<StoreMasterGroup> GetStoreMasterGroups()
        {
            return new StoreItemRepository().GetStoreMasterGroups();
        }

        public IList<VWStoreProductList> GetStoreBasicProductInfoList(string name, string _type)
        {
            return new StoreItemRepository().GetStoreBasicProductInfoList(name, _type);
        }

        public List<VMStoreRequisition> GetRequisitionListByUserByDate(int deptId, DateTime _date)
        {
            return new StoreItemRepository().GetRequisitionListByUserDate(deptId, _date);
        }

        public List<StoreDeptUser> GetStoreDeptListByUser2(int userId)
        {
            return new StoreItemRepository().GetStoreDeptListByUser2(userId);
        }

        public IList<StoreProductInfo> GetAllProduct()
        {
            return new StoreItemRepository().GetAllProduct();
        }

        public IList<VWStoreProductList> GetStockListForSale(string _filterString)
        {
            return new StoreItemRepository().GetStockListForSale(_filterString);
        }

        public double GetCurrentStockByProductId(int id)
        {
            return new StoreItemRepository().GetCurrentStockByProductId(id);
        }

        public IList<VWStoreProductList> GetProductListWithStock(string _filterString)
        {
            return new StoreItemRepository().GetProductListWithStock(_filterString);
        }

        public void PopulateSelectedItemData(IList<SelectedProductsToSaleOrReceive> _SelectedItems, StoreProductInfo productInfo, double _rate, double qty)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedItems.Any(x => x.ProductId == ItemId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObject(productInfo, _rate, qty));
        }

        public void PopulateSelectedItemDataforReagentTests(IList<SelectedProductsToSaleOrReceive> _SelectedItems, StoreProductInfo productInfo, double qty)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedItems.Any(x => x.ProductId == ItemId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObject1(productInfo, qty));
        }

        private SelectedProductsToSaleOrReceive GetPreparedSelectedItemObject1(StoreProductInfo productInfo, double qty)
        {
            SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
            _sItem.ProductId = productInfo.ProductId;
            _sItem.Code = productInfo.ProductCode;
            _sItem.Name = productInfo.Name;
            _sItem.Qty = qty;
            _sItem.Unit = productInfo.Unit;
            _sItem.DebitAccId = productInfo.DebitAccId;
            _sItem.CreditAccId = productInfo.CreditAccId;

            return _sItem;
        }

        private SelectedProductsToSaleOrReceive GetPreparedSelectedItemObject(StoreProductInfo productInfo, double _rate, double qty)
        {
            SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
            _sItem.ProductId = productInfo.ProductId;
            _sItem.Code = productInfo.ProductCode;
            _sItem.Name = productInfo.Name;
            _sItem.Qty = qty;
            _sItem.Unit = productInfo.Unit;
            _sItem.DebitAccId = productInfo.DebitAccId;
            _sItem.CreditAccId = productInfo.CreditAccId;
            _sItem.Rate = _rate;
            _sItem.Total = _rate * qty;

            return _sItem;

        }


        public void PopulateSCMSelectedItemData(IList<SelectedProductsToSaleOrReceive> _SelectedItems, VWStoreProductList productInfo, double _rate, double qty, string batchNo, DateTime expireDate)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedItems.Any(x => x.ProductId == ItemId)) return;

            _SelectedItems.Add(GetSCMPreparedSelectedItemObject(productInfo, _rate, qty,batchNo,expireDate));
        }

        public bool SaveTestForReagent(List<ReagentWithTest> _rDeatailsList)
        {
            return new StoreItemRepository().SaveTestForReagent(_rDeatailsList);
        }

        public bool UpdateStoreDept(StoreDept _dept)
        {
            return new StoreItemRepository().UpdateStoreDept(_dept);
        }

        public StoreDept GetStoreDeptById(int deptId)
        {
            return new StoreItemRepository().GetStoreDeptById(deptId);
        }

        public void PopulateStoreSelectedItemData(IList<SelectedProductsToSaleOrReceive> _SelectedItems, VWStoreProductList StoreProductInfo, double _rate, double _qty)
        {
            int ItemId;
            long _lotNo = 0;

            if (StoreProductInfo == null) return;

            ItemId = StoreProductInfo.ProductId;
            _lotNo = StoreProductInfo.LotNo;
            if (_SelectedItems.Any(x => x.ProductId == ItemId)) return;

            _SelectedItems.Add(GetStorePreparedSelectedItemObject(StoreProductInfo, _rate, _qty));
        }

        private SelectedProductsToSaleOrReceive GetStorePreparedSelectedItemObject(VWStoreProductList storeProductInfo, double _rate, double _qty)
        {
            SelectedProductsToSaleOrReceive _PhSelectedItem = new SelectedProductsToSaleOrReceive();
            _PhSelectedItem.ProductId = storeProductInfo.ProductId;
           // _PhSelectedItem.BarCode = storeProductInfo.BarCode;

            _PhSelectedItem.Name = storeProductInfo.Name;
            _PhSelectedItem.Unit = storeProductInfo.Unit;
            _PhSelectedItem.LotNo = storeProductInfo.LotNo;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.Rate = _rate;
           // _PhSelectedItem.di = 0;

            _PhSelectedItem.Total = _rate * _qty;

            return _PhSelectedItem;
        }

        private SelectedProductsToSaleOrReceive GetSCMPreparedSelectedItemObject(VWStoreProductList productInfo, double _rate, double qty, string batchNo, DateTime expdate)
        {

            long _lotNo = 0;

            StoreLotInfo _pLot = this.GetStoreLotInfo(batchNo, expdate);
            if (_pLot != null)
            {
                _lotNo = _pLot.LotNo;
            }
            else
            {
                StoreLotInfo _PL = new StoreLotInfo();
                _PL.BatchNo = batchNo;
                _PL.ExpireDate = expdate;
                _PL.CreateDate = DateTime.Now;
                _PL.UserId = 1;
                _PL.ModifyBy = 1;
                _PL.ModifyDate = DateTime.Now;
                _lotNo = this.SaveBatchAndExpireInfo(_PL);
            }



            SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
            _sItem.ProductId = productInfo.ProductId;
            _sItem.Code = productInfo.ProductCode;
            _sItem.LotNo = _lotNo;
            _sItem.Name = productInfo.Name;
            _sItem.Qty = qty;
            _sItem.Unit = productInfo.Unit;
            _sItem.DebitAccId = productInfo.DebitAccId;
            _sItem.CreditAccId = productInfo.CreditAccId;
            _sItem.Rate = _rate;
            _sItem.Total = _rate * qty;
            _sItem.BatchNo = batchNo;
            _sItem.ExpireDate = expdate;

            return _sItem;

        }

        public List<ReagentWithTest> GetReAgentsWithTest(int testId)
        {
            return new StoreItemRepository().GetReAgentsWithTest(testId);
        }

        public bool SaveStoreReturnToSupplier(StoreReturnToSupplier _retToSupplier)
        {
            return new StoreItemRepository().SaveStoreReturnToSupplier(_retToSupplier);
        }

        public void UpdateStoreStockOnReturnToSupplier(List<StoreReturnProductDetil> _retDetailsList)
        {
            new StoreItemRepository().UpdateStoreStockOnReturnToSupplier(_retDetailsList);
        }

        public bool AddStoreSupplierReturnDetails(List<StoreReturnProductDetil> _retDetailsList)
        {
            return new StoreItemRepository().AddStoreSupplierReturnDetails(_retDetailsList);
        }

        private long SaveBatchAndExpireInfo(StoreLotInfo pL)
        {
            return new StoreItemRepository().SaveBatchAndExpireInfo(pL);
        }

        public DataSet GetStoreExpireProductStatement(DateTime dtpfrm, DateTime dtpto, int groupId, int productId, string GroupName, string ProductName)
        {
            return new StoreItemRepository().GetStoreExpireProductStatement(dtpfrm, dtpto, groupId, productId, GroupName, ProductName);
        }

        private StoreLotInfo GetStoreLotInfo(string batchNo, DateTime expdate)
        {
            return new StoreItemRepository().GetStoreLotInfo(batchNo, expdate);
        }

        public void SaveNewProduct(StoreProductInfo sTPInfo)
        {
            new StoreItemRepository().StoreProductInfo(sTPInfo);
        }

        public DataSet GetStoreReturnInvoice(long returnId)
        {
            return new StoreItemRepository().GetStoreReturnInvoice(returnId);
        }

        public List<StoreDept> GetStoreDeptListByUser(int userId)
        {
            return new StoreItemRepository().GetStoreDeptListByUser(userId);
        }

        public StoreProductInfo GetProductByCode(string _PCode)
        {
            return new StoreItemRepository().GetProductByCode(_PCode);
        }

        public bool SaveStoreMaster(StoreItemUsesMaster _stMaster)
        {
            return new StoreItemRepository().SaveStoreMaster(_stMaster);
        }

        public long SaveReceivedInvoice(StoreReceive _receive)
        {
            return new StoreItemRepository().SaveReceivedInvoice(_receive);
        }

        public void PopulatePRItemData(IList<SelectedProductsToSaleOrReceive> _SelectedItems, VWStoreProductList productInfo, double qty, string unit, double rate)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedItems.Any(x => x.ProductId == ItemId)) return;

            _SelectedItems.Add(GetPreparedPRItemObject(productInfo, qty, unit, rate));
        }

        private SelectedProductsToSaleOrReceive GetPreparedPRItemObject(VWStoreProductList productInfo, double qty, string unit, double rate)
        {
            SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
            _sItem.ProductId = productInfo.ProductId;
            _sItem.Code = productInfo.ProductCode;
            _sItem.Name = productInfo.Name;
            _sItem.Qty = qty;
         
            _sItem.Unit = productInfo.Unit;
            _sItem.DebitAccId = productInfo.DebitAccId;
            _sItem.CreditAccId = productInfo.CreditAccId;
            _sItem.Rate = rate;
            _sItem.Total = rate * qty;

            return _sItem;
        }

        public void StoreDeptUser(StoreDeptUser _stdept)
        {
            new StoreItemRepository().StoreDeptUser(_stdept);
        }

        public bool CreateDepartment(StoreDept _dept)
        {
            return new StoreItemRepository().CreateDepartment(_dept);
        }

        public bool SaveReceiveDetails(List<StoreReceiveDetail> _rDeatailsList)
        {
            return new StoreItemRepository().SaveReceiveDetails(_rDeatailsList);
        }

        public long AddNewInvoice(StoreInvoice _invoice)
        {
            return new StoreItemRepository().AddNewInvoice(_invoice);
        }

        public StoreInvoice GetInvoiceByInvoiceNo(long _InvoiceId)
        {
            return new StoreItemRepository().GetInvoiceByInvoiceNo(_InvoiceId);
        }

        public bool SaveStoreItemUSesDetails(List<StoreItemUsesMasterDetail> _reqDetailsList)
        {
            return new StoreItemRepository().SaveStoreItemUSesDetails(_reqDetailsList);
        }

        public void AddNewInvDetails(List<StoreInvoiceDetail> _invDetailsList)
        {
            new StoreItemRepository().AddNewInvDetails(_invDetailsList);
        }

        public double GetCurrentPurchaseRateByProductId(int _pId)
        {
           return new StoreItemRepository().GetCurrentPurchaseRateByProductId(_pId);
        }

        public List<VMStoreRequisition> GetRequisitionListByDate(DateTime date)
        {
            return new StoreItemRepository().GetRequisitionListByDate(date);
        }

        public void PopulateSelectedItemDataForIssueAgainstRequisition(IList<SelectedProductsToSaleOrReceive> _SelectedItems, VMRequisitionList selectedItem)
        {

            StoreProductInfo _pInfo = this.GetProductById(selectedItem.ProductId);

            SelectedProductsToSaleOrReceive _sItem = new SelectedProductsToSaleOrReceive();
            _sItem.ProductId = _pInfo.ProductId;
            _sItem.Code = _pInfo.ProductCode;
            _sItem.Name = _pInfo.Name;
            _sItem.Qty = selectedItem.ReqQty;
            _sItem.Unit = _pInfo.Unit;
            _sItem.DebitAccId = _pInfo.DebitAccId;
            _sItem.CreditAccId = _pInfo.CreditAccId;
            _sItem.Rate = _pInfo.PurchaseRate;
            _sItem.Total = _pInfo.PurchaseRate * selectedItem.ReqQty;

            _SelectedItems.Add(_sItem);

        }

        private List<SCMSelectedItem> GetPreparedSelectedItemDataForIssueAgainstRequisition(VMRequisitionList selectedItem)
        {
            double stckQty = 0;
            List<SCMSelectedItem> _selectedPList = new List<SCMSelectedItem>();
            List<VWStoreAutomateRequisition> _reqAutoList = this.GetReuisitionAutoList(selectedItem.ProductId, selectedItem.ReqQty);
            foreach (var item in _reqAutoList)
            {
                SCMSelectedItem _selectedP = new SCMSelectedItem();
                _selectedP.LotNo = item.LotNo;
                _selectedP.ProductId = selectedItem.ProductId;
                _selectedP.Code = selectedItem.ProductCode;
                _selectedP.Name = selectedItem.BrandName;

                _selectedP.Rate = selectedItem.SalePrice;
                _selectedP.BatchNo = item.BatchNo;
                _selectedP.ExpireDate = item.ExpireDate;
                _selectedP.OutLetId = item.OutletId;
                _selectedP.Qty = item.Qty;

                _selectedP.Total = item.Qty * selectedItem.SalePrice;

                _selectedPList.Add(_selectedP);
            }

            return _selectedPList;
        }

        private List<VWStoreAutomateRequisition> GetReuisitionAutoList(int productId, double _requestedQty)
        {
            List<VWStoreAutomateRequisition> _reqAutoList = new StoreItemRepository().GetAvailableStockByBatchAndExpireDate(productId); // Retrieve StockList by BatchNo and ExpireDate
            _reqAutoList = _reqAutoList.OrderBy(x => x.ExpireDate).ToList();

            double _temReqQty = _requestedQty;
            List<VWStoreAutomateRequisition> _reqAuto = new List<VWStoreAutomateRequisition>();
            foreach (var item in _reqAutoList)
            {
                VWStoreAutomateRequisition _req = new VWStoreAutomateRequisition();
                if (_temReqQty > 0 && _temReqQty >= item.Qty)
                {
                    _req.LotNo = item.LotNo;
                    _req.ProductId = item.ProductId;
                    _req.BatchNo = item.BatchNo;
                    _req.ExpireDate = item.ExpireDate;
                    _req.OutletId = item.OutletId;
                    _req.Qty = item.Qty;
                    _reqAuto.Add(_req);
                    _temReqQty = _temReqQty - item.Qty;
                }
                else if (_temReqQty > 0 && _temReqQty <= item.Qty)
                {
                    _req.LotNo = item.LotNo;
                    _req.ProductId = item.ProductId;
                    _req.BatchNo = item.BatchNo;
                    _req.ExpireDate = item.ExpireDate;
                    _req.OutletId = item.OutletId;
                    _req.Qty = _temReqQty;
                    _reqAuto.Add(_req);
                    _temReqQty = _temReqQty - item.Qty;
                }

            }

            return _reqAuto;
        }

        public void PopulateSelectedItemDataForLabRequisition(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWStoreProductList storeProductInfo, double _qty)
        {
            int ItemId;

            if (storeProductInfo == null) return;

            ItemId = storeProductInfo.ProductId;
            if (_SelectedItems.Any(x => x.Id == ItemId))
            {

                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Qty = _qty);

                return;
            }

            _SelectedItems.Add(GetPreparedSelectedItemObjectForRequisition(storeProductInfo, _qty));
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForRequisition(VWStoreProductList storeProductInfo, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = storeProductInfo.ProductId;

            _PhSelectedItem.Code = storeProductInfo.ProductCode;
            _PhSelectedItem.Name = storeProductInfo.Name;
            _PhSelectedItem.Unit = storeProductInfo.Unit;
            _PhSelectedItem.Qty = _qty;

            return _PhSelectedItem;
        }

        public void UpOpdOrEmgSale(List<StoreInvoiceDetail> invDetailsList)
        {
            new StoreItemRepository().UpOpdOrEmgSale(invDetailsList);
        }

        public void PopulateSelectedItemDataForConsumeRecord(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, StoreProductInfo storeProductInfo, Patient patient, double _qty)
        {
            int ItemId;

            if (storeProductInfo == null) return;

            ItemId = storeProductInfo.ProductId;
            if (_SelectedItems.Any(x => x.Id == ItemId))
            {

                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Qty = _qty);

                return;
            }

            _SelectedItems.Add(GetPreparedSelectedItemDataForConsumeRecord(storeProductInfo, patient, _qty));
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemDataForConsumeRecord(StoreProductInfo storeProductInfo, Patient P, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = storeProductInfo.ProductId;
            _PhSelectedItem.Code = storeProductInfo.ProductCode;
            _PhSelectedItem.Name = storeProductInfo.Name;
            _PhSelectedItem.Unit = storeProductInfo.Unit;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.BillNo = P.BillNo;
            return _PhSelectedItem;
        }

        public List<VMRequisitionList> GetStoreRequisitionDetailByReqId(long requisitionId)
        {
            return new StoreItemRepository().GetStoreRequisitionDetailByReqId(requisitionId);
        }

        public StoreRequisition GetStoreRequisitionByReqId(long _requisitionNo)
        {
            return new StoreItemRepository().GetStoreRequisitionByReqId(_requisitionNo);
        }

        public void UpdateOrAddToStockInfo(List<StoreReceiveDetail> rDeatailsList)
        {
            new StoreItemRepository().UpdateOrAddToStockInfo(rDeatailsList);
        }

        public StoreInvoice GetStoreIssueInvoiceById(long _billNo)
        {
            return new StoreItemRepository().GetStoreIssueInvoiceById(_billNo);
        }

        public StoreInvoice GetStoreLastestIssueInvoice()
        {
            return new StoreItemRepository().GetStoreLastestIssueInvoice();
        }

        public StoreInvoice GetStoreFirstIssueInvoice()
        {
            return new StoreItemRepository().GetStoreFirstIssueInvoice();
        }

        public IList<StoreInvoiceDetail> GetStoreInvoiceDetails(long invoiceId)
        {
            return new StoreItemRepository().GetStoreInvoiceDetails(invoiceId);
        }

        public void UpdateRequisition(long _requisitionNo)
        {
            new StoreItemRepository().UpdateRequisition(_requisitionNo);
        }

        public bool SaveRequisitionDetails(List<StoreRequisitionDetail> _reqDetailsList)
        {
            return new StoreItemRepository().SaveRequisitionDetails(_reqDetailsList);
        }

        public long SaveRequisition(StoreRequisition _hpMReq)
        {
            return new StoreItemRepository().SaveRequisition(_hpMReq);
        }

        public StoreReceive GetStoreReceiveInvoiceById(long _billNo)
        {
            return new StoreItemRepository().GetStoreReceiveInvoiceById(_billNo);
        }

        public StoreReceive GetStoreLastestReceiveInvoice()
        {
            return new StoreItemRepository().GetStoreLastestReceiveInvoice();
        }

        public StoreReceive GetStoreFirstReceiveInvoice()
        {
            return new StoreItemRepository().GetStoreFirstReceiveInvoice();
        }

        public IList<StoreReceiveDetail> GetStoreReceiveDetails(long receiveId)
        {
            return new StoreItemRepository().GetStoreReceiveDetails(receiveId);
        }

        

        public List<VMPOItems> GetPOItems(long poNo)
        {
           return  new StoreItemRepository().GetPOItems(poNo);
        }

        public DataSet GetStoreStockStatement(DateTime dtpfrm, DateTime dtpto, int groupId, int productId, string GroupName, string ProductName)
        {
            return new StoreItemRepository().GetStoreStockStatement(dtpfrm, dtpto, groupId, productId, GroupName, ProductName);
        }
    }
}
