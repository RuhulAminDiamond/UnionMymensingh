using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Repository.Common;
using HDMS.Service.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Common
{
    public class RegRecordService
    {
        public bool IsRegAlloted(long _regNo)
        {
            return new RegRecordRepository().IsRegAlloted(_regNo);
        }

        public RegRecord SaveRegRecord(RegRecord _regRecord)
        {
            return new RegRecordRepository().SaveRegRecord(_regRecord);
        }

        public RegRecord GetRegRecordByRegNo(long _regNo)
        {
            return new RegRecordRepository().GetRegRecordByRegNo(_regNo);
        }



        public RegRecord GetRegRecordByPatientId(long _diagPatientId)
        {
            Patient _patient = new PatientService().GetPatientBySerial(_diagPatientId);
            if (_patient != null)
            {
                RegRecord _regRecord = new RegRecordService().GetRegRecordByRegNo(Convert.ToInt64(_patient.RegNo));
                return _regRecord;
            }

            return null;
        }

        public IList<RegRecord> GetRegRecordByMobileNo(string _MobileNo)
        {
            return new RegRecordRepository().GetRegRecordByMobileNo(_MobileNo);
        }
        public bool UpdateRegRecord(RegRecord _record)
        {
           return  new RegRecordRepository().UpdateRegRecord(_record);
        }

        public RegRecord GetFirstRegNo()
        {
            return new RegRecordRepository().GetFirstRegNo();
        }

        public RegRecord GetSubSequentRegRecordAsc(long _Id)
        {
            return new RegRecordRepository().GetSubSequentRegRecordAsc(_Id);
        }

        public IList<RegRecord> GetAllRegistrationByRegNoWildCard(string _RegNo)
        {
            return new RegRecordRepository().GetAllRegistrationByRegNoWildCard(_RegNo);
        }

        public IList<RegRecord> GetAllRegistrationByMobileNo(string _mobileNo)
        {
            return new RegRecordRepository().GetAllRegistrationByMobileNo(_mobileNo);
        }

        public async Task<RegRecord> GetLatestRegRecordByCpIdAsync(int cPId)
        {
            return await new RegRecordRepository().GetLatestRegRecordByCpIdAsync(cPId);
        }

        public RegRecord GetLastRegNo()
        {
            return new RegRecordRepository().GetLastRegNo();
        }

        public RegRecord GetSubSequentRegRecordDesc(long _Id)
        {
            return new RegRecordRepository().GetSubSequentRegRecordDesc(_Id);
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            return new RegRecordRepository().IsBillNoAlloted(_billNo);
        }

        public RegUniqueKeyTracker GetRegUniqueKey(string workStationId, string _yy, int _mm)
        {
            return new RegRecordRepository().GetRegUniqueKey(workStationId, _yy, _mm);
        }

        public bool IsRegUniqueKeyAlloted(long _regNo)
        {
            return new RegRecordRepository().IsRegUniqueKeyAlloted(_regNo);
        }

        public bool SaveRegUniqueKey(IList<RegUniqueKeyTracker> _ukeyList)
        {
            return new RegRecordRepository().SaveRegUniqueKey(_ukeyList);
        }

        public void UpdateRegTracker(RegUniqueKeyTracker _regTracker)
        {
            new RegRecordRepository().UpdateRegTracker(_regTracker);
        }

        public List<RegUniqueKeyTracker> GetRegUniqueKeyList(string workStationId, string _year, int _month)
        {
            int _yy = 0;
            int.TryParse(_year, out _yy);

            return new RegRecordRepository().GetRegUniqueKeyList(workStationId, _yy, _month);
        }

        public List<RegRecord> GetRegisterdPatients(DateTime dtpfrm, DateTime dtpto)
        {
            return new RegRecordRepository().GetRegisterdPatients(dtpfrm, dtpto);
        }

        public void GenerateRegKey(string name, string workStationId, string _gTime, int _NoOfRegCode, int _OrgCode)
        {
            new RegRecordRepository().GenerateRegKey(name,workStationId, _gTime, _NoOfRegCode, _OrgCode);
        }

        public RegRecord GetRegRecordById(long _Id)
        {
           return new RegRecordRepository().GetRegRecordById(_Id);
        }

        public List<RegRecord> GetRegisterdPatientByMobileNo(string _mobileNo)
        {
            return new RegRecordRepository().GetRegisterdPatientByMobileNo(_mobileNo);
        }

        public async Task<RegRecord> GetRegRecordByRegNoAsync(long regNo)
        {
            return await new RegRecordRepository().GetRegRecordByRegNoAsync(regNo);
        }

        public List<RegRecord> GetRegisterdPatientByName(string _name)
        {
            return new RegRecordRepository().GetRegisterdPatientByName(_name);
        }

        public List<RegRecord> GetRegisterdPatientByAdmId(string regno)
        {
            return new RegRecordRepository().GetRegisterdPatientByAdmId(regno);
        }
    }
}
