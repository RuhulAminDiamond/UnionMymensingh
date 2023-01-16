using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Media
{
    public class VMMedialCommissionCalculation
    {
        public long PatientId { get; set; }
        public string TestName { get; set; }
        public double TestRate { get; set; }
        public double CommissionInPercent { get; set; }
        public double CommissionInAmount { get; set; }
    }
}
