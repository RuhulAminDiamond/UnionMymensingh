using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class SelectedAccountHeadToVoucher
    {
        
            public int Id { get; set; }
            public string AccountHeadName { get; set; }
            public Int32 AccountHeadID { get; set; }
            public double Amount { get; set; }
            public string Remarks { get; set; }
    }
}
