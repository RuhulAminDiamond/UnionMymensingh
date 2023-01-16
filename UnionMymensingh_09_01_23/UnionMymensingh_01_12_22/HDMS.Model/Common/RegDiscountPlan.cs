using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Common
{
    public class RegDiscountPlan
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DesignationId { get; set; }    // Reg Designation
        public double LabDiscount { get; set; }
        public double NonLabDiscount { get; set; }
        public double IPDBedDiscount { get; set; }
        public double IPDServiceChargeDiscount { get; set; }
        public double ICU_CCU_Discount { get; set; }
        public double VentilationDiscount { get; set; }
        public double OxygenDiscount { get; set; }
        public double PharmacyDiscount { get; set; }
        public double OPDDiscount { get; set; }
        public double OthersDiscount { get; set; }
    }
}
