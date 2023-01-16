using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class VWMTestItemDetail
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestCriteria { get; set; }
        public string NormalValues { get; set; }
        public string ResultUnit { get; set; }
        public double lowerLimit { get; set; }
        public double upperLimit { get; set; }
        public double alarmLimit { get; set; }
        public bool HasAgeVariant { get; set; }
        public int Reportorder { get; set; }
    }
}
