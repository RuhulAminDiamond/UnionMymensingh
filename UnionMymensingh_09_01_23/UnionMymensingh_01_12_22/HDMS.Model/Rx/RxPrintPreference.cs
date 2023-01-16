using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxPrintPreference
    {
        public int Id { get; set; }
        public int CPId { get; set; }
        public bool ChiefComplains { get; set; }
        public bool ChiefComplainsWithHistory { get; set; }
        public bool BP { get; set; }
        public bool Pulse { get; set; }
        public bool Weight { get; set; }
        public bool PhysicalExam { get; set; }
        public bool Investigations { get; set; }
        public bool Treatment { get; set; }
        public bool Diagnosis { get; set; }
        public bool PrintFormat1 { get; set; }
        public bool PrintFormat2 { get; set; }
        public bool PrintFormat3 { get; set; }
        public bool PrintFormat4 { get; set; }
        public bool PrintFormat5 { get; set; }
        public bool PrintFormat6 { get; set; }
        public bool PrintFormat7 { get; set; }
        public bool PrintFormat8 { get; set; }

    }
}
