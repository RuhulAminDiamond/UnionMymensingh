using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model {
 [Table("PatientLedger")]
public class PatientLedger{
public long Id { get; set; }
public long PatientId { get; set; }
public DateTime TranDate { get; set; }
public string TransactionTime { get; set; }
public string Particulars { get; set; }
public double Debit { get; set; }
public double Credit { get; set; }
public double Balance { get; set; }
public string TransactionType { get; set; }
public string Remarks { get; set; }
public string TransactionTerminal { get; set; }
public string OperateBy { get; set; }
public int PCId { get; set; }  //Payment Channel Id
public string TransactionNo { get; set; }

    }
}