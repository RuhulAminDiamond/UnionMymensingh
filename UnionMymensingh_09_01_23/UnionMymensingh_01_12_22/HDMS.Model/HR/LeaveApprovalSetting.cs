using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class LeaveApprovalSetting
    {
        public int Id { get; set; }
        public string ApprovalLevel_1 { get; set; }
        public string ApprovalLevel_2 { get; set; }
        public string ApprovalLevel_3 { get; set; }
    }
}
