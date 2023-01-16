using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxCPPreferredMedicine    // Chamber Practioner Personal Medicine Database
    {
        [Key]
        public long CPPMId { get; set; }
        [ForeignKey("ChamberPractitioner")]
        public int CPId { get; set; }
        public int ProductId { get; set; }  // Central Pharmacy Producct Id
        public string BrandName { get; set; }
        public string BrandShortName { get; set; } // For Drug History and my Otherwise needed
        public int ManufacturerId { get; set; }
        public int GroupId { get; set; }
        public int GenericId { get; set; }
        public int FormationId { get; set; }
        public string DoseShortEn { get; set; }
        public string DoseShortBn { get; set; }
        public string DoseLongEn { get; set; }
        public string DoseLongBn { get; set; }
        public string BeforeAfterEn { get; set; }
        public string BeforeAfterBn { get; set; }
        public string Duration { get; set; }
        public string DurationUnit { get; set; }
        public int Qty { get; set; }
        public ChamberPractitioner ChamberPractitioner { get; set; }
        
    }
}
