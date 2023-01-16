using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMCabinAccomodationInfo
    {
        public long BookingOrder { get; set; }
        public long AdmissionId { get; set; }
        public int AccomodationTypeId { get; set; }
        public int CabinId { get; set; }
        public string CabinNo { get; set; }
      
        public int Rent { get; set; }
       
        public DateTime AccomodateDate { get; set; }
        public string AccomodateTime { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string ReleaseTime { get; set; }

        public string AllotType { get; set; }

    }
}
