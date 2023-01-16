using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class HospitalRoughBillDetail
    {
        [Key]
        public long HospitalRoughBillDetailId { get; set; }
        [ForeignKey("HospitalRoughBill")]
        public long HospitalRoughBillId { get; set; }
        public int ServiceHeadId { get; set; }
        public string ServiceName { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }
        public int DisplayOrder { get; set; }
        public int DoctorId { get; set; }
        public HospitalRoughBill HospitalRoughBill { get; set; }
    }
}
