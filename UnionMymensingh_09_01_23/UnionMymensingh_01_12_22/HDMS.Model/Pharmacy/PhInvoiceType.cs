using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhInvoiceType
    {
        [Key]
        public int InvoceTypeId { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceTypeShortName { get; set; }
    }
}
