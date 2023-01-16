using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Diagonstics
{
    public class WordReportService
    {

        public int GetConsultantId(string[] Ids)
        {
            return new WordReportRepository().GetConsultantId(Ids);
        }
    }
}
