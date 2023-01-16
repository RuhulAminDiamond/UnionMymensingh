using HDMS.Model;
using Models;
using Models.Accounting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using HDMS.Model.ViewModel;
using HDMS.Common.Utils;
using HDMS.Model.Accounting;
using System.Data.Entity;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.Users;

namespace HDMS.Repository.Accounting
{
    public class AccountRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        string sql = string.Empty;


        public bool AddNewAccountHead(AccountHead _sInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.AccountHeads.Add(_sInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }


        public bool UpdateAccountHead(AccountHead _sInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_sInfo).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }
        }

        public List<User> GetAccountsUsers()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Users.Where(x => x.RoleId == 10).ToList();
            }
        }

        public DataSet GetProfitAndLossSummary(DateTime dtpfrm, DateTime dtpto, DateTime dtpprevfrm, DateTime dtpprevto, int _statementType)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Summery_Profit_Loss] '{0}','{1}','{2}','{3}','{4}','4' ", dtpfrm, dtpto, dtpprevfrm, dtpprevto, _statementType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtProfitAndLoss");
                return dsLed;
            }
        }

        public DataSet GetGFLedger(DateTime fromdate, DateTime todate, int accId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_GORABA_Ledger_Book] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }

        public DataSet GetBKDLedger(DateTime fromdate, DateTime todate, int accId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_BKD_Ledger_Book] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }

        public void AccumulateBalance(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec [dbo].[spSetBalanceOnDeptAccountGroupMapping] '{0}','{1}'", dtpfrm, dtpto);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                }
            }
        }

        public DataSet GetBalanceSheet(DateTime dtpfrm, DateTime dtpto, DateTime dtpprevfrm, DateTime dtpprevto, int statementType)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Summery_Balance_Sheet] '{0}','{1}','{2}','{3}','{4}'", dtpfrm, dtpto, dtpprevfrm, dtpprevto, statementType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtProfitAndLoss");
                return dsLed;
            }
        }

        public DataSet GetVoucherStatement(DateTime datefrm, DateTime dateto, string voucherType, string drcr, string user)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec  [dbo].[spGetVoucherStatement] '{0}','{1}','{2}','{3}','{4}'", datefrm, dateto, voucherType, drcr, user);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtVoucher");
                return dsLed;
            }
        }

        public DataSet GetReceivePaymentStatement(DateTime fromdate, DateTime todate, DateTime prevfromdate, DateTime prevtodate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Summery_Receive_Payment] '{0}','{1}','{2}','{3}'", fromdate, todate, prevfromdate, prevtodate);
                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtAccCashBook");
                return dsLed;
            }
        }

        public DataSet GetTrialBalanceBasedOnSummaryHead(DateTime dtfrm, DateTime dtto, int IswithOpening)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SPGetTrailBalanceSummeryLedger] '{0}','{1}',{2},{3}", dtfrm, dtto, 0, IswithOpening);
                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtTrialBalance");
                return dsLed;
            }
        }

     
        public IList<VMAccountHeads> GetAllAccountGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMAccountHeads>(@"with CtePostingHeads as (
                Select * from AccountHeads where ParentAccountHeadID>0 and IsPostingHead=0)
                 select ph.*,ah.AccountHeadName as GroupName from CtePostingHeads ph join AccountHeads ah on ph.ParentAccountHeadID=ah.AccId and ah.IsPostingHead='false'").ToList();
            }
        }

        public DataSet GetGFLedgerSummary(DateTime fromdate, DateTime todate, int accId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SpGetGFLedgerSummary] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }

        public DataSet GetAccCashBook(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec  [dbo].[SP_RPT_Cash_Book_DR_CR_Wise] '{0}','{1}',0", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtAccCashBook");
                return dsLed;
            }
        }

        public DataSet GetBKDLedgerSummary(DateTime fromdate, DateTime todate, int accId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SpGetBKdLedgerSummary] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }

        public List<AccOpeningBalance> GetOpeningBalances(int fYId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccOpeningBalances.Where(x => x.FYId == fYId).ToList();
            }
        }

        public FiscalYear GetCurrentFiscalYear()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.FiscalYears.Where(x => x.IsClosed == false).FirstOrDefault();
            }
        }

        public IList<AccountHead> GetAllAccountHead()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.ToList();
            }
        }

        public IList<VMAccountHeads> GetAllPostingAccountHeads()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMAccountHeads>(@"with CtePostingHeads as (
                Select * from AccountHeads where ParentAccountHeadID>0 and IsPostingHead=1)
                 select ph.*,ah.AccountHeadName as GroupName from CtePostingHeads ph join AccountHeads ah on ph.ParentAccountHeadID=ah.AccId").ToList();
            }
        }

        public DataSet GetProfitAndLoss(DateTime dtpfrm, DateTime dtpto, DateTime _prevStartDate, DateTime _prevEndDate, int _statementType)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Summery_Profit_Loss] '{0}','{1}','{2}','{3}','{4}','0' ", dtpfrm, dtpto, _prevStartDate, _prevEndDate, _statementType);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtProfitAndLoss");
                return dsLed;
            }
        }

        public DataSet GetLedgerSummary(DateTime fromdate, DateTime todate, int accountHeadID)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SpGetLedgerSummary] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accountHeadID);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }

        public double GetPrevNetIncome(string _type)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select Sum([PrevDateRangeAmount]) from [dbo].[TempPL] where [Particulars]='{0}'", _type);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    double _cInc = Convert.ToDouble(cmd.ExecuteScalar());
                    return _cInc;

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public double GetCurrentNetIncome(string _type)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select Sum([CurrentDateRangeAmount]) from [dbo].[TempPL] where [Particulars]='{0}'", _type);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    double _cInc = Convert.ToDouble(cmd.ExecuteScalar());
                    return _cInc;

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public long GetLastSHAccCodeShareDivident()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<long>(@"SELECT MAX(AccCode) FROM AccountHeads WHERE ParentAccountHeadID = 2371").FirstOrDefault();
            }
        }

        public long GetLastSHAccCodePaidUpCapital()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<long>(@"SELECT MAX(AccCode) FROM AccountHeads WHERE ParentAccountHeadID = 2372").FirstOrDefault();
            }
        }

        public IList<AccountHead> GetAllAccountHeadRepository()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.ToList();
            }
        }






        public AccountHead GetAllHeadById(int accId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.Where(x => x.AccId == accId).FirstOrDefault();
            }
        }

        public bool UpdateOpeningBalance(AccOpeningBalance opBalance)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(opBalance).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveOpeningBalance(AccOpeningBalance opBalance)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.AccOpeningBalances.Add(opBalance);
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMAccountAutoImportLogs> GetAutoImportLogs(DateTime dtpfrm, DateTime dtpto)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMAccountAutoImportLogs>(@"Select ail.*,V.VMId from AccountsAutoImportLogs ail join Vouchers V on ail.AILogId=V.AILogId 
                  Where ImportDate>=@frmdate and ImportDate<=@todate", new SqlParameter("@frmdate", dtpfrm), new SqlParameter("@todate", dtpto)).ToList();
            }
        }

        public IList<AccountHead> GetAllBaseHead()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.Where(x => x.ParentAccountHeadId == 0).ToList();
            }
        }

        public List<VMAutoImportedPostedVoucherDetail> GetImportedDataDetails(int aILogId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMAutoImportedPostedVoucherDetail>(@"SELECT dbo.Vouchers.AILogId, dbo.VoucherDetails.AccId, dbo.AccountHeads.AccountHeadName, dbo.VoucherDetails.Amount
                         FROM dbo.AccountHeads INNER JOIN
                         dbo.VoucherDetails ON dbo.AccountHeads.AccId = dbo.VoucherDetails.AccId INNER JOIN
                         dbo.Vouchers ON dbo.VoucherDetails.VMId = dbo.Vouchers.VMId
                         WHERE (dbo.VoucherDetails.DRCR = 'C') AND (dbo.Vouchers.AILogId = @aILogId)", new SqlParameter("aILogId", aILogId)).ToList();
            }
        }

        public bool DeleteImportedResults(int aILogId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    Voucher voucher = entities.Vouchers.Where(x => x.AILogId == aILogId).FirstOrDefault();

                    entities.Database.ExecuteSqlCommand(@"Delete from VoucherDetails Where VMId={0}", new object[] { voucher.VMId });
                    entities.Database.ExecuteSqlCommand(@"Delete from Vouchers Where VMId={0}", new object[] { voucher.VMId });
                    entities.Database.ExecuteSqlCommand(@"Delete from AccountsAutoImportLogs Where AILogId={0}", new object[] { aILogId });

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public AccountHead GetPostingAccountHeadById(int accountHeadID)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.Where(x => x.AccId == accountHeadID && x.IsPostingHead == true).FirstOrDefault();
            }
        }

        public DataSet GetBalanceSheet(DateTime dtpfrm, DateTime dtpto, DateTime _prevstartDate, DateTime _prevEndDate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"USE Amina_HERP; Exec [dbo].[SP_RPT_ACC_BalanceSheet] '{0}','{1}','{2}','{3}','0' ", dtpfrm, dtpto, _prevstartDate, _prevEndDate);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsbal = new DataSet();
                da.Fill(dsbal, "dtBalanceSheet");
                return dsbal;
            }
        }

        public IList<VoucherDetail> GetVoucherDetails(long vMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.VoucherDetails.Where(x => x.VMId == vMId).ToList();
            }
        }

        public Voucher GetVoucherById(long _VMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Vouchers.Where(x => x.VMId == _VMId).FirstOrDefault();
            }
        }

        public VoucherDetail GetCreditHeadAgainstDebits(long vMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.VoucherDetails.SqlQuery(@"Select * from VoucherDetails d Where d.VMId={0} and d.DRCR='C'", vMId).FirstOrDefault();
            }
        }

        public bool DeleteExistingVoucherDetails(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Delete from  dbo.VoucherDetails Where VMId={0}", vMId);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<SelectedAccountHeadToVoucher> GetCreditHeadList(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.Vouchers.VMId, dbo.Vouchers.VoucherID, dbo.Vouchers.VoucherDate, dbo.VoucherDetails.AccId, dbo.AccountHeads.AccountHeadName, dbo.VoucherDetails.Amount, dbo.VoucherDetails.reamrks,dbo.VoucherDetails.DRCR
                                      FROM dbo.Vouchers INNER JOIN
                                      dbo.VoucherDetails ON dbo.Vouchers.VMId = dbo.VoucherDetails.VMId INNER JOIN
                                      dbo.AccountHeads ON dbo.VoucherDetails.AccId = dbo.AccountHeads.AccId Where dbo.Vouchers.VMId={0} and dbo.VoucherDetails.DRCR='C'", vMId);
                da = new SqlDataAdapter(sql, conn);
                conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                List<SelectedAccountHeadToVoucher> accList = new List<SelectedAccountHeadToVoucher>();


                accList = new List<SelectedAccountHeadToVoucher>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccDataTableRow(dRow)))
                    );

                return accList;
            }
        }

        public VoucherDetail GetDebitHeadAgainstCredits(long vMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.VoucherDetails.Where(x => x.VMId == vMId && x.DRCR == "D").FirstOrDefault();
            }
        }

        public Voucher GetLatestReceiptVoucher()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Vouchers.Where(x => x.VoucherType == "Credit").OrderByDescending(y => y.VMId).FirstOrDefault();
            }
        }

        public List<SelectedAccountHeadToVoucher> GetDebitHeadList(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.Vouchers.VMId, dbo.Vouchers.VoucherID, dbo.Vouchers.VoucherDate, dbo.VoucherDetails.AccId, dbo.AccountHeads.AccountHeadName, dbo.VoucherDetails.Amount, dbo.VoucherDetails.reamrks,dbo.VoucherDetails.DRCR
                                      FROM dbo.Vouchers INNER JOIN
                                      dbo.VoucherDetails ON dbo.Vouchers.VMId = dbo.VoucherDetails.VMId INNER JOIN
                                      dbo.AccountHeads ON dbo.VoucherDetails.AccId = dbo.AccountHeads.AccId Where dbo.Vouchers.VMId={0} and dbo.VoucherDetails.DRCR='D'", vMId);
                da = new SqlDataAdapter(sql, conn);
                conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                List<SelectedAccountHeadToVoucher> accList = new List<SelectedAccountHeadToVoucher>();


                accList = new List<SelectedAccountHeadToVoucher>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccDataTableRow(dRow)))
                    );

                return accList;
            }
        }

        public Voucher GetLatestPaymentVoucher()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Vouchers.Where(x => x.VoucherType == "Debit").OrderByDescending(y => y.VMId).FirstOrDefault();
            }
        }

        public AccountHead GetAccountHeadByAccCode(long debitAccCode)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.AccountHeads.Where(x => x.AccCode == debitAccCode).FirstOrDefault();
            }
        }

        public List<SelectedAccountHeadToVoucher> GetAccountListByVoucher(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.Vouchers.VMId, dbo.Vouchers.VoucherID, dbo.Vouchers.VoucherDate, dbo.VoucherDetails.AccId, dbo.AccountHeads.AccountHeadName, dbo.VoucherDetails.Amount, dbo.VoucherDetails.reamrks,dbo.VoucherDetails.DRCR
                                      FROM dbo.Vouchers INNER JOIN
                                      dbo.VoucherDetails ON dbo.Vouchers.VMId = dbo.VoucherDetails.VMId INNER JOIN
                                      dbo.AccountHeads ON dbo.VoucherDetails.AccId = dbo.AccountHeads.AccId Where dbo.Vouchers.VMId={0} and dbo.VoucherDetails.DRCR='D'", vMId);
                da = new SqlDataAdapter(sql, conn);
                conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                List<SelectedAccountHeadToVoucher> accList = new List<SelectedAccountHeadToVoucher>();


                accList = new List<SelectedAccountHeadToVoucher>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccDataTableRow(dRow)))
                    );

                return accList;
            }
        }

        public List<SelectedAccountHeadToVoucher> GetCreditAccountListByVoucher(long vMId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.Vouchers.VMId, dbo.Vouchers.VoucherID, dbo.Vouchers.VoucherDate, dbo.VoucherDetails.AccId, dbo.AccountHeads.AccountHeadName, dbo.VoucherDetails.Amount, dbo.VoucherDetails.reamrks,dbo.VoucherDetails.DRCR
                                      FROM dbo.Vouchers INNER JOIN
                                      dbo.VoucherDetails ON dbo.Vouchers.VMId = dbo.VoucherDetails.VMId INNER JOIN
                                      dbo.AccountHeads ON dbo.VoucherDetails.AccId = dbo.AccountHeads.AccId Where dbo.Vouchers.VMId={0} and dbo.VoucherDetails.DRCR='C'", vMId);
                da = new SqlDataAdapter(sql, conn);
                conn.Open();

                DataTable dt = new DataTable();
                da.Fill(dt);

                conn.Close();

                List<SelectedAccountHeadToVoucher> accList = new List<SelectedAccountHeadToVoucher>();


                accList = new List<SelectedAccountHeadToVoucher>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccDataTableRow(dRow)))
                    );

                return accList;
            }
        }

        private SelectedAccountHeadToVoucher GetAccDataTableRow(DataRow dr)
        {
            SelectedAccountHeadToVoucher _accInfo = new SelectedAccountHeadToVoucher();
            _accInfo.AccountHeadID = Convert.ToInt32(dr["AccId"]);
            _accInfo.AccountHeadName = dr["AccountHeadName"].ToString();
            _accInfo.Amount = Convert.ToDouble(dr["Amount"]);
            _accInfo.Remarks = dr["reamrks"].ToString();

            return _accInfo;


        }

        public void SaveVoucherDetails(List<VoucherDetail> _rVoucherDetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.VoucherDetails.AddRange(_rVoucherDetailList);
                entities.SaveChanges();
            }
        }

        public Voucher GetVocherById(int _voucherId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Vouchers.Where(x => x.VMId == _voucherId).FirstOrDefault();
            }
        }

        public DataSet GetJournalVoucher(long voucherID)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SpGetJournalVoucher] '{0}','Journal' ", voucherID);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtJournalVoucher");
                return dsLed;
            }
        }

        public DataSet GetTrialBalance(DateTime dtpfrm, DateTime dtpto, int IswithOpening)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Trail_Balance_Book] '{0}','{1}',{2}", dtpfrm, dtpto, IswithOpening);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtTrialBalance");
                return dsLed;
            }
        }

        public DataSet GetLedger(DateTime fromdate, DateTime todate, int accountHeadID)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Exec [dbo].[SP_RPT_ACC_Ledger_Book] '{0}','{1}',{2} ", fromdate.Date, todate.Date, accountHeadID);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsLed = new DataSet();
                da.Fill(dsLed, "dtLedger");
                return dsLed;
            }
        }
    }
}
