using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HpParameterSetup
    {
        [Key]
        public int ParameterId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string ParameterType { get; set; }

        public string AmountType { get; set; }
    }
}
