using HDMS.Model;
using HDMS.Model.Pharmacy;
using HDMS.Model.Rx;
using HDMS.Model.ViewModel;
using HDMS.Models.Pharmacy;
using HDMS.Repository.Diagonstics;
using HDMS.Repository.Rx;
using HDMS.Service.Diagonstics;
using HDMS.Service.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Pharmacy.ViewModels;
using System.Data;
using HDMS.Model.Common;
using HDMS.Repositories.Pharmacy;
using System.Globalization;

namespace HDMS.Service.Rx
{
    public class RxService
    {

        

        public List<RxCPAdvice> GetAdvicesByCP(int cPId)
        {
            return new RxRepository().GetAdvicesByCP(cPId);
        }

        public bool SaveDosages(RxCpDosage _rxD)
        {
            return new RxRepository().SaveDosages(_rxD);
        }

        private RxVMTestTemplate GetPreparedSelectedTestObject(TestItem item)
        {
            RxVMTestTemplate selectedItemforpatient = new RxVMTestTemplate();
            selectedItemforpatient.CPPTId = item.TestId;
            selectedItemforpatient.Name = item.Name;
            
            return selectedItemforpatient;
        }

        public IList<RxCPAdvice> GetRxCPAdvices(int cpId)
        {
            return new RxRepository().GetRxCPAdvices(cpId);
        }

        public bool SaveCPPreferredDrugs(RxCPPreferredMedicine preferredMedicine)
        {
            return new RxRepository().SaveCPPreferredDrugs(preferredMedicine);
        }

        public List<VMCPPreferredMedicine> GetCpPreferredMedicine(int cPId)
        {
            return new RxRepository().GetCpPreferredMedicine(cPId);
        }

        public List<RxCPPreferredTest> GetRxCpPreferredTestlist(int cPId)
        {
            return new RxRepository().GetRxCpPreferredTestlist(cPId);
        }

        public bool UpdateCDbDosages(RxDosage rxD)
        {
            return new RxRepository().UpdateCDbDosages(rxD);
        }

        public RxCarryOnBlock GetRxCarryOnBlocks(int cPId)
        {
            return new RxRepository().GetRxCarryOnBlocks(cPId);
        }

        public bool UpdateDosages(RxCpDosage rxD)
        {
            return new RxRepository().UpdateDosages(rxD);
        }

        public List<VMGenericWithDefaultDose> GetDefaultDoseWithGeneric()
        {
            return new RxRepository().GetDefaultDoseWithGeneric();
        }

        public IList<RxDosage> GetRxCDbAllDosage()
        {
            return new RxRepository().GetRxCDbAllDosage();
        }

        public IList<VMPreferredTestParameter> GetPreferredTestParameterListByTestId(int testId)
        {
            return new RxRepository().GetPreferredTestParameterListByTestId(testId);
        }

        public List<RxDoseApplication> GetRxDoseApplication()
        {
            return new RxRepository().GetRxDoseApplication();
        }

        public void SavePrintPreference(RxPrintPreference _printPref)
        {
            new RxRepository().SavePrintPreference(_printPref);
        }

        public bool SetDoseAsDefaultBasedOnGenAndFormation(Generic gen, Formation form, RxDosage rxDosage)
        {
           return  new RxRepository().SetDoseAsDefaultBasedOnGenAndFormation(gen, form, rxDosage);
        }

        public bool SaveCDbDosages(RxDosage rxD)
        {
           return  new RxRepository().SaveCDbDosages(rxD);
        }

        public void DeleteAccessPermissionItem(int userId, string option)
        {
            new RxRepository().DeleteAccessPermissionItem(userId, option);
        }

        public bool SaveCpPersonalDoseWithGeneric(RxCpDosageWithGenericMapping mappingObj)
        {
            return   new RxRepository().SaveCpPersonalDoseWithGeneric(mappingObj);
        }

        public IList<RxCpDosage> GetRxCPDosages(int cpId)
        {
            return  new RxRepository().GetRxCPDosages(cpId);
        }

        public bool UpdateAdvices(RxCPAdvice adv)
        {
            return new RxRepository().UpdateAdvices(adv);
        }

        public async Task<RxPatientMasterData> GetRxMasterDataAsync(long regNo)
        {
            return await new RxRepository().GetRxMasterDataAsync(regNo);
        }

        public List<RxDoseEMRInterpretation> GetEMRInterpretList()
        {
            return new RxRepository().GetEMRInterpretList();
        }

        public IList<RxCPPreferredTest> GetRxCpAllPreferredTests(int cpId)
        {
            return  new RxRepository().GetRxCpAllPreferredTests(cpId);
        }

        public async Task<RxVisitHistory> GetLastRxVisitHistoryAsync(long rxPMId, int _cpId)
        {
            return  await new RxRepository().GetLastRxVisitHistoryAsync(rxPMId, _cpId);
        }

