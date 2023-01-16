using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Enums
{
    public enum RxDoseApplyModeEnum  // For Dose EMR Interpretation
    {
        MNN, // Morning Noon Night That means three times in a day
        MNght, // Morning and Night
        M, // Moring Only
        Nght, // Night Only
        Noon, // Noon Only
        MNoon, // Morning and Noon
        NN, // Noon and Night Only
        Hourly,
        Weekly,
        Monthly
    }
}
