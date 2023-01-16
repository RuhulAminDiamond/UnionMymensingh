using HDMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Hospital
{
    public class OutDoorPatientRepository
    {
        public int SaveOutDoorPatient(OutDoorPatient odp ) {
            
            using (DBEntities entities = new DBEntities())
            {
                entities.OutDoorPatients.Add(odp);
                entities.SaveChanges();
                Int32 i = odp.Id;
                return i;
            }
        }

        public string GetNextRegNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OutDoorPatients.ToList().Count().ToString();
            }
        }

        public string SaveOutDoorPatientIncome(List<OutDoorIncome> odrinc)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.OutDoorIncomes.AddRange(odrinc);
                    entities.SaveChanges();
                    return "Patient Info saved successsful.";
                }
                catch
                {
                    return "Fail to save patient info";
                }
                
            }
        }

        public int GetTotalPatient(DateTime dt1, DateTime dt2, string serviceFor)
        {
            using (DBEntities entities = new DBEntities())
            {
                if (serviceFor == "All")
                {
                    return entities.OutDoorPatients.Where(x => (x.EntryDate >= dt1.Date && x.EntryDate <= dt2.Date)).ToList().Count();
                }
                else
                {
                    return entities.OutDoorPatients.Where(x => (x.EntryDate >= dt1.Date && x.EntryDate <= dt2.Date && x.ServiceFor == serviceFor)).ToList().Count();
                }

                return 0;
            }
        }

        public void SaveIncome(OutDoorIncome _outdoorIncom)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OutDoorIncomes.Add(_outdoorIncom);
                entities.SaveChanges();
            }
        }

        public int GetDailyId(DateTime dateTime)
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.OutDoorPatients.ToList().Where(x => x.EntryDate.ToString("MM/dd/yyyy") == dateTime.ToString("MM/dd/yyyy")).ToList().Count();
               
            }
        }

        public OutDoorPatient GetOutDoorPatientByRegNo(string _rego)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OutDoorPatients.Where(x => x.RegNo == _rego).FirstOrDefault();

            }
        }

        public List<OutDoorIncome> GetOutDoorIncomeByPatient(int pId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OutDoorIncomes.Where(x => x.PatientId == pId).ToList();

            }
        }

        public void UpdateOutDoorPatient(OutDoorPatient odp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(odp).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void DeleteIncomeStatements(int pId)
        {

            using (DBEntities entities = new DBEntities())
            {
                entities.OutDoorIncomes.RemoveRange(entities.OutDoorIncomes.Where(x => x.PatientId == pId));
                entities.SaveChanges();
            }

        }
    }
}
