using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic;
using HDMS.Model.Diagnostic.VM;
using HDMS.Models.Pharmacy.ViewModels;
using HDMS.Repository.Diagonstics;
using Models.Store;
using HDMS.Model;
using HDMS.Model.LIS;
using HDMS.Model.Rx;
using HDMS.Model.Rx.VModel;

namespace HDMS.Service.Diagonstics
{
    public class LabService
    {
        public List<LabInfo> GetLabList()
        {
            return new LabRepository().GetLabList();
        }

        public LabInfo GetlabInfoById(int _LabId)
        {
            return new LabRepository().GetlabInfoById(_LabId);
        }

        public void PopulateSelectedItemDataForLabRequisition(IList<PhSelectedProductsToSaleOrReceiveOrOrder> _SelectedItems, StoreProductInfo storeProductInfo, double _qty)
        {
            int ItemId;

            if (storeProductInfo == null) return;

            ItemId = storeProductInfo.ProductId;
            if (_SelectedItems.Any(x => x.Id == ItemId))
            {

                _SelectedItems.Where(w => w.Id == ItemId).ToList().ForEach(s => s.Qty = _qty);

                return;
            }

            _SelectedItems.Add(GetPreparedSelectedItemObjectForRequisition(storeProductInfo, _qty));
        }

        private PhSelectedProductsToSaleOrReceiveOrOrder GetPreparedSelectedItemObjectForRequisition(StoreProductInfo storeProductInfo, double _qty)
        {
            PhSelectedProductsToSaleOrReceiveOrOrder _PhSelectedItem = new PhSelectedProductsToSaleOrReceiveOrOrder();
            _PhSelectedItem.Id = storeProductInfo.ProductId;

            _PhSelectedItem.Code = storeProductInfo.ProductCode;
            _PhSelectedItem.Name = storeProductInfo.Name;
            _PhSelectedItem.Unit = storeProductInfo.Unit;

            _PhSelectedItem.Qty = _qty;


            return _PhSelectedItem;
        }

        public long SaveRequisition(LabRequisition _hpMReq)
        {
            return new LabRepository().SaveRequisition(_hpMReq);
        }

        public bool SaveRequisitionDetails(List<LabRequisitionDetail> _reqDetailsList)
        {
            return new LabRepository().SaveRequisitionDetails(_reqDetailsList);
        }

        public List<VMLabRequisition> GetRequisitionListByUserByDate(string username, DateTime dt)
        {
            return new LabRepository().GetRequisitionListByUserByDate(username, dt);
        }

        public LabRequisition GetLabRequisitionByReqId(long requisitionId)
        {
            return new LabRepository().GetLabRequisitionByReqId(requisitionId);
        }

        public List<VMLabRequisitionList> GetLabRequisitionDetailByReqId(long requisitionId)
        {
            return new LabRepository().GetLabRequisitionDetailByReqId(requisitionId);
        }

        public async Task<bool> LoadLISMachineData(string _billNo, Patient _PatientInfo)
        {
           return await  new LabRepository().LoadLISMachineData(_billNo, _PatientInfo);
        }

        public TEMPLISResultRecord GetLISResultRecord(long _PatientRecordId, long _PatientId, int reportDefId)
        {
            return new LabRepository().GetLISResultRecord(_PatientRecordId,_PatientId, reportDefId);
        }

        public async Task<bool> MAP_LIS_RESULT_WITH_SOFTWARE_REPORT_DEFINATION(string _ReportId)
        {
            return await new LabRepository().MAP_LIS_RESULT_WITH_SOFTWARE_REPORT_DEFINATION(_ReportId);
        }

        public List<TEMPLISPatientRecord> GetTestPerformedByList(string _reportTypeId, string _reportId)
        {
            return new LabRepository().GetTestPerformedByList(_reportTypeId, _reportId);
        }

        public PathologicalMachine GetPathologyMachineByShortName(string instrumentName)
        {
            return new LabRepository().GetPathologyMachineByShortName(instrumentName);
        }

        public List<PathologicalMachine> GetPathologyMachineByReportTypeId(int _reportTypeId)
        {
            return new LabRepository().GetPathologyMachineByReportTypeId(_reportTypeId);
        }

        public Task<List<RxVMTestResult>> GetRxLabResults(RxVisitHistory rxVisitHistory)
        {
            return new LabRepository().GetRxLabResults(rxVisitHistory);
        }
    }
}
