using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.LIS
{
    public class TEMPLISResultRecord
    {
        [Key]
        public long ResultRecordId { get; set; }

        public long PatientRecordId { get; set; }

        public int ReportDefId { get; set; }

        public string Category { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string LongName { get; set; }

        public string Value { get; set; }

        public string Unit { get; set; }

        public string Range { get; set; }

        public DateTime? ReportDate { get; set; }

        public string ResultProducedBy { get; set; } // Machine Name
    }
}
