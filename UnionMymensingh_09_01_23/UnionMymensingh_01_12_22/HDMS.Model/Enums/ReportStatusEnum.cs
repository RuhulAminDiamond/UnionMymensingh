using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Enums
{
    public enum ReportStatusEnum
    {
        NE,  // New Entry
        OP, // Order in Progress for Non-Lab Report
        SC,  // Sample Collcedted
        SR,  //Sample Received at Lab
        SRun, //Sample Running
        RG, //Result Generated
        RV, //Result Verified
        RP, // Report Printed
        RD // Report Delivered
    }
}
