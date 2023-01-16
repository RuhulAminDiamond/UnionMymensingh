using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Common
{
    public class WordReportRepository
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        public int GetConsultantId(string[] Ids)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLabDbConnectionString();
                con.Open();
                string sql = string.Format("select ConsultantId from dbo.Reports where RegNo='{0}' and TestId='{1}'", Ids[0], Ids[1]);
                cmd = new SqlCommand(sql, con);
                return Convert.ToInt32(cmd.ExecuteScalar());
               
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
