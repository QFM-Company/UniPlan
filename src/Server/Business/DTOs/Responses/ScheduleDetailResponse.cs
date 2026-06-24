namespace Business.DTOs.Responses
{
    public class ScheduleDetailResponse
    {
        public int DetailID { get; set; }

        public GeneratedScheduleResponse ScheduleInfo { get; set; }

        public CourseOfferingResponse OfferingInfo { get; set; }

        public ScheduleDetailResponse()
        {
            DetailID = -1;
            ScheduleInfo = new GeneratedScheduleResponse();
            OfferingInfo = new CourseOfferingResponse();
        }

        public ScheduleDetailResponse(int detailID, GeneratedScheduleResponse scheduleInfo, CourseOfferingResponse offeringInfo)
        {
            DetailID = detailID;
            ScheduleInfo = scheduleInfo;
            OfferingInfo = offeringInfo;
        }
    }
}
