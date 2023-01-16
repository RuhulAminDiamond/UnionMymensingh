using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using HDMS.Repository.Common;

namespace HDMS.Service.Common
{
    public class MemberService
    {
        public bool CreateMember(MemberInfo _member)
        {
            return new MemberRepository().CreateMember(_member);
        }

        public IList<MemberInfo> GetMemberList()
        {
            return new MemberRepository().GetMemberList();
        }
    }
}
