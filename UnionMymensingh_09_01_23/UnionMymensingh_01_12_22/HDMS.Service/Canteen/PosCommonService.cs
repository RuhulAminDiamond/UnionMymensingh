using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Common;
using Repositories.POS;

namespace Services.POS
{
    public class PosCommonService
    {
        public List<BusinessUnit> GetbusinessUnit()
        {
            return new CommonRepository().GetbusinessUnit();
        }
    }
}
