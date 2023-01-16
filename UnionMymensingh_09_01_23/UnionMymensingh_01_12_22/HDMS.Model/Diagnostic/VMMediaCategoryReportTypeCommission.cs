using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class VMMediaCategoryReportTypeCommission
    {
        public int CategoryRepotTypeId { get; set; }
        public double Commission { get; set; }
        public int CategoryId { get; set; }
        public int ReportTypeId { get; set; }
        public bool IsPercent { get; set; }
        public double CommissionPercent { get; set; }
        public string Report_Type { get; set; }
        public string CategoryName { get; set; }
    }
}