        public async Task<List<RxDosage>> GetRxCDbDosageList()
        {
            return await new RxRepository().GetRxCDbDosageList();
        }

        public IList<RxCpDosage> GetAllDosage()
        {
           return  new RxRepository().GetAllDosage();
        }

        public bool AddAdvices(RxCPAdvice _adv)
        {
            return new RxRepository().AddAdvices(_adv);
        }

        public void InsertOrUpdateRxCpPrintPageSetup(RxCPPrintPageSetup ps)
        {
            new RxRepository().InsertOrUpdateRxCpPrintPageSetup(ps);
        }

        public IList<RxCPTestTemplateMaster> GetRxTestTemplateItems(string _type)
        {
            return new RxRepository().GetRxTestTemplateItems(_type);
        }

       

        public List<RxCpDosage> GetRxDosageList(int CpId)
        {
            return new RxRepository().GetRxDosageList(CpId);
        }

        public void SaveRxCpPreferredTestInPersonalDb(RxCPPreferredTest pt)
        {
            new RxRepository().SaveRxCpPreferredTestInPersonalDb(pt);
        }

        public bool UpdateDiagnosis(RxDiagnosis _diagnosis)
        {
            return new RxRepository().UpdateDiagnosis(_diagnosis);
        }

        public void DeleteAdviceFromCpPersonalDb(RxCPAdvice selectedItem)
        {
            new RxRepository().DeleteAdviceFromCpPersonalDb(selectedItem);
        }

        public void PopulateSelectedProductDataForIPDPatient(IList<SelectedMedicineForPatientOnDischarge> _SelectedProducts, VWPhProductList productInfo, string pCode, RxDosage dosage, RxDoseApplication _beforeAfter, string duration, RxDuration _duration, bool IsPreferredShortDescription)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedProducts.Any(x => x.Id == ItemId)) return;

