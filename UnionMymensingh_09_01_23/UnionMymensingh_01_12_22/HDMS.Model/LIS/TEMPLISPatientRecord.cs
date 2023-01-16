using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.LIS
{
    public class TEMPLISPatientRecord
    {
        [Key]
        public long PatientRecordId { get; set; }

        public long InterfacingDbPatientRecordId { get; set; }

        public long PatientId { get; set; }

        public string ReportId { get; set; }

        public int? SequenceId { get; set; }

        public string InstrumentName { get; set; }

        public DateTime? ReportDate { get; set; }

        public int ReportTypeId { get; set; }
    }
}
