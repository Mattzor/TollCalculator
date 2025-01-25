using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculatorLib.Model;

namespace TollCalculatorLib
{
    public static class Constants
    {
        public static readonly List<TollInterval> TollIntervals =
        [
            new TollInterval(new TimeSpan(6, 0, 0), new TimeSpan(6, 29, 59), 8),
            new TollInterval(new TimeSpan(6, 30, 0), new TimeSpan(6, 59, 59), 13),
            new TollInterval(new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 59), 18),
            new TollInterval(new TimeSpan(8, 0, 0), new TimeSpan(8, 29, 59), 13),
            new TollInterval(new TimeSpan(8, 30, 0), new TimeSpan(14, 59, 59), 8),
            new TollInterval(new TimeSpan(15, 0, 0), new TimeSpan(15, 29, 59), 13),
            new TollInterval(new TimeSpan(15, 30, 0), new TimeSpan(16, 59, 59), 18),
            new TollInterval(new TimeSpan(17, 0, 0), new TimeSpan(17, 59, 59), 13),
            new TollInterval(new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 59), 8)
        ];
    }
}
