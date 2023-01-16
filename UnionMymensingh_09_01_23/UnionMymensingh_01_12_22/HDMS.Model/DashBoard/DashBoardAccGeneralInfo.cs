using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class DashBoardAccGeneralInfo
    {
        public int Id { get; set; }
        public string BroadHead { get; set; }
        public string SubHead { get; set; }
        public int DisplayOrder { get; set; }
        public double Col1 { get; set; }
        public double Col2 { get; set; }
        public double Col3 { get; set; }
        public double Col4 { get; set; }
        public double Col5 { get; set; }
        public double Col6 { get; set; }
        public double? Col7 { get; set; }
        public double? Col8 { get; set; }
        public string SelectionKey { get; set; }
    }
}
