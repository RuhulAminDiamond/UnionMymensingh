using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class TestGroup
    {
        [Key]
        public Int32 TestGroupId { get; set; }
        public string Name { get; set; }
        public Int32 ReportOrder { get; set; }
        public string Type { get; set; }
        public string SummaryGroup { get; set; }
        public int MasterTestGroupId { get; set; }
        public Int32? TokenOrder { get; set; }

        public int MovementOrder { get; set; }
        public string MovementRoomNo { get; set; }

        public string DeptName { get; set; }

        public string DiscountPlanGroup { get; set; }
        public double RefCommInPercent { get; set; }
        public double ReportingCommInPercent { get; set; }

    }
}
