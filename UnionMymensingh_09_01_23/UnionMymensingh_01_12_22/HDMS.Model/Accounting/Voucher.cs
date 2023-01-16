using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounting
{
    public class Voucher
    {
        [Key]
        public long VMId { get; set; }
        public int CompanyId { get; set; }
        public string VoucherId { get; set; }
        public string VTime { get; set; }
        public DateTime VoucherDate { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public string VoucherType { get; set; }
        public string Name { get; set; }  // For Alkamy  Who Receives the money
        public int AILogId { get; set; }  // Auto Import Log Id

        ICollection<VoucherDetail> VoucherDetail { get; set; }

    }
}
