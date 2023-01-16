using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareHolderRelation
    {
        [Key]
        public int RelationId { get; set; }
        public string Name { get; set; }

       
    }
}
