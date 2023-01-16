using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class UXEntryList
    {
        public long PatientId { get; set; }
        public long BillNo { get; set; }
        public string PatientName { get; set; }
        public string Tests { get; set; }
    }
}
