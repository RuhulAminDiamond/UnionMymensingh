using HDMS.Common.Utils;
using HDMS.Model.ShareHolder;
using HDMS.Model.ShareHolder.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HDMS.Repository.ShareHolder
{
    public class ShareHolderRepository
    {
        string sql = string.Empty;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        public bool SaveShareHolder(ShareHolderBasicData sh)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ShareHolderBasicDatas.Add(sh);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public ShareHolderBasicData GetShareHolderId(int shId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareHolderBasicDatas.Where(x => x.ShId == shId).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    return null;

                }
            }
        }

        public DataSet GetShareTransferStatement2(int fiscalYear)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                string sql = string.Format(@"EXECUTE spGetShareTransferStatement2 {0}", fiscalYear);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtShareTransfer");
                conn.Close();

                return ds;
            }
        }
        public List<VMRightShareInfo> GetDistributedRightShareList(int fiscalYear)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMRightShareInfo>(@"Select ri.*,sbd.ShName from RightShareInfoes ri join ShareHolderBasicDatas sbd
                 on ri.ShId=sbd.ShId where FiscalYear=@FiscalYear", new SqlParameter("@FiscalYear", fiscalYear)).ToList();
            }
        }

        public bool DistributeRightShare(int fiscalYear, double rightShare)
        {
            using (DBEntities entities = new DBEntities())
            {

                try
                {
                    List<ShareHolderBasicData> _activeshList = entities.ShareHolderBasicDatas.Where(x => x.isActive == true).ToList();

                    int _totalShareHolder = _activeshList.Count;



                    List<RightShareInfo> _rightShareList = new List<RightShareInfo>();
                    foreach (var item in _activeshList)
                    {
                        ShareInfo _si = entities.ShareInfoes.Where(x => x.ShId == item.ShId).FirstOrDefault();
                        double distributedrightShare = Math.Round((rightShare * _si.TotalShare) / 100, 00);

                        RightShareInfo rsObj = new RightShareInfo();
                        rsObj.ShId = item.ShId;
                        rsObj.TotalShare = _si.TotalShare;
                        rsObj.RightShare = distributedrightShare;
                        rsObj.FiscalYear = fiscalYear;
                        rsObj.IssuedShare = 0;
                        rsObj.ExtraShare = 0;
                        _rightShareList.Add(rsObj);
                    }

                    entities.RightShareInfoes.AddRange(_rightShareList);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool IssueRightShare(VMshareTransfer vMshareTransfer, int issuedShare, int year, string particulars)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    ShareInfo si = entities.ShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId).FirstOrDefault();
                    si.TotalShare = si.TotalShare + issuedShare;
                    entities.Entry(si).State = EntityState.Modified;
                    entities.SaveChanges();

                    YearOnYearShareInfo yoys = entities.YearOnYearShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId && x.Year == year).FirstOrDefault();
                    yoys.TotalShare = yoys.TotalShare + issuedShare;
                    entities.Entry(yoys).State = EntityState.Modified;
                    entities.SaveChanges();

                    RightShareInfo _rsi = entities.RightShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId && x.FiscalYear == year).FirstOrDefault();
                    if (_rsi != null)
                    {
                        _rsi.IssuedShare = issuedShare;
                        _rsi.Particulars = particulars;
                        entities.Entry(_rsi).State = EntityState.Modified;
                        entities.SaveChanges();

                    }

                    return true;



                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public void DeleteRightShareInfoes(int fiscalYear)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RightShareInfoes where FiscalYear = {0}", fiscalYear);
                entities.SaveChanges();
            }
        }

        public bool IsRightShareDistributed(int fiscalYear)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    RightShareInfo ri = entities.RightShareInfoes.Where(x => x.FiscalYear == fiscalYear).FirstOrDefault();
                    if (ri != null)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public RightShareInfo GetRightShareInfo(int shId, int year)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RightShareInfoes.Where(x => x.ShId == shId && x.FiscalYear == year).FirstOrDefault();
            }
        }

        public DataSet GetIssuedShareStatement(int fiscalYear)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"EXECUTE spGetIssuedShareStatement {0}", fiscalYear);


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtShareDividend");
                conn.Close();

                return ds;
            }
        }

        public bool IssueExtraShare(VMshareTransfer vMshareTransfer, int issuedShare, int year, string particulars)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    ShareInfo si = entities.ShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId).FirstOrDefault();
                    if (si != null)
                    {
                        si.TotalShare = si.TotalShare + issuedShare;
                        entities.Entry(si).State = EntityState.Modified;
                        entities.SaveChanges();
                    }

                    YearOnYearShareInfo yoys = entities.YearOnYearShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId && x.Year == year).FirstOrDefault();
                    if (yoys != null)
                    {
                        yoys.TotalShare = yoys.TotalShare + issuedShare;
                        entities.Entry(yoys).State = EntityState.Modified;
                        entities.SaveChanges();
                    }

                    RightShareInfo _rsi = entities.RightShareInfoes.Where(x => x.ShId == vMshareTransfer.ShId && x.FiscalYear == year).FirstOrDefault();
                    if (_rsi != null)
                    {
                        _rsi.ExtraShare = issuedShare;
                        _rsi.Particulars = particulars;
                        entities.Entry(_rsi).State = EntityState.Modified;
                        entities.SaveChanges();

                    }

                    return true;



                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public DataSet GetShareTransferStatement(int fiscalYear)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"EXECUTE spGetShareTransferStatement {0}", fiscalYear);


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtShareTransfer");
                conn.Close();

                return ds;
            }
        }

        public DataSet GetShareDividendStatement(int fiscalYear)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"EXECUTE spGetShareDividendStatement {0}", fiscalYear);


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtShareDividend");
                conn.Close();

                return ds;
            }
        }

        public DataSet GetRightShareStatement(int _fiscalYear)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                da = new SqlDataAdapter();
                sql = string.Format(@"Exec [dbo].[spGetRightShareStatement] {0}", _fiscalYear);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtRightShareStatement");
                conn.Close();

                return ds;


            }
        }

        public DataSet GetFinalShareStatement(int fiscalYear, int status)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                da = new SqlDataAdapter();
                sql = string.Format(@"Exec spGetFinalShareStatement {0},{1}", fiscalYear, status);


                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 900;
                da.SelectCommand = cmd;
                ds = new DataSet();

                conn.Open();
                da.Fill(ds, "dtFinalShare");
                conn.Close();

                return ds;


            }
        }


        public ShareTransferInfo GetShareTransferRecord(int transferId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ShareTransferInfoes.Where(x => x.transferId == transferId).FirstOrDefault();
            }
        }

        public ShareInfo GetShareInfoById(int shId)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareInfoes.Where(x => x.ShId == shId).FirstOrDefault();

                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool DeleteShareHolder(DividentInfo info)
        {
            
                using (DBEntities entities = new DBEntities())
                {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {

                        entities.Database.ExecuteSqlCommand("Delete from DividentInfoes where DId={0}", new object[] {info.DId });
                        entities.SaveChanges();
                        Thread.Sleep(100);

                        entities.Database.ExecuteSqlCommand("Delete from ShareHolderLedgers where DId={0}", new object[] { info.DId });
                        entities.SaveChanges();
                        transaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        
                        return false;
                    }
                }
            }
        }

        public bool UpdateShareTransferInfo(ShareTransferInfo obj, long prevSellShareAmount)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        entities.Entry(obj).State = EntityState.Modified;
                        entities.SaveChanges();

                        ShareInfo transferfrom = entities.ShareInfoes.Where(x => x.ShId == obj.TrfFromId).FirstOrDefault();
                        transferfrom.TotalShare += (int)prevSellShareAmount;
                        transferfrom.TotalShare -= (int)obj.SellShareAmount;
                        transferfrom.TotalInvestment -= (transferfrom.FaceValue * (double)obj.SellShareAmount);
                        entities.Entry(transferfrom).State = EntityState.Modified;
                        entities.SaveChanges();

                        if (transferfrom.TotalShare == 0)
                        {
                            ShareHolderBasicData bd = entities.ShareHolderBasicDatas.Where(x => x.ShId == obj.TrfFromId).FirstOrDefault();
                            bd.isActive = false;
                            entities.Entry(bd).State = EntityState.Modified;
                            entities.SaveChanges();
                        }

                        Thread.Sleep(100);

                        ShareInfo transferto = entities.ShareInfoes.Where(x => x.ShId == obj.TrfToId).FirstOrDefault();
                        transferto.TotalShare -= (int)prevSellShareAmount;
                        transferto.TotalShare += (int)obj.SellShareAmount;
                        transferto.TotalInvestment -= (transferto.FaceValue * (double)obj.SellShareAmount);
                        entities.Entry(transferto).State = EntityState.Modified;
                        entities.SaveChanges();

                        if (transferto.TotalShare > 0)
                        {
                            ShareHolderBasicData bd = entities.ShareHolderBasicDatas.Where(x => x.ShId == obj.TrfToId).FirstOrDefault();
                            if (bd.isActive == false)
                            {
                                bd.isActive = true;
                            }
                            entities.Entry(bd).State = EntityState.Modified;
                            entities.SaveChanges();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public DividentInfo IsDividentDistributed(int fiscalYear)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                   DividentInfo divident=  entities.DividentInfoes.Where(x=>x.FiscalYear==fiscalYear).FirstOrDefault();
                    return divident;
                }catch(Exception ex)
                {
                    
                    return null;
                }
            }


        }

        public List<VMShareTransferDetail> GetShareTransferInfoes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMShareTransferDetail>(@"
                    SELECT        
	                    dbo.ShareTransferInfoes.TDate,		
	                    dbo.ShareTransferInfoes.SellShareAmount, 
	                    dbo.ShareTransferInfoes.ReceiptNo, 
	                    dbo.ShareTransferInfoes.transferId, 
	                    dbo.ShareHolderBasicDatas.ShName AS TransferrerName,                      
	                    ShareHolderBasicDatas_1.ShName AS ReceiverName, 
	                    ShareInfoes_1.ShareNo AS ReceiverShareNo, 
	                    dbo.ShareInfoes.ShareNo AS TransferrerShareNo,
                        dbo.ShareTransferInfoes.ShareCountStart,
                        dbo.ShareTransferInfoes.ShareCountEnd
                    FROM dbo.ShareTransferInfoes 
                    INNER JOIN dbo.ShareHolderBasicDatas 
                    ON dbo.ShareTransferInfoes.TrfFromId = dbo.ShareHolderBasicDatas.ShId 
                    INNER JOIN dbo.ShareHolderBasicDatas AS ShareHolderBasicDatas_1 
                    ON dbo.ShareTransferInfoes.TrfToId = ShareHolderBasicDatas_1.ShId 
                    INNER JOIN dbo.ShareInfoes 
                    ON dbo.ShareTransferInfoes.TrfFromId = dbo.ShareInfoes.ShId 
                    INNER JOIN dbo.ShareInfoes AS ShareInfoes_1 
                    ON dbo.ShareTransferInfoes.TrfToId = ShareInfoes_1.ShId
                ").ToList();
            }
        }


        public IList<ShareHolderRelation> GetShareHolderRelation()
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareHolderRelations.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public List<ShareHolderLedger> GetShareHolderLedger(int shId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareHolderLedgers.Where(x => x.ShId == shId).ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool WithDrawdivident(double withdrawamount, int shId, double balance, string username, DateTime dateTime)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        ShareWithdrawdata withdrawdata = new ShareWithdrawdata();
                        withdrawdata.ShId = shId;
                        withdrawdata.WithdrawAmount = withdrawamount;
                        withdrawdata.Wdate = dateTime;
                        withdrawdata.transferby = username;
                        entities.ShareWithdrawdatas.Add(withdrawdata);
                        entities.SaveChanges();
                        Thread.Sleep(100);

                        
                        ShareHolderLedger ledger = new ShareHolderLedger();
                        ledger.DId =0;
                        ledger.ShId = shId;
                        ledger.TDate = dateTime;
                        ledger.particulars = "Withdraw amount " + withdrawamount.ToString();
                        ledger.Credit = 0;
                        ledger.Debit = withdrawamount;
                        ledger.Balance =balance-withdrawamount;
                        entities.ShareHolderLedgers.Add(ledger);
                        entities.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        
                        return false;
                    }
                }
            }
        }

        public IList<VMShareHolderInfo> GetAllShareHolderWithShareInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMShareHolderInfo>(@"Select sbd.*,isNull(si.ShareNo,0) ShareNo, IsNull(si.TotalShare,0) TotalShare, IsNull(si.FaceValue,0) FaceValue , IsNull(si.TotalInvestment,0) TotalInvestment  from ShareHolderBasicDatas sbd left join ShareInfoes si on sbd.ShId=si.ShId").ToList();
            }
        }

        public void SaveYearOnYearShareInfo(YearOnYearShareInfo shObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.YearOnYearShareInfoes.Add(shObj);
                entities.SaveChanges();
            }
        }

        public bool IsShareExistsInYearOnYearShare(int shId, int year)
        {
            using (DBEntities entities = new DBEntities())
            {
                var item = entities.YearOnYearShareInfoes.Where(x => x.ShId == shId && x.Year == year).ToList();
                if (item.Count == 0) return false;

                return true;
            }
        }

        public bool isShareNoUsed(long shareno)
        {
            using (DBEntities entities = new DBEntities())
            {
                ShareInfo si = entities.ShareInfoes.Where(x => x.ShareNo == shareno).FirstOrDefault();
                if (si == null) return false;
                return true;
            }
        }

        public bool ShareTransfer(VMTransferCarrier obj)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                       
                        ShareTransferInfo shareTransferInfo = new ShareTransferInfo();
                        shareTransferInfo.TrfFromId = obj.TransferFrom.ShId;
                        shareTransferInfo.TrfToId = obj.TransferTo.ShId;
                        shareTransferInfo.SellShareAmount = obj.transferedShare;
                        shareTransferInfo.TDate = obj.TDate;
                        entities.ShareTransferInfoes.Add(shareTransferInfo);
                        entities.SaveChanges();


                        ShareInfo transferfrom = entities.ShareInfoes.Where(x=>x.ShId==obj.TransferFrom.ShId).FirstOrDefault();
                        transferfrom.TotalShare -= obj.transferedShare;
                        transferfrom.TotalInvestment -= (transferfrom.FaceValue*(double)obj.transferedShare);
                        entities.Entry(transferfrom).State = EntityState.Modified;
                        entities.SaveChanges();


                        Thread.Sleep(100);

                        ShareInfo transferto = entities.ShareInfoes.Where(x => x.ShId == obj.TransferTo.ShId).FirstOrDefault();
                        transferto.TotalShare += obj.transferedShare;
                        transferto.TotalInvestment += (transferto.FaceValue * (double)obj.transferedShare);
                        entities.Entry(transferfrom).State = EntityState.Modified;
                        entities.SaveChanges();
                        entities.Entry(transferto).State = EntityState.Modified;
                        entities.SaveChanges();
                        transaction.Commit();
                        return true;
                    }catch(Exception ex)
                    {
                        transaction.Rollback();
                        
                        return false;
                    }
                    }
            }
        }

        public bool DisburseDivident(int fiscalYear, int divident, string username, DateTime Tdate)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {

                    try
                    {
                        DividentInfo dividentInfo = new DividentInfo();
                        dividentInfo.FiscalYear = fiscalYear;
                        dividentInfo.DividentRate = divident;
                        dividentInfo.DDate = Tdate;
                        dividentInfo.Dividentby = username;
                        entities.DividentInfoes.Add(dividentInfo);
                        entities.SaveChanges();
                        IList<ShareInfo> shList = entities.ShareInfoes.ToList();
                        List<ShareHolderLedger> shlList = new List<ShareHolderLedger>();
                        foreach(ShareInfo sh in shList)
                        {
                            List<ShareHolderLedger> shLg = entities.ShareHolderLedgers.Where(x => x.ShId == sh.ShId).ToList();
                            double _balance = shLg.Sum(x => x.Credit - x.Debit);
                            double _credit = (sh.TotalInvestment * divident) / 100;
                            ShareHolderLedger ledger = new ShareHolderLedger();
                            ledger.DId = dividentInfo.DId;
                            ledger.ShId = sh.ShId;
                            ledger.TDate = Tdate;
                            ledger.particulars = "Divident for the year of "+ fiscalYear.ToString();
                            ledger.Debit = 0;
                            ledger.Credit =_credit ;
                            ledger.Balance= _balance + _credit;
                            shlList.Add(ledger);
                           

                        }
                        entities.ShareHolderLedgers.AddRange(shlList);
                        entities.SaveChanges();


                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<ShareInfo> GetShareInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveShareTransferInfo(ShareTransferInfo shareTransferInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ShareTransferInfoes.Add(shareTransferInfo);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public IList<ShareInfo> Dgsh(int shid)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareInfoes.Where(x => x.ShId ==shid).ToList();

                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool DsSaveShareHolder(ShareHolderDescendantsInfo sh)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    entities.ShareHolderDescendantsInfoes.Add(sh);
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public IList<VMshareTransfer> GetShareHolderDetails()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.Database.SqlQuery<VMshareTransfer>(@"Select shb.ShId,shb.ShName,shb.ShMobile,shb.ShPermanentAddress,si.ShareNo from ShareHolderBasicDatas shb join ShareInfoes si on shb.ShId=si.ShId").ToList();

                }catch(Exception ex)
                {
                    return null;
                }
             }
        }
        public bool UpShareInfo(ShareInfo sh)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(sh).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public ShareHolderDescendantsInfo GetShareHolder(int shId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                return entities.ShareHolderDescendantsInfoes.Where(x => x.ShId == shId).FirstOrDefault();
                 }
                 catch (Exception ex)
                 {
                return null;
                 }
        }
        }
        public bool UpdateVMShareHolder(VMshareTransfer vMshareTransfer)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(vMshareTransfer).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public ShareInfo GetShareHolderById(int shId)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareInfoes.Where(x => x.ShId == shId).FirstOrDefault();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }
        public IList<ShareHolderDescendantsInfo> DataViewSh(int shId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareHolderDescendantsInfoes.Where(x=>x.ShId==shId).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<ShareInfo> GetAllShareInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveShareInfo(ShareInfo shareInfo)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    entities.ShareInfoes.Add(shareInfo);
                    entities.SaveChanges();
                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DsUpdateShareHolder(ShareHolderDescendantsInfo ds)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    entities.Entry(ds).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
               
            }
        }

        public ShareHolderRelation GetRelation()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareHolderRelations.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<ShareHolderDescendantsInfo> GetAllShareHolderDescendentInfo()
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareHolderDescendantsInfoes.ToList();
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public IList<ShareHolderBasicData> GetShareHolderByName(string text)
        {
            using (DBEntities entities=new DBEntities())
            {
                try
                {
                    return entities.ShareHolderBasicDatas.Where(x => x.ShName.ToLower().Contains(text.ToLower())).ToList();

                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool UpdateShareHolder(ShareHolderBasicData sg)
        {

            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(sg).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<ShareHolderBasicData> GetAllShareHolder()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.ShareHolderBasicDatas.ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
