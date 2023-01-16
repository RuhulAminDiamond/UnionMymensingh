using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Canteen
{
public class CantInvoice{
   [Key]
    public long InvoiceId { get; set; }
    public DateTime Invdate { get; set; }
    public string MobileNo { get; set; }
    public double TotalTK { get; set; }
    public double DiscountTK { get; set; }
    public double GrandTK { get; set; }
    public double ReceivedTK { get; set; }
    public double ChangeTK { get; set; }
    public int OrderFrom { get; set; }
    public double DueTK { get; set; }
    public double ReturnAdjustedTK { get; set; }
    public long  InvoiceNumber {get; set; }
    public int CustomerId { get; set; }

    public string ChallanNumber { get; set; }

    public string ChallanAddress { get; set; }

    public string InvoiceType { get; set; }
    public string IsReturened { get; set; }
    public long RRInvoice { get; set; } //Retuen Received Invoice
    public int ReturnedInvoiceNo { get; set; } // Invoice from which the product is returned.

}
}