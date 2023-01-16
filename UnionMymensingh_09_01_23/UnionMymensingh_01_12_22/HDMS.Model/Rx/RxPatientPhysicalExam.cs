using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxPatientPhysicalExam
    {
        [Key]
        public long RPEId { get; set; }
        [ForeignKey("RxPatientInfo")]
        public long RxId { get; set; }
        public string Appearance { get; set; }
        public string Nutrition { get; set; }
        public string Decubitus { get; set; }
        public string Cooperation { get; set; }
        public string Anaemia { get; set; }
        public string Jaundice { get; set; }
        public string Cyanosis { get; set; }
        public string Clubbing { get; set; }
        public string Koilonychia { get; set; }
        public string Leukonychia { get; set; }
        public string Oedema { get; set; }
        public string Dehydration { get; set; }
        public string Bonytenderness { get; set; }
        public string Pigmentation { get; set; }
        public string Lymphnodes { get; set; }
        public string Thyroidgland { get; set; }
        public string Breasts { get; set; }
        public string Bodyhair { get; set; }
        public string Pulse { get; set; }
        public string BPCystol { get; set; }
        public string BPDiastol { get; set; }
        public string Weight { get; set; }
        public string WeightUnit { get; set; }
        public string Temperature { get; set; }
        public string Respirtaion { get; set; }
        public string Neck { get; set; }
        public string Axilla { get; set; }
        public string Head { get; set; }

        public string Rash { get; set; }
        public string Scarmark { get; set; }
        public string Scratchmark { get; set; }

       
    }
}
