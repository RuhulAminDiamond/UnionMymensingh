using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Model.OPD;
using HDMS.Model.OPD.VM;
using System.Data;

namespace HDMS.Repository.OPD
{
    public class OPDFinancialRepository
    {
        string sql = string.Empty;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection con;
        public double GetBalanceByPatient(long _pId)
        {
           
            using (SqlConnection con = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Credit-Debit) as Balance from OPDPatientLedgers Where PatientId={0}", _pId);
                    cmd = new SqlCommand(sql, con);
                    con.Open();

                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
                catch
                {
                    return 0;
                }
            }
        
        }

        public long SaveOPDFinalBill(HpOPDBill _hbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpOPDBills.Add(_hbill);
                entities.SaveChanges();

                return _hbill.OPDBillId;


            }
        }

        public bool SaveOPDFinalBillDetail(List<HpOPDBillDetail> _hbilldetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpOPDBillDetails.AddRange(_hbilldetailList);
                entities.SaveChanges();
                return true;
            }
        }

        public DataSet GetOPDCashMemo(long _hbillId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spGetOPDFinalBill] {0}", _hbillId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtHBill"; //based on datatable name in .xsd
               // dsReports.Tables[1].TableName = "dtAdvance";

                return dsReports;

            }
        }

        public Task<List<VMOPDProcudureBill>> GetOPdPatientProcedurBill()
        {
            return Task.Run(() =>
            {
                try
                {
                    sql = string.Format("exec spGetOPDProcudireBill");  // Current OPD Active Patient List
                    con = new SqlConnection();
                    con.ConnectionString = Utility.GetLegacyDbConnectionString();
                    con.Open();
                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMOPDProcudureBill> listhp = new List<VMOPDProcudureBill>();

                    listhp = new List<VMOPDProcudureBill>(
                      (from dRow in dt.AsEnumerable()
                       select (GetPatientSrlDataTableRow(dRow)))
                      );

                    return listhp;
                }
                catch (Exception ex)
                {
                    return new List<VMOPDProcudureBill>();
                }
            });
        }

        private VMOPDProcudureBill GetPatientSrlDataTableRow(DataRow dr)
        {
            VMOPDProcudureBill obj = new VMOPDProcudureBill();
            obj.BillNo = Convert.ToInt64(dr["BillNo"]);
            obj.FullName = dr["FullName"].ToString();
            obj.TotalBill = Convert.ToDouble(dr["TotalBill"]);
            obj.TotalPaid = Convert.ToDouble(dr["PaidAmount"]);
            obj.TotalDue = Convert.ToDouble(dr["Due"]);
            obj.ProcedureBillId = Convert.ToInt32(dr["ProcedureBillId"]);
            obj.DischargeDate = Convert.ToDateTime(dr["DischargeDate"]);
            obj.TotalDiscount = Convert.ToDouble(dr["TotalDiscount"]);
            return obj;
        }

        public List<OPDPatientLedgerRough> GetOPDPatienLedgerRough(long patientId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDPatientLedgerRoughs.Where(x => x.PatientId == patientId).ToList();
            }
        }

        public void SaveOPDRoughLedger(List<OPDPatientLedgerRough> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDPatientLedgerRoughs.AddRange(transactionList);
                entities.SaveChanges();

            }
        }

        public List<OPDPatientLedger> GetOPDPatientLedgerFinalById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.OPDPatientLedgers.Where(x=>x.OPDBillId== _billId).ToList();
               
            }
        }

        public void SaveOPDFinalLedger(List<OPDPatientLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDPatientLedgers.AddRange(transactionList);
                entities.SaveChanges();
             
            }
        }

        public List<VMOPDFinalBill> GetOPDFinalBillItems(long patientId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spOPDFinalBill] {0}", patientId);

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMOPDFinalBill> listReportTests = new List<VMOPDFinalBill>();

                listReportTests = new List<VMOPDFinalBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBillDataTableRow(dRow)))
                    );

                return listReportTests;
            }
        }

        private VMOPDFinalBill GetBillDataTableRow(DataRow dr)
        {
            VMOPDFinalBill _pr = new VMOPDFinalBill();
            _pr.SrlNo = Convert.ToInt32(dr["DisplayOrder"]);
            _pr.ServiceName = dr["ServiceItem"].ToString();
            _pr.Qty = Convert.ToInt32(dr["Qty"]);
            _pr.Rate = Convert.ToDouble(dr["ServiceRate"]);
            _pr.Total = Convert.ToDouble(dr["TotalAmount"]);
            _pr.ServiceGroup = dr["ServiceGroup"].ToString();
            _pr.ServiceChargeInPercent = Convert.ToInt32(dr["ServiceChargeInPercent"]);

            return _pr;
        }

        public void SaveOPDLedgerTransaction(OPDPatientLedger _hpLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDPatientLedgers.Add(_hpLedger);
                entities.SaveChanges();

               
            }
        }

        public long SaveOPDServiceBill(HpOPDServiceBill _bService)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpOPDServiceBills.Add(_bService);
                entities.SaveChanges();

                return _bService.SBId;
            }
        }
    }
}
