using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class OrganizationInfo
    {
        [Key]
        public int OrgId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        [ForeignKey("CompanyInfo")]
        public int CompanyId { get; set; }

        public CompanyInfo CompanyInfo { get; set; }
    }
}
