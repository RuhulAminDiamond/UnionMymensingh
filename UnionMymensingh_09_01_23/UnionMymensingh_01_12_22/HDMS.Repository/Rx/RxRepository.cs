using HDMS.Common.Utils;
using HDMS.Model.Rx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Rx.VModel;
using HDMS.Model.ViewModel;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using System.Data.Entity.Migrations;
using HDMS.Model.Common;
using HDMS.Models.Pharmacy;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model;

namespace HDMS.Repository.Rx
{
    public class RxRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

      

        public List<RxCpDosage> GetDosages(int CpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosages.Where(x=>x.CpId== CpId).ToList();
            }
        }

        public List<RxDuration> GetRxDuration()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDurations.ToList();
            }
        }

      

        public bool SaveDiagnosis(RxDiagnosis _listrxDiagnosis)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxDiagnosises.Add(_listrxDiagnosis);
                entities.SaveChanges();
                return true;
            }
        }

        public List<RxCPAdvice> GetAdvicesByCP(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.RxCPAdvices.Where(x=>x.CPId == cPId || x.CPId==0).ToList();
              
            }
        }

        public bool SaveDosages(RxCpDosage _rxD)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCpDosages.Add(_rxD);
                entities.SaveChanges();
                return true;
            }
        }

        public List<RxCPPreferredTest> GetRxCpPreferredTestlist(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.RxCPPreferredTests.Where(x=>x.CPId== cPId).ToList();
            }
        }

        public bool UpdateCDbDosages(RxDosage rxD)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(rxD).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMGenericWithDefaultDose> GetDefaultDoseWithGeneric()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMGenericWithDefaultDose>(@"Select gp.GroupId , m.GenericId,m.DoseId,gp.Name as GroupName, g.Name as GenericName, d.DoseBnLong as Dose,m.DefaultDuration, m.DDUnit, m.Qty   from RxCpDosageWithGenericMappings m join Generics g on m.GenericId=g.GenericId join PhProductGroups gp on gp.GroupId = g.GroupId join RxCpDosages d
                on m.DoseId=d.DoseId").ToList();
            }
        }

        public RxCarryOnBlock GetRxCarryOnBlocks(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCarryOnBlocks.Where(x=>x.CPId== cPId).FirstOrDefault();

            }
        }

        public IList<RxDosage> GetRxCDbAllDosage()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.RxDosages.ToList();
               
            }
        }

        public bool UpdateDosages(RxCpDosage rxD)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(rxD).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public bool SetDoseAsDefaultBasedOnGenAndFormation(Generic gen, Formation form, RxDosage rxDosage)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Database.ExecuteSqlCommand("Update PhProductInfoes Set DoseId = {0} Where GenericId={1} and FormationId={2} ", new object[] { rxDosage.DoseId, gen.GenericId, form.FormationId });
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveCpPersonalDoseWithGeneric(RxCpDosageWithGenericMapping mappingObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                RxCpDosageWithGenericMapping existingObj = this.GetRxCPDosagesMappingObj(mappingObj.CpId, mappingObj.GenericId, mappingObj.FormationId);
                if (existingObj != null)
                {
                    existingObj.GenericId = mappingObj.GenericId;
                    existingObj.FormationId = mappingObj.FormationId;
                    existingObj.DoseId = mappingObj.DoseId;
                    existingObj.DefaultDuration = mappingObj.DefaultDuration;
                    existingObj.DDUnit = mappingObj.DDUnit;
                    existingObj.Qty = mappingObj.Qty;
                    entities.Entry(existingObj).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    entities.RxCpDosageWithGenericMappings.Add(mappingObj);
                    entities.SaveChanges();
                    return true;
                }
            }
        }

        private RxCpDosageWithGenericMapping GetRxCPDosagesMappingObj(int cpId, int genericId, int formationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosageWithGenericMappings.Where(x => x.CpId == cpId && x.GenericId == genericId && x.FormationId== formationId).FirstOrDefault();
            }
        }

        public IList<VMPreferredTestParameter> GetPreferredTestParameterListByTestId(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter TestId = new SqlParameter("TestId", testId);
               
                return entities.Database.SqlQuery<VMPreferredTestParameter>(@"SELECT 0 as TpId,  pt.CPPTId, pt.TestId,  rd.Id AS TestDetailId, 
                         rd.TestTitle as Parameter FROM  dbo.RxCPPreferredTests pt INNER JOIN
                         dbo.ReportDefinations rd ON  pt.TestId = rd.TestId Where pt.TestId=@TestId
                         Order by rd.TestId, rd.Id", TestId).ToList();

            }
        }

        public bool SaveCDbDosages(RxDosage rxD)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxDosages.Add(rxD);
                entities.SaveChanges();
                return true;
            }
        }

        public List<RxDoseEMRInterpretation> GetEMRInterpretList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDoseEMRInterpretations.ToList();
              
            }
        }

        public bool SaveDrug(List<RxDrug> _listrxDrugs)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxDrugs.AddRange(_listrxDrugs);
                entities.SaveChanges();
                return true;
            }
        }

        public void DeleteAccessPermissionItem(int userId, string option)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxCpSupportUserAccessOptions Where SupportUserId={0} and AccessOption={1}", new object[] { userId, option });

            }
        }

        public async Task<List<RxDosage>> GetRxCDbDosageList()
        {
            using (DBEntities entities = new DBEntities())
            {
               return await entities.RxDosages.ToListAsync();
            }
        }

        public bool UpdateAdvices(RxCPAdvice adv)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(adv).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public IList<RxCpDosage> GetRxCPDosages(int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosages.Where(x => x.CpId == cpId).ToList();
            }
        }

        public List<RxDoseApplication> GetRxDoseApplication()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDoseApplications.ToList();
            }
        }

        public IList<RxCPPreferredTest> GetRxCpAllPreferredTests(int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPPreferredTests.Where(x=>x.CPId== cpId).ToList();
            }
        }

        public IList<RxCPAdvice> GetRxCPAdvices(int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPAdvices.SqlQuery("Select * from RxCPAdvices Where CpId={0}", cpId).ToList();
            }
        }

        public bool SaveCPPreferredDrugs(RxCPPreferredMedicine preferredMedicine)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPPreferredMedicines.Add(preferredMedicine);
                entities.SaveChanges();
                return true;
            }
        }

        public void DeleteAdviceFromCpPersonalDb(RxCPAdvice selectedItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxCPAdvices where RxCpAdvId = {0}", new object[] { selectedItem.RxCpAdvId });
            }
        }

        public List<VMCPPreferredMedicine> GetCpPreferredMedicine(int cPId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"SELECT pm.CPPMId, pm.CPId, pm.ProductId,pm.BrandName, pm.BrandShortName, IsNull(pm.DoseShortEn,'') DoseShortEn, IsNull(pm.DoseShortBn,'') DoseShortBn, 
                            IsNull(pm.DoseLongEn,'') DoseLongEn, IsNull(pm.DoseLongBn,'') DoseLongBn, IsNull(pm.BeforeAfterEn,'') BeforeAfterEn, IsNull(pm.BeforeAfterBn,'') BeforeAfterBn, IsNull(pm.Duration,'') Duration, 
                            IsNull(pm.DurationUnit,'') DurationUnit,pm.Qty 
                            FROM dbo.RxCPPreferredMedicines pm Left JOIN
                            dbo.PhProductInfoes ON pm.ProductId = dbo.PhProductInfoes.ProductId
						    Where pm.CPId={0}", cPId);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMCPPreferredMedicine> listTItems = new List<VMCPPreferredMedicine>();


                    listTItems = new List<VMCPPreferredMedicine>(
                        (from dRow in dt.AsEnumerable()
                         select (GetRxCPDrugTemplateDataTableRow(dRow)))
                        );

                    return listTItems;

                }
                catch (Exception ex)
                {
                    return new List<VMCPPreferredMedicine>();
                }

            }
        }

        public List<RxPrintFormatTemplate> GetRxPrintFormatTemplates()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxPrintFormatTemplates.ToList();
            }
        }

        public RxCpDosage GetRxCPDosageByDoseId(int doseId)
        {

            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosages.Where(x=>x.DoseId== doseId).FirstOrDefault();
            }
        }

        public List<TitleOrNamePrefix> GetTitleStrings()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.TitleOrNamePrefixes.ToList();
            }
        }

        public void SaveRxCpPreferredTestInPersonalDb(RxCPPreferredTest pt)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPPreferredTests.Add(pt);
                entities.SaveChanges();
            }
        }

        public void DeleteTestFromCpPersonalDb(RxCPPreferredTest selectedItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxCPPreferredTests where CPPTId = {0}", new object[] { selectedItem.CPPTId });
            }
        }

        public void InsertOrUpdateRxCpPrintPageSetup(RxCPPrintPageSetup ps)
        {
            using (DBEntities entities = new DBEntities())
            {
                RxCPPrintPageSetup _psetup = this.GetRxCPPrintPageSetup(ps.CpId, ps.PageType);
                if (_psetup == null)
                {
                    entities.RxCPPrintPageSetups.Add(ps);
                    entities.SaveChanges();
                }
                else
                {
                    _psetup.PageType = ps.PageType;
                    _psetup.PageOrientation = ps.PageOrientation;
                    _psetup.TopMargin = ps.TopMargin;
                    _psetup.RightMargin = ps.RightMargin;
                    _psetup.BottomMargin = ps.BottomMargin;
                    _psetup.LeftMargin = ps.LeftMargin;
                    _psetup.footerText = "";
                    _psetup.headretext = "";

                    entities.Entry(_psetup).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        public async Task<List<RxCPPrintPageSetup>> GetRxCPPageSetup(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxCPPrintPageSetups.Where(x => x.CpId == cPId).ToListAsync();
            }
        }

        private RxCPPrintPageSetup GetRxCPPrintPageSetup(int cpId, string pageType)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPPrintPageSetups.Where(x=>x.CpId== cpId && x.PageType== pageType).FirstOrDefault();
            }
        }

        public List<RxCpSupportUserAccessOption> GetCpAssistAccessOptionsList(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpSupportUserAccessOptions.Where(x => x.SupportUserId == userId).ToList();
            }
        }

        public List<MedicineInterX> LoadMedicineInterXs()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MedicineInterXes.ToList();
            }
        }

        private VMCPPreferredMedicine GetRxCPDrugTemplateDataTableRow(DataRow dr)
        {
            VMCPPreferredMedicine Obj = new VMCPPreferredMedicine();
            Obj.CPPMId = Convert.ToInt64(dr["CPPMId"]);
            Obj.CPId = Convert.ToInt32(dr["CPId"]);
            Obj.ProductId = Convert.ToInt32(dr["ProductId"]);
            Obj.BrandName = dr["BrandName"].ToString();
            Obj.BrandShortName= dr["BrandShortName"].ToString();
            Obj.DoseShortEn = dr["DoseShortEn"].ToString();
            Obj.DoseShortBn = dr["DoseShortBn"].ToString();
            Obj.DoseLongEn = dr["DoseLongEn"].ToString();
            Obj.DoseLongBn = dr["DoseLongBn"].ToString();
            Obj.BeforeAfterEn = dr["BeforeAfterEn"].ToString();
            Obj.BeforeAfterBn = dr["BeforeAfterBn"].ToString();
            Obj.Duration = dr["Duration"].ToString();
            Obj.DurationUnit = dr["DurationUnit"].ToString();
            Obj.Qty= Convert.ToInt32(dr["Qty"]);
            return Obj;
        }

        public DataSet GetRxAdvicedTestsDataSet(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [spGetRxAdvicedTests] {0},{1}", rxVisitId, cpId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtAdvicedTests";
               
                return dsReports;
            }

        }

        public DataSet GetRxFullDataSet(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [spGetRxFullData] {0},{1}", rxVisitId, cpId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtHistory";
                dsReports.Tables[2].TableName = "dtRxBody";
                //dsReports.Tables[3].TableName = "dtRxAdvice";

                return dsReports;
            }
        }

        public List<RxCPHistory> GetRxCPHistoryData(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPHistories.Where(x => x.CPId == cPId).ToList();
            }
        }

        public List<RxCPPastHistory> GetRxCPPastHistoryData(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPPastHistories.Where(x => x.CPId == cPId).ToList();
            }
        }

        public DataSet GetRxTreatmentDataSet(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [spGetRxTreatments] {0},{1}", rxVisitId, cpId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtRxBody";

                return dsReports;
            }
        }

        public List<RxCPOtherFinding> GetRxCPOtherFindingData(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPOtherFindings.Where(x => x.CPId == cPId).ToList();
            }
        }

        public RxCPPreferredMedicine GetRxPreferredMedicine(int productId, int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPPreferredMedicines.Where(x=>x.CPId== cPId && x.ProductId== productId).FirstOrDefault();
            }
        }

        public IList<RxCpDosage> GetAllDosage()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.RxCpDosages.ToList();
            }
        }

        public async Task<RxPatientMasterData> GetRxMasterDataAsync(long regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxPatientMasterDatas.Where(x=>x.RegNo== regNo).FirstOrDefaultAsync();
            }
        }

        public async Task<List<RxVMPatientBasicInfo>> GetRxPatientListAsync(DateTime frmdate, DateTime todate, int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter CpId = new SqlParameter("CpId", cpId);
                SqlParameter datefrm = new SqlParameter("datefrm", frmdate);
                SqlParameter dateto = new SqlParameter("dateto", todate);
                return await entities.Database.SqlQuery<RxVMPatientBasicInfo>(@"With CteVh as (
                                         select vh.* from RxVisitHistories vh
                                         where vh.RxVisitId = (select max(t2.RxVisitId) 
                                         from RxVisitHistories   t2
                                         where t2.RxPMId=vh.RxPMId
                                      ))

                                     SELECT  pm.RegNo,vh.RxVisitId,vh.VisitDate, rr.FullName Name, rr.MobileNo, IsNull(rr.Address,'') Address,
                                       CASE WHEN vh.AgeYear <> '' THEN vh.AgeYear + 'Y ' ELSE vh.AgeYear END + CASE WHEN vh.AgeMonth <> '' THEN 
	                                   vh.AgeMonth + 'M ' ELSE vh.AgeMonth END + CASE WHEN vh.AgeDay <> '' THEN vh.AgeDay + 'D' ELSE vh.AgeDay END AS Age, rr.Sex
                                       FROM dbo.RxPatientMasterDatas pm INNER JOIN
                                       dbo.RegRecords rr ON pm.RegNo = rr.RegNo inner join  CteVh vh on 
			                           vh.RxPMId=pm.RxPMId WHERE (vh.CpId=@CpId  and   pm.RxMasterDataDate BETWEEN @datefrm AND @dateto)", CpId, datefrm, dateto).ToListAsync();

            }
        }

        public async Task<RxVisitHistory> GetLastRxVisitHistoryAsync(long rxPMId, int _cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxVisitHistories.SqlQuery("Select * from RxVisitHistories Where RxVisitId=(Select Max(RxVisitId) from RxVisitHistories Where RxPMId={0} and CpId={1})", rxPMId, _cpId).FirstOrDefaultAsync();
            }
        }

        public void AccumulatePrescriptionData(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec spAccumulatePrescriptionData {0},{1}", rxVisitId, cpId);
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

        public void SavePrintPreference(RxPrintPreference _printPref)
        {
            using (DBEntities entities = new DBEntities())
            {
                RxPrintPreference _pref = this.GetRxPrintPreference(_printPref.CPId);
                if (_pref == null)
                {
                    entities.RxPrintPreferences.Add(_printPref);
                    entities.SaveChanges();
                }
                else
                {
                    _pref.ChiefComplains = _printPref.ChiefComplains;
                    _pref.ChiefComplainsWithHistory = _printPref.ChiefComplainsWithHistory;
                    _pref.BP = _printPref.BP;
                    _pref.Pulse = _printPref.Pulse;
                    _pref.Weight = _printPref.Weight;
                    _pref.PhysicalExam = _printPref.PhysicalExam;
                    _pref.Investigations = _printPref.Investigations;
                    _pref.Treatment = _printPref.Treatment;
                    _pref.PrintFormat1 = _printPref.PrintFormat1;
                    _pref.PrintFormat2= _printPref.PrintFormat2;
                    _pref.PrintFormat3 = _printPref.PrintFormat3;
                    _pref.PrintFormat4 = _printPref.PrintFormat4;
                    _pref.PrintFormat5 = _printPref.PrintFormat5;
                    _pref.PrintFormat6 = _printPref.PrintFormat6;
                    _pref.PrintFormat7 = _printPref.PrintFormat7;
                    _pref.PrintFormat8 = _printPref.PrintFormat8;
                    _pref.Diagnosis = _printPref.Diagnosis;
                  
                    entities.Entry(_pref).State = EntityState.Modified;
                    entities.SaveChanges();
                }

            }
        }

        public void InsertOrUpdateCpAssistantAccessPermission(List<RxCpSupportUserAccessOption> optlist)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (var item in optlist)
                {
                    RxCpSupportUserAccessOption _acObj = this.GetCpAssistantIndividualAccessObj(item.SupportUserId,item.AccessOption);
                    if (_acObj == null)
                    {
                        entities.RxCpSupportUserAccessOptions.Add(item);
                        entities.SaveChanges();
                    }
                    else
                    {

                    }
                }
            }
        }

        private RxCpSupportUserAccessOption GetCpAssistantIndividualAccessObj(int supportUserId, string accessOption)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpSupportUserAccessOptions.Where(x => x.SupportUserId == supportUserId && x.AccessOption == accessOption).FirstOrDefault();
            }
        }

        public List<RxCpSupportUserAccessOption> GetCpAssistAccessOptions(int userId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpSupportUserAccessOptions.Where(x => x.SupportUserId == userId).ToList();
            }
        }

        public RxPrintPreference GetRxPrintPreference(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxPrintPreferences.Where(x => x.CPId == cPId).FirstOrDefault();
            }
        }

        public void DeleteDrugFromCpPersonalDb(VMCPPreferredMedicine selectedItem)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.RxCPPreferredMedicines.RemoveRange(entities.RxCPPreferredMedicines.Where(x=>x.CPId== selectedItem.CPId && x.CPPMId== selectedItem.CPPMId));
                entities.SaveChanges();
            }
        }

      
        public bool AddAdvices(RxCPAdvice _adv)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPAdvices.Add(_adv);
                entities.SaveChanges();
                return true;
            }
        }

       

        public IList<RxCPTestTemplateMaster> GetRxTestTemplateItems(string _type)
        {
            int _cpId = 0;
            int.TryParse(_type, out _cpId);

              using (DBEntities entities = new DBEntities())
                {
                    return entities.RxCPTestTemplateMasters.Where(x => x.CPId == _cpId).ToList();
                }
       
        }

        public List<RxCpDosage> GetRxDosageList(int CpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosages.Where(x=>x.CpId== CpId).ToList();
            }
        }

        public bool SaveRxTestTemplateMaster(RxCPTestTemplateMaster _templateMaster)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPTestTemplateMasters.Add(_templateMaster);
                entities.SaveChanges();
                return true;
            }
        }

       

        public void SaveRxTestTemplateDetail(List<RxCPTestTemplateDetail> _tdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPTestTemplateDetails.AddRange(_tdList);
                entities.SaveChanges();
              
            }
        }

        public bool DeleteExistingTreatment(VMIPDInfo _IpdInfo)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Delete from TreatmentOnDischarges Where AdmissionId={0}", _IpdInfo.AdmissionId);
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public RxPersonalPreferenceSetting GetRxPersonalPrefernce(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.RxPersonalPreferenceSettings.Where(x=>x.CpId== cPId).FirstOrDefault();
            }
        }

        public bool UpdateRxPersonalPreference(RxPersonalPreferenceSetting ps)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(ps).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveRxPersonalPreference(RxPersonalPreferenceSetting ps)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxPersonalPreferenceSettings.Add(ps);
                entities.SaveChanges();
                return true;
            }
        }

        public void AccumulatePrescriptionDataVer2(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec spAccumulatePrescriptionDataVer2 {0},{1}", rxVisitId, cpId);
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

        public void SaveIPDTreatmentOnDischarge(List<TreatmentOnDischarge> _treatmentList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.TreatmentOnDischarges.AddRange(_treatmentList);
                entities.SaveChanges();
            }
        }

        public DataSet GetRxFullDataSetVer2(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [spGetRxFullData_2] {0},{1}", rxVisitId, cpId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtHistory";
                dsReports.Tables[2].TableName = "dtRxBody";
                dsReports.Tables[3].TableName = "dtRxAdvice";

                return dsReports;
            }
        }

        public List<SelectedTestItemsForPatient> GetRxTestTemplateItem(long templateId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"SELECT dbo.RxTestTemplateDetails.TemplateId, dbo.RxTestTemplateDetails.TestId, dbo.TestItems.Name
                                            FROM  dbo.RxTestTemplateDetails INNER JOIN
                                           dbo.TestItems ON dbo.RxTestTemplateDetails.TestId = dbo.TestItems.TestId Where dbo.RxTestTemplateDetails.TemplateId={0}", templateId);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<SelectedTestItemsForPatient> listTItems = new List<SelectedTestItemsForPatient>();


                    listTItems = new List<SelectedTestItemsForPatient>(
                        (from dRow in dt.AsEnumerable()
                         select (GetRxTestTemplateDataTableRow(dRow)))
                        );

                    return listTItems;

                }
                catch (Exception ex)
                {
                    return new List<SelectedTestItemsForPatient>();
                }

            }
        }

        private SelectedTestItemsForPatient GetRxTestTemplateDataTableRow(DataRow dr)
        {
            SelectedTestItemsForPatient _testTemplate = new SelectedTestItemsForPatient();
            _testTemplate.Id = Convert.ToInt32(dr["TestId"]);
            _testTemplate.Name = dr["Name"].ToString();

            return _testTemplate;
        }

      

        public bool UpdateDiagnosis(RxDiagnosis _diagnosis)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_diagnosis).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public bool DeleteRxDrug(RxSelectedMedicineForPatient selectedItem, long rxVhId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Database.ExecuteSqlCommand("Delete from RxDrugs Where RxVisitId = {0} and ProductId={1} and CPPMId={2}", new object[] { rxVhId, selectedItem.ProductId, selectedItem.CPPMId });
                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public List<RxTest> GetRxTestsByRxId(long _RxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxTests.Where(x => x.RxVisitId == _RxVisitId).ToList();
            }
        }

        public List<TreatmentOnDischarge> GetTreatmentOnDischarge(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TreatmentOnDischarges.Where(x => x.AdmissionId == admissionId).ToList();
            }
        }

        public List<RxDiagnosis> GetRxDiagnosisList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDiagnosises.ToList();

            }
        }

       

        public System.Data.DataSet GetRxReportData(long _RxId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT RxId, PatientName,Age, Sex, RxDate, MobileNo, MaritalStatus, RegNo, 
                                      Diagnosis,OperateBy,  dosage, duration,  DrugName,TestName
                                      FROM VWRxDetails Where (RxId = {0}); SELECT dbo.RxTests.Id, dbo.RxTests.RxId, dbo.RxTests.TestId, dbo.TestItems.Name AS TestName
                                      FROM  dbo.RxTests INNER JOIN
                                      dbo.TestItems ON dbo.RxTests.TestId = dbo.TestItems.TestId
                                      WHERE (dbo.RxTests.RxId = {0})
                                      ORDER BY dbo.RxTests.Id; SELECT dbo.RxAdvices.Advice as AdviceName 
                                      FROM dbo.RxAdviceToPatients INNER JOIN
                                      dbo.RxAdvices ON dbo.RxAdviceToPatients.AdviceId = dbo.RxAdvices.Id
                                      WHERE (dbo.RxAdviceToPatients.RxId = {0}) order by dbo.RxAdviceToPatients.Id", _RxId);


                da = new SqlDataAdapter(sql, conn);

               
                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtTests";
                dsReports.Tables[2].TableName = "dtAdvices";
                return dsReports;
            }

        }

        public bool SaveOrUpdateRxPrintFormatTemplate(RxPrintFormatTemplate pfTemplate)
        {
            using (DBEntities entities = new DBEntities())
            {

                RxPrintFormatTemplate _template = entities.RxPrintFormatTemplates.Where(x => x.PrintFormat == pfTemplate.PrintFormat).FirstOrDefault();

                if (_template == null)
                {
                    entities.RxPrintFormatTemplates.Add(pfTemplate);
                    entities.SaveChanges();
                    return true;
                }
                else
                {

                }
               


                return false;
            }
        }

        public void SaveRxCPTreatmentTemplateDetailData(List<RxCPDrugTemplateDetail> ttdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDrugTemplateDetails.AddRange(ttdList);
                entities.SaveChanges();

            }
        }

        public List<RxCPDrugTemplateMaster> GetRxDrugMasterTemplateList(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPDrugTemplateMasters.Where(x=>x.CPId== cPId).ToList();
            }
        }

        public void SetDoseAsDefault(VMPhProductListForRxPerspective phprod, RxDosage item)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Database.ExecuteSqlCommand("Update PhProductInfoes Set DoseId = {0} Where GenericId={1} and FormationId={2} ", new object[] { item.DoseId, phprod.GenericId, phprod.FormationId });
            }
        }

        public void AccumulatePrescriptionDataVer3(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Exec spAccumulatePrescriptionDataVer3 {0},{1}", rxVisitId, cpId);
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

        public DataSet GetRxFullDataSetForPrintV3(long rxVisitId, int cpId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {


                sql = string.Format(@"EXEC [spGetRxFullData_3] {0},{1}", rxVisitId, cpId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtRxData"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtHistory";
                dsReports.Tables[2].TableName = "dtRxBody";
                dsReports.Tables[3].TableName = "dtRxAdvice";
                dsReports.Tables[4].TableName = "dtAdvicedTests";
                dsReports.Tables[5].TableName = "dtRxFollowUpComments";
                return dsReports;
            }
        }
    

        public void SaveOrUpdateCarryOnBlocks(RxCarryOnBlock cob)
        {
            using (DBEntities entities = new DBEntities())
            {
                RxCarryOnBlock cb = this.GetRxCarryOnBlocks(cob.CPId);
                if (cb == null)
                {
                    entities.RxCarryOnBlocks.Add(cob);
                    entities.SaveChanges();
                }
                else
                {
                    cb.ChiefComplains = cob.ChiefComplains;
                    cb.History = cob.History;
                    cb.Additional = cob.Additional;
                    cb.PhysicalFindings = cob.PhysicalFindings;
                    cb.OtherFindings = cob.OtherFindings;
                    cb.DrugHistory = cob.DrugHistory;
                    cb.Treatment = cob.Treatment;
                    cb.Advices = cob.Advices;
                    cb.Tests = cob.Tests;
                    cb.Diagnosis = cob.Diagnosis;
                    cb.Dx = cob.Dx;
                    entities.Entry(cb).State=EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        public RxCpDosageWithGenericMapping GetRxCpDosageWithGenericMapping(ChamberPractitioner chamberPractitioner, int genericId, int formationId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.RxCpDosageWithGenericMappings.Where(x=>x.CpId== chamberPractitioner.CPId && x.GenericId== genericId && x.FormationId== formationId).FirstOrDefault();
               
            }
        }

        public async Task<List<RxVMPatientBasicInfo>> GetRxWaitingPatientListAsync(DateTime dtfrm, DateTime dtto, int cpId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter CpId = new SqlParameter("CpId", cpId);
                SqlParameter datefrm = new SqlParameter("datefrm", dtfrm.Date);
                SqlParameter dateto = new SqlParameter("dateto", dtto.Date);
                return await entities.Database.SqlQuery<RxVMPatientBasicInfo>(@"With CteVh as (
                                         select vh.* from RxVisitHistories vh
                                         where vh.RxVisitId = (select max(t2.RxVisitId) 
                                         from RxVisitHistories   t2
                                         where t2.RxPMId=vh.RxPMId
                                      ))

                                     SELECT  pm.RegNo,vh.RxVisitId,vh.VisitDate,vh.PSrlNo, rr.FullName Name, rr.MobileNo, IsNull(rr.Address,'') Address,
                                       CASE WHEN vh.AgeYear <> '' THEN vh.AgeYear + 'Y ' ELSE vh.AgeYear END + CASE WHEN vh.AgeMonth <> '' THEN 
	                                   vh.AgeMonth + 'M ' ELSE vh.AgeMonth END + CASE WHEN vh.AgeDay <> '' THEN vh.AgeDay + 'D' ELSE vh.AgeDay END AS Age, rr.Sex
                                       FROM dbo.RxPatientMasterDatas pm INNER JOIN
                                       dbo.RegRecords rr ON pm.RegNo = rr.RegNo inner join  CteVh vh on 
			                           vh.RxPMId=pm.RxPMId WHERE (vh.CpId=@CpId  and vh.VisitDate BETWEEN @datefrm AND @dateto and vh.IsServiceCompleted=0)", CpId, datefrm, dateto).ToListAsync();

            }
        }

        public void SaveRxCPAdviceTemplateDetailData(List<RxCpAdviceTemplateDetail> advtdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCpAdviceTemplateDetails.AddRange(advtdList);
                entities.SaveChanges();
            }
        }

        public RxCpDosage GetRxCPDosagesByGeneric(ChamberPractitioner prac, int genericId, int formationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpDosages.SqlQuery(@"Select * from RxCpDosages Where DoseId=(Select Top 1 DoseId from RxCpDosageWithGenericMappings Where CpId={0} and GenericId={1} and FormationId={2})", prac.CPId, genericId,formationId).FirstOrDefault();
               
            }
        }

        public RxVMPatientBasicInfo GetPreviousPatient(long currentVisitId, int chamberPractitionerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter CpId = new SqlParameter("CpId", chamberPractitionerId);
                SqlParameter visitId = new SqlParameter("visitId", currentVisitId);
                
                return entities.Database.SqlQuery<RxVMPatientBasicInfo>(@"With CteVh as (
                       select vh.* from RxVisitHistories vh
                           where vh.RxVisitId = (select max(t2.RxVisitId) 
                               from RxVisitHistories   t2
                                         where t2.RxPMId=vh.RxPMId
                                      ))

                                  Select * from (   SELECT  pm.RegNo,vh.RxVisitId,vh.VisitDate, rr.FullName Name, rr.MobileNo, IsNull(rr.Address,'') Address,
                                       CASE WHEN vh.AgeYear <> '' THEN vh.AgeYear + 'Y ' ELSE vh.AgeYear END + CASE WHEN vh.AgeMonth <> '' THEN 
	                                   vh.AgeMonth + 'M ' ELSE vh.AgeMonth END + CASE WHEN vh.AgeDay <> '' THEN vh.AgeDay + 'D' ELSE vh.AgeDay END AS Age, rr.Sex
                                       FROM dbo.RxPatientMasterDatas pm inner JOIN
                                       dbo.RegRecords rr ON pm.RegNo = rr.RegNo inner join  CteVh vh on 
			                           vh.RxPMId=pm.RxPMId Where vh.CpId=@CpId ) T Where T.RxVisitId=(Select Max(v.RxVisitId) from CteVh v Where v.RxVisitId<@visitId)", CpId, visitId).FirstOrDefault();

            }
        }

        public List<RxDrug> GetRxDrugByRxId(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return  entities.RxDrugs.Where(x => x.RxVisitId == rxVisitId).ToList();
            }
        }

        public async Task<RxPatientMasterData> GetRxMasterDataByPMIdAsync(long rxPMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxPatientMasterDatas.Where(x => x.RxPMId == rxPMId).FirstOrDefaultAsync();
            }
        }

        public RxVisitHistory GetRxVisitHistory(long rxIN)
        {
            using (DBEntities entities= new DBEntities())
            {
                return entities.RxVisitHistories.Where(x=>x.RxIN== rxIN).FirstOrDefault();
            }
        }

        public void DeleteRxCpSavedOtherFindings(int cpId, string selectedStr)
        {
            using (DBEntities entities = new DBEntities())
            {
                var objToDelete = entities.RxCPOtherFindings.Where(x => x.CPId == cpId && x.OtherFindingEn == selectedStr).FirstOrDefault();
                if (objToDelete != null)
                {
                    entities.RxCPOtherFindings.Remove(objToDelete);
                    entities.SaveChanges();
                }
            }
        }

        public void DeleteRxCpSavedAdditionalHistory(int cpId, string selectedStr)
        {
            using (DBEntities entities = new DBEntities())
            {
                var objToDelete = entities.RxCPPastHistories.Where(x => x.CPId == cpId && x.HistoryEn == selectedStr).FirstOrDefault();
                if (objToDelete != null)
                {
                    entities.RxCPPastHistories.Remove(objToDelete);
                    entities.SaveChanges();
                }
            }
        }

        public void DeleteRxCpSavedHistory(int cpId, string selectedStr)
        {
            using (DBEntities entities = new DBEntities())
            {
                var objToDelete = entities.RxCPHistories.Where(x => x.CPId == cpId && x.HistoryEn == selectedStr).FirstOrDefault();
                if (objToDelete != null)
                {
                    entities.RxCPHistories.Remove(objToDelete);
                    entities.SaveChanges();
                }
            }
        }

        public void DeleteRxSavedCC(int CpId, string selectedStr)
        {
            using (DBEntities entities = new DBEntities())
            {
                var objToDelete = entities.RxCpCCs.Where(x =>x.CPId== CpId && x.CCEn == selectedStr).FirstOrDefault();
                if (objToDelete != null)
                {
                    entities.RxCpCCs.Remove(objToDelete);
                    entities.SaveChanges();
                }
            }
        }
        public RxVMPatientBasicInfo GetLastPatient(long currentVisitId, int chamberPractitionerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter CpId = new SqlParameter("CpId", chamberPractitionerId);
                SqlParameter visitId = new SqlParameter("visitId", currentVisitId);

                return entities.Database.SqlQuery<RxVMPatientBasicInfo>(@"With CteVh as (
                       select vh.* from RxVisitHistories vh
                           where vh.RxVisitId = (select max(t2.RxVisitId) 
                               from RxVisitHistories   t2
                                         where t2.RxPMId=vh.RxPMId
                                      ))

                                  Select * from (   SELECT  pm.RegNo,vh.RxVisitId,vh.VisitDate, rr.FullName Name, rr.MobileNo, IsNull(rr.Address,'') Address,
                                       CASE WHEN vh.AgeYear <> '' THEN vh.AgeYear + 'Y ' ELSE vh.AgeYear END + CASE WHEN vh.AgeMonth <> '' THEN 
	                                   vh.AgeMonth + 'M ' ELSE vh.AgeMonth END + CASE WHEN vh.AgeDay <> '' THEN vh.AgeDay + 'D' ELSE vh.AgeDay END AS Age, rr.Sex
                                       FROM dbo.RxPatientMasterDatas pm inner JOIN
                                       dbo.RegRecords rr ON pm.RegNo = rr.RegNo inner join  CteVh vh on 
			                           vh.RxPMId=pm.RxPMId Where vh.CpId=@CpId ) T Where T.RxVisitId=(Select Max(v.RxVisitId) from CteVh v)", CpId).FirstOrDefault();

            }
        }

        public RxVMPatientBasicInfo GetNextPatient(long currentVisitId, int chamberPractitionerId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter CpId = new SqlParameter("CpId", chamberPractitionerId);
                SqlParameter visitId = new SqlParameter("visitId", currentVisitId);

                return entities.Database.SqlQuery<RxVMPatientBasicInfo>(@"With CteVh as (
                       select vh.* from RxVisitHistories vh
                           where vh.RxVisitId = (select max(t2.RxVisitId) 
                               from RxVisitHistories   t2
                                         where t2.RxPMId=vh.RxPMId
                                      ))

                                  Select * from (   SELECT  pm.RegNo,vh.RxVisitId,vh.VisitDate, rr.FullName Name, rr.MobileNo, IsNull(rr.Address,'') Address,
                                       CASE WHEN vh.AgeYear <> '' THEN vh.AgeYear + 'Y ' ELSE vh.AgeYear END + CASE WHEN vh.AgeMonth <> '' THEN 
	                                   vh.AgeMonth + 'M ' ELSE vh.AgeMonth END + CASE WHEN vh.AgeDay <> '' THEN vh.AgeDay + 'D' ELSE vh.AgeDay END AS Age, rr.Sex
                                       FROM dbo.RxPatientMasterDatas pm inner JOIN
                                       dbo.RegRecords rr ON pm.RegNo = rr.RegNo inner join  CteVh vh on 
			                           vh.RxPMId=pm.RxPMId Where vh.CpId=@CpId ) T Where T.RxVisitId=(Select Min(v.RxVisitId) from CteVh v Where v.RxVisitId>@visitId)", CpId, visitId).FirstOrDefault();

            }
        }

        public void SaveRxCpTestTemplateMaster(RxCPTestTemplateMaster ttm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPTestTemplateMasters.Add(ttm);
                entities.SaveChanges();
            }
        }

        public void SaveRxCPTestTemplateDetailData(List<RxCPTestTemplateDetail> ttdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPTestTemplateDetails.AddRange(ttdList);
                entities.SaveChanges();
            }
        }

       

        public async Task<List<RxSelectedMedicineForPatient>> GetRxCpTreatmentTemplateData(long templateId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", templateId);
                return await entities.Database.SqlQuery<RxSelectedMedicineForPatient>(@"Select T.ProductId,T.CPPMId,T.BrandName,T.Dosage,T.Duration,T.Qty from (
                        SELECT tm.TemplateId, td.ProductId, td.CPPMId, f.ShortFormation+' '+ pm.BrandName as BrandName, td.Dosage, td.Duration, td.Qty, 0 AS doseId
                         FROM dbo.RxCPDrugTemplateMasters AS tm INNER JOIN
                         dbo.RxCPDrugTemplateDetails AS td ON tm.TemplateId = td.TemplateId INNER JOIN
                         dbo.PhProductInfoes AS pm ON td.ProductId = pm.ProductId join Formations f
						 on pm.FormationId = f.FormationId
                         
                         Union All

                         SELECT tm.TemplateId, td.ProductId, td.CPPMId, pm.BrandName, td.Dosage, td.Duration, td.Qty, 0 AS doseId
                         FROM dbo.RxCPDrugTemplateMasters AS tm INNER JOIN
                         dbo.RxCPDrugTemplateDetails AS td ON tm.TemplateId = td.TemplateId INNER JOIN
                         dbo.RxCPPreferredMedicines AS pm ON td.CPPMId = pm.CPPMId
                         ) T Where T.TemplateId = @parameter", parameter).ToListAsync();

            }
        }


        public  async Task<IList<RxVMTestTemplate>> GetRxCpTestTemplateData(long templateId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", templateId);
                return await entities.Database.SqlQuery<RxVMTestTemplate>(@"SELECT   TRY_PARSE('0' AS bigint) AS RxVisitId, ttd.CPPTId, dbo.TestItems.TestId, dbo.TestItems.Name AS Name
                                                FROM  dbo.RxCPTestTemplateMasters AS ttm INNER JOIN
                                                dbo.RxCPTestTemplateDetails AS ttd ON ttm.TemplateId = ttd.TemplateId inner JOIN
                                                dbo.TestItems ON ttd.TestId = dbo.TestItems.TestId
                                                WHERE (ttm.TemplateId = @parameter)", parameter).ToListAsync();

            }
        }

        public async Task<IList<SelectedAdvice>> GetRxCpAdviceTemplateData(long templateId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", templateId);
                return await entities.Database.SqlQuery<SelectedAdvice>(@"SELECT atd.RxCpAdvId, atm.CPId, atd.Advice, adv.ShortKey
                                              FROM dbo.RxCpAdviceTemplateMasters AS atm INNER JOIN
                                              dbo.RxCpAdviceTemplateDetails AS atd ON atm.TemplateId = atd.TemplateId INNER JOIN
                                              dbo.RxCPAdvices AS adv ON atd.RxCpAdvId = adv.RxCpAdvId
                                              WHERE (atm.TemplateId  = @parameter)", parameter).ToListAsync();

            }
        }

        public List<RxCPTestTemplateMaster> GetRxTestMasterTemplateList(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPTestTemplateMasters.Where(x => x.CPId == cPId).ToList();

            }
        }

        public List<RxCpAdviceTemplateMaster> GetRxAdviceMasterTemplateList(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.RxCpAdviceTemplateMasters.Where(x=>x.CPId== cPId).ToList();
              
            }
        }

        public void SaveRxCpAdviceTemplateMaster(RxCpAdviceTemplateMaster advtm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCpAdviceTemplateMasters.Add(advtm);
                entities.SaveChanges();

            }
        }

        public void SaveRxCpDrugTemplateMaster(RxCPDrugTemplateMaster ttm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDrugTemplateMasters.Add(ttm);
                entities.SaveChanges();

            }
        }

        public async Task<RxCPDiseaseTemplateHistoricalData> GetRxCPDiseaseTemplateHistoricalData(long dTId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return await  entities.RxCPDiseaseTemplateHistoricalDatas.Where(x=>x.DTId== dTId).FirstOrDefaultAsync();
               
            }
        }

        public async Task<List<RxSelectedMedicineForPatient>> GetRxCPDiseaseTemplateTreatmentDataAsync(long dTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", dTId);
                return await entities.Database.SqlQuery<RxSelectedMedicineForPatient>(@"Select T.ProductId, T.GenericId, T.CPPMId,T.BrandName,T.dosage,T.duration,T.Qty,T.doseId from (
                                                  Select d.DTId, d.ProductId, pm.GenericId, d.CPPMId,d.BrandName,d.dosage,d.duration,d.Qty,pm.DoseId as doseId from RxCPDiseaseTemplateTreatmentDatas d join PhProductInfoes pm 
                                                  on d.ProductId=pm.ProductId
                                                 
                                                  Union All

                                                   Select d.DTId, d.ProductId, 0 as GenericId, d.CPPMId,d.BrandName,d.dosage,d.duration,d.Qty,0 as doseId from RxCPDiseaseTemplateTreatmentDatas d join RxCPPreferredMedicines pm 
                                                   on d.CPPMId=pm.CPPMId) T Where T.DTId=@parameter", parameter).ToListAsync();

            }
        }

        public void DeleteRxTest(RxVMTestTemplate selectedItem, long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxTests where RxVisitId = {0} and CPPTId={1}", new object[] { rxVisitId, selectedItem.CPPTId });
            }
        }

        public void DeleteRxAdvice(SelectedAdvice objToRemove, long rxvisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxAdviceToPatients where RxVisitId = {0} and RxCpAdvId={1}", new object[] { rxvisitId, objToRemove.RxCpAdvId });
            }
        }

        public void DeleteExistingRxTreatmentData(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxDrugs where RxVisitId = {0}", new object[] { rxVisitId });
            }
        }

        public void DeleteExistingRxAdviceData(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxAdviceToPatients where RxVisitId = {0}", new object[] { rxVisitId });
            }
        }

        public void DeleteExistingRxTestData(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Delete from RxTests where RxVisitId = {0}", new object[] { rxVisitId });
            }
        }

        public async Task<RxVisitHistory> GetRxPreviousVisit(long rxPMId, int visitNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxVisitHistories.Where(x => x.RxPMId == rxPMId && x.VisitNo == visitNo).FirstOrDefaultAsync();
            }
        }

        public void DeleteExistingInitialData(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                var ItemToRemove = entities.RxInitialDatas.FirstOrDefault(x => x.RxVisitId == rxVisitId);// object your want to delete
                if (ItemToRemove != null)
                {
                    entities.RxInitialDatas.Remove(ItemToRemove);
                    entities.SaveChanges();
                }
            }
        }

        public async Task<IList<SelectedAdvice>> GetRxCpDiseaseTemplateAdvicesAsync(long dTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", dTId);
                return await entities.Database.SqlQuery<SelectedAdvice>(@"Select Cast(0 as bigint) as RxVisitId ,adv.RxCpAdvId,adv.CPId, advp.Advice from RxCPDiseaseTemplateAdviceDatas advp join 
                                         RxCPAdvices adv on advp.RxCpAdvId=adv.RxCpAdvId Where DTId=@parameter", parameter).ToListAsync();
            }
        }

        public async Task<IList<RxVMTestTemplate>> GetRxCpDiseaseTemplateTestsAsync(long dTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", dTId);
                return await entities.Database.SqlQuery<RxVMTestTemplate>(@"Select * from (
                                        Select t.DTId,t.CPPTId, pt.TestId, pt.Name from RxCPDiseaseTemplateTestDatas t join TestItems pt
                                         on t.TestId=pt.TestId
                                          Union All
                                        Select t.DTId,t.CPPTId, pt.TestId, pt.TestName as Name from RxCPDiseaseTemplateTestDatas t join RxCPPreferredTests pt
                                        on t.CPPTId=pt.CPPTId) T Where T.DTId=@parameter", parameter).ToListAsync();
            }
       }

        public void SaveRxCPDiseaseTemplateAdviceData(List<RxCPDiseaseTemplateAdviceData> advList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDiseaseTemplateAdviceDatas.AddRange(advList);
                entities.SaveChanges();
            }
        }

        public void SaveRxCPDiseaseTemplateTestData(List<RxCPDiseaseTemplateTestData> testList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDiseaseTemplateTestDatas.AddRange(testList);
                entities.SaveChanges();
            }
        }

        public void SaveRxCPDiseaseTemplateTreatmentData(List<RxCPDiseaseTemplateTreatmentData> drugList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDiseaseTemplateTreatmentDatas.AddRange(drugList);
                entities.SaveChanges();
            }
        }

        public void SaveRxCPDiseaseTemplateHistoricalData(RxCPDiseaseTemplateHistoricalData hd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDiseaseTemplateHistoricalDatas.Add(hd);
                entities.SaveChanges();
            }
        }

        public void SaveRxCpDiseaseTemplate(RxCPDiseaseTemplate dp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPDiseaseTemplates.Add(dp);
                entities.SaveChanges();
            }
        }

        public async Task<List<RxCPDiseaseTemplate>> GetDiseaseTemplateListAsync(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxCPDiseaseTemplates.Where(x => x.CpId == cPId).ToListAsync();
            }
        }

        public void UpdateRxPatientPhysicalExam(RxPatientPhysicalExam _rxPhysicalExam)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_rxPhysicalExam).State = EntityState.Modified;
                entities.SaveChanges();

            }
        }

        public void SaveRxPatientMasterData(RxPatientMasterData rxpMd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxPatientMasterDatas.Add(rxpMd);
                entities.SaveChanges();
            }
        }

        public async Task<IList<RxSelectedMedicineForPatient>> GetPatientTreatmentAsync(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", rxVisitId);
                return await entities.Database.SqlQuery<RxSelectedMedicineForPatient>(@"Select T.ProductId,T.GenericId,T.CPPMId,T.BrandName,T.dosage,T.duration,T.Qty,T.doseId from (
                           Select d.RxVisitId, p.ProductId, p.GenericId, d.BrandName,0 as CPPMId,d.dosage,d.duration,d.Qty,p.DoseId as doseId from PhProductInfoes p  Left join
                           RxDrugs d on p.ProductId=d.ProductId
                           Union All
                           Select d.RxVisitId, p.ProductId,0 as GenericId, d.BrandName,p.CPPMId,d.dosage,d.duration,d.Qty,0 as doseId from RxCPPreferredMedicines p  Left join
                           RxDrugs d on p.CPPMId=d.CPPMId) T Where T.RxVisitId=@parameter", parameter).ToListAsync();
            }
        }

        public async Task<IList<SelectedAdvice>> GetSelectedAdviceAsync(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", rxVisitId);
                return await entities.Database.SqlQuery<SelectedAdvice>(@"Select advp.RxVisitId,adv.RxCpAdvId,adv.CPId, advp.Advice  from RxAdviceToPatients advp join 
                                         RxCPAdvices adv on advp.RxCpAdvId=adv.RxCpAdvId Where RxVisitId=@parameter", parameter).ToListAsync();
            }
        }

        public async Task<IList<RxVMTestTemplate>> GetPatientTestsAsync(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter parameter = new SqlParameter("parameter", rxVisitId);
                return await entities.Database.SqlQuery<RxVMTestTemplate>(@"Select * from (
                                     Select t.RxVisitId,t.CPPTId, pt.TestId, pt.Name  from RxTests t join TestItems pt
                                     on t.TestId=pt.TestId
                                   
                                     union all 

                                     Select t.RxVisitId,t.CPPTId, pt.TestId, pt.TestName as Name from RxTests t join RxCPPreferredTests pt
                                      on t.CPPTId=pt.CPPTId) T Where T.RxVisitId=@parameter", parameter).ToListAsync();
            }
        }

        public void SaveRxCpHistory(RxCPHistory history)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPHistories.Add(history);
                entities.SaveChanges();
            }
        }

        public void InsertOrUpdateRxAdviceData(List<RxAdviceToPatient> advList)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (var item in advList)
                {
                    RxAdviceToPatient advObj = this.GetRxAdviceToPatient(item.RxVisitId, item.RxCpAdvId);
                    if (advObj == null)
                    {
                        entities.RxAdviceToPatients.Add(item);
                        entities.SaveChanges();
                    }
                    else
                    {

                    }
                }
            }
        }

        private RxAdviceToPatient GetRxAdviceToPatient(long rxVisitId, int advId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.RxAdviceToPatients.Where(x=>x.RxVisitId== rxVisitId && x.RxCpAdvId == advId).FirstOrDefault();
               
            }
        }

        public void SaveRxCpOtherFindings(RxCPOtherFinding otherFindings)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPOtherFindings.Add(otherFindings);
                entities.SaveChanges();
            }
        }

        public void SaveRxCpPastHistory(RxCPPastHistory pasthistory)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCPPastHistories.Add(pasthistory);
                entities.SaveChanges();
            }
        }

        public void SaveRxVisitHistory(RxVisitHistory visit)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxVisitHistories.Add(visit);
                entities.SaveChanges();
            }
        }

       
        
       
        public List<RxVMPatientBasicInfo> GetRxPatientList(DateTime dtpfrm, DateTime dtpto)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"SELECT  dbo.RxPatientInfoes.RxId AS RxId, dbo.RxPatientInfoes.RxDate, dbo.RxPatientInfoes.VisitStatus, dbo.RxPatientInfoes.RegNo,
                                         CASE WHEN dbo.RxPatientInfoes.AgeYear <> '' THEN dbo.RxPatientInfoes.AgeYear + 'Y ' ELSE dbo.RxPatientInfoes.AgeYear END + CASE WHEN dbo.RxPatientInfoes.AgeMonth <> '' THEN dbo.RxPatientInfoes.AgeMonth
                                        + 'M ' ELSE dbo.RxPatientInfoes.AgeMonth END + CASE WHEN dbo.RxPatientInfoes.AgeDay <> '' THEN dbo.RxPatientInfoes.AgeDay + 'D' ELSE dbo.RxPatientInfoes.AgeDay END AS Age, dbo.RegRecords.FullName, dbo.RegRecords.MobileNo,dbo.RegRecords.Sex
                                      FROM    dbo.RxPatientInfoes INNER JOIN
                                      dbo.RegRecords ON dbo.RxPatientInfoes.RegNo = dbo.RegRecords.RegNo
                                       WHERE (dbo.RxPatientInfoes.RxDate BETWEEN '{0}' AND '{1}')", dtpfrm, dtpto);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<RxVMPatientBasicInfo> listTItems = new List<RxVMPatientBasicInfo>();


                    listTItems = new List<RxVMPatientBasicInfo>(
                        (from dRow in dt.AsEnumerable()
                         select (GetRxPatientDataTableRow(dRow)))
                        );

                    return listTItems;

                }catch(Exception ex)
                {
                    return new List<RxVMPatientBasicInfo>();
                }

            }
        }

        public void InsertOrUpdateRxTestData(List<RxTest> testList)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (var item in testList)
                {
                    RxTest _dr = this.GetRxTest(item.RxVisitId, item.TestId, item.CPPTId);
                    if (_dr == null)
                    {
                        entities.RxTests.Add(item);
                        entities.SaveChanges();
                    }
                    
                }
            }
        }

        private RxTest GetRxTest(long rxVisitId,int _testId, long pdbtestId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxTests.Where(x => x.RxVisitId == rxVisitId && x.TestId== _testId && x.CPPTId == pdbtestId).FirstOrDefault();
            }
        }

        public async Task<bool>  InsertOrUpdateRxDrugData(List<RxDrug> drugList)
        {
            using (DBEntities entities = new DBEntities())
            {
                foreach (var item in drugList)
                {
                    RxDrug _dr = this.GetRxDrug(item.RxVisitId,item.CPPMId,item.ProductId);
                    if (_dr == null)
                    {
                        entities.RxDrugs.Add(item);
                        entities.SaveChanges();
                    }
                    else
                    {
                        if (_dr != null)
                        {
                            entities.Entry(_dr).State = EntityState.Detached;
                        }

                        _dr.dosage = item.dosage;
                        _dr.duration = item.duration;
                        _dr.Qty = item.Qty;
                       
                        entities.Entry(_dr).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
                }
            }

            return await Task.FromResult(true);
        }

        private RxDrug GetRxDrug(long rxVisitId, long cPPMId, int ProductId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDrugs.Where(x=>x.RxVisitId== rxVisitId && x.CPPMId== cPPMId && x.ProductId== ProductId).FirstOrDefault();
               
            }
        }

        public void SaveRxCpCC(RxCpCC cc)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxCpCCs.Add(cc);
                entities.SaveChanges();
            }
        }

        public List<RxCpCC> GetRxCPCCData(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCpCCs.Where(x => x.CPId == cPId).ToList();
            }
        }

        public async void InsertOrUpdateRxInitialData(RxInitialData initialDataObj)
        {
            RxInitialData _existingDataObj = await this.GetRxInitialDataObjAsync(initialDataObj.RxVisitId);
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    if (_existingDataObj != null)
                    {
                        _existingDataObj.CC = initialDataObj.CC;
                        _existingDataObj.CCDuration = initialDataObj.CCDuration;
                        _existingDataObj.CCDurationUnit = initialDataObj.CCDurationUnit;
                        _existingDataObj.PresentHistory = initialDataObj.PresentHistory;
                        _existingDataObj.PastHistory = initialDataObj.PastHistory;
                        _existingDataObj.RxInitDUpdateDate = initialDataObj.RxInitDUpdateDate;
                        _existingDataObj.RxInitDUpdateTime = initialDataObj.RxInitDUpdateTime;
                        _existingDataObj.TreatmentPaln = initialDataObj.TreatmentPaln;
                        _existingDataObj.Prescription = initialDataObj.Prescription;
                        _existingDataObj.WeightInKg = initialDataObj.WeightInKg; 
                        _existingDataObj.Height = initialDataObj.Height; 
                        _existingDataObj.HeightUnit = initialDataObj.HeightUnit;
                        _existingDataObj.BMI = initialDataObj.BMI;
                        _existingDataObj.BpErrectTop = initialDataObj.BpErrectTop;
                        _existingDataObj.BpErrectBottom = initialDataObj.BpErrectBottom;
                        _existingDataObj.BpSupineTop = initialDataObj.BpSupineTop;
                        _existingDataObj.BpSupineBottom = initialDataObj.BpSupineBottom;
                        _existingDataObj.Pulse = initialDataObj.Pulse;
                        _existingDataObj.PulseBehaviour1 = initialDataObj.PulseBehaviour1;

                        _existingDataObj.PulseBehaviour2 = initialDataObj.PulseBehaviour2;
                        _existingDataObj.OtherFindings = initialDataObj.OtherFindings;
                        _existingDataObj.DrugHistory = initialDataObj.DrugHistory;
                        _existingDataObj.IsSketchAvailable = false;
                        _existingDataObj.Diagnosis = initialDataObj.Diagnosis;
                        _existingDataObj.Dx = initialDataObj.Dx;
                        _existingDataObj.CommentsOrReferral = initialDataObj.CommentsOrReferral;
                        _existingDataObj.FollowUpAfter = initialDataObj.FollowUpAfter;
                        _existingDataObj.Notes = initialDataObj.Notes;
                        _existingDataObj.FollowUpOn = initialDataObj.FollowUpOn;
                        _existingDataObj.ModifiedUserId = initialDataObj.ModifiedUserId;


                        entities.Entry(_existingDataObj).State = EntityState.Modified;
                        await entities.SaveChangesAsync();
                    }
                    else
                    {
                        entities.RxInitialDatas.Add(initialDataObj);
                        await entities.SaveChangesAsync();
                    }
                }catch(Exception ex)
                {

                }
            }
        
        }

        public async Task<RxInitialData> GetRxInitialDataObjAsync(long rxVisitId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RxInitialDatas.Where(x => x.RxVisitId == rxVisitId).FirstOrDefaultAsync();
            }
        }

        private RxVMPatientBasicInfo GetRxPatientDataTableRow(DataRow dr)
        {
            RxVMPatientBasicInfo obj = new RxVMPatientBasicInfo();
            obj.RegNo = Convert.ToInt64(dr["RegNo"]);
            obj.RxVisitId = Convert.ToInt64(dr["RxId"]);
            obj.Name = dr["FullName"].ToString();
            obj.Age = dr["Age"].ToString();
            obj.Sex = dr["Sex"].ToString();
          
            obj.VisitDate = Convert.ToDateTime(dr["RxDate"]);
            return obj;
        }

        public IList<RxDiagnosis> GetAllDiagnosis()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDiagnosises.ToList();
            }
        }

       

        public List<RxDrug> GetRxDrugListByRxId(long _RxId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDrugs.Where(x => x.RxVisitId == _RxId).ToList();
            }
        }

        public List<RxCPAdvice> GetAdvices()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPAdvices.ToList();
            }
        }

       

        public List<RxTest> GetRxTests(long _RxId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxTests.Where(x => x.RxVisitId == _RxId).ToList();
            }
        }

        public List<RxDrug> GetRxDrugs(long _RxId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxDrugs.Where(x => x.RxVisitId == _RxId).ToList();
            }
        }

        

        public bool SaveRxTestSaved(List<RxTest> _listRxTests)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.RxTests.AddRange(_listRxTests);
                entities.SaveChanges();
                return true;
            }
        }

        public List<RxAdviceToPatient> GetRxAdvices(long _RxId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxAdviceToPatients.Where(x => x.RxVisitId == _RxId).ToList();

            }
        }

        public RxCPAdvice GetAdviceById(int adviceId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RxCPAdvices.Where(x => x.RxCpAdvId == adviceId).FirstOrDefault();
            }
        }

        public void SaveAdvices(List<RxAdviceToPatient> _adviceList)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.RxAdviceToPatients.AddRange(_adviceList);
                 entities.SaveChanges();

            }
        }
    }
}
