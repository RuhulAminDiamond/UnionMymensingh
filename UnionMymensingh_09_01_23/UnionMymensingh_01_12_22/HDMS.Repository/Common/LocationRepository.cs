using HDMS.Model.Common;
using HDMS.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Common
{
    public class LocationRepository
    {
        public IList<District> GetAllDistrict()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Districts.ToList();
            }
        }

        public List<UpazilaOrArea> GetUpazillaByDistrict(int _districtId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.UpazilaOrAreas.Where(x=>x.DistrictId==_districtId).ToList();
            }
        }

        public List<Division> GetAllDivision()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Divisions.ToList();
            }
        }

        public List<District> GetDistrictsByDivision(int _divisionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Districts.Where(x=>x.DivisionId== _divisionId).ToList();
            }
        }

        public List<Union> GetUnionByUpazilla(int _upazillaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Unions.Where(x => x.UpazilaId == _upazillaId).ToList();
            }
        }

        public List<Country> GetAllCountry()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Countries.ToList();
            }
        }

        public District GetDistrictById(int districtId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Districts.Where(x=>x.DistrictId== districtId).FirstOrDefault();
            }
        }

        public List<UpazilaOrArea> GetUpazillasByDistrict(int _districtId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.UpazilaOrAreas.Where(x => x.DistrictId == _districtId).ToList();
            }
        }

        public UpazilaOrArea GetUpazillaById(int upazilaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.UpazilaOrAreas.Where(x => x.UpazilaId == upazilaId).FirstOrDefault();
            }
        }
    }
}
