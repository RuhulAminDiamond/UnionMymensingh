using HDMS.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.MiniAccount
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime trandate{ get; set; }
        [ForeignKey("BusinessUnit")]
        public int BusinessUnitId { get; set; }
        public int AccountId{get;set;}
        public double Amount { get; set; }
        public string Description { get; set; }
        public string PaymentBy { get; set; }
        public string EntryBy { get; set; }

        public BusinessUnit BusinessUnit { get; set; }
    }
}
