using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class YearOnYearShareInfo
    {
        public int Id { get; set; }

        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }

        public int Year { get; set; }
        public int TotalShare { get; set; }

        public ShareHolderBasicData ShareHolderBasicData { get; set; }
    }
}
