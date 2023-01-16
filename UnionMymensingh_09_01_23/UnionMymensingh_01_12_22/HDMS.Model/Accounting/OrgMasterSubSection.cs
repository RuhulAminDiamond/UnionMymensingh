using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting
{
    public class OrgMasterBillingSubSection
    {
        public int Id { get; set; }
        [ForeignKey("OrgMasterBillingSection")]
        public int OMBId { get; set; }
        public string SSName { get; set; }

        public OrgMasterBillingSection OrgMasterBillingSection { get; set; }
    }
}
