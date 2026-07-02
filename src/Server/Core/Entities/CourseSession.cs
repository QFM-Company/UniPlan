namespace Core.Entities
{
    public class CourseSession
    {
        public int SessionID { get; set; }

        public CourseOffering CourseOffering { get; set; }

        public Hall Hall { get; set; }

        public TimeSlot? TimeSlot { get; set; }

        public int CreatedByAdminID { get; set; }

        public CourseSession(int sessionID, CourseOffering courseOffering, Hall hall, TimeSlot timeSlot, int createdByAdminID)
        {
            SessionID = sessionID;
            CourseOffering = courseOffering;
            Hall = hall;
            TimeSlot = timeSlot;
            CreatedByAdminID = createdByAdminID;
        }

        public CourseSession()
        {
            SessionID = -1;
            CourseOffering = new CourseOffering();
            Hall = new Hall();
            TimeSlot = new TimeSlot();
            CreatedByAdminID = -1;
        }
    }
}
