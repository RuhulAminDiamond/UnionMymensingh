using Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data.Entity;
using HDMS.Model.Accounting;

namespace HDMS.Repository.Accounting
{
    public class VoucherRepository
    {
        SqlDataAdapter da;
        DataSet ds;
        string sql = string.Empty;
        public long AddNewMasterVoucher(Voucher masterVoucher)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Vouchers.Add(masterVoucher);
                    entities.SaveChanges();
                    return masterVoucher.VMId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public long AddOrEditDetailsVoucher(VoucherDetail detailsVoucher)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    VoucherDetail _vd = entities.VoucherDetails.Where(x => x.VMId == detailsVoucher.VMId && x.AccId == detailsVoucher.AccId).FirstOrDefault();

                    if (_vd == null)
                    {
                        entities.VoucherDetails.Add(detailsVoucher);
                        entities.SaveChanges();

                        return detailsVoucher.Id;
                    }
                    else
                    {
                        _vd.Amount = detailsVoucher.Amount;
                        _vd.reamrks = detailsVoucher.reamrks;
                        entities.Entry(_vd).State = EntityState.Modified;
                        entities.SaveChanges();

                        return _vd.Id;

                    }



                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public long AddNewDetailsVoucher(VoucherDetail detailsVoucher)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.VoucherDetails.Add(detailsVoucher);
                    entities.SaveChanges();
                    return detailsVoucher.Id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }

        public bool UpdateMasterVoucher(Voucher _voucher)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_voucher).State=EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool SaveAutoImportLog(AccountsAutoImportLog importLog)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.AccountsAutoImportLogs.Add(importLog);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CheckIsAlreadyImported(DateTime datefrm, DateTime dateto)
        {
            using (DBEntities entities = new DBEntities())
            {

                AccountsAutoImportLog log = entities.AccountsAutoImportLogs.Where(x => x.FromDate == datefrm.Date || x.ToDate == dateto.Date).FirstOrDefault();

                if (log != null) return true;

                return false;
            }
        }

        public DataSet GetReceiptOrCreditVoucher(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[SpGetReceiptOrCreditVoucher] {0},'{1}'", vMId, "");

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtVoucher");
                return ds;
            }
        }

        public DataSet GetPaymentOrDebitVoucher(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Exec [dbo].[SpGetPaymentOrDebitVoucher] {0},'{1}'", vMId,"");

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtVoucher");
                return ds;
            }
        }
    }
}
