using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD.VM
{
    public class VMOPDServiceHead
    {
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public int ServiceCode { get; set; }
        public int ServiceHeadId { get; set; }
        public string ServiceHeadName { get; set; }
        public double Rate { get; set; }
        public string Unit { get; set; }
        public bool Vat { get; set; }
        public bool ServiceCharge { get; set; }
        public bool DocVisit { get; set; }
        public bool Show { get; set; }
        public bool OpdShow { get; set; }
    }
}
