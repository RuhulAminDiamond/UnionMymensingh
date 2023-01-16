using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class MediaLedger
    {

        public long Id { get; set; }
        [ForeignKey("BusinessMedia")]
        public int MediaId { get; set; }
        public DateTime TranDate { get; set; }
        public string Particulars { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public string OperateBy { get; set; }
        public long PatientId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public BusinessMedia BusinessMedia { get; set; }
    }
}
