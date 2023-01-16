using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMIPDInfo
    {
        public long RegNo { get; set; }
        public long AdmissionId { get; set; }
        public long BillNo { get; set; }
        public DateTime AddmissionDate { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string AdmTime { get; set; }
        public string BedCabinNo { get; set; }
        public int CabinId { get; set; }
        public string AssignedDoctor { get; set; }
        public string RefDoctor { get; set; }
        public string FatherName { get; set; }

        public string Status { get; set; }
        public string MobileNo { get; set; }
        public string CPMobile { get; set; }
        public string PatientAddress { get; set; }
        public string CPAddress { get; set; }
        public string Address { get; set; }

        public string RecommededDateForDischarge { get; set; }
        public string RecommededTimeForDischarge { get; set; }
        public string DischargeRecommendationConfirmedby { get; set; }

        public int PackageId { get; set; }
        public int DeptId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeTime { get; set; }
    }
}
