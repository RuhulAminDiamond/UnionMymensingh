using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Repository.Hospital;
using HDMS.Model.Enums;

namespace HDMS.Service.Hospital
{
    public class HospitalCabinBedService
    {
        public List<CabinInfo> GetCabinList()
        {
            return new HospitalCabinBedRepository().GetCabinList();
        }

        public HpPatientAccomodationType GetCabinServiceHeadId(int accomodationTypeId)
        {
            return new HospitalCabinBedRepository().GetCabinServiceHeadId(accomodationTypeId);
        }

        public List<WardInfo> GetWardList()
        {
            return new HospitalCabinBedRepository().GetWardList();
        }

        public List<WardBedInfo> GetWardBedList(int _wardId)
        {
            return new HospitalCabinBedRepository().GetWardBedList(_wardId);
        }

        public WardBedInfo GetWardBedInfo(int wardOrCabinId)
        {
            return new HospitalCabinBedRepository().GetWardBedInfo(wardOrCabinId);
        }

        public bool UpdateHpDepartment(HpDepartment _dept)
        {
            return new HospitalCabinBedRepository().UpdateHpDepartment(_dept);
        }

        public IList<CabinInfo> GetAllCabinInformation()
        {
            return new HospitalCabinBedRepository().GetAllCabinInformation();
        }

        public List<VMCabinInfo> GetVMAllCabinList()
        {
            return new HospitalCabinBedRepository().GetVMAllCabinList();
        }

        public List<HpPatientAccomodationType> GetHpAccomodationTypes()
        {
            return new HospitalCabinBedRepository().GetHpAccomodationTypes();
        }

        public bool SaveHpDepartment(HpDepartment _hpdept)
        {
            return new HospitalCabinBedRepository().SaveHpDepartment(_hpdept);
        }

        public List<VMFreeCabinList> GetFreeCabinListByFloor()
        {
            return new HospitalCabinBedRepository().GetFreeCabinListByFloor();
        }

        public List<HpDepartment> GetDeptList()
        {
            return new HospitalCabinBedRepository().GetDeptList();
        }

        public List<VMCabinInfo> GetVMCabinList()
        {
            return new HospitalCabinBedRepository().GetVMCabinList();
        }

        public CabinInfo GetCabinInfoId(int p)
        {
            return new HospitalCabinBedRepository().GetCabinInfoId(p);
        }

     

        public bool UpdateCabinInfo(CabinInfo _cf)
        {
            return new HospitalCabinBedRepository().UpdateCabinInfo(_cf);
        }

        public bool SaveWardInfo(WardInfo wi)
        {
            return new HospitalCabinBedRepository().SaveWardInfo(wi);
        }

        public IList<WardInfo> GetWarInfo()
        {
            return new HospitalCabinBedRepository().GetWarInfo();
        }



        public WardInfo GetWarInfoById(int wId)
        {
            return new HospitalCabinBedRepository().GetWarInfoById(wId);
        }

        public List<CabinInfo> GetFreeCabinList()
        {
            return new HospitalCabinBedRepository().GetFreeCabinList();
        }

        public List<HpPatientAccomodationType> GetAccomodationTypes()
        {
            return new HospitalCabinBedRepository().GetAccomodationTypes();
        }

        public IList<VMCabinInfo> GetVMExtraCabinList(string _type)
        {
            return new HospitalCabinBedRepository().GetVMExtraCabinList(_type);
        }

        public bool UpdateWardInfo(WardInfo wid)
        {
            return new HospitalCabinBedRepository().UpdateWardInfo(wid);
        }

        public bool SaveWardBedInfo(WardBedInfo wbi)
        {
            return new HospitalCabinBedRepository().SaveWardBedInfo(wbi);
        }

        public IList<WardBedInfo> GetWardBedInfo()
        {
            return new HospitalCabinBedRepository().GetWardBedInfo();
        }

        public HpCabinChargeSegmantMaster GetCabinChargeSegmantMaster()
        {
            return new HospitalCabinBedRepository().GetCabinChargeSegmantMaster();
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetail()
        {
            return new HospitalCabinBedRepository().GetCabinChargeSegmantDetail();
        }

        public HpCabinChargeSegmantDetail GetAdmissionDayCabinChargeSegmantDetail()
        {
            return new HospitalCabinBedRepository().GetAdmissionDayCabinChargeSegmantDetail();
        }

        public FloorInfo GetFloorById(int floorId)
        {
            return new HospitalCabinBedRepository().GetFloorById(floorId);
        }

        public bool SaveCabinInfo(CabinInfo cf)
        {
            return new HospitalCabinBedRepository().SaveCabinInfo(cf);
        }

        public List<DateTime> GetDistinctVacantedDateByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetDistinctVacantedDateByPatient(admissionId);
        }

        public HpPatientAccomodationInfo GetExtraCabinByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetExtraCabinByPatient(admissionId);
        }

