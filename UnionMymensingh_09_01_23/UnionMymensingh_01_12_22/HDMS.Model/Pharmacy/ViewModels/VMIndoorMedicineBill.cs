using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMIndoorMedicineBill
    {
        public long BillNo { get; set; }
        public string FullName { get; set; }
        public string CabinNo { get; set; }
        public double MedicineBill { get; set; }
    }
}
