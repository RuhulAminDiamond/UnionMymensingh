using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ViewModel
{
   public class SelectedTestItemsForPatient
    {
        public int Id { get; set; }
        public long TestCostId { get; set; }
        public string ShortBillNo { get; set; }
        public int TestCode { get; set; }
        public int Qty { get; set; }
        public int ReportTypeId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Cost { get; set; }
        public int VTId { get; set; }  // Vacu Type Id
        public string BarcodeLabel { get; set; }
        public int CategoryId { get; set; }

        public string discountInPercent { get; set; }  //Individual test
        public string discount { get; set; } //Individual Test
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }

        public string DiscountPlanGroup { get; set; }

        public string TestDeliveryDate { get; set; }
        public string TestDeliveryTime { get; set; }
        public int ReportOrder { get; set; }
        public string AdditionType { get; set; }   // New test or Old Test
        public string ReportStatus { get; set; }
        public string SampleReceivedBy { get; set; }  //In Lab sample received by
        public DateTime SampleReceivedDate { get; set; }
        public string SampleReceivedTime { get; set; }
        public int DisplayOrder { get; set; }
        public int? CollectionTypeId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public bool IsCancelApprove { get; set; }
    }
}
