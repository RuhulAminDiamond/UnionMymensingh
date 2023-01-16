using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPPrintPageSetup
    {
        public int Id { get; set; }
        public int CpId { get; set; }
        public string PageType { get; set; }  // Value from RxPageTypeEnum
        public string PageOrientation { get; set; }
        public double TopMargin { get; set; }
        public double RightMargin { get; set; }
        public double BottomMargin { get; set; }
        public double LeftMargin { get; set; }
        public string footerText { get; set; }
        public string headretext { get; set; }
    }
}
