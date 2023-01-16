using HDMS.Model.Pharmacy;
using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
   public class PhInvoice
    {
       [Key]
        public long InvoiceId { get; set; }

        [ForeignKey("MedicineOutlet")]
        public int OutLetId { get; set; }
        public long BillNo { get; set; }

        public long AdmissionNo { get; set; }

        public long RequisitionNo { get; set; }  //Nurse Requisition No, In case of IPD Reurn Return Indent No 

        public string InvoiceType { get; set; }
        public DateTime Invdate { get; set; }
       


        public string InvTime { get; set; }
        public int CustomerID { get; set; }
        public double TotalTK { get; set; }
        public double DiscountTK { get; set; }
        public double GrandTK { get; set; }
        public double ReceivedTK { get; set; }
        public double CardOrMobileReceiveTk { get; set; }
        public double CardOrMobileServiceChargeTk { get; set; }
        public double ChangeTK { get; set; }
        
        public double DueTK { get; set; }
        public double ReturnAdjustedTK { get; set; }

        public string OPDCustomerName { get; set; }
       
        public string IsReturened { get; set; }
        public int RRInvoice { get; set; } //Retuen Received Invoice
        public int ReturnedInvoiceNo { get; set; } // Invoice from which the product is returned.

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public MedicineOutlet MedicineOutlet { get; set; }

    }
}
