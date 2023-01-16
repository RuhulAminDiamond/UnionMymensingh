using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HDMS.Model.Users
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public int ChamberPractitionerId { get; set; }

        public int AssignedOutLet { get; set; } // For Pharmacy User
        public int FloorId { get; set; }  // Working location of this employee
        public int DeptId { get; set; }
        public int MedicineRequisitionForwardToOutLet { get; set; } // Medicine Requisition will forward to this outlet for this particular user
        public bool IsIndoorSaleAllowed { get; set; }
        public string Status { get; set; }
        public int CpId { get; set; } // To track the Cp Support User
        public string Comments { get; set; }
        public ICollection<Role> Roles { get; set; }
        public long EmployeeId { get; set; }
        public string SKey { get; set; }
    }
}