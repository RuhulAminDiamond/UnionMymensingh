using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareHolderLedger
    {
        [Key]
        public int tranId { get; set; }
        [ForeignKey("DividentInfo")]
        public int DId { get; set; }
        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }
        public DateTime TDate { get; set; }
        public string particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public DividentInfo DividentInfo { get; set; }
        public ShareHolderBasicData ShareHolderBasicData { get; set; }

    }
}
