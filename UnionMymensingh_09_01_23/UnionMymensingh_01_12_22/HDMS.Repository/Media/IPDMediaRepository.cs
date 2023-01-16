using HDMS.Common.Utils;
using HDMS.Model.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Media
{
    public static class IPDMediaRepository
    {
        public static VMIPDPaymentInfo GetPatientByBillNo(long billNo)
        {
            using(DBEntities entities = new DBEntities())
            {
                try
                {
                    string sql = string.Format($"EXEC spGetIPDPatientInfo {billNo}");
                    var result = entities.Database.SqlQuery<VMIPDPaymentInfo>(sql).FirstOrDefault();
                    return result;
                }
                catch(Exception ex)
                {
                    return new VMIPDPaymentInfo();
                }
            }
        }

        public static DataSet getMediaStatementDataset(DateTime from, DateTime to, int mediaId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    string sql = string.Format($"exec spGetIPDMediaCommissionStatement '{from}', '{to}', {mediaId}");
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "dtMediaCommissionStatement");
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool PayIPDMedia(long billNo, double payable)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var patient = entities.HospitalPatientInfoes.Where(x=> x.BillNo == billNo).FirstOrDefault();

                    if (patient != null)
                    {
                        patient.IsMediaPaid = true;
                        patient.MediaCommission = payable;

                        entities.Entry(patient).State = EntityState.Modified;
                        entities.SaveChanges();

                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
