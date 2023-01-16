using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class MedicineInterX
    {
        public int Id { get; set; }
        public string Agent1 { get; set; }
        public int Ag1_GenericId { get; set; }
        public int Ag1_GroupId { get; set; }
        public string Agent2 { get; set; }
        public int Ag2_GenericId { get; set; }
        public int Ag2_GroupId { get; set; }
        public string InterX { get; set; }
    }
}
