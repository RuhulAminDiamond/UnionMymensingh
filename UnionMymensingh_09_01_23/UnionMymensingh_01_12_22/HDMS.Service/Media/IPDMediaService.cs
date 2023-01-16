using HDMS.Model.Media;
using HDMS.Repository.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Media
{
    public static class IPDMediaService
    {
        public static VMIPDPaymentInfo GetPatientByBillNo(long billNo)
        {
            return IPDMediaRepository.GetPatientByBillNo(billNo);
        }

        public static bool PayIPDMedia(long billNo, double payable)
        {
            return IPDMediaRepository.PayIPDMedia(billNo, payable);
        }

        public static DataSet getMediaStatementDataset(DateTime from, DateTime to, int mediaId)
        {
            return IPDMediaRepository.getMediaStatementDataset(from, to, mediaId);
        }
    }
}
