using HDMS.Common.Utils;
using HDMS.Model;
using HDMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Repository.Common
{
    public class RegRecordRepository
    {

        string sql = string.Empty;
        SqlCommand cmd;
        public bool IsRegAlloted(long _regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                List<RegRecord> _regList = entities.RegRecords.Where(x => x.RegNo == _regNo).ToList();
                if (_regList.Count() > 0) return true;

                return false;
            }

        }

        public bool IsBillNoAlloted(long _billNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                List<Patient> _billList = entities.Patients.Where(x => x.BillNo == _billNo).ToList();
                if (_billList.Count() > 0) return true;

                return false;
            }

        }

        public RegRecord SaveRegRecord(RegRecord _regRecord)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.RegRecords.Add(_regRecord);
                    entities.SaveChanges();
                    return _regRecord;
                }
                catch(Exception ex)
                {
                    return new RegRecord();
                }
            }
        }

        public RegRecord GetRegRecordByRegNo(long _regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.Where(x => x.RegNo == _regNo).FirstOrDefault();
                
            }
        }



        public IList<RegRecord> GetRegRecordByMobileNo(string _MobileNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format("Select * from RegRecords where MobileNo like '%{0}%'", _MobileNo);

                return entities.RegRecords.SqlQuery(sql).ToList();   //Where(x => x.MobileNo == _MobileNo).ToList();
            }
        }

        public bool UpdateRegRecord(RegRecord _record)
        {
            using (DBEntities entities = new DBEntities())
            {
                 entities.Entry(_record).State=EntityState.Modified;
                 entities.SaveChanges();
                return true;
                 
            }
        }

        public async Task<RegRecord> GetLatestRegRecordByCpIdAsync(int cPId)
        {
            using (DBEntities entities = new DBEntities())
            {
                //entities.Configuration.LazyLoadingEnabled = false;
              return await entities.RegRecords.SqlQuery("Select * from RegRecords Where Id=(Select Max(Id) from RegRecords Where CpId={0})", cPId).FirstOrDefaultAsync();
            }
        }

        public RegRecord GetSubSequentRegRecordAsc(long _Id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.SqlQuery("Select * from RegRecords Where Id=(Select Min(Id) from RegRecords Where Id>{0})", _Id).FirstOrDefault();
            }
        }

       

        public bool IsRegUniqueKeyAlloted(long _regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                List<RegUniqueKeyTracker> _regList = entities.RegUniqueKeyTrackers.Where(x => x.RegNo == _regNo).ToList();
                if (_regList.Count() > 0) return true;

                return false;
            }
        }

        public void UpdateRegTracker(RegUniqueKeyTracker _regTracker)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_regTracker).State=EntityState.Modified;
                entities.SaveChanges();
               
            }
        }

        public List<RegRecord> GetRegisterdPatients(DateTime dtpfrm, DateTime dtpto)
        {
            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"Select * from RegRecords Where RegDate between '{0}' and '{1}' and IsRegisterd=1", dtpfrm, dtpto);
                return entities.RegRecords.SqlQuery(sql).ToList();
            }
        }

        public List<RegUniqueKeyTracker> GetRegUniqueKeyList(string workStationId, int _yy, int _month)
        {
            using (DBEntities entities = new DBEntities())
            {
              return  entities.RegUniqueKeyTrackers.Where(x => x.GenerateFrom == workStationId && x.RegYear == _yy && x.RegMonth == _month).ToList();
            }
        }

        public async Task<RegRecord> GetRegRecordByRegNoAsync(long regNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return await entities.RegRecords.FirstOrDefaultAsync(x => x.RegNo == regNo);
            }
        }

        public List<RegRecord> GetRegisterdPatientByAdmId(string regno)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    sql = string.Format(@"Select * from RegRecords Where RegNo  like '%{0}%'", regno);
                    return entities.RegRecords.SqlQuery(sql).ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<RegRecord> GetRegisterdPatientByName(string name)
        {
            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"Select * from RegRecords Where FullName like '%{0}%'", name);
                return entities.RegRecords.SqlQuery(sql).ToList();
            }
        }

        public List<RegRecord> GetRegisterdPatientByMobileNo(string mobileNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                sql = string.Format(@"Select * from RegRecords Where MobileNo like '%{0}%'", mobileNo);
                return entities.RegRecords.SqlQuery(sql).ToList();
            }
        }

        public RegRecord GetRegRecordById(long _Id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.Where(x => x.Id == _Id).FirstOrDefault();
            }
        }

        public void GenerateRegKey(string name, string workStationId, string _gTime, int _NoOfRegCode, int _OrgCode)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
               
                sql = string.Format(@"exec spGenerateKey  '{0}' , '{1}','{2}',{3},{4} ", name, workStationId, _gTime, _NoOfRegCode, _OrgCode);

                cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public bool SaveRegUniqueKey(IList<RegUniqueKeyTracker> _ukeyList)
        {
            using (DBEntities entities = new DBEntities())
            {
               entities.RegUniqueKeyTrackers.AddRange(_ukeyList);
               entities.SaveChanges();
                return true;
            }
        }

        public RegUniqueKeyTracker GetRegUniqueKey(string workStationId, string _yy, int _mm)
        {
            using (DBEntities entities = new DBEntities())
            {
                int _year = 0;
                int.TryParse(_yy,out _year);
                return entities.RegUniqueKeyTrackers.Where(x=>x.GenerateFrom== workStationId && x.RegYear == _year && x.RegMonth== _mm && x.IsUsed ==false).FirstOrDefault();
            }
        }

        public RegRecord GetFirstRegNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.SqlQuery("Select * from RegRecords Where Id=(Select Min(Id) from RegRecords)").FirstOrDefault();
            }
        }

        public IList<RegRecord> GetAllRegistrationByMobileNo(string _mobileNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format("Select * from RegRecords where MobileNo like '%{0}%'", _mobileNo);

                return entities.RegRecords.SqlQuery(sql).ToList();  //Where(x=>x.MobileNo== _mobileNo).ToList();
            }
        }

        public IList<RegRecord> GetAllRegistrationByRegNoWildCard(string _RegNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                string sql = string.Format("Select * from RegRecords where RegNo like '%{0}%'", _RegNo);

                return entities.RegRecords.SqlQuery(sql).ToList();  //Where(x=>x.MobileNo== _mobileNo).ToList();
            }
        }


        public RegRecord GetLastRegNo()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.SqlQuery("Select * from RegRecords Where Id=(Select Max(Id) from RegRecords)").FirstOrDefault();
            }
        }

        public RegRecord GetSubSequentRegRecordDesc(long _Id)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.RegRecords.SqlQuery("Select * from RegRecords Where Id=(Select Max(Id) from RegRecords Where Id<{0})", _Id).FirstOrDefault();
            }
        }

    }
}
