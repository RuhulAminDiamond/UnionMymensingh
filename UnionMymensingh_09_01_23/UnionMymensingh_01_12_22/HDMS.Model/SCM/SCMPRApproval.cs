using HDMS.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
    public class SCMPRApproval
    {
        public int Id { get; set; }
        public string ApprovLevel { get; set; }
        [ForeignKey("User")]
        public int ApprovebyUserId { get; set; }  // UserId from User Tabel
        public string LevelTagKey { get; set; }
        public bool IsThisTheHighestLevelApproval { get; set; }
        public User User { get; set; }
    }
}
