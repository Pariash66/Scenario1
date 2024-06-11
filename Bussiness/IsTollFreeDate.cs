
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace congestion_tax_calculator_bussiness
{
    public class IsTollFreeDate : IIsTollFreeDate
    {

        private readonly DateTime _date;

        private readonly List<DateTime> _tollFreeDates;
        public IsTollFreeDate(DateTime date)
        {
            _date = date;
            _tollFreeDates = new List<DateTime> {
                new DateTime(2013, 1, 1),
                new DateTime(2013, 3, 28),
                new DateTime(2013, 3, 29),
                new DateTime(2013, 4, 1),
                new DateTime(2013, 4, 30),
                new DateTime(2013, 5, 1),
                new DateTime(2013, 5, 8),
                new DateTime(2013, 5, 9),
                new DateTime(2013, 6, 5),
                new DateTime(2013, 6, 6),
                new DateTime(2013, 6, 21),
                new DateTime(2013, 7, 1),
                new DateTime(2013, 11, 1),
                new DateTime(2013, 12, 24),
                new DateTime(2013, 12, 25),
                new DateTime(2013, 12, 26),
                new DateTime(2013, 12, 31)
            };

        }



        public bool isTollFreeDatefunc()
        {
            try
            {
                bool findfreedate = false;
                bool daysbeforHoliday = false;
                findfreedate = _tollFreeDates.Any(d => d.Date == _date.Date) || _date.Month == 7;
                if (findfreedate) return true;
                foreach (DateTime holidate in _tollFreeDates)
                {
                    IsDaysBefroeHoliday isDaysBefroeHoliday = new IsDaysBefroeHoliday(_date, holidate);
                    daysbeforHoliday = isDaysBefroeHoliday.IsDaysBeforeHoliday();
                    if (daysbeforHoliday) return true;
                }
                return false;
            }
            catch(Exception ex) { throw; }
        }
        //private Boolean IsTollFreeDate(DateTime date)
        //{
        //    int year = date.Year;
        //    int month = date.Month;
        //    int day = date.Day;

        //    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        //    if (year == 2013)
        //    {
        //        if (month == 1 && day == 1 ||
        //            month == 3 && (day == 28 || day == 29) ||
        //            month == 4 && (day == 1 || day == 30) ||
        //            month == 5 && (day == 1 || day == 8 || day == 9) ||
        //            month == 6 && (day == 5 || day == 6 || day == 21) ||
        //            month == 7 ||
        //            month == 11 && day == 1 ||
        //            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
