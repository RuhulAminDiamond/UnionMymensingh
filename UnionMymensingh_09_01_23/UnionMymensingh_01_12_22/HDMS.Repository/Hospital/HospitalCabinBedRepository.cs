using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.Hospital;
using System.Data.Entity;
using HDMS.Model.Hospital.ViewModel;
using System.Data.SqlClient;
using HDMS.Common.Utils;
using System.Data;

namespace HDMS.Repository.Hospital
{
    public class HospitalCabinBedRepository
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        string sql = string.Empty;
        public List<CabinInfo> GetCabinList()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.CabinInfos.ToList();
            }
        }

        public HpPatientAccomodationType GetCabinServiceHeadId(int accomodationTypeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationTypes.Where(x => x.AccomodationTypeId == accomodationTypeId).FirstOrDefault();
            }
        }

        public List<WardInfo> GetWardList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardInfos.ToList();
            }
        }

        public List<WardBedInfo> GetWardBedList(int _wardId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardBedInfos.Where(x=>x.WardId== _wardId).ToList();
            }
        }

        public bool UpdateHpDepartment(HpDepartment _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.Entry(_dept).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public WardBedInfo GetWardBedInfo(int wardOrCabinId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardBedInfos.Where(x => x.WardBedId == wardOrCabinId).FirstOrDefault();
            }
        }

        public List<HpPatientAccomodationType> GetHpAccomodationTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationTypes.ToList();
            }
        }

        public List<HpDepartment> GetDeptList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpDepartments.ToList();
            }
        }

        public bool SaveHpDepartment(HpDepartment _hpdept)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.HpDepartments.Add(_hpdept);
                entities.SaveChanges();
                return true;
            }
        }

        public List<VMFreeCabinList> GetFreeCabinListByFloor()
        {
            try
            {

              
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"Select f.[Name] as FloorNo, dbo.GetFreeCabinsByFloor(f.FloorId) FreeCabins, Count(cb.CabinId) as TotalFree
                                      from FloorInfoes f join CabinInfoes cb on f.FloorId=cb.FloorId
                                      Where cb.IsBooked=0
                                      group by f.FloorId,f.[Name]");
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMFreeCabinList> _cabinList = new List<VMFreeCabinList>();


                _cabinList = new List<VMFreeCabinList>(
                    (from dRow in dt.AsEnumerable()
                     select (GetFreeCabinDataTableRow(dRow)))
                    );

                return _cabinList;


            }
            catch (Exception ex)
            {
                return new List<VMFreeCabinList>();
            }
        }

        private VMFreeCabinList GetFreeCabinDataTableRow(DataRow dr)
        {
            VMFreeCabinList _fc = new VMFreeCabinList();
            _fc.FloorNo = dr["FloorNo"].ToString();
            _fc.FreeCabins = dr["FreeCabins"].ToString();
            _fc.TotalFree = Convert.ToInt32(dr["TotalFree"]);

            return _fc;
        }

        public List<VMCabinInfo> GetVMAllCabinList()
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.CabinInfoes.CabinId, dbo.CabinInfoes.CabinNo, dbo.CabinInfoes.Description, dbo.CabinInfoes.Rent, dbo.CabinInfoes.IsBooked, dbo.FloorInfoes.Name AS Floor, dbo.CabinInfoes.FloorId, 
                                      CabinInfoes.DeptId,HpDepartments.Name DeptName, dbo.HpPatientAccomodationTypes.AccomodationType, dbo.CabinInfoes.AccomodationTypeId
                                      FROM dbo.CabinInfoes INNER JOIN
                                      dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId
									  Left join HpDepartments on HpDepartments.DeptId=CabinInfoes.DeptId INNER JOIN
                                      dbo.HpPatientAccomodationTypes ON dbo.CabinInfoes.AccomodationTypeId = dbo.HpPatientAccomodationTypes.AccomodationTypeId");
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinInfo> _cabinList = new List<VMCabinInfo>();


                _cabinList = new List<VMCabinInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetCabinDataTableRow(dRow)))
                    );

                return _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public IList<VMCabinInfo> GetVMExtraCabinList(string _type)
        {
            try
            {

                long _patientId = 0;
                long.TryParse(_type, out _patientId);

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.CabinInfoes.CabinId, dbo.CabinInfoes.CabinNo, dbo.CabinInfoes.Description, dbo.CabinInfoes.Rent, dbo.CabinInfoes.IsBooked, dbo.FloorInfoes.Name AS Floor, dbo.CabinInfoes.FloorId,  HpDepartments.DeptId,  HpDepartments.Name AS DeptName,
                                      dbo.HpPatientAccomodationTypes.AccomodationType, dbo.CabinInfoes.AccomodationTypeId
                                      FROM dbo.CabinInfoes INNER JOIN
                                      dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId INNER JOIN
									  HpDepartments oN CabinInfoes.DeptId=HpDepartments.DeptId INNER JOIN
                                      dbo.HpPatientAccomodationTypes ON dbo.CabinInfoes.AccomodationTypeId = dbo.HpPatientAccomodationTypes.AccomodationTypeId
									  Where CabinId in (Select CabinId from HpPatientAccomodationInfoes where AdmissionId={0} and HpPatientAccomodationInfoes.AllotType='ExtraBed')", _patientId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinInfo> _cabinList = new List<VMCabinInfo>();


                _cabinList = new List<VMCabinInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetCabinDataTableRow(dRow)))
                    );

                return _cabinList;


            }
            catch (Exception ex)
            {
                return new List<VMCabinInfo>();
            }

            //return new List<VMCabinInfo>();
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetailForCurrentOccupation(DateTime _admDate)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantDetails.Where(x=>x.StayingDate> _admDate && x.OccupationStatus.ToLower()== "occupied" || x.OccupationStatus.ToLower() == "release").ToList();
            }
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetailForExtraOccupation()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantDetails.Where(x=>x.OccupationStatus.ToLower() == "extrarelease").OrderBy(y=>y.SDId).ToList();
            }
        }

        public HpCabinChargeSegmantDetail GetCabinChargeSegmantDetailByDate(DateTime _date)
        {
            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"SELECT dbo.HpCabinChargeSegmantDetails.SDId, dbo.HpCabinChargeSegmantDetails.SMId, dbo.HpCabinChargeSegmantDetails.BookOrder, dbo.HpCabinChargeSegmantDetails.AdmissionId, dbo.HpCabinChargeSegmantDetails.ServiceHeadId,
                                 dbo.HpCabinChargeSegmantDetails.AccomodationTypeId,dbo.HpCabinChargeSegmantDetails.CabinId, dbo.HpCabinChargeSegmantDetails.CabinNo, dbo.HpCabinChargeSegmantDetails.Rent, dbo.HpCabinChargeSegmantDetails.StayingDate, 
                                 dbo.HpCabinChargeSegmantDetails.IsAdmissionDay, dbo.HpCabinChargeSegmantDetails.OccupationStatus
                                 FROM dbo.HpCabinChargeSegmantDetails INNER JOIN
                                 dbo.CabinInfoes ON dbo.HpCabinChargeSegmantDetails.CabinId = dbo.CabinInfoes.CabinId
                                 WHERE (dbo.HpCabinChargeSegmantDetails.StayingDate = '{0}') AND  (dbo.HpCabinChargeSegmantDetails.IsAdmissionDay = 'false')  AND (dbo.CabinInfoes.AccomodationTypeId IN (2, 3, 4))", _date);

                var segmantdata = entities.HpCabinChargeSegmantDetails.SqlQuery(sql).FirstOrDefault();

                if (segmantdata == null)
                {
                    return entities.HpCabinChargeSegmantDetails.Where(x => x.StayingDate == _date && x.IsAdmissionDay == false && x.OccupationStatus.ToLower() != "extrarelease").OrderByDescending(y => y.SDId).FirstOrDefault();

                } else
                {
                    return segmantdata;
                }
             }
        }

        public HpCabinChargeSegmantDetail GetAdmissionDayCabinChargeSegmantDetail()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantDetails.Where(x=>x.IsAdmissionDay==true).OrderByDescending(z=>z.BookOrder).FirstOrDefault();
            }
        }

        public List<CabinInfo> GetDeptWiseFreeAccomList(int accomodationTypeId, int deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CabinInfos.Where(x => x.IsBooked == false && x.DeptId== deptId).ToList();
            }
        }

        public List<HpCabinChargeSegmantDetail> GetCabinChargeSegmantDetail()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantDetails.ToList();
            }
        }

        public HpCabinChargeSegmantMaster GetCabinChargeSegmantMaster()
        {
            using (DBEntities entities=new DBEntities())
            {
                return entities.HpCabinChargeSegmantMasters.FirstOrDefault();
            }
        }

        public VMCabinAccomodationInfo GetExtraBedReleasedAccomInfo(long admissionId, DateTime _datetime)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT  dbo.HpPatientAccomodationInfoes.AccomId, dbo.HpPatientAccomodationInfoes.AdmissionId, dbo.HpPatientAccomodationInfoes.AccomodateDate,dbo.HpPatientAccomodationInfoes.AccomodateTime,HpPatientAccomodationInfoes.ReleaseDate,HpPatientAccomodationInfoes.ReleaseTime, dbo.HpPatientAccomodationInfoes.CabinId, dbo.CabinInfoes.CabinNo, 
                                      dbo.CabinInfoes.Rent,dbo.CabinInfoes.AccomodationTypeId
                                      FROM  dbo.HpPatientAccomodationInfoes INNER JOIN
                                      dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                      where  AdmissionId={0} and AccomodateDate='{1}'  and AllotType='ReleasedAsEB'
                                      and dbo.HpPatientAccomodationInfoes.AccomId in 
                                      (
                                         SELECT  min(dbo.HpPatientAccomodationInfoes.AccomId)
                                         FROM      dbo.HpPatientAccomodationInfoes INNER JOIN
                                         dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                         where AdmissionId={0} and AccomodateDate='{1}' and AllotType='ReleasedAsEB'  and dbo.CabinInfoes.Rent in 
                                         (
                                            SELECT        min(dbo.CabinInfoes.Rent)
                                            FROM            dbo.HpPatientAccomodationInfoes INNER JOIN
                                            dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                            where  AdmissionId={0} and AccomodateDate='{1}' and AllotType='ReleasedAsEB'
                                         )
                                      )", admissionId, _datetime.Date);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinAccomodationInfo> _accomList = new List<VMCabinAccomodationInfo>();


                _accomList = new List<VMCabinAccomodationInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccomodationDataTableRow(dRow)))
                    );

                return _accomList.FirstOrDefault();// _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public HpCabinChargeSegmantDetail GetExtraCabinChargeSegmantDetailByDate(DateTime _date)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantDetails.Where(x => x.StayingDate == _date && x.OccupationStatus.ToLower() == "extrarelease").OrderByDescending(y => y.SDId).FirstOrDefault();
            }
        }

        public HpCabinChargeSegmantMaster GetHpCabinChargeMasterSegmant()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpCabinChargeSegmantMasters.FirstOrDefault();
            }
        }

        public List<HpPatientAccomodationInfo> GetHpExtraAccomodationListByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId).Where(y => y.AllotType.ToLower() == "releasedaseb" || y.AllotType.ToLower() == "extrabed").OrderBy(y => y.AccomId).ToList();
            }
        }

        public void SaveHpCabinChargeSegmantDetail(List<HpCabinChargeSegmantDetail> ccgList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpCabinChargeSegmantDetails.AddRange(ccgList);
                entities.SaveChanges();
               
            }
        }

        public long SaveHpCabinChargeSegmantMaster(HpCabinChargeSegmantMaster _cabinChargeMaster)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HpCabinChargeSegmantMasters.Add(_cabinChargeMaster);
                entities.SaveChanges();
                return _cabinChargeMaster.SMId;
            }
        }

        public List<HpPatientAccomodationInfo> GetHpAccomodationListByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x =>x.AdmissionId== admissionId).Where(y=> y.AllotType.ToLower() == "releasedastb" || y.AllotType.ToLower() == "patientbed").OrderBy(y => y.AccomId).ToList();
            }
        }

        public List<VMCabinAccomodationInfo> GetOccupiedExtracabin(long admissionId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.HpPatientAccomodationInfoes.AdmissionId, dbo.HpPatientAccomodationInfoes.AccomodateDate,AccomodateTime,HpPatientAccomodationInfoes.ReleaseDate,HpPatientAccomodationInfoes.ReleaseTime, dbo.HpPatientAccomodationInfoes.CabinId, dbo.CabinInfoes.CabinNo, 
                         dbo.CabinInfoes.Rent,dbo.CabinInfoes.AccomodationTypeId FROM dbo.HpPatientAccomodationInfoes INNER JOIN
                         dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                         where  AdmissionId={0}  and AllotType='ExtraBed'", admissionId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinAccomodationInfo> _accomList = new List<VMCabinAccomodationInfo>();


                _accomList = new List<VMCabinAccomodationInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccomodationDataTableRow(dRow)))
                    );

                return _accomList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public List<DateTime> GetDistinctEBVacantedDateByPatient(long admissionId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT DISTINCT AccomodateDate FROM  HpPatientAccomodationInfoes
                                      WHERE (AdmissionId = {0}) AND (AllotType IN ('ReleasedAsEB'))", admissionId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<DateTime> _dateList = new List<DateTime>();


                _dateList = new List<DateTime>(
                    (from dRow in dt.AsEnumerable()
                     select (GetDateDataTableRow(dRow)))
                    );

                return _dateList;// _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public List<VMCabinAccomodationInfo> GetBedTransferredAccomInfo(long admissionId, DateTime _datetime)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.HpPatientAccomodationInfoes.AccomId,dbo.HpPatientAccomodationInfoes.AdmissionId, dbo.HpPatientAccomodationInfoes.AccomodateDate,dbo.HpPatientAccomodationInfoes.AccomodateTime,HpPatientAccomodationInfoes.ReleaseDate,HpPatientAccomodationInfoes.ReleaseTime, dbo.HpPatientAccomodationInfoes.CabinId, dbo.CabinInfoes.CabinNo, dbo.CabinInfoes.AccomodationTypeId,
                                      dbo.CabinInfoes.Rent
                                      FROM  dbo.HpPatientAccomodationInfoes INNER JOIN
                                      dbo.CabinInfoes ON dbo.HpPatientAccomodationInfoes.CabinId = dbo.CabinInfoes.CabinId
                                      where  AdmissionId={0} and AccomodateDate='{1}'  and AllotType='ReleasedAsTB' order by dbo.HpPatientAccomodationInfoes.AccomId", admissionId, _datetime.Date);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinAccomodationInfo> _accomList = new List<VMCabinAccomodationInfo>();


                _accomList = new List<VMCabinAccomodationInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetAccomodationDataTableRow(dRow)))
                    );

                return _accomList;// _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private VMCabinAccomodationInfo GetAccomodationDataTableRow(DataRow dr)
        {
            VMCabinAccomodationInfo _accom = new VMCabinAccomodationInfo();
            _accom.BookingOrder = Convert.ToInt64(dr["AccomId"]);
            _accom.AdmissionId = Convert.ToInt64(dr["AdmissionId"]);
            _accom.CabinId = Convert.ToInt32(dr["CabinId"]);
            _accom.CabinNo = dr["CabinNo"].ToString();
            _accom.AccomodationTypeId = Convert.ToInt32(dr["AccomodationTypeId"]);
            _accom.Rent = Convert.ToInt32(dr["Rent"]);
            _accom.AccomodateDate= Convert.ToDateTime(dr["AccomodateDate"]);
            _accom.AccomodateTime = dr["AccomodateTime"].ToString();
            if (dr["ReleaseDate"] == DBNull.Value)
            {


            }else
            {
                _accom.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
            }

            if (dr["ReleaseTime"] == DBNull.Value)
            {
                _accom.ReleaseTime = "";
            }
            else
            {
                _accom.ReleaseTime = dr["ReleaseTime"].ToString();
            }

            return _accom;
        }

        public List<DateTime> GetDistinctVacantedDateByPatient(long admissionId)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT DISTINCT AccomodateDate FROM  HpPatientAccomodationInfoes
                                      WHERE (AdmissionId = {0}) AND (AllotType IN ('ReleasedAsTB')) order by AccomodateDate", admissionId);
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<DateTime> _dateList = new List<DateTime>();


                _dateList = new List<DateTime>(
                    (from dRow in dt.AsEnumerable()
                     select (GetDateDataTableRow(dRow)))
                    );

                return _dateList;// _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private DateTime GetDateDataTableRow(DataRow dr)
        {
            return Convert.ToDateTime(dr["AccomodateDate"]);
        }

        public List<CabinInfo> GetFreeCabinList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CabinInfos.Where(x => x.IsBooked == false).ToList();
            }
        }

        public List<VMCabinInfo> GetVMCabinList()
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT dbo.CabinInfoes.CabinId, dbo.CabinInfoes.CabinNo, dbo.CabinInfoes.Description, dbo.CabinInfoes.Rent, dbo.CabinInfoes.IsBooked, dbo.FloorInfoes.Name AS Floor, dbo.CabinInfoes.FloorId, 
                                      CabinInfoes.DeptId,HpDepartments.Name DeptName,dbo.HpPatientAccomodationTypes.AccomodationType, dbo.CabinInfoes.AccomodationTypeId
                                      FROM dbo.CabinInfoes INNER JOIN
                                      dbo.FloorInfoes ON dbo.CabinInfoes.FloorId = dbo.FloorInfoes.FloorId INNER JOIN
                                      dbo.HpPatientAccomodationTypes ON dbo.CabinInfoes.AccomodationTypeId = dbo.HpPatientAccomodationTypes.AccomodationTypeId
									  Inner join HpDepartments on  dbo.CabinInfoes.DeptId=HpDepartments.DeptId
									   Where  dbo.CabinInfoes.IsBooked=0");
                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMCabinInfo> _cabinList = new List<VMCabinInfo>();


                _cabinList = new List<VMCabinInfo>(
                    (from dRow in dt.AsEnumerable()
                     select (GetCabinDataTableRow(dRow)))
                    );

                return _cabinList;


            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public HpPatientAccomodationInfo GetReleasedAsPBCabinByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId && x.Status.ToLower() == "vacant" && x.AllotType.ToLower() == "releasedaspb").FirstOrDefault();
            }
        }

        public HpPatientAccomodationInfo GetExtraCabinByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId && x.Status.ToLower() == "occupied" && x.AllotType.ToLower() == "extrabed").FirstOrDefault();
            }
        }

        public FloorInfo GetFloorById(int floorId)
        {
            using (DBEntities entities = new DBEntities())
            {
                 return entities.FloorInfos.Where(x => x.FloorId == floorId).FirstOrDefault();
            }
        }

        public List<HpPatientAccomodationInfo> GetHpOccupiedCabinListByAdmisissionId(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId && x.Status.ToLower()== "occupied").ToList();
            }
        }

        public bool ReleaseExtaCabin(long admissionId, int _cabinId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format("Update HpPatientAccomodationInfoes Set Status='Vacant', AllotType='Released' Where AdmissionId={0} and CabinId={1} and AllotType='ExtraBed'", admissionId, _cabinId);
                    cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void UpdateAccomodationInfoEF(HpPatientAccomodationInfo accomObj)
        {
            using(DBEntities entities=new DBEntities())
            {
                entities.Entry(accomObj).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void UpdateAccomodationInfo(long admissionId)
        {
            using (SqlConnection conn=new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format("Update HpPatientAccomodationInfoes Set Status='Vacant', AllotType='Released' Where AdmissionId={0}", admissionId);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<HpPatientAccomodationInfo> GetExtraCabinListByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.HpPatientAccomodationInfoes.Where(x => x.AdmissionId == admissionId && x.Status.ToLower() == "occupied" && x.AllotType.ToLower() == "extrabed").ToList();
            }
        }

        public HpPatientAccomodationInfo GetOccupiedCabinByPatient(long admissionId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.HpPatientAccomodationInfoes.Where(x=>x.AdmissionId== admissionId && x.Status.ToLower()=="occupied" && x.AllotType.ToLower()=="patientbed").FirstOrDefault();
            }
        }

        public List<HpPatientAccomodationType> GetAccomodationTypes()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HpPatientAccomodationTypes.ToList();
            }
        }

        public List<CabinInfo> GetAccomodationList(int _accomodationTypeId, int deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CabinInfos.Where(x=>x.AccomodationTypeId== _accomodationTypeId && x.IsBooked==false).ToList();
            }
        }

        public List<FloorInfo> GetFloorList()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.FloorInfos.ToList();
            }
        }

        private VMCabinInfo GetCabinDataTableRow(DataRow dr)
        {
            VMCabinInfo cb = new VMCabinInfo();
            cb.CabinId = Convert.ToInt32(dr["CabinId"]);
            cb.CabinNo = dr["CabinNo"].ToString();
            cb.Description = dr["Description"].ToString();
            cb.Rent = Convert.ToInt32( dr["Rent"]);

            if (Convert.ToBoolean(dr["IsBooked"]))
            {
                cb.Booked = "Booked";
            }else
            {
                cb.Booked = "Free";
            }

           cb.Floor = dr["Floor"].ToString();

           if(dr["DeptName"] != DBNull.Value)
           {
                cb.Department = dr["DeptName"].ToString();

            }
            else
            {
                cb.Department = "";
            }
          
           cb.AccomType= dr["AccomodationType"].ToString();
           cb.FloorId = Convert.ToInt32(dr["FloorId"]);
           cb.DeptId= Convert.ToInt32(dr["DeptId"]);

            cb.AccomTypeId = Convert.ToInt32(dr["AccomodationTypeId"]);

            return cb;
        }

        public IList<HDMS.Model.Hospital.CabinInfo> GetAllCabinInformation()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CabinInfos.ToList();
            }
        }

        public HDMS.Model.Hospital.CabinInfo GetCabinInfoId(int p)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.CabinInfos.Where(x => x.CabinId == p).FirstOrDefault();
            }
        }

        public bool UpdateCabinInfo(HDMS.Model.Hospital.CabinInfo _cf)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(_cf).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveWardInfo(HDMS.Model.Hospital.WardInfo wi)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.WardInfos.Add(wi);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<HDMS.Model.Hospital.WardInfo> GetWarInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardInfos.ToList();
            }
        }

        public HDMS.Model.Hospital.WardInfo GetWarInfoById(int wId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardInfos.Where(x => x.WardId == wId).FirstOrDefault();
            }
        }

        public bool UpdateWardInfo(HDMS.Model.Hospital.WardInfo wid)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.Entry(wid).State = EntityState.Modified;
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveWardBedInfo(HDMS.Model.Hospital.WardBedInfo wbi)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.WardBedInfos.Add(wbi);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public IList<WardBedInfo> GetWardBedInfo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.WardBedInfos.ToList();
            }
        }

        public bool SaveCabinInfo(CabinInfo cf)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.CabinInfos.Add(cf);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

      
    }
}
