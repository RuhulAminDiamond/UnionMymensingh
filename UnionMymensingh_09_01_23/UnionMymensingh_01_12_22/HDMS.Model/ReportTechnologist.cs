using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model
{
    public class ReportTechnologist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FSize1 { get; set; }
        public string Identity1 { get; set; }

        public int? FSize2 { get; set; }
        public string Identity2 { get; set; }

        public int? FSize3 { get; set; }
        public string Identity3 { get; set; }

        public int? FSize4 { get; set; }
    }
}
