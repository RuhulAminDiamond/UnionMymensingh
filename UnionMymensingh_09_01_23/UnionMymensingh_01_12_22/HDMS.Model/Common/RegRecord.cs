using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class RegRecord
    {
        public long Id { get; set; }
        public long RegNo { get; set; }
        public string RegHex { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string NoOfSons { get; set; }
        public string NoOfDaughters { get; set; }
        public string BloodGroup { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string Profession { get; set; }


        public string NationalId { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Status { get; set; }
        public int DesignationId { get; set; }
        public int CompanyId { get; set; } // For corporate client
        public string Others { get; set; }

        //Patient Address
        public string MobileNo { get; set; }
        public string CareOf { get; set; }
        public string HouseNo { get; set; }
        public string RoadNo { get; set; }
        public string Village { get; set; }
        public string PO { get; set; }
        public string District { get; set; }
        public string ArearOrThana { get; set; }
        public string PatientAddress { get; set; }

        // End of Patient Address


        //Local Gurdian or Contact Person Address
        public string CPName { get; set; }
        public string ContactPerson { get; set; }
        public string RelationWithPatient { get; set; }
        public string CPHouseNo { get; set; }
        public string CPRoadNo { get; set; }

        public string CPVillage { get; set; }
        public string CPPo { get; set; }


        public string CPMobile { get; set; }

        public string CPNationalId { get; set; }
        public string CPDistrict { get; set; }
        public string CPArearOrThana { get; set; }
        public string CPAddress { get; set; }

        // End of Local Gurdian or Contact Person Address

        public string CountryCode { get; set; }
        public string EmailId { get; set; }
        public string MType { get; set; } // Member Or Record Type 
        public double Discount { get; set; } // If any discount alloted for member
        public string Address { get; set; }
        public int UpazilaOrAreaId { get; set; }
        public int LocalGurdianUpazilaOrAreaId { get; set; }
        public int UnionId { get; set; }

        public int Referredby { get; set; }
        public int CpId { get; set; } // Chamber PractitionerId

        public int RefdId { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsRegisterd { get; set; }

    }
}
