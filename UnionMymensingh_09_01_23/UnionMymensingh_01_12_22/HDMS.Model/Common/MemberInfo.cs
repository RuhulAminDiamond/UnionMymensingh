using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
   public class MemberInfo
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
    }

    public class PhMemberInfo
    {
        [Key]
        public int MemberId { get; set; }
        public string MembershipCategory { get; set; }
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
    }
}