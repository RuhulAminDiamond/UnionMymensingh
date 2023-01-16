using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMLISOutput
    {
        public long PatientRecordId { get; set; }
        public string PatientId { get; set; }
        public string SequenceId { get; set; }
        public string TestName { get; set; }
        public string DeviceName { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
