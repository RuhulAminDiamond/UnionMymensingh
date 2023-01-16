using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HDMS.Models.Pharmacy;
using System.Data.Entity;
using System.Linq;

namespace HDMS.Repositories.Pharmacy
{
    public class PhReportingRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        public DataSet GetOrderedItemDataSetByOrderId(long _OrderId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT        dbo.PhOrders.OrderNo, dbo.PhOrders.OrderDate, dbo.Manufacturers.Name AS OrderTo, dbo.PhProductInfoes.ProductId, f.ShortFormation + ' ' + dbo.PhProductInfoes.BrandName as BrandName,IsNull(dbo.PhProductInfoes.Unit,'N/A') as Unit, dbo.PhOrderDetails.Qty, dbo.PhOrders.OrderId, 
                              dbo.[User].LoginName AS OrderBy
                              FROM  dbo.PhOrderDetails INNER JOIN
                              dbo.PhProductInfoes ON dbo.PhOrderDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
                              dbo.PhOrders ON dbo.PhOrderDetails.OrderId = dbo.PhOrders.OrderId INNER JOIN
                              dbo.Manufacturers ON dbo.PhOrders.OrderTo = dbo.Manufacturers.ManufacturerId INNER JOIN
							  Formations f on dbo.PhProductInfoes.FormationId=f.FormationId INNER JOIN
                              dbo.[User] ON dbo.PhOrders.OrderGenerateBy = dbo.[User].UserId Where dbo.PhOrders.OrderId = {0}", _OrderId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtOrder");
                return ds;
            }
        }

        public DataSet GetPhProfitAndLoss(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"exec spGetPhProfitAndLoss  '{0}' , '{1}'", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtPhProfitAndLoss");
                return dsSale;
            }
        }

        public DataSet GetMedicineDetailsByPatientId(long _admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT  dbo.HospitalPatientInfoes.AdmissionId, dbo.HospitalPatientInfoes.BillNo AS HospitalBillNo, dbo.PhInvoices.InvoiceId, dbo.PhInvoices.BillNo AS PhBillNo, dbo.PhInvoiceDetails.ProductId, dbo.PhProductInfoes.BrandName, 
                                      dbo.PhInvoiceDetails.Qty, dbo.PhInvoiceDetails.SaleRate, dbo.PhInvoiceDetails.LotNo, dbo.PhInvoiceDetails.TotalPrice, 
                                      CASE WHEN dbo.PhInvoices.InvoiceType = 'IS' THEN 'Sale' ELSE 'Return' END AS InvoiceType, dbo.HospitalPatientInfoes.RegNo, dbo.RegRecords.FullName, dbo.RegRecords.Sex, 
                                      CASE WHEN dbo.HospitalPatientInfoes.AgeYear <> '' THEN dbo.HospitalPatientInfoes.AgeYear + 'Y ' ELSE dbo.HospitalPatientInfoes.AgeYear END + CASE WHEN dbo.HospitalPatientInfoes.AgeMonth <> '' THEN dbo.HospitalPatientInfoes.AgeMonth
                                      + 'M ' ELSE dbo.HospitalPatientInfoes.AgeMonth END + CASE WHEN dbo.HospitalPatientInfoes.AgeDay <> '' THEN dbo.HospitalPatientInfoes.AgeDay + 'D' ELSE dbo.HospitalPatientInfoes.AgeDay END AS Age, 
                                      dbo.HospitalPatientInfoes.AddmissionDate, dbo.Doctor.Name AS AssignDoc, Doctor_1.Name AS RefdDoc,dbo.PhInvoices.Invdate 

                                      FROM  dbo.Doctor INNER JOIN
                                      dbo.HospitalPatientInfoes INNER JOIN
                                      dbo.PhInvoices ON dbo.HospitalPatientInfoes.BillNo = dbo.PhInvoices.AdmissionNo INNER JOIN
                                      dbo.PhInvoiceDetails ON dbo.PhInvoices.InvoiceId = dbo.PhInvoiceDetails.InvoiceId INNER JOIN
                                      dbo.PhProductInfoes ON dbo.PhInvoiceDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
                                      dbo.RegRecords ON dbo.HospitalPatientInfoes.RegNo = dbo.RegRecords.RegNo ON dbo.Doctor.DoctorId = dbo.HospitalPatientInfoes.AssignDoctorId INNER JOIN
                                      dbo.Doctor AS Doctor_1 ON dbo.HospitalPatientInfoes.RefdDoctorId = Doctor_1.DoctorId
                                      Where dbo.HospitalPatientInfoes.AdmissionId={0} order by dbo.PhInvoices.Invdate,dbo.PhInvoices.BillNo", _admissionId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtIndoorMedicineDetailByPatient");
                return ds;
            }
        }

        public DataSet GetPhDeptWiseIPDaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion, int _deptId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string _invType = string.Empty;


                _invType = "IS";


                sql = string.Format(@"exec spGetPhDeptWiseIPDSaleStatement  '{0}' , '{1}','{2}','{3}',{4} ", dtpfrm, dtpto, _user, _invType, _deptId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtSaleStatement");
                return dsSale;
            }
        }

        public DataSet GetPhIPDaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOption)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string _invType = string.Empty;


                _invType = "IS";


                sql = string.Format(@"exec spGetPhIPDSaleStatement  '{0}' , '{1}','{2}','{3}' ", dtpfrm, dtpto, _user, _invType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtSaleStatement");
                return dsSale;
            }
        }

        public DataSet GetPhOPDSaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOPtion)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string _invType = string.Empty;


                _invType = "GC";


                sql = string.Format(@"exec spGetPhOPDSaleStatement  '{0}' , '{1}','{2}','{3}' ", dtpfrm, dtpto, _user, _invType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtSaleStatement");
                return dsSale;
            }
        }

        public DataSet GetSaleEntryDataSetByReturnReceiveId(long _ReceiveId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                //sql = string.Format(@"SELECT dbo.PhReceives.ReceiveId, dbo.PhReceives.OPDReturnInvoice, dbo.PhReceives.TotalTk, dbo.PhReceives.ReceiveType,dbo.PhReceives.Receivedby as UserName, dbo.PhReceiveDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhReceiveDetails.Qty, 
                //                      dbo.PhProductInfoes.SalePrice as SaleRate, dbo.PhProductInfoes.SalePrice*dbo.PhReceiveDetails.Qty as TotalPrice, dbo.PhReceives.RDate,dbo.PhInvoices.BillNo,CONVERT(VARCHAR(50), dbo.PhInvoices.BillNo) AS BillNoString 
                //                      FROM  dbo.PhReceives INNER JOIN dbo.PhReceiveDetails ON dbo.PhReceives.ReceiveId = dbo.PhReceiveDetails.ReceivedId INNER JOIN
                //                      dbo.PhProductInfoes ON dbo.PhReceiveDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
                //                      dbo.PhInvoices ON dbo.PhReceives.OPDReturnInvoice = dbo.PhInvoices.InvoiceId Where dbo.PhReceives.ReceiveId={0}", _ReceiveId);
                sql = string.Format(@"SELECT dbo.PhReceives.ReceiveId, dbo.PhReceives.RDate as Invdate, dbo.PhReceives.OPDReturnInvoice, dbo.PhReceives.TotalTk, dbo.PhReceives.ReceiveType,dbo.PhReceives.Receivedby as UserName, dbo.PhReceiveDetails.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhReceiveDetails.Qty, 
                                      dbo.PhProductInfoes.SalePrice as SaleRate, dbo.PhProductInfoes.SalePrice*dbo.PhReceiveDetails.Qty as TotalPrice, dbo.PhReceives.RDate,dbo.PhInvoices.BillNo,CONVERT(VARCHAR(50), dbo.PhInvoices.BillNo) AS BillNoString 
                                      FROM  dbo.PhReceives INNER JOIN dbo.PhReceiveDetails ON dbo.PhReceives.ReceiveId = dbo.PhReceiveDetails.ReceivedId INNER JOIN
                                      dbo.PhProductInfoes ON dbo.PhReceiveDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
                                      dbo.PhInvoices ON dbo.PhReceives.OPDReturnInvoice = dbo.PhInvoices.InvoiceId Where dbo.PhReceives.ReceiveId={0}", _ReceiveId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtsale");
                return ds;
            }
        }

        public DataSet GetPhSaleSummaryStatement(DateTime dtfrm, DateTime dtto, string _reportOPtion, int _outletId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string _invType = string.Empty;

                if (_reportOPtion.ToLower() == "ipd")
                {
                    _invType = "IS";
                }
                else
                {
                    _invType = "GC";
                }

                sql = string.Format(@"exec spGetPhSaleSummary  '{0}' , '{1}','{2}',{3}", dtfrm, dtto, _invType, _outletId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtPhSaleSummary");
                return dsSale;
            }
        }

        public DataSet GetIndoorToOTInvoiceDataByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"exec GetIndoorToOTInvoiceDataByinvocieId  {0}", invocieId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtIndoorInvoice");
                return dsSale;
            }
        }

        public DataSet GetIndoorOTInvoiceDataByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"exec GetIndoorOTInvoceData  {0}", invocieId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtIndoorInvoice");
                return dsSale;
            }
        }

        public DataSet GetIndoorInvoiceDataByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"exec GetIndoorInvoceData  {0}", invocieId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtIndoorInvoice");
                return dsSale;
            }
        }


        public DataSet GetProductList(int _manufId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (_manufId == 0)
                {
                    sql = string.Format(@"SELECT dbo.PhProductInfoes.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhStockInfoes.CurrentStock AS SoftwareStock
                                          FROM  dbo.PhProductInfoes INNER JOIN
                                          dbo.PhStockInfoes ON dbo.PhProductInfoes.ProductId = dbo.PhStockInfoes.ProductId order by dbo.PhProductInfoes.GenericId");

                }else
                {
                    sql = string.Format(@"SELECT  dbo.PhProductInfoes.ProductId, dbo.PhProductInfoes.BrandName, dbo.PhStockInfoes.CurrentStock AS SoftwareStock
                                          FROM   dbo.PhProductInfoes INNER JOIN
                                          dbo.PhStockInfoes ON dbo.PhProductInfoes.ProductId = dbo.PhStockInfoes.ProductId Where dbo.PhProductInfoes.ManufacturerId={0} order by dbo.PhProductInfoes.GenericId", _manufId);
                }
                
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtProductList");
                return ds;
            }
        }

        public DataSet GetPhSaleStatement(DateTime dtpfrm, DateTime dtpto, string _user, string _reportOption)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string _invType = string.Empty;

                if (_reportOption.ToLower() == "ipd")
                {
                    _invType = "IS";
                }
                else
                {
                    _invType = "GC";
                }

                sql = string.Format(@"exec spGetPhSaleStatement  '{0}' , '{1}','{2}','{3}' ", dtpfrm, dtpto, _user, _invType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsSale = new DataSet();
                da.Fill(dsSale, "dtSaleStatement");
                return dsSale;
            }
        }

        public PhInvoice GetPhInvoiceById(long invocieId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhInvoices.Where(x => x.InvoiceId == invocieId).FirstOrDefault();
            }
        }

        public DataSet GetSaleEntryDataSetByinvocieId(long invocieId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.PhInvoices.BillNo,dbo.PhInvoices.InvoiceId, CONVERT(VARCHAR(50), dbo.PhInvoices.BillNo) AS BillNoString, dbo.PhInvoices.AdmissionNo, dbo.PhInvoices.InvoiceType, dbo.PhInvoices.Invdate, dbo.PhInvoices.InvTime, dbo.PhInvoices.DiscountTK, 
                                      dbo.PhInvoices.TotalTK, f.ShortFormation+' '+dbo.PhProductInfoes.BrandName as BrandName, dbo.PhInvoiceDetails.Qty, dbo.PhInvoiceDetails.SaleRate, dbo.PhInvoiceDetails.TotalPrice, dbo.PhInvoiceDetails.Discount, dbo.PhInvoices.GrandTK, 
                                      dbo.PhInvoices.ReceivedTK, dbo.PhInvoices.ChangeTK, dbo.PhInvoices.DueTK, dbo.[User].LoginName AS UserName
                                      FROM  dbo.PhInvoiceDetails INNER JOIN
                                      dbo.PhInvoices ON dbo.PhInvoiceDetails.InvoiceId = dbo.PhInvoices.InvoiceId INNER JOIN
                                      dbo.PhProductInfoes ON dbo.PhInvoiceDetails.ProductId = dbo.PhProductInfoes.ProductId INNER JOIN
									  Formations f on dbo.PhProductInfoes.FormationId=f.FormationId INNER JOIN
                                      dbo.[User] ON dbo.PhInvoices.UserId = dbo.[User].UserId Where dbo.PhInvoices.InvoiceId={0}", invocieId);
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtsale");
                return ds;
            }
        }


       
    }
}
