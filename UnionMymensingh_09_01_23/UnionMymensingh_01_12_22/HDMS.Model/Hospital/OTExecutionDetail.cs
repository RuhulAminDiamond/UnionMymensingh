using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
   public class OTExecutionDetail
    {
       [Key]
       public long OTDId { get; set; }
       [ForeignKey("OTSchedule")]
       public long OTId { get; set; }
       [ForeignKey("ServiceHead")]
       public int ServiceHeadId { get; set; }

       [ForeignKey("Doctor")]
       public int DoctorId { get; set; }

       public double Rate { get; set; }
       public double Qty {get; set;}
       public double Vat { get; set; }
       public double ServiceCharge { get; set; }
       public DateTime ServiceDate { get; set; }

       public string ServiceTime { get; set; }
       public string UserName { get; set; }

       public OTSchedule OTSchedule { get; set; }
       public ServiceHead ServiceHead { get; set; }
       public Doctor Doctor { get; set; }
    }
}
