using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Model {
public class HospitalBillDetail{
[Key]
public long HospitalBillDetailId { get; set; }
[ForeignKey("HospitalBill")]
public long HospitalBillId { get; set; }
public int ServiceHeadId { get; set; }
public string ServiceName { get; set; }
public int Qty { get; set; }
public double Rate { get; set; }
public double Total { get; set; }
public int DisplayOrder { get; set; }
public int DoctorId { get; set; }
public HospitalBill HospitalBill { get; set; }

    }
}