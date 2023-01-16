using Models;
using Models.ViewModel;
using Repositories.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Canteen;
using HDMS.Model;
using HDMS.Models.Pharmacy;
using HDMS.Model.Common;
using HDMS.Model.Store;

namespace Services.POS
{
    public class CantItemService
    {
        public List<CantGroup> GetAllGroups()
        {
            return new CantItemRepository().GetAllGroups();
        }

        public bool AddNewProduct(CantProductInfo _pInfo)
        {
            return new CantItemRepository().AddNewProduct(_pInfo);
        }

        public IList<CantGroup> GetAllCategory()
        {
            return new CantItemRepository().GetAllCategory();
        }

        public IList<CantProductInfo> GetAllProduct()
        {
            return new CantItemRepository().GetAllProduct();
        }

        public CantProductInfo GetProductById(int pId)
        {
            return new CantItemRepository().GetProductById(pId);
        }

        public bool UpdateProductInfo(CantProductInfo _P)
        {
            return new CantItemRepository().UpdateProductInfo(_P);
        }

        public CantProductInfo GetProductByCode(string pCode)
        {
            return new CantItemRepository().GetProductByCode(pCode); 
        }

        public void PopulateSelectedItemData(IList<CantSelectedProductsToSaleOrReceive> _SelectedItems, CantProductInfo productInfo, double _rate, double qty)
        {
            int ItemId;
            ItemId = productInfo.Id;
            if (productInfo == null) return;
            if (_SelectedItems.Any(x => x.Id == ItemId)) return;

            _SelectedItems.Add(GetPreparedSelectedItemObject(productInfo, _rate, qty));
        }

        public IList<OrderSource> GetAllSource()
        {
            return new CantItemRepository().GetAllSource();
        }

        public IList<CantVWItemInfo> GetBasicItemInfoList(string name, string _type)
        {
            return new CantItemRepository().GetBasicItemInfoList(name, _type);
        }

        private CantSelectedProductsToSaleOrReceive GetPreparedSelectedItemObject(CantProductInfo productInfo, double _rate, double qty)
        {
            CantSelectedProductsToSaleOrReceive _sItem = new CantSelectedProductsToSaleOrReceive();
            _sItem.Id = productInfo.Id;
            _sItem.Code = productInfo.ProductCode;
            _sItem.Name = productInfo.Name;
            _sItem.Qty = qty;
            _sItem.Unit = productInfo.Unit;
            _sItem.Rate = _rate;
            _sItem.Total = _rate*qty;

            return _sItem;

        }


        public long AddNewInvoice(CantInvoice _invoice)
        {
            
                return new CantItemRepository().AddNewInvoices(_invoice);
           
        }

        public bool AddNewInvDetails(List<CantInvoiceDetail> _invDetailsList)
        {
           
                return new CantItemRepository().AddNewInvDetails(_invDetailsList);
           
        }



        public long SaveReceivedInvoice(CantReceive _receive)
        {
            return new CantItemRepository().SaveReceivedInvoice(_receive);
        }

        public bool SaveReceiveDetails(List<CantReceiveDetail> _rDeatailsList)
        {
            return new CantItemRepository().SaveReceiveDetails(_rDeatailsList);
        }

        public double GetCurrentStockByProductId(int pId)
        {
            return new CantItemRepository().GetCurrentStockByProductId(pId);
        }

        public IList<CantMemberInfo> GetAllCustomer()
        {
            return new CantItemRepository().GetAllCustomer();
        }

        public long GetAllInvoiceCount(string shortName)
        {
            return new CantItemRepository().GetAllInvoiceCount();
        }

        // Add code on 2018-03-24
        // For CR : Invoice and Challan No Auto Generate
        public int GetAllReceivedCount(string shortName)
        {
            return new CantItemRepository().GetAllReceivedCount(shortName);
        }

        public IList<PhCompany> GetAllCompany()
        {
            return null; ;
        }


        public bool AddGroup(CantGroup _group)
        {
            return new CantItemRepository().AddGroup(_group);
        }

        public IList<CantInvoiceDetail> GetInvoiceDetails(Int64 _InvoiceNo)
        {
            return new CantItemRepository().GetInvoiceDetails(_InvoiceNo);
        }

        public CantInvoice GetInvoiceByInvoiceNo(Int64 _InvoiceNo)
        {
            return new CantItemRepository().GetInvoiceByInvoiceNo(_InvoiceNo);
        }

        public void UpdateInvoice(CantInvoice _Invoice)
        {
             new CantItemRepository().UpdateInvoice(_Invoice);
        }

        public CantReceive GetReceiveInvoiceInfo(int _receiveId)
        {
            return new CantItemRepository().GetReceiveInvoiceInfo(_receiveId);
        }

        public List<CantReceiveDetail> GetReceiveDetails(long _receiveId)
        {
            return new CantItemRepository().GetReceiveDetails(_receiveId);
        }

    

        public CantInvoice GetInvoiceByInvoiceNumber(long _InvoiceNumber)
        {
            return new CantItemRepository().GetInvoiceByInvoiceNumber(_InvoiceNumber);
        }

        public List<CantSelectedProductsToSaleOrReceive> GetSoldItems(long invoiceId)
        {
            List<CantInvoiceDetail> invDetails = new CantItemRepository().GetSoldItems(invoiceId);
            List<CantSelectedProductsToSaleOrReceive> srList = new List<CantSelectedProductsToSaleOrReceive>();
            foreach (var item in invDetails)
            {
                CantProductInfo _pInfo = new CantItemService().GetProductById(item.ProductId);
                CantSelectedProductsToSaleOrReceive _sItem = new CantSelectedProductsToSaleOrReceive();
                _sItem.Id = item.ProductId;
                _sItem.Code = _pInfo.ProductCode;
                _sItem.Name = _pInfo.Name;
                _sItem.Qty = item.Qty;
                _sItem.Unit = _pInfo.Unit;
                _sItem.Rate = item.SaleRate;
                _sItem.Total = item.SaleRate * item.Qty;

                srList.Add(_sItem);
            }

            return srList;
        }

        public void DeleteExistingLedger(long _InvoiceId)
        {
            new CantItemRepository().DeleteExistingLedger(_InvoiceId);
        }

        public void DeleteInvoiceItem(long _InvoiceId, int  ProdId)
        {
            new CantItemRepository().DeleteInvoiceItem(_InvoiceId, ProdId);
        }

        public OrderSource GetOrderSourceById(int orderFrom)
        {
            return new CantItemRepository().GetOrderSourceById(orderFrom);
        }
    }
}
