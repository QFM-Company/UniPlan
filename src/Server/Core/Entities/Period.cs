using System;

namespace Core.Entities
{
    public class Period
    {
        public int PeriodID { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
