using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Common.Utils
{
    public class CalculateCabinCharge
    {
        public double CabinCharge(DateTime _admDate,string _admTime, DateTime _releaseDateTime, string _releaseTime, double _cabinCharge)
        {

            return DaysInHospital(_admDate, _admTime, _releaseDateTime, _releaseTime, 0, true,false) * _cabinCharge;
        }

        public int DaysInHospital(DateTime _admDate,string _admTime, DateTime _releaseDateTime, string _releaseTime, double _graceperiod, bool isTransfer, bool isSandwichedhours_Greater_Than_GracePeriod_Considerable)
        {
         

            DateTime dtFrom = DateTime.Parse(_admTime);
            DateTime dtTo = DateTime.Parse(_releaseTime);

            TimeSpan _adspan = dtFrom.TimeOfDay;
            TimeSpan _respan = dtTo.TimeOfDay;

            DateTime newAdmDateTime = _admDate.Date.Add(_adspan);
            DateTime newReleaseDateTime = _releaseDateTime.Date.Add(_respan);

            TimeSpan tspan = newReleaseDateTime.Subtract(newAdmDateTime);

            int days = tspan.Days;
            int hoursInBetween = tspan.Hours;
            int minutes = tspan.Minutes;

            double _hrsfromMin = (double)minutes / (double)60;

            double _sandwithhours = hoursInBetween + _hrsfromMin;


            if (days == 0)
            {
                if (minutes > 30) hoursInBetween = hoursInBetween + 1;

                if (isTransfer && hoursInBetween>0)
                {
                    return 1;
                }


                if (_sandwithhours <= _graceperiod) return 0;

                return 1;

            }
            else
            {
                if (isSandwichedhours_Greater_Than_GracePeriod_Considerable)
                {
                    if (_sandwithhours <= _graceperiod) return days;

                    return days + 1;

                }else
                {
                    return days;
                }

               

               
            }

            return 0;
        }

        public bool IsWithin24Hours(DateTime _admDate, string _admTime, DateTime _releaseDateTime, string _releaseTime,double _gracePeriod)
        {
            DateTime dtFrom = DateTime.Parse(_admTime);
            DateTime dtTo = DateTime.Parse(_releaseTime);

            TimeSpan _adspan = dtFrom.TimeOfDay;
            TimeSpan _respan = dtTo.TimeOfDay;

            DateTime newAdmDateTime = _admDate.Date.Add(_adspan);
            DateTime newReleaseDateTime = _releaseDateTime.Date.Add(_respan);

            TimeSpan tspan = newReleaseDateTime.Subtract(newAdmDateTime);

            int days = tspan.Days;
            int hoursInBetween = tspan.Hours;
            hoursInBetween = hoursInBetween + days*24;

            if ( hoursInBetween <= 24 + _gracePeriod)
            {
                return true;
            }else
            {
                return false;
            }
        }
        
            
        public int GetReleaseDayHours(string _releaseTime)
        {

            DateTime dFrom;
            DateTime dTo;
            string sDateFrom = "00:00:00";
            string sDateTo = _releaseTime;
            if (DateTime.TryParse(sDateFrom, out dFrom) && DateTime.TryParse(sDateTo, out dTo))
            {
                TimeSpan TS = dTo - dFrom;
                int hour = TS.Hours;
                int mins = TS.Minutes;
                int secs = TS.Seconds;

                if (mins > 30) return hour + 1;

                return hour;
            }

            return 0;
        }

        public double GetGracePeriod(DateTime _admissionDate, string _admissionTime)
        {
            string _releaseTime = "12:00:00 AM";
            DateTime _releasedate = _admissionDate.AddDays(1);

            DateTime dtFrom = DateTime.Parse(_admissionTime);
            DateTime dtTo = DateTime.Parse(_releaseTime);

            TimeSpan _adspan = dtFrom.TimeOfDay;
            TimeSpan _respan = dtTo.TimeOfDay;

            DateTime newAdmDateTime = _admissionDate.Date.Add(_adspan);
            DateTime newReleaseDateTime = _releasedate.Date.Add(_respan);

            TimeSpan tspan = newReleaseDateTime.Subtract(newAdmDateTime);

            int days = tspan.Days;
            int hoursInBetween = tspan.Hours;
            int minutes = tspan.Minutes;
            int seconds = tspan.Seconds;

            double _hrsfromMin = (double)minutes / (double)60;
             _hrsfromMin = Math.Round(_hrsfromMin, 4);
            double _hrsfromSec = (double)seconds / (double)3600;
            _hrsfromSec= Math.Round(_hrsfromSec, 4);
            return hoursInBetween + _hrsfromMin+ _hrsfromSec;
        }

        public double GetTimeDistanceInHours(DateTime _admissionDate, string _admissionTime, DateTime _releaseDate, string _releaseTime)
        {
            DateTime dtFrom = DateTime.Parse(_admissionTime);
            DateTime dtTo = DateTime.Parse(_releaseTime);

            TimeSpan _adspan = dtFrom.TimeOfDay;
            TimeSpan _respan = dtTo.TimeOfDay;

            DateTime newAdmDateTime = _admissionDate.Date.Add(_adspan);
            DateTime newReleaseDateTime = _releaseDate.Date.Add(_respan);

            TimeSpan tspan = newReleaseDateTime.Subtract(newAdmDateTime);

            int days = tspan.Days;
            int hoursInBetween = tspan.Hours;
            int minsInBetween = tspan.Minutes;
            double _hrsfromMin = (double)minsInBetween / (double)60;
            _hrsfromMin = Math.Round(_hrsfromMin, 2);

            return days * 24 + hoursInBetween + _hrsfromMin;

        }

        public DateTime GetAccomodateDateAddingGracePeriod(DateTime accomodateDate, string accomodateTime, double _gracePeriod)
        {
            DateTime dtFrom = DateTime.Parse(accomodateTime);
            TimeSpan _adspan = dtFrom.TimeOfDay;
            DateTime newAdmDateTime = accomodateDate.Date.Add(_adspan);

            newAdmDateTime=newAdmDateTime.AddHours(_gracePeriod);

            return newAdmDateTime;
        }

        public DateTime CombinedDateAndTimePart(DateTime accomodateDate, string accomodateTime)
        {
            DateTime dtFrom = DateTime.Parse(accomodateTime);
          

            TimeSpan _adspan = dtFrom.TimeOfDay;
          

            DateTime newAdmDateTime = accomodateDate.Date.Add(_adspan);

            return newAdmDateTime;
        }

        public bool IsWithinFirstBillHour(DateTime admDate, string admTime, DateTime rDate, string rTime)
        {
            throw new NotImplementedException();
        }
    }
}
