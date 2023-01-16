using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareHolderBasicData
    {
        [Key]
        public int ShId { get; set; }
        public string ShName { get; set; }
        public string ShFName { get; set; }
        public string ShMName { get; set; }
        public string ShSpouseName { get; set; }
        public string ShPresentAddress { get; set; }
        public string ShPermanentAddress { get; set; }
        public string ShMobile { get; set; }
        public string ShPhone { get; set; }
        public string ShEmail { get; set; }
        public DateTime ShDOB { get; set; }
        public string ShNationality { get; set; }
        public string ShNationalId { get; set; }
        public string ShPassportNo { get; set; }
        public string ShDrivingLicenseNo { get; set; }
        public string ShStartingFiscalYear { get; set; }
        public string NmName { get; set; }
        public string NmFName { get; set; }
        public string NmMName { get; set; }
        public string NmAddress { get; set; }
        public string NmContactNo { get; set; }
        public string NmRelation { get; set; }
        public string ShNoofSons { get; set; }
        public string ShNoofDaughter { get; set; }
        public byte[] ShareHolderImg { get; set; }
        public byte[] NomineeImg { get; set; }
        public string NomineeNID { get; set; }
        public bool isActive { get; set; }
    }
}
