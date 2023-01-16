using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Enums
{
    public enum RxPatientHistoryAddCalledFrom
    {
        CC,  // Chief Complain
        CCD, // Chief Complain Duration
        PrIL, // Present illness
        PaIL, // Past illness
        FaH, // Family History
        PeH,  // Personal History
        SeH, // Socioeconomic History
        PscyH, // Psychiatric History
        DrH, // Drug & Treatment History
        AH, // Allergy History
        ImH, // Immunization History
        MoH, // Menstrual & Obstetric History
        OH // Other History
    }
}
