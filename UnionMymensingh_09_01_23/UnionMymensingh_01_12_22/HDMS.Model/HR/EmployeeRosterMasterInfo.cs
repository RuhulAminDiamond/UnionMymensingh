using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.HR
{
    public class EmployeeRosterMasterInfo
    {
        [Key]
        public long RosterMasterId { get; set; }
        public DateTime RosterStartDate { get; set; }
        public DateTime RosterEndDate { get; set; }
        public string Remarks { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }
    }
}
