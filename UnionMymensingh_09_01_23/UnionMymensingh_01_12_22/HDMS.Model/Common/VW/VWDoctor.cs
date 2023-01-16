using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common.VW
{
    public class VWDoctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string OPDConsultant { get; set; }
        public string DeptName { get; set; }
        public string ConsultantType { get; set; }
        public double ConsultancyFee { get; set; }
        public double HpPercent { get; set; }
        public double CpPercent { get; set; }
    }
}
