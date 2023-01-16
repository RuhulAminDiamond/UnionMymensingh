using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM.VWModel
{
    public class VMApprovalLevel
    {
        public int Id { get; set; }
        public string ApprovLevel { get; set; }
        public int ApprovebyUserId { get; set; }  // UserId from User Tabel
        public string LevelTagKey { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
