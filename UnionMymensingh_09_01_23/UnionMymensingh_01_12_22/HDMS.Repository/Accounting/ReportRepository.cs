using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HDMS.Common.Utils;

namespace Repositories.Accounting
{
    public class ReportRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        SqlConnection con;

        public DataSet GetTotalExpense(DateTime dtpfrm, DateTime dtpto, int _mode)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select Name as HeadName, Sum(Amount) as TotalAmount from VWExpenseDetails Where [TranDate] between '{0}' and '{1}' group by  Name", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsTotalExpense = new DataSet();
                da.Fill(dsTotalExpense, "dtTotalExpense");
                return dsTotalExpense;
            }
        }

        public double GetCashBookTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbooktotal", SqlDbType.Float));
                    cmd.Parameters["@cashbooktotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbooktotal"].Value != DBNull.Value)
                    {
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbooktotal"].Value);
                    }
                }
            }
            return cashbooktotal;
        }

       

        public double GetCashBookDebitTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookDebitTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbookdebittotal", SqlDbType.Float));
                    cmd.Parameters["@cashbookdebittotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbookdebittotal"].Value != DBNull.Value)
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbookdebittotal"].Value);
                }
            }
            return cashbooktotal;
        }

        public double GetCashBookCreditTotal()
        {
            double cashbooktotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("spCashBookCreditTotal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@cashbookcredittotal", SqlDbType.Float));
                    cmd.Parameters["@cashbookcredittotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@cashbookcredittotal"].Value != DBNull.Value)
                        cashbooktotal = Convert.ToDouble(cmd.Parameters["@cashbookcredittotal"].Value);
                }
            }
            return cashbooktotal;
        }


        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBook] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }
    }
}
