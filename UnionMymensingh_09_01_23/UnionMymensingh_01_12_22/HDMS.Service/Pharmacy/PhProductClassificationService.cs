
using HDMS.Model;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using HDMS.Repositories.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDMS.Service.Pharmacy
{
         public class PhProductClassificationService
    {

             public List<PhProductGroup> GetAllGroups()
             {
                 return new PhProductClassificationRepository().GetAllGroups();
             }
             public bool GetAllSubGroup(Models.Pharmacy.PhSubGroup sg)
             {
                 return new PhProductClassificationRepository().addSubGroup(sg);
             }

           
             public bool AddGeneric(Generic generic)
             {
                 return new PhProductClassificationRepository().AddGeneric(generic);
             }

             public List<VMGeneric> GetAllGeneric()
             {
                 return new PhProductClassificationRepository().GetAllGeneric();
             }
             public bool AddManufacturer(Manufacturer manufacturer)
             {
                 return new PhProductClassificationRepository().AddManufacturer(manufacturer);
             }



             public IList<Manufacturer> GetManufacturer()
             {
                 return new PhProductClassificationRepository().GetManufacturer();
             }
             public bool AddFormation(Formation formation)
             {
                 return new PhProductClassificationRepository().AddFormation(formation);
             }

             public IList<Formation> GetFormation()
             {
                 return new PhProductClassificationRepository().GetFormation();
             }
             public bool AddStrength(Strength strength)
             {
                 return new PhProductClassificationRepository().AddStrength(strength);
             }

             public IList<Strength> GetStrength()
             {
                 return new PhProductClassificationRepository().GetStrength();
             }

             public Generic GetGenericById(int genId)
             {
                 return new PhProductClassificationRepository().GetGenericById(genId);
             }

             public bool UpdateGeneric(Generic _gr)
             {
                 return new PhProductClassificationRepository().UpdateGeneric(_gr);
             }

             public List<Generic> GetGenericByGroupId(int groupId)
             {
                 return new PhProductClassificationRepository().GetGenericByGroupId(groupId);
            }

             public bool DeleteGeneric(Generic _gr)
             {
                 return new PhProductClassificationRepository().DeleteGeneric(_gr);
             }

             //public SubGroup GetSubGroupById()
             //{
             //    return new ProductClassificationRepository().GetSubGroupById(_gr);
             //}

            

             public Formation GetFormationById(int fId)
             {
                 return new PhProductClassificationRepository().GetFormationById(fId);
             }

             public Manufacturer GetManufactureById(int mId)
             {
                 return new PhProductClassificationRepository().GetManufactureById(mId);
             }

             public Strength GetStrengthById(int StrengthId)
             {
                 return new PhProductClassificationRepository().GetStrengthById(StrengthId);
             }





             public bool DeleteStrength(Strength _gr)
             {
                 return new PhProductClassificationRepository().DeleteStrength(_gr);
             }

        public List<Generic> GetGenList()
        {
            return new PhProductClassificationRepository().GetGenList();
        }

        public bool DeleteManufacturer(Manufacturer _gr)
             {
                 return new PhProductClassificationRepository().DeleteManufacturer(_gr);
             }

             public bool DeleteFormation(Formation _gr)
             {
                 return new PhProductClassificationRepository().DeleteFormation(_gr);
             }

             

             public bool UpdateManufacturer(Manufacturer _gr)
             {
                 return new PhProductClassificationRepository().UpdateManufacturer(_gr);
             }

             public bool UpdateFormation(Formation _gr)
             {
                 return new PhProductClassificationRepository().UpdateFormation(_gr);
             }

             public bool UpdateStrength(Strength _gr)
             {
                 return new PhProductClassificationRepository().UpdateStrength(_gr);
             }

            
             public bool UpdateSubGroup(PhSubGroup _gr)
             {
                 return new PhProductClassificationRepository().UpdateSubGroup(_gr);
             }

             public bool DeleteSubGroup(PhSubGroup _gr)
             {
                 return new PhProductClassificationRepository().DeleteSubGroup(_gr);
             }

             public IList<PhProductGroup> GetProductgroups()
             {
                 return new PhProductClassificationRepository().GetProductgroups();
             }



             public bool UpdateProduct(PhProductInfo _PInfo)
             {
                 return new PhProductClassificationRepository().UpdateProduct(_PInfo);
             }

        public List<VMGeneric> GetGenericBySearchStr(string searchStr)
        {
            return new PhProductClassificationRepository().GetGenericBySearchStr(searchStr);
        }

        public bool UpdateDoctorSerialPatient(PractitionerWisePatientSerial pr)
        {
            return new PhProductClassificationRepository().UpdateDoctorSerialPatient(pr);
        }
    }
}
