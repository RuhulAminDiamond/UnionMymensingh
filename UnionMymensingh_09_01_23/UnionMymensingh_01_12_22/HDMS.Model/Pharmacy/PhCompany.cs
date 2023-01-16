using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ShortName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

    }
}
