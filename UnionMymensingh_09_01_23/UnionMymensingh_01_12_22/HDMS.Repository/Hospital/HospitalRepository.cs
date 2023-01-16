using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using System.Data.Entity;
using HDMS.Model.Pharmacy.ViewModels;
using HDMS.Model.Enums;
using HDMS.Model.Common.VW;
using HDMS.Model.OPD;
using HDMS.Models.Pharmacy;
using HDMS.Model.OPD.VM;

namespace HDMS.Repository.Hospital
{
    public class HospitalRepository
    {
        string sql = string.Empty;

        public VMIPDInfo GetIPDInfoById(long _admissionId)
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where AdmissionId={0} and Status<>'DisCharged' and CabinStatus='Occupied'", _admissionId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();



                return GetTemplateDataTableRow(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                return new VMIPDInfo();
            }
        }

        public List<VMHpPatientAccomodationInfo> GetHpAccomDetails(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                SqlParameter admId = new SqlParameter("admId", admissionId);
                return entities.Database.SqlQuery<VMHpPatientAccomodationInfo>(@"SELECT  aci.AccomId, aci.AdmissionId, aci.AccomodateDate, aci.AccomodateTime, aci.CabinId, aci.Status, aci.OperatorRemarks, aci.SoftwareRemarks, aci.OperateBy, aci.AllotType, aci.ReleaseDate, aci.ReleaseTime, aci.Modifiedby, 
                                               aci.Modifiydate, aci.ModifyTime, c.CabinNo
                                               FROM dbo.HpPatientAccomodationInfoes AS aci INNER JOIN
                                               dbo.CabinInfoes AS c ON aci.CabinId = c.CabinId Where aci.AdmissionId=@admId order by aci.AccomId", admId).ToList();
               
            }
        }

