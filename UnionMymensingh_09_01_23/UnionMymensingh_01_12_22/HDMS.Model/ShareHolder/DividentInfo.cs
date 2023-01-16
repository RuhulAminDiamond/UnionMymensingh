using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class DividentInfo
    {
        [Key]
        public int DId { get; set; }
        public DateTime DDate { get; set; }
        public int FiscalYear { get; set; }
        public int DividentRate { get; set; }
        public string Dividentby { get; set; }
    }
}
