using HDMS.Model;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repositories.Pharmacy
{
    public class PhProductClassificationRepository
    {

        public List<PhProductGroup> GetAllGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductGroups.ToList();
            }

        }
        
        public bool addSubGroup(PhSubGroup subGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                   // entities.PhSubGroups.Add(subGroup);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
       

       
        public bool AddGeneric(Generic generic)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Generics.Add(generic);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public List<VMGeneric> GetAllGeneric()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMGeneric>(@"Select g.Name as GenName,IsNull(grp.Name,'') as GroupName,g.GenericId,IsNull(grp.GroupId,0) GroupId from Generics g left join PhProductGroups grp on g.GroupId= grp.GroupId").ToList();
            }
        }
        public bool AddManufacturer(Manufacturer manufacturer)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Manufacturers.Add(manufacturer);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<Manufacturer> GetManufacturer()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Manufacturers.ToList();
            }
        }

        public List<Generic> GetGenericByGroupId(int groupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Generics.Where(x=>x.GroupId== groupId).OrderBy(x=>x.Name).ToList();
            }
        }

        public bool AddFormation(Formation formation)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Formations.Add(formation);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<Formation> GetFormation()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Formations.ToList();
            }
        }
        public bool AddStrength(Strength strength)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Strengths.Add(strength);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<Generic> GetGenList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Generics.ToList();
            }
        }

        public IList<Strength> GetStrength()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.Strengths.ToList();
            }
        }

        public Generic GetGenericById(int genId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Generics.Where(x => x.GenericId == genId).FirstOrDefault();
            }
        }

        public bool UpdateGeneric(Generic _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteGeneric(Generic _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_gr).State = EntityState.Deleted;
                entities.SaveChanges();
                return true;
            }
        }



        

        public Formation GetFormationById(int fId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Formations.Where(x => x.FormationId == fId).FirstOrDefault();
            }
        }

        public List<VMGeneric> GetGenericBySearchStr(string searchStr)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format(@"Select g.Name as GenName, IsNull(grp.Name, '') as GroupName, g.GenericId, IsNull(grp.GroupId, 0) GroupId from Generics g left join PhProductGroups grp on g.GroupId = grp.GroupId Where g.Name like '%{0}%'", searchStr);
                return entities.Database.SqlQuery<VMGeneric>(sql).ToList();
            }
        }

        public bool UpdateDoctorSerialPatient(PractitionerWisePatientSerial pr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(pr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public Manufacturer GetManufactureById(int mId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Manufacturers.Where(x => x.ManufacturerId == mId).FirstOrDefault();
            }
        }

        public Strength GetStrengthById(int StrengthId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Strengths.Where(x => x.StrengthId == StrengthId).FirstOrDefault();
            }
        }

        public bool DeleteStrength(Strength _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_gr).State = EntityState.Deleted;
                entities.SaveChanges();
                return true;
            }
        }

        public bool DeleteManufacturer(Manufacturer _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_gr).State = EntityState.Deleted;
                entities.SaveChanges();
                return true;
            }
        }

        public bool DeleteFormation(Formation _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_gr).State = EntityState.Deleted;
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateManufacturer(Manufacturer _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateFormation(Formation _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateStrength(Strength _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

       

        public bool UpdateSubGroup(PhSubGroup _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_gr).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteSubGroup(PhSubGroup _gr)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_gr).State = EntityState.Deleted;
                entities.SaveChanges();
                return true;
            }
        }

        public IList<PhProductGroup> GetProductgroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PhProductGroups.ToList();
            }
        }

        public bool UpdateProduct(PhProductInfo _PInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_PInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
