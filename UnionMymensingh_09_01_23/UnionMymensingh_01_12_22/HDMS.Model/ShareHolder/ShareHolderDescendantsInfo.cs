using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.ShareHolder
{
    public class ShareHolderDescendantsInfo
    {
        [Key]
        public int DependantId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Relation { get; set; }
        public string NID { get; set; }

        public byte[] Img { get; set; }
        [ForeignKey("ShareHolderBasicData")]
        public int ShId { get; set; }
        [ForeignKey("ShareHolderRelation")]
        public int RelationId { get; set; }
        public ShareHolderBasicData ShareHolderBasicData { get; set; }
        public ShareHolderRelation ShareHolderRelation { get; set; }


    }
}
