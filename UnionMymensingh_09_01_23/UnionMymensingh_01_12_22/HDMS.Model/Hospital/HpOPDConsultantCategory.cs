using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpOPDConsultantCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public double CpPercent { get; set; }  // Percent of Rate Own by Consultant
        public double HpPercent { get; set; }  // Percent of Rate Own by Organization
    }
}
