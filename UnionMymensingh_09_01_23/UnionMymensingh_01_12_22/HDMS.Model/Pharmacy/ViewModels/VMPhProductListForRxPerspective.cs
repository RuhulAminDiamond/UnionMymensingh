using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy.ViewModels
{
    public class VMPhProductListForRxPerspective
    {
       
        public int ProductId { get; set; } // Medicine Id from Central Medicine Store/Pharmacy
        public string BrandName { get; set; }
        public string GroupName { get; set; }
        public string GenericName { get; set; }
        public int GenericId { get; set; }
        public int GroupId { get; set; }
        public int FormationId { get; set; }
        public string FormationShortName { get; set; }
        public string Manufacturer { get; set; }
        public string DoseEnShort { get; set; }
        public string DoseBnShort { get; set; }
        public string DoseEnLong { get; set; }
        public string DoseBnLong { get; set; }

        public string BeforeAfterEn { get; set; }
        public string BeforeAfterBn { get; set; }
        public string Duration { get; set; }
        public string DurationUnit { get; set; }
        public int DoseId { get; set; }

    }
}
