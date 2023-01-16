using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class BusinessMedia
    {
        [Key]
        public int MediaId { get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string MediaType { get; set; }
        public int CategoryId { get; set; }
    }
}
