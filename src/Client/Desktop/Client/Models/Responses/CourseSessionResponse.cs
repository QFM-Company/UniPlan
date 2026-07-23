namespace Client.Models.Responses
{
    public class CourseSessionResponse : Person
    {
        public int SessionID { get; set; }

        public CourseOfferingResponse? CourseOffering { get; set; }

        public HallResponse? Hall { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int? CreatedByAdminID { get; set; }

        public string Day { get; set; }

        public CourseSessionResponse(int sessionID, CourseOfferingResponse? courseOffering, HallResponse? hall, TimeSpan startTime, TimeSpan endTime, int? createdByAdminID, string day)
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
