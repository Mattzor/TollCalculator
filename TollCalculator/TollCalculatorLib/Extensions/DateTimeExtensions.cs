using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsJuly(this DateTime date)
        {
            return date.Month == 7;
        }

        public static bool IsPublicHoliday(this DateTime date)
        {
            throw new NotImplementedException();
        }

    }
}
