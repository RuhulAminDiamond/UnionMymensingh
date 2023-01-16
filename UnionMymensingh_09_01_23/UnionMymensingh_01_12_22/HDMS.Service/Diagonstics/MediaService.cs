using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Diagnostic.VM;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Diagonstics
{
  public  class MediaService
    {
        public List<BusinessMedia> GetMediaNameByPatientEntry(DateTime dtpFrom, DateTime dtpTo)
        {
            return new MediaRepository().GetMediaNameByPatientEntry(dtpFrom, dtpTo);
        }

        public List<VMPatientWiseMediaPayment> GetPatientWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {
            return new MediaRepository().GetPatientWiseMediaPayments(dtFrom, dtTo, mediaId);
        }

        public List<VMTestWiseMediaPayment> GetTestWiseMediaPayments(DateTime dtFrom, DateTime dtTo, int mediaId)
        {

            return new MediaRepository().GetTestWiseMediaPayments(dtFrom, dtTo, mediaId);
        }

        public DataSet GetUserWiseMediayPayment(int id, DateTime dtfrom, DateTime dtTo)
        {
            return new MediaRepository().GetUserWiseMediayPayment( id,  dtfrom,  dtTo);
        }

        public MediaLedger GetPatientIdByMedia(long patientId)
        {
            return new MediaRepository().GetPatientIdByMedia(patientId);
        }

        public static DataSet getMediaPaymentReceiptByPatientId(Patient patientId)
        {
            return MediaRepository.getMediaPaymentReceiptByPatientId(patientId);
        }
    }
}
