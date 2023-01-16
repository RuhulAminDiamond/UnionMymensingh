using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx.VModel
{
    public class SelectedAdvice
    {
        public long RxVisitId { get; set; }
        public int RxCpAdvId { get; set; }
        public int CPId { get; set; }
        public string Advice { get; set; }
        
    }
}
