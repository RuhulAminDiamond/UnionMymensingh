using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting
{
    public class OrgMasterBillingSection
    {
        [Key]
        public int OMBId { get; set; }
        public string Name { get; set; }
    }
}
