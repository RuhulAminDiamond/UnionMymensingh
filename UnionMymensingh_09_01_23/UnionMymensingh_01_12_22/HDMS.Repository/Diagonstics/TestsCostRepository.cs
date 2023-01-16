using HDMS.Common.Utils;
using HDMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Diagonstics
{
    public class TestsCostRepository
    {
        string sql = string.Empty;
        SqlCommand cmd;


        public bool SaveTestsCost(List<TestsCost> testsCost)
        {
            using (DBEntities entity = new DBEntities())
            {
                try { 
                    testsCost.ForEach(n => entity.TestsCosts.Add(n));
                    entity.SaveChanges();
                    return true;
                }catch(Exception ex){
                    return false;
                }
            }
        }

        public TestsCost GetTestCostByTestId(long _testCostId)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.TestsCosts.Where(x=>x.Id== _testCostId).FirstOrDefault();
            }
        }

        public void UpdateReportStatus(List<TestsCost> _testCostList)
        {
            using (SqlConnection  conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    conn.Open();
                    foreach (var item in _testCostList)
                    {
                        sql = string.Format(@"Update TestsCost Set ReportStatus='{0}', ReportDeliveredBy = '{1}' Where Id={2}", item.ReportStatus,item.ReportDeliveredBy,item.Id);
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                   
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public TestsCost GetTestCostByPatientAndTestId(long patientId, int testId)
        {
            using (DBEntities entities= new DBEntities())
            {
                return entities.TestsCosts.Where(x => x.PatientId == patientId && x.TestId == testId).FirstOrDefault();
            }
        }

        public bool UpdateReportStatusByTest(TestsCost _tc)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(_tc).State=EntityState.Modified;
               entities.SaveChanges();

                return true;
            }
        }
    }
}
