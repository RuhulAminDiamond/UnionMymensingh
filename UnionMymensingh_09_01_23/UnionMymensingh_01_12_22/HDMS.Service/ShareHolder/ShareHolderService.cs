using HDMS.Model.ShareHolder;
using HDMS.Model.ShareHolder.VM;
using HDMS.Repository.ShareHolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.ShareHolder
{
    public class ShareHolderService
    {
        public bool SaveShareHolder(ShareHolderBasicData sh)
        {
            return new ShareHolderRepository().SaveShareHolder(sh);
        }

        public IList<ShareHolderBasicData> GetAllShareHolder()
        {
            return new ShareHolderRepository().GetAllShareHolder();
        }

        public ShareHolderBasicData GetShareHolderId(int shId)
        {
            return new ShareHolderRepository().GetShareHolderId(shId);
        }

        public bool UpdateShareHolder(ShareHolderBasicData sg)
        {
            return new ShareHolderRepository().UpdateShareHolder(sg);
        }

        public DataSet GetShareTransferStatement2(int fiscalYear)
        {
            return new ShareHolderRepository().GetShareTransferStatement2(fiscalYear);
        }

        public DataSet GetIssuedShareStatement(int fiscalYear)
        {
            return new ShareHolderRepository().GetIssuedShareStatement(fiscalYear);
        }

        public DataSet GetShareDividendStatement(int fiscalYear)
        {
            return new ShareHolderRepository().GetShareDividendStatement(fiscalYear);
        }

        public void DeleteRightShareInfoes(int fiscalYear)
        {
            new ShareHolderRepository().DeleteRightShareInfoes(fiscalYear);
        }

        public bool DistributeRightShare(int fiscalYear, double rightShare)
        {
            return new ShareHolderRepository().DistributeRightShare(fiscalYear, rightShare);
        }

        public List<VMRightShareInfo> GetDistributedRightShareList(int fiscalYear)
        {
            return new ShareHolderRepository().GetDistributedRightShareList(fiscalYear);
        }

        public bool IsRightShareDistributed(int fiscalYear)
        {
            return new ShareHolderRepository().IsRightShareDistributed(fiscalYear);
        }

        public RightShareInfo GetRightShareInfo(int shId, int year)
        {
            return new ShareHolderRepository().GetRightShareInfo(shId, year);
        }

        public DataSet GetRightShareStatement(int _fiscalYear)
        {
            return new ShareHolderRepository().GetRightShareStatement(_fiscalYear);
        }

        public DataSet GetShareTransferStatement(int fiscalYear)
        {
            return new ShareHolderRepository().GetShareTransferStatement(fiscalYear);
        }

        public bool IssueRightShare(VMshareTransfer vMshareTransfer, int issuedShare, int year, string particulars)
        {
            return new ShareHolderRepository().IssueRightShare(vMshareTransfer, issuedShare, year, particulars);
        }

        public ShareTransferInfo GetShareTransferRecord(int transferId)
        {
            return new ShareHolderRepository().GetShareTransferRecord(transferId);
        }

        public DataSet GetFinalShareStatement(int fiscalYear, int status)
        {
            return new ShareHolderRepository().GetFinalShareStatement(fiscalYear, status);
        }

        public bool IssueExtraShare(VMshareTransfer vMshareTransfer, int issuedShare, int year, string particulars)
        {
            return new ShareHolderRepository().IssueExtraShare(vMshareTransfer, issuedShare, year, particulars);
        }

        public IList<ShareHolderRelation> GetShareHolderRelation()
        {
            return new ShareHolderRepository().GetShareHolderRelation();
        }

        public ShareInfo GetShareInfoById(int shId)
        {
            return new ShareHolderRepository().GetShareInfoById(shId);
        }

        public DividentInfo IsDividentDistributed(int fiscalyear)
        {
            return new ShareHolderRepository().IsDividentDistributed(fiscalyear);
        }

        public bool DeleteShareHolder(DividentInfo info)
        {
            return new ShareHolderRepository().DeleteShareHolder(info);
        }

        public IList<ShareHolderBasicData> GetShareHolderByName(string text)
        {
            return new ShareHolderRepository().GetShareHolderByName(text);
        }

        public IList<ShareInfo> DgSh(int shid)
        {
            return new ShareHolderRepository().Dgsh(shid);
        }

        public bool UpdateShareTransferInfo(ShareTransferInfo obj, long prevSellShareAmount)
        {
            return new ShareHolderRepository().UpdateShareTransferInfo(obj, prevSellShareAmount);
        }

        public bool SaveShareTransferInfo(ShareTransferInfo shareTransferInfo)
        {
            return new ShareHolderRepository().SaveShareTransferInfo(shareTransferInfo);
        }

        public List<ShareHolderLedger> GetShareHolderLedger(int shId)
        {
            return new ShareHolderRepository().GetShareHolderLedger(shId);
        }

        public bool DsSaveShareHolder(ShareHolderDescendantsInfo sh)
        {
            return new ShareHolderRepository().DsSaveShareHolder(sh);
        }

        public bool WithDrawdivident(double withdrawamount, int shId, double balance, string username, DateTime dateTime)
        {
            return new ShareHolderRepository().WithDrawdivident(withdrawamount, shId, balance, username,dateTime);
        }

        public IList<ShareHolderDescendantsInfo> GetAllShareHolderDescendentInfo()
        {
           return new ShareHolderRepository().GetAllShareHolderDescendentInfo();
        }

       

        public ShareHolderRelation GetRelation()
        {
            return new ShareHolderRepository().GetRelation();
        }

        public List<ShareInfo> GetShareInfo()
        {
            return new ShareHolderRepository().GetShareInfo();
        }

        public bool DisburseDivident(int fiscalYear, int divident, string username, DateTime TDate)
        {
            return new ShareHolderRepository().DisburseDivident(fiscalYear,divident,username,TDate);
        }

        public bool UpShareInfo(ShareInfo sh)
        {
            return new ShareHolderRepository().UpShareInfo(sh);
        }

        public bool ShareTransfer(VMTransferCarrier obj)
        {
            return new ShareHolderRepository().ShareTransfer(obj);
        }

        public IList<VMshareTransfer> GetShareHolderDetails()
        {
            return new ShareHolderRepository().GetShareHolderDetails();
        }

        public bool DsUpdateShareHolder(ShareHolderDescendantsInfo ds)
        {
            return new ShareHolderRepository().DsUpdateShareHolder(ds);
        }

        public IList<ShareHolderDescendantsInfo> DataViewSh(int shId)
        {
            return new ShareHolderRepository().DataViewSh(shId);
        }

        public bool SaveShareInfo(ShareInfo shareInfo)
        {
            return new ShareHolderRepository().SaveShareInfo(shareInfo);
        }

        public IList<ShareInfo> GetAllShareInfo()
        {
            return new ShareHolderRepository().GetAllShareInfo();
        }

        public ShareInfo GetShareHolderById(int shId)
        {
            return new ShareHolderRepository().GetShareHolderById(shId);
        }

        public ShareHolderDescendantsInfo GetShareHolder(int shId)
        {
            return new ShareHolderRepository().GetShareHolder(shId);
        }

       
        public bool UpdateVMShareHolder(VMshareTransfer vMshareTransfer)
        {
            return new ShareHolderRepository().UpdateVMShareHolder(vMshareTransfer);
        }

        public bool isShareNoUsed(long shareno)
        {
            return new ShareHolderRepository().isShareNoUsed(shareno);
        }

        public bool IsShareExistsInYearOnYearShare(int shId, int year)
        {
            return new ShareHolderRepository().IsShareExistsInYearOnYearShare(shId, year);
        }

        public void SaveYearOnYearShareInfo(YearOnYearShareInfo shObj)
        {
            new ShareHolderRepository().SaveYearOnYearShareInfo(shObj);
        }

        public IList<VMShareHolderInfo> GetAllShareHolderWithShareInfo()
        {
            return new ShareHolderRepository().GetAllShareHolderWithShareInfo();
        }

        public List<VMShareTransferDetail> GetShareTransferInfoes()
        {
            return new ShareHolderRepository().GetShareTransferInfoes();
        }
    }
}
