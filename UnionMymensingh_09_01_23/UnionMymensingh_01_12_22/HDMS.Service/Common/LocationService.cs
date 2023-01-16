using HDMS.Model.Common;
using HDMS.Model.Location;
using HDMS.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Common
{
    public class LocationService
    {
        public IList<District> GetAllDistrict()
        {
            return new LocationRepository().GetAllDistrict();
        }

        public List<UpazilaOrArea> GetUpazillaByDistrict(int _districtId)
        {
            return new LocationRepository().GetUpazillaByDistrict(_districtId);
        }

        public List<Division> GetAllDivision()
        {
            return new LocationRepository().GetAllDivision();
        }

        public List<District> GetDistrictsByDivision(int _divisionId)
        {
            return new LocationRepository().GetDistrictsByDivision(_divisionId);
        }

        public List<UpazilaOrArea> GetUpazillasByDistrict(int _districtId)
        {
            return new LocationRepository().GetUpazillasByDistrict(_districtId);
        }

        public List<Union> GetUnionByUpazilla(int _upazillaId)
        {
            return new LocationRepository().GetUnionByUpazilla(_upazillaId);
        }

        public List<Country> GetAllCountry()
        {
            return new LocationRepository().GetAllCountry();
        }

        public UpazilaOrArea GetUpazillaById(int upazilaId)
        {
            return new LocationRepository().GetUpazillaById(upazilaId);
        }

        public District GetDistrictById(int districtId)
        {
            return new LocationRepository().GetDistrictById(districtId);
        }
    }
}
