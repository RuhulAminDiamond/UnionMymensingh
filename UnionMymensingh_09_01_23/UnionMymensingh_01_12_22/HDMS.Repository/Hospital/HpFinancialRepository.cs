using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using HDMS.Model.Enums;
using HDMS.Model.Hospital.ViewModel;
using HDMS.Model;
using System.Data.Entity;
using HDMS.Model.Accounting.VModel;
using HDMS.Model.OPD;
using System.Threading;
using HDMS.Model.OPD.VM;

namespace HDMS.Repository.Hospital
{
    public class HpFinancialRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public double GetHospitalBill(long _admissionId)
        {
            double hospitaltotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //sql = string.Format(@"[spSummarySheet] {0}", dateTime1, dateTime2);
               
                using (SqlCommand cmd = new SqlCommand("GetHospitalBill", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdmissionId", SqlDbType.BigInt));
                    cmd.Parameters["@AdmissionId"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@AdmissionId"].Value = _admissionId;
                    cmd.Parameters.Add(new SqlParameter("@hospitaltotal", SqlDbType.Float));
                    cmd.Parameters["@hospitaltotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@hospitaltotal"].Value != DBNull.Value)
                        hospitaltotal = Convert.ToDouble(cmd.Parameters["@hospitaltotal"].Value);
                    
                }
            }
            return hospitaltotal;
        }

