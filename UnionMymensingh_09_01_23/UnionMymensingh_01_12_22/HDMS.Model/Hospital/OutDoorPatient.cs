using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class OutDoorPatient
    {
        public int Id { get; set; }
        public int DailyId { get; set; }
        public string RegNo { get; set; }
        public string ServiceFor { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string GurdianName { get; set; }
        public string Village { get; set; }
        public string Union { get; set; }
        public string Upazilla { get; set; }
        public string MobileNo { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
