using HDMS.Common.Utils;

using HDMS.Model.MiniAccount;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Account
{
    public class MiniAccountRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        public bool SaveAccountHead(MiniAccountHead _accHead)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.MiniAccountHeads.Add(_accHead);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public List<MiniAccountHead> GetAccountHeadsByType(string _type)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MiniAccountHeads.Where(x => x.Type == _type).ToList();
            }
        }

        public bool SaveExpense(Expense _exp)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Expenses.Add(_exp);
                    entities.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }

            }
        }

        public MiniAccountHead GetAccountHeadObj(string _headName)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MiniAccountHeads.Where(x => x.Name == _headName).FirstOrDefault();
            }
        }

      

        public List<VMExpense> GetAllExpensesByDate(DateTime dateTime,int _businessUnitId)
        {
            sql = string.Format(@"Select * from VWIncomeExpenseList Where BusinessUnitId={0} and trandate='{1}'", _businessUnitId, dateTime);

            da = new SqlDataAdapter(sql, new SqlConnection(Configuration.ConnectionString));
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<VMExpense> _listOfExpense = new List<VMExpense>();

            _listOfExpense = new List<VMExpense>(
                (from dRow in dt.AsEnumerable()
                 select (GetReportTestDataTableRow(dRow)))
                );

            return _listOfExpense;

        }

        private VMExpense GetReportTestDataTableRow(DataRow dr)
        {
            VMExpense _expense = new VMExpense();
            _expense.Id = Convert.ToInt32(dr["Id"]);
            _expense.BusinessUnitId= Convert.ToInt32(dr["BusinessUnitId"]);
            _expense.Name = dr["Name"].ToString();
            _expense.Description = dr["Description"].ToString();
            _expense.Amount = Convert.ToDouble(dr["Amount"]);
            return _expense;

        }

        public Expense GetExpenseById(int _Id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Expenses.Where(x => x.Id == _Id).FirstOrDefault();
            }
        }

        public bool UpdateExpense(Expense _exp)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_exp).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
              
            }
        }

        public IList<MiniAccountHead> GetAllAccountHeads()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MiniAccountHeads.ToList();
            }
        }

        public MiniAccountHead GetAccountHeadByAccountId(int _accId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MiniAccountHeads.Where(x => x.Id == _accId).FirstOrDefault();
            }
        }

        public DataSet GetCashBook(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBook] '{0}' , '{1}','{2}','{3}'", dateTime1, dateTime2, _CheckPaymentState, _userName);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }

        }

        public DataSet GetCashBookDiagDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spCashBookDiagDateWise] '{0}','{1}','{2}','{3}',{4}", dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBookDateWise");
                return dsCashBook;
            }
        }

        public DataSet GetCashBookPharDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spCashBookPharDateWise] '{0}','{1}','{2}','{3}',{4}", dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBookDateWise");
                return dsCashBook;
            }
        }

        public int GetAccountHeadIdByMediaId(int mediaId)
        {
            using (DBEntities entities = new DBEntities())
            {
                MiniAccountHead miniAccountHead = entities.MiniAccountHeads.Where(x => x.Name.StartsWith(mediaId.ToString())).FirstOrDefault();
                if (miniAccountHead != null) return miniAccountHead.Id;
                else return 0;
            }
        }

        public DataSet GetCashBookHosDateWise(DateTime dtpfrm, DateTime dtpto, string checkPaymentState, string _userName, int businessUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spCashBookHosDateWise] '{0}','{1}','{2}','{3}',{4}", dtpfrm, dtpto, checkPaymentState, _userName, businessUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBookDateWise");
                return dsCashBook;
            }
        }

        public DataSet GetCashBookDiag(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookDiag] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }


        public DataSet GetCashBookPhar(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookPhar] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }

        public DataSet GetCashBookHos(DateTime dateTime1, DateTime dateTime2, string _CheckPaymentState, string _userName, int _bUnitId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [spCashBookHos] '{0}','{1}','{2}','{3}',{4}", dateTime1, dateTime2, _CheckPaymentState, _userName, _bUnitId);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsCashBook = new DataSet();
                da.Fill(dsCashBook, "dtCashBook");
                return dsCashBook;
            }
        }


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

        public DataSet GetExpenseDetailsByHead(DateTime dateTime1, DateTime dateTime2, MiniAccountHead _accHead)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"Select trandate as [Date], Description,Amount from VWExpenseDetails Where [TranDate] between '{0}' and '{1}' and AccountId={2}", dateTime1, dateTime2, _accHead.Id);

                da = new SqlDataAdapter(sql, conn);
                DataSet dsHeadwiseExpense = new DataSet();
                da.Fill(dsHeadwiseExpense, "dtHeadwiseExpense");
                return dsHeadwiseExpense;
            }

        }

    }
}