        public List<VMCabinAccomodationInfo> GetBedTransferredAccomInfo(long admissionId, DateTime dt)
        {
            return new HospitalCabinBedRepository().GetBedTransferredAccomInfo(admissionId,dt);
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetailForCurrentOccupation(DateTime _admissionDate)
        {
            return new HospitalCabinBedRepository().GetCabinChargeSegmantDetailForCurrentOccupation(_admissionDate);
        }

        public List<CabinInfo> GetAccomodationList(int _accomodationTypeId,int deptId)
        {
            return new HospitalCabinBedRepository().GetAccomodationList(_accomodationTypeId, deptId);
        }

        public HpCabinChargeSegmantDetail GetCabinChargeSegmantDetailByDate(DateTime _date)
        {
            return new HospitalCabinBedRepository().GetCabinChargeSegmantDetailByDate(_date);
        }

        public HpPatientAccomodationInfo GetReleasedAsPBCabinByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetReleasedAsPBCabinByPatient(admissionId);
        }

        public List<DateTime> GetDistinctEBVacantedDateByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetDistinctEBVacantedDateByPatient(admissionId);
        }

        public VMCabinAccomodationInfo GetExtraBedReleasedAccomInfo(long admissionId, DateTime dt)
        {
            return new HospitalCabinBedRepository().GetExtraBedReleasedAccomInfo(admissionId, dt);
        }

        public List<FloorInfo> GetFloorList()
        {
            return new HospitalCabinBedRepository().GetFloorList();
        }

        public List<HpPatientAccomodationInfo> GetExtraCabinListByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetExtraCabinListByPatient(admissionId);
        }

        public HpPatientAccomodationInfo GetOccupiedCabinByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetOccupiedCabinByPatient(admissionId);
        }

        public void UpdateAccomodationInfo(long admissionId)
        {
             new HospitalCabinBedRepository().UpdateAccomodationInfo(admissionId);
        }

        public bool ReleaseExtaCabin(long admissionId,int _cabinId)
        {
            return  new HospitalCabinBedRepository().ReleaseExtaCabin(admissionId, _cabinId);
        }

        public List<HpPatientAccomodationInfo> GetHpOccupiedCabinListByAdmisissionId(long admissionId)
        {
            return new HospitalCabinBedRepository().GetHpOccupiedCabinListByAdmisissionId(admissionId);
        }

        public List<VMCabinAccomodationInfo> GetOccupiedExtracabin(long admissionId)
        {
            return new HospitalCabinBedRepository().GetOccupiedExtracabin(admissionId);
        }

        public void UpdateCurrentAccomodation(long admissionId)
        {
            List<HpPatientAccomodationInfo> _accomList = new HospitalCabinBedRepository().GetHpOccupiedCabinListByAdmisissionId(admissionId);

            foreach (var accomObj in _accomList)
            {
                if(accomObj.AllotType.ToLower()== "patientbed")
                {
                    accomObj.Status = "Vacant";
                    accomObj.AllotType = HpBedAllotTypeEnum.ReleasedAsPB.ToString();
                    new HospitalCabinBedRepository().UpdateAccomodationInfoEF(accomObj);
                }
                else
                {
                    accomObj.Status = "Vacant";
                    accomObj.AllotType = HpBedAllotTypeEnum.ReleasedAsEB.ToString();
                    new HospitalCabinBedRepository().UpdateAccomodationInfoEF(accomObj);
                }

            }
        }

        public List<HpPatientAccomodationInfo> GetHpAccomodationListByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetHpAccomodationListByPatient(admissionId);
        }

        public long SaveHpCabinChargeSegmantMaster(HpCabinChargeSegmantMaster _cabinChargeMaster)
        {
            return new HospitalCabinBedRepository().SaveHpCabinChargeSegmantMaster(_cabinChargeMaster);
        }

        public void SaveHpCabinChargeSegmantDetail(List<HpCabinChargeSegmantDetail> ccgList)
        {
            new HospitalCabinBedRepository().SaveHpCabinChargeSegmantDetail(ccgList);
        }

        public List<HpPatientAccomodationInfo> GetHpExtraAccomodationListByPatient(long admissionId)
        {
            return new HospitalCabinBedRepository().GetHpExtraAccomodationListByPatient(admissionId);
        }

        public HpCabinChargeSegmantMaster GetHpCabinChargeMasterSegmant()
        {
            return new HospitalCabinBedRepository().GetHpCabinChargeMasterSegmant();
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetailForExtraOccupation()
        {
            return new HospitalCabinBedRepository().GetCabinChargeSegmantDetailForExtraOccupation();
        }

        public HpCabinChargeSegmantDetail GetExtraCabinChargeSegmantDetailByDate(DateTime date)
        {
            return new HospitalCabinBedRepository().GetExtraCabinChargeSegmantDetailByDate(date);
        }

      
        public List<CabinInfo> GetDeptWiseFreeAccomList(int accomodationTypeId, int deptId)
        {
            return new HospitalCabinBedRepository().GetDeptWiseFreeAccomList(accomodationTypeId, deptId);
        }
    }
}
