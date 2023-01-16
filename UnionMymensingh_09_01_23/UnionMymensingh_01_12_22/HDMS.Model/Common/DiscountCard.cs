using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DiscountCard
    {
        [Key]
        public long CardId { get; set; }
        [ForeignKey("DiscountCardMaster")]
        public long DCMId { get; set; }
       
       
        public string CardNo { get; set; }
        public DateTime? UsedDate { get; set; }

        public string status { get; set; }

        public DiscountCardMaster DiscountCardMaster { get; set; }
      
    }
}
