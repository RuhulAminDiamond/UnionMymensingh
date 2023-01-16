using System;


namespace Models.Canteen
{
public class CantInvoiceDetail{

public long Id { get; set; }
public long InvoiceId { get; set; }
public int ProductId { get; set; }
public Double Qty { get; set; }

public Double PurchaseRate { get; set; }

public Double SaleRate { get; set; }

public Double TotalPrice { get; set; }

public Double Discount { get; set; }



}
}