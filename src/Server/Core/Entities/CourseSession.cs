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
        public bool OverlapsWith(CourseSession other)
        {
            return Day == other.Day && StartTime < other.EndTime && other.StartTime < EndTime;
        }


        public bool ContainsTime(DayOfWeek day, TimeSpan time)
        {
            return Day == day && time >= StartTime && time < EndTime;
        }
        
        public CourseSession(int sessionID, TimeSpan startTime, TimeSpan endTime, DayOfWeek day)
        {
            SessionID = sessionID;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }
    }
}
