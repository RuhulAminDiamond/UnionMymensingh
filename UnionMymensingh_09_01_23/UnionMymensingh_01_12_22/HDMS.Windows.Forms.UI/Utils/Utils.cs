using HDMS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using System.Drawing;
using System.IO;
using HDMS.Model.Hospital.ViewModel;
using System.Runtime.InteropServices;

using HDMS.Model.Enums;
using HDMS.Model.Common;

namespace HDMS.Windows.Forms.UI
{
    public static class Utils
    {
        static string sql = string.Empty;
       static SqlConnection con;
       static SqlCommand cmd;
        public static DateTime GetServerDateAndTime(){
            try
            {
                con = new SqlConnection();
                con.ConnectionString = Utility.GetLegacyDbConnectionString();
                con.Open();
                sql = string.Format(@"SELECT GETDATE();");
                cmd = new SqlCommand(sql, con);
                return Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch
            {
                return DateTime.Now;
            }
            finally
            {
                con.Close();
            }

        }

        public static string GetRegNo()
        {
            string _month = GetServerDateAndTime().Month.ToString();
            string _day = GetServerDateAndTime().Day.ToString();

            if (_month.Length == 1) _month = "0" + _month;
            if (_day.Length == 1) _day = "0" + _day;

            string _regpart1 = GetServerDateAndTime().Year.ToString().Substring(2, 2) + _month;//GetServerDateAndTime().Year.ToString().Substring(2,2) + _month + _day;

            return _regpart1;
        }

        public static string GetBillNo()
        {
            string _month = GetServerDateAndTime().Month.ToString();
            string _day = GetServerDateAndTime().Day.ToString();

            if (_month.Length == 1) _month = "0" + _month;
            if (_day.Length == 1) _day = "0" + _day;

            string _regpart1 = GetServerDateAndTime().Year.ToString().Substring(2, 2) + _month;//GetServerDateAndTime().Year.ToString().Substring(2,2) + _month + _day;

            return _regpart1;
        }


        public static double ExecuteAccountHeadIDReorder(int _TopHeadId)
        {
            try
            {
                sql = string.Format(" exec SP_RPT_Acc_Head_Tree_List {0}", _TopHeadId);
                con = new SqlConnection(HDMS.Common.Utils.Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static List<MonthsOfYear> GetMonthsOfYear()
        {
            List<MonthsOfYear> _monthList = new List<MonthsOfYear>();
            _monthList.Add(new MonthsOfYear() { Id = 1, Name = "January" });
            _monthList.Add(new MonthsOfYear() { Id = 2, Name = "February" });
            _monthList.Add(new MonthsOfYear() { Id = 3, Name = "March" });
            _monthList.Add(new MonthsOfYear() { Id = 4, Name = "April" });
            _monthList.Add(new MonthsOfYear() { Id = 5, Name = "May" });
            _monthList.Add(new MonthsOfYear() { Id = 6, Name = "Jun" });
            _monthList.Add(new MonthsOfYear() { Id = 7, Name = "July" });
            _monthList.Add(new MonthsOfYear() { Id = 8, Name = "August" });
            _monthList.Add(new MonthsOfYear() { Id = 9, Name = "September" });
            _monthList.Add(new MonthsOfYear() { Id = 10, Name = "October" });
            _monthList.Add(new MonthsOfYear() { Id = 11, Name = "November" });
            _monthList.Add(new MonthsOfYear() { Id = 12, Name = "December" });

            return _monthList;

        }

        internal static string GetReportStatus(string reportStatus)
        {
            if (reportStatus == ReportStatusEnum.NE.ToString()) return "Order Entry";

            if (reportStatus == ReportStatusEnum.OP.ToString()) return "Order in Progress";

            if (reportStatus == ReportStatusEnum.SC.ToString()) return "Sample Collected";

            if (reportStatus == ReportStatusEnum.SR.ToString()) return "Sample Received";

            if (reportStatus == ReportStatusEnum.SRun.ToString()) return "Sample Running";

            if (reportStatus == ReportStatusEnum.RG.ToString()) return "Result generated";

            if (reportStatus == ReportStatusEnum.RV.ToString()) return "Result Verified.";

            if (reportStatus == ReportStatusEnum.RP.ToString()) return "Report Ready";

            if (reportStatus == ReportStatusEnum.RD.ToString()) return "Report Delivered.";

            return "Unknown";
        }

        public static void VoucherPrint(int VoucherID)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Voucher_Report _rpt = new rptACC_Voucher_Report();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);
            _rpt.SetDatabaseLogon("emsl", "emsl@2018", "SERVER", "EMDIAG", true);

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();






            _rpt.SetParameterValue("@StartDate", "2000-01-01");
            _rpt.SetParameterValue("@EndDate", "2050-01-01");
            _rpt.SetParameterValue("@VoucherID", VoucherID.ToString());
            _rpt.SetParameterValue("@VoucherType", "");









            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = 0;
            rv.crviewer.PrintReport();
            rv.Show();
        }


        public static Image GetProfileImage(long _regNo)
        {
            SqlConnection con = new SqlConnection(Utility.GetImageDbConnectionString());
            MemoryStream stream = new MemoryStream();
            try
            {

                sql = string.Format("select ProfileImage from MemberImages where RegNo={0}", _regNo);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                byte[] b = (byte[])cmd.ExecuteScalar();

                if (b != null)
                {

                    stream.Write(b, 0, b.Length);
                    Bitmap bm = new Bitmap(stream);
                    con.Close();
                    return bm;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
                stream.Close();
            }
        }

        public static byte[] GetProfileImagebyte(long _regNo)
        {
            SqlConnection con = new SqlConnection(Utility.GetImageDbConnectionString());

            try
            {

                sql = string.Format("select ProfileImage from MemberImages where RegNo={0}", _regNo);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                byte[] b = (byte[])cmd.ExecuteScalar();


                return b;
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

        internal static string GetIPDInvestigations(List<VMInvestigationList> _InvestigationList)
        {
            string _test = string.Empty;
            foreach(var item in _InvestigationList)
            {
                if (String.IsNullOrEmpty(_test))
                {
                    _test = item.TestName;
                }else
                {
                    _test = _test+", "+item.TestName;
                }
            }

            return _test;
        }

        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        internal static string GetPatientAddress(string careOf, string _houseNo, string roadNo, string village, string po, string district,string _areaOrThanaha)
        {
            if (district.Contains("Select"))
                district = "";
            if (_areaOrThanaha.Contains("Select"))
                _areaOrThanaha = "";
            string _address = string.Format("{0}{1}{2}{3}{4}{5}{6}'", PrepareAddressString("Care of: ",careOf), PrepareAddressString("House No: ",_houseNo), PrepareAddressString("Road No",roadNo), PrepareAddressString("Village: ",village), PrepareAddressString("PO: ",po), PrepareAddressString("District: ",district), PrepareAddressString("Area/Thana: ",_areaOrThanaha));
            return _address;
        }

        private static string PrepareAddressString(string title, string _value)
        {
            if (!string.IsNullOrEmpty(_value)) return title + _value + ",";

            return "";
        }

        internal static Image GetHRProfileImage(long employeeNo)
        {
            SqlConnection con = new SqlConnection(Utility.GetLegacyDbConnectionString());
            MemoryStream stream = new MemoryStream();
            try
            {

                sql = string.Format("select ProfileImage from EmpProfileImages where EmployeeId={0}", employeeNo);
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                byte[] b = (byte[])cmd.ExecuteScalar();
                if (b != null)
                {
                    stream.Write(b, 0, b.Length);
                    Bitmap bm = new Bitmap(stream);
                    con.Close();
                    return bm;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
                stream.Close();
            }
        }
    }
}
