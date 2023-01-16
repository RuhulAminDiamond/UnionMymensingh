using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class ReferralCategory
    {
        [Key]
        public int RefCategoryId { get; set; }
        public string Name { get; set; }
    }
}
