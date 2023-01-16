using HDMS.Model;
using HDMS.Model.OPD;
using HDMS.Model.ViewModel;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Diagonstics
{
    public class ChamberPractitionerService
    {
        public bool AddPractitioner(ChamberPractitioner _practitioner)
        {
            return new ChamberPractitionerRepository().AddPractitioner(_practitioner);
        }

        public void InitializeSerialSlot(List<PractitionerWisePatientSerial> pSerialObj)
        {
            new ChamberPractitionerRepository().InitializeSerialSlot(pSerialObj);
        }

        public List<ChamberPractitioner> GetAllActivePractitioner()
        {
            return new ChamberPractitionerRepository().GetAllActivePractitioner();
        }

        public PractitionerWisePatientSerial GetPatientBySerialNo(int id)
        {
            return new ChamberPractitionerRepository().GetPatientBySerialNo(id);
        }

        public int GetSerialNo(ChamberPractitioner chamberPractitioner, DateTime dateTime)
        {
            return new ChamberPractitionerRepository().GetSerialNo(chamberPractitioner,dateTime);
        }

        public List<PractitionerWisePatientSerial> GetAllPatients(int cPId, DateTime date)
        {
            return new ChamberPractitionerRepository().GetAllPatients(cPId, date);
        }

        public bool CreateNewSerial(PractitionerWisePatientSerial _pSerial)
        {
            return new ChamberPractitionerRepository().CreateNewSerial(_pSerial);
        }

        public List<VMPractitionerWisePatientSerial> LoadPatientSerialByDoctor(int _pId,DateTime _date)
        {
            return new ChamberPractitionerRepository().LoadPatientSerialByDoctor(_pId, _date);
        }

        public async Task<List<VMPractitionerWisePatientSerial>> GetTodaysPatient(DateTime date)
        {
            return await new ChamberPractitionerRepository().GetTodaysPatient(date);
        }

        public OPDPatientVisitType GetVisitType(int visitTypeId)
        {
            return new ChamberPractitionerRepository().GetVisitType(visitTypeId);
        }

        public bool DeletePatientSerial(PractitionerWisePatientSerial patientSerial)
        {
            return new ChamberPractitionerRepository().DeletePatientSerial(patientSerial);
        }
    }
}
