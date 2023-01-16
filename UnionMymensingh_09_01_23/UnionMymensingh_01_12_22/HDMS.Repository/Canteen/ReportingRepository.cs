using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;
using Models.Canteen;
using HDMS.Common.Utils;
using Models.Store;

namespace Repositories.POS
{
    public class ReportingRepository
    {

        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;

        public DataSet GetSaleDataByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.Invoices.InvoiceId, dbo.Invoices.InvoiceNumber as BillNo, Convert(nvarchar(50),dbo.Invoices.InvoiceNumber) as BillNoString, dbo.Invoices.Invdate, dbo.Invoices.TotalTK, dbo.Invoices.DiscountTK, dbo.Invoices.GrandTK, dbo.Invoices.ReceivedTK, dbo.Invoices.DueTK, 
                         dbo.InvoiceDetails.ProductId, dbo.ProductInfoes.Name as ProductName, dbo.InvoiceDetails.SaleRate, dbo.InvoiceDetails.Qty, dbo.InvoiceDetails.TotalPrice
                         FROM   dbo.ProductInfoes INNER JOIN
                         dbo.InvoiceDetails ON dbo.ProductInfoes.Id = dbo.InvoiceDetails.ProductId INNER JOIN
                         dbo.Invoices ON dbo.InvoiceDetails.InvoiceId = dbo.Invoices.InvoiceId Where dbo.Invoices.InvoiceId={0}", invocieId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtsale");
                return ds;
            }
        }


        
        public DataSet GetPharmacyDailyTransectionReport(DateTime dtpFrom, DateTime dtpTo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec SPGetPharmacyDailyTransectionReports '{0}','{1}'", dtpFrom.Date, dtpTo.Date);
                    da = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    da.Fill(ds, "dtOPDSaleDueList");
                    return ds;
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public DataSet GetOPDSaleDueList(DateTime fromdate, DateTime todate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec spGetOPDSaleDueList '{0}','{1}'", fromdate.Date, todate.Date);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtOPDSaleDueList");
                return ds;
            }
        }

        public DataSet GetStoreIssueStatement(DateTime dtpfrm, DateTime dtpto, int depId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[spGetStoreIssueStatement] '{0}','{1}',{2}", dtpfrm.Date, dtpto.Date, depId);


                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtStockReport");
                return ds;
            }

        }

        public DataSet GetDueCollectionList(DateTime fromdate, DateTime todate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.CantMemberLedgers.CustomerId, dbo.CantMemberInfoes.Name, dbo.CantMemberLedgers.Trandate, dbo.CantMemberLedgers.Particulars, dbo.CantMemberLedgers.Credit, dbo.CantMemberLedgers.TransactionType, 
                                     dbo.CantMemberLedgers.OperateBy
                                     FROM dbo.CantMemberLedgers INNER JOIN
                                     dbo.CantMemberInfoes ON dbo.CantMemberLedgers.CustomerId = dbo.CantMemberInfoes.MemberId
                                     WHERE (dbo.CantMemberLedgers.TransactionType = 'PhDueCollection') AND (dbo.CantMemberLedgers.Trandate BETWEEN '{0}' AND '{1}')", fromdate.Date, todate.Date);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtDueCollection");
                return ds;
            }
        }

        /*=====================
         * Print Cash memo OPD Customer Due Collction 
         * 
         * 
         *====================== */
        public DataSet GetDueCollectionByCustomerId(long customerId, DateTime dateTime)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT phml.MemberId AS CustomerId
	,phinfo.Name AS CustomerName
	,phml.OperateBy
	,phml.TranDate As PaymentDate
	,phml.Balance AS Total
	,phml.Credit AS Paid
	,phinfo.MobileNo
