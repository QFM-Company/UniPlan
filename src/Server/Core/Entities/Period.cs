namespace Core.Entities
{
    public class Period
    {
        public int PeriodID { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public Period(int periodID, TimeSpan startTime, TimeSpan endTime)
        {
            PeriodID = periodID;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Period()
        {
            PeriodID = -1;
            StartTime = default;
            EndTime = default;
        }
    }
}
