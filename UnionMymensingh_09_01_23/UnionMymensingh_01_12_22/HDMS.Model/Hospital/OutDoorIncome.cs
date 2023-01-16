using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class OutDoorIncome
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PaymentType { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string HCVSerialNo { get; set; }
    }
}
