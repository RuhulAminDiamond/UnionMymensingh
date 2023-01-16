using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxSelectedMedicineForPatient
    {
        public int ProductId { get; set; }
        public long CPPMId { get; set; }
        public int GenericId { get; set; }
        public int GroupId { get; set; }
        public string BrandName { get; set; }
        public string dosage { get; set; }
        
        public string duration { get; set; }
       
        public int Qty { get; set; }
        public int doseId { get; set; }
    }
}
