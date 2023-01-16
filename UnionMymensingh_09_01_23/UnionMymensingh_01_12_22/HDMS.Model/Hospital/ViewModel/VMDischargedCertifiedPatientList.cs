using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMDischargedCertifiedPatientList
    {
        public long BillNo { get; set; }
        public DateTime DCPrintDate { get; set; }
        public long RegNo { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime AddmissionDate { get; set; }
        public string FullName { get; set; }
        public string CPAddress { get; set; }
        public string CPMobile { get; set; }
        
    }
}
