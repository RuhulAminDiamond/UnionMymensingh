using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data;
using HDMS.Model.Common.VW;
using HDMS.Model.Location;
using HDMS.Model.Marketing;
using HDMS.Model.Accounting;
using HDMS.Model;
using HDMS.Model.Diagnostic;

namespace HDMS.Repository.Common
{
    public class CommonRepository
    {
        string sql = string.Empty;
        SqlCommand cmd;
        SqlDataAdapter da;

        public List<DashBoardAccGeneralInfo> GetDashBoardBroadHeadsList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DashBoardAccGeneralInfoes.ToList();
            }
        }



        public void AccumulateTheDashBoardGeneralInfoItem(DateTime fromdate, DateTime todate)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec sp_Get_AccDashBoardBroadHeadData '{0}','{1}'", fromdate.Date, todate.Date);

                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public List<AvailableDoctor> GetAvailableDoctor(DateTime value)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    SqlParameter p = new SqlParameter("@dt", value.Date);
                    return entities.Database.SqlQuery<AvailableDoctor>("exec spGetTodaysDoctoe @dt", p).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveDepartment(Department _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Departments.Add(_dept);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public List<VMDeptGroupAccountHeadMapping> GetDeptGroupAccountHeadMappedBalanceList(DateTime dtfrm, DateTime dtto)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDeptGroupAccountHeadMapping>(@"with ctedg as (
                   Select dgm.*,acc.AccountHeadName,acc.ParentAccountHeadID, IsNull(tb.Amount,0) as Amount from DeptGroupWithAccountMappings dgm 
join AccountHeads acc on dgm.AccountHeadId=acc.AccId 
join TempBalanceOnDeptAccountGroupMapping tb on dgm.Id=tb.DeptId)
                    Select ctedg.*,acch.AccountHeadName as GroupName from ctedg 
join AccountHeads acch on ctedg.ParentAccountHeadID=acch.AccId").ToList();
            }
        }

        public IList<PractitionerWisePatientSerial> GetAllPatient()
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.PractitionerWisePatientSerials.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<BusinessMedia> GetAllMedia()
        {
            using (DBEntities entities=new DBEntities())
            {
               return entities.BusinessMedias.ToList();
                
            }
        }

        public bool SaveCompany(CompanyInfo cInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CompanyInfos.Add(cInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Relation> GetRelations()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Relations.ToList();

            }
        }

        public List<MarketingAgent> GetAllMarketingAgents()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MarketingAgents.ToList();

            }
        }

        public bool SaveBusinessUnit(BusinessUnit bU)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.BusinessUnits.Add(bU);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public MediaCategory GetMediaCatagory(int categoryId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.MediaCategories.Where(x=> x.CategoryId==categoryId).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public PractitionerWisePatientSerial GetPractionerwisePatient(int id)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.PractitionerWisePatientSerials.Where(x => x.Id == id).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool AddSupplier(SupplierInfo _sInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.SupplierInfoes.Add(_sInfo);
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateMedia(BusinessMedia _media)
        {
            using(DBEntities entities=new DBEntities())
            {
                try
                {
                    entities.Entry(_media).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool AddCardType(DiscountCardType _cType)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.DiscountCardTypes.Add(_cType);
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveDeptWithAccountGroupMapping(DeptGroupWithAccountMapping accObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.DeptGroupWithAccountMappings.Add(accObj);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<VMDeptGroupAccountHeadMapping> GetDeptGroupAccountHeadMappingList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMDeptGroupAccountHeadMapping>(@"with ctedg as (
                   Select dgm.*,acc.AccountHeadName,acc.ParentAccountHeadID, cast(0 as float) as Amount from 
DeptGroupWithAccountMappings dgm join AccountHeads acc on dgm.AccountHeadId=acc.AccId)
                    Select ctedg.*,acch.AccountHeadName as GroupName from ctedg join AccountHeads acch on ctedg.ParentAccountHeadID=acch.AccId
                   ").ToList();
            }
        }

        public bool UpdateCardtype(DiscountCardType _cardType)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_cardType).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<List<District>> GetAllDistricts()
        {
            using (DBEntities entities = new DBEntities())
            {

                return await entities.Districts.ToListAsync();

            }
        }

        public bool SaveDiscountPlan(RegDiscountPlan _discountPlan)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    RegDiscountPlan _getExistingPlan = this.GetRegDiscountPlan(_discountPlan.CompanyId, _discountPlan.DesignationId);
                    if (_getExistingPlan == null)
                    {
                        entities.RegDiscountPlans.Add(_discountPlan);
                        entities.SaveChanges();
                        return true;

                    }else
                    {
                        _getExistingPlan.LabDiscount = _discountPlan.LabDiscount;
                        _getExistingPlan.NonLabDiscount = _discountPlan.NonLabDiscount;
                        _getExistingPlan.IPDBedDiscount = _discountPlan.IPDBedDiscount;
                        _getExistingPlan.OxygenDiscount = _discountPlan.OxygenDiscount;
                        _getExistingPlan.VentilationDiscount = _discountPlan.VentilationDiscount;
                        _getExistingPlan.PharmacyDiscount = _discountPlan.PharmacyDiscount;
                        _getExistingPlan.IPDServiceChargeDiscount = _discountPlan.IPDServiceChargeDiscount;

                         entities.Entry(_getExistingPlan).State =EntityState.Modified;
                         entities.SaveChanges();
                         return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public RegDiscountPlan GetRegDiscountPlan(int companyId, int designationId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.RegDiscountPlans.Where(x => x.CompanyId == companyId && x.DesignationId == designationId).FirstOrDefault();
            
            }
        }

        public DataSet GetUsedCardList(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"SELECT  dbo.DiscountCards.CardId, dbo.DiscountCards.CardNo, dbo.DiscountCards.status, dbo.DiscountCards.UsedDate, dbo.DiscountCards.DCMId, dbo.DiscountCardMasters.DoctorId, 
                                          dbo.DiscountCardTypes.Name AS CardType, dbo.DiscountCardTypes.DiscountInPercent, dbo.DiscountCardMasters.CardTypeId, dbo.Patients.BillNo, dbo.Patients.EntryTime, dbo.[User].LoginName
                                          FROM   dbo.DiscountCards INNER JOIN
                                          dbo.DiscountCardMasters ON dbo.DiscountCards.DCMId = dbo.DiscountCardMasters.DCMId INNER JOIN
                                          dbo.DiscountCardTypes ON dbo.DiscountCardMasters.CardTypeId = dbo.DiscountCardTypes.CardTypeId INNER JOIN
                                          dbo.Patients ON dbo.DiscountCards.CardNo = dbo.Patients.DiscountCardNo INNER JOIN
                                          dbo.[User] ON dbo.Patients.UserId = dbo.[User].UserId
                                           WHERE (dbo.DiscountCards.status IS NOT NULL) AND (dbo.DiscountCardMasters.DoctorId = {0})", doctorId);


                    da = new SqlDataAdapter(sql, conn);
                    DataSet dsCards = new DataSet();
                    da.Fill(dsCards, "dtUsedCard");
                    return dsCards;



                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<PaymentMode> GetPaymentModes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PaymentModes.ToList();

            }
        }

        public OrgSetting GetOrgSettings()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OrgSettings.FirstOrDefault();

            }
        }

        public List<CorporateClient> GetCorporateClientList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CorporateClients.ToList();

            }
        }

        public List<RegDesignation> GetRegDesignationList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegDesignations.ToList();

            }
        }

        public List<RegStatus> GetRegStatusList()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.RegStatuses.ToList();
               
            }
        }

        public long SaveDiscountCardMaster(DiscountCardMaster _cardm)
        {
            using (DBEntities entities= new DBEntities())
            {
                entities.DiscountCardMasters.Add(_cardm);
                entities.SaveChanges();

                return _cardm.DCMId;
            }
        }

        public List<PaymentChannel> GetPaymentChannels(int pMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PaymentChannels.Where(x=>x.PMId== pMId).ToList();

            }
        }

        public  List<Occupation> GetAllOccupations()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.Occupations.ToList();
               
            }
        }

        public DataSet GetUnUsedCardList(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"SELECT dbo.DiscountCards.CardId, dbo.DiscountCards.CardNo, dbo.DiscountCards.status, dbo.DiscountCards.UsedDate, dbo.DiscountCards.DCMId, dbo.DiscountCardMasters.DoctorId, 
                                          dbo.DiscountCardTypes.Name AS CardType, dbo.DiscountCardTypes.DiscountInPercent, dbo.DiscountCardMasters.CardTypeId
                                          FROM   dbo.DiscountCards INNER JOIN
                                          dbo.DiscountCardMasters ON dbo.DiscountCards.DCMId = dbo.DiscountCardMasters.DCMId INNER JOIN
                                           dbo.DiscountCardTypes ON dbo.DiscountCardMasters.CardTypeId = dbo.DiscountCardTypes.CardTypeId
                                           WHERE (dbo.DiscountCards.status IS NULL) AND (dbo.DiscountCardMasters.DoctorId = {0})", doctorId);


                    da = new SqlDataAdapter(sql, conn);
                    DataSet dsCards = new DataSet();
                    da.Fill(dsCards, "dtUnUsedCard");
                    return dsCards;



                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<UpazilaOrArea> GetUpazilaOrAreaList(int districtId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.UpazilaOrAreas.Where(x=>x.DistrictId== districtId).ToList();
                //return entities.DiscountCards.Where(x => x.DoctorId == doctorId).ToList();
            }
        }

        public List<DiscountCard> GetAllIssuedCard(int doctorId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return null;
                //return entities.DiscountCards.Where(x => x.DoctorId == doctorId).ToList();
            }
        }

        public List<DiscountCard> GetAllUsedCard(int doctorId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return null;
                //return entities.DiscountCards.Where(x => x.DoctorId == doctorId && x.status=="Used").ToList();
            }
        }

        public bool UpdateOrgInfo(OrganizationInfo oInfo)
        {
            {
                using (DBEntities entities = new DBEntities())
                {
                    try
                    {
                        entities.Entry(oInfo).State = EntityState.Modified;
                        entities.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public List<DiscountCard> GetCardListByMasterId(long _dcmId)
        {
            using (DBEntities entities = new DBEntities())
            {
              
                return entities.DiscountCards.Where(x=>x.DCMId== _dcmId).ToList();
               
            }
        }

        public DiscountCard GetDiscountCardByCardNo(string _discCradNo)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.DiscountCards.Where(x => x.CardNo == _discCradNo).FirstOrDefault();

            }
        }

        public void SaveGeneratedCards(List<DiscountCard> _dCardList)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.DiscountCards.AddRange(_dCardList);
                  entities.SaveChanges();
            }
        }

        public DiscountCardType GetDiscountCardTypeById(int _CTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DiscountCardTypes.Where(x=>x.CardTypeId== _CTypeId).FirstOrDefault();
            }
        }

        public List<DiscountCardType> GetAllCardTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DiscountCardTypes.ToList();
            }
        }

        public List<BusinessUnit> GetbusinessUnitByOrgId(int orgId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessUnits.Where(x => x.BusinessUnitId == orgId).ToList();
            }
        }
        public bool UpdateCompanyInfo(CompanyInfo _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public DataSet GetDiscountCards(long _dcmId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format("Select * from DiscountCardPrintViews");

                  
                    da = new SqlDataAdapter(sql, conn);
                    DataSet dsCards = new DataSet();
                    da.Fill(dsCards, "dtDiscountCard");
                    return dsCards;

                   

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public void UpdateCardStatus(DiscountCard _dcard)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_dcard).State = EntityState.Modified; ;
                entities.SaveChanges();
            }
        }

        public VMDiscountCard GetDiscountCard(string _discCradNo, DateTime _todaysDate)
        {
            using (DBEntities entities = new DBEntities())
            {
               
                  return entities.Database.SqlQuery<VMDiscountCard>(@"SELECT dbo.DiscountCardMasters.DCMId, dbo.DiscountCardMasters.DoctorId,dbo.DiscountCardMasters.ExpireDate, 
                                                                     dbo.DiscountCards.CardId, dbo.DiscountCards.CardNo, dbo.DiscountCardMasters.CardTypeId 
                                                                     FROM dbo.DiscountCardMasters 
                                                                     INNER JOIN dbo.DiscountCards ON dbo.DiscountCardMasters.DCMId = dbo.DiscountCards.DCMId WHERE (dbo.DiscountCards.CardNo = @CardNo and dbo.DiscountCardMasters.ExpireDate < @todaysDate)", new SqlParameter("@CardNo", _discCradNo),new SqlParameter("@todaysDate", _todaysDate)).FirstOrDefault();
              
            }
        }

        public void DeleteExistingDiscountCard()
        {
            using (SqlConnection con = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format("Delete from DiscountCardPrintViews");
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }catch(Exception ex)
                {

                }
            }
        }

        public void SaveDiscountCardPrintPreview(List<DiscountCardPrintView> _ppList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.DiscountCardPrintViews.AddRange(_ppList);
                entities.SaveChanges();
            }
        }

        public OrganizationInfo GetOrganizationById(int orgId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OrganizationInfos.Where(x => x.OrgId == orgId).FirstOrDefault();
            }
        }

        public CompanyInfo GetCompanyById(int cId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CompanyInfos.Where(x => x.CompanyId == cId).FirstOrDefault();
            }
        }

        public CompanyInfo GetCompanyById()
        {
            throw new NotImplementedException();
        }

        public List<BusinessUnit> GetbusinessUnit()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BusinessUnits.ToList();

            }
        }

        public List<OrganizationInfo> GetOrganizationList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OrganizationInfos.ToList();

            }
        }

        public bool SaveOrganizeInfo(OrganizationInfo oInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.OrganizationInfos.Add(oInfo);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<CompanyInfo> GetCompany()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CompanyInfos.ToList();

            }
        }

        public List<Department> GetAllDepartment()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Departments.ToList();

            }

        }
    }
}
