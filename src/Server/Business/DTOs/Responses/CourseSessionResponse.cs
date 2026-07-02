namespace Business.DTOs.Responses
{
    public class CourseSessionResponse
    {
        public int SessionID { get; set; }

        public CourseOfferingResponse CourseOffering { get; set; }

        public HallResponse Hall { get; set; }

        public TimeSlotResponse? TimeSlot { get; set; }

        public int? CreatedByAdminID { get; set; }

        public CourseSessionResponse(int sessionID, CourseOfferingResponse courseOffering, HallResponse hall, TimeSlotResponse? timeSlot, int createdByAdminID)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
            CreatedByAdminID = createdByAdminID;
        }
    }
}
