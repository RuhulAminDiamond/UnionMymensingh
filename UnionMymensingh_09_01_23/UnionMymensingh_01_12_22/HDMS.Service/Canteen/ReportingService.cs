using Repositories.POS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Canteen;
using Models.Store;

namespace Services.POS
{
    public class ReportingService
    {
        public DataSet GetSaleDataByinvocieId(long invocieId)
        {
            return new ReportingRepository().GetSaleDataByinvocieId(invocieId);
        }

        public CantInvoice GetInvoiceById(long invocieId)
        {
            return new ReportingRepository().GetInvoiceById(invocieId);
        }

        public DataSet GetSaleStatement(DateTime fromdate, DateTime todate, string _userName)
        {
            return new ReportingRepository().GetSaleStatement(fromdate, todate, _userName);
        }

        public DataSet GetPharmacyDailyTransectionReport(DateTime dtpFrom, DateTime dtpTo)
        {
            return new ReportingRepository().GetPharmacyDailyTransectionReport(dtpFrom, dtpTo);
        }

        public DataSet GetStockStatement(DateTime dtpfrm, DateTime dtpto, string _rptOption)
        {
            return new ReportingRepository().GetStockStatement(dtpfrm, dtpto, _rptOption);
        }

        public DataSet GetOPDSaleDueList(DateTime fromdate, DateTime todate)
        {
            return new ReportingRepository().GetOPDSaleDueList(fromdate, todate);
        }

        public List<CantInvoiceDetail> GetInvoiceDetails(long _InvoiceId)
        {
            return new ReportingRepository().GetInvoiceDetails(_InvoiceId);
        }

        public DataSet GetPhOPDDueList(DateTime fromdate, DateTime todate)
        {
            return new ReportingRepository().GetPhOPDDueList(fromdate, todate);
        }

        public DataSet GetStoreIssueStatement(DateTime dtpfrm, DateTime dtpto, int depId)
        {
            return new ReportingRepository().GetStoreIssueStatement(dtpfrm, dtpto, depId);
        }

        public DataSet GetDueCollectionList(DateTime fromdate, DateTime todate)
        {
            return new ReportingRepository().GetDueCollectionList(fromdate, todate);
        }

        public DataSet GetDueList(DateTime fromdate, DateTime todate)
        {
            return new ReportingRepository().GetDueList(fromdate, todate);
        }

        public void UpdateInvoiceDetails(List<CantInvoiceDetail> _invdetailList)
        {
            new ReportingRepository().UpdateInvoiceDetails(_invdetailList);
        }

        public DataSet GetCanteenSaleStatement(DateTime fromdate, DateTime todate, string _userName)
        {
           return  new ReportingRepository().GetCanteenSaleStatement(fromdate, todate, _userName);
        }

        public DataSet GetSTIssueDataByinvocieId(long _InvoiceId)
        {
           return new ReportingRepository().GetSTIssueDataByinvocieId(_InvoiceId);
        }

        public DataSet GetStoreStockStatement(DateTime dtpfrm, DateTime dtpto, string _rptOption)
        {
            return new ReportingRepository().GetStoreStockStatement(dtpfrm, dtpto, _rptOption);
        }

        public DataSet GetCanteenSaleDataByinvocieId(long invocieId)
        {
            return new ReportingRepository().GetCanteenSaleDataByinvocieId(invocieId);
        }

        public StoreInvoice GetStoreInvoiceById(long _InvoiceId)
        {
            return new ReportingRepository().GetStoreInvoiceById(_InvoiceId);
        }

        public DataSet GetDueCollectionByCustomerId(long customerId, DateTime dateTime)
        {
            return new ReportingRepository().GetDueCollectionByCustomerId(customerId, dateTime);
        }
    }
}
