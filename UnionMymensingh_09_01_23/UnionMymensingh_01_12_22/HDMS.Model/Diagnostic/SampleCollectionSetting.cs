using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Diagnostic
{
    public class SampleCollectionSetting
    {
        [Key]
        public int SCSId { get; set; }
        public int MainTestId { get; set; }
        public int SerialNo { get; set; }

        public string Description { get; set; }

    }
}
