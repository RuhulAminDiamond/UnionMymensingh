using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic.VM
{
    public class VMLabRequisition
    {
        public long RequisitionId { get; set; }
        public DateTime RDate { get; set; }
        public int LabId { get; set; }

        public string LabName { get; set; }

        

        public string RequisitionBy { get; set; }
        public string Status { get; set; }
    }
}
