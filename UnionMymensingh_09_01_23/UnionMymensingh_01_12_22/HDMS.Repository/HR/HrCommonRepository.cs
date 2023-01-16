using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.HR;
using System.Data.Entity;
using HDMS.Model.HR.VM;
using System.Data.SqlClient;
using System.Data;
using HDMS.Common.Utils;
using HRM.Models;
using HDMS.Model.Enums;

namespace HDMS.Repository.HR
{
    public class HrCommonRepository
    {
        string sql = string.Empty;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public bool AddDept(EmpDepartment dept)
        {
            using (DBEntities entities=new DBEntities())
            {
                entities.EmpDepartments.Add(dept);
                entities.SaveChanges();

                return true;
            }
        }

        public bool UpdateDept(EmpDepartment _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_dept).State = EntityState.Modified;
                entities.SaveChanges();

                return true;
            }
        }

        public bool UpdateDivision(EmpDivision _dept)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_dept).State = EntityState.Modified;
                entities.SaveChanges();

                return true;
            }
        }

        public bool UpdateJobCirculation(JobCirculation JCirculation)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(JCirculation).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public EmpDepartment GetDeptById(int _deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDepartments.Where(x=>x.DeptId== _deptId).FirstOrDefault();
            }
        }

        public IList<VMEmpDepartment> GetDepartments()
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                sql = string.Format(@"SELECT dbo.EmpDepartments.DeptId, dbo.EmpDepartments.Name, dbo.EmpDepartments.DivId, ISNULL(dbo.EmpDivisions.Name, '') AS Division
                                     FROM  dbo.EmpDepartments LEFT OUTER JOIN
                                     dbo.EmpDivisions ON dbo.EmpDepartments.DivId = dbo.EmpDivisions.DivId");


                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMEmpDepartment> _divList = new List<VMEmpDepartment>();


                _divList = new List<VMEmpDepartment>(
                    (from dRow in dt.AsEnumerable()
                     select (GetEmpDeptDataTableRow(dRow)))
                    );

                return _divList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<VMLeaveApplication> GetLeaveApplicationList(string _applicationStatus, int _deptId, EmployeeInfo _empInfo)
        {
            try
            {

                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();

                if (_empInfo.IsHoD && _empInfo.DeptId == 3)
                {
                    sql = string.Format(@"SELECT dbo.LeaveApplications.ApplicationId, dbo.LeaveApplications.EmployeeId, dbo.LeaveApplications.AppDate, dbo.LeaveApplications.AppSubject, dbo.LeaveApplications.Application, dbo.LeaveApplications.ApprovalStatusLevel1, 
                                       dbo.LeaveApplications.ApprovalStatusLevel2,dbo.LeaveApplications.ApprovalStatusLevel3,dbo.LeaveApplications.Leavefrom, dbo.LeaveApplications.Leaveto, dbo.LeaveApplications.ApplicationTo, dbo.EmployeeInfoes.EmployeeName, dbo.EmpDepartments.Name AS Department, 
                                      dbo.EmpDesignations.Name AS Designation, dbo.GetCL() AS CL 
                                      FROM  dbo.LeaveApplications INNER JOIN
                                      dbo.EmployeeInfoes ON dbo.LeaveApplications.EmployeeId = dbo.EmployeeInfoes.EmployeeId INNER JOIN
                                      dbo.EmpDepartments ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId INNER JOIN
                                      dbo.EmpDesignations ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId
                                      WHERE (dbo.LeaveApplications.ApprovalStatusLevel3 = '{0}')", _applicationStatus, _deptId);
                }
                else
                {

                    sql = string.Format(@"SELECT dbo.LeaveApplications.ApplicationId, dbo.LeaveApplications.EmployeeId, dbo.LeaveApplications.AppDate, dbo.LeaveApplications.AppSubject, dbo.LeaveApplications.Application, dbo.LeaveApplications.ApprovalStatusLevel1, 
                                      dbo.LeaveApplications.ApprovalStatusLevel2,dbo.LeaveApplications.ApprovalStatusLevel3,dbo.LeaveApplications.Leavefrom, dbo.LeaveApplications.Leaveto, dbo.LeaveApplications.ApplicationTo, dbo.EmployeeInfoes.EmployeeName, dbo.EmpDepartments.Name AS Department, 
                                      dbo.EmpDesignations.Name AS Designation, dbo.GetCL() AS CL 
                                      FROM  dbo.LeaveApplications INNER JOIN
                                      dbo.EmployeeInfoes ON dbo.LeaveApplications.EmployeeId = dbo.EmployeeInfoes.EmployeeId INNER JOIN
                                      dbo.EmpDepartments ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId INNER JOIN
                                      dbo.EmpDesignations ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId
                                      WHERE (dbo.LeaveApplications.ApprovalStatusLevel1 = '{0}') and (dbo.EmployeeInfoes.DeptId={1} or {1}=0)", _applicationStatus, _deptId);
                }

                da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                List<VMLeaveApplication> _LeaveAppList = new List<VMLeaveApplication>();


                _LeaveAppList = new List<VMLeaveApplication>(
                    (from dRow in dt.AsEnumerable()
                     select (GetLeaveApplicationDataTableRow(dRow)))
                    );

                return _LeaveAppList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        private VMLeaveApplication GetLeaveApplicationDataTableRow(DataRow dr)
        {
            VMLeaveApplication _lApp = new VMLeaveApplication();
            _lApp.EmployeeId = Convert.ToInt64(dr["EmployeeId"]);
            _lApp.EmployeeName = dr["EmployeeName"].ToString();
            _lApp.DeptName = dr["Department"].ToString();
            _lApp.Designation = dr["Designation"].ToString();
            _lApp.AppSubject = dr["AppSubject"].ToString();
            _lApp.CL = Convert.ToInt32(dr["CL"]);

            _lApp.ApplicationId = Convert.ToInt64(dr["ApplicationId"]);
            _lApp.ApprovalLevel1 = dr["ApprovalStatusLevel1"].ToString();
            _lApp.ApprovalLevel2 = dr["ApprovalStatusLevel2"].ToString();
            _lApp.ApprovalLevel3 = dr["ApprovalStatusLevel3"].ToString();
            _lApp.Leavefrom = Convert.ToDateTime(dr["Leavefrom"]);
            _lApp.Leaveto = Convert.ToDateTime(dr["Leaveto"]);
            _lApp.ApplicationTo = dr["ApplicationTo"].ToString();
            _lApp.Application = dr["Application"].ToString();


            return _lApp;
        }

        public bool SaveLeaveApplication(LeaveApplication _lApp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.LeaveApplications.Add(_lApp);
                entities.SaveChanges();
                return true;
            }
        }

        public bool SaveEmployeeEducationalQualification(List<EmployeeEducationalQualification> empEduQualification)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {

                    entities.EmployeeEducationalQualifications.AddRange(empEduQualification);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public int GetCLExpense(long employeeId, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {

                    sql = string.Format(@"Select Sum(Lr.TotalDays) ClExp from EmployeeLeaveRecords Lr
                                            Where  EmployeeId={0} and Year(Lr.Leavefrom)={1}", employeeId, year);

                    cmd = new SqlCommand(sql, conn);

                    conn.Open();


                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<EmployeeEducationalQualification> GetEmployeeEducation(long employeeId)
        {

            using (DBEntities entities = new DBEntities())
            {
                return entities.EmployeeEducationalQualifications.Where(x => x.EmployeeId == employeeId).ToList();
            }
        }

        public bool SaveGAttLogPullHistory(TimedAttendanceLogPullHistory _pullHistory)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.TimedAttendanceLogPullHistories.Add(_pullHistory);
                    entities.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool SaveTimedAttendanceLog(List<TimedAttendanceLog> _attLogList)
        {
            using (DBEntities entities = new DBEntities())
            {
                try
                {
                    entities.TimedAttendanceLogs.AddRange(_attLogList);
                    entities.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }



        public bool AddJobCirculation(JobCirculation _JCir)
        {

            using (DBEntities entities = new DBEntities())
            {
                entities.JobCirculations.Add(_JCir);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<JobCirculation> GetJobCirculations()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCirculations.ToList();
            }
        }

        public bool AddJobCv(JobCV _JCv)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.JobCVs.Add(_JCv);
                entities.SaveChanges();

                return true;
            }
        }

        public bool AddDivision(EmpDivision division)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.EmpDivisions.Add(division);
                entities.SaveChanges();
                return true;
            }
        }

        public IList<JobCirculation> GetAllJobCircular()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCirculations.ToList();
            }
        }

        private VMEmpDepartment GetEmpDeptDataTableRow(DataRow dr)
        {
            VMEmpDepartment Obj = new VMEmpDepartment();
            Obj.DeptId = Convert.ToInt32(dr["DeptId"]);
            Obj.Name = dr["Name"].ToString();
            Obj.DivId = Convert.ToInt32(dr["DivId"]);
            Obj.Division = dr["Division"].ToString();

            return Obj;
        }

        public LeaveApplication GetLeaveApplicationById(long applicationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.LeaveApplications.Where(x => x.ApplicationId == applicationId).FirstOrDefault();
            }
        }

        public void UpdateLeaveApplication(LeaveApplication leaveapp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(leaveapp).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public EmpDivision GetDivisionById(int divId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDivisions.Where(x => x.DivId == divId).FirstOrDefault();

            }
        }

        public IList<JobCV> GetAllJobCVByCircular(string _type)
        {
            int _JCId = 0;
            int.TryParse(_type, out _JCId);
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCVs.Where(x => x.JCId == _JCId).ToList();
            }
        }

        public bool AddDesignation(EmpDesignation desig)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.EmpDesignations.Add(desig);
                entities.SaveChanges();

                return true;
            }
        }

        public List<EmpDepartment> GetAllDepartments()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDepartments.ToList();

            }
        }

        public HRSalaryPolicy GetHrSalaryPolicyByEmployeeId(long employeeId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HRSalaryPolicy.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            }
        }

        public IList<JobCV> GetJobCvs(JobCirculation _circulation)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCVs.Where(x => x.JCId == _circulation.JCId).ToList();

            }
        }

        public List<VMEmployeeInfo> GetEmployeeByName(string ename, string type)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT dbo.EmployeeInfoes.EmployeeId, dbo.EmployeeInfoes.EmployeeNo, dbo.EmployeeInfoes.BiometricEnrollmentNo, dbo.EmployeeInfoes.EmployeeName, dbo.EmployeeInfoes.FatherName, dbo.EmployeeInfoes.MotherName, 
                         dbo.EmployeeInfoes.DateofBirth, dbo.EmployeeInfoes.BloodGroup,dbo.EmployeeInfoes.Sex,dbo.EmployeeInfoes.Nationality, dbo.EmployeeInfoes.NationIDorPPNo,dbo.EmployeeInfoes.PermanentAddress,  dbo.EmployeeInfoes.PresentAddress, dbo.EmpDepartments.Name AS DeptName, dbo.EmpDepartments.DeptId, 
                         dbo.EmpDesignations.Name AS Designation, dbo.EmployeeInfoes.MobileNo, dbo.EmployeeInfoes.EmailId ,dbo.EmployeeInfoes.IsHoD, dbo.EmpDesignations.DesignationId, dbo.EmployeeInfoes.JoiningDate, dbo.EmployeeInfoes.Confirmationdate,
                         ISNULL(dbo.GetCL(), 0) AS CL, ISNULL(dbo.GetML(), 0) AS ML, ISNULL(dbo.GetMedicalLeave(), 0) AS MedLeave, ISNULL(dbo.GetIsLatedDeduction(), 0) AS LateDeduct, dbo.EmpDivisions.Name AS Division, 
                         dbo.JobCirculations.CirculationNo, dbo.JobCirculations.CirculationTitle, dbo.JobCVs.ApplicatName, dbo.JobCVs.JCId, dbo.JobCVs.JCVId
                         FROM   dbo.EmployeeInfoes INNER JOIN
                         dbo.EmpDepartments ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId INNER JOIN
                         dbo.EmpDesignations ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId INNER JOIN
                         dbo.JobCVs ON dbo.EmployeeInfoes.JCVId = dbo.JobCVs.JCVId INNER JOIN
                         dbo.JobCirculations ON dbo.JobCVs.JCId = dbo.JobCirculations.JCId INNER JOIN
                         dbo.EmpDivisions ON EmpDepartments.DivId = dbo.EmpDivisions.DivId Where dbo.EmployeeInfoes.EmployeeName like '%{0}%'", ename);

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMEmployeeInfo> empList = new List<VMEmployeeInfo>();


                    empList = new List<VMEmployeeInfo>(
                        (from dRow in dt.AsEnumerable()
                         select (GetEmployeeData(dRow)))
                        );

                    return empList;


                }
            }
            catch (Exception ex)
            {
                return new List<VMEmployeeInfo>();
            }

        }

        public JobCV GetJobCvById(int jCVId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCVs.Where(x => x.JCVId == jCVId).FirstOrDefault();
            }
        }

        public void UpdateCVStatus(List<JobCV> _cvList)
        {
            using (DBEntities entity = new DBEntities())
            {
                try
                {
                    _cvList.ForEach(n => entity.Entry(n).State = EntityState.Modified);
                    entity.SaveChanges();

                }
                catch (Exception ex)
                {

                }
            }
        }

        public DataSet GetShortlistedApplicants(JobCirculation _jc)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"Select * from JobCVs Where JCId={0} and Status='{1}'", _jc.JCId, JobCvStatusEnum.InShortList.ToString());

                da = new SqlDataAdapter(sql, conn);

                DataSet dsReports = new DataSet();
                da.Fill(dsReports);

                dsReports.DataSetName = "myDataset";
                dsReports.Tables[0].TableName = "dtApplicantShortList";


                return dsReports;
            }
        }

        public JobCirculation GetJobCirculationById(int _circulationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCirculations.Where(x => x.JCId == _circulationId).FirstOrDefault();
            }
        }

        public JobCV GetJobCVById(int jCvId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCVs.Where(x => x.JCVId == jCvId).FirstOrDefault();
            }
        }

        public JobCirculation GetJobCirculations(int _circulationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.JobCirculations.Where(x => x.JCId == _circulationId).FirstOrDefault();
            }
        }

        public List<EmpDepartment> GetDepartmentsByDivId(int divId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDepartments.Where(x => x.DivId == divId).ToList();
            }
        }

        private VMEmployeeInfo GetEmployeeData(DataRow dr)
        {
            VMEmployeeInfo _emp = new VMEmployeeInfo();
            _emp.EmployeeId = Convert.ToInt64(dr["EmployeeId"]);
            _emp.EmployeeNo = dr["EmployeeNo"].ToString();
            _emp.BiometricEnrollmentNo = Convert.ToInt32(dr["BiometricEnrollmentNo"]);
            _emp.DeptId = Convert.ToInt32(dr["DeptId"]);
            _emp.DesignationId = Convert.ToInt32(dr["DesignationId"]);
            _emp.EmployeeName = dr["EmployeeName"].ToString();
            _emp.FatherName = dr["FatherName"].ToString();
            _emp.MotherName = dr["MotherName"].ToString();
            _emp.PermanentAddress = dr["PermanentAddress"].ToString();
            _emp.PresentAddress = dr["PresentAddress"].ToString();
            _emp.DeptName = dr["DeptName"].ToString();
            _emp.Designation = dr["Designation"].ToString();
            _emp.JoiningDate = Convert.ToDateTime(dr["JoiningDate"]);
            _emp.DOB = Convert.ToDateTime(dr["DateofBirth"]);
            _emp.CL = Convert.ToInt32(dr["CL"]);

            if (!dr.IsNull("MobileNo"))
            {
                _emp.MobileNo = dr["MobileNo"].ToString();
            }

            if (!dr.IsNull("PresentAddress"))
            {
                _emp.Address = dr["PresentAddress"].ToString();
            }

            _emp.IsHoD = Convert.ToBoolean(dr["IsHoD"]);
            _emp.JCId = Convert.ToInt32(dr["JCId"]);
            _emp.JCVId = Convert.ToInt32(dr["JCVId"]);
            _emp.CirculationNo = dr["CirculationNo"].ToString();
            _emp.BloodGroup = dr["BloodGroup"].ToString();
            _emp.Nationality = Convert.ToInt32(dr["Nationality"]);
            _emp.NationalIdOrPPNo = dr["NationIDorPPNo"].ToString();
            _emp.Gender = dr["Sex"].ToString();
            _emp.PermanentAddress = dr["PermanentAddress"].ToString();
            _emp.PresentAddress = dr["PresentAddress"].ToString();
            _emp.Email = dr["EmailId"].ToString();

            return _emp;


        }

        public List<EmpDivision> GetAllDivision()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDivisions.ToList();

            }
        }

        //public HRSalaryPolicy GetHrSalaryPolicyById(int deptId,int desigId)
        //{
        //    using (DBEntities entities = new DBEntities())
        //    {
        //        return entities.HRSalaryPolicy.Where(x=>x.DeptId== deptId && x.DesignationId== desigId).FirstOrDefault();
        //    }
        //}

        public bool SaveSalaryPolicy(HRSalaryPolicy _sp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HRSalaryPolicy.Add(_sp);
                entities.SaveChanges();
                return true;
            }
        }

        public bool UpdateSalaryPolicy(HRSalaryPolicy _sp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_sp).State=EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
        }

        public List<HrWokingDay> GetHolyDayList(int _yr, int _mnth)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.HrWokingDays.Where(x => x.WYear == _yr && x.WMonth == _mnth && x.IsPublicHoliday == true).ToList();

            }
        }

        public void GetHolyDayList(IList<VMHoliday> _hldayList, string _year, string _month)
        {
            int _yr = 0, _mnth = 0;
            int.TryParse(_year, out _yr);
            int.TryParse(_month, out _mnth);

            List<HrWokingDay> _wdayList = new HrCommonRepository().GetHolyDayList(_yr, _mnth);

            foreach (var item in _wdayList)
            {
                VMHoliday _hday = new VMHoliday();
                _hday.HolyDay = item.WDate;
                _hday.Remarks = item.Remarks;
                _hldayList.Add(_hday);
            }

        }

        public IList<EmpDesignation> GetDesignations()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDesignations.ToList();
            }
        }

        public void SaveWorkingDays(List<HrWokingDay> _wdList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.HrWokingDays.AddRange(_wdList);
                entities.SaveChanges();
            }
        }
    }
}
