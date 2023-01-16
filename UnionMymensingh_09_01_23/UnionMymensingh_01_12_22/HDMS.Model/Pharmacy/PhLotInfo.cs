using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhLotInfo
    {
        [Key]
        public long LotNo { get; set; } 
        public string BatchNo { get; set; }
        public DateTime ExpireDate { get; set; }
       
        public DateTime CreateDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

        public User User { get; set; }
    }
}