        public DataSet GetConsultentAndSergeonTeamCharge(DateTime dtpfrm, DateTime dtpto)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"EXEC [dbo].[Spgetconsultationteamcharge]  '{0}','{1}'", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtConsultentAndSergeonTeamCharge ");
                return ds;
            }
        }

        public HpDayWiseBill GetHpDayWisebillbyDaybillNo(long _hbillNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpDayWiseBills.Where(x => x.DayBillNo == _hbillNo).FirstOrDefault();
            }
        }

        public HpDayWiseBill GetHospitalDayWiseBillByBillNo(long _hbillNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpDayWiseBills.Where(x => x.DayBillNo == _hbillNo).FirstOrDefault();
            }
        }

        public DataSet GetHpAdmittedOPDPatientList(DateTime dtfrm, DateTime dtto)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"EXEC [dbo].[AdmittedOPDPatientList]  '{0}','{1}'", dtfrm, dtto);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }

        public DataSet GetHpAdmittedAllPatientList(DateTime dtpfrm, DateTime dtpto)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"EXEC [dbo].[AdmittedPatientList]  '{0}','{1}'", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }

        public DataSet GetHpSummaryStatement(DateTime dtpfrm, DateTime dtpto)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [dbo].[sp_GetHospitalIncomeSummary]  '{0}','{1}','0'", dtpfrm, dtpto);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }

        }

        public DataSet GetHpDailyCollection(DateTime dtpfrm, DateTime dtpto, int _deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [dbo].[sp_hpdailycollection]  '{0}','{1}','',{2}", dtpfrm, dtpto, _deptId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }

        }

        public double GetConsultantLedgerBalance(int doctorId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from HpConsultantLedgers Where DoctorId={0}", doctorId);
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

        public List<VMFloorServiceEdit> GetFloorServiceList(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.Database.SqlQuery<VMFloorServiceEdit>(@"SELECT  dbo.ServiceBillDetails.SBDId, dbo.ServiceBillDetails.ServiceDate, dbo.ServiceHeads.ServiceHeadName AS ServiceName, dbo.ServiceBillDetails.Rate, dbo.ServiceBillDetails.Qty, 
                                    dbo.ServiceBillDetails.Rate * dbo.ServiceBillDetails.Qty AS Total
                                    FROM  dbo.ServiceBillDetails INNER JOIN dbo.ServiceHeads ON dbo.ServiceBillDetails.ServiceHeadId = dbo.ServiceHeads.ServiceHeadId
                                    WHERE (dbo.ServiceBillDetails.AdmissionId = @admissionId)", new SqlParameter("admissionId", admissionId)).ToList();
            }
        }

        public DataSet GetHpDailyCollection_2(DateTime dtpfrm, DateTime dtpto, string _userName,int deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC [dbo].[sp_hpdailycollection_02]  '{0}','{1}','{2}',{3}", dtpfrm, dtpto, _userName, deptId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }


        public DataSet GetHpDailyCollection_IPD(DateTime dtpfrm, DateTime dtpto, string _userName, int deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC [dbo].[sp_hpdailycollection_IPD]  '{0}','{1}','{2}',{3}", dtpfrm, dtpto, _userName, deptId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }

        public DataSet GetHpDailyCollection_OPD(DateTime dtpfrm, DateTime dtpto, string _userName, int deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC [dbo].[sp_hpdailycollection_OPD]  '{0}','{1}','{2}',{3}", dtpfrm, dtpto, _userName, deptId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }

        public void DeleteExistingFinalBill(long hospitalBillId)
        {
            try
            {
               
                        using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                        {
                           
                                sql = string.Format("Delete from HpPatientLedgerFinals Where HospitalBillId={0}", hospitalBillId);
                                cmd = new SqlCommand(sql, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();

                                sql = string.Format("Delete from HospitalBillDetails Where HospitalBillId={0}", hospitalBillId);
                                cmd = new SqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();

                                sql = string.Format("Delete from HospitalBills Where HospitalBillId={0}", hospitalBillId);
                                cmd = new SqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();

                                conn.Close();
                            
                   
                         }

          
             }
            catch (Exception ex)
            {
            
            }

        }

        public int SaveOPDDistributedBill(OpdProcedureBillDistribution distributebill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OpdProcedureBillDistributions.Add(distributebill);
                entities.SaveChanges();
                return distributebill.DisId;
            }
        }

        public bool SaveOpdProceduredistributionBillDetail(List<OpdProcedureBillDistributionDetail> obilldetaildistributionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OpdProcedureBillDistributionDetails.AddRange(obilldetaildistributionList);
                entities.SaveChanges();
                return true;
            }
        }

        public DataSet GetHpDailyCollection_3(DateTime dtpfrm, DateTime dtpto, string userName, int deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {

                sql = string.Format(@"EXEC [dbo].[sp_hpdailycollection_cash_card_mobile]  '{0}','{1}','{2}',{3}", dtpfrm, dtpto, userName, deptId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDailyCollection");
                return ds;
            }
        }

        public void DeleteExistingCabinChargeCalculation(long admissionId)
        {

            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {

                        entities.Database.ExecuteSqlCommand("Delete from HpCabinCharges Where AdmissionId={0}", new object[] { admissionId });
                        entities.SaveChanges();
                      

                        entities.Database.ExecuteSqlCommand("Delete from HpCabinChargeSegmantDetails");
                        entities.SaveChanges();

                        //Voucher _VM = entities.Vouchers.Where(x => x.DividentId == info.DId).FirstOrDefault();
                        //if (_VM != null)
                        //{
                            entities.Database.ExecuteSqlCommand("Delete from HpCabinChargeSegmantMasters");
                            entities.SaveChanges();

                            //entities.Database.ExecuteSqlCommand("Delete from Vouchers where VMId={0}", new object[] { _VM.VMId });
                            //entities.SaveChanges();

                       // }



                        transaction.Commit();
                       

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                      
                    }
                }
            }


          
        }

        public long SaveOPDProcedureServiceBill(OPDProcedureServiceBill oPDSbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDProcedureServiceBills.Add(oPDSbill);
                entities.SaveChanges();
                return oPDSbill.SBId;
            }
        }

        public double GetHpDayWisePatientBalance(int dayWiseBillId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Debit-Credit) as cBalance from  HPDayWiseBillingLedgers Where DayWiseBillId={0}", dayWiseBillId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());

                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public bool SaveOPDServiceBillDetails(List<OPDProcedureServiceBillDetail> sbillList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.OPDProcedureServiceBillDetails.AddRange(sbillList);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public long SaveOpdProcedureBill(OpdProcedureBill pbill)
        {
               using (DBEntities entities = new DBEntities())
                {
                    entities.OpdProcedureBills.Add(pbill);
                    entities.SaveChanges();
                    return pbill.ProcedureBillId;
                }
            
        }

        public List<VMConsultancyEdit> GetOTServiceList(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.Database.SqlQuery<VMConsultancyEdit>(@"SELECT dbo.OTExecutionDetails.OTDId AS DSBDId, dbo.OTExecutionDetails.ServiceDate, dbo.OTExecutionDetails.DoctorId, dbo.Doctor.Name AS DoctorName, dbo.ServiceHeads.ServiceHeadName AS ServiceName, 
                         dbo.OTExecutionDetails.Rate, dbo.OTExecutionDetails.Qty, dbo.OTExecutionDetails.Rate * dbo.OTExecutionDetails.Qty AS Total
                         FROM dbo.ServiceHeads INNER JOIN
                         dbo.OTExecutionDetails ON dbo.ServiceHeads.ServiceHeadId = dbo.OTExecutionDetails.ServiceHeadId INNER JOIN
                         dbo.OTSchedules ON dbo.OTExecutionDetails.OTId = dbo.OTSchedules.OTId INNER JOIN
                         dbo.Doctor ON dbo.OTExecutionDetails.DoctorId = dbo.Doctor.DoctorId
                         WHERE (dbo.OTSchedules.AdmissionId = @admissionId)", new SqlParameter("admissionId", admissionId)).ToList();
            }
        }

        public void SaveHpDayWiseFinalLedger(List<HPDayWiseBillingLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HPDayWiseBillingLedgers.AddRange(transactionList);
                entities.SaveChanges();

            }
        }

        public bool SaveOpdProcedureBillDetail(List<OpdProcedureBillDetails> hbilldetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OpdProcedureBillDetails.AddRange(hbilldetailList);
                entities.SaveChanges();
                return true;
            }
        }

        public void SaveOpdProcedureLedger(List<OpdProcedurepatientLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OpdProcedurepatientLedgers.AddRange(transactionList);
                entities.SaveChanges();

            }
        }

        public void SaveCabinChargeRange(List<HpCabinCharge> _cabinChargeList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpCabinCharges.AddRange(_cabinChargeList);
                entities.SaveChanges();
            }
        }
        public List<VMConsultancyEdit> GetConsultancyProvidedList(long admissionId)
        {
            using (DBEntities entities=new DBEntities())
            {

              return   entities.Database.SqlQuery<VMConsultancyEdit>(@"SELECT dbo.DoctorServiceBillDetails.DSBDId, dbo.DoctorServiceBillDetails.ServiceDate, dbo.DoctorServiceBillDetails.DoctorId, dbo.Doctor.Name AS DoctorName, dbo.ServiceHeads.ServiceHeadName AS ServiceName, dbo.DoctorServiceBillDetails.Rate, dbo.DoctorServiceBillDetails.Qty,
                                               dbo.DoctorServiceBillDetails.Rate*dbo.DoctorServiceBillDetails.Qty as Total FROM dbo.DoctorServiceBillDetails INNER JOIN
                                               dbo.Doctor ON dbo.DoctorServiceBillDetails.DoctorId = dbo.Doctor.DoctorId INNER JOIN
                                               dbo.ServiceHeads ON dbo.DoctorServiceBillDetails.ServiceHeadId = dbo.ServiceHeads.ServiceHeadId
                                               WHERE (dbo.DoctorServiceBillDetails.AdmissionId = @admissionId)", new SqlParameter("admissionId", admissionId)).ToList();
            }
        }

        public List<HpConsultantLedger> GetConsultantLedger(DateTime _datefrm, DateTime _dateto,int doctorId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Database.SqlQuery<HpConsultantLedger>(@"EXEC SP_GET_HpConsultantLedgers_Balance @datefrm, @dateto,  @doctorId", new SqlParameter("datefrm", _datefrm), new SqlParameter("dateto", _dateto),new SqlParameter("doctorId", doctorId)).ToList();
            }
        }

        public List<VMHpFinalBill> GetHpCabinBillItems(long admissionId,bool isAdmissionFeeApplicable)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spHpCabinCharges] {0},'{1}'", admissionId, isAdmissionFeeApplicable);

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMHpFinalBill> listReportTests = new List<VMHpFinalBill>();

                listReportTests = new List<VMHpFinalBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBillDataTableRow(dRow)))
                    );

                return listReportTests;
            }
        }

        public void UpdateHospitalBill(HospitalBill hbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(hbill).State = EntityState.Modified;
                    entities.SaveChanges();


                }
                catch (Exception ex)
                {

                }
            }
        }

        public int SaveDayWiseBillBill(HpDayWiseBill dayWisebill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpDayWiseBills.Add(dayWisebill);
                entities.SaveChanges();
               return dayWisebill.DayWiseBillId;
            }
        }

        public void SaveDayWiseBillingLedger(List<HPDayWiseBillingLedger> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HPDayWiseBillingLedgers.AddRange(transactionList);
                entities.SaveChanges();

            }
        }

        public List<VMHpFinalBill> GetHpDayWiseBillItems(long _admissionId, string _startDateTime, string _endDateTime, bool IsAdmissionFeeApplicable)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"EXEC [spHpDayWiseFinalBill] {0},'{1}', '{2}','{3}'", _admissionId, _startDateTime, _endDateTime, IsAdmissionFeeApplicable);

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMHpFinalBill> listReportTests = new List<VMHpFinalBill>();

                listReportTests = new List<VMHpFinalBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBillDataTableRow(dRow)))
                    );

                return listReportTests;
            }
        }

        public async Task<VMHospitalDayWiseBillCarrier2> SaveAndGetDayWiseBill(VMHospitalDayWiseBillCarrier carrierDataObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {

                        entities.HpDayWiseBills.Add(carrierDataObj.hdaybill);
                        entities.SaveChanges();

                        List<HpDayWiseBillDetail> billdetails = new List<HpDayWiseBillDetail>();
                        foreach (var item in carrierDataObj.hdaybilldetails)
                        {
                            item.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;

                            billdetails.Add(item);
                        }

                        entities.HpDayWiseBillDetails.AddRange(billdetails);
                        entities.SaveChanges();


                        double balance = 0;
                        balance = 0 - carrierDataObj.SaleAmount;
                        List<HPDayWiseBillingLedger> transactionList = new List<HPDayWiseBillingLedger>();

                        HPDayWiseBillingLedger pLedger = new HPDayWiseBillingLedger();
                        pLedger.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;
                        pLedger.TDate = carrierDataObj.TDate;
                        pLedger.TransactionTime = carrierDataObj.TransactionTime;
                        pLedger.Particulars = "Total Bill";
                        pLedger.Debit = carrierDataObj.SaleAmount;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                       // pLedger.OperateBy = carrierDataObj.PreparedBy;
                        transactionList.Add(pLedger);


                        balance = balance - carrierDataObj.ServiceCharge;
                        pLedger = new HPDayWiseBillingLedger();
                        pLedger.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;
                        pLedger.TDate = carrierDataObj.TDate;
                        pLedger.TransactionTime = carrierDataObj.TransactionTime;
                        pLedger.Particulars = "Service Charge";
                        pLedger.Debit = carrierDataObj.ServiceCharge;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.HpServiceCharge.ToString();
                       // pLedger.OperateBy = carrierDataObj.PreparedBy;

                        transactionList.Add(pLedger);

                        if (carrierDataObj.CashPaidAmount > 0)
                        {


                            balance = balance + carrierDataObj.CashPaidAmount;
                            pLedger = new HPDayWiseBillingLedger();
                            pLedger.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;
                            pLedger.TDate = carrierDataObj.TDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (Cash)";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.CashPaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.HpPaidAmount.ToString();
                           // pLedger.OperateBy = carrierDataObj.PreparedBy;
                            transactionList.Add(pLedger);

                        }

                        if (carrierDataObj.MobilePayment > 0)
                        {
                            balance = balance + carrierDataObj.MobilePayment;
                            pLedger = new HPDayWiseBillingLedger();
                            pLedger.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;
                            pLedger.TDate = carrierDataObj.TDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (Mobile Banking)";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.MobilePayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyMobileBanking.ToString();
                           // pLedger.OperateBy = carrierDataObj.PreparedBy;
                            transactionList.Add(pLedger);
                        }


                        if (carrierDataObj.CardPayment > 0)
                        {
                            balance = balance + carrierDataObj.CardPayment;
                            pLedger = new HPDayWiseBillingLedger();
                            pLedger.DayWiseBillId = carrierDataObj.hdaybill.DayWiseBillId;
                            pLedger.TDate = carrierDataObj.TDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (By Card))";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.CardPayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                           // pLedger.OperateBy = carrierDataObj.PreparedBy;
                            
                            transactionList.Add(pLedger);
                        }


                        entities.HPDayWiseBillingLedgers.AddRange(transactionList);
                        entities.SaveChanges();

                        VMHospitalDayWiseBillCarrier2 _retObj = new VMHospitalDayWiseBillCarrier2();

                        _retObj.SaveHpdayWIseBill = carrierDataObj.hdaybill;
                       

                        transaction.Commit();

                        return await Task.FromResult(_retObj);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return await Task.FromResult(new VMHospitalDayWiseBillCarrier2() { SaveHpdayWIseBill = new HpDayWiseBill() { DayWiseBillId = 0 } });
                    }



                }
            }
        }

        public bool SaveHPDayWiseBillDetails(List<HpDayWiseBillDetail> dayWiseBillDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpDayWiseBillDetails.AddRange(dayWiseBillDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public DataSet GetDayWiseBillCashMemo(long _billId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spGetDayWiseBillingMemo] {0}", _billId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtHBill"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtAdvance";

                return dsReports;

            }
        }

        public List<HPDayWiseBillingLedger> GetDayWiseBillingLedgerById(long billId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HPDayWiseBillingLedgers.Where(x => x.DayWiseBillId == billId).ToList();

            }
        }

        public DataSet GetDischargedPatient(DateTime dtpfrm, DateTime dtpto, int _deptId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spGetDischargedPatientStatement] '{0}','{1}',{2}", dtpfrm, dtpto, _deptId);



                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHpDischargedBillStatement");
                return ds;
            }

        }

        public void DeleteFloorService(ServiceBillDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State=EntityState.Deleted;
                entities.SaveChanges();
               
            }
        }

        public bool SaveFloorServiceDeleteLog(FloorServiceDeleteLog _dLog)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.FloorServiceDeleteLogs.Add(_dLog);
                entities.SaveChanges();
                return true;
            }
        }

        public ServiceBillDetail GetFloorServiceById(long sBDId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceBillDetails.Where(x => x.SBDId == sBDId).FirstOrDefault();
            }
        }

        public HospitalBill GetHospitalBillByBillNo(long _hbillNo)
        {
            try
            {
                using (DBEntities entities = new DBEntities())
                {
                    return entities.HospitalBills.Where(x => x.BillNo == _hbillNo).FirstOrDefault();
                }
            }catch(Exception ex)
            {
                // something doing
                DBEntities entities = new DBEntities();
                return entities.HospitalBills.Where(x => x.BillNo == _hbillNo).FirstOrDefault();
            }
        }

        public OTExecutionDetail GetOTConsultancyServiceById(long dSBDId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OTExecutionDetails.Where(x => x.OTDId == dSBDId).FirstOrDefault();
            }
        }

        public long SaveHpServiceBill(HpServiceBill _bService)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpServiceBills.Add(_bService);
                entities.SaveChanges();
                return _bService.SBId;
            }
        }

        public DataSet GetInPatientCareServiceByPatientId(long admissionId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spAdmission_Fee] {0}", admissionId);



                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtAdmissionfee");
                return ds;
            }
        }

        public void SaveOPDAdvancePayment(OPDAdvancePayment advancePayment)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.OPDAdvancePayments.Add(advancePayment);
                entities.SaveChanges();
            }
        }

        public List<HpAdvancePayment> GetAdvancePayments(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpAdvancePayments.Where(x => x.AdmissionId == admissionId).ToList();
            }
        }

        public async  Task<VMHospitalBillCarrierObj2> SaveAndGetHpFinalBill(VWHpEndPointDataCarrier carrierDataObj)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {

                        entities.HospitalBills.Add(carrierDataObj.hbill);
                        entities.SaveChanges();

                        List<HospitalBillDetail> billdetails = new List<HospitalBillDetail>();
                        foreach (var item in carrierDataObj.hbilldetails)
                        {
                            item.HospitalBillId = carrierDataObj.hbill.HospitalBillId;

                            billdetails.Add(item);
                        }

                        entities.HospitalBillDetails.AddRange(billdetails);
                        entities.SaveChanges();

                        CabinInfo _cabinObj = entities.CabinInfos.Where(x => x.CabinId == carrierDataObj.pInfo.CabinId).FirstOrDefault();
                      
                       // Change patient status to discharged
                       
                        HospitalPatientInfo _PInfo = entities.HospitalPatientInfoes.Where(x => x.AdmissionId == carrierDataObj.pInfo.AdmissionId).FirstOrDefault(); // new HospitalService().GetHospitalPatientInfoById(_pInfo.AdmissionId);
                       
                        _PInfo.Status = "Discharged";
                        _PInfo.DischargeDate = carrierDataObj.TransactionDate;
                        _PInfo.DischargeTime = carrierDataObj.TransactionTime;
                        _PInfo.Dischargedby = carrierDataObj.UserName;

                        entities.Entry(_PInfo).State = EntityState.Modified;
                        entities.SaveChanges();

                        //End of  Change patient status to discharged

                        // Free All Cabin

                        List<HpPatientAccomodationInfo> _accomList = entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == carrierDataObj.pInfo.AdmissionId && x.Status.ToLower() == "occupied").ToList();

                        foreach (var accomObj in _accomList)
                        {
                            if (accomObj.AllotType.ToLower() == "patientbed")
                            {
                                accomObj.Status = "Vacant";
                                accomObj.AllotType = HpBedAllotTypeEnum.ReleasedAsPB.ToString();
                                accomObj.ReleaseDate = carrierDataObj.TransactionDate;
                                accomObj.ReleaseTime = carrierDataObj.TransactionTime;
                                entities.Entry(accomObj).State = EntityState.Modified;
                                entities.SaveChanges();
                            }
                            else
                            {
                                accomObj.Status = "Vacant";
                                accomObj.AllotType = HpBedAllotTypeEnum.ReleasedAsEB.ToString();
                                accomObj.ReleaseDate = carrierDataObj.TransactionDate;
                                accomObj.ReleaseTime = carrierDataObj.TransactionTime;
                               // new HospitalCabinBedRepository().UpdateAccomodationInfoEF(accomObj);
                                entities.Entry(accomObj).State = EntityState.Modified;
                                entities.SaveChanges();
                            }

                            CabinInfo _cabin = entities.CabinInfos.Where(x => x.CabinId == accomObj.CabinId).FirstOrDefault(); 
                            _cabin.IsBooked = false;

                            entities.Entry(_cabin).State = EntityState.Modified;
                            entities.SaveChanges();
                        }

                        // End of Free All Cabin

                        double balance = 0;
                        balance = 0 - carrierDataObj.SaleAmount;
                        List<HpPatientLedgerFinal> transactionList = new List<HpPatientLedgerFinal>();

                        HpPatientLedgerFinal pLedger = new HpPatientLedgerFinal();
                        pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId; 
                        pLedger.TranDate = carrierDataObj.TransactionDate;
                        pLedger.TransactionTime = carrierDataObj.TransactionTime;
                        pLedger.Particulars = "Total Bill";
                        pLedger.Debit = carrierDataObj.SaleAmount;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.HpTotalBiLL.ToString();
                        pLedger.OperateBy = carrierDataObj.UserName;
                        pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                        pLedger.PCId = 0;
                        pLedger.TransactionNo = "";
                        transactionList.Add(pLedger);

                        balance = balance - carrierDataObj.ServiceCharge;
                        pLedger = new HpPatientLedgerFinal();
                        pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                        pLedger.TranDate = carrierDataObj.TransactionDate;
                        pLedger.TransactionTime = carrierDataObj.TransactionTime;
                        pLedger.Particulars = "Service Charge";
                        pLedger.Debit = carrierDataObj.ServiceCharge;
                        pLedger.Credit = 0;
                        pLedger.Balance = balance;
                        pLedger.TransactionType = TransactionTypeEnum.HpServiceCharge.ToString();
                        pLedger.OperateBy = carrierDataObj.UserName;
                        pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                        pLedger.PCId = 0;
                        pLedger.TransactionNo = "";
                        transactionList.Add(pLedger);



                        if (carrierDataObj.DiscountAmount > 0)
                        {

                            balance = balance + carrierDataObj.DiscountAmount;
                            pLedger = new HpPatientLedgerFinal();
                            pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                            pLedger.TranDate = carrierDataObj.TransactionDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Discount";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.DiscountAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.HpDiscount.ToString();
                            pLedger.OperateBy = carrierDataObj.UserName;
                            pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);
                        }

                        if (carrierDataObj.AdmissionFee > 0)
                        {

                            balance = balance + carrierDataObj.AdmissionFee;
                            pLedger = new HpPatientLedgerFinal();
                            pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                            pLedger.TranDate = carrierDataObj.TransactionDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Admission Fee";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.AdmissionFee;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.AdmissionFee.ToString();
                            pLedger.OperateBy = carrierDataObj.UserName;
                            pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                            pLedger.PCId = 0;
                            pLedger.TransactionNo = "";
                            transactionList.Add(pLedger);
                        }



                        List<HpAdvancePayment> _advanceList = entities.HpAdvancePayments.Where(x => x.AdmissionId == carrierDataObj.pInfo.AdmissionId).ToList();
                        if (_advanceList!=null && _advanceList.Count>0)
                        {
                              //  new HpFinancialService().GetRoughAdvancePaymentList(_pInfo.AdmissionId);

                            foreach (HpAdvancePayment _fl in _advanceList)
                            {

                                if (_fl.TransactionType.Equals("HpAdvance")|| _fl.TransactionType.Equals("AdvanceByMob") || _fl.TransactionType.Equals("AdvanceByCard"))
                                {
                                    balance = balance + _fl.Amount;
                                }
                                else
                                {
                                    balance = balance - _fl.Amount;
                                }
                                
                                pLedger = new HpPatientLedgerFinal();
                                pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                                pLedger.TranDate = _fl.PayDate;
                                pLedger.TransactionTime = _fl.PayTime;
                                pLedger.Particulars = _fl.Remarks;

                                if (_fl.TransactionType.Equals("HpAdvance")|| _fl.TransactionType.Equals("AdvanceByMob") || _fl.TransactionType.Equals("AdvanceByCard"))
                                {
                                    pLedger.Debit = 0;
                                    pLedger.Credit = _fl.Amount;
                                }
                                else
                                {
                                    pLedger.Debit = _fl.Amount;
                                    pLedger.Credit = 0;
                                }
                              
                                pLedger.Balance = balance;
                                pLedger.TransactionType = _fl.TransactionType;
                                pLedger.OperateBy = _fl.ReceievedBy;
                                pLedger.TransactionTerminal = _fl.TransactionTerminal;
                                pLedger.PCId = _fl.PCId;
                                pLedger.TransactionNo = _fl.TransactionNo;
                                transactionList.Add(pLedger);
                            }
                        }



                        if (carrierDataObj.CashPaidAmount > 0)
                        {


                            balance = balance + carrierDataObj.CashPaidAmount;
                            pLedger = new HpPatientLedgerFinal();
                            pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                            pLedger.TranDate = carrierDataObj.TransactionDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (Cash)";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.CashPaidAmount;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.HpPaidAmount.ToString();
                            pLedger.OperateBy = carrierDataObj.UserName;
                            pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                            pLedger.PCId = 1;
                            pLedger.TransactionNo = "CashTrxn";
                            transactionList.Add(pLedger);

                        }

                        if (carrierDataObj.MobilePayment > 0)
                        {
                            balance = balance + carrierDataObj.MobilePayment;
                            pLedger = new HpPatientLedgerFinal();
                            pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                            pLedger.TranDate = carrierDataObj.TransactionDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (Mobile Banking)";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.MobilePayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyMobileBanking.ToString();
                            pLedger.OperateBy = carrierDataObj.UserName;
                            pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                            pLedger.PCId = carrierDataObj.PCId;
                            pLedger.TransactionNo = carrierDataObj.TransactionNo;
                            transactionList.Add(pLedger);
                        }


                        if (carrierDataObj.CardPayment > 0)
                        {
                            balance = balance + carrierDataObj.CardPayment;
                            pLedger = new HpPatientLedgerFinal();
                            pLedger.HospitalBillId = carrierDataObj.hbill.HospitalBillId;
                            pLedger.TranDate = carrierDataObj.TransactionDate;
                            pLedger.TransactionTime = carrierDataObj.TransactionTime;
                            pLedger.Particulars = "Payment (By Card))";
                            pLedger.Debit = 0;
                            pLedger.Credit = carrierDataObj.CardPayment;
                            pLedger.Balance = balance;
                            pLedger.TransactionType = TransactionTypeEnum.PaymentbyCard.ToString();
                            pLedger.OperateBy = carrierDataObj.UserName;
                            pLedger.TransactionTerminal = carrierDataObj.WorkStationId;
                            pLedger.PCId = carrierDataObj.PCId;
                            pLedger.TransactionNo = carrierDataObj.TransactionNo;
                            transactionList.Add(pLedger);
                        }


                        entities.HpPatientLedgerFinals.AddRange(transactionList);
                        entities.SaveChanges();

                        VMHospitalBillCarrierObj2 _retObj = new VMHospitalBillCarrierObj2();

                        _retObj.SavedHpBill = carrierDataObj.hbill;
                        _retObj.Cabin = _cabinObj;
                        _retObj.billType = carrierDataObj.hbill.BillType;

                        transaction.Commit();

                        return await Task.FromResult(_retObj);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return await Task.FromResult(new VMHospitalBillCarrierObj2() { SavedHpBill = new HospitalBill() { HospitalBillId=0 } });
                    }
                 } 
            } 
        
        }
        public DataSet GetConsultancyLedger(DateTime dtpfrm, DateTime dtpto, int doctorId)
        {
            using (SqlConnection conn=new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spGetConsultantLedger]  '{0}','{1}',{2}", dtpfrm, dtpto, doctorId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtConsultantLedger");
                return ds;
            }
        }

        public bool UpdateFloorServiceBill(ServiceBillDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public void DeleteOTConsultancyService(OTExecutionDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }

        public DoctorServiceBillDetail GetConsultancyBillById(long dSBDId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DoctorServiceBillDetails.Where(x => x.DSBDId == dSBDId).FirstOrDefault();

            }
        }

        public void DeleteConsultancyService(DoctorServiceBillDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }
        public bool SaveConsultancyServiceDeleteLog(DoctorServiceDeleteLog _dLog)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.DoctorServiceDeleteLogs.Add(_dLog);
                 entities.SaveChanges();
                 return true;
            }
        }

        public List<HpPatientLedger> GetTransactionsByAdmissionId(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.HpPatientLedgers.Where(x=>x.AdmissionId== admissionId).ToList();

            }
        }

        public double GetAlreadySavedCabinCharge(long admissionId)
        {
            using (DBEntities entities=new DBEntities())
            {
                List<HpCabinCharge> _cabinCharges = entities.HpCabinCharges.Where(x=>x.AdmissionId== admissionId).ToList();

                double _amount = _cabinCharges.Where(x => x.AdmissionId == admissionId).Sum(q => q.Amount);

                return _amount;
            }
        }

        public void SaveHpConsultantTransaction(List<HpConsultantLedger> _hpcLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpConsultantLedgers.AddRange(_hpcLedger);
                entities.SaveChanges();
               
            }
        }

        public void SaveHpLedgerTransactionList(List<HpPatientLedger> _hpLedegerList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpPatientLedgers.AddRange(_hpLedegerList);
                entities.SaveChanges();

            }
        }

        public HpConsultantLedger GetConsultantLedgerByTransactionNo(long tranNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpConsultantLedgers.Where(x => x.PaymentTransactionNo == tranNo).FirstOrDefault();
            
            }
        }


        public void SaveHpConsultantTransactionUnit(HpConsultantLedger _hpcLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpConsultantLedgers.Add(_hpcLedger);
                entities.SaveChanges();

            }
        }


        public DataSet GetCabinChargeDetails(long admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT [AdmissionDate],[AdmissionTime],Case When [IsAdmissionDayBillApplicable]=1 Then 'Applicable' Else 'Not Applicable' End as AdmissionDayBill,
                                      Case When [IsAdmissionDayAndReleaseDaySame]=1 Then 'Same' Else 'Different' End as AdmissinAndReleaseDay,
                                      Case When [IsOccupationMorethanTwoCalendarDate]=1 Then 'Yes' Else 'No' End as IsOccupationmoreThanTwoCaledarDate
                                      from [dbo].[HpCabinChargeSegmantMasters]; Select row_number() over (Order by [SDId])  as BookOrder,[StayingDate] as RollDate, [CabinNo],[Rent] from [dbo].[HpCabinChargeSegmantDetails]");


                da = new SqlDataAdapter(sql, conn);


                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtCabinChrageDetails"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtCabinRolling";
             
                return dsReports;
            }

        }


        public double GetOTDoctorBill(long admissionId)
        {

            double _amount = 0;

            using (DBEntities entities=new DBEntities())
            {
                List<OTExecutionDetail> _cOtExecutionList = entities.OTExecutionDetails.SqlQuery(@"SELECT dbo.OTSchedules.AdmissionId, dbo.OTExecutionDetails.* FROM  dbo.OTSchedules INNER JOIN dbo.OTExecutionDetails ON dbo.OTSchedules.OTId = dbo.OTExecutionDetails.OTId Where dbo.OTSchedules.AdmissionId={0}", admissionId).ToList();

                if (_cOtExecutionList.Count > 0)
                {
                   _amount = _cOtExecutionList.Sum(p => p.Rate*p.Qty);

                }
                else
                {
                    _amount = 0;
                }
            }

                return _amount;
        }


        public bool UpdateOTServiceBill(OTExecutionDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }
      
        
    public DataSet GetHpCashMemo(long _billId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spGetHpFinalBill] {0}", _billId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtHBill"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtAdvance";

                return dsReports;

            }
        }
        public DataSet GetOpdCashMemo(long _billId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"EXEC [dbo].[spGetOpdProcedureBill] {0}", _billId);

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtHBill"; //based on datatable name in .xsd
                dsReports.Tables[1].TableName = "dtAdvance";

                return dsReports;

            }
        }


        public List<HpPatientLedgerRough> GetPatientLedgerRoughById(long _billId)
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.HpPatientLedgerRoughs.Where(x => x.HospitalRoughBillId == _billId).ToList();

            }
        }

        public bool UpdateDoctorServiceBill(DoctorServiceBillDetail _billDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_billDetail).State=EntityState.Modified;
                entities.SaveChanges();

                return true;
            }
        }

        public HospitalRoughBill GetHospitalRoughBillById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalRoughBills.Where(x => x.HospitalRoughBillId == _billId).FirstOrDefault();

            }
        }

        public DataSet GetHpRoughCashMemo(long _billId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
               
                
                    sql = string.Format(@"EXEC [dbo].[spGetHpRoughBill] {0}", _billId);

                    da = new SqlDataAdapter(sql, conn);

                  DataSet dsReports = new DataSet();
                    da.Fill(dsReports);

                    dsReports.DataSetName = "myDataset";
                    dsReports.Tables[0].TableName = "dtHBill"; //based on datatable name in .xsd
                    dsReports.Tables[1].TableName = "dtAdvance";

                    return dsReports;
                /** 
                   catch(Exception ex)
                    {
                        DataSet dsReports = new DataSet();
                        return dsReports;
                    }*/
            }
        }

        public DataSet GetConsultancyDetailsByPatientId(long admissionId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spGetConsultancyByPatient] {0}", admissionId);

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtConsultancyByPatient");
                return ds;
            }

        }

        public void SaveHpRoughLedger(List<HpPatientLedgerRough> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpPatientLedgerRoughs.AddRange(transactionList);
                entities.SaveChanges();

            }
        }

        public bool SaveHpRoughBillDetail(List<HospitalRoughBillDetail> _hbilldetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalRoughBillDetails.AddRange(_hbilldetailList);
                entities.SaveChanges();

                return true;
            }
        }

        public long SaveHpRoughBill(HospitalRoughBill _hbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalRoughBills.Add(_hbill);
                entities.SaveChanges();

                return _hbill.HospitalRoughBillId;
            }
        }
        public List<HpPatientLedgerRough> GetRoughAdvancePaymentList(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                HospitalRoughBill _hpbill = new HpFinancialRepository().GetHospitalRoughBillByAdmissionId(admissionId);

                if (_hpbill == null) return null;

                return entities.HpPatientLedgerRoughs.Where(x => x.HospitalRoughBillId == _hpbill.HospitalRoughBillId && (x.TransactionType == TransactionTypeEnum.HpAdvance.ToString() || x.TransactionType == TransactionTypeEnum.HpAdvanceReturn.ToString()||x.TransactionType==TransactionTypeEnum.AdvanceByMob.ToString()||x.TransactionType==TransactionTypeEnum.AdvanceByCard.ToString())).ToList();
            }
        }

        public HospitalRoughBill GetHospitalRoughBillByAdmissionId(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalRoughBills.Where(x => x.AdmissionId == admissionId).FirstOrDefault();
            }
        }

        public List<HpPatientLedgerFinal> GetAdvancePaymentList(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                HospitalBill _hpbill = new HpFinancialRepository().GetHospitalBillByAdmissionId(admissionId);

                if (_hpbill == null) return null;

                return entities.HpPatientLedgerFinals.Where(x => x.HospitalBillId == _hpbill.HospitalBillId && x.TransactionType==TransactionTypeEnum.HpAdvance.ToString()).ToList();
            }
        }
        public double GetAdvancePaymentByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                HospitalBill _hpbill = new HpFinancialRepository().GetHospitalBillByAdmissionId(admissionId);

                if (_hpbill == null) return 0;

                List<HpPatientLedgerFinal> _advList = entities.HpPatientLedgerFinals.Where(x => x.HospitalBillId == _hpbill.HospitalBillId && x.TransactionType==TransactionTypeEnum.HpAdvance.ToString()).ToList();
                double _advance = _advList.Sum(y => y.Credit);

                return _advance;
            }
       }

        public double GetRoughAdvancePaymentByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                List<HpAdvancePayment> _advList = entities.HpAdvancePayments.Where(x => x.AdmissionId == admissionId).ToList();

                if (_advList == null) return 0;

                var L1 = _advList.Where(y => y.TransactionType == TransactionTypeEnum.HpAdvance.ToString()).ToList();

                var L2 = _advList.Where(y => y.TransactionType == TransactionTypeEnum.HpAdvanceReturn.ToString()).ToList();

                var L3 = _advList.Where(y => y.TransactionType == TransactionTypeEnum.AdvanceByCard.ToString()).ToList();

                var L4 = _advList.Where(y => y.TransactionType == TransactionTypeEnum.AdvanceByMob.ToString()).ToList();


                double TAdvance = L1.Sum(x => x.Amount);
                double TCardAdvance = L3.Sum(x => x.Amount);
                double TMobileAdvance = L4.Sum(x => x.Amount);
                double TAdvanceReturn = L2.Sum(x => x.Amount);

                double _advance = TAdvance + TCardAdvance + TMobileAdvance - TAdvanceReturn;

                return _advance;
            }
        }

        public HospitalBill GetHospitalBillByAdmissionId(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalBills.Where(x => x.AdmissionId == admissionId).FirstOrDefault();
            }
        }
        public void SaveAdvancePayment(HpAdvancePayment _advPayment)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.HpAdvancePayments.Add(_advPayment);
                entities.SaveChanges();
            }
        }

        public double GetHpPatientBalance(long hospitalBillId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    sql = string.Format(@"Select Sum(Credit-Debit) as cBalance from  HpPatientLedgerFinals Where HospitalBillId={0}", hospitalBillId);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());

                }
                catch
                {
                    con.Close();
                    return 0;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public bool DeleteExistingBill(long admissionId)
        {
            try
            {
                using (DBEntities entities = new DBEntities())
                {
                    List<HospitalRoughBill> _billList = entities.HospitalRoughBills.Where(x => x.AdmissionId == admissionId).ToList();

                    foreach (HospitalRoughBill billItem in _billList)
                    {
                        using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                        {
                            if (billItem != null)
                            {
                                sql = string.Format("Delete from HpPatientLedgerRoughs Where HospitalRoughBillId={0}", billItem.HospitalRoughBillId);
                                cmd = new SqlCommand(sql, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();

                                sql = string.Format("Delete from HospitalRoughBillDetails Where HospitalRoughBillId={0}", billItem.HospitalRoughBillId);
                                cmd = new SqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();

                                sql = string.Format("Delete from HospitalRoughBills Where HospitalRoughBillId={0}", billItem.HospitalRoughBillId);
                                cmd = new SqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();

                                conn.Close();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SaveCabinCharge(HpCabinCharge _HpcabinCharge)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpCabinCharges.Add(_HpcabinCharge);
                entities.SaveChanges();

            }
        }

        public HospitalBill GetHospitalBillById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalBills.Where(x => x.HospitalBillId == _billId).FirstOrDefault();

            }
        }
        public OpdProcedureBill GetOpdProcedureBillById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OpdProcedureBills.Where(x => x.ProcedureBillId == _billId).FirstOrDefault();

            }
        }

        public List<HpPatientLedgerFinal> GetPatientLedgerFinalById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.HpPatientLedgerFinals.Where(x=>x.HospitalBillId== _billId).ToList();
               
            }
        }
        public List<OpdProcedurepatientLedger> GetProcedurePatientLedgerFinalById(long _billId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OpdProcedurepatientLedgers.Where(x => x.ProcedureBillId == _billId).ToList();

            }
        }

        public void SaveHpFinalLedger(List<HpPatientLedgerFinal> transactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpPatientLedgerFinals.AddRange(transactionList);
                entities.SaveChanges();
              
            }
        }

        public bool SaveHpFinalBillDetail(List<HospitalBillDetail> _hbilldetailList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalBillDetails.AddRange(_hbilldetailList);
                entities.SaveChanges();
                return true;
            }
        }

        public long SaveHpFinalBill(HospitalBill _hbill)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalBills.Add(_hbill);
                entities.SaveChanges();
                return _hbill.HospitalBillId;
            }
        }
        public void AccumulateHpFinalBill(long admissionId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [dbo].[spHpFinalBill]  {0}", admissionId);

                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public double GetConsultantCurrentBalance(int doctorId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from HpConsultantLedgers Where DoctorId={0}", doctorId);
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

        public double GetPatientCurrentBalance(long _admissionId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from HpPatientLedgers Where AdmissionId={0}", _admissionId);
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

        public bool SaveHpLedgerTransaction(HpPatientLedger _hpLedger)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.HpPatientLedgers.Add(_hpLedger);
               entities.SaveChanges();
               return true;
            }
        }

        public HpParameterSetup GetAdmissionFee()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.HpParameterSetups.Where(x => x.ParameterType == HospitalParameterTypeEnum.AdmissionFee.ToString()).FirstOrDefault();
            }
        }

        public double GetPathologyBill(long _admissionId)
        {
            double pathologytotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //sql = string.Format(@"[spSummarySheet] {0}", dateTime1, dateTime2);

                using (SqlCommand cmd = new SqlCommand("GetPathologyBill", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdmissionId", SqlDbType.BigInt));
                    cmd.Parameters["@AdmissionId"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@AdmissionId"].Value = _admissionId;
                    cmd.Parameters.Add(new SqlParameter("@pathologytotal", SqlDbType.Float));
                    cmd.Parameters["@pathologytotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@pathologytotal"].Value != DBNull.Value)
                        pathologytotal = Convert.ToDouble(cmd.Parameters["@pathologytotal"].Value);

                }
            }
            return pathologytotal;
        }

        public double GetMedicineBill(long _admissionId)
        {
            double medicinetotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //sql = string.Format(@"[spSummarySheet] {0}", dateTime1, dateTime2);

                using (SqlCommand cmd = new SqlCommand("GetMedicineBill", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdmissionId", SqlDbType.BigInt));
                    cmd.Parameters["@AdmissionId"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@AdmissionId"].Value = _admissionId;
                    cmd.Parameters.Add(new SqlParameter("@medicinetotal", SqlDbType.Float));
                    cmd.Parameters["@medicinetotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@medicinetotal"].Value != DBNull.Value)
                        medicinetotal = Convert.ToDouble(cmd.Parameters["@medicinetotal"].Value);

                }
            }
            return medicinetotal;
        }

        public double GetDoctorBill(long _admissionId)
        {
            double doctortotal = 0;
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                //sql = string.Format(@"[spSummarySheet] {0}", dateTime1, dateTime2);

                using (SqlCommand cmd = new SqlCommand("GetDoctorBill", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@AdmissionId", SqlDbType.BigInt));
                    cmd.Parameters["@AdmissionId"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@AdmissionId"].Value = _admissionId;
                    cmd.Parameters.Add(new SqlParameter("@doctortotal", SqlDbType.Float));
                    cmd.Parameters["@doctortotal"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (cmd.Parameters["@doctortotal"].Value != DBNull.Value)
                        doctortotal = Convert.ToDouble(cmd.Parameters["@doctortotal"].Value);

                }
            }
            return doctortotal;
        }

        public DataSet GetHpFinalBill(long _admissionId)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {


                sql = string.Format(@"EXEC [spHpFinalBill] {0}", _admissionId);

              

                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds, "dtHBill");
                return ds;
            }

        }

        public List<VMHpFinalBill> GetHpFinalBillItems(long _admissionId,bool IsAdmissionFeeApplicable)
        {
            string constring = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                sql = string.Format(@"EXEC [spHpFinalBill] {0},'{1}'", _admissionId, IsAdmissionFeeApplicable);

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMHpFinalBill> listReportTests = new List<VMHpFinalBill>();

                listReportTests = new List<VMHpFinalBill>(
                    (from dRow in dt.AsEnumerable()
                     select (GetBillDataTableRow(dRow)))
                    );

                return listReportTests;
            }

        }

        private VMHpFinalBill GetBillDataTableRow(DataRow dr)
        {
            VMHpFinalBill _pr = new VMHpFinalBill();
            _pr.SrlNo = Convert.ToInt32(dr["DisplayOrder"]);
            _pr.ServiceHeadId = Convert.ToInt32(dr["ServiceHeadId"]);
            _pr.ServiceName = dr["ServiceItem"].ToString();
            _pr.Qty = Convert.ToInt32(dr["Qty"]);
            _pr.Rate = Convert.ToDouble(dr["ServiceRate"]);
            _pr.Total = Convert.ToDouble(dr["TotalAmount"]);
            _pr.AccomodationTypeId = Convert.ToInt32(dr["AccomodationTypeId"]);
            if (dr["DoctorId"] == DBNull.Value)
            {
                _pr.DoctorId = 0;
            }
            else
            {
                _pr.DoctorId = Convert.ToInt32(dr["DoctorId"]);
            }
            _pr.ServiceGroup = dr["ServiceGroup"].ToString();
            _pr.ServiceChargeInPercent= Convert.ToInt32(dr["ServiceChargeInPercent"]);

            return _pr;
        }
    }
}
