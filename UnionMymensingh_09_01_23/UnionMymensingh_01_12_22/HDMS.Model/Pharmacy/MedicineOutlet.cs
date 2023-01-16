﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Pharmacy
{
    public class MedicineOutlet
    {
        [Key]
        public int OutLetId { get; set; }

        public string CodeNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
