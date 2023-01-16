using HDMS.Model.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Store
{
    public class StoreGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        [ForeignKey("StoreMasterGroup")]
        public int StoreMasterGroupId { get; set; }

        public StoreMasterGroup StoreMasterGroup { get; set; }
    }
}