            _SelectedProducts.Add(GetPreparedSelectedItemObjectForIPD(productInfo, dosage, _beforeAfter, duration, _duration, IsPreferredShortDescription));
        }

        public void DeleteDoseFromCpPersonalDb(RxCpDosage _dose)
        {
            new RxPhProductRepository().DeleteDoseFromCpPersonalDb(_dose);
        }

        public bool UpCPPreferredDrugs(RxCPPreferredMedicine preferredMedicine)
        {
            return new RxPhProductRepository().UpCPPreferredDrugs(preferredMedicine);
        }

        public void PopulateSelectedProductDataForRxPatient(IList<RxSelectedMedicineForPatient> _SelectedProducts, VWPhProductList productInfo, string pCode, RxCpDosage dosage, RxDoseApplication _beforeAfter, string duration, RxDuration _duration, bool IsPreferredShortDescription)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedProducts.Any(x => x.CPPMId == ItemId)) return;

            _SelectedProducts.Add(GetPreparedSelectedItemObjectForRx(productInfo, dosage, _beforeAfter, duration, _duration, IsPreferredShortDescription));
        }

        public RxCPPreferredMedicine GetRxPreferredMedicine(int productId, int cPId)
        {
            return new RxRepository().GetRxPreferredMedicine(productId, cPId);
        }

        public void DeleteTestFromCpPersonalDb(RxCPPreferredTest selectedItem)
        {
            new RxRepository().DeleteTestFromCpPersonalDb(selectedItem);
        }

        public List<RxCPOtherFinding> GetRxCPOtherFindingsData(int cPId)
        {
            return new RxRepository().GetRxCPOtherFindingData(cPId);
        }

        public List<RxCPPastHistory> GetRxCPPastHistoryData(int cPId)
        {
            return new RxRepository().GetRxCPPastHistoryData(cPId);
        }

        public List<TitleOrNamePrefix> GetTitleStrings()
        {
            return new RxRepository().GetTitleStrings();
        }

        public List<RxCPHistory> GetRxCPHistoryData(int cPId)
        {
            return new RxRepository().GetRxCPHistoryData(cPId);
        }

        public async Task<List<RxCPPrintPageSetup>> GetRxCPPageSetup(int cPId)
        {
            return await new RxRepository().GetRxCPPageSetup(cPId);
        }

        private SelectedMedicineForPatientOnDischarge GetPreparedSelectedItemObjectForIPD(VWPhProductList productInfo, RxDosage dosage, RxDoseApplication _beforeAfter, string duration, RxDuration _duration, bool IsPreferredShortDescription)
        {


            SelectedMedicineForPatientOnDischarge selectedProduct = new SelectedMedicineForPatientOnDischarge();
            selectedProduct.Id = productInfo.ProductId;
            selectedProduct.Name = productInfo.BrandName;
            if (IsPreferredShortDescription)
            {
                selectedProduct.dosage = dosage.DoseBnShort;

            }
            else
            {
                selectedProduct.dosage = dosage.DoseBnLong;

            }

           
            selectedProduct.BeforAfterMeal = _beforeAfter.DoseApplyRole;
            selectedProduct.IsBeforeAfterBanglaFont = _beforeAfter.IsBanglaFont;

            selectedProduct.duration = duration;
            selectedProduct.Unit = _duration.Name;
            selectedProduct.IsDurationBanglaFont = _duration.IsBanglaFont;

            return selectedProduct;
        }

        public List<RxPrintFormatTemplate> GetRxPrintFormatTemplates()
        {
            return new RxRepository().GetRxPrintFormatTemplates();
        }

        public List<RxCpSupportUserAccessOption> GetCpAssistAccessOptionsList(int userId)
        {
            return new RxRepository().GetCpAssistAccessOptionsList(userId);
        }

        public  RxPrintPreference GetRxPrintPreference(int cPId)
        {
            return new RxRepository().GetRxPrintPreference(cPId);
        }

        public DataSet GetRxAdvicedTestsDataSet(long rxVisitId, int cpId)
        {
            return new RxRepository().GetRxAdvicedTestsDataSet(rxVisitId, cpId);
        }

        public RxCpDosage GetRxCPDosageByDoseId(int doseId)
        {
            return new RxRepository().GetRxCPDosageByDoseId(doseId);
        }

        public DataSet GetRxFullDataSet(long rxVisitId, int cpId)
        {
            return new RxRepository().GetRxFullDataSet(rxVisitId, cpId);
        }

        private RxSelectedMedicineForPatient GetPreparedSelectedItemObjectForRx(VWPhProductList productInfo, RxCpDosage dosage, RxDoseApplication _beforeAfter, string duration, RxDuration _duration, bool IsPreferredShortDescription)
        {


            RxSelectedMedicineForPatient selectedProduct = new RxSelectedMedicineForPatient();
            selectedProduct.CPPMId = productInfo.ProductId;
            selectedProduct.BrandName = productInfo.BrandName;
            if (IsPreferredShortDescription)
            {
                selectedProduct.dosage = dosage.DoseBnShort;

            }else
            {
                selectedProduct.dosage = dosage.DoseBnLong;

            }

            //selectedProduct.IsDoseBanglaFont = dosage.IsBanglaFont;

            //selectedProduct.BeforAfterMeal = _beforeAfter.DoseApplyRole;
            //selectedProduct.IsBeforeAfterBanglaFont = _beforeAfter.IsBanglaFont;

            selectedProduct.duration = duration;
            //selectedProduct.Unit = _duration.Name;
            //selectedProduct.IsDurationBanglaFont = _duration.IsBanglaFont;

            return selectedProduct;
        }

        public void PopulateSelectedProductData(IList<RxSelectedMedicineForPatient> _SelectedProducts, VWPhProductList productInfo, string pCode, string dosage, string beforeafter, string duration)
        {
            int ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (_SelectedProducts.Any(x => x.CPPMId == ItemId)) return;

            _SelectedProducts.Add(GetPreparedSelectedItemObject(productInfo, dosage, beforeafter, duration));
        }

       

        public bool SaveRxTestTemplateMaster(RxCPTestTemplateMaster _templateMaster)
        {
            return new RxRepository().SaveRxTestTemplateMaster(_templateMaster);
        }

      

        public List<RxDiagnosis> GetRxDiagnosisList()
        {
            return new RxRepository().GetRxDiagnosisList();
        }

       
        public IList<RxDiagnosis> GetAllDiagnosis()
        {
            return new RxRepository().GetAllDiagnosis();
        }

        public DataSet GetRxTreatmentDataSet(long rxVisitId, int cpId)
        {
            return new RxRepository().GetRxTreatmentDataSet(rxVisitId, cpId);
        }

        public void SaveRxTestTemplateDetail(List<RxCPTestTemplateDetail> _tdList)
        {
            new RxRepository().SaveRxTestTemplateDetail(_tdList);
        }

        public bool DeleteExistingTreatment(VMIPDInfo _IpdInfo)
        {
            return new RxRepository().DeleteExistingTreatment(_IpdInfo);
        }

        public void SaveIPDTreatmentOnDischarge(List<TreatmentOnDischarge> _treatmentList)
        {
            new RxRepository().SaveIPDTreatmentOnDischarge(_treatmentList);
        }

        private RxSelectedMedicineForPatient GetPreparedSelectedItemObject(VWPhProductList productInfo, string dosage, string beforeafter, string duration)
        {
            string _dosage=dosage;
            if(!String.IsNullOrEmpty(beforeafter)){
                _dosage=_dosage+"("+beforeafter+")";
            }
            RxSelectedMedicineForPatient selectedProduct = new RxSelectedMedicineForPatient();
            selectedProduct.CPPMId = productInfo.ProductId;
            selectedProduct.BrandName = productInfo.BrandName;
            selectedProduct.dosage = _dosage;
            selectedProduct.duration = duration;
            return selectedProduct;
        }

        public List<RxCpDosage> GetDosages(int CpId)
        {
            return new RxRepository().GetDosages(CpId);
        }

        public async Task<RxInitialData> GetRxInitialDataObjAsync(long rxVisitId)
        {
            return await new RxRepository().GetRxInitialDataObjAsync(rxVisitId);
        }

        public List<MedicineInterX> LoadMedicineInterXs()
        {
            return new RxRepository().LoadMedicineInterXs();
        }

        public void PopulateRxSelectedTestData(IList<RxVMTestTemplate> selectedTests, TestItem item, string text, string v)
        {
           
            if (selectedTests.Any(x => x.TestId == item.TestId)) return;
            
            selectedTests.Add(GetRxPreparedSelectedTestObject(item));
        }

        private RxVMTestTemplate GetRxPreparedSelectedTestObject(TestItem item)
        {
            RxVMTestTemplate selectedItemforpatient = new RxVMTestTemplate();
            selectedItemforpatient.TestId = item.TestId;
            selectedItemforpatient.CPPTId = 0;
            selectedItemforpatient.Name = item.Name;

            return selectedItemforpatient;
        }

        public List<RxDuration> GetRxDuration()
        {
            return new RxRepository().GetRxDuration();
        }

        public bool SaveDiagnosis(RxDiagnosis _listrxDiagnosis)
        {
            return new RxRepository().SaveDiagnosis(_listrxDiagnosis);
        }

        public void AccumulatePrescriptionData(long rxVisitId, int cpId)
        {
            new RxRepository().AccumulatePrescriptionData(rxVisitId, cpId);
        }

        public async Task<List<RxVMPatientBasicInfo>> GetRxPatientListAsync(DateTime frmdate, DateTime todate, int cpId)
        {
            return await new RxRepository().GetRxPatientListAsync(frmdate, todate, cpId);
        }

        public bool SaveDrug(List<RxDrug> _listrxDrugs)
        {
            return new RxRepository().SaveDrug(_listrxDrugs);
        }

       
        public List<SelectedTestItemsForPatient> GetRxTestTemplateItem(long templateId)
        {
            return new RxRepository().GetRxTestTemplateItem(templateId);
        }

        public List<RxCPAdvice> GetAdvices()
        {
            return new RxRepository().GetAdvices();
        }

        public List<RxVMPatientBasicInfo> GetRxPatientList111(DateTime dtpfrm, DateTime dtpto)
        {
            return new RxRepository().GetRxPatientList(dtpfrm, dtpto);
        }

        public void InsertOrUpdateCpAssistantAccessPermission(List<RxCpSupportUserAccessOption> optlist)
        {
            new RxRepository().InsertOrUpdateCpAssistantAccessPermission(optlist);
        }

        public List<RxTest> GetRxTestsByRxId(long _RxVisitId)
        {
            return new RxRepository().GetRxTestsByRxId(_RxVisitId);
        }

        public System.Data.DataSet GetRxReportData(long _RxId)
        {
            return new RxRepository().GetRxReportData(_RxId);
        }

        internal List<RxDrug> GetRxDrugListByRxId(long _RxId)
        {
            return new RxRepository().GetRxDrugListByRxId(_RxId);
        }

        

        //public List<SelectedTestItemsForPatient> GetTestsByRxId(long _RxId)
        //{
        //    List<RxTest> _testList = new RxRepository().GetRxTests(_RxId);

        //    List<RxVMTestTemplate> _sTests = new List<RxVMTestTemplate>();

        //    foreach(var item in _testList)
        //    {
        //        RxVMTestTemplate _ti = new RxVMTestTemplate();
        //        _ti.CPPTId = item.CPPTId;

        //        RxCPPreferredTest _prfTest = new RxService().GetRxCpPreferredTest(item.CPPTId);
        //        TestItem _tItem = new TestService().GetTestItemById(item.TestId);

        //        _ti.ReportTypeId = _tItem.ReportTypeId;
        //        _ti.Name = _tItem.Name;
        //        _ti.Cost = _tItem.Rate;

        //        _ti.DeliveryDate = "";
        //        _ti.DeliveryTime = "";

        //        _sTests.Add(_ti);
        //    }


        //    return _sTests;

        //}

        public List<RxSelectedMedicineForPatient> GetSelectedMedicineByRxId(long _RxId)
        {
            List<RxDrug> _DrugList = new RxRepository().GetRxDrugs(_RxId);

            List<RxSelectedMedicineForPatient> _sMedicines = new List<RxSelectedMedicineForPatient>();

            foreach (var item in _DrugList)
            {
                RxSelectedMedicineForPatient _smp = new RxSelectedMedicineForPatient();
              
                RxCPPreferredMedicine _pInfo = new RxPhProductService().GetRxCPPProductById(item.CPPMId);

                _smp.CPPMId = item.CPPMId;
                _smp.BrandName = _pInfo.BrandName;
                _smp.dosage = item.dosage;
                _smp.duration = item.duration;
             
                _sMedicines.Add(_smp);
            }


            return _sMedicines;
        }

        public List<RxCpSupportUserAccessOption> GetCpAssistAccessOptions(int userId)
        {
            return new RxRepository().GetCpAssistAccessOptions(userId);
        }

        public void DeleteDrugFromCpPersonalDb(VMCPPreferredMedicine selectedItem)
        {
            new RxRepository().DeleteDrugFromCpPersonalDb(selectedItem);
        }

        public List<TreatmentOnDischarge> GetTreatmentOnDischarge(long admissionId)
        {
            return new RxRepository().GetTreatmentOnDischarge(admissionId);
        }

       

        public bool SaveRxTestSaved(List<RxTest> _listRxTests)
        {
            return new RxRepository().SaveRxTestSaved(_listRxTests);
        }

      

        public List<SelectedAdvice> GetSelectedAdicesByRxId(long _RxId)
        {
            List<RxAdviceToPatient> _advList = new RxRepository().GetRxAdvices(_RxId);

            List<SelectedAdvice> _sAdvices = new List<SelectedAdvice>();

            foreach (var item in _advList)
            {
                SelectedAdvice _sa = new SelectedAdvice();
                _sa.RxVisitId = item.RxVisitId;
                _sa.Advice = item.Advice;
               
                _sAdvices.Add(_sa);
            }


            return _sAdvices;
        }

       

        public void SaveAdvices(List<RxAdviceToPatient> _adviceList)
        {
            new RxRepository().SaveAdvices(_adviceList);
        }

      
       

        public void SaveRxPatientMasterData(RxPatientMasterData rxpMd)
        {
            new RxRepository().SaveRxPatientMasterData(rxpMd);
        }

        public void UpdateRxPatientPhysicalExam(RxPatientPhysicalExam _rxPhysicalExam)
        {
            new RxRepository().UpdateRxPatientPhysicalExam(_rxPhysicalExam);
        }

        public void SaveRxVisitHistory(RxVisitHistory visit)
        {
            new RxRepository().SaveRxVisitHistory(visit);
        }

        public void PopulateRxSelectedProductDataForPatient(IList<RxSelectedMedicineForPatient> selectedMedicines, VMPhProductListForRxPerspective productInfo, string pCode, string dose, string duration, int qty, bool isRxShortDoseDescriptionPreferred)
        {
            long ItemId;
            ItemId = productInfo.ProductId;
            if (productInfo == null) return;
            if (selectedMedicines!=null && selectedMedicines.Any(x => x.ProductId == ItemId)) return;

            selectedMedicines.Add(GetRxPreparedSelectedMedicineObj(productInfo, dose,  duration, qty, isRxShortDoseDescriptionPreferred));

        }

        private RxSelectedMedicineForPatient GetRxPreparedSelectedMedicineObj(VMPhProductListForRxPerspective productInfo, string dose, string duration,int _qty, bool isRxShortDoseDescriptionPreferred)
        {
            RxSelectedMedicineForPatient Obj = new RxSelectedMedicineForPatient();
            Obj.ProductId = productInfo.ProductId;
            Obj.GenericId = productInfo.GenericId;
            Obj.BrandName = productInfo.FormationShortName +" "+ productInfo.BrandName;
           
            Obj.dosage = dose;
            
            Obj.doseId = 0;
            Obj.duration = duration;
            Obj.Qty = _qty;

            return Obj;

        }

        private string GetProcessedBrandName(string brandName)
        {
            List<string> strList = new List<string>() { "Tab","Tab.","Tablet", "Tablet.", "Inj", "Inj.", "Injection", "Injection.","Cap","Cap.","Capsule", "Capsule." };
            string lastWord = brandName.Split(' ').Last();
            if (!string.IsNullOrEmpty(lastWord))
            {
                string matchWord = strList.Where(q => q.ToLower().Trim().Contains(lastWord.Trim().ToLower())).FirstOrDefault();
                if (!string.IsNullOrEmpty(matchWord))
                {
                    string _newStr = brandName.Replace(lastWord, "").Trim();
                    _newStr = matchWord + " " + _newStr;
                    _newStr = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_newStr.ToLower());

                    return _newStr;
                }

                return brandName;
            }
            else
            {
                return brandName;
            }
        }

        public void InsertOrUpdateRxInitialData(RxInitialData initialDataObj)
        {
            new RxRepository().InsertOrUpdateRxInitialData(initialDataObj);
        }

        public void PopulateAdvices(IList<SelectedAdvice> selectedAdvices,  RxCPAdvice _adviceObj, bool IsBnAdvice)
        {
            if (selectedAdvices.Any(x => x.RxCpAdvId == _adviceObj.RxCpAdvId)) return;
            SelectedAdvice advObj = new SelectedAdvice();
            advObj.RxCpAdvId = _adviceObj.RxCpAdvId;
            if (IsBnAdvice)
            {
                advObj.Advice = _adviceObj.AdviceBn;
            }
            else
            {
                advObj.Advice = _adviceObj.AdviceEn;
            }

            advObj.CPId = _adviceObj.CPId;


            selectedAdvices.Add(advObj);
        }

        public void PopulateDirectWrittenAdvices(IList<SelectedAdvice> selectedAdvices, string advice,int CPId)
        {
            RxCPAdvice _adv = new RxCPAdvice();
            _adv.AdviceEn = advice;
            _adv.CPId = CPId;

            if(new RxRepository().AddAdvices(_adv))
            {
                SelectedAdvice advObj = new SelectedAdvice();
                advObj.Advice = advice;
                advObj.RxCpAdvId = _adv.RxCpAdvId;

                selectedAdvices.Add(advObj);
            }

            
        }

        public void SaveRxCpHistory(RxCPHistory history)
        {
            new RxRepository().SaveRxCpHistory(history);
        }

        public void SaveRxCpPastHistory(RxCPPastHistory pasthistory)
        {
            new RxRepository().SaveRxCpPastHistory(pasthistory);
        }

        public void SaveRxCpOtherFindings(RxCPOtherFinding otherFindings)
        {
            new RxRepository().SaveRxCpOtherFindings(otherFindings);
        }

        public List<RxCpCC> GetRxCPCCData(int cPId)
        {
           return  new RxRepository().GetRxCPCCData(cPId);
        }

        public void SaveRxCpCC(RxCpCC cc)
        {
           new RxRepository().SaveRxCpCC(cc);
        }

        public async Task<IList<RxVMTestTemplate>> GetPatientTestsAsync(long rxVisitId)
        {
             return await new RxRepository().GetPatientTestsAsync(rxVisitId);
        }

        public async Task<IList<RxSelectedMedicineForPatient>> GetPatientTreatmentAsync(long rxVisitId)
        {
            return await new RxRepository().GetPatientTreatmentAsync(rxVisitId);
        }

        public async Task<IList<SelectedAdvice>> GetSelectedAdviceAsync(long rxVisitId)
        {
            return await new RxRepository().GetSelectedAdviceAsync(rxVisitId);
        }

        public async Task<bool> InsertOrUpdateRxDrugData(List<RxDrug> drugList)
        {
           return  await new RxRepository().InsertOrUpdateRxDrugData(drugList);
        }

        public void InsertOrUpdateRxTestData(List<RxTest> testList)
        {
            new RxRepository().InsertOrUpdateRxTestData(testList);
        }

        public bool DeleteRxDrug(RxSelectedMedicineForPatient selectedItem,long rxVhId)
        {
           return  new RxRepository().DeleteRxDrug(selectedItem, rxVhId);
        }

        public void InsertOrUpdateRxAdviceData(List<RxAdviceToPatient> advList)
        {
            new RxRepository().InsertOrUpdateRxAdviceData(advList);
        }

        public async Task<List<RxCPDiseaseTemplate>> GetDiseaseTemplateListAsync(int cPId)
        {
            return await new RxRepository().GetDiseaseTemplateListAsync(cPId);
        }

        public void SaveRxCpDiseaseTemplate(RxCPDiseaseTemplate dp)
        {
            new RxRepository().SaveRxCpDiseaseTemplate(dp);
        }

        public void SaveRxCPDiseaseTemplateHistoricalData(RxCPDiseaseTemplateHistoricalData hd)
        {
            new RxRepository().SaveRxCPDiseaseTemplateHistoricalData(hd);
        }

        public RxPersonalPreferenceSetting GetRxPersonalPrefernce(int cPId)
        {
           return new RxRepository().GetRxPersonalPrefernce(cPId);
        }

        public void SaveRxCPDiseaseTemplateTreatmentData(List<RxCPDiseaseTemplateTreatmentData> drugList)
        {
            new RxRepository().SaveRxCPDiseaseTemplateTreatmentData(drugList);
        }

        public bool UpdateRxPersonalPreference(RxPersonalPreferenceSetting ps)
        {
            return new RxRepository().UpdateRxPersonalPreference(ps);
        }

        public void SaveRxCPDiseaseTemplateTestData(List<RxCPDiseaseTemplateTestData> testList)
        {
            new RxRepository().SaveRxCPDiseaseTemplateTestData(testList);
        }

        public bool SaveRxPersonalPreference(RxPersonalPreferenceSetting ps)
        {
            return new RxRepository().SaveRxPersonalPreference(ps);
        }

        public void SaveRxCPDiseaseTemplateAdviceData(List<RxCPDiseaseTemplateAdviceData> advList)
        {
            new RxRepository().SaveRxCPDiseaseTemplateAdviceData(advList);
        }

        public IList<RxCPPreferredTest> GetCpAllPreferredTests()
        {
            throw new NotImplementedException();
        }

        public async Task<RxCPDiseaseTemplateHistoricalData> GetRxCPDiseaseTemplateHistoricalData(long dTId)
        {
           return await new RxRepository().GetRxCPDiseaseTemplateHistoricalData(dTId);
        }

        public async Task<List<RxSelectedMedicineForPatient>> GetRxCPDiseaseTemplateTreatmentDataAsync(long dTId)
        {
            return await new RxRepository().GetRxCPDiseaseTemplateTreatmentDataAsync(dTId);
        }

        public async Task<IList<RxVMTestTemplate>> GetRxCpDiseaseTemplateTestsAsync(long dTId)
        {
            return await new RxRepository().GetRxCpDiseaseTemplateTestsAsync(dTId);
        }

        public async Task<IList<SelectedAdvice>> GetRxCpDiseaseTemplateAdvicesAsync(long dTId)
        {
            return await new RxRepository().GetRxCpDiseaseTemplateAdvicesAsync(dTId);
        }

        public void AccumulatePrescriptionDataVer2(long rxVisitId, int cpId)
        {
            new RxRepository().AccumulatePrescriptionDataVer2(rxVisitId, cpId);
        }

        public void DeleteExistingTemplateDataIfAny(long rxVisitId)
        {
            this.DeleteExistingRxInitialData(rxVisitId);
            this.DeleteExistingRxTreatmentData(rxVisitId);
            this.DeleteExistingRxTestData(rxVisitId);
            this.DeleteExistingRxAdviceData(rxVisitId);
        }

        private void DeleteExistingRxAdviceData(long rxVisitId)
        {
            new RxRepository().DeleteExistingRxAdviceData(rxVisitId);
        }

        private void DeleteExistingRxTestData(long rxVisitId)
        {
            new RxRepository().DeleteExistingRxTestData(rxVisitId);
        }

        private void DeleteExistingRxTreatmentData(long rxVisitId)
        {
            new RxRepository().DeleteExistingRxTreatmentData(rxVisitId);
        }

        public DataSet GetRxFullDataSetVer2(long rxVisitId, int cpId)
        {
            return new RxRepository().GetRxFullDataSetVer2(rxVisitId, cpId);
        }

        private void DeleteExistingRxInitialData(long rxVisitId)
        {
            new RxRepository().DeleteExistingInitialData(rxVisitId);
        }

        public async Task<RxVisitHistory> GetRxPreviousVisit(long rxPMId, int visitNo)
        {
            return await new RxRepository().GetRxPreviousVisit(rxPMId, visitNo);
        }

        public void DeleteRxAdvice(SelectedAdvice objToRemove, long rxvisitId)
        {
            new RxRepository().DeleteRxAdvice(objToRemove, rxvisitId);
        }

        public void DeleteRxTest(RxVMTestTemplate selectedItem, long rxVisitId)
        {
            new RxRepository().DeleteRxTest(selectedItem, rxVisitId);
        }

        public void SaveRxCpDrugTemplateMaster(RxCPDrugTemplateMaster ttm)
        {
            new RxRepository().SaveRxCpDrugTemplateMaster(ttm);
        }

        public void SaveRxCPTreatmentTemplateDetailData(List<RxCPDrugTemplateDetail> ttdList)
        {
            new RxRepository().SaveRxCPTreatmentTemplateDetailData(ttdList);
        }

        public List<RxCPDrugTemplateMaster> GetRxDrugMasterTemplateList(int cPId)
        {
           return  new RxRepository().GetRxDrugMasterTemplateList(cPId);
        }

        public void SaveRxCpAdviceTemplateMaster(RxCpAdviceTemplateMaster advtm)
        {
            new RxRepository().SaveRxCpAdviceTemplateMaster(advtm);
        }

        public void SaveRxCPAdviceTemplateDetailData(List<RxCpAdviceTemplateDetail> advtdList)
        {
            new RxRepository().SaveRxCPAdviceTemplateDetailData(advtdList);
        }

        public List<RxCpAdviceTemplateMaster> GetRxAdviceMasterTemplateList(int cPId)
        {
            return new RxRepository().GetRxAdviceMasterTemplateList(cPId);
        }

        public void SaveRxCpTestTemplateMaster(RxCPTestTemplateMaster ttm)
        {
            new RxRepository().SaveRxCpTestTemplateMaster(ttm);
        }

        public void SaveRxCPTestTemplateDetailData(List<RxCPTestTemplateDetail> ttdList)
        {
            new RxRepository().SaveRxCPTestTemplateDetailData(ttdList);
        }

        public List<RxCPTestTemplateMaster> GetRxTestMasterTemplateList(int cPId)
        {
             return new RxRepository().GetRxTestMasterTemplateList(cPId);
        }

        public async Task<List<RxSelectedMedicineForPatient>> GetRxCpTreatmentTemplateData(long templateId)
        {
            return await new RxRepository().GetRxCpTreatmentTemplateData(templateId);
        }

        public async Task<IList<SelectedAdvice>> GetRxCpAdviceTemplateData(long templateId)
        {
            return await new RxRepository().GetRxCpAdviceTemplateData(templateId);
        }

        public async Task<IList<RxVMTestTemplate>> GetRxCpTestTemplateData(long templateId)
        {
            return await new RxRepository().GetRxCpTestTemplateData(templateId);
        }

        public void SaveOrUpdateCarryOnBlocks(RxCarryOnBlock cob)
        {
            new RxRepository().SaveOrUpdateCarryOnBlocks(cob);
        }

        public void SetDoseAsDefault(VMPhProductListForRxPerspective phprod, RxDosage item)
        {
            //PhProductInfo _pInfo = new PhProductRepository().GetProductById(phprod.ProductId);
            //if (_pInfo != null)
            //{
            //    _pInfo.DoseId = item.DoseId;

            //    new PhProductClassificationService().UpdateProduct(_pInfo);
            //}

            new RxRepository().SetDoseAsDefault(phprod, item);
        }

        public RxVMPatientBasicInfo GetPreviousPatient(long currentVisitId, int chamberPractitionerId)
        {
            return new RxRepository().GetPreviousPatient(currentVisitId, chamberPractitionerId);
        }

        public RxVMPatientBasicInfo GetNextPatient(long currentVisitId, int chamberPractitionerId)
        {
            return new RxRepository().GetNextPatient(currentVisitId, chamberPractitionerId);
        }

        public RxVMPatientBasicInfo GetLastPatient(long currentVisitId, int chamberPractitionerId)
        {
            return new RxRepository().GetLastPatient(currentVisitId, chamberPractitionerId);
        }

        public void DeleteRxSavedCC(int CpId, string selectedStr)
        {
            new RxRepository().DeleteRxSavedCC(CpId, selectedStr);
        }

        public void DeleteRxCpSavedHistory(int CpId, string selectedStr)
        {
            new RxRepository().DeleteRxCpSavedHistory(CpId, selectedStr);
        }

        public void DeleteRxCpSavedAdditionalHistory(int CpId, string selectedStr)
        {
            new RxRepository().DeleteRxCpSavedAdditionalHistory(CpId, selectedStr);
        }

        public void DeleteRxCpSavedOtherFindings(int CpId, string selectedStr)
        {
            new RxRepository().DeleteRxCpSavedOtherFindings(CpId, selectedStr);
        }

       

        public RxVisitHistory GetRxVisitHistory(long RxIN)
        {
          return new RxRepository().GetRxVisitHistory(RxIN);
        }

        public async Task<RxPatientMasterData> GetRxMasterDataByPMIdAsync(long rxPMId)
        {
             return await new RxRepository().GetRxMasterDataByPMIdAsync(rxPMId);
        }

        public List<RxDrug> GetRxDrugByRxId(long rxVisitId)
        {
            return new RxRepository().GetRxDrugByRxId(rxVisitId);
        }

        public RxCpDosage GetRxCPDosagesByGeneric(ChamberPractitioner chamberPractitioner, int genericId,int formationId)
        {
            return new RxRepository().GetRxCPDosagesByGeneric(chamberPractitioner, genericId, formationId);
        }

        public Task<List<RxVMPatientBasicInfo>> GetRxWaitingPatientListAsync(DateTime dtfrm, DateTime dtto, int chamberPractitionerId)
        {
            return new RxRepository().GetRxWaitingPatientListAsync(dtfrm, dtto, chamberPractitionerId);
        }

        public bool SaveOrUpdateRxPrintFormatTemplate(RxPrintFormatTemplate pfTemplate)
        {
            return new RxRepository().SaveOrUpdateRxPrintFormatTemplate(pfTemplate);
        }

        public RxCpDosageWithGenericMapping GetRxCpDosageWithGenericMapping(ChamberPractitioner chamberPractitioner, int genericId, int formationId)
        {
            return new RxRepository().GetRxCpDosageWithGenericMapping(chamberPractitioner, genericId, formationId);
        }

        public DataSet GetRxFullDataSetForPrintV3(long rxVisitId, int cpId)
        {
            return new RxRepository().GetRxFullDataSetForPrintV3(rxVisitId, cpId);
        }

        public void AccumulatePrescriptionDataVer3(long rxVisitId, int cpId)
        {
            new RxRepository().AccumulatePrescriptionDataVer3(rxVisitId,cpId);
        }
    }
}
