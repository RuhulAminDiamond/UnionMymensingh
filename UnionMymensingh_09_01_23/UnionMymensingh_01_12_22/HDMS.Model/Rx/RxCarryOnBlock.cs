using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCarryOnBlock
    {
        public int Id { get; set; }
        public int CPId { get; set; }
        public bool ChiefComplains { get; set; }
        public bool History { get; set; }
        public bool Additional { get; set; }
        public bool PhysicalFindings { get; set; }
        public bool OtherFindings { get; set; }
        public bool DrugHistory { get; set; }
        public bool Treatment { get; set; }
        public bool Advices { get; set; }
        public bool Tests { get; set; }
        public bool Notes { get; set; }
        public bool Diagnosis { get; set; }
        public bool Dx { get; set; }
    }
}
