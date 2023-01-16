using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxInitialData
    {
        [Key]
        public long RxInitDId { get; set; }
        [ForeignKey("RxVisitHistory")]
        public long RxVisitId { get; set; }
        public DateTime RxInitDDate { get; set; }
        public string RxInitDTime { get; set; }
        public DateTime RxInitDUpdateDate { get; set; }
        public string RxInitDUpdateTime { get; set; }
        public string CC { get; set; }
        public string CCDuration { get; set; }
        public string CCDurationUnit{ get; set; }
        // public string Confidential { get; set; }
        public string PresentHistory { get; set; } // txtHistory Text Box
        public string PastHistory { get; set; }  // Additional Text Box
        public string TreatmentPaln { get; set; }
        public string Prescription { get; set; }
        public string WeightInKg { get; set; }
        public string Height { get; set; }
        public string HeightUnit { get; set; }
        public string BpErrectTop { get; set; }
        public string BpErrectBottom { get; set; }
        public string BpSupineTop { get; set; }
        public string BpSupineBottom { get; set; }
        public string Pulse { get; set; }
        public string PulseBehaviour1 { get; set; }
        public string PulseBehaviour2 { get; set; }
        public string OtherFindings { get; set; }
        public string DrugHistory { get; set; }
        public string BMI { get; set; }  // Body mass Index
        
        public bool IsSketchAvailable { get; set; }

        public string CommentsOrReferral { get; set; }
        public string Notes { get; set; }

        public string Diagnosis { get; set; }
        public string Dx { get; set; }
        public DateTime? FollowUpOn { get; set; }
        public string FollowUpAfter { get; set; }
        [ForeignKey("User1")]
        public int CreatedUserId { get; set; }
        [ForeignKey("User2")]
        public int ModifiedUserId { get; set; }

        public RxVisitHistory RxVisitHistory { get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }

        public string TerminalMacAddress { get; set; }
    }
}
