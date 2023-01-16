using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCpDosage
    {
        [Key]
        public int DoseId { get; set; }
        public int CpId { get; set; }
        public string DoseEnLong { get; set; }
        public string DoseBnLong { get; set; }
        public string DoseEnShort { get; set; }
        public string DoseBnShort { get; set; }
        public string ShortKey { get; set; }
        public int EMRInterPretId { get; set; }
    }
}
