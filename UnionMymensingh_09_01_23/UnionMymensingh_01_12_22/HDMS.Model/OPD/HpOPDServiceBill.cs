using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD
{
    public class HpOPDServiceBill
    {
       [Key]
       public long SBId { get; set; }
       public DateTime SDate { get; set; }
       public double ServiceAmount { get; set; }
    }
}
