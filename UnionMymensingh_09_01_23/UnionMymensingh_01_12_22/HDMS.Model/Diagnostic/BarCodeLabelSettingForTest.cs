using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class BarCodeLabelSettingForTest
    {
        [Key]
        public int SettingId { get; set; }
        public int TestId { get; set; }
        public string BarcodeLabel { get; set; }
        public int CategoryId { get; set; }   //RBS CategoryId 1, CUS CategoryId 2
    }
}
