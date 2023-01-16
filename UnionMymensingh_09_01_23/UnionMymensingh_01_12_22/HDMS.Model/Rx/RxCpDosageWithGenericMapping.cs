using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpDosageWithGenericMapping
    {
        public int Id { get; set; }
        public int CpId { get; set; }
        public int GenericId { get; set; }
        public int FormationId { get; set; }
        public int DoseId { get; set; }
        public int DefaultDuration { get; set; }
        public string DDUnit { get; set; }
        public string Qty { get; set; }
    }
}
