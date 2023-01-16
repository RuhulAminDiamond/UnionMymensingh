using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common.VW
{
    public class VMDiscountCard
    {
        public long DCMId { get; set; }
        public long CardId { get; set; }
        public int DoctorId { get; set; }
        public int CardTypeId { get; set; }
        public string CardNo { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
