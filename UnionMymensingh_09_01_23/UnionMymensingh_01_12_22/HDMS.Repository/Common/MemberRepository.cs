using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;

namespace HDMS.Repository.Common
{
    public class MemberRepository
    {
        public bool CreateMember(MemberInfo _member)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.MemberInfos.Add(_member);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<MemberInfo> GetMemberList()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.MemberInfos.ToList();              
            }
        }
    }
}
