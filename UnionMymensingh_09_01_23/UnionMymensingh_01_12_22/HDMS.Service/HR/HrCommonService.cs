using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Model.HR;
using HDMS.Repository.HR;
using HDMS.Model.HR.VM;
using HRM.Models;
using System.Data;

namespace HDMS.Service.HR
{
    public class HrCommonService
    {
        public EmpDepartment GetDeptById(int _deptId)
        {
            return new HrCommonRepository().GetDeptById(_deptId);
        }

        public bool UpdateDept(EmpDepartment _dept)
        {
            return new HrCommonRepository().UpdateDept(_dept);
        }

        public bool AddDept(EmpDepartment dept)
        {
            return new HrCommonRepository().AddDept(dept);
        }

        public EmpDesignation GetDesignationById(int v)
        {
            throw new NotImplementedException();
        }

        public IList<VMEmpDepartment> GetDepartments()
        {
            return new HrCommonRepository().GetDepartments();
        }

        public bool UpdateDivision(EmpDivision _dept)
        {
            return new HrCommonRepository().UpdateDivision(_dept);
        }

        public bool UpdateJobCirculation(JobCirculation _JCirculation)
        {
            return new HrCommonRepository().UpdateJobCirculation(_JCirculation);
        }

        public bool UpdateDesignation(EmpDesignation _desig)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDept(EmpDepartment _gr)
        {
            throw new NotImplementedException();
        }

        public bool AddDesignation(EmpDesignation desig)
        {
            return new HrCommonRepository().AddDesignation(desig);
        }

        public IList<EmpDesignation> GetDesignations()
        {
            return new HrCommonRepository().GetDesignations();
        }

        public List<VMLeaveApplication> GetLeaveApplicationList(string _applicationStatus, int _deptId, EmployeeInfo _empInfo)
        {
            return new HrCommonRepository().GetLeaveApplicationList(_applicationStatus, _deptId, _empInfo);
        }

        public HRSalaryPolicy GetHrSalaryPolicyById(long empId)
        {
            return new HrCommonRepository().GetHrSalaryPolicyByEmployeeId(empId);
        }

        public bool AddJobCirculation(JobCirculation _JCir)
        {
            return new HrCommonRepository().AddJobCirculation(_JCir);
        }

        public bool AddDivision(EmpDivision dept)
        {
            return new HrCommonRepository().AddDivision(dept);
        }

        public bool SaveSalaryPolicy(HRSalaryPolicy _sp)
        {
            return new HrCommonRepository().SaveSalaryPolicy(_sp);
        }

        public bool SaveLeaveApplication(LeaveApplication _lApp)
        {
            return new HrCommonRepository().SaveLeaveApplication(_lApp);
        }

        public bool UpdateSalaryPolicy(HRSalaryPolicy _sp)
        {
            return new HrCommonRepository().UpdateSalaryPolicy(_sp);
        }

        public IList<JobCirculation> GetAllJobCircular()
        {
            return new HrCommonRepository().GetAllJobCircular();
        }

        public void SaveWorkingDays(List<HrWokingDay> _wdList)
        {
            new HrCommonRepository().SaveWorkingDays(_wdList);
        }

        public IList<JobCirculation> GetJobCirculations()
        {
            return new HrCommonRepository().GetJobCirculations();
        }

