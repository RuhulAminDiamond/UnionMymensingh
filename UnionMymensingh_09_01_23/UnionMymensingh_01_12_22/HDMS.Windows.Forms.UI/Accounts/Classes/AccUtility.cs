using HDMS.Common.Utils;
using HDMS.Model.ViewModel;
using HDMS.Service.Accounting;
using HDMS.Windows.Forms.UI.Reports.Accounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Windows.Forms.UI.Classes
{
    public static class AccUtility
    {
        static string sql = string.Empty;
        static SqlConnection con;
        static SqlCommand cmd;
        public static DateTime GetServerDateAndTime()
        {
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


        public static bool ExecuteAccountHeadIDReorder(int _TopHeadId)
        {
            try
            {
                sql = string.Format(" exec SP_RPT_Acc_Head_Tree_List {0}", _TopHeadId);
                con = new SqlConnection(HDMS.Common.Utils.Configuration.ConnectionString);
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void VoucherPrint(long VoucherID)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Voucher_Report _rpt = new rptACC_Voucher_Report();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);
            //  _rpt.SetDatabaseLogon("emsl", "emsl@2018", "SERVER", "EMDIAG", true);

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




        public static void VoucherPrint(long VoucherID, string _voucherHeader)
        {
            ReportViewer rv = new ReportViewer();
            rptACC_Voucher_Report _rpt = new rptACC_Voucher_Report();
            //_rpt.SetDatabaseLogon("sa", "123", "SERVER", "EMDIAG", true);

            // _rpt.SetDatabaseLogon("emsl", "Ems$rbsb007", "SERVER", "BuroLocal", true);

            DataSet ds = new AccountService().GetJournalVoucher(VoucherID);

            //////////Company _company = new ProductService().GetAllCompany().FirstOrDefault();

            //_rpt.SetParameterValue("@StartDate", "2000-01-01");
            //_rpt.SetParameterValue("@EndDate", "2050-01-01");
            //_rpt.SetParameterValue("@VoucherID", VoucherID.ToString());
            //_rpt.SetParameterValue("@VoucherType", "");
            _rpt.SetDataSource(ds.Tables[0]);
            _rpt.SetParameterValue("VoucherHeader", _voucherHeader);

            rv.crviewer.ReportSource = _rpt;
            rv.crviewer.ToolPanelView = 0;
            rv.crviewer.PrintReport();
            rv.Show();
        }

        internal static string GetSPayTo(List<SelectedAccountHeadToVoucher> _accToList)
        {
            string _payto = string.Empty;

            foreach (var item in _accToList)
            {
                if (String.IsNullOrEmpty(_payto))
                {
                    _payto = item.AccountHeadName;
                }
                else
                {
                    _payto = _payto + ", " + item.AccountHeadName;
                }
            }

            return _payto;
        }
    }
}
