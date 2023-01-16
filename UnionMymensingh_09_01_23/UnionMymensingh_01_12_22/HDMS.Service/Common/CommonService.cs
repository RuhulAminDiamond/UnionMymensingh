using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Repository.Common;
using HDMS.Model.Common.VW;
using HDMS.Model.Location;
using HDMS.Model.Marketing;
using HDMS.Model.Accounting;
using HDMS.Model;
using HDMS.Model.Diagnostic;

namespace HDMS.Service.Common
{
    public class CommonService
    {

        public List<DashBoardAccGeneralInfo> GetDashBoardBroadHeadsList()
        {
            return new CommonRepository().GetDashBoardBroadHeadsList();
        }


        public void AccumulateTheDashBoardGeneralInfoItem(DateTime fromdate, DateTime todate)
        {
            new CommonRepository().AccumulateTheDashBoardGeneralInfoItem(fromdate, todate);
        }


        public bool SaveDepartment(Department _dept)
        {
            return new CommonRepository().SaveDepartment(_dept);
        }

        public List<AvailableDoctor> GetAvailableDoctor(DateTime value)
        {
            return new CommonRepository().GetAvailableDoctor(value);
        }

        public List<Department> GetAllDepartment()
        {
            return new CommonRepository().GetAllDepartment();
        }

        public bool SaveCompany(CompanyInfo cInfo)
        {
            return new CommonRepository().SaveCompany(cInfo);
        }

        public List<CompanyInfo> GetCompany()
        {
            return new CommonRepository().GetCompany();
        }

        public List<MarketingAgent> GetAllMarketingAgents()
        {
            return new CommonRepository().GetAllMarketingAgents();
        }

        public List<VMDeptGroupAccountHeadMapping> GetDeptGroupAccountHeadMappedBalanceList(DateTime dtfrm, DateTime dtto)
        {
            return new CommonRepository().GetDeptGroupAccountHeadMappedBalanceList(dtfrm, dtto);
        }

        public bool SaveBusinessUnit(BusinessUnit bU)
        {
            return new CommonRepository().SaveBusinessUnit(bU);
        }

        public bool SaveOrganizeInfo(OrganizationInfo oInfo)
        {
            return new CommonRepository().SaveOrganizeInfo(oInfo);
        }

        public IList<PractitionerWisePatientSerial> GetAllPatient()
        {
            return new CommonRepository().GetAllPatient();
        }

        public bool AddSupplier(SupplierInfo _sInfo)
        {
            return new CommonRepository().AddSupplier(_sInfo);
        }

        public List<OrganizationInfo> GetOrganizationList()
        {
            return new CommonRepository().GetOrganizationList();
        }

        public bool UpdateOrgInfo(OrganizationInfo oInfo)
        {
            return new CommonRepository().UpdateOrgInfo(oInfo);
        }

        public bool AddCardType(DiscountCardType _cType)
        {
            return new CommonRepository().AddCardType(_cType);
        }

        public List<BusinessUnit> GetbusinessUnit()
        {
            return new CommonRepository().GetbusinessUnit();
        }

        public bool UpdateCardtype(DiscountCardType _cardType)
        {
            return new CommonRepository().UpdateCardtype(_cardType);
        }

        public bool UpdateCompanyInfo(CompanyInfo _gr)
        {
            return new CommonRepository().UpdateCompanyInfo(_gr);
        }

        public List<BusinessMedia> GetAllMedia()
        {
            return new CommonRepository().GetAllMedia();
        }

        public CompanyInfo GetCompanyById(int CId)
        {
            return new CommonRepository().GetCompanyById(CId);
        }

        public List<DiscountCardType> GetAllCardTypes()
        {
            return new CommonRepository().GetAllCardTypes();
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await new CommonRepository().GetAllDistricts();
        }

        public List<Relation> GetRelations()
        {
            return new CommonRepository().GetRelations();
        }

        public bool SaveDeptWithAccountGroupMapping(DeptGroupWithAccountMapping accObj)
        {
            return new CommonRepository().SaveDeptWithAccountGroupMapping(accObj);
        }

        public bool SaveDiscountPlan(RegDiscountPlan _discountPlan)
        {
            return new CommonRepository().SaveDiscountPlan(_discountPlan);
        }

        public DataSet GetUsedCardList(int doctorId)
        {
            return new CommonRepository().GetUsedCardList(doctorId);
        }

        public List<VMDeptGroupAccountHeadMapping> GetDeptGroupAccountHeadMappingList()
        {
            return new CommonRepository().GetDeptGroupAccountHeadMappingList();
        }

        public PractitionerWisePatientSerial GetPractionerwisePatient(int id)
        {
            return new CommonRepository().GetPractionerwisePatient(id);
        }

        public MediaCategory GetMediaCatagory(int categoryId)
        {
            return new CommonRepository().GetMediaCatagory(categoryId);
        }

