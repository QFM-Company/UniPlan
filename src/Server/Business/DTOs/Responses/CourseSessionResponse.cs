namespace Business.DTOs.Responses
{
    public class CourseSessionResponse
    {
        public int SessionID { get; set; }

        public CourseOfferingResponse CourseOffering { get; set; }

        public HallResponse Hall { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int? CreatedByAdminID { get; set; }

        public DayOfWeek Day { get; set; }

        public CourseSessionResponse(int sessionID, CourseOfferingResponse courseOffering, HallResponse hall, TimeSpan startTime, TimeSpan endTime, int? createdByAdminID, DayOfWeek day)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            StartTime = startTime;
            EndTime = endTime;
            CreatedByAdminID = createdByAdminID;
            Day = day;
        }
    }
}
