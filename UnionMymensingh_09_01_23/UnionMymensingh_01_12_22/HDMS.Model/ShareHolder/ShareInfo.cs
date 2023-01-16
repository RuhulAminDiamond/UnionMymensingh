using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDMS.Model.ShareHolder
{
    public class ShareInfo
    {

        [Key]
        public int ShareId { get; set; }
        public long ShareNo { get; set; }
        public int TotalShare { get; set; }
        public double FaceValue { get; set; }
        public double TotalInvestment { get; set; }
        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }
        public ShareHolderBasicData ShareHolderBasicData { get; set; }
    }
}
