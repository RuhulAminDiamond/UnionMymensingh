using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.OPD.VM
{
    public class SelectedServicesForOPDPatient
    {
        public int ServiceOrConsultandId { get; set; }
        public string ServiceHead { get; set; }
        public string DisplayName { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
        public int TAmount { get; set; }
        public int GroupId { get; set; }
        public int VisitTypeId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
       
    }
}
