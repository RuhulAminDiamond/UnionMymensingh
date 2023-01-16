﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HDMS.Model.Common
{
    public class SuplierInfo
    {
        [Key]
        public int SupId { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string CpMobileNo { get; set; }
        public string CpEmail { get; set; }
        public string Category { get; set; }
        public string CpStatus { get; set; }
        public int ManufacturerId { get; set; }  // For product sorting by Manufacturer, Specially pharmacy Item.
        public virtual IList<SupplierLedger> SupplierLedger { get; set; }
    }
}
