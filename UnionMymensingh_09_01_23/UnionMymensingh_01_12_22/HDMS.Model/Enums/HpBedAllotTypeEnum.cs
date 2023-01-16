using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Enums
{
    public enum HpBedAllotTypeEnum
    {
        PatientBed,
        ExtraBed,
        ReleasedAsPB, // Patient was at this bed during release
        ReleasedAsEB,   // This was Patient extra bed during release   
        ReleasedAsTB   //  Patient was transferred from this bed  
    }
}
