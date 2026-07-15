namespace Core.Entities
{
    public class CourseSession
    {
        public int SessionID { get; set; }

        public CourseOffering? CourseOffering { get; set; }

        public Hall? Hall { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int CreatedByAdminID { get; set; }

        public DayOfWeek Day { get; set; }

        public CourseSession(int sessionID, CourseOffering courseOffering, Hall hall, TimeSpan startTime, TimeSpan endTime, int createdByAdminID, DayOfWeek day)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            StartTime = startTime;
            EndTime = endTime;
            CreatedByAdminID = createdByAdminID;
            Day = day;
        }
     
        public CourseSession(int sessionID, TimeSpan startTime, TimeSpan endTime, DayOfWeek day)
        {
            SessionID = sessionID;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }

        public bool OverlapsWith(CourseSession other)
        {
            return Day == other?.Day && StartTime < other.EndTime && other.StartTime < EndTime;
        }

        public override string ToString()
        {
            return string.Format("{0}\nاليوم: {1}\nبداية المحاضرة: {2}\nنهاية المحاضرة: {3}", CourseOffering
                , Day , StartTime , EndTime
                );
        }
    }
}
