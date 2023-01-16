using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.OPD;

namespace HDMS.Repository.OPD
{
    public class OPDPatientLedgerRepository
    {
        string sql = string.Empty;

        public double GetPaidTk(long _PatientId)
        {
            double _PaidTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as tPaid from OPDPatientLedgers Where PatientId={0} and TransactionType in('OnEntryPayment','DueCollection','Refund')", _PatientId);
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


        public double GetDiscountTk(long _PatientId)
        {
            double _DiscountTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as tDiscount from OPDPatientLedgerRoughs Where PatientId={0} and TransactionType in('DiscountOnRegularCollection','DiscountOnDueCollection')", _PatientId);
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

        public double GetRefundable(long _PatientId)
        {
            using (DBEntities entites = new DBEntities())
            {
                var _ledger = entites.OPDPatientLedgerRoughs.Where(x => x.PatientId == _PatientId).ToList();
                double _refundable = _ledger.Sum(x => x.Credit) - _ledger.Sum(x => x.Debit);
                if (Math.Abs(_refundable) >= 1)
                    return Math.Round(_refundable, 2);

                return 0;
            }
        }

        public void SavePatientLedgerRough(List<OPDPatientLedgerRough> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDPatientLedgerRoughs.AddRange(transactionList);
                entities.SaveChanges();
            }
        }

        public void SavePatientLedger(List<OPDPatientLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDPatientLedgers.AddRange(transactionList);
                entities.SaveChanges();
            }
        }

        public List<OPDPatientLedgerRough> GetLedgerByPatientId(long patientId)
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.OPDPatientLedgerRoughs.Where(x => x.PatientId == patientId).ToList();
            }
        }

        public double GetCancelledAmount(long _PatientId)
        {
            double _CancelledTk = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit) as tCancelled from OPDPatientLedgers Where PatientId={0} and TransactionType='TestCancelled'", _PatientId);
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
                    sql = string.Format(@"Select SUM(Debit-Credit) as Balance from OPDPatientLedgers Where PatientId={0}", _PatientId);
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

    }
}
