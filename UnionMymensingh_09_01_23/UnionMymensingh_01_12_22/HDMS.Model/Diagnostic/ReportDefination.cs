using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class ReportDefination
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public string NormalValue { get; set; }
        public string ResultUnit { get; set; }
        public float? LowerLimit { get; set; }
        public float? UpperLimit { get; set; }
        public int AgeVariant { get; set; }
        public int DetailReportOrder { get; set; }
        public int TestTitle_FontBold { get; set; }
        public int TestTitle_FontItalic { get; set; }
        public int TestTitle_FontUnderline { get; set; }
        public int IsKeyValue { get; set; }  // If it is key value, it will automatically transfer to discharge patient file
        public string ResultOption { get; set; }  // PathReportValueComboType Option
        public string DefaultValue { get; set; }
    }
}
