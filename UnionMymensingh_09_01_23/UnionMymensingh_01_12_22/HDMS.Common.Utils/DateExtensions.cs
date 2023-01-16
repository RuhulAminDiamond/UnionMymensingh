using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Common.Utils
{
    public static class DateExtensions
    {
        public static bool IsEqualDate(this DateTime thisdate, DateTime? otherDate)
        {
            if (!otherDate.HasValue) return false;
            return thisdate.Year == otherDate.Value.Year
                && thisdate.Month == otherDate.Value.Month
                && thisdate.Day == otherDate.Value.Day;
        }
    }
}
