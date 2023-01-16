using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class RightShareInfo
    {
        public int Id { get; set; }
        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }
        public int FiscalYear { get; set; }
        public int TotalShare { get; set; }
        public double RightShare { get; set; }
        public double IssuedShare { get; set; }
        public double ExtraShare { get; set; }
        public string Particulars { get; set; }
        public ShareHolderBasicData ShareHolderBasicData { get; set; }
    }
}