        public bool UpdateHpPackage(HpPackage _pkg)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_pkg).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMDischargedCertifiedPatientList> GetDischargeCertificateList(DateTime dtpStart, DateTime dtpEnd)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    sql = string.Format(@"SELECT dc.BillNo,dc.DCPrintDate,dc.BillNo,p.RegNo,p.DischargeDate,p.AddmissionDate,rr.FullName,   
                       IsNull(rr.CPAddress,'') CPAddress, IsNull(rr.CPMobile,'') CPMobile FROM  DischargeCertificateTemplateBaseds  dc join
                       HospitalPatientInfoes p on dc.BillNo = p.BillNo join RegRecords rr on p.RegNo = rr.RegNo
                       Where dc.DCPrintDate>='{0}' and dc.DCPrintDate<='{1}' and p.DischargeDate is not Null", dtpStart.Date, dtpEnd.Date);
                    
                    return entities.Database.SqlQuery<VMDischargedCertifiedPatientList>(sql).ToList();

                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SaveHpPackage(HpPackage _pkg)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.HpPackages.Add(_pkg);
                 entities.SaveChanges();
                return true;
            }
        }

        public bool SaveHpPackageSubItem(HpPkgSubItem _sItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpPkgSubItems.Add(_sItem);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<VMIPDInfo> GetCurrentOPDInfo()
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where Status='Cabin' and DeptId=15");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }

        }

        public Task<List<VMIPDInfo>> GetOPdBillingDistributedPatient()
        {
            return Task.Run(() =>
            {
                try
                {
                    sql = string.Format("select * from VWOPDPatientDetails_2  Where isBillDistributed='false' and DeptId=15 order by AdmissionId Desc");  // Current OPD Active Patient List
                    con = new SqlConnection();
                    con.ConnectionString = Utility.GetLegacyDbConnectionString();
                    con.Open();
                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                    listhp = new List<VMIPDInfo>(
                      (from dRow in dt.AsEnumerable()
                       select (GetTemplateDataTableRow(dRow)))
                      );

                    return listhp;
                }
                catch (Exception ex)
                {
                    return new List<VMIPDInfo>();
                }
            });
        }

        public List<HpPkgSubItem> GetHpPackageSubItems(int pkgId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPkgSubItems.Where(x=>x.PkgId== pkgId).ToList();

            }
        }

        public List<HpPackage> GetAllHpPackages()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.HpPackages.ToList();
              
            }
        }

        public bool UpdateOPDServiceHead(OPDServiceHead _sh)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(_sh).State=EntityState.Modified;
               entities.SaveChanges();
               return true;
            }
        }

        public List<OPDServiceGroup> getOpdServiceGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceGroups.ToList();

            }
        }

        public List<OPDServiceSubGroup> getOpdServiceSubGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.OPDServiceSubGroups.ToList();
               
            }
        }

        public bool UpdateHpPackageSubItem(HpPkgSubItem _subItem)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_subItem).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMedicineRequisition> GetOPDRequisitionListByUserByDate(string username, DateTime dtp)
        {
            try
            {
                sql = string.Format(@"SELECT * from dbo.HpMedicineRequisitions Where RequisitionBy='{0}' and CAST(ReqDate as date)='{1}'", username, dtp.Date);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMedicineRequisition> _reqList = new List<VMedicineRequisition>();

                _reqList = new List<VMedicineRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetMedicineRequisitionData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateHpOPDConsultantCategory(HpOPDConsultantCategory _hpopdconsultantcat)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_hpopdconsultantcat).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public long SaveDischargeMaster(DischargeCertificateMaster _dcm)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.DischargeCertificateMasters.Add(_dcm);
                entities.SaveChanges();
                return _dcm.DischargeId;
            }
        }

        public List<VMOPDServiceHead> GetAllOPDServiceHeadsByGroup(string _type)
        {

            try
            {
                int _groupId = 0;
                int.TryParse(_type, out _groupId);

                sql = string.Format(@"SELECT dbo.OPDServiceGroups.GroupId, dbo.OPDServiceGroups.Name AS GroupName, dbo.OPDServiceSubGroups.SubGroupId, dbo.OPDServiceSubGroups.Name AS SubGroupName, dbo.OPDServiceHeads.ServiceHeadId, 
                             dbo.OPDServiceHeads.ServiceHeadName, dbo.OPDServiceHeads.Rate, dbo.OPDServiceHeads.Unit, dbo.OPDServiceHeads.Vat, dbo.OPDServiceHeads.ServiceCharge, dbo.OPDServiceHeads.DocVisit, 
                             dbo.OPDServiceHeads.Show, dbo.OPDServiceHeads.OpdShow, dbo.OPDServiceHeads.ServiceCode
                             FROM  dbo.OPDServiceGroups INNER JOIN
                             dbo.OPDServiceSubGroups ON dbo.OPDServiceGroups.GroupId = dbo.OPDServiceSubGroups.GroupId INNER JOIN
                             dbo.OPDServiceHeads ON dbo.OPDServiceSubGroups.SubGroupId = dbo.OPDServiceHeads.SubGroupId  Where dbo.OPDServiceGroups.GroupId={0}", _groupId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMOPDServiceHead> listOPDServices = new List<VMOPDServiceHead>();

                listOPDServices = new List<VMOPDServiceHead>(
                  (from dRow in dt.AsEnumerable()
                   select (GetOPDServiceDataTableRow(dRow)))
                  );

                return listOPDServices;
            }
            catch (Exception ex)
            {
                return new List<VMOPDServiceHead>();
            }


        }

        public DataSet GetHpAllPatientListByAdmissionDate(DateTime dtpfrm, DateTime dtpto,int deptId, int floorId, bool isAllIPD)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                if (isAllIPD)
                {
                    sql = string.Format(@" Select * from VWAllHpPatient Where AddmissionDate between '{0}' and '{1}' and DeptId in (Select DeptId from HpDepartments Where DeptId<>15)", dtpfrm, dtpto);
                }
                else if(floorId>0)
                {
                    sql = string.Format(@" Select * from VWAllHpPatient Where AddmissionDate between '{0}' and '{1}' and (floorId={2} or {2}=0 )", dtpfrm, dtpto, floorId);
                }
                else
                {
                    sql = string.Format(@" Select * from VWAllHpPatient Where AddmissionDate between '{0}' and '{1}' and (DeptId={2} or {2}=0)", dtpfrm, dtpto, deptId);

                }

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports, "dtHpAdmittedPatientList");
                return dsReports;
            }
        }

        public HospitalPatientInfo GetOPProcedurePatientByOPDBillNo(long billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.BillNo == billNo).FirstOrDefault();
            }
        }

        public void UpdateOPDProcedurePatientInfo(OpdProcedureBill _pInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_pInfo).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public OpdProcedureBill GetOPDProcedurePatientInfoById(int procedureBillId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OpdProcedureBills.Where(x => x.ProcedureBillId == procedureBillId).FirstOrDefault();
            }
        }

        public Task<List<VMIPDInfo>> GetCurrentOPDAdmittedInfo()
        {

            return Task.Run(() =>
            {
                try
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and DeptId=15 order by AdmissionId Desc");  // Current OPD Active Patient List
                    con = new SqlConnection();
                    con.ConnectionString = Utility.GetLegacyDbConnectionString();
                    con.Open();
                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                    listhp = new List<VMIPDInfo>(
                      (from dRow in dt.AsEnumerable()
                       select (GetTemplateDataTableRow(dRow)))
                      );

                    return listhp;
                }
                catch (Exception ex)
                {
                    return new List<VMIPDInfo>();
                }
            });
        }

        public List<VMIPDInfo> GetCurrentEmergencyPatients()
        {
            try
            {
                sql = string.Format("select * from VWHospitalEmergencyPatientDetails_2 Where Status in ('Cabin')");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public HpPatientAccomodationInfo GetPatientLastAccomodatedCabin(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId && x.AllotType == HpBedAllotTypeEnum.ReleasedAsPB.ToString()).FirstOrDefault();
            }
        }

        private VMOPDServiceHead GetOPDServiceDataTableRow(DataRow dr)
        {
            VMOPDServiceHead _Obj = new VMOPDServiceHead();
             _Obj.GroupId = Convert.ToInt32(dr["GroupId"]);
             _Obj.SubGroupId = Convert.ToInt32(dr["SubGroupId"]);
             _Obj.GroupName = dr["GroupName"].ToString();
             _Obj.SubGroupName = dr["SubGroupName"].ToString();
             _Obj.ServiceCode = Convert.ToInt32(dr["ServiceCode"]);
             _Obj.ServiceHeadId = Convert.ToInt32(dr["ServiceHeadId"]);
             _Obj.ServiceHeadName = dr["ServiceHeadName"].ToString();
             _Obj.Rate= Convert.ToDouble(dr["Rate"]);
              if (dr["Unit"] != DBNull.Value)
              {
                _Obj.Unit = dr["Unit"].ToString();
              }
               else
              {
                _Obj.Unit ="";
              }

             _Obj.Vat = Convert.ToBoolean(dr["Vat"]);
             _Obj.ServiceCharge = Convert.ToBoolean(dr["ServiceCharge"]);
             _Obj.DocVisit = Convert.ToBoolean(dr["DocVisit"]);
             _Obj.Show = Convert.ToBoolean(dr["Show"]);
             _Obj.OpdShow = Convert.ToBoolean(dr["OpdShow"]);

            return _Obj;
        }

        public IList<VWDoctor> GetDoctorListByName(string _name)
        {
            using (DBEntities entities = new DBEntities())
            {
                // var _NameParam = new SqlParameter("@Name", _name);
            
                return entities.Database.SqlQuery<VWDoctor>("Exec spGetDoctorDetail @name", new SqlParameter("@name", _name)).ToList();

            }
        }

        public OTSchedule GetOTScheduleByAdmissionId(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OTSchedules.Where(x=>x.AdmissionId== admissionId).FirstOrDefault();

            }
        }

        public List<VMOPDServiceHead> GetAllOPDServiceHeads()
        {
            try
            {
              
                sql = string.Format(@"SELECT dbo.OPDServiceGroups.GroupId, dbo.OPDServiceGroups.Name AS GroupName, dbo.OPDServiceSubGroups.SubGroupId, dbo.OPDServiceSubGroups.Name AS SubGroupName, dbo.OPDServiceHeads.ServiceHeadId, 
                             dbo.OPDServiceHeads.ServiceHeadName, dbo.OPDServiceHeads.Rate, dbo.OPDServiceHeads.Unit, dbo.OPDServiceHeads.Vat, dbo.OPDServiceHeads.ServiceCharge, dbo.OPDServiceHeads.DocVisit, 
                             dbo.OPDServiceHeads.Show, dbo.OPDServiceHeads.OpdShow, dbo.OPDServiceHeads.ServiceCode
                             FROM  dbo.OPDServiceGroups INNER JOIN
                             dbo.OPDServiceSubGroups ON dbo.OPDServiceGroups.GroupId = dbo.OPDServiceSubGroups.GroupId INNER JOIN
                             dbo.OPDServiceHeads ON dbo.OPDServiceSubGroups.SubGroupId = dbo.OPDServiceHeads.SubGroupId");  
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMOPDServiceHead> listOPDServices = new List<VMOPDServiceHead>();

                listOPDServices = new List<VMOPDServiceHead>(
                  (from dRow in dt.AsEnumerable()
                   select (GetOPDServiceDataTableRow(dRow)))
                  );

                return listOPDServices;
            }
            catch (Exception ex)
            {
                return new List<VMOPDServiceHead>();
            }

        }

        public List<VMSelectedOTServices> GetPastServices(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    return entities.Database.SqlQuery<VMSelectedOTServices>(@"SELECT       oe.ServiceHeadId, oe.DoctorId, sh.ServiceHeadName, d.Name as DoctorName, oe.Rate, 
                         oe.Qty, oe.Rate* oe.Qty as Amount, oe.ServiceCharge, oe.UserName as EnteredBy
                       FROM  dbo.OTSchedules os INNER JOIN
                         dbo.OTExecutionDetails oe ON os.OTId = oe.OTId INNER JOIN
                         dbo.ServiceHeads sh ON oe.ServiceHeadId  =sh.ServiceHeadId INNER JOIN
                         dbo.Doctor d ON oe.DoctorId = d.DoctorId Where AdmissionId=@admissionId", new SqlParameter("@admissionId", admissionId)).ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<DischargeCertificateTemplateBased> GetDischargeCertificates(DateTime _datetime)
        {
            using (DBEntities entities = new DBEntities())
            {
               return  entities.DischargeCertificateTemplateBaseds.Where(x=>x.DCPrintDate== _datetime.Date).ToList();
               
            }
        }

        public HpPackage GetHpPackageById(int packageId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPackages.Where(x=>x.PkgId== packageId).FirstOrDefault();

            }
        }

        public bool SaveOPDServiceHead(OPDServiceHead _sh)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDServiceHeads.Add(_sh);
                entities.SaveChanges();
                return true;
            }
        }

        public bool CreateOPDServiceGroup(OPDServiceGroup _sGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDServiceGroups.Add(_sGroup);
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveHpDepartment(HpDepartment _hpd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpDepartments.Add(_hpd);
                entities.SaveChanges();
                return true;
            }
        }

        public List<OTExecutionDetail> GetOTSurgeon(long oTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OTExecutionDetails.Where(x=>x.OTId== oTId && x.ServiceHeadId==115).ToList();

            }
        }

        public List<OPDServiceSubGroup> GetAllOPDServiceSubGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceSubGroups.ToList();

            }
        }

        public List<OTExecutionDetail> GetOTAnaesthetists(long oTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OTExecutionDetails.Where(x => x.OTId == oTId && x.ServiceHeadId == 146).ToList();

            }
        }

        public bool UpdateHpOPDServiceSubGroup(OPDServiceSubGroup _ssgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_ssgroup).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMIPDInfo> GetCurrentIPDs()
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where Status in ('Cabin','OT','PO')");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public async Task<HpMedicineRequisition> CreateNewIPdPhRequistion(HpMedicineRequisition hpMReq, List<HpMedicineRequisitionDetail> reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                using (var transaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        entities.HpMedicineRequisitions.Add(hpMReq);
                        entities.SaveChanges();

                        List<HpMedicineRequisitionDetail> _reqList = new List<HpMedicineRequisitionDetail>();
                        foreach (var item in reqDetailsList)
                        {
                            item.RequisitionId = hpMReq.RequisitionId;
                            _reqList.Add(item);
                        }

                        if (_reqList.Count > 0)
                        {
                            entities.HpMedicineRequisitionDetails.AddRange(_reqList);
                            entities.SaveChanges();
                        }
                        else
                        {
                            transaction.Rollback();
                            return await Task.FromResult(new HpMedicineRequisition() { RequisitionId = 0 });
                        }

                        transaction.Commit();
                        return await Task.FromResult(hpMReq);
                            
                     }catch(Exception ex)
                    {
                        transaction.Rollback();
                        return await Task.FromResult(new HpMedicineRequisition() { RequisitionId=0});
                    }
                }
            }
        }

        public List<OTExecutionDetail> GetOTAssistantSurgeonDetail(long oTId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OTExecutionDetails.SqlQuery("Select * from OTExecutionDetails Where OTId={0} and ServiceHeadId in (107,108,109)", oTId).ToList();

            }
        }

        public void SaveDischargeDetails(List<DischargeCertificateDetail> _dcdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.DischargeCertificateDetails.AddRange(_dcdList);
                entities.SaveChanges();
            }
        }

        public List<OPDServiceHead> GetAllOPDServiceHeadBySubGroupId(int subGroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceHeads.ToList();

            }
        }

        public DischargeCertificateTemplateBased GetDischargeCertificate(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.DischargeCertificateTemplateBaseds.Where(x=>x.BillNo== _billNo).FirstOrDefault();

            }
        }

        public bool UpdateHpDept(HpDepartment _hpd)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_hpd).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public OPDServiceHead GetOPDServiceHeadById(int _shId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceHeads.Where(x=>x.ServiceHeadId== _shId).FirstOrDefault();

            }
        }

        public List<HpOPDConsultantCategory> GetHpOPDConsultantCategories()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.HpOPDConsultantCategories.ToList();
               
            }
        }

        public bool SaveHpOPDServiceSubGroup(OPDServiceSubGroup _ssgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.OPDServiceSubGroups.Add(_ssgroup);
                entities.SaveChanges();
                return true;
            }
        }

        public HpPatientAccomodationInfo GetHpPatientExtraAccomodationByAdmAndCabinId(long admissionId, int cabinId)
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.HpPatientAccomodationInfoes.Where(x=>x.AdmissionId== admissionId && x.CabinId== cabinId && x.AllotType==HpBedAllotTypeEnum.ExtraBed.ToString()).FirstOrDefault();
            }
        }

        public bool SaveHpOPDConsultantCategory(HpOPDConsultantCategory _hpdcat)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpOPDConsultantCategories.Add(_hpdcat);
                entities.SaveChanges();
                return true;
            }
        }

        public string UpdateDischargeCertificate(DischargeCertificateTemplateBased reportTest)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(reportTest).State=EntityState.Modified;
                entities.SaveChanges();
                return "Success";

            }
        }

        public void SaveTreatmentOnDischarge(List<TreatmentOnDischarge> _treatmentList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.TreatmentOnDischarges.AddRange(_treatmentList);
                entities.SaveChanges();
             
            }
        }

        public HpOPDConsultantCategory GetHpOPDConsultantCategoryById(int _cateId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpOPDConsultantCategories.Where(x=>x.CategoryId== _cateId).FirstOrDefault();
            }
        }

        public OPDServiceGroup GetOPDServiceGroupById(int _groupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceGroups.Where(x => x.GroupId == _groupId).FirstOrDefault();
            }
        }

        public HpPatientAccomodationInfo GetHpAccomInfo(long accomId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x => x.AccomId == accomId).FirstOrDefault();
            }
        }

        public OPDServiceSubGroup GetOPDServiceSubGroupById(int subgroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.OPDServiceSubGroups.Where(x => x.SubGroupId == subgroupId).FirstOrDefault();
            }
        }

        //public List<VMOutletRequisitionList> GetPhMedicineRequisitionDetailByReqId(long requisitionId, int outLetId)
        //{
            
        //}

        public List<HpDepartment> GetHpDepartments()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpDepartments.ToList();
            }
        }


        //Depricated method
        public List<VMIPDInfo> GetDischargeCertificateList(string _searchPrefix, string type, DateTime _date)
        {
            try
            {
                if (type.ToLower() == "pname")
                {
                    sql = string.Format("select * from VWDischargeCertificateList Where  FullName like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "admid")
                {
                    sql = string.Format("select * from VWDischargeCertificateList Where BillNo like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
               
                else if (type.ToLower() == "mobileno")
                {
                    sql = string.Format("select * from VWDischargeCertificateList Where  CPMobile like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "address")
                {
                    sql = string.Format("select * from VWDischargeCertificateList Where CPAddress like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else
                {
                    sql = string.Format("select * from VWDischargeCertificateList Where DCPrintDate='{0}'", _date.Date);  // Current Active Patient List
                }

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetDischareCertificateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }

        }

        public bool IsAnyIpdServiceProvided(VMIPDInfo patient)
        {
            using (DBEntities entities = new DBEntities())
            {
                var services = entities.ServiceBillDetails.Where(x => x.AdmissionId == patient.AdmissionId).ToList();
                if (services == null || services.Count == 0) return false;

                return true;
            }
        }

        public bool IsCabinChargeApplied(VMIPDInfo patient, DateTime currentDateTime)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    ModifiedCabinCharge mcc = entities.ModifiedCabinCharges.Where(x => x.AdmissionId == patient.AdmissionId).FirstOrDefault();

                    if (mcc == null)
                    {
                        return currentDateTime.Date > patient.AddmissionDate.Date;
                    }

                    if (mcc.ModifiedQty > 0) return true;

                    return false;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }

        private VMIPDInfo GetDischareCertificateDataTableRow(DataRow dr)
        {
            VMIPDInfo pdInfo = new VMIPDInfo();
            pdInfo.RegNo = Convert.ToInt64(dr["RegNo"]);
            pdInfo.AdmissionId = Convert.ToInt32(dr["AdmissionId"]);
            pdInfo.BillNo = Convert.ToInt64(dr["BillNo"]);
            
            pdInfo.Name = dr["FullName"].ToString();
          

            return pdInfo;

        }



        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;

        public IList<ServiceGroup> GetAllProvidedService()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceGroups.ToList();
            }
        }

        public HpDepartment GetHpDeptById(int _deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpDepartments.Where(x=>x.DeptId== _deptId).FirstOrDefault();
            }
        }

        public long SavePatientInfo(HospitalPatientInfo _patientInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HospitalPatientInfoes.Add(_patientInfo);
                entities.SaveChanges();
                long i = _patientInfo.AdmissionId;
                return i;
            }
        }

        public List<VMHpFinalBill> GetHpPreviousBillDetails(long _hbillNo)
        {
            sql = string.Format(@"SELECT dbo.HospitalBills.HospitalBillId, dbo.HospitalBills.Billdate, dbo.HospitalBills.AdmissionId, dbo.HospitalBills.BillNo, dbo.HospitalBills.PreparedBy, dbo.HospitalBills.BillTime, dbo.HospitalBills.Remarks, 
                                   dbo.HospitalBills.BillType, dbo.HospitalBillDetails.HospitalBillDetailId, dbo.HospitalBillDetails.Qty, dbo.HospitalBillDetails.Rate, dbo.HospitalBillDetails.Total, dbo.HospitalBillDetails.ServiceHeadId, 
                                   dbo.HospitalBillDetails.ServiceName, dbo.HospitalBillDetails.DoctorId, dbo.HospitalBillDetails.DisplayOrder
                                   FROM  dbo.HospitalBills INNER JOIN
                                   dbo.HospitalBillDetails ON dbo.HospitalBills.HospitalBillId = dbo.HospitalBillDetails.HospitalBillId Where  dbo.HospitalBills.BillNo={0}", _hbillNo);

           

            con = new SqlConnection();
            con.ConnectionString = Utility.GetLegacyDbConnectionString();
            con.Open();
            da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();

            List<VMHpFinalBill> _hpprevbillItems = new List<VMHpFinalBill>();

            _hpprevbillItems = new List<VMHpFinalBill>(
              (from dRow in dt.AsEnumerable()
               select (GetHpFinalBillDataRow(dRow)))
              );

            return _hpprevbillItems;

        }

        public List<HpPatientAccomodationInfo> GetHpPatientExtraAccomodation(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x=>x.AdmissionId== admissionId && x.Status.ToLower()=="occupied" && x.AllotType=="extrabed").ToList();
            }
        }

        public List<VMedicineRequisition> GetRequisitionListByUserByDate(string username, DateTime _date)
        {
            try
            {
                sql = string.Format(@"SELECT * from dbo.HpMedicineRequisitions Where RequisitionBy='{0}' and CAST(ReqDate as date)='{1}' order by RequisitionId", username,_date.Date);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMedicineRequisition> _reqList = new List<VMedicineRequisition>();

                _reqList = new List<VMedicineRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetMedicineRequisitionData(dRow)))
                  );

                return _reqList;

            }catch(Exception ex)
            {
                return null;
            }

        }

        private VMedicineRequisition GetMedicineRequisitionData(DataRow dr)
        {
            VMedicineRequisition req = new VMedicineRequisition();
            req.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);
            req.RequisitionBy = dr["RequisitionBy"].ToString();
            req.CabinNo = GetCabinNo(Convert.ToInt64(dr["AdmissionId"]));
            req.RequisitionStatus = dr["Status"].ToString();


            return req;
        }

        public List<VMSelectedService> GetDeliveredFloorServices(long _admissionId)
        {
            try
            {
                sql = string.Format(@"SELECT dbo.ServiceBillDetails.AdmissionId, dbo.ServiceBillDetails.ServiceHeadId, dbo.ServiceHeads.ServiceHeadName, dbo.ServiceBillDetails.Rate, SUM(dbo.ServiceBillDetails.Qty) AS totalService, 
                                      SUM(dbo.ServiceBillDetails.Qty * dbo.ServiceBillDetails.Rate) AS total
                                      FROM dbo.ServiceBillDetails INNER JOIN
                                      dbo.ServiceHeads ON dbo.ServiceBillDetails.ServiceHeadId = dbo.ServiceHeads.ServiceHeadId
                                      WHERE (dbo.ServiceBillDetails.AdmissionId = {0})
                                      GROUP BY dbo.ServiceBillDetails.AdmissionId, dbo.ServiceBillDetails.ServiceHeadId, dbo.ServiceHeads.ServiceHeadName, dbo.ServiceBillDetails.Rate", _admissionId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMSelectedService> _reqList = new List<VMSelectedService>();

                _reqList = new List<VMSelectedService>(
                  (from dRow in dt.AsEnumerable()
                   select (GetDeliverdFloorServiceData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private VMSelectedService GetDeliverdFloorServiceData(DataRow dr)
        {
            VMSelectedService _pr = new VMSelectedService();
            _pr.ServiceHeadName = dr["ServiceHeadName"].ToString(); ;
            _pr.Rate = Convert.ToDouble(dr["Rate"]);
            _pr.Qty = Convert.ToInt32(dr["totalService"]);
            _pr.Amount = Convert.ToDouble(dr["total"]);
        

            return _pr;
        }

        private VMHpFinalBill GetHpFinalBillDataRow(DataRow dr)
        {
            VMHpFinalBill _pr = new VMHpFinalBill();
            _pr.SrlNo = Convert.ToInt32(dr["DisplayOrder"]);
            _pr.ServiceName = dr["ServiceName"].ToString();
            _pr.Qty = Convert.ToInt32(dr["Qty"]);
            _pr.Rate = Convert.ToDouble(dr["Rate"]);
            _pr.Total = Convert.ToDouble(dr["Total"]);
           // _pr.ServiceGroup = dr["ServiceGroup"].ToString();

            return _pr;
        }

        public List<ServiceSubGroup> GetAllServiceSubGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceSubGroups.ToList();
            }
        }

        public List<ServiceHead> GetAllServiceHeads()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceHeads.ToList();
            }
        }

        public IList<VMIPDInfo> GetCurrentOPDInfoBySearchParameter(string _searchPrefix, string type)
        {
            try
            {
                if (type.ToLower() == "pname")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and and DeptId=15 FullName like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "cabin")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and DeptId=15 and CabinNo like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "admid")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and and DeptId=15 BillNo like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "assigndoc")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and and DeptId=15 AssignedDoctorName like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "mobileno")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and and DeptId=15 CPMobile like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "address")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and CabinStatus='Occupied' and and DeptId=15 CPAddress like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  Status<>'DisCharged' and and DeptId=15 CabinStatus='Occupied'");  // Current Active Patient List
                }
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public ServiceGroup GetServiceByName(string serviceName)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceGroups.Where(x => x.Name == serviceName).FirstOrDefault();
            }
        }

        public bool CreateServiceGroup(ServiceGroup _sGroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                     entities.ServiceGroups.Add(_sGroup);
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateServiceHead(ServiceHead _sh)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_sh).State = EntityState.Modified;
                entities.SaveChanges(); ;
              
                return true;
            }
        }

        public List<ServiceSubGroup> getServiceSubGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceSubGroups.ToList();

            }
        }

        public List<ServiceGroup> getServiceGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.ServiceGroups.ToList();

            }
        }

      

        public bool UpdateHpSubGroup(ServiceSubGroup _ssgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_ssgroup).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMSelectedDoctorService> GetDeliveredDoctorConsultancies(long _admissionId)
        {
            try
            {
                sql = string.Format(@"SELECT dbo.DoctorServiceBillDetails.AdmissionId, dbo.DoctorServiceBillDetails.DoctorId, SUM(dbo.DoctorServiceBillDetails.Qty) AS totalVisit, dbo.Doctor.Name, dbo.DoctorServiceBillDetails.Rate, 
                                      SUM(dbo.DoctorServiceBillDetails.Qty * dbo.DoctorServiceBillDetails.Rate) AS totalAmount, dbo.DoctorServiceBillDetails.ServiceHeadId, dbo.ServiceHeads.ServiceHeadName
                                      FROM dbo.DoctorServiceBillDetails INNER JOIN
                                      dbo.Doctor ON dbo.DoctorServiceBillDetails.DoctorId = dbo.Doctor.DoctorId INNER JOIN
                                      dbo.ServiceHeads ON dbo.DoctorServiceBillDetails.ServiceHeadId = dbo.ServiceHeads.ServiceHeadId
                                      Where dbo.DoctorServiceBillDetails.AdmissionId={0}
                                      GROUP BY dbo.DoctorServiceBillDetails.AdmissionId, dbo.DoctorServiceBillDetails.DoctorId, dbo.Doctor.Name, dbo.DoctorServiceBillDetails.Rate, dbo.DoctorServiceBillDetails.ServiceHeadId, 
                                      dbo.ServiceHeads.ServiceHeadName", _admissionId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMSelectedDoctorService> _reqList = new List<VMSelectedDoctorService>();

                _reqList = new List<VMSelectedDoctorService>(
                  (from dRow in dt.AsEnumerable()
                   select (GetDeliveredConsultancyData(dRow)))
                  );

                return _reqList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<VMIPDInfo> GetCurrentIPDInfoByDept(int _deptId)
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where Status='Cabin' and DeptId={0}", _deptId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        private VMSelectedDoctorService GetDeliveredConsultancyData(DataRow dr)
        {
            VMSelectedDoctorService _consr = new VMSelectedDoctorService();
            _consr.ServiceHeadName = dr["ServiceHeadName"].ToString();
            _consr.DoctorName = dr["Name"].ToString();
            _consr.Rate = Convert.ToDouble(dr["Rate"]);
            _consr.Qty = Convert.ToDouble(dr["totalVisit"]);
            _consr.Amount = Convert.ToDouble(dr["totalAmount"]);

            return _consr;
        }

        public bool SaveHpSubGroup(ServiceSubGroup _ssgroup)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.ServiceSubGroups.Add(_ssgroup);
                entities.SaveChanges();
                return true;
            }
        }

        public ServiceSubGroup GetServiceSubGroupById(int _subGroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.ServiceSubGroups.Where(x=>x.SubGroupId== _subGroupId).FirstOrDefault();
              
            }
        }

        public DataTable PatientInfo(int patientId,object barcodeimg)
        {
            using (DBEntities entities = new DBEntities())
            {
                List<HospitalPatientInfo> _pList = entities.HospitalPatientInfoes.Where(x => x.AdmissionId == patientId).ToList();
                DataTable dt = new DataTable(); //Utility.ToDataTable(_pList, barcodeimg);
                return dt;
            }
        }

        public void UpdateHospitalPatientInfo(HospitalPatientInfo _pInfo)
        {
            try
            {
                using (DBEntities entities = new DBEntities())
                {
                    entities.Entry(_pInfo).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }catch(Exception ex)
            {

            }
        }

        public List<VMHpReturnRequest> GetHpPendingReturnRequestList(int _floorId,int outletId)
        {
            try
            {
                if (_floorId == 0)
                {
                    sql = string.Format(@"SELECT dbo.HpMedicineReturnInednts.ReturnIndentId, dbo.HpMedicineReturnInednts.ReturnIndentBy, dbo.CabinInfoes.CabinNo, dbo.HpMedicineReturnInednts.Status, dbo.HpPatientAccomodationInfoes.Status AS CabinStatus, 
                                         dbo.HpPatientAccomodationInfoes.AllotType, dbo.CabinInfoes.FloorId
                                         FROM   dbo.HpMedicineReturnInednts INNER JOIN
                                         dbo.HospitalPatientInfoes ON dbo.HpMedicineReturnInednts.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                          dbo.HpPatientAccomodationInfoes ON dbo.HospitalPatientInfoes.AdmissionId = dbo.HpPatientAccomodationInfoes.AdmissionId INNER JOIN
                                          dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                          WHERE (dbo.HpMedicineReturnInednts.Status = 'Pending') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed') AND (dbo.HpMedicineReturnInednts.OutletId in ('{0}'))", outletId);
                }
                else
                {
                    sql = string.Format(@"SELECT dbo.HpMedicineReturnInednts.ReturnIndentId, dbo.HpMedicineReturnInednts.ReturnIndentBy, dbo.CabinInfoes.CabinNo, dbo.HpMedicineReturnInednts.Status, dbo.HpPatientAccomodationInfoes.Status AS CabinStatus, 
                                          dbo.HpPatientAccomodationInfoes.AllotType, dbo.CabinInfoes.FloorId
                                          FROM   dbo.HpMedicineReturnInednts INNER JOIN
                                          dbo.HospitalPatientInfoes ON dbo.HpMedicineReturnInednts.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId INNER JOIN
                                          dbo.HpPatientAccomodationInfoes ON dbo.HospitalPatientInfoes.AdmissionId = dbo.HpPatientAccomodationInfoes.AdmissionId INNER JOIN
                                          dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                          WHERE (dbo.HpMedicineReturnInednts.Status = 'Pending') AND (dbo.HpPatientAccomodationInfoes.Status = 'Occupied') AND (dbo.HpPatientAccomodationInfoes.AllotType = 'PatientBed' AND (dbo.HpMedicineReturnInednts.OutletId in ('{0}'))  and dbo.CabinInfoes.FloorId={1}", outletId, _floorId);
                }

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMHpReturnRequest> _reqList = new List<VMHpReturnRequest>();

                _reqList = new List<VMHpReturnRequest>(
                  (from dRow in dt.AsEnumerable()
                   select (GetMedicineReturnDataRow(dRow)))
                  );

                return _reqList;
            }
            catch
            {
                return new List<VMHpReturnRequest>();
            }

        }

        public void UpdateRequisitionProductPartialDeliveryStatus(long _requisitionId, List<PhInvoiceDetail> _inVDetail)
        {
            using (DBEntities entities = new DBEntities())
            {
                List<PhInvoiceDetail> _invdL = _inVDetail.GroupBy(x => x.ProductId).Select(q => q.First()).ToList();

                foreach (PhInvoiceDetail _deliverItem in _invdL)
                {
                    HpMedicineRequisitionDetail _mreqd = this.GetHpMedicineRequisitionDetailByReqAndProductId(_requisitionId, _deliverItem.ProductId);
                    _mreqd.DeliveredQty = _mreqd.Qty;
                    //if (_mreqd.Qty == _deliverItem.Qty)
                    //{
                        _mreqd.Status = RequisitionStatusEnum.Served.ToString();
                    //}else
                    //{
                    //    _mreqd.Status = RequisitionStatusEnum.PartiallyServed.ToString();
                    //}
                    entities.Entry(_mreqd).State = EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        private HpMedicineRequisitionDetail GetHpMedicineRequisitionDetailByReqAndProductId(long _requisitionId, int productId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineRequisitionDetails.Where(x => x.RequisitionId == _requisitionId && x.ProductId== productId).FirstOrDefault();
            }
        }

        public void UpdateRequisitionProductDeliveryStatus(List<PhInvoiceDetail> _invList, List<HpMedicineRequisitionDetail> _reqList)
        {
            using (DBEntities entities = new DBEntities())
            {
               foreach(HpMedicineRequisitionDetail _regItem in _reqList)
               {

                    PhInvoiceDetail _invdetail = _invList.Where(x => x.ProductId == _regItem.ProductId).FirstOrDefault();
                    if (_invdetail != null)
                    {
                        _regItem.DeliveredQty = _invdetail.Qty;
                        if (_regItem.DeliveredQty == _invdetail.Qty)
                        {
                            _regItem.Status = RequisitionStatusEnum.Served.ToString();
                        }
                        else
                        {
                            RequisitionStatusEnum.PartiallyServed.ToString();
                        }



                        entities.Entry(_regItem).State = EntityState.Modified;
                        entities.SaveChanges();
                    }
               }
            }
        }

        public List<HpMedicineRequisitionDetail> GetHpMedicineRequisitionDetailById(long requisitionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineRequisitionDetails.Where(x=>x.RequisitionId== requisitionId).ToList();
            }
        }

        private VMHpReturnRequest GetMedicineReturnDataRow(DataRow dr)
        {
            VMHpReturnRequest pdInfo = new VMHpReturnRequest();
            pdInfo.RturnId = Convert.ToInt64(dr["ReturnIndentId"]);
            pdInfo.CabinNo = dr["CabinNo"].ToString();
            pdInfo.ReturnBy = dr["ReturnIndentBy"].ToString();
            pdInfo.Status = dr["Status"].ToString();
          
            return pdInfo;
        }

        public List<HpRequisitionType> GetRequisitionTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpRequisitionTypes.ToList();
            }
        }
        public List<ServiceHead> GetAllServiceHeadBySubGroupId(int subGroupId)
        {
            using (DBEntities entities = new DBEntities())
            {
                if (subGroupId == 0)
                {
                    return entities.ServiceHeads.ToList();
                }
                else
                {
                    return entities.ServiceHeads.Where(x => x.SubGroupId == subGroupId).ToList();
                }
            }
        }

        public HpPatientAccomodationInfo GetHpPatientCurrentAccomodation(long _admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId ==_admissionId && x.Status.ToLower() == "occupied" && x.AllotType== HpBedAllotTypeEnum.PatientBed.ToString()).FirstOrDefault();
            }
        }

        public void UpdateCurrentAccomodation(HpPatientAccomodationInfo _hpAccomodation)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_hpAccomodation).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public bool SaveServiceHead(ServiceHead _sh)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.ServiceHeads.Add(_sh);
                entities.SaveChanges();
                return true;
            }
        }

        public List<HpMedicineRequisition> GetUnservedRequisitionList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineRequisitions.Where(x => x.Status.ToLower() == "pending").ToList();
            }
        }

        public OperationConsent GetConsentNote()
        {
            using (DBEntities entities = new DBEntities())
            {
               return entities.OperationConsents.Where(x => x.Id == 1).FirstOrDefault();
            }
        }

        public bool IsBillNoAlloted(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                int count = entities.HospitalPatientInfoes.Where(x => x.BillNo == _billNo).ToList().Count();
                if (count > 0) return true;

                return false;
            }
        }

        public bool SaveService(ServiceGroup _pService)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ServiceGroups.Add(_pService);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public ServiceGroup GetServiceById(int sId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceGroups.Where(x => x.GroupId == sId).FirstOrDefault();
            }
        }


        public string GetNextRegNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.ToList().Count().ToString();
            }
        }



        public HospitalPatientInfo GetLastPatientById()
        {
            using (DBEntities entities = new DBEntities())
            {
                var _patient = entities.HospitalPatientInfoes.OrderByDescending(x => x.AdmissionId).FirstOrDefault();
                return _patient;
            }
        }

        public HospitalPatientInfo GetPatientInfoById(long pId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.AdmissionId== pId).FirstOrDefault();
            }
        }

        public HospitalPatientInfo GetFirstPatientById()
        {
            using (DBEntities entities = new DBEntities())
            {
                var _patient = entities.HospitalPatientInfoes.OrderBy(x => x.AdmissionId).FirstOrDefault();
                return _patient;
            }
        }

        public HospitalPatientInfo GetIPDInfoByBillNo(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.BillNo == _billNo).FirstOrDefault();

            }
        }

        public HospitalPatientInfo GetFirstPatientById(long regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.RegNo == regNo).FirstOrDefault();
                
            }
        }

        public int GetNewInvoiceNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.ToList().Count();
            }
        }



        public DataSet GetPatientAdmissionDetails(long _admissionNo)
        {
            sql = string.Format("select * from VWHospitalPatientDetails Where AdmissionId={0}", _admissionNo);


            return null;
        }

        public IList<VMIPDInfo> GetDischargedIPDInfo(DateTime _dtfrm, DateTime _dateto)
        {
            try
            {
                sql = string.Format("select * from VWDischargedPatientDetails Where DischargeDate>='{0}' and DischargeDate<='{1}' order by AdmissionId Desc", _dtfrm, _dateto);  //Discharge Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetDischargeDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        private VMIPDInfo GetDischargeDataTableRow(DataRow dr)
        {

            VMIPDInfo pdInfo = new VMIPDInfo();
            pdInfo.RegNo = Convert.ToInt64(dr["RegNo"]);
            pdInfo.AdmissionId = Convert.ToInt32(dr["AdmissionId"]);
            pdInfo.BillNo = Convert.ToInt64(dr["BillNo"]);
            pdInfo.AddmissionDate = Convert.ToDateTime(dr["AddmissionDate"]);
            pdInfo.AdmTime = dr["admissionTime"].ToString();
            pdInfo.Name = dr["FullName"].ToString();
            pdInfo.BedCabinNo = dr["CabinNo"].ToString();
            pdInfo.AssignedDoctor = dr["AssignedDoctorName"].ToString();
            pdInfo.FatherName = dr["FatherName"].ToString();
            pdInfo.Status = dr["Status"].ToString();
            pdInfo.DischargeDate= Convert.ToDateTime(dr["DischargeDate"]);
            pdInfo.DischargeTime = dr["DischargeTime"].ToString();
            return pdInfo;
        }

        public Task<List<VMIPDInfo>> GetCurrentIPDInfoForDischarge()
        {

            return Task.Run(() =>
            {
                try
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and  Status<>'DisCharged' and CabinStatus='Occupied' order by AdmissionId Desc");  // Current Active Patient List
                    con = new SqlConnection();
                    con.ConnectionString = Utility.GetLegacyDbConnectionString();
                    con.Open();
                    da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();

                    List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                    listhp = dt.AsEnumerable().Select(dr => new VMIPDInfo() {

                        RegNo = Convert.ToInt64(dr["RegNo"]),
                        AdmissionId = Convert.ToInt32(dr["AdmissionId"]),
                        BillNo = Convert.ToInt64(dr["BillNo"]),
                        AddmissionDate = Convert.ToDateTime(dr["AddmissionDate"]),
                        AdmTime = dr["admissionTime"].ToString(),
                        Name = dr["FullName"].ToString(),
                        BedCabinNo = dr["CabinNo"].ToString(),
                        AssignedDoctor = dr["AssignedDoctorName"].ToString(),
                        FatherName = dr["FatherName"].ToString(),
                        Status = dr["Status"].ToString(),
                        RefDoctor = dr["RefDoctorName"].ToString(),
                        Age = dr["Age"].ToString(),
                        Gender = dr["Sex"].ToString(),
                        PackageId = Convert.ToInt32(dr["PackageId"]),
                        MobileNo = dr["MobileNo"].ToString(),
                        PatientAddress= dr["PatientAddress"].ToString(),
                        CPAddress = dr["CPAddress"].ToString(),
                        CPMobile = dr["CPMobile"].ToString(),
                        Address = dr["Address"].ToString()

                    }).ToList();
                       
                      

                    return listhp;
                }
                catch (Exception ex)
                {
                    return new List<VMIPDInfo>();
                }
            });
        }

      

    public async Task<List<VMIPDInfo>> GetCurrentIPDInfo()
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and  Status<>'DisCharged' and CabinStatus='Occupied' order by AdmissionId Desc");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return await Task.FromResult(listhp);
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }


        public IList<VMIPDInfo> GetCurrentIPDAndOPDInfo()
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2  Where  Status<>'DisCharged' and CabinStatus='Occupied' order by AdmissionId Desc");  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }


        public IList<VMIPDInfo> GetCurrentIPDInfoBySearchParameter(string _searchPrefix, string type)
        {
            try
            {
                if (type.ToLower() == "pname")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  DeptId<>15 and  Status<>'DisCharged' and CabinStatus='Occupied' and FullName like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "cabin")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where  DeptId<>15 and Status<>'DisCharged' and CabinStatus='Occupied' and CabinNo like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "admid")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and  Status<>'DisCharged' and CabinStatus='Occupied' and BillNo like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "assigndoc")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and Status<>'DisCharged' and CabinStatus='Occupied' and AssignedDoctorName like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "mobileno")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and Status<>'DisCharged' and CabinStatus='Occupied' and CPMobile like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else if (type.ToLower() == "address")
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 Where DeptId<>15 and Status<>'DisCharged' and CabinStatus='Occupied' and CPAddress like '%{0}%'", _searchPrefix);  // Current Active Patient List
                }
                else
                {
                    sql = string.Format("select * from VWHospitalPatientDetails_2 WhereDeptId<>15 and  Status<>'DisCharged' and CabinStatus='Occupied'");  // Current Active Patient List
                }
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public void SaveHpPatientAccomadationInfo(HpPatientAccomodationInfo _currentAccomodation)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpPatientAccomodationInfoes.Add(_currentAccomodation);
                entities.SaveChanges();
               

            }
        }

        public long SaveDoctorServiceBill(HpDoctorServiceBill _hpsb)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.HpDoctorServiceBills.Add(_hpsb);
                entities.SaveChanges();
                return _hpsb.DSbId;

            }
        }

        private VMIPDInfo GetTemplateDataTableRow(DataRow dr)
        {
            
            VMIPDInfo pdInfo = new VMIPDInfo();
            pdInfo.RegNo = Convert.ToInt64(dr["RegNo"]);
            pdInfo.AdmissionId = Convert.ToInt64(dr["AdmissionId"]);
            pdInfo.BillNo = Convert.ToInt64(dr["BillNo"]);
            pdInfo.AddmissionDate = Convert.ToDateTime(dr["AddmissionDate"]);
            pdInfo.AdmTime = dr["admissionTime"].ToString();
            pdInfo.Name = dr["FullName"].ToString();
            pdInfo.BedCabinNo = dr["CabinNo"].ToString();
            pdInfo.CabinId= Convert.ToInt32(dr["CabinId"]);
            pdInfo.AssignedDoctor = dr["AssignedDoctorName"].ToString();
            pdInfo.FatherName = dr["FatherName"].ToString();
            pdInfo.Status = dr["Status"].ToString();
            pdInfo.RefDoctor = dr["RefDoctorName"].ToString();
            pdInfo.Age = dr["Age"].ToString();
            pdInfo.Gender = dr["Sex"].ToString();
            if (dr["RecommededDateForDischarge"] != DBNull.Value)
            {
                pdInfo.RecommededDateForDischarge = Convert.ToDateTime(dr["RecommededDateForDischarge"]).ToString("dd/MM/yyyy");
            }
            else
            {
                pdInfo.RecommededDateForDischarge = "";
            }

            if (dr["RecommededTimeForDischarge"] != DBNull.Value)
            {
                pdInfo.RecommededTimeForDischarge = dr["RecommededTimeForDischarge"].ToString();
            }
            else
            {
                pdInfo.RecommededTimeForDischarge = "";
            }

            if (dr["DischargeRecommendationConfirmedby"] != DBNull.Value)
            {
                pdInfo.DischargeRecommendationConfirmedby = dr["DischargeRecommendationConfirmedby"].ToString();
            }
            else
            {
                pdInfo.DischargeRecommendationConfirmedby = "";
            }

            pdInfo.PackageId= Convert.ToInt32(dr["PackageId"]);
            pdInfo.DeptId = Convert.ToInt32(dr["DeptId"]); 

            if (dr["CPMobile"] != DBNull.Value)
            {
                pdInfo.MobileNo = dr["CPMobile"].ToString();

            }
            else
            {
                pdInfo.MobileNo = "";
            }

            //if (dr["CPAddress"] != DBNull.Value)
            //{
            //    pdInfo.CPAddress = dr["CPAddress"].ToString();

            //}
            //else
            //{
                pdInfo.CPAddress = "";
            //}

            
            return pdInfo;
        }

        private string GetOccupiedCabin(long _admissionId)
        {
            string _strCabin = string.Empty;
            List<HpPatientAccomodationInfo> _accomList = GetOccupiedCabinList(_admissionId);
            foreach(HpPatientAccomodationInfo item in _accomList)
            {
                if (String.IsNullOrEmpty(_strCabin)) {
                    _strCabin = GetCabin(item.CabinId);
                }else
                {
                    _strCabin = _strCabin+", "+ GetCabin(item.CabinId);
                } 
            }

            return _strCabin;
        }

        private string GetCabin(int cabinId)
        {
            CabinInfo _cabin = new HospitalCabinBedRepository().GetCabinInfoId(cabinId);
            
            return _cabin.CabinNo;
        }

        private List<HpPatientAccomodationInfo> GetOccupiedCabinList(long _admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x=>x.AdmissionId== _admissionId && x.Status.ToLower()=="occupied").ToList();
            }
        }

        public List<VMIPDInfo> GetCurrentOTOrPostOperativePatients(int _floorId, string otOrpostOperative)
        {
            try
            {

                sql = string.Format("select * from VWHospitalPatientDetails_2 Where Status in ('Cabin') and FloorId={0}  union all  select * from VWHospitalPatientDetails_2 Where Status in ('{1}')", _floorId, otOrpostOperative);  // Current Active Patient List

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }


        public List<VMIPDInfo> GetCurrentIPDInfoByFloor(int _floorId)
        {
            try
            {
                sql = string.Format("select * from VWHospitalPatientDetails_2 Where Status='Cabin' and FloorId={0}", _floorId);  // Current Active Patient List
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                con.Close();

                List<VMIPDInfo> listhp = new List<VMIPDInfo>();

                listhp = new List<VMIPDInfo>(
                  (from dRow in dt.AsEnumerable()
                   select (GetTemplateDataTableRow(dRow)))
                  );

                return listhp;
            }
            catch (Exception ex)
            {
                return new List<VMIPDInfo>();
            }
        }

        public bool UpdateAllotedCabin(HpPatientAccomodationInfo _pAccomInfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_pAccomInfo).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<FloorInfo> GetFloors()
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.FloorInfos.ToList();
            }
        }
        public long SaveRequisition(HpMedicineRequisition _hpMReq)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.HpMedicineRequisitions.Add(_hpMReq);
                    entities.SaveChanges();
                    return _hpMReq.RequisitionId;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public Model.Hospital.ServiceHead GetServiceHeadById(int headId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.ServiceHeads.Where(x=>x.ServiceHeadId==headId).FirstOrDefault();
            }
        }

        public long SaveOTSchedule(Model.Hospital.OTSchedule _schedule)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.OTSchedules.Add(_schedule);
                    entities.SaveChanges();
                    return _schedule.OTId;
                }
                catch(Exception ex)
                {
                    return 0;
                }
            }
        }

        public HpMedicineRequisition GetHpMedicineRequisitionByReqId(long _reqId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpMedicineRequisitions.Where(x => x.RequisitionId == _reqId).FirstOrDefault();
            }
        }
        public bool SaveRequisitionDetails(List<HpMedicineRequisitionDetail> _reqDetailsList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.HpMedicineRequisitionDetails.AddRange(_reqDetailsList);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void UpdateRequisition(HpMedicineRequisition _Mreq)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_Mreq).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
        public List<VMRequisitionList> GetHpMedicineRequisitionDetailByReqId(long requisitionId, int _outLetId)
        {
            try
            {
                sql = string.Format(@"Exec [dbo].[spGetRequisitionData] {0},{1}", requisitionId, _outLetId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


                List<VMRequisitionList> listhp = new List<VMRequisitionList>();

                listhp = new List<VMRequisitionList>(
                  (from dRow in dt.AsEnumerable()
                   select (GetRequisitionDataRow(dRow, _outLetId)))
                  );

                return listhp;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private VMRequisitionList GetRequisitionDataRow(DataRow dr, int _outLetId)
        {
            double _stockAvail = 0; //GetAvailableStock(Convert.ToInt32(dr["ProductId"]), _outLetId);

            VMRequisitionList pdInfo = new VMRequisitionList();
            pdInfo.RequisitionId= Convert.ToInt64(dr["RequisitionId"]);
         
            pdInfo.ProductId = Convert.ToInt32(dr["ProductId"]);
            pdInfo.GenericId = Convert.ToInt32(dr["GenericId"]);
            pdInfo.BrandName = dr["BrandName"].ToString();
            pdInfo.OutLetId = _outLetId;
            pdInfo.ReqQty = Convert.ToDouble(dr["ReqQty"]);
            if (!dr.IsNull("AvailQty"))
            {
                _stockAvail = Convert.ToDouble(dr["AvailQty"]);
                pdInfo.StockAvailable = Convert.ToDouble(dr["AvailQty"]);
            }else
            {
                pdInfo.StockAvailable = 0;
            }

            pdInfo.PurchasePrice = Convert.ToDouble(dr["PurchasePrice"]);
            pdInfo.SalePrice = Convert.ToDouble(dr["SalePrice"]);
           
            if (Convert.ToDouble(dr["ReqQty"]) <= _stockAvail)
            {
                pdInfo.IsStockShort = false;
            }
            else
            {
                pdInfo.IsStockShort = true;
            }

            pdInfo.ItemDeliveryStatus= dr["Status"].ToString();

            if (!dr.IsNull("ReplaceRemarks"))
            {
                pdInfo.ReplaceRemarks = dr["ReplaceRemarks"].ToString();
            }else
            {
                pdInfo.ReplaceRemarks = "";
            }
               

            return pdInfo;
        }

        private double GetAvailableStock(int _ProductId, int _outLetId)
        {

            double _stock = 0;
            try
            {
                sql = string.Format("select Sum(CurrentStock) as tStockAvail from PhStockInfoes Where ProductId={0} and OutLetId={1}", _ProductId, _outLetId);
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                cmd = new SqlCommand(sql,con);
                _stock = Convert.ToDouble(cmd.ExecuteScalar());
                return _stock;
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

        public List<VMedicineRequisition> GetHpPendingRequisitionList(int _floorId,int _outletId)
        {
            try
            {
                if (_floorId == 0)
                {
                    sql = string.Format(@"SELECT dbo.HpMedicineRequisitions.*,
                                             IsNull(dbo.HospitalPatientInfoes.BillNo,0) BillNo,  
                                             CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN dbo.GetRequestedOutlet(HpMedicineRequisitions.RequisitionBy) ELSE IsNull(dbo.CabinInfoes.CabinNo,'') END as CabinNo, 
                                             CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN '' ELSE IsNull(dbo.FloorInfoes.Name,'') END as Name
                                             FROM  dbo.HpMedicineRequisitions Left JOIN
                                             dbo.HospitalPatientInfoes ON dbo.HpMedicineRequisitions.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId Left JOIN
                                             dbo.CabinInfoes ON dbo.HospitalPatientInfoes.WardOrCabinId = dbo.CabinInfoes.CabinId Left JOIN
                                             dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId Where HpMedicineRequisitions.Status in ('Pending','PartiallyServed')
                                             and HpMedicineRequisitions.OutletId in ({0},'3') and  HpMedicineRequisitions.RequisitionType in ('ForPatient')", _outletId);
                }else
                {
                    sql = string.Format(@"SELECT dbo.HpMedicineRequisitions.*,
                                            IsNull(dbo.HospitalPatientInfoes.BillNo,0) BillNo,  
                                            CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN dbo.GetRequestedOutlet(HpMedicineRequisitions.RequisitionBy) ELSE IsNull(dbo.CabinInfoes.CabinNo,'') END as CabinNo, 
                                            CASE WHEN dbo.HpMedicineRequisitions.AdmissionId=0  THEN '' ELSE IsNull(dbo.FloorInfoes.Name,'') END as Name 
                                            FROM  dbo.HpMedicineRequisitions Left JOIN
                                            dbo.HospitalPatientInfoes ON dbo.HpMedicineRequisitions.AdmissionId = dbo.HospitalPatientInfoes.AdmissionId Left JOIN
                                            dbo.CabinInfoes ON dbo.HospitalPatientInfoes.WardOrCabinId = dbo.CabinInfoes.CabinId Left JOIN
                                             dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId Where HpMedicineRequisitions.Status in ('Pending','PartiallyServed') 
                                            and HpMedicineRequisitions.RequisitionType in ('ForPatient') and HpMedicineRequisitions.OutletId in ({0},'3') and dbo.CabinInfoes.FloorId={1}", _outletId,_floorId);
                }

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMedicineRequisition> _reqList = new List<VMedicineRequisition>();

                _reqList = new List<VMedicineRequisition>(
                  (from dRow in dt.AsEnumerable()
                   select (GetMedicineRequisitionDataRow(dRow)))
                  );

                return _reqList;
            }
            catch(Exception ex)
            {
                return new List<VMedicineRequisition>();
            }


        }

        private VMedicineRequisition GetMedicineRequisitionDataRow(DataRow dr)
        {

            VMedicineRequisition req = new VMedicineRequisition();
            req.RequisitionId = Convert.ToInt64(dr["RequisitionId"]);
            req.RequisitionBy = dr["RequisitionBy"].ToString();
            if (Convert.ToInt64(dr["AdmissionId"]) == 0)
            {
                req.CabinNo = dr["CabinNo"].ToString();
            }
            else
            {
                req.CabinNo = GetCabinNo(Convert.ToInt64(dr["AdmissionId"]));
            }
           
            req.AdmissionId = Convert.ToInt64(dr["AdmissionId"]);
            req.OutletId = Convert.ToInt32(dr["OutletId"]);
            req.Floor = dr["Name"].ToString();
            req.RequisitionStatus = dr["Status"].ToString();
            

            return req;
        }

        private string GetCabinNo(long _admissionId)
        {
            if (_admissionId == 0) return "OT-INDENT";
            HpPatientAccomodationInfo _accomInfo = new HospitalCabinBedRepository().GetOccupiedCabinByPatient(_admissionId);

            if (_accomInfo != null)
            {
                CabinInfo _Cabin = new HospitalCabinBedRepository().GetCabinInfoId(_accomInfo.CabinId);

                return _Cabin.CabinNo;
            }

            return "";
        }

        public bool SaveOTExecutioDetails(List<Model.Hospital.OTExecutionDetail> _otelist)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.OTExecutionDetails.AddRange(_otelist);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveServiceBillDetails(List<Model.Hospital.ServiceBillDetail> _sbillList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.ServiceBillDetails.AddRange(_sbillList);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveDoctorServiceDetails(List<Model.Hospital.DoctorServiceBillDetail> _dsblist)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.DoctorServiceBillDetails.AddRange(_dsblist);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public HospitalPatientInfo GetLatestAdmittedPatient()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.SqlQuery("Select * from HospitalPatientInfoes Where AdmissionId=(Select Max(AdmissionId) from HospitalPatientInfoes)").FirstOrDefault();
            }
        }

        public HospitalPatientInfo GetHospitalPatientByBillNo(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.BillNo == _billNo).FirstOrDefault();
             //   return entities.HospitalPatientInfos.Where(x => x.BillNo == _billNo && x.Status.ToLower() != "discharged").FirstOrDefault();

            }
        }

        public HospitalPatientInfo GetHospitalPatientByBillNoAny(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HospitalPatientInfoes.Where(x => x.BillNo == _billNo).FirstOrDefault();
            }
        }
    }
}
