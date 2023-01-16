using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxPatientMasterData
    {
        [Key]
        public long RxPMId { get; set; }
        public long RegNo { get; set; }
        public DateTime RxMasterDataDate { get; set; }
        
        public int OperateBy { get; set; }
        public string TerminalMacAddress { get; set; }

    }
}
