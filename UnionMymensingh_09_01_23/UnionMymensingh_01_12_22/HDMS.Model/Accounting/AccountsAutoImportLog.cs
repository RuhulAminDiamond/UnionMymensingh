using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Accounting
{
    public class AccountsAutoImportLog
    {
        [Key]
        public int AILogId { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportTime { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ImportedBy { get; set; }
    }
}
