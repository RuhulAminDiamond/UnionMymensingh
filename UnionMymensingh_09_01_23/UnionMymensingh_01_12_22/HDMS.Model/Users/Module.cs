﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Users
{
    [Table("Module")]
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string frmName { get; set; }
        public string DisplayType { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public int IsActive { get; set; }  // 1=Active
    }
}