        public VMDiscountCardStatistics GetCardStatitics(int doctorId)
        {
            List<DiscountCard> _allcardList = new CommonRepository().GetAllIssuedCard(doctorId);
            List<DiscountCard> _usedcardList = new CommonRepository().GetAllUsedCard(doctorId);

            VMDiscountCardStatistics _cs = new VMDiscountCardStatistics();

            if (_allcardList != null && _usedcardList!=null)
            {
                _cs.IssuedCard = _allcardList.Count;
                _cs.UsedCard = _usedcardList.Count;
                _cs.UnusedCard = _allcardList.Count - _usedcardList.Count;

            }else
            {
                _cs.IssuedCard = 0;
                _cs.UsedCard = 0;
                _cs.UnusedCard = 0;
            }
          
         

            return _cs;
        }

        public bool UpdateMedia(BusinessMedia _media)
        {
            return new CommonRepository().UpdateMedia(_media);
        }

        public List<CorporateClient> GetCorporateClientList()
        {
            return new CommonRepository().GetCorporateClientList();
        }

        public List<RegDesignation> GetRegDesignationList()
        {
            return new CommonRepository().GetRegDesignationList();
        }

        public List<RegStatus> GetRegStatusList()
        {
            return new CommonRepository().GetRegStatusList();
        }

        public OrganizationInfo GetOrganizationById(int OrgId)
        {
            return new CommonRepository().GetOrganizationById(OrgId);
        }

        public RegDiscountPlan GetRegDiscountPlan(int companyId, int designationId)
        {
            return new CommonRepository().GetRegDiscountPlan(companyId, designationId);
        }

        public DataSet GetUnUsedCardList(int doctorId)
        {
            return new CommonRepository().GetUnUsedCardList(doctorId);
        }

        public DiscountCardType GetDiscountCardTypeById(int _CTypeId)
        {
            return new CommonRepository().GetDiscountCardTypeById(_CTypeId);
        }

        public List<BusinessUnit> GetbusinessUnitByOrgId(int orgId)
        {
            return new CommonRepository().GetbusinessUnitByOrgId(orgId);
        }

        public OrgSetting GetOrgSettings()
        {
            return new CommonRepository().GetOrgSettings();
        }

        public void SaveGeneratedCards(List<DiscountCard> _dCardList)
        {
            new CommonRepository().SaveGeneratedCards(_dCardList);
        }

        public long SaveDiscountCardMaster(DiscountCardMaster _cardm)
        {
           return  new CommonRepository().SaveDiscountCardMaster(_cardm);
        }

        public void GeneratePrintFormat(long _dcmId, string _topLabel, string _cardType)
        {
            int columcount = 0;

            DeleteExistingData();

            List<DiscountCard> _dCardList = new CommonRepository().GetCardListByMasterId(_dcmId);

            List<DiscountCardPrintView> _ppList = new List<DiscountCardPrintView>();

            DiscountCardPrintView pp = new DiscountCardPrintView();
            foreach (var _card in _dCardList)
            {
                if(columcount==0) pp = new DiscountCardPrintView();

                if (columcount >= 0 && columcount<3)
                {
                    if (columcount == 0)
                    {
                        pp.topLabel = _topLabel;
                        pp.CardType = _cardType;
                        pp.CardNo1 = _card.CardNo.ToString();
                    }
                      

                    if (columcount == 1)
                        pp.CardNo2 = _card.CardNo.ToString();

                    if (columcount == 2)
                        pp.CardNo3 = _card.CardNo.ToString();

                    //if (columcount == 3)
                    //    pp.CardNo4 = _card.CardNo.ToString();

                    //if (columcount == 4)
                    //    pp.CardNo5 = _card.CardNo.ToString();

                    if (columcount == 2) {_ppList.Add(pp); }
                }

                columcount++;

                if (columcount == 3) columcount = 0;
            }

            if (_ppList.Count > 0)
            {
                new CommonService().SaveDiscountCardPrintPreview(_ppList);
            }
        }

        public List<PaymentMode> GetPaymentModes()
        {
            return new CommonRepository().GetPaymentModes();
        }

        public DataSet GetDiscountCards(long _dcmId)
        {
            return new CommonRepository().GetDiscountCards(_dcmId);
        }

        private void DeleteExistingData()
        {
           new CommonRepository().DeleteExistingDiscountCard();
        }

        private void SaveDiscountCardPrintPreview(List<DiscountCardPrintView> _ppList)
        {
            new CommonRepository().SaveDiscountCardPrintPreview(_ppList);
        }

      

        public VMDiscountCard GetDiscountCard(string _discCradNo, DateTime _todaysDate)
        {
            return new CommonRepository().GetDiscountCard(_discCradNo, _todaysDate);
        }

        public  List<Occupation> GetAllOccupations()
        {
            return   new CommonRepository().GetAllOccupations();
        }

        public DiscountCard GetDiscountCardByCardNo(string _discCradNo)
        {
            return new CommonRepository().GetDiscountCardByCardNo(_discCradNo);
        }

        public void UpdateCardStatus(DiscountCard _dcard)
        {
            new CommonRepository().UpdateCardStatus(_dcard);
        }

        public List<UpazilaOrArea> GetUpazilaOrAreaList(int districtId)
        {
            return new CommonRepository().GetUpazilaOrAreaList(districtId);
        }

        public List<PaymentChannel> GetPaymentChannels(int pMId)
        {
            return new CommonRepository().GetPaymentChannels(pMId);
        }
    }
}
