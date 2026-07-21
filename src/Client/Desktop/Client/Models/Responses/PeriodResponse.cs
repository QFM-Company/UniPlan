namespace Client.Models.Responses
{
    public class PeriodResponse : BaseModel
    {
        public int PeriodID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public PeriodResponse(int periodID, TimeSpan startTime, TimeSpan endTime)
        {
            PeriodID = periodID;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
