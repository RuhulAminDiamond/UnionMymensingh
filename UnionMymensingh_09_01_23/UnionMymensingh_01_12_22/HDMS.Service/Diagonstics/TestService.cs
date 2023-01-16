using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Diagnostic;
using HDMS.Model.Enums;
using HDMS.Model.ViewModel;
using HDMS.Repository;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HDMS.Model.Common;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Diagnostic.VM;

namespace HDMS.Service.Diagonstics
{
    public class TestService
    {
        public IList<TestGroup> GetTestGroups()
        {
            return new TestRepository().GetTestGroups();
        }

        public List<TestItem> GetTestsForReAgentSetting()
        {
            return new TestRepository().GetTestsForReAgentSetting();
        }

        public List<VMPathologicalMachine> GetPathLabMachineList()
        {
            return new TestRepository().GetPathLabMachineList();
        }

        public List<ReportType> GetPathReportTypes()
        {
            return new TestRepository().GetPathReportTypes();
        }

        public IList<TestItem> GetItemsByGroup(int ReportTypeId)
        {
            return new TestRepository().GetTestItemsByReportTypeId(ReportTypeId);
        }

        public bool SaveReportDeliveryTimingMaster(ReportDeliveryTimingMaster rdtm)
        {
            return new TestRepository().SaveReportDeliveryTimingMaster(rdtm);
        }

        public bool SaveVacuType(VacuType _vType)
        {
            return new TestRepository().SaveVacuType(_vType);
        }

        public IList<ReportType> GetAllReportTypes()
        {
            return new TestRepository().GetAllReportTypes();
        }

        public bool UpdateReportDeliveryTimingMaster(ReportDeliveryTimingMaster rdtm)
        {
            return new TestRepository().UpdateReportDeliveryTimingMaster(rdtm);
        }

        public bool UpdateVacuType(VacuType _vT)
        {
            return new TestRepository().UpdateVacuType(_vT);
        }

        public List<ReportDeliveryTimingMaster> GetReportDeliveryTimingMasterList()
        {
            return new TestRepository().GetReportDeliveryTimingMasterList();
        }

        public List<TestItem> GetAllPathologicalTest()
        {
            return new TestRepository().GetAllPathologicalTest();
        }

        public TestItem GetTestItemByReportId(int reportTypeId)
        {
            return new TestRepository().GetTestItemByReportId(reportTypeId);
        }

        public DataSet GetTestList()
        {
            return new TestRepository().GetTestList();
        }

        public IList<TestItem> GetAllTests()
        {
            TestRepository repo = new TestRepository();
            return repo.GetAllTests();
        }

        public List<VMConsutantentTstFeeSeupt> GetReportFeeByRCID(int rCId, int ReportTypeId)
        {
            return new TestRepository().GetReportFeeByRCID(rCId, ReportTypeId);
        }

