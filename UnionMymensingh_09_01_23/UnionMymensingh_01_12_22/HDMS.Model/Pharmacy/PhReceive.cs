using HDMS.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
   public class PhReceive
    {
       [Key]
        public long ReceiveId { get; set; }
        public long OrderId { get; set; }
        [ForeignKey("MedicineOutlet")]
        public int OutLetId { get; set; }
        public DateTime RDate { get; set; }
        public string Particulars { get; set; }
        public double TotalTk { get; set; }
        public double DiscountTk { get; set; }
        public double VatTk { get; set; }
       
        public double GtotalTk { get; set; }
        public int SupplerId { get; set; }
        public int ReceiveInvoiceNo { get; set; }
        public string SupInvNo { get; set; }
        public string SupChalanNo { get; set; }
        public DateTime SupInvDate { get; set; }
        public string Receivedby { get; set; }

        public string ReceiveType { get; set; } // Either purchase receive from supplier/ Return Receive from customer

        public long IPDReturnBy { get; set; }

        public long OPDReturnInvoice { get; set; }

        public MedicineOutlet MedicineOutlet { get; set; }
    }
}
