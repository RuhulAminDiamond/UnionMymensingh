using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class TmpPrescriptionDataPart1
    {
        public long Id { get; set; }
        public int CpId { get; set; }
        public string Title { get; set; }
        public string Values { get; set; }
        public int DisplayOrder { get; set; }
    }
}
