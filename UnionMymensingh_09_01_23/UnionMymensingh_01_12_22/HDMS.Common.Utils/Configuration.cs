using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Common.Utils
{
    public static class Configuration
    {
        private const string _DATE_TIME_FORMAT = "DATE_TIME_FORMAT";
        private const string _ConnectionString = "DBEntities";
        private const string _OrgCode = "ORG_CODE";

        public static string DATE_TIME_FORMAT {
        get
            {
                return ConfigurationManager.AppSettings.Get(_DATE_TIME_FORMAT);
            }
        }

        public static string ORG_CODE
        {
            get
            {
                return ConfigurationManager.AppSettings.Get(_OrgCode);
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[_ConnectionString].ToString();
            }
        }
    }
}
