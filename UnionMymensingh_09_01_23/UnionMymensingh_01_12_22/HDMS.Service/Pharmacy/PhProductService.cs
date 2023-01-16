using HDMS.Models.Pharmacy;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Repositories.Pharmacy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Hospital;
using System.Data;
using System.Data.Entity;
using HDMS.Model.Accounting.VModel;

namespace HDMS.Service.Pharmacy
{
    public class PhProductService
    {

        public bool SaveProduct(PhProductInfo PhP_Info)
        {
            return new PhProductRepository().SaveProduct(PhP_Info);
        }

        public DataSet GetAuditedStockData(long _asmId)
        {
            return new PhProductRepository().GetAuditedStockData(_asmId);
        }

        public IList<PhProductInfo> GetAllProduct()
        {
            return new PhProductRepository().GetAllProduct();
        }

        public DataSet GetPhCompanyWiseDailySaleSummary(DateTime dtp)
        {
            return new PhProductRepository().GetPhCompanyWiseDailySaleSummary(dtp);
        }

        public DataSet GetPhCompanyWiseDailySalePurchase(DateTime dtpfrm, DateTime dtpto)
        {
            return new PhProductRepository().GetPhCompanyWiseDailySalePurchase(dtpfrm, dtpto);
        }

        public DataSet GetPhOpeningClosingStock(DateTime dtpfrm, DateTime dtpto)
        {
            return new PhProductRepository().GetPhOpeningClosingStock(dtpfrm, dtpto);
        }

        public List<VWPhStockWithLotAndExpireInfo> GetPhStockList(int productId)
        {
            return new PhProductRepository().GetPhStockList(productId);
        }

        public IList<VMPhStock> GetPhStock(int outLetId, string searchString, int _manufacturerId)
        {
            return new PhProductRepository().GetPhStock(outLetId, searchString, _manufacturerId);
        }

        

        public void PopulateSelectedItemDataForSaleFromMultipleLot(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductListForSale vWPhProductList, double rate, double qty)
        {
            List<PhSelectedProductsToSaleOrReceiveOrOrder> _pList = this.GetPreparedSelectedItemDataForSaleFromMultipleLot(vWPhProductList, rate, qty);

            foreach (var item in _pList)
            {
                _SelectedItems.Add(item);
            }
        }

        public List<VMOutletMedicineRequisition> GetAllPhOutletRequisition(DateTime _dt)
        {
            return new PhProductRepository().GetAllPhOutletRequisition(_dt);
        }

        public List<VMOutletMedicineRequisition> GetPhOutletRequisitionList(int outletId, DateTime _dt)
        {
            return new PhProductRepository().GetPhOutletRequisitionList(outletId,_dt);
        }

        //public IList<VWPhProductInfo> GetProductListBySpace()
        //{
        //    throw new NotImplementedException();
        //}

        public IList<VWPhProductInfo> GetProductListBySpace()
        {
            return new PhProductRepository().GetProductListBySpace();
        }

        private List<PhSelectedProductsToSaleOrReceiveOrOrder> GetPreparedSelectedItemDataForSaleFromMultipleLot(VWPhProductListForSale selectedItem, double rate, double qty)
        {
            double stckQty = 0;
            List<PhSelectedProductsToSaleOrReceiveOrOrder> _selectedPList = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            List<VMPhRequisitionAutomation> _reqAutoList = this.GetReuisitionAutoList(selectedItem.ProductId, qty, selectedItem.OutLetId);
            foreach (var item in _reqAutoList)
            {
                PhSelectedProductsToSaleOrReceiveOrOrder _selectedP = new PhSelectedProductsToSaleOrReceiveOrOrder();
                _selectedP.LotNo = item.LotNo;
                _selectedP.Id = selectedItem.ProductId;
                _selectedP.Code = selectedItem.ProductCode;
                _selectedP.Name = selectedItem.FormationShortName+" "+selectedItem.BrandName;
                _selectedP.PRate = selectedItem.PurchasePrice;
                _selectedP.SRate = selectedItem.SalePrice;
                _selectedP.BatchNo = item.BatchNo;
                _selectedP.ExpireDate = item.ExpireDate;
                _selectedP.OutLetId = item.OutletId;
                _selectedP.Qty = item.Qty;

                _selectedP.Total = item.Qty * selectedItem.SalePrice;
                _selectedP.PTotal = selectedItem.PurchasePrice * item.Qty;
                _selectedPList.Add(_selectedP);
            }

            return _selectedPList;

        }

