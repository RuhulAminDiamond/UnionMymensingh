using HDMS.Model;
using HDMS.Model.Common;
using HDMS.Model.Marketing;
using HDMS.Model.Media;
using HDMS.Repository.Diagonstics;
using System;
using System.Collections.Generic;
using System.Data;

namespace HDMS.Service.Media
{
    public class MediaService
    {
        //public static List<MediaCommissionGroup> getAllMediaCommissionGroups()
        //{
        //    return MediaRepository.getAllMediaCommissionGroups();
        //}

        //public static List<VmMediaCommission> getCommissionsByMediaId(int mediaId)
        //{
        //    return MediaRepository.getCommissionsByMediaId(mediaId);
        //}

        //public static DataSet GetMarketingSummaryStatement(DateTime fromDate, DateTime toDate)
        //{
        //    return MediaRepository.GetMarketingSummaryStatement(fromDate, toDate);
        //}

        public static DataSet getMediaStatementDataset(DateTime fromDate, DateTime toDate, int mediaId, bool paid = true)
        {
            return MediaRepository.getMediaStatementDataset(fromDate, toDate, mediaId, paid);
        }

        public static DataSet getMediaPaymentReceiptByPatientId(Patient patientId)
        {
            return MediaRepository.getMediaPaymentReceiptByPatientId(patientId);
        }

        public static DataSet GetHospitalMeidaPaymentStatement(DateTime from, DateTime to, int mediaId = 0)
        {
            return MediaRepository.GetHospitalMeidaPaymentStatement(from, to, mediaId);
        }

        public static DataSet GetHospitalMeidaWaisePaymentStatement(DateTime from, DateTime to, int mediaId)
        {
            return MediaRepository.GetHospitalMeidaWaisePaymentStatement(from, to, mediaId);
        }

        //public static bool FrezMedia(BusinessMedia media)
        //{
        //    return MediaRepository.FreezMedia(media);
        //}

        //public static DataSet GetMediaStatementMOWise(DateTime dtFrom, DateTime dtTo, int mAId)
        //{
        //    return MediaRepository.GetMediaStatementMOWise(dtFrom, dtTo, mAId);
        //}

        //public static bool SaveMedia(BusinessMedia _media, List<VmMediaCommission> vmMediaCommissions)
        //{
        //    return MediaRepository.SaveMedia(_media, vmMediaCommissions);
        //}

        //public static bool UpdateMedia(BusinessMedia _media, List<VmMediaCommission> vmMediaCommissions = null)
        //{
        //    return MediaRepository.UpdateMedia(_media, vmMediaCommissions);
        //}

        //public static List<BusinessMedia> GetAllMedia(string mediaType)
        //{
        //    return MediaRepository.GetAllMedia(mediaType);
        //}

        //public static void CommissionForPatient(Patient patient)
        //{
        //    MediaRepository.SaveCommisionForPatient(patient);
        //}

        //public static List<PatientWiseMediaCommission> fetchPatientWiseMediaCommission(long patientId)
        //{
        //    return MediaRepository.fetchPatientWiseMediaCommission(patientId);
        //}

        //public static BusinessMedia GetMediaById(int mediaId)
        //{
        //    return MediaRepository.GetMediaById(mediaId);
        //}

        //public static void SetMediaCommissionPaid(long patientId)
        //{
        //    MediaRepository.SetMediaCommissionPaid(patientId);
        //}

        //public static DataSet getMediaPaymentReceiptByPatientId(int patientId)
        //{
        //    return MediaRepository.getMediaPaymentReceiptByPatientId(patientId);
        //}

        //public static bool ResetMedia(BusinessMedia media, List<VmMediaCommission> vmMediaCommissions)
        //{
        //    return MediaRepository.ResetMedia(media, vmMediaCommissions);
        //}

        //public static PaymentDetail GetPaymentDetails(long patientId)
        //{
        //    return MediaRepository.GetPaymentDetails(patientId);
        //}
    }
}
