using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{

    public class VMDiagPatient
    {
        public long PatientId { get; set; }
        public long BillNo { get; set; }
        public string ReportId { get; set; }
        public long RegNo { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string RefdBy { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string ReportStatus { get; set; }
    }


    public class VMDiagPatientAndTestDetail
    {
        public long PatientId { get; set; }
        public string ReportId { get; set; }
        public long BillNo { get; set; }
        public long RegNo { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string RefdBy { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string ReportStatus { get; set; }
        public string ReportDeliveredBy { get; set; }
    }
}
