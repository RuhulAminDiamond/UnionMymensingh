using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpRequisitionType
    {
        [Key]
        public int RequisitionTypeId { get; set; }
        public string RequisitionType { get; set; }
    }
}
