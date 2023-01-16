using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMHpReturnRequest
    {
        public long RturnId { get; set; }
        public DateTime RetDate { get; set; }
        public long AdmissionId { get; set; }
        public string CabinNo { get; set; }
        public string Floor { get; set; }
        public int OutletId { get; set; }
        public string ReturnType { get; set; }
        public string ReturnBy { get; set; }
        public string Status { get; set; }
    }
}
