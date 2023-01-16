using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpMedicineReturnInednt
    {
        [Key]
        public long ReturnIndentId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnTime { get; set; }
        public long AdmissionId { get; set; }
        public int OutletId { get; set; }
        public string ReturnType { get; set; }  // From customer or outlet
        public string ReturnIndentBy { get; set; }
        public string Status { get; set; }
    }
}
