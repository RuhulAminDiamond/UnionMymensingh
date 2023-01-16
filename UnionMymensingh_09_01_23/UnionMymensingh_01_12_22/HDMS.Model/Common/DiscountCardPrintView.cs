using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DiscountCardPrintView
    {
        [Key]
        public long SrlNo { get; set; }
       
        public string CardType { get; set; }
        public string topLabel { get; set; }
      
        public string CardNo1 { get; set; }
        public string CardNo2 { get; set; }

        public string CardNo3 { get; set; }
        public string CardNo4 { get; set; }

        public string CardNo5 { get; set; }
       
    }
}
