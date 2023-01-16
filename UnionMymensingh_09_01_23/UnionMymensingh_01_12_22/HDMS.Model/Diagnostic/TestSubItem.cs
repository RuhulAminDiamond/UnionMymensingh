using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class TestSubItem
    {
        public int TestSubItemId { get; set; }
        public int MainTestId { get; set; }
        public int TestId { get; set; }

        public int TestCode { get; set; }

        public string Name { get; set; }
        public bool Vatable { get; set; }
        public int ReportTypeId { get; set; }
        public double Rate { get; set; }
        public int Qty { get; set; }
        public float SC { get; set; }
        public string Specimen { get; set; }
        public bool Exclusive { get; set; }
    }
}
