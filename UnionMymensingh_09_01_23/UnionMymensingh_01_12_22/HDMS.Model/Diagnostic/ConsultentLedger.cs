using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
  public  class ConsultentLedger
    {
        [Key]
        public long ConLedgerId { get; set; }
        public long PatientId { get; set; }
        public int ConsultentId { get; set; }
        public string ConsultantName { get; set; }
        public string PatientName { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Particulars { get; set; }
        public string TransectionType { get; set; }
        public DateTime TranDate { get; set; }
    }
}
