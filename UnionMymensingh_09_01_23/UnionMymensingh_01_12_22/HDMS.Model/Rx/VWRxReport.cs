using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class VWRxReport
    {
        public long Id { get; set; }
        public DateTime RxDate { get; set; }
        public long RegNo { get; set; }
        public int RxDoctorId { get; set; }
        public string InitialSymtoms { get; set; }

        public string Advices { get; set; }

        public string TestName { get; set; }

        public string DrugName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
        public int OperateBy { get; set; }
    }
}
