using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder.VM
{
    public class VMRightShareInfo
    {
        public int Id { get; set; }
        public int ShId { get; set; }
        public string ShName { get; set; }
        public int TotalShare { get; set; }
        public double RightShare { get; set; }
        public double IssuedShare { get; set; }
        public double ExtraShare { get; set; }
    }
}
