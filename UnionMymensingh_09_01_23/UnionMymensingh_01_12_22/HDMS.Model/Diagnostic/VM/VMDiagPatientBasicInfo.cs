using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMDiagPatientBasicInfo
    {
        public long PatientId { get; set; }
        public string ReportId { get; set; }
        public long RegNo { get; set; }
        public long BillNo { get; set; }
        public string PatientName { get; set; }
        public string Ageyear { get; set; }
        public string Sex { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string TestName { get; set; }
        public string MediaName { get; set; }
        public string status { get; set; }
        public string DiscountCareOf { get; set; }
        public DateTime EntryDate { get; set; }
        public long AdmissionNo { get; set; }
        public string UserName { get; set; }
        public string SampleId { get; set; }

        public string EntryTime { get; set; }

        public string LoginName { get; set; }
        public string ArearOrThana { get; set; }

    }
}
