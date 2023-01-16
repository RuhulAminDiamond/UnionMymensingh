using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.OPD
{
    public class OPDReportRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;

        public DataSet GetServiceList(long patientId, string _serviceType)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                if (_serviceType == "Consultant")
                {
                    sql = string.Format(@"SELECT  dbo.OPDPatientRecords.PatientId, dbo.OPDServiceCosts.Id,  dbo.OPDServiceCosts.ServiceOrConsultantId,OPDServiceCosts.GroupId, 
                                      dbo.Doctor.DoctorId, dbo.Doctor.Name as ServiceHeadName,dbo.OPDServiceCosts.Rate,dbo.OPDServiceCosts.Qty,OPDServiceCosts.TAmount,
                                      dbo.[User].LoginName as UserName, dbo.OPDServiceCosts.Status AS ServiceStatus
                                       FROM  dbo.OPDPatientRecords join  dbo.OPDServiceCosts on  
                                       dbo.OPDPatientRecords.PatientId= dbo.OPDServiceCosts.PatientId
								       join dbo.Doctor on
                                       dbo.Doctor.DoctorId = dbo.OPDServiceCosts.ServiceOrConsultantId 
								          INNER JOIN
                                      dbo.[User] ON dbo.OPDPatientRecords.UserId = dbo.[User].UserId
                                      WHERE  (dbo.OPDServiceCosts.PatientId = {0}  and dbo.OPDServiceCosts.Status<>'Cancelled')", patientId);

                }
                else
                {
                    sql = string.Format(@"SELECT  dbo.OPDPatientRecords.PatientId, dbo.OPDServiceCosts.Id,  dbo.OPDServiceCosts.ServiceOrConsultantId, OPDServiceCosts.GroupId,
                                        dbo.OPDServiceHeads.ServiceCode, dbo.OPDServiceHeads.ServiceHeadName,dbo.OPDServiceCosts.Rate,dbo.OPDServiceCosts.Qty,OPDServiceCosts.TAmount,
                                        dbo.[User].LoginName as UserName, dbo.OPDServiceCosts.Status AS ServiceStatus
                                        FROM  dbo.OPDPatientRecords join  dbo.OPDServiceCosts on  
                                         dbo.OPDPatientRecords.PatientId= dbo.OPDServiceCosts.PatientId
								        join dbo.OPDServiceHeads on
                                        dbo.OPDServiceHeads.ServiceHeadId = dbo.OPDServiceCosts.ServiceOrConsultantId 
								         INNER JOIN
                                        dbo.[User] ON dbo.OPDPatientRecords.UserId = dbo.[User].UserId
                                        WHERE  (dbo.OPDServiceCosts.PatientId = {0}  and dbo.OPDServiceCosts.Status<>'Cancelled')", patientId);

                }

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtCashMemo");
                return dsReports;
            }
        }
    }
}
