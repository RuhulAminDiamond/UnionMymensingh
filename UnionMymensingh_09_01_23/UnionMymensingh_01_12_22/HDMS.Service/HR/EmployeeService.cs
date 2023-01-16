using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.HR;
using HDMS.Repository.HR;
using HRM.Models;
using System.Data;
using HDMS.Model.HR.VM;
using HDMS.Model.Location;

namespace HDMS.Service.HR
{
    public class EmployeeService
    {
        public long SaveStaffInfo(EmployeeInfo _emp)
        {
            return new EmployeeRepository().SaveStaffInfo(_emp);
        }

        public List<VMEmployeeInfo> GetAll()
        {
            return new EmployeeRepository().GetAll();
        }

        public EmployeeInfo GetEmployeeById(long employeeId)
        {
            return new EmployeeRepository().GetEmployeeById(employeeId);
        }

        public bool UpdateEmployee(EmployeeInfo _employee)
        {
            return new EmployeeRepository().UpdateEmployee(_employee);
        }

        public IList<VMEmployeeInfo> GetEmployeeList()
        {
            return new EmployeeRepository().GetAll();
        }

        public List<VMLoanInfo> GetAllLoans()
        {
            return new EmployeeRepository().GetAllLoans();
        }

        public EmpDepartment GetDept(int deptId)
        {
            return new EmployeeRepository().GetDept(deptId);
        }

        public double GetEmployeePhLedgerBalance(int _employeeId)
        {
            return new EmployeeRepository().GetEmployeePhLedgerBalance(_employeeId);
        }

        public EmpDesignation GetDesignation(int designationId)
        {
            return new EmployeeRepository().GetDesignation(designationId);
        }

        public void SaveEmployeePhTransactionLedger(List<PhMemberLedger> _employeetransactionList)
        {
            new EmployeeRepository().SaveEmployeePhTransactionLedger(_employeetransactionList);
        }

        public List<EmpDivision> GetEmpDivisions()
        {
            return new EmployeeRepository().GetEmpDivisions();
        }

        public List<BloodGroup> GetBloodGroups()
        {
            return new EmployeeRepository().GetBloodGroups();
        }

        public List<MaritalStatus> GetMaritalStatus()
        {
            return new EmployeeRepository().GetMaritalStatus();
        }

        public List<Gender> GetGenders()
        {
            return new EmployeeRepository().GetGenders();
        }

        public List<Religion> GetReligions()
        {
            return new EmployeeRepository().GetReligions();
        }

        public bool SaveStaffRosterInfo(EmployeeRoster _empRoster)
        {
            try
            {
                return new EmployeeRepository().SaveStaffRosterInfo(_empRoster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country GetCountryByName(string countryName)
        {
            return new EmployeeRepository().GetCountryByName(countryName);
        }

        public bool SaveStaffRosterMasterInfo(EmployeeRosterMasterInfo _empRoster)
        {
            try
            {
                return new EmployeeRepository().SaveStaffRosterMasterInfo(_empRoster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<EmployeeRosterMasterInfo> GetEmployeeRosterMaster()
        {
            try
            {
                return new EmployeeRepository().GetEmployeeRosterMaster();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<EmployeeRosterMasterInfo> GetEmployeeRosterMasterExits(string StartDate, string EndDate, int DptID, int DeigID)
        {
            try
            {
                return new EmployeeRepository().GetEmployeeRosterMasterExits(StartDate, EndDate, DptID, DeigID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveLoanInfo(EmpLoanInfo _linfo)
        {
            return new EmployeeRepository().SaveLoanInfo(_linfo);
        }

        public EmployeeInfo GetEmployeeByEmployeeNo(string _employeeNo)
        {
            return new EmployeeRepository().GetEmployeeByEmployeeNo(_employeeNo);
        }

        public EmployeeInfo GetLastEmployee()
        {
            return new EmployeeRepository().GetLastEmployee();
        }

        public EmployeeInfo GetFirstEmployee()
        {
            return new EmployeeRepository().GetFirstEmployee();
        }

        public IList<VMEmployeeInfo> GetEmployeeByDeptDesig(int Deptid, int Desigid)
        {
            return new EmployeeRepository().GetEmployeeByDeptDesig(Deptid, Desigid);
        }

        public DataSet GetRoster(long rosterMasterId)
        {
            return new EmployeeRepository().GetRoster(rosterMasterId);
        }

        public DataSet GetEmployeeDetailsById(long employeeId)
        {
            return new EmployeeRepository().GetEmployeeDetailsById(employeeId);
        }

        public DataSet GetEmployeeListByDept(int deptId)
        {
            return new EmployeeRepository().GetEmployeeListByDept(deptId);
        }

        public Country GetCountryById(int countryId)
        {
            return new EmployeeRepository().GetCountryById(countryId);
        }

        public void PopulateSelectedServices(IList<EmployeeEducationalQualification> _SelectedServices, string _NameOfExam, int passingYear, string _Department, string _GPA, string _Board)
        {
            _SelectedServices.Add(GetPreparedSelectedServiceObject(_NameOfExam, passingYear, _Department, _GPA, _Board));
        }

        private EmployeeEducationalQualification GetPreparedSelectedServiceObject(string nameOfExam, int passingYear, string department, string gPA, string board)
        {
            EmployeeEducationalQualification ss = new EmployeeEducationalQualification();
            ss.NameOfExam = nameOfExam;
            ss.Passingyear = passingYear;
            ss.Department = department;
            ss.GPA = gPA;
            ss.Board = board;
            return ss;
        }
    }
}
