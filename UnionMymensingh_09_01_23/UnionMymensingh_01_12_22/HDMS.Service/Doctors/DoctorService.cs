using HDMS.Model;
using HDMS.Repository.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using HDMS.Model.Common.VW;
using HDMS.Model.Rx;

namespace HDMS.Service.Doctors
{
    public class DoctorService
    {

        public IList<Doctor> GetAllDoctors()
        {
            return new DoctorRepository().GetAllDoctors();
        }

        public ReportConsultant GetReportConsultantById(int id)
        {
            return new DoctorRepository().GetReportConsultantById(id);
        }

        public IList<ReportConsultant> GetlAlReportDoctorOtherThanPathology()
        {
            return new DoctorRepository().GetlAlReportDoctorOtherThanPathologyLegacy();
        }

        public bool UpdateDoctorSerialPatient(PractitionerWisePatientSerial pr)
        {
            return new DoctorRepository().UpdateDoctorSerialPatient(pr);
        }

        public List<CPOffDayCalender> GetCPOffDays(int cPId)
        {
            return new DoctorRepository().GetCPOffDays(cPId);
        }

        public ChamberPractitioner GetChamberPractitionerById(int chamberPractitionerId)
        {
            return new DoctorRepository().GetChamberPractitionerById(chamberPractitionerId);
        }

        public bool SaveMedia(BusinessMedia _media)
        {
            return new DoctorRepository().SaveMedia(_media);
        }

        public ChamberPractitionerSpeciality GetChamberPractionerSpecialityById(int _CPSId)
        {
            return new DoctorRepository().GetChamberPractionerSpecialityById(_CPSId);
        }

        public IList<VWDoctor> GetDoctorDetailList()
        {
            return new DoctorRepository().GetDoctorDetailList(); ;
        }

        public bool UpdateChamberPractionerSpeciality(ChamberPractitionerSpeciality _cp)
        {
            return new DoctorRepository().UpdateChamberPractionerSpeciality(_cp);
        }

        public IList<CorporateClient> GetAllCorporateClient()
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.CorporateClients.ToList();
            }
        }

        public Doctor GetDoctorByIdFromLegacy(int doctorId)
        {
            return new DoctorRepository().GetDoctorByIdFromLegacy(doctorId);
        }

        public IList<BusinessMedia> GetAllMedias()
        {
            return new DoctorRepository().GetAllMedias();
        }

        public IList<BusinessMedia> GetAllMediasByType(string type)
        {
            return new DoctorRepository().GetAllMediasByType(type); ;
        }

        public BusinessMedia getMediaById(int mediaId)
        {
            return new DoctorRepository().getMediaById(mediaId);
        }

        public IList<ReportConsultant> GetlAlReportDoctorOtherThanPathologyLegay()
        {
            return new DoctorRepository().GetlAlReportDoctorOtherThanPathologyLegacy();
        }

        public string SaveNewReferral(Doctor _doctor)
        {
            return new DoctorRepository().SaveNewReferral(_doctor);
        }

        public bool AddChamberPractitionerSpeciality(ChamberPractitionerSpeciality _cprac)
        {
            return new DoctorRepository().AddChamberPractitionerSpeciality(_cprac);
        }

        public bool IsExists(string p)
        {
            if((new DoctorRepository().IsExists(p))>0){
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ReferralCategory> GetRefCategories()
        {
            return new DoctorRepository().GetRefCategories();
        }

        public IList<ChamberPractitionerSpeciality> GetChamberPractitionerSpecialityList()
        {
            return new DoctorRepository().GetChamberPractitionerSpecialityList();
        }

        public IList<ReportConsultant> GetPathologyConsultants()
        {
            return new DoctorRepository().GetPathologyConsultants();
        }

        public IList<ReportTechnologist> GetReportTechnologists()
        {
            return new DoctorRepository().GetReportTechnologists();
        }

        public ReportConsultant GetReportConsultantByName(string name)
        {
            return new DoctorRepository().GetReportConsultantByName(name);
        }

        public object GetTechnologistByName(string name)
        {
            return new DoctorRepository().GetTechnologistByName(name);
        }

        public ReportTechnologist GetTechnologistById(int _technologistId)
        {
            return new DoctorRepository().GetTechnologistById(_technologistId);
        }

        public Doctor GetDoctorById(int _refdBy)
        {
            return new DoctorRepository().GetDoctorById(_refdBy);
        }

        public List<Doctor> GetDoctorBySearchString(string _searcgString)
        {
            return new DoctorRepository().GetDoctorBySearchString(_searcgString);
        }

        public void DeleteExistingAllowedGroups(int rCId)
        {
            new DoctorRepository().DeleteExistingAllowedGroups(rCId);
        }

        public void SaveChamberPractitionerOffDays(List<CPOffDayCalender> offdays)
        {
            new DoctorRepository().SaveChamberPractitionerOffDays(offdays);
        }

        public ReportConsultant GetConsultantByUserId(int _consultandUserId)
        {
            return new DoctorRepository().GetConsultantByUserId(_consultandUserId);
        }

        public int SaveReportConsultant(ReportConsultant _consultant)
        {
            return new DoctorRepository().SaveReportConsultant(_consultant);
        }

        public bool UpdateDoctorRecord(Doctor _doc)
        {
            return new DoctorRepository().UpdateDoctorRecord(_doc);
        }

        public ReportConsultant GetCurrentConsultant(string _regNo, Model.ViewModel.ViewModelReportTests viewModelReportTests)
        {
            return new DoctorRepository().GetCurrentConsultant(_regNo, viewModelReportTests);
        }

        public Doctor GetDoctorByUserId(int userId)
        {
            return new DoctorRepository().GetDoctorByUserId(userId);
        }

        public bool UpdateReportConsultant(ReportConsultant _rConsultant)
        {
           return new DoctorRepository().UpdateReportConsultant(_rConsultant);
        }

        public void SaveAllowedGroups(List<ReportConsultantWorkList> _rcWList)
        {
            new DoctorRepository().SaveAllowedGroups(_rcWList);
        }

        public IList<ReportConsultant> GetAllConsultants()
        {
           return new DoctorRepository().GetAllConsultants();
        }

        public List<ReportConsultantWorkList> GetConsultantWorkList(int rCId)
        {
            return new DoctorRepository().GetConsultantWorkList(rCId);
        }

        public int SaveChamberPractitioner(ChamberPractitioner _consultant)
        {
            return new DoctorRepository().SaveChamberPractitioner(_consultant);
        }

        public bool UpdateChamberPractitioner(ChamberPractitioner _consultant)
        {
            return new DoctorRepository().UpdateChamberPractitioner(_consultant);
        }

        public List<ChamberPractitioner> GetChamberPractitionerList()
        {
            return new DoctorRepository().GetChamberPractitionerList();
        }

        public IList<ChamberPractitioner> GetAllChamberPractitioners()
        {
            return new DoctorRepository().GetAllChamberPractitioners();
        }

        public CPOffDayCalender GetCPOffDays(ChamberPractitioner prac, DateTime dt)
        {
            return new DoctorRepository().GetCPOffDays(prac, dt);
        }

       
    }
}
