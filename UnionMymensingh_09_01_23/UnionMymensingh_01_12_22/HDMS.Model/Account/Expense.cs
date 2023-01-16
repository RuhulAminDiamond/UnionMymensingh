using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Account
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime trandate{ get; set; }
        public int AccountId{get;set;}
        public double Amount { get; set; }
        public string Description { get; set; }
        public string PaymentBy { get; set; }
        public string EntryBy { get; set; }
    }
}
