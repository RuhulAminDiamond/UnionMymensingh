using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class PathologyReport
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportTime { get; set; }
        public int ReportDoctor { get; set; }
        public int ReportTechnologist { get; set; }
        public int ReportType { get; set; }
        public string PreparedBy { get; set; }
        public string AnyComments { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedTime { get; set; }
        public int TestCarriedOutby { get; set; }
        public bool IsPaid { get; set; }
    }
}
