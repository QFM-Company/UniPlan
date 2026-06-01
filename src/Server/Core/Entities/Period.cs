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

        public bool Contains(TimeSpan time)
        {
            return time >= StartTime && time < EndTime;
        }

        public bool IsValid()
        {
            return StartTime < EndTime;
        }

        public bool OverlapsWith(Period other)
        {
            if (other == null)
                return false;

            return StartTime < other.EndTime && other.StartTime < EndTime;
        }

        /// <summary>
        ///  if you Need The Minuts just call this method and then .Minutes(int) on the result 
        ///  Same for Hours and Seconds 
        /// </summary>
        /// <returns>TimeSpan The differ between 2 start and End</returns>
        /// <returns>TimeSpan.Zero if The obj is not good</returns>
        public TimeSpan GetDuration()
        {
            if (!IsValid()) return TimeSpan.Zero;

            return EndTime - StartTime;
        }

        public bool IsBefore(Period other)
        {
            return EndTime <= other.StartTime;
        }

        public bool IsAfter(Period other)
        {
            return StartTime >= other.EndTime;
        }
        public override string ToString()
        {
            return $"{StartTime} - {EndTime}";
        }

    }
}
