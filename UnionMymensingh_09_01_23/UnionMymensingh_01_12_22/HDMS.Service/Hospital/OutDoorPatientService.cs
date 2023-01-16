using HDMS.Model;
using HDMS.Repository.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Hospital
{
    public class OutDoorPatientService
    {
        public int SaveOutDoorPatient(OutDoorPatient odp)
        {
            return new OutDoorPatientRepository().SaveOutDoorPatient(odp);
        }

        public string GetNextRegNo()
        {
            Int32 buffer = 300000000;
            buffer = buffer + (Convert.ToInt32(new OutDoorPatientRepository().GetNextRegNo()) + 1);
            return "BBCH" + buffer.ToString();
        }

        public string SaveOutDoorPatientIncome(List<OutDoorIncome> odrinc)
        {
            return new OutDoorPatientRepository().SaveOutDoorPatientIncome(odrinc);
        }

        public int GetTotalPatient(DateTime dt1, DateTime dt2, string serviceFor)
        {
            return new OutDoorPatientRepository().GetTotalPatient(dt1, dt2,serviceFor);
        }

        public void SaveIncome(OutDoorIncome _outdoorIncom)
        {
             new OutDoorPatientRepository().SaveIncome(_outdoorIncom);
        }

        public string GetDailyId(DateTime dateTime)
        {
           return (new OutDoorPatientRepository().GetDailyId(dateTime)+1).ToString();
        }

        public OutDoorPatient GetOutDoorPatientByRegNo(string _rego)
        {
           return new OutDoorPatientRepository().GetOutDoorPatientByRegNo(_rego);
        }

        public List<OutDoorIncome> GetOutDoorIncomeByPatient(int pId)
        {
            return new OutDoorPatientRepository().GetOutDoorIncomeByPatient(pId);
        }

        public void UpdateOutDoorPatient(OutDoorPatient odp)
        {
            new OutDoorPatientRepository().UpdateOutDoorPatient(odp);
        }

        public void DeleteIncomeStatements(int pId)
        {
            new OutDoorPatientRepository().DeleteIncomeStatements(pId);
        }
    }
}
