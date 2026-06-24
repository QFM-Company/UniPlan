namespace Core.Entities
{
    public class ScheduleDetail
    {
        public int DetailID { get; set; }

        public GeneratedSchedule Schedule { get; set; }

        public CourseOffering Offering { get; set; }

        public ScheduleDetail()
        {
            DetailID = -1;
            Schedule = new GeneratedSchedule();
            Offering = new CourseOffering();
        }

        public ScheduleDetail(int detailID, GeneratedSchedule schedule, CourseOffering offering)
        {
            DetailID = detailID;
            Schedule = schedule;
            Offering = offering;
        }
    }
}
