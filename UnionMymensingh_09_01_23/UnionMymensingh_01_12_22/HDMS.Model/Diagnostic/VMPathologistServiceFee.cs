using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
  public  class VMPathologistServiceFee
    {
        public long PatientId { get; set; }
        public string PatientName { get; set; }
        public double Fee { get; set; }
        public int ReportType { get; set; }
        public double TotalFee { get; set; }
        public double Cost { get; set; }
        public string Consultant { get; set; }
        public int RCId { get; set; }
    }
}
