
namespace Business.DTOs.Responses
{
    public class SessionBriefResponse
    {
        public int SessionID { get; set; }

        public CourseOfferingBriefResponse? CourseOffering { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string? Day { get; set; }

        public SessionBriefResponse(int sessionID, CourseOfferingBriefResponse? courseOffering, TimeSpan startTime, TimeSpan endTime, string? day)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }
    }
}
