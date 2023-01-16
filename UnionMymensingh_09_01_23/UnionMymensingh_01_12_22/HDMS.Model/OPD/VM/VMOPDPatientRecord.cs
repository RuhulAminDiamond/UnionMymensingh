using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD.VM
{
    public class VMOPDPatientRecord
    {
        public long RegNo { get; set; }
        public long PatientId { get; set; }
        public long BillNo { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string MobileNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string Status { get; set; }
    }
}
