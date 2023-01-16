using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital.ViewModel
{
    public class SelectedMedicineForPatientOnDischarge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string dosage { get; set; }
        public string Formation { get; set; }
        public bool IsDoseBanglaFont { get; set; }
        public string BeforAfterMeal { get; set; }
        public bool IsBeforeAfterBanglaFont { get; set; }
        public string duration { get; set; }
        public bool IsDurationBanglaFont { get; set; }
        public string Unit { get; set; }
        public bool IsUnitBanglaFont { get; set; }
        public int qty { get; set; }
        public int doseId { get; set; }
    }
}
