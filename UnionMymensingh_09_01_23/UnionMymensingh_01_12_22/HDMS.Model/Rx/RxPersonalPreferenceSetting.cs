using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Model.Rx
{
    public class RxPersonalPreferenceSetting
    {
        public int Id { get; set; }
        public int CpId { get; set; }
        public bool IsDefaultDoseInEnglish { get; set; }
        public bool IsDefaultDoseInShortForm { get; set; }
        public bool IsDefaultAdviceInEnglish { get; set; }
        public bool IsDefaultDoseFromPersonalDb { get; set; }
        public bool IsMedicineInterXEnable { get; set; }
    }
}
