using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Hospital
{
    public class DischargeCertificateDetail
    {
        [Key]
        public long DischargeDetailId { get; set; }
        [ForeignKey("DischargeCertificateMaster")]
        public long DischargeId { get; set; }

        public string DescriptionTitle { get; set; }
        public int DisplayOrder { get; set; }
        public string DescriptionLabel { get; set; }
        public int IsLabelBold { get; set; }
        public string Description { get; set; }

        public DischargeCertificateMaster DischargeCertificateMaster { get; set; }
    }
}
