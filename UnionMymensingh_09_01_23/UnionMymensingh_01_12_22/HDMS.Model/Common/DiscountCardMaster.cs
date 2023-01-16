using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DiscountCardMaster
    {
        [Key]
        public long DCMId { get; set; }
        public int DoctorId { get; set; }
        public string CardTopLabel { get; set; }
        [ForeignKey("DiscountCardType")]
        public int CardTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
     
        public string CreatedBy { get; set; }

        public DiscountCardType DiscountCardType { get; set; }
    }
}
