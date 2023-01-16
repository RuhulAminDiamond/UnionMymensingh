using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDMS.Model.Common
{
public class SupplierLedger
{
public long Id { get; set; }
[ForeignKey("SuplierInfo")]
public int SupplierId { get; set; }
public  DateTime Trandate { get; set; }
public string Particulars { get; set; }
public double Debit { get; set; }
public double Credit { get; set; }
public double Balance { get; set; }

public SupplierInfo SuplierInfo { get; set; }
}


}