        public string GetCLExpense(long employeeId, int year)
        {
            int _clExpense = new HrCommonRepository().GetCLExpense(employeeId, year);

            return _clExpense.ToString();
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

        public bool AddJobCv(JobCV _JCv)
        {
            return new HrCommonRepository().AddJobCv(_JCv);
        }

        public IList<JobCV> GetAllJobCVByCircular(string _type)
        {

            return new HrCommonRepository().GetAllJobCVByCircular(_type);
        }

        public EmpDivision GetDivisionById(int divId)
        {
            return new HrCommonRepository().GetDivisionById(divId);
        }

        //public IList<JobCV> GetAllJobCVByCircular(string _type)
        //{
        //    int _JCId = 0;
        //    int.TryParse(_type, out _JCId);
        //    using (DBEntities entities = new DBEntities())
        //    {
        //        return entities.JobCVs.Where(x => x.JCId == _JCId).ToList();
        //    }
        //}

        public void HolyDayList(IList<VMHoliday> _hldayList, string _remarks, DateTime dtfrm, DateTime dtto)
        {
            for (DateTime _dt = dtfrm; _dt <= dtto; _dt = _dt.AddDays(1))
            {
                VMHoliday _hd = new VMHoliday();
                _hd.HolyDay = _dt;
                _hd.Remarks = _remarks;
                _hldayList.Add(_hd);
            }
        }

        public LeaveApplication GetLeaveApplicationById(long applicationId)
        {
            return new HrCommonRepository().GetLeaveApplicationById(applicationId);
        }

        public void UpdateLeaveApplication(LeaveApplication leaveapp)
        {
            new HrCommonRepository().UpdateLeaveApplication(leaveapp);
        }

        public List<EmpDepartment> GetAllDepartments()
        {
            return new HrCommonRepository().GetAllDepartments();
        }

        //public HRSalaryPolicy GetHrSalaryPolicyById(long empId)
        //{
        //    return new HrCommonRepository().GetHrSalaryPolicyByEmployeeId(empId);
        //}

        public List<EmpDivision> GetAllDivision()
        {
            return new HrCommonRepository().GetAllDivision();
        }

        public List<VMEmployeeInfo> GetEmployeeByName(string ename, string type)
        {
            return new HrCommonRepository().GetEmployeeByName(ename, type);
        }

        public List<EmpDepartment> GetDepartmentsByDivId(int divId)
        {
            return new HrCommonRepository().GetDepartmentsByDivId(divId);
        }

        public JobCirculation GetCircularById(int _circulationId)
        {
            return new HrCommonRepository().GetJobCirculations(_circulationId);
        }

        public JobCV GetJobCVById(int JCvId)
        {
            return new HrCommonRepository().GetJobCVById(JCvId);
        }

        public IList<JobCVDetail> GetJobCvs(JobCirculation _circulation)
        {

            List<JobCV> _cvList = new HrCommonRepository().GetJobCvs(_circulation).ToList();
            List<JobCVDetail> _jcvdetail = new List<JobCVDetail>();

            foreach (var item in _cvList)
            {
                JobCVDetail cvd = new JobCVDetail();
                cvd.IsShorListed = false;
                cvd.JCVId = item.JCVId;
                cvd.JCId = item.JCId;
                cvd.JobCircularNo = _circulation.CirculationNo;
                cvd.Applyfor = item.Applyfor;
                cvd.ApplicatName = item.ApplicatName;
                cvd.ApplicatMobileNo = item.ApplicatMobileNo;
                cvd.FileName = item.FileName;
                cvd.CVInPdf = item.CVInPdf;
                cvd.CVInWord = item.CVInWord;
                cvd.Status = item.Status;
                _jcvdetail.Add(cvd);
            }

            return _jcvdetail;
        }

        public JobCirculation GetJobCirculationById(int _circulationId)
        {
            return new HrCommonRepository().GetJobCirculationById(_circulationId);
        }

        public bool SaveEmployeeEducationalQualification(List<EmployeeEducationalQualification> empEduQualification)
        {
            return new HrCommonRepository().SaveEmployeeEducationalQualification(empEduQualification);
        }

        public DataSet GetShortlistedApplicants(JobCirculation _jc)
        {
            return new HrCommonRepository().GetShortlistedApplicants(_jc);
        }

        public void UpdateCVStatus(List<JobCV> _cvList)
        {
            new HrCommonRepository().UpdateCVStatus(_cvList);
        }

        public JobCV GetJobCvById(int jCVId)
        {
            return new HrCommonRepository().GetJobCvById(jCVId);
        }

        public bool SaveTimedAttendanceLog(List<TimedAttendanceLog> _attLogList)
        {
            return new HrCommonRepository().SaveTimedAttendanceLog(_attLogList);
        }

        public bool SaveGAttLogPullHistory(TimedAttendanceLogPullHistory _pullHistory)
        {
            return new HrCommonRepository().SaveGAttLogPullHistory(_pullHistory);
        }

        public List<EmployeeEducationalQualification> GetEmployeeEducation(long employeeId)
        {
            return new HrCommonRepository().GetEmployeeEducation(employeeId);
        }
    }
}
