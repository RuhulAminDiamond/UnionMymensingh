using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Marketing
{
    public class MarketingAgent
    {
        [Key]
        public int MAId { get; set; }
        public string Name { get; set; }
        public long EmployeeId { get; set; }
    }
}