        public void PopulateSelectedItemDataForOrder(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductInfo vWPhProductInfo, double rate, double qty)
        {
            int ItemId;
            long _lotNo = 0;

            if (vWPhProductInfo == null) return;

            ItemId = vWPhProductInfo.ProductId;
            _lotNo = vWPhProductInfo.LotNo;
            if (_SelectedItems.Any(x => x.Id == ItemId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObjectForOrder(vWPhProductInfo, rate, qty));
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForOrder(VWPhProductInfo phProductInfo, double rate, double qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = phProductInfo.ProductId;
            _PhSelectedItem.BarCode = phProductInfo.BarCode;

            _PhSelectedItem.Name = phProductInfo.BrandName;
            _PhSelectedItem.Unit = phProductInfo.Unit;
            _PhSelectedItem.Qty2 = qty.ToString();
            _PhSelectedItem.CurrentStock = phProductInfo.Stock;
            _PhSelectedItem.PRate = rate;
            _PhSelectedItem.Discount = 0;

            _PhSelectedItem.Total = rate * qty;

            return _PhSelectedItem;
        }

        public PhLotInfo GetPhLotInfo(long lotNo)
        {
            return new PhProductRepository().GetPhLotInfo(lotNo);
        }

        public PhStockInfo GetPhStockInfo(long stckId)
        {
            return new PhProductRepository().GetPhStockInfo(stckId);
        }

        public List<VMPhSoldItem> GetPhSoldItems(long invoiceId)
        {
            return new PhProductRepository().GetPhSoldItems(invoiceId);
        }

        public void UpdatePhLotInfo(PhLotInfo lotInfo)
        {
            new PhProductRepository().UpdatePhLotInfo(lotInfo);
        }

        public void PopulateSelectedItemDataForSale(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductListForSale phProductInfo, double _rate, double _qty)
        {
            int ItemId;
            long _lotNo;
            int _outletId;

            if (phProductInfo == null) return;

            ItemId = phProductInfo.ProductId;
            _lotNo = phProductInfo.LotNo;
            _outletId = phProductInfo.OutLetId;
            if (_SelectedItems.Any(x => x.Id == ItemId && x.LotNo == _lotNo && x.OutLetId == _outletId))
            {

                PhSelectedProductsToSaleOrReceiveOrOrder sp = _SelectedItems.Where(x => x.Id == ItemId && x.LotNo == _lotNo && x.OutLetId == _outletId).FirstOrDefault();
                _qty = _qty + sp.Qty;

                _SelectedItems.Where(w => w.Id == ItemId && w.LotNo == _lotNo && w.OutLetId == _outletId).ToList().ForEach(s => s.Qty = _qty);
                _SelectedItems.Where(w => w.Id == ItemId && w.LotNo == _lotNo && w.OutLetId == _outletId).ToList().ForEach(s => s.SRate = _rate);
                _SelectedItems.Where(w => w.Id == ItemId && w.LotNo == _lotNo && w.OutLetId == _outletId).ToList().ForEach(s => s.Total = _rate * _qty);
                return;
            }

            _SelectedItems.Add(GetPreparedSelectedItemObjectForSale(phProductInfo, _rate, _qty));
        }

        public List<PhProductInfo> GetProductListByGeneric(int genericId)
        {
            return new PhProductRepository().GetProductListByGeneric(genericId);
        }

        public bool IsOpeningStockSet(DateTime _date)
        {
            return new PhProductRepository().IsOpeningStockSet(_date);
        }

        public bool SaveMapProductWithRackAndBlock(List<PhProductLocation> prodLocList)
        {
            return new PhProductRepository().SaveMapProductWithRackAndBlock(prodLocList);
        }

        public Manufacturer GetManufacturerById(int supplerId)
        {
            return new PhProductRepository().GetManufacturerById(supplerId);
        }

        public DataSet GetPhProductLedger(DateTime dtfrm, DateTime dtto, VWPhProductList phProductInfo,int outletId)
        {
            return new PhProductRepository().GetPhProductLedger(dtfrm, dtto, phProductInfo, outletId);
        }

        public List<VMPhProductMapWithRackAndBlock> GetPhMappedProductWithManufacturer(int manufacturerId,int genId, int outletId)
        {
            return new PhProductRepository().GetPhMappedProductWithManufacturer(manufacturerId, genId, outletId);
        }

        public DataSet GetPhStockTransferStatement(DateTime dtpfrm, DateTime dtpto, int fromoutLetId, int tooutletId)
        {
            return new PhProductRepository().GetPhStockTransferStatement(dtpfrm, dtpto, fromoutLetId, tooutletId);
        }

        public List<VMedicineRequisition> GetoutletsPendingRequisitionList()
        {
            return new PhProductRepository().GetoutletsPendingRequisitionList();
        }

        public async Task<List<VMPhProductListForRxPerspective>> GetBasicProductInfoListAsync(string brand, string generic)
        {
            return await new PhProductRepository().GetBasicProductInfoListAsync(brand, generic);
        }

        public IList<VMPhProductListForRxPerspective> GetBasicProductInfoListForRxPerspective(string brand, string generic)
        {
            return  new PhProductRepository().GetBasicProductInfoListForRxPerspective(brand, generic);
        }

        public IList<VWRxPhProductList> GetRxBasicProductInfoList(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public List<PhStockAuditMaster> GetPhStockAuditMasters()
        {
            return new PhProductRepository().GetPhStockAuditMasters();
        }

        public IList<VWRxPhProductList> GetFilteredRxCpPreferredProductListWithStock(string brand, string generic, string formation, int cpId)
        {
            return new PhProductRepository().GetFilteredRxCpPreferredProductListWithStock(brand, generic, formation, cpId);
        }

        public IList<VWRxPhProductList> GetFilteredRxProductListWithStock(string brand, string generic, string formation)
        {
            return new PhProductRepository().GetFilteredRxProductListWithStock(brand, generic, formation);
        }

        public IList<VWRxPhProductList> GetRxProductListWithStock(string filterString)
        {
            return new PhProductRepository().GetRxProductListWithStock(filterString);
        }

        public IList<VWPhProductList>  GetBasicProductInfoListByGeneric(int genId)
        {
            return new PhProductRepository().GetBasicProductInfoListByGeneric(genId);
        }

        public IList<VWPhProductListForSale> GetPhItemForSale(string filterString)
        {
            return new PhProductRepository().GetPhItemForSale(filterString);
        }

        public DataSet GetPhSupplierReturnStatement(DateTime dtpfrm, DateTime dtpto, int _manufacturerId)
        {
            return new PhProductRepository().GetPhSupplierReturnStatement(dtpfrm, dtpto, _manufacturerId);
        }

        public List<PhSaleLedger> GetPhLedgerByInvoice(long invoiceId)
        {
            return new PhProductRepository().GetPhLedgerByInvoice(invoiceId);
        }

       

        public List<VWPhProductInfo> GetPhStockByManufacturer(int manufacturerId)
        {
            return new PhProductRepository().GetPhStockByManufacturer(manufacturerId);
        }

        public bool UpdateOutletInfo(MedicineOutlet _outlet)
        {
            return new PhProductRepository().UpdateOutletInfo(_outlet);
        }

        public async Task<PhOutletMedicinieRequisition> CreateNewPhOutletRequistion(PhOutletMedicinieRequisition hpMReq, List<PhOutletMedicineRequisitionDetail> reqDetailsList)
        {
            return await new PhProductRepository().CreateNewPhOutletRequistion(hpMReq, reqDetailsList);
        }

        public void PopulateSelectedItemDataByManufacturer(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, int manufacturerId)
        {
            List<PhProductInfo> _pList = new PhProductRepository().GetPhProductListByManufacturer(manufacturerId).OrderBy(x => x.BrandName).ToList();

            foreach (var item in _pList)
            {
                _SelectedItems.Add(GetPhPreparedObject(item));
            }

        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPhPreparedObject(PhProductInfo phProductInfo)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();

            List<PhStockInfo> _stockList = new PhProductRepository().GetPhStockListByProdId(phProductInfo.ProductId);

            double _currentQty = _stockList.Sum(x => x.CurrentStock);

            double _orderQty = 0;
            string _orderQty2 = "";
            if (phProductInfo.ROLOutdoor > _currentQty)
            {
                _orderQty = phProductInfo.ROLOutdoor - _currentQty;
            }

            if (_orderQty > 0)
            {
                _orderQty2 = _orderQty.ToString();
            }

            _PhSelectedItem.Id = phProductInfo.ProductId;
            _PhSelectedItem.BarCode = phProductInfo.BarCode;

            _PhSelectedItem.Name = phProductInfo.BrandName;
            _PhSelectedItem.Unit = phProductInfo.Unit;
            _PhSelectedItem.Qty = _currentQty;
            _PhSelectedItem.Qty2 = _orderQty2;
            _PhSelectedItem.PRate = phProductInfo.PurchasePrice;

            _PhSelectedItem.Discount = 0;
            _PhSelectedItem.ROLOutdoor = phProductInfo.ROLOutdoor;

            _PhSelectedItem.Total = 0;

            return _PhSelectedItem;
        }

        public IList<VWPhProductList> GetProductListWithStockFilterByGeneric(string _filterString)
        {
            return new PhProductRepository().GetProductListWithStockFilterByGeneric(_filterString);
        }

        public List<MedicineOutlet> GetAllMedicineOutlets()
        {
            return new PhProductRepository().GetAllMedicineOutlets();
        }

        public IList<VWPhProductInfo> GetProductListByGenAndManufacturer(string _filterString)
        {
            return new PhProductRepository().GetProductListByGenAndManufacturer(_filterString);
        }

        public bool CreateOutlet(MedicineOutlet _outlet)
        {
            return new PhProductRepository().CreateOutlet(_outlet);
        }

        public DataSet GetPhStockByDate(DateTime dtpfrm, DateTime dtpto, int outLetId)
        {
            return new PhProductRepository().GetPhStockByDate(dtpfrm, dtpto, outLetId);
        }


        public IList<VWPhProductList> GetBasicProductInfoList(string name, string _type)
        {
            return new PhProductRepository().GetBasicProductInfoList(name, _type);
        }

        public IList<VWPhProductInfo> GetProductListBySearchStr(string _filterString)
        {
            return new PhProductRepository().GetProductListBySearchStr(_filterString);
        }

        public IList<VWPhProductInfo> GetUnderStockList(int manufacturerId)
        {
            return new PhProductRepository().GetUnderStockList(manufacturerId);
        }

        public DataSet GetPhOpeningClosingStockDataset(DateTime dtfrm, DateTime dtto)
        {
            return new PhProductRepository().GetPhOpeningClosingStockDataset(dtfrm, dtto);
        }

        public PhOutletMedicinieRequisition GetOutletMedicineRequisitionByReqId(long requisitionId)
        {
            return new PhProductRepository().GetOutletMedicineRequisitionByReqId(requisitionId);
        }

        public void UpdateOutletRequisition(PhOutletMedicinieRequisition mreq)
        {
            new PhProductRepository().UpdateOutletRequisition(mreq);
        }

        public PhStockTransferRecord GetPhStockTransferRecord(long requisitionId)
        {
            return new PhProductRepository().GetPhStockTransferRecord(requisitionId);
        }

        public List<VMIssuedProductAgainstRequisition> GetOutletIssuedProductAgainstRequisition(PhStockTransferRecord phTransferRecord)
        {
            return new PhProductRepository().GetOutletIssuedProductAgainstRequisition(phTransferRecord);
        }

        public List<VMOutletRequisitionList> GetOutletMedicineRequisitionDetailByReqId(long requisitionId, int fromOutletId)
        {
            return new PhProductRepository().GetOutletMedicineRequisitionDetailByReqId(requisitionId, fromOutletId);
        }

        public DataSet GetPhStockDataset(int outLetId, string searchStr, int _stockParam,int _manaufacturerId)
        {
            return new PhProductRepository().GetPhStockDataset(outLetId, searchStr, _stockParam, _manaufacturerId);
        }

        public void UpdatePhProductInfo(PhProductInfo _pInfo)
        {
            new PhProductRepository().UpdatePhProductInfo(_pInfo);
        }

        public PhReceive PhReceiveInvoice(long _ReceiveId)
        {
            return new PhProductRepository().PhReceiveInvoice(_ReceiveId);
        }

        public PhInvoice GetPhInvoiceByInvoiceNo(Int64 _InvoiceNo)
        {
            return new PhProductRepository().GetPhInvoiceByInvoiceNo(_InvoiceNo);
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForSale(VWPhProductListForSale phProductInfo, double _rate, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = phProductInfo.ProductId;
            _PhSelectedItem.BarCode = phProductInfo.BarCode;
            _PhSelectedItem.Code = phProductInfo.ProductCode;
            _PhSelectedItem.Name = phProductInfo.FormationShortName+" "+phProductInfo.BrandName;
            _PhSelectedItem.LotNo = phProductInfo.LotNo;
            _PhSelectedItem.OutLetId = phProductInfo.OutLetId;
            _PhSelectedItem.BatchNo = phProductInfo.BatchNo;
            _PhSelectedItem.ExpireDate = phProductInfo.ExpireDate;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.SRate = _rate;
            _PhSelectedItem.Discount = 0;
            _PhSelectedItem.PRate = phProductInfo.PurchasePrice;
            _PhSelectedItem.Total = _rate * _qty;
            _PhSelectedItem.PTotal = phProductInfo.PurchasePrice * _qty;

            return _PhSelectedItem;
        }

        public void PopulateOrderedItemData(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductInfo vWPhProductInfo, double _rate, double _qty)
        {
            int ItemId;
            long _lotNo = 0;

            if (vWPhProductInfo == null) return;

            ItemId = vWPhProductInfo.ProductId;
          
            if (_SelectedItems.Any(x => x.Id == ItemId)) return;

            _SelectedItems.Add(GetPreparedOrderedItemObject(vWPhProductInfo, _rate, _qty));
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedOrderedItemObject(VWPhProductInfo vWPhProductInfo, double _rate, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = vWPhProductInfo.ProductId;
            _PhSelectedItem.BarCode = vWPhProductInfo.BarCode;

            _PhSelectedItem.Name = vWPhProductInfo.FormationShortName + " " + vWPhProductInfo.BrandName;
            _PhSelectedItem.Unit = vWPhProductInfo.Unit;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.SRate = _rate;
            _PhSelectedItem.Discount = 0;

            _PhSelectedItem.Total = _rate * _qty;

            return _PhSelectedItem;
        }

        public List<VWPhProductInfo> GetPhStockByBrandName(string _brandName,int _outletId)
        {
            return new PhProductRepository().GetPhStockByBrandName(_brandName, _outletId);
        }

        public bool SaveStockTransferRecord(PhStockTransferRecord _sttr)
        {
            return new PhProductRepository().SaveStockTransferRecord(_sttr);
        }

        public PhStockInfo GetCurrentStockByProdId(int productId,long _lotNo)
        {
            return new PhProductRepository().GetCurrentStockByProdId(productId, _lotNo);
        }

        public bool UpdatePhStockInfo(PhStockInfo _stockInfo)
        {
            return new PhProductRepository().UpdatePhStockInfo(_stockInfo);
        }

        public bool AddStockTransferDetails(List<PhStockTransferRecordDetail> _rdDetailsList)
        {
            return new PhProductRepository().AddStockTransferDetails(_rdDetailsList);
        }

        public void AddUpdateStockOnTransfer(List<PhStockTransferRecordDetail> _rdDetailsList, int fromoutLetId, int toOutletId, DateTime _transferDate, string userName)
        {
            new PhProductRepository().AddUpdateStockOnTransfer(_rdDetailsList, fromoutLetId, toOutletId, _transferDate, userName);
        }

        public void DeleteExistingAuditRecord(int productId)
        {
            new PhProductRepository().DeleteExistingAuditRecord(productId);
        }

        public bool SaveReturnToSupplier(PhReturnToSupplier _retToSupplier)
        {
            return new PhProductRepository().SaveReturnToSupplier(_retToSupplier);
        }

        public List<HpMedicineReturnInednt> GetPhReturnIndentList()
        {
            return new PhProductRepository().GetPhRetutnIndentList();
        }

        public List<PhProductInfo> GetProductListByManufacturer(int manufacturerId)
        {
            return new PhProductRepository().GetProductListByManufacturer(manufacturerId);
        }

        public void SavePhAuditDetail(PhStockAuditMasterDetail _auditdetail)
        {
            new PhProductRepository().SavePhAuditDetail(_auditdetail);
        }

        public Generic GetGeneric(int genericId)
        {
            return new PhProductRepository().GetGeneric(genericId);
        }

        public void CancelOutletMedicineRequisition(long requisitionId)
        {
            new PhProductRepository().CancelOutletMedicineRequisition(requisitionId);
            
        }

        public List<PhProductInfo> GetProductsByGeneric(int genericId)
        {
            return new PhProductRepository().GetProductsByGeneric(genericId);
        }

        public bool AddSupplierReturnDetails(List<PhSupplierReturnDetail> _retDetailsList)
        {
            return new PhProductRepository().AddSupplierReturnDetails(_retDetailsList);
        }

        public void PopulateSelectedItemDataForRequisition(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductInfo vWPhProductInfo, double _qty)
        {
            int ItemId;

            if (vWPhProductInfo == null) return;

            ItemId = vWPhProductInfo.ProductId;
            if (_SelectedItems.Any(x => x.Id == ItemId))
            {

                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Qty = _qty);
              
                return;
            }

            _SelectedItems.Add(GetPreparedSelectedItemObjectForRequisition(vWPhProductInfo, _qty));
        }

        public void UpdateStockOnReturn(List<PhSupplierReturnDetail> _retDetailsList, int outLetId)
        {
            new PhProductRepository().UpdateStockInfoOnReturn(_retDetailsList,outLetId);
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForRequisition(VWPhProductInfo vWPhProductInfo, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = vWPhProductInfo.ProductId;
            
            _PhSelectedItem.Code = vWPhProductInfo.ProductCode;
            _PhSelectedItem.Name = vWPhProductInfo.FormationShortName+" "+vWPhProductInfo.BrandName;
            _PhSelectedItem.Unit = vWPhProductInfo.Unit;
           
            _PhSelectedItem.Qty = _qty;
           

            return _PhSelectedItem;
        }

        public bool IsPhBillNoAlloted(long _billNo)
        {
            return new PhProductRepository().IsPhBillNoAlloted(_billNo);
        }

        public PhOutletMedicineRequisitionDetail GetPhOutletRequisitionDetail(long requisitionId, int productId)
        {
            return new PhProductRepository().GetPhMedicineRequisitionDetail(requisitionId, productId);
        }

        public IList<VWPhProductList> GetProductListWithStock(string _filterString)
        {
             return new PhProductRepository().GetProductListWithStock(_filterString);
        }

        public void UpdatePhMedicineRequisitionDetail(PhOutletMedicineRequisitionDetail reqDetail)
        {
            new PhProductRepository().UpdatePhMedicineRequisitionDetail(reqDetail);
        }

        public PhStockInfo GetPhStockByStckId(long stckId)
        {
            return new PhProductRepository().GetPhStockByStckId(stckId);
        }

        public DataSet GetPhStockTransferInvoice(long stTId)
        {
            return new PhProductRepository().GetPhStockTransferInvoice(stTId);
        }

        public MedicineOutlet getOutletById(int _outletId)
        {
            return new PhProductRepository().getOutletById(_outletId);
        }

        public PhProductInfo GetProductById(int productId)
        {
            return new PhProductRepository().GetProductById(productId);
        }

        public bool IsRequisitionNoAlloted(long _requisitionNo)
        {
            return new PhProductRepository().IsRequisitionNoAlloted(_requisitionNo);
        }

        public IList<PhInvoiceDetail> GetPhInvoiceDetails(long _InvoiceNo)
        {
            return new PhProductRepository().GetPhInvoiceDetails(_InvoiceNo);
        }

        public bool AddGroup(PhProductGroup _group)
        {
            return new PhProductRepository().AddGroup(_group);
        }

       

        public void PopulateSelectedItemData(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductListForSale phProductInfo, double _rate, double _qty)
        {
            int ItemId;
            long _lotNo=0;

            if (phProductInfo == null) return;

            ItemId = phProductInfo.ProductId;
            _lotNo = phProductInfo.LotNo;
            if (_SelectedItems.Any(x => x.Id == ItemId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObject(phProductInfo, _rate, _qty));
        }

     

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObject(VWPhProductListForSale phProductInfo, double _rate, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
           
            _PhSelectedItem.Id = phProductInfo.ProductId;
            _PhSelectedItem.BarCode = phProductInfo.BarCode;
            _PhSelectedItem.Code = phProductInfo.ProductCode;
            _PhSelectedItem.Name = phProductInfo.BrandName;
            _PhSelectedItem.LotNo = phProductInfo.LotNo;
            _PhSelectedItem.OutLetId = phProductInfo.OutLetId;
            _PhSelectedItem.BatchNo = phProductInfo.BatchNo;
            _PhSelectedItem.ExpireDate = phProductInfo.ExpireDate;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.SRate = _rate;
            _PhSelectedItem.Discount = 0;
            _PhSelectedItem.PRate = phProductInfo.PurchasePrice;

            _PhSelectedItem.Total = _rate * _qty;

            return _PhSelectedItem;
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            return new PhProductRepository().IsBillNoAlloted(_billNo);
        }

        public int GetTotalOrderOfthisMonth(int year, int month)
        {
            return new PhProductRepository().GetTotalOrderOfthisMonth(year, month);
        }

        public long SaveReceivedInvoice(PhReceive rcv)
        {
            return new PhProductRepository().SaveReceivedInvoice(rcv);
        }

        public bool SaveReceiveDetails(List<PhReceiveDetail> _rDeatailsList)
        {
            return new PhProductRepository().SaveReceiveDetails(_rDeatailsList);
        }

        public IList<VWPhProductList> GetStockListForSale(string _filterString)
        {
            return new PhProductRepository().GetStockListForSale(_filterString);
        }

        public HpMedicineRequisition GetRequisitionByReqNo(long _requisitonNo)
        {
            return new PhProductRepository().GetRequisitionByReqId(_requisitonNo);
        }

        public long AddNewInvoice(PhInvoice pi)
        {
            return new PhProductRepository().AddNewInvoice(pi);
        }

        public bool AddNewInvDetails(List<PhInvoiceDetail> _invDetailsList)
        {
            return new PhProductRepository().AddNewInvDetails(_invDetailsList);
        }

        public long SaveOrder(PhOrder Phord)
        {
            return new PhProductRepository().SaveOrder(Phord);
        }

        public bool SaveOrderDetail(List<PhOrderDetail> _ODeatailsList)
        {
            return new PhProductRepository().SaveOrderDetail(_ODeatailsList);
        }



     

        public PhCompany GetCompany()
        {
            return new PhProductRepository().GetCompany();
        }

        public PhOrder GetOrderByOrderNo(string OrderNo)
        {
            return new PhProductRepository().GetOrderByOrderNo(OrderNo);
        }

        public List<PhSelectedProductsToSaleOrReceiveOrOrder> GetOrderedProductListByOrderId(long orderId)
        {
            return new PhProductRepository().GetOrderedProductListByOrderId(orderId);
        }

        public List<PhProductGroup> GetAllGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductGroups.ToList();
            }

        }

        public bool SaveBulkProductDataFromExcel(List<PhProductInfo> _pList)
        {
            return new PhProductRepository().SaveBulkProductDataFromExcel(_pList);
        }

       
        public void PopulateSelectedItemDataForStockEntry(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VWPhProductList phProductInfo, double _prate, double _srate, double _qty, string _batchNo, DateTime _ExpDate, double _total, double discInPercent, double vatInPercent, double _grossTotal, int _userId, DateTime _createDate, int outletId)
        {
                int ItemId;

                if (phProductInfo == null) return;

                ItemId = phProductInfo.ProductId;


                if (_SelectedItems.Any(x => x.Id == ItemId))  //&& x.BatchNo == _batchNo && x.ExpireDate == _ExpDate))
                {

                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.BatchNo = _batchNo);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.ExpireDate = _ExpDate);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Qty = _qty);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.PRate = _prate);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Total = _prate * _qty);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.DiscInPercentPerProduct = discInPercent);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.VatInPercentPerProduct = vatInPercent);
                double _discount = (_total * discInPercent) / 100;
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Discount = _discount);
                double _vatTk = (_total * vatInPercent) / 100;
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Vat = _vatTk);
                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Gtotal = _grossTotal);
                return;
            }

                _SelectedItems.Add(GetPreparedSelectedItemObjectForStockEntry(phProductInfo, _prate, _srate, _qty, _batchNo, _ExpDate, _total, discInPercent, vatInPercent, _grossTotal, _userId, _createDate, outletId));
            }

        public void UpdateOrAddToReturnedStockInfo(List<PhReceiveDetail> rDeatailsList, int outLetId,DateTime _rettrandate, string userName, long RetInvoiceNo)
        {
            new PhProductRepository().UpdateOrAddToReturnedStockInfo(rDeatailsList, outLetId, _rettrandate, userName, RetInvoiceNo);
        }

        public void UpdateStockInfoOnReturn(List<PhInvoiceDetail> _invDetailsList, int _outLetId)
        {
            new PhProductRepository().UpdateStockInfoOnReturn(_invDetailsList, _outLetId);
        }

        public void SaveBulkProductReceiveData(List<PhReceiveDetail> _pReceiveDetails)
        {
            new PhProductRepository().SaveBulkProductReceiveData(_pReceiveDetails);
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForStockEntry(VWPhProductList phProductInfo, double _prate, double _srate, double _qty, string _batchNo, DateTime _ExpDate, double _total, double discInPercent, double vatInPercent, double _grossTotal, int _userId, DateTime _createDate, int outletId)
        {
            long _lotNo = 0;

            PhLotInfo _pLot = new PhProductService().GetPhLotInfo(_batchNo, _ExpDate);
            if (_pLot != null)
            {
                _lotNo = _pLot.LotNo;
            }
            else
            {
                PhLotInfo _PL = new PhLotInfo();
                _PL.BatchNo = _batchNo;
                _PL.ExpireDate = _ExpDate;
                _PL.CreateDate = _createDate;
                _PL.UserId = _userId;
                _PL.ModifyBy = _userId;
                _PL.ModifyDate = _createDate;
                _lotNo = new PhProductService().SaveBatchAndExpireInfo(_PL);
            }

            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = phProductInfo.ProductId;
            _PhSelectedItem.BarCode = phProductInfo.BarCode;
            _PhSelectedItem.Code = phProductInfo.ProductCode;
            _PhSelectedItem.LotNo = _lotNo;
            _PhSelectedItem.BatchNo = _batchNo;
            _PhSelectedItem.ExpireDate = _ExpDate;
            _PhSelectedItem.Name = phProductInfo.FormationShortName+" "+phProductInfo.BrandName;
            _PhSelectedItem.Unit = phProductInfo.Unit;
            _PhSelectedItem.Qty = _qty;
            _PhSelectedItem.PRate = _prate;
            _PhSelectedItem.SRate = _srate;
            _PhSelectedItem.Total = _total;
            _PhSelectedItem.DiscInPercentPerProduct = discInPercent;
            _PhSelectedItem.Discount = (_total * discInPercent) / 100;
            _PhSelectedItem.VatInPercentPerProduct = vatInPercent;
            _PhSelectedItem.Vat = (_total * vatInPercent) / 100;
            _PhSelectedItem.PRIncludingVat = Math.Round(_prate + (_prate * (vatInPercent - discInPercent)) / 100, 2);
            _PhSelectedItem.Gtotal = _grossTotal;
            _PhSelectedItem.OutLetId = outletId;
            return _PhSelectedItem;
        }

        public PhReceive GetPhReceiveBySupInvoice(string supInvoiceNo,int supplierid)
        {
            return new PhProductRepository().GetPhReceiveBySupInvoice(supInvoiceNo,supplierid);
        }

        public Generic GetPhProducGenId(int genericId)
        {
            return new PhProductRepository().GetPhProducGenId(genericId);
        }

        private long SaveBatchAndExpireInfo(PhLotInfo _PL)
        {
            return new PhProductRepository().SaveBatchAndExpireInfo(_PL);
        }

        private PhLotInfo GetPhLotInfo(string _batchNo, DateTime _ExpDate)
        {
            return new PhProductRepository().GetPhLotInfo(_batchNo, _ExpDate);
        }

        public long SaveReturnIndent(HpMedicineReturnInednt _ReturnIndent)
        {
            return new PhProductRepository().SaveHpReturnIndent(_ReturnIndent);
        }

       
        public double getPhDiscountByInvoiceId(long invoiceId)
        {
            return new PhProductRepository().getPhDiscountByInvoiceId(invoiceId);
        }

        public IList<PhInvoiceType> GetInvoiceType()
        {
            return new PhProductRepository().GetInvoiceType();
        }

        public void SavePhSaleLedger(List<PhSaleLedger> transactionList)
        {
            new PhProductRepository().SavePhSaleLedger(transactionList);
        }

        public PhInvoice GetPhIPDLastestInvoice()
        {
           return new PhProductRepository().GetPhIPDLastestInvoice();
        }

        public double GetPhInvoiceBalance(long invoiceId)
        {
            return new PhProductRepository().GetPhInvoiceBalance(invoiceId);
        }

        public PhInvoice GetPhInvoiceByBillNo(long _billNo)
        {
            return new PhProductRepository().GetPhInvoiceByBillNo(_billNo);
        }

        public PhInvoice GetPhInvoiceByInvoiceId(long _InvoiceId)
        {
            return new PhProductRepository().GetPhInvoiceByInvoiceId(_InvoiceId);
        }

        public PhInvoice GetPhFirstInvoice()
        {
            return new PhProductRepository().GetPhFirstInvoice();
        }

        public void SaveReturnIndentDetail(List<HpMedicineReturnIndentDetail> _rDeatailsList)
        {
             new PhProductRepository().SaveReturnIndentDetail(_rDeatailsList);
        }

        public List<PhInvoice> GetInvoiceListByAdmissionNo(long _admissionId)
        {
            return new PhProductRepository().GetInvoiceListByAdmissionNo(_admissionId);
        }

        public void UpdateOrAddToStockInfo(List<PhSelectedProductsToSaleOrReceiveOrOrder> _rDeatailsList, int outLetId)
        {
            new PhProductRepository().UpdateOrAddToStockInfo(_rDeatailsList, outLetId);
        }

        public void UpdateReturnIndent(HpMedicineReturnInednt _RetIndent)
        {
            new PhProductRepository().UpdateReturnIndent(_RetIndent);
        }

        public VWPhProductListForSale GetStockByProductId(int ProductId, int OutLetId, long lotNo)
        {
            return new PhProductRepository().GetStockByProductId(ProductId, OutLetId, lotNo);
        }

        public VWPhProductListForSale GetStockForSaleByProductId(int ProductId, int OutLetId, long lotNo)
        {
            return new PhProductRepository().GetStockForSaleByProductId(ProductId, OutLetId, lotNo);
        }

        public double GetTotalStock(int productId)
        {
            return new PhProductRepository().GetTotalStock(productId);
        }

        public void PopulateSelectedItemDataForSaleAgainstRequisition(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VMOutletRequisitionList selectedItem, VMOutletMedicineRequisition reqMaster)
        {
          

            List<PhSelectedProductsToSaleOrReceiveOrOrder> _pList = GetPreparedSelectedItemDataForSaleAgainstRequisition(selectedItem, reqMaster);

            foreach (var item in _pList)
            {
                _SelectedItems.Add(item);
            }
            

            
           
        }

        public PhOrder GetPhOrderByOrderNo(string _orderNo)
        {
            return new PhProductRepository().GetPhOrderByOrderNo(_orderNo);
        }

        private bool IsProductAvailableOnSameExpireDate(VMRequisitionList selectedItem)
        {
            return true;
        }

        private List<PhSelectedProductsToSaleOrReceiveOrOrder> GetPreparedSelectedItemDataForSaleAgainstRequisition(VMOutletRequisitionList selectedItem, VMOutletMedicineRequisition _reqMaster)
        {
            double stckQty = 0;
            List<PhSelectedProductsToSaleOrReceiveOrOrder> _selectedPList = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            //List<VMPhRequisitionAutomation> _reqAutoList = this.GetReuisitionAutoList(selectedItem.ProductId, selectedItem.ReqQty, _reqMaster.ToOutletId);
            List<VMPhRequisitionAutomation> _reqAutoList = this.GetReuisitionAutoList(selectedItem.ProductId, selectedItem.TransferQty, _reqMaster.ToOutletId);
            foreach (var item in _reqAutoList)
            {
                PhProductInfo _pInfo = this.GetProductById(item.ProductId);

                PhSelectedProductsToSaleOrReceiveOrOrder _selectedP = new PhSelectedProductsToSaleOrReceiveOrOrder();
                _selectedP.LotNo = item.LotNo;
                _selectedP.Id = selectedItem.ProductId;
            
                _selectedP.Name = selectedItem.BrandName;

                _selectedP.SRate = selectedItem.SalePrice;
                _selectedP.BatchNo = item.BatchNo;
                _selectedP.ExpireDate = item.ExpireDate;
                _selectedP.OutLetId = item.OutletId;
                _selectedP.Qty = item.Qty;
              
                _selectedP.Total = item.Qty * selectedItem.SalePrice;

                _selectedP.PRate = _pInfo.PurchasePrice;

                _selectedPList.Add(_selectedP);
            }

            return _selectedPList;
        }

        public List<VMPhSoldItem> GetPhIPDSoldItems(long admissionId)
        {
            return new PhProductRepository().GetPhIPDSoldItems(admissionId);
        }

        private List<VMPhRequisitionAutomation> GetReuisitionAutoList(int productId,double _requestedQty,int outLetId)
        {
            List<VMPhRequisitionAutomation> _reqAutoList = new PhProductRepository().GetAvailablePhStockByBatchAndExpireDate(productId, outLetId); // Retrieve StockList by BatchNo and ExpireDate
            _reqAutoList = _reqAutoList.OrderBy(x => x.ExpireDate).ToList();

            double _temReqQty = _requestedQty;
            List<VMPhRequisitionAutomation> _reqAuto = new List<VMPhRequisitionAutomation>();
            foreach(var item in _reqAutoList)
            {
                VMPhRequisitionAutomation _req = new VMPhRequisitionAutomation();
                if (_temReqQty>0 && _temReqQty >= item.Qty)
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
                else if(_temReqQty > 0 && _temReqQty <= item.Qty)
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

        public async Task<bool> SetOpeningStock(DateTime _date)
        {
            return await new PhProductRepository().SetOpeningStock(_date);
        }

        public void UpdatePurchaseAndSalerate(VWPhProductList vWPhProductList, double _prate, double _sRate)
        {
            new PhProductRepository().UpdatePurchaseAndSalerate(vWPhProductList, _prate, _sRate);
        }

        public void UpdaMedicineRequisition(HpMedicineRequisition _requisition)
        {
            new PhProductRepository().UpdaMedicineRequisition(_requisition);
        }

        public void CancelMedicineRequisition(long _requisition)
        {
            new PhProductRepository().CancelMedicineRequisition(_requisition);
        }

        public HpMedicineReturnInednt GetReturnIndentById(long __retIndentNo)
        {
            return new PhProductRepository().GetReturnIndentById(__retIndentNo);
        }

        public void UpdatePhRefundedInvoiceDetail(long invoiceId, int _productId, long _lotNo, double qty)
        {
            PhInvoiceDetail _pInvd = new PhProductRepository().GetPhInvoiceDetail(invoiceId, _lotNo, _productId);
            if (_pInvd != null)
            {
                _pInvd.RetQty = qty;
                new PhProductRepository().UpdatePhRefundedInvoiceDetail(_pInvd);
            }
        }

        public string CheckStockAvailability(List<PhInvoiceDetail> invDetails, VMPhEndpointDataCarrier voucherObj)
        {
            return new PhProductRepository().CheckStockAvailability(invDetails,voucherObj);
        }

        public List<VMReturnRequestList> GetHpMedicineReturnDetail(long _retIndentId)
        {
            return new PhProductRepository().GetHpMedicineReturnDetail(_retIndentId);
        }

        public void PopulateSelectedItemDataForReceiceveAgainstReturn(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VMReturnRequestList selectedItem)
        {
            if (selectedItem!=null)
            {
                _SelectedItems.Add(GetPreparedSelectedItemDataForReceiveAgainstReturn(selectedItem));
            }
            else // TODO : implement if stock required to adjust from multiple batchno and expire date
            {

            }
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemDataForReceiveAgainstReturn(VMReturnRequestList selectedItem)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            PhLotInfo _plot = new PhProductService().GetPhLotInfoByLotNo(selectedItem.LotNo);
            _PhSelectedItem.Id = selectedItem.ProductId;
            _PhSelectedItem.BarCode = "";
            _PhSelectedItem.Code = selectedItem.ProductCode;
            _PhSelectedItem.BatchNo = _plot.BatchNo;
            _PhSelectedItem.ExpireDate = _plot.ExpireDate;
            _PhSelectedItem.LotNo = selectedItem.LotNo;
            _PhSelectedItem.OutLetId = selectedItem.OutLetId;
            _PhSelectedItem.Name = selectedItem.BrandName;
            _PhSelectedItem.Unit = selectedItem.Unit;
            _PhSelectedItem.Qty = selectedItem.RetQty;
            _PhSelectedItem.SRate = selectedItem.SalePrice;
            _PhSelectedItem.Total = selectedItem.TotalPrice;
            _PhSelectedItem.DiscInPercentPerProduct = 0;
            _PhSelectedItem.Discount = 0;
            _PhSelectedItem.Gtotal = 0;
             return _PhSelectedItem;
        }

        private PhLotInfo GetPhLotInfoByLotNo(long lotNo)
        {
            return new PhProductRepository().GetPhLotInfoByLotNo(lotNo);
        }

        public List<VMIssuedProductAgainstRequisition> GetIssuedProductAgainstRequisition(long invoiceId)
        {
            return new PhProductRepository().GetIssuedProductAgainstRequisition(invoiceId);
        }

        public void UpdateStockOnSale(List<PhInvoiceDetail> _invDetailsList, int outLetId)
        {
            new PhProductRepository().UpdateStockOnSale(_invDetailsList, outLetId);

        }

        public PhInvoice GetPhInvoiceByRequistionNo(long requisitionId)
        {
          return  new PhProductRepository().GetPhInvoiceByRequistionNo(requisitionId);
        }

        public void CancelMedicineReturnId(long _retId)
        {
            new PhProductRepository().CancelMedicineReturnId(_retId);
        }

        public List<PhInvoiceDetail> GetServedProductListAgainstRequisition(long requisitionId)
        {
            return new PhProductRepository().GetServedProductListAgainstRequisition(requisitionId);
        }

        public HpMedicineRequisitionDetail GetHpMedicineRequisitionDetail(long requisitionId, int productId)
        {
            return new PhProductRepository().GetHpMedicineRequisitionDetail(requisitionId, productId);
        }

        public void UpdateHpMedicineRequisitionDetail(HpMedicineRequisitionDetail _reqDetail)
        {
            new PhProductRepository().UpdateHpMedicineRequisitionDetail(_reqDetail);
        }

        public void PopulateSelectedItemDataForSaleAgainstRequisitionFromNS(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, VMRequisitionList selectedItem)
        {
            List<PhSelectedProductsToSaleOrReceiveOrOrder> _pList = GetPreparedSelectedItemDataForSaleAgainstRequisitionNS(selectedItem); //NS: Nurse Station Requisition

            foreach (var item in _pList)
            {
                _SelectedItems.Add(item);
            }
        }

        private List<PhSelectedProductsToSaleOrReceiveOrOrder> GetPreparedSelectedItemDataForSaleAgainstRequisitionNS(VMRequisitionList selectedItem)
        {
            double stckQty = 0;
            List<PhSelectedProductsToSaleOrReceiveOrOrder> _selectedPList = new List<PhSelectedProductsToSaleOrReceiveOrOrder>();
            List<VMPhRequisitionAutomation> _reqAutoList = this.GetReuisitionAutoList(selectedItem.ProductId, selectedItem.ReqQty, selectedItem.OutLetId);
            foreach (var item in _reqAutoList)
            {
                PhProductInfo _pInfo = this.GetProductById(item.ProductId);

                PhSelectedProductsToSaleOrReceiveOrOrder _selectedP = new PhSelectedProductsToSaleOrReceiveOrOrder();
                _selectedP.LotNo = item.LotNo;
                _selectedP.Id = selectedItem.ProductId;

                _selectedP.Name = selectedItem.BrandName;

                _selectedP.SRate = selectedItem.SalePrice;
                _selectedP.BatchNo = item.BatchNo;
                _selectedP.ExpireDate = item.ExpireDate;
                _selectedP.OutLetId = item.OutletId;
                _selectedP.Qty = item.Qty;

                _selectedP.Total = item.Qty * selectedItem.SalePrice;

                _selectedP.PRate = _pInfo.PurchasePrice;

                _selectedPList.Add(_selectedP);
            }

            return _selectedPList;
        }

        public PhInvoice GetPhOPDLastestInvoice()
        {
            return new PhProductRepository().GetPhOPDLastestInvoice();
        }
    }
}
