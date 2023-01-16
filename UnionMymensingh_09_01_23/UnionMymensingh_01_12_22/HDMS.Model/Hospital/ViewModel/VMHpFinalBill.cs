using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class VMHpFinalBill
    {
        public int SrlNo { get; set; }
        public int ServiceHeadId { get; set; }
        public string ServiceName { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }
        public int AccomodationTypeId { get; set; }
        public int DoctorId { get; set; }
        public string ServiceGroup { get; set; }
        public double ServiceChargeInPercent { get; set; }
    }
}
