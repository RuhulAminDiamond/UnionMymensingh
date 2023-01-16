using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class CabinInfo
    {
        [Key]
        public int CabinId { get; set; }
        public string CabinNo { get; set; }
        public string Description { get; set; }
        public int Rent { get; set; }
        public int FloorId { get; set; }
        public bool IsBooked { get; set; }

        public int AccomodationTypeId { get; set; }
        public int DeptId { get; set; }
       
       
    }
}
