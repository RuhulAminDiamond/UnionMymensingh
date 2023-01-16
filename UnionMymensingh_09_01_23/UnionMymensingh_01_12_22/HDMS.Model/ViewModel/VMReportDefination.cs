using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
    public class VMReportDefination 
    {
        public int TestDetailId { get; set; }

        public long PatientId { get; set; }
        public long ReportId { get; set; }
        public int ReportDoctor { get; set; }
        public int ReportTechnologist { get; set; }
        public int GroupId { get; set; }
        public string GroupTitle { get; set; }
        public int TestId { get; set; }
        public int ReportTypeId { get; set; }
        public string TestTitle { get; set; }
        public string NormalValue { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string MachineResult { get; set; }
        public string MachineCode { get; set; }
        public string ResultUnit { get; set; }
        public float? LowerLimit { get; set; }
        public float? UpperLimit { get; set; }
        public int AgeVariant { get; set; }
        public int DetailReportOrder { get; set; }
        public int TestReportOrder { get; set; }
        public int GroupReportOrder { get; set; }
        public int TestTitle_FontBold { get; set; }
        public int TestTitle_FontItalic { get; set; }
        public int TestTitle_FontUnderline { get; set; }
        public string ResultOption { get; set; }  // PathReportValueComboType Option
        public bool IsNewResult { get; set; }  // Check to display in R.Result Vs. Machine Result

        public string PrefixedPId { get; set; }
        public string IdPrefix { get; set; }
        public long PatientRecordId { get; set; }
        public string Value { get; set; }
        public string PatientIdNumeric { get; set; }
        public string DefaultValue { get; set; }


    }
}
