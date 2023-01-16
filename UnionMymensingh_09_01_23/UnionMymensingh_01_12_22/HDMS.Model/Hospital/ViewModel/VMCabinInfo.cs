using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMCabinInfo
    {
        public int CabinId { get; set; }
        public string CabinNo { get; set; }
        public string Description { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
        public int Rent { get; set; }
        public string Floor { get; set; }
        public string AccomType { get; set; }

        public int FloorId { get; set; }
        public int AccomTypeId { get; set; }

        public string Booked { get; set; }

    }
}
