using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting.VModel
{
    public class VMAutoImportedPostedVoucherDetail
    {
        public int AILogId { get; set; }
        public int AccId { get; set; }
        public string AccountHeadName { get; set; }

        public double Amount { get; set; }

    }
}
