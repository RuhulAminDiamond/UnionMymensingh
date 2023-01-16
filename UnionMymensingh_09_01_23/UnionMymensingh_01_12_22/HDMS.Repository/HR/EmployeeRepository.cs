using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.HR;
using System.Data.SqlClient;

using System.Data;
using System.Data.Entity;
using HDMS.Common.Utils;
using HRM.Models;
using HDMS.Model.HR.VM;
using HDMS.Model.Location;

namespace HDMS.Repository.HR
{
    public class EmployeeRepository
    {
        string sql = string.Empty;
        SqlDataAdapter da;
        DataSet ds;
        public long SaveStaffInfo(EmployeeInfo _emp)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.EmployeeInfoes.Add(_emp);
                entities.SaveChanges();
                return _emp.EmployeeId;
            }
        }

        public EmployeeInfo GetEmployeeById(long employeeId)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.EmployeeInfoes.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            }

        }



        public bool UpdateEmployee(EmployeeInfo _employee)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.Entry(_employee).State = EntityState.Modified;
                entities.SaveChanges();

                return true;
            }
        }

        public EmpDepartment GetDept(int deptId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDepartments.Where(x => x.DeptId == deptId).FirstOrDefault();
            }
        }

        public List<VMLoanInfo> GetAllLoans()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT  dbo.EmpLoanInfoes.EmployeeId, dbo.EmployeeInfoes.EmployeeName, dbo.EmpLoanInfoes.IssueAmount, dbo.EmpLoanInfoes.NoOfInstallment, dbo.EmpLoanInfoes.AmountPerInstallment, 
                         dbo.EmpLoanInfoes.InstallmentStartMonth, dbo.EmpLoanInfoes.InstallmentStartYear
                         FROM  dbo.EmpLoanInfoes INNER JOIN
                         dbo.EmployeeInfoes ON dbo.EmpLoanInfoes.EmployeeId = dbo.EmployeeInfoes.EmployeeId");

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<VMLoanInfo> empList = new List<VMLoanInfo>();


                    empList = new List<VMLoanInfo>(
                        (from dRow in dt.AsEnumerable()
                         select (GetEmployeeLoanData(dRow)))
                        );

                    return empList;


                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public EmpDesignation GetDesignation(int designationId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDesignations.Where(x => x.DesignationId == designationId).FirstOrDefault();
            }
        }

        public Country GetCountryByName(string countryName)
        {
            using (DBEntities entities = new DBEntities())
            {

                return entities.Countries.Where(x => x.Name == countryName).FirstOrDefault();
            }
        }

        private VMLoanInfo GetEmployeeLoanData(DataRow dr)
        {
            VMLoanInfo _emploan = new VMLoanInfo();
            _emploan.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            _emploan.Name = dr["EmployeeName"].ToString(); ;
            _emploan.IssueAmount = Convert.ToDouble(dr["IssueAmount"]);
            _emploan.NoOfInstallemnt = Convert.ToInt32(dr["NoOfInstallment"]);
            _emploan.AmountPerInstallment = Convert.ToDouble(dr["AmountPerInstallment"]);
            _emploan.InstamentStartMonth = dr["InstallmentStartMonth"].ToString();
            _emploan.installmentStartYear = Convert.ToInt32(dr["InstallmentStartYear"]);

            return _emploan;


            return _emploan;
        }

        public void SaveEmployeePhTransactionLedger(List<PhMemberLedger> _employeetransactionList)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.PhMemberLedgers.AddRange(_employeetransactionList);
                entities.SaveChanges();
            }
        }

        public List<BloodGroup> GetBloodGroups()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.BloodGroups.ToList();
            }
        }

        public List<MaritalStatus> GetMaritalStatus()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.MaritulStatus.ToList();
            }
        }

        public List<Religion> GetReligions()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Religions.ToList();
            }
        }

        public EmployeeInfo GetEmployeeByEmployeeNo(string _employeeNo)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmployeeInfoes.Where(x => x.EmployeeNo == _employeeNo).FirstOrDefault();
            }
        }

        public Country GetCountryById(int countryId)
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Countries.Where(x => x.CountryId == countryId).FirstOrDefault();
            }
        }

        public DataSet GetEmployeeListByDept(int deptId)
        {

            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {

                sql = string.Format(@"EXEC [dbo].[spGetEmployeeList] {0}", deptId);

                SqlCommand com = new SqlCommand(sql, conn);
                com.CommandTimeout = 0;
                da = new SqlDataAdapter(com);

                DataSet dsEmployeeList = new DataSet();
                da.Fill(dsEmployeeList, "dtEmployeeList");
                return dsEmployeeList;
            }

        }

        public EmployeeInfo GetFirstEmployee()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmployeeInfoes.ToList().FirstOrDefault();
            }
        }

        public EmployeeInfo GetLastEmployee()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmployeeInfoes.OrderByDescending(x => x.EmployeeId).FirstOrDefault();
            }
        }

        public List<Gender> GetGenders()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.Genders.ToList();
            }
        }

        public List<EmpDivision> GetEmpDivisions()
        {
            using (DBEntities entities = new DBEntities())
            {
                return entities.EmpDivisions.ToList();
            }
        }

        public bool SaveLoanInfo(EmpLoanInfo _linfo)
        {
            using (DBEntities entities = new DBEntities())
            {
                entities.EmpLoanInfoes.Add(_linfo);
                entities.SaveChanges();
                return true;
            }
        }

        public double GetEmployeePhLedgerBalance(int _employeeId)
        {
            double _balance = 0;
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    sql = string.Format(@"Select SUM(Credit-Debit) as Balance from EmployeeLedgers Where EmployeeId={0}", _employeeId);
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

        public DataSet GetRoster(long rosterMasterId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"SELECT        dbo.EmployeeRosterMasterInfoes.RosterMasterId, dbo.EmployeeRosterMasterInfoes.RosterStartDate, dbo.EmployeeRosterMasterInfoes.RosterEndDate, dbo.EmployeeRosters.RosterDate, dbo.EmployeeRosters.RosterDay, 
                                      dbo.EmployeeRosters.MorningEmpName, dbo.EmployeeRosters.EveningEmpName, dbo.EmployeeRosters.NightEmpName, dbo.EmployeeRosters.OverTimeEmpName, dbo.EmployeeRosters.DayOffEmpName
                                      FROM            dbo.EmployeeRosterMasterInfoes INNER JOIN
                                       dbo.EmployeeRosters ON dbo.EmployeeRosterMasterInfoes.RosterMasterId = dbo.EmployeeRosters.MasterRosterID Where dbo.EmployeeRosterMasterInfoes.RosterMasterId={0}", rosterMasterId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtRoster");
                return ds;
            }
        }

        public DataSet GetEmployeeDetailsById(long employeeId)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
            {
                sql = string.Format(@"
                    SELECT 
	                   dbo.EmployeeEducationalQualifications.NameOfExam,
					   dbo.EmployeeEducationalQualifications.Passingyear,
					   dbo.EmployeeEducationalQualifications.GPA,
					   dbo.EmployeeEducationalQualifications.Department as EduDepartment,
					   dbo.EmployeeEducationalQualifications.Board,
					   
					   dbo.EmployeeInfoes.EmployeeId, 
	                    dbo.EmployeeInfoes.EmployeeNo,
	                    dbo.EmployeeInfoes.EmployeeName, 
                         dbo.EmployeeInfoes.JoiningSalry,
                          dbo.EmployeeInfoes.WorkingHouse,
                          dbo.EmployeeInfoes.experience,
	                    dbo.EmployeeInfoes.FatherName, 
	                    dbo.EmployeeInfoes.MotherName, 
	                    dbo.EmployeeInfoes.BloodGroup, 
	                    dbo.EmployeeInfoes.DateofBirth, 
	                    dbo.EmployeeInfoes.Sex, 
	                    dbo.EmployeeInfoes.Religion, 
	                    dbo.Countries.Name AS Nationality, 

	                    dbo.EmployeeInfoes.NationIDorPPNo, 
	                    dbo.EmployeeInfoes.MaritalStatus,
	                    dbo.EmployeeInfoes.PermanentAddress, 
	                    dbo.EmployeeInfoes.PresentAddress,
						dbo.EmployeeInfoes.District,
						dbo.EmployeeInfoes.Thana,
						dbo.EmployeeInfoes.PostOffice,
						dbo.EmployeeInfoes.CareOf,
	                    'Mobile No: ' + dbo.EmployeeInfoes.MobileNo AS MobileNo, 

	                    'E-Mail: '+ dbo.EmployeeInfoes.EmailId as EmailId,
	                    dbo.EmployeeInfoes.DeptId, 
	                    dbo.EmpDepartments.Name AS Department,
	                    dbo.EmployeeInfoes.DesignationId, 
	                    dbo.EmpDesignations.Name AS Designation, 
						dbo.EmployeeInfoes.Confirmationdate,
	                    dbo.EmployeeInfoes.JoiningDate, 
	                    dbo.EmpProfileImages.ProfileImage

                    FROM  dbo.EmployeeInfoes

                    INNER JOIN dbo.EmpDepartments 
                    ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId 

                    INNER JOIN dbo.EmpDesignations 
                    ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId  

                    INNER JOIN dbo.EmpProfileImages
                    ON dbo.EmployeeInfoes.EmployeeId = dbo.EmpProfileImages.EmployeeId

					INNER JOIN dbo.Countries
					ON dbo.EmployeeInfoes.Nationality = dbo.Countries.CountryId

					left Join dbo.EmployeeEducationalQualifications 
					ON dbo.EmployeeInfoes.EmployeeId=dbo.EmployeeEducationalQualifications.EmployeeId

                    WHERE dbo.EmployeeInfoes.EmployeeId={0}
                ", employeeId);

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "dtEmployeeProfile");
                return ds;
            }

        }

        public List<VMEmployeeInfo> GetAll()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT  dbo.EmployeeInfoes.EmployeeId, dbo.EmployeeInfoes.EmployeeName,dbo.EmployeeInfoes.MobileNo,dbo.EmployeeInfoes.PresentAddress,dbo.EmpDepartments.Name AS DeptName, dbo.EmpDepartments.DeptId, dbo.EmpDesignations.Name AS Designation, 
                         dbo.EmpDesignations.DesignationId,dbo.EmployeeInfoes.JoiningDate,dbo.EmployeeInfoes.JCId,dbo.EmployeeInfoes.JCVId,dbo.EmployeeInfoes.Nationality 
                         FROM  dbo.EmployeeInfoes INNER JOIN
                         dbo.EmpDepartments ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId INNER JOIN
                         dbo.EmpDesignations ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId");

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
            catch(Exception ex)
            {
                return null;
            }

        }


        public List<VMEmployeeInfo> GetEmployeeByDeptDesig(int Deptid, int Desigid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT dbo.EmployeeInfoes.EmployeeId, dbo.EmployeeInfoes.EmployeeName, dbo.EmpDepartments.Name AS DeptName, dbo.EmpDepartments.DeptId, dbo.EmpDesignations.Name AS Designation, 
                                          EmployeeInfoes.MobileNo,EmployeeInfoes.PresentAddress,
                                           dbo.EmpDesignations.DesignationId, dbo.EmployeeInfoes.JoiningDate,dbo.EmployeeInfoes.JCId,dbo.EmployeeInfoes.JCVId,dbo.EmployeeInfoes.Nationality
                                          FROM dbo.EmployeeInfoes INNER JOIN
                                          dbo.EmpDepartments ON dbo.EmployeeInfoes.DeptId = dbo.EmpDepartments.DeptId INNER JOIN
                                          dbo.EmpDesignations ON dbo.EmployeeInfoes.DesignationId = dbo.EmpDesignations.DesignationId
                                           WHERE (dbo.EmpDepartments.DeptId = {0}) AND (dbo.EmployeeInfoes.DesignationId = {1})", Deptid, Desigid);

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
            catch
            {
                return null;
            }
        }


        private VMEmployeeInfo GetEmployeeData(DataRow dr)
        {
            VMEmployeeInfo _emp = new VMEmployeeInfo();
            _emp.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            _emp.DeptId = Convert.ToInt32(dr["DeptId"]);
            _emp.DesignationId = Convert.ToInt32(dr["DesignationId"]);
            _emp.EmployeeName = dr["EmployeeName"].ToString();
            _emp.DeptName = dr["DeptName"].ToString();
            _emp.Designation = dr["Designation"].ToString();
            _emp.JoiningDate = Convert.ToDateTime(dr["JoiningDate"]);
            if (!dr.IsNull("MobileNo"))
            {
                _emp.MobileNo = dr["MobileNo"].ToString();
            }

            if (!dr.IsNull("PresentAddress"))
            {
                _emp.Address = dr["PresentAddress"].ToString();
            }

            _emp.JCId = Convert.ToInt32(dr["JCId"]);
            _emp.JCVId = Convert.ToInt32(dr["JCVId"]);
            _emp.Nationality = Convert.ToInt32(dr["Nationality"]);
            return _emp;


        }

        public bool SaveStaffRosterInfo(EmployeeRoster _empRoster)
        {
            try
            {
                using (DBEntities entities = new DBEntities())
                {
                    entities.EmployeeRosters.Add(_empRoster);
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public bool SaveStaffRosterMasterInfo(EmployeeRosterMasterInfo _empRoster)
        {
            try
            {
                using (DBEntities entities = new DBEntities())
                {
                    entities.EmployeeRosterMasterInfos.Add(_empRoster);
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }




        public List<EmployeeRosterMasterInfo> GetEmployeeRosterMaster()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT [RosterMasterId]
                                              ,[RosterStartDate]
                                              ,[RosterEndDate]
                                              ,[Remarks]
                                              ,[DeptId]
                                              ,[DesignationId]
                                          FROM [dbo].[EmployeeRosterMasterInfoes]");

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<EmployeeRosterMasterInfo> empList = new List<EmployeeRosterMasterInfo>();


                    empList = new List<EmployeeRosterMasterInfo>(
                        (from dRow in dt.AsEnumerable()
                         select (GetEmployeeRosterMasterData(dRow)))
                        );

                    return empList;


                }


            }
            catch
            {
                return null;
            }
        }



        public List<EmployeeRosterMasterInfo> GetEmployeeRosterMasterExits(string StartDate, string EndDate, int DptID, int DeigID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.ConnectionString))
                {
                    sql = string.Format(@"SELECT [RosterMasterId]
                                              ,[RosterStartDate]
                                              ,[RosterEndDate]
                                              ,[Remarks]
                                              ,[DeptId]
                                              ,[DesignationId]
                                          FROM [dbo].[EmployeeRosterMasterInfoes]

                where StartDate between '" + StartDate + @"' and '" + EndDate + @"' and DeptId = " + DptID + " and DesignationId = '" + DeigID + "'");

                    da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conn.Close();

                    List<EmployeeRosterMasterInfo> empList = new List<EmployeeRosterMasterInfo>();


                    empList = new List<EmployeeRosterMasterInfo>(
                        (from dRow in dt.AsEnumerable()
                         select (GetEmployeeRosterMasterData(dRow)))
                        );

                    return empList;


                }


            }
            catch
            {
                return null;
            }
        }
        private EmployeeRosterMasterInfo GetEmployeeRosterMasterData(DataRow dr)
        {
            EmployeeRosterMasterInfo _emp = new EmployeeRosterMasterInfo();
            _emp.RosterMasterId = Convert.ToInt32(dr["RosterMasterId"]);
            _emp.DeptId = Convert.ToInt32(dr["DeptId"]);
            _emp.DesignationId = Convert.ToInt32(dr["DesignationId"]);
            _emp.RosterStartDate = Convert.ToDateTime(dr["RosterStartDate"].ToString());
            _emp.RosterEndDate = Convert.ToDateTime(dr["RosterEndDate"].ToString());
            _emp.Remarks = dr["Remarks"].ToString();

            return _emp;


        }


    }
}
