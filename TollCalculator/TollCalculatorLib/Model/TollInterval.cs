using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Model
{
    public class TollInterval
    {
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }
        public int Fee { get; }

        public TollInterval(TimeSpan startTime, TimeSpan endTime, int fee)
        {
            StartTime = startTime;
            EndTime = endTime;
            Fee = fee;
        }

        public bool IsInInterval(DateTime time)
        {
            return time.TimeOfDay >= StartTime && time.TimeOfDay <= EndTime;
        }
    }
}
