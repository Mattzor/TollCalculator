using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsPublicHoliday(this DateTime date)
        {
            throw new NotImplementedException();
        }

        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsJuly(this DateTime date)
        {
            return date.Month == 7;
        }

        public static bool IsChristmas(this DateTime date)
        {
            return date.Month == 12 && date.Day >= 24 && date.Day <= 26;
        }

        public static bool IsFirstOfMayOrLastOfApril(this DateTime date)
        {
            return (date.Month == 4 && date.Day == 30) || (date.Month == 5 && date.Day == 1);
        }

        public static bool IsNationalDayOfSwedenOrTheDayBefore(this DateTime date)
        {
            return date.Month == 6 && (date.Day == 5 || date.Day == 6);
        }

    }
}
