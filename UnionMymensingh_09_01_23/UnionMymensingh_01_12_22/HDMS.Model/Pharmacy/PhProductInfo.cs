using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Models.Pharmacy
{
    public class PhProductInfo
    {
      [Key]
        public int ProductId { get; set; }
        //public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string BrandName { get; set; }
       [ForeignKey("Generic")]
        public int GenericId { get; set; }
        [ForeignKey("Formation")]
        public int FormationId { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public string Unit { get; set; }
        public string PkgUnit { get; set; }  // Packaging Style
        public int QtyPerBox { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public string Indication { get; set; }
        public string ContraIndication { get; set; }
        public string DosageAdmistration { get; set; }

        public string Preperation { get; set; }
        public string SideEffact { get; set; }

        public string DoseShortEn { get; set; }
        public string DoseShortBn { get; set; }
        public string DoseLongEn { get; set; }
        public string DoseLongBn { get; set; }

        public string BeforeAfterEn { get; set; }
        public string BeforeAfterBn { get; set; }
        public string Duration { get; set; }
        public string DurationUnit { get; set; }

        public string RxFriendlyName { get; set; }

        public int ROLIndoor { get; set; }
        public int ROLOutdoor { get; set; }

        public int DoseId { get; set; }

    

        public virtual Generic Generic { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IList<PhOrderInfo> PhOrderInfos { get; set; }
    }


    public class PhProductInfo2
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string BrandName { get; set; }
        [ForeignKey("PhSubGroup")]
        public int SubGroupId { get; set; }
        [ForeignKey("Generic")]
        public int GenericId { get; set; }
        [ForeignKey("Formation")]
        public int FormationId { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public string Unit { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public string Indication { get; set; }
        public string DosageAdmistration { get; set; }
        public string Preperation { get; set; }
        public string SideEffact { get; set; }
        public virtual PhSubGroup PhSubGroup { get; set; }
        public virtual Generic Generic { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IList<PhOrderInfo> PhOrderInfos { get; set; }
    }


    public class PhProductInfo3
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string BrandName { get; set; }
        [ForeignKey("PhSubGroup")]
        public int SubGroupId { get; set; }
        [ForeignKey("Generic")]
        public int GenericId { get; set; }
        [ForeignKey("Formation")]
        public int FormationId { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public string Unit { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public string Indication { get; set; }
        public string DosageAdmistration { get; set; }
        public string Preperation { get; set; }
        public string SideEffact { get; set; }
        public virtual PhSubGroup PhSubGroup { get; set; }
        public virtual Generic Generic { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IList<PhOrderInfo> PhOrderInfos { get; set; }
    }
}
