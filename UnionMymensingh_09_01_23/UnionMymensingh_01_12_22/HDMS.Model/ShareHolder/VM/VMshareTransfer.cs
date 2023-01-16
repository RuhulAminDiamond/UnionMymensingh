using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class VMshareTransfer
    {

        public int ShId { get; set; }
        public string ShName { get; set; }
        public string ShMobile { get; set; }
        public string ShPermanentAddress { get; set; }
        public long Shareno { get; set; }


    }
}
