using HDMS.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class PhProductLedger
    {
        [Key]
        public long TranId { get; set; }
        public DateTime TDate { get; set; }
        public string TTime { get; set; }
        public int OutletId { get; set; }
        [ForeignKey("PhProductInfo")]
        public int ProductId { get; set; }
        public double OpStock { get; set; }    //Per bill no opening Stock of all lot
        public string Particulars { get; set; }
        public double StockQty { get; set; }
        public double SoldQty { get; set; }
        public double TransferQty { get; set; }
        public double RetQty { get; set; }
        public double ClosingStock { get; set; }  //Per bill no closing Stock  of all lot
        public string UserName { get; set; }
        public PhProductInfo PhProductInfo { get; set; }
    }
}
