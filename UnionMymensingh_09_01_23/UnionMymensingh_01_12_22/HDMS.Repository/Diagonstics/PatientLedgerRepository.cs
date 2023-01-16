using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Diagnostic.VM;
using HDMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Diagonstics
{
    public class PatientLedgerRepository
    {
        string sql = string.Empty;
        public bool SavePatientLedger(List<PatientLedger> pLedger)
        {
            using (DBEntities entity = new DBEntities())
            {
                try
                {
                    pLedger.ForEach(x => entity.PatientLedgers.Add(x));
                    entity.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public List<PatientLedger> GetLedgerByPatientId(long pId)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.PatientLedgers.Where(x => x.PatientId == pId).ToList();
            }
        }

        public PatientLedger GetInitialTestCost(long _PatientId)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.PatientLedgers.Where(x => x.PatientId == _PatientId && x.TransactionType == TransactionTypeEnum.TestCost.ToString()).FirstOrDefault();
            }
        }

        public double GetPaidTk(long _PatientId)
        {
            double _PaidTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as tPaid from PatientLedger Where PatientId={0} and TransactionType in('OnEntryPayment','DueCollection','Refund','DueCollectionByCardOrMob','CardOrMobilePaid')", _PatientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _PaidTk = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _PaidTk;
            }
        }

        public double GetMediaCommissionOnDiscount(long patientId)
        {
            double _mediaCommission = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"select  sum(pledger.Credit) as Discount
from 
	Patients as p
	inner Join PatientLedger as pledger ON pledger.PatientId = p.PatientId 

	where pledger.TransactionType in( 'DiscountOnRegularCollection','DiscountOnDueCollection') and pledger.PatientId= {0}

", patientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _mediaCommission = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _mediaCommission;
            }
        }

        public string GetPatientNameByPatientId(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    var result = from p in entities.Patients join r in entities.RegRecords on p.RegNo equals r.RegNo where p.PatientId == patientId select r.FullName;

                    string pname = result.FirstOrDefault();
                    return pname;

                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public VMMediaAndPatientName GetMeidaAndPatientName(long patientId)
        {


            var _patientId = new SqlParameter("@PatientId", patientId);

            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<VMMediaAndPatientName>(@"
                    select r.FullName as PatientName, bus.Name as MediaName from Patients as p  
                    inner join RegRecords as r on p.RegNo = r.RegNo
                    inner join BusinessMedias as bus on bus.MediaId = p.MediaId
                    where PatientId = {0}
                    ", patientId).FirstOrDefault();
             }





        }

        public double GetMediaCommissionOnTest(long patientId)
        {
            double _mediaCommission = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"select  sum(tis.MediaComm) as MediaComm

from 
	Patients as p

	inner Join TestsCost as tcs  ON p.PatientId = tcs.PatientId
	inner join TestItems as tis  ON tcs.TestId = tis.TestId
	where p.PatientId = {0}", patientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _mediaCommission = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _mediaCommission;
            }
        }

        public double GetInvoiceTotal(long _PatientId)
        {
            using (DBEntities entites = new DBEntities())
            {
                var _ledger = entites.PatientLedgers.Where(x => x.PatientId == _PatientId && x.TransactionType == TransactionTypeEnum.TestCost.ToString()).FirstOrDefault();
                if (_ledger == null) return 0;
                return Math.Round(_ledger.Debit, 2);
            }
        }

        public double GetRefundable(long _PatientId)
        {
            using (DBEntities entites = new DBEntities())
            {
                var _ledger = entites.PatientLedgers.Where(x => x.PatientId == _PatientId && x.TransactionType == TransactionTypeEnum.Refund.ToString()).FirstOrDefault();
                if (_ledger == null) return 0;
                return Math.Round(_ledger.Debit, 2);
            }
        }

        public double GetDiscountTk(long _PatientId)
        {
            double _DiscountTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as tDiscount from PatientLedger Where PatientId={0} and TransactionType in('DiscountOnRegularCollection','DiscountOnDueCollection')", _PatientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _DiscountTk = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _DiscountTk;
            }
        }


        public double GetCancelledAmount(long _PatientId)
        {
            double _CancelledTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit) as tCancelled from PatientLedger Where PatientId={0} and TransactionType='TestCancelled'", _PatientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _CancelledTk = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _CancelledTk;
            }
        }

        public double GetPatientLedgerBalance(long _PatientId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Debit-Credit) as Balance from PatientLedger Where PatientId={0}", _PatientId);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    _balance = Convert.ToDouble(com.ExecuteScalar());
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }

                return _balance;
            }
        }

        public void CreateDailyStatement(int RegNo)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"EXEC [spCreateDailyStatement] {0}", RegNo);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
