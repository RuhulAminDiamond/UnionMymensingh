using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Users
{
    public class VMUserDetail
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public int FloorId { get; set; }
        public int ChamberPractitionerId { get; set; }
        public int AssignedOutLet { get; set; }
        public int MedicineRequisitionForwardToOutlet { get; set; }
        public string FloorName { get; set; }
        public string OutletName { get; set; }
    }
}