FROM PhMemberLedgers AS phml
INNER JOIN PhMemberInfoes AS phinfo ON phinfo.MemberId = phml.MemberId
WHERE phml.MemberId = {0}
	AND Convert(DATE, phml.TranDate) = '{1}' AND phml.TransactionType = 'PhDueCollection'", customerId, dateTime.Date);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtOPDDueCollectionInvoice");
                return ds;
            }
        }

        public DataSet GetDueList(DateTime fromdate, DateTime todate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select T.CustomerId,m.[Name],m.[Address],m.[MobileNo],T.tDue from (
                                      Select [CustomerId],Sum([Debit]-[Credit]) as tDue from [dbo].[CantMemberLedgers] l where l.Trandate between '{0}' and '{1}' group by [CustomerId] ) T join [dbo].[CantMemberInfoes] m on T.CustomerId=m.MemberId
                                      where  T.tDue<>0", fromdate, todate);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtDueList");
                return ds;
            }
        }

        public StoreInvoice GetStoreInvoiceById(long _InvoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.StoreInvoices.Where(x => x.InvoiceId == _InvoiceId).FirstOrDefault();
            }
        }

        public DataSet GetPhOPDDueList(DateTime fromdate, DateTime todate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select T.MemberId,m.[Name],m.[Address],m.[MobileNo],T.tDue from (
                                      Select [MemberId],Sum([Debit]-[Credit]) as tDue from [dbo].[PhMemberLedgers] group by [MemberId]) T join [dbo].[PhMemberInfoes] m on T.MemberId=m.MemberId
                                      where T.tDue<>0");
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtDueList");
                return ds;
            }
        }

        public DataSet GetCanteenSaleStatement(DateTime fromdate, DateTime todate, string _userName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec SPGETCanteenSalesSummery '{0}','{1}','{2}'", fromdate.Date, todate.Date, _userName);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtSaleStatement");
                return ds;
            }
        }

        public DataSet GetSTIssueDataByinvocieId(long _InvoiceId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.StoreInvoices.InvoiceId, dbo.StoreInvoices.InvoiceNumber as BillNo, Convert(nvarchar(50),dbo.StoreInvoices.InvoiceNumber) as BillNoString, dbo.StoreInvoices.Invdate, dbo.StoreInvoices.TotalTK, dbo.StoreInvoices.DiscountTK, dbo.StoreInvoices.GrandTK, dbo.StoreInvoices.ReceivedTK, dbo.StoreInvoices.DueTK, 
                                      dbo.StoreInvoiceDetails.ProductId, dbo.StoreProductInfoes.Name as ProductName, dbo.StoreInvoiceDetails.SaleRate, dbo.StoreInvoiceDetails.Qty, dbo.StoreInvoiceDetails.TotalPrice
                                      FROM dbo.StoreProductInfoes INNER JOIN
                                      dbo.StoreInvoiceDetails ON dbo.StoreProductInfoes.ProductId = dbo.StoreInvoiceDetails.ProductId INNER JOIN
                                      dbo.StoreInvoices ON dbo.StoreInvoiceDetails.InvoiceId = dbo.StoreInvoices.InvoiceId Where dbo.StoreInvoices.InvoiceId={0}", _InvoiceId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtsale");
                return ds;
            }
        }

        public DataSet GetCanteenSaleDataByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.CantInvoices.InvoiceId, dbo.CantInvoices.InvoiceNumber as BillNo, Convert(nvarchar(50),dbo.CantInvoices.InvoiceNumber) as BillNoString, dbo.CantInvoices.Invdate, dbo.CantInvoices.TotalTK, dbo.CantInvoices.DiscountTK, dbo.CantInvoices.GrandTK, dbo.CantInvoices.ReceivedTK, dbo.CantInvoices.DueTK, 
                         dbo.CantInvoiceDetails.ProductId, dbo.CantProductInfoes.Name as ProductName, dbo.CantInvoiceDetails.SaleRate, dbo.CantInvoiceDetails.Qty, dbo.CantInvoiceDetails.TotalPrice
                         FROM   dbo.CantProductInfoes INNER JOIN
                         dbo.CantInvoiceDetails ON dbo.CantProductInfoes.Id = dbo.CantInvoiceDetails.ProductId INNER JOIN
                         dbo.CantInvoices ON dbo.CantInvoiceDetails.InvoiceId = dbo.CantInvoices.InvoiceId Where dbo.CantInvoices.InvoiceId={0}", invocieId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtsale");
                return ds;
            }
        }

        public DataSet GetStoreStockStatement(DateTime dtpfrm, DateTime dtpto, string _rptOption)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (_rptOption == "All")
                {
                    sql = string.Format(@"Exec spGetStoreStockByDate '{0}','{1}',''", dtpfrm.Date, dtpto.Date);

                }
                else
                {
                    sql = string.Format(@"Exec [dbo].[spGetStoreStockByDateOnlyValued] '{0}','{1}',''", dtpfrm.Date, dtpto.Date);
                }

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtStockReport");
                return ds;
            }
        }

      
      
        public void UpdateInvoiceDetails(List<CantInvoiceDetail> _invdetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (CantInvoiceDetail _invd in _invdetailList)
                {
                    entities.Entry(_invd).State = EntityState.Modified;
                    entities.SaveChanges();
                }


            }
        }

        public List<CantInvoiceDetail> GetInvoiceDetails(long _InvoiceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CantInvoiceDetails.Where(x => x.InvoiceId == _InvoiceId).ToList();
            }
        }

        public DataSet GetStockStatement(DateTime dtpfrm, DateTime dtpto, string _rptOption)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (_rptOption == "All")
                {
                    sql = string.Format(@"Exec spGetCanteenStockByDate '{0}','{1}',''", dtpfrm.Date, dtpto.Date);

                }else
                {
                    sql = string.Format(@"Exec [dbo].[spGetCanteenStockByDateOnlyValued] '{0}','{1}',''", dtpfrm.Date, dtpto.Date);
                }

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtStockReport");
                return ds;
            }
        }

        public DataSet GetSaleStatement(DateTime fromdate, DateTime todate,string _userName)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec SPGETSalesSummery '{0}','{1}','{2}'", fromdate.Date, todate.Date, _userName);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtSaleStatement");
                return ds;
            }
        }

        public CantInvoice GetInvoiceById(long invocieId)
        {
            using(DBEntities entities= new DBEntities())
            {
                return entities.CantInvoices.Where(x => x.InvoiceId == invocieId).FirstOrDefault();
            }
        }
    }
}
