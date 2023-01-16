using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class TreatmentOnDischarge
    {
        public long Id { get; set; }
        public long AdmissionId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public bool IsDoseBanglaFont { get; set; }
        public string Duration { get; set; }
        public bool IsDurationBanglaFont { get; set; }
        public string BeforAfterMeal { get; set; }
        public bool IsBeforAfterMealBanglaFont { get; set; }
        public string Unit { get; set; }
        public bool IsUnitBanglaFont { get; set; }
    }
}
