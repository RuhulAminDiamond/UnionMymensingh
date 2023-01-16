using System;
using System.ComponentModel.DataAnnotations;

namespace HDMS.Model {
public class HospitalBill
{
[Key]
public long HospitalBillId { get; set; }
public DateTime BillDate { get; set; } 
public string BillTime { get; set; }
public long AdmissionId { get; set; }
public long BillNo { get; set; }
public string PreparedBy { get; set; }
public string BillType { get; set; }
public string Remarks { get; set; }

}
}