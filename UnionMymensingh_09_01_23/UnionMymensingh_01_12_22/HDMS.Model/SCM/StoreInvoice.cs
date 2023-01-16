using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Store
{
    public class StoreInvoice
    {
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
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }

        public string ChallanNumber { get; set; }

        public string ChallanAddress { get; set; }

        public string InvoiceType { get; set; }
        public string IsReturened { get; set; }
        public int RRInvoice { get; set; } //Retuen Received Invoice
        public int ReturnedInvoiceNo { get; set; } // Invoice from which the product is returned.
        public long RequisitionId { get; set; }
        public int DeptId { get; set; }
    }
}
