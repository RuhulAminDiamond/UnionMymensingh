using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxPrintFormatTemplate
    {
        public int Id { get; set; }
        public byte[] Template { get; set; }
        public string PrintFormat { get; set; }
    }
}
