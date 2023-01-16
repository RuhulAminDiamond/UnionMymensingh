using Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.SCM
{
    public class StoreStcokInfo
    {
        [Key]
        public long StckId { get; set; }
        [ForeignKey("StoreLotInfo")]
        public long LotNo { get; set; }
        [ForeignKey("StoreProductInfo")]
        public int ProductId { get; set; }
        
        public double CurrentStock { get; set; }

        public StoreLotInfo StoreLotInfo { get; set; }
        public StoreProductInfo StoreProductInfo { get; set; }
       // public LogisticOutlet LogisticOutlet { get; set; }


    }
}
