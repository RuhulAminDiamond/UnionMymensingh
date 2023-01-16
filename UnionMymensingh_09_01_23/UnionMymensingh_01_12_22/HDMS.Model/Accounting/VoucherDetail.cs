using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounting
{
    public class VoucherDetail
    {
        public long Id { get; set; }
        [ForeignKey("Voucher")]
        public long VMId { get; set; }
        public string DRCR { get; set; }
        [ForeignKey("AccountHead")]
        public int AccId { get; set; }
        public double Amount { get; set; }
        public string reamrks { get; set; }
        public Voucher Voucher { get; set; }
        public AccountHead AccountHead { get; set; }
    }
}
