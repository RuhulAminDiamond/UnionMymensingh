using Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting
{
    public class AccOpeningBalance 
    {
        public int Id { get; set; }
        [ForeignKey("FiscalYear")]
        public int FYId { get; set; }
        [ForeignKey("AccountHead")]
        public int AccId { get; set; }
        public double OPAmount { get; set; }

        public FiscalYear FiscalYear { get; set; }
        public AccountHead AccountHead { get; set; }
    }
}
