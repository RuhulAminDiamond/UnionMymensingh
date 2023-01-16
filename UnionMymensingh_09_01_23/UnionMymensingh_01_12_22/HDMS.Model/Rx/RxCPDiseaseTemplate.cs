using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPDiseaseTemplate
    {
        [Key]
        public long DTId { get; set; }
        public int CpId { get; set; }
        public string DiseaseName { get; set; }
        public string TerminalMacAddress { get; set; }
    }
}
