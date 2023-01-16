using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class PractitionerWisePatientSerial
    {
        public int Id { get; set; }
        public int DailyId { get; set; }
        public int ChamberPractitionerId { get; set; }
        public int SerialNo { get; set; }
        public DateTime SerialDate { get; set; }
        public string SerilTime { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public int VisitTypeId { get; set; }
        public int MAId { get; set; }  // Marketing Agent Id
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string AgeYear { get; set; }
        public string AgeMonth { get; set; }
        public string AgeDay { get; set; }
        public DateTime? DOB { get; set; }
        public string EmailId { get; set; }
        public string StartTime { get; set; }
        public string StartAmPm { get; set; }
        public String EndTime { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public string Titel { get; set; }
    }
} 