        public void PopulateSelectedTestData(IList<SelectedTestItemsForPatient> selectedTests,  TestItem selectedItem, string testCode, DateTime dtpDeliveryDate, string deliveryTime)
        {
            int displayOrder = 0;
            int[] VacuTestIds = new int[] { 1046, 1047, 1048, 1049, 1050, 1051, 1052, 1054, 2503 };
            int testItemCode;
            if(!int.TryParse(testCode.Trim(), out testItemCode)) return;
            if(selectedTests.Any(x => x.Id == testItemCode)) return ;
            TestItem item = selectedItem;
            TestRepository repo = new TestRepository();
            if(item == null || item.TestId != testItemCode)
            {
                item = repo.GetTestItemByTestCode(testItemCode); //repo.GetTestItemsById(testItemId);
            }

            if (item == null) return;


            if (selectedTests.Count == 0) {
                displayOrder = 1;
            }
            else
            {
                displayOrder = selectedTests.Count + 1; 
            } 


            IList<TestSubItem> subItems = new List<TestSubItem>();
            if (item.IsPackage)
            {
                subItems = repo.GetSubTestItemsByTestId(item.TestId);
                foreach (TestSubItem subItem in subItems)
                {
                    if (!selectedTests.Any(x => x.Id == subItem.TestId))
                    {

                        selectedTests.Add(GetPreparedSelectedPackageTestObjectFromTestSubItem(subItem, dtpDeliveryDate, deliveryTime));
                    }
                }
            }
            else
            {
                selectedTests.Add(GetPreparedSelectedTestObject(item, dtpDeliveryDate, deliveryTime, displayOrder, false));

                if(item.TestId== 204 || item.TestId == 1821||item.TestId==43 ||item.TestId==44||item.TestId==1698) // Special Handler for GTT 2 or 3 Samples Glucose Packet
                {
                    TestItem _glucosPacket = new TestRepository().GetTestItemById(2372); // Glucose Item Id: 2372
                    selectedTests.Add(GetPreparedSelectedTestObject(_glucosPacket, dtpDeliveryDate, deliveryTime, displayOrder, true));
                }
                
                List<SelectedTestItemsForPatient> temselectedTests = selectedTests.Where(x => x.ReportTypeId == item.ReportTypeId).ToList();
                
                
                List<TestItem> vacues = repo.GetVacuesForSelectTest(item.TestId);


                    foreach (TestItem vacuItem in vacues)
                    {
                        if (vacuItem.ReportTypeId == 63)
                        {
                            if (selectedTests.Any(x => x.Id == vacuItem.TestId) && vacuItem.TestId != 1045)  // For Vacu Qty Increment, Except Needle (1045)
                            {

                                string[] arr = new string[2];
                                arr[0] = "";
                                arr[1] = "";
                                SelectedTestItemsForPatient _selected = selectedTests.Where(x => x.Id == vacuItem.TestId).FirstOrDefault();
                                string testName = _selected.Name;
                                arr = testName.Split('-');

                                if (temselectedTests.Count > 1 && item.CollectionTypeId == 1)
                                {

                                    if (arr.Length > 1 && !String.IsNullOrEmpty(arr[1]))
                                    {
                                        string _currentPcs = arr[1];
                                        string _currentPcno = _currentPcs[0].ToString();
                                        int vacuQty = Convert.ToInt32(_currentPcno);
                                        vacuQty = vacuQty + 1;

                                        testName = arr[0] + "-" + vacuQty.ToString() + "Pcs";

                                        double totalVacutk = vacuItem.Rate * vacuQty;

                                        selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Name = testName);
                                        selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Cost = totalVacutk);

                                    }
                                    else
                                    {

                                        int vacuQty = 2;

                                        testName = arr[0] + "-" + vacuQty.ToString() + "Pcs";

                                        double totalVacutk = vacuItem.Rate * vacuQty;

                                        selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Name = testName);
                                        selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Cost = totalVacutk);
                                    }

                                }else if (temselectedTests.Count == 1){


                                if (arr.Length > 1 && !String.IsNullOrEmpty(arr[1]))
                                {
                                    string _currentPcs = arr[1];
                                    string _currentPcno = _currentPcs[0].ToString();
                                    int vacuQty = Convert.ToInt32(_currentPcno);
                                    vacuQty = vacuQty + 1;

                                    testName = arr[0] + "-" + vacuQty.ToString() + "Pcs";

                                    double totalVacutk = vacuItem.Rate * vacuQty;

                                    selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Name = testName);
                                    selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Cost = totalVacutk);

                                }
                                else
                                {

                                    int vacuQty = 2;

                                    testName = arr[0] + "-" + vacuQty.ToString() + "Pcs";

                                    double totalVacutk = vacuItem.Rate * vacuQty;

                                    selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Name = testName);
                                    selectedTests.Where(w => w.Id == vacuItem.TestId).ToList().ForEach(s => s.Cost = totalVacutk);
                                }

                            }
                            }
                            else
                            {

                             displayOrder = selectedTests.Count + 101;
                              if (!selectedTests.Any(x => x.Id == vacuItem.TestId))
                                    selectedTests.Add(GetPreparedSelectedTestObjectForVacuItem(selectedTests, vacuItem, dtpDeliveryDate, deliveryTime, displayOrder, item));

                            //if VacuType Id is 1 or 2 or 3 or 4 or 5 or 6 Need a needle
                               if (!selectedTests.Any(x => x.Id == 1045) && VacuTestIds.Contains(vacuItem.TestId))
                               {
                                  TestItem needle = new TestRepository().GetTestItemById(1045);
                                  selectedTests.Add(GetPreparedSelectedTestObjectForVacuItemNeedle(selectedTests, needle, dtpDeliveryDate, deliveryTime, displayOrder));

                               }




                        }
                    }
                        else
                        {

                            if (!selectedTests.Any(x => x.Id == vacuItem.TestId))
                            {

                                selectedTests.Add(GetPreparedSelectedTestObjectFromTestSubItem(vacuItem, dtpDeliveryDate, deliveryTime));
                            }
                        }
                    }

                
            }
        }

        public List<VMConsutantentTstFeeSeupt> ShowAllConsultantReportTypeIdAdnFee(int reportType, int reportId)
        {
            return new TestRepository().ShowAllConsultantReportTypeIdAdnFee(reportType, reportId);
        }

        public bool UpdateReportFee(List<ReportFee> reportFee)
        {
            return new TestRepository().UpdateReportFee(reportFee);
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObjectForVacuItemNeedle(IList<SelectedTestItemsForPatient> selectedTests, TestItem subItem, DateTime dtpDeliveryDate, string deliveryTime, int displayOrder)
        {
            SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();

            selectedItemforpatient.Id = subItem.TestId;
            selectedItemforpatient.TestCode = subItem.TestCode;
            selectedItemforpatient.ReportTypeId = subItem.ReportTypeId;
            
            selectedItemforpatient.Name = subItem.Name;
            

            selectedItemforpatient.Cost = subItem.Rate ;
            selectedItemforpatient.discountInPercent = "";
            selectedItemforpatient.discount = "";

            if (subItem.ReportTypeId == 63)
            {
                selectedItemforpatient.DeliveryDate = "";
                selectedItemforpatient.DeliveryTime = "";
            }

            selectedItemforpatient.AdditionType = "";
            selectedItemforpatient.DisplayOrder = displayOrder;


            return selectedItemforpatient;
        }

        private SelectedTestItemsForPatient GetPreparedSelectedPackageTestObjectFromTestSubItem(TestSubItem item, DateTime dtpDeliveryDate, string deliveryTime)
        {
            string _discountPlanGroup = this.GetDiscountPlanGroup(item.ReportTypeId);

            TestItem _tItem = new TestRepository().GetTestItemById(item.TestId);

            SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();
            selectedItemforpatient.Id = item.TestId;
            selectedItemforpatient.TestCode = item.TestCode;
            selectedItemforpatient.ReportTypeId = item.ReportTypeId;
            selectedItemforpatient.Name = item.Name;
            selectedItemforpatient.Cost = item.Rate;
            selectedItemforpatient.discountInPercent = "";
            selectedItemforpatient.discount = "";
            if (_tItem.ReportTypeId==63)
            {
                selectedItemforpatient.DeliveryDate = "";
                selectedItemforpatient.DeliveryTime = "";
            }
            else
            {
                if (_tItem.DayNeededForReportDelivery > 0)
                {
                    selectedItemforpatient.DeliveryDate = dtpDeliveryDate.AddDays(_tItem.DayNeededForReportDelivery).ToString(Configuration.DATE_TIME_FORMAT);
                    selectedItemforpatient.DeliveryTime = "8:30 PM";
                }
                else
                {
                    selectedItemforpatient.DeliveryDate = dtpDeliveryDate.ToString(Configuration.DATE_TIME_FORMAT);
                    selectedItemforpatient.DeliveryTime = deliveryTime;
                }
            }

            selectedItemforpatient.AdditionType = "New";  // Newly added test for entry
            selectedItemforpatient.DiscountPlanGroup = _discountPlanGroup;

            return selectedItemforpatient;
        }

        public List<TestItem> GetAllTestByReportTypeAndGroup(int reportTypeId, int testGroupId)
        {
            return new TestRepository().GetAllTestByReportTypeAndGroup(reportTypeId, testGroupId);
        }

        public ReportType GetReportTypeByGroupId(int testGroupId)
        {
           return  new TestRepository().GetReportTypeByGroupId(testGroupId);
        }

        public void UpdatePathLabMachine(PathologicalMachine pathmObj)
        {
            new TestRepository().UpdatePathLabMachine(pathmObj);
        }

        public PathologicalMachine GetPathologicalMachines(int machineId)
        {
            return new TestRepository().GetPathologicalMachines(machineId);
        }

        public bool UpdateReportDeliveryTimingDetail(ReportDeliveryTimingDetail rdtd)
        {
            return new TestRepository().UpdateReportDeliveryTimingDetail(rdtd);
        }

        public List<ReportDeliveryTimingDetail> GetReportDeliveryTimingDetailList(int rDTMId)
        {
            return new TestRepository().GetReportDeliveryTimingDetailList(rDTMId);
        }

        public bool SaveReportDeliveryTimingDetail(ReportDeliveryTimingDetail rdtd)
        {
            return new TestRepository().SaveReportDeliveryTimingDetail(rdtd);
        }

        public void PopulateRxSelectedTestData(IList<SelectedTestItemsForPatient> selectedTests, TestItem selectedItem, string testCode, string discount)
        {
            int testItemId;
            if (!int.TryParse(testCode.Trim(), out testItemId)) return;
            if (selectedTests.Any(x => x.Id == testItemId)) return;
            TestItem item = selectedItem;
            TestRepository repo = new TestRepository();
            if (item == null || item.TestId != testItemId)
            {
                item = repo.GetTestItemsById(testItemId);
            }

            selectedTests.Add(GetPreparedSelectedTestObject(item, discount));
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObject(TestItem item, string disc)
        {
           
                SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();
                selectedItemforpatient.Id = item.TestId;
                selectedItemforpatient.ReportTypeId = item.ReportTypeId;
                selectedItemforpatient.Name = item.Name;
                selectedItemforpatient.Cost = item.Rate;
                selectedItemforpatient.discountInPercent = disc;
                selectedItemforpatient.DeliveryDate = "";
                selectedItemforpatient.DeliveryTime = "";


                return selectedItemforpatient;
          
        }

        public async Task<List<ReportDeliveryTimingDetail>> GetSelectedReportDeliveryTimingDetail(int rDTMId)
        {
            return await new TestRepository().GetSelectedReportDeliveryTimingDetail(rDTMId);
        }

        public async Task<ReportDeliveryTimingMaster> GetSelectedReportDeliveryTimeMaster()
        {
            return await new TestRepository().GetSelectedReportDeliveryTimeMaster();
        }

        public bool UpdateBarCodeLabel(BarCodeLabelSettingForTest _sLs)
        {
            return new TestRepository().UpdateBarCodeLabel(_sLs);
        }

        public bool DeleteFromVacuList(int VacuId,int testId)
        {
            return new TestRepository().DeleteFromVacuList(VacuId,testId);
        }

        public VacuWithTestSetting FindVacuTestSettingByTestId(int testId)
        {
            return new TestRepository().FindVacuTestSettingByTestId(testId);
        }

        public List<VMVacuTestSetting> GetVacuWithTestList(int vTId)
        {
            return new TestRepository().GetVacuWithTestList(vTId);
        }

        public bool AddTestWithVacutainer(VacuWithTestSetting _vts)
        {
            return new TestRepository().AddTestWithVacutainer(_vts);
        }

        public List<VacuType> GetVacuList()
        {
            return new TestRepository().GetVacuList();
        }

        public bool DeleteBarcodeLabelSetting(int settingId)
        {
            return new TestRepository().DeleteBarcodeLabelSetting(settingId);
        }

        public List<BarCodeLabelSettingForTest> GetBarcodeLabelList(int testId)
        {
            return new TestRepository().GetBarcodeLabelList(testId);
        }

        public bool SaveBarCodeLabel(BarCodeLabelSettingForTest _sbSetting)
        {
           return new TestRepository().SaveBarCodeLabel(_sbSetting);
        }

        public List<TestItem> GetAllFilteredPathologicalTest(string _searchStr)
        {
            return new TestRepository().GetAllFilteredPathologicalTest(_searchStr);
        }

        public IList<ViewModelReportTests> GetAllNonLabTestByPatientId(long patientId)
        {
            return new TestRepository().GetAllNonLabTestByPatientId(patientId);
        }

        public ConsultantFee GetCurrentCosultantFeeByTestId(int rCId, int testId)
        {
            return new TestRepository().GetCurrentCosultantFeeByTestId(rCId, testId);
        }

        public List<TestGroup> GetConsultancyGroups()
        {
           return  new TestRepository().GetConsultancyGroups();
        }

        public void UpdateConsultancyFeeRate(ConsultantFee _currenCf)
        {
             new TestRepository().UpdateConsultancyFeeRate(_currenCf);
        }

        public void AddConsultancyFeeRate(List<ConsultantFee> _newCFlist)
        {
            new TestRepository().AddConsultancyFeeRate(_newCFlist);
        }

        public void UpdateSubItemTestCode(int testId, int testCode)
        {
            new TestRepository().UpdateSubItemTestCode(testId, testCode);
        }

        public List<TestSubItem> GetSubTestListByTestId(int testId)
        {
            return new TestRepository().GetSubTestListByTestId(testId);
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObjectForVacuItem(IList<SelectedTestItemsForPatient> selectedTests, TestItem subItem, DateTime dtpDeliveryDate, string deliveryTime, int displayOrder, TestItem testItem)
        {
            SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();

            int _initialVacuQty = 1;
            if (testItem.TestId == 204) { _initialVacuQty = 3; } else if(testItem.TestId == 1821) { _initialVacuQty = 2; }


            selectedItemforpatient.Id = subItem.TestId;
                selectedItemforpatient.TestCode = subItem.TestCode;
                selectedItemforpatient.ReportTypeId = subItem.ReportTypeId;
            if (_initialVacuQty > 1)
            {
                selectedItemforpatient.Name = subItem.Name + "-"+ _initialVacuQty.ToString()+"Pcs";
            }
            else
            {
                selectedItemforpatient.Name = subItem.Name;
            }


            selectedItemforpatient.Qty = _initialVacuQty;
            selectedItemforpatient.Cost = subItem.Rate * _initialVacuQty;
                selectedItemforpatient.discountInPercent = "";
                selectedItemforpatient.discount = "";

                if (subItem.ReportTypeId == 63)
                {
                    selectedItemforpatient.DeliveryDate = "";
                    selectedItemforpatient.DeliveryTime = "";
                }

              selectedItemforpatient.AdditionType = "";
              selectedItemforpatient.DisplayOrder = displayOrder;


            return selectedItemforpatient;
        }

        public void UpdateReportType(ReportType _rType)
        {
            new TestRepository().UpdateReportType(_rType);
        }

        public bool UpdateTestGroup(TestGroup _tgroup)
        {
            return new TestRepository().UpdateTestGroup(_tgroup);
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObjectFromTestSubItem(TestItem subItem, DateTime dtpDeliveryDate, string deliveryTime)
        {
            SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();

                selectedItemforpatient.Id = subItem.TestId;
                selectedItemforpatient.TestCode = subItem.TestCode;
                selectedItemforpatient.ReportTypeId = subItem.ReportTypeId;
                selectedItemforpatient.Name = subItem.Name;
                selectedItemforpatient.Cost = subItem.Rate;
                selectedItemforpatient.discountInPercent = "";
                selectedItemforpatient.discount = "";

               if (subItem.ReportTypeId == 63)
               {
                  selectedItemforpatient.DeliveryDate = "";
                  selectedItemforpatient.DeliveryTime = "";
              }
              else
              {
                  selectedItemforpatient.DeliveryDate = dtpDeliveryDate.ToString(Configuration.DATE_TIME_FORMAT);
                  selectedItemforpatient.DeliveryTime = deliveryTime;
             }

            selectedItemforpatient.AdditionType = "New";

            return selectedItemforpatient;
        }

        public List<TestItem> GetAllTestItemByTestCode(int _testCode)
        {
            return new TestRepository().GetAllTestItemByTestCode(_testCode);
        }

        public bool SaveReportType(ReportType _rType)
        {
            return new TestRepository().SaveReportType(_rType);
        }

        public TestItem GetTestItemByTestCode(int _testCode)
        {
            return new TestRepository().GetTestItemByTestCode(_testCode);
        }

        public List<TestItem> GetAllTestByGroupId(int _groupId)
        {
           return  new TestRepository().GetAllTestByGroupId(_groupId);
        }

        public bool IsReportPrinted(Patient _Patient, int _itemId)
        {
            return new TestRepository().IsReportPrinted(_Patient, _itemId);
        }

        public List<VMConsutantentTstFeeSeupt> GetAllTestByReportType(int repotTypeId)
        {
            return new TestRepository().GetAllTestByReportType(repotTypeId);
        }

        public void DeleteTestItem(TestItem testItem)
        {
            new TestRepository().DeleteTestItem(testItem);
        }

        public TestItem GetTestItemById(int testId)
        {
            return new TestRepository().GetTestItemById(testId);
        }

        public bool DeleteTestGroup(TestGroup _tGroup)
        {
            return new TestRepository().DeleteTestGroup(_tGroup);
        }

        public List<ReportType> GetReportTypesByGroupId(int _groupId)
        {
            return new TestRepository().GetReportTypesByGroupId(_groupId);
        }

        public bool UpdateTestItemCollectionType(List<TestItem> _tList, int _reportTypeId)
        {
            return new TestRepository().UpdateTestItemCollectionType(_tList, _reportTypeId);
        }

        public bool SaveMasterGroup(MasterTestGroup _masterTestGroup)
        {
            return new TestRepository().SaveMasterGroup(_masterTestGroup);
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObject(TestItem item, DateTime dtpDeliveryDate, string deliveryTime, int displayOrder, bool isTube)
        {

            string _discountPlanGroup = this.GetDiscountPlanGroup(item.ReportTypeId);

            SelectedTestItemsForPatient selectedItemforpatient = new SelectedTestItemsForPatient();
            selectedItemforpatient.Id = item.TestId;
            selectedItemforpatient.TestCode = item.TestCode;
            selectedItemforpatient.ReportTypeId = item.ReportTypeId;
            selectedItemforpatient.Name = item.Name;
            selectedItemforpatient.Cost = item.Rate;
            selectedItemforpatient.discountInPercent = "";
            selectedItemforpatient.discount = "";
            if (isTube)
            {
                selectedItemforpatient.DeliveryDate = "";
                selectedItemforpatient.DeliveryTime = "";
            }
            else {
                if (item.DayNeededForReportDelivery > 0)
                {
                    selectedItemforpatient.DeliveryDate = dtpDeliveryDate.AddDays(item.DayNeededForReportDelivery).ToString(Configuration.DATE_TIME_FORMAT);
                    selectedItemforpatient.DeliveryTime = "8:30 PM";
                }
                else
                {
                    selectedItemforpatient.DeliveryDate = dtpDeliveryDate.ToString(Configuration.DATE_TIME_FORMAT);
                    selectedItemforpatient.DeliveryTime = deliveryTime;
                }
            }

            selectedItemforpatient.AdditionType = "New";  // Newly added test for entry
            selectedItemforpatient.DiscountPlanGroup = _discountPlanGroup;
            selectedItemforpatient.DisplayOrder = displayOrder;
            return selectedItemforpatient;
        }

        private string GetDiscountPlanGroup(int reportTypeId)
        {
            ReportType _reportType = new TestRepository().GetReportTypesById(reportTypeId);
            if (_reportType != null)
            {
                TestGroup _testGroup = new TestRepository().GetTestGroupById(_reportType.TestGroupId);

                return _testGroup.DiscountPlanGroup;
            }else
            {
                return "";
            }
        }

        public bool UpdateMasterGroup(MasterTestGroup _master)
        {
            return new TestRepository().UpdateMasterGroup(_master);
        }

        public MasterTestGroup GetMasterTestGroupById(int _MasterId)
        {
            return new TestRepository().GetMasterTestGroupById(_MasterId);
        }

        public List<MasterTestGroup> GetMasterGroups()
        {
            return new TestRepository().GetMasterGroups();
        }

        public void PopulateSampleCollectionSettingData(IList<VMSampleCollectionRole> _SCRole, List<SampleCollectionSetting> listSCRole, TestItem _tItem, int v1, int v2)
        {
            if (listSCRole == null && _tItem == null) return;

            TestItem item = _tItem;
            TestRepository repo = new TestRepository();
            if (item == null)
            {
                foreach (SampleCollectionSetting scsItem in listSCRole)
                {
                    //if (!_SCRole.Any(x => x.MainTestId == scsItem.MainTestId))
                    //{

                        _SCRole.Add(GetPreparedSCSItem(scsItem, _SCRole.Count()));
                    //}
                }
            }
            else
            {
                if (item != null)
                {
                    _SCRole.Add(GetPreparedSCSItemfromTestItem(item, _SCRole.Count()));
                }
            }
        }

        private VMSampleCollectionRole GetPreparedSCSItemfromTestItem(TestItem item, int _itemCount)
        {
            VMSampleCollectionRole _VSCS = new VMSampleCollectionRole();
            _VSCS.MainTestId = item.TestId;
            _VSCS.SerialNo = _itemCount + 1;
            _VSCS.Description = item.Name;

            return _VSCS;
        }

        private VMSampleCollectionRole GetPreparedSCSItem(SampleCollectionSetting scsItem, int _itemCount)
        {
            VMSampleCollectionRole _VSCS = new VMSampleCollectionRole();
            _VSCS.MainTestId = scsItem.MainTestId;
            _VSCS.SerialNo = _itemCount + 1;
            _VSCS.Description = scsItem.Description;

            return _VSCS;
        }

        public List<SampleCollectionSetting> GetSampleCollectionSetting(int testId)
        {
            return   new TestRepository().GetSampleCollectionSetting(testId);
        }

        public void DeleteReportType(ReportType _rType)
        {
             new TestRepository().DeleteReportType(_rType);
        }

        public TestsCost GetTestCostById(long _pId, int testId)
        {
            return new TestRepository().GetTestCostById(_pId, testId);
        }

        public List<VMInvestigationList> GetIPDPatientInvestigations(long billNo)
        {
            return new TestRepository().GetIPDPatientInvestigations(billNo);
        }

        public bool SaveSampleCollectionSetting(List<SampleCollectionSetting> _sItemList)
        {
            return new TestRepository().SaveSampleCollectionSetting(_sItemList);
        }

        public IList<ViewModelReportTests> GetAllTestByRegNoLegacy(long regNo, int RCId)
        {
            return new TestRepository().GetAllTestByRegNoLegacy(regNo, RCId);
        }

        public bool UpdateTestCost(List<TestsCost> _testList)
        {
            return new TestRepository().UpdateTestCost(_testList);
        }

        public List<TestSubItem> GetSubTestListByMainTestId(int _testId)
        {
            return new TestRepository().GetSubTestListByMainTestId(_testId);
        }

        public void PopulateSubTestItemData(IList<VMTestSubItem> _SubItems, List<TestSubItem> listTestSubItems, TestItem _tItem, int _MainTestId, int _Qty,double _rate, bool IsPackage)
        {
           
            if (listTestSubItems == null && _tItem == null) return;

            TestItem item = _tItem;
            TestRepository repo = new TestRepository();
            if (item == null)
            {
                foreach (TestSubItem subItem in listTestSubItems)
                {
                    if (!_SubItems.Any(x => x.TestId == subItem.TestId))
                    {

                        _SubItems.Add(GetPreparedSubItem(subItem));
                    }
                }
            }else
            {
                if(item!=null && !_SubItems.Any(x => x.TestId == item.TestId))
                {
                    _SubItems.Add(GetPreparedSubItem(item, _MainTestId, _Qty,_rate));
                }

                if (IsPackage)
                {
                    List<TestItem> _vacues = new TestService().GetVacuesForSelectTest(item.TestId);

                    foreach (TestItem itmObj in _vacues)
                    {
                        if (!_SubItems.Any(x => x.TestId == itmObj.TestId))
                        {

                            _SubItems.Add(GetPreparedSubItem(itmObj, _MainTestId,1, itmObj.Rate));
                        }
                    }
                }

            }

           
        }

        private List<TestItem> GetVacuesForSelectTest(int testId)
        {
            return new TestRepository().GetVacuesForSelectTest(testId);
        }

        private VMTestSubItem GetPreparedSubItem(TestSubItem subItem)
        {
            VMTestSubItem _sItem = new VMTestSubItem();
            _sItem.MainTestId = subItem.MainTestId;
            _sItem.TestId = subItem.TestId;
            _sItem.Name = subItem.Name;
            _sItem.Rate = subItem.Rate;
            _sItem.Qty = subItem.Qty;
            _sItem.ReportTypeId = subItem.ReportTypeId;
            _sItem.Specimen = subItem.Specimen;
            _sItem.SC = subItem.SC;
            _sItem.AdditionType = "Old"; // Already added in subitem list
            return _sItem;
        }

        private VMTestSubItem GetPreparedSubItem(TestItem item, int _MainTestId, int _Qty, double _rate)
        {
            VMTestSubItem _sItem =new VMTestSubItem();
            _sItem.MainTestId = _MainTestId;
            _sItem.TestId = item.TestId;
            _sItem.Name = item.Name;
            _sItem.Rate = _rate;
            _sItem.Qty = _Qty;
            _sItem.ReportTypeId = item.ReportTypeId;
            _sItem.SC = 0;
            _sItem.Specimen = item.Specimen;
            _sItem.AdditionType = "New";
            return _sItem;
        }

        public IList<ViewModelReportTests> GetAllPathologyTestByRegNoLegacy(long regNo)
        {
            return new TestRepository().GetAllPathologyTestByRegNoLegacy(regNo);
        }

        public bool SaveSubItem(List<TestSubItem> _sItemList)
        {
            return new TestRepository().SaveSubItem(_sItemList);
        }

        public ViewModelReportTests GetSelectedTestByRegNoLegacy(long RegNo, string TestId)
        {
            return new TestRepository().GetSelectedTestByRegNoLegacy(RegNo, TestId);
        }

        public bool SaveTestGroup(TestGroup testGroupName)
        {
            return new TestRepository().SaveTestGroup(testGroupName);
        }

        public List<TestGroup> GetAllGroup()
        {
            return new TestRepository().GetAllGroup();
        }

        public bool SaveTest(TestItem _tItem)
        {
            return new TestRepository().SaveTest(_tItem);
        }

        public List<TestsCost> GetCancelledTestList(long patientId)
        {
            return new TestRepository().GetCancelledTestList(patientId);
        }

        public List<TestItem> GetAllTestByReportTypeId(int ReportTypeId)
        {
            return new TestRepository().GetAllTestByReportTypeId(ReportTypeId);
        }

        public bool CheckIsReportPrintedForThisPatient(Patient _Patient)
        {
            return new TestRepository().CheckIsReportPrintedForThisPatient(_Patient);
        }

        public void UpdateTestItem(TestItem _Item)
        {
            new TestRepository().UpdateTestItem(_Item);
        }

        public TestItem GetTestItemByName(string testName)
        {
           return new TestRepository().GetTestItemByName(testName);
        }

        public bool SaveReportDefination(ReportDefination _reportdef)
        {
            return new TestRepository().SaveReportDefination(_reportdef);
        }

        public IList<ReportDefination> GetTestItemDetailByTestId(int itemId)
        {
            return new TestRepository().GetTestItemDetailByTestId(itemId);
        }

        public TestItemDetail GetTestItemDetailByItemDetailId(int itemdetailId)
        {
            return new TestRepository().GetTestItemDetailByItemDetailId(itemdetailId);
        }

        public bool UpdateTestItemDetail(ReportDefination _Item)
        {
            return new TestRepository().UpdateTestItemDetail(_Item);
        }



        public void PopulateSelectedTestForReport(IList<VMReportDefination> _SelectedTestItemsForPathologyReport,  List<VMReportDefination> _testList)
        {
            if (_testList.Count == 0) return;

            foreach (var item in _testList)
            {
                if (_SelectedTestItemsForPathologyReport.Count==0)
                {
                    _SelectedTestItemsForPathologyReport.Add(item);

                }else if(!_SelectedTestItemsForPathologyReport.Any(x => x.TestDetailId == item.TestDetailId) && _SelectedTestItemsForPathologyReport.Any(x => x.ReportTypeId == item.ReportTypeId))
                {
                    _SelectedTestItemsForPathologyReport.Add(item);
                }
                
            }
  
        }

        public List<PathologicalMachine> GetAllPathologicalMachines()
        {
            return new TestRepository().GetAllPathologicalMachines();
        }

        public ReportType GetReportTypesById(int _reportTypeId)
        {
            return new TestRepository().GetReportTypesById(_reportTypeId);
        }

        public double GetDiscountedAmount(long RegNo)
        {
            return new TestRepository().GetDiscountedAmount(RegNo);
        }

        public ViewModelReportTests GetSelectedPathTestByRegNoLegacy(string regNo, string testId)
        {
            return new TestRepository().GetSelectedPathTestByRegNoLegacy(regNo, testId);
        }

        public TestGroup GetTestGroupById(int _tgId)
        {
            return new TestRepository().GetTestGroupById(_tgId);
        }

        public IList<ReportDefination> GetTestReportDefinationByTestId(int _testId)
        {
            return new TestRepository().GetTestReportDefinationByTestId(_testId);
        }

        public ReportDefination GetTestReportDefinationById(int _reportdetailId)
        {
            return new TestRepository().GetTestReportDefinationById(_reportdetailId);
        }

        public bool DeleteReportDefination(ReportDefination _reportDef)
        {
            return new TestRepository().DeleteRepositoryDefination(_reportDef);
        }

        public void PopulateSelectedTestForGroupReport(IList<SelectedTestItemsForPatient> _SelectedTests, TestItem selectedItem, string testCode)
        {
            int testItemId;
            if (!int.TryParse(testCode.Trim(), out testItemId)) return;
            if (_SelectedTests.Any(x => x.Id == testItemId)) return;
            TestItem item = selectedItem;
           
            if (item == null) return;

            _SelectedTests.Add(GetPreparedSelectedTestObject(item, false));
        }

        private SelectedTestItemsForPatient GetPreparedSelectedTestObject(TestItem item, bool p)
        {
            SelectedTestItemsForPatient _selectedTest = new SelectedTestItemsForPatient();
            _selectedTest.Id = item.TestId;
            _selectedTest.Name = item.Name;
            _selectedTest.ReportOrder = item.ReportOrder;
            return _selectedTest;
        }

        public bool SaveGroupTestItem(List<GroupReportItem> gItems)
        {
            return new TestRepository().SaveGroupTestItem(gItems);
        }

        public IList<GroupReportItem> GetGroupRetportItemsById(int _itemId)
        {
            return new TestRepository().GetGroupRetportItemsById(_itemId).ToList();
        }

        public string GetDailyStatementHeaderName(int _itemId)
        {
            TestItem _testItem = new TestService().GetTestItemById(_itemId);
            if (_testItem != null)
            {
                if((_testItem.ReportTypeId==2) || (_testItem.ReportTypeId== 38) || (_testItem.ReportTypeId==18) || (_testItem.ReportTypeId==5) || 
                    (_testItem.ReportTypeId==16) || (_testItem.ReportTypeId==6) || (_testItem.ReportTypeId==19) || (_testItem.ReportTypeId==10) || (_testItem.ReportTypeId==27)||
                    (_testItem.ReportTypeId == 7) || (_testItem.ReportTypeId == 8) || (_testItem.ReportTypeId == 11) || (_testItem.ReportTypeId == 12) || (_testItem.ReportTypeId == 14)
                    || (_testItem.ReportTypeId == 17) || (_testItem.ReportTypeId == 24) || (_testItem.ReportTypeId == 21) || (_testItem.ReportTypeId == 22) || (_testItem.ReportTypeId == 51) || (_testItem.ReportTypeId == 53) || (_testItem.ReportTypeId == 60))
                {
                    return "Pathology";
                }

                if (_testItem.ReportTypeId == 34)
                {
                    return "ANAESTHESIA";
                }

                if (_testItem.ReportTypeId == 13)
                {
                    return "USG";
                }

                if (_testItem.ReportTypeId == 15)
                {
                    return "XRay";
                }

                if (_testItem.ReportTypeId == 63)
                {
                    return "Vacutainer"; 
                }

                if (_testItem.ReportTypeId == 26)
                {
                    return "CLONOSCOPY";
                }

                if (_testItem.ReportTypeId == 43)
                {
                    return "COLOR DOPPLER";
                }

                if (_testItem.ReportTypeId == 23)
                {
                    return "CTSCAN";
                }

                if (_testItem.ReportTypeId == 33)
                {
                    return "ECG";
                }

                if (_testItem.ReportTypeId == 3)
                {
                    return "ECHO";
                }

                if (_testItem.ReportTypeId == 25)
                {
                    return "EEG";
                }

                if (_testItem.ReportTypeId == 25)
                {
                    return "Endoscopy";
                }

                if (_testItem.ReportTypeId == 32)
                {
                    return "ETT";
                }

                if (_testItem.ReportTypeId == 41)
                {
                    return "HOLTERECG";
                }

                if (_testItem.ReportTypeId == 36)
                {
                    return "MEMMOGRAPHY";
                }

                if (_testItem.ReportTypeId == 37)
                {
                    return "SPIROMETRY";
                }

            }

            return "";
        }

        public IList<UXEntryList> GetUXEntryListByDate(DateTime _dt)
        {
            return new TestRepository().GetUXEntryListByDate(_dt);
        }

        public void PopulateKeyItems(IList<RegUniqueKeyTracker> _ukeyList, long _regNumber, string workStationId)
        {
            RegUniqueKeyTracker ukey = new RegUniqueKeyTracker();
            ukey.RegNo = _regNumber;
            ukey.GenerateFrom = workStationId;
           _ukeyList.Add(ukey);

        }

        public void UpdateReportStatus(List<VMReportDefination> _DistinctTestObj)
        {
            new ReportRepository().UpdateReportStatus(_DistinctTestObj);
        }

        public ReportDeliveryTimingMaster GetWeekEndReportDeliveryTimingMaster()
        {
            return  new ReportRepository().GetWeekEndReportDeliveryTimingMaster();
        }

        public List<ReportDeliveryTimingDetail> GetReportDeliveryTimingDetail(int rDTMId)
        {
            return new ReportRepository().GetReportDeliveryTimingDetail(rDTMId);
        }

        public ReportDeliveryTimingMaster GetRegularReportDeliveryTimeMaster()
        {
            return new ReportRepository().GetRegularReportDeliveryTimeMaster();
        }

        public List<VMGroupName> GetDistinctGroup(long _pId)
        {
            return new TestRepository().GetDistinctGroup(_pId);
        }

        public int GetCategoryIdByMediaId(int mediaId)
        {
            return new TestRepository().GetCategoryIdByMediaId(mediaId);
        }

        public List<MediaCategoryReportTypeCommission> GetReportTypeByCategoryId(int mediaCategoryId, int mediaId, int ReportTypeId)
        {
            return new TestRepository().GetReportTypeByCategoryId(mediaCategoryId, mediaId, ReportTypeId);
        }
    }
}
