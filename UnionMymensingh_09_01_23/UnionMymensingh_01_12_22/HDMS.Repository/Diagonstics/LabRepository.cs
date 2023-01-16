using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Diagnostic;
using HDMS.Model.Diagnostic.VM;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data;
using HDMS.Model.LIS;
using HDMS.Model;
using HDMS.Model.Rx.VModel;
using HDMS.Model.Rx;

namespace HDMS.Repository.Diagonstics
{
    public class LabRepository
    {
        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;

        public List<LabInfo> GetLabList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.LabInfoes.ToList();
            }
        }

        public LabInfo GetlabInfoById(int _LabId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.LabInfoes.Where(x=>x.LabId== _LabId).FirstOrDefault();
            }
        }

        public long SaveRequisition(LabRequisition _hpMReq)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.LabRequisitions.Add(_hpMReq);
                entities.SaveChanges();
                return _hpMReq.RequisitionId;
            }
        }

        public bool SaveRequisitionDetails(List<LabRequisitionDetail> _reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.LabRequisitionDetails.AddRange(_reqDetailsList);
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMLabRequisition> GetRequisitionListByUserByDate(string username, DateTime _dt)
        {
            try
            {
                sql = string.Format(@"SELECT  dbo.LabRequisitions.RequisitionId, dbo.LabRequisitions.LabId, dbo.LabRequisitions.RDate, dbo.LabRequisitions.RTime, dbo.LabRequisitions.OperateBy, dbo.LabRequisitions.Status, dbo.LabInfoes.Name
                                      FROM   dbo.LabRequisitions INNER JOIN
                                      dbo.LabInfoes ON dbo.LabRequisitions.LabId = dbo.LabInfoes.LabId Where OperateBy='{0}' and CAST(RDate as date)='{1}'", username, _dt);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMLabRequisition> _reqList = new List<VMLabRequisition>();

                _reqList = new List<VMLabRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetLabRequisitionData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> LoadLISMachineData(string _billNo, Patient _PatientInfo)
        {
            
                 await  LoadLISData(_billNo, _PatientInfo);

                 return await Task.FromResult(true);
            
        }

        private async Task<bool> LoadLISData(string _billNo, Patient _PatientInfo)
        {

            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {
                try
                {

                   string  _sql = string.Format(@"Exec spUpdateMAHDIAGTEMPLIS '{0}'", _billNo);

                    await conn.OpenAsync();
                    using (var tran = conn.BeginTransaction())
                    using (var command = new SqlCommand(_sql, conn, tran))
                    {
                        try
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                        tran.Commit();
                    }

                    return await Task.FromResult(true);

                   

                }
                catch (Exception ex)
                {
                    return await Task.FromResult(false);
                }
            }
        }

        public async Task<List<RxVMTestResult>> GetRxLabResults(RxVisitHistory rxVisitHistory)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await Task.FromResult(new List<RxVMTestResult>()); //entities.PathologicalMachines.Where(x => x.ReportTypeId == _reportTypeId).ToList();
            }
        }

        public List<PathologicalMachine> GetPathologyMachineByReportTypeId(int _reportTypeId)
        {
            using(DBEntities entities = new DBEntities())
            {
                return entities.PathologicalMachines.Where(x => x.ReportTypeId == _reportTypeId).ToList();
            }
        }

        public PathologicalMachine GetPathologyMachineByShortName(string instrumentName)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.PathologicalMachines.Where(x => x.MachineShortName == instrumentName).FirstOrDefault();
            }
        }

        public List<TEMPLISPatientRecord> GetTestPerformedByList(string _reportTypeId, string _reportId)
        {
            using (DBEntities entities = new DBEntities())
            {
                int rtype = 0;
                int.TryParse(_reportTypeId, out rtype);

                sql = string.Format(@"Select * from TEMPLISPatientRecords Where ReportId='{0}' and InstrumentName in (Select MachineShortName from PathologicalMachines
                        Where ReportTypeId = {1})", _reportId, rtype );

                return entities.TEMPLISPatientRecords.SqlQuery(sql).ToList();
            }
        }

        public async Task<bool> MAP_LIS_RESULT_WITH_SOFTWARE_REPORT_DEFINATION(string _ReportId)
        {
            await Task.Run(() => MapLisResult(_ReportId));

            return await Task.FromResult(true);
        }

        private void MapLisResult(string _ReportId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {

                try
                {

                    string _sql = string.Empty;

                    _sql = string.Format(@"Exec  [dbo].[spUpdateReportDefId] '{0}'", _ReportId);

                    cmd = new SqlCommand(_sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

            }
        }

        private List<TEMPLISResultRecord> GetLISPentaDxNexusResultList(string _billNo, long _pRecordId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {

                try
                {

                    string _sql = string.Empty;

                    _sql = string.Format(@"SELECT * from VWPentaDxNexus Where PatientId='{0}'", _billNo);

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<TEMPLISResultRecord> listLIsResults = new List<TEMPLISResultRecord>();


                    listLIsResults = new List<TEMPLISResultRecord>(
                        (from dRow in dt.AsEnumerable()
                         select (GetLISPatientResultData(dRow, _pRecordId)))
                        );



                    return listLIsResults;


                    // return null;

                }
                catch (Exception ex)
                {
                    return new List<TEMPLISResultRecord>();
                }

            }
        }

        private List<TEMPLISResultRecord> GetLISArchitect2000ResultList(string _billNo, long _pRecordId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {

                try
                {

                    string _sql = string.Empty;

                    _sql = string.Format(@"SELECT * from VWArchitect2000ImmunoChem Where PatientId='{0}'", _billNo);

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<TEMPLISResultRecord> listLIsResults = new List<TEMPLISResultRecord>();


                    listLIsResults = new List<TEMPLISResultRecord>(
                        (from dRow in dt.AsEnumerable()
                         select (GetLISPatientResultData(dRow, _pRecordId)))
                        );



                    return listLIsResults;


                    // return null;

                }
                catch (Exception ex)
                {
                    return new List<TEMPLISResultRecord>();
                }

            }

        }

        private List<TEMPLISResultRecord> GetLISSimensDwXLResultList(string _billNo, long _pRecordId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {

                try
                {

                    string _sql = string.Empty;

                    _sql = string.Format(@"SELECT * from VWSiemensDwXL Where PatientId='{0}'", _billNo);

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<TEMPLISResultRecord> listLIsResults = new List<TEMPLISResultRecord>();


                    listLIsResults = new List<TEMPLISResultRecord>(
                        (from dRow in dt.AsEnumerable()
                         select (GetLISPatientResultData(dRow, _pRecordId)))
                        );



                    return listLIsResults;


                    // return null;

                }
                catch (Exception ex)
                {
                    return new List<TEMPLISResultRecord>();
                }

            }

        }

        public TEMPLISResultRecord GetLISResultRecord(long _PatientRecordId,long _PatientId, int reportDefId)
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.TEMPLISResultRecords.SqlQuery(@"Select * from TEMPLISResultRecords lr join TEMPLISPatientRecords lpr on lr.PatientRecordId=lpr.PatientRecordId 
                                                                    Where lpr.PatientRecordId={0} and lpr.PatientId={1} and lr.ReportDefId={2}", _PatientRecordId, _PatientId, reportDefId).FirstOrDefault();
            }
        }

        private void DeleteTempLISExistingData(string _billNo)
        {
            using (DBEntities entities=new DBEntities())
            {
                TEMPLISPatientRecord pRecord = entities.TEMPLISPatientRecords.Where(x=>x.ReportId== _billNo).FirstOrDefault();
                if (pRecord != null)
                {

                    using (SqlConnection con = new SqlConnection(Utility.GetLegacyDbConnectionString()))
                    {

                        
                     
                      con.Open();
                        sql = string.Format(@"Delete from TEMPLISPatientRecords Where ReportId='{0}'", _billNo);
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                     
                        sql = string.Format(@"Delete from TEMPLISResultRecords Where PatientRecordId={0}", pRecord.PatientRecordId);
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();


                        con.Close();

                    }


                }
            }
        }

        private void SaveTempLISResultRecord(List<TEMPLISResultRecord> _resultList)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.TEMPLISResultRecords.AddRange(_resultList);
                entities.SaveChanges();
            }
        }

        private List<TEMPLISResultRecord> GetLisResultList(string billNo,long prevRecordId,long currentPRecordId)
        {
            using (SqlConnection conn = new SqlConnection(Utility.GetLISDbConnectionString()))
            {

                try
                {

                    string _sql = string.Empty;

                    _sql = string.Format(@"SELECT * from VWResults Where PatientId='{0}' and PatientRecordId={1}", billNo, prevRecordId);

                    da = new SqlDataAdapter(_sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<TEMPLISResultRecord> listLIsResults = new List<TEMPLISResultRecord>();


                    listLIsResults = new List<TEMPLISResultRecord>(
                        (from dRow in dt.AsEnumerable()
                         select (GetLISPatientResultData(dRow, currentPRecordId)))
                        );



                    return listLIsResults;


                    // return null;

                }
                catch (Exception ex)
                {
                   return new List<TEMPLISResultRecord>();
                }

            }

        }

        private TEMPLISResultRecord GetLISPatientResultData(DataRow dr, long currentPRecordId)
        {
            TEMPLISResultRecord Obj = new TEMPLISResultRecord();
            Obj.PatientRecordId = currentPRecordId;
            if (dr["ReportDefId"] != DBNull.Value)
            {
                Obj.ReportDefId = Convert.ToInt32(dr["ReportDefId"]);

            }else
            {
                Obj.ReportDefId = 0;
            }
           
            if (dr["Category"] != DBNull.Value)
            {
                Obj.Category = dr["Category"].ToString();
            }
            else
            {
                Obj.Category ="";
            }

            if (dr["Code"] != DBNull.Value)
            {
                Obj.Code = dr["Code"].ToString();
            }
            else
            {
                Obj.Code = "";
            }

            if (dr["Name"] != DBNull.Value)
            {
                Obj.Name = dr["Name"].ToString();
            }
            else
            {
                Obj.Name = "";
            }

            if (dr["Value"] != DBNull.Value)
            {
                Obj.Value = dr["Value"].ToString();
            }
            else
            {
                Obj.Value = "";
            }

            if (dr["Unit"] != DBNull.Value)
            {
                Obj.Unit = dr["Unit"].ToString();
            }
            else
            {
                Obj.Unit = "";
            }

            if (dr["Range"] != DBNull.Value)
            {
                Obj.Range = dr["Range"].ToString();
            }
            else
            {
                Obj.Range = "";
            }

          

            return Obj;
        }

        private long SaveLisPatientMasterData(TEMPLISPatientRecord pObj)
        {
            using (DBEntities entities=new DBEntities())
            {
               entities.TEMPLISPatientRecords.Add(pObj);
               entities.SaveChanges();
                return pObj.PatientRecordId;
            }
        }

        private TEMPLISPatientRecord GetLisPatientMasterData(DataRow dr,long _PatientId)
        {
            TEMPLISPatientRecord Obj = new TEMPLISPatientRecord();
            Obj.InterfacingDbPatientRecordId = Convert.ToInt64(dr["PatientRecordId"]);
            Obj.PatientId = _PatientId;
            Obj.ReportId = dr["PatientId"].ToString();
            Obj.InstrumentName = dr["InstrumentName"].ToString(); ;

            if (dr["ReportDate"] != DBNull.Value)
                Obj.ReportDate = Convert.ToDateTime(dr["ReportDate"]);

            return Obj;
        }

        public List<VMLabRequisitionList> GetLabRequisitionDetailByReqId(long requisitionId)
        {
            try
            {
                sql = string.Format(@"SELECT dbo.LabRequisitions.RequisitionId, dbo.LabRequisitions.LabId, dbo.LabRequisitions.RDate, dbo.LabRequisitions.RTime, dbo.LabRequisitions.OperateBy, dbo.LabRequisitions.Status, dbo.LabRequisitionDetails.ProductId, 
                                      dbo.LabRequisitionDetails.Qty AS ReqQty, dbo.StoreProductInfoes.Name
                                      FROM   dbo.LabRequisitions INNER JOIN
                                      dbo.LabRequisitionDetails ON dbo.LabRequisitions.RequisitionId = dbo.LabRequisitionDetails.RequisitionId INNER JOIN
                                      dbo.StoreProductInfoes ON dbo.LabRequisitionDetails.ProductId = dbo.StoreProductInfoes.ProductId Where dbo.LabRequisitions.RequisitionId={0}", requisitionId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                List<VMLabRequisitionList> listhp = new List<VMLabRequisitionList>();

                listhp = new List<VMLabRequisitionList>(
                  (from dRow in dt.AsEnumerable()
                   select (GetLabRequisitionDataRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMLabRequisitionList GetLabRequisitionDataRow(DataRow dr)
        {
            VMLabRequisitionList rqList = new VMLabRequisitionList();
            rqList.ProductId = Convert.ToInt32(dr["ProductId"]);
            rqList.Name = dr["Name"].ToString();
            rqList.ReqQty = Convert.ToDouble(dr["ReqQty"]);
            return rqList;
        }

        public LabRequisition GetLabRequisitionByReqId(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.LabRequisitions.Where(x => x.RequisitionId == requisitionId).FirstOrDefault();
            }
        }

        private VMLabRequisition GetLabRequisitionData(DataRow dr)
        {
            VMLabRequisition _req = new VMLabRequisition();
            _req.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);
            _req.LabId= Convert.ToInt32(dr["LabId"]);
            _req.RDate = Convert.ToDateTime(dr["RDate"]);
            _req.LabName = dr["Name"].ToString();
            _req.Status= dr["Status"].ToString();
            return _req;
        }
    }
}
