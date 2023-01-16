using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Common;

namespace HDMS.Repository.Diagonstics
{
    public class TestRepository
    {

        SqlConnection con;
        SqlDataAdapter da;
        string sql = string.Empty;
        public IList<TestGroup> GetTestGroups()
        {
            using(DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.ToList();
            }
        }

        public TestGroup GetGroupByType(string testGroupTypeEnum)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.Where(x => x.Type == testGroupTypeEnum).FirstOrDefault();
            }
        }

        public List<VMPathologicalMachine> GetPathLabMachineList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMPathologicalMachine>(@"Select pm.*,rt.Report_Type as ReportType from PathologicalMachines pm join ReportTypes rt on pm.ReportTypeId=rt.ReportTypeId").ToList();
            }
        }

        public List<ReportType> GetPathReportTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTypes.SqlQuery(@"Select * from ReportTypes Where ReportTypeId in (2,5,10)").ToList();
            }
        }

        public IList<ReportType> GetAllReportTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTypes.ToList();
            }
        }

        public List<TestItem> GetTestsForReAgentSetting()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<TestItem>(@"Select * from TestItems Where ReportTypeId in (2,4,5,6,7,8,9,10,11,12,14,19,26,28,36,15) ").ToList();
            }
        }

        public bool SaveReportDeliveryTimingMaster(ReportDeliveryTimingMaster rdtm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ReportDeliveryTimingMasters.Add(rdtm);
                entities.SaveChanges();
                return true;
            }
        }

        public TestItem GetTestItemByReportId(int reportTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var sql = entities.TestItems.Where(x => x.ReportTypeId == reportTypeId).FirstOrDefault();
                    return sql;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<VMConsutantentTstFeeSeupt> GetReportFeeByRCID(int rCId, int ReportTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var sql = entities.Database.SqlQuery<VMConsutantentTstFeeSeupt>(@"
select t.TestId, t.Name, rf.RCId, rf.Fee , rf.RFId, rf.ReportTypeId from TestItems as t inner join ReportFees as rf on rf.TestId = t.TestId
where rf.RCId = {0} and rf.ReportTypeId = {1}
", rCId, ReportTypeId).ToList();

                    return sql;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public bool UpdateReportDeliveryTimingMaster(ReportDeliveryTimingMaster rdtm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Database.ExecuteSqlCommand("Update ReportDeliveryTimingMasters Set IsActiveNow={0} Where IsWeekendDeliverySchedule='False'", new object[] { false });

                entities.Entry(rdtm).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<ReportDeliveryTimingMaster> GetReportDeliveryTimingMasterList()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.ReportDeliveryTimingMasters.ToList();
               
            }
        }

        public bool SaveVacuType(VacuType _vType)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.VacuTypes.Add(_vType);
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateVacuType(VacuType _vT)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_vT).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<TestItem> GetAllPathologicalTest()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.SqlQuery("Select * from TestItems Where ReportTypeId in (2,5,6,7,8,9,10,11,12,14,16,17,19,24,27,48,51,55)").ToList();
            }
        }

        public DataSet GetTestList()
        {
            using (SqlConnection conn=new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT dbo.TestItems.ReportTypeId , dbo.TestItems.TestId, dbo.TestItems.Name as TestName, dbo.ReportTypes.Report_Type as ReportTypeName
                                       FROM dbo.TestItems INNER JOIN
                                       dbo.ReportTypes ON dbo.TestItems.ReportTypeId = dbo.ReportTypes.ReportTypeId  where  dbo.TestItems.ReportTypeId in (2, 5, 6, 7, 8, 9, 10, 11, 12, 14, 19, 24)");

                da = new SqlDataAdapter(sql, conn);

                DataSet dsTestLists = new DataSet();
                da.Fill(dsTestLists);

                dsTestLists.DataSetName = "dsTestList";
                dsTestLists.Tables[0].TableName = "dtTestList";


                return dsTestLists;

            }
        }

        public IList<TestGroup> GetTestGroupByType()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.ToList();
            }
        }

        public IList<TestItem> GetTestItemsByReportTypeId(int reportTypeId)
        {
            throw new NotImplementedException();
        }

        public IList<TestItem> GetTestItemsByGroupId(int grouupId)
        {
            IList<TestItem> result = new List<TestItem>();
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.ReportTypeId == grouupId).ToList();
            }
        }

       

        public TestItem GetTestItemByTestCode(int testCode)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.TestCode == testCode).FirstOrDefault();
            }
        }

      

        public IList<TestItem> GetAllTests()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.ToList();
            }
        }

        
        public TestItem GetTestItemsById(int testItemId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.TestId == testItemId).FirstOrDefault();
            }
        }

        public IList<TestSubItem> GetSubTestItemsByTestId(int testItemId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestSubItems.SqlQuery(@"select tsi.* from  TestSubItems tsi  where tsi.MainTestId = @p0", testItemId).ToList();
            }
        }

        private ViewModelReportTests GetTestDataTableRow(DataRow dr)
        {
            ViewModelReportTests ttype = new ViewModelReportTests();
            ttype.Id = Convert.ToInt32(dr["TestId"]);
            ttype.Name = dr["Name"].ToString();
            ttype.GroupId = Convert.ToInt32(dr["TestGroupId"]);
            ttype.GroupName = dr["GroupName"].ToString();

            return ttype;
        }

        public bool UpdateTestGroup(TestGroup _tgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_tgroup).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void DeleteTestItem(TestItem testItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.Entry(testItem).State=EntityState.Deleted;
                 entities.SaveChanges();
            }
        }

        public TestItem GetTestItemById(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.TestId == testId).FirstOrDefault();
            }
        }

        public List<TestItem> GetAllTestItemByTestCode(int _testCode)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.TestCode == _testCode).ToList();
            }
        }

        public bool SaveReportType(ReportType _rType)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ReportTypes.Add(_rType);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public ConsultantFee GetCurrentCosultantFeeByTestId(int rCId, int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ConsultantFees.Where(x=>x.RCId== rCId && x.TestId== testId).FirstOrDefault();
            }
        }

        public List<TestItem> GetAllTestByReportTypeAndGroup(int reportTypeId, int testGroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.SqlQuery(@"Select * from TestItems ti join ReportTypes rt on ti.ReportTypeId=rt.ReportTypeId join TestGroups 
                      tg on rt.TestGroupId=tg.TestGroupId where tg.TestGroupId={0}", testGroupId).ToList();
            }
        }

        public List<VMConsutantentTstFeeSeupt> ShowAllConsultantReportTypeIdAdnFee(int reportType, int reportId)
        {
             using(DBEntities entities = new DBEntities())
            {
                try
                {
                    List<VMConsutantentTstFeeSeupt> reports = entities.Database.SqlQuery<VMConsutantentTstFeeSeupt>(@"
SELECT rf.RFId
	,rf.RCId
	,ti.TestId
	,rf.Fee
	,rp.ReportTypeId
	,ti.Name
, ti.Rate
FROM TestItems AS ti
INNER JOIN ReportTypes AS rp ON ti.ReportTypeId = rp.ReportTypeId
LEFT JOIN ReportFees rf ON ti.TestId = rf.TestId
WHERE rf.RCId = {0}
	AND ti.ReportTypeId = {1}

UNION

SELECT 0 AS RFId
	,0 AS RCId
	,ti.TestId
	,0 AS Fee
	,rp.ReportTypeId
	,ti.Name
    , ti.Rate
FROM TestItems AS ti
INNER JOIN ReportTypes AS rp ON ti.ReportTypeId = rp.ReportTypeId
WHERE ti.ReportTypeId = {1}
	AND TestId NOT IN (
		SELECT TestId
		FROM ReportFees
		WHERE ReportTypeId = {1}
			AND RCId = {0}
		)
ORDER BY ti.TestId ASC
", reportId, reportType).ToList();

                    return reports;
                }catch(Exception ex)
                {
                    return null;
                }

            }
        }

        public bool UpdateReportFee(List<ReportFee> reportFee)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    foreach (ReportFee item in reportFee)
                    {
                        //ReportFee _cost = GetTestCostById(item.PatientId, item.TestId);
                        //_cost.ReportStatus = item.ReportStatus;
                        entities.Entry(item).State = EntityState.Modified;
                        entities.SaveChanges();

                    }

                    //entities.Entry(reportFee).State = EntityState.Modified;
                    //entities.SaveChanges();

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public ReportType GetReportTypeByGroupId(int testGroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTypes.Where(x => x.TestGroupId == testGroupId).FirstOrDefault();
            }
        }

        public void UpdatePathLabMachine(PathologicalMachine pathmObj)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(pathmObj).State=EntityState.Modified;
               entities.SaveChanges();
            }
        }

        public PathologicalMachine GetPathologicalMachines(int machineId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.PathologicalMachines.Where(x=>x.Id== machineId).FirstOrDefault();
               
            }
        }

        public void UpdateConsultancyFeeRate(ConsultantFee _currenCf)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(_currenCf).State =EntityState.Modified;
               entities.SaveChanges();
            }
        }

        public void AddConsultancyFeeRate(List<ConsultantFee> _newCFlist)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ConsultantFees.AddRange(_newCFlist);
                entities.SaveChanges();
            }
        }

        public IList<ViewModelReportTests> GetAllNonLabTestByPatientId(long _PatientId)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            sql = string.Format(@"select * from dbo.VWUsgOrXrayOrEchoTestList where PatientID = {0}", _PatientId);
            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<ViewModelReportTests> listReportTests = new List<ViewModelReportTests>();

            listReportTests = new List<ViewModelReportTests>(
                (from dRow in dt.AsEnumerable()
                 select (GetTestDataTableRow(dRow)))
                );

            return listReportTests;
        }

        public bool UpdateReportDeliveryTimingDetail(ReportDeliveryTimingDetail rdtd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(rdtd).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<ReportDeliveryTimingDetail> GetReportDeliveryTimingDetailList(int rDTMId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.ReportDeliveryTimingDetails.Where(x=>x.RDTMId== rDTMId).ToList();
                
            }
        }

        public bool SaveReportDeliveryTimingDetail(ReportDeliveryTimingDetail rdtd)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.ReportDeliveryTimingDetails.Add(rdtd);
               entities.SaveChanges();
               return true;
            }
        }

        public async Task<List<ReportDeliveryTimingDetail>> GetSelectedReportDeliveryTimingDetail(int rDTMId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.ReportDeliveryTimingDetails.Where(x => x.RDTMId == rDTMId).OrderBy(x=>x.Id).ToListAsync();

            }
        }

        public async Task<ReportDeliveryTimingMaster> GetSelectedReportDeliveryTimeMaster()
        {
            using (DBEntities entities = new DBEntities())
            {
               return  await entities.ReportDeliveryTimingMasters.Where(x=>x.IsActiveNow==true).FirstOrDefaultAsync();
                
            }
        }

        public bool UpdateBarCodeLabel(BarCodeLabelSettingForTest _sLs)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.Entry(_sLs).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public bool DeleteFromVacuList(int VacuId, int testId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format("Delete from VacuWithTestSettings Where  VTId={0} and TestId={1}", VacuId, testId);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
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

        public VacuWithTestSetting FindVacuTestSettingByTestId(int testId)
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.VacuWithTestSettings.Where(x => x.TestId == testId).FirstOrDefault();
            }
        }

        public List<VMVacuTestSetting> GetVacuWithTestList(int vTId)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.VacuWithTestSettings.VSId, dbo.VacuWithTestSettings.VTId, dbo.VacuWithTestSettings.TestId, dbo.TestItems.Name, dbo.TestItems.ShortName
                                      FROM  dbo.VacuWithTestSettings INNER JOIN
                                      dbo.TestItems ON dbo.VacuWithTestSettings.TestId = dbo.TestItems.TestId
                                      WHERE  (dbo.VacuWithTestSettings.VTId = {0})", vTId);

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMVacuTestSetting> listVacuTests = new List<VMVacuTestSetting>();

                listVacuTests = new List<VMVacuTestSetting>(
                    (from dRow in dt.AsEnumerable()
                     select (GetVacuTestSettingDataTableRow(dRow)))
                    );

                return listVacuTests;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMVacuTestSetting GetVacuTestSettingDataTableRow(DataRow dr)
        {
            VMVacuTestSetting _vcTObj = new VMVacuTestSetting();
            _vcTObj.VTId = Convert.ToInt32(dr["VTId"]);
            _vcTObj.TestId = Convert.ToInt32(dr["TestId"]);
            _vcTObj.TestName = dr["Name"].ToString();
            _vcTObj.ShortName = dr["ShortName"].ToString();

            return _vcTObj;
        }

        public bool AddTestWithVacutainer(VacuWithTestSetting _vts)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.VacuWithTestSettings.Add(_vts);
                entities.SaveChanges();
                return true;
            }
        }

        public List<VacuType> GetVacuList()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.VacuTypes.ToList();
            }
        }

        public bool DeleteBarcodeLabelSetting(int settingId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format("Delete from BarCodeLabelSettingForTests Where  SettingId={0}", settingId);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    return true;

                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public List<BarCodeLabelSettingForTest> GetBarcodeLabelList(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.BarCodeLabelSettingForTests.Where(x=>x.TestId== testId).ToList();
               
            }
        }

        public bool SaveBarCodeLabel(BarCodeLabelSettingForTest _sbSetting)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.BarCodeLabelSettingForTests.Add(_sbSetting);
                entities.SaveChanges();
                return true;
            }
        }

        public List<TestItem> GetAllFilteredPathologicalTest(string _searchStr)
        {
            using (DBEntities entities=new DBEntities())
            {
                sql = string.Format(@"Select * from TestItems Where Name like '%{0}%'", _searchStr);
                return entities.TestItems.SqlQuery(sql).ToList();
            }
        }

        public IList<ViewModelReportTests> GetAllTestByRegNoLegacy(long RegNo, int RCId)
        {
            try
            { 
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("Exec spGetNonLabTests {0}, {1}", RegNo, RCId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<ViewModelReportTests> listReportTests = new List<ViewModelReportTests>();

                listReportTests = new List<ViewModelReportTests>(
                    (from dRow in dt.AsEnumerable()
                     select (GetTestDataTableRow(dRow)))
                    );

                return listReportTests;

            }catch(Exception ex)
            {
                return null;
            }
        }

        public List<TestGroup> GetConsultancyGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.SqlQuery("Select * from TestGroups Where TestGroupId in (5, 7, 20, 22, 29, 31, 32, 33, 4, 8, 9, 13, 17, 3, 11, 12, 10, 23, 28)").ToList();
            }
        }

        public void UpdateSubItemTestCode(int testId, int tesCode)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format("Update TestSubItems Set TestCode={0} Where TestId={1}", tesCode, testId );
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                }
                catch
                {

                }
            }
        }

        public void UpdateReportType(ReportType _rType)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_rType).State=EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public List<TestSubItem> GetSubTestListByTestId(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestSubItems.Where(x => x.TestId == testId).ToList();
            }
        }
        public bool SaveMasterGroup(MasterTestGroup _masterTestGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.MasterTestGroups.Add(_masterTestGroup);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return true;
                }
            }
        }

        private ViewModelReportTests GetRadiologyTestDataTableRow(DataRow dr)
        {
            ViewModelReportTests ttype = new ViewModelReportTests();
            ttype.Id = Convert.ToInt32(dr["TestId"]);
            ttype.Name = dr["Name"].ToString();
            ttype.GroupId = Convert.ToInt32(dr["TestGroupId"]);
            ttype.GroupName = dr["GroupName"].ToString();

            return ttype;
        }

        public bool UpdateTestItemCollectionType(List<TestItem> _tList, int _reportTypeId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format("Update TestItems Set CollectionTypeId=2 where ReportTypeId={0}", _reportTypeId);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    using (DBEntities entities = new DBEntities())
                    {
                        foreach (TestItem item in _tList)
                        {
                            TestItem _tItem = GetTestItemById(item.TestId);
                            _tItem.CollectionTypeId = 1;
                            entities.Entry(_tItem).State = EntityState.Modified;
                            entities.SaveChanges();

                        }

                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public List<VMConsutantentTstFeeSeupt> GetAllTestByReportType(int repotTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var result = entities.Database.SqlQuery<VMConsutantentTstFeeSeupt>(@" SELECT * FROM TestItems WHERE ReportTypeId = {0} order by TestItems.TestId  ASC", repotTypeId).ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool IsReportPrinted(Patient _Patient, int _itemId)
        {

            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                   sql = string.Format("Select PathologyReports.Id,PathologyReports.PatientId, PathologyNonWordReportReportDetails.TestId from PathologyReports join PathologyNonWordReportReportDetails on  PathologyReports.Id=PathologyNonWordReportReportDetails.ReportId Where PathologyReports.PatientId={0} and PathologyNonWordReportReportDetails.TestId={1}", _Patient.PatientId, _itemId);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    long _count = Convert.ToInt64(cmd.ExecuteScalar());

                    if (_count > 0) return true;

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

          
        }

        public bool UpdateMasterGroup(MasterTestGroup _master)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_master).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public MasterTestGroup GetMasterTestGroupById(int _MasterId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MasterTestGroups.Where(x=>x.MasterTestGroupId== _MasterId).FirstOrDefault();
            }
        }

        public List<MasterTestGroup> GetMasterGroups()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.MasterTestGroups.ToList();
            }
        }

        public List<SampleCollectionSetting> GetSampleCollectionSetting(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.SampleCollectionSettings.Where(x => x.MainTestId == testId).ToList();
            }
        }

        public bool DeleteTestGroup(TestGroup _tGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_tGroup).State = EntityState.Deleted;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<UXEntryList> GetUXEntryListByDate(DateTime _dt)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format("select Distinct PatientId,BillNo,FullName from dbo.VWUsgOrXrayOrEchoTestList where GroupName in ('USG','XRay','MRI','CT SCAN','Echo') and EntryDate='{0}'", _dt.Date);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<UXEntryList> listReportTests = new List<UXEntryList>();

                listReportTests = new List<UXEntryList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetTestDataTableRowForUxEntryList(dRow)))
                    );

                return listReportTests;
            }
            catch
            {
                return null;
            }
        }

        public List<TestItem> GetVacuesForSelectTest(int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.SqlQuery(@"Select * from TestItems Where TestId in (
                                      SELECT vt.TestId
                                      FROM  dbo.TestItems join VacuWithTestSettings on dbo.TestItems.TestId =  VacuWithTestSettings.TestId
								      INNER JOIN BarCodeLabelSettingForTests on dbo.TestItems.TestId=BarCodeLabelSettingForTests.TestId
                                      Join VacuTypes vt on VacuWithTestSettings.VTId=vt.VTId
                                      WHERE   dbo.TestItems.TestId = {0})", testId).ToList();
            }
        }

        public List<VMInvestigationList> GetIPDPatientInvestigations(long billNo)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.Patients.PatientId, dbo.Patients.AdmissionNo, dbo.TestsCost.TestId, dbo.TestItems.Name, dbo.TestsCost.Status
                                      FROM dbo.Patients INNER JOIN
                                      dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                                      dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId Where dbo.Patients.AdmissionNo={0}", billNo);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMInvestigationList> listReportTests = new List<VMInvestigationList>();

                listReportTests = new List<VMInvestigationList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetTestDataTableRowIPDPatient(dRow)))
                    );

                return listReportTests;
            }
            catch
            {
                return null;
            }
        }

        private VMInvestigationList GetTestDataTableRowIPDPatient(DataRow dr)
        {
            VMInvestigationList inv = new VMInvestigationList();
            inv.PatientId = Convert.ToInt64(dr["PatientId"]);
            inv.AdmissionNo = Convert.ToInt64(dr["AdmissionNo"]);
            inv.TestName = dr["Name"].ToString();

            return inv;
        }

        public bool SaveSampleCollectionSetting(List<SampleCollectionSetting> _sItemList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.SampleCollectionSettings.AddRange(_sItemList);
                    entities.SaveChanges();
                    return true;

                }
                catch
                {
                    return false;
                }

            }
        }

        public void DeleteReportType(ReportType _rType)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_rType).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }

        private UXEntryList GetTestDataTableRowForUxEntryList(DataRow dr)
        {
            UXEntryList uxEntry = new UXEntryList();
            uxEntry.PatientId = Convert.ToInt64(dr["PatientId"]);
            uxEntry.BillNo = Convert.ToInt64(dr["BillNo"]);
            uxEntry.PatientName = dr["FullName"].ToString();
            
            return uxEntry;
        }

        public IList<ViewModelReportTests> GetAllPathologyTestByRegNoLegacy(long RegNo)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            sql = string.Format("select * from dbo.VWPathologicalTests where PatientID={0}", RegNo);
            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<ViewModelReportTests> listReportTests = new List<ViewModelReportTests>();

            listReportTests = new List<ViewModelReportTests>(
                (from dRow in dt.AsEnumerable()
                 select (GetPathologicalTestDataTableRow(dRow)))
                );

            return listReportTests;
        }

        private ViewModelReportTests GetPathologicalTestDataTableRow(DataRow dr)
        {
            ViewModelReportTests ttype = new ViewModelReportTests();
            ttype.Id = Convert.ToInt32(dr["TestId"]);
            ttype.Name = dr["TestName"].ToString();
            ttype.GroupId = Convert.ToInt32(dr["TestGroupId"]);
            ttype.GroupName = dr["GroupName"].ToString();
            ttype.ReportType= dr["Report_Type"].ToString(); 
            return ttype;
        }

        public List<ReportType> GetReportTypesByGroupId(int _groupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTypes.Where(x => x.TestGroupId == _groupId).ToList();
            }
        }

        public List<TestItem> GetAllTestByReportTypeId(int reportTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.Where(x => x.ReportTypeId == reportTypeId).ToList();
            }
        }

        public ViewModelReportTests GetSelectedTestByRegNoLegacy(long RegNo,string TestId)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.VWUsgOrXrayOrEchoTestList where PatientID=" + RegNo+" and TestId="+TestId, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            return GetRadiologyTestDataTableRow(dt.Rows[0]);
        }

        public TestsCost GetTestCostById(long _pId, int testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestsCosts.Where(x => x.PatientId == _pId && x.TestId == testId).FirstOrDefault();
            }
        }

        public ViewModelReportTests GetSelectedPathTestByRegNoLegacy(string RegNo, string TestId)
        {
            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            da = new SqlDataAdapter("select * from dbo.VWPathologicalTest where BillNo=" + RegNo + " and TestId=" + TestId, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            return GetTestDataTableRow(dt.Rows[0]);
        }

        public List<TestsCost> GetCancelledTestList(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestsCosts.Where(x => x.PatientId == patientId && x.Status.ToLower() == "cancelled").ToList();
            }
        }

        public bool UpdateTestCost(List<TestsCost> _testList)
        {
            using (DBEntities entities = new DBEntities())
            {
               foreach(TestsCost item in _testList)
                {
                    TestsCost _cost = GetTestCostById(item.PatientId,item.TestId);
                    _cost.ReportStatus = item.ReportStatus;
                    entities.Entry(_cost).State = EntityState.Modified;
                    entities.SaveChanges();

                }
                  
                    return true;
           
            }
        }

        public bool CheckIsReportPrintedForThisPatient(Patient _Patient)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLegacyDbConnectionString()))
            {
                try
                {
                    sql = string.Format("Select PathologyReports.Id,PathologyReports.PatientId, PathologyNonWordReportReportDetails.TestId from PathologyReports join PathologyNonWordReportReportDetails on  PathologyReports.Id=PathologyNonWordReportReportDetails.ReportId Where PathologyReports.PatientId={0}", _Patient.PatientId);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    long _count = Convert.ToInt64(cmd.ExecuteScalar());

                    if (_count > 0) return true;

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public List<TestSubItem> GetSubTestListByMainTestId(int _testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestSubItems.Where(x => x.MainTestId == _testId).ToList();
            }
        }

        public bool SaveTestGroup(TestGroup _testGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.TestGroups.Add(_testGroup);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public List<TestGroup> GetAllGroup()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.ToList();
            }
        }

        public bool SaveTest(TestItem _tItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                //try
                //{
                    entities.TestItems.Add(_tItem);
                    entities.SaveChanges();
                    return true;
                //}
                //catch
                //{
                //    return false;
                //}
               
            }
        }

        public List<TestItem> GetAllTestByGroupId(int groupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItems.SqlQuery("Select TestItems.* from TestItems Join ReportTypes on TestItems.ReportTypeId=ReportTypes.ReportTypeId Join TestGroups on ReportTypes.TestGroupId=TestGroups.TestGroupId Where TestGroups.TestGroupId={0}", groupId).ToList();
            }
        }

        public void UpdateTestItem(TestItem _Item)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.Entry(_Item).State=EntityState.Modified;
                 entities.SaveChanges();
            }
        }

        public bool SaveSubItem(List<TestSubItem> _sItemList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.TestSubItems.AddRange(_sItemList);
                    entities.SaveChanges();
                    return true;

                }catch{
                    return false;
                }

            }
        }

        public TestItem GetTestItemByName(string testName)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.TestItems.Where(x => x.Name == testName).FirstOrDefault();
                
            }
        }

        public bool SaveReportDefination(ReportDefination _reportdef)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ReportDefinations.Add(_reportdef);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }

        }

        public IList<ReportDefination> GetTestItemDetailByTestId(int itemId)
        {

            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDefinations.Where(x => x.TestId == itemId).ToList();
            }
           
        }

        private VWMTestItemDetail GetTestItemDetailTableRow(DataRow dr)
        {
            VWMTestItemDetail ttype = new VWMTestItemDetail();
            ttype.Id = Convert.ToInt32(dr["Id"]);
            ttype.TestId = Convert.ToInt32(dr["TestId"]);
            ttype.TestName = dr["Name"].ToString();
            ttype.TestCriteria = dr["TestCriteria"].ToString();
            ttype.NormalValues = dr["NormalValues"].ToString();
            ttype.ResultUnit = dr["ResultUnit"].ToString();
            if (dr["lowerLimit"] != DBNull.Value)
            {
                 ttype.lowerLimit = Convert.ToDouble(dr["lowerLimit"]);
            }
            else
            {
                ttype.lowerLimit = 0;
            }

            if (dr["upperLimit"] != DBNull.Value)
            {
                ttype.upperLimit = Convert.ToDouble(dr["upperLimit"]);
            }
            else
            {
                ttype.upperLimit = 0;
            }

            if (dr["alarmLimit"] != DBNull.Value)
            {
                ttype.alarmLimit = Convert.ToDouble(dr["alarmLimit"]);
            }
            else
            {
                ttype.alarmLimit = 0;
            }

            if (dr["HasAgeVariant"] != DBNull.Value)
            {
                ttype.HasAgeVariant = Convert.ToBoolean(dr["HasAgeVariant"]);
            }
            else
            {
                ttype.HasAgeVariant = false;
            }

          
            ttype.Reportorder = Convert.ToInt32(dr["Reportorder"]);
            return ttype;
        }

        public ReportType GetReportTypesById(int _reportTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportTypes.Where(x => x.ReportTypeId == _reportTypeId).FirstOrDefault();
            }
        }

        public TestItemDetail GetTestItemDetailByItemDetailId(int itemdetailId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestItemDetails.Where(x => x.Id == itemdetailId).FirstOrDefault();
            }
        }

        public bool UpdateTestItemDetail(ReportDefination _Item)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_Item).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public List<PathologicalMachine> GetAllPathologicalMachines()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologicalMachines.ToList();
            }
        }

        public double GetDiscountedAmount(long RegNo)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Credit) as tDiscount from  PatientLedger Where PatientId={0} and Particulars='{1}'", RegNo, "Discount");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());
                  
                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public int GetCategoryIdByMediaId(int mediaId)
        {
            using(DBEntities entities = new DBEntities())
            {
                try
                {


                    BusinessMedia _category = entities.BusinessMedias.Where(x => x.MediaId == mediaId).FirstOrDefault();

                    return _category.CategoryId;

                }catch(Exception ex)
                {
                    return 0;
                }

            }
        }

        public List<MediaCategoryReportTypeCommission> GetReportTypeByCategoryId(int mediaCategoryId, int mediaId, int ReportTypeId)
        {
            using(DBEntities entities = new DBEntities())
            {
                try
                {
                    //List<MediaCategoryReportTypeCommission> mediaCom = entities.MediaCategoryReportTypeCommissions.Where(x => x.CategoryId == mediaCategoryId).ToList();

                    //return mediaCom;
                    sql = string.Format(@"
SELECT DISTINCT mcrc.ReportTypeId

    ,bs.name
	,mcrc.CategoryId As CategoryId
	,mcrc.CategoryId AS CategoryRepotTypeId
	,mc.CategoryName
	,mcrc.Commission AS Commission
	,mcrc.CommissionPercent  AS CommissionPercent
    ,mcrc.IsPercent
    
FROM MediaCategories AS mc
INNER JOIN MediaCategoryReportTypeCommissions AS mcrc ON mc.CategoryId = mcrc.CategoryId
INNER JOIN BusinessMedias AS bs ON bs.CategoryId = mc.CategoryId
WHERE bs.MediaId = {1}
	--AND mcrc.ReportTypeId = {2}
", mediaCategoryId, mediaId, ReportTypeId);

                    List<MediaCategoryReportTypeCommission> mediaCom = entities.Database.SqlQuery<MediaCategoryReportTypeCommission>(sql).ToList();

                    return mediaCom;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public List<VMGroupName> GetDistinctGroup(long _pId)
        {

            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            sql = string.Format(@"Select Distinct GroupName from (
                     SELECT dbo.Patients.PatientId as BillNo, dbo.RegRecords.RegNo, dbo.RegRecords.FullName as PatientName, CASE WHEN dbo.Patients.AgeYear<>'' THEN dbo.Patients.AgeYear+'Y ' ELSE dbo.Patients.AgeYear END 
          + CASE WHEN dbo.Patients.AgeMonth<>'' THEN RTRIM(dbo.Patients.AgeMonth)+'M ' ELSE dbo.Patients.AgeMonth END 
           + CASE WHEN dbo.Patients.AgeDay<>'' THEN RTRIM(dbo.Patients.AgeDay)+'D' ELSE dbo.Patients.AgeDay END AS Age, dbo.Patients.EntryDate, dbo.Patients.EntryTime, 
                         dbo.TestItems.Name AS TestName, dbo.TestGroups.SummaryGroup as GroupName, dbo.RegRecords.Sex as Gender, dbo.RegRecords.MobileNo, dbo.Doctor.Name AS RefdBy
             FROM            dbo.TestGroups INNER JOIN
                         dbo.ReportTypes INNER JOIN
                         dbo.Patients INNER JOIN
                         dbo.RegRecords ON dbo.Patients.RegNo = dbo.RegRecords.RegNo INNER JOIN
                         dbo.TestsCost ON dbo.Patients.PatientId = dbo.TestsCost.PatientId INNER JOIN
                         dbo.TestItems ON dbo.TestsCost.TestId = dbo.TestItems.TestId ON dbo.ReportTypes.ReportTypeId = dbo.TestItems.ReportTypeId ON dbo.TestGroups.TestGroupId = dbo.ReportTypes.TestGroupId INNER JOIN
                         dbo.Doctor ON dbo.Patients.DoctorId = dbo.Doctor.DoctorId
             Where  dbo.Patients.PatientId={0} ) T where T.GroupName<>'Logistic Supports'", _pId);


            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<VMGroupName> listReportTestGrouprs = new List<VMGroupName>();

            listReportTestGrouprs = new List<VMGroupName>(
                (from dRow in dt.AsEnumerable()
                 select (GetPathologicalTestGroupDataTableRow(dRow)))
                );

            return listReportTestGrouprs;



        }

        private VMGroupName GetPathologicalTestGroupDataTableRow(DataRow dr)
        {
            VMGroupName Obj = new VMGroupName();
            Obj.GroupName = dr["GroupName"].ToString();

            return Obj;
        }

        public TestGroup GetTestGroupById(int _groupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.TestGroups.Where(x=>x.TestGroupId==_groupId).FirstOrDefault();
            }
        }

        public IList<ReportDefination> GetTestReportDefinationByTestId(int _testId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDefinations.Where(x => x.TestId == _testId).ToList();
            }
        }

        public ReportDefination GetTestReportDefinationById(int _reportdetailId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ReportDefinations.Where(x => x.Id == _reportdetailId).FirstOrDefault();
            }
        }

        public bool DeleteRepositoryDefination(ReportDefination _reportDef)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_reportDef).State = EntityState.Deleted;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveGroupTestItem(List<GroupReportItem> gItems)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.GroupReportItems.AddRange(gItems);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IList<GroupReportItem> GetGroupRetportItemsById(int _itemId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.GroupReportItems.Where(x => x.GroupTestId == _itemId).ToList();
            }
        }
    }
}
