using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class VMGenericWithDefaultDose
    {
        public int GroupId { get; set; }
        public int GenericId { get; set; }
        public int DoseId { get; set; }
        public string GroupName { get; set; }
        public string GenericName { get; set; }
        public string Dose { get; set; }
        public int DefaultDuration { get; set; }
        public string DDUnit { get; set; }
        public string Qty { get; set; }
    }
}
