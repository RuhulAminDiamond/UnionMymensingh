using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareWithdrawdata
    {
        [Key]
        public int WithdrawId { get; set; }
        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }
        public double WithdrawAmount { get; set; }
        public DateTime Wdate { get; set; }
        public string transferby { get; set; }
        public ShareHolderBasicData ShareHolderBasicData { get; set; }
    }
}
