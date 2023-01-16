using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class OrgBusinessUnit
    {
        [Key]
        public int BusinessUnitId { get; set; }
        public string Name { get; set; }

        [ForeignKey("OrganizationInfo")]
        public int OrgId { get; set; }

        public OrganizationInfo OrganizationInfo { get; set; }
    }
}
