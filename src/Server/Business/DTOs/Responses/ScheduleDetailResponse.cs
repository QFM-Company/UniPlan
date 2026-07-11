namespace Business.DTOs.Responses
{
    public class ScheduleDetailResponse
    {
        public int ScheduleID { get; set; }

        public List<SessionBriefResponse>? Sessions { get; set; }

        public ScheduleDetailResponse(int scheduleID, List<SessionBriefResponse>? sessions)
        {
            ScheduleID = scheduleID;
            Sessions = sessions;
        }
    }
}
