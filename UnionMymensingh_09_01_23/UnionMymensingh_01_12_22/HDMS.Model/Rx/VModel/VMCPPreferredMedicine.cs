using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class VMCPPreferredMedicine
    {
        public long CPPMId { get; set; }
        public int CPId { get; set; }
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string BrandShortName { get; set; }
        public string DoseShortEn { get; set; }
        public string DoseShortBn { get; set; }
        public string DoseLongEn { get; set; }
        public string DoseLongBn { get; set; }
        public string BeforeAfterEn { get; set; }
        public string BeforeAfterBn { get; set; }
        public string Duration { get; set; }
        public string DurationUnit { get; set; }
        public int Qty { get; set; }
    }
}
